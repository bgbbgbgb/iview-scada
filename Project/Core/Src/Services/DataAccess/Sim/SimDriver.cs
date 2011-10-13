
namespace Aimirim.iView
{
	using System;
	using System.ComponentModel;
	using System.Windows.Forms;
	using System.Xml;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	
	public class SimDriver: AbstractDriver
	{
		#region FIELDS
		private object _thisLock;
		private Dictionary<SimAddress, string> _addrList;
		private SimUserControl _control;
		private XmlDocument _xmlDocument;
		#endregion

		#region PROPERTIES
		public override string Name
		{
			get
			{
				return "Simulation";
			}
		}
		public override string Description
		{
			get
			{
				return "Simulator driver";
			}
		}
		public override UserControl Control
		{
			get
			{
				if (_control == null)
				{
					_control = new SimUserControl();
				}
				return _control;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public SimDriver(XmlDocument xmlDocument)
		{
			_xmlDocument = xmlDocument;
			_id = "998C338B-2FB7-4780-8DF6-FF1531EC0DA6";
			_addrList = new Dictionary<SimAddress, string>();
			_thisLock = new object();
			_autoCreateAddr = true;
			
			ReadXml();
		}
		#endregion
		
		#region METHODS
		public override string ToString()
		{
			return string.Format(Name);
		}
		
		public override string GetValue(string itemName)
		{
			if (!ServiceManager.DesignMode)
			{
				lock(_thisLock)
				{
					string val = null;
					SimAddress addr = Find(itemName);
					if (addr != null)
					{
						val = _addrList[addr];
					}
					else if (addr == null && AutoCreateAddr)
					{
						Add(itemName);
						val = _addrList[Find(itemName)];
					}

					return val;
				}
			}
			else
			{
				return string.Empty;
			}
		}
		public override void SetValue(string itemName, string value)
		{
			if (!ServiceManager.DesignMode)
			{
				lock(_thisLock)
				{
					Console.Out.WriteLine(itemName + " " + value);

					SimAddress addr = Find(itemName);
					if (addr != null)
					{
						_addrList[addr] = value;
						OnDataChanged(new DataChangedEventArgs(itemName, value));
					}
					else if (addr == null && AutoCreateAddr)
					{
						Add(itemName);
						_addrList[Find(itemName)] = value;
						OnDataChanged(new DataChangedEventArgs(itemName, value));
					}
				}
			}
		}
		
		public override void Add(string itemName)
		{
			lock (_addrList)
			{
				SimAddress addr = new SimAddress();
				addr.ItemName = itemName;
				_addrList.Add(addr, "0");

				WriteXml();
			}
		}
		public override void Remove(string itemName)
		{
			lock (_addrList)
			{
				SimAddress addr = Find(itemName);
				if (addr != null)
				{
					_addrList.Remove(addr);
				}
				WriteXml();
			}
		}
		
		public override void ReadXml()
		{
			if (!ServiceManager.DesignMode)
			{
				XmlElement docRoot = _xmlDocument.DocumentElement;
				foreach (XmlNode driverNode in docRoot.ChildNodes)
				{
					if (driverNode.Attributes["Id"].Value.Equals("998C338B-2FB7-4780-8DF6-FF1531EC0DA6"))
					{
						foreach (XmlNode itemNode in driverNode.ChildNodes)
						{
							Add(itemNode.Attributes["Name"].Value);
							SimAddress addr = Find(itemNode.Attributes["Name"].Value);
						}
					}
				}
			}
		}
		public override void WriteXml()
		{
		}
		
		public override void Dispose()
		{
		}
		public override void Refresh()
		{
		}

		public SimAddress Find(string itemName)
		{
			foreach (KeyValuePair<SimAddress, string> kvp in _addrList)
			{
				if (kvp.Key.ItemName == itemName)
				{
					return kvp.Key;
				}
			}
			
			return null;
		}
		public List<SimAddress> GetAddressList()
		{
			return _addrList.Keys.ToList();
		}
		#endregion
	}
}

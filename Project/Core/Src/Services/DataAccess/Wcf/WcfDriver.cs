using System.ServiceModel;

namespace Aimirim.iView
{
	using System;
	using System.ComponentModel;
	using System.Windows.Forms;
	using System.Xml;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	
	public class WcfDriver: AbstractDriver, IMessageCallback
	{
		#region FIELDS
		private object _thisLock;
		private WcfUserControl _control;
		private XmlDocument _xmlDocument;
		private MessageClient messageClient;
		#endregion

		#region PROPERTIES
		public override string Name
		{
			get
			{
				return "WCF Connection";
			}
		}
		public override string Description
		{
			get
			{
				return "WCF Client";
			}
		}
		public override UserControl Control
		{
			get
			{
				if (_control == null)
				{
					_control = new WcfUserControl();
				}
				return _control;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public WcfDriver(XmlDocument xmlDocument)
		{
			_xmlDocument = xmlDocument;
			_id = "FE9E907F-2186-4186-B5EA-53B7609303C0";
			_thisLock = new object();
//			_configFileName = Path.Combine(DriverManager.ConfigFilePath, _configFileName);
			
			ReadXml();
			
			if (!ServiceManager.DesignMode)
			{
				InstanceContext context = new InstanceContext(this);
				messageClient = new MessageClient(context, "WSDualHttpBinding_IMessage");
				messageClient.Subscribe();
			}
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
					return string.Empty;
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
//					Console.Out.WriteLine(itemName + " " + value);
//
//					WcfAddress addr = Find(itemName);
//					if (addr != null)
//					{
//						_addrList[addr] = value;
//						OnDataChanged(new DataChangedEventArgs(itemName, value));
//					}
//					else if (addr == null && AutoCreateAddr)
//					{
//						Add(itemName);
//						_addrList[Find(itemName)] = value;
//						OnDataChanged(new DataChangedEventArgs(itemName, value));
//					}
				}
			}
		}
		
		public override void Add(string itemName)
		{
//			lock (_addrList)
//			{
//				WcfAddress addr = new WcfAddress();
//				addr.ItemName = itemName;
//				_addrList.Add(addr, "0");
//
//				WriteXml();
//			}
		}
		public override void Remove(string itemName)
		{
//			lock (_addrList)
//			{
//				WcfAddress addr = Find(itemName);
//				if (addr != null)
//				{
//					_addrList.Remove(addr);
//				}
//				WriteXml();
//			}
		}
		
		public override void ReadXml()
		{
//			if (!ServiceManager.DesignMode)
//			{
//				XmlElement docRoot = _xmlDocument.DocumentElement;
//				foreach (XmlNode driverNode in docRoot.ChildNodes)
//				{
//					if (driverNode.Attributes["Id"].Value.Equals("998C338B-2FB7-4780-8DF6-FF1531EC0DA6"))
//					{
//						foreach (XmlNode itemNode in driverNode.ChildNodes)
//						{
//							Add(itemNode.Attributes["Name"].Value);
//							WcfAddress addr = Find(itemNode.Attributes["Name"].Value);
//						}
//					}
//				}
//			}
		}
		public override void WriteXml()
		{
		}
		
		public override void Dispose()
		{
			messageClient.Close();
		}
		public override void Refresh()
		{
		}

		public void OnMessageAdded(string[] message, DateTime timestamp)
		{
			foreach (string msg in message)
			{
				string itemName = msg.Split('|')[0];
				string value = msg.Split('|')[1];
				
				Console.WriteLine(">>> Received "+ itemName + " " + value);
				OnDataChanged(new DataChangedEventArgs(itemName, value));
				//Console.WriteLine("<<< Recieved {0} with a timestamp of {1}", msg, timestamp);
			}
		}
		#endregion
	}
}

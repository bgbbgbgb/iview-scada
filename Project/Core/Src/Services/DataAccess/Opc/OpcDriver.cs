using System.Threading;
using System.Timers;
using System.Windows.Forms;

using Opc;
using Opc.Da;

namespace Aimirim.iView
{
	using System;
	using System.Text;
	using System.ComponentModel;
	using System.Xml;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	
	public class OpcDriver: AbstractDriver
	{
		#region FIELDS
		private object _thisLock;
		private List<OpcAddress> _addrList;
		private OpcUserControl _control;
		private int _subsCount = 0;
		
		private Opc.Da.Server _opcDaServer;
		private BackgroundWorker _backgroundWorker = new BackgroundWorker();
		private System.Windows.Forms.Timer _timerRefresh = new System.Windows.Forms.Timer();
		
		private XmlDocument _xmlDocument;
		#endregion

		#region PROPERTIES
		public override string Name
		{
			get
			{
				return "OPC Comunication";
			}
		}
		public override string Description
		{
			get
			{
				return "OPC driver";
			}
		}
		public override UserControl Control
		{
			get
			{
				if (_control == null)
				{
					_control = new OpcUserControl();
				}
				return _control;
			}
		}
		public URL Url
		{
			get
			{
				return _opcDaServer.Url;
			}
		}
		public SubscriptionCollection Subscriptions
		{
			get
			{
				return _opcDaServer.Subscriptions;
			}
		}
		public string ServerName
		{
			get
			{
				return _opcDaServer.Name;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public OpcDriver(XmlDocument xmlDocument)
		{
			_xmlDocument = xmlDocument;
			_id = "6A1B8105-BD9A-4658-870F-D35D4029C928";
			_addrList = new List<OpcAddress>();
			_thisLock = new object();
			_autoCreateAddr = true;
			
			if (!ServiceManager.DesignMode)
			{
				Connect();
				ReadXml();
				Refresh();

				_backgroundWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
				{
					Refresh();
				};
				_backgroundWorker.RunWorkerCompleted += delegate { _timerRefresh.Start(); };

				_timerRefresh.Tick += delegate
				{
					_timerRefresh.Stop();
					_backgroundWorker.RunWorkerAsync();
				};

				_timerRefresh.Interval = 1000;
				_timerRefresh.Start();
			}
		}
		#endregion
		
		#region METHODS
		private void OpcDataChanged(object subscriptionHandle, object requestHandle, Opc.Da.ItemValueResult[] values)
		{
//			foreach (Opc.Da.ItemValueResult ivr in values)
//			{
//				OpcAddress addr = Find(ivr.ItemName);
//				if (addr.Value != ivr.Value.ToString())
//				{
//					addr.SetValue(ivr.Value.ToString());
//					OnDataChanged(new DataChangedEventArgs(ivr.ItemName, ivr.Value));
//				}
//			}
		}

		public override string ToString()
		{
			return string.Format(Name);
		}
		
		public override string GetValue(string itemName)
		{
			if (!ServiceManager.DesignMode && _opcDaServer.IsConnected)
			{
				string val = null;
				OpcAddress addr = Find(itemName);
				if (addr != null)
				{
					val = addr.Value;
				}
				else if (addr == null && AutoCreateAddr)
				{
					Add(itemName);
					addr = Find(itemName);
					val = addr.GetValue();
				}

				if (val == null)
				{
					val = addr.GetValue();
					if (val != null)
					{
						addr.SetValue(val);
					}
					else
					{
						val = string.Empty;
					}
				}
				return val;
			}
			else
			{
				return string.Empty;
			}
		}
		public override void SetValue(string itemName, string value)
		{
			if (!ServiceManager.DesignMode && _opcDaServer.IsConnected)
			{
				OpcAddress addr = Find(itemName);
				if (addr != null)
				{
					addr.Value = value;
				}
				else if (addr == null && AutoCreateAddr)
				{
					Add(itemName);
					addr = Find(itemName);
					addr.Value = value;
				}
			}
		}
		
		public override void Add(string itemName)
		{
			lock(_thisLock)
			{
				try
				{
					OpcAddress addr = Find(itemName);
					
					if (addr == null)
					{
						string[] itemIdSplited = itemName.Split(']');
						string[] addressSplited;
						string topic = "";
						
						//Encontra o nome do topico
						if (itemName.Contains(']')) {
							topic = itemName.Split(']')[0].Substring(1);
						}
						
						if (itemIdSplited.Length > 1)
						{
							addressSplited = itemIdSplited[1].Split(':');
						}
						else
						{
							itemIdSplited = itemName.Split('.');
							addressSplited = itemIdSplited[2].Split(':');
						}
						
						Opc.Da.Subscription opcDaGroup = null;
						foreach (Opc.Da.Subscription opcDaGrp in _opcDaServer.Subscriptions)
						{
							if (opcDaGrp.Name == topic + addressSplited[0])
							{
								opcDaGroup = opcDaGrp;
							}
						}

						if (opcDaGroup == null)
						{
							Opc.Da.SubscriptionState groupState = new Opc.Da.SubscriptionState();
							groupState.ClientHandle = Guid.NewGuid().ToString();
							groupState.Name = topic + addressSplited[0];
//							groupState.UpdateRate = 100;
							
							opcDaGroup = (Opc.Da.Subscription)_opcDaServer.CreateSubscription(groupState);
							//opcDaGroup.DataChanged += new Opc.Da.DataChangedEventHandler(OpcDataChanged);
							opcDaGroup.DataChanged += delegate(object subscriptionHandle, object requestHandle, ItemValueResult[] values)
							{
								foreach (Opc.Da.ItemValueResult ivr in values)
								{
									OpcAddress adr = Find(ivr.ItemName);
									adr.SetValue(ivr.Value.ToString());
									OnDataChanged(new DataChangedEventArgs(ivr.ItemName, ivr.Value));
								}
							};
						}

						Opc.Da.Item opcDaItem = new Opc.Da.Item();
						opcDaItem.ClientHandle = Guid.NewGuid().ToString();
						opcDaItem.ItemName = itemName;
//						opcDaItem.MaxAgeSpecified = true;
//						opcDaItem.MaxAge = 10;
//						opcDaItem.SamplingRateSpecified = true;
//						opcDaItem.SamplingRate = 100;
						
						opcDaGroup.AddItems(new Opc.Da.Item[] { opcDaItem });

						addr = new OpcAddress(opcDaItem, opcDaGroup);
						_addrList.Add(addr);
					}

					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return;
				}
			}
		}
		public override void Remove(string itemName)
		{
			lock (_thisLock)
			{
				OpcAddress addr = Find(itemName);
				if (addr != null)
				{
					_addrList.Remove(addr);
				}
			}
		}
		
		public override void ReadXml()
		{
			XmlElement docRoot = _xmlDocument.DocumentElement;
			foreach (XmlNode driverNode in docRoot.ChildNodes)
			{
				if (driverNode.Attributes["Id"].Value.Equals("6A1B8105-BD9A-4658-870F-D35D4029C928"))
				{
					foreach (XmlNode itemNode in driverNode.ChildNodes)
					{
						Add(itemNode.Attributes["Name"].Value);
					}
				}
			}
		}
		public override void WriteXml()
		{
			XmlElement docRoot = _xmlDocument.DocumentElement;
			foreach (XmlNode driverNode in docRoot.ChildNodes)
			{
				if (driverNode.Attributes["Id"].Value.Equals("6A1B8105-BD9A-4658-870F-D35D4029C928"))
				{
					foreach (OpcAddress addr in _addrList)
					{
						XmlElement itemElement = _xmlDocument.CreateElement("Item");
						itemElement.SetAttribute("Name", addr.ItemName);
						driverNode.AppendChild(itemElement);
					}
				}
			}
			_xmlDocument.Save("DriverDatabase.ddb");
		}
		
		public override void Dispose()
		{
			if (!ServiceManager.DesignMode)
			{
				//WriteXml();
				
				if (_opcDaServer != null && _opcDaServer.IsConnected)
				{
					_opcDaServer.Disconnect();
					_opcDaServer.Dispose();
				}
			}
		}
		public override void Refresh()
		{
			try
			{
//				foreach (Subscription sub in _opcDaServer.Subscriptions)
//				{
//					sub.Refresh();
//				}

//				if (_opcDaServer.Subscriptions.Count > 0)
//				{
//					_opcDaServer.Subscriptions[_subsCount].Refresh();
//					_subsCount++;
//
//					if (_subsCount == _opcDaServer.Subscriptions.Count)
//					{
//						_subsCount = 0;
//					}
//
//				}
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message);
			}
		}

		public void Connect()
		{
			try
			{
				XmlElement docRoot = _xmlDocument.DocumentElement;
				foreach (XmlNode driverNode in docRoot.ChildNodes)
				{
					if (driverNode.Attributes["Id"].Value.Equals("6A1B8105-BD9A-4658-870F-D35D4029C928"))
					{
						OpcCom.Factory fact = new OpcCom.Factory();
						_opcDaServer = new Opc.Da.Server(fact, null);

						Opc.URL url = new Opc.URL(driverNode.Attributes["OpcServerUrl"].Value);
						_opcDaServer.Connect(url, new Opc.ConnectData(new System.Net.NetworkCredential()));
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		public OpcAddress Find(string itemName)
		{
			return _addrList.Find(delegate(OpcAddress opcAddr) {return opcAddr.ItemName.Equals(itemName);});
		}
		#endregion
	}
}

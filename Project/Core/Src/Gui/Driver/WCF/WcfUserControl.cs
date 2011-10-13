using System.ComponentModel;
using System.Data;
using System.Xml;
using System;
using System.IO;
using System.Windows.Forms;

namespace Aimirim.iView
{

	public partial class WcfUserControl : UserControl, IDriverControl
	{
		#region FIELDS
		private WcfDriver _driver;
		#endregion

		#region PROPERTIES
		#endregion
		
		#region CONSTRUCTORS
		public WcfUserControl()
		{
			InitializeComponent();

			_driver = DriverManager.Instance.GetDriver("FE9E907F-2186-4186-B5EA-53B7609303C0") as WcfDriver;
		}
		#endregion

		#region METHODS
		protected void OnDataChanged(EventArgs e)
		{
			if (_dataChanged != null)
			{
				_dataChanged(this, e);
			}
		}
		public void Load(XmlDocument xmlDocument)
		{
			XmlElement docRoot = xmlDocument.DocumentElement;
			foreach (XmlNode driverNode in docRoot.ChildNodes)
			{
				if (driverNode.Attributes["Id"].Value.Equals("FE9E907F-2186-4186-B5EA-53B7609303C0"))
				{
					foreach (XmlNode itemNode in driverNode.ChildNodes)
					{
//						SimAddress row = _bs.AddNew() as SimAddress;
//						row.ItemName = itemNode.Attributes["Name"].Value;
//						_bs.EndEdit();
					}
				}
			}
		}
		public void Save(XmlDocument xmlDocument)
		{
			XmlElement docElement = xmlDocument.DocumentElement;
			XmlElement drvElement = xmlDocument.CreateElement("Driver");
			
			drvElement.SetAttribute("Id", "FE9E907F-2186-4186-B5EA-53B7609303C0");
			docElement.AppendChild(drvElement);
			
//			foreach (SimAddress addr in bList)
//			{
//				if (addr.ItemName != "")
//				{
//					XmlElement itemElement = xmlDocument.CreateElement("Item");
//					itemElement.SetAttribute("Name", addr.ItemName);
//					drvElement.AppendChild(itemElement);
//				}
//			}
		}
		#endregion

		#region EVENTS
		protected event EventHandler _dataChanged;
		public event EventHandler DataChanged
		{
			add
			{
				_dataChanged += value;
			}
			remove
			{
				_dataChanged -= value;
			}
		}
		#endregion
	}
}

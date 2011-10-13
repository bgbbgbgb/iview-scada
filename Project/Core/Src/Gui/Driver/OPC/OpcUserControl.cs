using System.ComponentModel;
using System.Data;
using System.Xml;
using System;
using System.IO;
using System.Windows.Forms;
using Opc;
using Opc.Da;

namespace Aimirim.iView
{

	internal partial class OpcUserControl : UserControl, IDriverControl
	{
		#region FIELDS
		private BindingSource _bs = new BindingSource();
		private OpcDriver _driver;
		private BindingList<OpcAddress> bList;
		#endregion 
		
		#region PROPERTIES
		#endregion

		#region CONSTRUCTORS
		public OpcUserControl()
		{
			InitializeComponent();
			
			_driver = DriverManager.Instance.GetDriver("6A1B8105-BD9A-4658-870F-D35D4029C928") as OpcDriver;

			bList = new BindingList<OpcAddress>();
			_bs.DataSource = bList;
			dataGridView.DataSource = _bs;
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
			_bs.Clear();
			XmlElement docRoot = xmlDocument.DocumentElement;
			foreach (XmlNode driverNode in docRoot.ChildNodes)
			{
				if (driverNode.Attributes["Id"].Value.Equals("6A1B8105-BD9A-4658-870F-D35D4029C928"))
				{
					txbOpcServerUrl.Text = driverNode.Attributes["OpcServerUrl"].Value;
					
					foreach (XmlNode itemNode in driverNode.ChildNodes)
					{
						OpcAddress row = _bs.AddNew() as OpcAddress;
						row.ItemName = itemNode.Attributes["Name"].Value;
						_bs.EndEdit();
					}
				}
			}
			
			_bs.ListChanged += delegate { OnDataChanged(EventArgs.Empty); };
			txbOpcServerUrl.TextChanged += delegate { OnDataChanged(EventArgs.Empty); };
		}
		public void Save(XmlDocument xmlDocument)
		{
			XmlElement docElement = xmlDocument.DocumentElement;
			XmlElement drvElement = xmlDocument.CreateElement("Driver");
			
			drvElement.SetAttribute("Id", "6A1B8105-BD9A-4658-870F-D35D4029C928");
			drvElement.SetAttribute("OpcServerUrl", txbOpcServerUrl.Text);
			
			docElement.AppendChild(drvElement);
			
			foreach (OpcAddress addr in bList)
			{
				if (addr.ItemName.Trim().Length > 0)
				{
					XmlElement itemElement = xmlDocument.CreateElement("Item");
					itemElement.SetAttribute("Name", addr.ItemName);
					drvElement.AppendChild(itemElement);
				}
			}
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

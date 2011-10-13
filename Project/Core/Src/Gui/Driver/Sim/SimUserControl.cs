using System.ComponentModel;
using System.Data;
using System.Xml;
using System;
using System.IO;
using System.Windows.Forms;

namespace Aimirim.iView
{

	public partial class SimUserControl : UserControl, IDriverControl
	{
		#region FIELDS
		private BindingSource _bs = new BindingSource();
		private SimDriver _driver;
		private BindingList<SimAddress> bList;
		#endregion

		#region PROPERTIES
		#endregion
		
		#region CONSTRUCTORS
		public SimUserControl()
		{
			InitializeComponent();

			_driver = DriverManager.Instance.GetDriver("998C338B-2FB7-4780-8DF6-FF1531EC0DA6") as SimDriver;
			
			bList = new BindingList<SimAddress>();
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
				if (driverNode.Attributes["Id"].Value.Equals("998C338B-2FB7-4780-8DF6-FF1531EC0DA6"))
				{
					foreach (XmlNode itemNode in driverNode.ChildNodes)
					{
						SimAddress row = _bs.AddNew() as SimAddress;
						row.ItemName = itemNode.Attributes["Name"].Value;
						_bs.EndEdit();
					}
				}
			}
			
			_bs.ListChanged += delegate { OnDataChanged(EventArgs.Empty); };
		}
		public void Save(XmlDocument xmlDocument)
		{
			XmlElement docElement = xmlDocument.DocumentElement;
			XmlElement drvElement = xmlDocument.CreateElement("Driver");
			
			drvElement.SetAttribute("Id", "998C338B-2FB7-4780-8DF6-FF1531EC0DA6");
			docElement.AppendChild(drvElement);
			
			foreach (SimAddress addr in bList)
			{
				if (addr.ItemName != "")
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

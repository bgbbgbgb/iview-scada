using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

using ICSharpCode.SharpDevelop.Gui;

namespace Aimirim.iView
{
	public partial class DriverUserControl : UserControl
	{
		#region FIELDS
		private IViewContent _viewContent;
		#endregion

		#region PROPERTIES
		#endregion

		#region CONSTRUCTORS
		public DriverUserControl(IViewContent viewContent)
		{
			_viewContent = viewContent;
			
			InitializeComponent();
			CreateDriverTab();
		}
		#endregion

		#region METHODS
		private void CreateDriverTab()
		{
			foreach (IDriver drv in DriverManager.Instance.Drivers)
			{
				TabPage tab = new TabPage(drv.Name);
				
				IDriverControl drvControl = drv.Control as IDriverControl;
				drvControl.DataChanged += delegate
				{
					if (_viewContent.PrimaryFile != null)
					{
						_viewContent.PrimaryFile.MakeDirty();
					}
				};
				
				tab.Controls.Add(drv.Control);
				drv.Control.Dock = DockStyle.Fill;
				tabControl.TabPages.Add(tab);
			}
		}
		public void Load(Stream fileStream)
		{
			XmlDocument xmlDocument = null;
			StreamReader fileStreamReader = null;

			//
			xmlDocument = new XmlDocument();
			fileStreamReader = new StreamReader(fileStream);

			xmlDocument.Load(fileStreamReader);

			foreach (IDriver drv in DriverManager.Instance.Drivers)
			{
				IDriverControl drvControl = drv.Control as IDriverControl;
				drvControl.Load(xmlDocument);
			}
		}
		public void Save(Stream fileStream)
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement docElement = xmlDocument.CreateElement("DocumentElement");
			xmlDocument.AppendChild(docElement);
			
			foreach (IDriver drv in DriverManager.Instance.Drivers)
			{
				IDriverControl drvControl = drv.Control as IDriverControl;
				drvControl.Save(xmlDocument);
			}
			
			//
			xmlDocument.Save(fileStream);
		}
		#endregion
	}
}

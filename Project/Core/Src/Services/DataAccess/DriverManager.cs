
namespace Aimirim.iView
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Windows.Forms;
	using System.Xml;
	using System.Diagnostics;
	using System.Reflection;
	using System.Collections;
	using System.ComponentModel;
	using System.Xml.XPath;

	public sealed class DriverManager
	{
		#region FIELDS
		// statics
		private static object _thisLock = new object();
		private static DriverManager _instance;
		
		// instances
		private List<IDriver> _drivers = new List<IDriver>();
		#endregion

		#region PROPERTIES
		public static DriverManager Instance
		{
			get
			{
				lock (_thisLock)
				{
					if (_instance == null)
					{
						_instance = new DriverManager();
					}
					return _instance;
				}
			}
			set
			{
				_instance = value;
			}
		}
		public static string ConfigFilePath
		{
			get
			{
				return System.Configuration.ConfigurationSettings.AppSettings["DriverDatabase"];
			}
		}

		public List<IDriver> Drivers
		{
			get
			{
				return _drivers;
			}
		}
		#endregion

		#region CONSTRUCTORS
		private DriverManager()
		{
			XmlDocument xmlDocument = null;
			if (!ServiceManager.DesignMode)
			{
				try
				{
					xmlDocument = new XmlDocument();
					xmlDocument.Load(ConfigFilePath);

					if (!ServiceManager.IsClient)
					{
						_drivers.Add(new SimDriver(xmlDocument));
						_drivers.Add(new OpcDriver(xmlDocument));
					}
					else
					{
						_drivers.Add(new WcfDriver(xmlDocument));
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				_drivers.Add(new SimDriver(xmlDocument));
				_drivers.Add(new OpcDriver(xmlDocument));
			}
		}
		~DriverManager()
		{
			Unload();
		}
		#endregion

		#region METHODS
		public IDriver GetDriver(string id)
		{
			return _drivers.Find(delegate(IDriver drv) {return drv.Id == id;});
		}
		public static void Unload()
		{
			foreach (AbstractDriver drv in Instance.Drivers)
			{
				drv.Dispose();
			}
			_instance = null;
		}
		public void Refresh()
		{
			foreach( IDriver drv in _drivers)
			{
				drv.Refresh();
			}
		}
		#endregion
	}
}

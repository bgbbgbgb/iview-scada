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

namespace Aimirim.iView
{
	public sealed class AlarmManager
	{
		#region FIELDS
		private static object thisLock = new object();
		private static AlarmManager _instance;
		
		private List<IAlarm> _alarms = new List<IAlarm>();
		#endregion

		#region PROPERTIES
		public static AlarmManager Instance
		{
			get
			{
				lock (thisLock)
				{
					if (_instance == null)
					{
						_instance = new AlarmManager();
					}
					return _instance;
				}
			}
			set
			{
				_instance = value;
			}
		}
		public static string FullFileName
		{
			get
			{
				return System.Configuration.ConfigurationSettings.AppSettings["AlarmDatabase"];
			}
		}
		public List<IAlarm> Alarms
		{
			get
			{
				return _alarms;
			}
		}
		#endregion

		#region CONSTRUCTORS
		private AlarmManager()
		{
			Initialize();
		}
		#endregion

		#region METHODS
		private void Initialize()
		{
			if (!ServiceManager.DesignMode)
			{
				Load(FullFileName);
			}
		}
		public void Load(string fileName)
		{
			Alarms.Clear();

			XmlDocument xmlDocument = null;
			StreamReader fileStream = null;
			
			xmlDocument = new XmlDocument();
			fileStream = new StreamReader(fileName);
			
			xmlDocument.Load(fileStream);
			XmlElement docRoot = xmlDocument.DocumentElement;
			
			foreach (XmlNode alarmNode in docRoot.ChildNodes)
			{
				IAlarm nAlarm = NewAlarm(alarmNode.Attributes["DataType"].Value);
				nAlarm.ReadXml(alarmNode);
				
				Alarms.Add(nAlarm);
			}
			
			fileStream.Close();
			fileStream = null;
		}
		public IAlarm NewAlarm(string type)
		{
			switch (type)
			{
				case "Digital":
					AlarmDigital alarmDigital = new AlarmDigital();
					return alarmDigital;
				case "Analog":
					AlarmAnalog alarmAnalog = new AlarmAnalog();
					return alarmAnalog;
				default:
					return null;
			}
		}
		#endregion
	}
}

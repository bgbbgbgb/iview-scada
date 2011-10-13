using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System;
using System.ComponentModel;
using System.Xml;
using System.Timers;
using System.Data;
using System.Text;

namespace Aimirim.iView
{
	public class TagDigital: AbstractTag, IHistorical
	{
		#region FIELDS
		private string _value;
		private string _address;
		private IDriver _driver;
		
		private bool _historical;
		private DataTable _dtHistorical;
		
		private bool _onOpenChk = false;
		private string _onOpenMsg = string.Empty;
		private bool _onCloseChk = false;
		private string _onCloseMsg = string.Empty;
		#endregion

		#region PROPERTIES
		public override TagType DataType
		{
			get
			{
				return TagType.Digital;
			}
		}
		public override string Value
		{
			get
			{
				if (_driver != null && _address != null)
				{
					if (!ServiceManager.IsClient)
					{
						_value = _driver.GetValue(_address);
					}
				}
				return _value;
			}
			set
			{
				if (value != _value)
				{
					if (!ServiceManager.IsClient)
					{
						if (_driver != null && _address != null)
						{
							_driver.SetValue(_address, value);
						}
					}
				}
			}
		}
		public override string Address
		{
			get
			{
				return _address;
			}
			set
			{
				_address = value;
			}
		}
		public override IDriver Driver
		{
			get
			{
				return _driver;
			}
			set
			{
				if (_driver != null)
				{
					_driver.DataChanged -= new DataChangedEventHandler(DriverDataChanged);
				}
				
				_driver = value;
				
				if (_driver != null)
				{
					_driver.DataChanged += new DataChangedEventHandler(DriverDataChanged);
				}
			}
		}
		public bool Historical
		{
			get
			{
				return _historical;
			}
			set
			{
				_historical = value;
			}
		}

		public bool OnOpenChk
		{
			get
			{
				return _onOpenChk;
			}
			set
			{
				_onOpenChk = value;
			}
		}
		public string OnOpenMsg
		{
			get
			{
				return _onOpenMsg;
			}
			set
			{
				_onOpenMsg = value;
			}
		}
		public bool OnCloseChk
		{
			get
			{
				return _onCloseChk;
			}
			set
			{
				_onCloseChk = value;
			}
		}
		public string OnCloseMsg
		{
			get
			{
				return _onCloseMsg;
			}
			set
			{
				_onCloseMsg = value;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public TagDigital()
		{
		}
		~TagDigital()
		{
			try
			{
				if (_driver != null)
				{
					_driver.DataChanged -= new DataChangedEventHandler(DriverDataChanged);
				}

				if (_historical)
				{
					string fullPath = Path.Combine(Path.GetDirectoryName(ServiceManager.OutputAssemblyFullPath), "Historical");
					string fullFileName = Path.Combine(fullPath, Name + ".xml");
					
					if (!Directory.Exists(fullPath))
					{
						Directory.CreateDirectory(fullPath);
					}
					
					_dtHistorical.WriteXml(fullFileName);
				}
			}
			catch (Exception ex)
			{
				if (Name != null)
				{
					MessageBox.Show(ex.ToString());
					StreamWriter log = new StreamWriter(@".\log\" + Name + ".txt", true, Encoding.ASCII);
					log.WriteLine("==========================================================================================================");
					log.WriteLine("Destrutor: " + DateTime.Now.ToString());
					log.WriteLine("TAG: " + Name);
					log.WriteLine("");
					log.WriteLine(ex.Message);
					log.WriteLine("==========================================================================================================");
					log.Close();
				}
			}
			
		}
		#endregion
		
		#region METHODS
		private void DriverDataChanged(object sender, DataChangedEventArgs e)
		{
			if (!ServiceManager.IsClient || ServiceManager.DesignMode)
			{
				if (e.ItemName == Address)
				{
					if (_value == null || _value != e.Value.ToString())
					{
						_value = e.Value.ToString();
						if (!ServiceManager.DesignMode)
						{
							OnValueChanged(new EventArgs());
						}
					}
				}
			}
			else
			{
				if (e.ItemName == Name)
				{
					if (_value == null || !_value.Equals(e.Value))
					{
						_value = e.Value.ToString();
						if (!ServiceManager.DesignMode)
						{
							OnValueChanged(new EventArgs());
						}
					}
				}
			}
		}
		protected override void OnValueChanged(EventArgs e)
		{
			try
			{
				if (_historical)
				{
					DataRow nwRow = _dtHistorical.NewRow();
					nwRow["Value"] = Value;
					nwRow["TmStamp"] = DateTime.Now;
					_dtHistorical.Rows.Add(nwRow);
					_dtHistorical.AcceptChanges();
				}
				
				if(OnOpenChk && _value.Equals("0"))
				{
					IAlarm alm = AlarmManager.Instance.NewAlarm("Digital");
					alm.Name = Name;
					alm.Description = Description;
					alm.TimeStamp = DateTime.Now.ToString();
					AlarmManager.Instance.Alarms.Add(alm);
				}

				if(OnCloseChk && _value.Equals("1"))
				{
					IAlarm alm = AlarmManager.Instance.NewAlarm("Digital");
					alm.Name = Name;
					alm.Description = Description;
					alm.TimeStamp = DateTime.Now.ToString();
					AlarmManager.Instance.Alarms.Add(alm);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("OnValueChanged: Digital - " + ex.Message);
			}
			finally
			{
				base.OnValueChanged(e);
			}
		}
		public override DialogResult ShowConfigurator()
		{
			using (DigitalTagConfigurator frm = new DigitalTagConfigurator())
			{
				frm.Tag = this;
				return frm.ShowDialog();
			}
		}
		public override void ReadXml(XmlNode tag)
		{
			Name = tag.Attributes["Name"].Value;
			Description = tag.Attributes["Description"].Value;
			Address = tag.Attributes["Address"].Value;
			Historical = bool.Parse(tag.Attributes["Historical"].Value);
			
			OnOpenChk = tag.Attributes["OnOpenChk"] != null ? bool.Parse(tag.Attributes["OnOpenChk"].Value) : OnOpenChk;
			OnOpenMsg = tag.Attributes["OnOpenMsg"] != null ? tag.Attributes["OnOpenMsg"].Value : OnOpenMsg;
			OnCloseChk = tag.Attributes["OnCloseChk"] != null ? bool.Parse(tag.Attributes["OnCloseChk"].Value) : OnCloseChk;
			OnCloseMsg = tag.Attributes["OnCloseMsg"] != null ? tag.Attributes["OnCloseMsg"].Value : OnCloseMsg;
			
			string fullPath = Path.Combine(Path.GetDirectoryName(ServiceManager.OutputAssemblyFullPath), "Historical");
			string fullFileName = Path.Combine(fullPath, Name + ".xml");

			if (_dtHistorical == null && !ServiceManager.DesignMode)
			{
				DataColumn id = new DataColumn("Id");
				id.AutoIncrement = true;
				id.AutoIncrementStep = 1;
				
				DataColumn value = new DataColumn("Value");
				value.DataType = typeof(string);
				
				DataColumn tmStamp = new DataColumn("TmStamp");
				tmStamp.DataType = typeof(DateTime);
				
				_dtHistorical = new DataTable(Name);
				_dtHistorical.Columns.AddRange(new DataColumn[] {id, value, tmStamp});
				
				_dtHistorical.PrimaryKey = new DataColumn[] {id};

				if (!Directory.Exists(fullPath))
				{
					Directory.CreateDirectory(fullPath);
				}

				try
				{
					if (File.Exists(fullFileName))
					{
						_dtHistorical.ReadXml(fullFileName);
					}
				}
				catch (Exception)
				{
					long ticks = DateTime.Now.Ticks;
					File.Copy(fullFileName, fullFileName + "_error_" + ticks);
				}
			}
			
			try
			{
				if (!ServiceManager.DesignMode)
				{
					if (!ServiceManager.IsClient)
					{
						Driver = DriverManager.Instance.GetDriver(tag.Attributes["Driver"].Value);
						Driver.Add(Address);
						//_value = Driver.GetValue(Address);
					}
					else
					{
						Driver = DriverManager.Instance.GetDriver("FE9E907F-2186-4186-B5EA-53B7609303C0");
					}
				}
				else
				{
					Driver = DriverManager.Instance.GetDriver(tag.Attributes["Driver"].Value);
				}
			}
			catch (Exception)
			{
				if (!ServiceManager.DesignMode)
				{
					MessageBox.Show("A tag " + Name + " não pode se comunicar com a fonte da dados, favor verificar a comunicação");
				}
			}
		}
		public override void WriteXml(ref XmlElement parent)
		{
			//Create a new Tag node.
			XmlElement tagElement = parent.OwnerDocument.CreateElement("Tag");
			tagElement.SetAttribute("Name", Name);
			tagElement.SetAttribute("Description", Description);
			tagElement.SetAttribute("DataType", DataType.ToString());
			tagElement.SetAttribute("Address", Address);
			tagElement.SetAttribute("Driver", Driver.Id);
			tagElement.SetAttribute("Historical", Historical.ToString());

			tagElement.SetAttribute("OnOpenChk", OnOpenChk.ToString());
			tagElement.SetAttribute("OnOpenMsg", OnOpenMsg);
			tagElement.SetAttribute("OnCloseChk", OnCloseChk.ToString());
			tagElement.SetAttribute("OnCloseMsg", OnCloseMsg);
			
			parent.AppendChild(tagElement);
		}
		public DataTable ToDataTable()
		{
			return _dtHistorical;
		}
		#endregion
	}
}

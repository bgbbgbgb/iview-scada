using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Text;

namespace Aimirim.iView
{
	public class TagAnalog: AbstractTag, IHistorical
	{
		#region FIELDS
		private string _value;
		private string _address;
		private IDriver _driver;
		private string _min = string.Empty;
		private string _max = string.Empty;
		private ISignalCondition _signalCondition;
		
		private bool _lowChk = false;
		private string _lowVl = string.Empty;
		private bool _lowAlm = false;
		private string _lowMsg = string.Empty;
		
		private bool _lowLowChk = false;
		private string _lowLowVl =  string.Empty;
		private bool _lowLowAlm = false;
		private string _lowLowMsg = string.Empty;
		
		private bool _hiChk = false;
		private string _hiVl =  string.Empty;
		private bool _hiAlm = false;
		private string _hiMsg = string.Empty;
		
		private bool _hiHiChk = false;
		private string _hiHiVl =  string.Empty;
		private bool _hiHiAlm = false;
		private string _hiHiMsg = string.Empty;
		
		private bool _historical;
		private DataTable _dtHistorical;
		#endregion

		#region PROPERTIES
		public override TagType DataType
		{
			get
			{
				return TagType.Analog;
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

						if (SignalCondition != null)
						{
							_value = SignalCondition.Convert(_value, Min, Max, TypeDirection.FromDataSource);
						}
					}
					else
					{
						_value = _driver.GetValue(_name);
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
						if (SignalCondition != null)
						{
							value = SignalCondition.Convert(value, Min, Max, TypeDirection.ToDataSource);
						}
						
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
		
		public ISignalCondition SignalCondition
		{
			get
			{
				return _signalCondition;
			}
			set
			{
				_signalCondition = value;
			}
		}
		public string Min
		{
			get
			{
				return _min;
			}
			set
			{
				_min = value;
			}
		}
		public string Max
		{
			get
			{
				return _max;
			}
			set
			{
				_max = value;
			}
		}
		
		public bool LowChk
		{
			get
			{
				return _lowChk;
			}
			set
			{
				_lowChk = value;
			}
		}
		public string LowVl
		{
			get
			{
				return _lowVl;
			}
			set
			{
				_lowVl = value;
			}
		}
		public string LowMsg
		{
			get
			{
				return _lowMsg;
			}
			set
			{
				_lowMsg = value;
			}
		}
		
		public bool LowLowChk
		{
			get
			{
				return _lowLowChk;
			}
			set
			{
				_lowLowChk = value;
			}
		}
		public string LowLowVl
		{
			get
			{
				return _lowLowVl;
			}
			set
			{
				_lowLowVl = value;
			}
		}
		public string LowLowMsg
		{
			get
			{
				return _lowLowMsg;
			}
			set
			{
				_lowLowMsg = value;
			}
		}
		
		public bool HiChk
		{
			get
			{
				return _hiChk;
			}
			set
			{
				_hiChk = value;
			}
		}
		public string HiVl
		{
			get
			{
				return _hiVl;
			}
			set
			{
				_hiVl = value;
			}
		}
		public string HiMsg
		{
			get
			{
				return _hiMsg;
			}
			set
			{
				_hiMsg = value;
			}
		}
		
		public bool HiHiChk
		{
			get
			{
				return _hiHiChk;
			}
			set
			{
				_hiHiChk = value;
			}
		}
		public string HiHiVl
		{
			get
			{
				return _hiHiVl;
			}
			set
			{
				_hiHiVl = value;
			}
		}
		public string HiHiMsg
		{
			get
			{
				return _hiHiMsg;
			}
			set
			{
				_hiHiMsg = value;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public TagAnalog()
		{
		}
		~TagAnalog()
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
					if (SignalCondition != null)
					{
						string fromDataSource = SignalCondition.Convert(e.Value.ToString(), Min, Max, TypeDirection.FromDataSource);
						if (_value == null || _value != fromDataSource)
						{
							_value = fromDataSource;
							if (!ServiceManager.DesignMode)
							{
								OnValueChanged(new EventArgs());
							}
						}
					}
					else
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
			}
			else
			{
				if (e.ItemName == Name)
				{
					if (SignalCondition != null)
					{
						string fromDataSource = SignalCondition.Convert(e.Value.ToString(), Min, Max, TypeDirection.FromDataSource);
						if (_value == null || _value != fromDataSource)
						{
							_value = fromDataSource;
							if (!ServiceManager.DesignMode)
							{
								OnValueChanged(new EventArgs());
							}
						}
					}
					else
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
			}

		}
		protected override void OnValueChanged(EventArgs e)
		{
			try
			{
				// Instruções para gerar histórico
				if (_historical)
				{
					DataRow nwRow = _dtHistorical.NewRow();
					nwRow["Value"] = double.Parse(Value);
					nwRow["TmStamp"] = DateTime.Now;
					_dtHistorical.Rows.Add(nwRow);
					_dtHistorical.AcceptChanges();
				}
				
				//
				// Instruções do alarme
				// Nível baixo
				if (_lowChk && !_lowAlm && _value != null && _value != string.Empty && LowVl != null && LowVl != string.Empty && int.Parse(_value) <= int.Parse(LowVl))
				{
					_lowAlm = true;
					
					IAlarm alm = AlarmManager.Instance.NewAlarm("Analog");
					alm.Name = Name;
					alm.Description = Description;
					alm.TimeStamp = DateTime.Now.ToString();
					AlarmManager.Instance.Alarms.Add(alm);
				}
				else if (_value != null && LowVl != null && _value != string.Empty && LowVl != string.Empty && int.Parse(_value) > int.Parse(LowVl))
				{
					_lowAlm = false;
				}
				
				// Nível baixo-baixo
				if (_lowLowChk && !_lowLowAlm && _value != null && LowLowVl != null && _value != string.Empty && LowLowVl != string.Empty && int.Parse(_value) <= int.Parse(LowLowVl))
				{
					_lowLowAlm = true;
					
					IAlarm alm = AlarmManager.Instance.NewAlarm("Analog");
					alm.Name = Name;
					alm.Description = Description;
					alm.TimeStamp = DateTime.Now.ToString();
					AlarmManager.Instance.Alarms.Add(alm);
				}
				else if (_value != null && LowLowVl != null && _value != string.Empty && LowLowVl != string.Empty && int.Parse(_value) > int.Parse(LowLowVl))
				{
					_lowLowAlm = false;
				}
				
				// Nível alto
				if (_hiChk && !_hiAlm && _value != null && HiVl != null && _value != string.Empty && HiVl != string.Empty && int.Parse(_value) >= int.Parse(HiVl))
				{
					_hiAlm = true;
					
					IAlarm alm = AlarmManager.Instance.NewAlarm("Analog");
					alm.Name = Name;
					alm.Description = Description;
					alm.TimeStamp = DateTime.Now.ToString();
					AlarmManager.Instance.Alarms.Add(alm);
				}
				else if (_value != null && HiVl != null && _value != string.Empty && HiVl != string.Empty && int.Parse(_value) < int.Parse(HiVl))
				{
					_hiAlm = false;
				}
				
				// Nível alto-alto
				if (_hiHiChk && !_hiHiAlm && _value != null && HiHiVl != null && _value != string.Empty && HiHiVl != string.Empty && int.Parse(_value) >= int.Parse(HiHiVl))
				{
					_hiHiAlm = true;
					
					IAlarm alm = AlarmManager.Instance.NewAlarm("Analog");
					alm.Name = Name;
					alm.Description = Description;
					alm.TimeStamp = DateTime.Now.ToString();
					AlarmManager.Instance.Alarms.Add(alm);
				}
				else if (_value != null && HiHiVl != null && _value != string.Empty && HiHiVl != string.Empty && int.Parse(_value) < int.Parse(HiHiVl))
				{
					_hiHiAlm = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("OnValueChanged: Analog - " + ex.Message);
			}
			finally
			{
				base.OnValueChanged(e);
			}
		}
		public override DialogResult ShowConfigurator()
		{
			using (AnalogTagConfigurator frm = new AnalogTagConfigurator())
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
			
			SignalCondition = tag.Attributes["SignalCondition"].Value != String.Empty ? new SignalCondition16383() : null;
			Min = tag.Attributes["Min"].Value;
			Max = tag.Attributes["Max"].Value;

			LowChk = tag.Attributes["LowChk"] != null ? bool.Parse(tag.Attributes["LowChk"].Value) : LowChk;
			LowVl = tag.Attributes["LowVl"] != null ? tag.Attributes["LowVl"].Value : LowVl;
			LowMsg = tag.Attributes["LowMsg"] != null ? tag.Attributes["LowMsg"].Value : LowMsg;
			
			LowLowChk = tag.Attributes["LowLowChk"] != null ? bool.Parse(tag.Attributes["LowLowChk"].Value) : LowLowChk;
			LowLowVl = tag.Attributes["LowLowVl"] != null ? tag.Attributes["LowLowVl"].Value : LowLowVl;
			LowLowMsg = tag.Attributes["LowLowMsg"] != null ? tag.Attributes["LowLowMsg"].Value : LowLowMsg;
			
			HiChk = tag.Attributes["HiChk"] != null ? bool.Parse(tag.Attributes["HiChk"].Value) : HiChk;
			HiVl = tag.Attributes["HiVl"] != null ? tag.Attributes["HiVl"].Value : HiVl;
			HiMsg = tag.Attributes["HiMsg"] != null ? tag.Attributes["HiMsg"].Value : HiMsg;
			
			HiHiChk = tag.Attributes["HiHiChk"] != null ? bool.Parse(tag.Attributes["HiHiChk"].Value) : HiHiChk;
			HiHiVl = tag.Attributes["HiHiVl"] != null ? tag.Attributes["HiHiVl"].Value : HiHiVl;
			HiHiMsg = tag.Attributes["HiHiMsg"] != null ? tag.Attributes["HiHiMsg"].Value : HiHiMsg;
			
			string fullPath = Path.Combine(Path.GetDirectoryName(ServiceManager.OutputAssemblyFullPath), "Historical");
			string fullFileName = Path.Combine(fullPath, Name + ".xml");

			if (_dtHistorical == null && !ServiceManager.DesignMode)
			{
				DataColumn id = new DataColumn("Id");
				id.AutoIncrement = true;
				id.AutoIncrementStep = 1;
				
				DataColumn value = new DataColumn("Value");
				value.DataType = typeof(double);
				
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
			tagElement.SetAttribute("SignalCondition", SignalCondition != null ? SignalCondition.Id : String.Empty);
			tagElement.SetAttribute("Min", Min);
			tagElement.SetAttribute("Max", Max);

			tagElement.SetAttribute("LowChk", LowChk.ToString());
			tagElement.SetAttribute("LowVl", LowVl);
			tagElement.SetAttribute("LowMsg", LowMsg);
			
			tagElement.SetAttribute("LowLowChk", LowLowChk.ToString());
			tagElement.SetAttribute("LowLowVl", LowLowVl);
			tagElement.SetAttribute("LowLowMsg", LowLowMsg);
			
			tagElement.SetAttribute("HiChk", HiChk.ToString());
			tagElement.SetAttribute("HiVl", HiVl);
			tagElement.SetAttribute("HiMsg", HiMsg);
			
			tagElement.SetAttribute("HiHiChk", HiHiChk.ToString());
			tagElement.SetAttribute("HiHiVl", HiHiVl);
			tagElement.SetAttribute("HiHiMsg", HiHiMsg);
			
			parent.AppendChild(tagElement);
		}
		public DataTable ToDataTable()
		{
			return _dtHistorical;
		}
		#endregion
	}
}
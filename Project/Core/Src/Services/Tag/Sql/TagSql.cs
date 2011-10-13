using System;
using System.ComponentModel;
using System.Management.Instrumentation;
using System.Xml;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Aimirim.iView
{

	public class TagSql: AbstractTag
	{
		#region FIELDS
		private string _value;
		private string _address;
		private IDriver _driver;
		
		private string _dsn;
		private string _sqlCommand;
		private DataTable _sqlParams = new DataTable();
		
		private int _counter = 0;
		private bool _onChange = true;
		private bool _onOpen = false;
		private bool _onClose = false;
		
		private System.Timers.Timer _tmr;
		#endregion

		#region PROPERTIES
		public override TagType DataType
		{
			get
			{
				return TagType.Sql;
			}
		}
		public override string Value
		{
			get
			{
				return _counter.ToString();
			}
			set
			{
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
		
		public string Dsn
		{
			get
			{
				return _dsn;
			}
			set
			{
				_dsn = value;
			}
		}
		public string SqlCommand
		{
			get
			{
				return _sqlCommand;
			}
			set
			{
				_sqlCommand = value;
			}
		}
		public DataTable SqlParams
		{
			get
			{
				return _sqlParams;
			}
			set
			{
				_sqlParams = value;
			}
		}
		
		public bool OnChange
		{
			get
			{
				return _onChange;
			}
			set
			{
				_onChange = value;
			}
		}
		public bool OnOpen
		{
			get
			{
				return _onOpen;
			}
			set
			{
				_onOpen = value;
			}
		}
		public bool OnClose
		{
			get
			{
				return _onClose;
			}
			set
			{
				_onClose = value;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public TagSql()
		{
			DataColumn name = new DataColumn("Name");
			DataColumn value = new DataColumn("Value");
			
			_sqlParams.Columns.Add(name);
			_sqlParams.Columns.Add(value);
			
			_sqlParams.PrimaryKey = new DataColumn[] { name };
			
			_tmr = new  System.Timers.Timer();
			_tmr.Interval = 1000;
			_tmr.Elapsed += delegate
			{
				Console.WriteLine(Name + " Executou o timer.");
				_tmr.Stop();
				OnValueChanged(new EventArgs());
			};
		}
		#endregion
		
		#region METHODS
		protected override void OnValueChanged(EventArgs e)
		{
			if (SqlCommand == null || SqlCommand == string.Empty)
			{
				base.OnValueChanged(e);
				return;
			}
			
			DsnStruct dsnStruct = DataSourceManager.Instance.GetDsnFromAlias(Dsn);
			if (!dsnStruct.Name.Equals("Error"))
			{
				string connectionString = string.Format("dsn={0};UID={1};PWD={2};", dsnStruct.Name, dsnStruct.Uid, dsnStruct.Pwd);
				OdbcTransaction transaction = DataSourceManager.Instance.BeginTransaction(connectionString);
				
				// Apagar quando os testes terminarem
				// Inicio
				
				if (!Directory.Exists("log"))
				{
					Directory.CreateDirectory("log");
				}
				
				StreamWriter log = new StreamWriter(@".\log\" + Name + ".txt", true, Encoding.ASCII);
				log.WriteLine("==========================================================================================================");
				log.WriteLine("Momento da Execução: " + DateTime.Now.ToString());
				log.WriteLine("TAG: " + Name);
				
				// Fim
				try
				{
					// Inicio
					log.WriteLine("Comando: " + SqlCommand);
					log.WriteLine("Parametros:");
					// Fim
					string query = SqlCommand;
					foreach (DataRow row in SqlParams.Rows)
					{
						// Inicio
						log.WriteLine("Parametro: " + row["Name"].ToString() + " => Valor: " + ParseParam(row["Value"].ToString()));
						// Fim
						query = query.Replace(row["Name"].ToString(), ParseParam(row["Value"].ToString()));
					}
					// Inicio
					log.WriteLine("Comando a executar: " + query);
					// Fim

					bool execute = false;
					if (OnOpen && _value.Equals("0"))
					{
						execute = true;
					}
					else if (OnClose && int.Parse(_value) > 0)
					{
						execute = true;
					}
					else if (OnChange)
					{
						execute = true;
					}
					
					if(execute)
					{
						// Inicio
						try
						{
							// Fim
							DataSourceManager.Instance.ExecuteScalar(query, transaction);
							transaction.Commit();
							// Inicio
							log.WriteLine("Resultado: OK");
							// Inicio
							log.Close();
							// Fim
						}
						catch (Exception ex)
						{
							log.WriteLine("Resultado: NOK");
							log.WriteLine("Erro:");
							log.WriteLine(ex.ToString());
							// Inicio
							log.Close();
							// Fim
						}
						// Fim
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
					transaction.Rollback();
				}
				finally
				{
					base.OnValueChanged(e);
				}
			}
		}
		
		private void DriverDataChanged(object sender, DataChangedEventArgs e)
		{
			if ( e.ItemName == Address  )
			{
				if (!ServiceManager.DesignMode && _value != null && !_value.Equals(e.Value.ToString()))
				{
					Console.WriteLine(Name + " Valor atual " + _value.ToString());
					Console.WriteLine(Name + " Valor novo " + e.Value.ToString());

					_counter = ++_counter;
					_value = e.Value.ToString();
					_tmr.Start();

					Console.WriteLine(Name + " Executou o contador. " + _counter.ToString());
				}
				else if (_value == null)
				{
					Console.WriteLine(Name + " Inicializou com valor " + e.Value.ToString());
					_value = e.Value.ToString();
				}
			}
		}
		private string ParseParam(string param)
		{
			ITag tag = TagManager.Instance.GetTag(param);
			if (tag == null)
			{
				return param;
			}
			else
			{
				return tag.Value;
			}
		}
		
		public override DialogResult ShowConfigurator()
		{
			using (SqlTagConfigurator frm = new SqlTagConfigurator())
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
//			Driver = DriverManager.Instance.GetDriver(tag.Attributes["Driver"].Value);
			
			Dsn = tag.Attributes["Dsn"].Value;
			SqlCommand = tag.Attributes["SqlCommand"].Value;

			OnChange = bool.Parse(tag.Attributes["OnChange"].Value);
			OnOpen = bool.Parse(tag.Attributes["OnOpen"].Value);
			OnClose = bool.Parse(tag.Attributes["OnClose"].Value);
			
			foreach (XmlNode param in tag.ChildNodes)
			{
				DataRow nwRow = _sqlParams.NewRow();
				nwRow["Name"] = param.Attributes["Name"].Value;
				nwRow["Value"] = param.Attributes["Value"].Value;
				_sqlParams.Rows.Add(nwRow);
			}

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
		public override void WriteXml(ref XmlElement parent)
		{
			//Create a new Tag node.
			XmlElement tagElement = parent.OwnerDocument.CreateElement("Tag");
			tagElement.SetAttribute("Name", Name);
			tagElement.SetAttribute("Description", Description);
			tagElement.SetAttribute("DataType", DataType.ToString());
			tagElement.SetAttribute("Address", Address);
			tagElement.SetAttribute("Driver", Driver.Id);
			
			tagElement.SetAttribute("Dsn", Dsn);
			tagElement.SetAttribute("SqlCommand", SqlCommand);
			
			tagElement.SetAttribute("OnChange", OnChange.ToString());
			tagElement.SetAttribute("OnOpen", OnOpen.ToString());
			tagElement.SetAttribute("OnClose", OnClose.ToString());
			
			foreach (DataRow param in _sqlParams.Rows)
			{
				XmlElement paramElement = parent.OwnerDocument.CreateElement("SqlParam");
				paramElement.SetAttribute("Name", param["Name"].ToString());
				paramElement.SetAttribute("Value", param["Value"].ToString());
				
				tagElement.AppendChild(paramElement);
			}
			
			parent.AppendChild(tagElement);
		}
		#endregion
	}
}

using System.Data;

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
	using System.Data.Odbc;

	public sealed class DataSourceManager
	{
		#region FIELDS
		private static object _lock = new object();
		private static DataSourceManager _instance;

		private DataTable _tbDataSource;
		private BindingSource _bsDataSource;
		#endregion

		#region PROPERTIES
		public static DataSourceManager Instance
		{
			get
			{
				lock(_lock)
				{
					if (_instance == null)
					{
						_instance = new DataSourceManager();
					}
					return _instance;
				}
			}
		}
		#endregion

		#region CONSTRUCTORS
		private DataSourceManager()
		{
			if (!ServiceManager.DesignMode)
			{
				Initialize();
			}
		}
		#endregion

		#region METHODS
		private void Initialize()
		{
			string dataSourceCfgPath = System.Configuration.ConfigurationSettings.AppSettings["DataSourceCfg"];

			try
			{
				DataColumn alias = new DataColumn("Alias");
				DataColumn dsn = new DataColumn("Dsn");
				DataColumn uid = new DataColumn("Uid");
				DataColumn pwd = new DataColumn("Pwd");

				_tbDataSource = new DataTable("DataSource");
				
				_tbDataSource.Columns.Add(alias);
				_tbDataSource.Columns.Add(dsn);
				_tbDataSource.Columns.Add(uid);
				_tbDataSource.Columns.Add(pwd);
				
				_tbDataSource.ReadXml(dataSourceCfgPath);
				
				_bsDataSource = new BindingSource();
				_bsDataSource.DataSource = _tbDataSource;
				
				Console.Out.WriteLine("Load DataSource Success!");
			}
			catch(Exception ex)
			{
				Console.Out.WriteLine("Load DataSource Success! " + ex.Message);
				//MessageBox.Show("Loading DataSource failure! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		public DsnStruct GetDsnFromAlias(string alias)
		{
			int indx = _bsDataSource.Find("Alias", alias);
			if (indx >= 0)
			{
				DataRowView row = _bsDataSource[indx] as DataRowView;
				return new DsnStruct(row["Dsn"].ToString(), row["Uid"].ToString(), row["Pwd"].ToString());
			}
			else
			{
				return new DsnStruct("Error", "Error", "Error");
			}
		}
		public OdbcTransaction BeginTransaction(string connectionString)
		{
			OdbcConnection dbConnection = new OdbcConnection(connectionString);
			dbConnection.Open();
			
			OdbcTransaction dbTransaction = dbConnection.BeginTransaction();
			return dbTransaction;
		}
		public object ExecuteScalar(string query, OdbcTransaction transaction)
		{
			OdbcCommand dbCommand = transaction.Connection.CreateCommand();
			dbCommand.CommandType = CommandType.Text;
			dbCommand.CommandText = query;
			dbCommand.Transaction = transaction;
			return dbCommand.ExecuteScalar();
		}
		public DataTable ExecuteTable(string tableName, string query, OdbcTransaction transaction)
		{
			try
			{
				OdbcCommand dbCommand = transaction.Connection.CreateCommand();
				dbCommand.Transaction = transaction;
				dbCommand.CommandText = query;

				OdbcDataAdapter dbDataAdapter = new OdbcDataAdapter(dbCommand);
				DataTable dataTable = new DataTable(tableName);

				dbDataAdapter.MissingSchemaAction = MissingSchemaAction.Add;
				dbDataAdapter.FillSchema(dataTable, SchemaType.Source);
				dbDataAdapter.Fill(dataTable);

				return dataTable;
			}
			catch (Exception)
			{
				transaction.Rollback();
				
				var trace = new System.Diagnostics.StackTrace(true);
				var frame = trace.GetFrame(0);
				var method = frame.GetMethod();
				return null;
			}
		}
		
		/// <summary>
		/// Gets all System data source names for the local machine.
		/// </summary>
		public SortedList GetSystemDataSourceNames()
		{
			System.Collections.SortedList dsnList = new System.Collections.SortedList();

			// get system dsn's
			Microsoft.Win32.RegistryKey reg = (Microsoft.Win32.Registry.LocalMachine).OpenSubKey("Software");
			if (reg != null)
			{
				reg = reg.OpenSubKey("ODBC");
				if (reg != null)
				{
					reg = reg.OpenSubKey("ODBC.INI");
					if (reg != null)
					{
						reg = reg.OpenSubKey("ODBC Data Sources");
						if (reg != null)
						{
							// Get all DSN entries defined in DSN_LOC_IN_REGISTRY.
							foreach (string sName in reg.GetValueNames())
							{
								dsnList.Add(sName, DataSourceType.System);
							}
						}
						try
						{
							reg.Close();
						}
						catch { /* ignore this exception if we couldn't close */ }
					}
				}
			}

			return dsnList;
		}
		/// <summary>
		/// Gets all User data source names for the local machine.
		/// </summary>
		public SortedList GetUserDataSourceNames()
		{
			System.Collections.SortedList dsnList = new System.Collections.SortedList();

			// get user dsn's
			Microsoft.Win32.RegistryKey reg = (Microsoft.Win32.Registry.CurrentUser).OpenSubKey("Software");
			if (reg != null)
			{
				reg = reg.OpenSubKey("ODBC");
				if (reg != null)
				{
					reg = reg.OpenSubKey("ODBC.INI");
					if (reg != null)
					{
						reg = reg.OpenSubKey("ODBC Data Sources");
						if (reg != null)
						{
							// Get all DSN entries defined in DSN_LOC_IN_REGISTRY.
							foreach (string sName in reg.GetValueNames())
							{
								dsnList.Add(sName, DataSourceType.User);
							}
						}
						try
						{
							reg.Close();
						}
						catch { /* ignore this exception if we couldn't close */ }
					}
				}
			}

			return dsnList;
		}
		/// <summary>
		/// Returns a list of data source names from the local machine.
		/// </summary>
		public SortedList GetAllDataSourceNames()
		{
			// Get the list of user DSN's first.
			System.Collections.SortedList dsnList = GetUserDataSourceNames();

			// Get list of System DSN's and add them to the first list.
			System.Collections.SortedList systemDsnList = GetSystemDataSourceNames();
			for (int i = 0; i < systemDsnList.Count; i++)
			{
				string sName = systemDsnList.GetKey(i) as string;
				DataSourceType type = (DataSourceType)systemDsnList.GetByIndex(i);
				try
				{
					// This dsn to the master list
					dsnList.Add(sName, type);
				}
				catch
				{
					// An exception can be thrown if the key being added is a duplicate so
					// we just catch it here and have to ignore it.
				}
			}

			return dsnList;
		}
		#endregion
	}
	
	public struct DsnStruct
	{
		public string Name;
		public string Uid;
		public string Pwd;
		
		public DsnStruct(string name, string uid, string pwd)
		{
			Name = name;
			Uid = uid;
			Pwd = pwd;
		}
	}
}

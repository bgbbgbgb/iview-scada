using System.ComponentModel;
using System.Data;
using System.Xml;
using System;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.SharpDevelop.Project;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.SharpDevelop;
using System.Collections.Generic;
using ICSharpCode.Core;

namespace Aimirim.iView
{
	public partial class DataSourceUserControl : UserControl
	{
		#region FIELDS
		private DataTable _tbDataSource;
		private BindingSource _bsDataSource;
		private string _fileName = string.Empty;
		#endregion // fields

		#region CONSTRUCTORS
		public DataSourceUserControl()
		{
			InitializeComponent();

			DataColumn alias = new DataColumn("Alias");
			DataColumn dsn = new DataColumn("Dsn");
			DataColumn uid = new DataColumn("Uid");
			DataColumn pwd = new DataColumn("Pwd");

			_tbDataSource = new DataTable("DataSource");
			
			_tbDataSource.Columns.Add(alias);
			_tbDataSource.Columns.Add(dsn);
			_tbDataSource.Columns.Add(uid);
			_tbDataSource.Columns.Add(pwd);
			
			_bsDataSource = new BindingSource();
			_bsDataSource.DataSource = _tbDataSource;

			dataGridViewTagGroup.DataSource = _bsDataSource;
		}
		#endregion // constructors

		#region METHODS
		protected void OnDataChanged(EventArgs e)
		{
			if (_dataChanged != null)
			{
				_dataChanged(this, e);
			}
		}
		private void TsbNewClick(object sender, EventArgs e)
		{
			using (DataSourceCfg dscfg = new DataSourceCfg())
			{
				if (dscfg.ShowDialog() == DialogResult.OK)
				{
					DataRowView drvw = _bsDataSource.AddNew() as DataRowView;
					drvw["Alias"] = dscfg.textBoxAlias.Text;
					drvw["Dsn"] = dscfg.cbxDsn.SelectedItem.ToString();
					drvw["Uid"] = dscfg.txbUid.Text;
					drvw["Pwd"] = dscfg.txbPwd.Text;
					
					_bsDataSource.EndEdit();
					_tbDataSource.AcceptChanges();
				}
			}
		}
		private void TsbEditClick(object sender, EventArgs e)
		{
			using (DataSourceCfg dscfg = new DataSourceCfg())
			{
				DataRowView drvw = _bsDataSource.Current as DataRowView;
				
				dscfg.textBoxAlias.Text = drvw["Alias"].ToString();
				dscfg.cbxDsn.SelectedItem = drvw["Dsn"].ToString();
				dscfg.txbUid.Text = drvw["Uid"].ToString();
				dscfg.txbPwd.Text = drvw["Pwd"].ToString();

				if (dscfg.ShowDialog() == DialogResult.OK)
				{
					drvw["Alias"] = dscfg.textBoxAlias.Text;
					drvw["Dsn"] = dscfg.cbxDsn.SelectedItem.ToString();
					drvw["Uid"] = dscfg.txbUid.Text;
					drvw["Pwd"] = dscfg.txbPwd.Text;

					_bsDataSource.EndEdit();
					_tbDataSource.AcceptChanges();
				}
			}
		}
		private void TsbDeleteClick(object sender, EventArgs e)
		{
			_bsDataSource.RemoveCurrent();
			_bsDataSource.EndEdit();
			_tbDataSource.AcceptChanges();
		}
		
		public void Load(Stream fileStream)
		{
			_tbDataSource.Clear();
			_tbDataSource.ReadXml(fileStream);
			
			_bsDataSource.ListChanged += delegate { OnDataChanged(EventArgs.Empty); };
		}
		public void Save(Stream fileStream)
		{
			_tbDataSource.WriteXml(fileStream);
		}
		#endregion // methods

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

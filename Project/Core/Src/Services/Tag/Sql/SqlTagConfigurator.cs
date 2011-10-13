
namespace Aimirim.iView
{
	using System.Windows.Forms;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Collections;


	public partial class SqlTagConfigurator : Form
	{
		#region FIELDS
		private BindingList<Dictionary<string, string>> _bs = new BindingList<Dictionary<string, string>>();
		#endregion

		#region CONSTRUCTORS
		public SqlTagConfigurator()
		{
			InitializeComponent();
		}
		#endregion

		#region METHODS
		private void TagConfiguratorLoad(object sender, EventArgs e)
		{
			cbDriver.Items.AddRange(DriverManager.Instance.Drivers.ToArray());
			
			if (Tag == null)
				return;
			
			textBoxName.Text = ((TagSql)Tag).Name;
			textBoxDescription.Text = ((TagSql)Tag).Description;
			txbAddress.Text = ((TagSql)Tag).Address;
			cbDriver.SelectedItem = ((TagSql)Tag).Driver;
			
			txbDsn.Text = ((TagSql)Tag).Dsn;
			txbSqlCommand.Text = ((TagSql)Tag).SqlCommand;
			dgvParams.DataSource = ((TagSql)Tag).SqlParams;
			
			rbOnChange.Checked = ((TagSql)Tag).OnChange;
			rbOnOpen.Checked = ((TagSql)Tag).OnOpen;
			rbOnClose.Checked = ((TagSql)Tag).OnClose;
		}
		private void ButtonOkClick(object sender, EventArgs e)
		{
			if (Tag == null)
				return;
			
			((TagSql)Tag).Name = textBoxName.Text;
			((TagSql)Tag).Description = textBoxDescription.Text;
			((TagSql)Tag).Address = txbAddress.Text;
			((TagSql)Tag).Driver = cbDriver.SelectedItem as IDriver;
			
			((TagSql)Tag).Dsn = txbDsn.Text;
			((TagSql)Tag).SqlCommand = txbSqlCommand.Text;
			((TagSql)Tag).SqlParams = dgvParams.DataSource as DataTable;
			
			((TagSql)Tag).OnChange = rbOnChange.Checked;
			((TagSql)Tag).OnOpen = rbOnOpen.Checked;
			((TagSql)Tag).OnClose = rbOnClose.Checked;
		}
		#endregion
	}
}

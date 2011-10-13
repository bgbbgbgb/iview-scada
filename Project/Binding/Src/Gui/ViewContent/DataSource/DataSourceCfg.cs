using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;

namespace Aimirim.iView
{

	public partial class DataSourceCfg : Form
	{
		#region FIELDS
		#endregion

		#region CONSTRUCTORS
		public DataSourceCfg()
		{
			InitializeComponent();

			// fill data source names
			SortedList dsnList = DataSourceManager.Instance.GetAllDataSourceNames();
			for (int i = 0; i < dsnList.Count; i++)
			{
				string sName = (string)dsnList.GetKey(i);
				cbxDsn.Items.Add(sName);
			}
		}
		#endregion

		#region METHODS
		private void ButtonOkClick(object sender, EventArgs e)
		{
		}
		#endregion
	}
}

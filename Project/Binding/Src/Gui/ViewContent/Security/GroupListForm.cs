using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System;


namespace Aimirim.iView
{

	public partial class GroupListForm : Form
	{
		#region FIELDS
		private BindingSource _bs = new BindingSource();
		#endregion

		#region CONSTRUCTORS
		public GroupListForm( DataTable GroupList)
		{
			InitializeComponent();
			//_bs.DataSource = SecurityManager.Instance.DataSource.Tables["Group"];
			_bs.DataSource = GroupList;
			listBox1.DataSource = _bs;
			listBox1.DisplayMember = "Name";
		}
		#endregion

		#region METHODS
		#endregion
	}
}

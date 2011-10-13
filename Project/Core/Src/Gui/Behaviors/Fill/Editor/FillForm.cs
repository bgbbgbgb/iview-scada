
namespace Aimirim.iView
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;

	public partial class FillForm : Form
	{
		#region Fields
		private FillBehavior _behavior;
		#endregion

		#region Properties
		public FillBehavior Behavior
		{
			get
			{
				return _behavior;
			}
			set
			{
				_behavior = value;
			}
		}
		#endregion

		#region Constructos
		public FillForm()
		{
			InitializeComponent();
			
		}
		#endregion

		#region Methods
		private void VisibilityFormLoad(object sender, EventArgs e)
		{
			if (_behavior == null)
			{
				_behavior = new FillBehavior();
			}
			
			chkEnable.DataBindings.Add("Checked", _behavior, "Enable");
			txExpression.DataBindings.Add("Text", _behavior, "Expression");
		}
		private void BtnOkClick(object sender, EventArgs e)
		{
			//_behavior.Enable = chkEnable.Checked;
			//_behavior.Expression = txExpression.Text;
			
			DialogResult = DialogResult.OK;
			Close();
		}
		#endregion

		
	}
}

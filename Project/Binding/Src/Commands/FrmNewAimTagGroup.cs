/*
 * Created by SharpDevelop.
 * User: Romis Fava
 * Date: 1/4/2011
 * Time: 21:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Aimirim.iView
{
	/// <summary>
	/// Description of FrmNewAimTagGroup.
	/// </summary>
	public partial class FrmNewAimTagGroup : Form
	{
		public FrmNewAimTagGroup()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void BtnOkClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}

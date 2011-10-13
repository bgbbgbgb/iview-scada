
namespace Aimirim.iView
{
	using System.Windows.Forms;
	using System;

	public partial class DigitalTagConfigurator : Form
	{
		#region FIELDS
		#endregion

		#region CONSTRUCTORS
		public DigitalTagConfigurator()
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
			
			textBoxName.Text = ((TagDigital)Tag).Name;
			textBoxDescription.Text = ((TagDigital)Tag).Description;
			txbAddress.Text = ((TagDigital)Tag).Address;
			cbDriver.SelectedItem = ((TagDigital)Tag).Driver;
			chkBoxHistorical.Checked = ((TagDigital)Tag).Historical;
			
			chkBoxOnOpen.Checked = ((TagDigital)Tag).OnOpenChk;
			txtBoxOnOpenMsg.Text = ((TagDigital)Tag).OnOpenMsg;
			chkBoxOnClose.Checked = ((TagDigital)Tag).OnCloseChk;
			txtBoxOnCloseMsg.Text = ((TagDigital)Tag).OnCloseMsg;
		}
		private void ButtonOkClick(object sender, EventArgs e)
		{
			if (Tag == null)
				return;
			
			((TagDigital)Tag).Name = textBoxName.Text;
			((TagDigital)Tag).Description = textBoxDescription.Text;
			((TagDigital)Tag).Address = txbAddress.Text;
			((TagDigital)Tag).Driver = cbDriver.SelectedItem as IDriver;
			((TagDigital)Tag).Historical = chkBoxHistorical.Checked;
			
			((TagDigital)Tag).OnOpenChk = chkBoxOnOpen.Checked;
			((TagDigital)Tag).OnOpenMsg = txtBoxOnOpenMsg.Text;
			((TagDigital)Tag).OnCloseChk = chkBoxOnClose.Checked;
			((TagDigital)Tag).OnCloseMsg = txtBoxOnCloseMsg.Text;
		}
		#endregion
	}
}

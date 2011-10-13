using System.Windows.Forms;
using System;

namespace Aimirim.iView
{
	public partial class AnalogTagConfigurator : Form
	{
		#region FIELDS
		#endregion

		#region CONSTRUCTORS
		public AnalogTagConfigurator()
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

			if (((TagAnalog)Tag).SignalCondition != null)
			{
				cbSignalCondition.Items.Add(((TagAnalog)Tag).SignalCondition);
			}
			else
			{
				cbSignalCondition.Items.Add(new SignalCondition16383());
			}
			
			textBoxName.Text = ((TagAnalog)Tag).Name;
			textBoxDescription.Text = ((TagAnalog)Tag).Description;
			txbAddress.Text = ((TagAnalog)Tag).Address;
			cbDriver.SelectedItem = ((TagAnalog)Tag).Driver;
			chkBoxHistorical.Checked = ((TagAnalog)Tag).Historical;
			cbSignalCondition.SelectedItem = ((TagAnalog)Tag).SignalCondition;
			textBoxMin.Text = ((TagAnalog)Tag).Min;
			textBoxMax.Text = ((TagAnalog)Tag).Max;
			
			chkBoxLow.Checked = ((TagAnalog)Tag).LowChk;
			txtBoxLow.Text = ((TagAnalog)Tag).LowVl;
			txtBoxLowMsg.Text = ((TagAnalog)Tag).LowMsg;

			chkBoxLowLow.Checked = ((TagAnalog)Tag).LowLowChk;
			txtBoxLowLow.Text = ((TagAnalog)Tag).LowLowVl;
			txtBoxLowMsg.Text = ((TagAnalog)Tag).LowLowMsg;

			chkBoxHi.Checked = ((TagAnalog)Tag).HiChk;
			txtBoxHi.Text = ((TagAnalog)Tag).HiVl;
			txtBoxHiMsg.Text = ((TagAnalog)Tag).HiMsg;

			chkBoxHiHi.Checked = ((TagAnalog)Tag).HiHiChk;
			txtBoxHiHi.Text = ((TagAnalog)Tag).HiHiVl;
			txtBoxHiHiMsg.Text = ((TagAnalog)Tag).HiHiMsg;
		}
		private void ButtonOkClick(object sender, EventArgs e)
		{
			if (Tag == null)
				return;
			
			((TagAnalog)Tag).Name = textBoxName.Text;
			((TagAnalog)Tag).Description = textBoxDescription.Text;
			((TagAnalog)Tag).Address = txbAddress.Text;
			((TagAnalog)Tag).Driver = cbDriver.SelectedItem as IDriver;
			((TagAnalog)Tag).Historical = chkBoxHistorical.Checked;
			((TagAnalog)Tag).SignalCondition = cbSignalCondition.SelectedItem as ISignalCondition;
			((TagAnalog)Tag).Min = textBoxMin.Text;
			((TagAnalog)Tag).Max = textBoxMax.Text;
			
			((TagAnalog)Tag).LowChk = chkBoxLow.Checked;
			((TagAnalog)Tag).LowVl = txtBoxLow.Text;
			((TagAnalog)Tag).LowMsg = txtBoxLowMsg.Text;
			
			((TagAnalog)Tag).LowLowChk = chkBoxLowLow.Checked;
			((TagAnalog)Tag).LowLowVl = txtBoxLowLow.Text;
			((TagAnalog)Tag).LowLowMsg = txtBoxLowLowMsg.Text;
			
			((TagAnalog)Tag).HiChk = chkBoxHi.Checked;
			((TagAnalog)Tag).HiVl = txtBoxHi.Text;
			((TagAnalog)Tag).HiMsg = txtBoxHiMsg.Text;
			
			((TagAnalog)Tag).HiHiChk = chkBoxHiHi.Checked;
			((TagAnalog)Tag).HiHiVl = txtBoxHiHi.Text;
			((TagAnalog)Tag).HiHiMsg = txtBoxHiHiMsg.Text;
		}
		#endregion
	}
}

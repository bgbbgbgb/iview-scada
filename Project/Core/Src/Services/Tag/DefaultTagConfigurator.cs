
namespace Aimirim.iView
{
	using System.Windows.Forms;
	using System;

	public partial class DefaultTagConfigurator : Form
	{
		#region FIELDS
		#endregion

		#region CONSTRUCTORS
		public DefaultTagConfigurator()
		{
			InitializeComponent();
		}
		#endregion

		#region METHODS
		void TagConfiguratorLoad(object sender, EventArgs e)
		{
			cbDriver.Items.AddRange(DriverManager.Instance.Drivers.ToArray());
			
			if (Tag == null)
				return;
			
			textBoxName.Text = ((ITag)Tag).Name;
			textBoxDescription.Text = ((ITag)Tag).Description;
			txbAddress.Text = ((ITag)Tag).Address;
			cbDriver.SelectedItem = ((ITag)Tag).Driver;
		}
		void ButtonOkClick(object sender, EventArgs e)
		{
			if (Tag == null)
				return;
			
			((ITag)Tag).Name = textBoxName.Text;
			((ITag)Tag).Description = textBoxDescription.Text;
			((ITag)Tag).Address = txbAddress.Text;
			((ITag)Tag).Driver = cbDriver.SelectedItem as IDriver;
		}
		#endregion
	}
}

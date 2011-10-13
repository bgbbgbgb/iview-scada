
namespace Aimirim.iView
{
    using System;
    using System.Windows.Forms;

    public partial class SelectNewTag : Form
    {
        public SelectNewTag()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        void SelectNewTagLoad(object sender, EventArgs e)
        {
        	   listBox1.SelectedIndex = 0;
        }
    }
}



namespace Aimirim.iView
{
    using System.Windows.Forms;
    using System;

    public partial class DeleteControlForm : Form
    {
        #region FIELDS
        #endregion
        public string Message
        {
          get
          {
            return labelName.Text;
          }
          set
          {
            labelName.Text = value;
          }
        }

        #region CONSTRUCTORS
        public DeleteControlForm()
        {
            InitializeComponent();
        }
        #endregion

        #region METHODS
        #endregion
    }
}

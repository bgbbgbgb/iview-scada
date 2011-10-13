namespace Aimirim.iView
{
    partial class DataSourceCfg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.buttonOk = new System.Windows.Forms.Button();
        	this.buttonCancel = new System.Windows.Forms.Button();
        	this.textBoxAlias = new System.Windows.Forms.TextBox();
        	this.labelAlias = new System.Windows.Forms.Label();
        	this.cbxDsn = new System.Windows.Forms.ComboBox();
        	this.labelDsn = new System.Windows.Forms.Label();
        	this.labelUid = new System.Windows.Forms.Label();
        	this.txbUid = new System.Windows.Forms.TextBox();
        	this.labelPwd = new System.Windows.Forms.Label();
        	this.txbPwd = new System.Windows.Forms.TextBox();
        	this.SuspendLayout();
        	// 
        	// buttonOk
        	// 
        	this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonOk.Location = new System.Drawing.Point(11, 187);
        	this.buttonOk.Margin = new System.Windows.Forms.Padding(2);
        	this.buttonOk.Name = "buttonOk";
        	this.buttonOk.Size = new System.Drawing.Size(90, 29);
        	this.buttonOk.TabIndex = 18;
        	this.buttonOk.Text = "Ok";
        	this.buttonOk.UseVisualStyleBackColor = true;
        	this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
        	// 
        	// buttonCancel
        	// 
        	this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.buttonCancel.Location = new System.Drawing.Point(110, 187);
        	this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Size = new System.Drawing.Size(90, 29);
        	this.buttonCancel.TabIndex = 19;
        	this.buttonCancel.Text = "Cancel";
        	this.buttonCancel.UseVisualStyleBackColor = true;
        	// 
        	// textBoxAlias
        	// 
        	this.textBoxAlias.Location = new System.Drawing.Point(11, 24);
        	this.textBoxAlias.Margin = new System.Windows.Forms.Padding(2);
        	this.textBoxAlias.Name = "textBoxAlias";
        	this.textBoxAlias.Size = new System.Drawing.Size(188, 20);
        	this.textBoxAlias.TabIndex = 1;
        	// 
        	// labelAlias
        	// 
        	this.labelAlias.AutoSize = true;
        	this.labelAlias.Location = new System.Drawing.Point(11, 9);
        	this.labelAlias.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.labelAlias.Name = "labelAlias";
        	this.labelAlias.Size = new System.Drawing.Size(42, 13);
        	this.labelAlias.TabIndex = 0;
        	this.labelAlias.Text = "Apelido";
        	// 
        	// cbxDsn
        	// 
        	this.cbxDsn.FormattingEnabled = true;
        	this.cbxDsn.Location = new System.Drawing.Point(11, 65);
        	this.cbxDsn.Name = "cbxDsn";
        	this.cbxDsn.Size = new System.Drawing.Size(188, 21);
        	this.cbxDsn.TabIndex = 9;
        	// 
        	// labelDsn
        	// 
        	this.labelDsn.AutoSize = true;
        	this.labelDsn.Location = new System.Drawing.Point(11, 49);
        	this.labelDsn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.labelDsn.Name = "labelDsn";
        	this.labelDsn.Size = new System.Drawing.Size(120, 13);
        	this.labelDsn.TabIndex = 8;
        	this.labelDsn.Text = "Fonte de dados (ODBC)";
        	// 
        	// labelUid
        	// 
        	this.labelUid.AutoSize = true;
        	this.labelUid.Location = new System.Drawing.Point(11, 90);
        	this.labelUid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.labelUid.Name = "labelUid";
        	this.labelUid.Size = new System.Drawing.Size(43, 13);
        	this.labelUid.TabIndex = 10;
        	this.labelUid.Text = "Usuário";
        	// 
        	// txbUid
        	// 
        	this.txbUid.Location = new System.Drawing.Point(11, 106);
        	this.txbUid.Margin = new System.Windows.Forms.Padding(2);
        	this.txbUid.Name = "txbUid";
        	this.txbUid.Size = new System.Drawing.Size(188, 20);
        	this.txbUid.TabIndex = 11;
        	// 
        	// labelPwd
        	// 
        	this.labelPwd.AutoSize = true;
        	this.labelPwd.Location = new System.Drawing.Point(11, 131);
        	this.labelPwd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.labelPwd.Name = "labelPwd";
        	this.labelPwd.Size = new System.Drawing.Size(38, 13);
        	this.labelPwd.TabIndex = 12;
        	this.labelPwd.Text = "Senha";
        	// 
        	// txbPwd
        	// 
        	this.txbPwd.Location = new System.Drawing.Point(11, 147);
        	this.txbPwd.Margin = new System.Windows.Forms.Padding(2);
        	this.txbPwd.Name = "txbPwd";
        	this.txbPwd.PasswordChar = '*';
        	this.txbPwd.Size = new System.Drawing.Size(188, 20);
        	this.txbPwd.TabIndex = 13;
        	// 
        	// DataSourceCfg
        	// 
        	this.AcceptButton = this.buttonOk;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.ClientSize = new System.Drawing.Size(211, 227);
        	this.Controls.Add(this.cbxDsn);
        	this.Controls.Add(this.textBoxAlias);
        	this.Controls.Add(this.labelDsn);
        	this.Controls.Add(this.txbPwd);
        	this.Controls.Add(this.txbUid);
        	this.Controls.Add(this.labelAlias);
        	this.Controls.Add(this.labelPwd);
        	this.Controls.Add(this.labelUid);
        	this.Controls.Add(this.buttonCancel);
        	this.Controls.Add(this.buttonOk);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "DataSourceCfg";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "DS Config";
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        public System.Windows.Forms.TextBox textBoxAlias;
        private System.Windows.Forms.Label labelAlias;
        public System.Windows.Forms.ComboBox cbxDsn;
        private System.Windows.Forms.Label labelDsn;
        private System.Windows.Forms.Label labelUid;
        private System.Windows.Forms.Label labelPwd;
        public System.Windows.Forms.TextBox txbUid;
        public System.Windows.Forms.TextBox txbPwd;

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}
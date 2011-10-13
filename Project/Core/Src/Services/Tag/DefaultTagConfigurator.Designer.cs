namespace Aimirim.iView
{
    partial class DefaultTagConfigurator
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
        	this.lblAddress = new System.Windows.Forms.Label();
        	this.cbDriver = new System.Windows.Forms.ComboBox();
        	this.textBoxName = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.txbAddress = new System.Windows.Forms.TextBox();
        	this.labelName = new System.Windows.Forms.Label();
        	this.textBoxDescription = new System.Windows.Forms.TextBox();
        	this.labelDescription = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// buttonOk
        	// 
        	this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonOk.Location = new System.Drawing.Point(191, 117);
        	this.buttonOk.Margin = new System.Windows.Forms.Padding(2);
        	this.buttonOk.Name = "buttonOk";
        	this.buttonOk.Size = new System.Drawing.Size(90, 29);
        	this.buttonOk.TabIndex = 8;
        	this.buttonOk.Text = "Ok";
        	this.buttonOk.UseVisualStyleBackColor = true;
        	this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
        	// 
        	// buttonCancel
        	// 
        	this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.buttonCancel.Location = new System.Drawing.Point(286, 117);
        	this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Size = new System.Drawing.Size(90, 29);
        	this.buttonCancel.TabIndex = 9;
        	this.buttonCancel.Text = "Cancel";
        	this.buttonCancel.UseVisualStyleBackColor = true;
        	// 
        	// lblAddress
        	// 
        	this.lblAddress.AutoSize = true;
        	this.lblAddress.Location = new System.Drawing.Point(239, 51);
        	this.lblAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.lblAddress.Name = "lblAddress";
        	this.lblAddress.Size = new System.Drawing.Size(53, 13);
        	this.lblAddress.TabIndex = 6;
        	this.lblAddress.Text = "Endereço";
        	// 
        	// cbDriver
        	// 
        	this.cbDriver.FormattingEnabled = true;
        	this.cbDriver.Location = new System.Drawing.Point(12, 67);
        	this.cbDriver.Name = "cbDriver";
        	this.cbDriver.Size = new System.Drawing.Size(222, 21);
        	this.cbDriver.TabIndex = 5;
        	// 
        	// textBoxName
        	// 
        	this.textBoxName.Location = new System.Drawing.Point(11, 24);
        	this.textBoxName.Margin = new System.Windows.Forms.Padding(2);
        	this.textBoxName.Name = "textBoxName";
        	this.textBoxName.Size = new System.Drawing.Size(110, 20);
        	this.textBoxName.TabIndex = 1;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(12, 51);
        	this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(35, 13);
        	this.label1.TabIndex = 4;
        	this.label1.Text = "Driver";
        	// 
        	// txbAddress
        	// 
        	this.txbAddress.Location = new System.Drawing.Point(239, 67);
        	this.txbAddress.Margin = new System.Windows.Forms.Padding(2);
        	this.txbAddress.Name = "txbAddress";
        	this.txbAddress.Size = new System.Drawing.Size(138, 20);
        	this.txbAddress.TabIndex = 7;
        	// 
        	// labelName
        	// 
        	this.labelName.AutoSize = true;
        	this.labelName.Location = new System.Drawing.Point(11, 9);
        	this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.labelName.Name = "labelName";
        	this.labelName.Size = new System.Drawing.Size(35, 13);
        	this.labelName.TabIndex = 0;
        	this.labelName.Text = "Nome";
        	// 
        	// textBoxDescription
        	// 
        	this.textBoxDescription.Location = new System.Drawing.Point(125, 24);
        	this.textBoxDescription.Margin = new System.Windows.Forms.Padding(2);
        	this.textBoxDescription.Name = "textBoxDescription";
        	this.textBoxDescription.Size = new System.Drawing.Size(252, 20);
        	this.textBoxDescription.TabIndex = 3;
        	// 
        	// labelDescription
        	// 
        	this.labelDescription.AutoSize = true;
        	this.labelDescription.Location = new System.Drawing.Point(125, 9);
        	this.labelDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.labelDescription.Name = "labelDescription";
        	this.labelDescription.Size = new System.Drawing.Size(55, 13);
        	this.labelDescription.TabIndex = 2;
        	this.labelDescription.Text = "Descrição";
        	// 
        	// DefaultTagConfigurator
        	// 
        	this.AcceptButton = this.buttonOk;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.ClientSize = new System.Drawing.Size(387, 157);
        	this.Controls.Add(this.cbDriver);
        	this.Controls.Add(this.textBoxName);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.txbAddress);
        	this.Controls.Add(this.labelName);
        	this.Controls.Add(this.textBoxDescription);
        	this.Controls.Add(this.labelDescription);
        	this.Controls.Add(this.lblAddress);
        	this.Controls.Add(this.buttonCancel);
        	this.Controls.Add(this.buttonOk);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "DefaultTagConfigurator";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Tag Configurator";
        	this.Load += new System.EventHandler(this.TagConfiguratorLoad);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ComboBox cbDriver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAddress;
        public System.Windows.Forms.TextBox txbAddress;

        #endregion

        private System.Windows.Forms.Label labelName;
        public System.Windows.Forms.TextBox textBoxName;
        public System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}
namespace Aimirim.iView
{
    partial class AnalogTagConfigurator
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
        	this.chkBoxHistorical = new System.Windows.Forms.CheckBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.cbSignalCondition = new System.Windows.Forms.ComboBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.textBoxMin = new System.Windows.Forms.TextBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.textBoxMax = new System.Windows.Forms.TextBox();
        	this.txtBoxLow = new System.Windows.Forms.TextBox();
        	this.chkBoxLow = new System.Windows.Forms.CheckBox();
        	this.grpBoxAlarm = new System.Windows.Forms.GroupBox();
        	this.txtBoxHi = new System.Windows.Forms.TextBox();
        	this.txtBoxHiHi = new System.Windows.Forms.TextBox();
        	this.chkBoxHi = new System.Windows.Forms.CheckBox();
        	this.txtBoxLowLow = new System.Windows.Forms.TextBox();
        	this.chkBoxHiHi = new System.Windows.Forms.CheckBox();
        	this.chkBoxLowLow = new System.Windows.Forms.CheckBox();
        	this.txtBoxLowLowMsg = new System.Windows.Forms.TextBox();
        	this.txtBoxLowMsg = new System.Windows.Forms.TextBox();
        	this.txtBoxHiHiMsg = new System.Windows.Forms.TextBox();
        	this.txtBoxHiMsg = new System.Windows.Forms.TextBox();
        	this.lblMensagem = new System.Windows.Forms.Label();
        	this.lblLimite = new System.Windows.Forms.Label();
        	this.grpBoxAlarm.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// buttonOk
        	// 
        	this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonOk.Location = new System.Drawing.Point(191, 401);
        	this.buttonOk.Margin = new System.Windows.Forms.Padding(2);
        	this.buttonOk.Name = "buttonOk";
        	this.buttonOk.Size = new System.Drawing.Size(90, 29);
        	this.buttonOk.TabIndex = 16;
        	this.buttonOk.Text = "Ok";
        	this.buttonOk.UseVisualStyleBackColor = true;
        	this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
        	// 
        	// buttonCancel
        	// 
        	this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.buttonCancel.Location = new System.Drawing.Point(286, 401);
        	this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Size = new System.Drawing.Size(90, 29);
        	this.buttonCancel.TabIndex = 17;
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
        	this.cbDriver.Location = new System.Drawing.Point(11, 67);
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
        	this.label1.Location = new System.Drawing.Point(11, 51);
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
        	// chkBoxHistorical
        	// 
        	this.chkBoxHistorical.AutoSize = true;
        	this.chkBoxHistorical.Location = new System.Drawing.Point(310, 104);
        	this.chkBoxHistorical.Name = "chkBoxHistorical";
        	this.chkBoxHistorical.Size = new System.Drawing.Size(67, 17);
        	this.chkBoxHistorical.TabIndex = 8;
        	this.chkBoxHistorical.Text = "Histórico";
        	this.chkBoxHistorical.UseVisualStyleBackColor = true;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(11, 129);
        	this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(83, 13);
        	this.label2.TabIndex = 9;
        	this.label2.Text = "Signal Condition";
        	// 
        	// cbSignalCondition
        	// 
        	this.cbSignalCondition.FormattingEnabled = true;
        	this.cbSignalCondition.Location = new System.Drawing.Point(11, 145);
        	this.cbSignalCondition.Name = "cbSignalCondition";
        	this.cbSignalCondition.Size = new System.Drawing.Size(366, 21);
        	this.cbSignalCondition.TabIndex = 10;
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(11, 169);
        	this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(24, 13);
        	this.label3.TabIndex = 11;
        	this.label3.Text = "Min";
        	// 
        	// textBoxMin
        	// 
        	this.textBoxMin.Location = new System.Drawing.Point(11, 184);
        	this.textBoxMin.Margin = new System.Windows.Forms.Padding(2);
        	this.textBoxMin.Name = "textBoxMin";
        	this.textBoxMin.Size = new System.Drawing.Size(82, 20);
        	this.textBoxMin.TabIndex = 12;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(98, 169);
        	this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(27, 13);
        	this.label4.TabIndex = 13;
        	this.label4.Text = "Max";
        	// 
        	// textBoxMax
        	// 
        	this.textBoxMax.Location = new System.Drawing.Point(98, 184);
        	this.textBoxMax.Margin = new System.Windows.Forms.Padding(2);
        	this.textBoxMax.Name = "textBoxMax";
        	this.textBoxMax.Size = new System.Drawing.Size(82, 20);
        	this.textBoxMax.TabIndex = 14;
        	// 
        	// txtBoxLow
        	// 
        	this.txtBoxLow.Location = new System.Drawing.Point(85, 66);
        	this.txtBoxLow.Margin = new System.Windows.Forms.Padding(2);
        	this.txtBoxLow.Name = "txtBoxLow";
        	this.txtBoxLow.Size = new System.Drawing.Size(53, 20);
        	this.txtBoxLow.TabIndex = 6;
        	// 
        	// chkBoxLow
        	// 
        	this.chkBoxLow.AutoSize = true;
        	this.chkBoxLow.Location = new System.Drawing.Point(16, 68);
        	this.chkBoxLow.Name = "chkBoxLow";
        	this.chkBoxLow.Size = new System.Drawing.Size(46, 17);
        	this.chkBoxLow.TabIndex = 5;
        	this.chkBoxLow.Text = "Low";
        	this.chkBoxLow.UseVisualStyleBackColor = true;
        	// 
        	// grpBoxAlarm
        	// 
        	this.grpBoxAlarm.Controls.Add(this.txtBoxHiMsg);
        	this.grpBoxAlarm.Controls.Add(this.txtBoxHi);
        	this.grpBoxAlarm.Controls.Add(this.txtBoxHiHiMsg);
        	this.grpBoxAlarm.Controls.Add(this.txtBoxLowMsg);
        	this.grpBoxAlarm.Controls.Add(this.lblLimite);
        	this.grpBoxAlarm.Controls.Add(this.lblMensagem);
        	this.grpBoxAlarm.Controls.Add(this.txtBoxHiHi);
        	this.grpBoxAlarm.Controls.Add(this.txtBoxLow);
        	this.grpBoxAlarm.Controls.Add(this.txtBoxLowLowMsg);
        	this.grpBoxAlarm.Controls.Add(this.chkBoxHi);
        	this.grpBoxAlarm.Controls.Add(this.txtBoxLowLow);
        	this.grpBoxAlarm.Controls.Add(this.chkBoxHiHi);
        	this.grpBoxAlarm.Controls.Add(this.chkBoxLow);
        	this.grpBoxAlarm.Controls.Add(this.chkBoxLowLow);
        	this.grpBoxAlarm.Location = new System.Drawing.Point(11, 223);
        	this.grpBoxAlarm.Name = "grpBoxAlarm";
        	this.grpBoxAlarm.Size = new System.Drawing.Size(366, 163);
        	this.grpBoxAlarm.TabIndex = 15;
        	this.grpBoxAlarm.TabStop = false;
        	this.grpBoxAlarm.Text = "Alarme";
        	// 
        	// txtBoxHi
        	// 
        	this.txtBoxHi.Location = new System.Drawing.Point(85, 90);
        	this.txtBoxHi.Margin = new System.Windows.Forms.Padding(2);
        	this.txtBoxHi.Name = "txtBoxHi";
        	this.txtBoxHi.Size = new System.Drawing.Size(53, 20);
        	this.txtBoxHi.TabIndex = 9;
        	// 
        	// txtBoxHiHi
        	// 
        	this.txtBoxHiHi.Location = new System.Drawing.Point(85, 114);
        	this.txtBoxHiHi.Margin = new System.Windows.Forms.Padding(2);
        	this.txtBoxHiHi.Name = "txtBoxHiHi";
        	this.txtBoxHiHi.Size = new System.Drawing.Size(53, 20);
        	this.txtBoxHiHi.TabIndex = 12;
        	// 
        	// chkBoxHi
        	// 
        	this.chkBoxHi.AutoSize = true;
        	this.chkBoxHi.Location = new System.Drawing.Point(16, 92);
        	this.chkBoxHi.Name = "chkBoxHi";
        	this.chkBoxHi.Size = new System.Drawing.Size(36, 17);
        	this.chkBoxHi.TabIndex = 8;
        	this.chkBoxHi.Text = "Hi";
        	this.chkBoxHi.UseVisualStyleBackColor = true;
        	// 
        	// txtBoxLowLow
        	// 
        	this.txtBoxLowLow.Location = new System.Drawing.Point(85, 42);
        	this.txtBoxLowLow.Margin = new System.Windows.Forms.Padding(2);
        	this.txtBoxLowLow.Name = "txtBoxLowLow";
        	this.txtBoxLowLow.Size = new System.Drawing.Size(53, 20);
        	this.txtBoxLowLow.TabIndex = 3;
        	// 
        	// chkBoxHiHi
        	// 
        	this.chkBoxHiHi.AutoSize = true;
        	this.chkBoxHiHi.Location = new System.Drawing.Point(16, 116);
        	this.chkBoxHiHi.Name = "chkBoxHiHi";
        	this.chkBoxHiHi.Size = new System.Drawing.Size(46, 17);
        	this.chkBoxHiHi.TabIndex = 11;
        	this.chkBoxHiHi.Text = "HiHi";
        	this.chkBoxHiHi.UseVisualStyleBackColor = true;
        	// 
        	// chkBoxLowLow
        	// 
        	this.chkBoxLowLow.AutoSize = true;
        	this.chkBoxLowLow.Location = new System.Drawing.Point(16, 44);
        	this.chkBoxLowLow.Name = "chkBoxLowLow";
        	this.chkBoxLowLow.Size = new System.Drawing.Size(66, 17);
        	this.chkBoxLowLow.TabIndex = 2;
        	this.chkBoxLowLow.Text = "LowLow";
        	this.chkBoxLowLow.UseVisualStyleBackColor = true;
        	// 
        	// txtBoxLowLowMsg
        	// 
        	this.txtBoxLowLowMsg.Location = new System.Drawing.Point(142, 41);
        	this.txtBoxLowLowMsg.Margin = new System.Windows.Forms.Padding(2);
        	this.txtBoxLowLowMsg.Name = "txtBoxLowLowMsg";
        	this.txtBoxLowLowMsg.Size = new System.Drawing.Size(209, 20);
        	this.txtBoxLowLowMsg.TabIndex = 4;
        	// 
        	// txtBoxLowMsg
        	// 
        	this.txtBoxLowMsg.Location = new System.Drawing.Point(142, 65);
        	this.txtBoxLowMsg.Margin = new System.Windows.Forms.Padding(2);
        	this.txtBoxLowMsg.Name = "txtBoxLowMsg";
        	this.txtBoxLowMsg.Size = new System.Drawing.Size(209, 20);
        	this.txtBoxLowMsg.TabIndex = 7;
        	// 
        	// txtBoxHiHiMsg
        	// 
        	this.txtBoxHiHiMsg.Location = new System.Drawing.Point(142, 113);
        	this.txtBoxHiHiMsg.Margin = new System.Windows.Forms.Padding(2);
        	this.txtBoxHiHiMsg.Name = "txtBoxHiHiMsg";
        	this.txtBoxHiHiMsg.Size = new System.Drawing.Size(209, 20);
        	this.txtBoxHiHiMsg.TabIndex = 13;
        	// 
        	// txtBoxHiMsg
        	// 
        	this.txtBoxHiMsg.Location = new System.Drawing.Point(142, 89);
        	this.txtBoxHiMsg.Margin = new System.Windows.Forms.Padding(2);
        	this.txtBoxHiMsg.Name = "txtBoxHiMsg";
        	this.txtBoxHiMsg.Size = new System.Drawing.Size(209, 20);
        	this.txtBoxHiMsg.TabIndex = 10;
        	// 
        	// lblMensagem
        	// 
        	this.lblMensagem.AutoSize = true;
        	this.lblMensagem.Location = new System.Drawing.Point(142, 26);
        	this.lblMensagem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.lblMensagem.Name = "lblMensagem";
        	this.lblMensagem.Size = new System.Drawing.Size(59, 13);
        	this.lblMensagem.TabIndex = 1;
        	this.lblMensagem.Text = "Mensagem";
        	// 
        	// lblLimite
        	// 
        	this.lblLimite.AutoSize = true;
        	this.lblLimite.Location = new System.Drawing.Point(85, 27);
        	this.lblLimite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.lblLimite.Name = "lblLimite";
        	this.lblLimite.Size = new System.Drawing.Size(34, 13);
        	this.lblLimite.TabIndex = 0;
        	this.lblLimite.Text = "Limite";
        	// 
        	// AnalogTagConfigurator
        	// 
        	this.AcceptButton = this.buttonOk;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.ClientSize = new System.Drawing.Size(387, 441);
        	this.Controls.Add(this.grpBoxAlarm);
        	this.Controls.Add(this.chkBoxHistorical);
        	this.Controls.Add(this.cbSignalCondition);
        	this.Controls.Add(this.cbDriver);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.textBoxMax);
        	this.Controls.Add(this.textBoxMin);
        	this.Controls.Add(this.textBoxName);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.txbAddress);
        	this.Controls.Add(this.labelName);
        	this.Controls.Add(this.textBoxDescription);
        	this.Controls.Add(this.labelDescription);
        	this.Controls.Add(this.lblAddress);
        	this.Controls.Add(this.buttonCancel);
        	this.Controls.Add(this.buttonOk);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "AnalogTagConfigurator";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Tag Configurator";
        	this.Load += new System.EventHandler(this.TagConfiguratorLoad);
        	this.grpBoxAlarm.ResumeLayout(false);
        	this.grpBoxAlarm.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        public System.Windows.Forms.TextBox txtBoxLowLowMsg;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Label lblLimite;
        public System.Windows.Forms.TextBox txtBoxLowMsg;
        public System.Windows.Forms.TextBox txtBoxHiHiMsg;
        public System.Windows.Forms.TextBox txtBoxHiMsg;
        private System.Windows.Forms.CheckBox chkBoxLowLow;
        private System.Windows.Forms.CheckBox chkBoxHiHi;
        public System.Windows.Forms.TextBox txtBoxLowLow;
        private System.Windows.Forms.CheckBox chkBoxHi;
        public System.Windows.Forms.TextBox txtBoxHiHi;
        public System.Windows.Forms.TextBox txtBoxHi;
        private System.Windows.Forms.GroupBox grpBoxAlarm;
        private System.Windows.Forms.CheckBox chkBoxLow;
        public System.Windows.Forms.TextBox txtBoxLow;
        public System.Windows.Forms.TextBox textBoxMax;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSignalCondition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkBoxHistorical;
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
namespace Aimirim.iView
{
    partial class SqlTagConfigurator
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
        	this.label2 = new System.Windows.Forms.Label();
        	this.txbSqlCommand = new System.Windows.Forms.TextBox();
        	this.dgvParams = new System.Windows.Forms.DataGridView();
        	this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label4 = new System.Windows.Forms.Label();
        	this.txbDsn = new System.Windows.Forms.TextBox();
        	this.rbOnChange = new System.Windows.Forms.RadioButton();
        	this.rbOnOpen = new System.Windows.Forms.RadioButton();
        	this.rbOnClose = new System.Windows.Forms.RadioButton();
        	((System.ComponentModel.ISupportInitialize)(this.dgvParams)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// buttonOk
        	// 
        	this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonOk.Location = new System.Drawing.Point(191, 436);
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
        	this.buttonCancel.Location = new System.Drawing.Point(286, 436);
        	this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Size = new System.Drawing.Size(90, 29);
        	this.buttonCancel.TabIndex = 19;
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
        	this.txbAddress.Size = new System.Drawing.Size(137, 20);
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
        	this.textBoxDescription.Size = new System.Drawing.Size(251, 20);
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
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(12, 147);
        	this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(76, 13);
        	this.label2.TabIndex = 14;
        	this.label2.Text = "Comando SQL";
        	// 
        	// txbSqlCommand
        	// 
        	this.txbSqlCommand.Location = new System.Drawing.Point(12, 162);
        	this.txbSqlCommand.Margin = new System.Windows.Forms.Padding(2);
        	this.txbSqlCommand.Multiline = true;
        	this.txbSqlCommand.Name = "txbSqlCommand";
        	this.txbSqlCommand.Size = new System.Drawing.Size(365, 79);
        	this.txbSqlCommand.TabIndex = 15;
        	// 
        	// dgvParams
        	// 
        	this.dgvParams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        	this.dgvParams.BackgroundColor = System.Drawing.Color.White;
        	this.dgvParams.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.dgvParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvParams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.ColumnName,
        	        	        	this.ColumnValue});
        	this.dgvParams.Location = new System.Drawing.Point(12, 268);
        	this.dgvParams.Name = "dgvParams";
        	this.dgvParams.RowHeadersWidth = 10;
        	this.dgvParams.Size = new System.Drawing.Size(365, 127);
        	this.dgvParams.TabIndex = 17;
        	// 
        	// ColumnName
        	// 
        	this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.ColumnName.DataPropertyName = "Name";
        	this.ColumnName.HeaderText = "Nome";
        	this.ColumnName.Name = "ColumnName";
        	// 
        	// ColumnValue
        	// 
        	this.ColumnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.ColumnValue.DataPropertyName = "Value";
        	this.ColumnValue.HeaderText = "Valor";
        	this.ColumnValue.Name = "ColumnValue";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(12, 252);
        	this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(60, 13);
        	this.label3.TabIndex = 16;
        	this.label3.Text = "Parâmetros";
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(11, 98);
        	this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(120, 13);
        	this.label4.TabIndex = 8;
        	this.label4.Text = "Fonte de dados (ODBC)";
        	// 
        	// txbDsn
        	// 
        	this.txbDsn.Location = new System.Drawing.Point(11, 113);
        	this.txbDsn.Margin = new System.Windows.Forms.Padding(2);
        	this.txbDsn.Name = "txbDsn";
        	this.txbDsn.Size = new System.Drawing.Size(365, 20);
        	this.txbDsn.TabIndex = 11;
        	// 
        	// rbOnChange
        	// 
        	this.rbOnChange.AutoSize = true;
        	this.rbOnChange.Location = new System.Drawing.Point(13, 402);
        	this.rbOnChange.Name = "rbOnChange";
        	this.rbOnChange.Size = new System.Drawing.Size(70, 17);
        	this.rbOnChange.TabIndex = 20;
        	this.rbOnChange.TabStop = true;
        	this.rbOnChange.Text = "Ao mudar";
        	this.rbOnChange.UseVisualStyleBackColor = true;
        	// 
        	// rbOnOpen
        	// 
        	this.rbOnOpen.AutoSize = true;
        	this.rbOnOpen.Location = new System.Drawing.Point(98, 402);
        	this.rbOnOpen.Name = "rbOnOpen";
        	this.rbOnOpen.Size = new System.Drawing.Size(80, 17);
        	this.rbOnOpen.TabIndex = 20;
        	this.rbOnOpen.TabStop = true;
        	this.rbOnOpen.Text = "Igual a zero";
        	this.rbOnOpen.UseVisualStyleBackColor = true;
        	// 
        	// rbOnClose
        	// 
        	this.rbOnClose.AutoSize = true;
        	this.rbOnClose.Location = new System.Drawing.Point(184, 401);
        	this.rbOnClose.Name = "rbOnClose";
        	this.rbOnClose.Size = new System.Drawing.Size(74, 17);
        	this.rbOnClose.TabIndex = 20;
        	this.rbOnClose.TabStop = true;
        	this.rbOnClose.Text = "Igual a um";
        	this.rbOnClose.UseVisualStyleBackColor = true;
        	// 
        	// SqlTagConfigurator
        	// 
        	this.AcceptButton = this.buttonOk;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.ClientSize = new System.Drawing.Size(387, 476);
        	this.Controls.Add(this.rbOnClose);
        	this.Controls.Add(this.rbOnOpen);
        	this.Controls.Add(this.rbOnChange);
        	this.Controls.Add(this.dgvParams);
        	this.Controls.Add(this.cbDriver);
        	this.Controls.Add(this.textBoxName);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.txbSqlCommand);
        	this.Controls.Add(this.txbDsn);
        	this.Controls.Add(this.txbAddress);
        	this.Controls.Add(this.labelName);
        	this.Controls.Add(this.textBoxDescription);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.labelDescription);
        	this.Controls.Add(this.lblAddress);
        	this.Controls.Add(this.buttonCancel);
        	this.Controls.Add(this.buttonOk);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "SqlTagConfigurator";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Tag Configurator";
        	this.Load += new System.EventHandler(this.TagConfiguratorLoad);
        	((System.ComponentModel.ISupportInitialize)(this.dgvParams)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        public System.Windows.Forms.TextBox txbDsn;
        private System.Windows.Forms.RadioButton rbOnClose;
        private System.Windows.Forms.RadioButton rbOnOpen;
        private System.Windows.Forms.RadioButton rbOnChange;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txbSqlCommand;
        private System.Windows.Forms.DataGridView dgvParams;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.Label label2;
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
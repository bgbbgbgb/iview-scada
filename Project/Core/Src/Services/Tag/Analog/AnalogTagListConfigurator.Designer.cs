namespace Aimirim.iView
{
    partial class AnalogTagListConfigurator
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
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.dataGridView1 = new System.Windows.Forms.DataGridView();
        	this.tgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.TgDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.TgDriver = new System.Windows.Forms.DataGridViewComboBoxColumn();
        	this.TgEndereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.TgHistorico = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        	this.signalCondition = new System.Windows.Forms.DataGridViewComboBoxColumn();
        	this.min = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.max = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.groupBox1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// buttonOk
        	// 
        	this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonOk.Location = new System.Drawing.Point(916, 418);
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
        	this.buttonCancel.Location = new System.Drawing.Point(1010, 418);
        	this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Size = new System.Drawing.Size(90, 29);
        	this.buttonCancel.TabIndex = 9;
        	this.buttonCancel.Text = "Cancel";
        	this.buttonCancel.UseVisualStyleBackColor = true;
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.dataGridView1);
        	this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
        	this.groupBox1.Location = new System.Drawing.Point(0, 0);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(1111, 413);
        	this.groupBox1.TabIndex = 11;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Inclusão de Tags em Lote";
        	// 
        	// dataGridView1
        	// 
        	this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.tgName,
        	        	        	this.TgDescricao,
        	        	        	this.TgDriver,
        	        	        	this.TgEndereco,
        	        	        	this.TgHistorico,
        	        	        	this.signalCondition,
        	        	        	this.min,
        	        	        	this.max});
        	this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dataGridView1.Location = new System.Drawing.Point(3, 16);
        	this.dataGridView1.Name = "dataGridView1";
        	this.dataGridView1.Size = new System.Drawing.Size(1105, 394);
        	this.dataGridView1.TabIndex = 0;
        	this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView1KeyDown);
        	// 
        	// tgName
        	// 
        	this.tgName.HeaderText = "Nome";
        	this.tgName.Name = "tgName";
        	this.tgName.Width = 200;
        	// 
        	// TgDescricao
        	// 
        	this.TgDescricao.HeaderText = "Descrição";
        	this.TgDescricao.Name = "TgDescricao";
        	this.TgDescricao.Width = 389;
        	// 
        	// TgDriver
        	// 
        	this.TgDriver.HeaderText = "Driver";
        	this.TgDriver.Name = "TgDriver";
        	this.TgDriver.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.TgDriver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        	this.TgDriver.Width = 200;
        	// 
        	// TgEndereco
        	// 
        	this.TgEndereco.HeaderText = "Endereço";
        	this.TgEndereco.Name = "TgEndereco";
        	this.TgEndereco.Width = 200;
        	// 
        	// TgHistorico
        	// 
        	this.TgHistorico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
        	this.TgHistorico.HeaderText = "Histórico";
        	this.TgHistorico.Name = "TgHistorico";
        	this.TgHistorico.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.TgHistorico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        	this.TgHistorico.Width = 73;
        	// 
        	// signalCondition
        	// 
        	this.signalCondition.HeaderText = "SignalCondition";
        	this.signalCondition.Name = "signalCondition";
        	this.signalCondition.Width = 200;
        	// 
        	// min
        	// 
        	this.min.HeaderText = "Min";
        	this.min.Name = "min";
        	// 
        	// max
        	// 
        	this.max.HeaderText = "Max";
        	this.max.Name = "max";
        	// 
        	// AnalogTagListConfigurator
        	// 
        	this.AcceptButton = this.buttonOk;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.ClientSize = new System.Drawing.Size(1111, 458);
        	this.Controls.Add(this.groupBox1);
        	this.Controls.Add(this.buttonCancel);
        	this.Controls.Add(this.buttonOk);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "AnalogTagListConfigurator";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Tag Configurator";
        	this.Load += new System.EventHandler(this.TagConfiguratorLoad);
        	this.groupBox1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.DataGridViewTextBoxColumn max;
        private System.Windows.Forms.DataGridViewTextBoxColumn min;
        private System.Windows.Forms.DataGridViewComboBoxColumn signalCondition;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TgHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn TgEndereco;
        private System.Windows.Forms.DataGridViewComboBoxColumn TgDriver;
        private System.Windows.Forms.DataGridViewTextBoxColumn TgDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}
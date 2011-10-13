namespace Aimirim.iView
{
    partial class DataSourceUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataSourceUserControl));
        	this.toolStrip = new System.Windows.Forms.ToolStrip();
        	this.tsbNew = new System.Windows.Forms.ToolStripButton();
        	this.tsbEdit = new System.Windows.Forms.ToolStripButton();
        	this.tsbDelete = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.dataGridViewTagGroup = new System.Windows.Forms.DataGridView();
        	this.ColumnAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.ColumnDsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.ColumnUid = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.ColumnPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.toolStrip.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridViewTagGroup)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// toolStrip
        	// 
        	this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.tsbNew,
        	        	        	this.tsbEdit,
        	        	        	this.tsbDelete,
        	        	        	this.toolStripSeparator1,
        	        	        	this.toolStripTextBox1,
        	        	        	this.toolStripSeparator2});
        	this.toolStrip.Location = new System.Drawing.Point(3, 3);
        	this.toolStrip.Name = "toolStrip";
        	this.toolStrip.Padding = new System.Windows.Forms.Padding(2);
        	this.toolStrip.Size = new System.Drawing.Size(878, 27);
        	this.toolStrip.TabIndex = 4;
        	this.toolStrip.Text = "toolStrip1";
        	// 
        	// tsbNew
        	// 
        	this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
        	this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbNew.Name = "tsbNew";
        	this.tsbNew.Size = new System.Drawing.Size(36, 20);
        	this.tsbNew.Text = "&Novo";
        	this.tsbNew.Click += new System.EventHandler(this.TsbNewClick);
        	// 
        	// tsbEdit
        	// 
        	this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
        	this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbEdit.Name = "tsbEdit";
        	this.tsbEdit.Size = new System.Drawing.Size(44, 20);
        	this.tsbEdit.Text = "&Alterar";
        	this.tsbEdit.Click += new System.EventHandler(this.TsbEditClick);
        	// 
        	// tsbDelete
        	// 
        	this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
        	this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbDelete.Name = "tsbDelete";
        	this.tsbDelete.Size = new System.Drawing.Size(46, 20);
        	this.tsbDelete.Text = "Apaga&r";
        	this.tsbDelete.Click += new System.EventHandler(this.TsbDeleteClick);
        	// 
        	// toolStripSeparator1
        	// 
        	this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        	this.toolStripSeparator1.Name = "toolStripSeparator1";
        	this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
        	// 
        	// toolStripTextBox1
        	// 
        	this.toolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        	this.toolStripTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.toolStripTextBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
        	this.toolStripTextBox1.Margin = new System.Windows.Forms.Padding(1, 0, 5, 0);
        	this.toolStripTextBox1.Name = "toolStripTextBox1";
        	this.toolStripTextBox1.Size = new System.Drawing.Size(250, 23);
        	this.toolStripTextBox1.Text = "Digite aqui o nome da tag que está procurando.";
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
        	// 
        	// dataGridViewTagGroup
        	// 
        	this.dataGridViewTagGroup.BackgroundColor = System.Drawing.Color.White;
        	this.dataGridViewTagGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.dataGridViewTagGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridViewTagGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.ColumnAlias,
        	        	        	this.ColumnDsn,
        	        	        	this.ColumnUid,
        	        	        	this.ColumnPwd});
        	this.dataGridViewTagGroup.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dataGridViewTagGroup.Location = new System.Drawing.Point(3, 30);
        	this.dataGridViewTagGroup.Margin = new System.Windows.Forms.Padding(2);
        	this.dataGridViewTagGroup.Name = "dataGridViewTagGroup";
        	this.dataGridViewTagGroup.RowTemplate.Height = 24;
        	this.dataGridViewTagGroup.Size = new System.Drawing.Size(878, 566);
        	this.dataGridViewTagGroup.TabIndex = 5;
        	// 
        	// ColumnAlias
        	// 
        	this.ColumnAlias.DataPropertyName = "Alias";
        	this.ColumnAlias.HeaderText = "Apelido";
        	this.ColumnAlias.Name = "ColumnAlias";
        	this.ColumnAlias.Width = 200;
        	// 
        	// ColumnDsn
        	// 
        	this.ColumnDsn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.ColumnDsn.DataPropertyName = "Dsn";
        	this.ColumnDsn.HeaderText = "Fonte de dados ODBC";
        	this.ColumnDsn.Name = "ColumnDsn";
        	// 
        	// ColumnUid
        	// 
        	this.ColumnUid.DataPropertyName = "Uid";
        	this.ColumnUid.HeaderText = "Usuário";
        	this.ColumnUid.Name = "ColumnUid";
        	this.ColumnUid.Width = 150;
        	// 
        	// ColumnPwd
        	// 
        	this.ColumnPwd.DataPropertyName = "Pwd";
        	this.ColumnPwd.HeaderText = "Senha";
        	this.ColumnPwd.Name = "ColumnPwd";
        	this.ColumnPwd.Visible = false;
        	this.ColumnPwd.Width = 150;
        	// 
        	// DataSourceUserControl
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.dataGridViewTagGroup);
        	this.Controls.Add(this.toolStrip);
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "DataSourceUserControl";
        	this.Padding = new System.Windows.Forms.Padding(3);
        	this.Size = new System.Drawing.Size(884, 599);
        	this.toolStrip.ResumeLayout(false);
        	this.toolStrip.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridViewTagGroup)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAlias;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStrip toolStrip;
        public System.Windows.Forms.DataGridView dataGridViewTagGroup;

        #endregion


    }
}

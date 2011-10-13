namespace Aimirim.iView
{
    partial class TagManagerUserControl
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagManagerUserControl));
        	this.toolStrip = new System.Windows.Forms.ToolStrip();
        	this.tsbNew = new System.Windows.Forms.ToolStripButton();
        	this.tsbNewLote = new System.Windows.Forms.ToolStripButton();
        	this.tsbEdit = new System.Windows.Forms.ToolStripButton();
        	this.tsbDelete = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.dataGridViewTags = new System.Windows.Forms.DataGridView();
        	this.dataGridViewTextBoxColumnItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.dataGridViewTextBoxColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.dataGridViewTextBoxColumnDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.dataGridViewTextBoxColumnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.dataGridViewTextBoxColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.toolStrip.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridViewTags)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// toolStrip
        	// 
        	this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.tsbNew,
        	        	        	this.tsbNewLote,
        	        	        	this.tsbEdit,
        	        	        	this.tsbDelete,
        	        	        	this.toolStripSeparator1,
        	        	        	this.toolStripTextBox1,
        	        	        	this.toolStripSeparator2});
        	this.toolStrip.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip.Name = "toolStrip";
        	this.toolStrip.Padding = new System.Windows.Forms.Padding(2);
        	this.toolStrip.Size = new System.Drawing.Size(593, 27);
        	this.toolStrip.TabIndex = 3;
        	this.toolStrip.Text = "toolStrip1";
        	// 
        	// tsbNew
        	// 
        	this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
        	this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbNew.Name = "tsbNew";
        	this.tsbNew.Size = new System.Drawing.Size(57, 20);
        	this.tsbNew.Text = "&Nova Tag";
        	this.tsbNew.Click += new System.EventHandler(this.TsbNewClick);
        	// 
        	// tsbNewLote
        	// 
        	this.tsbNewLote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbNewLote.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewLote.Image")));
        	this.tsbNewLote.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbNewLote.Name = "tsbNewLote";
        	this.tsbNewLote.Size = new System.Drawing.Size(60, 20);
        	this.tsbNewLote.Text = "&Novo Lote";
        	this.tsbNewLote.Click += new System.EventHandler(this.TsbNewLoteClick);
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
        	this.toolStripTextBox1.Enter += new System.EventHandler(this.ToolStripTextBox1Enter);
        	this.toolStripTextBox1.Leave += new System.EventHandler(this.ToolStripTextBox1Leave);
        	this.toolStripTextBox1.TextChanged += new System.EventHandler(this.ToolStripTextBox1TextChanged);
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
        	// 
        	// dataGridViewTags
        	// 
        	this.dataGridViewTags.AllowUserToAddRows = false;
        	this.dataGridViewTags.AllowUserToDeleteRows = false;
        	this.dataGridViewTags.BackgroundColor = System.Drawing.Color.White;
        	this.dataGridViewTags.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.dataGridViewTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridViewTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.dataGridViewTextBoxColumnItemID,
        	        	        	this.dataGridViewTextBoxColumnDescription,
        	        	        	this.dataGridViewTextBoxColumnDataType,
        	        	        	this.dataGridViewTextBoxColumnAddress,
        	        	        	this.dataGridViewTextBoxColumnValue});
        	this.dataGridViewTags.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dataGridViewTags.Location = new System.Drawing.Point(0, 27);
        	this.dataGridViewTags.Margin = new System.Windows.Forms.Padding(2);
        	this.dataGridViewTags.Name = "dataGridViewTags";
        	this.dataGridViewTags.RowTemplate.Height = 24;
        	this.dataGridViewTags.Size = new System.Drawing.Size(593, 572);
        	this.dataGridViewTags.TabIndex = 4;
        	// 
        	// dataGridViewTextBoxColumnItemID
        	// 
        	this.dataGridViewTextBoxColumnItemID.DataPropertyName = "Name";
        	this.dataGridViewTextBoxColumnItemID.HeaderText = "Nome";
        	this.dataGridViewTextBoxColumnItemID.Name = "dataGridViewTextBoxColumnItemID";
        	this.dataGridViewTextBoxColumnItemID.ReadOnly = true;
        	this.dataGridViewTextBoxColumnItemID.Width = 200;
        	// 
        	// dataGridViewTextBoxColumnDescription
        	// 
        	this.dataGridViewTextBoxColumnDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.dataGridViewTextBoxColumnDescription.DataPropertyName = "Description";
        	this.dataGridViewTextBoxColumnDescription.HeaderText = "Descrição";
        	this.dataGridViewTextBoxColumnDescription.MinimumWidth = 200;
        	this.dataGridViewTextBoxColumnDescription.Name = "dataGridViewTextBoxColumnDescription";
        	this.dataGridViewTextBoxColumnDescription.ReadOnly = true;
        	// 
        	// dataGridViewTextBoxColumnDataType
        	// 
        	this.dataGridViewTextBoxColumnDataType.DataPropertyName = "DataType";
        	this.dataGridViewTextBoxColumnDataType.HeaderText = "Tipo";
        	this.dataGridViewTextBoxColumnDataType.Name = "dataGridViewTextBoxColumnDataType";
        	this.dataGridViewTextBoxColumnDataType.ReadOnly = true;
        	// 
        	// dataGridViewTextBoxColumnAddress
        	// 
        	this.dataGridViewTextBoxColumnAddress.DataPropertyName = "Address";
        	this.dataGridViewTextBoxColumnAddress.HeaderText = "Endereço";
        	this.dataGridViewTextBoxColumnAddress.Name = "dataGridViewTextBoxColumnAddress";
        	this.dataGridViewTextBoxColumnAddress.ReadOnly = true;
        	this.dataGridViewTextBoxColumnAddress.Visible = false;
        	// 
        	// dataGridViewTextBoxColumnValue
        	// 
        	this.dataGridViewTextBoxColumnValue.DataPropertyName = "Value";
        	this.dataGridViewTextBoxColumnValue.HeaderText = "Valor";
        	this.dataGridViewTextBoxColumnValue.Name = "dataGridViewTextBoxColumnValue";
        	this.dataGridViewTextBoxColumnValue.Visible = false;
        	// 
        	// TagManagerUserControl
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.dataGridViewTags);
        	this.Controls.Add(this.toolStrip);
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "TagManagerUserControl";
        	this.Size = new System.Drawing.Size(593, 599);
        	this.toolStrip.ResumeLayout(false);
        	this.toolStrip.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridViewTags)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolStripButton tsbNewLote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStrip toolStrip;

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnValue;

    }
}

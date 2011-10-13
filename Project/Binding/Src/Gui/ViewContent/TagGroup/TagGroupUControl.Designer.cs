namespace Aimirim.iView
{
    partial class TagGroupUControl
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
        	this.dataGridViewTagGroup = new System.Windows.Forms.DataGridView();
        	this.dataGridViewTextBoxColumnItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.dataGridViewTextBoxColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.dataGridViewTextBoxColumnDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridViewTagGroup)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// dataGridViewTagGroup
        	// 
        	this.dataGridViewTagGroup.BackgroundColor = System.Drawing.Color.White;
        	this.dataGridViewTagGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.dataGridViewTagGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridViewTagGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.dataGridViewTextBoxColumnItemID,
        	        	        	this.dataGridViewTextBoxColumnDescription,
        	        	        	this.dataGridViewTextBoxColumnDataType});
        	this.dataGridViewTagGroup.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dataGridViewTagGroup.Location = new System.Drawing.Point(3, 3);
        	this.dataGridViewTagGroup.Margin = new System.Windows.Forms.Padding(2);
        	this.dataGridViewTagGroup.Name = "dataGridViewTagGroup";
        	this.dataGridViewTagGroup.RowTemplate.Height = 24;
        	this.dataGridViewTagGroup.Size = new System.Drawing.Size(878, 593);
        	this.dataGridViewTagGroup.TabIndex = 3;
        	this.dataGridViewTagGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridViewTagGroupKeyDown);
        	// 
        	// dataGridViewTextBoxColumnItemID
        	// 
        	this.dataGridViewTextBoxColumnItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.dataGridViewTextBoxColumnItemID.DataPropertyName = "Symbol";
        	this.dataGridViewTextBoxColumnItemID.HeaderText = "Symbol";
        	this.dataGridViewTextBoxColumnItemID.MinimumWidth = 200;
        	this.dataGridViewTextBoxColumnItemID.Name = "dataGridViewTextBoxColumnItemID";
        	// 
        	// dataGridViewTextBoxColumnDescription
        	// 
        	this.dataGridViewTextBoxColumnDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.dataGridViewTextBoxColumnDescription.DataPropertyName = "Substitution";
        	this.dataGridViewTextBoxColumnDescription.HeaderText = "Substitution";
        	this.dataGridViewTextBoxColumnDescription.MinimumWidth = 200;
        	this.dataGridViewTextBoxColumnDescription.Name = "dataGridViewTextBoxColumnDescription";
        	// 
        	// dataGridViewTextBoxColumnDataType
        	// 
        	this.dataGridViewTextBoxColumnDataType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.dataGridViewTextBoxColumnDataType.DataPropertyName = "Description";
        	this.dataGridViewTextBoxColumnDataType.HeaderText = "Description";
        	this.dataGridViewTextBoxColumnDataType.MinimumWidth = 200;
        	this.dataGridViewTextBoxColumnDataType.Name = "dataGridViewTextBoxColumnDataType";
        	// 
        	// TagGroupUControl
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.dataGridViewTagGroup);
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "TagGroupUControl";
        	this.Padding = new System.Windows.Forms.Padding(3);
        	this.Size = new System.Drawing.Size(884, 599);
        	((System.ComponentModel.ISupportInitialize)(this.dataGridViewTagGroup)).EndInit();
        	this.ResumeLayout(false);
        }
        public System.Windows.Forms.DataGridView dataGridViewTagGroup;

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnDataType;

    }
}

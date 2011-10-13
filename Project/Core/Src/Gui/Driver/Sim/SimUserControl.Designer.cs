namespace Aimirim.iView
{
    partial class SimUserControl
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
        	this.dataGridView = new System.Windows.Forms.DataGridView();
        	this.dataGridViewTextBoxColumnItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// dataGridView
        	// 
        	this.dataGridView.BackgroundColor = System.Drawing.Color.White;
        	this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.dataGridViewTextBoxColumnItemID});
        	this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dataGridView.Location = new System.Drawing.Point(3, 3);
        	this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
        	this.dataGridView.Name = "dataGridView";
        	this.dataGridView.RowTemplate.Height = 24;
        	this.dataGridView.Size = new System.Drawing.Size(817, 684);
        	this.dataGridView.TabIndex = 11;
        	// 
        	// dataGridViewTextBoxColumnItemID
        	// 
        	this.dataGridViewTextBoxColumnItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.dataGridViewTextBoxColumnItemID.DataPropertyName = "ItemName";
        	this.dataGridViewTextBoxColumnItemID.HeaderText = "Item Name";
        	this.dataGridViewTextBoxColumnItemID.MinimumWidth = 200;
        	this.dataGridViewTextBoxColumnItemID.Name = "dataGridViewTextBoxColumnItemID";
        	// 
        	// SimUserControl
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.dataGridView);
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "SimUserControl";
        	this.Padding = new System.Windows.Forms.Padding(3);
        	this.Size = new System.Drawing.Size(823, 690);
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
        	this.ResumeLayout(false);
        }
        public System.Windows.Forms.DataGridView dataGridView;

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnItemID;

    }
}

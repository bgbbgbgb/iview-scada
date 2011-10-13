namespace Aimirim.iView
{
    partial class OpcUserControl
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
        	this.txbOpcServerUrl = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.dataGridView = new System.Windows.Forms.DataGridView();
        	this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// txbOpcServerUrl
        	// 
        	this.txbOpcServerUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.txbOpcServerUrl.Location = new System.Drawing.Point(13, 26);
        	this.txbOpcServerUrl.Name = "txbOpcServerUrl";
        	this.txbOpcServerUrl.Size = new System.Drawing.Size(897, 20);
        	this.txbOpcServerUrl.TabIndex = 7;
        	this.txbOpcServerUrl.Text = "opcda://localhost/RSLinx OPC Server";
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(13, 10);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(88, 13);
        	this.label1.TabIndex = 8;
        	this.label1.Text = "OPC Server URL";
        	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// dataGridView
        	// 
        	this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.dataGridView.BackgroundColor = System.Drawing.Color.White;
        	this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.dataGridViewTextBoxColumn1,
        	        	        	this.ColumnValue});
        	this.dataGridView.Location = new System.Drawing.Point(13, 58);
        	this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
        	this.dataGridView.Name = "dataGridView";
        	this.dataGridView.RowTemplate.Height = 24;
        	this.dataGridView.Size = new System.Drawing.Size(897, 714);
        	this.dataGridView.TabIndex = 13;
        	// 
        	// dataGridViewTextBoxColumn1
        	// 
        	this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.dataGridViewTextBoxColumn1.DataPropertyName = "ItemName";
        	this.dataGridViewTextBoxColumn1.HeaderText = "Item Name";
        	this.dataGridViewTextBoxColumn1.MinimumWidth = 200;
        	this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        	// 
        	// ColumnValue
        	// 
        	this.ColumnValue.DataPropertyName = "Value";
        	this.ColumnValue.HeaderText = "Value";
        	this.ColumnValue.Name = "ColumnValue";
        	this.ColumnValue.Visible = false;
        	// 
        	// OpcUserControl
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.dataGridView);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.txbOpcServerUrl);
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "OpcUserControl";
        	this.Padding = new System.Windows.Forms.Padding(10);
        	this.Size = new System.Drawing.Size(923, 784);
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        public System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.TextBox txbOpcServerUrl;
        private System.Windows.Forms.Label label1;

        #endregion


    }
}

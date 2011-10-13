namespace Aimirim.iView
{
    partial class WcfUserControl
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
        	this.lblUrlServer = new System.Windows.Forms.Label();
        	this.txtBoxUrlServer = new System.Windows.Forms.TextBox();
        	this.SuspendLayout();
        	// 
        	// lblUrlServer
        	// 
        	this.lblUrlServer.AutoSize = true;
        	this.lblUrlServer.Location = new System.Drawing.Point(19, 26);
        	this.lblUrlServer.Name = "lblUrlServer";
        	this.lblUrlServer.Size = new System.Drawing.Size(84, 13);
        	this.lblUrlServer.TabIndex = 0;
        	this.lblUrlServer.Text = "URL do servidor";
        	// 
        	// txtBoxUrlServer
        	// 
        	this.txtBoxUrlServer.Location = new System.Drawing.Point(19, 42);
        	this.txtBoxUrlServer.Name = "txtBoxUrlServer";
        	this.txtBoxUrlServer.Size = new System.Drawing.Size(467, 20);
        	this.txtBoxUrlServer.TabIndex = 1;
        	this.txtBoxUrlServer.Text = "http://<server>/iViewScada";
        	// 
        	// WcfUserControl
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.txtBoxUrlServer);
        	this.Controls.Add(this.lblUrlServer);
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "WcfUserControl";
        	this.Padding = new System.Windows.Forms.Padding(3);
        	this.Size = new System.Drawing.Size(823, 690);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.TextBox txtBoxUrlServer;
        private System.Windows.Forms.Label lblUrlServer;

        #endregion


    }
}

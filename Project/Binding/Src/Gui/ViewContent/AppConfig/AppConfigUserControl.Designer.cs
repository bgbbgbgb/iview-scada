namespace Aimirim.iView
{
    partial class AppConfigUserControl
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
        	this.textBoxTagDatabase = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.textBoxDriverDatabase = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.textBoxSecurityDatabase = new System.Windows.Forms.TextBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.textBoxDataSourceCfg = new System.Windows.Forms.TextBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.chkBoxClient = new System.Windows.Forms.CheckBox();
        	this.SuspendLayout();
        	// 
        	// textBoxTagDatabase
        	// 
        	this.textBoxTagDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.textBoxTagDatabase.Location = new System.Drawing.Point(109, 41);
        	this.textBoxTagDatabase.Name = "textBoxTagDatabase";
        	this.textBoxTagDatabase.Size = new System.Drawing.Size(769, 20);
        	this.textBoxTagDatabase.TabIndex = 0;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(6, 44);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(75, 13);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "TagDatabase:";
        	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// textBoxDriverDatabase
        	// 
        	this.textBoxDriverDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.textBoxDriverDatabase.Location = new System.Drawing.Point(109, 67);
        	this.textBoxDriverDatabase.Name = "textBoxDriverDatabase";
        	this.textBoxDriverDatabase.Size = new System.Drawing.Size(769, 20);
        	this.textBoxDriverDatabase.TabIndex = 0;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(6, 70);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(84, 13);
        	this.label2.TabIndex = 1;
        	this.label2.Text = "DriverDatabase:";
        	this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// textBoxSecurityDatabase
        	// 
        	this.textBoxSecurityDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.textBoxSecurityDatabase.Location = new System.Drawing.Point(109, 93);
        	this.textBoxSecurityDatabase.Name = "textBoxSecurityDatabase";
        	this.textBoxSecurityDatabase.Size = new System.Drawing.Size(769, 20);
        	this.textBoxSecurityDatabase.TabIndex = 0;
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(6, 96);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(94, 13);
        	this.label3.TabIndex = 1;
        	this.label3.Text = "SecurityDatabase:";
        	this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// textBoxDataSourceCfg
        	// 
        	this.textBoxDataSourceCfg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.textBoxDataSourceCfg.Location = new System.Drawing.Point(109, 119);
        	this.textBoxDataSourceCfg.Name = "textBoxDataSourceCfg";
        	this.textBoxDataSourceCfg.Size = new System.Drawing.Size(769, 20);
        	this.textBoxDataSourceCfg.TabIndex = 0;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(6, 122);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(83, 13);
        	this.label4.TabIndex = 1;
        	this.label4.Text = "DataSourceCfg:";
        	this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// chkBoxClient
        	// 
        	this.chkBoxClient.AutoSize = true;
        	this.chkBoxClient.Location = new System.Drawing.Point(11, 164);
        	this.chkBoxClient.Name = "chkBoxClient";
        	this.chkBoxClient.Size = new System.Drawing.Size(58, 17);
        	this.chkBoxClient.TabIndex = 2;
        	this.chkBoxClient.Text = "Cliente";
        	this.chkBoxClient.UseVisualStyleBackColor = true;
        	// 
        	// AppConfigUserControl
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.chkBoxClient);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.textBoxDataSourceCfg);
        	this.Controls.Add(this.textBoxSecurityDatabase);
        	this.Controls.Add(this.textBoxDriverDatabase);
        	this.Controls.Add(this.textBoxTagDatabase);
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "AppConfigUserControl";
        	this.Padding = new System.Windows.Forms.Padding(3);
        	this.Size = new System.Drawing.Size(884, 599);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.CheckBox chkBoxClient;
        private System.Windows.Forms.TextBox textBoxDataSourceCfg;
        private System.Windows.Forms.TextBox textBoxSecurityDatabase;
        private System.Windows.Forms.TextBox textBoxDriverDatabase;
        private System.Windows.Forms.TextBox textBoxTagDatabase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

        #endregion


    }
}

namespace Aimirim.iView
{
    partial class RuleListForm
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
        	this.listBox1 = new System.Windows.Forms.ListBox();
        	this.SuspendLayout();
        	// 
        	// buttonOk
        	// 
        	this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonOk.Location = new System.Drawing.Point(10, 169);
        	this.buttonOk.Margin = new System.Windows.Forms.Padding(2);
        	this.buttonOk.Name = "buttonOk";
        	this.buttonOk.Size = new System.Drawing.Size(99, 29);
        	this.buttonOk.TabIndex = 6;
        	this.buttonOk.Text = "Ok";
        	this.buttonOk.UseVisualStyleBackColor = true;
        	// 
        	// buttonCancel
        	// 
        	this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.buttonCancel.Location = new System.Drawing.Point(113, 169);
        	this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Size = new System.Drawing.Size(99, 29);
        	this.buttonCancel.TabIndex = 7;
        	this.buttonCancel.Text = "Cancel";
        	this.buttonCancel.UseVisualStyleBackColor = true;
        	// 
        	// listBox1
        	// 
        	this.listBox1.FormattingEnabled = true;
        	this.listBox1.Location = new System.Drawing.Point(12, 13);
        	this.listBox1.Name = "listBox1";
        	this.listBox1.Size = new System.Drawing.Size(199, 147);
        	this.listBox1.TabIndex = 8;
        	// 
        	// RuleListForm
        	// 
        	this.AcceptButton = this.buttonOk;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.ClientSize = new System.Drawing.Size(223, 209);
        	this.Controls.Add(this.listBox1);
        	this.Controls.Add(this.buttonCancel);
        	this.Controls.Add(this.buttonOk);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "RuleListForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Security Rule List";
        	this.ResumeLayout(false);
        }
        public System.Windows.Forms.ListBox listBox1;

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}
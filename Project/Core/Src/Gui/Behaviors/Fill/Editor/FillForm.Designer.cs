namespace Aimirim.iView
{
    partial class FillForm
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
        	this.chkEnable = new System.Windows.Forms.CheckBox();
        	this.txExpression = new System.Windows.Forms.TextBox();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.btnOk = new System.Windows.Forms.Button();
        	this.btnCancel = new System.Windows.Forms.Button();
        	this.groupBox1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// chkEnable
        	// 
        	this.chkEnable.AutoSize = true;
        	this.chkEnable.Location = new System.Drawing.Point(16, 5);
        	this.chkEnable.Name = "chkEnable";
        	this.chkEnable.Size = new System.Drawing.Size(77, 21);
        	this.chkEnable.TabIndex = 0;
        	this.chkEnable.Text = "Habilita";
        	this.chkEnable.UseVisualStyleBackColor = true;
        	// 
        	// txExpression
        	// 
        	this.txExpression.Location = new System.Drawing.Point(22, 37);
        	this.txExpression.Name = "txExpression";
        	this.txExpression.Size = new System.Drawing.Size(327, 22);
        	this.txExpression.TabIndex = 1;
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.txExpression);
        	this.groupBox1.Location = new System.Drawing.Point(8, 8);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(377, 84);
        	this.groupBox1.TabIndex = 3;
        	this.groupBox1.TabStop = false;
        	// 
        	// btnOk
        	// 
        	this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
        	this.btnOk.Location = new System.Drawing.Point(229, 98);
        	this.btnOk.Name = "btnOk";
        	this.btnOk.Size = new System.Drawing.Size(75, 30);
        	this.btnOk.TabIndex = 4;
        	this.btnOk.Text = "Ok";
        	this.btnOk.UseVisualStyleBackColor = true;
        	this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
        	// 
        	// btnCancel
        	// 
        	this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        	this.btnCancel.Location = new System.Drawing.Point(310, 98);
        	this.btnCancel.Name = "btnCancel";
        	this.btnCancel.Size = new System.Drawing.Size(75, 30);
        	this.btnCancel.TabIndex = 4;
        	this.btnCancel.Text = "Cancel";
        	this.btnCancel.UseVisualStyleBackColor = true;
        	// 
        	// FillForm
        	// 
        	this.AcceptButton = this.btnOk;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.btnCancel;
        	this.ClientSize = new System.Drawing.Size(396, 133);
        	this.Controls.Add(this.btnCancel);
        	this.Controls.Add(this.btnOk);
        	this.Controls.Add(this.chkEnable);
        	this.Controls.Add(this.groupBox1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        	this.Name = "FillForm";
        	this.Padding = new System.Windows.Forms.Padding(5);
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Animação de preenchimento";
        	this.Load += new System.EventHandler(this.VisibilityFormLoad);
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txExpression;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.GroupBox groupBox1;

        #endregion


    }
}
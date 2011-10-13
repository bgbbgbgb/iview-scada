namespace Aimirim.iView
{
    partial class RuleForm
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
        	this.labelName = new System.Windows.Forms.Label();
        	this.tbName = new System.Windows.Forms.TextBox();
        	this.tbDescription = new System.Windows.Forms.TextBox();
        	this.labelDescription = new System.Windows.Forms.Label();
        	this.buttonOk = new System.Windows.Forms.Button();
        	this.buttonCancel = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// labelName
        	// 
        	this.labelName.AutoSize = true;
        	this.labelName.Location = new System.Drawing.Point(9, 12);
        	this.labelName.Name = "labelName";
        	this.labelName.Size = new System.Drawing.Size(45, 17);
        	this.labelName.TabIndex = 0;
        	this.labelName.Text = "Nome";
        	// 
        	// tbName
        	// 
        	this.tbName.Location = new System.Drawing.Point(12, 32);
        	this.tbName.Name = "tbName";
        	this.tbName.Size = new System.Drawing.Size(270, 22);
        	this.tbName.TabIndex = 1;
        	// 
        	// tbDescription
        	// 
        	this.tbDescription.Location = new System.Drawing.Point(12, 77);
        	this.tbDescription.Name = "tbDescription";
        	this.tbDescription.Size = new System.Drawing.Size(270, 22);
        	this.tbDescription.TabIndex = 3;
        	// 
        	// labelDescription
        	// 
        	this.labelDescription.AutoSize = true;
        	this.labelDescription.Location = new System.Drawing.Point(9, 57);
        	this.labelDescription.Name = "labelDescription";
        	this.labelDescription.Size = new System.Drawing.Size(71, 17);
        	this.labelDescription.TabIndex = 2;
        	this.labelDescription.Text = "Descrição";
        	// 
        	// buttonOk
        	// 
        	this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonOk.Location = new System.Drawing.Point(12, 122);
        	this.buttonOk.Name = "buttonOk";
        	this.buttonOk.Size = new System.Drawing.Size(132, 36);
        	this.buttonOk.TabIndex = 6;
        	this.buttonOk.Text = "Ok";
        	this.buttonOk.UseVisualStyleBackColor = true;
        	// 
        	// buttonCancel
        	// 
        	this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.buttonCancel.Location = new System.Drawing.Point(150, 122);
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Size = new System.Drawing.Size(132, 36);
        	this.buttonCancel.TabIndex = 7;
        	this.buttonCancel.Text = "Cancel";
        	this.buttonCancel.UseVisualStyleBackColor = true;
        	// 
        	// RuleForm
        	// 
        	this.AcceptButton = this.buttonOk;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.ClientSize = new System.Drawing.Size(297, 173);
        	this.Controls.Add(this.buttonCancel);
        	this.Controls.Add(this.buttonOk);
        	this.Controls.Add(this.tbDescription);
        	this.Controls.Add(this.labelDescription);
        	this.Controls.Add(this.tbName);
        	this.Controls.Add(this.labelName);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Name = "RuleForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Security Rule";
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        public System.Windows.Forms.TextBox tbDescription;
        public System.Windows.Forms.TextBox tbName;

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}
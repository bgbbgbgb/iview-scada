namespace Aimirim.iView
{
    partial class UserForm
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
        	this.tbPass = new System.Windows.Forms.TextBox();
        	this.labelDescription = new System.Windows.Forms.Label();
        	this.buttonOk = new System.Windows.Forms.Button();
        	this.buttonCancel = new System.Windows.Forms.Button();
        	this.label1 = new System.Windows.Forms.Label();
        	this.tbConfirmPass = new System.Windows.Forms.TextBox();
        	this.SuspendLayout();
        	// 
        	// labelName
        	// 
        	this.labelName.AutoSize = true;
        	this.labelName.Location = new System.Drawing.Point(9, 12);
        	this.labelName.Name = "labelName";
        	this.labelName.Size = new System.Drawing.Size(54, 17);
        	this.labelName.TabIndex = 0;
        	this.labelName.Text = "Usuáro";
        	// 
        	// tbName
        	// 
        	this.tbName.Location = new System.Drawing.Point(12, 32);
        	this.tbName.Name = "tbName";
        	this.tbName.Size = new System.Drawing.Size(270, 22);
        	this.tbName.TabIndex = 1;
        	// 
        	// tbPass
        	// 
        	this.tbPass.Location = new System.Drawing.Point(12, 77);
        	this.tbPass.Name = "tbPass";
        	this.tbPass.PasswordChar = '*';
        	this.tbPass.Size = new System.Drawing.Size(132, 22);
        	this.tbPass.TabIndex = 3;
        	// 
        	// labelDescription
        	// 
        	this.labelDescription.AutoSize = true;
        	this.labelDescription.Location = new System.Drawing.Point(9, 57);
        	this.labelDescription.Name = "labelDescription";
        	this.labelDescription.Size = new System.Drawing.Size(49, 17);
        	this.labelDescription.TabIndex = 2;
        	this.labelDescription.Text = "Senha";
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
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(147, 57);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(107, 17);
        	this.label1.TabIndex = 4;
        	this.label1.Text = "Confirma senha";
        	// 
        	// tbConfirmPass
        	// 
        	this.tbConfirmPass.Location = new System.Drawing.Point(150, 77);
        	this.tbConfirmPass.Name = "tbConfirmPass";
        	this.tbConfirmPass.PasswordChar = '*';
        	this.tbConfirmPass.Size = new System.Drawing.Size(132, 22);
        	this.tbConfirmPass.TabIndex = 5;
        	// 
        	// UserForm
        	// 
        	this.AcceptButton = this.buttonOk;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.ClientSize = new System.Drawing.Size(295, 182);
        	this.Controls.Add(this.buttonCancel);
        	this.Controls.Add(this.buttonOk);
        	this.Controls.Add(this.tbConfirmPass);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.tbPass);
        	this.Controls.Add(this.labelDescription);
        	this.Controls.Add(this.tbName);
        	this.Controls.Add(this.labelName);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Name = "UserForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Security User";
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        public System.Windows.Forms.TextBox tbName;
        public System.Windows.Forms.TextBox tbConfirmPass;
        public System.Windows.Forms.TextBox tbPass;

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
    }
}
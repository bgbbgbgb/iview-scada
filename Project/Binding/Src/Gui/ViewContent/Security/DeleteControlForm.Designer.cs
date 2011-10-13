namespace Aimirim.iView
{
    partial class DeleteControlForm
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
        	this.buttonOk = new System.Windows.Forms.Button();
        	this.buttonCancel = new System.Windows.Forms.Button();
        	this.checkBox1 = new System.Windows.Forms.CheckBox();
        	this.SuspendLayout();
        	// 
        	// labelName
        	// 
        	this.labelName.AutoSize = true;
        	this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.labelName.Location = new System.Drawing.Point(25, 27);
        	this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.labelName.Name = "labelName";
        	this.labelName.Size = new System.Drawing.Size(269, 20);
        	this.labelName.TabIndex = 0;
        	this.labelName.Text = "Deseja apagar o grupo selecionado?";
        	// 
        	// buttonOk
        	// 
        	this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonOk.Location = new System.Drawing.Point(145, 76);
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
        	this.buttonCancel.Location = new System.Drawing.Point(248, 76);
        	this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Size = new System.Drawing.Size(99, 29);
        	this.buttonCancel.TabIndex = 7;
        	this.buttonCancel.Text = "Cancel";
        	this.buttonCancel.UseVisualStyleBackColor = true;
        	// 
        	// checkBox1
        	// 
        	this.checkBox1.Location = new System.Drawing.Point(182, 110);
        	this.checkBox1.Name = "checkBox1";
        	this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        	this.checkBox1.Size = new System.Drawing.Size(164, 24);
        	this.checkBox1.TabIndex = 8;
        	this.checkBox1.Text = "Aplicar a todos os usuários";
        	this.checkBox1.UseVisualStyleBackColor = true;
        	// 
        	// DeleteControlForm
        	// 
        	this.AcceptButton = this.buttonOk;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.ClientSize = new System.Drawing.Size(355, 140);
        	this.Controls.Add(this.checkBox1);
        	this.Controls.Add(this.buttonCancel);
        	this.Controls.Add(this.buttonOk);
        	this.Controls.Add(this.labelName);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "DeleteControlForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Warning";
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        public System.Windows.Forms.CheckBox checkBox1;

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}
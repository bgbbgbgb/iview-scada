
namespace Aimirim.iView
{
    partial class TagFind
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
        	this.button1 = new System.Windows.Forms.Button();
        	this.button2 = new System.Windows.Forms.Button();
        	this.textBoxName = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.SuspendLayout();
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(8, 94);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(102, 34);
        	this.button1.TabIndex = 3;
        	this.button1.Text = "Ok";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// button2
        	// 
        	this.button2.Location = new System.Drawing.Point(123, 94);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(103, 34);
        	this.button2.TabIndex = 4;
        	this.button2.Text = "Cancel";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.button2_Click);
        	// 
        	// textBoxName
        	// 
        	this.textBoxName.Location = new System.Drawing.Point(15, 29);
        	this.textBoxName.Name = "textBoxName";
        	this.textBoxName.Size = new System.Drawing.Size(202, 22);
        	this.textBoxName.TabIndex = 1;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(12, 9);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(150, 17);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Informe o nome da tag";
        	// 
        	// panel1
        	// 
        	this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.panel1.Location = new System.Drawing.Point(8, 73);
        	this.panel1.Margin = new System.Windows.Forms.Padding(0);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(218, 4);
        	this.panel1.TabIndex = 2;
        	// 
        	// TagFind
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(236, 142);
        	this.Controls.Add(this.panel1);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.textBoxName);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.button1);
        	this.Name = "TagFind";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Pesquisa";
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox textBoxName;
    }
}
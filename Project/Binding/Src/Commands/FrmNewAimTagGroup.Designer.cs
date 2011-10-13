/*
 * Created by SharpDevelop.
 * User: Romis Fava
 * Date: 1/4/2011
 * Time: 21:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Aimirim.iView
{
	partial class FrmNewAimTagGroup
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbNewTagGroup = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbNewTagGroup
			// 
			this.tbNewTagGroup.Location = new System.Drawing.Point(12, 12);
			this.tbNewTagGroup.Name = "tbNewTagGroup";
			this.tbNewTagGroup.Size = new System.Drawing.Size(240, 20);
			this.tbNewTagGroup.TabIndex = 0;
			// 
			// btnOk
			// 
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOk.Location = new System.Drawing.Point(258, 12);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(63, 20);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// FrmNewAimTagGroup
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(329, 48);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.tbNewTagGroup);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FrmNewAimTagGroup";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Novo arquivo de tag group";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnOk;
		public System.Windows.Forms.TextBox tbNewTagGroup;
	}
}

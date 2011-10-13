
namespace Aimirim.iView
{
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Drawing;
	using System.Windows.Forms;
	using System.Xml;
	using System.Collections.Generic;
	using System.Drawing.Imaging;
	using System.Drawing.Design;

	[ToolboxItem(false)]
	[ToolboxBitmapAttribute(typeof(iGroupBox))]
	public class iGroupBox : GroupBox, ISupportInitialize
	{
		#region FIELDS
		private iGroupBoxAnimotion _animotion;

		private event EventHandler click;
		private event EventHandler doubleclick;
		#endregion

		#region PROPERTIES
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;		// Get the default values from the base class
				int style = cp.Style;					// Store the Style and ExStyle values
				int exStyle = cp.ExStyle;
				cp.Style = style;
				cp.ExStyle = exStyle;					// Store the results
				
				if (BackColor == Color.Transparent)
				{
					cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT

					SetStyle(ControlStyles.Opaque, true);
					SetStyle(ControlStyles.OptimizedDoubleBuffer , false);
					return cp;
				}
				else
				{
					SetStyle(ControlStyles.Opaque, false);
					SetStyle(ControlStyles.OptimizedDoubleBuffer , true);
					return base.CreateParams;
				}
			}
		}
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
				RecreateHandle();
			}
		}
		
		[CategoryAttribute("Behavior")]
		[DescriptionAttribute("iView SCADA properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public iGroupBoxAnimotion Animotion
		{
			get
			{
				if (_animotion == null)
				{
					_animotion = new iGroupBoxAnimotion();
				}
				return _animotion;
			}
			set
			{
				_animotion = value;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public iGroupBox()
		{
		}
		#endregion

		#region METHODS
		protected override void OnClick(EventArgs e)
		{
			if (this.click != null)
			{
				this.click(this, e);
			}
		}
		public new event EventHandler Click
		{
			add
			{
				click += value;
			}
			remove
			{
				click -= value;
			}
		}
		protected override void OnDoubleClick(EventArgs e)
		{
			if (this.doubleclick != null)
			{
				this.doubleclick(this,e);
			}
		}
		public new event EventHandler DoubleClick
		{
			add
			{
				doubleclick += value;
			}
			remove
			{
				doubleclick -= value;
			}
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			if ((click != null && click.GetInvocationList().Length > 0) || (doubleclick != null && doubleclick.GetInvocationList().Length > 0) )
			{
				this.Cursor = Cursors.Hand;
			}
			base.OnMouseEnter(e);
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			if (this.Cursor == Cursors.Hand)
			{
				this.Cursor = Cursors.Default;
			}
			base.OnMouseLeave(e);
		}
		
		
		public void BeginInit()
		{
		}
		public void EndInit()
		{
			if (!DesignMode)
			{
				Animotion.Attach(this);
			}
		}
		#endregion
	}
}


namespace Aimirim.iView
{
	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Drawing.Imaging;
	using System.Windows.Forms;
	using System.Collections.Generic;
	using System.Xml;

	[TypeConverter(typeof(BehaviorConverter))]
	public class TransparencyBehavior : AbstractBehavior
	{
		#region FIELDS
		private bool _enable = false;
		private Color _transparentColor;
		#endregion

		#region PROPERTIES
		public bool Enable
		{
			get
			{
				return _enable;
			}
			set
			{
				_enable = value;
				
				if (_parent != null)
				{
					_parent.Parent.Invalidate(_parent.Bounds, true);
				}
			}
		}

		public Color Color
		{
			get
			{
				return _transparentColor;
			}

			set
			{
				_transparentColor = value;
				
				if (_parent != null)
				{
					_parent.Parent.Invalidate(_parent.Bounds, true);
				}
			}
		}
		public override string ToString()
		{
			return "";
		}
		#endregion

		#region CONSTRUCTORS
		public TransparencyBehavior()
		{
		}
		#endregion

		#region METHODS
		public void Attach(Control parent)
		{
			_parent = parent;
			_parent.Paint += new PaintEventHandler(Paint);
			_parent.Disposed += delegate 
			{	
				foreach (ITag tag in _tagList)
				{
					tag.ValueChanged -= new EventHandler(tag_ValueChanged);
				}

				_parent.Paint -= new PaintEventHandler(Paint);
			};

			//Execute();
		}
		public override void Execute()
		{
			if (_parent != null)
			{
				//_parent.Parent.Invalidate(_parent.Bounds, true);
				_parent.Invalidate();
			}
		}
		private void Paint(object sender, PaintEventArgs e)
		{
			if (Enable)
			{
				if (_parent.BackgroundImage != null)
				{
					Bitmap bmp = new Bitmap(_parent.BackgroundImage);
					// Make the bottom left pixel the transparent color
					bmp.MakeTransparent(_transparentColor);
					e.Graphics.DrawImage(bmp, _parent.ClientRectangle);
				}
			}
		}
		#endregion
	}
}

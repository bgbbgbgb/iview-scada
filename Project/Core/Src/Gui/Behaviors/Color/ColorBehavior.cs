
namespace Aimirim.iView
{
	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Drawing.Imaging;
	using System.Windows.Forms;
	using System.Xml;
	using System.Collections.Generic;
	using System.Drawing.Drawing2D;

	[TypeConverter(typeof(BehaviorConverter))]
	public class ColorBehavior : AbstractBehavior
	{
		#region FIELDS
		private bool _enable = false;
		private Color _oldColor;
		private Color _transparentColor;
		private ColorTableCollection _colorTableCollection = new ColorTableCollection();
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
				
				if (_parent != null && _parent.Parent != null)
				{
					_parent.Parent.Invalidate(_parent.Bounds, true);
				}
			}
		}
		public Color OldColor
		{
			get
			{
				return _oldColor;
			}
			set
			{
				_oldColor = value;
			}
		}
		
		[DefaultValueAttribute(null)]
		public Color TransparentColor
		{
			get
			{
				return _transparentColor;
			}
			set
			{
				_transparentColor = value;
				
				if (_parent != null && _parent.Parent != null)
				{
					_parent.Parent.Invalidate(_parent.Bounds, true);
				}
			}
		}

		public override string ToString()
		{
			return "";
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[TypeConverter(typeof(ColorTableCollectionConverter))]
		[RefreshProperties(RefreshProperties.All)]
		public ColorTableCollection Table
		{
			get
			{
				return _colorTableCollection;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public ColorBehavior()
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

			Execute();
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
				ColorTable currCorTable = null;
				foreach (ColorTable colorTable in _colorTableCollection)
				{
					if (getResult(colorTable.Expression, _parent.FindForm() as IFrmTagGroup).ToString().Equals("True"))
					{
						currCorTable = colorTable;
						break;
					}
				}
				
				if (currCorTable != null)
				{
					ColorMap[] colorMap = new ColorMap[1];
					colorMap[0] = new ColorMap();
					colorMap[0].OldColor = _oldColor;
					colorMap[0].NewColor = currCorTable.NewColor;
					// Set the image attribute's color mappings
					ImageAttributes attr = new ImageAttributes();
					attr.SetRemapTable(colorMap);

					e.Graphics.InterpolationMode = InterpolationMode.Low;
					e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
					e.Graphics.CompositingMode = CompositingMode.SourceOver;
					e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

					if (_parent is iButton)
					{
						iButton ibtn = _parent as iButton;
						if (ibtn.Image != null)
						{
							e.Graphics.DrawImage(ibtn.Image, new Rectangle(3, 3, ibtn.ClientRectangle.Width, ibtn.ClientRectangle.Height), ibtn.ClientRectangle.X, ibtn.ClientRectangle.Y, ibtn.ClientRectangle.Width, ibtn.ClientRectangle.Height, GraphicsUnit.Pixel, attr);
						}
					}
					else
					{
						if (_parent.BackgroundImage != null)
						{
							if (TransparentColor != null && TransparentColor != Color.Empty)
							{
								Bitmap bmp = new Bitmap(_parent.BackgroundImage);
								// Make the bottom left pixel the transparent color
								bmp.MakeTransparent(TransparentColor);

								e.Graphics.DrawImage(bmp, _parent.ClientRectangle, 0, 0, _parent.BackgroundImage.Width, _parent.BackgroundImage.Height, GraphicsUnit.Pixel, attr);
							}
							else
							{
								Bitmap bmp = new Bitmap(_parent.BackgroundImage);
								e.Graphics.DrawImage(bmp, _parent.ClientRectangle, 0, 0, _parent.BackgroundImage.Width, _parent.BackgroundImage.Height, GraphicsUnit.Pixel, attr);
							}
						}
					}
				}
			}
		}
		#endregion
	}
}

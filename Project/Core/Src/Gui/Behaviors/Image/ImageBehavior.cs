
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
	public class ImageBehavior : AbstractBehavior
	{
		#region FIELDS
		private bool _enable = false;
		private Color _oldColor;
		private Color _transparentColor;
		private ImageTableCollection _imageTableCollection = new ImageTableCollection();
		private ColorTableCollection _colorTableCollection = new ColorTableCollection();
		private bool _needRefresh = false;
		//private Bitmap _originalImage = null;
		//private Bitmap _atualImage = null;
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
		public override string ToString()
		{
			return "";
		}

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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[TypeConverter(typeof(ImageTableCollectionConverter))]
		[RefreshProperties(RefreshProperties.All)]
		public ImageTableCollection List
		{
			get
			{
				return _imageTableCollection;
			}
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
		public ImageBehavior()
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
		}
		
		public override void Execute()
		{
			if (_parent != null)
			{
				//_parent.Parent.Invalidate(_parent.Bounds, true);
				_needRefresh = true;
				_parent.Invalidate();
			}
		}

		private void Paint(object sender, PaintEventArgs e)
		{
			if (Enable)
			{
				ImageTable currImageTable = null;
				foreach (ImageTable imageTable in _imageTableCollection)
				{
					if (getResult(imageTable.Expression, _parent.FindForm() as IFrmTagGroup).ToString().Equals("True"))
					{
						currImageTable = imageTable;
						break;
					}
				}

				ColorTable currCorTable = null;
				foreach (ColorTable colorTable in _colorTableCollection)
				{
					if (getResult(colorTable.Expression, _parent.FindForm() as IFrmTagGroup).ToString().Equals("True"))
					{
						currCorTable = colorTable;
						break;
					}
				}
				
				Bitmap image = null;
				if (currImageTable != null)
				{
					image = new Bitmap(currImageTable.Image);
				}
				else
				{
					if (_parent.BackgroundImage != null)
					{
						image = new Bitmap(_parent.BackgroundImage);
					}
				}
				
				if (TransparentColor != null && TransparentColor != Color.Empty && image != null)
				{
					image.MakeTransparent(TransparentColor);
				}
				
				ColorMap[] colorMap = null;
				ImageAttributes attr = null;
				if (currCorTable != null)
				{
					colorMap = new ColorMap[1];
					colorMap[0] = new ColorMap();
					colorMap[0].OldColor = _oldColor;
					colorMap[0].NewColor = currCorTable.NewColor;
					// Set the image attribute's color mappings
					attr = new ImageAttributes();
					attr.SetRemapTable(colorMap);
				}
				
				e.Graphics.InterpolationMode = InterpolationMode.Low;
				e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
				e.Graphics.CompositingMode = CompositingMode.SourceOver;
				e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

				if (image != null)
				{
					if (attr != null)
					{
						e.Graphics.DrawImage(image, _parent.ClientRectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attr);
					}
					else
					{
						e.Graphics.DrawImage(image, _parent.ClientRectangle);
					}
				}
			}
		}
		#endregion
	}
}

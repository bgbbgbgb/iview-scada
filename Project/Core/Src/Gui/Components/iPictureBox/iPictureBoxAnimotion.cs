namespace Aimirim.iView
{
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Drawing;
	using System.Windows.Forms;
	using System.Xml;
	using System.Drawing.Imaging;
	using System.Runtime.InteropServices;
	using System.Drawing.Drawing2D;
	using System.Drawing.Design;

	[TypeConverter(typeof(BehaviorConverter))]
	public  class iPictureBoxAnimotion : AbstractAnimotion
	{
		#region FIELDS
		private VisibilityBehavior _visibilityBehavior;
		private FillBehavior _fillBehavior;
		private ImageBehavior _imageBehavior;
		private AllowBehavior _allowBehavior;
		#endregion

		#region PROPERTIES
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public VisibilityBehavior Visibility
		{
			get
			{
				if (_visibilityBehavior == null)
				{
					_visibilityBehavior = new VisibilityBehavior();
				}
				return _visibilityBehavior;
			}
			set
			{
				_visibilityBehavior = value;
			}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public ImageBehavior Image
		{
			get
			{
				if (_imageBehavior == null)
				{
					_imageBehavior = new ImageBehavior();
				}
				return _imageBehavior;
			}
			set
			{
				_imageBehavior = value;
			}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public FillBehavior Fill
		{
			get
			{
				if (_fillBehavior == null)
				{
					_fillBehavior = new FillBehavior();
				}
				return _fillBehavior;
			}
			set
			{
				_fillBehavior = value;
			}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public AllowBehavior Allow
		{
			get
			{
				if (_allowBehavior == null)
				{
					_allowBehavior = new AllowBehavior();
				}
				return _allowBehavior;
			}
			set
			{
				_allowBehavior = value;
			}
		}
		#endregion
		
		#region CONSTRUCTORS
		public iPictureBoxAnimotion()
		{
		}
		#endregion

		#region METHODS
		public override string ToString()
		{
			return string.Empty;
		}
		
		/// <summary>
		/// Inicializa os mecanismos de animação. É executado
		/// quando a classe for atribuida a propriedade do componente
		/// </summary>
		public override void Attach(Control parent)
		{
			Visibility.Attach(parent);
			Fill.Attach(parent);
			Image.Attach(parent);
			Allow.Attach(parent);			
			
			Visibility.Execute();
			Fill.Execute();
			Image.Execute();
			Allow.Execute();
		}
		#endregion
		
		#region EVENTS
		#endregion

	}
}

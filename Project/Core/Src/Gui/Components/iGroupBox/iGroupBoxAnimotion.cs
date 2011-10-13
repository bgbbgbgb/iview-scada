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
	public  class iGroupBoxAnimotion : AbstractAnimotion
	{
		#region FIELDS
		private VisibilityBehavior _visibilityBehavior;
		private AllowBehavior _allowBehavior;
		private TextBehavior _textBehavior;
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
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public TextBehavior Text
		{
			get
			{
				if (_textBehavior == null)
				{
					_textBehavior = new TextBehavior();
				}
				return _textBehavior;
			}
			set
			{
				_textBehavior = value;
			}
		}
		#endregion
		
		#region CONSTRUCTORS
		public iGroupBoxAnimotion()
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
			Allow.Attach(parent);
			Text.Attach(parent);
			
			Visibility.Execute();
			Allow.Execute();
			Text.Execute();
		}
		#endregion
	}
}

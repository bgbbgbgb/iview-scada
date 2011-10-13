
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

	//[DesignTimeVisible(false)]
	//[ToolboxItem(false)]
	//[ToolboxBitmapAttribute(typeof(Button))]
	//[ToolboxBitmap(@"D:\Empresa\Projetos\01. AIMIRIM\01. iView\Solution\Project\Core\icon10.bmp")]
	[ToolboxBitmap(typeof(Button))]
	[DesignTimeVisible(false)]
	[ToolboxItem(false)]
	public partial class iButton : Button, ISupportInitialize
	{
		#region FIELDS
		private iButtonAnimotion _animotion;
		#endregion

		#region PROPERTIES
		[CategoryAttribute("Behavior")]
		[DescriptionAttribute("iView SCADA properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public iButtonAnimotion Animotion
		{
			get
			{
				if (_animotion == null)
				{
					_animotion = new iButtonAnimotion();
				}
				return _animotion;
			}
			set
			{
				_animotion = value;
			}
		}

		public new string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				if (DesignMode || !Animotion.Text.Enable)
				{
					base.Text = value;
				}
			}
		}
		#endregion

		#region CONSTRUCTORS
		public iButton()
		{
			// Inicializa os componentes do form designer
			InitializeComponent();
		}
		#endregion

		#region METHODS
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

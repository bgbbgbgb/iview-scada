
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
	[ToolboxBitmapAttribute(typeof(iComboBox))]
	public partial class iComboBox : ComboBox, ISupportInitialize
	{
		#region FIELDS
		private iComboBoxAnimotion _animotion;
		#endregion

		#region PROPERTIES
		[CategoryAttribute("Behavior")]
		[DescriptionAttribute("iView SCADA properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public iComboBoxAnimotion Animotion
		{
			get
			{
				if (_animotion == null)
				{
					_animotion = new iComboBoxAnimotion();
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
		public iComboBox()
		{
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

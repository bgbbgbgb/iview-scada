
namespace Aimirim.iView
{
	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Collections;

	[TypeConverter(typeof(ImageTableConverter))]
	public class ImageTable
	{
		#region FIELDS
		private string _name;
		private string _expression;
		private Image _image;
		#endregion

		#region PROPERTIES
		public override string ToString()
		{
			return "";
		}
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}
		public string Expression
		{
			get
			{
				return _expression;
			}
			set
			{
				_expression = value;
			}
		}
		public Image Image
		{
			get
			{
				return _image;
			}
			set
			{
				_image = value;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public ImageTable()
		{
		}
		#endregion

		#region METHODS
		#endregion
	}
}

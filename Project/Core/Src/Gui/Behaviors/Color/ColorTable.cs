
namespace Aimirim.iView
{
	using System;
	using System.ComponentModel;
	using System.Drawing;

	[TypeConverter(typeof(ColorTableConverter))]
	public class ColorTable
	{
		#region FIELDS
		private string _expression;
		private Color _newColor;
		#endregion

		#region PROPERTIES
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
		public Color NewColor
		{
			get
			{
				return _newColor;
			}
			set
			{
				_newColor = value;
			}
		}
		
		public override string ToString()
		{
			return string.Empty;
		}
		#endregion

		#region CONSTRUCTORS
		public ColorTable()
		{
		}
		#endregion

		#region METHODS
		#endregion
	}
}

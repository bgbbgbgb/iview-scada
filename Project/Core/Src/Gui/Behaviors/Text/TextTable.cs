
namespace Aimirim.iView
{
	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Collections;
	using System.Windows.Forms;

	[TypeConverter(typeof(TextTableConverter))]
	public class TextTable
	{
		#region FIELDS
		private string _expression;
		private string _text;
		private string _mask = "{0}";
		#endregion

		#region PROPERTIES
		public override string ToString()
		{
			return "";
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
		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				_text = value;
			}
		}
		public string Mask
		{
			get
			{
				return _mask;
			}
			set
			{
				_mask = value;
			}
		}
		
		
		#endregion

		#region CONSTRUCTORS
		public TextTable()
		{
		}
		#endregion
		
		#region METHODS
		#endregion
	}
}

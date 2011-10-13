
namespace Aimirim.iView
{
	using System;
	using System.ComponentModel;
	using System.Windows.Forms;
	using System.Xml;
	using System.Collections.Generic;

	public class DataChangedEventArgs: EventArgs
	{
		#region FIELDS
		private string _itemName;
		private object _value;
		#endregion
		
		#region PROPERTIES
		public string ItemName
		{
			get
			{
				return _itemName;
			}
		}
		public object Value
		{
			get
			{
				return _value;
			}
		}
		#endregion
		
		#region CONSTRUCTORS
		public DataChangedEventArgs(string itemName, object value)
		{
			_itemName = itemName;
			_value = value;
		}
		#endregion
	}
}

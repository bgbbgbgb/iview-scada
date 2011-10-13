
namespace Aimirim.iView
{
	using System;
	using System.ComponentModel;
	using System.Windows.Forms;
	using System.Xml;
	using System.Collections.Generic;

	public class SimAddress
	{
		#region FIELDS
		private string _itemName;
		#endregion

		#region PROPERTIES
		public string ItemName
		{
			get
			{
				return _itemName;
			}
			set
			{
				_itemName = value;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public SimAddress()
		{
		}
		#endregion
		
		#region METHODS
		#endregion
	}
}

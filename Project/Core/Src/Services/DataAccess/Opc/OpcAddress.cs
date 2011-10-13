using System.Threading;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Generic;

namespace Aimirim.iView
{

	public class OpcAddress
	{
		#region FIELDS
		//
		private object _thisLock = new object();
		
		private Opc.Da.Item _opcItem;
		private Opc.Da.Subscription _subscription;
		private string _value;
		private string _itemName = string.Empty;
		#endregion

		#region PROPERTIES
		public string ItemName
		{
			get
			{
				if (!ServiceManager.DesignMode)
				{
					return _opcItem.ItemName;
				}
				else
				{
					return _itemName;
				}
			}
			set
			{
				if (!ServiceManager.DesignMode)
				{
					// do nothing
				}
				else
				{
					_itemName = value;
				}
			}
		}
		public string Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (value != _value)
				{
					Opc.Da.ItemValue iv = new Opc.Da.ItemValue(_opcItem.ItemName);
					iv.Value = value;
					_subscription.Server.Write(new Opc.Da.ItemValue[] {iv});
				}
			}
		}
		#endregion

		#region CONSTRUCTORS
		public OpcAddress() : this (null, null)
		{
			
		}
		public OpcAddress(Opc.Da.Item opcItem, Opc.Da.Subscription subscription)
		{
			_opcItem = opcItem;
			_subscription = subscription;
		}
		#endregion
		
		#region METHODS
		public void SetValue(string value)
		{
			_value = value;
		}
		public string GetValue()
		{
			try
			{
				Opc.Da.ItemValueResult[] results = _subscription.Server.Read(new Opc.Da.Item[] { _opcItem });
				return results[0].Value.ToString();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return string.Empty;
			}
		}
		#endregion
	}
}

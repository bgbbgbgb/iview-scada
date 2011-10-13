
namespace Aimirim.iView
{
	using System;
	using System.ComponentModel;
	using System.Windows.Forms;
	using System.Xml;
	using System.Collections.Generic;

	public abstract class AbstractDriver: IDriver, IDisposable
	{
		#region FIELDS
		protected string _id;
		protected bool _autoCreateAddr;
		#endregion

		#region PROPERTIES
		public string Id
		{
			get
			{
				return _id;
			}
		}
		public abstract string Name {get;}
		public abstract string Description {get;}
		public abstract UserControl Control {get;}
		
		public bool AutoCreateAddr
		{
			get
			{
				return _autoCreateAddr;
			}
			set
			{
				_autoCreateAddr = value;
			}
		}
		#endregion

		#region CONSTRUCTORS
		#endregion

		#region METHODS
		protected void OnDataChanged(DataChangedEventArgs e)
		{
			if (_dataChanged != null)
			{
				_dataChanged(this, e);
			}
		}

		public abstract string GetValue(string itemName);
		public abstract void SetValue(string itemName, string value);
		
		public abstract void Add(string itemName);
		public abstract void Remove(string itemName);
		
		public abstract void ReadXml();
		public abstract void WriteXml();

		public abstract void Dispose();
		public abstract void Refresh();
		#endregion

		#region EVENTS
		protected event DataChangedEventHandler _dataChanged;
		public event DataChangedEventHandler DataChanged
		{
			add
			{
				_dataChanged += value;
			}
			remove
			{
				_dataChanged -= value;
			}
		}
		#endregion
	}
}

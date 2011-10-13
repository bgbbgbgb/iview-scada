
namespace Aimirim.iView
{
	using System;
	using System.Windows.Forms;
	using System.IO;
	using System.ComponentModel;
	using System.Xml;
	using System.Collections.Generic;

	public interface IDriver
	{
		#region PROPERTIES
		string Id { get; }
		string Name { get; }
		string Description { get;}
		UserControl Control {get;}
		
		bool AutoCreateAddr { get; set; }
		
		//List<ISignalCondition> SignalConditionCollection { get; }
		#endregion
		
		#region METHODS
		//void WriteXml(ref XmlElement parent);
		string GetValue(string itemName);
		void SetValue(string itemName, string value);
		
		void Add(string itemName);
		void Remove(string itemName);
		
		void ReadXml();
		void WriteXml();
		void Refresh();
		#endregion
		
		#region EVENTS
		event DataChangedEventHandler DataChanged;
		#endregion
	}
}

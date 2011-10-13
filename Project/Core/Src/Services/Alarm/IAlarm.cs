using System;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Xml;

namespace Aimirim.iView
{
	public interface IAlarm
	{
		#region PROPERTIES
		string Name { get; set; }
		string Description { get; set; }
		string TimeStamp { get; set; }
		string TimeStampAck {get; set;}
		TagType DataType { get; }
		#endregion
		
		#region METHODS
		void ReadXml(XmlNode alarm);
		void WriteXml(ref XmlElement parent);
		#endregion
		
		#region EVENTS
		#endregion
	}
}

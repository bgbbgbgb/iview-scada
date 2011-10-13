
namespace Aimirim.iView
{
	using System;
	using System.Windows.Forms;
	using System.IO;
	using System.ComponentModel;
	using System.Xml;

	public interface ITag
	{
		#region PROPERTIES
		string Name { get; set; }
		string Description { get; set; }
		string Value { get; set; }
		string Address { get; set; }
		TagType DataType { get; }
		
		[Browsable(false)]
		IDriver Driver { get; set; }
		#endregion
		
		#region METHODS
		DialogResult ShowConfigurator();
		
		void ReadXml(XmlNode tag);
		void WriteXml(ref XmlElement parent);
		#endregion
		
		#region EVENTS
		event EventHandler ValueChanged;
		#endregion
	}
}

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace Aimirim.iView
{
	public abstract class AbstractAlarm: IAlarm
	{
		#region FIELDS
		protected string _name;
		protected string _description;
		protected string _timeStamp;
		protected string _timeStampAck;
		#endregion

		#region PROPERTIES
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
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}
		public string TimeStamp
		{
			get
			{
				return _timeStamp;
			}
			set
			{
				_timeStamp = value;
			}
		}
		public string TimeStampAck
		{
			get
			{
				return _timeStampAck;
			}
			set
			{
				_timeStampAck = value;
			}
		}
		public abstract TagType DataType { get; }
		#endregion

		#region CONSTRUCTORS
		#endregion

		#region METHODS
		public virtual void ReadXml(XmlNode alarm)
		{
			Name = alarm.Attributes["Name"].Value;
			Description = alarm.Attributes["Description"].Value;
			TimeStamp = alarm.Attributes["TimeStamp"].Value;
			TimeStampAck = alarm.Attributes["TimeStampAck"].Value;
		}
		public virtual void WriteXml(ref XmlElement parent)
		{
			XmlElement alarmElement = parent.OwnerDocument.CreateElement("Alarm");
			alarmElement.SetAttribute("Name", Name);
			alarmElement.SetAttribute("Description", Description);
			alarmElement.SetAttribute("TimeStamp", TimeStamp);
			alarmElement.SetAttribute("TimeStampAck", TimeStampAck);
			alarmElement.SetAttribute("DataType", DataType.ToString());
			
			parent.AppendChild(alarmElement);
		}
		#endregion

		#region EVENTS
		#endregion
	}
}

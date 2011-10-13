using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Text;

namespace Aimirim.iView
{
	public class AlarmAnalog: AbstractAlarm
	{
		#region FIELDS
		#endregion

		#region PROPERTIES
		public override TagType DataType
		{
			get
			{
				return TagType.Analog;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public AlarmAnalog()
		{
		}
		#endregion
		
		#region METHODS
		#endregion
	}
}
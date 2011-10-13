using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Text;

namespace Aimirim.iView
{
	public class AlarmDigital: AbstractAlarm
	{
		#region FIELDS
		#endregion

		#region PROPERTIES
		public override TagType DataType
		{
			get
			{
				return TagType.Digital;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public AlarmDigital()
		{
		}
		#endregion
		
		#region METHODS
		#endregion
	}
}
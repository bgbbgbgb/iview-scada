using System.Data;
using System;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Xml;

namespace Aimirim.iView
{
	public enum TypeDirection
	{
		ToDataSource,
		FromDataSource
	}
	public interface ISignalCondition
	{
		#region PROPERTIES
		String Id {get;}
		#endregion
		
		#region METHODS
		String Convert(String value, String min, String max, TypeDirection direction);
		#endregion
		
		#region EVENTS
		#endregion
	}
}

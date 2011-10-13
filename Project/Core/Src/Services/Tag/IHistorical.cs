using System.Data;

namespace Aimirim.iView
{
	using System;
	using System.Windows.Forms;
	using System.IO;
	using System.ComponentModel;
	using System.Xml;

	public interface IHistorical
	{
		#region PROPERTIES
		bool Historical { get; set; }
		#endregion
		
		#region METHODS
		DataTable ToDataTable();
		#endregion
		
		#region EVENTS
		#endregion
	}
}

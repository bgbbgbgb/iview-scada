
namespace Aimirim.iView
{
	using System;
	using System.Windows.Forms;
	using System.IO;
	using System.ComponentModel;
	using System.Xml;
	using System.Collections.Generic;

	public interface IDriverControl
	{
		#region PROPERTIES		#endregion
		
		#region METHODS
		void Load(XmlDocument xmlDocument);
		void Save(XmlDocument xmlDocument);
		#endregion
		
		#region EVENTS
		event EventHandler DataChanged;
		#endregion
	}
}

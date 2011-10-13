using System.ServiceModel;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aimirim.iView
{
	
	public class WcfHost
	{
		#region FIELDS
		ServiceHost myService;
		#endregion

		#region PROPERTIES
		#endregion

		#region CONSTRUCTORS
		//
		// Instanciada no método TagManager.Initialize().
		//
		public WcfHost()
		{
			myService = new ServiceHost(typeof(MessageService));
			myService.Open();
		}
		~WcfHost()
		{
			myService.Close();
		}
		#endregion
		
		#region METHODS
		#endregion
	}
}

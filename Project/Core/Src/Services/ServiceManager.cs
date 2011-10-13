using System.IO;
using System;

namespace Aimirim.iView
{
	public static class ServiceManager
	{
		#region FIELDS
		private static string _outputAssemblyFullPath = @".\";
		private static bool _designMode = false;
		#endregion

		#region PROPERTIES
		public static string OutputAssemblyFullPath
		{
			get
			{
				return _outputAssemblyFullPath;
			}
		}
		public static bool DesignMode
		{
			get
			{
				return _designMode;
			}
		}
		public static bool IsClient
		{
			get
			{
				return bool.Parse(System.Configuration.ConfigurationSettings.AppSettings["Client"]);
			}
		}
		#endregion

		#region CONSTRUCTORS
		#endregion

		#region METHODS
		public static void Load(string outputAssemblyFullPath)
		{
			_designMode = true;
			_outputAssemblyFullPath = outputAssemblyFullPath;
		}
		//
		// Descarrega os serviços principais
		// A princípio é executado pelo Desposed()
		// da classe AimProject
		public static void Unload()
		{
			TagManager.Unload();
			SecurityManager.Unload();
			DriverManager.Unload();
		}
		#endregion
	}
}

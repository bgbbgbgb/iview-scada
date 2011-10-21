using System.Drawing.Design;
using System.Windows.Forms;
using System;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Reflection;
using System.Xml;
using ICSharpCode.SharpDevelop.Internal.Templates;
using ICSharpCode.SharpDevelop.Project;
using ICSharpCode.SharpDevelop.Dom;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aimirim.iView
{
	//
	// Esta é a primeira classe que será instanciada no sistema
	// É a conexão do plugin com o SharpDevelop.
	// 
	public class AimProjectBinding : IProjectBinding
	{
		#region FIELDS
		public const string LanguageName = "iView";
		#endregion

		#region PROPERTIES
		public string Language
		{
			get
			{
				return LanguageName;
			}
		}
		public bool HandlingMissingProject
		{
			get
			{
				return false;
			}
		}
		#endregion
		
		#region CONSTRUCTORS
		public AimProjectBinding()
		{
			string addInRootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string response;
			var exist = AssemblyExist("Aimirim.iView", out response);
			if (exist){
				GacApi.RemoveAssemblyFromCache("Aimirim.iView");
			}
			GacApi.AddAssemblyToCache(Path.Combine(addInRootPath, "Aimirim.iView.dll"));
		}
		#endregion

		#region METHODS
		public IProject LoadProject(ProjectLoadInformation loadInformation)
		{
			return new AimProject(loadInformation);
		}
		public IProject CreateProject(ProjectCreateInformation info)
		{
			
			return new AimProject(info);
		}

		public static bool AssemblyExist(string assemblyname, out string response)
		{
			try
			{
				response = QueryAssemblyInfo(assemblyname);
				return true;
			}
			catch (System.IO.FileNotFoundException e)
			{
				response = e.Message;
				return false;
			}
		}


		// If assemblyName is not fully qualified, a random matching may be
		public static String QueryAssemblyInfo(string assemblyName)
		{
			var assembyInfo = new AssemblyInfo {cchBuf = 512};
			assembyInfo.currentAssemblyPath = new String('\0', assembyInfo.cchBuf);

			IAssemblyCache assemblyCache;

			// Get IAssemblyCache pointer
			var hr = GacApi.CreateAssemblyCache(out assemblyCache, 0);
			if (hr == IntPtr.Zero)
			{
				hr = assemblyCache.QueryAssemblyInfo(1, assemblyName, ref assembyInfo);
				if (hr != IntPtr.Zero)
				{
					Marshal.ThrowExceptionForHR(hr.ToInt32());
				}
			}
			else
			{
				Marshal.ThrowExceptionForHR(hr.ToInt32());
			}
			return assembyInfo.currentAssemblyPath;
		}
		
		#endregion
	}

	internal class GacApi
	{
		static internal int AddAssemblyToCache(string assembly)
		{
			IAssemblyCache ac = null;

			var hr = CreateAssemblyCache(out ac, 0);

			if (hr != IntPtr.Zero)
				return (int)hr;
			else
				return ac.InstallAssembly(0, assembly, (IntPtr)0);
		}

		static internal int RemoveAssemblyFromCache(string assembly)
		{
			IAssemblyCache ac = null;

			uint n;
			var hr = CreateAssemblyCache(out ac, 0);

			if (hr != IntPtr.Zero)
				return (int)hr;
			else
				return ac.UninstallAssembly(0, assembly, (IntPtr)0, out n);
		}

		
		[DllImport("fusion.dll")]
		internal static extern IntPtr CreateAssemblyCache(out IAssemblyCache ppAsmCache, int reserved);
	}

	// GAC Interfaces - IAssemblyCache. As a sample, non used vtable entries
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown),Guid("e707dcde-d1cd-11d2-bab9-00c04f8eceae")]
	internal interface IAssemblyCache
	{
		[PreserveSig()]
		int UninstallAssembly(uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pszAssemblyName, IntPtr pvReserved, out uint pulDisposition);
		
		[PreserveSig()]
		IntPtr QueryAssemblyInfo(int flags,[MarshalAs(UnmanagedType.LPWStr)]String assemblyName,ref AssemblyInfo assemblyInfo);

		[PreserveSig()]
		int CreateAssemblyCacheItem(uint dwFlags, IntPtr pvReserved, out /*IAssemblyCacheItem*/IntPtr ppAsmItem, [MarshalAs(UnmanagedType.LPWStr)] String pszAssemblyName);

		[PreserveSig()]
		int CreateAssemblyScavenger(out object ppAsmScavenger);
		
		[PreserveSig()]
		int InstallAssembly(uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pszManifestFilePath, IntPtr pvReserved);
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct AssemblyInfo
	{
		public int cbAssemblyInfo;
		public int assemblyFlags;
		public long assemblySizeInKB;

		[MarshalAs(UnmanagedType.LPWStr)]
		public String currentAssemblyPath;

		public int cchBuf;
	}
}

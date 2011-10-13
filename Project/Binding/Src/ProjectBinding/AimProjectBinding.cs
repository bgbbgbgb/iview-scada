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

		#region METHODS
		public IProject LoadProject(ProjectLoadInformation loadInformation)
		{
			return new AimProject(loadInformation);
		}
		public IProject CreateProject(ProjectCreateInformation info)
		{
			return new AimProject(info);
		}
		#endregion
	}
}

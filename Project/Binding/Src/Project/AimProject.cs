using System.Collections.Generic;
using System.Reflection;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Project.Converter;
using System;
using System.IO;
using System.Linq;
using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.SharpDevelop.Dom.CSharp;
using ICSharpCode.SharpDevelop.Internal.Templates;
using ICSharpCode.SharpDevelop.Project;

namespace Aimirim.iView
{
	public class AimProject : CompilableProject
	{
		#region FIELDS
		private static readonly CompilerVersion msbuild20 = new CompilerVersion(new Version(2, 0), "C# 2.0");
		private static readonly CompilerVersion msbuild35 = new CompilerVersion(new Version(3, 5), "C# 3.0");
		private static readonly CompilerVersion msbuild40 = new CompilerVersion(new Version(4, 0), "C# 4.0");
		#endregion

		#region PROPERTIES
		public override CompilerVersion CurrentCompilerVersion {
			get {
				switch (MinimumSolutionVersion) {
					case Solution.SolutionVersionVS2005:
						return msbuild20;
					case Solution.SolutionVersionVS2008:
						return msbuild35;
					case Solution.SolutionVersionVS2010:
						return msbuild40;
					default:
						throw new NotSupportedException();
				}
			}
		}
		public override string Language
		{
			get
			{
				return AimProjectBinding.LanguageName;
			}
		}
		public override LanguageProperties LanguageProperties
		{
			get
			{
				return LanguageProperties.CSharp;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public AimProject(ProjectLoadInformation info) : base(info)
		{
			// Inicializa a classe
			Init();
		}
		public AimProject(ProjectCreateInformation info) : base(info)
		{
			// Inicializa a classe
			Init();
			// Adiciona os TargetsFile
			AddImport(@"$(MSBuildBinPath)\Microsoft.CSharp.Targets", null);
			// Inclui a referência ao iView durante a criação de um novo projeto
//			Assembly aimAssembly = Assembly.GetAssembly(typeof(AimProject));
//			string aimAssemblyPath = Path.GetDirectoryName(aimAssembly.Location);
//			string aimAssemblyFullName = Path.Combine(aimAssemblyPath, "Aimirim.iView.dll");
//			ReferenceProjectItem rpi = new ReferenceProjectItem(this, "Aimirim.iView");
//			rpi.HintPath = aimAssemblyFullName;
//			ProjectService.AddProjectItem(this, rpi);
		}
		#endregion

		#region METHODS
		//
		// Este método contém instruções comuns
		// ao construtores desta classe
		//
		private void Init()
		{
			reparseReferencesSensitiveProperties.Add("TargetFrameworkVersion");
			reparseCodeSensitiveProperties.Add("DefineConstants");

			// Inicializa os serviços do iView
			ServiceManager.Load(OutputAssemblyFullPath);
		}

		public override IAmbience GetAmbience()
		{
			return new CSharpAmbience();
		}
		public override ItemType GetDefaultItemType(string fileName)
		{
			if (string.Equals(Path.GetExtension(fileName), ".cs", StringComparison.OrdinalIgnoreCase))
				return ItemType.Compile;
			else
				return base.GetDefaultItemType(fileName);
		}
		public override void StartBuild(ProjectBuildOptions options, IBuildFeedbackSink feedbackSink)
		{
			if (this.MinimumSolutionVersion == Solution.SolutionVersionVS2005) {
				MSBuildEngine.StartBuild(this,
				                         options,
				                         feedbackSink,
				                         MSBuildEngine.AdditionalTargetFiles.Concat(
				                         	new [] { Path.Combine(MSBuildEngine.SharpDevelopBinPath, "SharpDevelop.CheckMSBuild35Features.targets") }));
			} else {
				base.StartBuild(options, feedbackSink);
			}
		}
		public override IEnumerable<CompilerVersion> GetAvailableCompilerVersions()
		{
			return new[] { msbuild20, msbuild35, msbuild40 };
		}
		public override void Dispose()
		{
			base.Dispose();
			ServiceManager.Unload();
		}

		public void AddAimTagGroups(string[] fileNames)
		{
			foreach (string fileName in fileNames)
			{
				AddAimTagGroup(fileName);
			}
		}
		public void AddAimTagGroup(string fileName)
		{
			String appDir = Path.GetDirectoryName(ServiceManager.OutputAssemblyFullPath);
			String tagGroupDir = Path.Combine(appDir, "TagGroup");
			String fileDir = Path.GetDirectoryName(fileName);
			if (!fileDir.Equals(tagGroupDir))
			{
				String fileDest = Path.Combine(tagGroupDir, Path.GetFileName(fileName));
				File.Copy(fileName, fileDest);
				
//				AimTagGroupProjectItem projectItem = new AimTagGroupProjectItem(this);
//				projectItem.FileName = fileDest;
//				ProjectService.AddProjectItem(this, projectItem);
			}
			else
			{
//				AimTagGroupProjectItem projectItem = new AimTagGroupProjectItem(this);
//				projectItem.FileName = fileName;
//				ProjectService.AddProjectItem(this, projectItem);
			}
		}
		#endregion
	}
}

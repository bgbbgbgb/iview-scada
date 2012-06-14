using System;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Gui;

namespace Aimirim.iView
{
	/// <summary>
	/// Description of PreviewDisplayBinding.
	/// </summary>
	public class SecurityDisplayBinding : IDisplayBinding
	{
		#region FIELDS
		#endregion

		#region PROPERTIES
		#endregion

		#region METHODS
		public bool CanCreateContentForFile(string fileName)
		{
			return true;
		}
		
		public IViewContent CreateContentForFile(OpenedFile file)
		{
			return new SecurityViewContent(file);
		}
		#endregion
		
		public bool IsPreferredBindingForFile(string fileName)
		{
			return true;
		}
		
		public double AutoDetectFileContent(string fileName, System.IO.Stream fileContent, string detectedMimeType)
		{
			throw new NotImplementedException();
		}
	}
}

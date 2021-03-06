﻿using System.Windows.Forms;
using System;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Reflection;
using System.Xml;
using ICSharpCode.SharpDevelop.Internal.Templates;
using ICSharpCode.SharpDevelop.Project;
using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Gui;
using System.Collections.Generic;

namespace Aimirim.iView
{

	public class TagGroupDisplayBinding : IDisplayBinding
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
			return new TagGroupViewContent(file);
		}
		#endregion
		
		public bool IsPreferredBindingForFile(string fileName)
		{
			return true;
		}
		
		public double AutoDetectFileContent(string fileName, Stream fileContent, string detectedMimeType)
		{
			throw new NotImplementedException();
		}
	}
}

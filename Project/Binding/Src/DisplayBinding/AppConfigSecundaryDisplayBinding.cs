using System.Windows.Forms;
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

	public class AppConfigSecundaryDisplayBinding : ISecondaryDisplayBinding
	{
		#region FIELDS
		#endregion

		#region PROPERTIES
		public bool ReattachWhenParserServiceIsReady
		{
			get
			{
				return false;
			}
		}
		#endregion

		#region METHODS
		public bool CanAttachTo(IViewContent content)
		{
			return true;
		}

		public IViewContent[] CreateSecondaryViewContent(IViewContent viewContent)
		{
			return new IViewContent[] { new AppConfigSecundaryViewContent(viewContent) };
		}
		#endregion


	}
}

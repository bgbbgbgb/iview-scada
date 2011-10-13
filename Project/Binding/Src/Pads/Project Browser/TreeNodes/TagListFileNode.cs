using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using ICSharpCode.Core;
using ICSharpCode.Core.WinForms;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Project;
using ICSharpCode.SharpDevelop.Gui;

namespace Aimirim.iView
{
	public class TagListFileNode : FileNode
	{
	    #region FIELDS
	    #endregion //fields

	    #region CONSTRUCTORS
	    public TagListFileNode(String fileName, FileNodeStatus fileNodeStatus) : base(fileName, fileNodeStatus)
	    {
			sortOrder = 0;
            SetIcon("ProjectBrowser.ReferenceFolder.Closed");
            Text = "Tag Database";
			ContextmenuAddinTreePath = "";
	    }
	    #endregion //constructors

	    #region METHODS
	    #endregion //methods
	}
}

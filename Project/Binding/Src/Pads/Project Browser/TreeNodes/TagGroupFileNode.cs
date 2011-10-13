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
	public class TagGroupFileNode : FileNode
	{
	    #region FIELDS
	    #endregion //fields

	    #region CONSTRUCTORS
	    public TagGroupFileNode(String fileName, FileNodeStatus fileNodeStatus) : base(fileName, fileNodeStatus)
	    {
            SetIcon("Icons.16x16.Library");
			ContextmenuAddinTreePath = "/SharpDevelop/Pads/ProjectBrowser/ContextMenu/TagGroupFileNode";
	    }
	    #endregion //constructors

	    #region METHODS
	    #endregion //methods
	}
}

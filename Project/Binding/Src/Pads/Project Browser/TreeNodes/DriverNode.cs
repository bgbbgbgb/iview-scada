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
	public class DriverNode : FileNode
	{
	    #region FIELDS
	    IDriver _driver;
	    #endregion //fields

	    #region CONSTRUCTORS
	    public DriverNode(IDriver driver): base (driver.FileName, FileNodeStatus.InProject)
	    {
	    	_driver = driver;
            Text = _driver.Name;
            SetIcon("Icons.16x16.Library");
	    }
	    #endregion //constructors

	    #region METHODS
	    #endregion //methods
	}
}

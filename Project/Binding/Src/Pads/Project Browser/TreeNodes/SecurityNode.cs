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
	public class SecurityNode : CustomNode, IViewNode
	{
	    #region FIELDS
	    private SecurityViewContent _securityViewContent;
	    #endregion //fields

	    #region CONSTRUCTORS
	    public SecurityNode(IProject project)
	    {
            sortOrder = 3;
            SetIcon("Icons.16x16.Library");
            Text = "Security";
	    }
	    #endregion //constructors

	    #region METHODS
	    public void ShowView()
	    {
            if (_securityViewContent == null)
            {
                //_securityViewContent = new SecurityViewContent();
                WorkbenchSingleton.Workbench.ShowView(_securityViewContent);
            }
            else
            {
                try
                {
                    _securityViewContent.WorkbenchWindow.SelectWindow();
                }
                catch (Exception)
                {
                    WorkbenchSingleton.Workbench.ShowView(_securityViewContent);
                }
            }
	    }
	    #endregion //methods
	}
}

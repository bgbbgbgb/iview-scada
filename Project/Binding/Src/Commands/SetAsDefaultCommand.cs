using System;
using System.Drawing;
using System.Windows.Forms;

using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Project;

namespace Aimirim.iView
{
	public class SetAsDefaultCommand : AbstractMenuCommand
	{
		public override void Run()
		{
			AbstractProjectBrowserTreeNode node = ProjectBrowserPad.Instance.SelectedNode;
			System.Configuration.ConfigurationSettings.AppSettings["TagDatabase"] = ((FileNode)node).FullPath;
			//node.NodeFont = new Font(node.TreeView.Font, FontStyle.Bold);
		}
	}
}

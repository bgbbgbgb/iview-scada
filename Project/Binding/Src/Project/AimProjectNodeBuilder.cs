
namespace Aimirim.iView
{
	using System;
	using System.IO;
	using System.Windows.Forms;
	using ICSharpCode.SharpDevelop.Project;
	using ICSharpCode.SharpDevelop.Gui;
	
	public class AimProjectNodeBuilder : IProjectNodeBuilder
	{
		#region CONSTRUCTORS
		public AimProjectNodeBuilder()
		{
		}
		#endregion

		#region METHODS
		public bool CanBuildProjectTree(IProject project)
		{
			return project is AimProject;
		}
		public TreeNode AddProjectNode(TreeNode motherNode, IProject project)
		{			
			ProjectNode projectNode = new ProjectNode(project);
			projectNode.AddTo(motherNode);

			ReferenceFolder referenceFolderNode = new ReferenceFolder(project);
			referenceFolderNode.AddTo(projectNode);

			//TagManagerNode tagManagerNode = new TagManagerNode(project);
			//tagManagerNode.AddTo(projectNode);
//			
//			TagListFileNode tagListFileNode = new TagListFileNode(TagManager.FullFileName, FileNodeStatus.InProject);
//			tagListFileNode.AddTo(projectNode);
				
//			TagGroupNode tagGroupNode = new TagGroupNode(project);
//			tagGroupNode.AddTo(projectNode);

//			AimTagGroupFolderNode aimTagGroupFolderNode = new AimTagGroupFolderNode(project);
//			aimTagGroupFolderNode.AddTo(projectNode);
//
//			SecurityNode securityNode = new SecurityNode(project);
//			securityNode.AddTo(projectNode);

			//DriverFolderNode driverFolderNode = new DriverFolderNode(project);
			//driverFolderNode.AddTo(projectNode);

			motherNode.TreeView.MouseDoubleClick += new MouseEventHandler(TreeView_MouseDoubleClick);

			return projectNode;
		}
		private void TreeView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ExtTreeView etv = sender as ExtTreeView;
			IViewNode ivn = etv.SelectedNode as IViewNode;
			if (ivn != null)
			{
				ivn.ShowView();
			}
		}
		#endregion
	}
}

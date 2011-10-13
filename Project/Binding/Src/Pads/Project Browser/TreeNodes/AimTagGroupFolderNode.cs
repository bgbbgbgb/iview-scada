// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision: 3292 $</version>
// </file>

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using ICSharpCode.Core;
using ICSharpCode.Core.WinForms;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Project;

namespace Aimirim.iView
{
	public class AimTagGroupFolderNode : CustomFolderNode
	{
		#region FIELDS
		IProject _project;
		#endregion // fields
		
		#region PROPERTIES
		#endregion // properties
		
		#region CONSTRUCTORS
		public AimTagGroupFolderNode(IProject project)
		{
			_project = project;
			Text = "Tag Group";
			OpenedImage = "ProjectBrowser.ReferenceFolder.Open";
			ClosedImage = "ProjectBrowser.ReferenceFolder.Closed";
			ContextmenuAddinTreePath = "/SharpDevelop/Pads/ProjectBrowser/ContextMenu/AimTagGroupFolderNode";
		}
		#endregion // constructors
		
		#region METHODS
		
		public override void Refresh()
		{
			AddLibraryNodes();
			base.Refresh();
		}
		
		protected override void Initialize()
		{
			AddLibraryNodes();
			base.Initialize();
		}
		
		private void AddLibraryNodes()
		{
			Nodes.Clear();

			String appDir = Path.GetDirectoryName(ServiceManager.OutputAssemblyFullPath);
			String tagGroupDir = Path.Combine(appDir, "TagGroup");
			
			if (!Directory.Exists(tagGroupDir))
			{
				Directory.CreateDirectory(tagGroupDir);
			}
			
			String[] tagGroupFiles = Directory.GetFiles(tagGroupDir);
			foreach (String item in tagGroupFiles)
			{
				TagGroupFileNode node = new TagGroupFileNode(item, FileNodeStatus.InProject);
				node.AddTo(this);
			}
			
			
//			foreach (ProjectItem item in _project.Items)
//			{
//				if (item.ItemType == AimItemType.TagGroup)
//				{
//					TagGroupFileNode node = new TagGroupFileNode(item.FileName, FileNodeStatus.InProject);
//					node.AddTo(this);
//				}
//			}
		}
		#endregion // methods
	}
}

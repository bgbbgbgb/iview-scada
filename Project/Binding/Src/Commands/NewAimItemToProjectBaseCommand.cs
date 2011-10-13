// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Windows.Forms;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.SharpDevelop.Project;
using System.IO;

namespace Aimirim.iView
{
	/// <summary>
	/// Base class for the AddWixLibraryToProject and 
	/// AddWixExtensionToProject commands.
	/// </summary>
	public abstract class NewAimItemToProjectBaseCommand : AbstractMenuCommand
	{				
		/// <summary>
		/// Gets the folder tree node type to find from the
		/// project node.</summary>
		public abstract Type FileNodeType { get; }
		
		public override void Run()
		{
			// Get FolderNode.
			AimTagGroupFolderNode fileNode = GetFileNode(FileNodeType);
			if (fileNode == null) 
			{
				return;
			}
			
			using(FrmNewAimTagGroup frm = new FrmNewAimTagGroup())
			{
				if (frm.ShowDialog(WorkbenchSingleton.MainWin32Window) == DialogResult.OK)
				{
					String applicationPath = Path.GetDirectoryName(ServiceManager.OutputAssemblyFullPath);
					String tagGroupDirectory = Path.Combine(applicationPath, "TagGroup");
					if (!Directory.Exists(tagGroupDirectory))
					{
						Directory.CreateDirectory(tagGroupDirectory);
					}
					    
					String fileName = Path.Combine(tagGroupDirectory, frm.tbNewTagGroup.Text + ".tgg");
					if (!File.Exists(fileName))
					{
						// Append new text to an existing file
			            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true))
			            {			            	
			                file.WriteLine("<?xml version='1.0' standalone='yes'?>");
			                file.WriteLine("<DocumentElement>");
			                file.WriteLine("</DocumentElement>");
			            }  
					}
					
					// Add files to project.
					AimProject project = ((AimProject)fileNode.Project);
					AddFiles(project, new String[] {fileName});
//					project.Save();
				}
			}
			
			// Refresh project browser.
			fileNode.Refresh();
			fileNode.Expanding();
			fileNode.Expand();
		}

		/// <summary>
		/// Method used to add the files selected by the user to the project.
		/// </summary>
		protected abstract void AddFiles(AimProject project, string[] fileNames);		

		static AimTagGroupFolderNode GetFileNode(Type fileNodeType)
		{
			ProjectNode projectNode = ProjectBrowserPad.Instance.CurrentProject;
			if (projectNode != null) 
			{
				return GetFileNodeFromProjectNode(projectNode, fileNodeType);
			}
			return null;
		}
		
		static AimTagGroupFolderNode GetFileNodeFromProjectNode(ProjectNode projectNode, Type fileNodeType)
		{
			foreach (TreeNode node in projectNode.Nodes) 
			{
				
				AimTagGroupFolderNode fileNode = node as AimTagGroupFolderNode;
				if (fileNode != null && node.GetType() == fileNodeType) 
				{
					return fileNode;
				}
			}
			return null;
		}
	}
}

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
	public class AimProjectNode : DirectoryNode
	{
	    #region FIELDS
		IProject project;
		bool isStartupProject;
		#endregion // fields
		
		#region PROPERTIES
		public override bool Visible {
			get {
				return true;
			}
		}
		public override IProject Project {
			get {
				return project;
			}
		}
		public override string RelativePath {
			get {
				return "";
			}
		}
		public override string Directory {
			get {
				return project.Directory;
			}
			set {
				throw new System.NotSupportedException();
			}
		}
		#endregion // properties
		
		#region CONSTRUCTORS
		public AimProjectNode(IProject project)
		{
			sortOrder = 1;
			
			this.ContextmenuAddinTreePath = "/SharpDevelop/Pads/ProjectBrowser/ContextMenu/ProjectNode";
			this.project = project;
			
			Text = project.Name;
			if (project.ReadOnly) {
				Text += StringParser.Parse(" (${res:Global.ReadOnly})");
			}
			
			autoClearNodes = false;
			
			if (project is MissingProject) {
				OpenedImage = ClosedImage = "ProjectBrowser.MissingProject";
				this.ContextmenuAddinTreePath = "/SharpDevelop/Pads/ProjectBrowser/ContextMenu/MissingProjectNode";
			} else if (project is UnknownProject) {
				OpenedImage = ClosedImage = "ProjectBrowser.ProjectWarning";
				this.ContextmenuAddinTreePath = "/SharpDevelop/Pads/ProjectBrowser/ContextMenu/UnknownProjectNode";
			} else {
				OpenedImage = ClosedImage = IconService.GetImageForProjectType(project.Language);
			}
			Tag = project;
			
			if (project.ParentSolution != null) {
				project.ParentSolution.Preferences.StartupProjectChanged += OnStartupProjectChanged;
				OnStartupProjectChanged(null, null);
			}
		}
		#endregion // constructors
		
		#region METHODS
		public override void Dispose()
		{
			base.Dispose();
			if (project.ParentSolution != null) {
				project.ParentSolution.Preferences.StartupProjectChanged -= OnStartupProjectChanged;
			}
		}
		private void OnStartupProjectChanged(object sender, EventArgs e)
		{
			bool newIsStartupProject = (this.project == project.ParentSolution.Preferences.StartupProject);
			if (newIsStartupProject != isStartupProject) {
				isStartupProject = newIsStartupProject;
				drawDefault = !isStartupProject;
				if (this.TreeView != null) {
					this.TreeView.Invalidate(this.Bounds);
				}
			}
		}
		protected override int MeasureItemWidth(DrawTreeNodeEventArgs e)
		{
			if (isStartupProject) {
				return MeasureTextWidth(e.Graphics, this.Text, BoldDefaultFont);
			} else {
				return base.MeasureItemWidth(e);
			}
		}
		protected override void DrawForeground(DrawTreeNodeEventArgs e)
		{
			if (isStartupProject) {
				DrawText(e, this.Text, SystemBrushes.WindowText, BoldDefaultFont);
			}
		}
		public override void ActivateItem()
		{
			if (project is MSBuildFileProject) {
				FileService.OpenFile(project.FileName);
			}
		}
		public override void ShowProperties()
		{
			ICSharpCode.SharpDevelop.Project.Commands.ViewProjectOptions.ShowProjectOptions(project);
		}
		#endregion // methods
		
		#region Drag & Drop
		public override DataObject DragDropDataObject {
			get {
				return new DataObject(this);
			}
		}
		#endregion
		
		#region Cut & Paste
		public override bool EnableDelete {
			get {
				return true;
			}
		}
		public override void Delete()
		{
			ProjectService.RemoveSolutionFolder(Project.IdGuid);
			ProjectService.SaveSolution();
		}
		public override bool EnableCopy {
			get {
				return false;
			}
		}
		public override void Copy()
		{
			throw new System.NotSupportedException();
		}
		public override bool EnableCut {
			get {
				if (IsEditing) {
					return false;
				}
				return true;
			}
		}
		public override void Cut()
		{
			DoPerformCut = true;
			ClipboardWrapper.SetDataObject(new DataObject(typeof(ISolutionFolder).ToString(), project.IdGuid));
		}
		// Paste is inherited from DirectoryNode.
		#endregion
		
		public override void AfterLabelEdit(string newName)
		{
			RenameProject(project, newName);
			Text = project.Name;
		}
		public static void RenameProject(IProject project, string newName)
		{
			if (project.Name == newName)
				return;
			if (!FileService.CheckFileName(newName))
				return;
			// multiple projects with the same name shouldn't be a problem
//			foreach (IProject p in ProjectService.OpenSolution.Projects) {
//				if (string.Equals(p.Name, newName, StringComparison.OrdinalIgnoreCase)) {
//					MessageService.ShowMessage("There is already a project with this name.");
//					return;
//				}
//			}
			string newFileName = Path.Combine(project.Directory, newName + Path.GetExtension(project.FileName));
			
			if (!FileService.RenameFile(project.FileName, newFileName, false)) {
				return;
			}
			if (project.AssemblyName == project.Name)
				project.AssemblyName = newName;
			if (File.Exists(project.FileName + ".user"))
				FileService.RenameFile(project.FileName + ".user", newFileName + ".user", false);
			foreach (IProject p in ProjectService.OpenSolution.Projects) 
			{
				foreach (ProjectItem item in p.Items) 
				{
					if (item.ItemType == ItemType.ProjectReference) 
					{
						ProjectReferenceProjectItem refItem = (ProjectReferenceProjectItem)item;
						if (refItem.ReferencedProject == project) 
						{
							refItem.ProjectName = newName;
							refItem.Include = FileUtility.GetRelativePath(p.Directory, newFileName);
						}
					}
				}
			}
			project.FileName = newFileName;
			project.Name = newName;
			ProjectService.SaveSolution();
		}
		public override object AcceptVisitor(ProjectBrowserTreeNodeVisitor visitor, object data)
		{
			return visitor.Visit(this, data);
		}
		public virtual void AddNewItemsToProject()
		{
			new ICSharpCode.SharpDevelop.Project.Commands.AddNewItemsToProject().Run();
			return;
		}
	}
}

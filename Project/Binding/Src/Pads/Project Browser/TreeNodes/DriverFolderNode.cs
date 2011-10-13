using System;

namespace Aimirim.iView
{
	using System.Windows.Forms;
	using ICSharpCode.Core;
	using ICSharpCode.Core.WinForms;
	using ICSharpCode.SharpDevelop;
	using ICSharpCode.SharpDevelop.Project;
	using ICSharpCode.SharpDevelop.Gui;

	public class DriverFolderNode : CustomFolderNode
	{
		#region FIELDS
		#endregion

		#region CONSTRUCTORS
		public DriverFolderNode(IProject project)
		{
			Text = "Drivers";
			OpenedImage = "ProjectBrowser.ReferenceFolder.Open";
			ClosedImage = "ProjectBrowser.ReferenceFolder.Closed";
		}
		#endregion
		
		#region METHODS
		public override void Refresh()
		{
			AddNodes();
			base.Refresh();
		}
		protected override void Initialize()
		{
			AddNodes();
			base.Initialize();
		}
		private void AddNodes()
		{
			Nodes.Clear();

			foreach (IDriver driver in DriverManager.Instance.Drivers)
			{
				DriverNode node = new DriverNode(driver);
				node.AddTo(this);
			}			
		}
		#endregion
	}
}

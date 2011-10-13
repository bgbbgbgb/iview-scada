using System;
using ICSharpCode.FormsDesigner;
using ICSharpCode.SharpDevelop.Gui;

namespace Aimirim.iView
{
	public class AimDialogDesigner: FormsDesignerViewContent
	{
		public AimDialogDesigner(IViewContent primaryViewContent, IDesignerLoaderProvider loaderProvider, IDesignerGenerator generator) : base (primaryViewContent, loaderProvider, generator)
		{
		}

		static SharpDevelopSideBar setupDialogControlsToolBox;
		
		public static SharpDevelopSideBar SetupDialogControlsToolBox {
			get {
				WorkbenchSingleton.AssertMainThread();
				if (setupDialogControlsToolBox == null) {
					setupDialogControlsToolBox = new SharpDevelopSideBar();
//					setupDialogControlsToolBox.Tabs.Add(SetupDialogControlsSideTab.CreateSideTab());
//					setupDialogControlsToolBox.ActiveTab = setupDialogControlsToolBox.Tabs[0];
				}
				return setupDialogControlsToolBox;
			}
		}
		
		
		public override object ToolsContent {
			get { return SetupDialogControlsToolBox; }
		}
	}
}

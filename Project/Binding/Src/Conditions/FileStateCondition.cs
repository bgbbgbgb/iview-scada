using System;
using System.Drawing;
using System.Windows.Forms;

using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Project;

namespace Aimirim.iView
{
	public class FileStateCondition : IConditionEvaluator
	{
		public bool IsValid(object caller, Condition condition)
		{
			FileNode node = ProjectBrowserPad.Instance.SelectedNode as FileNode;
			if (node != null)
			{
				if (System.IO.Path.GetExtension(node.FileName).Contains(".tdb"))
				{
					return true;
				}
			}
			return false;
		}
	}
}

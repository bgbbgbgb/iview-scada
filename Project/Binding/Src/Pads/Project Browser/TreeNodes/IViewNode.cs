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
	public interface IViewNode
	{
        void ShowView();
	}
}

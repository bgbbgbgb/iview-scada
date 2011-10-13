// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Windows.Forms;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.SharpDevelop.Project;

namespace Aimirim.iView
{
	public class NewAimTagGroupToProject : NewAimItemToProjectBaseCommand
	{		
		public override Type FileNodeType
		{
			get 
			{
				return typeof(AimTagGroupFolderNode); 
			}
		}
		
		protected override void AddFiles(AimProject project, string[] fileNames)
		{
			project.AddAimTagGroups(fileNames);
		}		
	}
}

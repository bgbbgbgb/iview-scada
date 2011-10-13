// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using ICSharpCode.SharpDevelop.Project;

namespace Aimirim.iView
{
	public class AimTagGroupProjectItem : ProjectItem
	{
		public AimTagGroupProjectItem(IProject project)
			: base(project, AimItemType.TagGroup)
		{
		}
		
		public AimTagGroupProjectItem(IProject project, IProjectItemBackendStore item)
			: base(project, item)
		{
		}
	}
}

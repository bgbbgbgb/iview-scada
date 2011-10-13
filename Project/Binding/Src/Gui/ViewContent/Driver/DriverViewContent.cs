using System;
using System.IO;
using System.Windows.Forms;

using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Gui;

namespace Aimirim.iView
{
	public class DriverViewContent : AbstractViewContent
	{
		#region FIELDS
		private DriverUserControl _control;
		#endregion
		
		#region PROPERTIES
		public override object Control 
		{
			get 
			{
				return _control;
			}
		}
		#endregion
		
		#region CONTRUCTORS
		public DriverViewContent(OpenedFile file)
		{			
			_control = new DriverUserControl(this);
			
			Files.Add(file);
			OnFileNameChanged(file);
			file.ForceInitializeView(this);
			
			TabPageText = "Design";
		}
		#endregion
		
		#region METHODS
		public override void Save(OpenedFile file, Stream stream)
		{
			_control.Save(stream);
		}
		public override void Load(OpenedFile file, Stream stream)
		{
			_control.Load(stream);
			TitleName = Path.GetFileName(file.FileName);
		}
		#endregion
	}
}

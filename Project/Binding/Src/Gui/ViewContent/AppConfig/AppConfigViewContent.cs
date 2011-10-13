using System;
using System.IO;
using System.Windows.Forms;

using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Gui;

namespace Aimirim.iView
{
	public class AppConfigViewContent : AbstractViewContent
	{
		#region FIELDS
		private AppConfigUserControl _control = new AppConfigUserControl();
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

		#region CONSTRUCTORS
		public AppConfigViewContent(OpenedFile file)
		{
			TabPageText = "Design";

			Files.Add(file);
			OnFileNameChanged(file);
			file.ForceInitializeView(this);
		}
		#endregion

		#region METHODS
		private void DataChanged(object sender, EventArgs e)
		{
			if (PrimaryFile != null)
			{
				PrimaryFile.MakeDirty();
			}
		}
		public override void Save(OpenedFile file, Stream stream)
		{
		}
		public override void Load(OpenedFile file, Stream stream)
		{
			TitleName = Path.GetFileName(file.FileName);
			_control.DataChanged += delegate { DataChanged(null, null); };
		}
		#endregion
	}
}

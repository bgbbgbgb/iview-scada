using System;
using System.IO;
using System.Windows.Forms;

using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Gui;

namespace Aimirim.iView
{
	public class DataSourceViewContent : AbstractViewContent
	{
		#region FIELDS
		private DataSourceUserControl _control = new DataSourceUserControl();
		private OpenedFile _file;
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
		public DataSourceViewContent(OpenedFile file)
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
			_control.Save(stream);
		}
		public override void Load(OpenedFile file, Stream stream)
		{
			_file = file;
			TitleName = Path.GetFileName(file.FileName);
			
			_control.Load(stream);
			_control.DataChanged += new EventHandler(DataChanged);
		}
		#endregion
	}
}

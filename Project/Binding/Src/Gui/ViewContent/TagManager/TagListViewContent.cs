
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

using ICSharpCode.Core;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Gui;

namespace Aimirim.iView
{
	public class TagListViewContent : AbstractViewContent
	{
		#region FIELDS
		private TagManagerUserControl _control = new TagManagerUserControl();
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

		#region CONTRUCTORS
		public TagListViewContent(OpenedFile file)
		{
			Files.Add(file);
			OnFileNameChanged(file);
			file.ForceInitializeView(this);
			TabPageText = "Design";
		}
		#endregion

		#region METHODS
		private void _control_dataGridViewTags_CurrentCellDirtyStateChanged(object sender, EventArgs e)
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
			_control.Load(stream);
			TitleName = Path.GetFileName(file.FileName);

			BindingSource bs = _control.dataGridViewTags.DataSource as BindingSource;
			bs.ListChanged += _control_dataGridViewTags_CurrentCellDirtyStateChanged;
		}
		#endregion
	}
}

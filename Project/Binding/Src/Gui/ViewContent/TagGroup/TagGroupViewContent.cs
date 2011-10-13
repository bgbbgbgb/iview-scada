using System;
using System.IO;
using System.Windows.Forms;

using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Gui;

namespace Aimirim.iView
{
	public class TagGroupViewContent : AbstractViewContent
	{
		#region FIELDS
		private TagGroupUControl _control = new TagGroupUControl();
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
		public TagGroupViewContent(OpenedFile file)
		{
			TabPageText = "Design";
			Files.Add(file);
			OnFileNameChanged(file);
			file.ForceInitializeView(this);

			//_control.dataGridViewTagGroup.CurrentCellDirtyStateChanged += new EventHandler(_control_dataGridViewTagGroup_CurrentCellDirtyStateChanged);

			BindingSource bs = _control.dataGridViewTagGroup.DataSource as BindingSource;
			bs.ListChanged += _control_dataGridViewTagGroup_CurrentCellDirtyStateChanged;
		}
		#endregion

		#region METHODS
		private void _control_dataGridViewTagGroup_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (PrimaryFile != null)
			{
				PrimaryFile.MakeDirty();
			}
		}
		public override void Dispose()
		{
			if (_file.IsDirty)
			{
				_file.ReloadFromDisk();
			}
			_control.Dispose();
		}
		public override void Save(OpenedFile file, Stream stream)
		{
			_control.Save(stream);
			TitleName = Path.GetFileName(file.FileName);
		}
		public override void Load(OpenedFile file, Stream stream)
		{
			_file = file;
			_control.Open(stream);
			TitleName = Path.GetFileName(file.FileName);
		}
		#endregion
	}
}

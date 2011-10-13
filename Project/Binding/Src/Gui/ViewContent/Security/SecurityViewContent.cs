using System.IO;
using System.Windows.Forms;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Gui;

namespace Aimirim.iView
{

	public class SecurityViewContent : AbstractViewContent
	{
		#region FIELDS
		private SecurityUserControl _control = new SecurityUserControl();
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
		public SecurityViewContent(OpenedFile file)
		{
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
			TitleName = Path.GetFileName(file.FileName);
			
			_control.Load(stream);
			_control.DataChanged += delegate
			{
				if (PrimaryFile != null)
				{
					PrimaryFile.MakeDirty();
				}
			};
		}
		#endregion
	}
}

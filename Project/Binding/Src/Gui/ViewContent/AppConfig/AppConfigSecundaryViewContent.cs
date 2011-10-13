using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Gui;

namespace Aimirim.iView
{
	public class AppConfigSecundaryViewContent : AbstractSecondaryViewContent
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
		public ITextEditor TextEditor
		{
			get
			{
				foreach (IViewContent view in PrimaryFile.RegisteredViewContents)
				{
					ITextEditorProvider provider = view as ITextEditorProvider;
					if (provider != null)
					{
						IDocument document = provider.GetDocumentForFile(PrimaryFile);
						if (document != null)
						{
							return provider.TextEditor;
						}
					}
				}
				return null;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public AppConfigSecundaryViewContent(IViewContent viewContent) : base(viewContent)
		{
			TabPageText = "Design";
		}
		#endregion

		#region METHODS
		private void PrimaryFileChanged(object sender, EventArgs e)
		{
			if (PrimaryFile != null)
			{
				PrimaryFile.MakeDirty();
			}
		}
		protected override void LoadFromPrimary()
		{
			IFileDocumentProvider provider = this.PrimaryViewContent as IFileDocumentProvider;
			TextReader textReader = provider.GetDocumentForFile(PrimaryFile).CreateReader();
			_control.Load(textReader);
			_control.DataChanged += new EventHandler(PrimaryFileChanged);
		}
		protected override void SaveToPrimary()
		{
			IFileDocumentProvider provider = this.PrimaryViewContent as IFileDocumentProvider;
			TextReader textReader = provider.GetDocumentForFile(PrimaryFile).CreateReader();
			_control.Save(textReader, TextEditor);
		}
		#endregion
	}
}

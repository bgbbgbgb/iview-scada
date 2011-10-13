using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

using ICSharpCode.Core;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.SharpDevelop.Project;

namespace Aimirim.iView
{
	public partial class TagManagerUserControl : UserControl
	{
		#region FIELDS
		private BindingSource _bsTagList;
		private List<ITag> _tags = new List<ITag>();
		#endregion

		#region PROPERTIES
		#endregion

		#region CONSTRUCTORS
		public TagManagerUserControl()
		{
			InitializeComponent();

			_bsTagList = new BindingSource();
			_bsTagList.DataSource =  new BindingList<ITag>(_tags);

			dataGridViewTags.DataSource = _bsTagList;
		}
		#endregion

		#region METHODS
		private void TsbNewClick(object sender, EventArgs e)
		{
			using (SelectNewTag frmNewTag = new SelectNewTag())
			{
				if (frmNewTag.ShowDialog()  == DialogResult.OK)
				{
					ITag nTag = TagManager.NewTag(frmNewTag.listBox1.SelectedItem.ToString());
					if (nTag.ShowConfigurator() == DialogResult.OK)
					{
						_tags.Add(nTag);
						_bsTagList.ResetBindings(false);
					}
				}
			}
		}
		private void TsbNewLoteClick(object sender, EventArgs e)
		{
			using (SelectNewTag frmNewTag = new SelectNewTag())
			{
				frmNewTag.listBox1.Items.RemoveAt(2);
				if (frmNewTag.ShowDialog()  == DialogResult.OK)
				{
					ITag[] tags = TagManager.Instance.NewListTag(frmNewTag.listBox1.SelectedItem.ToString());
					
					if (tags != null)
					{
						foreach (ITag tag in tags)
						{
							_tags.Add(tag);
						}
						_bsTagList.ResetBindings(false);
					}
				}
			}
		}
		private void TsbEditClick(object sender, EventArgs e)
		{
			ITag currentTag = _bsTagList.Current as ITag;
			if (currentTag.ShowConfigurator() == DialogResult.OK)
			{
				_bsTagList.ResetCurrentItem();
			}
		}
		private void TsbDeleteClick(object sender, EventArgs e)
		{
			if (MessageBox.Show("Confirma?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				_bsTagList.RemoveCurrent();
			}
		}
		
		private void ToolStripTextBox1Enter(object sender, EventArgs e)
		{
			toolStripTextBox1.Clear();
			toolStripTextBox1.ResetFont();
			toolStripTextBox1.ResetForeColor();
		}
		private void ToolStripTextBox1TextChanged(object sender, EventArgs e)
		{
			if (toolStripTextBox1.Text != string.Empty)
			{
				int indx = _tags.FindIndex(delegate(ITag tag) { return tag.Name.StartsWith(toolStripTextBox1.Text); });
				if (indx >= 0 && toolStripTextBox1.Focused)
				{
					_bsTagList.Position = indx;
					dataGridViewTags.Rows[_bsTagList.Position].Selected = true;
				}
			}
		}
		private void ToolStripTextBox1Leave(object sender, EventArgs e)
		{
			toolStripTextBox1.Clear();
			toolStripTextBox1.Font = new System.Drawing.Font(new FontFamily("Tahoma"), 8.25F, FontStyle.Italic, GraphicsUnit.Point);
			toolStripTextBox1.ForeColor = SystemColors.InactiveCaptionText;
			toolStripTextBox1.Text = "Digite aqui o nome da tag que está procurando.";
		}

		public void Save(Stream fileStream)
		{
			//
			// XmlDocument
			//
			XmlDocument xmlDocument = new XmlDocument();

			//
			// Database Node
			//
			XmlElement docElement = xmlDocument.CreateElement("DocumentElement");
			xmlDocument.AppendChild(docElement);
			
			foreach (ITag tag in _tags)
			{
				tag.WriteXml(ref docElement);
			}

			//
			// Save project file
			//
			xmlDocument.Save(fileStream);
		}
		public void Load(Stream fileStream)
		{
			// Limpa o conteúdo da coleção
			_bsTagList.Clear();

			//
			// XmlDocument
			//
			XmlDocument xmlDocument = null;
			StreamReader fileStreamReader = null;

			//
			// Load TagDatabase file
			//
			xmlDocument = new XmlDocument();
			fileStreamReader = new StreamReader(fileStream);

			xmlDocument.Load(fileStream);
			XmlElement docRoot = xmlDocument.DocumentElement;

			foreach (XmlNode tagNode in docRoot.ChildNodes)
			{
				ITag nTag = TagManager.NewTag(tagNode.Attributes["DataType"].Value);
				nTag.ReadXml(tagNode);

				_bsTagList.Add(nTag);
			}

			fileStream.Close();
			fileStream = null;
		}
		#endregion
	}
}

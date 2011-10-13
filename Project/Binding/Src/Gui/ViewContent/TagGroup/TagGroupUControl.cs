using System.ComponentModel;
using System.Data;
using System.Xml;

namespace Aimirim.iView
{
	using System;
	using System.IO;
	using System.Windows.Forms;
	using ICSharpCode.SharpDevelop.Project;
	using ICSharpCode.SharpDevelop.Gui;
	using ICSharpCode.SharpDevelop;
	using System.Collections.Generic;
	using ICSharpCode.Core;

	internal partial class TagGroupUControl : UserControl
	{
		#region FIELDS
		private DataTable _tbTagGroup;
		private BindingSource _bsTagGroup;
		private string _fileName = string.Empty;
		#endregion // fields

		#region CONSTRUCTORS
		public TagGroupUControl()
		{
			InitializeComponent();

			DataColumn symbol = new DataColumn("Symbol");
			DataColumn substitution = new DataColumn("Substitution");
			DataColumn description = new DataColumn("Description");

			_tbTagGroup = new DataTable("TagGroup");
			_tbTagGroup.Columns.Add(symbol);
			_tbTagGroup.Columns.Add(substitution);
			_tbTagGroup.Columns.Add(description);
			_bsTagGroup = new BindingSource();
			_bsTagGroup.DataSource = _tbTagGroup;

			dataGridViewTagGroup.DataSource = _bsTagGroup;
		}
		#endregion // constructors

		#region METHODS
		public void Open(Stream fileStream)
		{
			_tbTagGroup.Clear();
			_tbTagGroup.ReadXml(fileStream);
		}
		public void Save(Stream fileStream)
		{
			_tbTagGroup.WriteXml(fileStream);
		}
		#endregion // methods
        
        void DataGridViewTagGroupKeyDown(object sender, KeyEventArgs e)
        {
			if (e.Control && e.KeyCode == Keys.C)
			{
				DataObject d = dataGridViewTagGroup.GetClipboardContent();
				Clipboard.SetDataObject(d);
				e.Handled = true;
			}
			else if(e.Control && e.KeyCode == Keys.V)
			{
				string s = Clipboard.GetText();
				string[] lines = s.Split('\n');
				int row = _bsTagGroup.Position;
				int col = dataGridViewTagGroup.CurrentCell.ColumnIndex;
				foreach (string line in lines)
				{
					if (line.Length > 0)
					{
						DataRowView drv = null;
						if (row < _bsTagGroup.Count)
						{
							drv = _bsTagGroup[row] as DataRowView;
						}
						else
						{
							drv = _bsTagGroup.AddNew() as DataRowView;
						}
						string[] cells = line.Split('\t');
						drv["Symbol"] = cells[0];
						drv["Substitution"] = cells[1];
						drv["Description"] = cells[2];
//						for (int i = 0; i < cells.GetLength(0); ++i)
//						{
//							if (col + i < this.dataGridViewTagGroup.ColumnCount)
//							{
//								drv[Symbol] = cells[i];
//							}
//							else
//							{
//								break;
//							}
//						}
						row++;
					}
					else
					{
						break;
					}
				}
			}
		}
	}
}

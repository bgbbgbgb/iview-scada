using System.Data;

namespace Aimirim.iView
{
	using System.Windows.Forms;
	using System;

	public partial class AnalogTagListConfigurator : Form
	{
		private BindingSource _bs = new BindingSource();
		private DataTable _dt = new DataTable();
		
		#region FIELDS
		private TagAnalog[] _items;
		#endregion
		
		#region PROPERTIES
		public ITag[] Items
		{
			get
			{
				return _items;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public AnalogTagListConfigurator()
		{
			InitializeComponent();
			
		}
		#endregion

		#region METHODS
		void TagConfiguratorLoad(object sender, EventArgs e)
		{
			SignalCondition16383 sc = new SignalCondition16383();
			
			foreach (IDriver drv in DriverManager.Instance.Drivers.ToArray())
			{
				TgDriver.Items.Add(drv.ToString());
			}
			
			signalCondition.Items.Add(sc.ToString());
			
		}
		void ButtonOkClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			
			_items = new TagAnalog[dataGridView1.RowCount -1];
			int idx = 0;

			IDriver[] drivers = DriverManager.Instance.Drivers.ToArray();
			ISignalCondition sc = null;
			for (int i = 0; i < dataGridView1.RowCount - 1; i++)
			{
				_items[idx] = new TagAnalog();
				_items[idx].Name        = dataGridView1.Rows[i].Cells[0].Value.ToString();
				_items[idx].Description = dataGridView1.Rows[i].Cells[1].Value.ToString();
				foreach (IDriver driver in drivers)
				{
					if (driver.ToString() == dataGridView1.Rows[i].Cells[2].Value.ToString())
					{
						_items[idx].Driver = driver;
					}
				}
				_items[idx].Address     = dataGridView1.Rows[i].Cells[3].Value.ToString();
				_items[idx].Historical  = Convert.ToBoolean(dataGridView1.Rows[i].Cells[4].Value.ToString());
				if (dataGridView1.Rows[i].Cells[5].Value.ToString().Equals(""))
				{
					sc = null;
				}
				else
				{
					sc = new SignalCondition16383();
				}
				_items[idx].SignalCondition = sc;
				_items[idx].Min = dataGridView1.Rows[i].Cells[6].Value.ToString();
				_items[idx].Max = dataGridView1.Rows[i].Cells[7].Value.ToString();
				
				idx++;
			}
			
			return;
		}
		void DataGridView1KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.C)
			{
				DataObject d = dataGridView1.GetClipboardContent();
				Clipboard.SetDataObject(d);
				e.Handled = true;
			}
			else if(e.Control && e.KeyCode == Keys.V)
			{
				string s = Clipboard.GetText();
				string[] lines = s.Split('\n');
				int row = dataGridView1.CurrentCell.RowIndex;
				int startRow = row;
				int col = dataGridView1.CurrentCell.ColumnIndex;
				int nImport = 0;
				foreach (string line in lines)
				{
					if (line.Length > 0)
					{
						if (lines.Length + startRow > dataGridView1.RowCount)
						{
							dataGridView1.Rows.Add((lines.Length + row) - dataGridView1.RowCount);
						}
						string[] cells = line.Split('\t');
						if (cells.Length > 8)
						{
							nImport++;
						}
						else
						{
							dataGridView1[0,row].Value = Convert.ChangeType(cells[0].Replace('\r',' ').Trim(), dataGridView1[0, row].ValueType);
							dataGridView1[1,row].Value = Convert.ChangeType(cells[1].Replace('\r',' ').Trim(), dataGridView1[1, row].ValueType);
							dataGridView1[2,row].Value = Convert.ChangeType(cells[2].Replace('\r',' ').Trim(), dataGridView1[2, row].ValueType);
							dataGridView1[3,row].Value = Convert.ChangeType(cells[3].Replace('\r',' ').Trim(), dataGridView1[3, row].ValueType);
							cells[4] = cells[4].ToUpper().Replace('\r',' ').Trim();
							if (cells[4].Equals("SIM")  ||
							    cells[4].Equals("S")    ||
							    cells[4].Equals("YES")  ||
							    cells[4].Equals("Y")    ||
							    cells[4].Equals("TRUE") ||
							    cells[4].Equals("T")
							   )
							{
								dataGridView1[4,row].Value = true;
							}
							else
							{
								dataGridView1[4,row].Value = false;
							}
							dataGridView1[5,row].Value = Convert.ChangeType(cells[5].Replace('\r',' ').Trim(), dataGridView1[5, row].ValueType);
							dataGridView1[6,row].Value = Convert.ChangeType(cells[6].Replace('\r',' ').Trim(), dataGridView1[6, row].ValueType);
							dataGridView1[7,row].Value = Convert.ChangeType(cells[7].Replace('\r',' ').Trim(), dataGridView1[7, row].ValueType);
						}
						row++;
					}
					else
					{
						break;
					}
				}
				
				if (nImport > 0)
				{
					MessageBox.Show(nImport.ToString() + " não foram transferidos por possuírem colunas demais");
				}
			}
		}
		#endregion
	}
}

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Aimirim.iView
{
	public class iPen
	{
		#region FIELDS
		private string _name;
		private string _description;
		private string _value;
		private Color _lineColor;
		private int _borderWidth = 1;
		private double _minimum = 0;
		private double _maximum = 0;
		
		private ITag _tag;
		
		#endregion // fields
		
		#region PROPERTIES
		public string Name
		{
			get
			{
				if (_tag != null)
				{
					return _tag.Name;
				}
				
				return _name;
			}
			set
			{
				_name = value;
			}
		}
		public string Description
		{
			get
			{
				if (_tag != null)
				{
					return _tag.Description;
				}

				return _description;
			}
			set
			{
				_description = value;
			}
		}
		public string Value
		{
			get
			{
				return string.Format("{0:F2}", double.Parse(_value));
			}
		}
		public Color LineColor
		{
			get
			{
				return _lineColor;
			}
			set
			{
				_lineColor = value;
			}
		}
		public int BorderWidth
		{
			get
			{
				return _borderWidth;
			}
			set
			{
				_borderWidth = value;
			}
		}
		public double Minimum
		{
			get
			{
				return _minimum;
			}
			set
			{
				_minimum = value;
			}
		}
		public double Maximum
		{
			get
			{
				return _maximum;
			}
			set
			{
				_maximum = value;
			}
		}
		[Browsable(false)]
		public DataTable Historical
		{
			get
			{
				if (_tag != null)
				{
					IHistorical histTag = _tag as IHistorical;
					if (histTag != null)
					{
						return histTag.ToDataTable();
					}
				}
				return null;
			}
		}
		#endregion // properties
		
		#region CONSTRUCTORS
		public iPen()
		{
		}
		#endregion // constructors
		
		#region METHODS
		public void Attach(Control parent)
		{
			IFrmTagGroup frm = parent.FindForm() as IFrmTagGroup;
			_tag = TagManager.Instance.GetTag(Name, frm);
			_value = _tag.Value;
			_tag.ValueChanged += new EventHandler(TagValueChanged);
		}
		private void OnValueChanged()
		{
			
		}
		private void TagValueChanged(object sender, EventArgs e)
		{
			_value = _tag.Value;
		}
		#endregion // methods
	}
}

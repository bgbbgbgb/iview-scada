
namespace Aimirim.iView
{
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Drawing;
	using System.Windows.Forms;
	using System.Xml;
	using System.Collections.Generic;
	using System.Drawing.Imaging;

	[ToolboxItem(false)]
	[ToolboxBitmapAttribute(typeof(iCheckBox))]
	public class iCheckBox : CheckBox, ISupportInitialize
	{
		#region FIELDS
		private string _inputTag;
		private ITag _tag;
		private iCheckBoxAnimotion _animotion;
		private delegate void OutputUpdateDelegate(string data);
		#endregion

		#region PROPERTIES
		[CategoryAttribute("Behavior")]
		[DescriptionAttribute("")]
		public string InputTag
		{
			get
			{
				return _inputTag;
			}
			set
			{
				if (value != _inputTag)
				{
					_inputTag = value;
					OnInputTagChanged();
				}
			}
		}
		[CategoryAttribute("Behavior")]
		[DescriptionAttribute("iView SCADA properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public iCheckBoxAnimotion Animotion
		{
			get
			{
				if (_animotion == null)
				{
					_animotion = new iCheckBoxAnimotion();
				}
				return _animotion;
			}
			set
			{
				_animotion = value;
			}
		}

		public new string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				if (DesignMode || !Animotion.Text.Enable)
				{
					base.Text = value;
				}
			}
		}
		
		#endregion

		#region CONSTRUCTORS
		public iCheckBox()
		{
		}
		#endregion

		#region METHODS
		private void OutputUpdateCallback(string data)
		{
			Checked = int.Parse(data) > 0 ? true : false;
		}
		protected override void OnCheckedChanged(EventArgs e)
		{
			//
			// Escreve na tag
			// 
			if (!DesignMode)
			{
				if (_tag != null && _tag.Value.ToString() != (Checked ? "1" : "0"))
				{
					_tag.Value = Checked ? "1" : "0";
				}
			}
			
			//
			// e avisa os interessados
			// 
			base.OnCheckedChanged(e);
		}
		private void OnInputTagChanged()
		{
			if (!DesignMode && _inputTag != null)
			{
				_tag = TagManager.Instance.GetTag(_inputTag, FindForm() as IFrmTagGroup);
				if (_tag != null)
				{
					int result;
					if (int.TryParse(_tag.Value.ToString(), out result))
					{
						Checked = result > 0 ? true : false;
					}
					
					_tag.ValueChanged += delegate
					{
						if (InvokeRequired)
						{
							Invoke(new OutputUpdateDelegate(OutputUpdateCallback), new object[] { _tag.Value });
						}
						else
						{
							OutputUpdateCallback(_tag.Value.ToString()); //call directly
						}
					};
				}
			}
			
		}

		public void BeginInit()
		{
		}
		public void EndInit()
		{
			if (!DesignMode)
			{
				OnInputTagChanged();
				Animotion.Attach(this);
			}
		}
		#endregion
	}
}


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
	using System.Drawing.Design;

	[ToolboxItem(false)]
	[ToolboxBitmapAttribute(typeof(iTextBox))]
	public class iTextBox : TextBox, ISupportInitialize
	{
		#region FIELDS
		private ITag _tag;
		private string _inputTag;
		private iTextBoxAnimotion _animotion;
		private delegate void OutputUpdateDelegate(string data);

		private event EventHandler click;
		private event EventHandler doubleclick;
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
				_inputTag = value;
				OnInputTagChanged();
			}
		}
		[CategoryAttribute("Behavior")]
		[DescriptionAttribute("iView SCADA properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public iTextBoxAnimotion Animotion
		{
			get
			{
				if (_animotion == null)
				{
					_animotion = new iTextBoxAnimotion();
				}
				return _animotion;
			}
			set
			{
				_animotion = value;
			}
		}
		#endregion

		#region CONSTRUCTORS
		public iTextBox()
		{
		}
		#endregion

		#region METHODS
		protected override void OnClick(EventArgs e)
		{
			if (this.click != null)
			{
				this.click(this, e);
			}
		}
		public new event EventHandler Click
		{
			add
			{
				click += value;
			}
			remove
			{
				click -= value;
			}
		}
		protected override void OnDoubleClick(EventArgs e)
		{
			if (this.doubleclick != null)
			{
				this.doubleclick(this,e);
			}
		}
		public new event EventHandler DoubleClick
		{
			add
			{
				doubleclick += value;
			}
			remove
			{
				doubleclick -= value;
			}
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			if ((click != null && click.GetInvocationList().Length > 0) || (doubleclick != null && doubleclick.GetInvocationList().Length > 0) )
			{
				this.Cursor = Cursors.Hand;
			}
			base.OnMouseEnter(e);
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			if (this.Cursor == Cursors.Hand)
			{
				this.Cursor = Cursors.Default;
			}
			base.OnMouseLeave(e);
		}
		protected override void OnValidated(EventArgs e)
		{
			//
			// Escreve na tag
			//
			if (!DesignMode && _inputTag != null && _tag != null && _tag.Value.ToString() != Text)
			{
				_tag.Value = Text;
			}
			
			base.OnValidated(e);
		}
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			
			if (e.KeyChar == (Char)Keys.Enter)
			{
				OnValidated(new EventArgs());
			}
			else if (e.KeyChar == (Char)Keys.Escape)
			{
				if (!DesignMode && _inputTag != null && _tag != null && _tag.Value.ToString() != Text)
				{
					Text = _tag.Value.ToString();
				}
			}
		}
		
		private void OnInputTagChanged()
		{
			if (!DesignMode && _inputTag != null)
			{
				_tag = TagManager.Instance.GetTag(_inputTag, FindForm() as IFrmTagGroup);
				if (_tag != null)
				{
					Text = _tag.Value.ToString();
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
		private void OutputUpdateCallback(string data)
		{
			if (Text != data)
			{
				Text = data;
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

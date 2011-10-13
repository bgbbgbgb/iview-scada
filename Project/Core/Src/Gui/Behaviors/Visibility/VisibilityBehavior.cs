
namespace Aimirim.iView
{
	using System;
	using System.ComponentModel;
	using System.Windows.Forms;
	using System.Xml;
	using System.Collections.Generic;
	using System.Drawing;

	[TypeConverter(typeof(BehaviorConverter))]
	public class VisibilityBehavior : AbstractBehavior
	{
		#region FIELDS
		private bool _enable;
		private string _expression;
		private delegate void OutputUpdateDelegate();
		#endregion

		#region PROPERTIES
		public bool Enable
		{
			get
			{
				return _enable;
			}
			set
			{
				_enable = value;
			}
		}
		public string Expression
		{
			get
			{
				return _expression;
			}
			set
			{
				_expression = value;
			}
		}
		public override string ToString()
		{
			// Mostra vazio na propertieGrid
			return String.Empty;
		}
		
		#endregion

		#region CONSTRUCTORS
		public VisibilityBehavior()
		{
		}
		#endregion

		#region METHODS
		public void Attach(Control parent)
		{
			_parent = parent;
			_parent.Disposed += delegate 
			{	
				foreach (ITag tag in _tagList)
				{
					tag.ValueChanged -= new EventHandler(tag_ValueChanged);
				}
			};
		}
		public override void Execute()
		{
			if (_parent != null)
			{
				if (_parent.InvokeRequired)
				{
					_parent.Invoke(new OutputUpdateDelegate(OutputUpdateCallback), new object[] {  });
				}
				else
				{
					OutputUpdateCallback(); //call directly
				}
			}
		}
		private void OutputUpdateCallback()
		{
			if (Enable)
			{
				bool result;
				string val = getResult(_expression, _parent.FindForm() as IFrmTagGroup).ToString();
				if (bool.TryParse(val, out result))
				{
					_parent.Visible = result;
				}
			}
		}
		#endregion
	}
}

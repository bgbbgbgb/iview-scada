namespace Aimirim.iView
{
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Drawing;
	using System.Windows.Forms;
	using System.Xml;
	using System.Drawing.Imaging;
	using System.Runtime.InteropServices;
	using System.Drawing.Drawing2D;
	using System.Drawing.Design;


	[TypeConverter(typeof(BehaviorConverter))]
	public abstract class AbstractAnimotion
	{
		#region FIELDS
		#endregion

		#region PROPERTIES
		#endregion
		
		#region CONSTRUCTORS
		#endregion

		#region METHODS
		public override string ToString()
		{
			return string.Empty;
		}
		
		/// <summary>
		/// Inicializa os mecanismos de animação. É executado
		/// quando a classe for atribuida a propriedade do componente
		/// </summary>
		public abstract void Attach(Control parent);
		#endregion
		
		#region EVENTS
		#endregion

	}
}

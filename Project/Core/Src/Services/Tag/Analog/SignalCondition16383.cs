using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Data;

namespace Aimirim.iView
{
	public class SignalCondition16383 : ISignalCondition
	{
		#region FIELDS
		#endregion

		#region PROPERTIES
		public String Id
		{
			get
			{
				return "62F85763-83A6-499c-8BC8-BB696579F58E";
			}
		}
		#endregion

		#region CONSTRUCTORS
		public SignalCondition16383()
		{
		}
		#endregion
		
		#region METHODS
		public override string ToString()
		{
			return "16383 Conversion";
		}
		public String Convert(String value, String min, String max, TypeDirection direction)
		{
			//y = mx + b
			//
			//Where:
			//y = scaled output
			//m = slope (scaled max. -scaled min.)/(input max. -input min.)
			//x = input value
			//b = offset (y intercept) = scaled min - (input min. X slope)

			double valueOut;
			double minOut;
			double maxOut;
			if (double.TryParse(value, out valueOut) && double.TryParse(min, out minOut)
			    && double.TryParse(max, out maxOut))
			{
				if (direction == TypeDirection.ToDataSource)
				{
					double raw = double.Parse(value);
					double raw_min = double.Parse(min);
					double raw_max = double.Parse(max);
					double scaled_min = 0;
					double scaled_max = 16383;
					
					double m = ((scaled_max - (-scaled_min)) / (raw_max - (-raw_min)));
					double x = raw;
					double b = scaled_min - (raw_min * (m));
					double scaled =  (m * x) + b;
					return string.Format("{0:F0}", scaled);
				}
				else
				{
					double raw = double.Parse(value);
					double raw_min = 0;
					double raw_max = 16383;
					double scaled_min = double.Parse(min);
					double scaled_max = double.Parse(max);

					double m = ((scaled_max - (-scaled_min)) / (raw_max - (-raw_min)));
					double x = raw;
					double b = scaled_min - (raw_min * (m));
					double scaled =  (m * x) + b;
					return string.Format("{0:F0}", scaled);
				}
			}
			else
			{
				return value;
			}
		}
		
		#endregion
	}
}

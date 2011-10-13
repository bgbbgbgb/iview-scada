using System;
using System.ComponentModel; 

namespace Aimirim.iView
{

    // This is a special type converter which will be associated with the EmployeeCollection class.
    // It converts an EmployeeCollection object to a string representation for use in a property grid.
    internal class TextTableCollectionConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(string) && value is TextTableCollection)
            {
                // Return department and department role separated by comma.
                return "";
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }
}

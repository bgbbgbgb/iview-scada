
namespace Aimirim.iView
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing.Design;
    using System.Windows.Forms.Design;

    public partial class FillEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null)
            {
                return UITypeEditorEditStyle.Modal;
            }
            return base.GetEditStyle(context);
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((context != null) && (provider != null))
            {
                // Access the Property Browser's UI display service
                IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (editorService != null)
                {
                    // Create an instance of the UI editor form
                    FillForm modalEditor = new FillForm();

                    // Pass the UI editor dialog the current property value
                    modalEditor.Behavior = value as FillBehavior;

                    // Display the UI editor dialog
                    if (editorService.ShowDialog(modalEditor) == DialogResult.OK)
                    {
                        // Return the new property value from the UI editor form
                        return modalEditor.Behavior;
                    }
                }
            }
            return base.EditValue(context, provider, value);
        }
    }
}

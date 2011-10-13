
namespace Aimirim.iView
{
    using System;
    using System.Text;
    using System.ComponentModel;

    /// <summary>
    /// Summary description for CollectionPropertyDescriptor.
    /// </summary>
    public class iPenCollectionPropertyDescriptor : PropertyDescriptor
    {
        #region FIELDS
        private iPenCollection collection = null;
        private int index = -1;
        #endregion

        #region PROPERTIES
        public override string Name
        {
            get { return "#" + index.ToString(); }
        }
        public override bool IsReadOnly
        {
            get { return false; }
        }
        public override string DisplayName
        {
            get
            {
                return this.collection[index].Name;
            }
        }
        public override string Description
        {
            get
            {
                return "";
            }
        }
        public override Type ComponentType
        {
            get
            {
                return this.collection.GetType();
            }
        }
        public override AttributeCollection Attributes
        {
            get
            {
                return new AttributeCollection(null);
            }
        }
        public override Type PropertyType
        {
            get { return this.collection[index].GetType(); }
        }
        #endregion

        #region CONSTRUCTORS
        public iPenCollectionPropertyDescriptor(iPenCollection coll, int idx) : base("#" + idx.ToString(), null)
        {
            this.collection = coll;
            this.index = idx;
        }
        #endregion

        #region METHODS
        public override bool CanResetValue(object component)
        {
            return true;
        }
        public override object GetValue(object component)
        {
            return this.collection[index];
        }
        public override void ResetValue(object component)
        {
        }
        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
        public override void SetValue(object component, object value)
        {
            // this.collection[index] = value;
        }
        #endregion
    }
}

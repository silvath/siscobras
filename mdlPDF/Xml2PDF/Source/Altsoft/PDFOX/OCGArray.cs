namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class OCGArray : ComplexObjectArrayDirect
    {
        // Methods
        public OCGArray(PDFDirect direct, bool single_value) : base(direct, single_value)
        {
        }

        public void Add(OCGCollectionDirect value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(OCGCollectionDirect));
        }

        public void Remove(OCGCollectionDirect value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public OCGCollectionDirect this[int index]
        {
            get
            {
                return (base._GetObject(index) as OCGCollectionDirect);
            }
            set
            {
                base._SetObject(index, value, value.mDirect);
            }
        }

    }
}


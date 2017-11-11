namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class IntList : ComplexObjectArrayDirect
    {
        // Methods
        public IntList(PDFDirect direct, bool single_name) : base(direct, single_name)
        {
        }

        public void Add(int value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(PDFInteger));
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public int this[int index]
        {
            get
            {
                return (base._GetObject(index) as PDFInteger).Int32Value;
            }
            set
            {
                PDFInteger integer1 = Library.CreateInteger(((long) value));
                base._SetObject(index, integer1, integer1.Direct);
            }
        }

    }
}


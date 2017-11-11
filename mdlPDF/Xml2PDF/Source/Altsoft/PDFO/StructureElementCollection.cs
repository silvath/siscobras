namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class StructureElementCollection : ComplexObjectArrayDirect
    {
        // Methods
        public StructureElementCollection(PDFDirect direct, bool single_value) : base(direct, single_value)
        {
        }

        public void Add(StructureElement value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(StructureElement));
        }

        public void Remove(StructureElement value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public StructureElement this[int index]
        {
            get
            {
                return (base._GetObject(index) as StructureElement);
            }
            set
            {
                base._SetObject(index, value, value.Direct);
            }
        }

    }
}


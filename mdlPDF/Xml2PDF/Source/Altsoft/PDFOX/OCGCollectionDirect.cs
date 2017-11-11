namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class OCGCollectionDirect : ComplexObjectArrayDirect
    {
        // Methods
        public OCGCollectionDirect(PDFDirect direct, bool single_value) : base(direct, single_value)
        {
        }

        public void Add(OptionalContent value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(OptionalContent));
        }

        public void Remove(OptionalContent value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public OptionalContent this[int index]
        {
            get
            {
                return (base._GetObject(index) as OptionalContent);
            }
            set
            {
                base._SetObject(index, value, value.Dict);
            }
        }

    }
}


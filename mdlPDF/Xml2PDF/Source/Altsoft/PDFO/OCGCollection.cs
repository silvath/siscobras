namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class OCGCollection : ComplexObjectArrayBase
    {
        // Methods
        public OCGCollection(PDFDict dict, string key, bool single_value) : base(dict, key, single_value)
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


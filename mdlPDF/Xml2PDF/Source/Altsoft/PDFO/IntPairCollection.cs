namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class IntPairCollection : ComplexObjectArrayBase
    {
        // Methods
        public IntPairCollection(PDFDict dict, string key, bool single_value) : base(dict, key, single_value)
        {
        }

        public void Add(IntPair value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(IntPair));
        }

        public void Remove(IntPair value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public IntPair this[int index]
        {
            get
            {
                return (base._GetObject(index) as IntPair);
            }
            set
            {
                base._SetObject(index, value, value.Dict);
            }
        }

    }
}


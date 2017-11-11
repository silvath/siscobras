namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class FieldKids : ComplexObjectArrayBase
    {
        // Methods
        public FieldKids(PDFDict dict, string key) : base(dict, key, false)
        {
        }

        public void Add(Field value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return (Resources.Get(dict, typeof(Field)) as Field);
        }

        public void Remove(Field value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public Field this[int index]
        {
            get
            {
                return (base._GetObject(index) as Field);
            }
            set
            {
                base._SetObject(index, value, value.Dict);
            }
        }

    }
}


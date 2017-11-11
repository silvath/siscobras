namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class FieldVarCollection : ComplexObjectArrayBase
    {
        // Methods
        public FieldVarCollection(PDFDict dict, string key, bool single_value) : base(dict, key, single_value)
        {
        }

        public void Add(FieldVar value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(FieldVar));
        }

        public void Remove(FieldVar value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public FieldVar this[int index]
        {
            get
            {
                return (base._GetObject(index) as FieldVar);
            }
            set
            {
                base._SetObject(index, value, value.Direct);
            }
        }

    }
}


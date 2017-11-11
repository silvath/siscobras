namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class SignRefCollection : ComplexObjectArrayBase
    {
        // Methods
        public SignRefCollection(PDFDict dict, string key, bool single_value) : base(dict, key, single_value)
        {
        }

        public void Add(SignatureReference value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(SignatureReference));
        }

        public void Remove(SignatureReference value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public SignatureReference this[int index]
        {
            get
            {
                return (base._GetObject(index) as SignatureReference);
            }
            set
            {
                base._SetObject(index, value, value.Dict);
            }
        }

    }
}


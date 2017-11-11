namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class FontList : ComplexObjectArrayBase
    {
        // Methods
        public FontList(PDFDict Dict, string key) : base(Dict, key, false)
        {
        }

        public void Add(Font value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(Font));
        }

        public void Remove(Font value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public Font this[int index]
        {
            get
            {
                return (base._GetObject(index) as Font);
            }
            set
            {
                base._SetObject(index, value, value.Direct);
            }
        }

    }
}


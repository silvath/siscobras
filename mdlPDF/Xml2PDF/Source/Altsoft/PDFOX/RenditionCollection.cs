namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class RenditionCollection : ComplexObjectArrayBase
    {
        // Methods
        public RenditionCollection(PDFDict dict, string key, bool single_value) : base(dict, key, single_value)
        {
        }

        public void Add(Rendition value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(Rendition));
        }

        public void Remove(Rendition value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public Rendition this[int index]
        {
            get
            {
                return (base._GetObject(index) as Rendition);
            }
            set
            {
                base._SetObject(index, value, value.Direct);
            }
        }

    }
}


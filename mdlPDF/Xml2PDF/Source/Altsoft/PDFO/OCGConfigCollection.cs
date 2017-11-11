namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class OCGConfigCollection : ComplexObjectArrayBase
    {
        // Methods
        public OCGConfigCollection(PDFDict dict, string key, bool single_value) : base(dict, key, single_value)
        {
        }

        public void Add(OCGConfig value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(OCGConfig));
        }

        public void Remove(OCGConfig value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public OCGConfig this[int index]
        {
            get
            {
                return (base._GetObject(index) as OCGConfig);
            }
            set
            {
                base._SetObject(index, value, value.Dict);
            }
        }

    }
}


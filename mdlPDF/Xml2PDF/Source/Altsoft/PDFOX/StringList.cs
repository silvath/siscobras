namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class StringList : ComplexObjectArrayBase
    {
        // Methods
        public StringList(PDFDict Dict, string key, bool single_name) : base(Dict, key, single_name)
        {
        }

        public void Add(string value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(PDFString));
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public string this[int index]
        {
            get
            {
                return (base._GetObject(index) as PDFString).Value;
            }
            set
            {
                PDFString text1 = Library.CreateString(value);
                base._SetObject(index, text1, text1.Direct);
            }
        }

    }
}


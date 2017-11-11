namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class NameList : ComplexObjectArrayBase
    {
        // Methods
        public NameList(PDFDict Dict, string key, bool single_name) : base(Dict, key, single_name)
        {
        }

        public void Add(string value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(PDFName));
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
                return (base._GetObject(index) as PDFName).Value;
            }
            set
            {
                PDFName name1 = Library.CreateName(value);
                base._SetObject(index, name1, name1.Direct);
            }
        }

    }
}


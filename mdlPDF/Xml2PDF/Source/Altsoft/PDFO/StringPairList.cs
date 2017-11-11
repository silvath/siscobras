namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class StringPairList : ComplexObjectCommonArrayBase
    {
        // Methods
        public StringPairList(PDFDirect direct) : base(direct, 2)
        {
        }

        public void Add(StringPair value)
        {
            base._Add(value);
        }

        internal override object ComplexObjectFactory(PDFDirect direct)
        {
            return Resources.Get(direct, typeof(StringPair));
        }

        public void Remove(StringPair value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public StringPair this[int index]
        {
            get
            {
                return (Resources.Get(this.mInternalArr[index], typeof(StringPair)) as StringPair);
            }
            set
            {
                this.mInternalArr[index] = value.Direct;
            }
        }

    }
}


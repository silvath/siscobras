namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class TagPairList : ComplexObjectCommonArrayBase
    {
        // Methods
        public TagPairList(PDFDirect direct) : base(direct, 2)
        {
        }

        public void Add(TagPair value)
        {
            base._Add(value);
        }

        internal override object ComplexObjectFactory(PDFDirect direct)
        {
            return Resources.Get(direct, typeof(TagPair));
        }

        public void Remove(TagPair value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public TagPair this[int index]
        {
            get
            {
                return (Resources.Get(this.mInternalArr[index], typeof(TagPair)) as TagPair);
            }
            set
            {
                this.mInternalArr[index] = value.Direct;
            }
        }

    }
}


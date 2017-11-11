namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class PointList : ComplexObjectCommonArrayBase
    {
        // Methods
        public PointList(PDFDirect direct) : base(direct, 2)
        {
        }

        public void Add(IntPair value)
        {
            base._Add(value);
        }

        internal override object ComplexObjectFactory(PDFDirect direct)
        {
            return Resources.Get(direct, typeof(IntPair));
        }

        public void Remove(IntPair value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public IntPair this[int index]
        {
            get
            {
                return (Resources.Get(this.mInternalArr[index], typeof(IntPair)) as IntPair);
            }
            set
            {
                this.mInternalArr[index] = value.Direct;
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class ColorantList : ComplexObjectCommonArrayBase
    {
        // Methods
        public ColorantList(PDFDirect direct) : base(direct, 2, 1)
        {
        }

        public void Add(Colorant value)
        {
            base._Add(value);
        }

        internal override object ComplexObjectFactory(PDFDirect direct)
        {
            return Resources.Get(direct, typeof(Colorant));
        }

        public void Remove(Colorant value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public string ColorantName
        {
            get
            {
                return ((base.Direct as PDFArray)[0] as PDFName).Value;
            }
        }

        public Colorant this[int index]
        {
            get
            {
                return (Resources.Get(this.mInternalArr[index], typeof(Colorant)) as Colorant);
            }
            set
            {
                this.mInternalArr[index] = value.Direct;
            }
        }

    }
}


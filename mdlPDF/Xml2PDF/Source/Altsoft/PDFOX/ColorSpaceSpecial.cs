namespace Altsoft.PDFO
{
    using System;

    public abstract class ColorSpaceSpecial : ColorSpace
    {
        // Methods
        internal ColorSpaceSpecial(PDFDirect d) : base(d)
        {
        }


        // Properties
        public ColorSpace Base
        {
            get
            {
                return (Resources.Get(((PDFArray) this.mDirect)[this.mBaseCSIndex], typeof(ColorSpace)) as ColorSpace);
            }
            set
            {
                if (value != null)
                {
                    value = (((base.Direct.Doc == null) ? value : base.Direct.Doc.Resources.Add(value)) as ColorSpace);
                }
                if (value != null)
                {
                    ((PDFArray) this.mDirect)[this.mBaseCSIndex] = value.Direct;
                    return;
                }
                ((PDFArray) this.mDirect)[this.mBaseCSIndex] = Library.CreateNull();
            }
        }

        protected abstract int mBaseCSIndex { get; }

    }
}


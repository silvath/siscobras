namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class ShadingByFunction : Shading
    {
        // Methods
        public ShadingByFunction(PDFDirect d) : base(d)
        {
            this.mDomain = null;
        }


        // Properties
        public virtual DoubleMinMaxArray Domain
        {
            get
            {
                return this.mDomain;
            }
            set
            {
                this.Domain.Set(value);
            }
        }


        // Fields
        protected DoubleMinMaxArray mDomain;
    }
}


namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;

    public abstract class CorePDFDirect : CorePDFObject, PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Methods
        public CorePDFDirect()
        {
        }


        // Properties
        public override PDFDirect Direct
        {
            get
            {
                return this;
            }
            set
            {
                throw new NotSupportedException("Can\'t set direct of DIRECT object");
            }
        }

        public override bool Dirty
        {
            get
            {
                if (base.Parent != null)
                {
                    return base.Parent.Dirty;
                }
                return false;
            }
            set
            {
                if (!value)
                {
                    return;
                }
                if (base.Parent != null)
                {
                    base.Parent.Dirty = true;
                }
            }
        }

        public override Document Doc
        {
            get
            {
                if (base.Parent != null)
                {
                    return base.Parent.Doc;
                }
                return null;
            }
        }

        public override PDFIndirect Indirect
        {
            get
            {
                if (this.IsIndirect)
                {
                    return ((PDFIndirect) base.Parent);
                }
                return null;
            }
        }

        public override bool IsIndirect
        {
            get
            {
                if (base.Parent != null)
                {
                    return base.Parent.GetType().Equals(typeof(CorePDFIndirect));
                }
                return false;
            }
        }

    }
}


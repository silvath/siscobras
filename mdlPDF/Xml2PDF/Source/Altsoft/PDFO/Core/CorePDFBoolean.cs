namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;

    public sealed class CorePDFBoolean : CorePDFDirect, PDFBoolean, PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Methods
        internal CorePDFBoolean(bool val)
        {
            this.mValue = val;
        }

        public override object Clone()
        {
            return new CorePDFBoolean(this.mValue);
        }

        public override string ToString()
        {
            return this.mValue.ToString();
        }


        // Properties
        public override PDFObjectType PDFType
        {
            get
            {
                return PDFObjectType.tPDFBoolean;
            }
        }

        public bool Value
        {
            get
            {
                return this.mValue;
            }
            set
            {
                base._Changing();
                this.Dirty = (this.mValue != value);
                this.mValue = value;
                base._Changed();
            }
        }


        // Fields
        private bool mValue;
    }
}


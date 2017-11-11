namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;

    public sealed class CorePDFInteger : CorePDFNumeric, PDFInteger, PDFNumeric, PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Methods
        internal CorePDFInteger(long val)
        {
            this.mValue = val;
        }

        public override object Clone()
        {
            return new CorePDFInteger(this.mValue);
        }

        public override string ToString()
        {
            return this.mValue.ToString();
        }


        // Properties
        public override double DoubleValue
        {
            get
            {
                return ((double) this.mValue);
            }
        }

        public override int Int32Value
        {
            get
            {
                return ((int) this.mValue);
            }
        }

        public override long Int64Value
        {
            get
            {
                return this.mValue;
            }
        }

        public override PDFObjectType PDFType
        {
            get
            {
                return PDFObjectType.tPDFInteger;
            }
        }

        public long Value
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
        private long mValue;
    }
}


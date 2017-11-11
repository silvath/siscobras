namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;

    public sealed class CorePDFFixed : CorePDFNumeric, PDFFixed, PDFNumeric, PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Methods
        internal CorePDFFixed(double val)
        {
            this.mValue = val;
        }

        public override object Clone()
        {
            return new CorePDFFixed(this.mValue);
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
                return this.mValue;
            }
        }

        public override int Int32Value
        {
            get
            {
                if (Math.Abs(this.mValue) > 2147483647f)
                {
                    throw new OverflowException("Value is outside integer range");
                }
                return ((int) this.mValue);
            }
        }

        public override long Int64Value
        {
            get
            {
                return ((long) this.mValue);
            }
        }

        public override PDFObjectType PDFType
        {
            get
            {
                return PDFObjectType.tPDFFixed;
            }
        }

        public double Value
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
        private double mValue;
    }
}


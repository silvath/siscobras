namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    internal class PDFRect : Rect
    {
        // Methods
        internal PDFRect(PDFArray arr)
        {
            this.mArr = null;
            this.mArr = new PDFDoubleArray(arr, 4);
            try
            {
                this.x1 = this.mArr[0];
                this.y1 = this.mArr[1];
                this.x2 = this.mArr[2];
                this.y2 = this.mArr[3];
            }
            catch (InvalidCastException)
            {
                throw new ArgumentOutOfRangeException("arr", arr, "Array describing rectangle should contain NUMERIC values");
            }
        }

        internal PDFRect(PDFDict parent, string keyName, params double[] def)
        {
            this.mArr = null;
            this.mArr = new PDFDoubleArray(parent, keyName, false, def);
            try
            {
                this.x1 = this.mArr[0];
                this.y1 = this.mArr[1];
                this.x2 = this.mArr[2];
                this.y2 = this.mArr[3];
            }
            catch (InvalidCastException)
            {
                throw new ArgumentOutOfRangeException("arr", parent, "Array describing rectangle should contain NUMERIC values");
            }
        }


        // Properties
        public override double x1
        {
            get
            {
                return base.x1;
            }
            set
            {
                base.x1 = value;
                this.mArr[0] = value;
            }
        }

        public override double x2
        {
            get
            {
                return base.x2;
            }
            set
            {
                base.x2 = value;
                this.mArr[2] = value;
            }
        }

        public override double y1
        {
            get
            {
                return base.y1;
            }
            set
            {
                base.y1 = value;
                this.mArr[1] = value;
            }
        }

        public override double y2
        {
            get
            {
                return base.y2;
            }
            set
            {
                base.y2 = value;
                this.mArr[3] = value;
            }
        }


        // Fields
        private PDFDoubleArray mArr;
    }
}


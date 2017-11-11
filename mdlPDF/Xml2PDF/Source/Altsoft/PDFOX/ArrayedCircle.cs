namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    internal class ArrayedCircle : Circle
    {
        // Methods
        internal ArrayedCircle(DoubleArray arr, int offset)
        {
            this.mArr = null;
            this.mOffset = 0;
            this.mArr = arr;
            this.mOffset = offset;
            base.x = this.mArr[this.mOffset];
            base.y = this.mArr[(this.mOffset + 1)];
            base.r = this.mArr[(this.mOffset + 2)];
        }


        // Properties
        public override double r
        {
            get
            {
                return base.r;
            }
            set
            {
                base.r = value;
                this.mArr[(this.mOffset + 2)] = value;
            }
        }

        public override double x
        {
            get
            {
                return base.x;
            }
            set
            {
                base.x = value;
                this.mArr[this.mOffset] = value;
            }
        }

        public override double y
        {
            get
            {
                return base.y;
            }
            set
            {
                base.y = value;
                this.mArr[(this.mOffset + 1)] = value;
            }
        }


        // Fields
        private DoubleArray mArr;
        private int mOffset;
    }
}


namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public abstract class ColorSpaceCal : ColorSpaceCIEBased
    {
        // Methods
        internal ColorSpaceCal(PDFDirect d) : base(d)
        {
            this.mWhitePoint = null;
            this.mBlackPoint = null;
            this.mGamma = null;
        }


        // Properties
        public DoubleArray BlackPoint
        {
            get
            {
                double[] numArray1;
                if (this.mBlackPoint == null)
                {
                    numArray1 = new double[3];
                    this.mBlackPoint = new PDFDoubleArray(this.Dict, "BlackPoint", false, numArray1);
                }
                return this.mBlackPoint;
            }
            set
            {
                this.BlackPoint.Set(value);
            }
        }

        public override PDFDict Dict
        {
            get
            {
                return (((PDFArray) this.mDirect)[1] as PDFDict);
            }
        }

        public virtual DoubleArray Gamma
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                this.Gamma.Set(value);
            }
        }

        public DoubleArray WhitePoint
        {
            get
            {
                double[] numArray1;
                if (this.mWhitePoint == null)
                {
                    numArray1 = new double[3];
                    numArray1[0] = 1f;
                    numArray1[1] = 1f;
                    numArray1[2] = 1f;
                    this.mWhitePoint = new PDFDoubleArray(this.Dict, "WhitePoint", false, numArray1);
                }
                return this.mWhitePoint;
            }
            set
            {
                this.WhitePoint.Set(value);
            }
        }


        // Fields
        private PDFDoubleArray mBlackPoint;
        internal PDFDoubleArray mGamma;
        private PDFDoubleArray mWhitePoint;
    }
}


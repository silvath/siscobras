namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class ShadingType2 : ShadingByFunction
    {
        // Methods
        public ShadingType2(PDFDirect d) : base(d)
        {
            this.mCoords = null;
            this.mExtend = null;
        }


        // Properties
        public PointArray Coords
        {
            get
            {
                PDFArray array1;
                if (this.mCoords == null)
                {
                    array1 = ((PDFArray) this.Dict["Coords"]);
                    if (array1 != null)
                    {
                        this.mCoords = new PointArray(new PDFDoubleArray(array1, array1.Count));
                    }
                }
                return this.mCoords;
            }
            set
            {
                double[] numArray1;
                if (this.Coords == null)
                {
                    numArray1 = new double[4];
                    this.mCoords = new PointArray(new PDFDoubleArray(this.Dict, "Coords", false, numArray1));
                }
                this.Coords.Set(value);
            }
        }

        public override DoubleMinMaxArray Domain
        {
            get
            {
                double[] numArray1;
                if (this.mDomain == null)
                {
                    numArray1 = new double[2];
                    numArray1[1] = 1f;
                    this.mDomain = new DoubleMinMaxArray(new PDFDoubleArray(this.Dict, "Domain", false, numArray1));
                }
                return this.mDomain;
            }
            set
            {
                if (value.Count != 1)
                {
                    throw new ArgumentException("Domain for Type1 shading should be one-dimetional", "value");
                }
                base.Domain = value;
            }
        }

        private BoolArray Extend
        {
            get
            {
                bool[] flagArray1;
                if (this.mExtend == null)
                {
                    flagArray1 = new bool[2];
                    this.mExtend = new PDFBoolArray(this.Dict, "Extend", false, flagArray1);
                }
                return this.mExtend;
            }
        }

        public bool ExtendBeyondEnd
        {
            get
            {
                return this.Extend[1];
            }
            set
            {
                this.Extend[1] = value;
            }
        }

        public bool ExtendBeyondStart
        {
            get
            {
                return this.Extend[0];
            }
            set
            {
                this.Extend[0] = value;
            }
        }


        // Fields
        private PointArray mCoords;
        private PDFBoolArray mExtend;
    }
}


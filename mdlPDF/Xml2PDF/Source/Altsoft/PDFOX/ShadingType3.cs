namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class ShadingType3 : ShadingByFunction
    {
        // Methods
        public ShadingType3(PDFDirect d) : base(d)
        {
            this.mCoords = null;
            this.mStartCoord = null;
            this.mEndCoord = null;
            this.mExtend = null;
        }


        // Properties
        private DoubleArray CoordsArr
        {
            get
            {
                double[] numArray1;
                if (this.mCoords == null)
                {
                    numArray1 = new double[6];
                    this.mCoords = new PDFDoubleArray(this.Dict, "Coords", false, numArray1);
                    if (this.Dict["Coords"] == null)
                    {
                        this.mCoords[0] = 0f;
                    }
                }
                return this.mCoords;
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
                    throw new ArgumentException("Domain for Type3 shading should be two-dimetional", "value");
                }
                base.Domain = value;
            }
        }

        public Circle EndCoord
        {
            get
            {
                if (this.mEndCoord == null)
                {
                    this.mEndCoord = new ArrayedCircle(this.CoordsArr, 3);
                }
                return this.mEndCoord;
            }
            set
            {
                this.EndCoord.Set(value);
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

        public Circle StartCoord
        {
            get
            {
                if (this.mStartCoord == null)
                {
                    this.mStartCoord = new ArrayedCircle(this.CoordsArr, 0);
                }
                return this.mStartCoord;
            }
            set
            {
                this.StartCoord.Set(value);
            }
        }


        // Fields
        private PDFDoubleArray mCoords;
        private ArrayedCircle mEndCoord;
        private PDFBoolArray mExtend;
        private ArrayedCircle mStartCoord;
    }
}


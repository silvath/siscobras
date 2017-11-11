namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class ShadingType1 : ShadingByFunction
    {
        // Methods
        public ShadingType1(PDFDirect d) : base(d)
        {
            this.mCTM = null;
        }

        public static ShadingType1 Create(ColorSpace cs, Function fn)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Type"] = Library.CreateName("Shading");
            dict1["ShadingType"] = Library.CreateInteger(((long) 1));
            dict1["ColorSpace"] = cs.Direct;
            dict1["Function"] = fn.Direct;
            return new ShadingType1(dict1);
        }


        // Properties
        public CTM CTM
        {
            get
            {
                double[] numArray1;
                if (this.mCTM == null)
                {
                    numArray1 = new double[6];
                    numArray1[0] = 1f;
                    numArray1[3] = 1f;
                    this.mCTM = new PDFCTM(this.Dict, "Matrix", numArray1);
                }
                return this.mCTM;
            }
            set
            {
                this.CTM.Set(value);
            }
        }

        public override DoubleMinMaxArray Domain
        {
            get
            {
                double[] numArray1;
                if (this.mDomain == null)
                {
                    numArray1 = new double[4];
                    numArray1[1] = 1f;
                    numArray1[3] = 1f;
                    this.mDomain = new DoubleMinMaxArray(new PDFDoubleArray(this.Dict, "Domain", false, numArray1));
                }
                return this.mDomain;
            }
            set
            {
                if (value.Count != 2)
                {
                    throw new ArgumentException("Domain for Type1 shading should be two-dimetional", "value");
                }
                base.Domain = value;
            }
        }


        // Fields
        private PDFCTM mCTM;
    }
}


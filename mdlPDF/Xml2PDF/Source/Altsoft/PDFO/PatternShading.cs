namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class PatternShading : Pattern
    {
        // Methods
        public PatternShading(PDFDirect d) : base(d)
        {
            this.mShading = null;
            this.mCTM = null;
            this.mExtGState = null;
        }

        public static PatternShading Create(Shading sh)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Type"] = Library.CreateName("Pattern");
            dict1["PatternType"] = Library.CreateInteger(((long) 2));
            dict1["Shading"] = sh.Direct;
            return new PatternShading(dict1);
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

        public ExtGState ExtGState
        {
            get
            {
                if (this.mExtGState == null)
                {
                    if (this.Dict["ExtGState"] == null)
                    {
                        return null;
                    }
                    if (this.Dict.Doc == null)
                    {
                        this.mExtGState = ((ExtGState) ExtGState.Factory(this.Dict["ExtGState"].Direct));
                    }
                    else
                    {
                        this.mExtGState = ((ExtGState) this.Dict.Doc.Resources[this.Dict["ExtGState"], typeof(ExtGState)]);
                    }
                }
                return this.mExtGState;
            }
            set
            {
                this.mExtGState = value;
                this.Dict["ExtGState"] = value.Direct;
            }
        }

        public Shading Shading
        {
            get
            {
                if (this.mShading == null)
                {
                    if (this.Dict["Shading"] == null)
                    {
                        return null;
                    }
                    if (this.Dict.Doc == null)
                    {
                        this.mShading = ((Shading) Shading.Factory(this.Dict["Shading"].Direct));
                    }
                    else
                    {
                        this.mShading = ((Shading) this.Dict.Doc.Resources[this.Dict["Shading"], typeof(Shading)]);
                    }
                }
                return this.mShading;
            }
            set
            {
                this.mShading = value;
                this.Dict["Shading"] = value.Direct;
            }
        }


        // Fields
        private PDFCTM mCTM;
        private ExtGState mExtGState;
        private Shading mShading;
    }
}


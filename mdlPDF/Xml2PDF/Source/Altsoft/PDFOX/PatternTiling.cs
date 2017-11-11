namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.IO;

    public class PatternTiling : Pattern
    {
        // Methods
        public PatternTiling(PDFDirect d) : base(d)
        {
            this.mBBox = null;
            this.mCTM = null;
            this.mResources = null;
        }

        private Stream GetContents()
        {
            return ((PDFStream) this.mDirect).Decode();
        }

        private void SetContents(Stream val)
        {
            ((PDFStream) this.mDirect).Encode(val);
        }


        // Properties
        public Rect BBox
        {
            get
            {
                double[] numArray1;
                if (this.mBBox == null)
                {
                    numArray1 = new double[4];
                    this.mBBox = new PDFRect(this.Dict, "BBox", numArray1);
                }
                return this.mBBox;
            }
            set
            {
                this.BBox.Set(value);
            }
        }

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

        public PatternPaintType PaintType
        {
            get
            {
                return ((PatternPaintType) ((int) ((PDFInteger) this.Dict["PaintType"]).Value));
            }
            set
            {
                ((PDFInteger) this.Dict["PaintType"]).Value = ((long) value);
            }
        }

        public override DocResourceSet Resources
        {
            get
            {
                if (this.mResources == null)
                {
                    this.mResources = new DocResourceSet(((PDFDict) this.Dict["Resources"]), this.Dict, null);
                }
                return this.mResources;
            }
        }

        public PatternTilingType TilingType
        {
            get
            {
                return ((PatternTilingType) ((int) ((PDFInteger) this.Dict["TilingType"]).Value));
            }
            set
            {
                ((PDFInteger) this.Dict["TilingType"]).Value = ((long) value);
            }
        }

        public double XStep
        {
            get
            {
                return ((PDFFixed) this.Dict["XStep"]).Value;
            }
            set
            {
                ((PDFFixed) this.Dict["XStep"]).Value = value;
            }
        }

        public double YStep
        {
            get
            {
                return ((PDFFixed) this.Dict["YStep"]).Value;
            }
            set
            {
                ((PDFFixed) this.Dict["YStep"]).Value = value;
            }
        }


        // Fields
        private PDFRect mBBox;
        private PDFCTM mCTM;
        private DocResourceSet mResources;
    }
}


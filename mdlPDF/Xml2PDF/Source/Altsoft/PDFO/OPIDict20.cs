namespace Altsoft.PDFO
{
    using System;

    public class OPIDict20 : OPIDict
    {
        // Methods
        public OPIDict20(PDFDict dict) : base(dict)
        {
            this.mInks = null;
            this.mDim = null;
        }


        // Properties
        public ColorantList ColorantList
        {
            get
            {
                if (this.mInks != null)
                {
                    return this.mInks;
                }
                PDFArray array1 = (this.Dict["Inks"] as PDFArray);
                if (array1 != null)
                {
                    this.mInks = new ColorantList(array1);
                }
                return this.mInks;
            }
            set
            {
                this.Dict["Inks"] = this.mInks.Direct;
            }
        }

        public string ColorantName
        {
            get
            {
                PDFString text1 = (this.Dict["Inks"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["Inks"] = Library.CreateName(value);
            }
        }

        public double ImageHeight
        {
            get
            {
                if (this.mDim == null)
                {
                    this.mDim = (this.Dict["IncludedImageDimensions"] as PDFArray);
                }
                if (this.mDim == null)
                {
                    return NaNf;
                }
                return (this.mDim[1] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mDim == null)
                {
                    this.mDim = Library.CreateArray(2);
                }
                this.mDim[1] = Library.CreateFixed(value);
                this.Dict["IncludedImageDimensions"] = this.mDim;
            }
        }

        public int ImageQuality
        {
            get
            {
                PDFNumeric numeric1 = (this.Dict["IncludedImageQuality"] as PDFNumeric);
                if (numeric1 == null)
                {
                    return -2147483648;
                }
                return numeric1.Int32Value;
            }
            set
            {
                this.Dict["IncludedImageQuality"] = Library.CreateInteger(((long) value));
            }
        }

        public double ImageWidth
        {
            get
            {
                if (this.mDim == null)
                {
                    this.mDim = (this.Dict["IncludedImageDimensions"] as PDFArray);
                }
                if (this.mDim == null)
                {
                    return NaNf;
                }
                return (this.mDim[0] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mDim == null)
                {
                    this.mDim = Library.CreateArray(2);
                }
                this.mDim[0] = Library.CreateFixed(value);
                this.Dict["IncludedImageDimensions"] = this.mDim;
            }
        }

        public string MainImage
        {
            get
            {
                PDFString text1 = (this.Dict["MainImage"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["MainImage"] = Library.CreateString(value);
            }
        }


        // Fields
        private PDFArray mDim;
        private ColorantList mInks;
    }
}


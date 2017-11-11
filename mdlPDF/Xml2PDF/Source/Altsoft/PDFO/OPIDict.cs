namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class OPIDict : Resource
    {
        // Methods
        public OPIDict(PDFDirect direct) : base(direct)
        {
            this.mSize = null;
        }


        // Properties
        public Rect CropRect
        {
            get
            {
                PDFArray array1;
                double[] numArray1;
                if (this.mCropRect == null)
                {
                    array1 = (this.Dict["CropRect"] as PDFArray);
                    numArray1 = new double[4];
                    if (array1 != null)
                    {
                        Library.CopyArray(array1, 0, 4, numArray1, 0);
                    }
                    this.mCropRect = new PDFRect(this.Dict, "CropRect", numArray1);
                }
                return this.mCropRect;
            }
            set
            {
                this.CropRect.Set(value);
            }
        }

        public FileSpec FileExt
        {
            get
            {
                return (Resources.Get((this.Dict["F"] as PDFDirect), typeof(FileSpec)) as FileSpec);
            }
            set
            {
                this.Dict["F"] = value.Direct;
            }
        }

        public bool OverPrint
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["Overprint"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["Overprint"] = Library.CreateBoolean(value);
            }
        }

        public double PixelHeight
        {
            get
            {
                if (this.mSize == null)
                {
                    this.mSize = (this.Dict["Size"] as PDFArray);
                }
                if (this.mSize == null)
                {
                    return NaNf;
                }
                return (this.mSize[1] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mSize == null)
                {
                    this.mSize = Library.CreateArray(2);
                }
                this.mSize[1] = Library.CreateFixed(value);
                this.Dict["Size"] = this.mSize;
            }
        }

        public double PixelWidth
        {
            get
            {
                if (this.mSize == null)
                {
                    this.mSize = (this.Dict["Size"] as PDFArray);
                }
                if (this.mSize == null)
                {
                    return NaNf;
                }
                return (this.mSize[0] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mSize == null)
                {
                    this.mSize = Library.CreateArray(2);
                }
                this.mSize[0] = Library.CreateFixed(value);
                this.Dict["Size"] = this.mSize;
            }
        }

        public TagPairList TagList
        {
            get
            {
                PDFArray array1 = (this.Dict["Tags"] as PDFArray);
                if (array1 == null)
                {
                    return null;
                }
                return (Resources.Get(array1, typeof(TagPairList)) as TagPairList);
            }
            set
            {
                this.Dict["Tags"] = value.Direct;
            }
        }

        public double Version
        {
            get
            {
                return (this.Dict["Version"] as PDFFixed).DoubleValue;
            }
            set
            {
                this.Dict["Version"] = Library.CreateFixed(value);
            }
        }


        // Fields
        private PDFRect mCropRect;
        private PDFArray mSize;
        public const string Type = "OPI";
    }
}


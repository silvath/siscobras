namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class OPIDict13 : OPIDict
    {
        // Methods
        public OPIDict13(PDFDict dict) : base(dict)
        {
            this.mRes = null;
            this.mGrayMap = null;
        }


        // Properties
        public double BitsPerSample
        {
            get
            {
                if (this.mImageType != null)
                {
                    return (this.mImageType[1] as PDFFixed).DoubleValue;
                }
                this.mImageType = (this.Dict["ImageType"] as PDFArray);
                if (this.mImageType == null)
                {
                    return NaNf;
                }
                return (this.mImageType[1] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mImageType == null)
                {
                    this.mImageType = Library.CreateArray(2);
                }
                this.mImageType[1] = Library.CreateFixed(value);
                this.Dict["ImageType"] = this.mImageType;
            }
        }

        public double ColorBlack
        {
            get
            {
                if (this.mColor != null)
                {
                    return (this.mColor[3] as PDFFixed).DoubleValue;
                }
                this.mColor = (this.Dict["Color"] as PDFArray);
                if (this.mColor == null)
                {
                    return 1f;
                }
                return (this.mColor[3] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mColor == null)
                {
                    this.mColor = Library.CreateArray(5);
                }
                this.mColor[3] = Library.CreateFixed(value);
                this.Dict["Color"] = this.mColor;
            }
        }

        public double ColorCyan
        {
            get
            {
                if (this.mColor != null)
                {
                    return (this.mColor[0] as PDFFixed).DoubleValue;
                }
                this.mColor = (this.Dict["Color"] as PDFArray);
                if (this.mColor == null)
                {
                    return 0f;
                }
                return (this.mColor[0] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mColor == null)
                {
                    this.mColor = Library.CreateArray(5);
                }
                this.mColor[0] = Library.CreateFixed(value);
                this.Dict["Color"] = this.mColor;
            }
        }

        public double ColorMagenta
        {
            get
            {
                if (this.mColor != null)
                {
                    return (this.mColor[1] as PDFFixed).DoubleValue;
                }
                this.mColor = (this.Dict["Color"] as PDFArray);
                if (this.mColor == null)
                {
                    return 0f;
                }
                return (this.mColor[1] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mColor == null)
                {
                    this.mColor = Library.CreateArray(5);
                }
                this.mColor[1] = Library.CreateFixed(value);
                this.Dict["Color"] = this.mColor;
            }
        }

        public string ColorName
        {
            get
            {
                if (this.mColor != null)
                {
                    return (this.mColor[4] as PDFName).Value;
                }
                this.mColor = (this.Dict["Color"] as PDFArray);
                if (this.mColor == null)
                {
                    return "Black";
                }
                return (this.mColor[4] as PDFName).Value;
            }
            set
            {
                if (this.mColor == null)
                {
                    this.mColor = Library.CreateArray(5);
                }
                this.mColor[4] = Library.CreateName(value);
                this.Dict["Color"] = this.mColor;
            }
        }

        public EColorType ColorType
        {
            get
            {
                PDFString text1 = (this.Dict["ColorType"] as PDFString);
                if (text1 == null)
                {
                    return EColorType.Spot;
                }
                string text2 = text1.Value;
                if (text2 == null)
                {
                    goto Label_005D;
                }
                text2 = string.IsInterned(text2);
                if (text2 != "Process")
                {
                    if (text2 == "Separation")
                    {
                        goto Label_0059;
                    }
                    if (text2 == "Spot")
                    {
                        goto Label_005B;
                    }
                    goto Label_005D;
                }
                return EColorType.Process;
            Label_0059:
                return EColorType.Separation;
            Label_005B:
                return EColorType.Spot;
            Label_005D:
                throw new Exception("Unknown color type");
            }
            set
            {
                string text1 = "";
                EColorType type1 = value;
                switch (type1)
                {
                    case EColorType.Process:
                    {
                        text1 = "Process";
                        goto Label_0032;
                    }
                    case EColorType.Spot:
                    {
                        goto Label_002C;
                    }
                    case EColorType.Separation:
                    {
                        text1 = "Separation";
                        goto Label_0032;
                    }
                }
                goto Label_0032;
            Label_002C:
                text1 = "Spot";
            Label_0032:
                this.Dict["ColorType"] = Library.CreateString(text1);
            }
        }

        public double ColorYellow
        {
            get
            {
                if (this.mColor != null)
                {
                    return (this.mColor[2] as PDFFixed).DoubleValue;
                }
                this.mColor = (this.Dict["Color"] as PDFArray);
                if (this.mColor == null)
                {
                    return 0f;
                }
                return (this.mColor[2] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mColor == null)
                {
                    this.mColor = Library.CreateArray(5);
                }
                this.mColor[2] = Library.CreateFixed(value);
                this.Dict["Color"] = this.mColor;
            }
        }

        public string Comments
        {
            get
            {
                PDFString text1 = (this.Dict["Comments"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["Comments"] = Library.CreateString(value);
            }
        }

        public Rect CropFixed
        {
            get
            {
                PDFArray array1;
                double[] numArray1;
                double[] numArray2;
                if (this.mCropFixed == null)
                {
                    array1 = (this.Dict["CropFixed"] as PDFArray);
                    numArray2 = new double[4];
                    numArray2[0] = base.CropRect.Left;
                    numArray2[1] = base.CropRect.Top;
                    numArray2[2] = base.CropRect.Right;
                    numArray2[3] = base.CropRect.Bottom;
                    numArray1 = numArray2;
                    if (array1 != null)
                    {
                        Library.CopyArray(array1, 0, 4, numArray1, 0);
                        this.mCropFixed = new PDFRect(this.Dict, "CropFixed", numArray1);
                    }
                }
                return this.mCropFixed;
            }
            set
            {
                base.CropRect.Set(value);
            }
        }

        public IntList GrayMap
        {
            get
            {
                if (this.mGrayMap != null)
                {
                    return this.mGrayMap;
                }
                PDFArray array1 = (this.Dict["GrayMap"] as PDFArray);
                if (array1 != null)
                {
                    this.mGrayMap = new IntList(array1, false);
                }
                return this.mGrayMap;
            }
            set
            {
                this.mGrayMap = value;
                this.Dict["GrayMap"] = value.mDirect;
            }
        }

        public string Id
        {
            get
            {
                PDFString text1 = (this.Dict["ID"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["ID"] = Library.CreateString(value);
            }
        }

        public quadrilateral Position
        {
            get
            {
                return (Resources.Get((this.Dict["Position"] as PDFDirect), typeof(quadrilateral)) as quadrilateral);
            }
            set
            {
                this.Dict["Position"] = value.Direct;
            }
        }

        public double ResHor
        {
            get
            {
                if (this.mRes != null)
                {
                    return (this.mRes[0] as PDFFixed).DoubleValue;
                }
                this.mRes = (this.Dict["Resolution"] as PDFArray);
                if (this.mRes == null)
                {
                    return NaNf;
                }
                return (this.mRes[0] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mRes == null)
                {
                    this.mRes = Library.CreateArray(2);
                }
                this.mRes[0] = Library.CreateFixed(value);
                this.Dict["Resolution"] = this.mRes;
            }
        }

        public double ResVert
        {
            get
            {
                if (this.mRes != null)
                {
                    return (this.mRes[1] as PDFFixed).DoubleValue;
                }
                this.mRes = (this.Dict["Resolution"] as PDFArray);
                if (this.mRes == null)
                {
                    return NaNf;
                }
                return (this.mRes[1] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mRes == null)
                {
                    this.mRes = Library.CreateArray(2);
                }
                this.mRes[1] = Library.CreateFixed(value);
                this.Dict["Resolution"] = this.mRes;
            }
        }

        public double SamplesPerPixel
        {
            get
            {
                if (this.mImageType != null)
                {
                    return (this.mImageType[0] as PDFFixed).DoubleValue;
                }
                this.mImageType = (this.Dict["ImageType"] as PDFArray);
                if (this.mImageType == null)
                {
                    return NaNf;
                }
                return (this.mImageType[0] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mImageType == null)
                {
                    this.mImageType = Library.CreateArray(2);
                }
                this.mImageType[0] = Library.CreateFixed(value);
                this.Dict["ImageType"] = this.mImageType;
            }
        }

        public double Tint
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["Tint"] as PDFFixed);
                if (fixed1 == null)
                {
                    return 1f;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["Tint"] = Library.CreateFixed(value);
            }
        }

        public bool Transparency
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["Transparency"] as PDFBoolean);
                if (flag1 == null)
                {
                    return true;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["Transparency"] = Library.CreateBoolean(value);
            }
        }


        // Fields
        private PDFArray mColor;
        private PDFRect mCropFixed;
        private IntList mGrayMap;
        private PDFArray mImageType;
        private PDFArray mRes;
    }
}


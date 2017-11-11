namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public abstract class Shading : Resource
    {
        // Methods
        static Shading()
        {
            Shading.DictKeyName = "Shading";
        }

        public Shading(PDFDirect d) : base(d)
        {
            this.mColorSpace = null;
            this.mBackground = null;
            this.mBBox = null;
            this.mFunction = null;
        }

        internal static Resource Factory(PDFDirect d)
        {
            int num1;
            Resource resource1;
            int num2;
            try
            {
                num1 = ((PDFInteger) ((d.PDFType == PDFObjectType.tPDFDict) ? ((PDFDict) d) : ((PDFStream) d).Dict)["ShadingType"]).Int32Value;
                num2 = num1;
                switch (num2)
                {
                    case 1:
                    {
                        return new ShadingType1(d);
                    }
                    case 2:
                    {
                        return new ShadingType2(d);
                    }
                    case 3:
                    {
                        return new ShadingType3(d);
                    }
                    case 4:
                    {
                        return new ShadingType4(d);
                    }
                    case 5:
                    {
                        return new ShadingType5(d);
                    }
                    case 6:
                    {
                        return new ShadingType6(d);
                    }
                    case 7:
                    {
                        return new ShadingType7(d);
                    }
                }
                throw new PDFSyntaxException(d, "Invalid shading");
            }
            catch (InvalidCastException)
            {
                throw new PDFSyntaxException(d, "Invalid shading");
            }
            return resource1;
        }


        // Properties
        public DoubleArray Background
        {
            get
            {
                double[] numArray1;
                if ((this.mBackground == null) && (this.Dict["Background"] != null))
                {
                    numArray1 = new double[1];
                    this.mBackground = new PDFDoubleArray(this.Dict, "Background", false, numArray1);
                }
                return this.mBackground;
            }
            set
            {
                double[] numArray1;
                if (this.Background == null)
                {
                    numArray1 = new double[value.Count];
                    this.mBackground = new PDFDoubleArray(this.Dict, "Background", false, numArray1);
                }
                this.Background.Set(value);
            }
        }

        public Rect BBox
        {
            get
            {
                double[] numArray1;
                if (this.mBBox == null)
                {
                    ((PDFArray) this.Dict["BBox"]);
                    if (this.Dict["BBox"] != null)
                    {
                        numArray1 = new double[1];
                        this.mBBox = new PDFRect(this.Dict, "BBox", numArray1);
                    }
                }
                return this.mBBox;
            }
            set
            {
                double[] numArray1;
                if (this.BBox == null)
                {
                    numArray1 = new double[4];
                    numArray1[0] = value.x1;
                    numArray1[1] = value.y1;
                    numArray1[2] = value.x2;
                    numArray1[3] = value.y2;
                    this.mBBox = new PDFRect(this.Dict, "BBox", numArray1);
                }
                this.BBox.Set(value);
            }
        }

        public ColorSpace ColorSpace
        {
            get
            {
                if (this.mColorSpace == null)
                {
                    if (this.mDirect.Doc != null)
                    {
                        this.mColorSpace = ((ColorSpace) this.mDirect.Doc.Resources[this.Dict["ColorSpace"], typeof(ColorSpace)]);
                    }
                    else
                    {
                        this.mColorSpace = ((ColorSpace) ColorSpace.Factory(this.Dict["ColorSpace"].Direct));
                    }
                }
                return this.mColorSpace;
            }
            set
            {
                if (value.Direct.Doc != this.mDirect.Doc)
                {
                    throw new PDFException("Can\'t connect objects from different documents");
                }
                this.mColorSpace = value;
                this.Dict["ColorSpace"] = (value.Direct.IsIndirect ? value.Direct.Indirect : value.Direct);
            }
        }

        public virtual Function Function
        {
            get
            {
                PDFDirect direct1;
                if (this.mFunction == null)
                {
                    direct1 = this.Dict["Function"].Direct;
                    if (direct1 == null)
                    {
                        return null;
                    }
                    if (direct1.PDFType == PDFObjectType.tPDFArray)
                    {
                        this.mFunction = new FunctionArray(((PDFArray) direct1));
                    }
                    else if (direct1.Doc != null)
                    {
                        this.mFunction = ((Function) direct1.Doc.Resources[direct1, typeof(Function)]);
                    }
                    else
                    {
                        this.mFunction = ((Function) Function.Factory(direct1));
                    }
                }
                return this.mFunction;
            }
            set
            {
                this.mFunction = value;
                this.Dict["Function"] = value.Direct;
            }
        }

        public int ShadingType
        {
            get
            {
                PDFInteger integer1 = (this.Dict["ShadingType"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return integer1.Int32Value;
            }
        }

        public bool YStep
        {
            get
            {
                PDFBoolean flag1 = ((PDFBoolean) this.Dict["AntiAlias"]);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["AntiAlias"] = Library.CreateBoolean(value);
            }
        }


        // Fields
        internal static readonly string DictKeyName;
        private PDFDoubleArray mBackground;
        private PDFRect mBBox;
        private ColorSpace mColorSpace;
        private Function mFunction;
    }
}


namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class ExtGState : Resource
    {
        // Methods
        static ExtGState()
        {
            string[] textArray1 = new string[4];
            textArray1[0] = "AbsoluteColorimetric";
            textArray1[1] = "RelativeColorimetric";
            textArray1[2] = "Saturation";
            textArray1[3] = "Perceptual";
            ExtGState.RIs = textArray1;
            ExtGState.DictKeyName = "ExtGState";
        }

        internal ExtGState(PDFDirect d) : base(d)
        {
            this.mDashPattern = null;
            this.mFont = null;
            this.mBG = null;
            this.mBG2 = null;
            this.mUCR = null;
            this.mUCR2 = null;
            this.mBlendMode = null;
            try
            {
                this.mDict = ((PDFDict) d);
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("Constructor parameter should be a DICTIONARY");
            }
        }

        public static ExtGState Create()
        {
            PDFDict dict1 = Library.CreateDict();
            return (Resources.Get(dict1, typeof(ExtGState)) as ExtGState);
        }

        internal static Resource Factory(PDFDirect d)
        {
            return new ExtGState(d);
        }

        internal static ExtGState New()
        {
            ExtGState state1 = new ExtGState(Library.CreateDict());
            ((PDFDict) state1.Direct);
            return state1;
        }


        // Properties
        public bool AlphaIsShape
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["AIS"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["AIS"] = Library.CreateBoolean(value);
            }
        }

        public Function BG
        {
            get
            {
                if (this.mBG == null)
                {
                    if (this.Dict["BG"] == null)
                    {
                        return null;
                    }
                    this.mBG = (Resources.Get(this.Dict["BG"], typeof(Function)) as Function);
                }
                return this.mBG;
            }
            set
            {
                this.mBG = value;
                this.Dict["BG"] = value.Direct;
            }
        }

        public Function BG2
        {
            get
            {
                if (this.mBG2 == null)
                {
                    if (!(this.Dict["BG2"] is PDFDict))
                    {
                        return null;
                    }
                    this.mBG2 = (Resources.Get(this.Dict["BG2"], typeof(Function)) as Function);
                }
                return this.mBG2;
            }
            set
            {
                this.mBG2 = value;
                this.Dict["BG2"] = value.Direct;
            }
        }

        public NameList BlendMode
        {
            get
            {
                if (this.mBlendMode != null)
                {
                    return this.mBlendMode;
                }
                PDFDirect direct1 = (this.Dict["BM"] as PDFDirect);
                if (direct1 != null)
                {
                    this.mBlendMode = new NameList(this.Dict, "BM", true);
                }
                return this.mBlendMode;
            }
            set
            {
                this.mBlendMode = value;
                this.Dict["BM"] = this.mBlendMode.mBaseDict[this.mBlendMode.mBaseKeyName];
            }
        }

        public LineDashPattern DashPattern
        {
            get
            {
                PDFArray array1;
                if (this.mDashPattern == null)
                {
                    array1 = (this.Dict["D"] as PDFArray);
                    if (array1 != null)
                    {
                        this.mDashPattern = new LineDashPattern(array1);
                    }
                }
                return this.mDashPattern;
            }
            set
            {
                PDFArray array1;
                if (this.DashPattern == null)
                {
                    array1 = Library.CreateArray(2);
                    this.Dict["D"] = array1;
                    array1[0] = Library.CreateArray(value.Count);
                }
                this.DashPattern.Set(value);
            }
        }

        public double FlatnessTolerance
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["FL"] as PDFFixed);
                if (fixed1 == null)
                {
                    return NaNf;
                }
                if (fixed1.DoubleValue < 0f)
                {
                    throw new Exception("Illegal Flatness Tolerance value");
                }
                return fixed1.DoubleValue;
            }
            set
            {
                if (value < 0f)
                {
                    throw new Exception("Illegal Flatness Tolerance value");
                }
                this.Dict["FL"] = Library.CreateFixed(value);
            }
        }

        public Font Font
        {
            get
            {
                PDFArray array1;
                if (this.mFont == null)
                {
                    array1 = (this.Dict["Font"] as PDFArray);
                    if (array1 == null)
                    {
                        return null;
                    }
                    if (array1.Count < 2)
                    {
                        return null;
                    }
                    this.mFont = (Resources.Get(array1[0], typeof(Font)) as Font);
                }
                return this.mFont;
            }
            set
            {
                PDFIndirect indirect1 = value.Direct.Indirect;
                if (indirect1 == null)
                {
                    indirect1 = this.Dict.Doc.Indirects.New(value.Direct);
                }
                this.mFont = value;
                PDFArray array1 = (this.Dict["Font"] as PDFArray);
                if (array1 == null)
                {
                    array1 = Library.CreateArray(2);
                    this.Dict["Font"] = array1;
                }
                array1[0] = indirect1;
            }
        }

        public double FontSize
        {
            get
            {
                PDFArray array1 = (this.Dict["Font"] as PDFArray);
                if (array1 == null)
                {
                    return 0f;
                }
                if (array1.Count < 2)
                {
                    return 0f;
                }
                PDFNumeric numeric1 = (array1[1] as PDFNumeric);
                if (numeric1 == null)
                {
                    return 0f;
                }
                return numeric1.DoubleValue;
            }
            set
            {
                PDFArray array1 = (this.Dict["Font"] as PDFArray);
                if (array1 == null)
                {
                    array1 = Library.CreateArray(2);
                    this.Dict["Font"] = array1;
                }
                array1[1] = Library.CreateFixed(value);
            }
        }

        public Halftone Halftone
        {
            get
            {
                PDFDirect direct1 = (this.Dict["Halftone"] as PDFDirect);
                if ((direct1 == null) || (direct1 is PDFName))
                {
                    return null;
                }
                return (Resources.Get(direct1, typeof(Halftone)) as Halftone);
            }
            set
            {
                this.Dict["Halftone"] = value.Dict;
            }
        }

        public bool IsBG2Default
        {
            get
            {
                PDFName name1 = (this.Dict["BG2"] as PDFName);
                if (name1 == null)
                {
                    return false;
                }
                if (name1.Value == "Default")
                {
                    return true;
                }
                return false;
            }
            set
            {
                if (value)
                {
                    this.Dict["BG2"] = Library.CreateName("Default");
                    return;
                }
                if (this.IsBG2Default)
                {
                    this.Dict.Remove("BG2");
                }
            }
        }

        public string IsHalftoneDefault
        {
            get
            {
                PDFName name1 = (this.Dict["Halftone"] as PDFName);
                if (name1 == null)
                {
                    return null;
                }
                return name1.Value;
            }
            set
            {
                this.Dict["Halftone"] = Library.CreateName(value);
            }
        }

        public bool IsUCR2Default
        {
            get
            {
                PDFName name1 = (this.Dict["UCR2"] as PDFName);
                if (name1 == null)
                {
                    return false;
                }
                if (name1.Value == "Default")
                {
                    return true;
                }
                return false;
            }
            set
            {
                if (value)
                {
                    this.Dict["UCR2"] = Library.CreateName("Default");
                    return;
                }
                if (this.IsUCR2Default)
                {
                    this.Dict.Remove("UCR2");
                }
            }
        }

        public LineCapType LC
        {
            get
            {
                PDFInteger integer1 = (this.Dict["LC"] as PDFInteger);
                if (integer1 == null)
                {
                    return LineCapType.SquareButtCap;
                }
                return ((LineCapType) integer1.Int32Value);
            }
            set
            {
                this.Dict["LC"] = Library.CreateInteger(((long) value));
            }
        }

        public LineJoinType LJ
        {
            get
            {
                PDFInteger integer1 = (this.Dict["LJ"] as PDFInteger);
                if (integer1 == null)
                {
                    return LineJoinType.Miter;
                }
                return ((LineJoinType) integer1.Int32Value);
            }
            set
            {
                this.Dict["LJ"] = Library.CreateInteger(((long) value));
            }
        }

        public double LW
        {
            get
            {
                PDFNumeric numeric1 = (this.Dict["LW"] as PDFNumeric);
                if (numeric1 == null)
                {
                    return 1f;
                }
                return numeric1.DoubleValue;
            }
            set
            {
                this.Dict["LW"] = Library.CreateFixed(value);
            }
        }

        public double ML
        {
            get
            {
                PDFNumeric numeric1 = (this.Dict["ML"] as PDFNumeric);
                if (numeric1 == null)
                {
                    return 10f;
                }
                return numeric1.DoubleValue;
            }
            set
            {
                this.Dict["ML"] = Library.CreateFixed(value);
            }
        }

        public double NonStrokingAlphaConstant
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["ca"] as PDFFixed);
                if (fixed1 == null)
                {
                    return NaNf;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["ca"] = Library.CreateFixed(value);
            }
        }

        public bool op
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["op"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["op"] = Library.CreateBoolean(value);
            }
        }

        public bool OP
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["OP"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["op"] = Library.CreateBoolean(value);
            }
        }

        public int OPM
        {
            get
            {
                PDFNumeric numeric1 = (this.Dict["OPM"] as PDFNumeric);
                if (numeric1 == null)
                {
                    return 0;
                }
                return numeric1.Int32Value;
            }
            set
            {
                this.Dict["OPM"] = Library.CreateInteger(((long) value));
            }
        }

        public RenderIntent RI
        {
            get
            {
                int num1;
                PDFName name1 = (this.Dict["RI"] as PDFName);
                if (name1 == null)
                {
                    return RenderIntent.Unknown;
                }
                string text1 = name1.Value;
                for (num1 = 0; (num1 < ExtGState.RIs.Length); num1 += 1)
                {
                    if (text1 == ExtGState.RIs[num1])
                    {
                        return ((RenderIntent) num1);
                    }
                }
                return RenderIntent.Unknown;
            }
            set
            {
                this.Dict["RI"] = Library.CreateName(ExtGState.RIs[value]);
            }
        }

        public XObjectImage SMask
        {
            get
            {
                PDFDict dict1 = (this.Dict["SMASK"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(XObjectImage)) as XObjectImage);
            }
            set
            {
                this.Dict["SMASK"] = value.Direct;
            }
        }

        public double SmoothnessTolerance
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["SM"] as PDFFixed);
                if (fixed1 == null)
                {
                    return NaNf;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["SM"] = Library.CreateFixed(value);
            }
        }

        public bool StrokeAdjustment
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["SA"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["SA"] = Library.CreateBoolean(value);
            }
        }

        public double StrokingAlphaConstant
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["CA"] as PDFFixed);
                if (fixed1 == null)
                {
                    return NaNf;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["CA"] = Library.CreateFixed(value);
            }
        }

        public bool TextKnockout
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["TK"] as PDFBoolean);
                if (flag1 == null)
                {
                    return true;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["TK"] = Library.CreateBoolean(value);
            }
        }

        public Function TR2Black
        {
            get
            {
                return this.TR2Gray;
            }
            set
            {
                this.TR2Gray = value;
            }
        }

        public Function TR2Blue
        {
            get
            {
                PDFDirect direct1 = (this.Dict["TR2"] as PDFDirect);
                if ((direct1 == null) || (direct1 is PDFName))
                {
                    return null;
                }
                if ((direct1 is PDFArray))
                {
                    return (Resources.Get((direct1 as PDFArray)[2], typeof(Function)) as Function);
                }
                return (Resources.Get(direct1, typeof(Function)) as Function);
            }
            set
            {
                PDFArray array1 = (this.Dict["TR2"] as PDFArray);
                if (array1 == null)
                {
                    array1 = Library.CreateArray(4);
                    this.Dict["TR2"] = array1;
                }
                if (value == null)
                {
                    array1[2] = Library.CreateName("Default");
                    return;
                }
                array1[2] = value.Dict;
            }
        }

        public Function TR2Common
        {
            set
            {
                if (value == null)
                {
                    this.Dict["TR2"] = Library.CreateName("Default");
                    return;
                }
                this.Dict["TR2"] = value.Dict;
            }
        }

        public Function TR2Cyan
        {
            get
            {
                return this.TR2Red;
            }
            set
            {
                this.TR2Red = value;
            }
        }

        public bool TR2Exists
        {
            get
            {
                if ((this.Dict["TR2"] is PDFDirect))
                {
                    return true;
                }
                return false;
            }
        }

        public Function TR2Gray
        {
            get
            {
                PDFDirect direct1 = (this.Dict["TR2"] as PDFDirect);
                if ((direct1 == null) || (direct1 is PDFName))
                {
                    return null;
                }
                if ((direct1 is PDFArray))
                {
                    return (Resources.Get((direct1 as PDFArray)[3], typeof(Function)) as Function);
                }
                return (Resources.Get(direct1, typeof(Function)) as Function);
            }
            set
            {
                PDFArray array1 = (this.Dict["TR2"] as PDFArray);
                if (array1 == null)
                {
                    array1 = Library.CreateArray(4);
                    this.Dict["TR2"] = array1;
                }
                if (value == null)
                {
                    array1[3] = Library.CreateName("Default");
                    return;
                }
                array1[3] = value.Dict;
            }
        }

        public Function TR2Green
        {
            get
            {
                PDFDirect direct1 = (this.Dict["TR2"] as PDFDirect);
                if ((direct1 == null) || (direct1 is PDFName))
                {
                    return null;
                }
                if ((direct1 is PDFArray))
                {
                    return (Resources.Get((direct1 as PDFArray)[1], typeof(Function)) as Function);
                }
                return (Resources.Get(direct1, typeof(Function)) as Function);
            }
            set
            {
                PDFArray array1 = (this.Dict["TR2"] as PDFArray);
                if (array1 == null)
                {
                    array1 = Library.CreateArray(4);
                    this.Dict["TR2"] = array1;
                }
                if (value == null)
                {
                    array1[1] = Library.CreateName("Default");
                    return;
                }
                array1[1] = value.Dict;
            }
        }

        public Function TR2Magenta
        {
            get
            {
                return this.TR2Green;
            }
            set
            {
                this.TR2Green = value;
            }
        }

        public Function TR2Red
        {
            get
            {
                PDFDirect direct1 = (this.Dict["TR2"] as PDFDirect);
                if ((direct1 == null) || (direct1 is PDFName))
                {
                    return null;
                }
                if ((direct1 is PDFArray))
                {
                    return (Resources.Get((direct1 as PDFArray)[0], typeof(Function)) as Function);
                }
                return (Resources.Get(direct1, typeof(Function)) as Function);
            }
            set
            {
                PDFArray array1 = (this.Dict["TR2"] as PDFArray);
                if (array1 == null)
                {
                    array1 = Library.CreateArray(4);
                    this.Dict["TR2"] = array1;
                }
                if (value == null)
                {
                    array1[0] = Library.CreateName("Default");
                    return;
                }
                array1[0] = value.Dict;
            }
        }

        public Function TR2Yellow
        {
            get
            {
                return this.TR2Blue;
            }
            set
            {
                this.TR2Blue = value;
            }
        }

        public Function TRBlack
        {
            get
            {
                return this.TRGray;
            }
            set
            {
                this.TRGray = value;
            }
        }

        public Function TRBlue
        {
            get
            {
                PDFDirect direct1 = (this.Dict["TR"] as PDFDirect);
                if ((direct1 == null) || (direct1 is PDFName))
                {
                    return null;
                }
                if ((direct1 is PDFArray))
                {
                    return (Resources.Get((direct1 as PDFArray)[2], typeof(Function)) as Function);
                }
                return (Resources.Get(direct1, typeof(Function)) as Function);
            }
            set
            {
                PDFArray array1 = (this.Dict["TR"] as PDFArray);
                if (array1 == null)
                {
                    array1 = Library.CreateArray(4);
                    this.Dict["TR"] = array1;
                }
                if (value == null)
                {
                    array1[2] = Library.CreateName("Identity");
                    return;
                }
                array1[2] = value.Dict;
            }
        }

        public Function TRCommon
        {
            set
            {
                if (value == null)
                {
                    this.Dict["TR"] = Library.CreateName("Identity");
                    return;
                }
                this.Dict["TR"] = value.Dict;
            }
        }

        public Function TRCyan
        {
            get
            {
                return this.TRRed;
            }
            set
            {
                this.TRRed = value;
            }
        }

        public bool TRExists
        {
            get
            {
                if ((this.Dict["TR"] is PDFDirect))
                {
                    return true;
                }
                return false;
            }
        }

        public Function TRGray
        {
            get
            {
                PDFDirect direct1 = (this.Dict["TR"] as PDFDirect);
                if ((direct1 == null) || (direct1 is PDFName))
                {
                    return null;
                }
                if ((direct1 is PDFArray))
                {
                    return (Resources.Get((direct1 as PDFArray)[3], typeof(Function)) as Function);
                }
                return (Resources.Get(direct1, typeof(Function)) as Function);
            }
            set
            {
                PDFArray array1 = (this.Dict["TR"] as PDFArray);
                if (array1 == null)
                {
                    array1 = Library.CreateArray(4);
                    this.Dict["TR"] = array1;
                }
                if (value == null)
                {
                    array1[3] = Library.CreateName("Identity");
                    return;
                }
                array1[3] = value.Dict;
            }
        }

        public Function TRGreen
        {
            get
            {
                PDFDirect direct1 = (this.Dict["TR"] as PDFDirect);
                if ((direct1 == null) || (direct1 is PDFName))
                {
                    return null;
                }
                if ((direct1 is PDFArray))
                {
                    return (Resources.Get((direct1 as PDFArray)[1], typeof(Function)) as Function);
                }
                return (Resources.Get(direct1, typeof(Function)) as Function);
            }
            set
            {
                PDFArray array1 = (this.Dict["TR"] as PDFArray);
                if (array1 == null)
                {
                    array1 = Library.CreateArray(4);
                    this.Dict["TR"] = array1;
                }
                if (value == null)
                {
                    array1[1] = Library.CreateName("Identity");
                    return;
                }
                array1[1] = value.Dict;
            }
        }

        public Function TRMagenta
        {
            get
            {
                return this.TRGreen;
            }
            set
            {
                this.TRGreen = value;
            }
        }

        public Function TRRed
        {
            get
            {
                PDFDirect direct1 = (this.Dict["TR"] as PDFDirect);
                if ((direct1 == null) || (direct1 is PDFName))
                {
                    return null;
                }
                if ((direct1 is PDFArray))
                {
                    return (Resources.Get((direct1 as PDFArray)[0], typeof(Function)) as Function);
                }
                return (Resources.Get(direct1, typeof(Function)) as Function);
            }
            set
            {
                PDFArray array1 = (this.Dict["TR"] as PDFArray);
                if (array1 == null)
                {
                    array1 = Library.CreateArray(4);
                    this.Dict["TR"] = array1;
                }
                if (value == null)
                {
                    array1[0] = Library.CreateName("Identity");
                    return;
                }
                array1[0] = value.Dict;
            }
        }

        public Function TRYellow
        {
            get
            {
                return this.TRBlue;
            }
            set
            {
                this.TRBlue = value;
            }
        }

        public Function UCR
        {
            get
            {
                if (this.mUCR == null)
                {
                    if (this.Dict["UCR"] == null)
                    {
                        return null;
                    }
                    this.mUCR = (Resources.Get(this.Dict["UCR"], typeof(Function)) as Function);
                }
                return this.mUCR;
            }
            set
            {
                this.mUCR = value;
                this.Dict["UCR"] = value.Direct;
            }
        }

        public Function UCR2
        {
            get
            {
                if (this.mUCR2 == null)
                {
                    if (!(this.Dict["UCR2"] is PDFDict))
                    {
                        return null;
                    }
                    this.mUCR2 = (Resources.Get(this.Dict["UCR2"], typeof(Function)) as Function);
                }
                return this.mUCR2;
            }
            set
            {
                this.mUCR2 = value;
                this.Dict["UCR2"] = value.Direct;
            }
        }


        // Fields
        internal static readonly string DictKeyName;
        private Function mBG;
        private Function mBG2;
        private NameList mBlendMode;
        private LineDashPattern mDashPattern;
        private PDFDict mDict;
        private Font mFont;
        private Function mUCR;
        private Function mUCR2;
        internal static string[] RIs;
    }
}


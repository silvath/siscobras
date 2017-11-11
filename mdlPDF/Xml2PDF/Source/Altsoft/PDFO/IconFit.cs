namespace Altsoft.PDFO
{
    using System;

    public class IconFit : Resource
    {
        // Methods
        public IconFit(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new IconFit(direct);
        }


        // Properties
        public double BottomFraction
        {
            get
            {
                if (this.mFraction != null)
                {
                    return (this.mFraction[1] as PDFFixed).DoubleValue;
                }
                this.mFraction = (this.Dict["A"] as PDFArray);
                return (this.mFraction[1] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mFraction == null)
                {
                    this.mFraction = Library.CreateArray(2);
                }
                this.mFraction[1] = Library.CreateFixed(value);
                this.Dict["A"] = this.mFraction;
            }
        }

        public bool FullFit
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["FB"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["FB"] = Library.CreateBoolean(value);
            }
        }

        public double LeftFraction
        {
            get
            {
                if (this.mFraction != null)
                {
                    return (this.mFraction[0] as PDFFixed).DoubleValue;
                }
                this.mFraction = (this.Dict["A"] as PDFArray);
                return (this.mFraction[0] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mFraction == null)
                {
                    this.mFraction = Library.CreateArray(2);
                }
                this.mFraction[0] = Library.CreateFixed(value);
                this.Dict["A"] = this.mFraction;
            }
        }

        public EScales Scale
        {
            get
            {
                PDFName name1 = (this.Dict["SW"] as PDFName);
                if (name1 == null)
                {
                    return EScales.Always;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_006C;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "A")
                {
                    if (text1 == "B")
                    {
                        goto Label_0066;
                    }
                    if (text1 == "S")
                    {
                        goto Label_0068;
                    }
                    if (text1 == "N")
                    {
                        goto Label_006A;
                    }
                    goto Label_006C;
                }
                return EScales.Always;
            Label_0066:
                return EScales.IconBigger;
            Label_0068:
                return EScales.IconSmaller;
            Label_006A:
                return EScales.Never;
            Label_006C:
                throw new Exception("Unknown scale");
            }
            set
            {
                string text1 = "A";
                EScales scales1 = value;
                switch (scales1)
                {
                    case EScales.Always:
                    {
                        text1 = "A";
                        goto Label_003E;
                    }
                    case EScales.IconBigger:
                    {
                        text1 = "B";
                        goto Label_003E;
                    }
                    case EScales.IconSmaller:
                    {
                        text1 = "S";
                        goto Label_003E;
                    }
                    case EScales.Never:
                    {
                        goto Label_0038;
                    }
                }
                goto Label_003E;
            Label_0038:
                text1 = "N";
            Label_003E:
                this.Dict["SW"] = Library.CreateName(text1);
            }
        }

        public EScalingTypes ScalingStyle
        {
            get
            {
                PDFName name1 = (this.Dict["S"] as PDFName);
                if (name1 == null)
                {
                    return EScalingTypes.Proportional;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_004E;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "A")
                {
                    if (text1 == "P")
                    {
                        goto Label_004C;
                    }
                    goto Label_004E;
                }
                return EScalingTypes.Anamorphic;
            Label_004C:
                return EScalingTypes.Proportional;
            Label_004E:
                throw new Exception("Unknown scaling type");
            }
            set
            {
                string text1 = "P";
                EScalingTypes types1 = value;
                switch (types1)
                {
                    case EScalingTypes.Anamorphic:
                    {
                        text1 = "A";
                        goto Label_0026;
                    }
                    case EScalingTypes.Proportional:
                    {
                        goto Label_0020;
                    }
                }
                goto Label_0026;
            Label_0020:
                text1 = "P";
            Label_0026:
                this.Dict["SW"] = Library.CreateName(text1);
            }
        }


        // Fields
        private PDFArray mFraction;
    }
}


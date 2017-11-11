namespace Altsoft.PDFO
{
    using System;

    public class BoxStyle : Resource
    {
        // Methods
        public BoxStyle(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new BoxStyle(direct);
        }


        // Properties
        public double BIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["C"] as PDFArray);
                }
                if (this.RGB == null)
                {
                    return NaNf;
                }
                return (this.RGB[2] as PDFFixed).DoubleValue;
            }
            set
            {
                if (value == NaNf)
                {
                    this.RGB = null;
                    this.Dict.Remove("C");
                    return;
                }
                this.RGB[2] = Library.CreateFixed(value);
            }
        }

        public double GIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["C"] as PDFArray);
                }
                if (this.RGB == null)
                {
                    return NaNf;
                }
                return (this.RGB[1] as PDFFixed).DoubleValue;
            }
            set
            {
                if (value == NaNf)
                {
                    this.RGB = null;
                    this.Dict.Remove("C");
                    return;
                }
                this.RGB[1] = Library.CreateFixed(value);
            }
        }

        public LineDashPattern LinePattern
        {
            get
            {
                if (this.mLinePattern != null)
                {
                    return this.mLinePattern;
                }
                PDFArray array1 = (this.Dict["D"] as PDFArray);
                if (array1 == null)
                {
                    return null;
                }
                return new LineDashPattern(array1);
            }
            set
            {
                this.mLinePattern = value;
                this.Dict["D"] = Library.CreateArray(false, value);
            }
        }

        public double RIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["C"] as PDFArray);
                }
                if (this.RGB == null)
                {
                    return NaNf;
                }
                return (this.RGB[0] as PDFFixed).DoubleValue;
            }
            set
            {
                if (value == NaNf)
                {
                    this.RGB = null;
                    this.Dict.Remove("C");
                    return;
                }
                this.RGB[0] = Library.CreateFixed(value);
            }
        }

        public GuidelineStyles Style
        {
            get
            {
                PDFName name1 = (this.Dict["S"] as PDFName);
                if (name1 == null)
                {
                    return GuidelineStyles.Solid;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_004E;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "Solid")
                {
                    if (text1 == "Dashed")
                    {
                        goto Label_004C;
                    }
                    goto Label_004E;
                }
                return GuidelineStyles.Solid;
            Label_004C:
                return GuidelineStyles.Dashed;
            Label_004E:
                throw new Exception("Unknown guidelinestyle");
            }
            set
            {
                string text1 = "Solid";
                if (value == GuidelineStyles.Dashed)
                {
                    text1 = "Dashed";
                }
                this.Dict["S"] = Library.CreateName(text1);
            }
        }

        public int Width
        {
            get
            {
                PDFNumeric numeric1 = (this.Dict["W"] as PDFNumeric);
                if (numeric1 == null)
                {
                    return 1;
                }
                return numeric1.Int32Value;
            }
            set
            {
                this.Dict["W"] = Library.CreateInteger(((long) value));
            }
        }


        // Fields
        private LineDashPattern mLinePattern;
        private PDFArray RGB;
    }
}


namespace Altsoft.PDFO
{
    using System;

    public class BorderStyles
    {
        // Methods
        public BorderStyles(Annotation annotation)
        {
            this.mDict = null;
            this.mAnnotation = annotation;
        }

        public BorderStyles(double width, EBorderStyle style, double[] dash)
        {
            this.mDict = null;
            this.mDict = Library.CreateDict();
            this.mDict["Type"] = Library.CreateName("Border");
            this.Style = style;
            this.Width = width;
            this.DashArray = dash;
        }


        // Properties
        public Annotation Annotation
        {
            get
            {
                return this.mAnnotation;
            }
            set
            {
                this.mAnnotation = value;
                this.mAnnotation.BorderStyle = this;
            }
        }

        public double[] DashArray
        {
            get
            {
                int num1;
                PDFArray array1 = (this.mDict["D"] as PDFArray);
                if (array1 == null)
                {
                    return null;
                }
                double[] numArray1 = new double[array1.Count];
                for (num1 = 0; (num1 < array1.Count); num1 += 1)
                {
                    numArray1[num1] = (array1[num1] as PDFFixed).DoubleValue;
                }
                return numArray1;
            }
            set
            {
                int num1;
                PDFArray array1 = Library.CreateArray();
                for (num1 = 0; (num1 < value.Length); num1 += 1)
                {
                    array1[num1] = Library.CreateFixed(value[num1]);
                }
                this.mDict["D"] = array1;
            }
        }

        public PDFDict Dict
        {
            get
            {
                return this.mDict;
            }
        }

        public EBorderStyle Style
        {
            get
            {
                if (this.Dict == null)
                {
                    return EBorderStyle.Solid;
                }
                PDFName name1 = (this.Dict["S"] as PDFName);
                if (name1 == null)
                {
                    return EBorderStyle.Solid;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_0085;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "S")
                {
                    if (text1 == "D")
                    {
                        goto Label_007D;
                    }
                    if (text1 == "B")
                    {
                        goto Label_007F;
                    }
                    if (text1 == "I")
                    {
                        goto Label_0081;
                    }
                    if (text1 == "U")
                    {
                        goto Label_0083;
                    }
                    goto Label_0085;
                }
                return EBorderStyle.Solid;
            Label_007D:
                return EBorderStyle.Dashed;
            Label_007F:
                return EBorderStyle.Beveled;
            Label_0081:
                return EBorderStyle.Inset;
            Label_0083:
                return EBorderStyle.Underline;
            Label_0085:
                return EBorderStyle.Solid;
            }
            set
            {
                if (this.mDict == null)
                {
                    this.mDict = Library.CreateDict();
                }
                string text1 = "S";
                EBorderStyle style1 = value;
                switch (style1)
                {
                    case EBorderStyle.Solid:
                    {
                        text1 = "S";
                        goto Label_005D;
                    }
                    case EBorderStyle.Dashed:
                    {
                        text1 = "D";
                        goto Label_005D;
                    }
                    case EBorderStyle.Beveled:
                    {
                        text1 = "B";
                        goto Label_005D;
                    }
                    case EBorderStyle.Inset:
                    {
                        text1 = "I";
                        goto Label_005D;
                    }
                    case EBorderStyle.Underline:
                    {
                        goto Label_0057;
                    }
                }
                goto Label_005D;
            Label_0057:
                text1 = "U";
            Label_005D:
                this.mDict["S"] = PDF.N(text1);
            }
        }

        public double Width
        {
            get
            {
                if (this.mDict == null)
                {
                    return 1f;
                }
                PDFNumeric numeric1 = (this.Dict["W"] as PDFNumeric);
                if (numeric1 == null)
                {
                    return 1f;
                }
                return numeric1.DoubleValue;
            }
            set
            {
                if (this.mDict == null)
                {
                    this.mDict = Library.CreateDict();
                }
                this.Dict["W"] = PDF.O(value);
            }
        }


        // Fields
        private Annotation mAnnotation;
        private PDFDict mDict;
    }
}


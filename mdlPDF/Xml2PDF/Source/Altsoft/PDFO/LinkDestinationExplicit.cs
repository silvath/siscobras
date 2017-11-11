namespace Altsoft.PDFO
{
    using System;

    public class LinkDestinationExplicit : LinkDestination
    {
        // Methods
        static LinkDestinationExplicit()
        {
            string[] textArray1 = new string[9];
            textArray1[0] = "XYZ";
            textArray1[1] = "Fit";
            textArray1[2] = "FitH";
            textArray1[3] = "FitV";
            textArray1[4] = "FitR";
            textArray1[5] = "FitB";
            textArray1[6] = "FitBH";
            textArray1[7] = "FitBV";
            textArray1[8] = "";
            LinkDestinationExplicit.PageFitTags = textArray1;
        }

        public LinkDestinationExplicit(PDFDirect direct) : base(direct)
        {
        }

        public static LinkDestinationExplicit Create(Page page)
        {
            PDFArray array1 = Library.CreateArray(2);
            array1[0] = page.Dict;
            array1[1] = Library.CreateName("Fit");
            return (Resources.Get(array1, typeof(LinkDestinationExplicit)) as LinkDestinationExplicit);
        }

        public static LinkDestinationExplicit Create(int page_number)
        {
            PDFArray array1 = Library.CreateArray(2);
            array1[0] = Library.CreateInteger(((long) page_number));
            array1[1] = Library.CreateName("Fit");
            return (Resources.Get(array1, typeof(LinkDestinationExplicit)) as LinkDestinationExplicit);
        }

        private void SetArraySize(int size)
        {
            PDFArray array1 = (base.Direct as PDFArray);
            while ((size < array1.Count))
            {
                array1.RemoveAt((array1.Count - 1));
            }
            while ((size > array1.Count))
            {
                array1.Add(Library.CreateNull());
            }
        }


        // Properties
        public double Bottom
        {
            get
            {
                PDFFixed fixed1;
                if (this.PageFit == EPageFit.FitR)
                {
                    fixed1 = ((base.Direct as PDFArray)[3] as PDFFixed);
                    if (fixed1 == null)
                    {
                        return NaNf;
                    }
                    return fixed1.DoubleValue;
                }
                return NaNf;
            }
            set
            {
                if (this.PageFit == EPageFit.FitR)
                {
                    (base.Direct as PDFArray)[3] = Library.CreateFixed(value);
                }
            }
        }

        public double Left
        {
            get
            {
                PDFFixed fixed1;
                if (((this.PageFit == EPageFit.XYZ) || (this.PageFit == EPageFit.FitV)) || ((this.PageFit == EPageFit.Fit) || (this.PageFit == EPageFit.FitBV)))
                {
                    fixed1 = ((base.Direct as PDFArray)[2] as PDFFixed);
                    if (fixed1 == null)
                    {
                        return NaNf;
                    }
                    return fixed1.DoubleValue;
                }
                return NaNf;
            }
            set
            {
                if (((this.PageFit != EPageFit.XYZ) && (this.PageFit != EPageFit.FitV)) && ((this.PageFit != EPageFit.FitR) && (this.PageFit != EPageFit.FitBV)))
                {
                    return;
                }
                (base.Direct as PDFArray)[2] = Library.CreateFixed(value);
            }
        }

        public Page Page
        {
            get
            {
                return (Resources.Get(((PDFArray) base.Direct)[0], typeof(Page)) as Page);
            }
            set
            {
                ((PDFArray) base.Direct)[0] = value.Direct;
            }
        }

        public EPageFit PageFit
        {
            get
            {
                string text1 = ((base.Direct as PDFArray)[1] as PDFName).Value;
                if (text1 == null)
                {
                    goto Label_00A2;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "XYZ")
                {
                    if (text1 == "Fit")
                    {
                        goto Label_0094;
                    }
                    if (text1 == "FitH")
                    {
                        goto Label_0096;
                    }
                    if (text1 == "FitV")
                    {
                        goto Label_0098;
                    }
                    if (text1 == "FitR")
                    {
                        goto Label_009A;
                    }
                    if (text1 == "FitB")
                    {
                        goto Label_009C;
                    }
                    if (text1 == "FitBV")
                    {
                        goto Label_009E;
                    }
                    if (text1 == "FitBH")
                    {
                        goto Label_00A0;
                    }
                    goto Label_00A2;
                }
                return EPageFit.XYZ;
            Label_0094:
                return EPageFit.Fit;
            Label_0096:
                return EPageFit.FitH;
            Label_0098:
                return EPageFit.FitV;
            Label_009A:
                return EPageFit.FitR;
            Label_009C:
                return EPageFit.FitB;
            Label_009E:
                return EPageFit.FitBV;
            Label_00A0:
                return EPageFit.FitBH;
            Label_00A2:
                return EPageFit.Unknown;
            }
            set
            {
                PDFArray array1 = (base.Direct as PDFArray);
                EPageFit fit1 = value;
                switch (fit1)
                {
                    case EPageFit.XYZ:
                    {
                        this.SetArraySize(5);
                        goto Label_007B;
                    }
                    case EPageFit.Fit:
                    {
                        this.SetArraySize(2);
                        goto Label_007B;
                    }
                    case EPageFit.FitH:
                    {
                        this.SetArraySize(3);
                        goto Label_007B;
                    }
                    case EPageFit.FitV:
                    {
                        this.SetArraySize(3);
                        goto Label_007B;
                    }
                    case EPageFit.FitR:
                    {
                        this.SetArraySize(6);
                        goto Label_007B;
                    }
                    case EPageFit.FitB:
                    {
                        this.SetArraySize(2);
                        goto Label_007B;
                    }
                    case EPageFit.FitBH:
                    {
                        goto Label_0074;
                    }
                    case EPageFit.FitBV:
                    {
                        this.SetArraySize(3);
                        goto Label_007B;
                    }
                }
                return;
            Label_0074:
                this.SetArraySize(3);
            Label_007B:
                array1[1] = PDF.N(LinkDestinationExplicit.PageFitTags[value]);
            }
        }

        public int PageNumber
        {
            get
            {
                PDFInteger integer1 = ((base.Direct as PDFArray)[0] as PDFInteger);
                if (integer1 == null)
                {
                    return -1;
                }
                return integer1.Int32Value;
            }
            set
            {
                (base.Direct as PDFArray)[0] = PDF.O(value);
            }
        }

        public double Right
        {
            get
            {
                PDFFixed fixed1;
                if (this.PageFit == EPageFit.FitR)
                {
                    fixed1 = ((base.Direct as PDFArray)[4] as PDFFixed);
                    if (fixed1 == null)
                    {
                        return NaNf;
                    }
                    return fixed1.DoubleValue;
                }
                return NaNf;
            }
            set
            {
                if (this.PageFit == EPageFit.FitR)
                {
                    (base.Direct as PDFArray)[4] = Library.CreateFixed(value);
                }
            }
        }

        public double Top
        {
            get
            {
                PDFFixed fixed1;
                int num1 = 0;
                EPageFit fit1 = this.PageFit;
                switch (fit1)
                {
                    case EPageFit.XYZ:
                    {
                        num1 = 3;
                        goto Label_0047;
                    }
                    case EPageFit.Fit:
                    case EPageFit.FitB:
                    case EPageFit.FitV:
                    {
                        goto Label_003D;
                    }
                    case EPageFit.FitH:
                    {
                        num1 = 2;
                        goto Label_0047;
                    }
                    case EPageFit.FitR:
                    {
                        num1 = 5;
                        goto Label_0047;
                    }
                    case EPageFit.FitBH:
                    {
                        num1 = 2;
                        goto Label_0047;
                    }
                }
            Label_003D:
                return NaNf;
            Label_0047:
                fixed1 = ((base.Direct as PDFArray)[num1] as PDFFixed);
                if (fixed1 == null)
                {
                    return NaNf;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                int num1 = 0;
                EPageFit fit1 = this.PageFit;
                switch (fit1)
                {
                    case EPageFit.XYZ:
                    {
                        num1 = 3;
                        goto Label_003D;
                    }
                    case EPageFit.Fit:
                    case EPageFit.FitB:
                    case EPageFit.FitV:
                    {
                        return;
                    }
                    case EPageFit.FitH:
                    {
                        num1 = 2;
                        goto Label_003D;
                    }
                    case EPageFit.FitR:
                    {
                        num1 = 5;
                        goto Label_003D;
                    }
                    case EPageFit.FitBH:
                    {
                        num1 = 2;
                        goto Label_003D;
                    }
                }
                return;
            Label_003D:
                (base.Direct as PDFArray)[num1] = Library.CreateFixed(value);
            }
        }

        public double Zoom
        {
            get
            {
                PDFFixed fixed1;
                if (this.PageFit == EPageFit.XYZ)
                {
                    fixed1 = ((base.Direct as PDFArray)[4] as PDFFixed);
                    if (fixed1 == null)
                    {
                        return NaNf;
                    }
                    return fixed1.DoubleValue;
                }
                return NaNf;
            }
            set
            {
                if (this.PageFit == EPageFit.XYZ)
                {
                    (base.Direct as PDFArray)[4] = Library.CreateFixed(value);
                }
            }
        }


        // Fields
        private static string[] PageFitTags;
    }
}


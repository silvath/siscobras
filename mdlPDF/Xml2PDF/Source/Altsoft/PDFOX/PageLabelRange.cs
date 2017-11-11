namespace Altsoft.PDFO
{
    using System;

    public class PageLabelRange : Resource
    {
        // Methods
        internal PageLabelRange(PDFDirect direct) : base(direct)
        {
        }

        public static PageLabelRange Create(string prefix, int start, PageNumberingStyle style, bool indirect)
        {
            PageLabelRange range1 = (Resources.Get(Library.CreateDict(), typeof(PageLabelRange)) as PageLabelRange);
            range1.Prefix = prefix;
            range1.Start = start;
            range1.NumberingStyle = style;
            if (indirect)
            {
                Library.CreateIndirect(range1.Direct);
            }
            return range1;
        }

        internal static Resource Factory(PDFDirect direct)
        {
            return new PageLabelRange(direct);
        }


        // Properties
        public PageNumberingStyle NumberingStyle
        {
            get
            {
                PDFName name1 = (this.Dict["S"] as PDFName);
                if (name1 == null)
                {
                    return PageNumberingStyle.Unknown;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_007B;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "D")
                {
                    if (text1 == "R")
                    {
                        goto Label_0073;
                    }
                    if (text1 == "r")
                    {
                        goto Label_0075;
                    }
                    if (text1 == "A")
                    {
                        goto Label_0077;
                    }
                    if (text1 == "a")
                    {
                        goto Label_0079;
                    }
                    goto Label_007B;
                }
                return PageNumberingStyle.Arabic;
            Label_0073:
                return PageNumberingStyle.RomanUpperCase;
            Label_0075:
                return PageNumberingStyle.RomanLowerCase;
            Label_0077:
                return PageNumberingStyle.LettersUpperCase;
            Label_0079:
                return PageNumberingStyle.LettersLowerCase;
            Label_007B:
                return PageNumberingStyle.Unknown;
            }
            set
            {
                PageNumberingStyle style1 = value;
                switch (style1)
                {
                    case PageNumberingStyle.None:
                    {
                        this.Dict.Remove("S");
                        return;
                    }
                    case PageNumberingStyle.Arabic:
                    {
                        this.Dict["S"] = PDF.N("D");
                        return;
                    }
                    case PageNumberingStyle.RomanUpperCase:
                    {
                        this.Dict["S"] = PDF.N("R");
                        return;
                    }
                    case PageNumberingStyle.RomanLowerCase:
                    {
                        this.Dict["S"] = PDF.N("r");
                        return;
                    }
                    case PageNumberingStyle.LettersUpperCase:
                    {
                        this.Dict["S"] = PDF.N("A");
                        return;
                    }
                    case PageNumberingStyle.LettersLowerCase:
                    {
                        this.Dict["S"] = PDF.N("a");
                        return;
                    }
                }
                throw new ArgumentException("Can not set numbering style to unknown");
            }
        }

        public string Prefix
        {
            get
            {
                PDFString text1 = (this.Dict["P"] as PDFString);
                if (text1 == null)
                {
                    return "";
                }
                return text1.Value;
            }
            set
            {
                this.Dict["P"] = PDF.O(value);
            }
        }

        public int Start
        {
            get
            {
                PDFInteger integer1 = (this.Dict["St"] as PDFInteger);
                if (integer1 == null)
                {
                    return 1;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.Dict["St"] = PDF.O(value);
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;

    public class XObjectGroupTransparancy : XObjectGroup
    {
        // Methods
        internal XObjectGroupTransparancy(PDFDict dict) : base(dict)
        {
        }


        // Properties
        public ColorSpace ColorSpace
        {
            get
            {
                PDFDirect direct1;
                if (this.mColorSpace == null)
                {
                    direct1 = (this.mDict["CS"] as PDFDirect);
                    if (direct1 == null)
                    {
                        return null;
                    }
                    this.mColorSpace = (this.mDict.Doc.Resources[direct1, typeof(ColorSpace)] as ColorSpace);
                }
                return this.mColorSpace;
            }
            set
            {
                this.mColorSpace = value;
                this.mDict["CS"] = value.Direct;
            }
        }

        public bool Isolated
        {
            get
            {
                PDFBoolean flag1 = (this.mDict["I"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.mDict["I"] = PDF.O(value);
            }
        }

        public bool Knockout
        {
            get
            {
                PDFBoolean flag1 = (this.mDict["K"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.mDict["K"] = PDF.O(value);
            }
        }


        // Fields
        private ColorSpace mColorSpace;
    }
}


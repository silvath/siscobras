namespace Altsoft.PDFO
{
    using System;

    public abstract class Pattern : Resource
    {
        // Methods
        static Pattern()
        {
            Pattern.DictKeyName = "Pattern";
        }

        public Pattern(PDFDirect d) : base(d)
        {
        }

        internal static Resource Factory(PDFDirect d)
        {
            PDFObjectType type1 = d.PDFType;
            switch (type1)
            {
                case PDFObjectType.tPDFDict:
                {
                    goto Label_0024;
                }
                case PDFObjectType.tPDFArray:
                {
                    goto Label_002B;
                }
                case PDFObjectType.tPDFStream:
                {
                    goto Label_001D;
                }
            }
            goto Label_002B;
        Label_001D:
            return new PatternTiling(d);
        Label_0024:
            return new PatternShading(d);
        Label_002B:
            throw new PDFSyntaxException(d, "Invalid Pattern");
        }


        // Fields
        internal static readonly string DictKeyName;
    }
}


namespace Altsoft.PDFO
{
    using System;

    public abstract class XObject : Resource
    {
        // Methods
        static XObject()
        {
            XObject.DictKeyName = "XObject";
        }

        public XObject(PDFDirect d) : base(d)
        {
        }

        internal static Resource Factory(PDFDirect d)
        {
            PDFName name1;
            PDFDict dict1 = (d as PDFStream).Dict;
            string text1 = (dict1["Subtype"] as PDFName).Value;
            if (text1 == "Image")
            {
                return new XObjectImage(d);
            }
            if (text1 == "Form")
            {
                name1 = (dict1["SubType2"] as PDFName);
                if (name1 == null)
                {
                    return new XObjectForm(d);
                }
                if (name1.Value == "PS")
                {
                    return new XObjectPS(d);
                }
                return new XObjectForm(d);
            }
            if (text1 == "PS")
            {
                return new XObjectPS(d);
            }
            throw new PDFSyntaxException(d, "Invalid XObject type");
        }


        // Fields
        internal static readonly string DictKeyName;
    }
}


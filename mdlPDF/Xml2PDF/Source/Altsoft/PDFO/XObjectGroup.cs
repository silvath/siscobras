namespace Altsoft.PDFO
{
    using System;

    public class XObjectGroup
    {
        // Methods
        internal XObjectGroup(PDFDict dict)
        {
            this.mDict = dict;
        }

        internal static XObjectGroup Factory(PDFDict dict)
        {
            PDFName name1 = (dict["S"] as PDFName);
            if (name1 == null)
            {
                throw new PDFSyntaxException(dict, "Missing group subtype");
            }
            if (name1.Value == "Transparency")
            {
                return new XObjectGroupTransparancy(dict);
            }
            throw new PDFSyntaxException(dict, "Invalid group subtype");
        }


        // Fields
        internal PDFDict mDict;
    }
}


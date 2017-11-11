namespace Altsoft.PDFO
{
    using System;

    public class MediaOffset : Resource
    {
        // Methods
        public MediaOffset(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            if (direct == null)
            {
                return null;
            }
            string text1 = ((direct as PDFDict)["S"] as PDFName).Value;
            if (text1 == null)
            {
                goto Label_006A;
            }
            text1 = string.IsInterned(text1);
            if (text1 != "T")
            {
                if (text1 == "F")
                {
                    goto Label_005C;
                }
                if (text1 == "M")
                {
                    goto Label_0063;
                }
                goto Label_006A;
            }
            return new MediaOffsetTime(direct);
        Label_005C:
            return new MediaOffsetFrame(direct);
        Label_0063:
            return new MediaOffsetMarker(direct);
        Label_006A:
            return null;
        }


        // Properties
        public string SubType
        {
            get
            {
                return (this.Dict["S"] as PDFName).Value;
            }
        }


        // Fields
        public const string Type = "MediaOffset";
    }
}


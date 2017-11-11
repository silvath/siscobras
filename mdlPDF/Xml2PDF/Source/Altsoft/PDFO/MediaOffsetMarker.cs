namespace Altsoft.PDFO
{
    using System;

    public class MediaOffsetMarker : MediaOffset
    {
        // Methods
        public MediaOffsetMarker(PDFDirect direct) : base(direct)
        {
        }

        public static MediaOffsetMarker Create(string namedoffset)
        {
            return MediaOffsetMarker.Create(true, namedoffset);
        }

        public static MediaOffsetMarker Create(bool indirect, string namedoffset)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["M"] = Library.CreateString(namedoffset);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MediaOffsetMarker(dict1);
        }


        // Properties
        public string MarkerOffset
        {
            get
            {
                return (this.Dict["M"] as PDFString).Value;
            }
            set
            {
                this.Dict["M"] = Library.CreateString(value);
            }
        }

    }
}


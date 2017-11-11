namespace Altsoft.PDFO
{
    using System;

    public class MediaOffsetFrame : MediaOffset
    {
        // Methods
        public MediaOffsetFrame(PDFDirect direct) : base(direct)
        {
        }

        public static MediaOffsetFrame Create(int framenum)
        {
            return MediaOffsetFrame.Create(true, framenum);
        }

        public static MediaOffsetFrame Create(bool indirect, int framenum)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["F"] = Library.CreateInteger(((long) framenum));
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MediaOffsetFrame(dict1);
        }


        // Properties
        public int Frame
        {
            get
            {
                return (this.Dict["F"] as PDFInteger).Int32Value;
            }
            set
            {
                this.Dict["F"] = Library.CreateInteger(((long) value));
            }
        }

    }
}


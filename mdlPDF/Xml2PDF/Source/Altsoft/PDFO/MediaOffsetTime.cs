namespace Altsoft.PDFO
{
    using System;

    public class MediaOffsetTime : MediaOffset
    {
        // Methods
        public MediaOffsetTime(PDFDirect direct) : base(direct)
        {
        }

        public static MediaOffsetTime Create(MediaTimeSpan timespan)
        {
            return MediaOffsetTime.Create(true, timespan);
        }

        public static MediaOffsetTime Create(bool indirect, MediaTimeSpan timespan)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["T"] = timespan.Dict;
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MediaOffsetTime(dict1);
        }


        // Properties
        public MediaTimeSpan TemporalOffset
        {
            get
            {
                return (Resources.Get((this.Dict["T"] as PDFDirect), typeof(MediaTimeSpan)) as MediaTimeSpan);
            }
            set
            {
                this.Dict["T"] = value.Dict;
            }
        }

    }
}


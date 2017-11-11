namespace Altsoft.PDFO
{
    using System;

    public class MediaPlayerInfo : Resource
    {
        // Methods
        public MediaPlayerInfo(PDFDirect direct) : base(direct)
        {
        }

        public static MediaPlayerInfo Create(SoftwareIdentifier PID)
        {
            return MediaPlayerInfo.Create(true, PID);
        }

        public static MediaPlayerInfo Create(bool indirect, SoftwareIdentifier PID)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["PID"] = PID.Direct;
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MediaPlayerInfo(dict1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new MediaPlayerInfo(direct);
        }


        // Properties
        public SoftwareIdentifier PID
        {
            get
            {
                return (Resources.Get((this.Dict["PID"] as PDFDirect), typeof(SoftwareIdentifier)) as SoftwareIdentifier);
            }
            set
            {
                this.Dict["PID"] = value.Direct;
            }
        }

    }
}


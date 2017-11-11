namespace Altsoft.PDFO
{
    using System;

    public class MediaClipSection : MediaClipBase
    {
        // Methods
        public MediaClipSection(PDFDirect direct) : base(direct)
        {
        }

        public static MediaClipSection Create(MediaClipBase mediaclip)
        {
            return MediaClipSection.Create(true, mediaclip);
        }

        public static MediaClipSection Create(bool indirect, MediaClipBase mediaclip)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["D"] = mediaclip.Dict;
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MediaClipSection(dict1);
        }


        // Properties
        public MCS_MHBE BE
        {
            get
            {
                PDFDict dict1 = (this.Dict["BE"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MCS_MHBE)) as MCS_MHBE);
            }
            set
            {
                this.Dict["BE"] = value.Dict;
            }
        }

        public MediaClipBase MediaObject
        {
            get
            {
                return (Resources.Get((this.Dict["D"] as PDFDirect), typeof(MediaClipBase)) as MediaClipBase);
            }
            set
            {
                this.Dict["D"] = value.Dict;
            }
        }

        public MCS_MHBE MH
        {
            get
            {
                PDFDict dict1 = (this.Dict["MH"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MCS_MHBE)) as MCS_MHBE);
            }
            set
            {
                this.Dict["MH"] = value.Dict;
            }
        }

    }
}


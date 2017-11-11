namespace Altsoft.PDFO
{
    using System;

    public class RenditionMedia : Rendition
    {
        // Methods
        public RenditionMedia(PDFDirect direct) : base(direct)
        {
        }

        public static RenditionMedia Create(MediaClipBase mediaclip)
        {
            return RenditionMedia.Create(true, mediaclip);
        }

        public static RenditionMedia Create(MediaPlayParameters mpp)
        {
            return RenditionMedia.Create(true, mpp);
        }

        private static RenditionMedia Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("MR");
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new RenditionMedia(dict1);
        }

        public static RenditionMedia Create(MediaClipBase mediaclip, MediaPlayParameters mpp)
        {
            return RenditionMedia.Create(true, mediaclip, mpp);
        }

        public static RenditionMedia Create(MediaPlayParameters mpp, MediaScreenParameters msp)
        {
            return RenditionMedia.Create(true, mpp, msp);
        }

        public static RenditionMedia Create(bool indirect, MediaClipBase mediaclip)
        {
            RenditionMedia media1 = RenditionMedia.Create(indirect);
            media1.MediaClip = mediaclip;
            return media1;
        }

        public static RenditionMedia Create(bool indirect, MediaPlayParameters mpp)
        {
            RenditionMedia media1 = RenditionMedia.Create(indirect);
            media1.MediaPlayParameters = mpp;
            return media1;
        }

        public static RenditionMedia Create(MediaClipBase mediaclip, MediaPlayParameters mpp, MediaScreenParameters msp)
        {
            return RenditionMedia.Create(true, mediaclip, mpp, msp);
        }

        public static RenditionMedia Create(bool indirect, MediaClipBase mediaclip, MediaPlayParameters mpp)
        {
            RenditionMedia media1 = RenditionMedia.Create(indirect);
            media1.MediaClip = mediaclip;
            media1.MediaPlayParameters = mpp;
            return media1;
        }

        public static RenditionMedia Create(bool indirect, MediaPlayParameters mpp, MediaScreenParameters msp)
        {
            RenditionMedia media1 = RenditionMedia.Create(indirect);
            media1.MediaPlayParameters = mpp;
            media1.MediaScreenParams = msp;
            return media1;
        }

        public static RenditionMedia Create(bool indirect, MediaClipBase mediaclip, MediaPlayParameters mpp, MediaScreenParameters msp)
        {
            RenditionMedia media1 = RenditionMedia.Create(indirect);
            media1.MediaClip = mediaclip;
            media1.MediaPlayParameters = mpp;
            media1.MediaScreenParams = msp;
            return media1;
        }


        // Properties
        public MediaClipBase MediaClip
        {
            get
            {
                PDFDict dict1 = (this.Dict["C"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MediaClipBase)) as MediaClipBase);
            }
            set
            {
                this.Dict["C"] = value.Dict;
            }
        }

        public MediaPlayParameters MediaPlayParameters
        {
            get
            {
                PDFDict dict1 = (this.Dict["P"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MediaPlayParameters)) as MediaPlayParameters);
            }
            set
            {
                this.Dict["P"] = value.Direct;
            }
        }

        public MediaScreenParameters MediaScreenParams
        {
            get
            {
                PDFDict dict1 = (this.Dict["SP"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MediaScreenParameters)) as MediaScreenParameters);
            }
            set
            {
                this.Dict["SP"] = value.Dict;
            }
        }

    }
}


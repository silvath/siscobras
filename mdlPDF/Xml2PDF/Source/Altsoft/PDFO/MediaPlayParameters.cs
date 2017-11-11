namespace Altsoft.PDFO
{
    using System;

    public class MediaPlayParameters : Resource
    {
        // Methods
        public MediaPlayParameters(PDFDirect direct) : base(direct)
        {
        }

        public static MediaPlayParameters Create()
        {
            return MediaPlayParameters.Create(true);
        }

        public static MediaPlayParameters Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MediaPlayParameters(dict1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new MediaPlayParameters(direct);
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

        public MediaPlayers MediaPlayers
        {
            get
            {
                PDFDict dict1 = (this.Dict["PL"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MediaPlayers)) as MediaPlayers);
            }
            set
            {
                this.Dict["PL"] = value.Dict;
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


        // Fields
        public const string Type = "MediaPlayParams";
    }
}


namespace Altsoft.PDFO
{
    using System;

    public class MediaScreenParameters : Resource
    {
        // Methods
        public MediaScreenParameters(PDFDirect direct) : base(direct)
        {
        }

        public static MediaScreenParameters Create()
        {
            return MediaScreenParameters.Create(true);
        }

        public static MediaScreenParameters Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MediaScreenParameters(dict1);
        }

        public static MediaScreenParameters Create(MS_MHBE MH, MS_MHBE BE)
        {
            MediaScreenParameters parameters1 = MediaScreenParameters.Create(true);
            parameters1.MH = MH;
            parameters1.BE = BE;
            return parameters1;
        }

        public static MediaScreenParameters Create(bool indirect, MS_MHBE MH, MS_MHBE BE)
        {
            MediaScreenParameters parameters1 = MediaScreenParameters.Create(indirect);
            parameters1.MH = MH;
            parameters1.BE = BE;
            return parameters1;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new MediaScreenParameters(direct);
        }


        // Properties
        public MS_MHBE BE
        {
            get
            {
                PDFDict dict1 = (this.Dict["BE"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MS_MHBE)) as MS_MHBE);
            }
            set
            {
                this.Dict["BE"] = value.Dict;
            }
        }

        public MS_MHBE MH
        {
            get
            {
                PDFDict dict1 = (this.Dict["MH"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MS_MHBE)) as MS_MHBE);
            }
            set
            {
                this.Dict["MH"] = value.Dict;
            }
        }


        // Fields
        public const string Type = "MediaScreenParams";
    }
}


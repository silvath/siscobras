namespace Altsoft.PDFO
{
    using System;

    public class MCD_MHBE : Resource
    {
        // Methods
        public MCD_MHBE(PDFDirect direct) : base(direct)
        {
        }

        public static MCD_MHBE Create()
        {
            return MCD_MHBE.Create(true);
        }

        public static MCD_MHBE Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MCD_MHBE(dict1);
        }

        public static MCD_MHBE Create(string URL)
        {
            MCD_MHBE mcd_mhbe1 = MCD_MHBE.Create(true);
            mcd_mhbe1.URL = URL;
            return mcd_mhbe1;
        }

        public static MCD_MHBE Create(bool indirect, string URL)
        {
            MCD_MHBE mcd_mhbe1 = MCD_MHBE.Create(indirect);
            mcd_mhbe1.URL = URL;
            return mcd_mhbe1;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new MCD_MHBE(direct);
        }


        // Properties
        public string URL
        {
            get
            {
                PDFString text1 = (this.Dict["BU"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["BU"] = Library.CreateString(value);
            }
        }

    }
}


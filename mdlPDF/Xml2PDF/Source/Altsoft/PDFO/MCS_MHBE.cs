namespace Altsoft.PDFO
{
    using System;

    public class MCS_MHBE : Resource
    {
        // Methods
        public MCS_MHBE(PDFDirect direct) : base(direct)
        {
        }

        public static MCS_MHBE Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MCS_MHBE(dict1);
        }

        public static MCS_MHBE Create(MediaOffset sectionbegin, MediaOffset sectionend)
        {
            MCS_MHBE mcs_mhbe1 = MCS_MHBE.Create(true);
            mcs_mhbe1.MediaClipSectionBegin = sectionbegin;
            mcs_mhbe1.MediaClipSectionEnd = sectionend;
            return mcs_mhbe1;
        }

        public static MCS_MHBE Create(bool indirect, MediaOffset sectionbegin, MediaOffset sectionend)
        {
            MCS_MHBE mcs_mhbe1 = MCS_MHBE.Create(indirect);
            mcs_mhbe1.MediaClipSectionBegin = sectionbegin;
            mcs_mhbe1.MediaClipSectionEnd = sectionend;
            return mcs_mhbe1;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new MCS_MHBE(direct);
        }


        // Properties
        public MediaOffset MediaClipSectionBegin
        {
            get
            {
                PDFDict dict1 = (this.Dict["B"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MediaOffset)) as MediaOffset);
            }
            set
            {
                this.Dict["B"] = value.Dict;
            }
        }

        public MediaOffset MediaClipSectionEnd
        {
            get
            {
                PDFDict dict1 = (this.Dict["E"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MediaOffset)) as MediaOffset);
            }
            set
            {
                this.Dict["E"] = value.Dict;
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;

    public class RenditionMHBE : Resource
    {
        // Methods
        public RenditionMHBE(PDFDirect direct) : base(direct)
        {
        }

        public static RenditionMHBE Create()
        {
            return RenditionMHBE.Create(true);
        }

        public static RenditionMHBE Create(MediaCriteria MediaCriteria)
        {
            RenditionMHBE nmhbe1 = RenditionMHBE.Create(true);
            nmhbe1.MediaCriteria = MediaCriteria;
            return nmhbe1;
        }

        public static RenditionMHBE Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new RenditionMHBE(dict1);
        }

        public static RenditionMHBE Create(bool indirect, MediaCriteria MediaCriteria)
        {
            RenditionMHBE nmhbe1 = RenditionMHBE.Create(indirect);
            nmhbe1.MediaCriteria = MediaCriteria;
            return nmhbe1;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new RenditionMHBE(direct);
        }


        // Properties
        public MediaCriteria MediaCriteria
        {
            get
            {
                PDFDict dict1 = (this.Dict["C"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MediaCriteria)) as MediaCriteria);
            }
            set
            {
                this.Dict["C"] = value.Dict;
            }
        }

    }
}


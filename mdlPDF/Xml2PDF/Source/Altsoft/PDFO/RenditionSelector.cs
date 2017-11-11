namespace Altsoft.PDFO
{
    using System;

    public class RenditionSelector : Rendition
    {
        // Methods
        public RenditionSelector(PDFDirect direct) : base(direct)
        {
            this.mRend = null;
        }

        public static RenditionSelector Create(RenditionCollection rendColl)
        {
            return RenditionSelector.Create(true, rendColl);
        }

        public static RenditionSelector Create(bool indirect, RenditionCollection rendColl)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("SR");
            dict1["R"] = rendColl.mBaseDict[rendColl.mBaseKeyName];
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new RenditionSelector(dict1);
        }


        // Properties
        public RenditionCollection RenditionCollection
        {
            get
            {
                if (this.mRend != null)
                {
                    return this.mRend;
                }
                return new RenditionCollection(this.Dict, "R", false);
            }
            set
            {
                this.mRend = value;
                this.Dict["R"] = value.mBaseDict[value.mBaseKeyName];
            }
        }


        // Fields
        private RenditionCollection mRend;
    }
}


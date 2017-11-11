namespace Altsoft.PDFO
{
    using System;

    public class OCGProperties : Resource
    {
        // Methods
        public OCGProperties(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new OCGProperties(direct);
        }


        // Properties
        public OCGConfigCollection AlternateConfig
        {
            get
            {
                if (this.mAltConfig != null)
                {
                    return null;
                }
                PDFObject obj1 = this.Dict["Configs"];
                if (obj1 == null)
                {
                    return null;
                }
                return new OCGConfigCollection(this.Dict, "OCGs", false);
            }
            set
            {
                this.mAltConfig = value;
            }
        }

        public OCGConfig DefaultConfig
        {
            get
            {
                return (Resources.Get((this.Dict["D"] as PDFDict), typeof(OCGConfig)) as OCGConfig);
            }
            set
            {
                this.Dict["D"] = value.Direct;
            }
        }

        public OCGCollection OptContentCollection
        {
            get
            {
                if (this.mOptContent != null)
                {
                    return null;
                }
                PDFObject obj1 = this.Dict["OCGs"];
                if (obj1 == null)
                {
                    return null;
                }
                return new OCGCollection(this.Dict, "OCGs", false);
            }
            set
            {
                this.mOptContent = value;
            }
        }


        // Fields
        private OCGConfigCollection mAltConfig;
        private OCGCollection mOptContent;
    }
}


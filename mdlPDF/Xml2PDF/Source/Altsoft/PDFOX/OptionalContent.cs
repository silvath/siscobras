namespace Altsoft.PDFO
{
    using System;

    public class OptionalContent : Resource
    {
        // Methods
        public OptionalContent(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new OptionalContent(direct);
        }


        // Properties
        public string ContentGroupName
        {
            get
            {
                return (this.Dict["Name"] as PDFName).Value;
            }
            set
            {
                this.Dict["Name"] = Library.CreateName(value);
            }
        }

        public NameList Intent
        {
            get
            {
                if (this.mIntent != null)
                {
                    return this.mIntent;
                }
                PDFDirect direct1 = (this.Dict["Intent"] as PDFDirect);
                if (direct1 == null)
                {
                    return null;
                }
                return new NameList(this.Dict, "Intent", true);
            }
            set
            {
                this.mIntent = value;
            }
        }

        public string Type
        {
            get
            {
                return "OCG";
            }
        }

        public OCGUsage Usage
        {
            get
            {
                PDFDict dict1 = (this.Dict["Usage"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(OCGUsage)) as OCGUsage);
            }
            set
            {
                this.Dict["Usage"] = value.Direct;
            }
        }


        // Fields
        private NameList mIntent;
    }
}


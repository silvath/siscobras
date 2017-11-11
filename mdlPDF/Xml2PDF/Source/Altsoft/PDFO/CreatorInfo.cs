namespace Altsoft.PDFO
{
    using System;

    public class CreatorInfo : Resource
    {
        // Methods
        public CreatorInfo(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new CreatorInfo(direct);
        }


        // Properties
        public string Creator
        {
            get
            {
                return (this.Dict["Creator"] as PDFName).Value;
            }
            set
            {
                this.Dict["Creator"] = Library.CreateName(value);
            }
        }

        public string SubType
        {
            get
            {
                return (this.Dict["Subtype"] as PDFName).Value;
            }
            set
            {
                this.Dict["Subtype"] = Library.CreateName(value);
            }
        }

    }
}


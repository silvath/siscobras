namespace Altsoft.PDFO
{
    using System;

    public class LinkDestinationNamed : LinkDestination
    {
        // Methods
        internal LinkDestinationNamed(PDFDirect direct) : base(direct)
        {
        }


        // Properties
        public string Name
        {
            get
            {
                return ((PDFString) base.Direct).Value;
            }
            set
            {
                ((PDFString) base.Direct).Value = value;
            }
        }

        public LinkDestination Target
        {
            get
            {
                Document document1 = base.Direct.Doc;
                if (document1 == null)
                {
                    return null;
                }
                if (this.Name == "")
                {
                    return null;
                }
                return document1.Names.Destinations[this.Name];
            }
        }

    }
}


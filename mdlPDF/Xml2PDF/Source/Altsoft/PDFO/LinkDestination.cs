namespace Altsoft.PDFO
{
    using System;

    public class LinkDestination : Resource
    {
        // Methods
        internal LinkDestination(PDFDirect direct) : base(direct)
        {
        }

        internal static Resource Factory(PDFDirect direct)
        {
            if ((direct is PDFString))
            {
                return new LinkDestinationNamed(direct);
            }
            if ((direct is PDFArray))
            {
                return new LinkDestinationExplicit(direct);
            }
            if ((direct is PDFName))
            {
                return null;
            }
            return null;
        }

    }
}


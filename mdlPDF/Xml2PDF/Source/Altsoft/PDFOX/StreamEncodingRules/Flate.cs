namespace Altsoft.PDFO.StreamEncodingRules
{
    using Altsoft.PDFO;
    using System;

    public class Flate : IStreamEncodingRule
    {
        // Methods
        public Flate()
        {
        }

        public bool Handle(PDFStream stream)
        {
            return false;
        }

    }
}


namespace Altsoft.PDFO
{
    using System;

    public interface IStreamEncodingRule
    {
        // Methods
        bool Handle(PDFStream stream);

    }
}


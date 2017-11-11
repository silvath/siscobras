namespace Altsoft.PDFO
{
    using System;

    public interface PDFFixed : PDFNumeric, PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Properties
        double Value { get; set; }

    }
}


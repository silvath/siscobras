namespace Altsoft.PDFO
{
    using System;

    public interface PDFInteger : PDFNumeric, PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Properties
        long Value { get; set; }

    }
}


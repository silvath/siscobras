namespace Altsoft.PDFO
{
    using System;

    public interface PDFName : PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Properties
        string Value { get; set; }

    }
}


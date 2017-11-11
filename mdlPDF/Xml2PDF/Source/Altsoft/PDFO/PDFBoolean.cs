namespace Altsoft.PDFO
{
    using System;

    public interface PDFBoolean : PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Properties
        bool Value { get; set; }

    }
}


namespace Altsoft.PDFO
{
    using System;

    public interface PDFString : PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Properties
        byte[] Bytes { get; set; }

        string Value { get; set; }

    }
}


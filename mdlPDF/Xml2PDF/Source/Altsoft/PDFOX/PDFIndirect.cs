namespace Altsoft.PDFO
{
    using System;

    public interface PDFIndirect : PDFObject, IDisposable, ICloneable
    {
        // Methods
        PDFDirect DetachDirect();


        // Properties
        int Generation { get; }

        int Id { get; }

    }
}


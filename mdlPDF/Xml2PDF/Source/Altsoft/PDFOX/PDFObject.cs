namespace Altsoft.PDFO
{
    using System;

    public interface PDFObject : IDisposable, ICloneable
    {
        // Properties
        PDFDirect Direct { get; set; }

        bool Dirty { get; set; }

        Document Doc { get; }

        PDFIndirect Indirect { get; }

        bool IsIndirect { get; }

        PDFObject Parent { get; set; }

        PDFObjectType PDFType { get; }

        long UniqueID { get; }

    }
}


namespace Altsoft.PDFO
{
    using System;

    public interface PDFNumeric : PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Properties
        double DoubleValue { get; }

        int Int32Value { get; }

        long Int64Value { get; }

    }
}


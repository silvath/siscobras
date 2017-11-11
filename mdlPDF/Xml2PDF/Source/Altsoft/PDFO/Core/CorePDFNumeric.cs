namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;

    public abstract class CorePDFNumeric : CorePDFDirect, PDFNumeric, PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Methods
        protected CorePDFNumeric()
        {
        }


        // Properties
        public abstract double DoubleValue { get; }

        public abstract int Int32Value { get; }

        public abstract long Int64Value { get; }

    }
}


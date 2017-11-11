namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;

    public sealed class CorePDFNull : CorePDFDirect, PDFNull, PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Methods
        static CorePDFNull()
        {
            CorePDFNull.mInstance = new CorePDFNull();
        }

        private CorePDFNull()
        {
        }

        public override object Clone()
        {
            return this;
        }

        public override string ToString()
        {
            return "null";
        }


        // Properties
        internal static CorePDFNull Instance
        {
            get
            {
                return CorePDFNull.mInstance;
            }
        }

        public override PDFObjectType PDFType
        {
            get
            {
                return PDFObjectType.tPDFNull;
            }
        }


        // Fields
        private static CorePDFNull mInstance;
    }
}


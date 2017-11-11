namespace Altsoft.PDFO
{
    using System;

    public class IntPair : Resource
    {
        // Methods
        public IntPair(PDFDirect direct) : base(direct)
        {
        }

        internal static Resource Factory(PDFDirect d)
        {
            return new IntPair(d);
        }


        // Properties
        public int Length
        {
            get
            {
                return ((base.Direct as PDFArray)[1] as PDFInteger).Int32Value;
            }
            set
            {
                (base.Direct as PDFArray)[1] = Library.CreateInteger(((long) value));
            }
        }

        public int Offset
        {
            get
            {
                return ((base.Direct as PDFArray)[0] as PDFInteger).Int32Value;
            }
            set
            {
                (base.Direct as PDFArray)[0] = Library.CreateInteger(((long) value));
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;

    public class Colorant : Resource
    {
        // Methods
        public Colorant(PDFDirect direct) : base(direct)
        {
        }

        internal static Resource Factory(PDFDirect direct)
        {
            return new Colorant(direct);
        }


        // Properties
        public string ColorantName
        {
            get
            {
                return ((base.Direct as PDFArray)[0] as PDFName).Value;
            }
            set
            {
                (base.Direct as PDFArray)[0] = Library.CreateName(value);
            }
        }

        public double ColorantTint
        {
            get
            {
                return ((base.Direct as PDFArray)[1] as PDFFixed).DoubleValue;
            }
            set
            {
                (base.Direct as PDFArray)[1] = Library.CreateFixed(value);
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;

    public class StringPair : Resource
    {
        // Methods
        public StringPair(PDFDirect direct) : base(direct)
        {
        }

        internal static Resource Factory(PDFDirect d)
        {
            return new StringPair(d);
        }


        // Properties
        public string FirstStr
        {
            get
            {
                return ((base.Direct as PDFArray)[0] as PDFString).Value;
            }
            set
            {
                (base.Direct as PDFArray)[0] = Library.CreateString(value);
            }
        }

        public string SecStr
        {
            get
            {
                return ((base.Direct as PDFArray)[1] as PDFString).Value;
            }
            set
            {
                (base.Direct as PDFArray)[1] = Library.CreateString(value);
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;

    public class PDF
    {
        // Methods
        public PDF()
        {
        }

        public static PDFName N(string n)
        {
            return Library.CreateName(n);
        }

        public static PDFObject O(object o)
        {
            return Library.CreateObject(false, o);
        }

        public static PDFString S(byte[] s)
        {
            return Library.CreateString(Utils.BytesToString(s));
        }

    }
}


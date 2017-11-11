namespace C1.C1Pdf
{
    using System;
    using System.Collections;
    using System.Reflection;

    [DefaultMember("Item")]
    internal class 0O : ArrayList
    {
        // Methods
        internal 0O(C1PdfDocumentBase doc)
        {
            this.UL = doc;
        }


        // Properties
        public 0P this[int 0DV]
        {
            get
            {
                return ((0P) base[0DU]);
            }
            set
            {
                base[0DV] = 0DW;
            }
        }


        // Fields
        internal C1PdfDocumentBase UL;
        internal int UM;
    }
}


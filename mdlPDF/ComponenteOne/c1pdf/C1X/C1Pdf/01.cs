namespace C1.C1Pdf
{
    using System;
    using System.Collections;

    internal class 01 : ArrayList
    {
        // Methods
        internal 01(C1PdfDocumentBase doc)
        {
            this.NE = doc;
        }

        internal void 5V()
        {
            foreach (02 1 in this)
            {
                if (this.NE.Pages.Contains(1.NH))
                {
                    1.NI = this.NE.Pages.IndexOf(1.NH);
                    continue;
                }
                1.NI = -1;
            }
        }


        // Fields
        internal C1PdfDocumentBase NE;
    }
}


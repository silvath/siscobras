namespace C1.C1Pdf
{
    using System;
    using System.Drawing;

    internal abstract class 02
    {
        // Methods
        internal 02(PdfPage page, RectangleF rc)
        {
            this.NH = page;
            this.NG = rc;
            this.NI = -1;
        }


        // Fields
        internal int NF;
        internal RectangleF NG;
        internal PdfPage NH;
        internal int NI;
    }
}


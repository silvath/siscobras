namespace C1.C1Pdf
{
    using System;
    using System.Drawing;

    internal class 0L : 02
    {
        // Methods
        internal 0L(string name, PdfPage page, RectangleF rc) : base(page, rc)
        {
            if (!name.StartsWith("#"))
            {
                name = "#" + name;
            }
            this.SS = name;
        }


        // Fields
        internal string SS;
    }
}


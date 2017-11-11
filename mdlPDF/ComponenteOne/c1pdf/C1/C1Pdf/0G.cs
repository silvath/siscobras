namespace C1.C1Pdf
{
    using System;
    using System.Collections;
    using System.Reflection;

    [DefaultMember("Item")]
    internal class 0G : ArrayList
    {
        // Methods
        internal 0G(C1PdfDocumentBase doc)
        {
            this.S2 = doc;
        }

        internal void 7S()
        {
            object[] objArray1;
            if (this.Count <= 0)
            {
                return;
            }
            this.S2.Write("/XObject <<", new object[0]);
            foreach (0H h1 in this)
            {
                objArray1 = new object[2];
                objArray1[0] = this.IndexOf(h1);
                objArray1[1] = h1.S4;
                this.S2.Write(" /I{0} {1} 0 R", objArray1);
            }
            this.S2.Write(" >>\r\n", new object[0]);
        }


        // Properties
        public 0H this[int 0A4]
        {
            get
            {
                return ((0H) base[0A3]);
            }
            set
            {
                base[0A4] = 0A5;
            }
        }


        // Fields
        internal C1PdfDocumentBase S2;
    }
}


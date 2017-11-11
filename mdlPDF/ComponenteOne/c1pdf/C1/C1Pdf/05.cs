namespace C1.C1Pdf
{
    using System;
    using System.Collections;
    using System.Reflection;

    [DefaultMember("Item")]
    internal class 05 : ArrayList
    {
        // Methods
        internal 05(C1PdfDocumentBase doc)
        {
            this.NT = doc;
        }

        internal void 5Y()
        {
            if (this.Count < 1)
            {
                return;
            }
            foreach (06 1 in this)
            {
                1.NW = (this.NT.Pages.Contains(1.NZ) ? this.NT.Pages.IndexOf(1.NZ) : 2147483647);
            }
            this.Sort();
            this.NS = this.NT.65("Outline object");
            this.NT.67();
            this.NT.6A("Count", ((long) this.Count));
            object[] objArray1 = new object[1];
            objArray1[0] = this.NT.6K((this.NS + 1));
            this.NT.Write("/First {0}\r\n", objArray1);
            objArray1 = new object[1];
            objArray1[0] = this.NT.6K((this.NS + this.Count));
            this.NT.Write("/Last  {0}\r\n", objArray1);
            this.NT.6B();
            this.NT.66();
            foreach (06 2 in this)
            {
                2.60(this.NT);
            }
        }


        // Properties
        public 06 this[int 06P]
        {
            get
            {
                return ((06) base[06P]);
            }
            set
            {
                base[06Q] = 06R;
            }
        }


        // Fields
        internal int NS;
        internal C1PdfDocumentBase NT;
    }
}


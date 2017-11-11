namespace C1.C1Pdf
{
    using System;
    using System.Collections;
    using System.Reflection;

    [DefaultMember("Item")]
    internal class 09 : ArrayList
    {
        // Methods
        internal 09(C1PdfDocumentBase doc)
        {
            this.PA = doc;
            this.Add(new 0A("/Courier"));
            this.Add(new 0A("/Courier-Bold"));
            this.Add(new 0A("/Courier-BoldOblique"));
            this.Add(new 0A("/Courier-Oblique"));
            this.Add(new 0A("/Helvetica"));
            this.Add(new 0A("/Helvetica-Bold"));
            this.Add(new 0A("/Helvetica-BoldOblique"));
            this.Add(new 0A("/Helvetica-Oblique"));
            this.Add(new 0A("/Times-Roman"));
            this.Add(new 0A("/Times-Bold"));
            this.Add(new 0A("/Times-Italic"));
            this.Add(new 0A("/Times-BoldItalic"));
            this.Add(new 0A("/Symbol"));
            this.Add(new 0A("/ZapfDingbats"));
        }

        internal void 7B()
        {
            object[] objArray1;
            if (this.Count <= 0)
            {
                return;
            }
            this.PA.Write("/Font <<", new object[0]);
            foreach (0A a1 in this)
            {
                if (!a1.PL)
                {
                    continue;
                }
                objArray1 = new object[2];
                objArray1[0] = this.IndexOf(a1);
                objArray1[1] = a1.PN;
                this.PA.Write(" /F{0} {1} 0 R", objArray1);
            }
            this.PA.Write(" >>\r\n", new object[0]);
        }


        // Properties
        public 0A this[int 09A]
        {
            get
            {
                return ((0A) base[09A]);
            }
            set
            {
                base[09B] = 09C;
            }
        }


        // Fields
        internal C1PdfDocumentBase PA;
    }
}


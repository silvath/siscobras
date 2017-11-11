namespace C1.C1Pdf
{
    using System;
    using System.Drawing;

    internal class 0K : 02
    {
        // Methods
        internal 0K(string url, PdfPage page, RectangleF rc) : base(page, rc)
        {
            this.SR = url;
        }

        internal void 86(C1PdfDocumentBase 0AM)
        {
            0L l1 = null;
            if ((this.SR != null) && this.SR.StartsWith("#"))
            {
                foreach (0L l2 in 0AM.O9)
                {
                    if (string.Compare(this.SR, l2.SS, true) != 0)
                    {
                        continue;
                    }
                    l1 = l2;
                    goto Label_0069;
                }
            }
        Label_0069:
            this.NF = 0AM.65("Link annotation");
            0AM.67();
            0AM.68("Type", "/Annot");
            0AM.68("Subtype", "/Link");
            0AM.68("Border", "[0 0 0]");
            object[] objArray1 = new object[4];
            objArray1[0] = 0AM.6L(((double) this.NG.Left));
            objArray1[1] = 0AM.6L(((double) this.NG.Top));
            objArray1[2] = 0AM.6L(((double) this.NG.Right));
            objArray1[3] = 0AM.6L(((double) this.NG.Bottom));
            0AM.Write("/Rect [{0} {1} {2} {3}]\r\n", objArray1);
            if (l1 != null)
            {
                objArray1 = new object[3];
                objArray1[0] = l1.NI;
                objArray1[1] = 0AM.6L(((double) l1.NG.Left));
                objArray1[2] = 0AM.6L(((double) l1.NG.Bottom));
                0AM.Write("/Dest [{0} /XYZ {1} {2} 0]\r\n", objArray1);
            }
            else
            {
                0AM.Write("/A << /Type /Action /S /URI /URI ", new object[0]);
                0AM.6H(this.SR, true);
                0AM.Write(" >>\r\n", new object[0]);
            }
            0AM.6B();
            0AM.66();
        }


        // Fields
        internal string SR;
    }
}


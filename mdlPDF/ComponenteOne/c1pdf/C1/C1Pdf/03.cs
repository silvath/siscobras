namespace C1.C1Pdf
{
    using C1.C1Zip;
    using System;
    using System.Drawing;
    using System.IO;

    internal class 03 : 02
    {
        // Methods
        public 03(string fileName, PdfPage page, RectangleF rc, AttachmentIconEnum icon, Color iconColor) : base(page, rc)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Cannot find file to include as attachment.");
            }
            this.NJ = fileName;
            this.NL = icon;
            this.NK = iconColor;
            this.NG = rc;
            this.NH = page;
        }

        internal void 5W(C1PdfDocumentBase 06N)
        {
            bool flag1 = (06N.Compression != CompressionEnum.None);
            byte[] numArray1 = this.5X(flag1);
            this.NF = 06N.65("File Attachment");
            06N.67();
            06N.68("Type", "/Annot");
            06N.68("Subtype", "/FileAttachment");
            object[] objArray1 = new object[4];
            objArray1[0] = 06N.6L(((double) this.NG.Left));
            objArray1[1] = 06N.6L(((double) this.NG.Top));
            objArray1[2] = 06N.6L(((double) this.NG.Right));
            objArray1[3] = 06N.6L(((double) this.NG.Bottom));
            06N.Write("/Rect [{0} {1} {2} {3}]\r\n", objArray1);
            06N.68("Name", "/" + this.NL.ToString());
            if (this.NK != Color.Transparent)
            {
                06N.68("C", string.Format("[{0}]", 06N.6N(this.NK)));
            }
            06N.Write("/FS << /Type /FileSpec /F ", new object[0]);
            06N.6H(Path.GetFileName(this.NJ), true);
            objArray1 = new object[1];
            objArray1[0] = 06N.6K((this.NF + 1));
            06N.Write(" /EF << /F {0} >> >>\r\n", objArray1);
            06N.6B();
            06N.66();
            06N.65("Embedded File");
            06N.67();
            06N.68("Type", "/EmbeddedFile");
            06N.6A("Length", ((long) numArray1.Length));
            if (flag1)
            {
                06N.68("Filter", "/FlateDecode");
            }
            06N.6B();
            06N.6E((this.NF + 1), numArray1);
            06N.66();
        }

        private byte[] 5X(bool 06O)
        {
            FileStream stream1;
            byte[] numArray1;
            int num1;
            if (!06O)
            {
                stream1 = new FileStream(this.NJ, FileMode.Open, FileAccess.Read);
                numArray1 = new byte[((uint) stream1.Length)];
                stream1.Read(numArray1, 0, numArray1.Length);
                stream1.Close();
                return numArray1;
            }
            FileStream stream2 = new FileStream(this.NJ, FileMode.Open, FileAccess.Read);
            MemoryStream stream3 = new MemoryStream();
            X x1 = new X(stream3);
            byte[] numArray2 = new byte[16384];
            do
            {
                num1 = stream2.Read(numArray2, 0, numArray2.Length);
                x1.Write(numArray2, 0, num1);
            }
            while ((num1 >= numArray2.Length));
            x1.Close();
            return stream3.ToArray();
        }


        // Fields
        internal string NJ;
        internal Color NK;
        internal AttachmentIconEnum NL;
    }
}


namespace C1.C1Pdf
{
    using C1.C1Zip;
    using System;
    using System.Drawing;
    using System.IO;

    public class PdfPage
    {
        // Methods
        internal PdfPage(SizeF sizeInPoints)
        {
            this.UU = sizeInPoints;
        }

        internal StreamWriter 9Q(CompressionEnum 0DX)
        {
            this.UT = new MemoryStream();
            if (0DX == CompressionEnum.None)
            {
                this.UV = false;
                return new StreamWriter(this.UT);
            }
            this.UV = true;
            X x1 = new X(this.UT, 0DX);
            return new StreamWriter(x1);
        }

        internal StreamWriter 9R(CompressionEnum 0DY)
        {
            int num1;
            Stream stream1 = null;
            if (this.UT != null)
            {
                stream1 = new MemoryStream(this.UT.ToArray());
                if (this.UV)
                {
                    stream1 = new V(stream1);
                }
            }
            StreamWriter writer1 = this.9Q(0DY);
            if (stream1 == null)
            {
                return writer1;
            }
            byte[] numArray1 = new byte[1024];
            do
            {
                num1 = stream1.Read(numArray1, 0, numArray1.Length);
                writer1.BaseStream.Write(numArray1, 0, num1);
            }
            while ((num1 >= numArray1.Length));
            return writer1;
        }

        internal void 9S(C1PdfDocumentBase 0DZ)
        {
            this.US = 0DZ.65("Page content");
            byte[] numArray1 = this.UT.ToArray();
            0DZ.67();
            0DZ.6A("Length", ((long) numArray1.Length));
            if (this.UV)
            {
                0DZ.68("Filter", "/FlateDecode");
            }
            0DZ.6B();
            0DZ.6E(this.US, numArray1);
            0DZ.66();
        }

        internal void 9T(C1PdfDocumentBase 0E0)
        {
            object[] objArray1;
            int num1 = 0E0.O4.UQ;
            if (num1 < 0)
            {
                throw new ApplicationException("can\'t write page before \'Pages\' object");
            }
            if (this.US < 0)
            {
                throw new ApplicationException("can\'t write page before page content");
            }
            this.UR = 0E0.65("Page definition");
            0E0.67();
            0E0.68("Type", "/Page");
            0E0.68("Parent", 0E0.6K(num1));
            0E0.68("Contents", 0E0.6K(this.US));
            if (this.UU != 0E0.PageSize)
            {
                objArray1 = new object[2];
                objArray1[0] = 0E0.6L(((double) this.UU.Width));
                objArray1[1] = 0E0.6L(((double) this.UU.Height));
                0E0.Write("/MediaBox [0 0 {0} {1}]\r\n", objArray1);
            }
            0E0.68("Resources", 0E0.6K((num1 + 1)));
            bool flag1 = false;
            int num2 = 0E0.O4.IndexOf(this);
            foreach (0K k1 in 0E0.O8)
            {
                if (k1.NI != num2)
                {
                    continue;
                }
                if (!flag1)
                {
                    0E0.Write("/Annots [", new object[0]);
                }
                0E0.Write(0E0.6K(k1.NF), new object[0]);
                0E0.Write(" ", new object[0]);
                flag1 = true;
            }
            foreach (03 1 in 0E0.OA)
            {
                if (1.NI != num2)
                {
                    continue;
                }
                if (!flag1)
                {
                    0E0.Write("/Annots [", new object[0]);
                }
                0E0.Write(0E0.6K(1.NF), new object[0]);
                0E0.Write(" ", new object[0]);
                flag1 = true;
            }
            if (flag1)
            {
                0E0.Write("]\r\n", new object[0]);
            }
            0E0.6B();
        }


        // Properties
        public object Tag
        {
            get
            {
                return this.UW;
            }
            set
            {
                this.UW = value;
            }
        }


        // Fields
        internal int UR;
        internal int US;
        internal MemoryStream UT;
        internal SizeF UU;
        internal bool UV;
        internal object UW;
    }
}


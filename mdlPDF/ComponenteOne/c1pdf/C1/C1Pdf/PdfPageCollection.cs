namespace C1.C1Pdf
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Reflection;

    public class PdfPageCollection : ArrayList
    {
        // Methods
        internal PdfPageCollection(C1PdfDocumentBase doc)
        {
            this.UP = doc;
        }

        internal void 9P()
        {
            int num1;
            this.UQ = this.UP.65("Page catalog");
            this.UP.67();
            this.UP.68("Type", "/Pages");
            this.UP.6A("Count", ((long) this.Count));
            object[] objArray1 = new object[2];
            SizeF ef1 = this.UP.PageSize;
            objArray1[0] = this.UP.6L(((double) ef1.Width));
            ef1 = this.UP.PageSize;
            objArray1[1] = this.UP.6L(((double) ef1.Height));
            this.UP.Write("/MediaBox [0 0 {0} {1}]\r\n", objArray1);
            this.UP.68("Resources", this.UP.6K((this.UQ + 1)));
            this.UP.Write("/Kids [", new object[0]);
            for (num1 = 0; (num1 < this.Count); num1 += 1)
            {
                this.UP.Write(this.UP.6K(((this.UQ + 2) + num1)), new object[0]);
                this.UP.Write(((((num1 + 1) % 12) != 0) ? " " : "\r\n       "), new object[0]);
            }
            this.UP.Write("]\r\n", new object[0]);
            this.UP.6B();
            this.UP.66();
        }

        public int Add()
        {
            return this.Add(new PdfPage(this.UP.PageSize));
        }

        public int Add(PdfPage page)
        {
            if (this.Contains(page))
            {
                throw new ArgumentException("Page is already in the document.");
            }
            int num1 = base.Add(page);
            this.UP.CurrentPage = num1;
            return num1;
        }

        public int Add(PaperKind paperKind)
        {
            SizeF ef1 = C1PdfDocument.77(paperKind);
            return this.Add(new PdfPage(ef1));
        }

        public int Add(SizeF pageSize)
        {
            return this.Add(new PdfPage(pageSize));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Add(object page)
        {
            return base.Add(((PdfPage) page));
        }

        public override void Clear()
        {
            this.UP.CurrentPage = -1;
            base.Clear();
        }

        public void Insert(int index)
        {
            this.Insert(index, new PdfPage(this.UP.PageSize));
        }

        public void Insert(int index, PdfPage page)
        {
            if (this.Contains(page))
            {
                throw new ArgumentException("Page is already in the document.");
            }
            base.Insert(index, page);
            this.UP.CurrentPage = index;
        }

        public void Insert(int index, PaperKind paperKind)
        {
            SizeF ef1 = C1PdfDocument.77(paperKind);
            this.Insert(index, new PdfPage(ef1));
        }

        public void Insert(int index, SizeF pageSize)
        {
            this.Insert(index, new PdfPage(pageSize));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Insert(int index, object page)
        {
            base.Insert(index, ((PdfPage) page));
        }

        public void Remove(PdfPage page)
        {
            this.RemoveAt(this.IndexOf(page));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Remove(object page)
        {
            base.Remove(page);
        }

        public override void RemoveAt(int index)
        {
            this.RemoveRange(index, 1);
        }

        public override void RemoveRange(int index, int count)
        {
            int num1 = this.UP.CurrentPage;
            if (index < num1)
            {
                num1 -= 1;
            }
            this.UP.CurrentPage = -1;
            base.RemoveRange(index, count);
            num1 = Math.Min(num1, (this.Count - 1));
            if (num1 > -1)
            {
                this.UP.CurrentPage = num1;
            }
        }


        // Properties
        public PdfPage this[int index]
        {
            get
            {
                return ((PdfPage) base[index]);
            }
            set
            {
                if (this.Contains(value))
                {
                    throw new ArgumentException("Page is already in the document.");
                }
                base[index] = value;
            }
        }


        // Fields
        internal C1PdfDocumentBase UP;
        internal int UQ;
    }
}


namespace C1.C1Pdf
{
    using C1.Util.Localization;
    using C1.Win;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Reflection;

    [EditorBrowsable(EditorBrowsableState.Never), LicenseProvider(typeof(LicenseProvider))]
    public abstract class C1PdfDocumentBase : Component, B
    {
        // Methods
        static C1PdfDocumentBase()
        {
            C1PdfDocumentBase.OQ = new Bitmap(1, 1);
        }

        public C1PdfDocumentBase()
        {
            ProviderInfo.Validate(typeof(C1PdfDocumentBase), this);
            this.OC = new SizeF(612f, 792f);
            this.OF = ImageQualityEnum.Default;
            this.OG = CompressionEnum.Default;
            this.OE = FontTypeEnum.TrueType;
            this.ON = -1;
            this.Clear();
        }

        internal int 63(0H 074)
        {
            foreach (0H h1 in this.O6)
            {
                if (!074.Equals(h1))
                {
                    continue;
                }
                return this.O6.IndexOf(h1);
            }
            return this.O6.Add(074);
        }

        internal void 64(0H 075, RectangleF 076, RectangleF 077)
        {
            object[] objArray1;
            if (this.XN != 07.OR)
            {
                return;
            }
            bool flag1 = false;
            if ((077 != 076) && (RectangleF.Union(077, 076) != 077))
            {
                flag1 = true;
                objArray1 = new object[4];
                objArray1[0] = this.6L(((double) 077.Left));
                objArray1[1] = this.6L(((double) 077.Top));
                objArray1[2] = this.6L(((double) 077.Width));
                objArray1[3] = this.6L(((double) 077.Height));
                this.Write("q {0} {1} {2} {3} re W n\r\n", objArray1);
            }
            int num1 = this.63(075);
            objArray1 = new object[5];
            objArray1[0] = this.6L(((double) 076.Width));
            objArray1[1] = this.6L(((double) 076.Height));
            objArray1[2] = this.6L(((double) 076.Left));
            objArray1[3] = this.6L(((double) 076.Top));
            objArray1[4] = num1;
            this.Write("q {0} 0 0 {1} {2} {3} cm /I{4} Do Q\r\n", objArray1);
            if (flag1)
            {
                this.Write("Q\r\n", new object[0]);
            }
        }

        internal int 65(string 078)
        {
            0P p1 = new 0P(this.GetNewID(), this.GetStreamPosition());
            this.OB.Add(p1);
            this.6D(078);
            object[] objArray1 = new object[1];
            objArray1[0] = this.GetCurrentID();
            this.Write("{0} 0 obj\r\n", objArray1);
            return this.GetCurrentID();
        }

        internal void 66()
        {
            this.Write("endobj\r\n", new object[0]);
        }

        internal void 67()
        {
            this.Write("<<\r\n", new object[0]);
        }

        internal void 68(string 079, string 07A)
        {
            this.69(079, 07A, false);
        }

        internal void 69(string 07B, string 07C, bool 07D)
        {
            object[] objArray1;
            if ((07B == null) || (07B.Length == 0))
            {
                return;
            }
            if ((07C == null) || (07C.Length == 0))
            {
                return;
            }
            if (!07D)
            {
                objArray1 = new object[2];
                objArray1[0] = 07B;
                objArray1[1] = 07C;
                this.Write("/{0} {1}\r\n", objArray1);
                return;
            }
            objArray1 = new object[1];
            objArray1[0] = 07B;
            this.Write("/{0} ", objArray1);
            this.6H(07C, true);
            this.Write("\r\n", new object[0]);
        }

        internal void 6A(string 07E, long 07F)
        {
            this.68(07E, 07F.ToString());
        }

        internal void 6B()
        {
            this.Write(">>\r\n", new object[0]);
        }

        internal void 6C(byte[] 07G)
        {
            this.OD.Flush();
            this.OD.BaseStream.Write(07G, 0, 07G.Length);
        }

        internal void 6D(string 07H)
        {
        }

        internal void 6E(int 07I, byte[] 07J)
        {
            this.Write("stream\r\n", new object[0]);
            this.O3.A0(07I, 07J);
            this.6C(07J);
            this.Write("endstream\r\n", new object[0]);
        }

        internal void 6F(string 07K)
        {
            this.6H(07K, false);
        }

        private byte[] 6G(string 07L)
        {
            if ((07L == null) || (07L.Length == 0))
            {
                return new byte[0];
            }
            if ((this.OO != -1) && (this.XM || this.XL))
            {
                return this.O5[this.OO].7K(07L, this.XL);
            }
            return Encoding.Default.GetBytes(07L);
        }

        internal void 6H(string 07M, bool 07N)
        {
            byte[] numArray1;
            bool flag1;
            int num1;
            char ch1;
            int num2;
            int num3;
            char ch2;
            char ch3;
            CharEnumerator enumerator1;
            object[] objArray1;
            if ((07M == null) || (07M.Length == 0))
            {
                return;
            }
            if (!07N)
            {
                numArray1 = this.6G(07M);
            }
            else
            {
                flag1 = false;
                for (num1 = 0; (num1 < 07M.Length); num1 += 1)
                {
                    ch1 = 07M[num1];
                    if (ch1 > '\u0100')
                    {
                        flag1 = true;
                        break;
                    }
                }
                if (!flag1)
                {
                    numArray1 = Encoding.Default.GetBytes(07M);
                }
                else
                {
                    num2 = 0;
                    numArray1 = new byte[((uint) ((2 * 07M.Length) + 2))];
                    int num4 = num2;
                    num2 = (num4 + 1);
                    numArray1[num2] = 254;
                    int num5 = num2;
                    num2 = (num5 + 1);
                    numArray1[num2] = 255;
                    for (num3 = 0; (num3 < 07M.Length); num3 += 1)
                    {
                        ch2 = 07M[num3];
                        int num6 = num2;
                        num2 = (num6 + 1);
                        numArray1[num2] = ((byte) (ch2 >> '\b'));
                        int num7 = num2;
                        num2 = (num7 + 1);
                        numArray1[num2] = ((byte) (ch2 & '\u00ff'));
                    }
                }
                this.O3.A0(this.GetCurrentID(), numArray1);
                if (!flag1 && (07M.Length != numArray1.Length))
                {
                    this.Write("<FEFF", new object[0]);
                    enumerator1 = Encoding.Default.GetString(numArray1).GetEnumerator();
                    while (enumerator1.MoveNext())
                    {
                        ch3 = enumerator1.Current;
                        objArray1 = new object[1];
                        objArray1[0] = ch3;
                        this.Write("{0:X4}", objArray1);
                    }
                    this.Write(">", new object[0]);
                    return;
                }
            }
            this.6I(numArray1);
        }

        private void 6I(byte[] 07O)
        {
            if ((07O == null) || (07O.Length == 0))
            {
                return;
            }
            this.OD.Write('(');
            this.6J(07O);
            this.OD.Write(')');
        }

        private void 6J(byte[] 07P)
        {
            byte num1;
            char ch1;
            this.OD.Flush();
            byte[] numArray1 = 07P;
            int num2 = 0;
            while ((num2 < numArray1.Length))
            {
                num1 = numArray1[num2];
                ch1 = ((char) ((ushort) num1));
                if (ch1 == '\r')
                {
                    goto Label_005B;
                }
                switch (ch1)
                {
                    case '(':
                    case ')':
                    {
                        goto Label_0036;
                    }
                }
                if (ch1 != '\\')
                {
                    goto Label_0081;
                }
            Label_0036:
                this.OD.BaseStream.WriteByte(92);
                this.OD.BaseStream.WriteByte(num1);
                goto Label_0092;
            Label_005B:
                this.OD.BaseStream.WriteByte(92);
                this.OD.BaseStream.WriteByte(114);
                goto Label_0092;
            Label_0081:
                this.OD.BaseStream.WriteByte(num1);
            Label_0092:
                num2 += 1;
            }
        }

        internal string 6K(int 07Q)
        {
            return string.Format("{0} 0 R", 07Q);
        }

        internal string 6L(double 07R)
        {
            return this.6M(07R, false);
        }

        internal string 6M(double 07S, bool 07T)
        {
            char[] chArray1;
            string text1 = (07T ? "{0:F06}" : "{0:F02}");
            object[] objArray1 = new object[1];
            objArray1[0] = 07S;
            string text2 = string.Format(CultureInfo.InvariantCulture, text1, objArray1);
            if (text2.IndexOf('.') > -1)
            {
                chArray1 = new char[1];
                chArray1[0] = '0';
                text2 = text2.TrimEnd(chArray1);
            }
            if (text2.EndsWith("."))
            {
                text2 = text2.Substring(0, (text2.Length - 1));
            }
            return text2;
        }

        internal string 6N(Color 07U)
        {
            return string.Format("{0} {1} {2}", this.6L(((double) (((float) 07U.R) / 255f))), this.6L(((double) (((float) 07U.G) / 255f))), this.6L(((double) (((float) 07U.B) / 255f))));
        }

        protected void BeginPathInternal()
        {
            if (this.XN == 07.OU)
            {
                this.Write("n ", new object[0]);
                this.XN = 07.OR;
            }
            if (this.XN != 07.OR)
            {
                this.EndPathInternal();
            }
            this.XN = 07.OS;
        }

        public void Clear()
        {
            this.EndPage();
            this.XN = 07.OR;
            string text1 = null;
            this.OJ = text1;
            text1 = text1;
            this.OI = text1;
            this.OH = text1;
            this.OK = null;
            this.OL = null;
            this.OM = null;
            this.O2 = new PdfDocumentInfo(this);
            this.O4 = new PdfPageCollection(this);
            this.O5 = new 09(this);
            this.O6 = new 0G(this);
            this.O7 = new 05(this);
            this.OB = new 0O(this);
            this.O3 = new PdfSecurity(this);
            this.O8 = new 01(this);
            this.O9 = new 01(this);
            this.OA = new 01(this);
            this.StartPage();
        }

        protected void CurveTo(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            object[] objArray1 = new object[6];
            objArray1[0] = this.6L(((double) x1));
            objArray1[1] = this.6L(((double) y1));
            objArray1[2] = this.6L(((double) x2));
            objArray1[3] = this.6L(((double) y2));
            objArray1[4] = this.6L(((double) x3));
            objArray1[5] = this.6L(((double) y3));
            this.Write("{0} {1} {2} {3} {4} {5} c\r\n", objArray1);
        }

        protected void Ellipse(RectangleF rc)
        {
            float single1 = ((rc.Left + rc.Right) / 2f);
            float single2 = ((rc.Top + rc.Bottom) / 2f);
            float single3 = ((rc.Right - rc.Left) / 2f);
            float single4 = ((rc.Bottom - rc.Top) / 2f);
            this.MoveTo((single1 + single3), single2);
            this.CurveTo((single1 + single3), (single2 + (single4 * 0.5523f)), (single1 + (single3 * 0.5523f)), (single2 + single4), single1, (single2 + single4));
            this.CurveTo((single1 - (single3 * 0.5523f)), (single2 + single4), (single1 - single3), (single2 + (single4 * 0.5523f)), (single1 - single3), single2);
            this.CurveTo((single1 - single3), (single2 - (single4 * 0.5523f)), (single1 - (single3 * 0.5523f)), (single2 - single4), single1, (single2 - single4));
            this.CurveTo((single1 + (single3 * 0.5523f)), (single2 - single4), (single1 + single3), (single2 - (single4 * 0.5523f)), (single1 + single3), single2);
        }

        protected virtual void EndPage()
        {
            if ((this.ON < 0) || (this.OD == null))
            {
                return;
            }
            PdfPage page1 = this.O4[this.ON];
            page1.UU = this.OC;
            this.OD.Close();
            this.OD = null;
            this.ON = -1;
        }

        protected void EndPathInternal()
        {
            this.XN;
            this.XN = 07.OU;
        }

        protected void FillStrokeInternal(bool close, bool fill, bool stroke, FillMode mode)
        {
            if ((this.XN == 07.OS) || (this.XN == 07.OT))
            {
                return;
            }
            if (close)
            {
                if (fill && stroke)
                {
                    this.Write("b", new object[0]);
                }
                else if (stroke)
                {
                    this.Write("s", new object[0]);
                }
                else if (fill)
                {
                    this.Write("f", new object[0]);
                }
            }
            else if (fill && stroke)
            {
                this.Write("B", new object[0]);
            }
            else if (stroke)
            {
                this.Write("S", new object[0]);
            }
            else if (fill)
            {
                this.Write("f", new object[0]);
            }
            if (fill && (mode == FillMode.Alternate))
            {
                this.Write("*", new object[0]);
            }
            this.Write("\r\n", new object[0]);
            this.XN = 07.OR;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Assembly GetCallingAssembly()
        {
            return null;
        }

        protected int GetCurrentID()
        {
            return this.OB.UM;
        }

        protected int GetNewID()
        {
            0O o1 = this.OB;
            return (o1.UM + 1);
        }

        protected long GetStreamPosition()
        {
            this.OD.Flush();
            return this.OD.BaseStream.Position;
        }

        protected static bool IsUnicodeText(string text)
        {
            int num1;
            if (text == null)
            {
                return false;
            }
            for (num1 = 0; (num1 < text.Length); num1 += 1)
            {
                if (text[num1] > '\u00ff')
                {
                    return true;
                }
            }
            return false;
        }

        protected void LineTo(float x, float y)
        {
            object[] objArray1 = new object[2];
            objArray1[0] = this.6L(((double) x));
            objArray1[1] = this.6L(((double) y));
            this.Write("{0} {1} l\r\n", objArray1);
            this.XN = 07.OT;
        }

        protected SizeF MeasureText(string text)
        {
            return C1PdfDocumentBase.MeasureText(text, this.OK);
        }

        protected static SizeF MeasureText(string text, Font font)
        {
            SizeF ef1 = SizeF.Empty;
            if (font == null)
            {
                return ef1;
            }
            using (Graphics graphics1 = Graphics.FromImage(C1PdfDocumentBase.OQ))
            {
                graphics1.PageUnit = GraphicsUnit.Point;
                ef1 = graphics1.MeasureString(text, font);
                SizeF* efPtr1 = &ef1;
                ef1.Width = (efPtr1.Width * 0.96f);
                SizeF* efPtr2 = &ef1;
                ef1.Height = (efPtr2.Height * 0.96f);
                return ef1;
            }
            return ef1;
        }

        protected void MoveTo(float x, float y)
        {
            object[] objArray1;
            if (this.XN == 07.OT)
            {
                objArray1 = new object[2];
                objArray1[0] = this.6L(((double) x));
                objArray1[1] = this.6L(((double) y));
                this.Write("{0} {1} l\r\n", objArray1);
            }
            else
            {
                objArray1 = new object[2];
                objArray1[0] = this.6L(((double) x));
                objArray1[1] = this.6L(((double) y));
                this.Write("{0} {1} m\r\n", objArray1);
            }
            this.XN = 07.OT;
        }

        [E("Bookmarks", "Gets the collection of PdfBookmark objects that make up the document outline."), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public void NewPage()
        {
            this.EndPage();
            this.StartPage();
        }

        protected void PieArc(RectangleF rc, float startAngle, float sweepAngle, bool close)
        {
            this.PieArc(rc, startAngle, sweepAngle, close, true);
        }

        protected void PieArc(RectangleF rc, float startAngle, float sweepAngle, bool close, bool clockwise)
        {
            float single6;
            float single8;
            float single1 = ((rc.Left + rc.Right) / 2f);
            float single2 = ((rc.Top + rc.Bottom) / 2f);
            float single3 = (rc.Width / 2f);
            float single4 = (rc.Height / 2f);
            startAngle = ((float) (((double) (startAngle / 180f)) * 3.1415926535897931f));
            sweepAngle = ((float) (((double) (sweepAngle / 180f)) * 3.1415926535897931f));
            float single5 = (startAngle + sweepAngle);
            if (single5 < startAngle)
            {
                single6 = startAngle;
                startAngle = single5;
                single5 = single6;
            }
            float single7 = ((float) (clockwise ? -1 : 1));
            if (close)
            {
                this.MoveTo(single1, single2);
            }
            else
            {
                this.MoveTo((single1 + ((float) (((double) single3) * Math.Cos(((double) startAngle))))), (single2 + ((float) ((((double) single4) * Math.Sin(((double) startAngle))) * ((double) single7)))));
            }
            bool flag1 = false;
            for (single8 = startAngle; !flag1; single8 += 0.1047198f)
            {
                if (single8 > single5)
                {
                    single8 = single5;
                    flag1 = true;
                }
                this.LineTo((single1 + ((float) (((double) single3) * Math.Cos(((double) single8))))), (single2 + ((float) ((((double) single4) * Math.Sin(((double) single8))) * ((double) single7)))));
            }
            if (close)
            {
                this.LineTo(single1, single2);
            }
            this.XN = 07.OT;
        }

        protected void Polygon(PointF[] points)
        {
            int num1;
            this.MoveTo(points[0].X, points[0].Y);
            for (num1 = 1; (num1 < points.Length); num1 += 1)
            {
                this.LineTo(points[num1].X, points[num1].Y);
            }
        }

        protected void Rectangle(RectangleF rc)
        {
            object[] objArray1 = new object[4];
            objArray1[0] = this.6L(((double) rc.X));
            objArray1[1] = this.6L(((double) rc.Y));
            objArray1[2] = this.6L(((double) rc.Width));
            objArray1[3] = this.6L(((double) rc.Height));
            this.Write("{0} {1} {2} {3} re ", objArray1);
            this.XN = 07.OT;
        }

        protected void RoundRect(RectangleF rc, SizeF sz)
        {
            this.MoveTo(rc.X, (rc.Y + sz.Height));
            this.CurveTo(rc.X, (rc.Y + sz.Height), rc.X, rc.Y, (rc.X + sz.Width), rc.Y);
            this.LineTo((rc.Right - sz.Width), rc.Y);
            this.CurveTo((rc.Right - sz.Width), rc.Y, rc.Right, rc.Y, rc.Right, (rc.Y + sz.Height));
            this.LineTo(rc.Right, (rc.Bottom - sz.Height));
            this.CurveTo(rc.Right, (rc.Bottom - sz.Height), rc.Right, rc.Bottom, (rc.Right - sz.Width), rc.Bottom);
            this.LineTo((rc.X + sz.Width), rc.Bottom);
            this.CurveTo((rc.X + sz.Width), rc.Bottom, rc.X, rc.Bottom, rc.X, (rc.Bottom - sz.Height));
        }

        public void Save(Stream stream)
        {
            this.EndPage();
            this.OD = new StreamWriter(stream);
            this.Write("%PDF-1.3\r\n", new object[0]);
            object[] objArray1 = new object[4];
            objArray1[0] = 200;
            objArray1[1] = 201;
            objArray1[2] = 202;
            objArray1[3] = 203;
            this.Write("%{0}{1}{2}{3}\r\n", objArray1);
            this.O3.9Z();
            this.O2.7A();
            this.O8.5V();
            this.O9.5V();
            this.OA.5V();
            foreach (PdfPage page1 in this.O4)
            {
                page1.9S(this);
            }
            foreach (0A a1 in this.O5)
            {
                a1.7C(this);
            }
            foreach (0H h1 in this.O6)
            {
                h1.7T(this);
            }
            foreach (0K k1 in this.O8)
            {
                k1.86(this);
            }
            foreach (03 1 in this.OA)
            {
                1.5W(this);
            }
            this.O4.9P();
            this.65("Resources");
            this.67();
            objArray1 = new object[1];
            objArray1[0] = ((this.O6.Count > 0) ? "/ImageC" : string.Empty);
            this.Write("/ProcSet [/PDF/Text{0}]\r\n", objArray1);
            this.O5.7B();
            this.O6.7S();
            this.6B();
            this.66();
            foreach (PdfPage page2 in this.O4)
            {
                page2.9T(this);
            }
            this.O7.5Y();
            this.O3.A1();
            int num1 = this.65("Root object");
            this.67();
            this.68("Type", "/Catalog");
            this.68("Pages", this.6K(this.O4.UQ));
            if (this.O7.Count > 0)
            {
                this.68("Outlines", this.6K(this.O7.NS));
                this.68("PageMode", "/UseOutlines");
            }
            this.6B();
            this.66();
            long num2 = this.GetStreamPosition();
            this.Write("xref\r\n", new object[0]);
            objArray1 = new object[1];
            objArray1[0] = (this.GetCurrentID() + 1);
            this.Write("0 {0}\r\n", objArray1);
            this.Write("0000000000 65535 f\r\n", new object[0]);
            foreach (0P p1 in this.OB)
            {
                objArray1 = new object[1];
                objArray1[0] = p1.UO;
                this.Write("{0:D10} 00000 n\r\n", objArray1);
            }
            this.Write("trailer\r\n", new object[0]);
            this.67();
            this.6A("Size", ((long) (this.GetCurrentID() + 1)));
            this.68("Info", this.6K(1));
            this.68("Root", this.6K(num1));
            this.O3.A2();
            this.6B();
            this.Write("startxref\r\n", new object[0]);
            objArray1 = new object[1];
            objArray1[0] = num2;
            this.Write("{0}\r\n", objArray1);
            this.Write("%%EOF\r\n", new object[0]);
            this.OD.Flush();
            this.OD = null;
        }

        public void Save(string fileName)
        {
            FileStream stream1 = new FileStream(fileName, FileMode.Create);
            this.Save(stream1);
            stream1.Close();
        }

        protected void SetBrush(Brush brush)
        {
            this.OM = (brush as SolidBrush);
            if (brush == null)
            {
                return;
            }
            this.OJ = string.Format("{0} rg\r\n", this.6N(this.OM.Color));
        }

        protected void SetFont(Font font)
        {
            this.SetFont(font, null);
        }

        protected void SetFont(Font font, string text)
        {
            this.OK = font;
            if (font == null)
            {
                return;
            }
            0A a1 = null;
            int num1 = -1;
            foreach (0A a2 in this.O5)
            {
                if (!a2.7I(font))
                {
                    continue;
                }
                if ((((a2.PR != null) && a2.PR.N9) && (!a2.PR.NA && (text != null))) && C1PdfDocumentBase.IsUnicodeText(text))
                {
                    a2.PM = true;
                    break;
                }
                a1 = a2;
                num1 = this.O5.IndexOf(a2);
                break;
            }
        Label_0097:
            if (a1 == null)
            {
                a1 = new 0A(font);
                num1 = this.O5.Add(a1);
            }
            if (((this.OE == FontTypeEnum.Standard) || (font.Name.Length == 0)) && (a1 != null))
            {
                num1 = a1.7H();
            }
            if (num1 < 0)
            {
                throw new ApplicationException("Failed to set font.");
            }
            this.OH = string.Format("/F{0} {1} Tf\r\n", num1, this.6L(((double) this.OK.Size)));
            this.O5[num1].PL = true;
            this.OO = num1;
        }

        protected void SetPen(Pen pen)
        {
            object[] objArray1;
            this.OL = pen;
            if (pen == null)
            {
                return;
            }
            float single1 = Math.Max(0.05f, pen.Width);
            string text1 = this.6L(((double) single1));
            string text2 = this.6L(((double) single1));
            string text3 = this.6L(((double) (single1 * 2f)));
            string text4 = this.6L(((double) (single1 * 12f)));
            DashStyle style1 = pen.DashStyle;
            switch (style1)
            {
                case DashStyle.Solid:
                {
                    goto Label_014F;
                }
                case DashStyle.Dash:
                {
                    this.OI = string.Format("{0} RG {1} w [{2} {2}] 0 d\r\n", this.6N(pen.Color), text1, text4);
                    return;
                }
                case DashStyle.Dot:
                {
                    objArray1 = new object[4];
                    objArray1[0] = this.6N(pen.Color);
                    objArray1[1] = text1;
                    objArray1[2] = text2;
                    objArray1[3] = text3;
                    this.OI = string.Format("{0} RG {1} w [{2} {3}] 0 d\r\n", objArray1);
                    return;
                }
                case DashStyle.DashDot:
                {
                    objArray1 = new object[5];
                    objArray1[0] = this.6N(pen.Color);
                    objArray1[1] = text1;
                    objArray1[2] = text4;
                    objArray1[3] = text3;
                    objArray1[4] = text2;
                    this.OI = string.Format("{0} RG {1} w [{2} {3} {4} {3}] 0 d\r\n", objArray1);
                    return;
                }
                case DashStyle.DashDotDot:
                {
                    objArray1 = new object[5];
                    objArray1[0] = this.6N(pen.Color);
                    objArray1[1] = text1;
                    objArray1[2] = text4;
                    objArray1[3] = text3;
                    objArray1[4] = text2;
                    this.OI = string.Format("{0} RG {1} w [{2} {3} {4} {3} {4} {3}] 0 d\r\n", objArray1);
                    return;
                }
            }
        Label_014F:
            this.OI = string.Format("{0} RG {1} w [] 0 d\r\n", this.6N(pen.Color), text1);
        }

        protected virtual void StartOverlay(int pageIndex)
        {
            this.EndPage();
            this.ON = pageIndex;
            PdfPage page1 = this.O4[pageIndex];
            this.OD = page1.9R(this.OG);
        }

        protected virtual void StartPage()
        {
            this.ON = this.O4.Count;
            PdfPage page1 = new PdfPage(this.OC);
            this.O4.Add(page1);
            this.OD = page1.9Q(this.OG);
        }

        protected void TextOut(string text, PointF pt, StringAlignment align, bool baseLine)
        {
            double num1;
            string text1;
            string text2;
            object[] objArray1;
            if ((text == null) || (text.Length == 0))
            {
                return;
            }
            this.UpdateResources(typeof(Font));
            if (align == StringAlignment.Near)
            {
                goto Label_0080;
            }
            text = text.Trim();
            if (text.Length == 0)
            {
                return;
            }
            SizeF ef1 = this.MeasureText(text);
            StringAlignment alignment1 = align;
            switch (alignment1)
            {
                case StringAlignment.Center:
                {
                    goto Label_0065;
                }
                case StringAlignment.Far:
                {
                    PointF* tfPtr1 = &pt;
                    pt.X = (tfPtr1.X - ef1.Width);
                    goto Label_0080;
                }
            }
            goto Label_0080;
        Label_0065:
            PointF* tfPtr2 = &pt;
            pt.X = (tfPtr2.X - (ef1.Width / 2f));
        Label_0080:
            if (!baseLine)
            {
                PointF* tfPtr3 = &pt;
                pt.Y = (tfPtr3.Y - this.OK.Size);
            }
            byte[] numArray1 = this.6G(text);
            if (((this.OK != null) && (this.OO != -1)) && this.O5[this.OO].XW)
            {
                objArray1 = new object[3];
                objArray1[0] = this.6L(0.21f);
                objArray1[1] = this.6L((((double) pt.X) + (((double) this.OK.Size) * 0.21f)));
                objArray1[2] = this.6L(((double) pt.Y));
                this.Write("BT 1 0 {0} 1 {1} {2} Tm ", objArray1);
            }
            else
            {
                objArray1 = new object[2];
                objArray1[0] = this.6L(((double) pt.X));
                objArray1[1] = this.6L(((double) pt.Y));
                this.Write("BT {0} {1} Td ", objArray1);
            }
            this.6I(numArray1);
            if (((this.OK != null) && (this.OO != -1)) && this.O5[this.OO].XV)
            {
                this.Write(" Tj\r\n", new object[0]);
                num1 = (((double) this.OK.Size) * 0.028f);
                text1 = this.6L(num1);
                text2 = this.6L(-num1);
                if (!text1.Equals("0"))
                {
                    text1 = this.6M(num1, true);
                    text2 = this.6M(-num1, true);
                }
                objArray1 = new object[2];
                objArray1[0] = text1;
                objArray1[1] = "0";
                this.Write("{0} {1} TD ", objArray1);
                this.6I(numArray1);
                this.Write(" Tj\r\n", new object[0]);
                objArray1 = new object[2];
                objArray1[0] = text2;
                objArray1[1] = text2;
                this.Write("{0} {1} TD ", objArray1);
                this.6I(numArray1);
                this.Write(" Tj\r\n", new object[0]);
                objArray1 = new object[2];
                objArray1[0] = text1;
                objArray1[1] = "0";
                this.Write("{0} {1} TD ", objArray1);
                this.6I(numArray1);
            }
            this.Write(" Tj ET\r\n", new object[0]);
            if ((this.OK == null) || (!this.OK.Underline && !this.OK.Strikeout))
            {
                return;
            }
            SizeF ef2 = this.MeasureText(text);
            float single1 = ef2.Width;
            float single2 = (this.OK.Size / 20f);
            if (this.OK.Underline)
            {
                objArray1 = new object[4];
                objArray1[0] = this.6L(((double) pt.X));
                objArray1[1] = this.6L(((double) (pt.Y - (2f * single2))));
                objArray1[2] = this.6L(((double) single1));
                objArray1[3] = this.6L(((double) -single2));
                this.Write("{0} {1} {2} {3} re f\r\n", objArray1);
            }
            if (this.OK.Strikeout)
            {
                objArray1 = new object[4];
                objArray1[0] = this.6L(((double) pt.X));
                objArray1[1] = this.6L(((double) (pt.Y + (this.OK.Size * 0.3f))));
                objArray1[2] = this.6L(((double) single1));
                objArray1[3] = this.6L(((double) -single2));
                this.Write("{0} {1} {2} {3} re f\r\n", objArray1);
            }
        }

        protected void UpdateResources(object res)
        {
            if (this.XN != 07.OR)
            {
                return;
            }
            if ((res is Pen))
            {
                if ((this.OI != null) && (this.OI.Length > 0))
                {
                    this.Write(this.OI, new object[0]);
                }
                this.OI = string.Empty;
                return;
            }
            if ((res is Brush))
            {
                if ((this.OJ != null) && (this.OJ.Length > 0))
                {
                    this.Write(this.OJ, new object[0]);
                }
                this.OJ = string.Empty;
                return;
            }
            if ((this.OI != null) && (this.OI.Length > 0))
            {
                this.Write(this.OI, new object[0]);
            }
            if ((this.OH != null) && (this.OH.Length > 0))
            {
                this.Write(this.OH, new object[0]);
            }
            if ((this.OJ != null) && (this.OJ.Length > 0))
            {
                this.Write(this.OJ, new object[0]);
            }
            string text1 = string.Empty;
            this.OJ = text1;
            text1 = text1;
            this.OH = text1;
            this.OI = text1;
        }

        public void Write(string format, params object[] args)
        {
            this.OD.Write(format, args);
        }


        // Properties
        [E("Compression", "Gets or sets the level of compression to use when saving the document."), DefaultValue(-1)]
        public CompressionEnum Compression
        {
            get
            {
                return this.OG;
            }
            set
            {
                this.OG = value;
                if (this.CurrentPage > -1)
                {
                    this.StartOverlay(this.CurrentPage);
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentPage
        {
            get
            {
                return this.ON;
            }
            set
            {
                if (value == this.ON)
                {
                    return;
                }
                this.EndPage();
                if (value < 0)
                {
                    return;
                }
                if (value < this.O4.Count)
                {
                    this.StartOverlay(value);
                }
                while ((this.ON < value))
                {
                    this.NewPage();
                }
                PdfPage page1 = this.Pages[this.CurrentPage];
                this.OC = page1.UU;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), TypeConverter(typeof(ExpandableObjectConverter)), E("DocumentInfo", "Gets the object that contains information about this document (author, etc).")]
        public PdfDocumentInfo DocumentInfo
        {
            get
            {
                return this.O2;
            }
        }

        [DefaultValue(1), E("FontType", "Gets or sets the type of font that should be saved with the document.")]
        public FontTypeEnum FontType
        {
            get
            {
                return this.OE;
            }
            set
            {
                this.OE = value;
            }
        }

        [DefaultValue(2), E("ImageQuality", "Gets or sets the image quality to use when saving the document.")]
        public ImageQualityEnum ImageQuality
        {
            get
            {
                return this.OF;
            }
            set
            {
                this.OF = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual RectangleF PageRectangle
        {
            get
            {
                return new RectangleF(PointF.Empty, this.OC);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), E("Pages", "Gets the collection of PdfPage objects that make up the document.")]
        public PdfPageCollection Pages
        {
            get
            {
                return this.O4;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual SizeF PageSize
        {
            get
            {
                return this.OC;
            }
            set
            {
                this.OC = value;
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter)), E("Security", "Gets the object that manages security for this document (passwords, etc)."), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PdfSecurity Security
        {
            get
            {
                return this.O3;
            }
        }

        internal bool XL
        {
            get
            {
                return (this.OE == FontTypeEnum.Embedded);
            }
        }

        internal bool XM
        {
            get
            {
                return true;
            }
        }

        private 07 XN
        {
            get
            {
                return this.OP;
            }
            set
            {
                if ((this.OP == 07.OR) && (073 == 07.OT))
                {
                    return;
                }
                if (this.OP != 073)
                {
                    this.OP = 073;
                }
            }
        }


        // Fields
        internal PdfDocumentInfo O2;
        internal PdfSecurity O3;
        internal PdfPageCollection O4;
        internal 09 O5;
        internal 0G O6;
        internal 05 O7;
        internal 01 O8;
        internal 01 O9;
        internal 01 OA;
        internal 0O OB;
        internal SizeF OC;
        internal StreamWriter OD;
        internal FontTypeEnum OE;
        internal ImageQualityEnum OF;
        internal CompressionEnum OG;
        internal string OH;
        internal string OI;
        internal string OJ;
        internal Font OK;
        internal Pen OL;
        internal SolidBrush OM;
        internal int ON;
        internal int OO;
        private 07 OP;
        private static Bitmap OQ;

        // Nested Types
        private enum 07
        {
            // Fields
            OR = 0,
            OS = 1,
            OT = 2,
            OU = 3
        }
    }
}


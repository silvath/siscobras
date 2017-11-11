namespace C1.C1Pdf
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Text;

    internal class 0A // Fonte
    {
        // Methods
        static 0A()
        {
            0A.PI = new Bitmap(1, 1);
            string[] textArray1 = new string[5];
            textArray1[0] = "/WinAnsiEncoding";
            textArray1[1] = "/90ms-RKSJ-H";
            textArray1[2] = "/90ms-RKSJ-V";
            textArray1[3] = "/90msp-RKSJ-H";
            textArray1[4] = "/90msp-RKSJ-V";
            0A.PJ = textArray1;
        }

        internal 0A(Font font)
        {
            float single1;
            Font font1;
            IntPtr ptr1;
            IntPtr ptr2;
            IntPtr ptr3;
            0B b1;
            Size size1;
            StringBuilder builder1;
            int num1;
            bool flag1;
            int num2;
            this.PK = font;
            this.PL = false;
            this.PM = false;
            this.PO = this.7E();
            this.PS.QR = 212;
            using (Graphics graphics1 = Graphics.FromImage(0A.PI))
            {
                single1 = (72000f / graphics1.DpiX);
                font1 = new Font(font.Name, single1, font.Style, GraphicsUnit.Point);
                ptr1 = graphics1.GetHdc();
                ptr2 = font1.ToHfont();
                ptr3 = 0A.7N(ptr1, ptr2);
                if (0A.7M(ptr1, 212, ref this.PS) != 0)
                {
                    b1 = this.PS.QS;
                    this.PP = new int[((uint) ((b1.Q5 - b1.Q4) + 1))];
                    if (Environment.OSVersion.Platform >= PlatformID.Win32NT)
                    {
                        0A.7Q(ptr1, b1.Q4, b1.Q5, this.PP);
                    }
                    else
                    {
                        size1 = Size.Empty;
                        builder1 = new StringBuilder();
                        for (num1 = 0; (num1 < this.PP.Length); num1 += 1)
                        {
                            builder1.Length = 0;
                            builder1.Append(((ushort) (b1.Q4 + num1)));
                            0A.7R(ptr1, builder1.ToString(), 1, ref size1);
                            this.PP[num1] = size1.Width;
                        }
                    }
                }
                flag1 = ((this.PS.QW & 1) == 0);
                if (flag1)
                {
                    num2 = 0A.7P(ptr1, 0, 0, null, 0);
                    this.PQ = new byte[((uint) num2)];
                    0A.7P(ptr1, 0, 0, this.PQ, num2);
                    this.PR = new Y(this);
                }
                0A.7N(ptr1, ptr3);
                0A.7O(ptr2);
                graphics1.ReleaseHdc(ptr1);
                font1.Dispose();
            }
        }

        internal 0A(string faceName)
        {
            this.PO = faceName;
            this.PL = false;
            this.PM = false;
        }

        internal void 7C(C1PdfDocumentBase 09D)
        {
            StringBuilder builder1;
            int num5;
            int num6;
            if (!this.PL)
            {
                return;
            }
            int num1 = 09D.O5.IndexOf(this);
            if (this.PK == null)
            {
                this.PN = 09D.65("Font object");
                09D.67();
                09D.68("Type", "/Font");
                09D.68("Subtype", "/Type1");
                09D.68("Name", string.Format("/F{0}", num1));
                09D.68("BaseFont", this.PO);
                if ((num1 == 12) || (num1 == 13))
                {
                    09D.68("Flags", "4");
                }
                else
                {
                    09D.68("Encoding", "/WinAnsiEncoding");
                }
                09D.6B();
                09D.66();
                return;
            }
            if (((this.PR != null) && this.PR.NA) && this.PR.5D(09D))
            {
                return;
            }
            int num2 = 09D.65("FontDescriptor");
            09D.67();
            09D.68("Type", "/FontDescriptor");
            09D.68("FontName", this.7E());
            09D.6A("Flags", ((long) this.7F()));
            09D.68("FontBBox", this.7G());
            09D.6A("MissingWidth", ((long) this.PS.QS.PY));
            09D.6A("StemV", ((long) (this.PK.Bold ? 144 : 72)));
            09D.6A("StemH", ((long) (this.PK.Bold ? 144 : 72)));
            09D.6A("ItalicAngle", ((long) (this.PK.Italic ? (this.PS.QZ / 10) : 0)));
            09D.6A("CapHeight", ((long) this.PS.R4));
            09D.6A("XHeight", ((long) this.PS.R5));
            09D.6A("Ascent", ((long) this.PS.R1));
            09D.6A("Descent", ((long) this.PS.R2));
            09D.6A("Leading", ((long) this.PS.QS.PX));
            09D.6A("MaxWidth", ((long) this.PS.QS.PZ));
            09D.6A("AvgWidth", ((long) this.PS.QS.PY));
            if (this.PK.GdiCharSet == 128)
            {
                09D.Write("/Style ", new object[0]);
                09D.67();
                builder1 = new StringBuilder("<0801");
                builder1.Append(this.PS.QU.QH.ToString("X2"));
                builder1.Append(this.PS.QU.QI.ToString("X2"));
                builder1.Append(this.PS.QU.QJ.ToString("X2"));
                builder1.Append(((this.PS.QU.QK == 9) ? "00" : "01"));
                builder1.Append("000000000000>");
                09D.68("Panose", builder1.ToString());
                09D.6B();
            }
            09D.6B();
            09D.66();
            int num3 = ((int) this.PS.QS.Q4);
            int num4 = ((int) this.PS.QS.Q5);
            if (this.XQ)
            {
                num4 = num3;
            }
            if (this.PK.GdiCharSet == 128)
            {
                num5 = 09D.65("Font " + this.PO);
                09D.67();
                09D.68("Type", "/Font");
                09D.68("Subtype", "/CIDFontType2");
                09D.68("BaseFont", this.PO);
                09D.6A("WinCharSet", ((long) 128));
                09D.68("FontDescriptor", string.Format("{0} 0 R", num2));
                09D.Write("/CIDSystemInfo ", new object[0]);
                09D.67();
                09D.68("Registry", "(Adobe)");
                09D.68("Ordering", "(Japan1)");
                09D.6A("Supplement", ((long) 2));
                09D.6B();
                09D.6A("DW", ((long) (this.PS.R6.QD + this.PS.R6.QF)));
                09D.68("W", this.7L());
                09D.6B();
                09D.66();
                num6 = ((this.XQ ? 1 : 3) + (this.PK.GdiVerticalFont ? 1 : 0));
                this.PN = 09D.65("Font " + this.PO + "_2");
                09D.67();
                09D.68("Type", "/Font");
                09D.68("Subtype", "/Type0");
                09D.68("BaseFont", this.PO);
                09D.68("DescendantFonts", string.Format("[{0}]", 09D.6K(num5)));
                09D.68("Encoding", 0A.PJ[num6]);
                09D.6B();
                09D.66();
                return;
            }
            this.PN = 09D.65("Font " + this.PO);
            09D.67();
            09D.68("Type", "/Font");
            09D.68("Subtype", "/TrueType");
            09D.68("BaseFont", this.PO);
            if (this.PK.Name != "Symbol")
            {
                09D.68("Encoding", "/WinAnsiEncoding");
            }
            09D.68("FontDescriptor", 09D.6K(num2));
            09D.6A("FirstChar", ((long) num3));
            09D.6A("LastChar", ((long) num4));
            09D.68("Widths", this.7J((num3 == num4)));
            09D.6B();
            09D.66();
        }

        private static string 7D(string 09E)
        {
            byte num1;
            int num2;
            StringBuilder builder1 = new StringBuilder();
            byte[] numArray1 = Encoding.Default.GetBytes(09E);
            for (num2 = 0; (num2 < numArray1.Length); num2 += 1)
            {
                num1 = numArray1[num2];
                if ((((num1 >= 48) && (num1 <= 57)) || ((num1 >= 97) && (num1 <= 122))) || ((num1 >= 65) && (num1 <= 90)))
                {
                    builder1.Append(((ushort) num1));
                }
                else
                {
                    builder1.AppendFormat("#{0:X2}", num1);
                }
            }
            return builder1.ToString();
        }

        internal string 7E()
        {
            StringBuilder builder1 = new StringBuilder("/");
            builder1.Append(0A.7D(this.PK.Name));
            if (this.PK.Bold && this.PK.Italic)
            {
                builder1.Append(",BoldItalic");
            }
            else if (this.PK.Bold)
            {
                builder1.Append(",Bold");
            }
            else if (this.PK.Italic)
            {
                builder1.Append(",Italic");
            }
            return builder1.ToString();
        }

        internal int 7F()
        {
            int num1 = 0;
            if (this.XQ)
            {
                num1 |= 1;
            }
            if (!this.XS)
            {
                num1 |= 2;
            }
            if (this.XP)
            {
                num1 |= 4;
            }
            if (this.XR)
            {
                num1 |= 8;
            }
            if (!this.XP)
            {
                num1 |= 32;
            }
            if (this.PK.Italic)
            {
                num1 |= 64;
            }
            return num1;
        }

        internal string 7G()
        {
            int num1 = this.PS.R6.QD;
            int num2 = this.PS.R6.QF;
            int num3 = this.PS.R6.QE;
            int num4 = this.PS.R6.QG;
            object[] objArray1 = new object[4];
            objArray1[0] = Math.Min(num1, num2);
            objArray1[1] = Math.Min(num3, num4);
            objArray1[2] = Math.Max(num1, num2);
            objArray1[3] = Math.Max(num3, num4);
            return string.Format("[{0} {1} {2} {3}]", objArray1);
        }

        internal int 7H()
        {
            int num1 = 8;
            if (this.XS)
            {
                num1 = 4;
            }
            if (this.XQ)
            {
                num1 = 0;
            }
            if (this.XP)
            {
                num1 = 12;
            }
            if (this.XP)
            {
                return num1;
            }
            if (this.PK.Bold)
            {
                return (num1 + (this.PK.Italic ? 2 : 1));
            }
            return (num1 + (this.PK.Italic ? 3 : 0));
        }

        internal bool 7I(Font 09G)
        {
            if (((this.PK != null) && !this.PM) && ((09G.Name == this.PK.Name) && (09G.Bold == this.PK.Bold)))
            {
                return (09G.Italic == this.PK.Italic);
            }
            return false;
        }

        internal string 7J(bool 09H)
        {
			// Montando os Widths
            int num2;
            if (this.PP == null)
            {
                return null;
            }
            StringBuilder builder1 = new StringBuilder();
            int num1 = (09H ? 1 : this.PP.Length);
            builder1.Append("[");
            for (num2 = 0; (num2 < num1); num2 += 1)
            {
                builder1.AppendFormat("{0} ", this.PP[num2]);
                if ((num2 % 20) == 19)
                {
                    builder1.Append("\r\n\t");
                }
            }
            builder1.Append("]");
            return builder1.ToString();
        }

        internal byte[] 7K(string 09I, bool 09J)
        {
            if (this.PR != null)
            {
                return this.PR.5F(09I, 09J);
            }
            return Encoding.Default.GetBytes(09I);
        }

        internal string 7L()
        {
            int num2;
            int num3;
            int num4;
            if (this.PP == null)
            {
                return null;
            }
            StringBuilder builder1 = new StringBuilder();
            int num1 = this.PP.Length;
            builder1.Append("[");
            if (this.XQ)
            {
                builder1.Append("231 389 500 631 631 500");
            }
            else if (num1 > 194)
            {
                builder1.AppendFormat("{0} [", (this.PS.QS.Q4 - 29));
                for (num2 = 0; (num2 < 94); num2 += 1)
                {
                    builder1.AppendFormat("{0} ", this.PP[(num2 + 2)]);
                    if ((num2 % 20) == 19)
                    {
                        builder1.Append("\r\n\t");
                    }
                }
                builder1.Append("]\r\n\t326 [");
                for (num3 = 0; (num3 < 64); num3 += 1)
                {
                    builder1.AppendFormat("{0} ", this.PP[(num3 + 130)]);
                    if ((num3 % 20) == 19)
                    {
                        builder1.Append("\r\n\t");
                    }
                }
                builder1.Append("] 631 631 414");
            }
            else
            {
                for (num4 = 0; (num4 < num1); num4 += 1)
                {
                    builder1.AppendFormat("{0} ", this.PP[num4]);
                    if ((num4 % 20) == 19)
                    {
                        builder1.Append("\r\n\t");
                    }
                }
            }
            builder1.Append("]");
            return builder1.ToString();
        }

        [DllImport("GDI32.DLL", EntryPoint="GetOutlineTextMetrics")]
        private static extern int 7M(IntPtr 09K, int 09L, ref 0E 09M);

        [DllImport("GDI32.DLL", EntryPoint="SelectObject")]
        private static extern IntPtr 7N(IntPtr 09N, IntPtr 09O);

        [DllImport("GDI32.DLL", EntryPoint="DeleteObject")]
        private static extern int 7O(IntPtr 09P);

        [DllImport("GDI32.DLL", EntryPoint="GetFontData")]
        private static extern int 7P(IntPtr 09Q, int 09R, int 09S, byte[] 09T, int 09U);

        [DllImport("GDI32.DLL", EntryPoint="GetCharWidth32")]
        private static extern bool 7Q(IntPtr 09V, int 09W, int 09X, int[] 09Y);

        [DllImport("GDI32.DLL", EntryPoint="GetTextExtentPoint32")]
        private static extern bool 7R(IntPtr 09Z, string 0A0, int 0A1, ref Size 0A2);


        // Properties
        internal bool XP
        {
            get
            {
                return (this.PS.QS.QC == 2);
            }
        }

        internal bool XQ
        {
            get
            {
                return ((this.PS.QS.QB & 1) != 1);
            }
        }

        internal bool XR
        {
            get
            {
                return ((this.PS.QS.QB & 64) == 64);
            }
        }

        internal bool XS
        {
            get
            {
                return ((this.PS.QS.QB & 32) == 32);
            }
        }

        internal bool XT
        {
            get
            {
                return (this.PR != null);
            }
        }

        internal bool XU
        {
            get
            {
                if (this.PR != null)
                {
                    return this.PR.NA;
                }
                return false;
            }
            set
            {
                if (this.PR != null)
                {
                    this.PR.NA = 09F;
                }
            }
        }

        internal bool XV
        {
            get
            {
                if (((this.PK != null) && this.PK.Bold) && ((this.PR != null) && this.PR.NA))
                {
                    return !this.PR.XA;
                }
                return false;
            }
        }

        internal bool XW
        {
            get
            {
                if (((this.PK != null) && this.PK.Italic) && ((this.PR != null) && this.PR.NA))
                {
                    return !this.PR.XB;
                }
                return false;
            }
        }


        // Fields
        internal const int PB = 212;
        internal const int PC = 1;
        internal const int PD = 2;
        internal const int PE = 32;
        internal const int PF = 48;
        internal const int PG = 64;
        internal const int PH = 128;
        private static Bitmap PI;
        private static string[] PJ;
        internal Font PK;
        internal bool PL;
        internal bool PM;
        internal int PN;
        internal string PO;
        internal int[] PP;
        internal byte[] PQ;
        internal Y PR;
        internal 0E PS;

        // Nested Types
        [StructLayout(LayoutKind.Sequential)]
        internal struct 0B
        {
            // Fields
            internal int PT;
            internal int PU;
            internal int PV;
            internal int PW;
            internal int PX;
            internal int PY;
            internal int PZ;
            internal int Q0;
            internal int Q1;
            internal int Q2;
            internal int Q3;
            internal byte Q4;
            internal byte Q5;
            internal byte Q6;
            internal byte Q7;
            internal byte Q8;
            internal byte Q9;
            internal byte QA;
            internal byte QB;
            internal byte QC;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct 0C
        {
            // Fields
            internal int QD;
            internal int QE;
            internal int QF;
            internal int QG;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct 0D
        {
            // Fields
            internal byte QH;
            internal byte QI;
            internal byte QJ;
            internal byte QK;
            internal byte QL;
            internal byte QM;
            internal byte QN;
            internal byte QO;
            internal byte QP;
            internal byte QQ;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct 0E
        {
            // Fields
            internal int QR;
            internal 0B QS;
            internal byte QT;
            internal 0D QU;
            internal uint QV;
            internal uint QW;
            internal int QX;
            internal int QY;
            internal int QZ;
            internal uint R0;
            internal int R1;
            internal int R2;
            internal uint R3;
            internal uint R4;
            internal uint R5;
            internal 0C R6;
            internal int R7;
            internal int R8;
            internal uint R9;
            internal uint RA;
            internal Point RB;
            internal Point RC;
            internal Point RD;
            internal Point RE;
            internal uint RF;
            internal int RG;
            internal int RH;
            internal int RI;
            internal IntPtr RJ;
            internal IntPtr RK;
            internal IntPtr RL;
            internal IntPtr RM;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class 0F
        {
            // Methods
            public 0F()
            {
            }


            // Fields
            internal const int RN = 32;
            internal int RO;
            internal int RP;
            internal int RQ;
            internal int RR;
            internal int RS;
            internal byte RT;
            internal byte RU;
            internal byte RV;
            internal byte RW;
            internal byte RX;
            internal byte RY;
            internal byte RZ;
            internal byte S0;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
            internal string S1;
        }
    }
}


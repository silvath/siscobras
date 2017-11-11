namespace C1.C1Pdf
{
    using C1.C1Zip;
    using System;
    using System.Collections;
    using System.IO;
    using System.Text;

    internal class Y : IComparer
    {
        // Methods
        static Y()
        {
            string[] textArray1 = new string[9];
            textArray1[0] = "cvt ";
            textArray1[1] = "fpgm";
            textArray1[2] = "glyf";
            textArray1[3] = "head";
            textArray1[4] = "hhea";
            textArray1[5] = "hmtx";
            textArray1[6] = "loca";
            textArray1[7] = "maxp";
            textArray1[8] = "prep";
            Y.MI = textArray1;
            textArray1 = new string[10];
            textArray1[0] = "cmap";
            textArray1[1] = "cvt ";
            textArray1[2] = "fpgm";
            textArray1[3] = "glyf";
            textArray1[4] = "head";
            textArray1[5] = "hhea";
            textArray1[6] = "hmtx";
            textArray1[7] = "loca";
            textArray1[8] = "maxp";
            textArray1[9] = "prep";
            Y.MJ = textArray1;
            Y.MK = new int[21] { 0, 0, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4 };
            Y.ML = 36;
        }

        internal Y(0A font) : this(font, false)
        {
        }

        internal Y(0A font, bool cmap)
        {
            this.MO = null;
            this.MP = null;
            this.MQ = null;
            this.MR = new Hashtable();
            this.MS = false;
            this.MW = null;
            this.N6 = 0;
            this.N7 = new ArrayList();
            this.N8 = new Hashtable();
            this.N9 = false;
            this.NA = false;
            this.NB = false;
            this.N5 = font;
            this.NB = cmap;
            this.MN = font.7E();
            this.5G();
            this.5H();
        }

        private int 5A(object 065, object 066)
        {
            int num1 = ((int[]) 065)[0];
            int num2 = ((int[]) 066)[0];
            if (num1 < num2)
            {
                return -1;
            }
            if (num1 > num2)
            {
                return 1;
            }
            return 0;
        }

        internal int 5B(int 067)
        {
            if (this.MO == null)
            {
                this.5I();
            }
            if (067 >= this.MO.Length)
            {
                067 = (this.MO.Length - 1);
            }
            return this.MO[067];
        }

        internal int[] 5C(int 068)
        {
            if ((this.MP == null) && (this.MQ == null))
            {
                this.5J();
            }
            if ((!this.MS || (this.MP == null)) && (this.MQ != null))
            {
                return ((int[]) this.MQ[068]);
            }
            if (this.MP != null)
            {
                return ((int[]) this.MP[068]);
            }
            return null;
        }

        internal bool 5D(C1PdfDocumentBase 069)
        {
            int num4;
            StringBuilder builder1;
            int num5;
            bool flag1;
            int num6;
            int[] numArray3;
            int num7;
            if (!this.NA && !069.XL)
            {
                return false;
            }
            string text1 = this.N5.7E().Replace("#20", "-");
            string text2 = "/" + Y.XD + text1.Substring(1, (text1.Length - 1));
            string text3 = this.XC;
            object[] objArray1 = new object[((uint) this.MR.Count)];
            this.MR.Values.CopyTo(objArray1, 0);
            Array.Sort(objArray1, this);
            byte[] numArray1 = this.X9;
            byte[] numArray2 = numArray1;
            int num1 = 069.65("FontFile2");
            069.67();
            if (069.Compression != CompressionEnum.None)
            {
                numArray1 = this.5U(numArray2);
                069.68("Filter", "/FlateDecode");
            }
            069.6A("Length1", ((long) numArray2.Length));
            069.6A("Length", ((long) numArray1.Length));
            069.6B();
            069.6E(num1, numArray1);
            069.66();
            int num2 = 069.65("FontDescriptor");
            069.67();
            069.68("Type", "/FontDescriptor");
            069.68("FontName", text2);
            069.6A("Flags", ((long) this.N5.7F()));
            069.6A("Ascent", ((long) this.N5.PS.R1));
            069.6A("Descent", ((long) this.N5.PS.R2));
            069.68("FontBBox", this.N5.7G());
            069.6A("StemV", ((long) (this.N5.PK.Bold ? 144 : 72)));
            069.6A("ItalicAngle", ((long) (this.N5.PK.Italic ? (this.N5.PS.QZ / 10) : 0)));
            069.6A("CapHeight", ((long) this.N5.PS.R4));
            069.6A("XHeight", ((long) this.N5.PS.R5));
            069.68("FontFile2", 069.6K(num1));
            069.6B();
            069.66();
            int num3 = 069.65("CIDFontType2");
            069.67();
            069.68("Type", "/Font");
            069.68("Subtype", "/CIDFontType2");
            069.68("BaseFont", text2);
            069.68("FontDescriptor", string.Format("{0} 0 R", num2));
            069.Write("/CIDSystemInfo ", new object[0]);
            069.67();
            069.68("Registry", "(Adobe)");
            069.68("Ordering", "(Identity)");
            069.6A("Supplement", ((long) 0));
            069.6B();
            if (!this.N5.PK.GdiVerticalFont)
            {
                num4 = 1000;
                builder1 = new StringBuilder("[");
                num5 = -10;
                flag1 = true;
                for (num6 = 0; (num6 < objArray1.Length); num6 += 1)
                {
                    numArray3 = ((int[]) objArray1[num6]);
                    if (numArray3[1] != num4)
                    {
                        num7 = numArray3[0];
                        if (num7 == (num5 + 1))
                        {
                            builder1.Append(' ').Append(numArray3[1]);
                        }
                        else
                        {
                            if (!flag1)
                            {
                                builder1.Append("]");
                            }
                            flag1 = false;
                            builder1.Append(num7).Append("[").Append(numArray3[1]);
                        }
                        num5 = num7;
                    }
                }
                if (builder1.Length > 1)
                {
                    builder1.Append("]]");
                    069.6A("DW", ((long) num4));
                    069.68("W", builder1.ToString());
                }
            }
            069.6B();
            069.66();
            int num8 = 069.65("ToUnicode map");
            numArray1 = this.5E(objArray1);
            numArray2 = numArray1;
            069.67();
            if (069.Compression != CompressionEnum.None)
            {
                numArray1 = this.5U(numArray2);
                069.68("Filter", "/FlateDecode");
            }
            069.6A("Length", ((long) numArray1.Length));
            069.6B();
            069.6E(num8, numArray1);
            069.66();
            this.N5.PN = 069.65("Type0");
            069.67();
            069.68("Type", "/Font");
            069.68("Subtype", "/Type0");
            069.68("BaseFont", text2);
            069.68("DescendantFonts", string.Format("[{0}]", 069.6K(num3)));
            069.68("Encoding", "/" + text3);
            069.68("ToUnicode", string.Format("{0} 0 R", num8));
            069.6B();
            069.66();
            return true;
        }

        internal byte[] 5E(object[] 06A)
        {
            int num2;
            int[] numArray1;
            string text1;
            StringBuilder builder1 = new StringBuilder("/CIDInit /ProcSet findresource begin\n");
            builder1.Append("12 dict begin\n").Append("begincmap\n").Append("/CIDSystemInfo\n");
            builder1.Append("<< /Registry (Adobe)\n");
            builder1.Append("/Ordering (UCS)\n").Append("/Supplement 0\n");
            builder1.Append(">> def\n");
            builder1.Append("/CMapName /Adobe-Identity-UCS def\n").Append("/CMapType 2 def\n");
            builder1.Append("1 begincodespacerange\n");
            builder1.Append('<').Append(((int[]) 06A[0])[0].ToString("X4")).Append('>');
            builder1.Append('<').Append(((int[]) 06A[(06A.Length - 1)])[0].ToString("X4")).Append('>');
            builder1.Append("\nendcodespacerange\n");
            int num1 = 0;
            for (num2 = 0; (num2 < 06A.Length); num2 += 1)
            {
                if (num1 == 0)
                {
                    if (num2 != 0)
                    {
                        builder1.Append("endbfrange\n");
                    }
                    num1 = Math.Min(100, (06A.Length - num2));
                    builder1.Append(num1).Append(" beginbfrange\n");
                }
                num1 -= 1;
                numArray1 = ((int[]) 06A[num2]);
                text1 = numArray1[0].ToString("X4");
                builder1.Append('<').Append(text1).Append("><").Append(text1).Append('>');
                builder1.Append('<').Append(numArray1[2].ToString("X4")).Append(">\n");
            }
            builder1.Append("endbfrange\n").Append("endcmap\n");
            builder1.Append("CMapName currentdict /CMap defineresource pop\n");
            builder1.Append("end end\n");
            return Encoding.ASCII.GetBytes(builder1.ToString());
        }

        internal byte[] 5F(string 06B, bool 06C)
        {
            int num1;
            bool flag1;
            char[] chArray1;
            int num2;
            char ch1;
            int num3;
            int[] numArray1;
            byte[] numArray2;
            int num4;
            int num5;
            char ch2;
            int[] numArray3;
            if (!this.N9)
            {
                num1 = 0;
                flag1 = false;
                chArray1 = new char[((uint) 06B.Length)];
                for (num2 = 0; (num2 < 06B.Length); num2 += 1)
                {
                    ch1 = 06B[num2];
                    if (ch1 >= '\u0100')
                    {
                        flag1 = true;
                    }
                    num3 = 0;
                    numArray1 = this.5C(ch1);
                    if (numArray1 != null)
                    {
                        num3 = numArray1[0];
                        if (!this.MR.ContainsKey(num3))
                        {
                            numArray3 = new int[3];
                            numArray3[0] = num3;
                            numArray3[1] = numArray1[1];
                            numArray3[2] = ((int) ch1);
                            this.MR.Add(num3, numArray3);
                            this.N8.Add(num3, null);
                            this.N7.Add(num3);
                        }
                    }
                    int num6 = num1;
                    num1 = (num6 + 1);
                    chArray1[num1] = ((char) ((ushort) num3));
                }
                if (((this.NA || 06C) || flag1) && (this.MR.Count > 0))
                {
                    this.NA = true;
                    numArray2 = new byte[((uint) (2 * num1))];
                    num4 = 0;
                    for (num5 = 0; (num5 < num1); num5 += 1)
                    {
                        ch2 = chArray1[num5];
                        int num7 = num4;
                        num4 = (num7 + 1);
                        numArray2[num4] = ((byte) (ch2 >> '\b'));
                        int num8 = num4;
                        num4 = (num8 + 1);
                        numArray2[num4] = ((byte) (ch2 & '\u00ff'));
                    }
                    return numArray2;
                }
                this.N9 = true;
            }
            return Encoding.Default.GetBytes(06B);
        }

        private void 5G()
        {
            int[] numArray1;
            int num1;
            int num2;
            int num3;
            string text1;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            int num10;
            int[] numArray3;
            using (MemoryStream stream1 = new MemoryStream(this.N5.PQ))
            {
                using (Z z1 = new Z(stream1))
                {
                    this.MM = new Hashtable();
                    num1 = z1.ReadInt32();
                    if (num1 != 65536)
                    {
                        throw new Exception("Font is not a True Type font.");
                    }
                    num2 = ((int) z1.ReadUInt16());
                    Stream stream2 = z1.BaseStream;
                    z1.BaseStream.Position = (stream2.Position + ((long) 6));
                    for (num3 = 0; (num3 < num2); num3 += 1)
                    {
                        text1 = this.5S(z1, 4);
                        numArray1 = new int[3];
                        numArray1[0] = z1.ReadInt32();
                        numArray1[1] = z1.ReadInt32();
                        numArray1[2] = z1.ReadInt32();
                        this.MM.Add(text1, numArray1);
                    }
                    this.N6 = 0;
                    numArray1 = ((int[]) this.MM["cmap"]);
                    while ((this.N6 < Y.ML))
                    {
                        z1.BaseStream.Position = ((long) (numArray1[1] - this.N6));
                        num4 = ((int) z1.ReadUInt16());
                        num5 = ((int) z1.ReadUInt16());
                        num6 = ((int) z1.ReadUInt16());
                        num7 = ((int) z1.ReadUInt16());
                        num8 = z1.ReadInt32();
                        if ((((num4 == 0) && (num5 > 0)) && ((num6 < 4) && (num7 < 4))) && (num8 > 0))
                        {
                            num9 = ((numArray1[1] - this.N6) + num8);
                            if (((long) num9) < z1.BaseStream.Length)
                            {
                                z1.BaseStream.Position = ((long) num9);
                                num10 = ((int) z1.ReadUInt16());
                                if (((num10 == 0) || (num10 == 4)) || (num10 == 6))
                                {
                                    break;
                                }
                            }
                        }
                        this.N6 += 4;
                    }
                    if (this.N6 == Y.ML)
                    {
                        this.N9 = true;
                        return;
                    }
                    if (this.N6 <= 0)
                    {
                        return;
                    }
                    foreach (int[] numArray2 in this.MM.Values)
                    {
                        numArray3 = numArray2;
                        numArray3[1] = (numArray3[1] - this.N6);
                    }
                }
            }
        }

        private void 5H()
        {
            int[] numArray1;
            using (MemoryStream stream1 = new MemoryStream(this.N5.PQ))
            {
                using (Z z1 = new Z(stream1))
                {
                    numArray1 = ((int[]) this.MM["head"]);
                    if (numArray1 == null)
                    {
                        throw new FormatException("Table \'head\' does not exist in " + this.MN);
                    }
                    z1.BaseStream.Position = ((long) (numArray1[1] + 18));
                    this.MU = ((int) z1.ReadUInt16());
                    Stream stream2 = z1.BaseStream;
                    z1.BaseStream.Position = (stream2.Position + ((long) 24));
                    this.MV = ((int) z1.ReadUInt16());
                    numArray1 = ((int[]) this.MM["hhea"]);
                    if (numArray1 == null)
                    {
                        throw new FormatException("Table \'hhea\' does not exist in " + this.MN);
                    }
                    z1.BaseStream.Position = ((long) (numArray1[1] + 34));
                    this.MT = ((int) z1.ReadUInt16());
                }
            }
        }

        private void 5I()
        {
            int num1;
            int[] numArray1 = ((int[]) this.MM["hmtx"]);
            if (numArray1 == null)
            {
                throw new FormatException("Table \'hmtx\' does not exist in " + this.MN);
            }
            using (MemoryStream stream1 = new MemoryStream(this.N5.PQ))
            {
                using (Z z1 = new Z(stream1))
                {
                    z1.BaseStream.Position = ((long) numArray1[1]);
                    this.MO = new int[((uint) this.MT)];
                    for (num1 = 0; (num1 < this.MT); num1 += 1)
                    {
                        this.MO[num1] = ((1000 * ((int) z1.ReadUInt16())) / this.MU);
                        z1.ReadUInt16();
                    }
                }
            }
        }

        private void 5J()
        {
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            int num10;
            int[] numArray1 = ((int[]) this.MM["cmap"]);
            if (numArray1 == null)
            {
                throw new FormatException("Table \'cmap\' does not exist in " + this.MN);
            }
            using (MemoryStream stream1 = new MemoryStream(this.N5.PQ))
            {
                using (Z z1 = new Z(stream1))
                {
                    z1.BaseStream.Position = ((long) (numArray1[1] + 2));
                    num1 = ((int) z1.ReadUInt16());
                    num2 = 0;
                    num3 = 0;
                    for (num4 = 0; (num4 < num1); num4 += 1)
                    {
                        num5 = ((int) z1.ReadUInt16());
                        num6 = ((int) z1.ReadUInt16());
                        num7 = z1.ReadInt32();
                        if ((num5 == 3) && (num6 == 0))
                        {
                            this.MS = true;
                        }
                        else if ((num5 == 3) && (num6 == 1))
                        {
                            num2 = num7;
                        }
                        if ((num5 == 1) && (num6 == 0))
                        {
                            num3 = num7;
                        }
                    }
                    if (num2 <= 0)
                    {
                        goto Label_0128;
                    }
                    z1.BaseStream.Position = ((long) (numArray1[1] + num2));
                    num8 = ((int) z1.ReadUInt16());
                    num10 = num8;
                    if (num10 != 0)
                    {
                        switch (num10)
                        {
                            case 4:
                            {
                                this.MP = this.5L(z1);
                                goto Label_0128;
                            }
                            case 5:
                            {
                                goto Label_0128;
                            }
                            case 6:
                            {
                                goto Label_011B;
                            }
                        }
                        goto Label_0128;
                    }
                    this.MP = this.5K(z1);
                    goto Label_0128;
                Label_011B:
                    this.MP = this.5M(z1);
                Label_0128:
                    if (num3 <= 0)
                    {
                        return;
                    }
                    z1.BaseStream.Position = ((long) (numArray1[1] + num3));
                    num9 = ((int) z1.ReadUInt16());
                    if ((num9 == 0) && (this.MS || (this.MP == null)))
                    {
                        this.MQ = this.5K(z1);
                        return;
                    }
                    if (num9 != 4)
                    {
                        return;
                    }
                    this.MQ = this.5L(z1);
                }
            }
        }

        private Hashtable 5K(BinaryReader 06D)
        {
            int num1;
            int[] numArray1;
            Hashtable hashtable1 = new Hashtable();
            Stream stream1 = 06D.BaseStream;
            06D.BaseStream.Position = (stream1.Position + ((long) 4));
            for (num1 = 0; (num1 < 256); num1 += 1)
            {
                numArray1 = new int[2];
                numArray1[0] = ((int) 06D.ReadByte());
                numArray1[1] = this.5B(numArray1[0]);
                hashtable1.Add(num1, numArray1);
            }
            return hashtable1;
        }

        private Hashtable 5L(BinaryReader 06E)
        {
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            int num10;
            int num11;
            int[] numArray6;
            Hashtable hashtable1 = new Hashtable();
            int num1 = ((int) 06E.ReadUInt16());
            Stream stream1 = 06E.BaseStream;
            06E.BaseStream.Position = (stream1.Position + ((long) 2));
            int num2 = (((int) 06E.ReadUInt16()) / 2);
            Stream stream2 = 06E.BaseStream;
            06E.BaseStream.Position = (stream2.Position + ((long) 6));
            int[] numArray1 = new int[((uint) num2)];
            for (num3 = 0; (num3 < num2); num3 += 1)
            {
                numArray1[num3] = ((int) 06E.ReadUInt16());
            }
            Stream stream3 = 06E.BaseStream;
            06E.BaseStream.Position = (stream3.Position + ((long) 2));
            int[] numArray2 = new int[((uint) num2)];
            for (num4 = 0; (num4 < num2); num4 += 1)
            {
                numArray2[num4] = ((int) 06E.ReadUInt16());
            }
            int[] numArray3 = new int[((uint) num2)];
            for (num5 = 0; (num5 < num2); num5 += 1)
            {
                numArray3[num5] = ((int) 06E.ReadUInt16());
            }
            int[] numArray4 = new int[((uint) num2)];
            for (num6 = 0; (num6 < num2); num6 += 1)
            {
                numArray4[num6] = ((int) 06E.ReadUInt16());
            }
            int[] numArray5 = new int[((uint) (((num1 / 2) - 8) - (4 * num2)))];
            for (num7 = 0; (num7 < numArray5.Length); num7 += 1)
            {
                numArray5[num7] = ((int) 06E.ReadUInt16());
            }
            for (num8 = 0; (num8 < num2); num8 += 1)
            {
                for (num10 = numArray2[num8]; ((num10 <= numArray1[num8]) && (num10 != 65535)); num10 += 1)
                {
                    if (numArray4[num8] == 0)
                    {
                        num9 = ((num10 + numArray3[num8]) & 65535);
                    }
                    else
                    {
                        num11 = ((((num8 + (numArray4[num8] / 2)) - num2) + num10) - numArray2[num8]);
                        num9 = ((numArray5[num11] + numArray3[num8]) & 65535);
                    }
                    numArray6 = new int[2];
                    numArray6[0] = num9;
                    numArray6[1] = this.5B(numArray6[0]);
                    hashtable1.Add(num10, numArray6);
                }
            }
            return hashtable1;
        }

        private Hashtable 5M(BinaryReader 06F)
        {
            int num2;
            int[] numArray1;
            Hashtable hashtable1 = new Hashtable();
            Stream stream1 = 06F.BaseStream;
            06F.BaseStream.Position = (stream1.Position + ((long) 4));
            06F.ReadUInt16();
            int num1 = ((int) 06F.ReadUInt16());
            for (num2 = 0; (num2 < num1); num2 += 1)
            {
                numArray1 = new int[2];
                numArray1[0] = ((int) 06F.ReadUInt16());
                numArray1[1] = this.5B(numArray1[0]);
                hashtable1.Add(num2, numArray1);
            }
            return hashtable1;
        }

        private void 5N()
        {
            int num1;
            int num2;
            int num3;
            int num4;
            int[] numArray1 = ((int[]) this.MM["head"]);
            if (numArray1 == null)
            {
                throw new Exception("Table \'head\' does not exist in " + this.MN);
            }
            using (MemoryStream stream1 = new MemoryStream(this.N5.PQ))
            {
                using (Z z1 = new Z(stream1))
                {
                    z1.BaseStream.Position = ((long) (numArray1[1] + 51));
                    this.MX = (((int) z1.ReadUInt16()) == 0);
                    numArray1 = ((int[]) this.MM["loca"]);
                    if (numArray1 == null)
                    {
                        throw new Exception("Table \'loca\' does not exist in " + this.MN);
                    }
                    z1.BaseStream.Position = ((long) numArray1[1]);
                    if (this.MX)
                    {
                        num1 = (numArray1[2] / 2);
                        this.MY = new int[((uint) num1)];
                        for (num2 = 0; (num2 < num1); num2 += 1)
                        {
                            this.MY[num2] = (2 * ((int) z1.ReadUInt16()));
                        }
                        return;
                    }
                    num3 = (numArray1[2] / 4);
                    this.MY = new int[((uint) num3)];
                    for (num4 = 0; (num4 < num3); num4 += 1)
                    {
                        this.MY[num4] = z1.ReadInt32();
                    }
                }
            }
        }

        private void 5O()
        {
            int num2;
            int num3;
            int[] numArray1 = ((int[]) this.MM["glyf"]);
            if (numArray1 == null)
            {
                throw new Exception("Table \'glyf\' does not exist in " + this.MN);
            }
            int num1 = 0;
            if (!this.N8.ContainsKey(num1))
            {
                this.N8.Add(num1, null);
                this.N7.Add(num1);
            }
            this.MZ = numArray1[1];
            for (num2 = 0; (num2 < this.N7.Count); num2 += 1)
            {
                num3 = ((int) this.N7[num2]);
                this.5P(num3);
            }
        }

        private void 5P(int 06G)
        {
            int num2;
            int num3;
            int num4;
            int num5;
            int num1 = this.MY[06G];
            if (num1 == this.MY[(06G + 1)])
            {
                return;
            }
            if (num1 < 0)
            {
                return;
            }
            using (MemoryStream stream1 = new MemoryStream(this.N5.PQ))
            {
                using (Z z1 = new Z(stream1))
                {
                    z1.BaseStream.Position = ((long) (this.MZ + num1));
                    num2 = ((int) z1.ReadInt16());
                    if (num2 >= 0)
                    {
                        return;
                    }
                    Stream stream2 = z1.BaseStream;
                    z1.BaseStream.Position = (stream2.Position + ((long) 8));
                Label_006C:
                    num3 = ((int) z1.ReadUInt16());
                    num4 = ((int) z1.ReadUInt16());
                    if (!this.N8.ContainsKey(num4))
                    {
                        this.N8.Add(num4, null);
                        this.N7.Add(num4);
                    }
                    if ((num3 & 32) == 0)
                    {
                        return;
                    }
                    if ((num3 & 1) != 0)
                    {
                        num5 = 4;
                    }
                    else
                    {
                        num5 = 2;
                    }
                    if ((num3 & 8) != 0)
                    {
                        num5 += 2;
                    }
                    else if ((num3 & 64) != 0)
                    {
                        num5 += 4;
                    }
                    if ((num3 & 128) != 0)
                    {
                        num5 += 8;
                    }
                    Stream stream3 = z1.BaseStream;
                    z1.BaseStream.Position = (stream3.Position + ((long) num5));
                    goto Label_006C;
                }
            }
        }

        private void 5Q()
        {
            int num1;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            int num10;
            this.N0 = new int[((uint) this.MY.Length)];
            int[] numArray1 = new int[((uint) this.N7.Count)];
            for (num1 = 0; (num1 < numArray1.Length); num1 += 1)
            {
                numArray1[num1] = ((int) this.N7[num1]);
            }
            Array.Sort(numArray1);
            int num2 = 0;
            for (num3 = 0; (num3 < numArray1.Length); num3 += 1)
            {
                num4 = numArray1[num3];
                num2 += (this.MY[(num4 + 1)] - this.MY[num4]);
            }
            this.N3 = num2;
            num2 = ((num2 + 3) & -4);
            this.N2 = new byte[((uint) num2)];
            using (MemoryStream stream1 = new MemoryStream(this.N5.PQ))
            {
                using (Z z1 = new Z(stream1))
                {
                    num5 = 0;
                    num6 = 0;
                    for (num7 = 0; (num7 < this.N0.Length); num7 += 1)
                    {
                        this.N0[num7] = num5;
                        if ((num6 < numArray1.Length) && (numArray1[num6] == num7))
                        {
                            num6 += 1;
                            this.N0[num7] = num5;
                            num8 = this.MY[num7];
                            num9 = (this.MY[(num7 + 1)] - num8);
                            if (num9 > 0)
                            {
                                z1.BaseStream.Position = ((long) (this.MZ + num8));
                                z1.Read(this.N2, num5, num9);
                                num5 += num9;
                            }
                        }
                    }
                }
            }
            if (this.MX)
            {
                this.N4 = (this.N0.Length * 2);
            }
            else
            {
                this.N4 = (this.N0.Length * 4);
            }
            this.N1 = new byte[((uint) ((this.N4 + 3) & -4))];
            using (MemoryStream stream2 = new MemoryStream(this.N1))
            {
                using (00 1 = new 00(stream2))
                {
                    for (num10 = 0; (num10 < this.N0.Length); num10 += 1)
                    {
                        if (this.MX)
                        {
                            1.Write(((short) (this.N0[num10] / 2)));
                        }
                        else
                        {
                            1.Write(this.N0[num10]);
                        }
                    }
                }
            }
        }

        private void 5R()
        {
            int[] numArray1;
            string[] textArray1;
            int num4;
            string text1;
            int num6;
            int num7;
            string text2;
            int num8;
            string text3;
            int num1 = 0;
            if (this.NB)
            {
                textArray1 = Y.MJ;
            }
            else
            {
                textArray1 = Y.MI;
            }
            int num2 = 2;
            int num3 = 0;
            for (num4 = 0; (num4 < textArray1.Length); num4 += 1)
            {
                text1 = textArray1[num4];
                if (text1.Equals("glyf"))
                {
                    num1 += this.N2.Length;
                }
                else if (text1.Equals("loca"))
                {
                    num1 += this.N1.Length;
                }
                else
                {
                    numArray1 = ((int[]) this.MM[text1]);
                    if (numArray1 != null)
                    {
                        num2 += 1;
                        num1 += ((numArray1[2] + 3) & -4);
                    }
                }
            }
            int num5 = ((16 * num2) + 12);
            num1 += num5;
            this.MW = new byte[((uint) num1)];
            using (MemoryStream stream1 = new MemoryStream(this.MW))
            {
                using (00 1 = new 00(stream1))
                {
                    1.Write(65536);
                    1.Write(((short) num2));
                    num6 = Y.MK[num2];
                    1.Write(((short) ((1 << (num6 & 31)) * 16)));
                    1.Write(((short) num6));
                    1.Write(((short) ((num2 - (1 << (num6 & 31))) * 16)));
                    for (num7 = 0; (num7 < textArray1.Length); num7 += 1)
                    {
                        text2 = textArray1[num7];
                        numArray1 = ((int[]) this.MM[text2]);
                        if (numArray1 != null)
                        {
                            1.Write(Encoding.Default.GetBytes(text2));
                            if (text2.Equals("glyf"))
                            {
                                1.Write(this.5T(this.N2));
                                num3 = this.N3;
                            }
                            else if (text2.Equals("loca"))
                            {
                                1.Write(this.5T(this.N1));
                                num3 = this.N4;
                            }
                            else
                            {
                                1.Write(numArray1[0]);
                                num3 = numArray1[2];
                            }
                            1.Write(num5);
                            1.Write(num3);
                            num5 += ((num3 + 3) & -4);
                        }
                    }
                    using (MemoryStream stream2 = new MemoryStream(this.N5.PQ))
                    {
                        using (Z z1 = new Z(stream2))
                        {
                            for (num8 = 0; (num8 < textArray1.Length); num8 += 1)
                            {
                                text3 = textArray1[num8];
                                numArray1 = ((int[]) this.MM[text3]);
                                if (numArray1 != null)
                                {
                                    if (text3.Equals("glyf"))
                                    {
                                        1.Write(this.N2);
                                        this.N2 = null;
                                    }
                                    else if (text3.Equals("loca"))
                                    {
                                        1.Write(this.N1);
                                        this.N1 = null;
                                    }
                                    else
                                    {
                                        z1.BaseStream.Position = ((long) numArray1[1]);
                                        z1.Read(this.MW, ((int) 1.BaseStream.Position), numArray1[2]);
                                        Stream stream3 = 1.BaseStream;
                                        1.BaseStream.Position = (stream3.Position + ((long) ((numArray1[2] + 3) & -4)));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private string 5S(BinaryReader 06H, int 06I)
        {
            byte[] numArray1 = new byte[((uint) 06I)];
            06H.Read(numArray1, 0, numArray1.Length);
            char[] chArray1 = Encoding.ASCII.GetChars(numArray1);
            return new string(chArray1);
        }

        private int 5T(byte[] 06J)
        {
            int num7;
            int num1 = (06J.Length / 4);
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            for (num7 = 0; (num7 < num1); num7 += 1)
            {
                int num8 = num6;
                num6 = (num8 + 1);
                num5 += (06J[num6] & 255);
                int num9 = num6;
                num6 = (num9 + 1);
                num4 += (06J[num6] & 255);
                int num10 = num6;
                num6 = (num10 + 1);
                num3 += (06J[num6] & 255);
                int num11 = num6;
                num6 = (num11 + 1);
                num2 += (06J[num6] & 255);
            }
            return (((num2 + (num3 << 8)) + (num4 << 16)) + (num5 << 24));
        }

        private byte[] 5U(byte[] 06K)
        {
            MemoryStream stream1 = new MemoryStream();
            X x1 = new X(stream1);
            x1.Write(06K, 0, 06K.Length);
            x1.Close();
            return stream1.ToArray();
        }


        // Properties
        internal byte[] X9
        {
            get
            {
                if (this.MW == null)
                {
                    this.5N();
                    this.5O();
                    this.5Q();
                    this.5R();
                }
                return this.MW;
            }
        }

        internal bool XA
        {
            get
            {
                return ((this.MV & 1) != 0);
            }
        }

        internal bool XB
        {
            get
            {
                return ((this.MV & 2) != 0);
            }
        }

        internal string XC
        {
            get
            {
                if (this.N5.PK.GdiVerticalFont)
                {
                    return "Identity-V";
                }
                return "Identity-H";
            }
        }

        public static string XD
        {
            get
            {
                int num1;
                Random random1 = new Random();
                StringBuilder builder1 = new StringBuilder();
                for (num1 = 0; (num1 < 6); num1 += 1)
                {
                    builder1.Append(((ushort) (random1.Next(26) + 65)));
                }
                builder1.Append('+');
                return builder1.ToString();
            }
        }


        // Fields
        private static readonly string[] MI;
        private static readonly string[] MJ;
        private static readonly int[] MK;
        private static readonly int ML;
        private Hashtable MM;
        private string MN;
        private int[] MO;
        private Hashtable MP;
        private Hashtable MQ;
        private Hashtable MR;
        private bool MS;
        private int MT;
        private int MU;
        private int MV;
        private byte[] MW;
        private bool MX;
        private int[] MY;
        private int MZ;
        private int[] N0;
        private byte[] N1;
        private byte[] N2;
        private int N3;
        private int N4;
        private 0A N5;
        private int N6;
        private ArrayList N7;
        private Hashtable N8;
        internal bool N9;
        internal bool NA;
        private bool NB;

        // Nested Types
        internal class 00 : BinaryWriter
        {
            // Methods
            internal 00(Stream stream) : base(stream)
            {
                this.ND = Encoding.Default;
            }

            internal 00(Stream stream, Encoding encoding) : base(stream, encoding)
            {
                this.ND = Encoding.Default;
                this.ND = encoding;
            }

            public override void Write(short value)
            {
                base.Write(((byte) (value >> 8)));
                base.Write(((byte) (value & 255)));
            }

            public override void Write(int value)
            {
                this.Write(((short) (value >> 16)));
                this.Write(((short) (value & 65535)));
            }

            public override void Write(long value)
            {
                this.Write(((int) (value >> 32)));
                this.Write(((int) (value & ((ulong) -1))));
            }

            public override void Write(string value)
            {
                this.Write(value.ToCharArray());
            }


            // Properties
            internal Encoding XF
            {
                get
                {
                    return this.ND;
                }
                set
                {
                    this.ND = 06M;
                }
            }


            // Fields
            private Encoding ND;
        }

        internal class Z : BinaryReader
        {
            // Methods
            internal Z(Stream stream) : base(stream)
            {
                this.NC = Encoding.Default;
            }

            internal Z(Stream stream, Encoding encoding) : base(stream, encoding)
            {
                this.NC = Encoding.Default;
                this.NC = encoding;
            }

            public override char ReadChar()
            {
                return ((char) ((ushort) ((this.ReadByte() << 8) + this.ReadByte())));
            }

            public override char[] ReadChars(int count)
            {
                int num1;
                char[] chArray1 = new char[((uint) (count * 2))];
                for (num1 = 0; (num1 < count); num1 += 1)
                {
                    chArray1[num1] = this.ReadChar();
                }
                return chArray1;
            }

            public override double ReadDouble()
            {
                return BitConverter.Int64BitsToDouble(this.ReadInt64());
            }

            public override short ReadInt16()
            {
                return ((short) ((this.ReadByte() << 8) + this.ReadByte()));
            }

            public override int ReadInt32()
            {
                return ((int) ((((this.ReadByte() << 24) + (this.ReadByte() << 16)) + (this.ReadByte() << 8)) + this.ReadByte()));
            }

            public override long ReadInt64()
            {
                return ((long) ((((ulong) this.ReadUInt32()) << 32) + (((ulong) this.ReadUInt32()) & ((ulong) -1))));
            }

            public override float ReadSingle()
            {
                return ((float) BitConverter.Int64BitsToDouble(((ulong) this.ReadUInt32())));
            }

            public override ushort ReadUInt16()
            {
                return ((ushort) ((this.ReadByte() << 8) + this.ReadByte()));
            }

            public override uint ReadUInt32()
            {
                return ((uint) ((((this.ReadByte() << 24) + (this.ReadByte() << 16)) + (this.ReadByte() << 8)) + this.ReadByte()));
            }

            public override ulong ReadUInt64()
            {
                return ((((ulong) this.ReadUInt32()) << 32) + (((ulong) this.ReadUInt32()) & ((ulong) -1)));
            }


            // Properties
            internal Encoding XE
            {
                get
                {
                    return this.NC;
                }
                set
                {
                    this.NC = 06L;
                }
            }


            // Fields
            private Encoding NC;
        }
    }
}


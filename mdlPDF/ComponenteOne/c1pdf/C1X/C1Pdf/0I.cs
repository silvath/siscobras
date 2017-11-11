namespace C1.C1Pdf
{
    using C1.C1Zip;
    using System;
    using System.Drawing;
    using System.IO;

    internal class 0I : 0H
    {
        // Methods
        internal 0I(BinaryReader br, byte[] data, int offBmiSrc, int cbBmiSrc, int offBitsSrc, int cbBitsSrc) : base(null)
        {
            this.S8 = (offBmiSrc - 8);
            this.S9 = cbBmiSrc;
            this.SA = (offBitsSrc - 8);
            this.SB = cbBitsSrc;
            br.BaseStream.Position = ((long) this.S8);
            this.S7 = new 0J(br);
            this.SC = data;
        }

        internal override void 7T(C1PdfDocumentBase 0AF)
        {
            this.S4 = 0AF.65("Image");
            byte[] numArray1 = this.80(0AF.Compression);
            0AF.67();
            0AF.68("Type", "/XObject");
            0AF.68("Subtype", "/Image");
            0AF.6A("Length", ((long) numArray1.Length));
            Size size1 = this.Y0;
            0AF.6A("Width", ((long) size1.Width));
            size1 = this.Y0;
            0AF.6A("Height", ((long) size1.Height));
            0AF.6A("BitsPerComponent", ((long) (this.XZ ? 1 : 8)));
            0AF.68("ColorSpace", (this.XZ ? "/DeviceGray" : "/DeviceRGB"));
            if (0AF.Compression != CompressionEnum.None)
            {
                0AF.68("Filter", "/FlateDecode");
            }
            if (this.SD)
            {
                0AF.68("ImageMask", "true");
            }
            else if (this.SE != null)
            {
                0AF.68("Mask", 0AF.6K(this.SE.S4));
            }
            0AF.6B();
            0AF.6E(this.S4, numArray1);
            0AF.66();
        }

        internal void 7X(0I 0AD)
        {
            if (!0AD.XZ)
            {
                throw new ArgumentException("Mask images must be monochrome.");
            }
            this.SE = 0AD;
            0AD.SD = true;
        }

        public override int 7Y()
        {
            return this.SC.GetHashCode();
        }

        public override bool 7Z(object 0AE)
        {
            int num3;
            int num4;
            0I i1 = (0AE as 0I);
            if (i1 == null)
            {
                return false;
            }
            if (this.SD != i1.SD)
            {
                return false;
            }
            if (((this.S9 != i1.S9) || (this.S8 != i1.S8)) || ((this.SB != i1.SB) || (this.SA != i1.SA)))
            {
                return false;
            }
            int num1 = this.S8;
            int num2 = (this.S8 + this.S9);
            for (num3 = num1; (num3 < num2); num3 += 1)
            {
                if (this.SC[num3] != i1.SC[num3])
                {
                    return false;
                }
            }
            num1 = this.SA;
            num2 = (this.SA + this.SB);
            for (num4 = num1; (num4 < num2); num4 += 1)
            {
                if (this.SC[num4] != i1.SC[num4])
                {
                    return false;
                }
            }
            return true;
        }

        private byte[] 80(CompressionEnum 0AG)
        {
            MemoryStream stream1 = new MemoryStream();
            Stream stream2 = stream1;
            if (0AG != CompressionEnum.None)
            {
                stream2 = new X(stream1, 0AG);
            }
            short num1 = this.S7.SJ;
            if (num1 <= 8)
            {
                if (num1 == 1)
                {
                    goto Label_0042;
                }
                if (num1 == 4)
                {
                    goto Label_004B;
                }
                if (num1 == 8)
                {
                    goto Label_0054;
                }
                goto Label_0076;
            }
            if (num1 == 16)
            {
                goto Label_005D;
            }
            if (num1 == 24)
            {
                goto Label_0066;
            }
            if (num1 == 32)
            {
                goto Label_006F;
            }
            goto Label_0076;
        Label_0042:
            this.81(stream2);
            goto Label_0076;
        Label_004B:
            this.82(stream2);
            goto Label_0076;
        Label_0054:
            this.83(stream2);
            goto Label_0076;
        Label_005D:
            this.84(stream2);
            goto Label_0076;
        Label_0066:
            this.85(stream2);
            goto Label_0076;
        Label_006F:
            this.85(stream2);
        Label_0076:
            stream2.Close();
            return stream1.ToArray();
        }

        private void 81(Stream 0AH)
        {
            int num4;
            int num5;
            int num6;
            int num7;
            byte num8;
            Size size1 = this.Y0;
            int num1 = size1.Height;
            int num2 = this.Y1;
            bool flag1 = false;
            size1 = this.Y0;
            int num3 = (size1.Width / 8);
            size1 = this.Y0;
            if ((size1.Width % 8) != 0)
            {
                num3 += 1;
            }
            bool flag2 = ((bool) (((this.S7.SQ.Length <= 1) || (this.S7.SQ[0] == 0)) ? 0 : (this.S7.SQ[1] == 0)));
            for (num4 = 0; (num4 < num1); num4 += 1)
            {
                num5 = (flag1 ? num4 : ((num1 - num4) - 1));
                for (num6 = 0; (num6 < num3); num6 += 1)
                {
                    num7 = ((num5 * num2) + num6);
                    num8 = this.SC[(this.SA + num7)];
                    if (flag2)
                    {
                        num8 = ~num8;
                    }
                    0AH.WriteByte(num8);
                }
            }
        }

        private void 82(Stream 0AI)
        {
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            Size size1 = this.Y0;
            int num1 = size1.Height;
            int num2 = this.Y1;
            bool flag1 = false;
            for (num3 = 0; (num3 < num1); num3 += 1)
            {
                for (num4 = 0; (num4 < this.S7.SG); num4 += 2)
                {
                    num5 = (flag1 ? num3 : ((num1 - num3) - 1));
                    num6 = ((num5 * num2) + (num4 / 2));
                    num7 = ((int) ((this.SC[(this.SA + num6)] >> 4) & 15));
                    num8 = this.S7.SQ[num7];
                    0AI.WriteByte(((byte) ((num8 >> 16) & 255)));
                    0AI.WriteByte(((byte) ((num8 >> 8) & 255)));
                    0AI.WriteByte(((byte) (num8 & 255)));
                    if ((num4 + 1) >= this.S7.SG)
                    {
                        break;
                    }
                    num7 = ((int) (this.SC[(this.SA + num6)] & 15));
                    num8 = this.S7.SQ[num7];
                    0AI.WriteByte(((byte) ((num8 >> 16) & 255)));
                    0AI.WriteByte(((byte) ((num8 >> 8) & 255)));
                    0AI.WriteByte(((byte) (num8 & 255)));
                }
            }
        }

        private void 83(Stream 0AJ)
        {
            int num3;
            int num4;
            int num5;
            int num6;
            byte num7;
            int num8;
            Size size1 = this.Y0;
            int num1 = size1.Height;
            int num2 = this.Y1;
            bool flag1 = false;
            for (num3 = 0; (num3 < num1); num3 += 1)
            {
                for (num4 = 0; (num4 < this.S7.SG); num4 += 1)
                {
                    num5 = (flag1 ? num3 : ((num1 - num3) - 1));
                    num6 = ((num5 * num2) + num4);
                    num7 = this.SC[(this.SA + num6)];
                    num8 = this.S7.SQ[num7];
                    0AJ.WriteByte(((byte) ((num8 >> 16) & 255)));
                    0AJ.WriteByte(((byte) ((num8 >> 8) & 255)));
                    0AJ.WriteByte(((byte) (num8 & 255)));
                }
            }
        }

        private void 84(Stream 0AK)
        {
            int num3;
            int num4;
            int num5;
            int num6;
            short num7;
            Size size1 = this.Y0;
            int num1 = size1.Height;
            int num2 = this.Y1;
            bool flag1 = false;
            for (num3 = 0; (num3 < num1); num3 += 1)
            {
                for (num4 = 0; (num4 < this.S7.SG); num4 += 1)
                {
                    num5 = (flag1 ? num3 : ((num1 - num3) - 1));
                    num6 = ((num5 * num2) + (2 * num4));
                    num7 = ((short) (this.SC[(this.SA + num6)] | (this.SC[((this.SA + num6) + 1)] << 8)));
                    0AK.WriteByte(((byte) (((num7 >> 10) & 255) << 3)));
                    0AK.WriteByte(((byte) (((num7 >> 5) & 255) << 3)));
                    0AK.WriteByte(((byte) ((num7 & 255) << 3)));
                }
            }
        }

        private void 85(Stream 0AL)
        {
            int num4;
            int num5;
            int num6;
            int num7;
            Size size1 = this.Y0;
            int num1 = size1.Height;
            int num2 = this.Y1;
            bool flag1 = false;
            int num3 = ((this.S7.SJ == 24) ? 3 : 4);
            for (num4 = 0; (num4 < num1); num4 += 1)
            {
                for (num5 = 0; (num5 < this.S7.SG); num5 += 1)
                {
                    num6 = (flag1 ? num4 : ((num1 - num4) - 1));
                    num7 = ((num6 * num2) + (num5 * num3));
                    0AL.WriteByte(this.SC[((this.SA + num7) + 2)]);
                    0AL.WriteByte(this.SC[((this.SA + num7) + 1)]);
                    0AL.WriteByte(this.SC[(this.SA + num7)]);
                }
            }
        }


        // Properties
        internal bool XY
        {
            get
            {
                if ((this.S7 == null) || (this.SC == null))
                {
                    return false;
                }
                if ((this.S7.SK != 0) || (this.S7.SI != 1))
                {
                    return false;
                }
                int num1 = ((int) this.S7.SJ);
                if ((((num1 != 1) && (num1 != 4)) && ((num1 != 8) && (num1 != 16))) && ((num1 != 24) && (num1 != 32)))
                {
                    return false;
                }
                return true;
            }
        }

        internal bool XZ
        {
            get
            {
                return (this.S7.SJ == 1);
            }
        }

        internal Size Y0
        {
            get
            {
                return new Size(this.S7.SG, Math.Abs(this.S7.SH));
            }
        }

        internal int Y1
        {
            get
            {
                Size size1 = this.Y0;
                return (this.S7.SL / size1.Height);
            }
        }


        // Fields
        private 0J S7;
        private int S8;
        private int S9;
        private int SA;
        private int SB;
        private byte[] SC;
        private bool SD;
        private 0I SE;

        // Nested Types
        private class 0J
        {
            // Methods
            internal 0J(BinaryReader br)
            {
                int num4;
                this.SF = br.ReadInt32();
                this.SG = br.ReadInt32();
                this.SH = br.ReadInt32();
                this.SI = br.ReadInt16();
                this.SJ = br.ReadInt16();
                this.SK = br.ReadInt32();
                this.SL = br.ReadInt32();
                this.SM = br.ReadInt32();
                this.SN = br.ReadInt32();
                this.SO = br.ReadInt32();
                this.SP = br.ReadInt32();
                int num1 = ((int) ((((this.SJ * this.SG) + 31) / 32) * 4));
                int num2 = (num1 * Math.Abs(this.SH));
                if (this.SL == 0)
                {
                    this.SL = num2;
                }
                int num3 = 0;
                if (this.SJ >= 16)
                {
                    goto Label_0103;
                }
                if (this.SO > 0)
                {
                    num3 = this.SO;
                    goto Label_0103;
                }
                short num5 = this.SJ;
                if (num5 != 1)
                {
                    if (num5 == 4)
                    {
                        goto Label_00F8;
                    }
                    if (num5 == 8)
                    {
                        goto Label_00FD;
                    }
                    goto Label_0103;
                }
                num3 = 2;
                goto Label_0103;
            Label_00F8:
                num3 = 16;
                goto Label_0103;
            Label_00FD:
                num3 = 256;
            Label_0103:
                this.SQ = new int[((uint) num3)];
                for (num4 = 0; (num4 < num3); num4 += 1)
                {
                    this.SQ[num4] = br.ReadInt32();
                }
            }


            // Fields
            internal int SF;
            internal int SG;
            internal int SH;
            internal short SI;
            internal short SJ;
            internal int SK;
            internal int SL;
            internal int SM;
            internal int SN;
            internal int SO;
            internal int SP;
            internal int[] SQ;
        }
    }
}


namespace C1.C1Zip.ZLib
{
    using System;

    internal class N
    {
        // Methods
        static N()
        {
            N.GN = new int[17] { 0, 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023, 2047, 4095, 8191, 16383, 32767, 65535 };
            N.GO = new int[19] { 16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 14, 1, 15 };
        }

        internal N(T z, object checkfn, int w)
        {
            this.GU = new int[1];
            this.GV = new int[1];
            this.GY = new int[4320];
            this.H2 = new byte[((uint) w)];
            this.H3 = w;
            this.GZ = checkfn;
            this.GP = 0;
            this.41(z, null);
        }

        internal void 41(T 03A, long[] 03B)
        {
            long num2;
            if (03B != null)
            {
                03B[0] = this.H6;
            }
            if ((this.GP == 4) || (this.GP == 5))
            {
                this.GT = null;
            }
            if (this.GP == 6)
            {
                this.GW.47(03A);
            }
            this.GP = 0;
            this.H0 = 0;
            this.H1 = 0;
            int num1 = 0;
            this.H5 = num1;
            this.H4 = num1;
            if (this.GZ != null)
            {
                num2 = 03A.LW.2T(((long) 0), null, 0, 0);
                this.H6 = num2;
                03A.LV = num2;
            }
        }

        internal int 42(T 03C, int 03D)
        {
            int[] numArray1;
            int[] numArray2;
            int[][] numArrayArray1;
            int[][] numArrayArray2;
            int num8;
            int num9;
            int num10;
            int num11;
            int num4 = 03C.LK;
            int num5 = 03C.LL;
            int num2 = this.H1;
            int num3 = this.H0;
            int num6 = this.H5;
            int num7 = ((num6 < this.H4) ? ((this.H4 - num6) - 1) : (this.H3 - num6));
        Label_0047:
            num11 = this.GP;
            switch (num11)
            {
                case 0:
                {
                    goto Label_00F4;
                }
                case 1:
                {
                    goto Label_0290;
                }
                case 2:
                {
                    if (num5 != 0)
                    {
                        goto Label_037F;
                    }
                    this.H1 = num2;
                    this.H0 = num3;
                    03C.LL = num5;
                    T t5 = 03C;
                    03C.LM = (t5.LM + ((long) (num4 - 03C.LK)));
                    03C.LK = num4;
                    this.H5 = num6;
                    return this.45(03C, 03D);
                }
                case 3:
                {
                    goto Label_0564;
                }
                case 4:
                {
                    goto Label_06C1;
                }
                case 5:
                {
                    goto Label_0795;
                }
                case 6:
                {
                    goto Label_0B35;
                }
                case 7:
                {
                    goto Label_0BFE;
                }
                case 8:
                {
                    goto Label_0C93;
                }
                case 9:
                {
                    03D = -3;
                    this.H1 = num2;
                    this.H0 = num3;
                    03C.LL = num5;
                    T t18 = 03C;
                    03C.LM = (t18.LM + ((long) (num4 - 03C.LK)));
                    03C.LK = num4;
                    this.H5 = num6;
                    return this.45(03C, 03D);
                }
            }
            goto Label_0D22;
        Label_0083:
            if (num5 != 0)
            {
                03D = 0;
            }
            else
            {
                this.H1 = num2;
                this.H0 = num3;
                03C.LL = num5;
                T t1 = 03C;
                03C.LM = (t1.LM + ((long) (num4 - 03C.LK)));
                03C.LK = num4;
                this.H5 = num6;
                return this.45(03C, 03D);
            }
            num5 -= 1;
            int num12 = num4;
            num4 = (num12 + 1);
            num2 |= ((03C.LJ[num4] & 255) << (num3 & 31));
            num3 += 8;
        Label_00F4:
            if (num3 < 3)
            {
                goto Label_0083;
            }
            int num1 = (num2 & 7);
            this.GX = (num1 & 1);
            num11 = (num1 >> 1);
            switch (num11)
            {
                case 0:
                {
                    num2 = (num2 >> 3);
                    num3 -= 3;
                    num1 = (num3 & 7);
                    num2 = (num2 >> (num1 & 31));
                    num3 -= num1;
                    this.GP = 1;
                    goto Label_0047;
                }
                case 1:
                {
                    numArray1 = new int[1];
                    numArray2 = new int[1];
                    numArrayArray1 = new int[1][];
                    numArrayArray2 = new int[1][];
                    Q.4I(numArray1, numArray2, numArrayArray1, numArrayArray2, 03C);
                    this.GW = new O(numArray1[0], numArray2[0], numArrayArray1[0], numArrayArray2[0], 03C);
                    num2 = (num2 >> 3);
                    num3 -= 3;
                    this.GP = 6;
                    goto Label_0047;
                }
                case 2:
                {
                    num2 = (num2 >> 3);
                    num3 -= 3;
                    this.GP = 3;
                    goto Label_0047;
                }
                case 3:
                {
                    num2 = (num2 >> 3);
                    num3 -= 3;
                    this.GP = 9;
                    03C.LR = "invalid block type";
                    03D = -3;
                    this.H1 = num2;
                    this.H0 = num3;
                    03C.LL = num5;
                    T t2 = 03C;
                    03C.LM = (t2.LM + ((long) (num4 - 03C.LK)));
                    03C.LK = num4;
                    this.H5 = num6;
                    return this.45(03C, 03D);
                }
            }
            goto Label_0047;
        Label_021F:
            if (num5 != 0)
            {
                03D = 0;
            }
            else
            {
                this.H1 = num2;
                this.H0 = num3;
                03C.LL = num5;
                T t3 = 03C;
                03C.LM = (t3.LM + ((long) (num4 - 03C.LK)));
                03C.LK = num4;
                this.H5 = num6;
                return this.45(03C, 03D);
            }
            num5 -= 1;
            int num13 = num4;
            num4 = (num13 + 1);
            num2 |= ((03C.LJ[num4] & 255) << (num3 & 31));
            num3 += 8;
        Label_0290:
            if (num3 < 32)
            {
                goto Label_021F;
            }
            if (((~num2 >> 16) & 65535) != (num2 & 65535))
            {
                this.GP = 9;
                03C.LR = "invalid stored block lengths";
                03D = -3;
                this.H1 = num2;
                this.H0 = num3;
                03C.LL = num5;
                T t4 = 03C;
                03C.LM = (t4.LM + ((long) (num4 - 03C.LK)));
                03C.LK = num4;
                this.H5 = num6;
                return this.45(03C, 03D);
            }
            this.GQ = (num2 & 65535);
            num3 = 0;
            num2 = num3;
            this.GP = ((this.GX != 0) ? ((this.GQ != 0) ? 2 : 7) : 0);
            goto Label_0047;
        Label_037F:
            if (num7 == 0)
            {
                if ((num6 == this.H3) && (this.H4 != 0))
                {
                    num6 = 0;
                    num7 = ((num6 < this.H4) ? ((this.H4 - num6) - 1) : (this.H3 - num6));
                }
                if (num7 == 0)
                {
                    this.H5 = num6;
                    03D = this.45(03C, 03D);
                    num6 = this.H5;
                    num7 = ((num6 < this.H4) ? ((this.H4 - num6) - 1) : (this.H3 - num6));
                    if ((num6 == this.H3) && (this.H4 != 0))
                    {
                        num6 = 0;
                        num7 = ((num6 < this.H4) ? ((this.H4 - num6) - 1) : (this.H3 - num6));
                    }
                    if (num7 == 0)
                    {
                        this.H1 = num2;
                        this.H0 = num3;
                        03C.LL = num5;
                        T t6 = 03C;
                        03C.LM = (t6.LM + ((long) (num4 - 03C.LK)));
                        03C.LK = num4;
                        this.H5 = num6;
                        return this.45(03C, 03D);
                    }
                }
            }
            03D = 0;
            num1 = this.GQ;
            if (num1 > num5)
            {
                num1 = num5;
            }
            if (num1 > num7)
            {
                num1 = num7;
            }
            Array.Copy(03C.LJ, num4, this.H2, num6, num1);
            num4 += num1;
            num5 -= num1;
            num6 += num1;
            num7 -= num1;
            num11 = (this.GQ - num1);
            this.GQ = num11;
            if (num11 != 0)
            {
                goto Label_0047;
            }
            this.GP = ((this.GX != 0) ? 7 : 0);
            goto Label_0047;
        Label_04F3:
            if (num5 != 0)
            {
                03D = 0;
            }
            else
            {
                this.H1 = num2;
                this.H0 = num3;
                03C.LL = num5;
                T t7 = 03C;
                03C.LM = (t7.LM + ((long) (num4 - 03C.LK)));
                03C.LK = num4;
                this.H5 = num6;
                return this.45(03C, 03D);
            }
            num5 -= 1;
            int num14 = num4;
            num4 = (num14 + 1);
            num2 |= ((03C.LJ[num4] & 255) << (num3 & 31));
            num3 += 8;
        Label_0564:
            if (num3 < 14)
            {
                goto Label_04F3;
            }
            num1 = (num2 & 16383);
            this.GR = num1;
            if (((num1 & 31) > 29) || (((num1 >> 5) & 31) > 29))
            {
                this.GP = 9;
                03C.LR = "too many length or distance symbols";
                03D = -3;
                this.H1 = num2;
                this.H0 = num3;
                03C.LL = num5;
                T t8 = 03C;
                03C.LM = (t8.LM + ((long) (num4 - 03C.LK)));
                03C.LK = num4;
                this.H5 = num6;
                return this.45(03C, 03D);
            }
            num1 = ((258 + (num1 & 31)) + ((num1 >> 5) & 31));
            this.GT = new int[((uint) num1)];
            num2 = (num2 >> 14);
            num3 -= 14;
            this.GS = 0;
            this.GP = 4;
            goto Label_06C1;
        Label_0621:
            if (num5 != 0)
            {
                03D = 0;
            }
            else
            {
                this.H1 = num2;
                this.H0 = num3;
                03C.LL = num5;
                T t9 = 03C;
                03C.LM = (t9.LM + ((long) (num4 - 03C.LK)));
                03C.LK = num4;
                this.H5 = num6;
                return this.45(03C, 03D);
            }
            num5 -= 1;
            int num15 = num4;
            num4 = (num15 + 1);
            num2 |= ((03C.LJ[num4] & 255) << (num3 & 31));
            num3 += 8;
        Label_0692:
            if (num3 < 3)
            {
                goto Label_0621;
            }
            num11 = this.GS;
            this.GS = (num11 + 1);
            this.GT[N.GO[num11]] = (num2 & 7);
            num2 = (num2 >> 3);
            num3 -= 3;
        Label_06C1:
            if (this.GS < (4 + (this.GR >> 10)))
            {
                goto Label_0692;
            }
            while ((this.GS < 19))
            {
                num11 = this.GS;
                this.GS = (num11 + 1);
                this.GT[N.GO[num11]] = 0;
            }
            this.GU[0] = 7;
            num1 = Q.4G(this.GT, this.GU, this.GV, this.GY, 03C);
            if (num1 != 0)
            {
                this.GT = null;
                03D = num1;
                if (03D == -3)
                {
                    this.GP = 9;
                }
                this.H1 = num2;
                this.H0 = num3;
                03C.LL = num5;
                T t10 = 03C;
                03C.LM = (t10.LM + ((long) (num4 - 03C.LK)));
                03C.LK = num4;
                this.H5 = num6;
                return this.45(03C, 03D);
            }
            this.GS = 0;
            this.GP = 5;
        Label_0795:
            num1 = this.GR;
            if (this.GS < ((258 + (num1 & 31)) + ((num1 >> 5) & 31)))
            {
                num1 = this.GU[0];
                while ((num3 < num1))
                {
                    if (num5 != 0)
                    {
                        03D = 0;
                    }
                    else
                    {
                        this.H1 = num2;
                        this.H0 = num3;
                        03C.LL = num5;
                        T t11 = 03C;
                        03C.LM = (t11.LM + ((long) (num4 - 03C.LK)));
                        03C.LK = num4;
                        this.H5 = num6;
                        return this.45(03C, 03D);
                    }
                    num5 -= 1;
                    int num16 = num4;
                    num4 = (num16 + 1);
                    num2 |= ((03C.LJ[num4] & 255) << (num3 & 31));
                    num3 += 8;
                }
                this.GV[0];
                num1 = this.GY[(((this.GV[0] + (num2 & N.GN[num1])) * 3) + 1)];
                num10 = this.GY[(((this.GV[0] + (num2 & N.GN[num1])) * 3) + 2)];
                if (num10 < 16)
                {
                    num2 = (num2 >> (num1 & 31));
                    num3 -= num1;
                    num11 = this.GS;
                    this.GS = (num11 + 1);
                    this.GT[num11] = num10;
                    goto Label_0795;
                }
                num8 = ((num10 == 18) ? 7 : (num10 - 14));
                num9 = ((num10 == 18) ? 11 : 3);
                while ((num3 < (num1 + num8)))
                {
                    if (num5 != 0)
                    {
                        03D = 0;
                    }
                    else
                    {
                        this.H1 = num2;
                        this.H0 = num3;
                        03C.LL = num5;
                        T t12 = 03C;
                        03C.LM = (t12.LM + ((long) (num4 - 03C.LK)));
                        03C.LK = num4;
                        this.H5 = num6;
                        return this.45(03C, 03D);
                    }
                    num5 -= 1;
                    int num17 = num4;
                    num4 = (num17 + 1);
                    num2 |= ((03C.LJ[num4] & 255) << (num3 & 31));
                    num3 += 8;
                }
                num2 = (num2 >> (num1 & 31));
                num3 -= num1;
                num9 += (num2 & N.GN[num8]);
                num2 = (num2 >> (num8 & 31));
                num3 -= num8;
                num8 = this.GS;
                num1 = this.GR;
                if (((num8 + num9) > ((258 + (num1 & 31)) + ((num1 >> 5) & 31))) || ((num10 == 16) && (num8 < 1)))
                {
                    this.GT = null;
                    this.GP = 9;
                    03C.LR = "invalid bit length repeat";
                    03D = -3;
                    this.H1 = num2;
                    this.H0 = num3;
                    03C.LL = num5;
                    T t13 = 03C;
                    03C.LM = (t13.LM + ((long) (num4 - 03C.LK)));
                    03C.LK = num4;
                    this.H5 = num6;
                    return this.45(03C, 03D);
                }
                num10 = ((num10 == 16) ? this.GT[(num8 - 1)] : 0);
                do
                {
                    int num18 = num8;
                    num8 = (num18 + 1);
                    this.GT[num8] = num10;
                    num9 -= 1;
                }
                while ((num9 != 0));
                this.GS = num8;
                goto Label_0795;
            }
            this.GV[0] = -1;
            int[] numArray3 = new int[1];
            int[] numArray4 = new int[1];
            int[] numArray5 = new int[1];
            int[] numArray6 = new int[1];
            numArray3[0] = 9;
            numArray4[0] = 6;
            num1 = this.GR;
            num1 = Q.4H((257 + (num1 & 31)), (1 + ((num1 >> 5) & 31)), this.GT, numArray3, numArray4, numArray5, numArray6, this.GY, 03C);
            this.GT = null;
            if (num1 != 0)
            {
                if (num1 == -3)
                {
                    this.GP = 9;
                }
                03D = num1;
                this.H1 = num2;
                this.H0 = num3;
                03C.LL = num5;
                T t14 = 03C;
                03C.LM = (t14.LM + ((long) (num4 - 03C.LK)));
                03C.LK = num4;
                this.H5 = num6;
                return this.45(03C, 03D);
            }
            this.GW = new O(numArray3[0], numArray4[0], this.GY, numArray5[0], this.GY, numArray6[0], 03C);
            this.GP = 6;
        Label_0B35:
            this.H1 = num2;
            this.H0 = num3;
            03C.LL = num5;
            T t15 = 03C;
            03C.LM = (t15.LM + ((long) (num4 - 03C.LK)));
            03C.LK = num4;
            this.H5 = num6;
            03D = this.GW.46(this, 03C, 03D);
            if (03D != 1)
            {
                return this.45(03C, 03D);
            }
            03D = 0;
            this.GW.47(03C);
            num4 = 03C.LK;
            num5 = 03C.LL;
            num2 = this.H1;
            num3 = this.H0;
            num6 = this.H5;
            num7 = ((num6 < this.H4) ? ((this.H4 - num6) - 1) : (this.H3 - num6));
            if (this.GX == 0)
            {
                this.GP = 0;
                goto Label_0047;
            }
            this.GP = 7;
        Label_0BFE:
            this.H5 = num6;
            03D = this.45(03C, 03D);
            num6 = this.H5;
            num7 = ((num6 < this.H4) ? ((this.H4 - num6) - 1) : (this.H3 - num6));
            if (this.H4 != this.H5)
            {
                this.H1 = num2;
                this.H0 = num3;
                03C.LL = num5;
                T t16 = 03C;
                03C.LM = (t16.LM + ((long) (num4 - 03C.LK)));
                03C.LK = num4;
                this.H5 = num6;
                return this.45(03C, 03D);
            }
            this.GP = 8;
        Label_0C93:
            03D = 1;
            this.H1 = num2;
            this.H0 = num3;
            03C.LL = num5;
            T t17 = 03C;
            03C.LM = (t17.LM + ((long) (num4 - 03C.LK)));
            03C.LK = num4;
            this.H5 = num6;
            return this.45(03C, 03D);
        Label_0D22:
            03D = -2;
            this.H1 = num2;
            this.H0 = num3;
            03C.LL = num5;
            T t19 = 03C;
            03C.LM = (t19.LM + ((long) (num4 - 03C.LK)));
            03C.LK = num4;
            this.H5 = num6;
            return this.45(03C, 03D);
        }

        internal void 43(T 03E)
        {
            this.41(03E, null);
            this.H2 = null;
            this.GY = null;
        }

        internal void 44(byte[] 03F, int 03G, int 03H)
        {
            Array.Copy(03F, 03G, this.H2, 0, 03H);
            int num1 = 03H;
            this.H5 = num1;
            this.H4 = num1;
        }

        internal int 45(T 03I, int 03J)
        {
            long num4;
            int num2 = 03I.LO;
            int num3 = this.H4;
            int num1 = (((num3 <= this.H5) ? this.H5 : this.H3) - num3);
            if (num1 > 03I.LP)
            {
                num1 = 03I.LP;
            }
            if ((num1 != 0) && (03J == -5))
            {
                03J = 0;
            }
            T t1 = 03I;
            03I.LP = (t1.LP - num1);
            T t2 = 03I;
            03I.LQ = (t2.LQ + ((long) num1));
            if (this.GZ != null)
            {
                num4 = 03I.LW.2T(this.H6, this.H2, num3, num1);
                this.H6 = num4;
                03I.LV = num4;
            }
            Array.Copy(this.H2, num3, 03I.LN, num2, num1);
            num2 += num1;
            num3 += num1;
            if (num3 == this.H3)
            {
                num3 = 0;
                if (this.H5 == this.H3)
                {
                    this.H5 = 0;
                }
                num1 = (this.H5 - num3);
                if (num1 > 03I.LP)
                {
                    num1 = 03I.LP;
                }
                if ((num1 != 0) && (03J == -5))
                {
                    03J = 0;
                }
                T t3 = 03I;
                03I.LP = (t3.LP - num1);
                T t4 = 03I;
                03I.LQ = (t4.LQ + ((long) num1));
                if (this.GZ != null)
                {
                    num4 = 03I.LW.2T(this.H6, this.H2, num3, num1);
                    this.H6 = num4;
                    03I.LV = num4;
                }
                Array.Copy(this.H2, num3, 03I.LN, num2, num1);
                num2 += num1;
                num3 += num1;
            }
            03I.LO = num2;
            this.H4 = num3;
            return 03J;
        }


        // Fields
        private const int G3 = 1440;
        private const int G4 = 0;
        private const int G5 = 1;
        private const int G6 = 2;
        private const int G7 = -1;
        private const int G8 = -2;
        private const int G9 = -3;
        private const int GA = -4;
        private const int GB = -5;
        private const int GC = -6;
        private const int GD = 0;
        private const int GE = 1;
        private const int GF = 2;
        private const int GG = 3;
        private const int GH = 4;
        private const int GI = 5;
        private const int GJ = 6;
        private const int GK = 7;
        private const int GL = 8;
        private const int GM = 9;
        private static int[] GN;
        private static int[] GO;
        private int GP;
        private int GQ;
        private int GR;
        private int GS;
        private int[] GT;
        private int[] GU;
        private int[] GV;
        private O GW;
        private int GX;
        private int[] GY;
        private object GZ;
        internal int H0;
        internal int H1;
        internal byte[] H2;
        internal int H3;
        internal int H4;
        internal int H5;
        internal long H6;
    }
}


namespace C1.C1Zip.ZLib
{
    using System;

    internal class O
    {
        // Methods
        static O()
        {
            O.HQ = new int[17] { 0, 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023, 2047, 4095, 8191, 16383, 32767, 65535 };
        }

        internal O(int bl, int bd, int[] tl, int[] td, T z)
        {
            this.HU = 0;
            this.HR = 0;
            this.HZ = ((byte) bl);
            this.I0 = ((byte) bd);
            this.I1 = tl;
            this.I2 = 0;
            this.I3 = td;
            this.I4 = 0;
        }

        internal O(int bl, int bd, int[] tl, int tl_index, int[] td, int td_index, T z)
        {
            this.HU = 0;
            this.HR = 0;
            this.HZ = ((byte) bl);
            this.I0 = ((byte) bd);
            this.I1 = tl;
            this.I2 = tl_index;
            this.I3 = td;
            this.I4 = td_index;
        }

        internal int 46(N 03K, T 03L, int 03M)
        {
            int num1;
            int num11;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            num6 = 03L.LK;
            int num7 = 03L.LL;
            num4 = 03K.H1;
            num5 = 03K.H0;
            int num8 = 03K.H5;
            int num9 = ((num8 < 03K.H4) ? ((03K.H4 - num8) - 1) : (03K.H3 - num8));
        Label_0051:
            num11 = this.HR;
            switch (num11)
            {
                case 0:
                {
                    if ((num9 < 258) || (num7 < 10))
                    {
                        goto Label_016E;
                    }
                    03K.H1 = num4;
                    03K.H0 = num5;
                    03L.LL = num7;
                    T t1 = 03L;
                    03L.LM = (t1.LM + ((long) (num6 - 03L.LK)));
                    03L.LK = num6;
                    03K.H5 = num8;
                    03M = this.48(this.HZ, this.I0, this.I1, this.I2, this.I3, this.I4, 03K, 03L);
                    num6 = 03L.LK;
                    num7 = 03L.LL;
                    num4 = 03K.H1;
                    num5 = 03K.H0;
                    num8 = 03K.H5;
                    num9 = ((num8 < 03K.H4) ? ((03K.H4 - num8) - 1) : (03K.H3 - num8));
                    if (03M == 0)
                    {
                        goto Label_016E;
                    }
                    this.HR = ((03M == 1) ? 7 : 9);
                    goto Label_0051;
                }
                case 1:
                {
                    goto Label_0199;
                }
                case 2:
                {
                    num1 = this.HX;
                    goto Label_03BE;
                }
                case 3:
                {
                    goto Label_0411;
                }
                case 4:
                {
                    num1 = this.HX;
                    goto Label_0605;
                }
                case 5:
                {
                    goto Label_0634;
                }
                case 6:
                {
                    if (num9 == 0)
                    {
                        if ((num8 == 03K.H3) && (03K.H4 != 0))
                        {
                            num8 = 0;
                            num9 = ((num8 < 03K.H4) ? ((03K.H4 - num8) - 1) : (03K.H3 - num8));
                        }
                        if (num9 == 0)
                        {
                            03K.H5 = num8;
                            03M = 03K.45(03L, 03M);
                            num8 = 03K.H5;
                            num9 = ((num8 < 03K.H4) ? ((03K.H4 - num8) - 1) : (03K.H3 - num8));
                            if ((num8 == 03K.H3) && (03K.H4 != 0))
                            {
                                num8 = 0;
                                num9 = ((num8 < 03K.H4) ? ((03K.H4 - num8) - 1) : (03K.H3 - num8));
                            }
                            if (num9 == 0)
                            {
                                03K.H1 = num4;
                                03K.H0 = num5;
                                03L.LL = num7;
                                T t9 = 03L;
                                03L.LM = (t9.LM + ((long) (num6 - 03L.LK)));
                                03L.LK = num6;
                                03K.H5 = num8;
                                return 03K.45(03L, 03M);
                            }
                        }
                    }
                    03M = 0;
                    int num18 = num8;
                    num8 = (num18 + 1);
                    03K.H2[num8] = ((byte) this.HW);
                    num9 -= 1;
                    this.HR = 0;
                    goto Label_0051;
                }
                case 7:
                {
                    goto Label_08E4;
                }
                case 8:
                {
                    goto Label_0993;
                }
                case 9:
                {
                    03M = -3;
                    03K.H1 = num4;
                    03K.H0 = num5;
                    03L.LL = num7;
                    T t12 = 03L;
                    03L.LM = (t12.LM + ((long) (num6 - 03L.LK)));
                    03L.LK = num6;
                    03K.H5 = num8;
                    return 03K.45(03L, 03M);
                }
            }
            goto Label_0A28;
        Label_016E:
            this.HV = ((int) this.HZ);
            this.HT = this.I1;
            this.HU = this.I2;
            this.HR = 1;
        Label_0199:
            num1 = this.HV;
            while ((num5 < num1))
            {
                if (num7 != 0)
                {
                    03M = 0;
                }
                else
                {
                    03K.H1 = num4;
                    03K.H0 = num5;
                    03L.LL = num7;
                    T t2 = 03L;
                    03L.LM = (t2.LM + ((long) (num6 - 03L.LK)));
                    03L.LK = num6;
                    03K.H5 = num8;
                    return 03K.45(03L, 03M);
                }
                num7 -= 1;
                int num12 = num6;
                num6 = (num12 + 1);
                num4 |= ((03L.LJ[num6] & 255) << (num5 & 31));
                num5 += 8;
            }
            int num2 = ((this.HU + (num4 & O.HQ[num1])) * 3);
            num4 = (num4 >> (this.HT[(num2 + 1)] & 31));
            num5 -= this.HT[(num2 + 1)];
            int num3 = this.HT[num2];
            if (num3 == 0)
            {
                this.HW = this.HT[(num2 + 2)];
                this.HR = 6;
                goto Label_0051;
            }
            if ((num3 & 16) != 0)
            {
                this.HX = (num3 & 15);
                this.HS = this.HT[(num2 + 2)];
                this.HR = 2;
                goto Label_0051;
            }
            if ((num3 & 64) == 0)
            {
                this.HV = num3;
                this.HU = ((num2 / 3) + this.HT[(num2 + 2)]);
                goto Label_0051;
            }
            if ((num3 & 32) != 0)
            {
                this.HR = 7;
                goto Label_0051;
            }
            this.HR = 9;
            03L.LR = "invalid literal/length code";
            03M = -3;
            03K.H1 = num4;
            03K.H0 = num5;
            03L.LL = num7;
            T t3 = 03L;
            03L.LM = (t3.LM + ((long) (num6 - 03L.LK)));
            03L.LK = num6;
            03K.H5 = num8;
            return 03K.45(03L, 03M);
        Label_0345:
            if (num7 != 0)
            {
                03M = 0;
            }
            else
            {
                03K.H1 = num4;
                03K.H0 = num5;
                03L.LL = num7;
                T t4 = 03L;
                03L.LM = (t4.LM + ((long) (num6 - 03L.LK)));
                03L.LK = num6;
                03K.H5 = num8;
                return 03K.45(03L, 03M);
            }
            num7 -= 1;
            int num13 = num6;
            num6 = (num13 + 1);
            num4 |= ((03L.LJ[num6] & 255) << (num5 & 31));
            num5 += 8;
        Label_03BE:
            if (num5 < num1)
            {
                goto Label_0345;
            }
            this.HS += (num4 & O.HQ[num1]);
            num4 = (num4 >> (num1 & 31));
            num5 -= num1;
            this.HV = ((int) this.I0);
            this.HT = this.I3;
            this.HU = this.I4;
            this.HR = 3;
        Label_0411:
            num1 = this.HV;
            while ((num5 < num1))
            {
                if (num7 != 0)
                {
                    03M = 0;
                }
                else
                {
                    03K.H1 = num4;
                    03K.H0 = num5;
                    03L.LL = num7;
                    T t5 = 03L;
                    03L.LM = (t5.LM + ((long) (num6 - 03L.LK)));
                    03L.LK = num6;
                    03K.H5 = num8;
                    return 03K.45(03L, 03M);
                }
                num7 -= 1;
                int num14 = num6;
                num6 = (num14 + 1);
                num4 |= ((03L.LJ[num6] & 255) << (num5 & 31));
                num5 += 8;
            }
            num2 = ((this.HU + (num4 & O.HQ[num1])) * 3);
            num4 = (num4 >> (this.HT[(num2 + 1)] & 31));
            num5 -= this.HT[(num2 + 1)];
            num3 = this.HT[num2];
            if ((num3 & 16) != 0)
            {
                this.HX = (num3 & 15);
                this.HY = this.HT[(num2 + 2)];
                this.HR = 4;
                goto Label_0051;
            }
            if ((num3 & 64) == 0)
            {
                this.HV = num3;
                this.HU = ((num2 / 3) + this.HT[(num2 + 2)]);
                goto Label_0051;
            }
            this.HR = 9;
            03L.LR = "invalid distance code";
            03M = -3;
            03K.H1 = num4;
            03K.H0 = num5;
            03L.LL = num7;
            T t6 = 03L;
            03L.LM = (t6.LM + ((long) (num6 - 03L.LK)));
            03L.LK = num6;
            03K.H5 = num8;
            return 03K.45(03L, 03M);
        Label_058C:
            if (num7 != 0)
            {
                03M = 0;
            }
            else
            {
                03K.H1 = num4;
                03K.H0 = num5;
                03L.LL = num7;
                T t7 = 03L;
                03L.LM = (t7.LM + ((long) (num6 - 03L.LK)));
                03L.LK = num6;
                03K.H5 = num8;
                return 03K.45(03L, 03M);
            }
            num7 -= 1;
            int num15 = num6;
            num6 = (num15 + 1);
            num4 |= ((03L.LJ[num6] & 255) << (num5 & 31));
            num5 += 8;
        Label_0605:
            if (num5 < num1)
            {
                goto Label_058C;
            }
            this.HY += (num4 & O.HQ[num1]);
            num4 = (num4 >> (num1 & 31));
            num5 -= num1;
            this.HR = 5;
        Label_0634:
            int num10 = ((num8 < this.HY) ? (03K.H3 - (this.HY - num8)) : (num8 - this.HY));
            while ((this.HS != 0))
            {
                if (num9 == 0)
                {
                    if ((num8 == 03K.H3) && (03K.H4 != 0))
                    {
                        num8 = 0;
                        num9 = ((num8 < 03K.H4) ? ((03K.H4 - num8) - 1) : (03K.H3 - num8));
                    }
                    if (num9 == 0)
                    {
                        03K.H5 = num8;
                        03M = 03K.45(03L, 03M);
                        num8 = 03K.H5;
                        num9 = ((num8 < 03K.H4) ? ((03K.H4 - num8) - 1) : (03K.H3 - num8));
                        if ((num8 == 03K.H3) && (03K.H4 != 0))
                        {
                            num8 = 0;
                            num9 = ((num8 < 03K.H4) ? ((03K.H4 - num8) - 1) : (03K.H3 - num8));
                        }
                        if (num9 == 0)
                        {
                            03K.H1 = num4;
                            03K.H0 = num5;
                            03L.LL = num7;
                            T t8 = 03L;
                            03L.LM = (t8.LM + ((long) (num6 - 03L.LK)));
                            03L.LK = num6;
                            03K.H5 = num8;
                            return 03K.45(03L, 03M);
                        }
                    }
                }
                int num16 = num8;
                num8 = (num16 + 1);
                int num17 = num10;
                num10 = (num17 + 1);
                03K.H2[num8] = 03K.H2[num10];
                num9 -= 1;
                if (num10 == 03K.H3)
                {
                    num10 = 0;
                }
                this.HS -= 1;
            }
            this.HR = 0;
            goto Label_0051;
        Label_08E4:
            if (num5 > 7)
            {
                num5 -= 8;
                num7 += 1;
                num6 -= 1;
            }
            03K.H5 = num8;
            03M = 03K.45(03L, 03M);
            num8 = 03K.H5;
            num9 = ((num8 < 03K.H4) ? ((03K.H4 - num8) - 1) : (03K.H3 - num8));
            if (03K.H4 != 03K.H5)
            {
                03K.H1 = num4;
                03K.H0 = num5;
                03L.LL = num7;
                T t10 = 03L;
                03L.LM = (t10.LM + ((long) (num6 - 03L.LK)));
                03L.LK = num6;
                03K.H5 = num8;
                return 03K.45(03L, 03M);
            }
            this.HR = 8;
        Label_0993:
            03M = 1;
            03K.H1 = num4;
            03K.H0 = num5;
            03L.LL = num7;
            T t11 = 03L;
            03L.LM = (t11.LM + ((long) (num6 - 03L.LK)));
            03L.LK = num6;
            03K.H5 = num8;
            return 03K.45(03L, 03M);
        Label_0A28:
            03M = -2;
            03K.H1 = num4;
            03K.H0 = num5;
            03L.LL = num7;
            T t13 = 03L;
            03L.LM = (t13.LM + ((long) (num6 - 03L.LK)));
            03L.LK = num6;
            03K.H5 = num8;
            return 03K.45(03L, 03M);
        }

        internal void 47(T 03N)
        {
        }

        private int 48(int 03O, int 03P, int[] 03Q, int 03R, int[] 03S, int 03T, N 03U, T 03V)
        {
            int num13;
            int num14;
            int num6 = 03V.LK;
            int num7 = 03V.LL;
            int num4 = 03U.H1;
            int num5 = 03U.H0;
            int num8 = 03U.H5;
            int num9 = ((num8 < 03U.H4) ? ((03U.H4 - num8) - 1) : (03U.H3 - num8));
            int num10 = O.HQ[03O];
            int num11 = O.HQ[03P];
        Label_0092:
            while ((num5 < 20))
            {
                num7 -= 1;
                int num15 = num6;
                num6 = (num15 + 1);
                num4 |= ((03V.LJ[num6] & 255) << (num5 & 31));
                num5 += 8;
            }
            int num1 = (num4 & num10);
            int[] numArray1 = 03Q;
            int num2 = 03R;
            int num3 = numArray1[((num2 + num1) * 3)];
            if (num3 == 0)
            {
                num4 = (num4 >> (numArray1[(((num2 + num1) * 3) + 1)] & 31));
                num5 -= numArray1[(((num2 + num1) * 3) + 1)];
                int num16 = num8;
                num8 = (num16 + 1);
                03U.H2[num8] = ((byte) numArray1[(((num2 + num1) * 3) + 2)]);
                num9 -= 1;
                goto Label_05CB;
            }
        Label_00F1:
            num4 = (num4 >> (numArray1[(((num2 + num1) * 3) + 1)] & 31));
            num5 -= numArray1[(((num2 + num1) * 3) + 1)];
            if ((num3 & 16) == 0)
            {
                goto Label_044E;
            }
            num3 &= 15;
            int num12 = (numArray1[(((num2 + num1) * 3) + 2)] + (num4 & O.HQ[num3]));
            num4 = (num4 >> (num3 & 31));
            num5 -= num3;
            while ((num5 < 15))
            {
                num7 -= 1;
                int num17 = num6;
                num6 = (num17 + 1);
                num4 |= ((03V.LJ[num6] & 255) << (num5 & 31));
                num5 += 8;
            }
            num1 = (num4 & num11);
            numArray1 = 03S;
            num2 = 03T;
            num3 = numArray1[((num2 + num1) * 3)];
        Label_018B:
            num4 = (num4 >> (numArray1[(((num2 + num1) * 3) + 1)] & 31));
            num5 -= numArray1[(((num2 + num1) * 3) + 1)];
            if ((num3 & 16) != 0)
            {
                num3 &= 15;
                while ((num5 < num3))
                {
                    num7 -= 1;
                    int num18 = num6;
                    num6 = (num18 + 1);
                    num4 |= ((03V.LJ[num6] & 255) << (num5 & 31));
                    num5 += 8;
                }
                num13 = (numArray1[(((num2 + num1) * 3) + 2)] + (num4 & O.HQ[num3]));
                num4 = (num4 >> (num3 & 31));
                num5 -= num3;
                num9 -= num12;
                if (num8 >= num13)
                {
                    num14 = (num8 - num13);
                    if (((num8 - num14) > 0) && (2 > (num8 - num14)))
                    {
                        int num19 = num8;
                        num8 = (num19 + 1);
                        int num20 = num14;
                        num14 = (num20 + 1);
                        03U.H2[num8] = 03U.H2[num14];
                        num12 -= 1;
                        int num21 = num8;
                        num8 = (num21 + 1);
                        int num22 = num14;
                        num14 = (num22 + 1);
                        03U.H2[num8] = 03U.H2[num14];
                        num12 -= 1;
                    }
                    else
                    {
                        Array.Copy(03U.H2, num14, 03U.H2, num8, 2);
                        num8 += 2;
                        num14 += 2;
                        num12 -= 2;
                    }
                }
                else
                {
                    num3 = (num13 - num8);
                    num14 = (03U.H3 - num3);
                    if (num12 > num3)
                    {
                        num12 -= num3;
                        if (((num8 - num14) > 0) && (num3 > (num8 - num14)))
                        {
                            do
                            {
                                int num23 = num8;
                                num8 = (num23 + 1);
                                int num24 = num14;
                                num14 = (num24 + 1);
                                03U.H2[num8] = 03U.H2[num14];
                                num3 -= 1;
                            }
                            while ((num3 != 0));
                        }
                        else
                        {
                            Array.Copy(03U.H2, num14, 03U.H2, num8, num3);
                            num8 += num3;
                            num14 += num3;
                            num3 = 0;
                        }
                        num14 = 0;
                    }
                }
                if (((num8 - num14) > 0) && (num12 > (num8 - num14)))
                {
                    do
                    {
                        int num25 = num8;
                        num8 = (num25 + 1);
                        int num26 = num14;
                        num14 = (num26 + 1);
                        03U.H2[num8] = 03U.H2[num14];
                        num12 -= 1;
                    }
                    while ((num12 != 0));
                    goto Label_05CB;
                }
                Array.Copy(03U.H2, num14, 03U.H2, num8, num12);
                num8 += num12;
                num14 += num12;
                num12 = 0;
                goto Label_05CB;
            }
            if ((num3 & 64) == 0)
            {
                num1 += numArray1[(((num2 + num1) * 3) + 2)];
                num1 += (num4 & O.HQ[num3]);
                num3 = numArray1[((num2 + num1) * 3)];
                goto Label_018B;
            }
            03V.LR = "invalid distance code";
            num12 = (03V.LL - num7);
            num12 = (((num5 >> 3) < num12) ? (num5 >> 3) : num12);
            num7 += num12;
            num6 -= num12;
            num5 -= (num12 << 3);
            03U.H1 = num4;
            03U.H0 = num5;
            03V.LL = num7;
            T t1 = 03V;
            03V.LM = (t1.LM + ((long) (num6 - 03V.LK)));
            03V.LK = num6;
            03U.H5 = num8;
            return -3;
        Label_044E:
            if ((num3 & 64) == 0)
            {
                num1 += numArray1[(((num2 + num1) * 3) + 2)];
                num1 += (num4 & O.HQ[num3]);
                num3 = numArray1[((num2 + num1) * 3)];
                if (num3 != 0)
                {
                    goto Label_00F1;
                }
                num4 = (num4 >> (numArray1[(((num2 + num1) * 3) + 1)] & 31));
                num5 -= numArray1[(((num2 + num1) * 3) + 1)];
                int num27 = num8;
                num8 = (num27 + 1);
                03U.H2[num8] = ((byte) numArray1[(((num2 + num1) * 3) + 2)]);
                num9 -= 1;
            }
            else
            {
                if ((num3 & 32) != 0)
                {
                    num12 = (03V.LL - num7);
                    num12 = (((num5 >> 3) < num12) ? (num5 >> 3) : num12);
                    num7 += num12;
                    num6 -= num12;
                    num5 -= (num12 << 3);
                    03U.H1 = num4;
                    03U.H0 = num5;
                    03V.LL = num7;
                    T t2 = 03V;
                    03V.LM = (t2.LM + ((long) (num6 - 03V.LK)));
                    03V.LK = num6;
                    03U.H5 = num8;
                    return 1;
                }
                03V.LR = "invalid literal/length code";
                num12 = (03V.LL - num7);
                num12 = (((num5 >> 3) < num12) ? (num5 >> 3) : num12);
                num7 += num12;
                num6 -= num12;
                num5 -= (num12 << 3);
                03U.H1 = num4;
                03U.H0 = num5;
                03V.LL = num7;
                T t3 = 03V;
                03V.LM = (t3.LM + ((long) (num6 - 03V.LK)));
                03V.LK = num6;
                03U.H5 = num8;
                return -3;
            }
        Label_05CB:
            if ((num9 >= 258) && (num7 >= 10))
            {
                goto Label_0092;
            }
            num12 = (03V.LL - num7);
            num12 = (((num5 >> 3) < num12) ? (num5 >> 3) : num12);
            num7 += num12;
            num6 -= num12;
            num5 -= (num12 << 3);
            03U.H1 = num4;
            03U.H0 = num5;
            03V.LL = num7;
            T t4 = 03V;
            03V.LM = (t4.LM + ((long) (num6 - 03V.LK)));
            03V.LK = num6;
            03U.H5 = num8;
            return 0;
        }


        // Fields
        private const int H7 = 0;
        private const int H8 = 1;
        private const int H9 = 2;
        private const int HA = -1;
        private const int HB = -2;
        private const int HC = -3;
        private const int HD = -4;
        private const int HE = -5;
        private const int HF = -6;
        private const int HG = 0;
        private const int HH = 1;
        private const int HI = 2;
        private const int HJ = 3;
        private const int HK = 4;
        private const int HL = 5;
        private const int HM = 6;
        private const int HN = 7;
        private const int HO = 8;
        private const int HP = 9;
        private static int[] HQ;
        private int HR;
        private int HS;
        private int[] HT;
        private int HU;
        private int HV;
        private int HW;
        private int HX;
        private int HY;
        private byte HZ;
        private byte I0;
        private int[] I1;
        private int I2;
        private int[] I3;
        private int I4;
    }
}


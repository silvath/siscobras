namespace C1.C1Zip.ZLib
{
    using System;

    internal class P
    {
        // Methods
        static P()
        {
            byte[] numArray1 = new byte[4];
            numArray1[2] = 255;
            numArray1[3] = 255;
            P.J8 = numArray1;
        }

        public P()
        {
            this.J2 = new long[1];
        }

        private int 49(T 03W)
        {
            if ((03W == null) || (03W.LT == null))
            {
                return -2;
            }
            long num1 = ((long) 0);
            03W.LQ = num1;
            03W.LM = num1;
            03W.LR = null;
            03W.LT.J0 = ((03W.LT.J5 != 0) ? 7 : 0);
            03W.LT.J7.41(03W, null);
            return 0;
        }

        internal int 4A(T 03X)
        {
            if (this.J7 != null)
            {
                this.J7.43(03X);
            }
            this.J7 = null;
            return 0;
        }

        internal int 4B(T 03Y, int 03Z)
        {
            03Y.LR = null;
            this.J7 = null;
            this.J5 = 0;
            if (03Z < 0)
            {
                03Z = -03Z;
                this.J5 = 1;
            }
            if ((03Z < 8) || (03Z > 15))
            {
                this.4A(03Y);
                return -2;
            }
            this.J6 = 03Z;
            03Y.LT.J7 = new N(03Y, ((03Y.LT.J5 != 0) ? null : this), (1 << (03Z & 31)));
            this.49(03Y);
            return 0;
        }

        internal int 4C(T 040, int 041)
        {
            int num3;
            if (((040 == null) || (040.LT == null)) || (040.LJ == null))
            {
                return -2;
            }
            041 = ((041 == 4) ? -5 : 0);
            int num1 = -5;
        Label_0024:
            num3 = 040.LT.J0;
            switch (num3)
            {
                case 0:
                {
                    if (040.LL == 0)
                    {
                        return num1;
                    }
                    goto Label_007D;
                }
                case 1:
                {
                    goto Label_014A;
                }
                case 2:
                {
                    goto Label_01F2;
                }
                case 3:
                {
                    goto Label_0254;
                }
                case 4:
                {
                    goto Label_02BD;
                }
                case 5:
                {
                    goto Label_0325;
                }
                case 6:
                {
                    040.LT.J0 = 13;
                    040.LR = "need dictionary";
                    040.LT.J4 = 0;
                    return -2;
                }
                case 7:
                {
                    num1 = 040.LT.J7.42(040, num1);
                    if (num1 != -3)
                    {
                        goto Label_03FB;
                    }
                    040.LT.J0 = 13;
                    040.LT.J4 = 0;
                    goto Label_0024;
                }
                case 8:
                {
                    goto Label_044F;
                }
                case 9:
                {
                    goto Label_04B2;
                }
                case 10:
                {
                    goto Label_051C;
                }
                case 11:
                {
                    goto Label_0585;
                }
                case 12:
                {
                    goto Label_0631;
                }
                case 13:
                {
                    goto Label_0633;
                }
            }
            goto Label_0636;
        Label_007D:
            num1 = 041;
            T t1 = 040;
            040.LL = (t1.LL - 1);
            T t2 = 040;
            040.LM = (t2.LM + ((long) 1));
            T t3 = 040;
            num3 = t3.LK;
            040.LK = (num3 + 1);
            040.LT.J1 = ((int) 040.LJ[num3]);
            if ((040.LT.J1 & 15) != 8)
            {
                040.LT.J0 = 13;
                040.LR = "unknown compression method";
                040.LT.J4 = 5;
                goto Label_0024;
            }
            if (((040.LT.J1 >> 4) + 8) > 040.LT.J6)
            {
                040.LT.J0 = 13;
                040.LR = "invalid window size";
                040.LT.J4 = 5;
                goto Label_0024;
            }
            040.LT.J0 = 1;
        Label_014A:
            if (040.LL == 0)
            {
                return num1;
            }
            num1 = 041;
            T t4 = 040;
            040.LL = (t4.LL - 1);
            T t5 = 040;
            040.LM = (t5.LM + ((long) 1));
            T t6 = 040;
            num3 = t6.LK;
            040.LK = (num3 + 1);
            int num2 = ((int) (040.LJ[num3] & 255));
            if ((((040.LT.J1 << 8) + num2) % 31) != 0)
            {
                040.LT.J0 = 13;
                040.LR = "incorrect header check";
                040.LT.J4 = 5;
                goto Label_0024;
            }
            if ((num2 & 32) == 0)
            {
                040.LT.J0 = 7;
                goto Label_0024;
            }
            040.LT.J0 = 2;
        Label_01F2:
            if (040.LL == 0)
            {
                return num1;
            }
            num1 = 041;
            T t7 = 040;
            040.LL = (t7.LL - 1);
            T t8 = 040;
            040.LM = (t8.LM + ((long) 1));
            T t9 = 040;
            num3 = t9.LK;
            040.LK = (num3 + 1);
            040.LT.J3 = ((long) ((040.LJ[num3] & 255) << 24));
            040.LT.J0 = 3;
        Label_0254:
            if (040.LL == 0)
            {
                return num1;
            }
            num1 = 041;
            T t10 = 040;
            040.LL = (t10.LL - 1);
            T t11 = 040;
            040.LM = (t11.LM + ((long) 1));
            P p1 = 040.LT;
            T t12 = 040;
            num3 = t12.LK;
            040.LK = (num3 + 1);
            040.LT.J3 = (p1.J3 + ((long) ((040.LJ[num3] & 255) << 16)));
            040.LT.J0 = 4;
        Label_02BD:
            if (040.LL == 0)
            {
                return num1;
            }
            num1 = 041;
            T t13 = 040;
            040.LL = (t13.LL - 1);
            T t14 = 040;
            040.LM = (t14.LM + ((long) 1));
            P p2 = 040.LT;
            T t15 = 040;
            num3 = t15.LK;
            040.LK = (num3 + 1);
            040.LT.J3 = (p2.J3 + ((long) ((040.LJ[num3] & 255) << 8)));
            040.LT.J0 = 5;
        Label_0325:
            if (040.LL == 0)
            {
                return num1;
            }
            num1 = 041;
            T t16 = 040;
            040.LL = (t16.LL - 1);
            T t17 = 040;
            040.LM = (t17.LM + ((long) 1));
            P p3 = 040.LT;
            T t18 = 040;
            num3 = t18.LK;
            040.LK = (num3 + 1);
            040.LT.J3 = (p3.J3 + ((long) (040.LJ[num3] & 255)));
            040.LV = 040.LT.J3;
            040.LT.J0 = 6;
            return 2;
        Label_03FB:
            if (num1 == 0)
            {
                num1 = 041;
            }
            if (num1 != 1)
            {
                return num1;
            }
            num1 = 041;
            040.LT.J7.41(040, 040.LT.J2);
            if (040.LT.J5 != 0)
            {
                040.LT.J0 = 12;
                goto Label_0024;
            }
            040.LT.J0 = 8;
        Label_044F:
            if (040.LL == 0)
            {
                return num1;
            }
            num1 = 041;
            T t19 = 040;
            040.LL = (t19.LL - 1);
            T t20 = 040;
            040.LM = (t20.LM + ((long) 1));
            T t21 = 040;
            num3 = t21.LK;
            040.LK = (num3 + 1);
            040.LT.J3 = ((long) ((040.LJ[num3] & 255) << 24));
            040.LT.J0 = 9;
        Label_04B2:
            if (040.LL == 0)
            {
                return num1;
            }
            num1 = 041;
            T t22 = 040;
            040.LL = (t22.LL - 1);
            T t23 = 040;
            040.LM = (t23.LM + ((long) 1));
            P p4 = 040.LT;
            T t24 = 040;
            num3 = t24.LK;
            040.LK = (num3 + 1);
            040.LT.J3 = (p4.J3 + ((long) ((040.LJ[num3] & 255) << 16)));
            040.LT.J0 = 10;
        Label_051C:
            if (040.LL == 0)
            {
                return num1;
            }
            num1 = 041;
            T t25 = 040;
            040.LL = (t25.LL - 1);
            T t26 = 040;
            040.LM = (t26.LM + ((long) 1));
            P p5 = 040.LT;
            T t27 = 040;
            num3 = t27.LK;
            040.LK = (num3 + 1);
            040.LT.J3 = (p5.J3 + ((long) ((040.LJ[num3] & 255) << 8)));
            040.LT.J0 = 11;
        Label_0585:
            if (040.LL == 0)
            {
                return num1;
            }
            num1 = 041;
            T t28 = 040;
            040.LL = (t28.LL - 1);
            T t29 = 040;
            040.LM = (t29.LM + ((long) 1));
            P p6 = 040.LT;
            T t30 = 040;
            num3 = t30.LK;
            040.LK = (num3 + 1);
            040.LT.J3 = (p6.J3 + ((long) (040.LJ[num3] & 255)));
            if (((int) 040.LT.J2[0]) != ((int) 040.LT.J3))
            {
                040.LT.J0 = 13;
                040.LR = "incorrect data check";
                040.LT.J4 = 5;
                goto Label_0024;
            }
            040.LT.J0 = 12;
        Label_0631:
            return 1;
        Label_0633:
            return -3;
        Label_0636:
            return -2;
        }

        internal int 4D(T 042, byte[] 043, int 044)
        {
            int num1 = 0;
            int num2 = 044;
            if (((042 == null) || (042.LT == null)) || (042.LT.J0 != 6))
            {
                return -2;
            }
            if (042.LW.2T(((long) 1), 043, 0, 044) != 042.LV)
            {
                return -3;
            }
            042.LV = 042.LW.2T(((long) 0), null, 0, 0);
            if (num2 >= (1 << (042.LT.J6 & 31)))
            {
                num2 = ((1 << (042.LT.J6 & 31)) - 1);
                num1 = (044 - num2);
            }
            042.LT.J7.44(043, num1, num2);
            042.LT.J0 = 7;
            return 0;
        }

        internal int 4E(T 045)
        {
            if ((045 == null) || (045.LT == null))
            {
                return -2;
            }
            if (045.LT.J0 != 13)
            {
                045.LT.J0 = 13;
                045.LT.J4 = 0;
            }
            int num1 = 045.LL;
            if (num1 == 0)
            {
                return -5;
            }
            int num2 = 045.LK;
            int num3 = 045.LT.J4;
            while (((num1 != 0) && (num3 < 4)))
            {
                if (045.LJ[num2] == P.J8[num3])
                {
                    num3 += 1;
                }
                else if (045.LJ[num2] != 0)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = (4 - num3);
                }
                num2 += 1;
                num1 -= 1;
            }
            T t1 = 045;
            045.LM = (t1.LM + ((long) (num2 - 045.LK)));
            045.LK = num2;
            045.LL = num1;
            045.LT.J4 = num3;
            if (num3 != 4)
            {
                return -3;
            }
            long num4 = 045.LM;
            long num5 = 045.LQ;
            this.49(045);
            045.LM = num4;
            045.LQ = num5;
            045.LT.J0 = 7;
            return 0;
        }


        // Fields
        private const int I5 = 15;
        private const int I6 = 32;
        private const int I7 = 0;
        private const int I8 = 1;
        private const int I9 = 2;
        private const int IA = 3;
        private const int IB = 4;
        private const int IC = 8;
        private const int ID = 0;
        private const int IE = 1;
        private const int IF = 2;
        private const int IG = -1;
        private const int IH = -2;
        private const int II = -3;
        private const int IJ = -4;
        private const int IK = -5;
        private const int IL = -6;
        private const int IM = 0;
        private const int IN = 1;
        private const int IO = 2;
        private const int IP = 3;
        private const int IQ = 4;
        private const int IR = 5;
        private const int IS = 6;
        private const int IT = 7;
        private const int IU = 8;
        private const int IV = 9;
        private const int IW = 10;
        private const int IX = 11;
        private const int IY = 12;
        private const int IZ = 13;
        private int J0;
        private int J1;
        private long[] J2;
        private long J3;
        private int J4;
        private int J5;
        private int J6;
        private N J7;
        private static byte[] J8;
    }
}


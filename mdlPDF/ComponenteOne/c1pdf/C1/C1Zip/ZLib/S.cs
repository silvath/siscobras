namespace C1.C1Zip.ZLib
{
    using System;

    internal class S
    {
        // Methods
        static S()
        {
            S.KL = new int[29] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 0 };
            S.KM = new int[30] { 0, 0, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13 };
            S.KN = new int[19] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 7 };
            S.KO = new byte[19] { 16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 14, 1, 15 };
            S.KP = new byte[512] { 0, 1, 2, 3, 4, 4, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 0, 0, 16, 17, 18, 18, 19, 19, 20, 20, 20, 20, 21, 21, 21, 21, 22, 22, 22, 22, 22, 22, 22, 22, 23, 23, 23, 23, 23, 23, 23, 23, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29 };
            S.KQ = new byte[256] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 12, 12, 13, 13, 13, 13, 14, 14, 14, 14, 15, 15, 15, 15, 16, 16, 16, 16, 16, 16, 16, 16, 17, 17, 17, 17, 17, 17, 17, 17, 18, 18, 18, 18, 18, 18, 18, 18, 19, 19, 19, 19, 19, 19, 19, 19, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 28 };
            S.KR = new int[29] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 10, 12, 14, 16, 20, 24, 28, 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 0 };
            S.KS = new int[30] { 0, 1, 2, 3, 4, 6, 8, 12, 16, 24, 32, 48, 64, 96, 128, 192, 256, 384, 512, 768, 1024, 1536, 2048, 3072, 4096, 6144, 8192, 12288, 16384, 24576 };
        }

        public S()
        {
        }

        internal static int 4J(int 050)
        {
            if (050 >= 256)
            {
                return ((int) S.KP[(256 + (050 >> 7))]);
            }
            return ((int) S.KP[050]);
        }

        private void 4K(L 051)
        {
            int num4;
            int num5;
            int num7;
            short num8;
            short[] numArray4;
            IntPtr ptr1;
            short[] numArray1 = this.KT;
            short[] numArray2 = this.KV.K4;
            int[] numArray3 = this.KV.K5;
            int num1 = this.KV.K6;
            int num2 = this.KV.K8;
            int num9 = 0;
            int num6 = 0;
            while ((num6 <= 15))
            {
                051.FJ[num6] = 0;
                num6 += 1;
            }
            numArray1[((051.FK[051.FM] * 2) + 1)] = 0;
            int num3 = (051.FM + 1);
            while ((num3 < 573))
            {
                num4 = 051.FK[num3];
                num6 = ((int) (numArray1[((numArray1[((num4 * 2) + 1)] * 2) + 1)] + 1));
                if (num6 > num2)
                {
                    num6 = num2;
                    num9 += 1;
                }
                numArray1[((num4 * 2) + 1)] = ((short) num6);
                if (num4 <= this.KU)
                {
                    numArray4 = 051.FJ;
                    ptr1 = ((IntPtr) num6);
                    numArray4[ptr1] = (numArray4[ptr1] + 1);
                    num7 = 0;
                    if (num4 >= num1)
                    {
                        num7 = numArray3[(num4 - num1)];
                    }
                    num8 = numArray1[(num4 * 2)];
                    L l1 = 051;
                    051.FS = (l1.FS + (num8 * (num6 + num7)));
                    if (numArray2 != null)
                    {
                        L l2 = 051;
                        051.FT = (l2.FT + (num8 * (numArray2[((num4 * 2) + 1)] + num7)));
                    }
                }
                num3 += 1;
            }
            if (num9 == 0)
            {
                return;
            }
            do
            {
                num6 = (num2 - 1);
                while ((051.FJ[num6] == 0))
                {
                    num6 -= 1;
                }
                numArray4 = 051.FJ;
                ptr1 = ((IntPtr) num6);
                numArray4[ptr1] = (numArray4[ptr1] - 1);
                numArray4 = 051.FJ;
                ptr1 = ((IntPtr) (num6 + 1));
                numArray4[ptr1] = (numArray4[ptr1] + 2);
                numArray4 = 051.FJ;
                ptr1 = ((IntPtr) num2);
                numArray4[ptr1] = (numArray4[ptr1] - 1);
                num9 -= 2;
            }
            while ((num9 > 0));
            for (num6 = num2; (num6 != 0); num6 -= 1)
            {
                for (num4 = ((int) 051.FJ[num6]); (num4 != 0); num4 -= 1)
                {
                    num3 -= 1;
                    num5 = 051.FK[num3];
                    if (num5 > this.KU)
                    {
                        continue;
                    }
                    if (numArray1[((num5 * 2) + 1)] != num6)
                    {
                        051.FS = (051.FS + ((int) ((((long) num6) - ((long) numArray1[((num5 * 2) + 1)])) * ((long) numArray1[(num5 * 2)]))));
                        numArray1[((num5 * 2) + 1)] = ((short) num6);
                    }
                }
            }
        }

        internal void 4L(L 052)
        {
            int num3;
            int num5;
            int num6;
            short num7;
            short[] numArray1 = this.KT;
            short[] numArray2 = this.KV.K4;
            int num1 = this.KV.K7;
            int num4 = -1;
            052.FL = 0;
            052.FM = 573;
            int num2 = 0;
            while ((num2 < num1))
            {
                if (numArray1[(num2 * 2)] != 0)
                {
                    L l1 = 052;
                    num6 = (l1.FL + 1);
                    052.FL = num6;
                    num4 = num2;
                    052.FK[num6] = num4;
                    052.FN[num2] = 0;
                }
                else
                {
                    numArray1[((num2 * 2) + 1)] = 0;
                }
                num2 += 1;
            }
            while ((052.FL < 2))
            {
                L l2 = 052;
                num6 = (l2.FL + 1);
                052.FL = num6;
                num6 = ((num4 < 2) ? (num4 += 1) : 0);
                052.FK[num6] = ((num4 < 2) ? (num4 += 1) : 0);
                num5 = num6;
                numArray1[(num5 * 2)] = 1;
                052.FN[num5] = 0;
                L l3 = 052;
                052.FS = (l3.FS - 1);
                if (numArray2 == null)
                {
                    continue;
                }
                L l4 = 052;
                052.FT = (l4.FT - numArray2[((num5 * 2) + 1)]);
            }
            this.KU = num4;
            num2 = (052.FL / 2);
            while ((num2 >= 1))
            {
                052.33(numArray1, num2);
                num2 -= 1;
            }
            num5 = num1;
            do
            {
                num2 = 052.FK[1];
                L l5 = 052;
                num6 = l5.FL;
                052.FL = (num6 - 1);
                052.FK[1] = 052.FK[num6];
                052.33(numArray1, 1);
                num3 = 052.FK[1];
                L l6 = 052;
                num6 = (l6.FM - 1);
                052.FM = num6;
                052.FK[num6] = num2;
                L l7 = 052;
                num6 = (l7.FM - 1);
                052.FM = num6;
                052.FK[num6] = num3;
                numArray1[(num5 * 2)] = (numArray1[(num2 * 2)] + numArray1[(num3 * 2)]);
                052.FN[num5] = (Math.Max(052.FN[num2], 052.FN[num3]) + 1);
                num7 = ((short) num5);
                numArray1[((num3 * 2) + 1)] = num7;
                numArray1[((num2 * 2) + 1)] = num7;
                int num9 = num5;
                num5 = (num9 + 1);
                052.FK[1] = num5;
                052.33(numArray1, 1);
            }
            while ((052.FL >= 2));
            L l8 = 052;
            num6 = (l8.FM - 1);
            052.FM = num6;
            052.FK[num6] = 052.FK[1];
            this.4K(052);
            S.4M(numArray1, num4, 052.FJ);
        }

        private static void 4M(short[] 053, int 054, short[] 055)
        {
            int num2;
            int num3;
            int num4;
            short[] numArray2;
            IntPtr ptr1;
            short num5;
            short[] numArray1 = new short[16];
            short num1 = 0;
            for (num2 = 1; (num2 <= 15); num2 += 1)
            {
                num1 = ((num1 + 055[(num2 - 1)]) << 1);
                numArray1[num2] = num1;
            }
            for (num3 = 0; (num3 <= 054); num3 += 1)
            {
                num4 = ((int) 053[((num3 * 2) + 1)]);
                if (num4 != 0)
                {
                    numArray2 = numArray1;
                    ptr1 = ((IntPtr) num4);
                    num5 = numArray2[ptr1];
                    numArray2[ptr1] = (num5 + 1);
                    053[(num3 * 2)] = ((short) S.4N(num5, num4));
                }
            }
        }

        private static int 4N(int 056, int 057)
        {
            int num1 = 0;
            do
            {
                num1 |= (056 & 1);
                056 = (056 >> 1);
                num1 = (num1 << 1);
                057 = (057 - 1);
            }
            while ((057 > 0));
            return (num1 >> 1);
        }


        // Fields
        private const int K9 = 15;
        private const int KA = 19;
        private const int KB = 30;
        private const int KC = 256;
        private const int KD = 29;
        private const int KE = 286;
        private const int KF = 573;
        private const int KG = 7;
        private const int KH = 256;
        private const int KI = 16;
        private const int KJ = 17;
        private const int KK = 18;
        internal static int[] KL;
        internal static int[] KM;
        internal static int[] KN;
        internal static byte[] KO;
        private static byte[] KP;
        internal static byte[] KQ;
        internal static int[] KR;
        internal static int[] KS;
        internal short[] KT;
        internal int KU;
        internal R KV;
    }
}


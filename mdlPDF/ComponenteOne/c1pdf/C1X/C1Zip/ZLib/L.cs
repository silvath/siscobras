namespace C1.C1Zip.ZLib
{
    using System;

    internal class L
    {
        // Methods
        static L()
        {
            M[] mArray1 = new M[10];
            mArray1[0] = new M(0, 0, 0, 0, 0);
            mArray1[1] = new M(4, 4, 8, 4, 1);
            mArray1[2] = new M(4, 5, 16, 8, 1);
            mArray1[3] = new M(4, 6, 32, 32, 1);
            mArray1[4] = new M(4, 4, 16, 16, 2);
            mArray1[5] = new M(8, 16, 32, 32, 2);
            mArray1[6] = new M(8, 16, 128, 128, 2);
            mArray1[7] = new M(8, 32, 128, 256, 2);
            mArray1[8] = new M(32, 128, 258, 1024, 2);
            mArray1[9] = new M(32, 258, 258, 4096, 2);
            L.EB = mArray1;
            string[] textArray1 = new string[10];
            textArray1[0] = "need dictionary";
            textArray1[1] = "stream end";
            textArray1[2] = string.Empty;
            textArray1[3] = "file error";
            textArray1[4] = "stream error";
            textArray1[5] = "data error";
            textArray1[6] = "insufficient memory";
            textArray1[7] = "buffer error";
            textArray1[8] = "incompatible version";
            textArray1[9] = string.Empty;
            L.EC = textArray1;
        }

        internal L()
        {
            this.FG = new S();
            this.FH = new S();
            this.FI = new S();
            this.FJ = new short[16];
            this.FK = new int[573];
            this.FN = new byte[573];
            this.FD = new short[1146];
            this.FE = new short[122];
            this.FF = new short[78];
        }

        private void 30()
        {
            int num1;
            this.ER = (2 * this.EN);
            this.ET[(this.EV - 1)] = 0;
            for (num1 = 0; (num1 < (this.EV - 1)); num1 += 1)
            {
                this.ET[num1] = 0;
            }
            this.F8 = L.EB[this.F9].FZ;
            this.FB = L.EB[this.F9].FY;
            this.FC = L.EB[this.F9].G0;
            this.F7 = L.EB[this.F9].G1;
            this.F3 = 0;
            this.EZ = 0;
            this.F5 = 0;
            int num2 = 2;
            this.F6 = num2;
            this.F0 = num2;
            this.F2 = 0;
            this.EU = 0;
        }

        private void 31()
        {
            this.FG.KT = this.FD;
            this.FG.KV = R.K1;
            this.FH.KT = this.FE;
            this.FH.KV = R.K2;
            this.FI.KT = this.FF;
            this.FI.KV = R.K3;
            this.FW = 0;
            this.FX = 0;
            this.FV = 8;
            this.32();
        }

        private void 32()
        {
            int num1;
            int num2;
            int num3;
            for (num1 = 0; (num1 < 286); num1 += 1)
            {
                this.FD[(num1 * 2)] = 0;
            }
            for (num2 = 0; (num2 < 30); num2 += 1)
            {
                this.FE[(num2 * 2)] = 0;
            }
            for (num3 = 0; (num3 < 19); num3 += 1)
            {
                this.FF[(num3 * 2)] = 0;
            }
            this.FD[512] = 1;
            int num4 = 0;
            this.FT = num4;
            this.FS = num4;
            num4 = 0;
            this.FU = num4;
            this.FQ = num4;
        }

        internal void 33(short[] 01N, int 01O)
        {
            int num2;
            int num1 = this.FK[01O];
            for (num2 = (01O << 1); (num2 <= this.FL); num2 = (num2 << 1))
            {
                if ((num2 < this.FL) && L.34(01N, this.FK[(num2 + 1)], this.FK[num2], this.FN))
                {
                    num2 += 1;
                }
                if (L.34(01N, num1, this.FK[num2], this.FN))
                {
                    break;
                }
                this.FK[01O] = this.FK[num2];
                01O = num2;
            }
            this.FK[01O] = num1;
        }

        private static bool 34(short[] 01P, int 01Q, int 01R, byte[] 01S)
        {
            if (01P[(01Q * 2)] >= 01P[(01R * 2)])
            {
                if (01P[(01Q * 2)] == 01P[(01R * 2)])
                {
                    return (01S[01Q] <= 01S[01R]);
                }
                return false;
            }
            return true;
        }

        private void 35(short[] 01T, int 01U)
        {
            int num1;
            int num3;
            short[] numArray1;
            IntPtr ptr1;
            int num2 = -1;
            int num4 = ((int) 01T[1]);
            int num5 = 0;
            int num6 = 7;
            int num7 = 4;
            if (num4 == 0)
            {
                num6 = 138;
                num7 = 3;
            }
            01T[(((01U + 1) * 2) + 1)] = -1;
            for (num1 = 0; (num1 <= 01U); num1 += 1)
            {
                num3 = num4;
                num4 = ((int) 01T[(((num1 + 1) * 2) + 1)]);
                num5 += 1;
                if ((num5 >= num6) || (num3 != num4))
                {
                    if (num5 < num7)
                    {
                        numArray1 = this.FF;
                        ptr1 = ((IntPtr) (num3 * 2));
                        numArray1[ptr1] = (numArray1[ptr1] + ((short) num5));
                    }
                    else if (num3 != 0)
                    {
                        if (num3 != num2)
                        {
                            numArray1 = this.FF;
                            ptr1 = ((IntPtr) (num3 * 2));
                            numArray1[ptr1] = (numArray1[ptr1] + 1);
                        }
                        numArray1 = this.FF;
                        numArray1[32] = (numArray1[32] + 1);
                    }
                    else if (num5 <= 10)
                    {
                        numArray1 = this.FF;
                        numArray1[34] = (numArray1[34] + 1);
                    }
                    else
                    {
                        numArray1 = this.FF;
                        numArray1[36] = (numArray1[36] + 1);
                    }
                    num5 = 0;
                    num2 = num3;
                    if (num4 == 0)
                    {
                        num6 = 138;
                        num7 = 3;
                    }
                    else if (num3 == num4)
                    {
                        num6 = 6;
                        num7 = 3;
                    }
                    else
                    {
                        num6 = 7;
                        num7 = 4;
                    }
                }
            }
        }

        private int 36()
        {
            this.35(this.FD, this.FG.KU);
            this.35(this.FE, this.FH.KU);
            this.FI.4L(this);
            int num1 = 18;
            while ((num1 >= 3))
            {
                if (this.FF[((S.KO[num1] * 2) + 1)] != 0)
                {
                    break;
                }
                num1 -= 1;
            }
            this.FS += ((((3 * (num1 + 1)) + 5) + 5) + 4);
            return num1;
        }

        private void 37(int 01V, int 01W, int 01X)
        {
            int num1;
            this.3E((01V - 257), 5);
            this.3E((01W - 1), 5);
            this.3E((01X - 4), 4);
            for (num1 = 0; (num1 < 01X); num1 += 1)
            {
                this.3E(this.FF[((S.KO[num1] * 2) + 1)], 3);
            }
            this.38(this.FD, (01V - 1));
            this.38(this.FE, (01W - 1));
        }

        private void 38(short[] 01Y, int 01Z)
        {
            int num1;
            int num3;
            int num2 = -1;
            int num4 = ((int) 01Y[1]);
            int num5 = 0;
            int num6 = 7;
            int num7 = 4;
            if (num4 == 0)
            {
                num6 = 138;
                num7 = 3;
            }
            for (num1 = 0; (num1 <= 01Z); num1 += 1)
            {
                num3 = num4;
                num4 = ((int) 01Y[(((num1 + 1) * 2) + 1)]);
                num5 += 1;
                if ((num5 >= num6) || (num3 != num4))
                {
                    if (num5 < num7)
                    {
                        do
                        {
                            this.3D(num3, this.FF);
                            num5 -= 1;
                        }
                        while ((num5 != 0));
                    }
                    else if (num3 != 0)
                    {
                        if (num3 != num2)
                        {
                            this.3D(num3, this.FF);
                            num5 -= 1;
                        }
                        this.3D(16, this.FF);
                        this.3E((num5 - 3), 2);
                    }
                    else if (num5 <= 10)
                    {
                        this.3D(17, this.FF);
                        this.3E((num5 - 3), 3);
                    }
                    else
                    {
                        this.3D(18, this.FF);
                        this.3E((num5 - 11), 7);
                    }
                    num5 = 0;
                    num2 = num3;
                    if (num4 == 0)
                    {
                        num6 = 138;
                        num7 = 3;
                    }
                    else if (num3 == num4)
                    {
                        num6 = 6;
                        num7 = 3;
                    }
                    else
                    {
                        num6 = 7;
                        num7 = 4;
                    }
                }
            }
        }

        private void 39(byte[] 020, int 021, int 022)
        {
            Array.Copy(020, 021, this.EJ, this.EL, 022);
            this.EL += 022;
        }

        private void 3A(byte 023)
        {
            int num1 = this.EL;
            this.EL = (num1 + 1);
            this.EJ[num1] = 023;
        }

        private void 3B(int 024)
        {
            this.3A(((byte) 024));
            this.3A(((byte) (024 >> 8)));
        }

        private void 3C(int 025)
        {
            this.3A(((byte) (025 >> 8)));
            this.3A(((byte) 025));
        }

        private void 3D(int 026, short[] 027)
        {
            this.3E((027[(026 * 2)] & 65535), (027[((026 * 2) + 1)] & 65535));
        }

        private void 3E(int 028, int 029)
        {
            int num2;
            int num1 = 029;
            if (this.FX > (16 - num1))
            {
                num2 = 028;
                this.FW = ((short) (((int) ((ushort) this.FW)) | ((int) ((ushort) ((num2 << (this.FX & 31)) & 65535)))));
                this.3B(this.FW);
                this.FW = ((short) (num2 >> ((16 - this.FX) & 31)));
                this.FX += (num1 - 16);
                return;
            }
            this.FW = ((short) (((int) ((ushort) this.FW)) | ((int) ((ushort) ((028 << (this.FX & 31)) & 65535)))));
            this.FX += num1;
        }

        private void 3F()
        {
            this.3E(2, 3);
            this.3D(256, R.JZ);
            this.3J();
            if ((((1 + this.FV) + 10) - this.FX) < 9)
            {
                this.3E(2, 3);
                this.3D(256, R.JZ);
                this.3J();
            }
            this.FV = 7;
        }

        private bool 3G(int 02A, int 02B)
        {
            int num1;
            int num2;
            int num3;
            short[] numArray1;
            IntPtr ptr1;
            this.EJ[(this.FR + (this.FQ * 2))] = ((byte) (02A >> 8));
            this.EJ[((this.FR + (this.FQ * 2)) + 1)] = ((byte) 02A);
            this.EJ[(this.FO + this.FQ)] = ((byte) 02B);
            this.FQ += 1;
            if (02A == 0)
            {
                numArray1 = this.FD;
                ptr1 = ((IntPtr) (02B * 2));
                numArray1[ptr1] = (numArray1[ptr1] + 1);
            }
            else
            {
                this.FU += 1;
                02A = (02A - 1);
                numArray1 = this.FD;
                ptr1 = ((IntPtr) (((S.KQ[02B] + 256) + 1) * 2));
                numArray1[ptr1] = (numArray1[ptr1] + 1);
                numArray1 = this.FE;
                ptr1 = ((IntPtr) (S.4J(02A) * 2));
                numArray1[ptr1] = (numArray1[ptr1] + 1);
            }
            if (((this.FQ & 8191) == 0) && (this.F9 > 2))
            {
                num1 = (this.FQ * 8);
                num2 = (this.F3 - this.EZ);
                for (num3 = 0; (num3 < 30); num3 += 1)
                {
                    num1 += (this.FE[(num3 * 2)] * ((int) (((long) 5) + ((long) S.KM[num3]))));
                }
                num1 = (num1 >> 3);
                if ((this.FU < (this.FQ / 2)) && (num1 < (num2 / 2)))
                {
                    return true;
                }
            }
            return (this.FQ == (this.FP - 1));
        }

        private void 3H(short[] 02C, short[] 02D)
        {
            int num1;
            int num2;
            int num4;
            int num5;
            int num3 = 0;
            if (this.FQ != 0)
            {
                do
                {
                    num1 = ((int) (((this.EJ[(this.FR + (num3 * 2))] << 8) & 65280) | (this.EJ[((this.FR + (num3 * 2)) + 1)] & 255)));
                    num2 = ((int) (this.EJ[(this.FO + num3)] & 255));
                    num3 += 1;
                    if (num1 == 0)
                    {
                        this.3D(num2, 02C);
                    }
                    else
                    {
                        num4 = ((int) S.KQ[num2]);
                        this.3D(((num4 + 256) + 1), 02C);
                        num5 = S.KL[num4];
                        if (num5 != 0)
                        {
                            num2 -= S.KR[num4];
                            this.3E(num2, num5);
                        }
                        num1 -= 1;
                        num4 = S.4J(num1);
                        this.3D(num4, 02D);
                        num5 = S.KM[num4];
                        if (num5 != 0)
                        {
                            num1 -= S.KS[num4];
                            this.3E(num1, num5);
                        }
                    }
                }
                while ((num3 < this.FQ));
            }
            this.3D(256, 02C);
            this.FV = ((int) 02C[513]);
        }

        private void 3I()
        {
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            while ((num1 < 7))
            {
                num3 += this.FD[(num1 * 2)];
                num1 += 1;
            }
            while ((num1 < 128))
            {
                num2 += this.FD[(num1 * 2)];
                num1 += 1;
            }
            while ((num1 < 256))
            {
                num3 += this.FD[(num1 * 2)];
                num1 += 1;
            }
            this.EG = ((byte) ((num3 > (num2 >> 2)) ? 0 : 1));
        }

        private void 3J()
        {
            if (this.FX == 16)
            {
                this.3B(this.FW);
                this.FW = 0;
                this.FX = 0;
                return;
            }
            if (this.FX >= 8)
            {
                this.3A(((byte) this.FW));
                this.FW = (this.FW >> 8);
                this.FX -= 8;
            }
        }

        private void 3K()
        {
            if (this.FX > 8)
            {
                this.3B(this.FW);
            }
            else if (this.FX > 0)
            {
                this.3A(((byte) this.FW));
            }
            this.FW = 0;
            this.FX = 0;
        }

        private void 3L(int 02E, int 02F, bool 02G)
        {
            this.3K();
            this.FV = 8;
            if (02G)
            {
                this.3B(((short) 02F));
                this.3B(((short) ~02F));
            }
            this.39(this.EQ, 02E, 02F);
        }

        private void 3M(bool 02H)
        {
            this.3P(((this.EZ >= 0) ? this.EZ : -1), (this.F3 - this.EZ), 02H);
            this.EZ = this.F3;
            this.ED.50();
        }

        private int 3N(int 02I)
        {
            int num1 = 65535;
            if (num1 > (this.EF - 5))
            {
                num1 = (this.EF - 5);
            }
        Label_001A:
            if (this.F5 <= 1)
            {
                this.3Q();
                if ((this.F5 == 0) && (02I == 0))
                {
                    return 0;
                }
                if (this.F5 == 0)
                {
                    goto Label_00D7;
                }
            }
            this.F3 += this.F5;
            this.F5 = 0;
            int num2 = (this.EZ + num1);
            if ((this.F3 == 0) || (this.F3 >= num2))
            {
                this.F5 = (this.F3 - num2);
                this.F3 = num2;
                this.3M(false);
                if (this.ED.LP == 0)
                {
                    return 0;
                }
            }
            if ((this.F3 - this.EZ) < (this.EN - 262))
            {
                goto Label_001A;
            }
            this.3M(false);
            if (this.ED.LP != 0)
            {
                goto Label_001A;
            }
            return 0;
        Label_00D7:
            this.3M((02I == 4));
            if (this.ED.LP == 0)
            {
                if (02I != 4)
                {
                    return 0;
                }
                return 2;
            }
            if (02I != 4)
            {
                return 1;
            }
            return 3;
        }

        private void 3O(int 02J, int 02K, bool 02L)
        {
            this.3E((02L ? 1 : 0), 3);
            this.3L(02J, 02K, true);
        }

        private void 3P(int 02M, int 02N, bool 02O)
        {
            int num1;
            int num2;
            int num3 = 0;
            if (this.F9 > 0)
            {
                if (this.EG == 2)
                {
                    this.3I();
                }
                this.FG.4L(this);
                this.FH.4L(this);
                num3 = this.36();
                num1 = (((this.FS + 3) + 7) >> 3);
                num2 = (((this.FT + 3) + 7) >> 3);
                if (num2 <= num1)
                {
                    num1 = num2;
                }
            }
            else
            {
                num2 = (02N + 5);
                num1 = num2;
            }
            if (((02N + 4) <= num1) && (02M != -1))
            {
                this.3O(02M, 02N, 02O);
            }
            else if (num2 == num1)
            {
                this.3E((2 + (02O ? 1 : 0)), 3);
                this.3H(R.JZ, R.K0);
            }
            else
            {
                this.3E((4 + (02O ? 1 : 0)), 3);
                this.37((this.FG.KU + 1), (this.FH.KU + 1), (num3 + 1));
                this.3H(this.FD, this.FE);
            }
            this.32();
            if (02O)
            {
                this.3K();
            }
        }

        private void 3Q()
        {
            int num1;
            int num2;
            int num3;
            int num4;
            do
            {
                num4 = ((this.ER - this.F5) - this.F3);
                if (((num4 == 0) && (this.F3 == 0)) && (this.F5 == 0))
                {
                    num4 = this.EN;
                }
                else if (num4 == -1)
                {
                    num4 -= 1;
                }
                else if (this.F3 >= ((this.EN + this.EN) - 262))
                {
                    Array.Copy(this.EQ, this.EN, this.EQ, 0, this.EN);
                    this.F4 -= this.EN;
                    this.F3 -= this.EN;
                    this.EZ -= this.EN;
                    num1 = this.EV;
                    num3 = num1;
                    do
                    {
                        num3 -= 1;
                        num2 = ((int) (this.ET[num3] & 65535));
                        this.ET[num3] = ((num2 >= this.EN) ? ((short) (num2 - this.EN)) : 0);
                        num1 -= 1;
                    }
                    while ((num1 != 0));
                    num1 = this.EN;
                    num3 = num1;
                    do
                    {
                        num3 -= 1;
                        num2 = ((int) (this.ES[num3] & 65535));
                        this.ES[num3] = ((num2 >= this.EN) ? ((short) (num2 - this.EN)) : 0);
                        num1 -= 1;
                    }
                    while ((num1 != 0));
                    num4 += this.EN;
                }
                if (this.ED.LL == 0)
                {
                    return;
                }
                num1 = this.ED.51(this.EQ, (this.F3 + this.F5), num4);
                this.F5 += num1;
                if (this.F5 >= 3)
                {
                    this.EU = ((int) (this.EQ[this.F3] & 255));
                    this.EU = (((this.EU << (this.EY & 31)) ^ (this.EQ[(this.F3 + 1)] & 255)) & this.EX);
                }
            }
            while (((this.F5 < 262) && (this.ED.LL != 0)));
        }

        private int 3R(int 02P)
        {
            bool flag1;
            int num2;
            int num1 = 0;
        Label_0002:
            if (this.F5 < 262)
            {
                this.3Q();
                if ((this.F5 < 262) && (02P == 0))
                {
                    return 0;
                }
                if (this.F5 == 0)
                {
                    goto Label_02C0;
                }
            }
            if (this.F5 >= 3)
            {
                this.EU = (((this.EU << (this.EY & 31)) ^ (this.EQ[(this.F3 + 2)] & 255)) & this.EX);
                num1 = ((int) (this.ET[this.EU] & 65535));
                this.ES[(this.F3 & this.EP)] = this.ET[this.EU];
                this.ET[this.EU] = ((short) this.F3);
            }
            if (((((long) num1) != ((long) 0)) && ((this.F3 - num1) <= (this.EN - 262))) && (this.FA != 2))
            {
                this.F0 = this.3T(num1);
            }
            if (this.F0 >= 3)
            {
                flag1 = this.3G((this.F3 - this.F4), (this.F0 - 3));
                this.F5 -= this.F0;
                if ((this.F0 <= this.F8) && (this.F5 >= 3))
                {
                    this.F0 -= 1;
                    do
                    {
                        this.F3 += 1;
                        this.EU = (((this.EU << (this.EY & 31)) ^ (this.EQ[(this.F3 + 2)] & 255)) & this.EX);
                        num1 = ((int) (this.ET[this.EU] & 65535));
                        this.ES[(this.F3 & this.EP)] = this.ET[this.EU];
                        this.ET[this.EU] = ((short) this.F3);
                        num2 = (this.F0 - 1);
                        this.F0 = num2;
                    }
                    while ((num2 != 0));
                    this.F3 += 1;
                }
                else
                {
                    this.F3 += this.F0;
                    this.F0 = 0;
                    this.EU = ((int) (this.EQ[this.F3] & 255));
                    this.EU = (((this.EU << (this.EY & 31)) ^ (this.EQ[(this.F3 + 1)] & 255)) & this.EX);
                }
            }
            else
            {
                flag1 = this.3G(0, (this.EQ[this.F3] & 255));
                this.F5 -= 1;
                this.F3 += 1;
            }
            if (!flag1)
            {
                goto Label_0002;
            }
            this.3M(false);
            if (this.ED.LP != 0)
            {
                goto Label_0002;
            }
            return 0;
        Label_02C0:
            this.3M((02P == 4));
            if (this.ED.LP == 0)
            {
                if (02P == 4)
                {
                    return 2;
                }
                return 0;
            }
            if (02P != 4)
            {
                return 1;
            }
            return 3;
        }

        private int 3S(int 02Q)
        {
            bool flag1;
            int num2;
            int num3;
            int num1 = 0;
        Label_0002:
            if (this.F5 < 262)
            {
                this.3Q();
                if ((this.F5 < 262) && (02Q == 0))
                {
                    return 0;
                }
                if (this.F5 == 0)
                {
                    goto Label_031D;
                }
            }
            if (this.F5 >= 3)
            {
                this.EU = (((this.EU << (this.EY & 31)) ^ (this.EQ[(this.F3 + 2)] & 255)) & this.EX);
                num1 = ((int) (this.ET[this.EU] & 65535));
                this.ES[(this.F3 & this.EP)] = this.ET[this.EU];
                this.ET[this.EU] = ((short) this.F3);
            }
            this.F6 = this.F0;
            this.F1 = this.F4;
            this.F0 = 2;
            if (((num1 != 0) && (this.F6 < this.F8)) && ((this.F3 - num1) <= (this.EN - 262)))
            {
                if (this.FA != 2)
                {
                    this.F0 = this.3T(num1);
                }
                if ((this.F0 <= 5) && ((this.FA == 1) || ((this.F0 == 3) && ((this.F3 - this.F4) > 4096))))
                {
                    this.F0 = 2;
                }
            }
            if ((this.F6 >= 3) && (this.F0 <= this.F6))
            {
                num2 = ((this.F3 + this.F5) - 3);
                flag1 = this.3G(((this.F3 - 1) - this.F1), (this.F6 - 3));
                this.F5 -= (this.F6 - 1);
                this.F6 -= 2;
                do
                {
                    num3 = (this.F3 + 1);
                    this.F3 = num3;
                    if (num3 <= num2)
                    {
                        this.EU = (((this.EU << (this.EY & 31)) ^ (this.EQ[(this.F3 + 2)] & 255)) & this.EX);
                        num1 = ((int) (this.ET[this.EU] & 65535));
                        this.ES[(this.F3 & this.EP)] = this.ET[this.EU];
                        this.ET[this.EU] = ((short) this.F3);
                    }
                    num3 = (this.F6 - 1);
                    this.F6 = num3;
                }
                while ((num3 != 0));
                this.F2 = 0;
                this.F0 = 2;
                this.F3 += 1;
                if (!flag1)
                {
                    goto Label_0002;
                }
                this.3M(false);
                if (this.ED.LP == 0)
                {
                    return 0;
                }
                goto Label_0002;
            }
            if (this.F2 != 0)
            {
                flag1 = this.3G(0, (this.EQ[(this.F3 - 1)] & 255));
                if (flag1)
                {
                    this.3M(false);
                }
                this.F3 += 1;
                this.F5 -= 1;
                if (this.ED.LP == 0)
                {
                    return 0;
                }
                goto Label_0002;
            }
            this.F2 = 1;
            this.F3 += 1;
            this.F5 -= 1;
            goto Label_0002;
        Label_031D:
            if (this.F2 != 0)
            {
                flag1 = this.3G(0, (this.EQ[(this.F3 - 1)] & 255));
                this.F2 = 0;
            }
            this.3M((02Q == 4));
            if (this.ED.LP == 0)
            {
                if (02Q == 4)
                {
                    return 2;
                }
                return 0;
            }
            if (02Q != 4)
            {
                return 1;
            }
            return 3;
        }

        private int 3T(int 02R)
        {
            int num3;
            int num4;
            int num1 = this.F7;
            int num2 = this.F3;
            int num5 = this.F6;
            int num6 = ((this.F3 > (this.EN - 262)) ? (this.F3 - (this.EN - 262)) : 0);
            int num7 = this.FC;
            int num8 = this.EP;
            int num9 = (this.F3 + 258);
            byte num10 = this.EQ[((num2 + num5) - 1)];
            byte num11 = this.EQ[(num2 + num5)];
            if (this.F6 >= this.FB)
            {
                num1 = (num1 >> 2);
            }
            if (num7 > this.F5)
            {
                num7 = this.F5;
            }
        Label_00A0:
            num3 = 02R;
            if (((this.EQ[(num3 + num5)] == num11) && (this.EQ[((num3 + num5) - 1)] == num10)) && (this.EQ[num3] == this.EQ[num2]))
            {
                num3 += 1;
                if (this.EQ[num3] == this.EQ[(num2 + 1)])
                {
                    num2 += 2;
                    num3 += 1;
                    do
                    {
                        num2 += 1;
                        num3 += 1;
                        if (this.EQ[num2] != this.EQ[num3])
                        {
                            break;
                        }
                        num2 += 1;
                        num3 += 1;
                        if (this.EQ[num2] != this.EQ[num3])
                        {
                            break;
                        }
                        num2 += 1;
                        num3 += 1;
                        if (this.EQ[num2] != this.EQ[num3])
                        {
                            break;
                        }
                        num2 += 1;
                        num3 += 1;
                        if (this.EQ[num2] != this.EQ[num3])
                        {
                            break;
                        }
                        num2 += 1;
                        num3 += 1;
                        if (this.EQ[num2] != this.EQ[num3])
                        {
                            break;
                        }
                        num2 += 1;
                        num3 += 1;
                        if (this.EQ[num2] != this.EQ[num3])
                        {
                            break;
                        }
                        num2 += 1;
                        num3 += 1;
                        if (this.EQ[num2] != this.EQ[num3])
                        {
                            break;
                        }
                        num2 += 1;
                        num3 += 1;
                    }
                    while (((this.EQ[num2] == this.EQ[num3]) && (num2 < num9)));
                    num4 = (258 - (num9 - num2));
                    num2 = (num9 - 258);
                    if (num4 > num5)
                    {
                        this.F4 = 02R;
                        num5 = num4;
                        if (num4 >= num7)
                        {
                            goto Label_0247;
                        }
                        num10 = this.EQ[((num2 + num5) - 1)];
                        num11 = this.EQ[(num2 + num5)];
                    }
                }
            }
            02R = ((int) (this.ES[(02R & num8)] & 65535));
            if (02R > num6)
            {
                num1 -= 1;
                if (num1 != 0)
                {
                    goto Label_00A0;
                }
            }
        Label_0247:
            if (num5 <= this.F5)
            {
                return num5;
            }
            return this.F5;
        }

        internal int 3U(T 02S, int 02T, int 02U)
        {
            return this.3V(02S, 02T, 8, 02U, 8, 0);
        }

        private int 3V(T 02V, int 02W, int 02X, int 02Y, int 02Z, int 030)
        {
            int num1 = 0;
            02V.LR = null;
            if (02W < 0)
            {
                02W = 6;
            }
            if (02Y < 0)
            {
                num1 = 1;
                02Y = -02Y;
            }
            if ((((02Z < 1) || (02Z > 9)) || ((02X != 8) || (02Y < 8))) || (((02Y > 15) || (02W < 0)) || (((02W > 9) || (030 < 0)) || (030 > 2))))
            {
                return -2;
            }
            02V.LS = this;
            this.EM = num1;
            this.EO = 02Y;
            this.EN = (1 << (this.EO & 31));
            this.EP = (this.EN - 1);
            this.EW = (02Z + 7);
            this.EV = (1 << (this.EW & 31));
            this.EX = (this.EV - 1);
            this.EY = (((this.EW + 3) - 1) / 3);
            this.EQ = new byte[((uint) (this.EN * 2))];
            this.ES = new short[((uint) this.EN)];
            this.ET = new short[((uint) this.EV)];
            this.FP = (1 << ((02Z + 6) & 31));
            this.EJ = new byte[((uint) (this.FP * 4))];
            this.EF = (this.FP * 4);
            this.FR = (this.FP / 2);
            this.FO = (3 * this.FP);
            this.F9 = 02W;
            this.FA = 030;
            this.EH = ((byte) 02X);
            return this.3W(02V);
        }

        private int 3W(T 031)
        {
            long num1 = ((long) 0);
            031.LQ = num1;
            031.LM = num1;
            031.LR = null;
            031.LU = 2;
            this.EL = 0;
            this.EK = 0;
            if (this.EM < 0)
            {
                this.EM = 0;
            }
            this.EE = ((this.EM != 0) ? 113 : 42);
            031.LV = 031.LW.2T(((long) 0), null, 0, 0);
            this.EI = 0;
            this.31();
            this.30();
            return 0;
        }

        internal int 3X()
        {
            if (((this.EE != 42) && (this.EE != 113)) && (this.EE != 666))
            {
                return -2;
            }
            this.EJ = null;
            this.ET = null;
            this.ES = null;
            this.EQ = null;
            if (this.EE != 113)
            {
                return 0;
            }
            return -3;
        }

        internal int 3Y(T 032, int 033, int 034)
        {
            int num1 = 0;
            if (033 < 0)
            {
                033 = 6;
            }
            if (((033 < 0) || (033 > 9)) || ((034 < 0) || (034 > 2)))
            {
                return -2;
            }
            if ((L.EB[this.F9].G2 != L.EB[033].G2) && (032.LM != ((long) 0)))
            {
                num1 = 032.4W(1);
            }
            if (this.F9 != 033)
            {
                this.F9 = 033;
                this.F8 = L.EB[this.F9].FZ;
                this.FB = L.EB[this.F9].FY;
                this.FC = L.EB[this.F9].G0;
                this.F7 = L.EB[this.F9].G1;
            }
            this.FA = 034;
            return num1;
        }

        internal int 3Z(T 035, byte[] 036, int 037)
        {
            int num3;
            int num1 = 037;
            int num2 = 0;
            if ((036 == null) || (this.EE != 42))
            {
                return -2;
            }
            035.LV = 035.LW.2T(035.LV, 036, 0, 037);
            if (num1 < 3)
            {
                return 0;
            }
            if (num1 > (this.EN - 262))
            {
                num1 = (this.EN - 262);
                num2 = (037 - num1);
            }
            Array.Copy(036, num2, this.EQ, 0, num1);
            this.F3 = num1;
            this.EZ = num1;
            this.EU = ((int) (this.EQ[0] & 255));
            this.EU = (((this.EU << (this.EY & 31)) ^ (this.EQ[1] & 255)) & this.EX);
            for (num3 = 0; (num3 <= (num1 - 3)); num3 += 1)
            {
                this.EU = (((this.EU << (this.EY & 31)) ^ (this.EQ[(num3 + 2)] & 255)) & this.EX);
                this.ES[(num3 & this.EP)] = this.ET[this.EU];
                this.ET[this.EU] = ((short) num3);
            }
            return 0;
        }

        internal int 40(T 038, int 039)
        {
            int num2;
            int num3;
            int num5;
            if ((039 > 4) || (039 < 0))
            {
                return -2;
            }
            if (((038.LN == null) || ((038.LJ == null) && (038.LL != 0))) || ((this.EE == 666) && (039 != 4)))
            {
                038.LR = L.EC[4];
                return -2;
            }
            if (038.LP == 0)
            {
                038.LR = L.EC[7];
                return -5;
            }
            this.ED = 038;
            int num1 = this.EI;
            this.EI = 039;
            if (this.EE == 42)
            {
                num2 = ((8 + ((this.EO - 8) << 4)) << 8);
                num3 = (((this.F9 - 1) & 255) >> 1);
                if (num3 > 3)
                {
                    num3 = 3;
                }
                num2 |= (num3 << 6);
                if (this.F3 != 0)
                {
                    num2 |= 32;
                }
                num2 += (31 - (num2 % 31));
                this.EE = 113;
                this.3C(num2);
                if (this.F3 != 0)
                {
                    this.3C(((int) (038.LV >> 16)));
                    this.3C(((int) (038.LV & ((long) 65535))));
                }
                038.LV = 038.LW.2T(((long) 0), null, 0, 0);
            }
            if (this.EL != 0)
            {
                038.50();
                if (038.LP != 0)
                {
                    goto Label_0143;
                }
                this.EI = -1;
                return 0;
            }
            if (((038.LL == 0) && (039 <= num1)) && (039 != 4))
            {
                return 1;
            }
        Label_0143:
            if ((this.EE == 666) && (038.LL != 0))
            {
                038.LR = L.EC[7];
                return -5;
            }
            if (((038.LL == 0) && (this.F5 == 0)) && ((039 == 0) || (this.EE == 666)))
            {
                goto Label_0252;
            }
            int num4 = -1;
            int num6 = L.EB[this.F9].G2;
            switch (num6)
            {
                case 0:
                {
                    num4 = this.3N(039);
                    goto Label_01D4;
                }
                case 1:
                {
                    num4 = this.3R(039);
                    goto Label_01D4;
                }
                case 2:
                {
                    goto Label_01CC;
                }
            }
            goto Label_01D4;
        Label_01CC:
            num4 = this.3S(039);
        Label_01D4:
            if ((num4 == 2) || (num4 == 3))
            {
                this.EE = 666;
            }
            if ((num4 == 0) || (num4 == 2))
            {
                if (038.LP == 0)
                {
                    this.EI = -1;
                }
                return 0;
            }
            if (num4 == 1)
            {
                if (039 == 1)
                {
                    this.3F();
                }
                else
                {
                    this.3O(0, 0, false);
                    if (039 == 3)
                    {
                        for (num5 = 0; (num5 < this.EV); num5 += 1)
                        {
                            this.ET[num5] = 0;
                        }
                    }
                }
                038.50();
                if (038.LP == 0)
                {
                    this.EI = -1;
                    return 0;
                }
            }
        Label_0252:
            if (039 != 4)
            {
                return 0;
            }
            if (this.EM != 0)
            {
                return 1;
            }
            this.3C(((int) (038.LV >> 16)));
            this.3C(((int) (038.LV & ((long) 65535))));
            038.50();
            this.EM = -1;
            if (this.EL == 0)
            {
                return 1;
            }
            return 0;
        }


        // Fields
        private const int CY = 9;
        private const int CZ = 15;
        private const int D0 = 8;
        private const int D1 = 0;
        private const int D2 = 1;
        private const int D3 = 2;
        private const int D4 = 0;
        private const int D5 = 1;
        private const int D6 = 2;
        private const int D7 = 3;
        private const int D8 = 32;
        private const int D9 = 1;
        private const int DA = 2;
        private const int DB = 0;
        private const int DC = 0;
        private const int DD = 1;
        private const int DE = 3;
        private const int DF = 4;
        private const int DG = 0;
        private const int DH = 1;
        private const int DI = 2;
        private const int DJ = -2;
        private const int DK = -3;
        private const int DL = -5;
        private const int DM = 42;
        private const int DN = 113;
        private const int DO = 666;
        internal const int DP = 8;
        private const int DQ = 0;
        private const int DR = 1;
        private const int DS = 2;
        private const int DT = 0;
        private const int DU = 1;
        private const int DV = 2;
        private const int DW = 16;
        private const int DX = 16;
        private const int DY = 17;
        private const int DZ = 18;
        private const int E0 = 3;
        private const int E1 = 258;
        private const int E2 = 262;
        private const int E3 = 15;
        private const int E4 = 30;
        private const int E5 = 19;
        private const int E6 = 29;
        private const int E7 = 256;
        private const int E8 = 286;
        private const int E9 = 573;
        private const int EA = 256;
        private static M[] EB;
        private static string[] EC;
        private T ED;
        private int EE;
        private int EF;
        private byte EG;
        private byte EH;
        private int EI;
        internal byte[] EJ;
        internal int EK;
        internal int EL;
        internal int EM;
        private int EN;
        private int EO;
        private int EP;
        private byte[] EQ;
        private int ER;
        private short[] ES;
        private short[] ET;
        private int EU;
        private int EV;
        private int EW;
        private int EX;
        private int EY;
        private int EZ;
        private int F0;
        private int F1;
        private int F2;
        private int F3;
        private int F4;
        private int F5;
        private int F6;
        private int F7;
        private int F8;
        private int F9;
        private int FA;
        private int FB;
        private int FC;
        private short[] FD;
        private short[] FE;
        private short[] FF;
        private S FG;
        private S FH;
        private S FI;
        internal short[] FJ;
        internal int[] FK;
        internal int FL;
        internal int FM;
        internal byte[] FN;
        private int FO;
        private int FP;
        private int FQ;
        private int FR;
        internal int FS;
        internal int FT;
        private int FU;
        private int FV;
        private short FW;
        private int FX;

        // Nested Types
        private class M
        {
            // Methods
            internal M(int good_length, int max_lazy, int nice_length, int max_chain, int func)
            {
                this.FY = good_length;
                this.FZ = max_lazy;
                this.G0 = nice_length;
                this.G1 = max_chain;
                this.G2 = func;
            }


            // Fields
            internal int FY;
            internal int FZ;
            internal int G0;
            internal int G1;
            internal int G2;
        }
    }
}


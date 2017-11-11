namespace C1.C1Zip.ZLib
{
    using System;

    internal class T
    {
        // Methods
        public T()
        {
            this.LW = new J();
        }

        public T(bool crc32)
        {
            this.LX = crc32;
            if (crc32)
            {
                this.LW = new K();
                return;
            }
            this.LW = new J();
        }

        public int 4O()
        {
            this.LT = new P();
            return this.LT.4B(this, 15);
        }

        public int 4P(int 058)
        {
            this.LT = new P();
            return this.LT.4B(this, 058);
        }

        public int 4Q(int 059)
        {
            if (this.LT == null)
            {
                return -2;
            }
            return this.LT.4C(this, 059);
        }

        public int 4R()
        {
            if (this.LT == null)
            {
                return -2;
            }
            int num1 = this.LT.4A(this);
            this.LT = null;
            return num1;
        }

        public int 4S()
        {
            if (this.LT == null)
            {
                return -2;
            }
            return this.LT.4E(this);
        }

        public int 4T(byte[] 05A, int 05B)
        {
            if (this.LT == null)
            {
                return -2;
            }
            return this.LT.4D(this, 05A, 05B);
        }

        public int 4U(int 05C)
        {
            this.LS = new L();
            return this.LS.3U(this, 05C, 15);
        }

        public int 4V(int 05D, int 05E)
        {
            this.LS = new L();
            return this.LS.3U(this, 05D, 05E);
        }

        public int 4W(int 05F)
        {
            if (this.LS == null)
            {
                return -2;
            }
            return this.LS.40(this, 05F);
        }

        public int 4X()
        {
            if (this.LS == null)
            {
                return -2;
            }
            int num1 = this.LS.3X();
            this.LS = null;
            return num1;
        }

        public int 4Y(int 05G, int 05H)
        {
            if (this.LS == null)
            {
                return -2;
            }
            return this.LS.3Y(this, 05G, 05H);
        }

        public int 4Z(byte[] 05I, int 05J)
        {
            if (this.LS == null)
            {
                return -2;
            }
            return this.LS.3Z(this, 05I, 05J);
        }

        internal void 50()
        {
            int num1 = this.LS.EL;
            if (num1 > this.LP)
            {
                num1 = this.LP;
            }
            if (num1 == 0)
            {
                return;
            }
            Array.Copy(this.LS.EJ, this.LS.EK, this.LN, this.LO, num1);
            this.LO += num1;
            L l1 = this.LS;
            this.LS.EK = (l1.EK + num1);
            this.LQ += ((long) num1);
            this.LP -= num1;
            L l2 = this.LS;
            this.LS.EL = (l2.EL - num1);
            if (this.LS.EL == 0)
            {
                this.LS.EK = 0;
            }
        }

        internal int 51(byte[] 05K, int 05L, int 05M)
        {
            int num1 = this.LL;
            if (num1 > 05M)
            {
                num1 = 05M;
            }
            if (num1 == 0)
            {
                return 0;
            }
            this.LL -= num1;
            if ((this.LS.EM == 0) || this.LX)
            {
                this.LV = this.LW.2T(this.LV, this.LJ, this.LK, num1);
            }
            Array.Copy(this.LJ, this.LK, 05K, 05L, num1);
            this.LK += num1;
            this.LM += ((long) num1);
            return num1;
        }

        public void 52()
        {
            this.LJ = null;
            this.LN = null;
            this.LR = null;
            this.LW = null;
        }


        // Fields
        public const int KW = 0;
        public const int KX = 1;
        public const int KY = 9;
        public const int KZ = 6;
        public const int L0 = 1;
        public const int L1 = 2;
        public const int L2 = 0;
        public const int L3 = 0;
        public const int L4 = 1;
        public const int L5 = 2;
        public const int L6 = 3;
        public const int L7 = 4;
        public const int L8 = 0;
        public const int L9 = 1;
        public const int LA = 2;
        public const int LB = -1;
        public const int LC = -2;
        public const int LD = -3;
        public const int LE = -4;
        public const int LF = -5;
        public const int LG = -6;
        internal const int LH = 15;
        internal const int LI = 15;
        public byte[] LJ;
        public int LK;
        public int LL;
        public long LM;
        public byte[] LN;
        public int LO;
        public int LP;
        public long LQ;
        public string LR;
        internal L LS;
        internal P LT;
        internal int LU;
        public long LV;
        internal I LW;
        internal bool LX;
    }
}


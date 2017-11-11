namespace C1.C1Pdf
{
    using System;

    internal class 06 : IComparable
    {
        // Methods
        static 06()
        {
            06.O1 = 0;
        }

        internal 06(string text, int level, PdfPage page, float y)
        {
            this.NV = text;
            this.NX = level;
            this.NZ = page;
            this.O0 = y;
            this.NW = 2147483647;
            this.NY = 06.O1;
            06.O1 += 1;
        }

        private int 5Z(object 06W)
        {
            06 1 = ((06) 06W);
            int num1 = (this.NW - 1.NW);
            if (num1 == 0)
            {
                num1 = ((int) (1000f * (1.O0 - this.O0)));
            }
            if (num1 == 0)
            {
                num1 = (this.NY - 1.NY);
            }
            return num1;
        }

        internal void 60(C1PdfDocumentBase 06X)
        {
            06X.O4;
            06X.O7;
            this.NU = 06X.65("Bookmark");
            06X.67();
            06X.69("Title", this.NV, true);
            int num1 = this.NZ.UR;
            object[] objArray1 = new object[2];
            objArray1[0] = 06X.6K(num1);
            objArray1[1] = 06X.6L(((double) this.O0));
            06X.Write("/Dest [ {0} /XYZ null {1} null ]\r\n", objArray1);
            this.61(06X, "Parent", 04.NM);
            this.61(06X, "First", 04.NN);
            this.61(06X, "Prev", 04.NP);
            this.61(06X, "Next", 04.NQ);
            this.61(06X, "Last", 04.NO);
            this.61(06X, "Count", 04.NR);
            06X.6B();
            06X.66();
        }

        internal void 61(C1PdfDocumentBase 06Y, string 06Z, 04 070)
        {
            int num1 = this.62(06Y, 070);
            if (num1 < 0)
            {
                return;
            }
            if (070 == 04.NR)
            {
                if (num1 > 0)
                {
                    06Y.6A("Count", ((long) num1));
                }
                return;
            }
            int num2 = ((num1 + 06Y.O7.NS) + 1);
            06Y.68(06Z, 06Y.6K(num2));
        }

        internal int 62(C1PdfDocumentBase 071, 04 072)
        {
            int num1;
            05 1 = 071.O7;
            int num2 = 1.IndexOf(this);
            04 2 = 072;
            switch (2)
            {
                case 04.NM:
                {
                    num1 = (num2 - 1);
                    goto Label_0054;
                }
                case 04.NN:
                {
                    if ((num2 < (1.Count - 1)) && (1[(num2 + 1)].NX > this.NX))
                    {
                        return (num2 + 1);
                    }
                    goto Label_007F;
                }
                case 04.NO:
                {
                    num1 = (num2 + 1);
                    goto Label_009F;
                }
                case 04.NP:
                {
                    num1 = (num2 - 1);
                    goto Label_012B;
                }
                case 04.NQ:
                {
                    num1 = (num2 + 1);
                    goto Label_00EA;
                }
                case 04.NR:
                {
                    num1 = (num2 + 1);
                    goto Label_0155;
                }
            }
            goto Label_0160;
        Label_003A:
            if (1[num1].NX < this.NX)
            {
                return num1;
            }
            num1 -= 1;
        Label_0054:
            if (num1 >= 0)
            {
                goto Label_003A;
            }
            return -1;
        Label_007F:
            return -1;
        Label_0087:
            if (1[num1].NX <= this.NX)
            {
                goto Label_00A8;
            }
            num1 += 1;
        Label_009F:
            if (num1 < 1.Count)
            {
                goto Label_0087;
            }
        Label_00A8:
            if ((num1 - 1) > num2)
            {
                return (num1 - 1);
            }
            return -1;
        Label_00BA:
            if (1[num1].NX == this.NX)
            {
                return num1;
            }
            if (1[num1].NX < this.NX)
            {
                return -1;
            }
            num1 += 1;
        Label_00EA:
            if (num1 < 1.Count)
            {
                goto Label_00BA;
            }
            return -1;
        Label_00FB:
            if (1[num1].NX == this.NX)
            {
                return num1;
            }
            if (1[num1].NX < this.NX)
            {
                return -1;
            }
            num1 -= 1;
        Label_012B:
            if (num1 >= 0)
            {
                goto Label_00FB;
            }
            return -1;
        Label_0137:
            if (1[num1].NX <= this.NX)
            {
                return ((num1 - num2) - 1);
            }
            num1 += 1;
        Label_0155:
            if (num1 < 1.Count)
            {
                goto Label_0137;
            }
            return 0;
        Label_0160:
            return -1;
        }


        // Properties
        public string XH
        {
            get
            {
                return this.NV;
            }
            set
            {
                this.NV = 06S;
            }
        }

        public int XI
        {
            get
            {
                return this.NX;
            }
            set
            {
                this.NX = 06T;
            }
        }

        public PdfPage XJ
        {
            get
            {
                return this.NZ;
            }
            set
            {
                this.NZ = 06U;
            }
        }

        public float XK
        {
            get
            {
                return this.O0;
            }
            set
            {
                this.O0 = 06V;
            }
        }


        // Fields
        internal int NU;
        internal string NV;
        internal int NW;
        internal int NX;
        internal int NY;
        internal PdfPage NZ;
        internal float O0;
        private static int O1;
    }
}


namespace C1.C1Zip.ZLib
{
    using System;

    internal class J : I
    {
        // Methods
        public J()
        {
            this.CV = ((long) 1);
        }

        public long 2T(long 019, byte[] 01A, int 01B, int 01C)
        {
            if ((019 == ((long) 1)) || (01A == null))
            {
                this.2U();
            }
            if (01A != null)
            {
                this.2W(01A, 01B, 01C);
            }
            return this.2V();
        }

        private void 2U()
        {
            this.CV = ((long) 1);
        }

        private long 2V()
        {
            return this.CV;
        }

        private void 2W(byte[] 01D, int 01E, int 01F)
        {
            int num3;
            if (((01D == null) || (01E < 0)) || ((01F < 0) || ((01E + 01F) > 01D.Length)))
            {
                throw new ArgumentException("Bad parameters in call to Adler.update");
            }
            long num1 = (this.CV & ((long) 65535));
            long num2 = ((this.CV >> 16) & ((long) 65535));
            while ((01F > 0))
            {
                num3 = ((01F < 5552) ? 01F : 5552);
                01F = (01F - num3);
                while ((num3 >= 16))
                {
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num3 -= 16;
                }
                while ((num3 != 0))
                {
                    num1 += ((long) (01D[01E] & 255));
                    num2 += num1;
                    01E = (01E + 1);
                    num3 -= 1;
                }
                num1 = (num1 % ((long) 65521));
                num2 = (num2 % ((long) 65521));
            }
            this.CV = ((num2 << 16) | num1);
        }


        // Fields
        private const int CT = 65521;
        private const int CU = 5552;
        private long CV;
    }
}


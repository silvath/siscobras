namespace C1.C1Zip
{
    using C1.C1Zip.ZLib;
    using System;
    using System.IO;

    internal class V : Stream
    {
        // Methods
        internal V()
        {
            this.M7 = new byte[1];
        }

        public V(Stream baseStream)
        {
            this.M7 = new byte[1];
            this.53(baseStream, true, false);
        }

        public V(Stream baseStream, bool zip)
        {
            this.M7 = new byte[1];
            bool flag1 = !zip;
            bool flag2 = zip;
            this.53(baseStream, flag1, flag2);
        }

        public V(Stream baseStream, bool header, bool crc32)
        {
            this.M7 = new byte[1];
            this.53(baseStream, header, crc32);
        }

        public V(Stream baseStream, bool zip, int sizeCompressed)
        {
            this.M7 = new byte[1];
            bool flag1 = !zip;
            bool flag2 = zip;
            this.53(baseStream, flag1, flag2);
            this.M3 = ((long) sizeCompressed);
        }

        public V(Stream baseStream, bool zip, int sizeCompressed, int method)
        {
            this.M7 = new byte[1];
            bool flag1 = !zip;
            bool flag2 = zip;
            this.53(baseStream, flag1, flag2);
            this.M3 = ((long) sizeCompressed);
            this.M6 = (method == 0);
            if ((method != 0) && (method != 8))
            {
                throw new Exception("Compression method not supported by C1Zip.");
            }
        }

        internal void 53(Stream 05N, bool 05O, bool 05P)
        {
            if ((05N == null) || !05N.CanRead)
            {
                throw new ArgumentException("C1ZStreamReader needs a readable stream.");
            }
            this.M2 = false;
            this.M1 = new byte[32768];
            this.LZ = 05N;
            this.M4 = ((long) 0);
            this.M3 = ((long) -1);
            this.M6 = false;
            try
            {
                this.M4 = 05N.Position;
            }
            catch
            {
            }
            this.M0 = new T(05P);
            this.M0.LK = 0;
            this.M0.LL = 0;
            this.M0.LJ = this.M1;
            int num1 = this.M0.4P((05O ? 15 : -15));
            if (num1 != 0)
            {
                throw new Exception("Cannot initialize compressed stream");
            }
        }

        private int 54(byte[] 05R, int 05S, int 05T)
        {
            int num2;
            int num1 = 0;
        Label_0002:
            num2 = this.55(05R, 05S, 05T);
            if (num2 == 0)
            {
                return num1;
            }
            num1 += num2;
            05S = (05S + num2);
            05T = (05T - num2);
            goto Label_0002;
        }

        private int 55(byte[] 05U, int 05V, int 05W)
        {
            int num1;
            int num3;
            int num4;
            if (05W == 0)
            {
                return 0;
            }
            this.M0.LN = 05U;
            this.M0.LO = 05V;
            this.M0.LP = 05W;
        Label_0029:
            if ((this.M0.LL == 0) && !this.M2)
            {
                num1 = Math.Min(05W, this.M1.Length);
                if (this.M3 >= ((long) 0))
                {
                    num1 = ((int) Math.Min(((long) num1), (this.M3 - this.Position)));
                }
                this.M0.LK = 0;
                this.M0.LL = this.LZ.Read(this.M1, 0, num1);
                if ((this.M0.LL == 0) || (this.M0.LL < num1))
                {
                    this.M2 = true;
                }
            }
            int num2 = 0;
            if (this.M6)
            {
                num3 = Math.Min(this.M0.LL, this.M0.LP);
                for (num4 = 0; (num4 < num3); num4 += 1)
                {
                    this.M0.LN[(this.M0.LO + num4)] = this.M1[num4];
                }
                T t1 = this.M0;
                this.M0.LL = (t1.LL - num3);
                T t2 = this.M0;
                this.M0.LP = (t2.LP - num3);
            }
            else
            {
                num2 = this.M0.4Q(0);
            }
            if (!this.M2 || (num2 != -5))
            {
                if ((num2 != 0) && (num2 != 1))
                {
                    throw new U("Error inflating: " + this.M0.LR);
                }
                if ((!this.M2 || (this.M0.LP != 05W)) && (this.M0.LP == 05W))
                {
                    goto Label_0029;
                }
            }
            return (05W - this.M0.LP);
        }

        public override void Close()
        {
            if (this.M5)
            {
                this.LZ.Close();
            }
        }

        public override void Flush()
        {
            this.LZ.Flush();
        }

        public override int Read(byte[] buf, int offset, int count)
        {
            return this.54(buf, offset, count);
        }

        public override int ReadByte()
        {
            if (this.54(this.M7, 0, 1) != 0)
            {
                return ((int) this.M7[0]);
            }
            return -1;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException("Seek not supported.");
        }

        public override void SetLength(long value)
        {
            this.M3 = value;
        }

        public override void Write(byte[] buf, int offset, int count)
        {
            throw new NotSupportedException("Write not supported.");
        }


        // Properties
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        public override long Length
        {
            get
            {
                if (this.M3 >= ((long) 0))
                {
                    return this.M3;
                }
                return ((long) 0);
            }
        }

        public override long Position
        {
            get
            {
                return (this.LZ.Position - this.M4);
            }
            set
            {
                throw new NotSupportedException("Seek not supported.");
            }
        }

        public Stream WY
        {
            get
            {
                return this.LZ;
            }
        }

        public bool WZ
        {
            get
            {
                return this.M5;
            }
            set
            {
                this.M5 = 05Q;
            }
        }

        public int X0
        {
            get
            {
                return ((int) this.M0.LM);
            }
        }

        public int X1
        {
            get
            {
                return ((int) this.M0.LQ);
            }
        }

        public T X2
        {
            get
            {
                return this.M0;
            }
        }


        // Fields
        private const int LY = 32768;
        private Stream LZ;
        private T M0;
        private byte[] M1;
        private bool M2;
        private long M3;
        private long M4;
        private bool M5;
        private bool M6;
        private byte[] M7;
    }
}


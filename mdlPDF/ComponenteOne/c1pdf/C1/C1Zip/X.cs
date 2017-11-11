namespace C1.C1Zip
{
    using C1.C1Zip.ZLib;
    using System;
    using System.IO;

    internal class X : Stream
    {
        // Methods
        internal X()
        {
            this.MH = new byte[1];
        }

        public X(Stream baseStream)
        {
            this.MH = new byte[1];
            this.56(baseStream, W.MB, true, false);
        }

        public X(Stream baseStream, W level)
        {
            this.MH = new byte[1];
            this.56(baseStream, level, true, false);
        }

        public X(Stream baseStream, bool zip)
        {
            this.MH = new byte[1];
            bool flag1 = !zip;
            bool flag2 = zip;
            this.56(baseStream, W.MB, flag1, flag2);
        }

        public X(Stream baseStream, W level, bool zip)
        {
            this.MH = new byte[1];
            bool flag1 = !zip;
            bool flag2 = zip;
            this.56(baseStream, level, flag1, flag2);
        }

        public X(Stream baseStream, bool header, bool crc32)
        {
            this.MH = new byte[1];
            this.56(baseStream, W.MB, header, crc32);
        }

        public X(Stream baseStream, W level, bool header, bool crc32)
        {
            this.MH = new byte[1];
            this.56(baseStream, level, header, crc32);
        }

        internal void 56(Stream 05X, W 05Y, bool 05Z, bool 060)
        {
            if ((05X == null) || !05X.CanWrite)
            {
                throw new ArgumentException("baseStream must be writable stream.");
            }
            this.ME = new byte[16384];
            this.MC = 05X;
            this.MG = true;
            this.MD = new T(060);
            this.MD.LN = this.ME;
            this.MD.LP = this.ME.Length;
            this.MD.LO = 0;
            int num1 = (05Z ? this.MD.4U(05Y) : this.MD.4V(05Y, -15));
            if (num1 != 0)
            {
                throw new Exception("Cannot initialize compressed stream");
            }
        }

        internal void 57(byte[] 062, int 063, int 064)
        {
            int num1;
            if (064 == 0)
            {
                return;
            }
            if (this.MF)
            {
                throw new Exception("Can\'t write data after call to Finish()");
            }
            this.MD.LJ = 062;
            this.MD.LK = 063;
            this.MD.LL = 064;
        Label_003B:
            num1 = this.MD.4W(0);
            if (num1 != 0)
            {
                throw new U("Error deflating: " + this.MD.LR);
            }
            int num2 = (this.ME.Length - this.MD.LP);
            if (num2 > 0)
            {
                this.MC.Write(this.ME, 0, num2);
                this.MD.LP = this.ME.Length;
                this.MD.LN = this.ME;
                this.MD.LO = 0;
            }
            if (this.MD.LL <= 0)
            {
                return;
            }
            goto Label_003B;
        }

        internal void 58()
        {
            int num1;
            if (this.MF)
            {
                return;
            }
        Label_0009:
            num1 = this.MD.4W(2);
            if (num1 == 1)
            {
                return;
            }
            if (num1 != 0)
            {
                throw new U("Error deflating: " + this.MD.LR);
            }
            int num2 = (this.ME.Length - this.MD.LP);
            if (num2 <= 0)
            {
                goto Label_0009;
            }
            this.MC.Write(this.ME, 0, num2);
            this.MD.LP = this.ME.Length;
            this.MD.LN = this.ME;
            this.MD.LO = 0;
            goto Label_0009;
        }

        internal void 59()
        {
            int num1;
            int num2;
            if (this.MF)
            {
                return;
            }
        Label_0009:
            num1 = this.MD.4W(4);
            if (num1 != 1)
            {
                if (num1 != 0)
                {
                    throw new U("Error deflating: " + this.MD.LR);
                }
                num2 = (this.ME.Length - this.MD.LP);
                if (num2 <= 0)
                {
                    goto Label_0009;
                }
                this.MC.Write(this.ME, 0, num2);
                this.MD.LP = this.ME.Length;
                this.MD.LN = this.ME;
                this.MD.LO = 0;
                goto Label_0009;
            }
            num1 = this.MD.4X();
            if (num1 != 0)
            {
                throw new U("Error deflating: " + this.MD.LR);
            }
            num2 = (this.ME.Length - this.MD.LP);
            if (num2 > 0)
            {
                this.MC.Write(this.ME, 0, num2);
            }
            this.MF = true;
        }

        public override void Close()
        {
            this.59();
            if (this.MG)
            {
                this.MC.Close();
            }
        }

        public override void Flush()
        {
            this.58();
            this.MC.Flush();
        }

        public override int Read(byte[] buf, int offset, int count)
        {
            throw new NotSupportedException("Read not supported");
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException("Seek not supported");
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException("SetLength not supported");
        }

        public override void Write(byte[] buf, int offset, int count)
        {
            this.57(buf, offset, count);
        }

        public override void WriteByte(byte value)
        {
            this.MH[0] = value;
            this.57(this.MH, 0, 1);
        }


        // Properties
        public override bool CanRead
        {
            get
            {
                return false;
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
                return true;
            }
        }

        public override long Length
        {
            get
            {
                return this.MC.Length;
            }
        }

        public override long Position
        {
            get
            {
                return this.MC.Position;
            }
            set
            {
                throw new NotSupportedException("Seek not supported");
            }
        }

        public Stream X3
        {
            get
            {
                return this.MC;
            }
        }

        public bool X4
        {
            get
            {
                return this.MG;
            }
            set
            {
                this.MG = 061;
            }
        }

        public int X5
        {
            get
            {
                return ((int) this.MD.LV);
            }
        }

        public int X6
        {
            get
            {
                return ((int) this.MD.LQ);
            }
        }

        public int X7
        {
            get
            {
                return ((int) this.MD.LM);
            }
        }

        public T X8
        {
            get
            {
                return this.MD;
            }
        }


        // Fields
        private Stream MC;
        private T MD;
        private byte[] ME;
        private bool MF;
        private bool MG;
        private byte[] MH;
    }
}


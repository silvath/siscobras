namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.IO;
    using System.Reflection;

    internal class PDFIndexedCSDoubleArrayStream : DoubleArray
    {
        // Methods
        internal PDFIndexedCSDoubleArrayStream(PDFStream str, int pos, int ncomponet, byte[] data, int start) : base(ncomponet)
        {
            int num1;
            this.Position = pos;
            this.mNComponent = ncomponet;
            this.mStr = str;
            for (num1 = 0; (num1 < ncomponet); num1 += 1)
            {
                this.mArr[num1] = ((double) data[(start + num1)]);
            }
        }


        // Properties
        public override double this[int x]
        {
            get
            {
                return base[x];
            }
            set
            {
                base[x] = value;
                Stream stream1 = this.mStr.Decode();
                byte[] numArray1 = new byte[((IntPtr) stream1.Length)];
                stream1.Read(numArray1, 0, numArray1.Length);
                stream1.Close();
                numArray1[((this.Position * this.mNComponent) + x)] = ((byte) value);
                this.mStr.Encode(new MemoryStream(numArray1, false));
            }
        }


        // Fields
        private int mNComponent;
        private PDFStream mStr;
        internal int Position;
    }
}


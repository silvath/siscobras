namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Reflection;

    internal class PDFIndexedCSDoubleArrayString : DoubleArray
    {
        // Methods
        internal PDFIndexedCSDoubleArrayString(PDFString str, int pos, int ncomponet, byte[] data, int start) : base(ncomponet)
        {
            int num1;
            this.Position = pos;
            this.mNComponent = ncomponet;
            this.mStr = str;
            for (num1 = 0; (num1 < ncomponet); num1 += 1)
            {
                this.mArr[num1] = ((double) data[(num1 + start)]);
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
                string text1 = this.mStr.Value;
                byte[] numArray2 = new byte[1];
                numArray2[0] = ((byte) value);
                byte[] numArray1 = numArray2;
                text1 = text1.Substring(0, ((this.Position * this.mNComponent) + x)) + Encoding.ASCII.GetChars(numArray1)[0] + text1.Substring((((this.Position * this.mNComponent) + x) + 1));
                this.mStr.Value = text1;
            }
        }


        // Fields
        private int mNComponent;
        private PDFString mStr;
        internal int Position;
    }
}


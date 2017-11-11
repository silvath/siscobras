namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Reflection;

    internal class PDFCTM : CTM
    {
        // Methods
        internal PDFCTM(PDFArray arr)
        {
            int num1;
            this.mArr = new PDFDoubleArray(arr, 6);
            for (num1 = 0; (num1 < 6); num1 += 1)
            {
                base[(num1 % 3), (num1 / 2)] = this.mArr[num1];
            }
        }

        internal PDFCTM(PDFDict parent, string keyName, params double[] def)
        {
            int num1;
            this.mArr = new PDFDoubleArray(parent, keyName, false, def);
            for (num1 = 0; (num1 < 6); num1 += 1)
            {
                base[(num1 % 3), (num1 / 2)] = this.mArr[num1];
            }
        }


        // Properties
        public override double this[int x, int y]
        {
            set
            {
                base[x, y] = value;
                if ((x < 2) && (this.mArr != null))
                {
                    this.mArr[(x + (y * 2))] = value;
                }
            }
        }


        // Fields
        private DoubleArray mArr;
    }
}


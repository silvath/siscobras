namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class FontType3 : Font
    {
        // Methods
        public FontType3(PDFDirect d) : base(d)
        {
            int num1;
            PDFNumeric numeric1;
            PDFArray array1 = (this.Dict["FontMatrix"] as PDFArray);
            if (array1 == null)
            {
                throw new ArgumentException("No FontMatrix entry for the Type3 font.");
            }
            if (6 != array1.Count)
            {
                throw new ArgumentException("Incorrect FontMatrix entry for the Type3 font. Must have 6 positions.");
            }
            double[] numArray1 = new double[6];
            for (num1 = 0; (num1 < 6); num1 += 1)
            {
                numeric1 = (array1[num1] as PDFNumeric);
                if (numeric1 == null)
                {
                    throw new ArgumentException("Incorrect datatype for the entry of FontMatrix array.");
                }
                numArray1[num1] = numeric1.DoubleValue;
            }
            this.mMatrix = new CTM(numArray1);
        }

        public PDFStream GetGlyphStream(PDFName key)
        {
            PDFDict dict1 = (this.Dict["CharProcs"] as PDFDict);
            if (dict1 == null)
            {
                throw new ArgumentException("Invalid CharProcs in Type3 font");
            }
            return (dict1[key, 1] as PDFStream);
        }


        // Properties
        public override string BaseFont
        {
            get
            {
                return "";
            }
        }

    }
}


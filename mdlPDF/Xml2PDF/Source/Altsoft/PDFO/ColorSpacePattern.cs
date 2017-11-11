namespace Altsoft.PDFO
{
    using System;

    public class ColorSpacePattern : ColorSpaceSpecial
    {
        // Methods
        internal ColorSpacePattern(PDFDirect d) : base(d)
        {
        }

        public static ColorSpacePattern Create(bool indirect, ColorSpace baseCS)
        {
            PDFArray array1 = Library.CreateArray(2);
            array1[0] = PDF.N("Pattern");
            ColorSpacePattern pattern1 = (Resources.Get(array1, typeof(ColorSpacePattern)) as ColorSpacePattern);
            if (indirect)
            {
                Library.CreateIndirect(array1);
            }
            return pattern1;
        }


        // Properties
        protected override int mBaseCSIndex
        {
            get
            {
                return 2;
            }
        }

        public override int NrOfChannels
        {
            get
            {
                return 1;
            }
        }

        public override string SubType
        {
            get
            {
                return "Pattern";
            }
        }

    }
}


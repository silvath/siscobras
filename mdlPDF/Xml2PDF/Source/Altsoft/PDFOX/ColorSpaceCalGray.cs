namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class ColorSpaceCalGray : ColorSpaceCal
    {
        // Methods
        internal ColorSpaceCalGray(PDFDirect d) : base(d)
        {
        }

        public static ColorSpaceCalGray Create()
        {
            return ColorSpaceCalGray.Create(false);
        }

        public static ColorSpaceCalGray Create(bool indirect)
        {
            double[] numArray1 = new double[3] { 1f, 1f, 1f };
            return ColorSpaceCalGray.Create(indirect, numArray1);
        }

        public static ColorSpaceCalGray Create(bool indirect, double[] whitePoint)
        {
            PDFArray array1 = Library.CreateArray(2);
            array1[0] = PDF.N("CalGray");
            PDFDict dict1 = Library.CreateDict();
            array1[1] = dict1;
            dict1["WhitePoint"] = PDF.O(whitePoint);
            ColorSpaceCalGray gray1 = (Resources.Get(array1, typeof(ColorSpaceCalGray)) as ColorSpaceCalGray);
            if (indirect)
            {
                Library.CreateIndirect(array1);
            }
            return gray1;
        }

        public static ColorSpaceCalGray Create(bool indirect, double[] whitePoint, double[] blackPoint)
        {
            ColorSpaceCalGray gray1 = ColorSpaceCalGray.Create(indirect, whitePoint);
            gray1.BlackPoint = DoubleArray.op_Implicit(blackPoint);
            return gray1;
        }

        public static ColorSpaceCalGray Create(bool indirect, double[] whitePoint, double[] blackPoint, double gamma)
        {
            ColorSpaceCalGray gray1 = ColorSpaceCalGray.Create(indirect, whitePoint);
            gray1.Gamma = DoubleArray.op_Implicit(gamma);
            gray1.BlackPoint = DoubleArray.op_Implicit(blackPoint);
            return gray1;
        }


        // Properties
        public override DoubleArray Gamma
        {
            get
            {
                double[] numArray1;
                if (this.mGamma == null)
                {
                    numArray1 = new double[1];
                    numArray1[0] = 1f;
                    this.mGamma = new PDFDoubleArray(this.Dict, "Gamma", true, numArray1);
                }
                return this.mGamma;
            }
            set
            {
                base.Gamma = value;
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
                return "CalGray";
            }
        }

    }
}


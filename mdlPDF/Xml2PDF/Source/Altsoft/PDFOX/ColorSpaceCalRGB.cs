namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class ColorSpaceCalRGB : ColorSpaceCal
    {
        // Methods
        internal ColorSpaceCalRGB(PDFDirect d) : base(d)
        {
        }

        public static ColorSpaceCalRGB Create()
        {
            return ColorSpaceCalRGB.Create(false);
        }

        public static ColorSpaceCalRGB Create(bool indirect)
        {
            double[] numArray1 = new double[3] { 1f, 1f, 1f };
            return ColorSpaceCalRGB.Create(indirect, numArray1);
        }

        public static ColorSpaceCalRGB Create(bool indirect, double[] whitePoint)
        {
            PDFArray array1 = Library.CreateArray(2);
            array1[0] = PDF.N("CalRGB");
            PDFDict dict1 = Library.CreateDict();
            array1[1] = dict1;
            dict1["WhitePoint"] = PDF.O(whitePoint);
            ColorSpaceCalRGB lrgb1 = (Resources.Get(array1, typeof(ColorSpaceCalRGB)) as ColorSpaceCalRGB);
            if (indirect)
            {
                Library.CreateIndirect(array1);
            }
            return lrgb1;
        }

        public static ColorSpaceCalRGB Create(bool indirect, double[] whitePoint, double[] blackPoint)
        {
            ColorSpaceCalRGB lrgb1 = ColorSpaceCalRGB.Create(indirect, whitePoint);
            lrgb1.BlackPoint = DoubleArray.op_Implicit(blackPoint);
            return lrgb1;
        }

        public static ColorSpaceCalRGB Create(bool indirect, double[] whitePoint, double[] blackPoint, double[] gamma)
        {
            ColorSpaceCalRGB lrgb1 = ColorSpaceCalRGB.Create(indirect, whitePoint);
            lrgb1.Gamma = DoubleArray.op_Implicit(gamma);
            lrgb1.BlackPoint = DoubleArray.op_Implicit(blackPoint);
            return lrgb1;
        }


        // Properties
        public override DoubleArray Gamma
        {
            get
            {
                double[] numArray1;
                if (this.mGamma == null)
                {
                    numArray1 = new double[3];
                    numArray1[0] = 1f;
                    numArray1[1] = 1f;
                    numArray1[2] = 1f;
                    this.mGamma = new PDFDoubleArray(this.Dict, "Gamma", false, numArray1);
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
                return 3;
            }
        }

        public override string SubType
        {
            get
            {
                return "CalRGB";
            }
        }

    }
}


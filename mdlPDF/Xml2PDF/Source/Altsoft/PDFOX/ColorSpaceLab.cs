namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class ColorSpaceLab : ColorSpaceCal
    {
        // Methods
        internal ColorSpaceLab(PDFDirect direct) : base(direct)
        {
            this.mRange = null;
        }

        public static ColorSpaceLab Create()
        {
            return ColorSpaceLab.Create(false);
        }

        public static ColorSpaceLab Create(bool indirect)
        {
            double[] numArray1 = new double[3] { 1f, 1f, 1f };
            return ColorSpaceLab.Create(indirect, numArray1);
        }

        public static ColorSpaceLab Create(bool indirect, double[] whitePoint)
        {
            PDFArray array1 = Library.CreateArray(2);
            array1[0] = PDF.N("Lab");
            PDFDict dict1 = Library.CreateDict();
            array1[1] = dict1;
            dict1["WhitePoint"] = PDF.O(whitePoint);
            ColorSpaceLab lab1 = (Resources.Get(array1, typeof(ColorSpaceLab)) as ColorSpaceLab);
            if (indirect)
            {
                Library.CreateIndirect(array1);
            }
            return lab1;
        }

        public static ColorSpaceLab Create(bool indirect, double[] whitePoint, double[] blackPoint)
        {
            ColorSpaceLab lab1 = ColorSpaceLab.Create(indirect, whitePoint);
            lab1.BlackPoint = DoubleArray.op_Implicit(blackPoint);
            return lab1;
        }

        public static ColorSpaceLab Create(bool indirect, double[] whitePoint, double[] blackPoint, double[] gamma)
        {
            ColorSpaceLab lab1 = ColorSpaceLab.Create(indirect, whitePoint);
            lab1.Gamma = DoubleArray.op_Implicit(gamma);
            lab1.BlackPoint = DoubleArray.op_Implicit(blackPoint);
            return lab1;
        }

        public static ColorSpaceLab Create(bool indirect, double[] whitePoint, double[] blackPoint, double[] gamma, double[] range)
        {
            ColorSpaceLab lab1 = ColorSpaceLab.Create(indirect, whitePoint);
            lab1.Gamma = DoubleArray.op_Implicit(gamma);
            lab1.BlackPoint = DoubleArray.op_Implicit(blackPoint);
            lab1.Range.LinearArray.Set(range);
            return lab1;
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

        public DoubleMinMaxArray Range
        {
            get
            {
                double[] numArray1;
                if (this.mRange == null)
                {
                    numArray1 = new double[4];
                    numArray1[0] = -100f;
                    numArray1[1] = 100f;
                    numArray1[2] = -100f;
                    numArray1[3] = 100f;
                    this.mRange = new DoubleMinMaxArray(new PDFDoubleArray(this.Dict, "Range", false, numArray1));
                }
                return this.mRange;
            }
            set
            {
                this.Range.Set(value);
            }
        }

        public double RangeAMax
        {
            get
            {
                return this.Range[0].Max;
            }
            set
            {
                this.Range[0].Max = value;
            }
        }

        public double RangeAMin
        {
            get
            {
                return this.Range[0].Min;
            }
            set
            {
                this.Range[0].Min = value;
            }
        }

        public double RangeBMax
        {
            get
            {
                return this.Range[1].Max;
            }
            set
            {
                this.Range[1].Max = value;
            }
        }

        public double RangeBMin
        {
            get
            {
                return this.Range[1].Min;
            }
            set
            {
                this.Range[1].Min = value;
            }
        }

        public override string SubType
        {
            get
            {
                return "Lab";
            }
        }


        // Fields
        private DoubleMinMaxArray mRange;
    }
}


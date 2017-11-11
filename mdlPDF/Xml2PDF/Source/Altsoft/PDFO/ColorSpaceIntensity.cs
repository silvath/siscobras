namespace Altsoft.PDFO
{
    using System;

    public class ColorSpaceIntensity : Resource
    {
        // Methods
        public ColorSpaceIntensity(PDFDirect direct) : base(direct)
        {
            this.mArr = (direct as PDFArray);
        }

        public static ColorSpaceIntensity Create(double[] arr)
        {
            int num1;
            PDFArray array1 = Library.CreateArray(arr.Length);
            for (num1 = 0; (num1 < arr.Length); num1 += 1)
            {
                array1[num1] = Library.CreateFixed(arr[num1]);
            }
            return new ColorSpaceIntensity(array1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new ColorSpaceIntensity(direct);
        }


        // Properties
        public double BlackIntencity
        {
            get
            {
                if ((this.mArr == null) || (this.mArr.Count != 4))
                {
                    return NaNf;
                }
                return (this.mArr[3] as PDFFixed).DoubleValue;
            }
            set
            {
                if ((this.mArr == null) || (this.mArr.Count != 4))
                {
                    throw new Exception("Illegal colorspace set");
                }
                this.mArr[3] = Library.CreateFixed(value);
            }
        }

        public double BlueIntencity
        {
            get
            {
                if ((this.mArr == null) || (this.mArr.Count != 3))
                {
                    return NaNf;
                }
                return (this.mArr[2] as PDFFixed).DoubleValue;
            }
            set
            {
                if ((this.mArr == null) || (this.mArr.Count != 3))
                {
                    throw new Exception("Illegal colorspace set");
                }
                this.mArr[2] = Library.CreateFixed(value);
            }
        }

        public EColorSpaces ColorSpace
        {
            get
            {
                if (this.mArr == null)
                {
                    return EColorSpaces.transparent;
                }
                return ((EColorSpaces) this.mArr.Count);
            }
            set
            {
                int num1 = ((int) value);
                if (num1 == 0)
                {
                    this.mArr = null;
                    return;
                }
                this.mArr = Library.CreateArray(num1);
                this.mDirect = this.mArr;
            }
        }

        public double CyanIntencity
        {
            get
            {
                if ((this.mArr == null) || (this.mArr.Count != 4))
                {
                    return NaNf;
                }
                return (this.mArr[0] as PDFFixed).DoubleValue;
            }
            set
            {
                if ((this.mArr == null) || (this.mArr.Count != 4))
                {
                    throw new Exception("Illegal colorspace set");
                }
                this.mArr[0] = Library.CreateFixed(value);
            }
        }

        public double GrayIntencity
        {
            get
            {
                if ((this.mArr == null) || (this.mArr.Count != 1))
                {
                    return NaNf;
                }
                return (this.mArr[0] as PDFFixed).DoubleValue;
            }
            set
            {
                if ((this.mArr == null) || (this.mArr.Count != 1))
                {
                    throw new Exception("Illegal colorspace set");
                }
                this.mArr[0] = Library.CreateFixed(value);
            }
        }

        public double GreenIntencity
        {
            get
            {
                if ((this.mArr == null) || (this.mArr.Count != 3))
                {
                    return NaNf;
                }
                return (this.mArr[1] as PDFFixed).DoubleValue;
            }
            set
            {
                if ((this.mArr == null) || (this.mArr.Count != 3))
                {
                    throw new Exception("Illegal colorspace set");
                }
                this.mArr[1] = Library.CreateFixed(value);
            }
        }

        public double MagentaIntencity
        {
            get
            {
                if ((this.mArr == null) || (this.mArr.Count != 4))
                {
                    return NaNf;
                }
                return (this.mArr[1] as PDFFixed).DoubleValue;
            }
            set
            {
                if ((this.mArr == null) || (this.mArr.Count != 4))
                {
                    throw new Exception("Illegal colorspace set");
                }
                this.mArr[1] = Library.CreateFixed(value);
            }
        }

        public double RedIntencity
        {
            get
            {
                if ((this.mArr == null) || (this.mArr.Count != 3))
                {
                    return NaNf;
                }
                return (this.mArr[0] as PDFFixed).DoubleValue;
            }
            set
            {
                if ((this.mArr == null) || (this.mArr.Count != 3))
                {
                    throw new Exception("Illegal colorspace set");
                }
                this.mArr[0] = Library.CreateFixed(value);
            }
        }

        public double YellowIntencity
        {
            get
            {
                if ((this.mArr == null) || (this.mArr.Count != 4))
                {
                    return NaNf;
                }
                return (this.mArr[2] as PDFFixed).DoubleValue;
            }
            set
            {
                if ((this.mArr == null) || (this.mArr.Count != 4))
                {
                    throw new Exception("Illegal colorspace set");
                }
                this.mArr[2] = Library.CreateFixed(value);
            }
        }


        // Fields
        private PDFArray mArr;
    }
}


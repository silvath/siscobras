namespace Altsoft.PDFO
{
    using System;

    public class BorderCharact
    {
        // Methods
        public BorderCharact(PDFDict dict, string key)
        {
            this.mDict = dict;
            this.mKey = key;
            this.mArr = (dict[key] as PDFArray);
        }

        public BorderCharact(double h_r, double v_r, double width)
        {
            this.mArr = Library.CreateArray(3);
            this.mArr[0] = Library.CreateFixed(h_r);
            this.mArr[1] = Library.CreateFixed(v_r);
            this.mArr[2] = Library.CreateFixed(width);
        }


        // Properties
        public PDFArray CharactArray
        {
            get
            {
                return this.mArr;
            }
            set
            {
                this.mArr = value;
            }
        }

        public double HCornerRadius
        {
            get
            {
                if (this.mArr == null)
                {
                    return NaNf;
                }
                return (this.mArr[0] as PDFFixed).DoubleValue;
            }
            set
            {
                double[] numArray1;
                if (this.mArr == null)
                {
                    numArray1 = new double[3];
                    this.mArr = Library.CreateArray(false, numArray1);
                }
                this.mArr[0] = Library.CreateFixed(value);
                if (this.mDict != null)
                {
                    this.mDict[this.mKey] = this.mArr;
                }
            }
        }

        public LineDashPattern LinePattern
        {
            get
            {
                if (this.mLinePattern != null)
                {
                    return this.mLinePattern;
                }
                if (this.mArr == null)
                {
                    return null;
                }
                if (this.mArr.Count < 4)
                {
                    return null;
                }
                PDFArray array1 = (this.mArr[3] as PDFArray);
                if (array1 == null)
                {
                    return null;
                }
                return new LineDashPattern(array1);
            }
            set
            {
                if (this.mArr == null)
                {
                    this.mArr = Library.CreateArray(4);
                }
                this.mLinePattern = value;
                this.mArr[3] = Library.CreateArray(false, value);
                if (this.mDict != null)
                {
                    this.mDict[this.mKey] = this.mArr;
                }
            }
        }

        public double LineWidth
        {
            get
            {
                if (this.mArr == null)
                {
                    return NaNf;
                }
                return (this.mArr[2] as PDFFixed).DoubleValue;
            }
            set
            {
                double[] numArray1;
                if (this.mArr == null)
                {
                    numArray1 = new double[3];
                    this.mArr = Library.CreateArray(false, numArray1);
                }
                this.mArr[2] = Library.CreateFixed(value);
                if (this.mDict != null)
                {
                    this.mDict[this.mKey] = this.mArr;
                }
            }
        }

        public double VCornerRadius
        {
            get
            {
                if (this.mArr == null)
                {
                    return NaNf;
                }
                return (this.mArr[1] as PDFFixed).DoubleValue;
            }
            set
            {
                double[] numArray1;
                if (this.mArr == null)
                {
                    numArray1 = new double[3];
                    this.mArr = Library.CreateArray(false, numArray1);
                }
                this.mArr[1] = Library.CreateFixed(value);
                if (this.mDict != null)
                {
                    this.mDict[this.mKey] = this.mArr;
                }
            }
        }


        // Fields
        private PDFArray mArr;
        private PDFDict mDict;
        private string mKey;
        private LineDashPattern mLinePattern;
    }
}


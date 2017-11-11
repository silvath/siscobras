namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Reflection;

    public class FunctionType2 : Function
    {
        // Methods
        internal FunctionType2(PDFDirect d) : base(d)
        {
            this.mC0 = null;
            this.mC1 = null;
        }

        public static FunctionType2 Create(double[] domain, double[] c0, double[] c1, double n)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["FunctionType"] = Library.CreateInteger(((long) 2));
            dict1["Domain"] = Library.CreateArray(false, domain);
            dict1["C0"] = Library.CreateArray(false, c0);
            dict1["C1"] = Library.CreateArray(false, c1);
            dict1["N"] = Library.CreateFixed(n);
            return new FunctionType2(dict1);
        }


        // Properties
        public DoubleArray C0
        {
            get
            {
                double[] numArray1;
                if (this.mC0 == null)
                {
                    numArray1 = new double[1];
                    numArray1[0] = 1f;
                    this.mC0 = new PDFDoubleArray(this.Dict, "C0", false, numArray1);
                }
                return this.mC0;
            }
            set
            {
                this.C0.Set(value);
            }
        }

        public DoubleArray C1
        {
            get
            {
                double[] numArray1;
                if (this.mC1 == null)
                {
                    numArray1 = new double[1];
                    numArray1[0] = 1f;
                    this.mC1 = new PDFDoubleArray(this.Dict, "C1", false, numArray1);
                }
                return this.mC1;
            }
            set
            {
                this.C1.Set(value);
            }
        }

        public override double[] this[double[] args]
        {
            get
            {
                int num3;
                double num4;
                double num5;
                int num6;
                if (args.Length != 1)
                {
                    throw new ArgumentException("Incorrect number of arguments. For Type2 function it is always 1", "args");
                }
                double[] numArray1 = null;
                if (this.C0 != null)
                {
                    numArray1 = new double[this.C0.Count];
                }
                else
                {
                    numArray1 = new double[1];
                }
                double num1 = Math.Min(Math.Max(args[0], this.Domain[0].Min), this.Domain[0].Max);
                double num2 = this.N;
                for (num3 = 0; (num3 < numArray1.Length); num3 += 1)
                {
                    if (this.C0 != null)
                    {
                        num4 = this.C0[num3];
                    }
                    else
                    {
                        num4 = 0f;
                    }
                    if (this.C1 != null)
                    {
                        num5 = this.C1[num3];
                    }
                    else
                    {
                        num5 = 1f;
                    }
                    numArray1[num3] = (num4 + (Math.Pow(num1, num2) * (num5 - num4)));
                }
                if (this.Range == null)
                {
                    return numArray1;
                }
                for (num6 = 0; (num6 < numArray1.Length); num6 += 1)
                {
                    numArray1[num6] = Math.Min(Math.Max(numArray1[num6], this.Range[num6].Min), this.Range[num6].Max);
                }
                return numArray1;
            }
        }

        public double N
        {
            get
            {
                return ((PDFNumeric) this.Dict["N"]).DoubleValue;
            }
            set
            {
                this.Dict["N"] = Library.CreateFixed(value);
            }
        }

        public override int SubType
        {
            get
            {
                return 2;
            }
        }


        // Fields
        private PDFDoubleArray mC0;
        private PDFDoubleArray mC1;
    }
}


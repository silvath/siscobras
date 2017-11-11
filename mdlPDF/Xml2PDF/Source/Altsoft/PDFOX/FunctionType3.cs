namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Reflection;

    public class FunctionType3 : Function
    {
        // Methods
        internal FunctionType3(PDFDirect d) : base(d)
        {
            int num1;
            this.mEncode = null;
            this.mBounds = null;
            this.Functions = null;
            PDFArray array1 = ((PDFArray) this.Dict["Functions"]);
            this.Functions = new Function[array1.Count];
            for (num1 = 0; (num1 < array1.Count); num1 += 1)
            {
                if (this.mDirect.Doc != null)
                {
                    this.Functions[num1] = ((Function) this.mDirect.Doc.Resources[array1[num1], typeof(Function)]);
                }
                else
                {
                    this.Functions[num1] = ((Function) Function.Factory(array1[num1].Direct));
                }
            }
        }


        // Properties
        public DoubleArray Bounds
        {
            get
            {
                double[] numArray1;
                if (this.mBounds == null)
                {
                    numArray1 = new double[1];
                    this.mBounds = new PDFDoubleArray(this.Dict, "Bounds", false, numArray1);
                }
                return this.mBounds;
            }
            set
            {
                this.Bounds.Set(value);
            }
        }

        public DoubleMinMaxArray Encode
        {
            get
            {
                double[] numArray1;
                if (this.mEncode == null)
                {
                    numArray1 = new double[1];
                    this.mEncode = new DoubleMinMaxArray(new PDFDoubleArray(this.Dict, "Encode", false, numArray1));
                }
                return this.mEncode;
            }
            set
            {
                this.Encode.Set(value);
            }
        }

        public override double[] this[double[] args]
        {
            get
            {
                if (args.Length != 1)
                {
                    throw new ArgumentException("Incorrect number of arguments. For Type3 function it is always 1", "args");
                }
                double num1 = Math.Min(Math.Max(args[0], this.Domain[0].Min), this.Domain[0].Max);
                int num2 = 0;
                while ((num2 < this.Bounds.Count))
                {
                    if (num1 < this.Bounds[num2])
                    {
                        break;
                    }
                    num2 += 1;
                }
                num1 = Function.InterpolateLin1d(num1, ((num2 == 0) ? this.Domain[0].Min : this.Bounds[(num2 - 1)]), ((num2 == this.Bounds.Count) ? this.Domain[0].Max : this.Bounds[num2]), this.Encode[num2].Min, this.Encode[num2].Max);
                double[] numArray1 = new double[1];
                numArray1[0] = num1;
                return this.Functions[num2][numArray1];
            }
        }

        public override int SubType
        {
            get
            {
                return 3;
            }
        }


        // Fields
        public Function[] Functions;
        private PDFDoubleArray mBounds;
        private DoubleMinMaxArray mEncode;
    }
}


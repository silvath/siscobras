namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.IO;
    using System.Reflection;

    public class FunctionType0 : Function
    {
        // Methods
        internal FunctionType0(PDFDirect d) : base(d)
        {
            this.mEncode = null;
            this.mDecode = null;
            this.mSize = null;
            this.mData = null;
        }


        // Properties
        public int BitsPerSample
        {
            get
            {
                return ((PDFInteger) this.Dict["BitsPerSample"]).Int32Value;
            }
            set
            {
                if ((((value != 1) && (value != 1)) && ((value != 1) && (value != 1))) && (((value != 1) && (value != 1)) && ((value != 1) && (value != 1))))
                {
                    throw new ArgumentException("BitsPerSample must be one of {1,2,4,8,12,16,24,32}", "value");
                }
                this.Dict["BitsPerSample"] = Library.CreateInteger(((long) value));
            }
        }

        private BitArrayAccessor Data
        {
            get
            {
                PDFStream stream1;
                Stream stream2;
                byte[] numArray1;
                if (this.mData == null)
                {
                    stream1 = ((PDFStream) this.mDirect);
                    stream2 = stream1.Decode();
                    numArray1 = new byte[((IntPtr) stream2.Length)];
                    stream2.Read(numArray1, 0, ((int) stream2.Length));
                    stream2.Close();
                    this.mData = new BitArrayAccessor(numArray1, this.BitsPerSample, false);
                }
                return this.mData;
            }
        }

        public DoubleMinMaxArray Decode
        {
            get
            {
                double[] numArray1;
                int num1;
                if (this.mDecode == null)
                {
                    numArray1 = new double[(this.Range.Count * 2)];
                    for (num1 = 0; (num1 < numArray1.Length); num1 += 1)
                    {
                        numArray1[num1] = (((num1 % 2) == 0) ? this.Range[(num1 / 2)].Min : this.Range[(num1 / 2)].Max);
                    }
                    this.mDecode = new DoubleMinMaxArray(new PDFDoubleArray(this.Dict, "Decode", false, numArray1));
                }
                return this.mDecode;
            }
            set
            {
                this.Decode.Set(value);
            }
        }

        public DoubleMinMaxArray Encode
        {
            get
            {
                double[] numArray1;
                int num1;
                if (this.mEncode == null)
                {
                    numArray1 = new double[(this.Size.Count * 2)];
                    for (num1 = 0; (num1 < numArray1.Length); num1 += 1)
                    {
                        numArray1[num1] = (((num1 % 2) == 0) ? 0f : (this.Size[(num1 / 2)] - 1f));
                    }
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
                int num1;
                int num2;
                int num4;
                if (args.Length != this.Domain.Count)
                {
                    throw new ArgumentException("Incorrect number of arguments", "args");
                }
                double[] numArray1 = new double[args.Length];
                for (num1 = 0; (num1 < numArray1.Length); num1 += 1)
                {
                    numArray1[num1] = Math.Min(Math.Max(args[num1], this.Domain[num1].Min), this.Domain[num1].Max);
                    numArray1[num1] = Function.InterpolateLin1d(numArray1[num1], this.Domain[num1].Min, this.Domain[num1].Max, this.Encode[num1].Min, this.Encode[num1].Max);
                }
                Stream stream1 = ((PDFStream) this.mDirect).Decode();
                byte[] numArray2 = new byte[((IntPtr) stream1.Length)];
                stream1.Read(numArray2, 0, numArray2.Length);
                BitArrayAccessor accessor1 = new BitArrayAccessor(numArray2, this.BitsPerSample, false);
                int[] numArray3 = new int[this.Size.Count];
                for (num2 = 0; (num2 < numArray3.Length); num2 += 1)
                {
                    numArray3[num2] = ((int) this.Size[num2]);
                }
                double[] numArray4 = Type0FunctionCalculator.Calculate(this.Order, accessor1, numArray3, this.Range.Count, numArray1);
                double num3 = (Math.Pow(2f, ((double) this.BitsPerSample)) - 1f);
                for (num4 = 0; (num4 < numArray4.Length); num4 += 1)
                {
                    numArray4[num4] = Function.InterpolateLin1d(numArray4[num4], 0f, num3, this.Decode[num4].Min, this.Decode[num4].Max);
                    numArray4[num4] = Math.Min(Math.Max(numArray4[num4], this.Range[num4].Min), this.Range[num4].Max);
                }
                return numArray4;
            }
        }

        public InterpolationOrder Order
        {
            get
            {
                PDFInteger integer1 = ((PDFInteger) this.Dict["Order"]);
                if (integer1 == null)
                {
                    return InterpolationOrder.Linear;
                }
                return ((InterpolationOrder) integer1.Int32Value);
            }
            set
            {
                this.Dict["Order"] = Library.CreateInteger(((long) value));
            }
        }

        public DoubleArray Size
        {
            get
            {
                if (this.mSize == null)
                {
                    this.mSize = new PDFDoubleArray(((PDFArray) this.Dict["Size"]));
                }
                return this.mSize;
            }
            set
            {
                this.Size.Set(value);
            }
        }

        public override int SubType
        {
            get
            {
                return 0;
            }
        }


        // Fields
        private BitArrayAccessor mData;
        private DoubleMinMaxArray mDecode;
        private DoubleMinMaxArray mEncode;
        private PDFDoubleArray mSize;
    }
}


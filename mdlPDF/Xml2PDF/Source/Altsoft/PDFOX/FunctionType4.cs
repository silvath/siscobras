namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.IO;
    using System.Reflection;

    public class FunctionType4 : Function
    {
        // Methods
        internal FunctionType4(PDFDirect d) : base(d)
        {
        }

        public static FunctionType4 Create(DoubleMinMax[] domain, DoubleMinMax[] range, string expression)
        {
            int num1;
            int num2;
            double[] numArray1 = new double[(domain.Length * 2)];
            double[] numArray2 = new double[(range.Length * 2)];
            for (num1 = 0; (num1 < numArray1.Length); num1 += 1)
            {
                numArray1[num1] = (((num1 % 2) == 0) ? domain[(num1 / 2)].Min : domain[(num1 / 2)].Max);
            }
            for (num2 = 0; (num2 < numArray2.Length); num2 += 1)
            {
                numArray1[num2] = (((num2 % 2) == 0) ? range[(num2 / 2)].Min : range[(num2 / 2)].Max);
            }
            return FunctionType4.Create(numArray1, numArray2, expression);
        }

        public static FunctionType4 Create(DoubleMinMaxArray domain, DoubleMinMaxArray range, string expression)
        {
            double[] numArray1 = new double[(domain.Count * 2)];
            double[] numArray2 = new double[(range.Count * 2)];
            domain.LinearArray.CopyTo(numArray1, 0);
            range.LinearArray.CopyTo(numArray2, 0);
            return FunctionType4.Create(numArray1, numArray2, expression);
        }

        public static FunctionType4 Create(double[] domain, double[] range, string expression)
        {
            byte[] numArray1 = Encoding.ASCII.GetBytes(expression);
            PDFStream stream1 = Library.CreateStream(numArray1, 0, numArray1.Length, false, null);
            PDFDict dict1 = stream1.Dict;
            dict1["FunctionType"] = Library.CreateInteger(((long) 4));
            dict1["Domain"] = Library.CreateArray(false, domain);
            dict1["Range"] = Library.CreateArray(false, range);
            return new FunctionType4(stream1);
        }


        // Properties
        public override double[] this[double[] args]
        {
            get
            {
                int num1;
                int num2;
                if (args.Length != this.Domain.Count)
                {
                    throw new ArgumentException("Incorrect number of arguments", "args");
                }
                double[] numArray1 = new double[args.Length];
                for (num1 = 0; (num1 < numArray1.Length); num1 += 1)
                {
                    numArray1[num1] = Math.Min(Math.Max(args[num1], this.Domain[num1].Min), this.Domain[num1].Max);
                }
                double[] numArray2 = Type4FunctionCalculator.Calculate(this.PSFunction, numArray1);
                if (numArray2.Length != this.Range.Count)
                {
                    throw new PDFException("Wrong number of output values");
                }
                for (num2 = 0; (num2 < numArray2.Length); num2 += 1)
                {
                    numArray2[num2] = Math.Min(Math.Max(numArray2[num2], this.Range[num2].Min), this.Range[num2].Max);
                }
                return numArray2;
            }
        }

        public string PSFunction
        {
            get
            {
                Stream stream1 = ((PDFStream) this.mDirect).Decode();
                byte[] numArray1 = new byte[((IntPtr) stream1.Length)];
                stream1.Read(numArray1, 0, numArray1.Length);
                return Encoding.ASCII.GetString(numArray1);
            }
            set
            {
                ((PDFStream) this.mDirect).Encode(new MemoryStream(Encoding.ASCII.GetBytes(value)), true);
            }
        }

        public override int SubType
        {
            get
            {
                return 4;
            }
        }

    }
}


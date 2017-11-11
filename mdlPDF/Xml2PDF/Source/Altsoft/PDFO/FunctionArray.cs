namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Reflection;

    public class FunctionArray : Function
    {
        // Methods
        public FunctionArray(PDFArray arr) : base(arr)
        {
            int num1;
            int num2;
            this.Functions = null;
            this.Functions = new Function[arr.Count];
            if (arr.Doc != null)
            {
                for (num1 = 0; (num1 < arr.Count); num1 += 1)
                {
                    this.Functions[num1] = ((Function) arr.Doc.Resources[arr[num1], typeof(Function)]);
                }
                return;
            }
            for (num2 = 0; (num2 < arr.Count); num2 += 1)
            {
                this.Functions[num2] = ((Function) Function.Factory(arr[num2].Direct));
            }
        }


        // Properties
        public override DoubleMinMaxArray Domain
        {
            get
            {
                return null;
            }
            set
            {
                throw new InvalidOperationException("Domain setting is not allowed on array pseudo-function");
            }
        }

        public override double[] this[double[] args]
        {
            get
            {
                int num1;
                double[] numArray1 = new double[this.Functions.Length];
                for (num1 = 0; (num1 < this.Functions.Length); num1 += 1)
                {
                    numArray1[num1] = this.Functions[num1][args][0];
                }
                return numArray1;
            }
        }

        public override DoubleMinMaxArray Range
        {
            get
            {
                return null;
            }
            set
            {
                throw new InvalidOperationException("Range setting is not allowed on array pseudo-function");
            }
        }

        public override int SubType
        {
            get
            {
                return -1;
            }
        }


        // Fields
        public Function[] Functions;
    }
}


namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Reflection;

    internal class PDFDoubleArray : DoubleArray
    {
        // Methods
        internal PDFDoubleArray(PDFArray arr) : base(arr.Count)
        {
            int num2;
            int num3;
            this.mPDFArr = null;
            this.mPDFFix = null;
            this.mParent = null;
            this.mKeyName = null;
            this.mAsFixed = false;
            this.mPDFArr = arr;
            int num1 = arr.Count;
            if (arr.Count != num1)
            {
                arr.Clear();
                for (num2 = 0; (num2 < num1); num2 += 1)
                {
                    arr.Add(Library.CreateFixed(0f));
                }
            }
            for (num3 = 0; (num3 < num1); num3 += 1)
            {
                this.mArr[num3] = ((PDFNumeric) arr[num3]).DoubleValue;
            }
        }

        internal PDFDoubleArray(PDFFixed val) : base(1)
        {
            this.mPDFArr = null;
            this.mPDFFix = null;
            this.mParent = null;
            this.mKeyName = null;
            this.mAsFixed = false;
            this.mAsFixed = true;
            this.mPDFFix = val;
            this.mArr[0] = val.Value;
        }

        internal PDFDoubleArray(PDFArray arr, int size) : base(size)
        {
            int num1;
            this.mPDFArr = null;
            this.mPDFFix = null;
            this.mParent = null;
            this.mKeyName = null;
            this.mAsFixed = false;
            this.mAsFixed = false;
            this.mPDFArr = arr;
            if (arr.Count != size)
            {
                throw new ArgumentException(string.Format("Array should consist of {0} items", size));
            }
            for (num1 = 0; (num1 < size); num1 += 1)
            {
                this.mArr[num1] = ((PDFNumeric) arr[num1]).DoubleValue;
            }
        }

        internal PDFDoubleArray(PDFDict parent, string keyName, bool asFixed, params double[] def) : base(def.Length)
        {
            int num1;
            this.mPDFArr = null;
            this.mPDFFix = null;
            this.mParent = null;
            this.mKeyName = null;
            this.mAsFixed = false;
            if (asFixed && (def.Length != 1))
            {
                throw new ArgumentException("if \'asFixed\' is true default value should consist of 1 item");
            }
            this.mParent = parent;
            this.mKeyName = keyName;
            this.mAsFixed = asFixed;
            try
            {
                if (asFixed)
                {
                    this.mPDFFix = ((PDFFixed) this.mParent[this.mKeyName]);
                    if (this.mPDFFix == null)
                    {
                        goto Label_012D;
                    }
                    this.mArr[0] = this.mPDFFix.Value;
                    return;
                }
                this.mPDFArr = ((PDFArray) this.mParent[this.mKeyName]);
                if (this.mPDFArr != null)
                {
                    this.mArr = new double[this.mPDFArr.Count];
                    for (num1 = 0; (num1 < this.mPDFArr.Count); num1 += 1)
                    {
                        this.mArr[num1] = ((PDFNumeric) this.mPDFArr[num1]).DoubleValue;
                    }
                    return;
                }
            }
            catch (InvalidCastException)
            {
                throw new PDFSyntaxException(parent, string.Format("{0} expected at key {1}", (asFixed ? "Array of double" : "Double value"), keyName));
            }
        Label_012D:
            def.CopyTo(this.mArr, 0);
        }


        // Properties
        public override double this[int index]
        {
            get
            {
                return this.mArr[index];
            }
            set
            {
                int num1;
                PDFArray array1;
                PDFFixed fixed1;
                base[index] = value;
                if (!this.mAsFixed)
                {
                    if (this.mPDFArr == null)
                    {
                        array1 = Library.CreateArray(this.mArr.Length);
                        this.mPDFArr = array1;
                        this.mParent[this.mKeyName] = array1;
                        for (num1 = 0; (num1 < this.mArr.Length); num1 += 1)
                        {
                            this.mPDFArr[num1] = Library.CreateFixed(this.mArr[num1]);
                        }
                        return;
                    }
                    this.mPDFArr[index] = Library.CreateFixed(value);
                    return;
                }
                if (index > 0)
                {
                    throw new IndexOutOfRangeException();
                }
                if (this.mPDFFix == null)
                {
                    fixed1 = Library.CreateFixed(value);
                    this.mPDFFix = fixed1;
                    this.mParent[this.mKeyName] = fixed1;
                    return;
                }
                this.mPDFFix.Value = value;
            }
        }


        // Fields
        private bool mAsFixed;
        private string mKeyName;
        private PDFDict mParent;
        private PDFArray mPDFArr;
        private PDFFixed mPDFFix;
    }
}


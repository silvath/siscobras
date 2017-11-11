namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Reflection;

    public class PDFInt64Array : Int64Array
    {
        // Methods
        internal PDFInt64Array(PDFArray arr) : base(arr.Count)
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
                this.mArr[num3] = ((PDFInteger) arr[num3]).Value;
            }
        }

        internal PDFInt64Array(PDFInteger val) : base(1)
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

        internal PDFInt64Array(PDFArray arr, int size) : base(size)
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
                this.mArr[num1] = ((PDFInteger) arr[num1]).Value;
            }
        }

        internal PDFInt64Array(PDFDict parent, string keyName, bool asFixed, params long[] def) : base(def.Length)
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
                    this.mPDFFix = ((PDFInteger) this.mParent[this.mKeyName]);
                    if (this.mPDFFix == null)
                    {
                        goto Label_0114;
                    }
                    this.mArr[0] = this.mPDFFix.Value;
                    return;
                }
                this.mPDFArr = ((PDFArray) this.mParent[this.mKeyName]);
                if (this.mPDFArr != null)
                {
                    for (num1 = 0; (num1 < this.mPDFArr.Count); num1 += 1)
                    {
                        this.mArr[num1] = ((PDFInteger) this.mPDFArr[num1]).Int64Value;
                    }
                    return;
                }
            }
            catch (InvalidCastException)
            {
                throw new PDFSyntaxException(parent, string.Format("{0} expected at key {1}", (asFixed ? "Array of long" : "Int64 value"), keyName));
            }
        Label_0114:
            def.CopyTo(this.mArr, 0);
        }


        // Properties
        public override long this[int index]
        {
            get
            {
                return this.mArr[index];
            }
            set
            {
                int num1;
                PDFArray array1;
                PDFInteger integer1;
                base[index] = value;
                if (this.mAsFixed)
                {
                    if (this.mPDFArr == null)
                    {
                        array1 = Library.CreateArray(this.mArr.Length);
                        this.mPDFArr = array1;
                        this.mParent[this.mKeyName] = array1;
                        for (num1 = 0; (num1 < this.mArr.Length); num1 += 1)
                        {
                            this.mPDFArr[num1] = Library.CreateFixed(((double) this.mArr[num1]));
                        }
                        return;
                    }
                    ((PDFInteger) this.mPDFArr[index]).Value = value;
                    return;
                }
                if (index > 0)
                {
                    throw new IndexOutOfRangeException();
                }
                if (this.mPDFFix == null)
                {
                    integer1 = Library.CreateInteger(value);
                    this.mPDFFix = integer1;
                    this.mParent[this.mKeyName] = integer1;
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
        private PDFInteger mPDFFix;
    }
}


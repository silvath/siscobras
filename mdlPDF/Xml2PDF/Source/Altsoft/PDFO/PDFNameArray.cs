namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Reflection;

    internal class PDFNameArray : StringArray
    {
        // Methods
        internal PDFNameArray(PDFArray arr) : base(arr.Count)
        {
            int num2;
            int num3;
            this.mPDFArr = null;
            this.mPDFFix = null;
            this.mParent = null;
            this.mKeyName = null;
            this.mAsName = false;
            this.mPDFArr = arr;
            int num1 = arr.Count;
            if (arr.Count != num1)
            {
                arr.Clear();
                for (num2 = 0; (num2 < num1); num2 += 1)
                {
                    arr.Add(Library.CreateName(""));
                }
            }
            for (num3 = 0; (num3 < num1); num3 += 1)
            {
                this.mArr[num3] = ((PDFName) arr[num3]).Value;
            }
        }

        internal PDFNameArray(PDFName val) : base(1)
        {
            this.mPDFArr = null;
            this.mPDFFix = null;
            this.mParent = null;
            this.mKeyName = null;
            this.mAsName = false;
            this.mAsName = true;
            this.mPDFFix = val;
            this.mArr[0] = val.Value;
        }

        internal PDFNameArray(PDFArray arr, int size) : base(size)
        {
            int num1;
            this.mPDFArr = null;
            this.mPDFFix = null;
            this.mParent = null;
            this.mKeyName = null;
            this.mAsName = false;
            this.mAsName = false;
            this.mPDFArr = arr;
            if (arr.Count != size)
            {
                throw new ArgumentException(string.Format("Array should consist of {0} items", size));
            }
            for (num1 = 0; (num1 < size); num1 += 1)
            {
                this.mArr[num1] = ((PDFName) arr[num1]).Value;
            }
        }

        internal PDFNameArray(PDFDict parent, string keyName, bool asName, params string[] def) : base(def.Length)
        {
            int num1;
            this.mPDFArr = null;
            this.mPDFFix = null;
            this.mParent = null;
            this.mKeyName = null;
            this.mAsName = false;
            if (asName && (def.Length != 1))
            {
                throw new ArgumentException("if \'asName\' is true default value should consist of 1 item");
            }
            this.mParent = parent;
            this.mKeyName = keyName;
            this.mAsName = asName;
            try
            {
                if (asName)
                {
                    this.mPDFFix = ((PDFName) this.mParent[this.mKeyName]);
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
                        this.mArr[num1] = ((PDFName) this.mPDFArr[num1]).Value;
                    }
                    return;
                }
            }
            catch (InvalidCastException)
            {
                throw new PDFSyntaxException(parent, string.Format("{0} expected at key {1}", (asName ? "Array of string" : "Name value"), keyName));
            }
        Label_0114:
            def.CopyTo(this.mArr, 0);
        }


        // Properties
        public override string this[int index]
        {
            get
            {
                return this.mArr[index];
            }
            set
            {
                int num1;
                PDFArray array1;
                PDFName name1;
                base[index] = value;
                if (this.mAsName)
                {
                    if (this.mPDFArr == null)
                    {
                        array1 = Library.CreateArray(this.mArr.Length);
                        this.mPDFArr = array1;
                        this.mParent[this.mKeyName] = array1;
                        for (num1 = 0; (num1 < this.mArr.Length); num1 += 1)
                        {
                            this.mPDFArr[num1] = Library.CreateName(this.mArr[num1]);
                        }
                        return;
                    }
                    ((PDFName) this.mPDFArr[index]).Value = value;
                    return;
                }
                if (index > 0)
                {
                    throw new IndexOutOfRangeException();
                }
                if (this.mPDFFix == null)
                {
                    name1 = Library.CreateName(value);
                    this.mPDFFix = name1;
                    this.mParent[this.mKeyName] = name1;
                    return;
                }
                this.mPDFFix.Value = value;
            }
        }


        // Fields
        private bool mAsName;
        private string mKeyName;
        private PDFDict mParent;
        private PDFArray mPDFArr;
        private PDFName mPDFFix;
    }
}


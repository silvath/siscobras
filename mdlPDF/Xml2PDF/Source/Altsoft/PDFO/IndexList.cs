namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class IndexList : Resource
    {
        // Methods
        public IndexList(PDFArray arr) : base(arr)
        {
            this.mArr = arr;
        }

        public void Add(int value)
        {
            int num1;
            if (this.Count == 0)
            {
                this.mArr.Add(Library.CreateInteger(((long) value)));
                return;
            }
            for (num1 = 0; (num1 < this.Count); num1 += 1)
            {
                if (value < (this.mArr[num1] as PDFInteger).Int32Value)
                {
                    this.mArr.Insert(num1, Library.CreateInteger(((long) value)));
                }
            }
        }

        public static IndexList Create(int[] list)
        {
            int num1;
            PDFArray array1 = Library.CreateArray(0);
            for (num1 = 0; (num1 < list.Length); num1 += 1)
            {
                array1.Add(Library.CreateInteger(((long) list[num1])));
            }
            return new IndexList(array1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new IndexList((direct as PDFArray));
        }

        public void Remove(int value)
        {
            int num1;
            for (num1 = 0; (num1 < this.Count); num1 += 1)
            {
                if ((this.mArr[num1] as PDFInteger).Int32Value == value)
                {
                    this.mArr.RemoveAt(num1);
                }
            }
        }

        public void RemoveAt(int index)
        {
            this.mArr.RemoveAt(index);
        }


        // Properties
        public int Count
        {
            get
            {
                return this.mArr.Count;
            }
        }

        public int this[int index]
        {
            get
            {
                return (this.mArr[index] as PDFInteger).Int32Value;
            }
        }


        // Fields
        private PDFArray mArr;
    }
}


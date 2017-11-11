namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class quadrilateralList : ComplexObjectCommonArrayBase
    {
        // Methods
        public quadrilateralList(PDFDirect direct) : base(direct, 8)
        {
        }

        public void Add(quadrilateral value)
        {
            base._Add(value);
        }

        internal override object ComplexObjectFactory(PDFDirect direct)
        {
            return Resources.Get(direct, typeof(quadrilateral));
        }

        public static quadrilateralList Create(double[] arr)
        {
            int num1;
            PDFArray array1 = Library.CreateArray(arr.Length);
            for (num1 = 0; (num1 < arr.Length); num1 += 1)
            {
                array1[num1] = Library.CreateFixed(arr[num1]);
            }
            return new quadrilateralList(array1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new quadrilateralList(direct);
        }

        public void Remove(quadrilateral value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public quadrilateral this[int index]
        {
            get
            {
                return (Resources.Get(this.mInternalArr[index], typeof(quadrilateral)) as quadrilateral);
            }
            set
            {
                this.mInternalArr[index] = value.Direct;
            }
        }

    }
}


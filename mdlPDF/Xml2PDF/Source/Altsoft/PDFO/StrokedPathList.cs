namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class StrokedPathList : ComplexObjectArrayDirect
    {
        // Methods
        public StrokedPathList(PDFDirect direct) : base(direct, false)
        {
        }

        public void Add(PointList value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect direct)
        {
            return Resources.Get(direct, typeof(PointList));
        }

        public static StrokedPathList Create(double[] arr)
        {
            int num1;
            PDFArray array1 = Library.CreateArray(1);
            array1[0] = Library.CreateArray(arr.Length);
            for (num1 = 0; (num1 < arr.Length); num1 += 1)
            {
                (array1[0] as PDFArray)[num1] = Library.CreateFixed(arr[num1]);
            }
            return new StrokedPathList(array1);
        }

        public void Remove(PointList value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public PointList this[int index]
        {
            get
            {
                return (base._GetObject(index) as PointList);
            }
            set
            {
                base._SetObject(index, value, value.Direct);
            }
        }

    }
}


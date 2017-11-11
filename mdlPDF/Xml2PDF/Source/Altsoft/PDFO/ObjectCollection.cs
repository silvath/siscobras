namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class ObjectCollection : ComplexObjectArrayDirect
    {
        // Methods
        public ObjectCollection(PDFDirect direct) : base(direct, false)
        {
            this.mArr = Library.CreateArray(0);
        }

        public void Add(object value)
        {
            this[base.Count] = value;
        }

        private static void AddResource(ref PDFArray arr, DocResourceSet res)
        {
            foreach (Resource resource1 in res)
            {
                arr.Add(resource1.Direct);
                if (resource1.Dict["OPI"] != null)
                {
                    arr.Add(resource1.Dict["OPI"].Direct);
                }
                if (resource1.Resources == null)
                {
                    continue;
                }
                ObjectCollection.AddResource(arr, resource1.Resources);
            }
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(object));
        }

        public static ObjectCollection Create(Page page)
        {
            PDFArray array1 = Library.CreateArray(0);
            foreach (PDFStream stream1 in page.Contents)
            {
                array1.Add(stream1.Direct);
            }
            ObjectCollection.AddResource(ref array1, page.Resources);
            return new ObjectCollection(array1);
        }

        public void Remove(object value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public object this[int index]
        {
            get
            {
                return base._GetObject(index);
            }
            set
            {
                base._SetObject(index, value, (value as PDFObject).Direct);
            }
        }


        // Fields
        private PDFArray mArr;
    }
}


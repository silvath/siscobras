namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Collections;
    using System.Reflection;

    public class AlternateImageColl : ICollection, IEnumerable
    {
        // Methods
        internal AlternateImageColl(XObjectImage x)
        {
            this.mParent = x;
        }

        public void Add(XObjectImage img)
        {
            PDFArray array1 = (this.mParent.Dict["Alternates"] as PDFArray);
            if (array1 == null)
            {
                array1 = Library.CreateArray(0);
                this.mParent.Dict["Alternates"] = array1;
            }
            array1.Add(img.Direct);
        }

        public void CopyTo(Array array, int index)
        {
            int num1 = index;
            foreach (object obj1 in this)
            {
                int num2 = num1;
                num1 = (num2 + 1);
                array.SetValue(obj1, num1);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new CollectionEnumerator(this);
        }


        // Properties
        public int Count
        {
            get
            {
                PDFArray array1 = (this.mParent.Dict["Alternates"] as PDFArray);
                if (array1 == null)
                {
                    return 0;
                }
                return array1.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return true;
            }
        }

        public XObjectImage this[int index]
        {
            get
            {
                PDFArray array1 = (this.mParent.Dict["Alternates"] as PDFArray);
                if (array1 == null)
                {
                    throw new IndexOutOfRangeException("Alternate image dictionary is absent");
                }
                return ((XObjectImage) array1.Doc.Resources[array1[index], typeof(XObjectImage)]);
            }
            set
            {
                PDFArray array1 = (this.mParent.Dict["Alternates"] as PDFArray);
                if (array1 == null)
                {
                    array1 = Library.CreateArray(1);
                    this.mParent.Dict["Alternates"] = array1;
                }
                array1[index] = value.Direct;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this;
            }
        }


        // Fields
        private XObjectImage mParent;
    }
}


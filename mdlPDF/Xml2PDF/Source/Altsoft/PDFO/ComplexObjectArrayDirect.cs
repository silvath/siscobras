namespace Altsoft.PDFO
{
    using System;
    using System.Collections;

    public abstract class ComplexObjectArrayDirect : ICollection, IEnumerable
    {
        // Methods
        internal ComplexObjectArrayDirect(PDFDirect direct, bool allowSingleValue)
        {
            this.mObjectList = new ArrayList();
            this.mDirect = direct;
            this.mAllowSingleValue = allowSingleValue;
        }

        internal object _GetObject(int index)
        {
            DictionaryEntry entry2;
            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index in collection is out of range");
            }
            object obj1 = null;
            if (this.mDirect == null)
            {
                if (this.mAllowSingleValue)
                {
                    obj1 = ((object) this.mDirect);
                }
                return null;
            }
            obj1 = ((object) (this.mDirect as PDFArray)[index]);
            foreach (DictionaryEntry entry1 in this.mObjectList)
            {
                if (entry1.Key != obj1)
                {
                    continue;
                }
                return entry1.Value;
            }
            entry2 = new DictionaryEntry(obj1, this.ComplexObjectFactory(((PDFDirect) obj1)));
            if (entry2.Value != null)
            {
                this.mObjectList.Add(entry2);
            }
            return entry2.Value;
        }

        protected void _Remove(object obj)
        {
            foreach (DictionaryEntry entry1 in this.mObjectList)
            {
                if (obj != entry1.Value)
                {
                    continue;
                }
                this.mObjectList.Remove(entry1);
                if (!(this.mDirect is PDFArray))
                {
                    return;
                }
                (this.mDirect as PDFArray).Remove(((PDFObject) entry1.Key));
            }
        }

        protected void _RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            PDFArray array1 = (this.mDirect as PDFArray);
            if (array1 != null)
            {
                array1.RemoveAt(index);
            }
        }

        internal void _SetObject(int index, object value, PDFObject valueDict)
        {
            if (index > this.Count)
            {
                throw new IndexOutOfRangeException("Index in collection is out of range");
            }
            PDFArray array1 = (this.mDirect as PDFArray);
            if (array1 == null)
            {
                array1 = Library.CreateArray(1);
                if (this.mDirect != null)
                {
                    array1[0] = this.mDirect;
                }
            }
            (this.mDirect as PDFArray)[index] = valueDict;
            this.mObjectList.Add(new DictionaryEntry(valueDict.Direct, value));
        }

        internal abstract object ComplexObjectFactory(PDFDirect dir);

        public void CopyTo(Array arr, int offset)
        {
        }

        public IEnumerator GetEnumerator()
        {
            return new ComplexObjectArrayDirectEnumerator(this);
        }


        // Properties
        public int Count
        {
            get
            {
                if (this.mDirect == null)
                {
                    if (this.mAllowSingleValue)
                    {
                        return 1;
                    }
                    return 0;
                }
                return (this.mDirect as PDFArray).Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return true;
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
        internal bool mAllowSingleValue;
        internal PDFDirect mDirect;
        internal ArrayList mObjectList;

        // Nested Types
        private class ComplexObjectArrayDirectEnumerator : IEnumerator
        {
            // Methods
            internal ComplexObjectArrayDirectEnumerator(ComplexObjectArrayDirect coll)
            {
                this.mColl = coll;
            }

            public bool MoveNext()
            {
                int num1 = (this.mCurr + 1);
                this.mCurr = num1;
                if (num1 >= this.mColl.Count)
                {
                    return false;
                }
                return true;
            }

            public void Reset()
            {
                this.mCurr = 0;
            }


            // Properties
            public object Current
            {
                get
                {
                    return this.mColl._GetObject(this.mCurr);
                }
            }


            // Fields
            private ComplexObjectArrayDirect mColl;
            private int mCurr;
        }
    }
}


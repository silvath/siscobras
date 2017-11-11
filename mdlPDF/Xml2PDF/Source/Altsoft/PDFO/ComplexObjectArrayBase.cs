namespace Altsoft.PDFO
{
    using System;
    using System.Collections;

    public abstract class ComplexObjectArrayBase : ICollection, IEnumerable
    {
        // Methods
        internal ComplexObjectArrayBase(PDFDict baseDict, string keyName, bool allowSingleValue)
        {
            this.mObjectList = new ArrayList();
            this.mBaseDict = baseDict;
            this.mBaseKeyName = keyName;
            this.mAllowSingleValue = allowSingleValue;
        }

        internal object _GetObject(int index)
        {
            DictionaryEntry entry2;
            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index in collection is out of range");
            }
            PDFObject obj1 = this.mBaseDict[this.mBaseKeyName];
            PDFArray array1 = (obj1 as PDFArray);
            object obj2 = null;
            if (array1 == null)
            {
                if (this.mAllowSingleValue)
                {
                    obj2 = ((object) obj1);
                }
                return null;
            }
            obj2 = ((object) array1[index]);
            foreach (DictionaryEntry entry1 in this.mObjectList)
            {
                if (entry1.Key != obj2)
                {
                    continue;
                }
                return entry1.Value;
            }
            entry2 = new DictionaryEntry(obj2, this.ComplexObjectFactory(((PDFDirect) obj2)));
            if (entry2.Value != null)
            {
                this.mObjectList.Add(entry2);
            }
            return entry2.Value;
        }

        protected void _Remove(object obj)
        {
            PDFObject obj1 = this.mBaseDict[this.mBaseKeyName];
            PDFArray array1 = (obj1 as PDFArray);
            if ((array1 == null) && (obj1 != null))
            {
                this.mBaseDict.Remove(this.mBaseKeyName);
            }
            foreach (DictionaryEntry entry1 in this.mObjectList)
            {
                if (obj != entry1.Value)
                {
                    continue;
                }
                this.mObjectList.Remove(entry1);
                if (array1 == null)
                {
                    return;
                }
                array1.Remove(((PDFObject) entry1.Key));
            }
        }

        protected void _RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            PDFObject obj1 = this.mBaseDict[this.mBaseKeyName];
            PDFArray array1 = (obj1 as PDFArray);
            if (array1 != null)
            {
                array1.RemoveAt(index);
                return;
            }
            this.mBaseDict.Remove(this.mBaseKeyName);
        }

        internal void _SetObject(int index, object value, PDFObject valueDict)
        {
            if (index > this.Count)
            {
                throw new IndexOutOfRangeException("Index in collection is out of range");
            }
            PDFObject obj1 = this.mBaseDict[this.mBaseKeyName];
            PDFArray array1 = (obj1 as PDFArray);
            if (array1 == null)
            {
                array1 = Library.CreateArray(1);
                this.mBaseDict[this.mBaseKeyName] = array1;
                if (obj1 != null)
                {
                    array1[0] = obj1;
                }
            }
            array1[index] = valueDict;
            this.mObjectList.Add(new DictionaryEntry(valueDict.Direct, value));
        }

        internal abstract object ComplexObjectFactory(PDFDirect dir);

        public void CopyTo(Array arr, int offset)
        {
        }

        public IEnumerator GetEnumerator()
        {
            return new ComplexObjectArrayBaseEnumerator(this);
        }


        // Properties
        public int Count
        {
            get
            {
                if (this.mBaseDict == null)
                {
                    return 0;
                }
                PDFObject obj1 = this.mBaseDict[this.mBaseKeyName];
                if (obj1 == null)
                {
                    return 0;
                }
                PDFArray array1 = (obj1 as PDFArray);
                if (array1 == null)
                {
                    if (this.mAllowSingleValue)
                    {
                        return 1;
                    }
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

        public object SyncRoot
        {
            get
            {
                return this;
            }
        }


        // Fields
        internal bool mAllowSingleValue;
        internal PDFDict mBaseDict;
        internal string mBaseKeyName;
        internal ArrayList mObjectList;

        // Nested Types
        private class ComplexObjectArrayBaseEnumerator : IEnumerator
        {
            // Methods
            internal ComplexObjectArrayBaseEnumerator(ComplexObjectArrayBase coll)
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
            private ComplexObjectArrayBase mColl;
            private int mCurr;
        }
    }
}


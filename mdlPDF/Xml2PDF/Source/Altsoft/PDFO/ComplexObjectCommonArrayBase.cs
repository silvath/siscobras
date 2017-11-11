namespace Altsoft.PDFO
{
    using System;
    using System.Collections;

    public abstract class ComplexObjectCommonArrayBase : Resource, ICollection, IEnumerable
    {
        // Methods
        internal ComplexObjectCommonArrayBase(PDFDirect direct, int ObjSize) : base(direct)
        {
            int num1;
            int num2;
            this.mIndexSkip = 0;
            this.mObjSize = 1;
            this.mObjectList = new ArrayList();
            this.mArr = null;
            this.mInternalArr = Library.CreateArray(0);
            this.mArr = (direct as PDFArray);
            this.mObjSize = ObjSize;
            if (this.mArr == null)
            {
                return;
            }
            for (num1 = this.mIndexSkip; (num1 < (this.mArr.Count / this.mObjSize)); num1 += 1)
            {
                this.mInternalArr[num1] = Library.CreateArray(this.mObjSize);
                for (num2 = 0; (num2 < this.mObjSize); num2 += 1)
                {
                    (this.mInternalArr[num1] as PDFArray)[num2] = this.mArr[((num1 * this.mObjSize) + num2)];
                }
            }
        }

        internal ComplexObjectCommonArrayBase(PDFDirect direct, int ObjSize, int IndexSkip) : base(direct)
        {
            int num1;
            int num2;
            this.mIndexSkip = 0;
            this.mObjSize = 1;
            this.mObjectList = new ArrayList();
            this.mArr = null;
            this.mInternalArr = Library.CreateArray(0);
            this.mArr = (direct as PDFArray);
            this.mObjSize = ObjSize;
            this.mIndexSkip = IndexSkip;
            if (this.mArr == null)
            {
                return;
            }
            for (num1 = this.mIndexSkip; (num1 < (this.mArr.Count / this.mObjSize)); num1 += 1)
            {
                this.mInternalArr[num1] = Library.CreateArray(this.mObjSize);
                for (num2 = 0; (num2 < this.mObjSize); num2 += 1)
                {
                    (this.mInternalArr[num1] as PDFArray)[num2] = this.mArr[((num1 * this.mObjSize) + num2)].Indirect;
                }
            }
        }

        protected void _Add(object obj)
        {
            int num1;
            if (obj == null)
            {
                return;
            }
            this.mObjectList.Add(new DictionaryEntry((obj as PDFObject).Direct, obj));
            this.mInternalArr.Add((obj as PDFObject).Direct);
            for (num1 = 0; (num1 < this.mObjSize); num1 += 1)
            {
                this.mArr.Add((this.mInternalArr[(this.Count - 1)] as PDFArray)[num1]);
                (this.mInternalArr[(this.Count - 1)] as PDFArray)[num1] = this.mArr[(this.mArr.Count - 1)].Indirect;
            }
        }

        internal object _GetObject(int index)
        {
            DictionaryEntry entry2;
            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index in collection is out of range");
            }
            object obj1 = ((object) this.mInternalArr[index]);
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
            int num1;
            foreach (DictionaryEntry entry1 in this.mObjectList)
            {
                if (obj != entry1.Value)
                {
                    continue;
                }
                this.mObjectList.Remove(entry1);
                for (num1 = 0; (num1 < this.Count); num1 += 1)
                {
                    if (this.mInternalArr[num1] == ((PDFObject) entry1.Key))
                    {
                        this._RemoveAt(num1);
                    }
                }
            }
        }

        protected void _RemoveAt(int index)
        {
            int num1;
            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            this.mInternalArr.RemoveAt(index);
            for (num1 = 0; (num1 < this.mObjSize); num1 += 1)
            {
                this.mArr.RemoveAt((index * this.mObjSize));
            }
        }

        internal void _SetObject(int index, object value, PDFObject valueDict)
        {
            if (index > this.Count)
            {
                throw new IndexOutOfRangeException("Index in collection is out of range");
            }
            this.mInternalArr[index] = valueDict;
            this.mObjectList.Add(new DictionaryEntry(valueDict.Direct, value));
        }

        internal abstract object ComplexObjectFactory(PDFDirect dir);

        public void CopyTo(Array arr, int offset)
        {
        }

        public IEnumerator GetEnumerator()
        {
            return new ComplexObjectCommonArrayBaseEnumerator(this);
        }


        // Properties
        public int Count
        {
            get
            {
                return this.mInternalArr.Count;
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
        protected PDFArray mArr;
        private int mIndexSkip;
        internal PDFArray mInternalArr;
        internal ArrayList mObjectList;
        private int mObjSize;

        // Nested Types
        private class ComplexObjectCommonArrayBaseEnumerator : IEnumerator
        {
            // Methods
            internal ComplexObjectCommonArrayBaseEnumerator(ComplexObjectCommonArrayBase coll)
            {
                this.mCurr = 0;
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
            private ComplexObjectCommonArrayBase mColl;
            private int mCurr;
        }
    }
}


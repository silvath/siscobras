namespace Altsoft.PDFO
{
    using System;
    using System.Collections;

    public abstract class ComplexObjectDictBase : ICollection, IEnumerable
    {
        // Methods
        internal ComplexObjectDictBase(PDFDict baseDict, string keyName)
        {
            this.mObjectList = new ArrayList();
            this.mBaseDict = baseDict;
            this.mBaseKeyName = keyName;
        }

        internal object _GetObject(string index)
        {
            DictionaryEntry entry2;
            PDFObject obj1 = this.mBaseDict[this.mBaseKeyName];
            PDFDict dict1 = (obj1 as PDFDict);
            object obj2 = null;
            if (dict1 == null)
            {
                return null;
            }
            obj2 = ((object) dict1[index]);
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
            PDFDict dict1 = (this.mBaseDict[this.mBaseKeyName] as PDFDict);
            if (dict1 == null)
            {
                return;
            }
            foreach (DictionaryEntry entry1 in this.mObjectList)
            {
                if (obj != entry1.Value)
                {
                    continue;
                }
                this.mObjectList.Remove(entry1);
                if (dict1 == null)
                {
                    return;
                }
                foreach (DictionaryEntry entry2 in dict1)
                {
                    if (((PDFObject) entry2.Value).UniqueID != ((PDFObject) entry1.Key).UniqueID)
                    {
                        continue;
                    }
                    dict1.Remove(((PDFName) entry2.Key));
                }
            }
        }

        protected void _RemoveAt(string index)
        {
            PDFDict dict1 = (this.mBaseDict[this.mBaseKeyName] as PDFDict);
            if (dict1 != null)
            {
                dict1.Remove(index);
            }
        }

        internal void _SetObject(string index, object value, PDFObject valueDict)
        {
            PDFDict dict1 = (this.mBaseDict[this.mBaseKeyName] as PDFDict);
            if (dict1 == null)
            {
                dict1 = Library.CreateDict();
                this.mBaseDict[this.mBaseKeyName] = dict1;
            }
            dict1[index] = valueDict;
            this.mObjectList.Add(new DictionaryEntry(valueDict.Direct, value));
        }

        internal abstract object ComplexObjectFactory(PDFDirect dir);

        public void CopyTo(Array arr, int offset)
        {
        }

        public IEnumerator GetEnumerator()
        {
            return new ComplexObjectDictBaseEnumerator(this);
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
                PDFDict dict1 = (this.mBaseDict[this.mBaseKeyName] as PDFDict);
                if (dict1 == null)
                {
                    return 0;
                }
                return dict1.Count;
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
        internal PDFDict mBaseDict;
        internal string mBaseKeyName;
        internal ArrayList mObjectList;

        // Nested Types
        private class ComplexObjectDictBaseEnumerator : IEnumerator
        {
            // Methods
            internal ComplexObjectDictBaseEnumerator(ComplexObjectDictBase coll)
            {
                this.mColl = coll;
                PDFDict dict1 = (coll.mBaseDict[coll.mBaseKeyName] as PDFDict);
                if (dict1 != null)
                {
                    this.mCurr = dict1.Keys.GetEnumerator();
                    return;
                }
                this.mCurr = null;
            }

            public bool MoveNext()
            {
                if (this.mCurr == null)
                {
                    return false;
                }
                return this.mCurr.MoveNext();
            }

            public void Reset()
            {
                if (this.mCurr != null)
                {
                    this.mCurr.Reset();
                }
            }


            // Properties
            public object Current
            {
                get
                {
                    return this.mColl._GetObject(((PDFName) this.mCurr.Current).Value);
                }
            }


            // Fields
            private ComplexObjectDictBase mColl;
            private IEnumerator mCurr;
        }
    }
}


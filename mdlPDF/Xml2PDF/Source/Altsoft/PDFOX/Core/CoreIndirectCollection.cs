namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;
    using System.Collections;
    using System.Reflection;

    public class CoreIndirectCollection : IndirectCollection, ICollection, IEnumerable
    {
        // Methods
        internal CoreIndirectCollection(CoreDocument doc)
        {
            this.mDoc = doc;
        }

        public void CopyTo(Array array, int index)
        {
            int num1;
            for (num1 = 0; (num1 < this.Count); num1 += 1)
            {
                array.SetValue(this[num1], (index + num1));
            }
        }

        public void Delete(int id)
        {
            XRefEntry entry1;
            XRefEntry entry2;
            try
            {
                entry1 = ((XRefEntry) this.mDoc.mXRef[id]);
                entry2 = ((XRefEntry) this.mDoc.mXRef[0]);
                entry1.type = 0;
                XRefEntry entry3 = entry1;
                entry1.generation = (entry3.generation + 1);
                entry1.dirty = true;
                entry1.offset = entry2.offset;
                entry2.offset = ((long) id);
                entry2.dirty = true;
                this.mCount -= 1;
            }
            catch (IndexOutOfRangeException)
            {
                throw new PDFException("Invalid indirect ID");
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new XRefEnumerator(this.mDoc);
        }

        internal PDFIndirect Insert(CorePDFIndirect ind)
        {
            int num1;
            XRefEntry entry2;
            PDFIndirect indirect1;
            XRefEntry entry1 = ((XRefEntry) this.mDoc.mXRef[0]);
            for (num1 = ((int) entry1.offset); (num1 != 0); num1 = ((int) entry1.offset))
            {
                entry1 = ((XRefEntry) this.mDoc.mXRef[num1]);
                entry2 = ((XRefEntry) this.mDoc.mXRef[num1]);
                entry1.offset = entry2.offset;
                if (entry2.generation < 65535)
                {
                    entry2.dirty = true;
                    entry2.type = 1;
                    XRefEntry entry3 = entry2;
                    entry2.generation = (entry3.generation + 1);
                    ((XRefEntry) this.mDoc.mXRef[0]).offset = entry2.offset;
                    ind.mId = num1;
                    indirect1 = ind;
                    entry2.indirect = indirect1;
                    return indirect1;
                }
            }
            entry1 = new XRefEntry();
            entry1.dirty = true;
            entry1.type = 1;
            entry1.generation = 0;
            entry1.offset = ((long) -1);
            this.mDoc.mXRef.Add(entry1);
            ind.mId = (this.mDoc.mXRef.Count - 1);
            entry1.indirect = ind;
            if (this.mDoc.mToSaveQueue != null)
            {
                this.mDoc.mToSaveQueue.Enqueue(entry1.indirect);
            }
            this.mCount += 1;
            return entry1.indirect;
        }

        public PDFIndirect New()
        {
            int num1;
            XRefEntry entry2;
            PDFIndirect indirect1;
            XRefEntry entry1 = ((XRefEntry) this.mDoc.mXRef[0]);
            for (num1 = ((int) entry1.offset); (num1 != 0); num1 = ((int) entry1.offset))
            {
                entry1 = ((XRefEntry) this.mDoc.mXRef[num1]);
                entry2 = ((XRefEntry) this.mDoc.mXRef[num1]);
                entry1.offset = entry2.offset;
                if (entry2.generation < 65535)
                {
                    entry2.dirty = true;
                    entry2.type = 1;
                    XRefEntry entry3 = entry2;
                    entry2.generation = (entry3.generation + 1);
                    ((XRefEntry) this.mDoc.mXRef[0]).offset = entry2.offset;
                    entry2.offset = ((long) -1);
                    indirect1 = new CorePDFIndirect(this.mDoc, num1);
                    entry2.indirect = indirect1;
                    return indirect1;
                }
            }
            entry1 = new XRefEntry();
            entry1.dirty = true;
            entry1.type = 1;
            entry1.generation = 0;
            entry1.offset = ((long) -1);
            this.mDoc.mXRef.Add(entry1);
            entry1.indirect = new CorePDFIndirect(this.mDoc, (this.mDoc.mXRef.Count - 1));
            if (this.mDoc.mToSaveQueue != null)
            {
                this.mDoc.mToSaveQueue.Enqueue(entry1.indirect);
            }
            this.mCount += 1;
            return entry1.indirect;
        }

        public PDFIndirect New(PDFDirect dir)
        {
            PDFIndirect indirect1 = this.New();
            indirect1.Direct = dir;
            return indirect1;
        }

        internal void UpdateIndirectCount()
        {
            this.mCount = 0;
            foreach (object obj1 in this)
            {
                this.mCount += 1;
            }
        }


        // Properties
        public int Count
        {
            get
            {
                return this.mCount;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public PDFIndirect this[int id]
        {
            get
            {
                XRefEntry entry1;
                PDFIndirect indirect1;
                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException("id", id, "Indirect number should be greater that zero");
                }
                try
                {
                    entry1 = ((XRefEntry) this.mDoc.mXRef[id]);
                    if (entry1.type == 0)
                    {
                        return null;
                    }
                    if (entry1.indirect == null)
                    {
                        entry1.indirect = new CorePDFIndirect(this.mDoc, id);
                    }
                    return entry1.indirect;
                }
                catch (ArgumentOutOfRangeException)
                {
                    return null;
                }
                return indirect1;
            }
        }

        public object SyncRoot
        {
            get
            {
                return null;
            }
        }


        // Fields
        private int mCount;
        private CoreDocument mDoc;
    }
}


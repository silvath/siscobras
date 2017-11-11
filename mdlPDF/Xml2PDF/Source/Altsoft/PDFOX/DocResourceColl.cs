namespace Altsoft.PDFO
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class DocResourceColl : ICollection, IEnumerable, IDisposable
    {
        // Methods
        internal DocResourceColl(Document doc)
        {
            this.mDoc = null;
            this.mResources = new Hashtable();
            this.mDoc = doc;
        }

        public Resource Add(Resource res)
        {
            Document document1 = this.mDoc;
            if (res.Direct.Doc == this.mDoc)
            {
                return res;
            }
            PDFObject obj1 = document1.CloneObject((res.Direct.IsIndirect ? res.Direct.Indirect : res.Direct));
            if (obj1.IsIndirect)
            {
                return this[obj1, res.GetType()];
            }
            PDFDirect direct1 = ((PDFDirect) obj1);
            document1.Indirects.New().Direct = direct1;
            return this[direct1, res.GetType()];
        }

        public void CopyTo(Array array, int index)
        {
            this.mResources.Values.CopyTo(array, index);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.mResources.Clear();
            this.mResources = null;
        }

        private void EnumResources(Resource r)
        {
            if (r.Resources == null)
            {
                return;
            }
            foreach (DictionaryEntry entry1 in r.Resources)
            {
                this.EnumResources((entry1.Value as Resource));
            }
        }

        ~DocResourceColl()
        {
            this.Dispose();
        }

        public int FindAllResources()
        {
            DictionaryEntry entry1;
            foreach (Page page1 in this.mDoc.Pages)
            {
                if (page1.Resources == null)
                {
                    continue;
                }
                foreach (object obj1 in page1.Resources)
                {
                    if (!(obj1 is DictionaryEntry))
                    {
                        continue;
                    }
                    entry1 = ((DictionaryEntry) obj1);
                    this.EnumResources((entry1.Value as Resource));
                }
            }
            return this.Count;
        }

        public IEnumerator GetEnumerator()
        {
            return this.mResources.Values.GetEnumerator();
        }


        // Properties
        public int Count
        {
            get
            {
                return this.mResources.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return this.mResources.Values.IsSynchronized;
            }
        }

        public Resource this[PDFObject i]
        {
            get
            {
                return this[i, typeof(Resource)];
            }
        }

        public Resource this[PDFObject i, Type resType]
        {
            get
            {
                object obj1 = Resources.Get(i, resType);
                this.mResources[i.Direct.UniqueID] = obj1;
                return ((Resource) obj1);
            }
        }

        public Resource this[int nr, Type resType]
        {
            get
            {
                PDFIndirect indirect1 = this.mDoc.Indirects[nr];
                if (indirect1 == null)
                {
                    return null;
                }
                return this[indirect1, resType];
            }
        }

        public Resource this[int nr]
        {
            get
            {
                return this[nr, typeof(Resource)];
            }
        }

        public object SyncRoot
        {
            get
            {
                return this.mResources.Values.SyncRoot;
            }
        }


        // Fields
        private Document mDoc;
        private Hashtable mResources;
    }
}


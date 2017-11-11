namespace Altsoft.PDFO
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class PageLabelRangesCollection : ICollection, IEnumerable
    {
        // Methods
        internal PageLabelRangesCollection(PDFDict root)
        {
            this.mLabels = null;
            this.mLabels = new NumberTree(root, "PageLabels", 20);
        }

        public void Add(int firstPage, PageNumberingStyle style, string prefix, int start)
        {
            this[firstPage] = PageLabelRange.Create(prefix, start, style, true);
        }

        public void Clear()
        {
        }

        public void CopyTo(Array array, int index)
        {
        }

        public IEnumerator GetEnumerator()
        {
            return null;
        }

        public void RemoveAtPosition(int index)
        {
        }

        public void RemoveAtStartingPage(int pageNr)
        {
        }


        // Properties
        public int Count
        {
            get
            {
                return this.mLabels.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public PageLabelRange this[int index]
        {
            get
            {
                return (Resources.Get(this.mLabels[index], typeof(PageLabelRange)) as PageLabelRange);
            }
            set
            {
                this.mLabels[index] = value.Direct;
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
        private NumberTree mLabels;
    }
}


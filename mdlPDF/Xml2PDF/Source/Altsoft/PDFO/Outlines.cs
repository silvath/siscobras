namespace Altsoft.PDFO
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class Outlines : Resource, ICollection, IEnumerable
    {
        // Methods
        public Outlines(PDFDirect direct) : base(direct)
        {
            this.mParentDict = null;
        }

        public void Add(OutlineItem item)
        {
            PDFObject obj1;
            if (base.Direct == null)
            {
                obj1 = Library.CreateDict();
                this.mParentDict["Outlines"] = obj1;
                this.mDirect = (obj1 as PDFDirect);
            }
            PDFDict dict1 = item.Dict;
            PDFDict dict2 = (this.Dict["Last"] as PDFDict);
            if (dict2 != null)
            {
                dict2["Next"] = dict1;
                dict1["Prev"] = dict2;
                dict1.Remove("Next");
                this.Dict["Last"] = dict1;
            }
            else
            {
                obj1 = item.Direct;
                this.Dict["Last"] = obj1;
                this.Dict["First"] = obj1;
                dict1.Remove("Prev");
                dict1.Remove("Next");
            }
            PDFInteger integer1 = (this.Dict["Count"] as PDFInteger);
            if (integer1 == null)
            {
                integer1 = Library.CreateInteger(((long) 1));
                this.Dict["Count"] = integer1;
            }
            else
            {
                integer1.Value += ((long) 1);
            }
            dict1["Parent"] = this.Dict;
        }

        private PDFDict At(int index)
        {
            if (base.Direct == null)
            {
                return null;
            }
            PDFDict dict1 = (this.Dict["First"] as PDFDict);
            while ((index > 0))
            {
                if (dict1 == null)
                {
                    return null;
                }
                dict1 = (dict1["Next"] as PDFDict);
                index = (index - 1);
            }
            return dict1;
        }

        public void Clear()
        {
            if (base.Direct == null)
            {
                throw new PDFException("Attempt to remove from non-existing outline collection");
            }
            this.Dict.Remove("First");
            this.Dict.Remove("Last");
            this.Dict["Count"] = PDF.O(0);
        }

        public void CopyTo(Array array, int index)
        {
        }

        internal static Outlines Create(PDFDict parent)
        {
            Outlines outlines1 = new Outlines(null);
            outlines1.mParentDict = parent;
            return outlines1;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new Outlines(direct);
        }

        public IEnumerator GetEnumerator()
        {
            return new OutlinesEnumerator(this);
        }

        public void Insert(int index, OutlineItem item)
        {
            PDFDict dict2;
            PDFInteger integer1;
            PDFDict dict3;
            PDFInteger integer2;
            PDFObject obj1;
            if (base.Direct == null)
            {
                obj1 = Library.CreateDict();
                this.mParentDict["Outlines"] = obj1;
                this.mDirect = (obj1 as PDFDirect);
            }
            PDFDict dict1 = item.Dict;
            if (index == 0)
            {
                dict2 = (this.Dict["First"] as PDFDict);
                if (dict2 != null)
                {
                    dict2["Prev"] = dict1;
                    dict1["Next"] = dict2;
                    dict1.Remove("Prev");
                    this.Dict["First"] = dict1;
                }
                else
                {
                    obj1 = item.Direct;
                    this.Dict["Last"] = obj1;
                    this.Dict["First"] = obj1;
                    dict1.Remove("Prev");
                    dict1.Remove("Next");
                }
                integer1 = (this.Dict["Count"] as PDFInteger);
                if (integer1 == null)
                {
                    integer1 = Library.CreateInteger(((long) 1));
                    this.Dict["Count"] = integer1;
                }
                else
                {
                    integer1.Value += ((long) 1);
                }
            }
            else if (index == this.Count)
            {
                this.Add(item);
            }
            else
            {
                dict3 = this.At(index);
                if (dict3 == null)
                {
                    throw new IndexOutOfRangeException("OutlineItem index out of range");
                }
                dict1["Prev"] = dict3["Prev"];
                dict1["Next"] = dict3;
                (dict3["Prev"] as PDFDict)["Next"] = dict1;
                integer2 = (this.Dict["Count"] as PDFInteger);
                if (integer2 == null)
                {
                    integer2 = Library.CreateInteger(((long) 1));
                    this.Dict["Count"] = integer2;
                }
                else
                {
                    integer2.Value += ((long) 1);
                }
            }
            dict1["Parent"] = this.Dict;
        }

        public void Remove(OutlineItem item)
        {
            if (base.Direct == null)
            {
                throw new PDFException("Attempt to remove from non-existing outline collection");
            }
            PDFDict dict1 = item.Dict;
            PDFDict dict2 = (dict1["Prev"] as PDFDict);
            PDFDict dict3 = (dict1["Next"] as PDFDict);
            if (dict2 != null)
            {
                dict2["Next"] = dict1["Next"];
            }
            else
            {
                this.Dict["First"] = dict1["Next"];
            }
            if (dict3 != null)
            {
                dict3["Prev"] = dict1["Prev"];
            }
            else
            {
                this.Dict["Last"] = dict1["Prev"];
            }
            PDFInteger integer1 = (this.Dict["Count"] as PDFInteger);
            if (integer1 == null)
            {
                throw new PDFSyntaxException(base.Direct, "Non-empty outlines collection missing Count item");
            }
            integer1.Value -= ((long) 1);
        }

        public void RemoveAt(int index)
        {
            this.Remove(this[index]);
        }


        // Properties
        public int Count
        {
            get
            {
                if (base.Direct == null)
                {
                    return 0;
                }
                PDFInteger integer1 = (this.Dict["Count"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return integer1.Int32Value;
            }
        }

        public OutlineItem First
        {
            get
            {
                if (base.Direct == null)
                {
                    return null;
                }
                PDFDict dict1 = (this.Dict["First"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(OutlineItem)) as OutlineItem);
            }
            set
            {
                PDFObject obj1;
                if (base.Direct == null)
                {
                    obj1 = Library.CreateDict();
                    this.mParentDict["Outlines"] = obj1;
                    this.mDirect = (obj1 as PDFDirect);
                }
                this.Dict["First"] = value.Dict;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return true;
            }
        }

        public OutlineItem this[int index]
        {
            get
            {
                PDFDict dict1 = this.At(index);
                if (dict1 == null)
                {
                    throw new IndexOutOfRangeException("OutlineItem index out of range");
                }
                return (Resources.Get(dict1, typeof(OutlineItem)) as OutlineItem);
            }
            set
            {
                PDFDict dict1 = this.At(index);
                if (dict1 == null)
                {
                    throw new IndexOutOfRangeException("OutlineItem index out of range");
                }
                PDFDict dict2 = value.Dict;
                dict2["Next"] = dict1["Next"];
                dict2["Prev"] = dict1["Prev"];
                dict2 = (dict1["Prev"] as PDFDict);
                if (dict2 != null)
                {
                    dict2["Next"] = value.Direct;
                }
                else
                {
                    this.Dict["First"] = value.Direct;
                }
                dict2 = (dict1["Next"] as PDFDict);
                if (dict2 != null)
                {
                    dict2["Prev"] = value.Direct;
                }
                else
                {
                    this.Dict["Last"] = value.Direct;
                }
                dict1["Parent"] = this.Dict;
            }
        }

        public OutlineItem Last
        {
            get
            {
                if (base.Direct == null)
                {
                    return null;
                }
                PDFDict dict1 = (this.Dict["Last"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(OutlineItem)) as OutlineItem);
            }
            set
            {
                PDFObject obj1;
                if (base.Direct == null)
                {
                    obj1 = Library.CreateDict();
                    this.mParentDict["Outlines"] = obj1;
                    this.mDirect = (obj1 as PDFDirect);
                }
                this.Dict["Last"] = value.Dict;
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
        private PDFDict mParentDict;

        // Nested Types
        private class OutlinesEnumerator : IEnumerator
        {
            // Methods
            public OutlinesEnumerator(Outlines coll)
            {
                this.mItem = null;
                this.mColl = coll;
            }

            public bool MoveNext()
            {
                if (this.mItem == null)
                {
                    this.mItem = this.mColl.First;
                }
                else
                {
                    this.mItem = this.mItem.Next;
                }
                return (this.mItem != null);
            }

            public void Reset()
            {
            }


            // Properties
            public object Current
            {
                get
                {
                    return this.mItem;
                }
            }


            // Fields
            private Outlines mColl;
            private OutlineItem mItem;
        }
    }
}


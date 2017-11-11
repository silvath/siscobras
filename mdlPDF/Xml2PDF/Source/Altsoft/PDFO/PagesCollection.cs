namespace Altsoft.PDFO
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class PagesCollection : ICollection, IEnumerable
    {
        // Methods
        static PagesCollection()
        {
            PagesCollection.MaxKids = 6;
        }

        internal PagesCollection(Document doc)
        {
            this.mDoc = null;
            this.mPagesDict = null;
            this.mPagesColl = new ArrayList();
            this.mDoc = doc;
            try
            {
                this.mPagesDict = (doc.Root["Pages"] as PDFDict);
                if (this.mPagesDict != null)
                {
                    this.PageEnumProc(this.mPagesDict);
                }
                this.LabelRanges = new PageLabelRangesCollection(doc.Root);
            }
            catch (NullReferenceException)
            {
            }
        }

        public Page Add()
        {
            return this.Insert(this.Count);
        }

        public Page Add(PDFObject page)
        {
            return this.Insert(this.Count, page);
        }

        public void CopyTo(Array array, int index)
        {
            int num1;
            for (num1 = 0; (num1 < this.Count); num1 += 1)
            {
                array.SetValue(this[num1], (index + num1));
            }
        }

        public void Delete(int nr)
        {
            PDFDict dict3;
            PDFDict dict1 = this[nr].Dict;
            PDFDict dict2 = ((PDFDict) dict1["Parent"]);
            PDFArray array1 = ((PDFArray) dict2["Kids"]);
            int num1 = 0;
            while ((num1 < array1.Count))
            {
                if (array1[num1].Indirect.Id == dict1.Indirect.Id)
                {
                    break;
                }
                num1 += 1;
            }
            if (num1 == array1.Count)
            {
                throw new PDFException(string.Format("Invalid page tree - invalid parent pointer in page {0}", nr));
            }
            array1.RemoveAt(num1);
            for (dict3 = dict2; (dict3 != null); dict3 = ((PDFDict) dict3["Parent"]))
            {
                PDFInteger integer1 = ((PDFInteger) dict2["Count"]);
                ((PDFInteger) dict2["Count"]).Value = (integer1.Value - ((long) 1));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.mPagesColl = null;
            this.mPagesDict = null;
        }

        ~PagesCollection()
        {
            this.Dispose();
        }

        public IEnumerator GetEnumerator()
        {
            return new PagesCollectionEnumerator(this.mPagesColl);
        }

        public Page Insert(int nr)
        {
            return this.Insert(nr, Page.New(this.mDoc));
        }

        public Page Insert(int nr, PDFObject page)
        {
            PDFDict dict1;
            PDFArray array1;
            int num1;
            PDFDict dict2;
            PDFDict dict3;
            PDFDict dict4;
            PDFIndirect indirect1;
            PDFArray array2;
            int num2;
            int num3;
            PDFDict dict5;
            int num4;
            PDFDict dict6;
            PDFArray array3;
            PDFDict dict7;
            PDFArray array4;
            int num5;
            Page page1;
            Page page2;
            PDFDict dict8;
            PDFObject obj1;
            try
            {
                if (nr > this.Count)
                {
                    throw new ArgumentOutOfRangeException("nr", nr, "New page number should be less or equal to page count");
                }
                if (this.mPagesDict == null)
                {
                    dict8 = Library.CreateDict();
                    this.mPagesDict = dict8;
                    this.mDoc.Root["Pages"] = Library.CreateIndirect(dict8);
                }
                dict1 = null;
                array1 = null;
                num1 = 0;
                if (this.Count == 0)
                {
                    dict1 = this.mPagesDict;
                    array1 = ((PDFArray) dict1["Kids"]);
                    if (array1 == null)
                    {
                        obj1 = Library.CreateArray(0);
                        dict1["Kids"] = obj1;
                        array1 = ((PDFArray) obj1);
                    }
                    dict1["Count"] = PDF.O(0);
                }
                else
                {
                    dict2 = this[((nr > 0) ? (nr - 1) : 0)].Dict;
                    dict1 = ((PDFDict) dict2["Parent"]);
                    array1 = ((PDFArray) dict1["Kids"]);
                    if (nr > 0)
                    {
                        num1 = 0;
                        while ((num1 < array1.Count))
                        {
                            if (array1[num1].Indirect.Id == dict2.Indirect.Id)
                            {
                                break;
                            }
                            num1 += 1;
                        }
                        if (num1 == array1.Count)
                        {
                            throw new PDFException(string.Format("Invalid page tree - invalid parent pointer in page {0}", nr));
                        }
                        num1 += 1;
                    }
                    else
                    {
                        num1 = 0;
                    }
                }
                array1.Insert(num1, page);
                ((PDFDict) page.Direct)["Parent"] = dict1.Indirect;
                for (dict3 = dict1; (dict3 != null); dict3 = ((PDFDict) dict3["Parent"]))
                {
                    PDFInteger integer1 = ((PDFInteger) dict3["Count"]);
                    ((PDFInteger) dict3["Count"]).Value = (integer1.Value + ((long) 1));
                }
                while ((array1.Count > PagesCollection.MaxKids))
                {
                    dict4 = Library.CreateDict();
                    indirect1 = this.mDoc.Indirects.New(dict4);
                    dict4["Type"] = Library.CreateName("Pages");
                    obj1 = Library.CreateArray(0);
                    dict4["Kids"] = obj1;
                    array2 = ((PDFArray) obj1);
                    num2 = ((PDFNumeric) dict1["Count"]).Int32Value;
                    num3 = 0;
                    while ((array1.Count > (PagesCollection.MaxKids / 2)))
                    {
                        dict5 = ((PDFDict) array1[(PagesCollection.MaxKids / 2)]);
                        array1.RemoveAt((PagesCollection.MaxKids / 2));
                        dict5["Parent"] = dict4.Indirect;
                        num4 = 0;
                        if (((PDFName) dict5["Type"]).Value.Equals("Pages"))
                        {
                            num4 = ((PDFNumeric) dict5["Count"]).Int32Value;
                        }
                        else
                        {
                            num4 = 1;
                        }
                        num2 -= num4;
                        num3 += num4;
                        array2.Add(dict5.Indirect);
                    }
                    ((PDFInteger) dict1["Count"]).Value = ((long) num2);
                    dict4["Count"] = Library.CreateInteger(((long) num3));
                    if (dict1["Parent"] == null)
                    {
                        dict6 = Library.CreateDict();
                        this.mDoc.Indirects.New(dict6);
                        dict6["Type"] = Library.CreateName("Pages");
                        dict6["Count"] = Library.CreateInteger(((long) (num3 + num2)));
                        obj1 = Library.CreateArray(0);
                        dict6["Kids"] = obj1;
                        array3 = ((PDFArray) obj1);
                        array3.Add(dict1.Indirect);
                        array3.Add(dict4.Indirect);
                        dict1["Parent"] = dict6.Indirect;
                        dict4["Parent"] = dict6.Indirect;
                        this.mDoc.Root["Pages"] = dict6.Indirect;
                        dict1 = dict6;
                    }
                    else
                    {
                        dict4["Parent"] = dict1["Parent"].Indirect;
                        dict7 = ((PDFDict) dict1["Parent"]);
                        array4 = ((PDFArray) dict7["Kids"]);
                        num5 = 0;
                        while ((num5 < array4.Count))
                        {
                            if (array4[num5].Indirect.Id == dict1.Indirect.Id)
                            {
                                break;
                            }
                            num5 += 1;
                        }
                        if (num5 == array4.Count)
                        {
                            throw new PDFException("Invalid page tree - invalid parent pointer");
                        }
                        array4.Insert((num5 + 1), indirect1);
                        dict1 = dict7;
                    }
                    array1 = ((PDFArray) dict1["Kids"]);
                }
                page1 = (Resources.Get(page, typeof(Page)) as Page);
                this.mPagesColl.Insert(nr, page);
                return page1;
            }
            catch (InvalidCastException)
            {
                throw new PDFSyntaxException("Invalid PDF page tree");
            }
            return page2;
        }

        private void PageEnumProc(PDFDict dict)
        {
            int num1;
            PDFArray array1;
            PDFDict dict1;
            PDFName name1;
            try
            {
                num1 = 0;
                array1 = (dict["Kids"] as PDFArray);
                foreach (PDFObject obj1 in array1)
                {
                    dict1 = (obj1.Direct as PDFDict);
                    name1 = (dict1["Type"].Direct as PDFName);
                    if (name1.Value == "Pages")
                    {
                        this.PageEnumProc(dict1);
                    }
                    if (name1.Value != "Page")
                    {
                        continue;
                    }
                    this.mPagesColl.Add(dict1);
                    num1 += 1;
                }
            }
            catch (InvalidCastException)
            {
            }
            catch (NullReferenceException)
            {
            }
        }

        private void PullInheritedParams(PDFDict obj)
        {
            try
            {
                if (((PDFName) obj["Type"]).Equals("Page"))
                {
                    (Resources.Get(obj, typeof(Page)) as Page).PullInheritedParams();
                    return;
                }
                if (((PDFName) obj["Type"]).Equals("Pages"))
                {
                    foreach (PDFDict dict1 in ((PDFArray) obj["Kids"]))
                    {
                        this.PullInheritedParams(dict1);
                    }
                    return;
                }
                throw new PDFSyntaxException(obj, "Invalid PDF tree object - /Type sould be either /Page or /Pages");
            }
            catch (InvalidCastException)
            {
                throw new PDFSyntaxException(obj, "Invalid PDF tree object - invalid object type");
            }
        }

        public void PullInheritedParamsOnAllPages()
        {
            this.PullInheritedParams(this.mPagesDict);
        }

        public void Rebalance()
        {
        }


        // Properties
        public int Count
        {
            get
            {
                return this.mPagesColl.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public Page this[int index]
        {
            get
            {
                return (Resources.Get((this.mPagesColl[index] as PDFObject), typeof(Page)) as Page);
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
        public readonly PageLabelRangesCollection LabelRanges;
        private static readonly int MaxKids;
        private Document mDoc;
        private ArrayList mPagesColl;
        private PDFDict mPagesDict;

        // Nested Types
        private class PagesCollectionEnumerator : IEnumerator
        {
            // Methods
            internal PagesCollectionEnumerator(ArrayList list)
            {
                this.mEnum = list.GetEnumerator();
            }

            public bool MoveNext()
            {
                return this.mEnum.MoveNext();
            }

            public void Reset()
            {
                this.mEnum.Reset();
            }


            // Properties
            public object Current
            {
                get
                {
                    return Resources.Get((this.mEnum.Current as PDFObject), typeof(Page));
                }
            }


            // Fields
            private IEnumerator mEnum;
        }
    }
}


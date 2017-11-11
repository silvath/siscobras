namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Collections;
    using System.Reflection;

    public class NameTree : ICollection, IEnumerable
    {
        // Methods
        static NameTree()
        {
            NameTree.TreeCountFilterDelegate = new EnumerationFilter(NameTree.TreeCountFilter);
        }

        public NameTree(PDFDict parentDict, string parentKey, int maxKids)
        {
            this.mParentDict = parentDict;
            this.mParentKey = parentKey;
            this.mMaxKids = maxKids;
        }

        public void CopyTo(Array arr, int offset)
        {
        }

        public IEnumerator GetEnumerator()
        {
            return new NameTreeEnumerator((this.mParentDict[this.mParentKey] as PDFDict));
        }

        private PDFObject GetItem(PDFDict curr, string index)
        {
            int num1;
            PDFString text1;
            int num2;
            PDFDict dict1;
            PDFArray array3;
            PDFString text2;
            PDFString text3;
            PDFArray array1 = (curr["Names"] as PDFArray);
            if (array1 != null)
            {
                if ((array1.Count % 2) != 0)
                {
                    return null;
                }
                for (num1 = 0; (num1 < (array1.Count / 2)); num1 += 1)
                {
                    text1 = (array1[(2 * num1)] as PDFString);
                    if ((text1 != null) && (text1.Value == index))
                    {
                        return array1[((2 * num1) + 1)];
                    }
                }
            }
            PDFArray array2 = (curr["Kids"] as PDFArray);
            if (array2 != null)
            {
                for (num2 = 0; (num2 < array2.Count); num2 += 1)
                {
                    dict1 = (array2[num2] as PDFDict);
                    if (dict1 != null)
                    {
                        array3 = (dict1["Limits"] as PDFArray);
                        if ((array3 != null) && (array3.Count == 2))
                        {
                            text2 = (array3[0] as PDFString);
                            text3 = (array3[1] as PDFString);
                            if (((text2 != null) && (text3 != null)) && ((string.Compare(text2.Value, index, false) <= 0) || (string.Compare(index, text3.Value, false) <= 0)))
                            {
                                return this.GetItem(dict1, index);
                            }
                        }
                    }
                }
            }
            return null;
        }

        private PDFDict SetItem(PDFDict curr, string index, PDFObject value)
        {
            bool flag1;
            int num1;
            PDFString text1;
            PDFArray array3;
            int num2;
            PDFArray array4;
            PDFDict dict1;
            PDFArray array5;
            PDFArray array6;
            int num3;
            PDFDict dict2;
            PDFArray array7;
            PDFString text2;
            PDFString text3;
            PDFDict dict3;
            PDFArray array8;
            PDFObject obj1;
            PDFArray array1 = (curr["Names"] as PDFArray);
            PDFArray array2 = (curr["Kids"] as PDFArray);
            if (array1 != null)
            {
                if ((array1.Count % 2) != 0)
                {
                    throw new InvalidOperationException("Attempt to manipulate invalid name tree");
                }
                flag1 = true;
                for (num1 = 0; (num1 < (array1.Count / 2)); num1 += 1)
                {
                    text1 = (array1[(2 * num1)] as PDFString);
                    if (text1 == null)
                    {
                        throw new InvalidOperationException("Attempt to manipulate invalid name tree");
                    }
                    if (text1.Value == index)
                    {
                        array1[((2 * num1) + 1)] = value;
                        return null;
                    }
                    if (string.Compare(text1.Value, index, false) > 0)
                    {
                        array1.Insert((2 * num1), value);
                        array1.Insert((2 * num1), PDF.O(index));
                        flag1 = false;
                        break;
                    }
                }
                if (flag1)
                {
                    array1.Add(PDF.O(index));
                    array1.Add(value);
                    array3 = (curr["Limits"] as PDFArray);
                    if (array3 != null)
                    {
                        ((PDFString) array3[1]).Value = index;
                    }
                }
                if ((array1.Count / 2) > this.mMaxKids)
                {
                    num2 = (array1.Count / 2);
                    array4 = Library.CreateArray(0);
                    dict1 = Library.CreateDict();
                    Library.CreateIndirect(dict1);
                    while ((array1.Count > num2))
                    {
                        array4.Insert(0, array1.RemoveAt((array1.Count - 1)));
                        array4.Insert(0, array1.RemoveAt((array1.Count - 1)));
                    }
                    array5 = Library.CreateArray(1);
                    array5[0] = array1[0];
                    array5[1] = array1[(array1.Count - 2)];
                    curr["Limits"] = array5;
                    dict1["Names"] = array4;
                    array6 = Library.CreateArray(0);
                    array6[0] = array4[0];
                    array6[1] = array4[(array4.Count - 2)];
                    dict1["Limits"] = array6;
                    return dict1;
                }
                return null;
            }
            if (array2 != null)
            {
                for (num3 = 0; (num3 < array2.Count); num3 += 1)
                {
                    dict2 = (array2[num3] as PDFDict);
                    if (dict2 == null)
                    {
                        throw new InvalidOperationException("Attempt to manipulate invalid name tree");
                    }
                    array7 = (dict2["Limits"] as PDFArray);
                    if (array7.Count != 2)
                    {
                        throw new InvalidOperationException("Attempt to manipulate invalid name tree");
                    }
                    text2 = (array7[0] as PDFString);
                    text3 = (array7[1] as PDFString);
                    if ((text2 == null) || (text3 == null))
                    {
                        throw new InvalidOperationException("Attempt to manipulate invalid name tree");
                    }
                    if (((string.Compare(index, text2.Value) < 0) || (string.Compare(index, text3.Value) < 0)) || ((num3 + 1) == array2.Count))
                    {
                        dict3 = this.SetItem(dict2, index, value);
                        if (string.Compare(index, text2.Value) < 0)
                        {
                            array7[0] = PDF.O(index);
                        }
                        if (dict3 != null)
                        {
                            return this.SplitNode(curr, num3, dict3);
                        }
                        return null;
                    }
                }
            }
            else
            {
                array1 = Library.CreateArray(2);
                curr["Names"] = array1;
                array8 = Library.CreateArray(2);
                obj1 = PDF.O(index);
                array1[0] = obj1;
                obj1 = obj1;
                array8[1] = obj1;
                array8[0] = obj1;
                array1[1] = value;
            }
            return null;
        }

        private PDFDict SplitNode(PDFDict curr, int index, PDFDict splinter)
        {
            PDFDict dict1;
            PDFArray array2;
            int num1;
            PDFArray array3;
            PDFArray array4;
            PDFArray array1 = (curr["Kids"] as PDFArray);
            if (index == (array1.Count - 1))
            {
                array1.Add(splinter);
            }
            else
            {
                array1.Insert((index + 1), splinter);
            }
            if (array1.Count > this.mMaxKids)
            {
                dict1 = Library.CreateDict();
                Library.CreateIndirect(dict1);
                array2 = Library.CreateArray();
                dict1["Kids"] = array2;
                num1 = (array1.Count / 2);
                while ((array1.Count > num1))
                {
                    array2.Insert(0, array1.RemoveAt((array1.Count - 1)));
                }
                array3 = Library.CreateArray(2);
                dict1["Limits"] = array3;
                array3[0] = ((array2[0] as PDFDict)["Limits"] as PDFArray)[0];
                array3[1] = ((array2[(array2.Count - 1)] as PDFDict)["Limits"] as PDFArray)[1];
                array4 = Library.CreateArray(2);
                array4[0] = ((array1[0] as PDFDict)["Limits"] as PDFArray)[0];
                array4[1] = ((array1[(array1.Count - 1)] as PDFDict)["Limits"] as PDFArray)[1];
                curr["Limits"] = array4;
                return dict1;
            }
            return null;
        }

        private static ItemAction TreeCountFilter(object item)
        {
            if (!(item is DictionaryEntry))
            {
                return ItemAction.Enumerate;
            }
            DictionaryEntry entry1 = ((DictionaryEntry) item);
            string text1 = ((PDFName) entry1.Key).Value;
            if (text1 == "Names")
            {
                return ItemAction.EnumerateInto;
            }
            return ItemAction.Skip;
        }


        // Properties
        public int Count
        {
            get
            {
                if (this.mParentDict == null)
                {
                    return 0;
                }
                PDFDict dict1 = (this.mParentDict[this.mParentKey] as PDFDict);
                if (dict1 == null)
                {
                    return 0;
                }
                int num1 = 0;
                foreach (object obj1 in new EnumerableTree(dict1, NameTree.TreeCountFilterDelegate))
                {
                    num1 += 1;
                }
                return (num1 / 2);
            }
        }

        public PDFDict Dict
        {
            get
            {
                return (this.mParentDict[this.mParentKey] as PDFDict);
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return true;
            }
        }

        public PDFObject this[string index, bool direct]
        {
            get
            {
                if (this.mParentDict == null)
                {
                    return null;
                }
                PDFDict dict1 = (this.mParentDict[this.mParentKey] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                PDFObject obj1 = this.GetItem(dict1, index);
                if (direct)
                {
                    obj1 = obj1.Direct;
                }
                return obj1;
            }
        }

        public PDFObject this[string index]
        {
            get
            {
                return this[index, 0];
            }
            set
            {
                PDFArray array1;
                PDFDict dict3;
                PDFArray array2;
                if (this.mParentDict == null)
                {
                    throw new InvalidOperationException("Attempt to modify non-existing nametree");
                }
                PDFDict dict1 = (this.mParentDict[this.mParentKey] as PDFDict);
                if (dict1 == null)
                {
                    dict1 = Library.CreateDict();
                    this.mParentDict[this.mParentKey] = Library.CreateIndirect(dict1);
                    array1 = Library.CreateArray(2);
                    dict1["Names"] = array1;
                    array1[0] = PDF.O(index);
                    array1[1] = value;
                    return;
                }
                PDFDict dict2 = this.SetItem(dict1, index, value);
                if (dict2 != null)
                {
                    dict3 = Library.CreateDict();
                    Library.CreateIndirect(dict3);
                    array2 = Library.CreateArray(2);
                    array2[0] = dict1;
                    array2[1] = dict2;
                    dict3["Kids"] = array2;
                    this.mParentDict[this.mParentKey] = dict3;
                }
            }
        }

        public string Max
        {
            get
            {
                PDFString text1;
                PDFString text2;
                int num1;
                PDFDict dict1;
                PDFString text3;
                PDFArray array1 = (this.Dict["Names"] as PDFArray);
                if (array1 != null)
                {
                    if (array1.Count == 0)
                    {
                        return null;
                    }
                    if ((array1.Count % 2) != 0)
                    {
                        return null;
                    }
                    text1 = (array1[(array1.Count - 2)] as PDFString);
                    if (text1 == null)
                    {
                        return null;
                    }
                    return text1.Value;
                }
                PDFArray array2 = (this.Dict["Limits"] as PDFArray);
                if (array2 != null)
                {
                    text2 = (array2[1] as PDFString);
                    if (text2 == null)
                    {
                        return null;
                    }
                    return text2.Value;
                }
                PDFArray array3 = (this.Dict["Kids"] as PDFArray);
                if (array3 != null)
                {
                    if (array3.Count == 0)
                    {
                        return null;
                    }
                    for (num1 = (array3.Count - 1); (num1 > 0); num1 -= 1)
                    {
                        dict1 = (array3[(array3.Count - 1)] as PDFDict);
                        if (dict1 == null)
                        {
                            return null;
                        }
                        array2 = (dict1["Limits"] as PDFArray);
                        if (array2 != null)
                        {
                            text3 = (array2[1] as PDFString);
                            if (text3 == null)
                            {
                                return null;
                            }
                            return text3.Value;
                        }
                    }
                }
                return null;
            }
        }

        public string Min
        {
            get
            {
                foreach (DictionaryEntry entry1 in this)
                {
                    return (entry1.Key as PDFString).Value;
                }
                return null;
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
        private int mMaxKids;
        public PDFDict mParentDict;
        private string mParentKey;
        private static EnumerationFilter TreeCountFilterDelegate;

        // Nested Types
        private class NameTreeEnumerator : IEnumerator
        {
            // Methods
            public NameTreeEnumerator(PDFDict tree)
            {
                this.mCurr = new DictionaryEntry();
                this.mArrs = new PDFArray[16];
                this.mPos = new int[16];
                this.mTop = -1;
                this.mTree = tree;
            }

            public bool MoveNext()
            {
                PDFDict dict1;
                PDFArray array1;
                PDFArray[] arrayArray1;
                int[] numArray1;
                PDFArray array2;
                PDFArray[] arrayArray2;
                int[] numArray2;
                int num1;
                int[] numArray3;
                IntPtr ptr1;
                if (this.mTop == -1)
                {
                    if (this.mTree == null)
                    {
                        return false;
                    }
                    this.mArrs[0] = (this.mTree["Kids"] as PDFArray);
                    if (this.mArrs[0] == null)
                    {
                        this.mArrs[0] = (this.mTree["Names"] as PDFArray);
                    }
                    if (this.mArrs[0] == null)
                    {
                        return false;
                    }
                    if (this.mArrs[0].Count == 0)
                    {
                        return false;
                    }
                    this.mTop = 0;
                }
                while ((this.mTop >= 0))
                {
                    if (this.mArrs[this.mTop].Count == this.mPos[this.mTop])
                    {
                        num1 = (this.mTop - 1);
                        this.mTop = num1;
                        if (num1 < 0)
                        {
                            continue;
                        }
                        numArray3 = this.mPos;
                        ptr1 = ((IntPtr) this.mTop);
                        numArray3[ptr1] = (numArray3[ptr1] + 1);
                        continue;
                    }
                    if ((this.mArrs[this.mTop][this.mPos[this.mTop]] is PDFString))
                    {
                        this.mCurr.Key = ((object) this.mArrs[this.mTop][this.mPos[this.mTop]]);
                        this.mCurr.Value = ((object) this.mArrs[this.mTop][(this.mPos[this.mTop] + 1)]);
                        numArray3 = this.mPos;
                        ptr1 = ((IntPtr) this.mTop);
                        numArray3[ptr1] = (numArray3[ptr1] + 2);
                        return true;
                    }
                    dict1 = (this.mArrs[this.mTop][this.mPos[this.mTop]] as PDFDict);
                    if (dict1 == null)
                    {
                        throw new InvalidOperationException("Iterating invalid tree");
                    }
                    array1 = (dict1["Kids"] as PDFArray);
                    if ((array1 != null) && (array1.Count == 0))
                    {
                        array1 = null;
                    }
                    if (array1 != null)
                    {
                        this.mTop += 1;
                        if (this.mTop == this.mArrs.Length)
                        {
                            arrayArray1 = new PDFArray[(this.mArrs.Length + 16)];
                            numArray1 = new int[(this.mArrs.Length + 16)];
                            this.mArrs.CopyTo(arrayArray1, 0);
                            this.mPos.CopyTo(numArray1, 0);
                            this.mArrs = arrayArray1;
                            this.mPos = numArray1;
                        }
                        this.mArrs[this.mTop] = array1;
                        this.mPos[this.mTop] = 0;
                        continue;
                    }
                    array2 = (dict1["Names"] as PDFArray);
                    if ((array2 != null) && (array2.Count == 0))
                    {
                        array2 = null;
                    }
                    if (array2 != null)
                    {
                        this.mTop += 1;
                        if (this.mTop == this.mArrs.Length)
                        {
                            arrayArray2 = new PDFArray[(this.mArrs.Length + 16)];
                            numArray2 = new int[(this.mArrs.Length + 16)];
                            this.mArrs.CopyTo(arrayArray2, 0);
                            this.mPos.CopyTo(numArray2, 0);
                            this.mArrs = arrayArray2;
                            this.mPos = numArray2;
                        }
                        this.mArrs[this.mTop] = array2;
                        this.mPos[this.mTop] = 0;
                        continue;
                    }
                    numArray3 = this.mPos;
                    ptr1 = ((IntPtr) this.mTop);
                    num1 = (numArray3[ptr1] + 1);
                    numArray3[ptr1] = num1;
                    if (num1 != this.mArrs[this.mTop].Count)
                    {
                        continue;
                    }
                    this.mTop -= 1;
                }
                return false;
            }

            public void Reset()
            {
            }


            // Properties
            public object Current
            {
                get
                {
                    return this.mCurr;
                }
            }


            // Fields
            private PDFArray[] mArrs;
            private DictionaryEntry mCurr;
            private int[] mPos;
            private int mTop;
            private PDFDict mTree;
        }
    }
}


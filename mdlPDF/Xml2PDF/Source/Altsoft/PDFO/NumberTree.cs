namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Collections;
    using System.Reflection;

    public class NumberTree : ICollection, IEnumerable
    {
        // Methods
        static NumberTree()
        {
            NumberTree.TreeCountFilterDelegate = new EnumerationFilter(NumberTree.TreeCountFilter);
        }

        public NumberTree(PDFDict parentDict, string parentKey, int maxKids)
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
            return new NumberTreeEnumerator((this.mParentDict[this.mParentKey] as PDFDict));
        }

        private PDFObject GetItem(PDFDict curr, int index)
        {
            int num1;
            PDFInteger integer1;
            int num2;
            PDFDict dict1;
            PDFArray array3;
            PDFInteger integer2;
            PDFInteger integer3;
            PDFArray array1 = (curr["Nums"] as PDFArray);
            if (array1 != null)
            {
                if ((array1.Count % 2) != 0)
                {
                    return null;
                }
                for (num1 = 0; (num1 < (array1.Count / 2)); num1 += 1)
                {
                    integer1 = (array1[(2 * num1)] as PDFInteger);
                    if ((integer1 != null) && (integer1.Value == ((long) index)))
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
                            integer2 = (array3[0] as PDFInteger);
                            integer3 = (array3[1] as PDFInteger);
                            if (((integer2 != null) && (integer3 != null)) && ((integer2.Value <= ((long) index)) || (((long) index) <= integer3.Value)))
                            {
                                return this.GetItem(dict1, index);
                            }
                        }
                    }
                }
            }
            return null;
        }

        private PDFDict SetItem(PDFDict curr, int index, PDFObject value)
        {
            bool flag1;
            int num1;
            PDFInteger integer1;
            PDFArray array3;
            int num2;
            PDFArray array4;
            PDFDict dict1;
            PDFArray array5;
            PDFArray array6;
            int num3;
            PDFDict dict2;
            PDFArray array7;
            PDFInteger integer2;
            PDFInteger integer3;
            PDFDict dict3;
            PDFArray array8;
            PDFObject obj1;
            PDFArray array1 = (curr["Nums"] as PDFArray);
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
                    integer1 = (array1[(2 * num1)] as PDFInteger);
                    if (integer1 == null)
                    {
                        throw new InvalidOperationException("Attempt to manipulate invalid name tree");
                    }
                    if (integer1.Value == ((long) index))
                    {
                        array1[((2 * num1) + 1)] = value;
                        return null;
                    }
                    if (integer1.Value > ((long) index))
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
                        ((PDFInteger) array3[1]).Value = ((long) index);
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
                    dict1["Nums"] = array4;
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
                    integer2 = (array7[0] as PDFInteger);
                    integer3 = (array7[1] as PDFInteger);
                    if ((integer2 == null) || (integer3 == null))
                    {
                        throw new InvalidOperationException("Attempt to manipulate invalid name tree");
                    }
                    if (((((long) index) < integer2.Value) || (((long) index) < integer3.Value)) || ((num3 + 1) == array2.Count))
                    {
                        dict3 = this.SetItem(dict2, index, value);
                        if (((long) index) < integer2.Value)
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
                curr["Nums"] = array1;
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
            if (text1 == "Nums")
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
                foreach (object obj1 in new EnumerableTree(dict1, NumberTree.TreeCountFilterDelegate))
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

        public PDFObject this[int index, bool direct]
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

        public PDFObject this[int index]
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
                    dict1["Nums"] = array1;
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

        public long Max
        {
            get
            {
                PDFInteger integer1;
                PDFInteger integer2;
                int num1;
                PDFDict dict1;
                PDFInteger integer3;
                PDFArray array1 = (this.Dict["Names"] as PDFArray);
                if (array1 != null)
                {
                    if (array1.Count == 0)
                    {
                        return ((long) 0);
                    }
                    if ((array1.Count % 2) != 0)
                    {
                        return ((long) 0);
                    }
                    integer1 = (array1[(array1.Count - 2)] as PDFInteger);
                    if (integer1 == null)
                    {
                        return ((long) 0);
                    }
                    return integer1.Value;
                }
                PDFArray array2 = (this.Dict["Limits"] as PDFArray);
                if (array2 != null)
                {
                    integer2 = (array2[1] as PDFInteger);
                    if (integer2 == null)
                    {
                        return ((long) 0);
                    }
                    return integer2.Value;
                }
                PDFArray array3 = (this.Dict["Kids"] as PDFArray);
                if (array3 != null)
                {
                    if (array3.Count == 0)
                    {
                        return ((long) 0);
                    }
                    for (num1 = (array3.Count - 1); (num1 > 0); num1 -= 1)
                    {
                        dict1 = (array3[(array3.Count - 1)] as PDFDict);
                        if (dict1 == null)
                        {
                            return ((long) 0);
                        }
                        array2 = (dict1["Limits"] as PDFArray);
                        if (array2 != null)
                        {
                            integer3 = (array2[1] as PDFInteger);
                            if (integer3 == null)
                            {
                                return ((long) 0);
                            }
                            return integer3.Value;
                        }
                    }
                }
                return ((long) 0);
            }
        }

        public long Min
        {
            get
            {
                foreach (DictionaryEntry entry1 in this)
                {
                    return (entry1.Key as PDFInteger).Value;
                }
                return ((long) 0);
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
        private class NumberTreeEnumerator : IEnumerator
        {
            // Methods
            public NumberTreeEnumerator(PDFDict tree)
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
                        this.mArrs[0] = (this.mTree["Nums"] as PDFArray);
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
                    if ((this.mArrs[this.mTop][this.mPos[this.mTop]] is PDFInteger))
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
                    array2 = (dict1["Nums"] as PDFArray);
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


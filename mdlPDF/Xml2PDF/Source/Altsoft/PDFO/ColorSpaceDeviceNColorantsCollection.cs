namespace Altsoft.PDFO
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class ColorSpaceDeviceNColorantsCollection : ICollection, IEnumerable
    {
        // Methods
        internal ColorSpaceDeviceNColorantsCollection(PDFArray arr)
        {
            this.mArr = null;
            this.mDict = null;
            this.mHash = new Hashtable();
            this.mArr = arr;
            if (this.mArr.Count >= 5)
            {
                this.mDict = (this.mArr[4] as PDFDict);
            }
        }

        public void CopyTo(Array array, int index)
        {
            this.mDict.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return this.mDict.GetEnumerator();
        }


        // Properties
        public int Count
        {
            get
            {
                if (this.mDict == null)
                {
                    return 0;
                }
                return this.mDict.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return true;
            }
        }

        public ColorSpaceSeparation this[string index]
        {
            get
            {
                if (this.mDict == null)
                {
                    return null;
                }
                if ((this.mHash[index] == null) || (this.mDict[index] != null))
                {
                    if (this.mDict.Doc == null)
                    {
                        this.mHash[index] = ColorSpace.Factory(this.mDict[index].Direct);
                    }
                    else
                    {
                        this.mHash[index] = this.mDict.Doc.Resources[this.mDict[index], typeof(ColorSpaceSeparation)];
                    }
                }
                return ((ColorSpaceSeparation) this.mHash[index]);
            }
            set
            {
                PDFDict dict1;
                if (this.mDict == null)
                {
                    if (this.mArr.Count >= 5)
                    {
                        dict1 = Library.CreateDict();
                        this.mDict = dict1;
                        this.mArr[4] = dict1;
                    }
                    else
                    {
                        dict1 = Library.CreateDict();
                        this.mDict = dict1;
                        this.mArr.Add(dict1);
                    }
                }
                this.mDict[index] = value.Direct;
                this.mHash[index] = value;
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
        private PDFArray mArr;
        private PDFDict mDict;
        private Hashtable mHash;
    }
}


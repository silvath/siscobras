namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public sealed class CorePDFArray : CorePDFDirect, PDFArray, PDFDirect, PDFObject, IDisposable, ICloneable, ICollection, IEnumerable
    {
        // Events
        public event ArrayChangeDelegate Cleared;
        public event ArrayChangeDelegate Clearing;
        public event ArrayChangeDelegate Inserted;
        public event ArrayChangeDelegate Inserting;
        public event ArrayChangeDelegate Removed;
        public event ArrayChangeDelegate Removing;
        public event ArrayChangeDelegate Replaced;
        public event ArrayChangeDelegate Replacing;

        // Methods
        internal CorePDFArray(int size)
        {
            int num1;
            this.mArray = new ArrayList();
            for (num1 = 0; (num1 < size); num1 += 1)
            {
                this.mArray.Add(CorePDFNull.Instance);
            }
        }

        private void _Cleared()
        {
            if (this.Cleared != null)
            {
                this.Cleared.Invoke(this, -1, null);
            }
        }

        private void _Clearing()
        {
            if (this.Clearing != null)
            {
                this.Clearing.Invoke(this, -1, null);
            }
        }

        private void _Inserted(int index, PDFObject obj)
        {
            if (this.Inserted != null)
            {
                this.Inserted.Invoke(this, index, obj);
            }
        }

        private void _Inserting(int index, PDFObject obj)
        {
            if (this.Inserting != null)
            {
                this.Inserting.Invoke(this, index, obj);
            }
        }

        private void _Removed(int index)
        {
            if (this.Removed != null)
            {
                this.Removed.Invoke(this, index, null);
            }
        }

        private void _Removing(int index)
        {
            if (this.Removing != null)
            {
                this.Removing.Invoke(this, index, null);
            }
        }

        private void _Replaced(int index, PDFObject obj)
        {
            if (this.Replaced != null)
            {
                this.Replaced.Invoke(this, index, obj);
            }
        }

        private void _Replacing(int index, PDFObject obj)
        {
            if (this.Replacing != null)
            {
                this.Replacing.Invoke(this, index, obj);
            }
        }

        public void Add(PDFObject obj)
        {
            base._Changing();
            this._Inserting(this.Count, obj);
            obj = CorePDFObject.TreatNewCollectionObject(this, obj);
            this.mArray.Add(obj);
            this.Dirty = true;
            this._Inserted((this.Count - 1), obj);
            base._Changed();
        }

        public void Clear()
        {
            base._Changing();
            this._Clearing();
            foreach (CorePDFObject obj1 in this.mArray)
            {
                if ((obj1 == null) || obj1.IsIndirect)
                {
                    continue;
                }
                obj1.Parent = null;
            }
            this.mArray.Clear();
            this.Dirty = true;
            this._Cleared();
            base._Changed();
        }

        public override object Clone()
        {
            int num1;
            PDFObject obj1;
            CorePDFArray array1 = new CorePDFArray(this.Count);
            for (num1 = 0; (num1 < this.Count); num1 += 1)
            {
                obj1 = this[num1, 0];
                array1[num1] = ((obj1 is PDFIndirect) ? obj1 : ((PDFObject) obj1.Clone()));
            }
            return array1;
        }

        public void CopyTo(Array array, int index)
        {
            this.mArray.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return this.mArray.GetEnumerator();
        }

        public void Insert(int pos, PDFObject obj)
        {
            base._Changing();
            this._Inserting(pos, obj);
            obj = CorePDFObject.TreatNewCollectionObject(this, obj);
            this.mArray.Insert(pos, obj);
            this.Dirty = true;
            this._Inserted(pos, obj);
            base._Changed();
        }

        public void Remove(PDFObject obj)
        {
            int num2;
            if (obj.IsIndirect)
            {
                obj = obj.Indirect;
            }
            int num1 = this.Count;
            for (num2 = 0; (num2 < num1); num2 += 1)
            {
                if (obj == this[num2])
                {
                    this.RemoveAt(num2);
                }
            }
        }

        public PDFObject RemoveAt(int index)
        {
            base._Changing();
            this._Removing(index);
            CorePDFObject obj1 = (this.mArray[index] as CorePDFObject);
            if ((obj1 != null) && !obj1.IsIndirect)
            {
                obj1.Parent = null;
            }
            this.mArray.RemoveAt(index);
            this.Dirty = true;
            this._Removed(index);
            base._Changed();
            return obj1;
        }

        internal override void SetDocument(Document doc)
        {
            foreach (CorePDFObject obj1 in this)
            {
                if (obj1.Doc == doc)
                {
                    continue;
                }
                obj1.SetDocument(doc);
            }
        }


        // Properties
        public int Count
        {
            get
            {
                return this.mArray.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return this.mArray.IsSynchronized;
            }
        }

        public PDFObject this[int index, bool getDirect]
        {
            get
            {
                if (index >= this.mArray.Count)
                {
                    return null;
                }
                PDFObject obj1 = ((PDFObject) this.mArray[index]);
                if ((obj1 != null) && getDirect)
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
                return this[index, 1];
            }
            set
            {
                base._Changing();
                CorePDFObject obj1 = null;
                if (index < this.mArray.Count)
                {
                    obj1 = (this.mArray[index] as CorePDFObject);
                }
                else
                {
                    obj1 = null;
                }
                if (obj1 != null)
                {
                    this._Replacing(index, value);
                    if (!obj1.IsIndirect)
                    {
                        obj1.Parent = null;
                    }
                }
                else
                {
                    this._Inserting(index, value);
                }
                value = CorePDFObject.TreatNewCollectionObject(this, value);
                if (index == this.mArray.Count)
                {
                    this.mArray.Add(value);
                }
                else
                {
                    this.mArray[index] = ((object) value);
                }
                this.Dirty = true;
                if (obj1 != null)
                {
                    this._Replaced(index, value);
                }
                else
                {
                    this._Inserted(index, value);
                }
                base._Changed();
            }
        }

        public override PDFObjectType PDFType
        {
            get
            {
                return PDFObjectType.tPDFArray;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this.mArray.SyncRoot;
            }
        }


        // Fields
        private ArrayList mArray;
    }
}


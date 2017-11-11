namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public sealed class CorePDFDict : CorePDFDirect, PDFDict, PDFDirect, PDFObject, IDisposable, ICloneable, ICollection, IEnumerable
    {
        // Events
        public event DictChangeDelegate Cleared;
        public event DictChangeDelegate Clearing;
        public event DictChangeDelegate Inserted;
        public event DictChangeDelegate Inserting;
        public event DictChangeDelegate Removed;
        public event DictChangeDelegate Removing;
        public event DictChangeDelegate Replaced;
        public event DictChangeDelegate Replacing;

        // Methods
        public CorePDFDict()
        {
            this.mHash = new Hashtable();
        }

        private void _Cleared()
        {
            if (this.Cleared != null)
            {
                this.Cleared.Invoke(this, "", null);
            }
        }

        private void _Clearing()
        {
            if (this.Clearing != null)
            {
                this.Clearing.Invoke(this, "", null);
            }
        }

        private void _Inserted(string index, PDFObject obj)
        {
            if (this.Inserted != null)
            {
                this.Inserted.Invoke(this, index, obj);
            }
        }

        private void _Inserting(string index, PDFObject obj)
        {
            if (this.Inserting != null)
            {
                this.Inserting.Invoke(this, index, obj);
            }
        }

        private void _Removed(string index)
        {
            if (this.Removed != null)
            {
                this.Removed.Invoke(this, index, null);
            }
        }

        private void _Removing(string index)
        {
            if (this.Removing != null)
            {
                this.Removing.Invoke(this, index, null);
            }
        }

        private void _Replaced(string index, PDFObject obj)
        {
            if (this.Replaced != null)
            {
                this.Replaced.Invoke(this, index, obj);
            }
        }

        private void _Replacing(string index, PDFObject obj)
        {
            if (this.Replacing != null)
            {
                this.Replacing.Invoke(this, index, obj);
            }
        }

        public void Clear()
        {
            base._Changing();
            this._Clearing();
            foreach (CorePDFObject obj1 in this.mHash.Values)
            {
                if ((obj1 == null) || obj1.IsIndirect)
                {
                    continue;
                }
                obj1.Parent = null;
            }
            this.mHash.Clear();
            this.Dirty = true;
            this._Cleared();
            base._Changed();
        }

        public override object Clone()
        {
            PDFObject obj1;
            CorePDFDict dict1 = new CorePDFDict();
            foreach (DictionaryEntry entry1 in this)
            {
                obj1 = ((PDFObject) entry1.Value);
                dict1[((PDFName) entry1.Key)] = ((obj1 is PDFIndirect) ? obj1 : ((PDFObject) obj1.Clone()));
            }
            return dict1;
        }

        public bool ContainsKey(PDFName key)
        {
            return this.mHash.ContainsKey(key);
        }

        public bool ContainsKey(string key)
        {
            return this.ContainsKey(new CorePDFName(key));
        }

        public bool ContainsValue(PDFObject val)
        {
            return this.mHash.ContainsValue(val);
        }

        public void CopyTo(Array array, int index)
        {
            this.mHash.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return this.mHash.GetEnumerator();
        }

        public PDFObject Remove(PDFName key)
        {
            base._Changing();
            this._Removing(key.Value);
            CorePDFObject obj1 = (this.mHash[key] as CorePDFObject);
            if ((obj1 != null) && !obj1.IsIndirect)
            {
                obj1.Parent = null;
            }
            this.mHash.Remove(key);
            this.Dirty = true;
            this._Removed(key.Value);
            base._Changed();
            return obj1;
        }

        public PDFObject Remove(string key)
        {
            return this.Remove(new CorePDFName(key));
        }

        internal override void SetDocument(Document doc)
        {
            foreach (CorePDFObject obj1 in this.Values)
            {
                obj1.SetDocument(doc);
            }
        }


        // Properties
        public int Count
        {
            get
            {
                return this.mHash.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return this.mHash.IsSynchronized;
            }
        }

        public PDFObject this[string key, bool getDirect]
        {
            get
            {
                return this[new CorePDFName(key), getDirect];
            }
        }

        public PDFObject this[PDFName key, bool getDirect]
        {
            get
            {
                PDFObject obj1 = ((PDFObject) this.mHash[key]);
                if ((obj1 != null) && getDirect)
                {
                    obj1 = obj1.Direct;
                }
                return obj1;
            }
        }

        public PDFObject this[PDFName key]
        {
            get
            {
                return this[key, 1];
            }
            set
            {
                base._Changing();
                CorePDFObject obj1 = (this.mHash[key] as CorePDFObject);
                if (obj1 != null)
                {
                    this._Replacing(key.Value, value);
                    if (!obj1.IsIndirect)
                    {
                        obj1.Parent = null;
                    }
                }
                else
                {
                    this._Inserting(key.Value, value);
                }
                value = CorePDFObject.TreatNewCollectionObject(this, value);
                if (!this.mHash.ContainsKey(key))
                {
                    if (key.Parent != null)
                    {
                        key = new CorePDFName(key.Value);
                    }
                    key.Parent = this;
                }
                this.mHash[key] = ((object) value);
                this.Dirty = true;
                if (obj1 != null)
                {
                    this._Replaced(key.Value, value);
                }
                else
                {
                    this._Inserted(key.Value, value);
                }
                base._Changed();
            }
        }

        public PDFObject this[string key]
        {
            get
            {
                return this[new CorePDFName(key), 1];
            }
            set
            {
                this[new CorePDFName(key)] = value;
            }
        }

        public ICollection Keys
        {
            get
            {
                return this.mHash.Keys;
            }
        }

        public override PDFObjectType PDFType
        {
            get
            {
                return PDFObjectType.tPDFDict;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this.mHash.SyncRoot;
            }
        }

        public ICollection Values
        {
            get
            {
                return this.mHash.Values;
            }
        }


        // Fields
        private Hashtable mHash;
    }
}


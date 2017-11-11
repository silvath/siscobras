namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;
    using System.Runtime.CompilerServices;

    public abstract class CorePDFObject : PDFObject, IDisposable, ICloneable
    {
        // Events
        public event ObjectChangeDelegate Changed;
        public event ObjectChangeDelegate Changing;

        // Methods
        static CorePDFObject()
        {
            CorePDFObject._id = ((long) 0);
        }

        public CorePDFObject()
        {
            this.mID = Interlocked.Increment(ref CorePDFObject._id);
        }

        internal void _Changed()
        {
            if (this.Changed != null)
            {
                this.Changed.Invoke(this);
            }
        }

        internal void _Changing()
        {
            if (this.Changing != null)
            {
                this.Changing.Invoke(this);
            }
        }

        public virtual object Clone()
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
        }

        internal virtual void SetDocument(Document doc)
        {
        }

        internal static PDFObject TreatNewCollectionObject(PDFDirect collection, PDFObject o)
        {
            if (!o.IsIndirect)
            {
                if (o.Parent != null)
                {
                    o = ((PDFObject) o.Clone());
                }
                if (o.PDFType == PDFObjectType.tPDFStream)
                {
                    if (collection.Doc != null)
                    {
                        o = collection.Doc.Indirects.New(o.Direct);
                    }
                    else
                    {
                        o = Library.CreateIndirect(o.Direct);
                    }
                }
                o.Parent = collection;
                return o;
            }
            if (((o.Doc != collection.Doc) && (o.Doc != null)) && (collection.Doc != null))
            {
                throw new InvalidOperationException("Can not connect objects from different documents");
            }
            if ((o.Doc == null) && (collection.Doc != null))
            {
                ((CorePDFObject) o.Indirect).SetDocument(collection.Doc);
            }
            return o.Indirect;
        }


        // Properties
        public abstract PDFDirect Direct { get; set; }

        public abstract bool Dirty { get; set; }

        public abstract Document Doc { get; }

        public abstract PDFIndirect Indirect { get; }

        public abstract bool IsIndirect { get; }

        public PDFObject Parent
        {
            get
            {
                return this.mParent;
            }
            set
            {
                try
                {
                    this.mParent = ((CorePDFObject) value);
                }
                catch (InvalidCastException)
                {
                    throw new ArgumentException("value", "Parent object must be created by the same library");
                }
            }
        }

        public abstract PDFObjectType PDFType { get; }

        public long UniqueID
        {
            get
            {
                return this.mID;
            }
        }


        // Fields
        private static long _id;
        private long mID;
        protected CorePDFObject mParent;
    }
}


namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;

    public sealed class CorePDFIndirect : CorePDFObject, PDFIndirect, PDFObject, IDisposable, ICloneable
    {
        // Methods
        internal CorePDFIndirect()
        {
            this.mDoc = null;
            this.mId = -1;
        }

        internal CorePDFIndirect(CoreDocument doc, int id)
        {
            this.mDoc = doc;
            this.mId = id;
        }

        public override object Clone()
        {
            if (this.Doc != null)
            {
                return ((object) this.Doc.Indirects.New(this.Direct));
            }
            CorePDFIndirect indirect1 = new CorePDFIndirect();
            indirect1.Direct = ((PDFDirect) this.Direct.Clone());
            return indirect1;
        }

        public PDFDirect DetachDirect()
        {
            PDFDirect direct1 = this.Direct;
            this.mDirect = CorePDFNull.Instance;
            return direct1;
        }

        public override void Dispose()
        {
        }

        public override bool Equals(object obj)
        {
            PDFIndirect indirect1 = (obj as PDFIndirect);
            if (indirect1 == null)
            {
                return false;
            }
            if (this.mId == indirect1.Id)
            {
                return (this.Doc == indirect1.Doc);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        internal override void SetDocument(Document doc)
        {
            if (doc == this.mDoc)
            {
                return;
            }
            if (this.mDoc != null)
            {
                throw new InvalidOperationException("Can\'t change ownership of indirect object");
            }
            this.mDoc = ((CoreDocument) doc);
            ((CoreIndirectCollection) doc.Indirects).Insert(this);
            ((CorePDFDirect) this.Direct).SetDocument(doc);
        }


        // Properties
        public override PDFDirect Direct
        {
            get
            {
                CorePDFStream stream1;
                if ((this.mDirect == null) && (this.mDoc != null))
                {
                    this.mDirect = this.mDoc.ReadDirect(this.mId);
                    if (this.mDoc.Encryption != null)
                    {
                        stream1 = (this.mDirect as CorePDFStream);
                        if (stream1 != null)
                        {
                            stream1.mEncGen = this.Generation;
                            stream1.mEncId = this.Id;
                        }
                    }
                    this.mDirect.Parent = this;
                }
                if (this.mDirect == null)
                {
                    this.mDirect = CorePDFNull.Instance;
                }
                return this.mDirect;
            }
            set
            {
                this.DetachDirect();
                if (value == null)
                {
                    this.mDirect = CorePDFNull.Instance;
                }
                else
                {
                    this.mDirect = ((CorePDFDirect) value);
                    value.Parent = this;
                }
                this.Dirty = true;
            }
        }

        public override bool Dirty
        {
            get
            {
                if (this.mDoc == null)
                {
                    return true;
                }
                return ((XRefEntry) this.mDoc.mXRef[this.mId]).dirty;
            }
            set
            {
                if (this.mDoc == null)
                {
                    return;
                }
                if (((this.mDoc.mToSaveQueue != null) && !((XRefEntry) this.mDoc.mXRef[this.mId]).dirty) && value)
                {
                    this.mDoc.mToSaveQueue.Enqueue(this);
                }
                ((XRefEntry) this.mDoc.mXRef[this.mId]).dirty = value;
            }
        }

        public override Document Doc
        {
            get
            {
                return this.mDoc;
            }
        }

        public int Generation
        {
            get
            {
                if (this.mDoc == null)
                {
                    return -1;
                }
                return ((XRefEntry) this.mDoc.mXRef[this.mId]).generation;
            }
        }

        public int Id
        {
            get
            {
                return this.mId;
            }
        }

        public override PDFIndirect Indirect
        {
            get
            {
                return this;
            }
        }

        public override bool IsIndirect
        {
            get
            {
                return true;
            }
        }

        public override PDFObjectType PDFType
        {
            get
            {
                if (this.Direct == null)
                {
                    return PDFObjectType.tPDFNull;
                }
                return this.Direct.PDFType;
            }
        }


        // Fields
        private CorePDFDirect mDirect;
        private CoreDocument mDoc;
        internal int mId;
    }
}


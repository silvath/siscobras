namespace Altsoft.PDFO
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;

    public abstract class Document : IDisposable
    {
        // Methods
        protected Document()
        {
            this.mPages = null;
            this.mNames = null;
            this.mThreads = null;
            this.mStreamEcodingRuleColl = new StreamEncodingRuleColl();
            this.mResources = null;
            this.mDefCH = new CopyHandlerDelegate(Document.DefaultCopyHandler);
            this.mCH = null;
            this.mCH = new CopyHandlerIdentity(this);
        }

        public PDFObject CloneObject(PDFObject src)
        {
            return this.CloneObject(src, null);
        }

        public PDFObject CloneObject(PDFObject src, CopyHandlerDelegate ch)
        {
            return this.mCH.CopyHandler(src, ch);
        }

        public virtual void Close()
        {
            Resources.RemoveResourcesByDoc(this);
        }

        protected internal abstract PDFIndirect CreateIndirectObject(int objNr, int gen);

        public static PDFObject DefaultCopyHandler(Document dstDoc, PDFObject src)
        {
            PDFIndirect indirect1;
            PDFStream stream1;
            if (src == null)
            {
                return Library.CreateNull();
            }
            if ((src is PDFIndirect))
            {
                indirect1 = dstDoc.Indirects.New();
                indirect1.Direct = ((PDFDirect) Document.DefaultCopyHandler(dstDoc, src.Direct));
                return indirect1;
            }
            PDFDirect direct1 = null;
            PDFDirect direct2 = ((PDFDirect) src);
            PDFObjectType type1 = src.PDFType;
            switch (type1)
            {
                case PDFObjectType.tPDFNull:
                {
                    return Library.CreateNull();
                }
                case PDFObjectType.tPDFInteger:
                {
                    return Library.CreateInteger(((PDFInteger) direct2).Value);
                }
                case PDFObjectType.tPDFFixed:
                {
                    return Library.CreateFixed(((PDFFixed) direct2).Value);
                }
                case PDFObjectType.tPDFBoolean:
                {
                    return Library.CreateBoolean(((PDFBoolean) direct2).Value);
                }
                case PDFObjectType.tPDFName:
                {
                    return Library.CreateName(((PDFName) direct2).Value);
                }
                case PDFObjectType.tPDFString:
                {
                    return Library.CreateString(((PDFString) direct2).Value);
                }
                case PDFObjectType.tPDFDict:
                case PDFObjectType.tPDFArray:
                {
                    goto Label_0108;
                }
                case PDFObjectType.tPDFStream:
                {
                    stream1 = ((PDFStream) direct2);
                    return Library.CreateStream(stream1.Decrypt(), ((PDFDict) dstDoc.CloneObject(stream1.Dict)), false);
                }
            }
        Label_0108:
            return Library.CreateDirect(src.PDFType);
        }

        public virtual void Dispose()
        {
            this.Close();
            GC.SuppressFinalize(this);
            this.mPages = null;
            this.mNames = null;
            this.mThreads = null;
        }

        ~Document()
        {
            this.Dispose();
        }

        protected virtual bool Init()
        {
            this.mPages = new PagesCollection(this);
            this.mResources = new DocResourceColl(this);
            this.mNames = new Names(this);
            this.mThreads = new ArticleThreadCollection((this.Root["Threads"] as PDFDirect));
            return true;
        }

        public abstract void Save();

        public void SaveAs(Stream str)
        {
            if (this.Header == "")
            {
                this.SaveAs(str, "%PDF-1.3");
                return;
            }
            this.SaveAs(str, this.Header);
        }

        public void SaveAs(string path)
        {
            if (this.Header == "%PDF-")
            {
                this.SaveAs(path, "%PDF-1.3");
                return;
            }
            this.SaveAs(path, this.Header);
        }

        public abstract void SaveAs(Stream str, string header);

        public abstract void SaveAs(string path, string header);

        public abstract void SaveAs(Stream strm, string header, IEncryption encrypt);

        public abstract void SaveAs(string path, string header, IEncryption encrypt);


        // Properties
        public InteractiveForm AcroForm
        {
            get
            {
                return (Resources.Get((this.Root["AcroForm"] as PDFDirect), typeof(InteractiveForm)) as InteractiveForm);
            }
            set
            {
                this.Root["AcroForm"] = value.Direct;
            }
        }

        public abstract IEncryption Encryption { get; }

        public abstract string Header { get; set; }

        public abstract byte[] Id1 { get; }

        public abstract byte[] Id2 { get; }

        public abstract IndirectCollection Indirects { get; }

        public abstract PDFDict Info { get; set; }

        public bool IsEncrypted
        {
            get
            {
                return (this.Encryption != null);
            }
        }

        public Names Names
        {
            get
            {
                return this.mNames;
            }
        }

        public Outlines Outlines
        {
            get
            {
                PDFDict dict1;
                if (this.mOutlines == null)
                {
                    dict1 = (this.Root["Outlines"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mOutlines = (Resources.Get(dict1, typeof(Outlines)) as Outlines);
                    }
                    else
                    {
                        this.mOutlines = Outlines.Create(this.Root);
                    }
                }
                return this.mOutlines;
            }
        }

        public EPageMode PageMode
        {
            get
            {
                PDFName name1 = (this.Root["PageMode"] as PDFName);
                if (name1 == null)
                {
                    return EPageMode.UseNone;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_005D;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "UseOutlines")
                {
                    if (text1 == "UseOS")
                    {
                        goto Label_0059;
                    }
                    if (text1 == "Thumbs")
                    {
                        goto Label_005B;
                    }
                    goto Label_005D;
                }
                return EPageMode.UseOutlines;
            Label_0059:
                return EPageMode.UseOC;
            Label_005B:
                return EPageMode.UseThumbs;
            Label_005D:
                return EPageMode.UseNone;
            }
            set
            {
                string text1 = "";
                EPageMode mode1 = value;
                switch (mode1)
                {
                    case EPageMode.UseOutlines:
                    {
                        text1 = "UseOutlines";
                        goto Label_003C;
                    }
                    case EPageMode.UseThumbs:
                    {
                        text1 = "Thumbs";
                        goto Label_003C;
                    }
                    case EPageMode.UseOC:
                    {
                        text1 = "UseOS";
                        goto Label_003C;
                    }
                }
                text1 = "UseNone";
            Label_003C:
                this.Root["PageMode"] = Library.CreateName(text1);
            }
        }

        public PagesCollection Pages
        {
            get
            {
                return this.mPages;
            }
        }

        public abstract string Path { get; }

        public DocResourceColl Resources
        {
            get
            {
                return this.mResources;
            }
        }

        public abstract PDFDict Root { get; }

        public StreamEncodingRuleColl StreamEncodingRules
        {
            get
            {
                return this.mStreamEcodingRuleColl;
            }
        }

        public ArticleThreadCollection Threads
        {
            get
            {
                return this.mThreads;
            }
        }

        public ViewerPreferences ViewerPreferences
        {
            get
            {
                PDFDict dict1 = (this.Root["ViewerPreferences"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(ViewerPreferences)) as ViewerPreferences);
            }
        }

        public abstract PDFWriter Writer { get; set; }


        // Fields
        public Library Library;
        private CopyHandlerIdentity mCH;
        private CopyHandlerDelegate mDefCH;
        private Names mNames;
        private Outlines mOutlines;
        private PagesCollection mPages;
        private DocResourceColl mResources;
        private StreamEncodingRuleColl mStreamEcodingRuleColl;
        private ArticleThreadCollection mThreads;

        // Nested Types
        public delegate PDFObject CopyHandlerDelegate(Document dstDoc, PDFObject src);

    }
}


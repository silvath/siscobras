namespace Altsoft.PDFO
{
    using System;

    public class Names
    {
        // Methods
        internal Names(Document doc)
        {
            this.mDoc = doc;
            this.mDests = new NamedDestinations(doc);
        }


        // Properties
        public NameTree AlternatePresentations
        {
            get
            {
                if (this.mDict == null)
                {
                    return null;
                }
                if (this.mAlternatePresentations != null)
                {
                    return this.mAlternatePresentations;
                }
                PDFDirect direct1 = (this.mDict["AlternatePresentations"] as PDFDirect);
                if (direct1 != null)
                {
                    this.mAlternatePresentations = new NameTree(this.mDict, "AlternatePresentations", -1);
                }
                return this.mAlternatePresentations;
            }
            set
            {
                if (this.mDict == null)
                {
                    this.mDict = Library.CreateDict();
                }
                this.mAlternatePresentations = value;
                this.mDict["AlternatePresentations"] = value.Dict;
            }
        }

        public NameTree Appearances
        {
            get
            {
                if (this.mDict == null)
                {
                    return null;
                }
                if (this.mApp != null)
                {
                    return this.mApp;
                }
                PDFDirect direct1 = (this.mDict["AP"] as PDFDirect);
                if (direct1 != null)
                {
                    this.mApp = new NameTree(this.mDict, "AP", -1);
                }
                return this.mApp;
            }
            set
            {
                if (this.mDict == null)
                {
                    this.mDict = Library.CreateDict();
                }
                this.mApp = value;
                this.mDict["AP"] = value.Dict;
            }
        }

        public NamedDestinations Destinations
        {
            get
            {
                return this.mDests;
            }
        }

        public PDFDict Dict
        {
            get
            {
                return this.mDict;
            }
        }

        public NameTree EmbeddedFiles
        {
            get
            {
                if (this.mDict == null)
                {
                    return null;
                }
                if (this.mEmbeddedFiles != null)
                {
                    return this.mEmbeddedFiles;
                }
                PDFDirect direct1 = (this.mDict["EmbeddedFiles"] as PDFDirect);
                if (direct1 != null)
                {
                    this.mEmbeddedFiles = new NameTree(this.mDict, "EmbeddedFiles", -1);
                }
                return this.mEmbeddedFiles;
            }
            set
            {
                if (this.mDict == null)
                {
                    this.mDict = Library.CreateDict();
                }
                this.mEmbeddedFiles = value;
                this.mDict["EmbeddedFiles"] = value.Dict;
            }
        }

        public NameTree IDSs
        {
            get
            {
                if (this.mDict == null)
                {
                    return null;
                }
                if (this.mIDSs != null)
                {
                    return this.mIDSs;
                }
                PDFDirect direct1 = (this.mDict["IDS"] as PDFDirect);
                if (direct1 != null)
                {
                    this.mIDSs = new NameTree(this.mDict, "IDS", -1);
                }
                return this.mIDSs;
            }
            set
            {
                if (this.mDict == null)
                {
                    this.mDict = Library.CreateDict();
                }
                this.mIDSs = value;
                this.mDict["IDS"] = value.Dict;
            }
        }

        public NameTree JavaScripts
        {
            get
            {
                if (this.mDict == null)
                {
                    return null;
                }
                if (this.mJavaScripts != null)
                {
                    return this.mJavaScripts;
                }
                PDFDirect direct1 = (this.mDict["JavaScript"] as PDFDirect);
                if (direct1 != null)
                {
                    this.mJavaScripts = new NameTree(this.mDict, "JavaScript", -1);
                }
                return this.mJavaScripts;
            }
            set
            {
                if (this.mDict == null)
                {
                    this.mDict = Library.CreateDict();
                }
                this.mJavaScripts = value;
                this.mDict["JavaScript"] = value.Dict;
            }
        }

        public NameTree Pages
        {
            get
            {
                if (this.mDict == null)
                {
                    return null;
                }
                if (this.mPages != null)
                {
                    return this.mPages;
                }
                PDFDirect direct1 = (this.mDict["Pages"] as PDFDirect);
                if (direct1 != null)
                {
                    this.mPages = new NameTree(this.mDict, "Pages", -1);
                }
                return this.mPages;
            }
            set
            {
                if (this.mDict == null)
                {
                    this.mDict = Library.CreateDict();
                }
                this.mPages = value;
                this.mDict["Pages"] = value.Dict;
            }
        }

        public NameTree Renditions
        {
            get
            {
                if (this.mDict == null)
                {
                    return null;
                }
                if (this.mRenditions != null)
                {
                    return this.mRenditions;
                }
                PDFDirect direct1 = (this.mDict["Renditions"] as PDFDirect);
                if (direct1 != null)
                {
                    this.mRenditions = new NameTree(this.mDict, "Renditions", -1);
                }
                return this.mRenditions;
            }
            set
            {
                if (this.mDict == null)
                {
                    this.mDict = Library.CreateDict();
                }
                this.mRenditions = value;
                this.mDict["Renditions"] = value.Dict;
            }
        }

        public NameTree Templates
        {
            get
            {
                if (this.mDict == null)
                {
                    return null;
                }
                if (this.mTemplates != null)
                {
                    return this.mTemplates;
                }
                PDFDirect direct1 = (this.mDict["Templates"] as PDFDirect);
                if (direct1 != null)
                {
                    this.mTemplates = new NameTree(this.mDict, "Templates", -1);
                }
                return this.mTemplates;
            }
            set
            {
                if (this.mDict == null)
                {
                    this.mDict = Library.CreateDict();
                }
                this.mTemplates = value;
                this.mDict["Templates"] = value.Dict;
            }
        }

        public NameTree URLs
        {
            get
            {
                if (this.mDict == null)
                {
                    return null;
                }
                if (this.mURLs != null)
                {
                    return this.mURLs;
                }
                PDFDirect direct1 = (this.mDict["URLS"] as PDFDirect);
                if (direct1 != null)
                {
                    this.mURLs = new NameTree(this.mDict, "URLS", -1);
                }
                return this.mURLs;
            }
            set
            {
                if (this.mDict == null)
                {
                    this.mDict = Library.CreateDict();
                }
                this.mURLs = value;
                this.mDict["URLS"] = value.Dict;
            }
        }


        // Fields
        private NameTree mAlternatePresentations;
        private NameTree mApp;
        private NamedDestinations mDests;
        private PDFDict mDict;
        private Document mDoc;
        private NameTree mEmbeddedFiles;
        private NameTree mIDSs;
        private NameTree mJavaScripts;
        private NameTree mPages;
        private NameTree mRenditions;
        private NameTree mTemplates;
        private NameTree mURLs;
    }
}


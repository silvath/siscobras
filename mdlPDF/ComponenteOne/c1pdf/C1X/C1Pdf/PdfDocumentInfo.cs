namespace C1.C1Pdf
{
    using C1.Util.Localization;
    using System;
    using System.ComponentModel;

    public class PdfDocumentInfo
    {
        // Methods
        internal PdfDocumentInfo(C1PdfDocumentBase doc)
        {
            this.P2 = doc;
            string text1 = string.Empty;
            this.P8 = text1;
            text1 = text1;
            this.P7 = text1;
            this.P4 = text1;
            text1 = string.Empty;
            this.P6 = text1;
            this.P5 = text1;
            this.P9 = "ComponentOne C1Pdf";
        }

        internal void 7A()
        {
            DateTime time1 = DateTime.Now;
            time1 = DateTime.Now;
            string text1 = "D:" + time1.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + time1.ToString("HHmmss", CultureInfo.InvariantCulture);
            this.P3 = this.P2.65("Document Information");
            this.P2.67();
            this.P2.69("Title", this.P4, true);
            this.P2.69("Creator", this.P5, true);
            this.P2.69("Author", this.P6, true);
            this.P2.69("Subject", this.P7, true);
            this.P2.69("Keywords", this.P8, true);
            this.P2.69("Producer", this.P9, true);
            this.P2.69("CreationDate", text1, true);
            this.P2.69("ModDate", text1, true);
            this.P2.6B();
            this.P2.66();
        }


        // Properties
        [E("Author", "Gets or sets the name of the person that created the pdf document."), DefaultValue("")]
        public string Author
        {
            get
            {
                return this.P6;
            }
            set
            {
                this.P6 = value;
            }
        }

        [E("Creator", "Gets or sets the name of the application that created the original document."), DefaultValue("")]
        public string Creator
        {
            get
            {
                return this.P5;
            }
            set
            {
                this.P5 = value;
            }
        }

        [E("Keywords", "Gets or sets keywords associated with the pdf document."), DefaultValue("")]
        public string Keywords
        {
            get
            {
                return this.P8;
            }
            set
            {
                this.P8 = value;
            }
        }

        [DefaultValue("ComponentOne C1Pdf"), E("Producer", "Gets or sets the name of the application that created the pdf document.")]
        public string Producer
        {
            get
            {
                return this.P9;
            }
            set
            {
                this.P9 = value;
            }
        }

        [E("Subject", "Gets or sets the subject of the pdf document."), DefaultValue("")]
        public string Subject
        {
            get
            {
                return this.P7;
            }
            set
            {
                this.P7 = value;
            }
        }

        [E("Title", "Gets or sets the title of the pdf document."), DefaultValue("")]
        public string Title
        {
            get
            {
                return this.P4;
            }
            set
            {
                this.P4 = value;
            }
        }


        // Fields
        internal C1PdfDocumentBase P2;
        internal int P3;
        internal string P4;
        internal string P5;
        internal string P6;
        internal string P7;
        internal string P8;
        internal string P9;
    }
}


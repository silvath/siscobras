namespace Altsoft.PDFO
{
    using System;

    public class ArticleThread : Resource
    {
        // Methods
        public ArticleThread(PDFDirect direct) : base(direct)
        {
            this.mFirstBead = null;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new ArticleThread(direct);
        }


        // Properties
        public DocInfo DocumentInfo
        {
            get
            {
                if (this.mDocumentInfo != null)
                {
                    return this.mDocumentInfo;
                }
                PDFDict dict1 = (this.Dict["I"] as PDFDict);
                if (dict1 != null)
                {
                    this.mDocumentInfo = new DocInfo(dict1);
                }
                return this.mDocumentInfo;
            }
            set
            {
                this.mDocumentInfo = value;
                this.Dict["I"] = this.mDocumentInfo.mDict;
            }
        }

        public ArticleBead FirstBead
        {
            get
            {
                if (this.mFirstBead != null)
                {
                    return this.mFirstBead;
                }
                PDFDict dict1 = (this.Dict["F"] as PDFDict);
                if (dict1 != null)
                {
                    this.mFirstBead = new ArticleBead(dict1);
                }
                return this.mFirstBead;
            }
            set
            {
                this.mFirstBead = value;
                this.Dict["F"] = this.mFirstBead.Dict;
            }
        }

        public string Type
        {
            get
            {
                return "Thread";
            }
        }


        // Fields
        private DocInfo mDocumentInfo;
        private ArticleBead mFirstBead;
    }
}


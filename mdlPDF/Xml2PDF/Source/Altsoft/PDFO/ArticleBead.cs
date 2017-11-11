namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class ArticleBead : Resource
    {
        // Methods
        public ArticleBead(PDFDirect direct) : base(direct)
        {
            this.mThread = null;
            this.mNextBead = null;
            this.mPrevBead = null;
            this.mBeadRect = null;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new ArticleBead(direct);
        }


        // Properties
        public Rect BeadRect
        {
            get
            {
                PDFArray array1;
                double[] numArray1;
                if (this.mBeadRect == null)
                {
                    array1 = (this.Dict["MediaBox"] as PDFArray);
                    numArray1 = new double[4];
                    if (array1 != null)
                    {
                        Library.CopyArray(array1, 0, 4, numArray1, 0);
                    }
                    this.mBeadRect = new PDFRect(this.Dict, "R", numArray1);
                }
                return this.mBeadRect;
            }
            set
            {
                this.BeadRect.Set(value);
            }
        }

        public ArticleBead NextBead
        {
            get
            {
                if (this.mNextBead != null)
                {
                    return this.mNextBead;
                }
                PDFDict dict1 = (this.Dict["N"] as PDFDict);
                if (dict1 == null)
                {
                    return this.mNextBead;
                }
                this.mNextBead = (Resources.Get(dict1, typeof(ArticleBead)) as ArticleBead);
                if (this.mNextBead == null)
                {
                    this.mNextBead = new ArticleBead(dict1);
                }
                return this.mNextBead;
            }
            set
            {
                this.mNextBead = value;
                this.Dict["N"] = this.mNextBead.Dict;
            }
        }

        public Page ParentPage
        {
            get
            {
                if (this.mPageParent != null)
                {
                    return this.mPageParent;
                }
                PDFDict dict1 = (this.Dict["P"] as PDFDict);
                if (dict1 != null)
                {
                    this.mPageParent = new Page(dict1);
                }
                return this.mPageParent;
            }
            set
            {
                this.mPageParent = value;
                this.Dict["P"] = this.mPageParent.Dict;
            }
        }

        public ArticleBead PrevBead
        {
            get
            {
                if (this.mPrevBead != null)
                {
                    return this.mPrevBead;
                }
                PDFDict dict1 = (this.Dict["V"] as PDFDict);
                if (dict1 == null)
                {
                    return this.mPrevBead;
                }
                this.mPrevBead = (Resources.Get(dict1, typeof(ArticleBead)) as ArticleBead);
                if (this.mPrevBead == null)
                {
                    this.mPrevBead = new ArticleBead(dict1);
                }
                return this.mPrevBead;
            }
            set
            {
                this.mPrevBead = value;
                this.Dict["V"] = this.mPrevBead.Dict;
            }
        }

        public ArticleThread Thread
        {
            get
            {
                if (this.mThread != null)
                {
                    return this.mThread;
                }
                PDFDict dict1 = (this.Dict["T"] as PDFDict);
                if (dict1 == null)
                {
                    return this.mThread;
                }
                this.mThread = (Resources.Get(dict1, typeof(ArticleThread)) as ArticleThread);
                if (this.mThread == null)
                {
                    this.mThread = new ArticleThread(dict1);
                }
                return this.mThread;
            }
            set
            {
                this.mThread = value;
                this.Dict["T"] = this.mThread.Dict;
            }
        }

        public string Type
        {
            get
            {
                return "Bead";
            }
        }


        // Fields
        private PDFRect mBeadRect;
        private ArticleBead mNextBead;
        private Page mPageParent;
        private ArticleBead mPrevBead;
        private ArticleThread mThread;
    }
}


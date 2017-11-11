namespace Altsoft.PDFO
{
    using System;

    public class ActionThread : Action
    {
        // Methods
        public ActionThread(PDFDirect direct) : base(direct)
        {
        }

        public static ActionThread Create(ArticleThread thread)
        {
            ActionThread thread1 = ActionThread.Create(true);
            thread1.DestThread = thread;
            return thread1;
        }

        private static ActionThread Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Thread");
            ActionThread thread1 = (Resources.Get(dict1, typeof(ActionThread)) as ActionThread);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return thread1;
        }

        public static ActionThread Create(ArticleThread thread, ArticleBead bead)
        {
            ActionThread thread1 = ActionThread.Create(true);
            thread1.DestThread = thread;
            thread1.Bead = bead;
            return thread1;
        }

        public static ActionThread Create(ArticleThread thread, FileSpec filespec)
        {
            ActionThread thread1 = ActionThread.Create(true);
            thread1.DestThread = thread;
            thread1.FileSpecification = filespec;
            return thread1;
        }

        public static ActionThread Create(bool indirect, ArticleThread thread)
        {
            ActionThread thread1 = ActionThread.Create(indirect);
            thread1.DestThread = thread;
            return thread1;
        }

        public static ActionThread Create(ArticleThread thread, FileSpec filespec, ArticleBead bead)
        {
            ActionThread thread1 = ActionThread.Create(true);
            thread1.DestThread = thread;
            thread1.FileSpecification = filespec;
            thread1.Bead = bead;
            return thread1;
        }

        public static ActionThread Create(bool indirect, ArticleThread thread, ArticleBead bead)
        {
            ActionThread thread1 = ActionThread.Create(indirect);
            thread1.DestThread = thread;
            thread1.Bead = bead;
            return thread1;
        }

        public static ActionThread Create(bool indirect, ArticleThread thread, FileSpec filespec)
        {
            ActionThread thread1 = ActionThread.Create(indirect);
            thread1.DestThread = thread;
            thread1.FileSpecification = filespec;
            return thread1;
        }

        public static ActionThread Create(bool indirect, ArticleThread thread, FileSpec filespec, ArticleBead bead)
        {
            ActionThread thread1 = ActionThread.Create(indirect);
            thread1.DestThread = thread;
            thread1.FileSpecification = filespec;
            thread1.Bead = bead;
            return thread1;
        }


        // Properties
        public ArticleBead Bead
        {
            get
            {
                PDFObjectType type1 = this.Dict["B"].PDFType;
                if (type1 != PDFObjectType.tPDFInteger)
                {
                    if (type1 == PDFObjectType.tPDFDict)
                    {
                        goto Label_0059;
                    }
                    goto Label_0083;
                }
                ArticleBead bead1 = this.DestThread.FirstBead;
                int num1 = (this.Dict["B"] as PDFInteger).Int32Value;
                goto Label_0050;
            Label_0049:
                bead1 = bead1.NextBead;
            Label_0050:
                int num2 = num1;
                num1 = (num2 - 1);
                if (num1 != 0)
                {
                    goto Label_0049;
                }
                return bead1;
            Label_0059:
                return (Resources.Get((this.Dict["B"] as PDFDict), typeof(ArticleThread)) as ArticleBead);
            Label_0083:
                throw new Exception("Illegal bead reference type");
            }
            set
            {
                this.Dict["B"] = value.Dict;
            }
        }

        public ArticleThread DestThread
        {
            get
            {
                ArticleThreadCollection collection1;
                int num1;
                PDFObjectType type1 = this.Dict["D"].PDFType;
                if (type1 != PDFObjectType.tPDFInteger)
                {
                    switch (type1)
                    {
                        case PDFObjectType.tPDFString:
                        {
                            collection1 = this.Dict.Doc.Threads;
                            num1 = 0;
                            goto Label_00DC;
                        }
                        case PDFObjectType.tPDFDict:
                        {
                            goto Label_005F;
                        }
                    }
                    goto Label_00E7;
                }
                return this.Dict.Doc.Threads[(this.Dict["D"] as PDFInteger).Int32Value];
            Label_005F:
                return (Resources.Get((this.Dict["D"] as PDFDict), typeof(ArticleThread)) as ArticleThread);
            Label_009E:
                if (collection1[num1].DocumentInfo.Title == (this.Dict["D"] as PDFString).Value)
                {
                    return collection1[num1];
                }
                num1 += 1;
            Label_00DC:
                if (num1 < collection1.Count)
                {
                    goto Label_009E;
                }
                return null;
            Label_00E7:
                throw new Exception("Illegal destination thread type");
            }
            set
            {
                this.Dict["D"] = value.Dict;
            }
        }

        public FileSpec FileSpecification
        {
            get
            {
                return (Resources.Get(this.Dict["F"], typeof(FileSpec)) as FileSpec);
            }
            set
            {
                this.Dict["F"] = Library.CreateString(value.Path);
            }
        }


        // Fields
        public const string Type = "Thread";
    }
}


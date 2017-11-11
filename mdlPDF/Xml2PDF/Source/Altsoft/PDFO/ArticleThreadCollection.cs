namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class ArticleThreadCollection : ComplexObjectArrayDirect
    {
        // Methods
        public ArticleThreadCollection(PDFDirect direct) : base(direct, false)
        {
        }

        public void Add(ArticleThread value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(ArticleThread));
        }

        public static ArticleThreadCollection Create(Document doc)
        {
            return new ArticleThreadCollection((doc.Root["Dests"] as PDFDirect));
        }

        public void Remove(ArticleThread value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public ArticleThread this[int index]
        {
            get
            {
                return (base._GetObject(index) as ArticleThread);
            }
            set
            {
                base._SetObject(index, value, value.Direct);
            }
        }

    }
}


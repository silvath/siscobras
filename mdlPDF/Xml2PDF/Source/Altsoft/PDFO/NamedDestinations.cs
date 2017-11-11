namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class NamedDestinations
    {
        // Methods
        public NamedDestinations(Document doc)
        {
            this.mDoc = doc;
            this.mTree = new NameTree((doc.Root["Names"] as PDFDict), "Dests", 2147483647);
        }


        // Properties
        public LinkDestination this[string index]
        {
            get
            {
                return (Resources.Get(this.mTree[index], typeof(LinkDestination)) as LinkDestination);
            }
            set
            {
                PDFDict dict1 = (this.mDoc.Root["Names"] as PDFDict);
                this.mTree.mParentDict = dict1;
                if (dict1 == null)
                {
                    dict1 = Library.CreateDict();
                    this.mTree.mParentDict = dict1;
                    this.mDoc.Root["Names"] = dict1;
                }
                this.mTree[index] = this.mDoc.Indirects.New(value.Direct);
            }
        }


        // Fields
        private Document mDoc;
        private NameTree mTree;
    }
}


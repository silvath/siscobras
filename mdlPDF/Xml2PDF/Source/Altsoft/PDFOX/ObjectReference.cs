namespace Altsoft.PDFO
{
    using System;

    public class ObjectReference : Resource
    {
        // Methods
        public ObjectReference(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new ObjectReference(direct);
        }


        // Properties
        internal PDFObject Owner
        {
            get
            {
                PDFDirect direct1 = (this.Dict["StmOwn"] as PDFDirect);
                if (direct1 == null)
                {
                    return null;
                }
                return (Resources.Get(direct1, typeof(PDFObject)) as PDFObject);
            }
            set
            {
                this.Dict["StmOwn"] = value.Direct;
            }
        }

        public Page Page
        {
            get
            {
                PDFDirect direct1 = (this.Dict["PG"] as PDFDirect);
                if (direct1 == null)
                {
                    return null;
                }
                return (Resources.Get(direct1, typeof(Page)) as Page);
            }
            set
            {
                this.Dict["PG"] = value.Dict;
            }
        }


        // Fields
        public const string Type = "OBJR";
    }
}


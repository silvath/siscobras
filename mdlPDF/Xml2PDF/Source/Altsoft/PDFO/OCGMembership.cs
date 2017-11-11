namespace Altsoft.PDFO
{
    using System;

    public class OCGMembership : Resource
    {
        // Methods
        public OCGMembership(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new OCGMembership(direct);
        }


        // Properties
        public OCGCollection OptContentCollection
        {
            get
            {
                if (this.mOptContent != null)
                {
                    return null;
                }
                PDFObject obj1 = this.Dict["OCGs"];
                if (obj1 == null)
                {
                    return null;
                }
                return new OCGCollection(this.Dict, "OCGs", true);
            }
            set
            {
                this.mOptContent = value;
                this.Dict["OCGs"] = this.mOptContent.mBaseDict;
            }
        }

        public string Type
        {
            get
            {
                return "OCMD";
            }
        }

        public EVisiblePolicy VisiblePolicy
        {
            get
            {
                PDFName name1 = (this.Dict["P"] as PDFName);
                if (name1 == null)
                {
                    return EVisiblePolicy.AnyOn;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_006C;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "AllOn")
                {
                    if (text1 == "AnyOn")
                    {
                        goto Label_0066;
                    }
                    if (text1 == "AnyOff")
                    {
                        goto Label_0068;
                    }
                    if (text1 == "AllOff")
                    {
                        goto Label_006A;
                    }
                    goto Label_006C;
                }
                return EVisiblePolicy.AllOn;
            Label_0066:
                return EVisiblePolicy.AnyOn;
            Label_0068:
                return EVisiblePolicy.AnyOff;
            Label_006A:
                return EVisiblePolicy.AllOff;
            Label_006C:
                throw new Exception("Unknown visibility policy");
            }
            set
            {
                string text1 = "";
                EVisiblePolicy policy1 = value;
                switch (policy1)
                {
                    case EVisiblePolicy.AllOn:
                    {
                        text1 = "AllOn";
                        goto Label_003E;
                    }
                    case EVisiblePolicy.AnyOn:
                    {
                        text1 = "AnyOn";
                        goto Label_003E;
                    }
                    case EVisiblePolicy.AnyOff:
                    {
                        text1 = "AnyOff";
                        goto Label_003E;
                    }
                    case EVisiblePolicy.AllOff:
                    {
                        goto Label_0038;
                    }
                }
                goto Label_003E;
            Label_0038:
                text1 = "AllOff";
            Label_003E:
                this.Dict["P"] = Library.CreateName(text1);
            }
        }


        // Fields
        private OCGCollection mOptContent;
    }
}


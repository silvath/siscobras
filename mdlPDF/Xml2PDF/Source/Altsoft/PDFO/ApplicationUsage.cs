namespace Altsoft.PDFO
{
    using System;

    public class ApplicationUsage : Resource
    {
        // Methods
        public ApplicationUsage(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new ApplicationUsage(direct);
        }


        // Properties
        public NameList Category
        {
            get
            {
                if (this.mCategory != null)
                {
                    return this.mCategory;
                }
                PDFDict dict1 = (this.Dict["Category"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return new NameList(dict1, "Category", false);
            }
            set
            {
                this.mCategory = value;
            }
        }

        public EEvent Event
        {
            get
            {
                string text1 = (this.Dict["Event"] as PDFName).Value;
                if (text1 == null)
                {
                    goto Label_0056;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "View")
                {
                    if (text1 == "Print")
                    {
                        goto Label_0052;
                    }
                    if (text1 == "Export")
                    {
                        goto Label_0054;
                    }
                    goto Label_0056;
                }
                return EEvent.View;
            Label_0052:
                return EEvent.Print;
            Label_0054:
                return EEvent.Export;
            Label_0056:
                throw new Exception("Unknown event");
            }
            set
            {
                string text1 = "";
                EEvent event1 = value;
                switch (event1)
                {
                    case EEvent.View:
                    {
                        text1 = "View";
                        goto Label_0032;
                    }
                    case EEvent.Print:
                    {
                        text1 = "Print";
                        goto Label_0032;
                    }
                    case EEvent.Export:
                    {
                        goto Label_002C;
                    }
                }
                goto Label_0032;
            Label_002C:
                text1 = "Export";
            Label_0032:
                this.Dict["Event"] = Library.CreateName(text1);
            }
        }

        public OCGCollection OptContentCollection
        {
            get
            {
                if (this.mOptContent != null)
                {
                    return null;
                }
                PDFObject obj1 = this.Dict["On"];
                if (obj1 == null)
                {
                    return null;
                }
                return new OCGCollection(this.Dict, "OCGs", false);
            }
            set
            {
                this.mOptContent = value;
            }
        }


        // Fields
        private NameList mCategory;
        private OCGCollection mOptContent;
    }
}


namespace Altsoft.PDFO
{
    using System;

    public class SignatureLock : Resource
    {
        // Methods
        public SignatureLock(PDFDict dict) : base(dict)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new SignatureLock((direct as PDFDict));
        }


        // Properties
        public EAction Action
        {
            get
            {
                string text1 = (this.Dict["Action"] as PDFName).Value;
                if (text1 == null)
                {
                    goto Label_0056;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "All")
                {
                    if (text1 == "Include")
                    {
                        goto Label_0052;
                    }
                    if (text1 == "Exclude")
                    {
                        goto Label_0054;
                    }
                    goto Label_0056;
                }
                return EAction.All;
            Label_0052:
                return EAction.Include;
            Label_0054:
                return EAction.Exclude;
            Label_0056:
                throw new Exception("Unknown Action value");
            }
            set
            {
                string text1 = "";
                EAction action1 = value;
                switch (action1)
                {
                    case EAction.All:
                    {
                        text1 = "All";
                        goto Label_0032;
                    }
                    case EAction.Include:
                    {
                        text1 = "Include";
                        goto Label_0032;
                    }
                    case EAction.Exclude:
                    {
                        goto Label_002C;
                    }
                }
                goto Label_0032;
            Label_002C:
                text1 = "Exclude";
            Label_0032:
                this.Dict["Action"] = Library.CreateName(text1);
            }
        }

        public StringList Fields
        {
            get
            {
                if (this.mFields != null)
                {
                    return this.mFields;
                }
                return new StringList(this.Dict, "Fields", false);
            }
            set
            {
                this.mFields = value;
            }
        }

        public string Type
        {
            get
            {
                return "SigFieldLock";
            }
        }


        // Fields
        private StringList mFields;
    }
}


namespace Altsoft.PDFO
{
    using System;

    public class FieldMDP : Resource
    {
        // Methods
        public FieldMDP(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new FieldMDP(direct);
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

        public string Type
        {
            get
            {
                return "TransformParams";
            }
        }

        public double Version
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["V"] as PDFFixed);
                if (fixed1 == null)
                {
                    return 1f;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["V"] = Library.CreateFixed(value);
            }
        }

    }
}


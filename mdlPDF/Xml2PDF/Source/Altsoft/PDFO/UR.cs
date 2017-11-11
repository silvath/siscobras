namespace Altsoft.PDFO
{
    using System;

    public class UR : Resource
    {
        // Methods
        public UR(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new UR(direct);
        }


        // Properties
        public NameList FormUsageRights
        {
            get
            {
                if (this.mFormUsageRights != null)
                {
                    return this.mFormUsageRights;
                }
                PDFDict dict1 = (this.Dict["Form"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return new NameList(dict1, "Form", false);
            }
            set
            {
                this.mFormUsageRights = value;
            }
        }

        public string Message
        {
            get
            {
                PDFString text1 = (this.Dict["Msg"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["Msg"] = Library.CreateString(value);
            }
        }

        public NameList SignUsageRights
        {
            get
            {
                if (this.mSignUsageRights != null)
                {
                    return this.mSignUsageRights;
                }
                PDFDict dict1 = (this.Dict["Signature"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return new NameList(dict1, "Signature", false);
            }
            set
            {
                this.mSignUsageRights = value;
            }
        }

        public string Type
        {
            get
            {
                return "TransformParams";
            }
        }

        public NameList UsageRights
        {
            get
            {
                if (this.mUsageRights != null)
                {
                    return this.mUsageRights;
                }
                PDFDict dict1 = (this.Dict["Document"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return new NameList(dict1, "Document", false);
            }
            set
            {
                this.mUsageRights = value;
            }
        }

        public double Version
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["V"] as PDFFixed);
                if (fixed1 == null)
                {
                    return 2f;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["V"] = Library.CreateFixed(value);
            }
        }


        // Fields
        private NameList mFormUsageRights;
        private NameList mSignUsageRights;
        private NameList mUsageRights;
    }
}


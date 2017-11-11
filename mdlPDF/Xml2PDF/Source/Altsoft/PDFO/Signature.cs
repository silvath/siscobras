namespace Altsoft.PDFO
{
    using System;

    public class Signature : Resource
    {
        // Methods
        public Signature(PDFDirect direct) : base(direct)
        {
            this.mTimeSigning = null;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new Signature(direct);
        }


        // Properties
        public EAuthType AuthType
        {
            get
            {
                PDFName name1 = (this.Dict["Prop_AuthType"] as PDFName);
                if (name1 == null)
                {
                    return EAuthType.NotSpecified;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_005D;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "Password")
                {
                    if (text1 == "PIN")
                    {
                        goto Label_0059;
                    }
                    if (text1 == "Fingerprint")
                    {
                        goto Label_005B;
                    }
                    goto Label_005D;
                }
                return EAuthType.Password;
            Label_0059:
                return EAuthType.PIN;
            Label_005B:
                return EAuthType.Fingerprint;
            Label_005D:
                throw new Exception("Unknown Authentication type");
            }
            set
            {
                string text1 = "";
                EAuthType type1 = value;
                switch (type1)
                {
                    case EAuthType.Password:
                    {
                        text1 = "Password";
                        goto Label_004A;
                    }
                    case EAuthType.PIN:
                    {
                        text1 = "PIN";
                        goto Label_004A;
                    }
                    case EAuthType.Fingerprint:
                    {
                        text1 = "Fingerprint";
                        goto Label_004A;
                    }
                    case EAuthType.NotSpecified:
                    {
                        this.Dict.Remove("Prop_AuthType");
                        return;
                    }
                }
            Label_004A:
                this.Dict["Prop_AuthType"] = Library.CreateName(text1);
            }
        }

        public IntPairCollection ByteRange
        {
            get
            {
                if (this.mByteRange != null)
                {
                    return this.mByteRange;
                }
                return new IntPairCollection(this.Dict, "ByteRange", false);
            }
            set
            {
                this.mByteRange = value;
            }
        }

        public StringList Certificate
        {
            get
            {
                if (this.mStringList != null)
                {
                    return this.mStringList;
                }
                return new StringList(this.Dict, "Cert", true);
            }
            set
            {
                this.mStringList = value;
            }
        }

        public string ContactInfo
        {
            get
            {
                PDFString text1 = (this.Dict["ContactInfo"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["ContactInfo"] = Library.CreateString(value);
            }
        }

        public string Contents
        {
            get
            {
                return (this.Dict["Contents"] as PDFName).Value;
            }
            set
            {
                this.Dict["Contents"] = Library.CreateName(value);
            }
        }

        public int FieldsAltered
        {
            get
            {
                if (this.mChanges != null)
                {
                    return (this.mChanges[1] as PDFInteger).Int32Value;
                }
                this.mChanges = (this.Dict["Changes"] as PDFArray);
                if (this.mChanges == null)
                {
                    return -2147483648;
                }
                return (this.mChanges[1] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.mChanges == null)
                {
                    this.mChanges = Library.CreateArray(3);
                }
                this.mChanges[1] = Library.CreateInteger(((long) value));
                this.Dict["Changes"] = this.mChanges;
            }
        }

        public int FieldsFilled
        {
            get
            {
                if (this.mChanges != null)
                {
                    return (this.mChanges[2] as PDFInteger).Int32Value;
                }
                this.mChanges = (this.Dict["Changes"] as PDFArray);
                if (this.mChanges == null)
                {
                    return -2147483648;
                }
                return (this.mChanges[2] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.mChanges == null)
                {
                    this.mChanges = Library.CreateArray(3);
                }
                this.mChanges[2] = Library.CreateInteger(((long) value));
                this.Dict["Changes"] = this.mChanges;
            }
        }

        public string Filter
        {
            get
            {
                return (this.Dict["Filter"] as PDFName).Value;
            }
            set
            {
                this.Dict["Filter"] = Library.CreateName(value);
            }
        }

        public string Location
        {
            get
            {
                PDFString text1 = (this.Dict["Location"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["Location"] = Library.CreateString(value);
            }
        }

        public string Name
        {
            get
            {
                PDFName name1 = (this.Dict["Name"] as PDFName);
                if (name1 == null)
                {
                    return null;
                }
                return name1.Value;
            }
            set
            {
                this.Dict["Name"] = Library.CreateName(value);
            }
        }

        public int PagesAltered
        {
            get
            {
                if (this.mChanges != null)
                {
                    return (this.mChanges[0] as PDFInteger).Int32Value;
                }
                this.mChanges = (this.Dict["Changes"] as PDFArray);
                if (this.mChanges == null)
                {
                    return -2147483648;
                }
                return (this.mChanges[0] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.mChanges == null)
                {
                    this.mChanges = Library.CreateArray(3);
                }
                this.mChanges[0] = Library.CreateInteger(((long) value));
                this.Dict["Changes"] = this.mChanges;
            }
        }

        public PDFDict PropBuild
        {
            get
            {
                throw new Exception("Not ready still");
            }
        }

        public int PropTime
        {
            get
            {
                throw new Exception("Not ready still");
            }
        }

        public string Reason
        {
            get
            {
                PDFString text1 = (this.Dict["Reason"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["Reason"] = Library.CreateString(value);
            }
        }

        public double SignatureFormatVersion
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["V"] as PDFFixed);
                if (fixed1 == null)
                {
                    return 0f;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["V"] = Library.CreateFixed(value);
            }
        }

        public double SignatureHandlerVersion
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["R"] as PDFFixed);
                if (fixed1 == null)
                {
                    return NaNf;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["R"] = Library.CreateFixed(value);
            }
        }

        public SignRefCollection SignatureReference
        {
            get
            {
                if (this.mSignRef != null)
                {
                    return this.mSignRef;
                }
                return new SignRefCollection(this.Dict, "Reference", false);
            }
            set
            {
                this.mSignRef = value;
            }
        }

        public string SubFilter
        {
            get
            {
                return (this.Dict["SubFilter"] as PDFName).Value;
            }
            set
            {
                this.Dict["SubFilter"] = Library.CreateName(value);
            }
        }

        public Date TimeSigning
        {
            get
            {
                PDFString text1;
                if (this.mTimeSigning == null)
                {
                    text1 = (this.Dict["M"] as PDFString);
                    this.mTimeSigning = new Date(text1);
                }
                return this.mTimeSigning;
            }
            set
            {
                this.Dict["M"] = PDF.O(value.String);
                this.mTimeSigning = null;
            }
        }

        public string Type
        {
            get
            {
                return "Sig";
            }
        }


        // Fields
        private IntPairCollection mByteRange;
        private PDFArray mChanges;
        private SignRefCollection mSignRef;
        private StringList mStringList;
        private Date mTimeSigning;
    }
}


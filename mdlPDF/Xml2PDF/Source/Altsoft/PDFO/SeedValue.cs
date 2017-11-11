namespace Altsoft.PDFO
{
    using System;

    public class SeedValue : Resource
    {
        // Methods
        public SeedValue(PDFDict dict) : base(dict)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new SeedValue((direct as PDFDict));
        }


        // Properties
        public CertificateSeedValue Certificate
        {
            get
            {
                PDFDict dict1 = (this.Dict["Cert"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(CertificateSeedValue)) as CertificateSeedValue);
            }
            set
            {
                this.Dict["SV"] = value.Dict;
            }
        }

        public NameList Encodings
        {
            get
            {
                if (this.mEncodings != null)
                {
                    return this.mEncodings;
                }
                PDFDict dict1 = (this.Dict["SubFilter"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return new NameList(dict1, "SubFilter", false);
            }
            set
            {
                this.mEncodings = value;
            }
        }

        public string Filter
        {
            get
            {
                PDFName name1 = (this.Dict["Filter"] as PDFName);
                if (name1 == null)
                {
                    return null;
                }
                return name1.Value;
            }
            set
            {
                this.Dict["Filter"] = Library.CreateName(value);
            }
        }

        public EEntrySpecific Flags
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Ff"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return ((EEntrySpecific) integer1.Int32Value);
            }
            set
            {
                this.Dict["Ff"] = Library.CreateInteger(((long) value));
            }
        }

        public StringList Reasons
        {
            get
            {
                if (this.mReasons != null)
                {
                    return this.mReasons;
                }
                return new StringList(this.Dict, "Reasons", true);
            }
            set
            {
                this.mReasons = value;
            }
        }

        public string Type
        {
            get
            {
                return "SV";
            }
        }

        public double Version
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["V"] as PDFFixed);
                if (fixed1 == null)
                {
                    return NaNf;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["V"] = Library.CreateFixed(value);
            }
        }


        // Fields
        private NameList mEncodings;
        private StringList mReasons;
    }
}


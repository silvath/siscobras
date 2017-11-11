namespace Altsoft.PDFO
{
    using System;

    public class CertificateSeedValue : Resource
    {
        // Methods
        public CertificateSeedValue(PDFDict dict) : base(dict)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new CertificateSeedValue((direct as PDFDict));
        }


        // Properties
        public ECSVEntrySpecific Flags
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Ff"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return ((ECSVEntrySpecific) integer1.Int32Value);
            }
            set
            {
                this.Dict["Ff"] = Library.CreateInteger(((long) value));
            }
        }

        public StringList Issuer
        {
            get
            {
                if (this.mIssuer != null)
                {
                    return this.mIssuer;
                }
                return new StringList(this.Dict, "Issuer", false);
            }
            set
            {
                this.mIssuer = value;
            }
        }

        public StringList OID
        {
            get
            {
                if (this.mOID != null)
                {
                    return this.mOID;
                }
                return new StringList(this.Dict, "OID", false);
            }
            set
            {
                this.mOID = value;
            }
        }

        public StringList Subject
        {
            get
            {
                if (this.mSubject != null)
                {
                    return this.mSubject;
                }
                return new StringList(this.Dict, "Subject", false);
            }
            set
            {
                this.mSubject = value;
            }
        }

        public string Type
        {
            get
            {
                return "SVCert";
            }
        }

        public string URL
        {
            get
            {
                PDFString text1 = (this.Dict["URL"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["URL"] = Library.CreateString(value);
            }
        }


        // Fields
        private StringList mIssuer;
        private StringList mOID;
        private StringList mSubject;
    }
}


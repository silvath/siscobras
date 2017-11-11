namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;

    public sealed class CorePDFName : CorePDFDirect, PDFName, PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Methods
        internal CorePDFName(string val)
        {
            Exception exception1 = Helpers.IsNameValid(val);
            if (exception1 != null)
            {
                throw exception1;
            }
            this.mValue = val;
        }

        public override object Clone()
        {
            return new CorePDFName(this.mValue);
        }

        public override bool Equals(object obj)
        {
            PDFName name1 = (obj as PDFName);
            if (name1 == null)
            {
                return false;
            }
            return this.mValue.Equals(name1.Value);
        }

        public override int GetHashCode()
        {
            return this.mValue.GetHashCode();
        }

        public override string ToString()
        {
            return this.mValue;
        }


        // Properties
        public override PDFObjectType PDFType
        {
            get
            {
                return PDFObjectType.tPDFName;
            }
        }

        public string Value
        {
            get
            {
                return this.mValue;
            }
            set
            {
                base._Changing();
                Exception exception1 = Helpers.IsNameValid(value);
                if (exception1 != null)
                {
                    throw exception1;
                }
                this.Dirty = (this.mValue != value);
                this.mValue = value;
                base._Changed();
            }
        }


        // Fields
        private string mValue;
    }
}


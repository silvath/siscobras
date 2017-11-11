namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;

    public sealed class CorePDFString : CorePDFDirect, PDFString, PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Methods
        internal CorePDFString(string val)
        {
            this.Value = val;
        }

        public override object Clone()
        {
            return new CorePDFString(this.Value);
        }

        public override bool Equals(object obj)
        {
            PDFName name1 = (obj as PDFName);
            if (name1 == null)
            {
                return false;
            }
            return this.Value.Equals(name1.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override string ToString()
        {
            return this.Value;
        }


        // Properties
        public byte[] Bytes
        {
            get
            {
                return Utils.StringToBytes(this.mValue);
            }
            set
            {
                this.Value = Utils.BytesToString(value);
            }
        }

        public override PDFObjectType PDFType
        {
            get
            {
                return PDFObjectType.tPDFString;
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
                this.mValue = value;
                this.Dirty = true;
                base._Changed();
            }
        }


        // Fields
        internal string mValue;
    }
}


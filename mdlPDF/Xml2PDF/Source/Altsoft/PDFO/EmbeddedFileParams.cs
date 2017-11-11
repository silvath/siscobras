namespace Altsoft.PDFO
{
    using System;

    public class EmbeddedFileParams : Resource
    {
        // Methods
        public EmbeddedFileParams(PDFDirect direct) : base(direct)
        {
        }

        public static EmbeddedFileParams Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            EmbeddedFileParams params1 = (Resources.Get(dict1, typeof(EmbeddedFileParams)) as EmbeddedFileParams);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return params1;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new EmbeddedFileParams(direct);
        }


        // Properties
        public string CheckSum
        {
            get
            {
                PDFString text1 = (this.Dict["CheckSum"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["CheckSum"] = Library.CreateString(value);
            }
        }

        public Date CreationDate
        {
            get
            {
                PDFString text1 = (this.Dict["CreationDate"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return new Date(text1);
            }
            set
            {
                this.Dict["CreationDate"] = Library.CreateString(value.String);
            }
        }

        public MacFile MacFile
        {
            get
            {
                PDFObject obj1 = this.Dict["Mac"];
                if (obj1 == null)
                {
                    return null;
                }
                return (Resources.Get(obj1, typeof(MacFile)) as MacFile);
            }
            set
            {
                this.Dict["Mac"] = value.Dict;
            }
        }

        public Date ModificationDate
        {
            get
            {
                PDFString text1 = (this.Dict["ModDate"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return new Date(text1);
            }
            set
            {
                this.Dict["ModDate"] = Library.CreateString(value.String);
            }
        }

        public int Size
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Size"] as PDFInteger);
                if (integer1 == null)
                {
                    return -2147483648;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.Dict["Size"] = Library.CreateInteger(((long) value));
            }
        }

    }
}


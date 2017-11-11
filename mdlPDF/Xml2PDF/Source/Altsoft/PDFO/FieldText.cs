namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public class FieldText : FieldVariable
    {
        // Methods
        public FieldText(PDFDirect direct) : base(direct)
        {
        }

        public static FieldText Create()
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["FT"] = Library.CreateName("Tx");
            dict1["Ff"] = Library.CreateInteger(((long) 4096));
            Library.CreateIndirect(dict1);
            return new FieldText(dict1);
        }

        public static FieldText Create(PDFDict dict)
        {
            dict["FT"] = Library.CreateName("Tx");
            dict["Ff"] = Library.CreateInteger(((long) 4096));
            return new FieldText(dict);
        }


        // Properties
        public int MaxLength
        {
            get
            {
                PDFInteger integer1 = (this.Dict["MaxLen"] as PDFInteger);
                if (integer1 == null)
                {
                    return 2147483647;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.Dict["MaxLen"] = Library.CreateInteger(((long) value));
            }
        }

        public string Text
        {
            get
            {
                string text2;
                PDFObject obj1 = this.Dict["V"];
                if (obj1 == null)
                {
                    return null;
                }
                if ((obj1 is PDFString))
                {
                    return (obj1 as PDFString).Value;
                }
                Stream stream1 = (obj1 as PDFStream).Decode();
                byte[] numArray1 = new byte[65536];
                char[] chArray1 = new char[65536];
                string text1 = null;
                while ((stream1.Read(numArray1, 0, 65536) != 0))
                {
                    numArray1.CopyTo(chArray1, 0);
                    text2 = new string(chArray1);
                    text1 = text1 + text2;
                }
                return text1;
            }
            set
            {
                this.Dict["V"] = Library.CreateString(value);
            }
        }

    }
}


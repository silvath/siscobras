namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public class FieldVariable : Field
    {
        // Methods
        public FieldVariable(PDFDirect direct) : base(direct)
        {
        }


        // Properties
        public ETextAlign Align
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Q"] as PDFInteger);
                if (integer1 == null)
                {
                    return ETextAlign.LeftJustified;
                }
                return ((ETextAlign) integer1.Int32Value);
            }
            set
            {
                this.Dict["Q"] = Library.CreateInteger(((long) value));
            }
        }

        public string DefaultAppearance
        {
            get
            {
                PDFString text1 = (this.Dict["DA"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["DA"] = Library.CreateString(value);
            }
        }

        public string DefaultStyle
        {
            get
            {
                PDFString text1 = (this.Dict["DS"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["DS"] = Library.CreateString(value);
            }
        }

        public string RichTextString
        {
            get
            {
                string text2;
                PDFObject obj1 = this.Dict["RV"];
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
                this.Dict["RV"] = Library.CreateString(value);
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public abstract class AnnotationMarkup : Annotation
    {
        // Methods
        public AnnotationMarkup(PDFDict dict) : base(dict)
        {
            this.mCreationDate = null;
        }


        // Properties
        public double ConstantOpacity
        {
            get
            {
                PDFNumeric numeric1 = (this.Dict["CA"] as PDFNumeric);
                if (numeric1 == null)
                {
                    return 1f;
                }
                return numeric1.DoubleValue;
            }
            set
            {
                this.Dict["CA"] = Library.CreateFixed(value);
            }
        }

        public Date CreationDate
        {
            get
            {
                PDFString text1;
                if (this.mCreationDate == null)
                {
                    text1 = (this.Dict["CreationDate"] as PDFString);
                    this.mCreationDate = new Date(text1);
                }
                return this.mCreationDate;
            }
            set
            {
                this.Dict["CreationDate"] = PDF.O(value.String);
                this.mCreationDate = null;
            }
        }

        public AnnotationPopup Popup
        {
            get
            {
                PDFDict dict1 = (this.Dict["Popup"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(AnnotationPopup)) as AnnotationPopup);
            }
            set
            {
                this.Dict["Popup"] = value.Direct;
            }
        }

        public string RichTextString
        {
            get
            {
                string text2;
                PDFObject obj1 = this.Dict["RC"];
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
                this.Dict["RC"] = Library.CreateString(value);
            }
        }

        public string Subject
        {
            get
            {
                PDFString text1 = (this.Dict["Subj"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["Subj"] = Library.CreateString(value);
            }
        }

        public string Title
        {
            get
            {
                PDFString text1 = (this.Dict["T"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["T"] = Library.CreateString(value);
            }
        }


        // Fields
        private Date mCreationDate;
    }
}


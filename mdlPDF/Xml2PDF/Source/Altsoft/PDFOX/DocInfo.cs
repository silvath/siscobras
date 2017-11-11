namespace Altsoft.PDFO
{
    using System;

    public class DocInfo
    {
        // Methods
        public DocInfo(PDFDict dict)
        {
            this.mCreationDate = null;
            this.mModDate = null;
            this.mDict = dict;
        }


        // Properties
        public string Author
        {
            get
            {
                PDFString text1 = (this.mDict["Author"] as PDFString);
                if (text1 != null)
                {
                    return text1.Value;
                }
                return null;
            }
            set
            {
                this.mDict["Author"] = Library.CreateString(value);
            }
        }

        public Date CreationDate
        {
            get
            {
                PDFString text1;
                if (this.mCreationDate == null)
                {
                    text1 = (this.mDict["CreationDate"] as PDFString);
                    this.mCreationDate = new Date(text1);
                }
                return this.mCreationDate;
            }
            set
            {
                this.mDict["CreationDate"] = PDF.O(value.String);
                this.mCreationDate = null;
            }
        }

        public string Creator
        {
            get
            {
                PDFString text1 = (this.mDict["Creator"] as PDFString);
                if (text1 != null)
                {
                    return text1.Value;
                }
                return null;
            }
            set
            {
                this.mDict["Creator"] = Library.CreateString(value);
            }
        }

        public string Keywords
        {
            get
            {
                PDFString text1 = (this.mDict["Keywords"] as PDFString);
                if (text1 != null)
                {
                    return text1.Value;
                }
                return null;
            }
            set
            {
                this.mDict["Keywords"] = Library.CreateString(value);
            }
        }

        public Date ModDate
        {
            get
            {
                PDFString text1;
                if (this.mModDate == null)
                {
                    text1 = (this.mDict["ModDate"] as PDFString);
                    this.mModDate = new Date(text1);
                }
                return this.mModDate;
            }
            set
            {
                this.mDict["ModDate"] = PDF.O(value.String);
                this.mModDate = null;
            }
        }

        public string Producer
        {
            get
            {
                PDFString text1 = (this.mDict["Producer"] as PDFString);
                if (text1 != null)
                {
                    return text1.Value;
                }
                return null;
            }
            set
            {
                this.mDict["Producer"] = Library.CreateString(value);
            }
        }

        public string Subject
        {
            get
            {
                PDFString text1 = (this.mDict["Subject"] as PDFString);
                if (text1 != null)
                {
                    return text1.Value;
                }
                return null;
            }
            set
            {
                this.mDict["Subject"] = Library.CreateString(value);
            }
        }

        public string Title
        {
            get
            {
                PDFString text1 = (this.mDict["Title"] as PDFString);
                if (text1 != null)
                {
                    return text1.Value;
                }
                return null;
            }
            set
            {
                this.mDict["Title"] = Library.CreateString(value);
            }
        }

        public TrappedInfo Trapped
        {
            get
            {
                PDFString text1 = (this.mDict["Trapped"] as PDFString);
                if ((text1 == null) || (text1.Value == "Unknown"))
                {
                    return TrappedInfo.Unknown;
                }
                return TrappedInfo.False;
            }
            set
            {
                if (value == TrappedInfo.Unknown)
                {
                    this.mDict["Trapped"] = Library.CreateName("Unknown");
                    return;
                }
                this.mDict["Trapped"] = Library.CreateName("False");
            }
        }


        // Fields
        private Date mCreationDate;
        public readonly PDFDict mDict;
        private Date mModDate;
    }
}


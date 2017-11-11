namespace Altsoft.PDFO
{
    using System;

    public class StructureElement : Resource
    {
        // Methods
        public StructureElement(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new StructureElement(direct);
        }


        // Properties
        public string Abbreviation
        {
            get
            {
                PDFString text1 = (this.Dict["E"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["E"] = Library.CreateString(value);
            }
        }

        public string ActualText
        {
            get
            {
                PDFString text1 = (this.Dict["ActualText"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["ActualText"] = Library.CreateString(value);
            }
        }

        public string AlternateDescription
        {
            get
            {
                PDFString text1 = (this.Dict["Alt"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["Alt"] = Library.CreateString(value);
            }
        }

        public string Identifier
        {
            get
            {
                PDFString text1 = (this.Dict["ID"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["ID"] = Library.CreateString(value);
            }
        }

        public string Language
        {
            get
            {
                PDFString text1 = (this.Dict["Lang"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["Lang"] = Library.CreateString(value);
            }
        }

        public Page Page
        {
            get
            {
                PDFDirect direct1 = (this.Dict["PG"] as PDFDirect);
                if (direct1 == null)
                {
                    return null;
                }
                return (Resources.Get(direct1, typeof(Page)) as Page);
            }
            set
            {
                this.Dict["PG"] = value.Dict;
            }
        }

        public StructureElement Parent
        {
            get
            {
                return (Resources.Get(this.Dict["P"], typeof(StructureElement)) as StructureElement);
            }
            set
            {
                this.Dict["P"] = value.Dict;
            }
        }

        public int RevisionNumber
        {
            get
            {
                PDFInteger integer1 = (this.Dict["R"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.Dict["R"] = Library.CreateInteger(((long) value));
            }
        }

        public string StructureType
        {
            get
            {
                PDFName name1 = (this.Dict["S"] as PDFName);
                if (name1 == null)
                {
                    return null;
                }
                return name1.Value;
            }
            set
            {
                this.Dict["S"] = Library.CreateName(value);
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
        public const string Type = "StructElem";
    }
}


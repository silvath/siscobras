namespace Altsoft.PDFO
{
    using System;

    public class FieldChoice : Field
    {
        // Methods
        public FieldChoice(PDFDirect direct) : base(direct)
        {
        }

        public static FieldChoice Create(PDFDict dict)
        {
            dict["FT"] = Library.CreateName("Ch");
            dict["Ff"] = Library.CreateInteger(((long) 262144));
            return new FieldChoice(dict);
        }


        // Properties
        public ChoiceOpt Options
        {
            get
            {
                PDFArray array1 = (this.Dict["Opt"] as PDFArray);
                if (array1 == null)
                {
                    return null;
                }
                return (Resources.Get(array1, typeof(ChoiceOpt)) as ChoiceOpt);
            }
            set
            {
                this.Dict["Opt"] = value.Direct;
            }
        }

        public IndexList SelectedIndexes
        {
            get
            {
                PDFArray array1 = (this.Dict["I"] as PDFArray);
                if (array1 == null)
                {
                    return null;
                }
                return (Resources.Get(array1, typeof(IndexList)) as IndexList);
            }
            set
            {
                this.Dict["I"] = value.Direct;
            }
        }

        public NameList SelectedItems
        {
            get
            {
                if (this.mSelectedItems != null)
                {
                    return this.mSelectedItems;
                }
                PDFDict dict1 = (this.Dict["V"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return new NameList(dict1, "V", true);
            }
            set
            {
                this.mSelectedItems = value;
            }
        }

        public int TopIndex
        {
            get
            {
                PDFInteger integer1 = (this.Dict["TI"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.Dict["TI"] = Library.CreateInteger(((long) value));
            }
        }


        // Fields
        private NameList mSelectedItems;
    }
}


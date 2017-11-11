namespace Altsoft.PDFO
{
    using System;

    public class FieldCheckBox : Field
    {
        // Methods
        public FieldCheckBox(PDFDirect direct) : base(direct)
        {
        }

        public static FieldCheckBox Create(string partial_name)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["FT"] = Library.CreateName("Btn");
            dict1["T"] = Library.CreateString(partial_name);
            Library.CreateIndirect(dict1);
            return new FieldCheckBox(dict1);
        }

        public static FieldCheckBox Create(PDFDict dict, string partial_name)
        {
            dict["FT"] = Library.CreateName("Btn");
            dict["T"] = Library.CreateString(partial_name);
            return new FieldCheckBox(dict);
        }


        // Properties
        public string Value
        {
            get
            {
                PDFName name1 = (this.Dict["V"] as PDFName);
                if (name1 == null)
                {
                    return null;
                }
                return name1.Value;
            }
            set
            {
                this.Dict["V"] = Library.CreateName(value);
            }
        }

        public StringArrayResource WidgetStateArray
        {
            get
            {
                PDFArray array1 = (this.Dict["Opt"] as PDFArray);
                if (array1 == null)
                {
                    return null;
                }
                return (Resources.Get(array1, typeof(StringArrayResource)) as StringArrayResource);
            }
            set
            {
                this.Dict["Opt"] = value.Direct;
            }
        }

    }
}


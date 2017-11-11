namespace Altsoft.PDFO
{
    using System;

    public class FieldRadioButton : Field
    {
        // Methods
        public FieldRadioButton(PDFDirect direct) : base(direct)
        {
            this.mWidgets = null;
        }

        public static FieldRadioButton Create()
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["FT"] = Library.CreateName("Btn");
            dict1["Ff"] = Library.CreateInteger(((long) 32768));
            Library.CreateIndirect(dict1);
            return new FieldRadioButton(dict1);
        }

        public static FieldRadioButton Create(AnnotationWidgetCollection widg)
        {
            FieldRadioButton button1 = FieldRadioButton.Create();
            button1.Kids = widg;
            return button1;
        }

        public static FieldRadioButton Create(PDFDict dict, string partial_name)
        {
            dict["FT"] = Library.CreateName("Btn");
            dict["Ff"] = Library.CreateInteger(((long) 32768));
            dict["T"] = Library.CreateString(partial_name);
            return new FieldRadioButton(dict);
        }


        // Properties
        public string AppearanceState
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

        public AnnotationWidgetCollection Kids
        {
            get
            {
                if (this.mWidgets != null)
                {
                    return this.mWidgets;
                }
                PDFArray array1 = (this.Dict["Kids"] as PDFArray);
                if (array1 != null)
                {
                    this.mWidgets = new AnnotationWidgetCollection(array1);
                }
                return this.mWidgets;
            }
            set
            {
                this.mWidgets = value;
                if (this.mWidgets != null)
                {
                    this.Dict["Kids"] = this.mWidgets.mDirect;
                }
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


        // Fields
        private AnnotationWidgetCollection mWidgets;
    }
}


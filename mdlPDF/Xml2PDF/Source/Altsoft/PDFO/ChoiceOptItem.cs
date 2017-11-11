namespace Altsoft.PDFO
{
    using System;

    public class ChoiceOptItem : Resource
    {
        // Methods
        public ChoiceOptItem(PDFArray arr) : base(arr)
        {
        }

        public static ChoiceOptItem Create(string item)
        {
            PDFArray array1 = Library.CreateArray(2);
            array1[0] = Library.CreateString(item);
            array1[1] = Library.CreateString(item);
            return new ChoiceOptItem(array1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new ChoiceOptItem((direct as PDFArray));
        }


        // Properties
        public string ExportValue
        {
            get
            {
                return ((base.Direct as PDFArray)[0] as PDFString).Value;
            }
            set
            {
                (this.mDirect as PDFArray)[0] = Library.CreateString(value);
            }
        }

        public string IsSingleValue
        {
            get
            {
                if ((base.Direct is PDFString))
                {
                    return (base.Direct as PDFString).Value;
                }
                return null;
            }
            set
            {
                this.mDirect = Library.CreateString(value);
            }
        }

        public string Text
        {
            get
            {
                return ((base.Direct as PDFArray)[1] as PDFString).Value;
            }
            set
            {
                (this.mDirect as PDFArray)[0] = Library.CreateString(value);
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;

    public class FieldVar : Resource
    {
        // Methods
        public FieldVar(PDFDirect direct) : base(direct)
        {
        }

        internal static Resource Factory(PDFDirect d)
        {
            return new FieldVar(d);
        }


        // Properties
        public Field Field
        {
            get
            {
                return (Resources.Get(base.Direct, typeof(Field)) as Field);
            }
            set
            {
                this.mDirect = value.Direct;
            }
        }

        public string IsFieldName
        {
            get
            {
                PDFString text1 = (base.Direct as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.mDirect = Library.CreateString(value);
            }
        }

    }
}


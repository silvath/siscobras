namespace Altsoft.PDFO
{
    using System;

    public class AnnotationVar : Resource
    {
        // Methods
        public AnnotationVar(PDFDirect direct) : base(direct)
        {
        }

        internal static Resource Factory(PDFDirect d)
        {
            return new AnnotationVar(d);
        }


        // Properties
        public string IsAnnotationName
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

        public AnnotationWidget WidgetAnnotation
        {
            get
            {
                return (Resources.Get(base.Direct, typeof(AnnotationWidget)) as AnnotationWidget);
            }
            set
            {
                this.mDirect = value.Direct;
            }
        }

    }
}


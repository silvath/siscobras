namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationUnderline : AnnotationTextMarkup
    {
        // Methods
        public AnnotationUnderline(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationUnderline Create(Rect rect, quadrilateralList ql)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Underline");
            AnnotationUnderline underline1 = (Resources.Get(dict1, typeof(AnnotationUnderline)) as AnnotationUnderline);
            underline1.Rect = rect;
            underline1.QuadPoints = ql;
            Library.CreateIndirect(dict1);
            return underline1;
        }


        // Fields
        public const string SubType = "Underline";
    }
}


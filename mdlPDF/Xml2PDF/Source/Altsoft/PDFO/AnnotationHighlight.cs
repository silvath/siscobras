namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationHighlight : AnnotationTextMarkup
    {
        // Methods
        public AnnotationHighlight(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationHighlight Create(Rect rect, quadrilateralList ql)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Highlight");
            AnnotationHighlight highlight1 = (Resources.Get(dict1, typeof(AnnotationHighlight)) as AnnotationHighlight);
            highlight1.Rect = rect;
            highlight1.QuadPoints = ql;
            Library.CreateIndirect(dict1);
            return highlight1;
        }


        // Fields
        public const string SubType = "Highlight";
    }
}


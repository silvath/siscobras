namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationSquiggly : AnnotationTextMarkup
    {
        // Methods
        public AnnotationSquiggly(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationSquiggly Create(Rect rect, quadrilateralList ql)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Squiggly");
            AnnotationSquiggly squiggly1 = (Resources.Get(dict1, typeof(AnnotationSquiggly)) as AnnotationSquiggly);
            squiggly1.Rect = rect;
            squiggly1.QuadPoints = ql;
            Library.CreateIndirect(dict1);
            return squiggly1;
        }


        // Fields
        public const string SubType = "Squiggly";
    }
}


namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationStrikeOut : AnnotationTextMarkup
    {
        // Methods
        public AnnotationStrikeOut(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationStrikeOut Create(Rect rect, quadrilateralList ql)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("StrikeOut");
            AnnotationStrikeOut out1 = (Resources.Get(dict1, typeof(AnnotationStrikeOut)) as AnnotationStrikeOut);
            out1.Rect = rect;
            out1.QuadPoints = ql;
            Library.CreateIndirect(dict1);
            return out1;
        }


        // Fields
        public const string SubType = "StrikeOut";
    }
}


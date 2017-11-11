namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationPrinterMark : Annotation
    {
        // Methods
        public AnnotationPrinterMark(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationPrinterMark Create(Rect rect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("PrinterMark");
            AnnotationPrinterMark mark1 = (Resources.Get(dict1, typeof(AnnotationPrinterMark)) as AnnotationPrinterMark);
            mark1.Rect = rect;
            Library.CreateIndirect(dict1);
            return mark1;
        }

        public static AnnotationPrinterMark Create(Rect rect, string Name)
        {
            AnnotationPrinterMark mark1 = AnnotationPrinterMark.Create(rect);
            mark1.MarkName = Name;
            return mark1;
        }


        // Properties
        public string MarkName
        {
            get
            {
                PDFName name1 = (this.Dict["MN"] as PDFName);
                if (name1 == null)
                {
                    return null;
                }
                return name1.Value;
            }
            set
            {
                this.Dict["NM"] = Library.CreateName(value);
            }
        }


        // Fields
        public const string SubType = "PrinterMark";
    }
}


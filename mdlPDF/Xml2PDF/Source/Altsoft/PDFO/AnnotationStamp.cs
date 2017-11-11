namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationStamp : AnnotationMarkup
    {
        // Methods
        public AnnotationStamp(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationStamp Create(Rect rect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Stamp");
            AnnotationStamp stamp1 = (Resources.Get(dict1, typeof(AnnotationStamp)) as AnnotationStamp);
            stamp1.Rect = rect;
            Library.CreateIndirect(dict1);
            return stamp1;
        }

        public static AnnotationStamp Create(Rect rect, string iconname)
        {
            AnnotationStamp stamp1 = AnnotationStamp.Create(rect);
            stamp1.IconName = iconname;
            return stamp1;
        }


        // Properties
        public string IconName
        {
            get
            {
                PDFName name1 = (this.Dict["Name"] as PDFName);
                if (name1 == null)
                {
                    return "Draft";
                }
                return name1.Value;
            }
            set
            {
                this.Dict["Name"] = Library.CreateName(value);
            }
        }


        // Fields
        public const string SubType = "Stamp";
    }
}


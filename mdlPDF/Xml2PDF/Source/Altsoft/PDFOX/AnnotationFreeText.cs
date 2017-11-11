namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationFreeText : AnnotationMarkup
    {
        // Methods
        public AnnotationFreeText(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationFreeText Create(Rect rect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("FreeText");
            AnnotationFreeText text1 = (Resources.Get(dict1, typeof(AnnotationFreeText)) as AnnotationFreeText);
            text1.Rect = rect;
            Library.CreateIndirect(dict1);
            return text1;
        }

        public static AnnotationFreeText Create(Rect rect, string defaultAppearance)
        {
            AnnotationFreeText text1 = AnnotationFreeText.Create(rect);
            text1.DefaultAppearance = defaultAppearance;
            return text1;
        }


        // Properties
        public ETextAlign Align
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Q"] as PDFInteger);
                if (integer1 == null)
                {
                    return ETextAlign.LeftJustified;
                }
                return ((ETextAlign) integer1.Int32Value);
            }
            set
            {
                this.Dict["Q"] = Library.CreateInteger(((long) value));
            }
        }

        public string DefaultAppearance
        {
            get
            {
                PDFString text1 = (this.Dict["DA"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["DA"] = Library.CreateString(value);
            }
        }

        public string DefaultStyle
        {
            get
            {
                PDFString text1 = (this.Dict["DS"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["DS"] = Library.CreateString(value);
            }
        }


        // Fields
        public const string SubType = "FreeText";
    }
}


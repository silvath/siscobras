namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationScreen : Annotation
    {
        // Methods
        public AnnotationScreen(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationScreen Create(Rect rect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Screen");
            dict1["Type"] = Library.CreateName("Annot");
            AnnotationScreen screen1 = (Resources.Get(dict1, typeof(AnnotationScreen)) as AnnotationScreen);
            screen1.Rect = rect;
            Library.CreateIndirect(dict1);
            return screen1;
        }

        public static AnnotationScreen Create(Rect rect, AppearanceCharacteristic ap)
        {
            AnnotationScreen screen1 = AnnotationScreen.Create(rect);
            screen1.AppearanceCharact = ap;
            return screen1;
        }


        // Properties
        public AppearanceCharacteristic AppearanceCharact
        {
            get
            {
                PDFDict dict1 = (this.Dict["MK"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(AppearanceCharacteristic)) as AppearanceCharacteristic);
            }
            set
            {
                this.Dict["MK"] = value.Direct;
            }
        }


        // Fields
        public const string SubType = "Screen";
    }
}


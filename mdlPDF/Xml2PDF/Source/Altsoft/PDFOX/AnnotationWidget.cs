namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationWidget : Annotation
    {
        // Methods
        public AnnotationWidget(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationWidget Create(Rect rect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Widget");
            AnnotationWidget widget1 = (Resources.Get(dict1, typeof(AnnotationWidget)) as AnnotationWidget);
            widget1.Rect = rect;
            Library.CreateIndirect(dict1);
            return widget1;
        }

        public static AnnotationWidget Create(Rect rect, AppearanceCharacteristic ap)
        {
            AnnotationWidget widget1 = AnnotationWidget.Create(rect);
            widget1.AppearanceCharact = ap;
            return widget1;
        }

        public static AnnotationWidget Create(Rect rect, EHighlightModes hm)
        {
            AnnotationWidget widget1 = AnnotationWidget.Create(rect);
            widget1.HighlightMode = hm;
            return widget1;
        }

        public static AnnotationWidget Create(Rect rect, AppearanceCharacteristic ap, EHighlightModes hm)
        {
            AnnotationWidget widget1 = AnnotationWidget.Create(rect);
            widget1.AppearanceCharact = ap;
            widget1.HighlightMode = hm;
            return widget1;
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

        public EHighlightModes HighlightMode
        {
            get
            {
                PDFName name1 = (this.Dict["H"] as PDFName);
                if (name1 == null)
                {
                    return EHighlightModes.Invert;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_007B;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "N")
                {
                    if (text1 == "I")
                    {
                        goto Label_0073;
                    }
                    if (text1 == "O")
                    {
                        goto Label_0075;
                    }
                    if (text1 == "P")
                    {
                        goto Label_0077;
                    }
                    if (text1 == "T")
                    {
                        goto Label_0079;
                    }
                    goto Label_007B;
                }
                return EHighlightModes.None;
            Label_0073:
                return EHighlightModes.Invert;
            Label_0075:
                return EHighlightModes.Outline;
            Label_0077:
                return EHighlightModes.Push;
            Label_0079:
                return EHighlightModes.Toggle;
            Label_007B:
                throw new Exception("Unknown highlight mode");
            }
            set
            {
                string text1 = "I";
                EHighlightModes modes1 = value;
                switch (modes1)
                {
                    case EHighlightModes.None:
                    {
                        text1 = "N";
                        goto Label_004A;
                    }
                    case EHighlightModes.Invert:
                    {
                        text1 = "I";
                        goto Label_004A;
                    }
                    case EHighlightModes.Outline:
                    {
                        text1 = "O";
                        goto Label_004A;
                    }
                    case EHighlightModes.Push:
                    {
                        text1 = "P";
                        goto Label_004A;
                    }
                    case EHighlightModes.Toggle:
                    {
                        goto Label_0044;
                    }
                }
                goto Label_004A;
            Label_0044:
                text1 = "T";
            Label_004A:
                this.Dict["H"] = Library.CreateName(text1);
            }
        }


        // Fields
        public const string SubType = "Widget";
    }
}


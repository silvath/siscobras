namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationPopup : Annotation
    {
        // Methods
        public AnnotationPopup(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationPopup Create(Rect rect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Popup");
            AnnotationPopup popup1 = (Resources.Get(dict1, typeof(AnnotationPopup)) as AnnotationPopup);
            popup1.Rect = rect;
            Library.CreateIndirect(dict1);
            return popup1;
        }

        public static AnnotationPopup Create(Rect rect, Annotation parent)
        {
            AnnotationPopup popup1 = AnnotationPopup.Create(rect);
            popup1.Parent = parent;
            return popup1;
        }

        public static AnnotationPopup Create(Rect rect, bool open)
        {
            AnnotationPopup popup1 = AnnotationPopup.Create(rect);
            popup1.DisplayedOpen = open;
            return popup1;
        }

        public static AnnotationPopup Create(Rect rect, Annotation parent, bool open)
        {
            AnnotationPopup popup1 = AnnotationPopup.Create(rect);
            popup1.Parent = parent;
            popup1.DisplayedOpen = open;
            return popup1;
        }


        // Properties
        public bool DisplayedOpen
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["Open"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["Open"] = Library.CreateBoolean(value);
            }
        }

        public Annotation Parent
        {
            get
            {
                PDFDict dict1 = (this.Dict["Parent"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(Annotation)) as Annotation);
            }
            set
            {
                this.Dict["Parent"] = value.Direct;
            }
        }


        // Fields
        public const string SubType = "Popup";
    }
}


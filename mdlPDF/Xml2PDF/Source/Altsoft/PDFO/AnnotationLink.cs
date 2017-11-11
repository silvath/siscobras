namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationLink : Annotation
    {
        // Methods
        public AnnotationLink(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationLink Create(Rect rect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Link");
            AnnotationLink link1 = (Resources.Get(dict1, typeof(AnnotationLink)) as AnnotationLink);
            link1.Rect = rect;
            Library.CreateIndirect(dict1);
            return link1;
        }

        public static AnnotationLink Create(Rect rect, LinkDestination dest, EHighlightingMode mode, ActionURI action)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Link");
            AnnotationLink link1 = (Resources.Get(dict1, typeof(AnnotationLink)) as AnnotationLink);
            link1.Rect = rect;
            link1.Destination = dest;
            link1.HighlightingMode = mode;
            link1.ActivateAction = action;
            Library.CreateIndirect(dict1);
            return link1;
        }


        // Properties
        public ActionURI AssociatedAction
        {
            get
            {
                PDFDict dict1 = (this.Dict["PA"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(Action)) as ActionURI);
            }
            set
            {
                if (value == null)
                {
                    this.Dict.Remove("PA");
                    return;
                }
                this.Dict["PA"] = value.Dict;
            }
        }

        public LinkDestination Destination
        {
            get
            {
                return (Resources.Get(this.Dict["Dest"], typeof(LinkDestination)) as LinkDestination);
            }
            set
            {
                this.Dict["Dest"] = value.Direct;
            }
        }

        public EHighlightingMode HighlightingMode
        {
            get
            {
                PDFName name1 = (this.Dict["H"] as PDFName);
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_0067;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "N")
                {
                    if (text1 == "I")
                    {
                        goto Label_0061;
                    }
                    if (text1 == "O")
                    {
                        goto Label_0063;
                    }
                    if (text1 == "P")
                    {
                        goto Label_0065;
                    }
                    goto Label_0067;
                }
                return EHighlightingMode.None;
            Label_0061:
                return EHighlightingMode.Invert;
            Label_0063:
                return EHighlightingMode.Outline;
            Label_0065:
                return EHighlightingMode.Push;
            Label_0067:
                return EHighlightingMode.None;
            }
            set
            {
                EHighlightingMode mode1 = value;
                switch (mode1)
                {
                    case EHighlightingMode.None:
                    {
                        this.Dict["T"] = PDF.N("N");
                    }
                    case EHighlightingMode.Invert:
                    {
                        this.Dict["T"] = PDF.N("I");
                    }
                    case EHighlightingMode.Outline:
                    {
                        this.Dict["T"] = PDF.N("O");
                    }
                    case EHighlightingMode.Push:
                    {
                        this.Dict["T"] = PDF.N("P");
                    }
                }
            }
        }


        // Fields
        public const string SubType = "Link";

        // Nested Types
        public enum EHighlightingMode
        {
            // Fields
            Invert = 2,
            None = 1,
            Outline = 3,
            Push = 4
        }
    }
}


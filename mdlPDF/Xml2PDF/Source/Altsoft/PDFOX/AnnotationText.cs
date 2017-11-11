namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationText : AnnotationMarkup
    {
        // Methods
        public AnnotationText(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationText Create(Rect rect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Text");
            dict1["Type"] = Library.CreateName("Annot");
            AnnotationText text1 = (Resources.Get(dict1, typeof(AnnotationText)) as AnnotationText);
            text1.Rect = rect;
            Library.CreateIndirect(dict1);
            return text1;
        }


        // Properties
        public string IconName
        {
            get
            {
                PDFName name1 = (this.Dict["Name"] as PDFName);
                if (name1 == null)
                {
                    return "Note";
                }
                return name1.Value;
            }
            set
            {
                this.Dict["Name"] = Library.CreateName(value);
            }
        }

        public Annotation InReplyTo
        {
            get
            {
                PDFDict dict1 = (this.Dict["IRT"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(Annotation)) as Annotation);
            }
            set
            {
                this.Dict["IRT"] = value.Direct;
            }
        }

        public bool OpenFlag
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

        public States State
        {
            get
            {
                PDFString text1 = (this.Dict["State"] as PDFString);
                if (text1 == null)
                {
                    if (this.StateModel == StateModels.Marked)
                    {
                        return States.Unmarked;
                    }
                    return States.None;
                }
                string text2 = text1.Value;
                if (text2 == null)
                {
                    goto Label_00A3;
                }
                text2 = string.IsInterned(text2);
                if (text2 != "Marked")
                {
                    if (text2 == "Unmarked")
                    {
                        goto Label_0097;
                    }
                    if (text2 == "Accepted")
                    {
                        goto Label_0099;
                    }
                    if (text2 == "Rejected")
                    {
                        goto Label_009B;
                    }
                    if (text2 == "Cancelled")
                    {
                        goto Label_009D;
                    }
                    if (text2 == "Completed")
                    {
                        goto Label_009F;
                    }
                    if (text2 == "None")
                    {
                        goto Label_00A1;
                    }
                    goto Label_00A3;
                }
                return States.Marked;
            Label_0097:
                return States.Unmarked;
            Label_0099:
                return States.Accepted;
            Label_009B:
                return States.Rejected;
            Label_009D:
                return States.Cancelled;
            Label_009F:
                return States.Completed;
            Label_00A1:
                return States.None;
            Label_00A3:
                throw new Exception("Unknown state");
            }
            set
            {
                string text1 = "None";
                States states1 = value;
                switch (states1)
                {
                    case States.Marked:
                    {
                        text1 = "Marked";
                        goto Label_0062;
                    }
                    case States.Unmarked:
                    {
                        text1 = "Unmarked";
                        goto Label_0062;
                    }
                    case States.Accepted:
                    {
                        text1 = "Accepted";
                        goto Label_0062;
                    }
                    case States.Rejected:
                    {
                        text1 = "Rejected";
                        goto Label_0062;
                    }
                    case States.Cancelled:
                    {
                        text1 = "Cancelled";
                        goto Label_0062;
                    }
                    case States.Completed:
                    {
                        text1 = "Completed";
                        goto Label_0062;
                    }
                    case States.None:
                    {
                        goto Label_005C;
                    }
                }
                goto Label_0062;
            Label_005C:
                text1 = "None";
            Label_0062:
                this.Dict["State"] = Library.CreateString(text1);
            }
        }

        public StateModels StateModel
        {
            get
            {
                PDFString text1 = (this.Dict["StateModel"] as PDFString);
                if (text1 == null)
                {
                    return StateModels.None;
                }
                string text2 = text1.Value;
                if (text2 == null)
                {
                    goto Label_004E;
                }
                text2 = string.IsInterned(text2);
                if (text2 != "Review")
                {
                    if (text2 == "Marked")
                    {
                        goto Label_004C;
                    }
                    goto Label_004E;
                }
                return StateModels.Review;
            Label_004C:
                return StateModels.Marked;
            Label_004E:
                throw new Exception("Unknown state model");
            }
            set
            {
                string text1 = "Unknown";
                StateModels models1 = value;
                switch (models1)
                {
                    case StateModels.Marked:
                    {
                        goto Label_0020;
                    }
                    case StateModels.Review:
                    {
                        text1 = "Review";
                        goto Label_0026;
                    }
                }
                goto Label_0026;
            Label_0020:
                text1 = "Marked";
            Label_0026:
                this.Dict["StateModel"] = Library.CreateString(text1);
            }
        }


        // Fields
        public const string SubType = "Text";
    }
}


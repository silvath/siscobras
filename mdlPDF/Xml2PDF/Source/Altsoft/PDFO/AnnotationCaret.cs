namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationCaret : AnnotationMarkup
    {
        // Methods
        public AnnotationCaret(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationCaret Create(Rect rect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Caret");
            AnnotationCaret caret1 = (Resources.Get(dict1, typeof(AnnotationCaret)) as AnnotationCaret);
            caret1.Rect = rect;
            Library.CreateIndirect(dict1);
            return caret1;
        }

        public static AnnotationCaret Create(Rect rect, Rect RectDiff)
        {
            AnnotationCaret caret1 = AnnotationCaret.Create(rect);
            caret1.RectDifference = RectDiff;
            return caret1;
        }

        public static AnnotationCaret Create(Rect rect, Rect RectDiff, ECaretSymbol Caret)
        {
            AnnotationCaret caret1 = AnnotationCaret.Create(rect);
            caret1.RectDifference = RectDiff;
            caret1.Caret = Caret;
            return caret1;
        }


        // Properties
        public ECaretSymbol Caret
        {
            get
            {
                PDFName name1 = (this.Dict["Sy"] as PDFName);
                if (name1 == null)
                {
                    return ECaretSymbol.None;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_004E;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "None")
                {
                    if (text1 == "P")
                    {
                        goto Label_004C;
                    }
                    goto Label_004E;
                }
                return ECaretSymbol.None;
            Label_004C:
                return ECaretSymbol.Paragraph;
            Label_004E:
                throw new Exception("Unknown caret symbol");
            }
            set
            {
                string text1 = "None";
                ECaretSymbol symbol1 = value;
                switch (symbol1)
                {
                    case ECaretSymbol.Paragraph:
                    {
                        goto Label_0020;
                    }
                    case ECaretSymbol.None:
                    {
                        text1 = "None";
                        goto Label_0026;
                    }
                }
                goto Label_0026;
            Label_0020:
                text1 = "P";
            Label_0026:
                this.Dict["Sy"] = Library.CreateName(text1);
            }
        }

        public Rect RectDifference
        {
            get
            {
                PDFArray array1;
                double[] numArray1;
                if (this.mRect == null)
                {
                    array1 = (this.Dict["RD"] as PDFArray);
                    numArray1 = new double[4];
                    if (array1 != null)
                    {
                        Library.CopyArray(array1, 0, 4, numArray1, 0);
                    }
                    this.mRect = new PDFRect(this.Dict, "RD", numArray1);
                }
                return this.mRect;
            }
            set
            {
                this.RectDifference.Set(value);
            }
        }


        // Fields
        private PDFRect mRect;
        public const string SubType = "Caret";

        // Nested Types
        public enum ECaretSymbol
        {
            // Fields
            None = 1,
            Paragraph = 0
        }
    }
}


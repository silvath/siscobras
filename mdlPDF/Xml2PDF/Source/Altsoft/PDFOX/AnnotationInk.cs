namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationInk : AnnotationMarkup
    {
        // Methods
        public AnnotationInk(PDFDict dict) : base(dict)
        {
            this.mInkList = null;
        }

        private static AnnotationInk Create(Rect rect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Ink");
            AnnotationInk ink1 = (Resources.Get(dict1, typeof(AnnotationInk)) as AnnotationInk);
            ink1.Rect = rect;
            Library.CreateIndirect(dict1);
            return ink1;
        }

        public static AnnotationInk Create(Rect rect, StrokedPathList InkList)
        {
            AnnotationInk ink1 = AnnotationInk.Create(rect);
            ink1.InkList = InkList;
            return ink1;
        }

        public static AnnotationInk Create(Rect rect, StrokedPathList InkList, BorderStyles bs)
        {
            AnnotationInk ink1 = AnnotationInk.Create(rect);
            ink1.InkList = InkList;
            ink1.BorderStyle = bs;
            return ink1;
        }


        // Properties
        public StrokedPathList InkList
        {
            get
            {
                if (this.mInkList == null)
                {
                    this.mInkList = new StrokedPathList((this.Dict["InkList"] as PDFDirect));
                }
                return this.mInkList;
            }
            set
            {
                this.mInkList = value;
                this.Dict["InkList"] = this.mInkList.mDirect;
            }
        }


        // Fields
        private StrokedPathList mInkList;
        public const string SubType = "Ink";
    }
}


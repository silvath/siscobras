namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationCircle : GraphPrimitiveAnnot
    {
        // Methods
        public AnnotationCircle(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationCircle Create(Rect rect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Circle");
            AnnotationCircle circle1 = (Resources.Get(dict1, typeof(AnnotationCircle)) as AnnotationCircle);
            circle1.Rect = rect;
            Library.CreateIndirect(dict1);
            return circle1;
        }


        // Properties
        public BorderEffects BorderEffect
        {
            get
            {
                if (this.mBorderEffect != null)
                {
                    return this.mBorderEffect;
                }
                PDFDict dict1 = (this.Dict["BE"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return new BorderEffects(dict1);
            }
            set
            {
                this.Dict["BE"] = value.Dict;
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
        private BorderEffects mBorderEffect;
        private PDFRect mRect;
        public const string SubType = "Circle";
    }
}


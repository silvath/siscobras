namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationPolygon : GraphPrimitiveAnnot
    {
        // Methods
        public AnnotationPolygon(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationPolygon Create(Rect rect, PointArray vertices)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Polygon");
            AnnotationPolygon polygon1 = (Resources.Get(dict1, typeof(AnnotationPolygon)) as AnnotationPolygon);
            polygon1.Rect = rect;
            polygon1.Vertices = vertices;
            Library.CreateIndirect(dict1);
            return polygon1;
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

        public PointArray Vertices
        {
            get
            {
                if (this.mVertices != null)
                {
                    return this.mVertices;
                }
                PDFArray array1 = (this.Dict["Vertices"] as PDFArray);
                if (array1 == null)
                {
                    return null;
                }
                double[] numArray1 = new double[array1.Count];
                Library.CopyArray(array1, 0, array1.Count, numArray1, 0);
                DoubleArray array2 = new DoubleArray(array1.Count);
                array2.Set(numArray1);
                return new PointArray(array2);
            }
            set
            {
                this.mVertices = value;
                if (value == null)
                {
                    this.Dict.Remove("Vertices");
                    return;
                }
                double[] numArray1 = new double[(value.Count * 2)];
                value.CopyTo(numArray1, 0);
                this.Dict["Vertices"] = Library.CreateArray(false, numArray1);
            }
        }


        // Fields
        private BorderEffects mBorderEffect;
        private PointArray mVertices;
        public const string SubType = "Polygon";
    }
}


namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Collections;

    public class AnnotationPolyline : GraphPrimitiveAnnot
    {
        // Methods
        public AnnotationPolyline(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationPolyline Create(Rect rect, PointArray vertices)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Polyline");
            AnnotationPolyline polyline1 = (Resources.Get(dict1, typeof(AnnotationPolyline)) as AnnotationPolyline);
            polyline1.Rect = rect;
            polyline1.Vertices = vertices;
            Library.CreateIndirect(dict1);
            return polyline1;
        }


        // Properties
        public ELineEndingStyles LeftEnd
        {
            get
            {
                if (<PrivateImplementationDetails>.$$method0x6000195-1 == null)
                {
                    Hashtable hashtable1 = new Hashtable(20, 0.5f);
                    hashtable1.Add("Square", 0);
                    Hashtable hashtable2 = new Hashtable(20, 0.5f);
                    hashtable2.Add("Circle", 1);
                    Hashtable hashtable3 = new Hashtable(20, 0.5f);
                    hashtable3.Add("Diamond", 2);
                    Hashtable hashtable4 = new Hashtable(20, 0.5f);
                    hashtable4.Add("OpenArrow", 3);
                    Hashtable hashtable5 = new Hashtable(20, 0.5f);
                    hashtable5.Add("ClosedArrow", 4);
                    Hashtable hashtable6 = new Hashtable(20, 0.5f);
                    hashtable6.Add("None", 5);
                    Hashtable hashtable7 = new Hashtable(20, 0.5f);
                    hashtable7.Add("Butt", 6);
                    Hashtable hashtable8 = new Hashtable(20, 0.5f);
                    hashtable8.Add("ROpenArrow", 7);
                    Hashtable hashtable9 = new Hashtable(20, 0.5f);
                    hashtable9.Add("RClosedArrow", 8);
                    <PrivateImplementationDetails>.$$method0x6000195-1 = new Hashtable(20, 0.5f);
                }
                if (this.mLineEnding == null)
                {
                    this.mLineEnding = (this.Dict["LE"] as PDFArray);
                }
                if (this.mLineEnding == null)
                {
                    return ELineEndingStyles.None;
                }
                object obj1 = (this.mLineEnding[0] as PDFName).Value;
                if (obj1 == null)
                {
                    goto Label_0154;
                }
                obj1 = <PrivateImplementationDetails>.$$method0x6000195-1[obj1];
                if (obj1 == null)
                {
                    goto Label_0154;
                }
                switch (((int) obj1))
                {
                    case 0:
                    {
                        goto Label_0142;
                    }
                    case 1:
                    {
                        goto Label_0144;
                    }
                    case 2:
                    {
                        goto Label_0146;
                    }
                    case 3:
                    {
                        goto Label_0148;
                    }
                    case 4:
                    {
                        goto Label_014A;
                    }
                    case 5:
                    {
                        goto Label_014C;
                    }
                    case 6:
                    {
                        goto Label_014E;
                    }
                    case 7:
                    {
                        goto Label_0150;
                    }
                    case 8:
                    {
                        goto Label_0152;
                    }
                }
                goto Label_0154;
            Label_0142:
                return ELineEndingStyles.Square;
            Label_0144:
                return ELineEndingStyles.Circle;
            Label_0146:
                return ELineEndingStyles.Diamond;
            Label_0148:
                return ELineEndingStyles.OpenArrow;
            Label_014A:
                return ELineEndingStyles.ClosedArrow;
            Label_014C:
                return ELineEndingStyles.None;
            Label_014E:
                return ELineEndingStyles.Butt;
            Label_0150:
                return ELineEndingStyles.ROpenArrow;
            Label_0152:
                return ELineEndingStyles.RClosedArrow;
            Label_0154:
                throw new Exception("Unknown Line Ending Style");
            }
            set
            {
                string text1 = "None";
                ELineEndingStyles styles1 = value;
                switch (styles1)
                {
                    case ELineEndingStyles.Square:
                    {
                        text1 = "Square";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.Circle:
                    {
                        text1 = "Circle";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.Diamond:
                    {
                        text1 = "Diamond";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.OpenArrow:
                    {
                        text1 = "OpenArrow";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.ClosedArrow:
                    {
                        text1 = "ClosedArrow";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.None:
                    {
                        text1 = "None";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.Butt:
                    {
                        text1 = "Butt";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.ROpenArrow:
                    {
                        text1 = "ROpenArrow";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.RClosedArrow:
                    {
                        text1 = "RClosedArrow";
                        goto Label_0082;
                    }
                }
                text1 = "None";
            Label_0082:
                if (this.mLineEnding == null)
                {
                    this.mLineEnding = Library.CreateArray(2);
                }
                this.mLineEnding[0] = Library.CreateName(text1);
                this.Dict["LE"] = this.mLineEnding;
            }
        }

        public ELineEndingStyles RightEnd
        {
            get
            {
                if (<PrivateImplementationDetails>.$$method0x6000197-1 == null)
                {
                    Hashtable hashtable1 = new Hashtable(20, 0.5f);
                    hashtable1.Add("Square", 0);
                    Hashtable hashtable2 = new Hashtable(20, 0.5f);
                    hashtable2.Add("Circle", 1);
                    Hashtable hashtable3 = new Hashtable(20, 0.5f);
                    hashtable3.Add("Diamond", 2);
                    Hashtable hashtable4 = new Hashtable(20, 0.5f);
                    hashtable4.Add("OpenArrow", 3);
                    Hashtable hashtable5 = new Hashtable(20, 0.5f);
                    hashtable5.Add("ClosedArrow", 4);
                    Hashtable hashtable6 = new Hashtable(20, 0.5f);
                    hashtable6.Add("None", 5);
                    Hashtable hashtable7 = new Hashtable(20, 0.5f);
                    hashtable7.Add("Butt", 6);
                    Hashtable hashtable8 = new Hashtable(20, 0.5f);
                    hashtable8.Add("ROpenArrow", 7);
                    Hashtable hashtable9 = new Hashtable(20, 0.5f);
                    hashtable9.Add("RClosedArrow", 8);
                    <PrivateImplementationDetails>.$$method0x6000197-1 = new Hashtable(20, 0.5f);
                }
                if (this.mLineEnding == null)
                {
                    this.mLineEnding = (this.Dict["LE"] as PDFArray);
                }
                if (this.mLineEnding == null)
                {
                    return ELineEndingStyles.None;
                }
                object obj1 = (this.mLineEnding[1] as PDFName).Value;
                if (obj1 == null)
                {
                    goto Label_0154;
                }
                obj1 = <PrivateImplementationDetails>.$$method0x6000197-1[obj1];
                if (obj1 == null)
                {
                    goto Label_0154;
                }
                switch (((int) obj1))
                {
                    case 0:
                    {
                        goto Label_0142;
                    }
                    case 1:
                    {
                        goto Label_0144;
                    }
                    case 2:
                    {
                        goto Label_0146;
                    }
                    case 3:
                    {
                        goto Label_0148;
                    }
                    case 4:
                    {
                        goto Label_014A;
                    }
                    case 5:
                    {
                        goto Label_014C;
                    }
                    case 6:
                    {
                        goto Label_014E;
                    }
                    case 7:
                    {
                        goto Label_0150;
                    }
                    case 8:
                    {
                        goto Label_0152;
                    }
                }
                goto Label_0154;
            Label_0142:
                return ELineEndingStyles.Square;
            Label_0144:
                return ELineEndingStyles.Circle;
            Label_0146:
                return ELineEndingStyles.Diamond;
            Label_0148:
                return ELineEndingStyles.OpenArrow;
            Label_014A:
                return ELineEndingStyles.ClosedArrow;
            Label_014C:
                return ELineEndingStyles.None;
            Label_014E:
                return ELineEndingStyles.Butt;
            Label_0150:
                return ELineEndingStyles.ROpenArrow;
            Label_0152:
                return ELineEndingStyles.RClosedArrow;
            Label_0154:
                throw new Exception("Unknown Line Ending Style");
            }
            set
            {
                string text1 = "None";
                ELineEndingStyles styles1 = value;
                switch (styles1)
                {
                    case ELineEndingStyles.Square:
                    {
                        text1 = "Square";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.Circle:
                    {
                        text1 = "Circle";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.Diamond:
                    {
                        text1 = "Diamond";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.OpenArrow:
                    {
                        text1 = "OpenArrow";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.ClosedArrow:
                    {
                        text1 = "ClosedArrow";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.None:
                    {
                        text1 = "None";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.Butt:
                    {
                        text1 = "Butt";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.ROpenArrow:
                    {
                        text1 = "ROpenArrow";
                        goto Label_0082;
                    }
                    case ELineEndingStyles.RClosedArrow:
                    {
                        text1 = "RClosedArrow";
                        goto Label_0082;
                    }
                }
                text1 = "None";
            Label_0082:
                if (this.mLineEnding == null)
                {
                    this.mLineEnding = Library.CreateArray(2);
                }
                this.mLineEnding[1] = Library.CreateName(text1);
                this.Dict["LE"] = this.mLineEnding;
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
        private PDFArray mLineEnding;
        private PointArray mVertices;
        public const string SubType = "Polyline";
    }
}


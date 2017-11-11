namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Collections;
    using System.Reflection;

    public abstract class Function : Resource
    {
        // Methods
        static Function()
        {
            Function.DictKeyName = "Function";
        }

        internal Function(PDFDirect d) : base(d)
        {
            this.mDomain = null;
            this.mRange = null;
        }

        internal static Resource Factory(PDFDirect d)
        {
            if (d.PDFType != PDFObjectType.tPDFDict)
            {
                goto Label_0061;
            }
            PDFDict dict1 = ((PDFDict) d);
            int num1 = ((PDFInteger) dict1["FunctionType"]).Int32Value;
            int num3 = num1;
            switch (num3)
            {
                case 2:
                {
                    goto Label_003C;
                }
                case 3:
                {
                    goto Label_0043;
                }
            }
            goto Label_004A;
        Label_003C:
            return new FunctionType2(d);
        Label_0043:
            return new FunctionType3(d);
        Label_004A:
            throw new PDFSyntaxException(d, string.Format("Unknown function type: {0}", num1));
        Label_0061:
            if (d.PDFType != PDFObjectType.tPDFStream)
            {
                goto Label_00C0;
            }
            PDFStream stream1 = ((PDFStream) d);
            int num2 = ((PDFInteger) stream1.Dict["FunctionType"]).Int32Value;
            num3 = num2;
            if (num3 != 0)
            {
                if (num3 == 4)
                {
                    goto Label_00A2;
                }
                goto Label_00A9;
            }
            return new FunctionType0(d);
        Label_00A2:
            return new FunctionType4(d);
        Label_00A9:
            throw new PDFSyntaxException(d, string.Format("Unknown function type: {0}", num2));
        Label_00C0:
            throw new PDFSyntaxException(d, "Invalid Function");
        }

        internal static double InterpolateLin1d(double x, double x0, double x1, double y0, double y1)
        {
            return ((((x - x0) * (y1 - y0)) / (x1 - x0)) + y0);
        }


        // Properties
        public virtual DoubleMinMaxArray Domain
        {
            get
            {
                double[] numArray1;
                if (this.mDomain == null)
                {
                    numArray1 = new double[1];
                    this.mDomain = new DoubleMinMaxArray(new PDFDoubleArray(this.Dict, "Domain", false, numArray1));
                }
                return this.mDomain;
            }
            set
            {
                this.Domain.Set(value);
            }
        }

        public abstract double[] this[double[] args] { get; }

        public virtual DoubleMinMaxArray Range
        {
            get
            {
                PDFArray array1;
                if (this.mRange == null)
                {
                    array1 = ((PDFArray) this.Dict["Range"]);
                    if (array1 != null)
                    {
                        this.mRange = new DoubleMinMaxArray(new PDFDoubleArray(array1, array1.Count));
                    }
                }
                return this.mRange;
            }
            set
            {
                double[] numArray1;
                if (this.Range == null)
                {
                    numArray1 = new double[value.Count];
                    value.CopyTo(numArray1, 0);
                    this.mRange = new DoubleMinMaxArray(new PDFDoubleArray(this.Dict, "Range", false, numArray1));
                    return;
                }
                this.Range.Set(value);
            }
        }

        public abstract int SubType { get; }


        // Fields
        internal static readonly string DictKeyName;
        private DoubleMinMaxArray mDomain;
        private DoubleMinMaxArray mRange;

        // Nested Types
        public class NamedFunctions
        {
            // Methods
            static NamedFunctions()
            {
                NamedFunctions._Instance = null;
            }

            private NamedFunctions()
            {
                this.funcs = new Hashtable();
                this.funcs["Identity"] = "{}";
                this.funcs["SimpleDot"] = "{ dup mul exch dup mul add 1 exch sub }";
                this.funcs["InvertedSimpleDot"] = "{ dup mul exch dup mul add 1 sub }";
                this.funcs["DoubleDot"] = "{ 360 mul sin 2 div exch 360 mul sin 2 div add }";
                this.funcs["InvertedDoubleDot"] = "{ 360 mul sin 2 div exch 360 mul sin 2 div add neg }";
                this.funcs["CosineDot"] = "{ 180 mul cos exch 180 mul cos add 2 div }";
                this.funcs["Double"] = "{ 360 mul sin 2 div exch 2 div 360 mul sin 2 div add }";
                this.funcs["InvertedDouble"] = "{ 360 mul sin 2 div exch 2 div 360 mul sin 2 div add neg }";
                this.funcs["Line"] = "{ exch pop abs neg }";
                this.funcs["LineX"] = "{ pop }";
                this.funcs["LineY"] = "{ exch pop }";
                this.funcs["Round"] = "{ abs exch abs\t2 copy add 1 le { dup mul exch dup mul add 1 exch sub }\t{ 1 sub dup mul exch 1 sub dup mul add 1 sub } ifelse }";
                this.funcs["Ellipse"] = "{ abs exch abs 2 copy 3 mul exch 4 mul add 3 sub dup 0 lt { pop dup mul exch 0.75 div dup mul add 4 div 1 exch sub } { dup 1 gt { pop 1 exch sub dup mul exch 1 exch sub 0.75 div dup mul add 4 div 1 sub } { 0.5 exch sub exch pop exch pop } ifelse } ifelse }";
                this.funcs["EllipseA"] = "{ dup mul 0.9 mul exch dup mul add 1 exch sub }";
                this.funcs["InvertedEllipseA"] = "{ dup mul 0.9 mul exch dup mul add 1 sub }";
                this.funcs["EllipseB"] = "{ dup 5 mul 8 div mul exch dup mul exch add sqrt 1 exch sub }";
                this.funcs["EllipseC"] = "{ dup mul exch dup mul 0.9 mul add 1 exch sub }";
                this.funcs["InvertedEllipseC"] = "{ dup mul exch dup mul 0.9 mul add 1 sub }";
                this.funcs["Square"] = "{ abs exch abs 2 copy lt\t{ exch } if pop neg }";
                this.funcs["Cross"] = "{ abs exch abs 2 copy gt { exch } if pop neg }";
                this.funcs["Rhombold"] = "{ abs exch abs 0.9 mul add 2 div }";
                this.funcs["Diamond"] = "{ abs exch abs 2 copy add 0.75 le { dup mul exch dup mul add 1 exch sub } {2 copy add 1.23 le { 0.85 mul add 1 exch sub } { 1 sub dup mul exch 1 sub dup mul add 1 sub }\tifelse } ifelse }";
            }

            public static Function Create(string name)
            {
                double[] numArray1;
                if (name == "Identity")
                {
                    numArray1 = new double[2];
                    numArray1[1] = 1f;
                    numArray1 = new double[2];
                    numArray1[1] = 1f;
                    return FunctionType4.Create(numArray1, numArray1, ((string) NamedFunctions.Instance.funcs[name]));
                }
                numArray1 = new double[4];
                numArray1[1] = 1f;
                numArray1[3] = 1f;
                numArray1 = new double[2];
                numArray1[1] = 1f;
                return FunctionType4.Create(numArray1, numArray1, ((string) NamedFunctions.Instance.funcs[name]));
            }


            // Properties
            private static NamedFunctions Instance
            {
                get
                {
                    if (NamedFunctions._Instance == null)
                    {
                        NamedFunctions._Instance = new NamedFunctions();
                    }
                    return NamedFunctions._Instance;
                }
            }

            public static ICollection Names
            {
                get
                {
                    return NamedFunctions.Instance.funcs.Keys;
                }
            }


            // Fields
            private static NamedFunctions _Instance;
            private Hashtable funcs;
        }
    }
}


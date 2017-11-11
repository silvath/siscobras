namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Collections;

    public class Annotation : Resource
    {
        // Methods
        public Annotation(PDFDirect dict) : base(dict)
        {
            this.mLastModified = null;
        }

        internal static Resource Factory(PDFDirect d)
        {
            if (<PrivateImplementationDetails>.$$method0x6000121-1 == null)
            {
                Hashtable hashtable1 = new Hashtable(48, 0.5f);
                hashtable1.Add("Text", 0);
                Hashtable hashtable2 = new Hashtable(48, 0.5f);
                hashtable2.Add("FreeText", 1);
                Hashtable hashtable3 = new Hashtable(48, 0.5f);
                hashtable3.Add("Line", 2);
                Hashtable hashtable4 = new Hashtable(48, 0.5f);
                hashtable4.Add("Square", 3);
                Hashtable hashtable5 = new Hashtable(48, 0.5f);
                hashtable5.Add("Circle", 4);
                Hashtable hashtable6 = new Hashtable(48, 0.5f);
                hashtable6.Add("Polygon", 5);
                Hashtable hashtable7 = new Hashtable(48, 0.5f);
                hashtable7.Add("Polyline", 6);
                Hashtable hashtable8 = new Hashtable(48, 0.5f);
                hashtable8.Add("Highlight", 7);
                Hashtable hashtable9 = new Hashtable(48, 0.5f);
                hashtable9.Add("Underline", 8);
                Hashtable hashtable10 = new Hashtable(48, 0.5f);
                hashtable10.Add("Squiggly", 9);
                Hashtable hashtable11 = new Hashtable(48, 0.5f);
                hashtable11.Add("StrikeOut", 10);
                Hashtable hashtable12 = new Hashtable(48, 0.5f);
                hashtable12.Add("Stamp", 11);
                Hashtable hashtable13 = new Hashtable(48, 0.5f);
                hashtable13.Add("Caret", 12);
                Hashtable hashtable14 = new Hashtable(48, 0.5f);
                hashtable14.Add("Ink", 13);
                Hashtable hashtable15 = new Hashtable(48, 0.5f);
                hashtable15.Add("FileAttachment", 14);
                Hashtable hashtable16 = new Hashtable(48, 0.5f);
                hashtable16.Add("Sound", 15);
                Hashtable hashtable17 = new Hashtable(48, 0.5f);
                hashtable17.Add("Link", 16);
                Hashtable hashtable18 = new Hashtable(48, 0.5f);
                hashtable18.Add("Popup", 17);
                Hashtable hashtable19 = new Hashtable(48, 0.5f);
                hashtable19.Add("Movie", 18);
                Hashtable hashtable20 = new Hashtable(48, 0.5f);
                hashtable20.Add("Widget", 19);
                Hashtable hashtable21 = new Hashtable(48, 0.5f);
                hashtable21.Add("Screen", 20);
                Hashtable hashtable22 = new Hashtable(48, 0.5f);
                hashtable22.Add("PrinterMark", 21);
                Hashtable hashtable23 = new Hashtable(48, 0.5f);
                hashtable23.Add("TrapNet", 22);
                <PrivateImplementationDetails>.$$method0x6000121-1 = new Hashtable(48, 0.5f);
            }
            PDFDict dict1 = (d as PDFDict);
            string text1 = "";
            PDFName name1 = (dict1["Subtype"] as PDFName);
            if (name1 != null)
            {
                text1 = name1.Value;
            }
            object obj1 = text1;
            if (obj1 == null)
            {
                goto Label_0306;
            }
            obj1 = <PrivateImplementationDetails>.$$method0x6000121-1[obj1];
            if (obj1 == null)
            {
                goto Label_0306;
            }
            switch (((int) obj1))
            {
                case 0:
                {
                    goto Label_0265;
                }
                case 1:
                {
                    goto Label_026C;
                }
                case 2:
                {
                    goto Label_0273;
                }
                case 3:
                {
                    goto Label_027A;
                }
                case 4:
                {
                    goto Label_0281;
                }
                case 5:
                {
                    goto Label_0288;
                }
                case 6:
                {
                    goto Label_028F;
                }
                case 7:
                {
                    goto Label_0296;
                }
                case 8:
                {
                    goto Label_029D;
                }
                case 9:
                {
                    goto Label_02A4;
                }
                case 10:
                {
                    goto Label_02AB;
                }
                case 11:
                {
                    goto Label_02B2;
                }
                case 12:
                {
                    goto Label_02B9;
                }
                case 13:
                {
                    goto Label_02C0;
                }
                case 14:
                {
                    goto Label_02C7;
                }
                case 15:
                {
                    goto Label_02CE;
                }
                case 16:
                {
                    goto Label_02D5;
                }
                case 17:
                {
                    goto Label_02DC;
                }
                case 18:
                {
                    goto Label_02E3;
                }
                case 19:
                {
                    goto Label_02EA;
                }
                case 20:
                {
                    goto Label_02F1;
                }
                case 21:
                {
                    goto Label_02F8;
                }
                case 22:
                {
                    goto Label_02FF;
                }
            }
            goto Label_0306;
        Label_0265:
            return new AnnotationText(dict1);
        Label_026C:
            return new AnnotationFreeText(dict1);
        Label_0273:
            return new AnnotationLine(dict1);
        Label_027A:
            return new AnnotationSquare(dict1);
        Label_0281:
            return new AnnotationCircle(dict1);
        Label_0288:
            return new AnnotationPolygon(dict1);
        Label_028F:
            return new AnnotationPolyline(dict1);
        Label_0296:
            return new AnnotationHighlight(dict1);
        Label_029D:
            return new AnnotationUnderline(dict1);
        Label_02A4:
            return new AnnotationSquiggly(dict1);
        Label_02AB:
            return new AnnotationStrikeOut(dict1);
        Label_02B2:
            return new AnnotationStamp(dict1);
        Label_02B9:
            return new AnnotationCaret(dict1);
        Label_02C0:
            return new AnnotationInk(dict1);
        Label_02C7:
            return new AnnotationFileAttachment(dict1);
        Label_02CE:
            return new AnnotationSound(dict1);
        Label_02D5:
            return new AnnotationLink(dict1);
        Label_02DC:
            return new AnnotationPopup(dict1);
        Label_02E3:
            return new AnnotationMovie(dict1);
        Label_02EA:
            return new AnnotationWidget(dict1);
        Label_02F1:
            return new AnnotationScreen(dict1);
        Label_02F8:
            return new AnnotationPrinterMark(dict1);
        Label_02FF:
            return new AnnotationTrapNet(dict1);
        Label_0306:
            return new Annotation(dict1);
        }


        // Properties
        public virtual Action ActivateAction
        {
            get
            {
                PDFDict dict1 = (this.Dict["A"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(Action)) as Action);
            }
            set
            {
                if (value == null)
                {
                    this.Dict.Remove("A");
                    return;
                }
                this.Dict["A"] = ((this.Dict.Doc != null) ? value.Dict : value.Dict);
            }
        }

        public AnnotationAdditionalActions AdditionalActions
        {
            get
            {
                if (this.mAdditionalActions != null)
                {
                    return this.mAdditionalActions;
                }
                PDFDict dict1 = (this.Dict["AA"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(AnnotationAdditionalActions)) as AnnotationAdditionalActions);
            }
            set
            {
                this.mAdditionalActions = value;
                this.Dict["AA"] = this.mAdditionalActions.Dict;
            }
        }

        public string AnnotationName
        {
            get
            {
                PDFString text1 = (this.Dict["NM"] as PDFString);
                if (text1 == null)
                {
                    return "";
                }
                return text1.Value;
            }
            set
            {
                this.Dict["NM"] = PDF.O(value);
            }
        }

        public Appearance Appearance
        {
            get
            {
                PDFDict dict1 = (this.Dict["AP"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(Appearance)) as Appearance);
            }
            set
            {
                this.Dict["AP"] = value.Direct;
            }
        }

        public string AppearanceState
        {
            get
            {
                PDFName name1 = (this.Dict["AS"] as PDFName);
                if (name1 == null)
                {
                    return null;
                }
                return name1.Value;
            }
            set
            {
                this.Dict["AS"] = Library.CreateName(value);
            }
        }

        public double BIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["C"] as PDFArray);
                }
                if (this.RGB == null)
                {
                    return NaNf;
                }
                return (this.RGB[2] as PDFFixed).DoubleValue;
            }
            set
            {
                if (value == NaNf)
                {
                    this.RGB = null;
                    this.Dict.Remove("C");
                    return;
                }
                if (this.RGB == null)
                {
                    this.RGB = Library.CreateArray(3);
                }
                this.RGB[2] = Library.CreateFixed(value);
                this.Dict["C"] = this.RGB;
            }
        }

        public BorderCharact Border
        {
            get
            {
                if (this.mBorder != null)
                {
                    return this.mBorder;
                }
                return new BorderCharact(this.Dict, "Border");
            }
            set
            {
                this.mBorder = value;
                this.Dict["Border"] = this.mBorder.CharactArray;
            }
        }

        public BorderStyles BorderStyle
        {
            get
            {
                if (this.mBorderStyle != null)
                {
                    return this.mBorderStyle;
                }
                return new BorderStyles(this);
            }
            set
            {
                this.mBorderStyle = value;
                this.Dict["BS"] = this.mBorderStyle.Dict;
            }
        }

        public string Contents
        {
            get
            {
                PDFString text1 = (this.Dict["Contents"] as PDFString);
                if (text1 == null)
                {
                    return "";
                }
                return text1.Value;
            }
            set
            {
                this.Dict["Contents"] = PDF.O(value);
            }
        }

        public FlagsEnum Flags
        {
            get
            {
                PDFInteger integer1 = (this.Dict["F"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return ((FlagsEnum) integer1.Int32Value);
            }
            set
            {
                this.Dict["F"] = PDF.O(value);
            }
        }

        public double GIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["C"] as PDFArray);
                }
                if (this.RGB == null)
                {
                    return NaNf;
                }
                return (this.RGB[1] as PDFFixed).DoubleValue;
            }
            set
            {
                if (value == NaNf)
                {
                    this.RGB = null;
                    this.Dict.Remove("C");
                    return;
                }
                if (this.RGB == null)
                {
                    this.RGB = Library.CreateArray(3);
                }
                this.RGB[1] = Library.CreateFixed(value);
                this.Dict["C"] = this.RGB;
            }
        }

        public string Label
        {
            get
            {
                PDFString text1 = (this.Dict["T"] as PDFString);
                if (text1 == null)
                {
                    return "";
                }
                return text1.Value;
            }
            set
            {
                this.Dict["T"] = PDF.O(value);
            }
        }

        public Date LastModified
        {
            get
            {
                PDFString text1;
                if (this.mLastModified == null)
                {
                    text1 = (this.Dict["M"] as PDFString);
                    this.mLastModified = new Date(text1);
                }
                return this.mLastModified;
            }
            set
            {
                this.Dict["M"] = PDF.O(value.String);
                this.mLastModified = null;
            }
        }

        public OptionalContent OptionalContent
        {
            get
            {
                PDFDict dict1 = (this.Dict["OC"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(OptionalContent)) as OptionalContent);
            }
            set
            {
                this.Dict["OC"] = value.Direct;
            }
        }

        public OCGMembership OptionalContentMembership
        {
            get
            {
                PDFDict dict1 = (this.Dict["OC"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(OCGMembership)) as OCGMembership);
            }
            set
            {
                this.Dict["OC"] = value.Direct;
            }
        }

        public Page Page
        {
            get
            {
                PDFIndirect indirect1 = (this.Dict["P", 0] as PDFIndirect);
                if (indirect1 == null)
                {
                    return null;
                }
                foreach (Page page1 in this.Dict.Doc.Pages)
                {
                    if (indirect1 != page1.Dict.Indirect)
                    {
                        continue;
                    }
                    return page1;
                }
                return null;
            }
            set
            {
                this.Dict["P"] = value.Dict;
            }
        }

        public Rect Rect
        {
            get
            {
                PDFArray array1;
                double[] numArray1;
                if (this.mRect == null)
                {
                    array1 = (this.Dict["Rect"] as PDFArray);
                    numArray1 = new double[4];
                    if (array1 != null)
                    {
                        Library.CopyArray(array1, 0, 4, numArray1, 0);
                    }
                    this.mRect = new PDFRect(this.Dict, "Rect", numArray1);
                }
                return this.mRect;
            }
            set
            {
                this.Rect.Set(value);
            }
        }

        public double RIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["C"] as PDFArray);
                }
                if (this.RGB == null)
                {
                    return NaNf;
                }
                return (this.RGB[0] as PDFFixed).DoubleValue;
            }
            set
            {
                if (value == NaNf)
                {
                    this.RGB = null;
                    this.Dict.Remove("C");
                    return;
                }
                if (this.RGB == null)
                {
                    this.RGB = Library.CreateArray(3);
                }
                this.RGB[0] = Library.CreateFixed(value);
                this.Dict["C"] = this.RGB;
            }
        }

        public int StructParent
        {
            get
            {
                PDFInteger integer1 = (this.Dict["StructParent"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.Dict["StructParent"] = Library.CreateInteger(((long) value));
            }
        }

        public virtual string SubType
        {
            get
            {
                PDFName name1 = (this.Dict["Subtype"] as PDFName);
                if (name1 == null)
                {
                    return "";
                }
                return name1.Value;
            }
        }

        public string Type
        {
            get
            {
                return "Annot";
            }
        }


        // Fields
        private AnnotationAdditionalActions mAdditionalActions;
        private BorderCharact mBorder;
        private BorderStyles mBorderStyle;
        private Date mLastModified;
        private PDFRect mRect;
        private PDFArray RGB;

        // Nested Types
        [Flags]
        public enum FlagsEnum
        {
            // Fields
            Hidden = 2,
            Invisible = 1,
            Locked = 128,
            NoRotate = 16,
            NoView = 32,
            NoZoom = 8,
            Print = 4,
            ReadOnly = 64,
            ToggleNoView = 256
        }
    }
}


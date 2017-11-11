namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Reflection;

    public class Page : Resource
    {
        // Methods
        internal Page(PDFDict dict) : base(dict)
        {
            this.mAnnots = null;
            this.mPageContents = null;
            this.mResources = null;
            this.mLastModified = null;
            this.mBeads = null;
        }

        internal static Resource Factory(PDFDirect direct)
        {
            PDFDict dict1 = (direct as PDFDict);
            if (dict1 == null)
            {
                return null;
            }
            PDFName name1 = (dict1["Type"] as PDFName);
            if (name1 == null)
            {
                return null;
            }
            if (name1.Value != "Page")
            {
                return null;
            }
            return new Page(dict1);
        }

        internal PDFObject GetInheritedValue(string name)
        {
            PDFObject obj2;
            PDFObject obj1 = null;
            PDFDict dict1 = null;
            try
            {
                for (dict1 = this.Dict; (dict1 != null); dict1 = ((PDFDict) dict1["Parent"]))
                {
                    obj1 = dict1[name];
                    if (obj1 != null)
                    {
                        break;
                    }
                }
                return obj1;
            }
            catch (InvalidCastException)
            {
                throw new PDFSyntaxException(dict1, "Parent of page tree node sould point to a DICTIONARY");
            }
            return obj2;
        }

        internal static PDFIndirect New(Document doc)
        {
            int num1;
            PDFIndirect indirect1 = doc.Indirects.New();
            PDFDict dict1 = Library.CreateDict();
            indirect1.Direct = dict1;
            dict1["Type"] = Library.CreateName("Page");
            dict1["Resources"] = Library.CreateDict();
            PDFArray array1 = Library.CreateArray(4);
            for (num1 = 0; (num1 < 4); num1 += 1)
            {
                array1[num1] = Library.CreateInteger(((long) 0));
            }
            dict1["MediaBox"] = array1;
            return indirect1;
        }

        public void PullInheritedParams()
        {
            string text1;
            int num1;
            string[] textArray1 = Tags.PageInheritableParams;
            for (num1 = 0; (num1 < textArray1.Length); num1 += 1)
            {
                text1 = textArray1[num1];
                this.Dict[text1] = this.GetInheritedValue(text1);
            }
        }


        // Properties
        public AnnotationAdditionalActions AdditionnalActions
        {
            get
            {
                PDFDict dict1 = (this.Dict["AA"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (this.Dict.Doc.Resources[dict1, typeof(AnnotationAdditionalActions)] as AnnotationAdditionalActions);
            }
            set
            {
                this.Dict["AA"] = this.Dict.Doc.Resources.Add(value).Direct;
            }
        }

        public AnnotationsCollection Annotations
        {
            get
            {
                if (this.mAnnots == null)
                {
                    this.mAnnots = new AnnotationsCollection(this.Dict);
                }
                return this.mAnnots;
            }
        }

        public Rect ArtBox
        {
            get
            {
                PDFArray array1;
                Rect rect1;
                double[] numArray1;
                double[] numArray2;
                if (this.mArtBox == null)
                {
                    array1 = (this.GetInheritedValue("ArtBox") as PDFArray);
                    rect1 = this.CropBox;
                    numArray2 = new double[4];
                    numArray2[0] = rect1.x1;
                    numArray2[1] = rect1.y1;
                    numArray2[2] = rect1.x2;
                    numArray2[3] = rect1.y2;
                    numArray1 = numArray2;
                    if (array1 != null)
                    {
                        Library.CopyArray(array1, 0, 4, numArray1, 0);
                    }
                    this.mArtBox = new PDFRect(this.Dict, "ArtBox", numArray1);
                }
                return this.mArtBox;
            }
            set
            {
                this.ArtBox.Set(value);
            }
        }

        public ArticleBeadsCollection Beads
        {
            get
            {
                if (this.mBeads == null)
                {
                    this.mBeads = new ArticleBeadsCollection(this.Dict);
                }
                return this.mBeads;
            }
            set
            {
                this.mBeads = value;
                this.Dict["B"] = this.mBeads.mBaseDict["B"];
            }
        }

        public Rect BleedBox
        {
            get
            {
                PDFArray array1;
                Rect rect1;
                double[] numArray1;
                double[] numArray2;
                if (this.mBleedBox == null)
                {
                    array1 = (this.GetInheritedValue("BleedBox") as PDFArray);
                    rect1 = this.CropBox;
                    numArray2 = new double[4];
                    numArray2[0] = rect1.x1;
                    numArray2[1] = rect1.y1;
                    numArray2[2] = rect1.x2;
                    numArray2[3] = rect1.y2;
                    numArray1 = numArray2;
                    if (array1 != null)
                    {
                        Library.CopyArray(array1, 0, 4, numArray1, 0);
                    }
                    this.mBleedBox = new PDFRect(this.Dict, "BleedBox", numArray1);
                }
                return this.mBleedBox;
            }
            set
            {
                this.BleedBox.Set(value);
            }
        }

        public PageContents Contents
        {
            get
            {
                if (this.mPageContents == null)
                {
                    this.mPageContents = new PageContents(this.Dict);
                }
                return this.mPageContents;
            }
        }

        public Rect CropBox
        {
            get
            {
                PDFArray array1;
                Rect rect1;
                double[] numArray1;
                double[] numArray2;
                if (this.mCropBox == null)
                {
                    array1 = (this.GetInheritedValue("CropBox") as PDFArray);
                    rect1 = this.MediaBox;
                    numArray2 = new double[4];
                    numArray2[0] = rect1.x1;
                    numArray2[1] = rect1.y1;
                    numArray2[2] = rect1.x2;
                    numArray2[3] = rect1.y2;
                    numArray1 = numArray2;
                    if (array1 != null)
                    {
                        Library.CopyArray(array1, 0, 4, numArray1, 0);
                    }
                    this.mCropBox = new PDFRect(this.Dict, "CropBox", numArray1);
                }
                return this.mCropBox;
            }
            set
            {
                this.CropBox.Set(value);
            }
        }

        public double DisplayDuration
        {
            get
            {
                PDFNumeric numeric1 = (this.Dict["Dur"] as PDFNumeric);
                if (numeric1 == null)
                {
                    return NaNf;
                }
                return numeric1.DoubleValue;
            }
            set
            {
                this.Dict["Dur"] = PDF.O(value);
            }
        }

        public TransparencyGroup Group
        {
            get
            {
                return (this.Dict.Doc.Resources[this.GetInheritedValue("Group"), typeof(TransparencyGroup)] as TransparencyGroup);
            }
            set
            {
                this.Dict["Group"] = this.Dict.Doc.Resources.Add(value).Direct;
            }
        }

        public string ID
        {
            get
            {
                PDFString text1 = (this.GetInheritedValue("ID") as PDFString);
                if (text1 == null)
                {
                    return "";
                }
                return text1.Value;
            }
            set
            {
                this.Dict["ID"] = Library.CreateString(value);
            }
        }

        public string Label
        {
            get
            {
                int num2;
                PDFDict dict2;
                int num3;
                PDFString text1;
                PDFInteger integer1;
                string text2;
                string text3;
                PDFName name1;
                int num4;
                char ch1;
                int num5;
                int num6;
                char ch2;
                int num7;
                string text4;
                string text5;
                byte[] numArray1;
                PDFDict dict1 = (this.Dict.Doc.Root["PageLabels"] as PDFDict);
                if (dict1 == null)
                {
                    return "";
                }
                PDFArray array1 = (dict1["Nums"] as PDFArray);
                if (array1.Count == 0)
                {
                    return "";
                }
                if ((array1.Count % 2) != 0)
                {
                    throw new PDFSyntaxException("Invalid page label list");
                }
                int num1 = this.PageNr;
                try
                {
                    num2 = 0;
                    num2 = ((array1.Count / 2) - 1);
                    while ((num2 >= 0))
                    {
                        if (((PDFInteger) array1[(2 * num2)]).Int32Value <= num1)
                        {
                            break;
                        }
                        num2 -= 1;
                    }
                    dict2 = (array1[((2 * num2) + 1)] as PDFDict);
                    num3 = (num1 - ((PDFInteger) array1[(2 * num2)]).Int32Value);
                    text1 = (dict2["P"] as PDFString);
                    integer1 = (dict2["St"] as PDFInteger);
                    if (integer1 != null)
                    {
                        num3 += integer1.Int32Value;
                    }
                    else
                    {
                        num3 += 1;
                    }
                    text2 = "";
                    if (text1 != null)
                    {
                        text2 = text1.Value;
                    }
                    text3 = "";
                    name1 = (dict2["S"] as PDFName);
                    if (name1 != null)
                    {
                        text3 = name1.Value;
                    }
                    text5 = text3;
                    if (text5 == null)
                    {
                        return text2;
                    }
                    text5 = string.IsInterned(text5);
                    if (text5 != "D")
                    {
                        if (text5 == "R")
                        {
                            goto Label_01AB;
                        }
                        if (text5 == "r")
                        {
                            goto Label_01C0;
                        }
                        if (text5 == "A")
                        {
                            goto Label_01DA;
                        }
                        if (text5 != "a")
                        {
                            return text2;
                        }
                        goto Label_0241;
                    }
                    return text2 + num3.ToString();
                Label_01AB:
                    return text2 + Utils.ArabicToRomanAsAdobe(num3);
                Label_01C0:
                    return text2 + Utils.ArabicToRomanAsAdobe(num3).ToLower();
                Label_01DA:
                    num4 = (1 + (num3 / 26));
                    (num3 % 26);
                    numArray1 = new byte[1];
                    numArray1[0] = ((byte) (num4 + Encoding.ASCII.GetBytes("A")[0]));
                    ch1 = Encoding.ASCII.GetChars(numArray1)[0];
                    for (num5 = 0; (num5 < num4); num5 += 1)
                    {
                        text2 = text2 + ch1;
                    }
                    return text2;
                Label_0241:
                    num6 = (1 + (num3 / 26));
                    (num3 % 26);
                    numArray1 = new byte[1];
                    numArray1[0] = ((byte) (num6 + Encoding.ASCII.GetBytes("a")[0]));
                    ch2 = Encoding.ASCII.GetChars(numArray1)[0];
                    for (num7 = 0; (num7 < num6); num7 += 1)
                    {
                        text2 = text2 + ch2;
                    }
                    return text2;
                }
                catch (InvalidCastException)
                {
                    throw new PDFSyntaxException("Invalid page label list - non-integer index");
                }
                return text4;
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

        public Rect MediaBox
        {
            get
            {
                PDFArray array1;
                double[] numArray1;
                if (this.mMediaBox == null)
                {
                    array1 = (this.GetInheritedValue("MediaBox") as PDFArray);
                    numArray1 = new double[4];
                    if (array1 != null)
                    {
                        Library.CopyArray(array1, 0, 4, numArray1, 0);
                    }
                    this.mMediaBox = new PDFRect(this.Dict, "MediaBox", numArray1);
                }
                return this.mMediaBox;
            }
            set
            {
                this.MediaBox.Set(value);
            }
        }

        public NavigationNode NavigationNode
        {
            get
            {
                PDFDict dict1 = (this.Dict["PresSteps"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(NavigationNode)) as NavigationNode);
            }
            set
            {
                this.Dict["PresSteps"] = value.Dict;
            }
        }

        public int PageNr
        {
            get
            {
                int num2;
                PagesCollection collection1 = this.Dict.Doc.Pages;
                int num1 = this.Dict.Indirect.Id;
                for (num2 = 0; (num2 < collection1.Count); num2 += 1)
                {
                    if (collection1[num2].Dict.Indirect.Id == num1)
                    {
                        return num2;
                    }
                }
                throw new PDFException("PDF tree error - disconneced page");
            }
        }

        public double PreferredZoom
        {
            get
            {
                PDFNumeric numeric1 = (this.Dict["PZ"] as PDFNumeric);
                if (numeric1 == null)
                {
                    return NaNf;
                }
                return numeric1.DoubleValue;
            }
            set
            {
                this.Dict["PZ"] = PDF.O(value);
            }
        }

        public override DocResourceSet Resources
        {
            get
            {
                if (this.mResources == null)
                {
                    this.mResources = new DocResourceSet(((PDFDict) this.Dict["Resources"]), this.Dict, null);
                }
                return this.mResources;
            }
        }

        public int Rotate
        {
            get
            {
                PDFInteger integer1 = (this.GetInheritedValue("Rotate") as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                int num1 = (integer1.Int32Value % 360);
                if (num1 < 0)
                {
                    num1 += 360;
                }
                return num1;
            }
            set
            {
                if ((((value % 90) != 0) || (value < 0)) || (value > 270))
                {
                    throw new ArgumentException("Rotate should be either 0,90,180 or 270");
                }
                this.Dict["Rotate"] = PDF.O(value);
            }
        }

        public PageSeparationInfo SeparationInfo
        {
            get
            {
                return null;
            }
        }

        public int StructParents
        {
            get
            {
                PDFNumeric numeric1 = (this.GetInheritedValue("StructParents") as PDFNumeric);
                if (numeric1 != null)
                {
                    return numeric1.Int32Value;
                }
                return 0;
            }
            set
            {
                this.Dict["StructParents"] = Library.CreateInteger(((long) value));
            }
        }

        public string Tabs
        {
            get
            {
                PDFString text1 = (this.GetInheritedValue("Tabs") as PDFString);
                if (text1 != null)
                {
                    return text1.Value;
                }
                return "";
            }
            set
            {
                this.Dict["Tabs"] = Library.CreateString(value);
            }
        }

        public string TemplateInstantiated
        {
            get
            {
                PDFString text1 = (this.GetInheritedValue("TemplateInstantiated") as PDFString);
                if (text1 != null)
                {
                    return text1.Value;
                }
                return "";
            }
            set
            {
                this.Dict["TemplateInstantiated"] = Library.CreateString(value);
            }
        }

        public XObjectImage Thumbnail
        {
            get
            {
                PDFStream stream1 = (this.Dict["Thumb"] as PDFStream);
                if (stream1 == null)
                {
                    return null;
                }
                return ((XObjectImage) this.Dict.Doc.Resources[stream1, typeof(XObjectImage)]);
            }
            set
            {
                if (value == null)
                {
                    this.Dict.Remove("Thumb");
                    return;
                }
                this.Dict["Thumb"] = this.Dict.Doc.Resources.Add(value).Direct;
            }
        }

        public Transition Transition
        {
            get
            {
                PDFDict dict1 = (this.Dict["Trans"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (this.Dict.Doc.Resources[dict1, typeof(Transition)] as Transition);
            }
            set
            {
                this.Dict["Trans"] = this.Dict.Doc.Resources.Add(value).Direct;
            }
        }

        public Rect TrimBox
        {
            get
            {
                PDFArray array1;
                Rect rect1;
                double[] numArray1;
                double[] numArray2;
                if (this.mTrimBox == null)
                {
                    array1 = (this.GetInheritedValue("TrimBox") as PDFArray);
                    rect1 = this.CropBox;
                    numArray2 = new double[4];
                    numArray2[0] = rect1.x1;
                    numArray2[1] = rect1.y1;
                    numArray2[2] = rect1.x2;
                    numArray2[3] = rect1.y2;
                    numArray1 = numArray2;
                    if (array1 != null)
                    {
                        Library.CopyArray(array1, 0, 4, numArray1, 0);
                    }
                    this.mTrimBox = new PDFRect(this.Dict, "TrimBox", numArray1);
                }
                return this.mTrimBox;
            }
            set
            {
                this.TrimBox.Set(value);
            }
        }


        // Fields
        private AnnotationsCollection mAnnots;
        private PDFRect mArtBox;
        private ArticleBeadsCollection mBeads;
        private PDFRect mBleedBox;
        private PDFRect mCropBox;
        private Date mLastModified;
        private PDFRect mMediaBox;
        private PageContents mPageContents;
        private DocResourceSet mResources;
        private PDFRect mTrimBox;

        // Nested Types
        public class AnnotationsCollection : ComplexObjectArrayBase
        {
            // Methods
            public AnnotationsCollection(PDFDict pageDict) : base(pageDict, "Annots", false)
            {
            }

            public void Add(Annotation value)
            {
                this[base.Count] = value;
            }

            internal override object ComplexObjectFactory(PDFDirect dict)
            {
                return dict.Doc.Resources[dict, typeof(Annotation)];
            }

            public void Remove(Annotation value)
            {
                base._Remove(value);
            }

            public void RemoveAt(int index)
            {
                base._RemoveAt(index);
            }


            // Properties
            public Annotation this[int index]
            {
                get
                {
                    return (base._GetObject(index) as Annotation);
                }
                set
                {
                    base._SetObject(index, value, value.Dict);
                }
            }

        }

        public class ArticleBeadsCollection : ComplexObjectArrayBase
        {
            // Methods
            public ArticleBeadsCollection(PDFDict pageDict) : base(pageDict, "B", false)
            {
            }

            public void Add(ArticleBead value)
            {
                this[base.Count] = value;
            }

            internal override object ComplexObjectFactory(PDFDirect dict)
            {
                return dict.Doc.Resources[dict, typeof(ArticleBead)];
            }

            public void Remove(ArticleBead value)
            {
                base._Remove(value);
            }

            public void RemoveAt(int index)
            {
                base._RemoveAt(index);
            }


            // Properties
            public ArticleBead this[int index]
            {
                get
                {
                    return (base._GetObject(index) as ArticleBead);
                }
                set
                {
                    base._SetObject(index, value, value.Dict);
                }
            }

        }

        public enum GroupCS
        {
            // Fields
            Custom = 4,
            DefaultCMYK = 3,
            DefaultGray = 1,
            DefaultRGB = 2,
            Unknown = 0
        }

        public class PageSeparationInfo
        {
            // Methods
            internal PageSeparationInfo(Page _page)
            {
                this.mPages = null;
                this.mPage = _page;
            }


            // Properties
            public bool IsPreseparated
            {
                get
                {
                    return (this.mPage.Dict["SeparationInfo"] != null);
                }
                set
                {
                }
            }

            public SeparationPageCollection Pages
            {
                get
                {
                    if (this.mPages == null)
                    {
                        this.mPages = new SeparationPageCollection(this);
                    }
                    this.mPages.mBaseDict = (this.mPage.Dict["SeparationInfo"] as PDFDict);
                    return this.mPages;
                }
            }


            // Fields
            internal Page mPage;
            private SeparationPageCollection mPages;

            // Nested Types
            public class SeparationPageCollection : ComplexObjectArrayBase
            {
                // Methods
                internal SeparationPageCollection(PageSeparationInfo sepInfo) : base(null, "Pages", false)
                {
                }

                internal override object ComplexObjectFactory(PDFDirect dir)
                {
                    PDFIndirect indirect1 = dir.Indirect;
                    foreach (Page page1 in dir.Doc.Pages)
                    {
                        if (page1.Dict.Indirect != indirect1)
                        {
                            continue;
                        }
                        return page1;
                    }
                    return null;
                }

            }
        }

        public class TransparencyGroup : Resource
        {
            // Methods
            private TransparencyGroup(PDFDirect direct) : base(direct)
            {
                this.mCSType = GroupCS.Unknown;
            }

            internal Resource Factory(PDFDirect direct)
            {
                return new TransparencyGroup(direct);
            }

            internal PDFObject GetInheritedValue(string name)
            {
                PDFObject obj2;
                PDFObject obj1 = null;
                PDFDict dict1 = null;
                try
                {
                    for (dict1 = this.Dict; (dict1 != null); dict1 = ((PDFDict) dict1["Parent"].Direct))
                    {
                        obj1 = dict1[name];
                        if (obj1 != null)
                        {
                            break;
                        }
                    }
                    return obj1;
                }
                catch (InvalidCastException)
                {
                    throw new PDFSyntaxException(dict1, "Parent of transparency groupsould point to a DICTIONARY");
                }
                return obj2;
            }


            // Properties
            public ColorSpace ColorSpace
            {
                get
                {
                    PDFObject obj1 = this.Dict["CS"];
                    if (this.ColorSpaceType == GroupCS.Custom)
                    {
                        return (this.Dict.Doc.Resources[obj1, typeof(ColorSpace)] as ColorSpace);
                    }
                    return null;
                }
                set
                {
                    if (value != null)
                    {
                        value = (this.Dict.Doc.Resources.Add(value) as ColorSpace);
                        this.Dict["CS"] = value.Dict;
                        return;
                    }
                    this.Dict.Remove("CS");
                }
            }

            public GroupCS ColorSpaceType
            {
                get
                {
                    PDFObject obj1 = this.GetInheritedValue("CS");
                    PDFName name1 = (obj1 as PDFName);
                    if (name1 == null)
                    {
                        goto Label_0076;
                    }
                    string text1 = name1.Value;
                    if (text1 == null)
                    {
                        goto Label_006D;
                    }
                    text1 = string.IsInterned(text1);
                    if (text1 != "DefaultGray")
                    {
                        if (text1 == "DefaultRGB")
                        {
                            goto Label_005B;
                        }
                        if (text1 == "DefaultCMYK")
                        {
                            goto Label_0064;
                        }
                        goto Label_006D;
                    }
                    this.mCSType = GroupCS.DefaultGray;
                    goto Label_007D;
                Label_005B:
                    this.mCSType = GroupCS.DefaultRGB;
                    goto Label_007D;
                Label_0064:
                    this.mCSType = GroupCS.DefaultCMYK;
                    goto Label_007D;
                Label_006D:
                    this.mCSType = GroupCS.Custom;
                    goto Label_007D;
                Label_0076:
                    this.mCSType = GroupCS.Custom;
                Label_007D:
                    return this.mCSType;
                }
                set
                {
                    this.mCSType = value;
                    GroupCS pcs1 = this.mCSType;
                    switch (pcs1)
                    {
                        case GroupCS.DefaultGray:
                        {
                            this.Dict["CS"] = PDF.N("DefaultGray");
                            return;
                        }
                        case GroupCS.DefaultRGB:
                        {
                            this.Dict["CS"] = PDF.N("DefaultRGB");
                            return;
                        }
                        case GroupCS.DefaultCMYK:
                        {
                            this.Dict["CS"] = PDF.N("DefaultCMYK");
                            return;
                        }
                    }
                    throw new Exception("Illegal Default Colospace");
                }
            }

            public bool Isolated
            {
                get
                {
                    PDFBoolean flag1 = (this.Dict["I"] as PDFBoolean);
                    if (flag1 != null)
                    {
                        return flag1.Value;
                    }
                    return false;
                }
                set
                {
                    this.Dict["I"] = PDF.O(value);
                }
            }

            public bool Knockout
            {
                get
                {
                    PDFBoolean flag1 = (this.Dict["K"] as PDFBoolean);
                    if (flag1 != null)
                    {
                        return flag1.Value;
                    }
                    return false;
                }
                set
                {
                    this.Dict["K"] = PDF.O(value);
                }
            }


            // Fields
            private GroupCS mCSType;
        }
    }
}


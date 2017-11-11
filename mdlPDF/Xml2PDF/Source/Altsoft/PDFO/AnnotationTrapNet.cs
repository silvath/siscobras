namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationTrapNet : Annotation
    {
        // Methods
        public AnnotationTrapNet(PDFDict dict) : base(dict)
        {
            this.mLastModified = null;
            this.mVersion = null;
        }

        private static AnnotationTrapNet Create(Rect rect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("TrapNet");
            AnnotationTrapNet net1 = (Resources.Get(dict1, typeof(AnnotationTrapNet)) as AnnotationTrapNet);
            net1.Rect = rect;
            Library.CreateIndirect(dict1);
            return net1;
        }

        public static AnnotationTrapNet Create(Rect rect, Date lastmodified)
        {
            AnnotationTrapNet net1 = AnnotationTrapNet.Create(rect);
            net1.LastModified = lastmodified;
            return net1;
        }

        public static AnnotationTrapNet Create(Rect rect, DateTime lastmodified)
        {
            AnnotationTrapNet net1 = AnnotationTrapNet.Create(rect);
            net1.LastModified = new Date(lastmodified);
            return net1;
        }

        public static AnnotationTrapNet Create(Rect rect, ObjectCollection version, NameList annotsStates)
        {
            AnnotationTrapNet net1 = AnnotationTrapNet.Create(rect);
            net1.Version = version;
            net1.AnnotStates = annotsStates;
            return net1;
        }

        public static AnnotationTrapNet Create(Rect rect, Page page, NameList annotsStates)
        {
            AnnotationTrapNet net1 = AnnotationTrapNet.Create(rect);
            net1.AnnotStates = annotsStates;
            net1.Version = ObjectCollection.Create(page);
            return net1;
        }


        // Properties
        public NameList AnnotStates
        {
            get
            {
                if (this.mAnnotStates != null)
                {
                    return this.mAnnotStates;
                }
                PDFDict dict1 = (this.Dict["AnnotStates"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return new NameList(dict1, "AnnotStates", false);
            }
            set
            {
                this.mAnnotStates = value;
            }
        }

        public FontList FontFauxing
        {
            get
            {
                if (this.mFontFauxing != null)
                {
                    return this.mFontFauxing;
                }
                PDFDict dict1 = (this.Dict["FontFauxing"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return new FontList(dict1, "FontFauxing");
            }
            set
            {
                this.mFontFauxing = value;
            }
        }

        public Date LastModified
        {
            get
            {
                if (this.mLastModified != null)
                {
                    return this.mLastModified;
                }
                PDFString text1 = (this.Dict["LastModified"] as PDFString);
                if (text1 != null)
                {
                    this.mLastModified = new Date(text1);
                }
                return this.mLastModified;
            }
            set
            {
                this.Dict["LastModified"] = PDF.O(value.String);
                this.mLastModified = null;
            }
        }

        public ObjectCollection Version
        {
            get
            {
                if (this.mVersion != null)
                {
                    return this.mVersion;
                }
                PDFArray array1 = (this.Dict["Version"] as PDFArray);
                if (array1 != null)
                {
                    this.mVersion = new ObjectCollection(array1);
                }
                return this.mVersion;
            }
            set
            {
                this.mVersion = value;
                this.Dict["Version"] = this.mVersion.mDirect;
            }
        }


        // Fields
        private NameList mAnnotStates;
        private FontList mFontFauxing;
        private Date mLastModified;
        private ObjectCollection mVersion;
        public const string SubType = "TrapNet";
    }
}


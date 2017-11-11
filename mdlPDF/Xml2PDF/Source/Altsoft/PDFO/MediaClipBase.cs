namespace Altsoft.PDFO
{
    using System;

    public class MediaClipBase : Resource
    {
        // Methods
        public MediaClipBase(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            if (direct == null)
            {
                return null;
            }
            string text1 = ((direct as PDFDict)["S"] as PDFName).Value;
            if (text1 == null)
            {
                goto Label_0056;
            }
            text1 = string.IsInterned(text1);
            if (text1 != "MCD")
            {
                if (text1 == "MCS")
                {
                    goto Label_004F;
                }
                goto Label_0056;
            }
            return new MediaClipData(direct);
        Label_004F:
            return new MediaClipSection(direct);
        Label_0056:
            return null;
        }


        // Properties
        public string Name
        {
            get
            {
                PDFString text1 = (this.Dict["N"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["N"] = Library.CreateString(value);
            }
        }

        public StringPairList TagList
        {
            get
            {
                PDFArray array1 = (this.Dict["Alt"] as PDFArray);
                if (array1 == null)
                {
                    return null;
                }
                return (Resources.Get(array1, typeof(StringPairList)) as StringPairList);
            }
            set
            {
                this.Dict["Alt"] = value.Direct;
            }
        }


        // Fields
        public const string Type = "MediaClip";
    }
}


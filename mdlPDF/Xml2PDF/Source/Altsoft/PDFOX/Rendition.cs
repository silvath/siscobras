namespace Altsoft.PDFO
{
    using System;

    public class Rendition : Resource
    {
        // Methods
        public Rendition(PDFDirect direct) : base(direct)
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
            if (text1 != "MR")
            {
                if (text1 == "SR")
                {
                    goto Label_004F;
                }
                goto Label_0056;
            }
            return new RenditionMedia(direct);
        Label_004F:
            return new RenditionSelector(direct);
        Label_0056:
            return null;
        }


        // Properties
        public RenditionMHBE BestEffort
        {
            get
            {
                PDFDict dict1 = (this.Dict["BE"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(RenditionMHBE)) as RenditionMHBE);
            }
            set
            {
                this.Dict["BE"] = value.Dict;
            }
        }

        public RenditionMHBE MustHonored
        {
            get
            {
                PDFDict dict1 = (this.Dict["MH"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(RenditionMHBE)) as RenditionMHBE);
            }
            set
            {
                this.Dict["MH"] = value.Dict;
            }
        }

        public string RenditionName
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

        public ERenditionType RenditionType
        {
            get
            {
                PDFName name1 = (this.Dict["S"] as PDFName);
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_0049;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "MR")
                {
                    if (text1 == "SR")
                    {
                        goto Label_0047;
                    }
                    goto Label_0049;
                }
                return ERenditionType.MediaRendition;
            Label_0047:
                return ERenditionType.SelectorRendition;
            Label_0049:
                return ERenditionType.Non_viable;
            }
            set
            {
                string text1 = "Non-viable";
                ERenditionType type1 = value;
                switch (type1)
                {
                    case ERenditionType.MediaRendition:
                    {
                        text1 = "MR";
                        goto Label_0032;
                    }
                    case ERenditionType.SelectorRendition:
                    {
                        text1 = "SR";
                        goto Label_0032;
                    }
                    case ERenditionType.Non_viable:
                    {
                        goto Label_002C;
                    }
                }
                goto Label_0032;
            Label_002C:
                text1 = "Non-viable";
            Label_0032:
                this.Dict["S"] = Library.CreateName(text1);
            }
        }

        public string Type
        {
            get
            {
                return "Rendition";
            }
        }

    }
}


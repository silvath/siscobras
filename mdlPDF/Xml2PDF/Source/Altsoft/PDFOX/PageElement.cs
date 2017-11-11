namespace Altsoft.PDFO
{
    using System;

    public class PageElement : Resource
    {
        // Methods
        public PageElement(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new PageElement(direct);
        }


        // Properties
        public EContainer ContainerType
        {
            get
            {
                PDFName name1 = (this.Dict["Subtype"] as PDFName);
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_0067;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "HF")
                {
                    if (text1 == "FG")
                    {
                        goto Label_0061;
                    }
                    if (text1 == "BG")
                    {
                        goto Label_0063;
                    }
                    if (text1 == "L")
                    {
                        goto Label_0065;
                    }
                    goto Label_0067;
                }
                return EContainer.Header_footer;
            Label_0061:
                return EContainer.ForegroundImage_graphic;
            Label_0063:
                return EContainer.BackgroundImage_graphic;
            Label_0065:
                return EContainer.Logo;
            Label_0067:
                throw new Exception("Illegal container type");
            }
            set
            {
                string text1 = "L";
                EContainer container1 = value;
                switch (container1)
                {
                    case EContainer.Header_footer:
                    {
                        text1 = "HF";
                        goto Label_003E;
                    }
                    case EContainer.ForegroundImage_graphic:
                    {
                        text1 = "FG";
                        goto Label_003E;
                    }
                    case EContainer.BackgroundImage_graphic:
                    {
                        goto Label_0038;
                    }
                    case EContainer.Logo:
                    {
                        text1 = "L";
                        goto Label_003E;
                    }
                }
                goto Label_003E;
            Label_0038:
                text1 = "BG";
            Label_003E:
                this.Dict["Subtype"] = Library.CreateName(text1);
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;

    public class OCGUsage : Resource
    {
        // Methods
        public OCGUsage(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new OCGUsage(direct);
        }


        // Properties
        public CreatorInfo CreatorInfo
        {
            get
            {
                PDFDict dict1 = (this.Dict["CreatorInfo"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(CreatorInfo)) as CreatorInfo);
            }
            set
            {
                this.Dict["CreatorInfo"] = value.Direct;
            }
        }

        public Export Export
        {
            get
            {
                PDFDict dict1 = (this.Dict["Export"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(Export)) as Export);
            }
            set
            {
                this.Dict["Export"] = value.Direct;
            }
        }

        public LanguageSpecification Language
        {
            get
            {
                PDFDict dict1 = (this.Dict["LanguageInfo"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(LanguageSpecification)) as LanguageSpecification);
            }
            set
            {
                this.Dict["LanguageInfo"] = value.Direct;
            }
        }

        public PageElement PageElement
        {
            get
            {
                PDFDict dict1 = (this.Dict["PageElement"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(PageElement)) as PageElement);
            }
            set
            {
                this.Dict["PageElement"] = value.Direct;
            }
        }

        public PrintInfo Print
        {
            get
            {
                PDFDict dict1 = (this.Dict["Print"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(PrintInfo)) as PrintInfo);
            }
            set
            {
                this.Dict["Print"] = value.Direct;
            }
        }

        public UserInfo User
        {
            get
            {
                PDFDict dict1 = (this.Dict["User"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(UserInfo)) as UserInfo);
            }
            set
            {
                this.Dict["User"] = value.Direct;
            }
        }

        public ViewInfo View
        {
            get
            {
                PDFDict dict1 = (this.Dict["View"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(ViewInfo)) as ViewInfo);
            }
            set
            {
                this.Dict["View"] = value.Direct;
            }
        }

        public ZoomInfo Zoom
        {
            get
            {
                PDFDict dict1 = (this.Dict["Zoom"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(ZoomInfo)) as ZoomInfo);
            }
            set
            {
                this.Dict["Zoom"] = value.Direct;
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;

    public class BoxColor : Resource
    {
        // Methods
        public BoxColor(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new BoxColor(direct);
        }


        // Properties
        public BoxStyle ArtBox
        {
            get
            {
                PDFDict dict1 = (this.Dict["ArtBox"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(BoxStyle)) as BoxStyle);
            }
            set
            {
                this.Dict["ArtBox"] = value.Direct;
            }
        }

        public BoxStyle BleedBox
        {
            get
            {
                PDFDict dict1 = (this.Dict["BleedBox"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(BoxStyle)) as BoxStyle);
            }
            set
            {
                this.Dict["BleedBox"] = value.Direct;
            }
        }

        public BoxStyle CropBox
        {
            get
            {
                PDFDict dict1 = (this.Dict["CropBox"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(BoxStyle)) as BoxStyle);
            }
            set
            {
                this.Dict["CropBox"] = value.Direct;
            }
        }

        public BoxStyle TrimBox
        {
            get
            {
                PDFDict dict1 = (this.Dict["TrimBox"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(BoxStyle)) as BoxStyle);
            }
            set
            {
                this.Dict["TrimBox"] = value.Direct;
            }
        }

    }
}


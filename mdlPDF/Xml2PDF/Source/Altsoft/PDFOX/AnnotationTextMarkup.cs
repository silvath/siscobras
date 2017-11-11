namespace Altsoft.PDFO
{
    using System;

    public class AnnotationTextMarkup : AnnotationMarkup
    {
        // Methods
        public AnnotationTextMarkup(PDFDict dict) : base(dict)
        {
        }


        // Properties
        public quadrilateralList QuadPoints
        {
            get
            {
                PDFDict dict1 = (this.Dict["QuadPoints"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(quadrilateralList)) as quadrilateralList);
            }
            set
            {
                this.Dict["QuadPoints"] = value.Direct;
            }
        }

        public override string SubType
        {
            get
            {
                return base.SubType;
            }
        }

    }
}


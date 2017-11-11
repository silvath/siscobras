namespace Altsoft.PDFO
{
    using System;

    public class GraphPrimitiveAnnot : AnnotationMarkup
    {
        // Methods
        public GraphPrimitiveAnnot(PDFDict dict) : base(dict)
        {
        }


        // Properties
        public double BIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["IC"] as PDFArray);
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
                    this.Dict.Remove("IC");
                }
                if (this.RGB == null)
                {
                    this.RGB = Library.CreateArray(3);
                }
                this.RGB[2] = Library.CreateFixed(value);
                this.Dict["C"] = this.RGB;
            }
        }

        public double GIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["IC"] as PDFArray);
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
                    this.Dict.Remove("IC");
                }
                if (this.RGB == null)
                {
                    this.RGB = Library.CreateArray(3);
                }
                this.RGB[1] = Library.CreateFixed(value);
                this.Dict["C"] = this.RGB;
            }
        }

        public double RIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["IC"] as PDFArray);
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
                    this.Dict.Remove("IC");
                }
                if (this.RGB == null)
                {
                    this.RGB = Library.CreateArray(3);
                }
                this.RGB[0] = Library.CreateFixed(value);
                this.Dict["C"] = this.RGB;
            }
        }


        // Fields
        private PDFArray RGB;
    }
}


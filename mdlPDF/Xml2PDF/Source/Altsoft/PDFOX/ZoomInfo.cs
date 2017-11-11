namespace Altsoft.PDFO
{
    using System;

    public class ZoomInfo : Resource
    {
        // Methods
        public ZoomInfo(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new ZoomInfo(direct);
        }


        // Properties
        public double max
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["max"] as PDFFixed);
                if (fixed1 == null)
                {
                    return NaNf;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["max"] = Library.CreateFixed(value);
            }
        }

        public double min
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["min"] as PDFFixed);
                if (fixed1 == null)
                {
                    return 0f;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["min"] = Library.CreateFixed(value);
            }
        }

    }
}


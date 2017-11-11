namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public class HalftoneThreshold : Halftone
    {
        // Methods
        public HalftoneThreshold(PDFDirect direct) : base(direct)
        {
        }


        // Properties
        public string IsTranferFunctionIdentity
        {
            get
            {
                PDFName name1 = (this.Dict["TransferFunction"] as PDFName);
                if (name1 == null)
                {
                    return null;
                }
                return name1.Value;
            }
            set
            {
                this.Dict["TransferFunction"] = Library.CreateName(value);
            }
        }

        public Stream Threshold
        {
            get
            {
                return (base.Direct as PDFStream).Decode();
            }
        }

        public Function TransferFunction
        {
            get
            {
                PDFDirect direct1 = (this.Dict["TransferFunction"] as PDFDirect);
                if (direct1 == null)
                {
                    return null;
                }
                return (Resources.Get(direct1, typeof(Function)) as Function);
            }
            set
            {
                this.Dict["TransferFunction"] = value.Dict;
            }
        }

    }
}


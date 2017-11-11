namespace Altsoft.PDFO
{
    using System;

    public class HalftoneType16 : HalftoneThreshold
    {
        // Methods
        public HalftoneType16(PDFDirect direct) : base(direct)
        {
        }


        // Properties
        public int Height
        {
            get
            {
                return (this.Dict["Height"] as PDFInteger).Int32Value;
            }
            set
            {
                this.Dict["Height"] = Library.CreateInteger(((long) value));
            }
        }

        public int Height2
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Height2"] as PDFInteger);
                if (integer1 == null)
                {
                    return -2147483648;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.Dict["Height2"] = Library.CreateInteger(((long) value));
            }
        }

        public int Width
        {
            get
            {
                return (this.Dict["Width"] as PDFInteger).Int32Value;
            }
            set
            {
                this.Dict["Width"] = Library.CreateInteger(((long) value));
            }
        }

        public int Width2
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Width2"] as PDFInteger);
                if (integer1 == null)
                {
                    return -2147483648;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.Dict["Width2"] = Library.CreateInteger(((long) value));
            }
        }

    }
}


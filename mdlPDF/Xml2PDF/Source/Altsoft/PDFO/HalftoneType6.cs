namespace Altsoft.PDFO
{
    using System;

    public class HalftoneType6 : HalftoneThreshold
    {
        // Methods
        public HalftoneType6(PDFDirect direct) : base(direct)
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

    }
}


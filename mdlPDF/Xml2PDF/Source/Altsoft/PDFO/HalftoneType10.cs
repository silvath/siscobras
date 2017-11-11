namespace Altsoft.PDFO
{
    using System;

    public class HalftoneType10 : HalftoneThreshold
    {
        // Methods
        public HalftoneType10(PDFDirect direct) : base(direct)
        {
        }


        // Properties
        public int XSquare
        {
            get
            {
                return (this.Dict["XSquare"] as PDFInteger).Int32Value;
            }
            set
            {
                this.Dict["XSquare"] = Library.CreateInteger(((long) value));
            }
        }

        public int YSquare
        {
            get
            {
                return (this.Dict["YSquare"] as PDFInteger).Int32Value;
            }
            set
            {
                this.Dict["YSquare"] = Library.CreateInteger(((long) value));
            }
        }

    }
}


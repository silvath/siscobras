namespace Altsoft.PDFO
{
    using System;

    public class LineDashPattern : PDFInt64Array
    {
        // Methods
        internal LineDashPattern(PDFArray arr) : base((arr[0] as PDFArray), (arr[0] as PDFArray).Count)
        {
            this.mParArr = arr;
        }

        public LineDashPattern Set(LineDashPattern src)
        {
            base.Set(src);
            this.Phase = src.Phase;
            return this;
        }


        // Properties
        public int Phase
        {
            get
            {
                PDFInteger integer1 = (this.mParArr[1] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.mParArr[1] = Library.CreateInteger(((long) value));
            }
        }


        // Fields
        private PDFArray mParArr;
    }
}


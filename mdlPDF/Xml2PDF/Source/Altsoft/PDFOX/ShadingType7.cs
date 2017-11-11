namespace Altsoft.PDFO
{
    using System;

    public class ShadingType7 : ShadingByStream
    {
        // Methods
        public ShadingType7(PDFDirect d) : base(d)
        {
        }


        // Properties
        public int BitsPerFlag
        {
            get
            {
                PDFInteger integer1 = (this.Dict["BitsPerFlag"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return integer1.Int32Value;
            }
            set
            {
                if ((((value != 1) && (value != 2)) && ((value != 4) && (value != 8))) && (((value != 12) && (value != 16)) && ((value != 24) && (value != 32))))
                {
                    throw new ArgumentException("BitsPerFlag must be one of {1,2,4,8,12,16,24,32}", "value");
                }
                this.Dict["BitsPerFlag"] = Library.CreateInteger(((long) value));
            }
        }

    }
}


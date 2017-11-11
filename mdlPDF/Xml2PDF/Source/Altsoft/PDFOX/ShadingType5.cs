namespace Altsoft.PDFO
{
    using System;

    public class ShadingType5 : ShadingByStream
    {
        // Methods
        public ShadingType5(PDFDirect d) : base(d)
        {
        }


        // Properties
        public int VerticesPerRow
        {
            get
            {
                PDFInteger integer1 = (this.Dict["VerticesPerRow"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return integer1.Int32Value;
            }
            set
            {
                if (value <= 2)
                {
                    throw new ArgumentException("VerticesPerRow must be greater than 2", "value");
                }
                this.Dict["VerticesPerRow"] = Library.CreateInteger(((long) value));
            }
        }

    }
}


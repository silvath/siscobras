namespace Altsoft.PDFO
{
    using System;

    public class Halftone : Resource
    {
        // Methods
        public Halftone(PDFDirect direct) : base(direct)
        {
        }


        // Properties
        public string HalftoneName
        {
            get
            {
                PDFString text1 = (this.Dict["HalftoneName"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["HalftoneName"] = Library.CreateString(value);
            }
        }

        public EHalftoneType HalftoneType
        {
            get
            {
                return ((EHalftoneType) (this.Dict["HalftoneType"] as PDFInteger).Int32Value);
            }
            set
            {
                this.Dict["HalftoneType"] = Library.CreateInteger(((long) value));
            }
        }


        // Fields
        public const string Type = "Halftone";
    }
}


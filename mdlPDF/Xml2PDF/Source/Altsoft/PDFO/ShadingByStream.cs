namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public abstract class ShadingByStream : Shading
    {
        // Methods
        public ShadingByStream(PDFDirect d) : base(d)
        {
            this.mDecode = null;
        }


        // Properties
        public int BitsPerComponent
        {
            get
            {
                PDFInteger integer1 = (this.Dict["BitsPerComponent"] as PDFInteger);
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
                    throw new ArgumentException("BitsPerComponent must be one of {1,2,4,8,12,16,24,32}", "value");
                }
                this.Dict["BitsPerComponent"] = Library.CreateInteger(((long) value));
            }
        }

        public int BitsPerCoordinate
        {
            get
            {
                PDFInteger integer1 = (this.Dict["BitsPerCoordinate"] as PDFInteger);
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
                    throw new ArgumentException("BitsPerCoordinate must be one of {1,2,4,8,12,16,24,32}", "value");
                }
                this.Dict["BitsPerCoordinate"] = Library.CreateInteger(((long) value));
            }
        }

        public DoubleMinMaxArray Decode
        {
            get
            {
                PDFArray array1;
                if (this.mDecode == null)
                {
                    array1 = (this.Dict["Decode"] as PDFArray);
                    if (array1 != null)
                    {
                        this.mDecode = new DoubleMinMaxArray(new PDFDoubleArray(array1, array1.Count));
                    }
                }
                return this.mDecode;
            }
            set
            {
                double[] numArray1;
                if (this.Decode == null)
                {
                    numArray1 = new double[(value.Count * 2)];
                    this.mDecode = new DoubleMinMaxArray(new PDFDoubleArray(this.Dict, "Decode", false, numArray1));
                }
                this.Decode.Set(value);
            }
        }


        // Fields
        private DoubleMinMaxArray mDecode;
    }
}


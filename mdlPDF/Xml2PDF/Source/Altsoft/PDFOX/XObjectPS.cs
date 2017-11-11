namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public class XObjectPS : XObject
    {
        // Methods
        internal XObjectPS(PDFDirect d) : base(d)
        {
        }

        public static XObjectPS Create(Stream ps)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Type"] = PDF.N("XObject");
            dict1["Subtype"] = PDF.N("PS");
            PDFStream stream1 = Library.CreateStream(ps, dict1);
            return (Resources.Get(stream1, typeof(XObjectPS)) as XObjectPS);
        }


        // Properties
        public Stream Level1Stream
        {
            get
            {
                PDFStream stream1 = (this.Dict["Level1"] as PDFStream);
                if (stream1 == null)
                {
                    return null;
                }
                return stream1.Decode();
            }
            set
            {
                this.Dict["Level1"] = Library.CreateStream(value);
            }
        }

        public Stream Stream
        {
            get
            {
                return (base.Direct as PDFStream).Decode();
            }
            set
            {
                (base.Direct as PDFStream).Encode(value);
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public class EmbeddedFileStream : Resource
    {
        // Methods
        public EmbeddedFileStream(PDFDirect direct) : base(direct)
        {
        }

        public static EmbeddedFileStream Create(bool indirect, Stream _str)
        {
            PDFStream stream1 = Library.CreateStream(_str);
            EmbeddedFileStream stream2 = (Resources.Get(stream1, typeof(EmbeddedFileStream)) as EmbeddedFileStream);
            if (indirect)
            {
                Library.CreateIndirect(stream1);
            }
            return stream2;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new EmbeddedFileStream(direct);
        }


        // Properties
        public EmbeddedFileParams Params
        {
            get
            {
                PDFObject obj1 = this.Dict["Params"];
                if (obj1 == null)
                {
                    return null;
                }
                return (Resources.Get(obj1, typeof(EmbeddedFileParams)) as EmbeddedFileParams);
            }
            set
            {
                this.Dict["Params"] = value.Dict;
            }
        }

        public PDFStream PDFStream
        {
            get
            {
                return (Resources.Get(this.Dict, typeof(PDFStream)) as PDFStream);
            }
        }

        public string SubType
        {
            get
            {
                PDFName name1 = (this.Dict["Subtype"] as PDFName);
                if (name1 == null)
                {
                    return null;
                }
                return name1.Value;
            }
        }


        // Fields
        public const string Type = "EmbeddedFile";
    }
}


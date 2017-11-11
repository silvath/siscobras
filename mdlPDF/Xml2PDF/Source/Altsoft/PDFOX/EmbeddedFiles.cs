namespace Altsoft.PDFO
{
    using System;

    public class EmbeddedFiles : Resource
    {
        // Methods
        public EmbeddedFiles(PDFDirect direct) : base(direct)
        {
        }

        public static EmbeddedFiles Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            EmbeddedFiles files1 = (Resources.Get(dict1, typeof(EmbeddedFiles)) as EmbeddedFiles);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return files1;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new EmbeddedFiles(direct);
        }


        // Properties
        public EmbeddedFileStream File
        {
            get
            {
                PDFObject obj1 = this.Dict["F"];
                if (obj1 == null)
                {
                    return null;
                }
                return (Resources.Get(obj1, typeof(EmbeddedFileStream)) as EmbeddedFileStream);
            }
            set
            {
                this.Dict["F"] = value.Direct;
            }
        }

        public EmbeddedFileStream FileDOS
        {
            get
            {
                PDFObject obj1 = this.Dict["Dos"];
                if (obj1 == null)
                {
                    return null;
                }
                return (Resources.Get(obj1, typeof(EmbeddedFileStream)) as EmbeddedFileStream);
            }
            set
            {
                this.Dict["Dos"] = value.Dict;
            }
        }

        public EmbeddedFileStream FileMac
        {
            get
            {
                PDFObject obj1 = this.Dict["Mac"];
                if (obj1 == null)
                {
                    return null;
                }
                return (Resources.Get(obj1, typeof(EmbeddedFileStream)) as EmbeddedFileStream);
            }
            set
            {
                this.Dict["Mac"] = value.Dict;
            }
        }

        public EmbeddedFileStream FileUnix
        {
            get
            {
                PDFObject obj1 = this.Dict["Unix"];
                if (obj1 == null)
                {
                    return null;
                }
                return (Resources.Get(obj1, typeof(EmbeddedFileStream)) as EmbeddedFileStream);
            }
            set
            {
                this.Dict["Unix"] = value.Dict;
            }
        }

    }
}


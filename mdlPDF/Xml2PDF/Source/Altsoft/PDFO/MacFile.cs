namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public class MacFile : Resource
    {
        // Methods
        public MacFile(PDFDirect direct) : base(direct)
        {
        }

        public static MacFile Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            MacFile file1 = (Resources.Get(dict1, typeof(MacFile)) as MacFile);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return file1;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new MacFile(direct);
        }


        // Properties
        public string Creator
        {
            get
            {
                PDFString text1 = (this.Dict["Creator"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["Creator"] = Library.CreateString(value);
            }
        }

        public Stream ResFork
        {
            get
            {
                PDFStream stream1 = (this.Dict["ResFork"] as PDFStream);
                if (stream1 == null)
                {
                    return null;
                }
                return stream1.Decode();
            }
            set
            {
                this.Dict["ResFork"] = Library.CreateStream(value);
            }
        }

        public string SubType
        {
            get
            {
                PDFString text1 = (this.Dict["Subtype"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["Subtype"] = Library.CreateString(value);
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public class FileSpec : Resource
    {
        // Methods
        public FileSpec(PDFDirect obj) : base(obj)
        {
        }

        public static FileSpec Create(bool indirect, Stream obj, string filespec)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Type"] = Library.CreateName("Filespec");
            FileSpec spec1 = (Resources.Get(dict1, typeof(FileSpec)) as FileSpec);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            spec1.EmbeddedFiles = EmbeddedFiles.Create(false);
            spec1.EmbeddedFiles.File = EmbeddedFileStream.Create(false, obj);
            spec1.FileSpecStr = filespec;
            return spec1;
        }

        internal static Resource Factory(PDFDirect direct)
        {
            return new FileSpec(direct);
        }

        private static string FileSpecStrToStr(string value)
        {
            return value.Replace(@"\", "");
        }

        private static string StrToFileSpecStr(string value)
        {
            return value.Replace("/", @"\/");
        }


        // Properties
        public EmbeddedFiles EmbeddedFiles
        {
            get
            {
                PDFDict dict1 = (this.Dict["EF"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(EmbeddedFiles)) as EmbeddedFiles);
            }
            set
            {
                this.Dict["EF"] = value.Dict;
            }
        }

        public string FileNameDOS
        {
            get
            {
                PDFString text1 = (this.Dict["Dos"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return FileSpec.FileSpecStrToStr(text1.Value);
            }
            set
            {
                this.Dict["Dos"] = Library.CreateString(FileSpec.StrToFileSpecStr(value));
            }
        }

        public string FileNameMac
        {
            get
            {
                PDFString text1 = (this.Dict["Mac"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return FileSpec.FileSpecStrToStr(text1.Value);
            }
            set
            {
                this.Dict["Mac"] = Library.CreateString(FileSpec.StrToFileSpecStr(value));
            }
        }

        public string FileNameUnix
        {
            get
            {
                PDFString text1 = (this.Dict["Unix"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return FileSpec.FileSpecStrToStr(text1.Value);
            }
            set
            {
                this.Dict["Unix"] = Library.CreateString(FileSpec.StrToFileSpecStr(value));
            }
        }

        public string FileSpecStr
        {
            get
            {
                PDFString text1 = (this.Dict["F"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return FileSpec.FileSpecStrToStr(text1.Value);
            }
            set
            {
                this.Dict["F"] = Library.CreateString(FileSpec.StrToFileSpecStr(value));
            }
        }

        public string FileSystem
        {
            get
            {
                PDFName name1 = (this.Dict["FS"] as PDFName);
                if (name1 == null)
                {
                    return null;
                }
                return name1.Value;
            }
            set
            {
                this.Dict["FS"] = Library.CreateName(value);
            }
        }

        public bool IsAbsolute
        {
            get
            {
                return (this.mPath[0] == '/');
            }
        }

        public bool IsValid
        {
            get
            {
                return true;
            }
        }

        public string Path
        {
            get
            {
                return this.mPath;
            }
        }

        public bool Volatile
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["V"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["V"] = Library.CreateBoolean(value);
            }
        }


        // Fields
        private string mPath;
        public const string Type = "Filespec";
    }
}


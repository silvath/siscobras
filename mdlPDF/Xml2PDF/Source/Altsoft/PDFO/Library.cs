namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Collections;
    using System.IO;
    using System.Reflection;

    public abstract class Library
    {
        // Methods
        static Library()
        {
            Library.mResources = null;
            Library.EncryptionHandlers = new ArrayList();
            Library.mLibrary = null;
        }

        protected Library()
        {
        }

        protected abstract PDFArray _CreateArray(int size);

        protected abstract PDFBoolean _CreateBoolean(bool val);

        protected abstract PDFDict _CreateDict();

        protected abstract PDFFixed _CreateFixed(double val);

        protected abstract PDFIndirect _CreateIndirect();

        protected abstract PDFInteger _CreateInteger(long val);

        protected abstract PDFName _CreateName(string val);

        protected abstract PDFNull _CreateNull();

        protected abstract PDFStream _CreateStream(Stream src, long offset, long count, PDFDict strmDict, bool encodeAndEncrypt);

        protected abstract PDFStream _CreateStream(byte[] buffer, int offset, int count, bool copyData, PDFDict strmDict, bool encodeAndEncrypt);

        protected abstract PDFString _CreateString(string val);

        protected abstract Document _OpenDocument(string fileName, DocOpenMode mode, FileShare shareMode, string header, IExternalStreamHandler extHandler, ISecurityHandler secHandler);

        public static Document BuildDefaultResources(string pathToFileToBuildTo)
        {
            Document document1 = Library.OpenDocument(pathToFileToBuildTo, DocOpenMode.Create);
            PDFDict dict1 = document1.Info;
            dict1["Title"] = Library.CreateString("Standard Resources Container for PDFO.NET based projects");
            dict1["Author"] = Library.CreateString("Victor Vishnyakov via PDFO.NET");
            Page page1 = document1.Pages.Add();
            page1.MediaBox = new Rect(0f, 0f, 612f, 792f);
            Resource resource1 = document1.Resources[Library.BuildStandardFont(document1, "Helvetica"), typeof(Font)];
            page1.Resources.Add("HELVETICA", resource1);
            resource1 = document1.Resources[Library.BuildStandardFont(document1, "Times-Roman"), typeof(Font)];
            page1.Resources.Add("TIMES_ROMAN", resource1);
            resource1 = document1.Resources[Library.BuildStandardFont(document1, "Times-Bold"), typeof(Font)];
            page1.Resources.Add("TIMES_BOLD", resource1);
            resource1 = document1.Resources[Library.BuildStandardFont(document1, "Courier"), typeof(Font)];
            page1.Resources.Add("COURIER", resource1);
            resource1 = document1.Resources[Library.BuildStandardFont(document1, "Symbol"), typeof(Font)];
            page1.Resources.Add("SYMBOL", resource1);
            resource1 = document1.Resources[Library.BuildStandardFont(document1, "Helvetica-Bold"), typeof(Font)];
            page1.Resources.Add("HELVETICA_BOLD", resource1);
            resource1 = document1.Resources[Library.BuildStandardFont(document1, "Courier-Bold"), typeof(Font)];
            page1.Resources.Add("COURIER_BOLD", resource1);
            resource1 = document1.Resources[Library.BuildStandardFont(document1, "ZapfDingbats"), typeof(Font)];
            page1.Resources.Add("ZAPFDINGBATS", resource1);
            resource1 = document1.Resources[Library.BuildStandardFont(document1, "Times-Italic"), typeof(Font)];
            page1.Resources.Add("TIMES_ITALIC", resource1);
            resource1 = document1.Resources[Library.BuildStandardFont(document1, "Helvetica-Oblique"), typeof(Font)];
            page1.Resources.Add("HELVETICA_OBLIQUE", resource1);
            resource1 = document1.Resources[Library.BuildStandardFont(document1, "Courier-Oblique"), typeof(Font)];
            page1.Resources.Add("COURIER_OBLIQUE", resource1);
            resource1 = document1.Resources[Library.BuildStandardFont(document1, "Times-BoldItalic"), typeof(Font)];
            page1.Resources.Add("TIMES_BOLDITALIC", resource1);
            resource1 = document1.Resources[Library.BuildStandardFont(document1, "Helvetica-BoldOblique"), typeof(Font)];
            page1.Resources.Add("HELVETICA_BOLDOBLIQUE", resource1);
            resource1 = document1.Resources[Library.BuildStandardFont(document1, "Courier-BoldOblique"), typeof(Font)];
            page1.Resources.Add("COURIER_BOLDOBLIQUE", resource1);
            return document1;
        }

        protected static PDFIndirect BuildStandardFont(Document doc, string fontname)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Type"] = Library.CreateName("Font");
            dict1["Subtype"] = Library.CreateName("Type1");
            dict1["Encoding"] = Library.CreateName("WinAnsiEncoding");
            dict1["BaseFont"] = Library.CreateName(fontname);
            PDFIndirect indirect1 = doc.Indirects.New();
            indirect1.Direct = dict1;
            return indirect1;
        }

        public static void CopyArray(PDFArray src, int srcOffset, int srcCount, Array dst, int dstOffset)
        {
            int num1;
            PDFObject obj1;
            Type type1;
            MethodInfo info1;
            for (num1 = 0; (num1 < srcCount); num1 += 1)
            {
                obj1 = src[(num1 + srcOffset)];
                type1 = obj1.GetType();
                info1 = type1.GetMethod("get_Value");
                dst.SetValue(info1.Invoke(obj1, null), (dstOffset + num1));
            }
        }

        public static PDFArray CreateArray()
        {
            return Library.CreateArray(0);
        }

        public static PDFArray CreateArray(int size)
        {
            return Library.Instance._CreateArray(size);
        }

        public static PDFArray CreateArray(bool treatStringAsName, object _array)
        {
            Array array2;
            int num1;
            PDFArray array1 = null;
            if (_array.GetType().IsArray)
            {
                array2 = (_array as Array);
                array1 = Library.CreateArray(array2.Length);
                for (num1 = 0; (num1 < array2.Length); num1 += 1)
                {
                    array1[num1] = Library.CreateObject(treatStringAsName, array2.GetValue(num1));
                }
                return array1;
            }
            if (!(_array is ICollection))
            {
                return array1;
            }
            ICollection collection1 = (_array as ICollection);
            array1 = Library.CreateArray(collection1.Count);
            int num2 = 0;
            foreach (object obj1 in collection1)
            {
                int num3 = num2;
                num2 = (num3 + 1);
                array1[num2] = Library.CreateObject(treatStringAsName, obj1);
            }
            return array1;
        }

        public static PDFBoolean CreateBoolean(bool val)
        {
            return Library.Instance._CreateBoolean(val);
        }

        public static PDFDict CreateDict()
        {
            return Library.Instance._CreateDict();
        }

        public static PDFDict CreateDict(bool treatStringAsName, IDictionary dict)
        {
            PDFDict dict1 = Library.CreateDict();
            foreach (DictionaryEntry entry1 in dict)
            {
                dict1[entry1.Key.ToString()] = Library.CreateObject(treatStringAsName, entry1.Value);
            }
            return dict1;
        }

        public static PDFDirect CreateDirect(PDFObjectType type)
        {
            PDFObjectType type1 = type;
            switch (type1)
            {
                case PDFObjectType.tPDFNull:
                {
                    goto Label_0060;
                }
                case PDFObjectType.tPDFInteger:
                {
                    goto Label_004D;
                }
                case PDFObjectType.tPDFFixed:
                {
                    goto Label_003E;
                }
                case PDFObjectType.tPDFBoolean:
                {
                    goto Label_0031;
                }
                case PDFObjectType.tPDFName:
                {
                    goto Label_0055;
                }
                case PDFObjectType.tPDFString:
                {
                    goto Label_0066;
                }
                case PDFObjectType.tPDFDict:
                {
                    goto Label_0038;
                }
                case PDFObjectType.tPDFArray:
                {
                    goto Label_002A;
                }
            }
            goto Label_0071;
        Label_002A:
            return Library.CreateArray(0);
        Label_0031:
            return Library.CreateBoolean(false);
        Label_0038:
            return Library.CreateDict();
        Label_003E:
            return Library.CreateFixed(0f);
        Label_004D:
            return Library.CreateInteger(((long) 0));
        Label_0055:
            return Library.CreateName("");
        Label_0060:
            return Library.CreateNull();
        Label_0066:
            return Library.CreateString("");
        Label_0071:
            throw new ArgumentOutOfRangeException("type", type, "Invalid direct type");
        }

        public static PDFFixed CreateFixed(double val)
        {
            return Library.Instance._CreateFixed(val);
        }

        public static PDFIndirect CreateIndirect()
        {
            return Library.Instance._CreateIndirect();
        }

        public static PDFIndirect CreateIndirect(PDFDirect direct)
        {
            PDFIndirect indirect1 = Library.Instance._CreateIndirect();
            indirect1.Direct = direct;
            return indirect1;
        }

        public static PDFInteger CreateInteger(long val)
        {
            return Library.Instance._CreateInteger(val);
        }

        public static PDFName CreateName(string val)
        {
            return Library.Instance._CreateName(val);
        }

        public static PDFNull CreateNull()
        {
            return Library.Instance._CreateNull();
        }

        public static PDFObject CreateObject(bool treatStringAsName, object o)
        {
            if (o == null)
            {
                return Library.CreateNull();
            }
            Type type1 = o.GetType();
            if (type1.Equals(typeof(double)))
            {
                return Library.CreateFixed(((double) o));
            }
            if (type1.Equals(typeof(float)))
            {
                return Library.CreateFixed(((double) ((float) o)));
            }
            if (type1.Equals(typeof(int)))
            {
                return Library.CreateInteger(((long) ((int) o)));
            }
            if (type1.Equals(typeof(uint)))
            {
                return Library.CreateInteger(((ulong) ((uint) o)));
            }
            if (type1.Equals(typeof(string)))
            {
                if (treatStringAsName)
                {
                    return Library.CreateName(((string) o));
                }
                return Library.CreateString(((string) o));
            }
            if (type1.Equals(typeof(bool)))
            {
                return Library.CreateBoolean(((bool) o));
            }
            if (type1.IsArray)
            {
                return Library.CreateArray(treatStringAsName, o);
            }
            if (type1.GetInterface("System.Collections.IDictionary", false) != null)
            {
                return Library.CreateDict(treatStringAsName, ((IDictionary) o));
            }
            if (type1.GetInterface("System.Collections.ICollection", false) != null)
            {
                return Library.CreateArray(treatStringAsName, o);
            }
            throw new ArgumentException("Invalid item", "o");
        }

        public static PDFStream CreateStream()
        {
            return Library.CreateStream(Stream.Null, ((long) 0), ((long) 0), null);
        }

        public static PDFStream CreateStream(Stream src)
        {
            return Library.CreateStream(src, Library.CreateDict(), true);
        }

        public static PDFStream CreateStream(Stream src, PDFDict strmDict)
        {
            return Library.CreateStream(src, strmDict, true);
        }

        public static PDFStream CreateStream(Stream src, PDFDict strmDict, bool encodeAndEncrypt)
        {
            Stream stream1 = new MemoryStream();
            byte[] numArray1 = new byte[65536];
            int num1 = 0;
            goto Label_001E;
        Label_0015:
            stream1.Write(numArray1, 0, num1);
        Label_001E:
            num1 = src.Read(numArray1, 0, numArray1.Length);
            if (num1 != 0)
            {
                goto Label_0015;
            }
            stream1.Position = ((long) 0);
            return Library.CreateStream(stream1, ((long) 0), stream1.Length, strmDict, encodeAndEncrypt);
        }

        public static PDFStream CreateStream(Stream src, long offset, long count, PDFDict strmDict)
        {
            return Library.CreateStream(src, offset, count, strmDict, true);
        }

        public static PDFStream CreateStream(Stream src, long offset, long count, PDFDict strmDict, bool encodeAndEncrypt)
        {
            return Library.Instance._CreateStream(src, offset, count, strmDict, encodeAndEncrypt);
        }

        public static PDFStream CreateStream(byte[] buffer, int offset, int count, bool copyData, PDFDict strmDict)
        {
            return Library.CreateStream(buffer, offset, count, copyData, strmDict, true);
        }

        public static PDFStream CreateStream(byte[] buffer, int offset, int count, bool copyData, PDFDict strmDict, bool encodeAndEncrypt)
        {
            return Library.Instance._CreateStream(buffer, offset, count, copyData, strmDict, encodeAndEncrypt);
        }

        public static PDFString CreateString(string val)
        {
            return Library.Instance._CreateString(val);
        }

        public static Document OpenDocument(string fileName)
        {
            return Library.OpenDocument(fileName, DocOpenMode.Read);
        }

        public static Document OpenDocument(string fileName, DocOpenMode mode)
        {
            return Library.OpenDocument(fileName, mode, FileShare.Read);
        }

        public static Document OpenDocument(string fileName, DocOpenMode mode, FileShare shareMode)
        {
            return Library.OpenDocument(fileName, mode, shareMode, "%PDF-");
        }

        public static Document OpenDocument(string fileName, DocOpenMode mode, FileShare shareMode, string header)
        {
            return Library.OpenDocument(fileName, mode, shareMode, header, null);
        }

        public static Document OpenDocument(string fileName, DocOpenMode mode, FileShare shareMode, string header, IExternalStreamHandler extHandler)
        {
            return Library.OpenDocument(fileName, mode, shareMode, header, extHandler, null);
        }

        public static Document OpenDocument(string fileName, DocOpenMode mode, FileShare shareMode, string header, IExternalStreamHandler extHandler, ISecurityHandler secHandler)
        {
            return Library.Instance._OpenDocument(fileName, mode, shareMode, header, extHandler, secHandler);
        }


        // Properties
        protected abstract PlatformType _Platform { get; }

        public static Library Instance
        {
            get
            {
                return Library.mLibrary;
            }
        }

        public static Hashtable Params
        {
            get
            {
                return Library.Instance.mParams;
            }
        }

        public static PlatformType Platform
        {
            get
            {
                return Library.Instance._Platform;
            }
        }

        public static DocResourceSet Resources
        {
            get
            {
                Document document1;
                if (Library.mResources == null)
                {
                    document1 = Library.BuildDefaultResources("");
                    document1.Resources.FindAllResources();
                    Library.mResources = document1.Pages[0].Resources;
                }
                return Library.mResources;
            }
        }


        // Fields
        public static ArrayList EncryptionHandlers;
        protected static Library mLibrary;
        protected Hashtable mParams;
        private static DocResourceSet mResources;
    }
}


namespace Altsoft.PDFO.Core
{
    using Altsoft.Common;
    using Altsoft.PDFO;
    using System;
    using System.Collections;
    using System.IO;

    public class CoreLibrary : Library
    {
        // Methods
        static CoreLibrary()
        {
            CoreLibrary.PURE_MANAGED = "PureManaged";
        }

        internal CoreLibrary(Hashtable pars)
        {
            Library.mLibrary = this;
            this.mParams = pars;
        }

        protected override PDFArray _CreateArray(int size)
        {
            return new CorePDFArray(size);
        }

        protected override PDFBoolean _CreateBoolean(bool val)
        {
            return new CorePDFBoolean(val);
        }

        protected override PDFDict _CreateDict()
        {
            return new CorePDFDict();
        }

        protected override PDFFixed _CreateFixed(double val)
        {
            return new CorePDFFixed(val);
        }

        protected override PDFIndirect _CreateIndirect()
        {
            return new CorePDFIndirect();
        }

        protected override PDFInteger _CreateInteger(long val)
        {
            return new CorePDFInteger(val);
        }

        protected override PDFName _CreateName(string val)
        {
            return new CorePDFName(val);
        }

        protected override PDFNull _CreateNull()
        {
            return CorePDFNull.Instance;
        }

        protected override PDFStream _CreateStream(Stream src, long offset, long count, PDFDict strmDict, bool encodeAndEncrypt)
        {
            if (strmDict == null)
            {
                strmDict = this._CreateDict();
            }
            return new CorePDFStream(new SubStream(src, offset, count), ((CorePDFDict) strmDict), encodeAndEncrypt);
        }

        protected override PDFStream _CreateStream(byte[] buffer, int offset, int count, bool copyData, PDFDict strmDict, bool encodeAndEncrypt)
        {
            if (strmDict == null)
            {
                strmDict = this._CreateDict();
            }
            if (copyData)
            {
                buffer = ((byte[]) buffer.Clone());
            }
            return new CorePDFStream(new MemoryStream(buffer, offset, count), ((CorePDFDict) strmDict), encodeAndEncrypt);
        }

        protected override PDFString _CreateString(string val)
        {
            return new CorePDFString(val);
        }

        protected override Document _OpenDocument(string fileName, DocOpenMode mode, FileShare shareMode, string header, IExternalStreamHandler extHandler, ISecurityHandler secHandler)
        {
            return new CoreDocument(fileName, mode, shareMode, header, extHandler, secHandler);
        }

        public static bool Init()
        {
            Library.EncryptionHandlers.Add(new EncryptionFactoryDelegate(EncryptionStandard.Factory));
            new CoreLibrary(new Hashtable());
            if (Environment.OSVersion.ToString().IndexOf("Windows") == -1)
            {
                Library.Params[CoreLibrary.PURE_MANAGED] = 1;
            }
            if (Environment.OSVersion.ToString().IndexOf("Windows") != -1)
            {
                ((CoreLibrary) Library.Instance).mPlatform = PlatformType.Win32;
            }
            if (Environment.OSVersion.ToString().IndexOf("Unix") != -1)
            {
                ((CoreLibrary) Library.Instance).mPlatform = PlatformType.Unix;
            }
            return true;
        }

        public static bool Init(Hashtable pars)
        {
            new CoreLibrary(pars);
            if (Environment.OSVersion.ToString().IndexOf("Windows") == -1)
            {
                Library.Params[CoreLibrary.PURE_MANAGED] = 1;
            }
            if (Environment.OSVersion.ToString().IndexOf("Windows") != -1)
            {
                ((CoreLibrary) Library.Instance).mPlatform = PlatformType.Win32;
            }
            if (Environment.OSVersion.ToString().IndexOf("Unix") != -1)
            {
                ((CoreLibrary) Library.Instance).mPlatform = PlatformType.Unix;
            }
            return true;
        }


        // Properties
        protected override PlatformType _Platform
        {
            get
            {
                return this.mPlatform;
            }
        }


        // Fields
        private PlatformType mPlatform;
        public static readonly string PURE_MANAGED;
    }
}


namespace Altsoft.PDFO.Core
{
    using Altsoft.Common;
    using Altsoft.PDFO;
    using System;
    using System.Collections;
    using System.IO;
    using System.Security;
    using System.Security.Cryptography;
    using System.Text;

    public sealed class CoreDocument : Document
    {
        // Methods
        internal CoreDocument(string fileName, DocOpenMode mode, FileShare shareMode, string header, IExternalStreamHandler extHandler, ISecurityHandler secHandler)
        {
            string text1;
            string[] textArray1;
            this.mParser = null;
            this.mStream = null;
            this.mXRef = new ArrayList();
            this.mTrailer = null;
            this.mRoot = null;
            this.mInfo = null;
            this.mSecHandler = null;
            this.mExtHandler = null;
            this.mToSaveQueue = null;
            this.mIndirects = null;
            this.mEncrypt = null;
            this.mEncryption = null;
            this.mWriter = null;
            this.mPrevStartXRef = ((long) -1);
            this.mPath = null;
            try
            {
                this.mPath = fileName;
                this.mShareMode = shareMode;
                this.mIndirects = new CoreIndirectCollection(this);
                this.mFileName = fileName;
                this.mDocOpenMode = mode;
                this.mHeader = header;
                this.mSecHandler = secHandler;
                this.mExtHandler = extHandler;
                if ((mode & DocOpenMode.Read) != 0)
                {
                    this.ReadFile();
                }
                if ((mode & DocOpenMode.Create) != 0)
                {
                    this.Create();
                    text1 = Encoding.ASCII.GetString(this.GenerateFileId(fileName));
                    textArray1 = new string[2];
                    textArray1[0] = text1;
                    textArray1[1] = text1;
                    this.mTrailer["ID"] = PDF.O(textArray1);
                }
                this.mIndirects.UpdateIndirectCount();
                if (this.Init())
                {
                    return;
                }
                throw new PDFException("Error openning document");
            }
            catch
            {
                try
                {
                    if (this.mStream != null)
                    {
                        this.mStream.Close();
                    }
                }
                catch
                {
                }
                throw;
            }
        }

        private void AddWatermarks(bool bCheckLicence, bool bAdd_qQ_ToOrigSc)
        {
            bool flag1;
            Snow snow1;
            uint[] numArray1;
            int num1;
            int num2;
            if (bCheckLicence)
            {
                flag1 = false;
                snow1 = new Snow();
                snow1.LoadKey(41869, Rect.serial[0], 1, 0);
                numArray1 = new uint[3];
                for (num1 = 0; (num1 < 3); num1 += 1)
                {
                    numArray1[num1] = Rect.serial[(num1 + 1)];
                }
                snow1.EncryptDecrypt(ref numArray1);
                flag1 = ((bool) (((((numArray1[0] ^ numArray1[1]) ^ numArray1[2]) & (Circle.productType & 44933)) != (Circle.productType & 44933)) ? 0 : (numArray1[0] == numArray1[1])));
                if (flag1)
                {
                    return;
                }
            }
            WTM_Stamper stamper1 = new WTM_Stamper(this, false, bAdd_qQ_ToOrigSc);
            for (num2 = 0; (num2 < base.Pages.Count); num2 += 1)
            {
                stamper1.AddWatermarks(base.Pages[num2]);
            }
        }

        public override void Close()
        {
            base.Close();
            if (this.mStream != null)
            {
                this.mStream.Close();
            }
            if (this.mXRef != null)
            {
                this.mXRef.Clear();
            }
            this.mXRef = null;
            if (this.mToSaveQueue != null)
            {
                this.mToSaveQueue.Clear();
            }
            this.mToSaveQueue = null;
            this.mIndirects = null;
        }

        private void Create()
        {
            XRefEntry entry1 = new XRefEntry();
            entry1.dirty = false;
            entry1.type = 0;
            entry1.generation = 65535;
            entry1.indirect = null;
            entry1.offset = ((long) 0);
            this.mXRef.Add(entry1);
            this.mRoot = Library.CreateDict();
            this.Indirects.New().Direct = this.mRoot;
            this.mRoot["Type"] = Library.CreateName("Catalog");
            PDFObject obj1 = this.Indirects.New();
            this.mRoot["Pages"] = obj1;
            PDFDirect direct1 = Library.CreateDict();
            obj1.Direct = direct1;
            PDFDict dict1 = ((PDFDict) direct1);
            dict1["Type"] = Library.CreateName("Pages");
            dict1["Count"] = Library.CreateInteger(((long) 0));
            dict1["Kids"] = Library.CreateArray(0);
            this.mInfo = Library.CreateDict();
            this.mTrailer = Library.CreateDict();
            this.mTrailer["Root"] = this.Indirects.New(this.mRoot);
            this.mTrailer["Info"] = this.Indirects.New(this.mInfo);
        }

        protected override PDFIndirect CreateIndirectObject(int id, int gen)
        {
            if (!this.mXRefValid)
            {
                return new CorePDFIndirect(this, id);
            }
            XRefEntry entry1 = ((XRefEntry) this.mXRef[id]);
            if (entry1.indirect == null)
            {
                entry1.indirect = new CorePDFIndirect(this, id);
            }
            return entry1.indirect;
        }

        internal void DecryptObject(PDFDirect direct, int id, int gene)
        {
            PDFObject obj2;
            IEnumerator enumerator1;
            IDisposable disposable1;
            PDFObjectType type1 = direct.PDFType;
            switch (type1)
            {
                case PDFObjectType.tPDFString:
                {
                    ((CorePDFString) direct).mValue = Utils.BytesToString(this.Encryption.DecryptString(((CorePDFString) direct), id, gene));
                    return;
                }
                case PDFObjectType.tPDFDict:
                {
                    goto Label_008F;
                }
                case PDFObjectType.tPDFArray:
                {
                    foreach (PDFObject obj1 in ((PDFArray) direct))
                    {
                        if (obj1.IsIndirect)
                        {
                            continue;
                        }
                        this.DecryptObject(obj1.Direct, id, gene);
                    }
                    return;
                }
            }
            return;
        Label_008F:
            enumerator1 = ((PDFDict) direct).Values.GetEnumerator();
            try
            {
                while (enumerator1.MoveNext())
                {
                    obj2 = ((PDFObject) enumerator1.Current);
                    if (obj2.IsIndirect)
                    {
                        continue;
                    }
                    this.DecryptObject(obj2.Direct, id, gene);
                }
            }
            finally
            {
                disposable1 = (enumerator1 as IDisposable);
                if (disposable1 != null)
                {
                    disposable1.Dispose();
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        private void EnqeueIndirects(Hashtable tab, PDFObject o)
        {
            PDFObject obj1;
            DictionaryEntry entry1;
            IEnumerator enumerator1;
            IDisposable disposable1;
            if (o.IsIndirect)
            {
                tab[o.Indirect] = null;
            }
            PDFDirect direct1 = o.Direct;
            PDFObjectType type1 = direct1.PDFType;
            switch (type1)
            {
                case PDFObjectType.tPDFDict:
                {
                    goto Label_0088;
                }
                case PDFObjectType.tPDFArray:
                {
                    goto Label_0038;
                }
                case PDFObjectType.tPDFStream:
                {
                    goto Label_00EB;
                }
            }
            return;
        Label_0038:
            enumerator1 = ((PDFArray) direct1).GetEnumerator();
            try
            {
                while (enumerator1.MoveNext())
                {
                    obj1 = ((PDFObject) enumerator1.Current);
                    if (tab.Contains(obj1))
                    {
                        continue;
                    }
                    this.EnqeueIndirects(tab, obj1);
                }
                return;
            }
            finally
            {
                disposable1 = (enumerator1 as IDisposable);
                if (disposable1 != null)
                {
                    disposable1.Dispose();
                }
            }
        Label_0088:
            enumerator1 = ((PDFDict) direct1).GetEnumerator();
            try
            {
                while (enumerator1.MoveNext())
                {
                    entry1 = ((DictionaryEntry) enumerator1.Current);
                    if (tab.Contains(entry1.Value))
                    {
                        continue;
                    }
                    this.EnqeueIndirects(tab, ((PDFObject) entry1.Value));
                }
                return;
            }
            finally
            {
                disposable1 = (enumerator1 as IDisposable);
                if (disposable1 != null)
                {
                    disposable1.Dispose();
                }
            }
        Label_00EB:
            this.EnqeueIndirects(tab, ((PDFStream) direct1).Dict);
        }

        internal byte[] GenerateFileId(string path)
        {
            StringBuilder builder1 = new StringBuilder();
            builder1.Append(path);
            DateTime time1 = DateTime.Now;
            builder1.Append(time1.ToString());
            if (this.Info != null)
            {
                foreach (DictionaryEntry entry1 in this.Info)
                {
                    builder1.Append(entry1.Value.ToString());
                }
            }
            return new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(builder1.ToString()));
        }

        protected override bool Init()
        {
            this.mWriter = new PDFWriter();
            return base.Init();
        }

        internal CorePDFDirect ReadDirect(int id)
        {
            CorePDFDirect direct1;
            PDFStream stream1;
            PDFName name1;
            int num4;
            if (!this.mXRefValid)
            {
                return CorePDFNull.Instance;
            }
            if (id > this.mXRef.Count)
            {
                return CorePDFNull.Instance;
            }
            XRefEntry entry1 = ((XRefEntry) this.mXRef[id]);
            int num5 = entry1.type;
            switch (num5)
            {
                case 0:
                {
                    goto Label_0054;
                }
                case 1:
                {
                    if (entry1.offset == ((long) -1))
                    {
                        return CorePDFNull.Instance;
                    }
                    goto Label_006A;
                }
                case 2:
                {
                    stream1 = (this.Indirects[((int) entry1.offset)].Direct as PDFStream);
                    if (stream1 == null)
                    {
                        return CorePDFNull.Instance;
                    }
                    goto Label_00D0;
                }
            }
            goto Label_0218;
        Label_0054:
            return CorePDFNull.Instance;
        Label_006A:
            direct1 = null;
            long num1 = this.mParser.Stream.Position;
            direct1 = this.ReadDirectFromStream(this.mParser, entry1.offset, id, entry1.generation);
            this.mParser.Stream.Position = num1;
            return direct1;
        Label_00D0:
            name1 = (stream1.Dict["Type"] as PDFName);
            if (name1 == null)
            {
                throw new PDFException("Invalid Object Stream");
            }
            if (name1.Value != "ObjStm")
            {
                throw new PDFException("Invalid object stream");
            }
            long num2 = ((long) 0);
            PDFInteger integer1 = (stream1.Dict["First"] as PDFInteger);
            if (integer1 == null)
            {
                throw new PDFException("Invalid Object stream");
            }
            long num3 = integer1.Value;
            PDFInteger integer2 = (stream1.Dict["N"] as PDFInteger);
            if (integer2 == null)
            {
                throw new PDFException("Invalid Object stream");
            }
            bool flag1 = false;
            Stream stream2 = stream1.Decode();
            PDFParser parser1 = new PDFParser(stream2, this);
            for (num4 = 0; (num4 < integer2.Int32Value); num4 += 1)
            {
                integer1 = (parser1.ReadNextObject() as PDFInteger);
                if (integer1 == null)
                {
                    throw new PDFException("Invalid object stream");
                }
                if (integer1.Value != ((long) id))
                {
                    parser1.ReadNextObject();
                }
                else
                {
                    integer1 = (parser1.ReadNextObject() as PDFInteger);
                    if (integer1 == null)
                    {
                        throw new PDFException("Invalid object stream");
                    }
                    num2 = (num3 + integer1.Value);
                    flag1 = true;
                    break;
                }
            }
            if (!flag1)
            {
                return CorePDFNull.Instance;
            }
            stream2.Position = num2;
            return ((CorePDFDirect) parser1.ReadNextObject());
        Label_0218:
            throw new PDFException("Invalid object type");
        }

        internal CorePDFDirect ReadDirectFromStream(PDFParser p, long offset, int id, int gene)
        {
            PDFInteger integer1;
            PDFInteger integer2;
            PDFName name1;
            CorePDFDirect direct1;
            long num1;
            CorePDFDirect direct2;
            p.Stream.Position = offset;
            try
            {
                integer1 = ((PDFInteger) p.ReadNextObject());
                if ((integer1.Value != ((long) id)) && (id != -1))
                {
                    throw new PDFSyntaxException("XREF points to incorrect object. objId doesn\'t match");
                }
                integer2 = ((PDFInteger) p.ReadNextObject());
                if ((integer2.Value != ((long) gene)) && (gene != -1))
                {
                    throw new PDFSyntaxException("XREF points to incorrect object. Generation number doesn\'t match");
                }
                name1 = ((PDFName) p.ReadNextObject());
                if (name1.Value != "obj")
                {
                    throw new PDFSyntaxException("XREF points to incorrect object. \'obj\' token missing");
                }
                direct1 = ((CorePDFDirect) p.ReadNextObject());
                name1 = ((PDFName) p.ReadNextObject());
                if (name1.Value == "stream")
                {
                    p.SkipToEOL();
                    num1 = p.Stream.Position;
                    direct1 = new CorePDFStream(this, p.Stream, num1, ((CorePDFDict) direct1));
                    name1 = ((PDFName) p.ReadNextObject());
                    if (name1.Value != "endstream")
                    {
                        throw new PDFSyntaxException("XREF points to incorrect object. \'endstream\' token missing");
                    }
                    name1 = ((PDFName) p.ReadNextObject());
                }
                if (base.IsEncrypted)
                {
                    this.DecryptObject(direct1, id, gene);
                }
                if (name1.Value == "endobj")
                {
                    return direct1;
                }
                throw new PDFSyntaxException("XREF points to incorrect object. \'endobj\' or \'stream\' token missing");
            }
            catch (InvalidCastException)
            {
                throw new PDFSyntaxException("XREF points to incorrect object");
            }
            return direct2;
        }

        private void ReadFile()
        {
            PDFString text1;
            int num1;
            bool flag1;
            bool flag2;
            long num2;
            PDFNumeric numeric1;
            long num3;
            PDFInteger integer1;
            IEncryption encryption1;
            try
            {
                this.mStream = File.Open(this.mFileName, FileMode.Open, ((((this.mDocOpenMode & DocOpenMode.Read) != 0) ? 1 : 0) | (((this.mDocOpenMode & DocOpenMode.Write) != 0) ? 2 : 0)), this.mShareMode);
                this.mParser = new PDFParser(this.mStream, this);
                this.mParser.SkipComments = false;
                text1 = (this.mParser.ReadNextObject() as PDFString);
                if (text1 == null)
                {
                    throw new PDFSyntaxException("PDF should start with COMMENT HEADER");
                }
                this.mHeader = text1.Value;
                num1 = 16;
                flag1 = false;
                flag2 = false;
                while ((num1 < 1024))
                {
                    this.mStream.Seek(((long) -num1), SeekOrigin.End);
                    flag2 = this.mParser.ParseToName("%%EOF", true);
                    if (flag2 || flag1)
                    {
                        break;
                    }
                    num1 += 16;
                    if (((long) num1) <= this.mStream.Length)
                    {
                        continue;
                    }
                    num1 = ((int) this.mStream.Length);
                    flag1 = true;
                }
                if (!flag2)
                {
                    throw new PDFException("%%EOF not found");
                }
                num2 = this.mStream.Position;
                this.mParser.SkipComments = true;
                for (flag1 = false; (num1 <= 64); flag1 = true)
                {
                    this.mStream.Seek((num2 - ((long) num1)), SeekOrigin.Begin);
                    flag2 = this.mParser.ParseToName("startxref", true);
                    if (flag2 || flag1)
                    {
                        break;
                    }
                    num1 += 16;
                    if (((long) num1) <= this.mStream.Length)
                    {
                        continue;
                    }
                    num1 = ((int) this.mStream.Length);
                }
                if (!flag2)
                {
                    throw new PDFSyntaxException("No STARTXREF token found");
                }
                numeric1 = (this.mParser.ReadNextObject() as PDFNumeric);
                if (numeric1 == null)
                {
                    throw new PDFSyntaxException("STARTXREF must be NUMBER");
                }
                this.mPrevStartXRef = numeric1.Int64Value;
                this.mXRefValid = false;
                num3 = this.ReadXRefTable(numeric1.Int64Value);
                if (num3 != ((long) -1))
                {
                    this.mStream.Position = num3;
                    this.mXRefValid = true;
                    this.mTrailer = ((PDFDict) this.mParser.ReadNextObject());
                    if (((PDFInteger) this.mTrailer["Size"]).Value != ((long) this.mXRef.Count))
                    {
                        throw new PDFException("XREF size incosistent with SIZE key in trailer dictionary");
                    }
                    integer1 = (this.mTrailer["XRefStm"] as PDFInteger);
                    if (integer1 != null)
                    {
                        this.ReadXRefTable(integer1.Int64Value);
                    }
                }
                this.mEncrypt = (this.mTrailer["Encrypt"] as PDFDict);
                if (this.mEncrypt == null)
                {
                    goto Label_02CA;
                }
                foreach (EncryptionFactoryDelegate delegate1 in Library.EncryptionHandlers)
                {
                    encryption1 = delegate1.Invoke(this.mEncrypt, this.mSecHandler);
                    this.mEncryption = encryption1;
                    if (encryption1 != null)
                    {
                        break;
                    }
                }
            Label_02B7:
                if (this.mEncryption == null)
                {
                    throw new PDFException("Unsupported encryption");
                }
            Label_02CA:
                this.mRoot = (this.mTrailer["Root"] as PDFDict);
                this.mInfo = (this.mTrailer["Info"] as PDFDict);
                if (this.mRoot != null)
                {
                    return;
                }
                throw new PDFException("Invalid or missing Root dictionary");
            }
            catch (PDFException)
            {
                throw;
            }
        }

        private void ReadXRefStream(long offset)
        {
            int num3;
            int num4;
            int num5;
            long num6;
            int num7;
            XRefEntry entry1;
            int num8;
            PDFObject obj1;
            PDFStream stream1 = (this.ReadDirectFromStream(this.mParser, offset, -1, -1) as PDFStream);
            if (stream1 == null)
            {
                throw new PDFException("Invalid XRef-Stream");
            }
            PDFDict dict1 = stream1.Dict;
            PDFName name1 = (dict1["Type"] as PDFName);
            if (name1 == null)
            {
                throw new PDFException("Invalid XRef-Stream");
            }
            int[] numArray1 = new int[3];
            PDFArray array1 = (dict1["W"] as PDFArray);
            if (array1 == null)
            {
                throw new PDFException("Invalid or missing W entry in XRef stream");
            }
            if (array1.Count != 3)
            {
                throw new PDFException("Invalid W entry in XRef stream (wrong number of elements");
            }
            int num1 = 0;
            foreach (PDFInteger integer1 in array1)
            {
                int num9 = num1;
                num1 = (num9 + 1);
                numArray1[num1] = integer1.Int32Value;
            }
            PDFInteger integer2 = (dict1["Size"] as PDFInteger);
            if (integer2 == null)
            {
                throw new PDFException("Invalid or missing size entry");
            }
            PDFArray array2 = (dict1["Index"] as PDFArray);
            if (array2 != null)
            {
                goto Label_0121;
            }
            throw new PDFException("Invalid or missing index entry");
        Label_0114:
            this.mXRef.Add(null);
        Label_0121:
            if (((long) this.mXRef.Count) < integer2.Value)
            {
                goto Label_0114;
            }
            Stream stream2 = stream1.Decode();
            byte[] numArray2 = new byte[((numArray1[0] + numArray1[1]) + numArray1[2])];
            BitArrayAccessor accessor1 = new BitArrayAccessor(numArray2, 8, false);
            if (numArray1[1] < 0)
            {
                throw new PDFException("Invalid w2 value");
            }
            int num2 = 0;
            try
            {
                while ((num2 < array2.Count))
                {
                    num3 = ((PDFInteger) array2[num2]).Int32Value;
                    num4 = (num3 + ((PDFInteger) array2[(num2 + 1)]).Int32Value);
                    num1 = num3;
                    while ((num1 < num4))
                    {
                        stream2.Read(numArray2, 0, numArray2.Length);
                        if (this.mXRef[num1] != null)
                        {
                            goto Label_02A2;
                        }
                        num5 = ((numArray1[0] == 0) ? 1 : ((int) accessor1.GetBits(((long) 0), (numArray1[0] * 8), 1, false, false)[0]));
                        num6 = accessor1.GetBits(((long) (numArray1[0] * 8)), (numArray1[1] * 8), 1, false, false)[0];
                        if (numArray1[2] == 0)
                        {
                            if (num5 == 1)
                            {
                                num7 = 0;
                                goto Label_023C;
                            }
                            throw new PDFException("Not default value for w3 for this object type");
                        }
                        num7 = ((int) accessor1.GetBits(((long) ((numArray1[0] + numArray1[1]) * 8)), (numArray1[2] * 8), 1, false, false)[0]);
                    Label_023C:
                        entry1 = new XRefEntry();
                        entry1.type = num5;
                        num8 = num5;
                        switch (num8)
                        {
                            case 0:
                            case 1:
                            {
                                entry1.generation = num7;
                                entry1.offset = num6;
                                goto Label_0293;
                            }
                            case 2:
                            {
                                goto Label_0279;
                            }
                        }
                        goto Label_0293;
                    Label_0279:
                        entry1.generation = 0;
                        entry1.offset = num6;
                        entry1.index = num7;
                    Label_0293:
                        this.mXRef[num1] = entry1;
                    Label_02A2:
                        num1 += 1;
                    }
                    num2 += 2;
                }
            }
            catch (InvalidCastException)
            {
                throw new PDFException("Invalid index entry");
            }
            PDFInteger integer3 = (dict1["Prev"] as PDFInteger);
            if (integer3 != null)
            {
                this.ReadXRefStream(integer3.Value);
            }
            this.mXRefValid = true;
            this.mTrailer = new CorePDFDict();
            if ((dict1["Root"] != null) && (this.mTrailer["Root"] == null))
            {
                obj1 = dict1["Root"];
                this.mTrailer["Root"] = obj1;
                this.mRoot = ((PDFDict) obj1);
            }
            if ((dict1["Info"] is PDFDict) && (this.mTrailer["Info"] == null))
            {
                obj1 = dict1["Info"];
                this.mTrailer["Info"] = obj1;
                this.mInfo = ((PDFDict) obj1);
            }
        }

        private long ReadXRefTable(long offset)
        {
            PDFObject obj2;
            int num1;
            int num2;
            int num3;
            XRefEntry entry1;
            long num4;
            PDFDict dict1;
            PDFInteger integer1;
            this.mStream.Position = offset;
            PDFObject obj1 = this.mParser.ReadNextObject();
            if ((obj1.PDFType == PDFObjectType.tPDFName) && ((obj1 as PDFName).Value == "xref"))
            {
                try
                {
                    obj2 = null;
                    goto Label_0129;
                Label_0045:
                    num1 = ((PDFInteger) obj2).Int32Value;
                    num2 = ((PDFInteger) this.mParser.ReadNextObject()).Int32Value;
                    while ((this.mXRef.Count < (num1 + num2)))
                    {
                        this.mXRef.Add(null);
                    }
                    for (num3 = 0; (num3 < num2); num3 += 1)
                    {
                        entry1 = new XRefEntry();
                        entry1.offset = ((PDFInteger) this.mParser.ReadNextObject()).Value;
                        entry1.generation = ((PDFInteger) this.mParser.ReadNextObject()).Int32Value;
                        entry1.type = ((((PDFName) this.mParser.ReadNextObject()).Value == "f") ? 0 : 1);
                        if (this.mXRef[(num3 + num1)] == null)
                        {
                            this.mXRef[(num3 + num1)] = entry1;
                        }
                    }
                Label_0129:
                    obj2 = this.mParser.ReadNextObject();
                    if (obj2.PDFType == PDFObjectType.tPDFInteger)
                    {
                        goto Label_0045;
                    }
                    if (((PDFName) obj2).Value != "trailer")
                    {
                        throw new PDFSyntaxException("Missing TRAILER after XREF");
                    }
                    num4 = this.mStream.Position;
                    dict1 = ((PDFDict) this.mParser.ReadNextObject());
                    integer1 = ((PDFInteger) dict1["Prev"]);
                    if (integer1 != null)
                    {
                        this.ReadXRefTable(integer1.Value);
                    }
                    return num4;
                }
                catch (InvalidCastException)
                {
                    throw new PDFSyntaxException("Type mistmatch in XREF");
                }
                catch (PDFException)
                {
                    throw;
                }
                catch (Exception exception1)
                {
                    throw new PDFSyntaxException(string.Format("Error parsing XREF: {0:S}", exception1.Message));
                }
            }
            if (obj1.PDFType == PDFObjectType.tPDFInteger)
            {
                this.ReadXRefStream(offset);
                return ((long) -1);
            }
            throw new PDFSyntaxException("Error parsing XREF");
        }

        public override void Save()
        {
            string text1;
            XRefEntry entry2;
            int num4;
            XRefEntry entry3;
            this.AddWatermarks(true, true);
            if (this.mWriter == null)
            {
                this.mWriter = new PDFWriter();
            }
            if (this.mStream == null)
            {
                this.mStream = File.Open(this.mFileName, FileMode.Create, FileAccess.Write, this.mShareMode);
                this.mWriter.AttachToStream(this.mStream);
                this.mWriter.WriteRaw(this.Header);
                this.mWriter.WriteEOL();
                text1 = "%\u00cd\u00ce\u00cf\u00ff";
                this.mWriter.WriteRaw(text1);
                this.mWriter.WriteEOL();
            }
            else
            {
                this.mWriter.AttachToStream(this.mStream);
            }
            Hashtable hashtable1 = new Hashtable();
            if (this.mTrailer["Root"] != null)
            {
                this.EnqeueIndirects(hashtable1, this.mTrailer["Root"]);
            }
            if (this.mTrailer["Info"] != null)
            {
                this.EnqeueIndirects(hashtable1, this.mTrailer["Info"]);
            }
            if (this.mTrailer["Encrypt"] != null)
            {
                this.EnqeueIndirects(hashtable1, this.mTrailer["Encrypt"]);
            }
            this.mToSaveQueue = new Queue();
            foreach (DictionaryEntry entry1 in hashtable1)
            {
                if (!((CorePDFIndirect) entry1.Key).Dirty || (((CorePDFIndirect) entry1.Key).Direct.PDFType == PDFObjectType.tPDFNull))
                {
                    continue;
                }
                this.mToSaveQueue.Enqueue(entry1.Key);
            }
            ArrayList list1 = new ArrayList();
            this.mWriter.Flush();
            this.mStream.Seek(((long) 0), SeekOrigin.End);
            ArrayList list2 = new ArrayList();
            if (this.mToSaveQueue.Count == 0)
            {
                return;
            }
            foreach (PDFIndirect indirect1 in this.mToSaveQueue)
            {
                entry2 = ((XRefEntry) this.mXRef[indirect1.Id]);
                this.SaveIndirect(entry2, indirect1);
                if (indirect1.PDFType == PDFObjectType.tPDFStream)
                {
                    list2.Add(indirect1);
                }
                list1.Add(entry2);
            }
            list1.Add(this.mXRef[0]);
            list1.Sort(new XRefComparer());
            long num1 = this.mWriter.Position;
            int num2 = 0;
            int num3 = 0;
            this.mWriter.WriteRaw("xref");
            this.mWriter.WriteEOL();
            this.mWriter.WriteRaw("\n");
            for (num4 = 1; (num4 < list1.Count); num4 += 1)
            {
                entry3 = ((XRefEntry) list1[num4]);
                if ((num2 + (num4 - num3)) != entry3.indirect.Id)
                {
                    this.mWriter.WriteXRefSection(list1, num3, num2, (num4 - num3));
                    num3 = num4;
                    num2 = entry3.indirect.Id;
                }
            }
            this.mWriter.WriteXRefSection(list1, num3, num2, (list1.Count - num3));
            this.mWriter.WriteRaw("trailer");
            this.mWriter.WriteEOL();
            this.mTrailer["Root"] = this.mRoot.Indirect;
            if (this.mInfo != null)
            {
                this.mTrailer["Info"] = this.mInfo.Indirect;
            }
            if (this.mEncrypt != null)
            {
                this.mTrailer["Encrypt"] = this.mEncrypt.Indirect;
            }
            this.mTrailer["Size"] = new CorePDFInteger(((long) this.mXRef.Count));
            if (this.mPrevStartXRef != ((long) -1))
            {
                this.mTrailer["Prev"] = Library.CreateInteger(this.mPrevStartXRef);
            }
            this.mWriter.WriteLn(this.mTrailer);
            this.mWriter.WriteRaw("startxref");
            this.mWriter.WriteEOL();
            this.mWriter.Write(num1);
            this.mWriter.WriteEOL();
            this.mWriter.WriteRaw("%%EOF");
            this.mWriter.WriteEOL();
            this.mWriter.Flush();
        }

        public override void SaveAs(Stream str, string header)
        {
            int num1;
            byte[] numArray2;
            UserAccessPermissions permissions1;
            PDFDict dict2;
            PDFArray array1;
            PDFStream stream1;
            Stream stream2;
            int num4;
            this.UpdateInfo();
            PDFDict dict1 = ((PDFDict) this.mTrailer.Clone());
            string text1 = Encoding.ASCII.GetString(this.GenerateFileId(this.mPath));
            string[] textArray1 = new string[2];
            textArray1[0] = text1;
            textArray1[1] = text1;
            this.mTrailer["ID"] = PDF.O(textArray1);
            bool flag1 = false;
            Snow snow1 = new Snow();
            snow1.LoadKey(41869, Rect.serial[0], 1, 0);
            uint[] numArray1 = new uint[3];
            for (num1 = 0; (num1 < 3); num1 += 1)
            {
                numArray1[num1] = Rect.serial[(num1 + 1)];
            }
            snow1.EncryptDecrypt(ref numArray1);
            flag1 = ((bool) (((((numArray1[0] ^ numArray1[1]) ^ numArray1[2]) & (Circle.productType & 44933)) != (Circle.productType & 44933)) ? 0 : (numArray1[0] == numArray1[1])));
            DateTime time1 = DateTime.Now;
            Random random1 = new Random(time1.Millisecond);
            if (!flag1)
            {
                this.AddWatermarks(false, false);
                numArray2 = new byte[32];
                random1.NextBytes(numArray2);
                permissions1 = -1340;
                this.mWriter.Encryption = EncryptionStandard.Create(Encoding.ASCII.GetString(numArray2), "", permissions1, 128, true);
                dict2 = this.mWriter.Encryption.CreateEncryptionDict(this);
                this.mTrailer["Encrypt"] = this.Indirects.New(dict2);
            }
            else
            {
                array1 = Library.CreateArray(1);
                array1[0] = Library.CreateName("FlateDecode");
                foreach (PDFIndirect indirect1 in this.Indirects)
                {
                    if (((indirect1 == null) || (indirect1.Direct == null)) || (indirect1.Direct.PDFType != PDFObjectType.tPDFStream))
                    {
                        continue;
                    }
                    stream1 = (indirect1.Direct as PDFStream);
                    if (stream1 == null)
                    {
                        continue;
                    }
                    stream2 = stream1.Decode();
                    stream1.Dict["Filter"] = base.CloneObject(array1);
                    stream1.Dict.Remove("DecodeParms");
                    stream1.Encode(stream2);
                }
            }
            if (this.mWriter == null)
            {
                this.mWriter = new PDFWriter();
            }
            this.mWriter.AttachToStream(str);
            this.mWriter.WriteRaw(header);
            this.mWriter.WriteEOL();
            string text2 = "%\u00cd\u00ce\u00cf\u00ff";
            this.mWriter.WriteRaw(text2);
            this.mWriter.WriteEOL();
            Hashtable hashtable1 = new Hashtable();
            this.mTrailer.Remove("Prev");
            if (this.mTrailer["Root"] != null)
            {
                this.EnqeueIndirects(hashtable1, this.mTrailer["Root"]);
            }
            if (this.mTrailer["Info"] != null)
            {
                this.EnqeueIndirects(hashtable1, this.mTrailer["Info"]);
            }
            if (this.mTrailer["Encrypt"] != null)
            {
                this.EnqeueIndirects(hashtable1, this.mTrailer["Encrypt"]);
            }
            this.mToSaveQueue = new Queue();
            int num2 = 1;
            ArrayList list1 = this.mXRef;
            this.mXRef = new ArrayList();
            XRefEntry entry1 = new XRefEntry();
            entry1.dirty = false;
            entry1.type = 0;
            entry1.generation = 65535;
            entry1.indirect = null;
            entry1.offset = ((long) 0);
            this.mXRef.Add(entry1);
            foreach (DictionaryEntry entry2 in hashtable1)
            {
                ((CorePDFIndirect) entry2.Key).mId = num2;
                entry1 = new XRefEntry();
                entry1.dirty = true;
                entry1.type = 1;
                entry1.generation = 0;
                entry1.indirect = ((CorePDFIndirect) entry2.Key);
                entry1.offset = ((long) -1);
                this.mXRef.Add(entry1);
                num2 += 1;
                this.mToSaveQueue.Enqueue(entry2.Key);
            }
            num2 = 0;
            foreach (PDFIndirect indirect2 in this.mToSaveQueue)
            {
                num2 += 1;
                this.SaveIndirect(((XRefEntry) this.mXRef[num2]), indirect2);
            }
            long num3 = this.mWriter.Position;
            this.mWriter.WriteRaw("xref");
            this.mWriter.WriteEOL();
            this.mWriter.WriteXRefSection(this.mXRef, 0, 0, this.mXRef.Count);
            this.mWriter.WriteRaw("trailer");
            this.mWriter.WriteEOL();
            this.mTrailer["Root"] = this.mRoot.Indirect;
            if (this.mInfo != null)
            {
                this.mTrailer["Info"] = this.mInfo.Indirect;
            }
            if (this.mEncrypt != null)
            {
                this.mTrailer["Encrypt"] = this.mEncrypt.Indirect;
            }
            this.mTrailer["Size"] = new CorePDFInteger(((long) this.mXRef.Count));
            this.mWriter.WriteLn(this.mTrailer);
            this.mWriter.WriteRaw("startxref");
            this.mWriter.WriteEOL();
            this.mWriter.Write(num3);
            this.mWriter.WriteEOL();
            this.mWriter.WriteRaw("%%EOF");
            this.mWriter.WriteEOL();
            this.mWriter.Flush();
            this.mTrailer = dict1;
            this.mXRef = list1;
            for (num4 = 0; (num4 < this.mXRef.Count); num4 += 1)
            {
                entry1 = ((XRefEntry) this.mXRef[num4]);
                if (entry1.indirect != null)
                {
                    ((CorePDFIndirect) entry1.indirect).mId = num4;
                }
            }
        }

        public override void SaveAs(string path, string header)
        {
            using (Stream stream1 = File.Open(path, FileMode.Create, FileAccess.Write, this.mShareMode))
            {
                this.SaveAs(stream1, header);
            }
        }

        public override void SaveAs(Stream strm, string header, IEncryption encrypt)
        {
            int num1;
            this.UpdateInfo();
            bool flag1 = false;
            Snow snow1 = new Snow();
            snow1.LoadKey(41869, Rect.serial[0], 1, 0);
            uint[] numArray1 = new uint[3];
            for (num1 = 0; (num1 < 3); num1 += 1)
            {
                numArray1[num1] = Rect.serial[(num1 + 1)];
            }
            snow1.EncryptDecrypt(ref numArray1);
            flag1 = ((bool) (((((numArray1[0] ^ numArray1[1]) ^ numArray1[2]) & (Circle.productType & 44933)) != (Circle.productType & 44933)) ? 0 : (numArray1[0] == numArray1[1])));
            if (!flag1 && (encrypt != null))
            {
                throw new SecurityException("Ecnryption is unsupported in the trial version");
            }
            PDFDict dict1 = this.mTrailer;
            ArrayList list1 = ((ArrayList) this.mXRef.Clone());
            this.mTrailer = ((PDFDict) dict1.Clone());
            this.mTrailer["Info"] = dict1["Info"];
            string text1 = Encoding.ASCII.GetString(this.GenerateFileId(this.mPath));
            string[] textArray1 = new string[2];
            textArray1[0] = text1;
            textArray1[1] = text1;
            this.mTrailer["ID"] = PDF.O(textArray1);
            PDFDict dict2 = encrypt.CreateEncryptionDict(this);
            this.mTrailer["Encrypt"] = this.Indirects.New(dict2);
            this.mWriter.Encryption = encrypt;
            this.SaveAs(strm, header);
            this.mWriter.Encryption = null;
            this.mXRef = list1;
            this.mTrailer = dict1;
        }

        public override void SaveAs(string path, string header, IEncryption encrypt)
        {
            using (Stream stream1 = File.Open(path, FileMode.Create, FileAccess.Write, this.mShareMode))
            {
                this.SaveAs(stream1, header, encrypt);
            }
        }

        private void SaveIndirect(XRefEntry e, PDFIndirect i)
        {
            if (i.PDFType == PDFObjectType.tPDFStream)
            {
                foreach (IStreamEncodingRule rule1 in base.StreamEncodingRules)
                {
                    if (rule1.Handle(((PDFStream) i.Direct)))
                    {
                        goto Label_0051;
                    }
                }
            }
        Label_0051:
            e.offset = this.mWriter.Position;
            this.mWriter.WriteSp(i.Id);
            this.mWriter.WriteSp(i.Generation);
            this.mWriter.WriteRaw("obj");
            this.mWriter.WriteEOL();
            IEncryption encryption1 = this.mWriter.Encryption;
            if ((this.mTrailer["Encrypt"] != null) && (i.Id == this.mTrailer["Encrypt"].Indirect.Id))
            {
                this.mWriter.Encryption = null;
            }
            this.mWriter.WriteLn(i.Direct);
            this.mWriter.Encryption = encryption1;
            this.mWriter.WriteRaw("endobj");
            this.mWriter.WriteEOL();
            i.Dirty = false;
        }

        private void UpdateInfo()
        {
            if (this.mInfo == null)
            {
                this.mInfo = Library.CreateDict();
                this.mTrailer["Info"] = this.Indirects.New(this.mInfo);
            }
            string text1 = Date.GetPDFString(DateTime.Now);
            this.mInfo["CreationDate"] = Library.CreateString(text1);
            this.mInfo["ModDate"] = Library.CreateString(text1);
        }


        // Properties
        public override IEncryption Encryption
        {
            get
            {
                return this.mEncryption;
            }
        }

        public override string Header
        {
            get
            {
                return this.mHeader;
            }
            set
            {
                this.mHeader = value;
            }
        }

        public override byte[] Id1
        {
            get
            {
                PDFArray array1 = (this.mTrailer["ID"] as PDFArray);
                if (array1 == null)
                {
                    return null;
                }
                PDFString text1 = (array1[0] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Bytes;
            }
        }

        public override byte[] Id2
        {
            get
            {
                PDFArray array1 = (this.mTrailer["ID"] as PDFArray);
                if (array1 == null)
                {
                    return null;
                }
                PDFString text1 = (array1[1] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Bytes;
            }
        }

        public override IndirectCollection Indirects
        {
            get
            {
                return this.mIndirects;
            }
        }

        public override PDFDict Info
        {
            get
            {
                return this.mInfo;
            }
            set
            {
                if (!value.IsIndirect)
                {
                    value = (this.Indirects.New(value).Direct as PDFDict);
                }
                PDFDict dict1 = value;
                this.mInfo = dict1;
                this.mTrailer["Info"] = dict1;
            }
        }

        public override string Path
        {
            get
            {
                return this.mPath;
            }
        }

        public override PDFDict Root
        {
            get
            {
                return this.mRoot;
            }
        }

        public override PDFWriter Writer
        {
            get
            {
                return this.mWriter;
            }
            set
            {
                this.mWriter = value;
            }
        }


        // Fields
        private DocOpenMode mDocOpenMode;
        private PDFDict mEncrypt;
        private IEncryption mEncryption;
        internal IExternalStreamHandler mExtHandler;
        private string mFileName;
        private string mHeader;
        private CoreIndirectCollection mIndirects;
        private PDFDict mInfo;
        private PDFParser mParser;
        private string mPath;
        private long mPrevStartXRef;
        private PDFDict mRoot;
        private ISecurityHandler mSecHandler;
        private FileShare mShareMode;
        private Stream mStream;
        internal Queue mToSaveQueue;
        private PDFDict mTrailer;
        private PDFWriter mWriter;
        internal ArrayList mXRef;
        private bool mXRefValid;
    }
}


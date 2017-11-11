namespace Altsoft.PDFO.Core
{
    using Altsoft.Common;
    using Altsoft.PDFO;
    using Altsoft.StreamFilters;
    using System;
    using System.IO;

    public sealed class CorePDFStream : CorePDFDirect, PDFStream, PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Methods
        internal CorePDFStream(Stream str, CorePDFDict dict, bool encodeAndEncrypt)
        {
            this.mRawStream = null;
            this.mEncId = -1;
            this.mEncGen = -1;
            if (dict.Parent != null)
            {
                throw new ArgumentException("Dictionary is already owned it can not be used as stream dictionary", "dict");
            }
            this.mDict = dict;
            this.mDict.Parent = this;
            str.Position = ((long) 0);
            if (encodeAndEncrypt)
            {
                this.Encode(str);
                return;
            }
            this.SetRawStream(str);
        }

        internal CorePDFStream(CoreDocument doc, Stream str, long pos, CorePDFDict dict)
        {
            long num1;
            this.mRawStream = null;
            this.mEncId = -1;
            this.mEncGen = -1;
            this.mDict = dict;
            this.mDict.Parent = this;
            try
            {
                if (this.FileSpec != null)
                {
                    if (!this.FileSpec.IsValid)
                    {
                        return;
                    }
                    if (doc != null)
                    {
                        if (doc.mExtHandler != null)
                        {
                            this.mRawStream = doc.mExtHandler.GetReadStream(doc, this.FileSpec);
                            return;
                        }
                        this.mRawStream = Stream.Null;
                        return;
                    }
                    this.mRawStream = Stream.Null;
                    return;
                }
                num1 = ((PDFInteger) dict["Length"].Direct).Value;
                this.mRawStream = new SubStream(str, pos, num1);
                str.Position = (pos + num1);
            }
            catch (InvalidCastException)
            {
                throw new PDFSyntaxException("Invalid length value in stream dictionary");
            }
            catch (NullReferenceException)
            {
                throw new PDFSyntaxException("No length value in stream dictionary");
            }
            catch (IOException exception1)
            {
                throw new PDFSyntaxException(string.Format("Error opening data stream: {S:O}}", exception1.Message));
            }
        }

        private Stream ApplyDecodeFilter(Stream src, PDFName filter, PDFDict pars)
        {
            if (filter.Value == "ASCIIHexDecode")
            {
                return new ASCIIHexDecoder(src);
            }
            if (filter.Value == "ASCII85Decode")
            {
                return new ASCII85Decoder(src);
            }
            if (filter.Value == "LZWDecode")
            {
                return new LZW_Decoder(src, pars);
            }
            if (filter.Value == "FlateDecode")
            {
                return new Flate_Decoder(src, pars);
            }
            if (filter.Value == "RunLengthDecode")
            {
                return new RLE_Decoder(src);
            }
            if (filter.Value == "CCITTFaxDecode")
            {
                return new CCITT_Decoder(src, pars);
            }
            if (filter.Value == "DCTDecode")
            {
                return new DCT_Decoder(src, pars);
            }
            if (filter.Value == "JBIG2Decode")
            {
                return new JBIG2_Decoder(src, pars);
            }
            if (filter.Value == "JPXDecode")
            {
                return new JPX_Decoder(src, pars);
            }
            throw new PDFException(string.Format("Unknown filter: {0:S}", filter.Value));
        }

        public Stream ApplyDecodeFilters(PDFObject filter, PDFObject decodeParams)
        {
            Stream stream1;
            PDFArray array1;
            PDFArray array2;
            int num1;
            Stream stream2;
            try
            {
                if (filter.PDFType == PDFObjectType.tPDFArray)
                {
                    stream1 = this.Decrypt();
                    array1 = ((PDFArray) filter);
                    array2 = ((PDFArray) decodeParams);
                    for (num1 = 0; (num1 < array1.Count); num1 += 1)
                    {
                        stream1 = this.ApplyDecodeFilter(stream1, ((PDFName) array1[num1]), ((array2 != null) ? (array2[num1] as PDFDict) : null));
                    }
                    return stream1;
                }
                return this.ApplyDecodeFilter(this.Decrypt(), ((PDFName) filter), ((PDFDict) decodeParams));
            }
            catch (InvalidCastException)
            {
                throw new PDFSyntaxException("Invalid stream dictionary");
            }
            return stream2;
        }

        private Stream ApplyEncodeFilter(Stream str, PDFName filter, PDFDict encodeParams)
        {
            if (filter.Value == "ASCIIHexDecode")
            {
                return new ASCIIHexEncoder(str);
            }
            if (filter.Value == "ASCII85Decode")
            {
                return new ASCII85Encoder(str);
            }
            if (filter.Value == "LZWDecode")
            {
                return new LZW_Encoder(str, encodeParams);
            }
            if (filter.Value == "FlateDecode")
            {
                return new Flate_Encoder(str, encodeParams);
            }
            if (filter.Value == "RunLengthDecode")
            {
                return new RLE_Encoder(str);
            }
            if (filter.Value == "CCITTFaxDecode")
            {
                return new CCITT_Encoder(str, encodeParams);
            }
            if (filter.Value == "DCTDecode")
            {
                return new DCT_Encoder(str, encodeParams);
            }
            throw new PDFException(string.Format("Unknown filter: {0:S}", filter.Value));
        }

        public void ApplyEncodeFilters(Stream str, PDFObject filter, PDFObject encodeParams)
        {
            this.ApplyEncodeFilters(str, filter, encodeParams, false);
        }

        public void ApplyEncodeFilters(Stream str, PDFObject filter, PDFObject encodeParams, bool setDirectly)
        {
            MemoryStream stream1;
            Stream stream2;
            PDFArray array1;
            PDFArray array2;
            int num1;
            byte[] numArray1;
            int num2;
            try
            {
                stream1 = new MemoryStream();
                stream2 = stream1;
                if (filter.PDFType == PDFObjectType.tPDFArray)
                {
                    array1 = ((PDFArray) filter);
                    array2 = ((PDFArray) encodeParams);
                    for (num1 = 0; (num1 < array1.Count); num1 += 1)
                    {
                        stream2 = this.ApplyEncodeFilter(stream2, ((PDFName) array1[num1]), ((array2 != null) ? (array2[num1] as PDFDict) : null));
                    }
                }
                else
                {
                    stream2 = this.ApplyEncodeFilter(stream2, ((PDFName) filter), ((PDFDict) encodeParams));
                }
                numArray1 = new byte[16384];
                if (stream2 == stream1)
                {
                    goto Label_00B4;
                }
                num2 = 0;
                goto Label_0092;
            Label_0087:
                stream2.Write(numArray1, 0, num2);
            Label_0092:
                num2 = str.Read(numArray1, 0, numArray1.Length);
                if (num2 != 0)
                {
                    goto Label_0087;
                }
                stream2.Flush();
                this.Encrypt(stream1, true);
                return;
            Label_00B4:
                this.Encrypt(str, setDirectly);
            }
            catch (InvalidCastException)
            {
                throw new PDFSyntaxException("Invalid stream dictionary");
            }
        }

        public override object Clone()
        {
            return ((object) Library.CreateStream(this.GetRawStream(), this.Dict, false));
        }

        public Stream Decode()
        {
            PDFObject obj1 = null;
            PDFObject obj2 = null;
            if (this.IsExternal)
            {
                obj1 = this.mDict["FFilter"];
                obj2 = this.mDict["FDecodeParms"];
            }
            else
            {
                obj1 = this.mDict["Filter"];
                obj2 = this.mDict["DecodeParms"];
            }
            if (obj1 == null)
            {
                return this.Decrypt();
            }
            return this.ApplyDecodeFilters(obj1, obj2);
        }

        public Stream Decrypt()
        {
            if (this.Doc == null)
            {
                return this.GetRawStream();
            }
            if (this.Doc.IsEncrypted)
            {
                if (this.mEncId != -1)
                {
                    return this.Doc.Encryption.DecryptStream(this.GetRawStream(), this.mEncId, this.mEncGen);
                }
                return this.GetRawStream();
            }
            return this.GetRawStream();
        }

        public void Encode(Stream str)
        {
            this.Encode(str, false);
        }

        public void Encode(Stream str, bool setDirectly)
        {
            if (str.Position > ((long) 0))
            {
                str.Position = ((long) 0);
            }
            PDFObject obj1 = null;
            PDFObject obj2 = null;
            if (this.IsExternal)
            {
                obj1 = this.mDict["FFilter"];
                obj2 = this.mDict["FDecodeParms"];
            }
            else
            {
                obj1 = this.mDict["Filter"];
                obj2 = this.mDict["DecodeParms"];
            }
            if (obj1 == null)
            {
                this.Encrypt(str, setDirectly);
                return;
            }
            this.ApplyEncodeFilters(str, obj1, obj2, setDirectly);
        }

        public void Encrypt(Stream str)
        {
            this.Encrypt(str, false);
        }

        public void Encrypt(Stream str, bool setDirectly)
        {
            if (str.Position > ((long) 0))
            {
                str.Position = ((long) 0);
            }
            if (this.Doc == null)
            {
                this.SetRawStream(str, setDirectly);
                return;
            }
            if (this.Doc.IsEncrypted)
            {
                this.SetRawStream(str, setDirectly);
                this.mEncId = -1;
                this.mEncGen = -1;
                return;
            }
            this.SetRawStream(str, setDirectly);
        }

        public Stream GetRawStream()
        {
            if (this.FileSpec != null)
            {
                if (this.FileSpec.IsValid)
                {
                    if (this.Doc != null)
                    {
                        if (((CoreDocument) this.Doc).mExtHandler != null)
                        {
                            return ((CoreDocument) this.Doc).mExtHandler.GetReadStream(this.Doc, this.FileSpec);
                        }
                        return Stream.Null;
                    }
                    return Stream.Null;
                }
                return Stream.Null;
            }
            return new SubStream(this.mRawStream, ((long) 0), this.mRawStream.Length);
        }

        public void SetRawStream(Stream str)
        {
            this.SetRawStream(str, false);
        }

        public void SetRawStream(Stream str, bool setDirectly)
        {
            if (this.IsExternal)
            {
                if (this.Doc == null)
                {
                    throw new InvalidOperationException("External streams are not allowed on free objects");
                }
                if (((CoreDocument) this.Doc).mExtHandler == null)
                {
                    throw new InvalidOperationException("No external stream handler specified in document");
                }
                ((CoreDocument) this.Doc).mExtHandler.WriteStream(this.Doc, this.FileSpec, (setDirectly ? str : new ReusableInputStream(str)));
                return;
            }
            if (str.Position > ((long) 0))
            {
                str.Position = ((long) 0);
            }
            if (str.CanSeek && setDirectly)
            {
                this.mRawStream = str;
            }
            else
            {
                this.mRawStream = new ReusableInputStream(str);
            }
            this.mDict["Length"] = Library.CreateInteger(this.mRawStream.Length);
            this.Dirty = true;
        }


        // Properties
        public PDFDict Dict
        {
            get
            {
                return this.mDict;
            }
        }

        public FileSpec FileSpec
        {
            get
            {
                return (Resources.Get(this.mDict["F"], typeof(FileSpec)) as FileSpec);
            }
        }

        public bool IsExternal
        {
            get
            {
                return (this.FileSpec != null);
            }
        }

        public override PDFObjectType PDFType
        {
            get
            {
                return PDFObjectType.tPDFStream;
            }
        }


        // Fields
        private CorePDFDict mDict;
        internal int mEncGen;
        internal int mEncId;
        internal Stream mRawStream;
    }
}


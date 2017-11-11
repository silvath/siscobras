namespace Altsoft.PDFO
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class PDFWriter
    {
        // Methods
        public PDFWriter()
        {
            this.mNumberFormat = new NumberFormatInfo();
            this.Encryption = null;
            this.mNumberFormat.NumberDecimalSeparator = ".";
            this.mNumberFormat.NumberDecimalDigits = 6;
        }

        public void AttachToStream(Stream str)
        {
            this.mStream = str;
            this.mWriter = new StreamWriter(str);
        }

        public Stream DetachFromStream()
        {
            Stream stream1 = this.mStream;
            this.mWriter = null;
            this.mStream = null;
            return stream1;
        }

        public void Flush()
        {
            this.mWriter.Flush();
            this.mStream.Flush();
        }

        public void Write(object obj)
        {
            PDFObject obj1;
            PDFObjectType type2;
            Type type1 = obj.GetType();
            if ((obj is PDFDirect))
            {
                obj1 = ((PDFDirect) obj);
                type2 = obj1.PDFType;
                switch (type2)
                {
                    case PDFObjectType.tPDFNull:
                    {
                        this.WriteNull();
                        return;
                    }
                    case PDFObjectType.tPDFInteger:
                    {
                        this.WriteInteger(((PDFInteger) obj1));
                        return;
                    }
                    case PDFObjectType.tPDFFixed:
                    {
                        this.WriteFixed(((PDFFixed) obj1));
                        return;
                    }
                    case PDFObjectType.tPDFBoolean:
                    {
                        this.WriteBoolean(((PDFBoolean) obj1));
                        return;
                    }
                    case PDFObjectType.tPDFName:
                    {
                        this.WriteName(((PDFName) obj1));
                        return;
                    }
                    case PDFObjectType.tPDFString:
                    {
                        this.WriteString(((PDFString) obj1));
                        return;
                    }
                    case PDFObjectType.tPDFDict:
                    {
                        this.WriteDict(((PDFDict) obj1));
                        return;
                    }
                    case PDFObjectType.tPDFArray:
                    {
                        this.WriteArray(((PDFArray) obj1));
                        return;
                    }
                    case PDFObjectType.tPDFStream:
                    {
                        this.WriteStream(((PDFStream) obj1));
                        return;
                    }
                }
                throw new PDFException("Invalid PDF object type");
            }
            if ((obj is PDFIndirect))
            {
                this.WriteIndirect(((PDFIndirect) obj));
                return;
            }
            if (type1 == typeof(string))
            {
                this.WriteString(((string) obj));
                return;
            }
            if (type1 == typeof(int))
            {
                this.WriteInteger(((long) ((int) obj)));
                return;
            }
            if (type1 == typeof(long))
            {
                this.WriteInteger(((long) obj));
                return;
            }
            if (type1 == typeof(double))
            {
                this.WriteFixed(((double) obj));
                return;
            }
            if (type1 == typeof(bool))
            {
                this.WriteBoolean(((bool) obj));
            }
        }

        public void WriteArray(PDFArray val)
        {
            this.WriteOpenArray();
            foreach (object obj1 in val)
            {
                this.WriteSp(obj1);
            }
            this.WriteCloseArray();
        }

        public void WriteBoolean(PDFBoolean val)
        {
            this.WriteBoolean(val.Value);
        }

        public void WriteBoolean(bool val)
        {
            if (val)
            {
                this.WriteRaw("true");
                return;
            }
            this.WriteRaw("false");
        }

        public void WriteCloseArray()
        {
            this.mWriter.Write("]");
        }

        public void WriteCloseDict()
        {
            this.mWriter.Write(">>");
        }

        public void WriteDict(PDFDict val)
        {
            this.WriteOpenDict();
            foreach (DictionaryEntry entry1 in val)
            {
                this.WriteSp(entry1.Key);
                this.WriteLn(entry1.Value);
            }
            this.WriteCloseDict();
        }

        public void WriteEOL()
        {
            this.mWriter.Write("\r");
        }

        public void WriteFixed(PDFFixed val)
        {
            this.WriteFixed(val.Value);
        }

        public void WriteFixed(double val)
        {
            if (double.IsInfinity(val) || double.IsNaN(val))
            {
                throw new NotFiniteNumberException(string.Format("Can\'t write {0} to PDF file", val));
            }
            object[] objArray1 = new object[1];
            objArray1[0] = val;
            string text1 = string.Format(this.mNumberFormat, "{0:F}", objArray1);
            while ((text1[(text1.Length - 1)] == '0'))
            {
                text1 = text1.Substring(0, (text1.Length - 1));
            }
            if (text1[(text1.Length - 1)] == '.')
            {
                text1 = text1 + "0";
            }
            this.WriteRaw(text1);
        }

        public void WriteHexString(string val)
        {
            char ch1;
            int num1;
            this.mWriter.Write("<");
            string text1 = val;
            for (num1 = 0; (num1 < text1.Length); num1 += 1)
            {
                ch1 = text1[num1];
                this.mWriter.Write(string.Format("{0:X}", new object[0]), ch1);
            }
            this.mWriter.Write(">");
        }

        public void WriteIndirect(PDFIndirect ind)
        {
            this.WriteInteger(((long) ind.Id));
            this.WriteSpace();
            this.WriteInteger(((long) ind.Generation));
            this.WriteSpace();
            this.mWriter.Write("R");
        }

        public void WriteInteger(PDFInteger val)
        {
            this.WriteInteger(val.Value);
        }

        public void WriteInteger(long val)
        {
            this.mWriter.Write(string.Format("{0:D}", val));
        }

        public void WriteInteger(long val, int padZeroes)
        {
            string text1 = string.Format("{0:D}", ((val > ((long) 0)) ? val : -val));
            while ((text1.Length < padZeroes))
            {
                text1 = "0" + text1;
            }
            if (val < ((long) 0))
            {
                text1 = "-" + text1.Substring(1);
            }
            this.mWriter.Write(text1);
        }

        public void WriteLn(object obj)
        {
            this.Write(obj);
            this.WriteEOL();
        }

        public void WriteName(PDFName val)
        {
            this.WriteName(val.Value);
        }

        public void WriteName(string val)
        {
            char ch1;
            int num1;
            Exception exception1 = Helpers.IsNameValid(val);
            if (exception1 != null)
            {
                throw exception1;
            }
            this.mWriter.Write("/");
            string text1 = val;
            for (num1 = 0; (num1 < text1.Length); num1 += 1)
            {
                ch1 = text1[num1];
                if ((ch1 < '!') || (ch1 > '~'))
                {
                    this.mWriter.Write(string.Format("#{0:S}", Helpers.NtoAOctal(((ulong) ch1))));
                }
                else
                {
                    this.mWriter.Write(ch1);
                }
            }
        }

        public void WriteNull()
        {
            this.mWriter.Write("null");
        }

        public void WriteOpenArray()
        {
            this.mWriter.Write("[");
        }

        public void WriteOpenDict()
        {
            this.mWriter.Write("<<");
        }

        public void WriteRaw(string val)
        {
            this.mWriter.Write(val);
        }

        public void WriteSp(object obj)
        {
            this.Write(obj);
            this.WriteSpace();
        }

        public void WriteSpace()
        {
            this.mWriter.Write(" ");
        }

        public void WriteStream(PDFStream val)
        {
            this.WriteLn(val.Dict);
            this.WriteRaw("stream");
            this.WriteEOL();
            this.WriteRaw("\n");
            if (val.IsExternal)
            {
                goto Label_0099;
            }
            byte[] numArray1 = new byte[4096];
            Stream stream1 = val.Decrypt();
            if (this.Encryption != null)
            {
                stream1 = this.Encryption.EncryptStream(stream1, val.Indirect.Id, val.Indirect.Generation);
            }
            int num1 = 0;
            this.mWriter.Flush();
            goto Label_008A;
        Label_007C:
            this.mStream.Write(numArray1, 0, num1);
        Label_008A:
            num1 = stream1.Read(numArray1, 0, numArray1.Length);
            if (num1 != 0)
            {
                goto Label_007C;
            }
        Label_0099:
            this.WriteEOL();
            this.WriteRaw("endstream");
        }

        public void WriteString(PDFString val)
        {
            byte num3;
            byte[] numArray1 = val.Bytes;
            PDFObject obj1 = val;
            while (!obj1.IsIndirect)
            {
                obj1 = obj1.Parent;
                if (obj1 == null)
                {
                    break;
                }
            }
            if ((this.Encryption != null) && (obj1 != null))
            {
                numArray1 = this.Encryption.EncryptString(val, obj1.Indirect.Id, obj1.Indirect.Generation);
            }
            byte[] numArray2 = new byte[((val.Bytes.Length * 2) + 2)];
            numArray2[0] = 40;
            int num1 = 1;
            int num2 = 0;
            while ((num2 < numArray1.Length))
            {
                num3 = numArray1[num2];
                if (num3 <= 13)
                {
                    if (num3 == 10)
                    {
                        goto Label_00EE;
                    }
                    if (num3 == 13)
                    {
                        goto Label_00DA;
                    }
                    goto Label_0102;
                }
                switch (num3)
                {
                    case 40:
                    {
                        int num6 = num1;
                        num1 = (num6 + 1);
                        numArray2[num1] = 92;
                        int num7 = num1;
                        num1 = (num7 + 1);
                        numArray2[num1] = 40;
                        goto Label_010D;
                    }
                    case 41:
                    {
                        int num8 = num1;
                        num1 = (num8 + 1);
                        numArray2[num1] = 92;
                        int num9 = num1;
                        num1 = (num9 + 1);
                        numArray2[num1] = 41;
                        goto Label_010D;
                    }
                }
                if (num3 != 92)
                {
                    goto Label_0102;
                }
                int num4 = num1;
                num1 = (num4 + 1);
                numArray2[num1] = 92;
                int num5 = num1;
                num1 = (num5 + 1);
                numArray2[num1] = 92;
                goto Label_010D;
            Label_00DA:
                int num10 = num1;
                num1 = (num10 + 1);
                numArray2[num1] = 92;
                int num11 = num1;
                num1 = (num11 + 1);
                numArray2[num1] = 114;
                goto Label_010D;
            Label_00EE:
                int num12 = num1;
                num1 = (num12 + 1);
                numArray2[num1] = 92;
                int num13 = num1;
                num1 = (num13 + 1);
                numArray2[num1] = 110;
                goto Label_010D;
            Label_0102:
                int num14 = num1;
                num1 = (num14 + 1);
                numArray2[num1] = numArray1[num2];
            Label_010D:
                num2 += 1;
            }
            int num15 = num1;
            num1 = (num15 + 1);
            numArray2[num1] = 41;
            this.mWriter.Flush();
            this.mStream.Write(numArray2, 0, num1);
        }

        public void WriteString(string val)
        {
            char ch1;
            char ch2;
            this.mWriter.Write("(");
            string text1 = val;
            int num1 = 0;
            while ((num1 < text1.Length))
            {
                ch1 = text1[num1];
                ch2 = ch1;
                switch (ch2)
                {
                    case '(':
                    {
                        this.mWriter.Write(@"\(");
                        goto Label_0078;
                    }
                    case ')':
                    {
                        this.mWriter.Write(@"\)");
                        goto Label_0078;
                    }
                }
                if (ch2 == '\\')
                {
                    this.mWriter.Write(@"\\");
                }
                else
                {
                    this.mWriter.Write(ch1);
                }
            Label_0078:
                num1 += 1;
            }
            this.mWriter.Write(")");
        }

        public void WriteXRefSection(ArrayList arr, int arrStart, int sectionStart, int count)
        {
            int num1;
            XRefEntry entry1;
            this.WriteSp(sectionStart);
            this.Write(count);
            this.WriteEOL();
            for (num1 = arrStart; (num1 < (arrStart + count)); num1 += 1)
            {
                entry1 = ((XRefEntry) arr[num1]);
                this.WriteInteger(entry1.offset, 10);
                this.WriteSpace();
                this.WriteInteger(((long) entry1.generation), 5);
                this.WriteSpace();
                if (entry1.type == 0)
                {
                    this.WriteRaw("f");
                }
                else
                {
                    this.WriteRaw("n");
                }
                this.WriteEOL();
                this.WriteRaw("\n");
            }
        }


        // Properties
        public Stream DataStream
        {
            get
            {
                return this.mStream;
            }
        }

        public long Position
        {
            get
            {
                this.mWriter.Flush();
                return this.mStream.Position;
            }
        }


        // Fields
        public IEncryption Encryption;
        public indirectFactory IndirectFactory;
        private NumberFormatInfo mNumberFormat;
        private Stream mStream;
        private StreamWriter mWriter;

        // Nested Types
        public delegate PDFIndirect indirectFactory();

    }
}


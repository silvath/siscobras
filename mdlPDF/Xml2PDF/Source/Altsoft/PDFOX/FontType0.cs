namespace Altsoft.PDFO
{
    using Altsoft.FTMB;
    using System;
    using System.IO;

    public class FontType0 : Altsoft.PDFO.Font
    {
        // Methods
        public FontType0(PDFDirect d) : base(d)
        {
        }

        public static Altsoft.PDFO.Font EmbedFont(Document doc, Stream fontstream, string encoding)
        {
            return FontType0.EmbedFont(doc, fontstream, encoding, false);
        }

        public static Altsoft.PDFO.Font EmbedFont(Document doc, Stream fontstream, string encoding, bool embedFontFile)
        {
            return FontType0.EmbedFont(doc, fontstream, encoding, embedFontFile, false);
        }

        public static Altsoft.PDFO.Font EmbedFont(Document doc, Stream fontstream, string encoding, bool embedFontFile, bool isVertical)
        {
            int num2;
            PDFArray array2;
            int num10;
            Altsoft.FTMB.Font font1 = Altsoft.FTMB.Font.OpenFont(fontstream);
            if ((font1.FontType != FontType.TrueTypeFontT) || (encoding != "Unicode"))
            {
                return null;
            }
            TrueTypeFont font2 = (font1 as TrueTypeFont);
            double num1 = ((double) font2.UnitsPerEm);
            PDFDict dict1 = Library.CreateDict();
            dict1["Type"] = Library.CreateName("Font");
            dict1["Subtype"] = Library.CreateName("CIDFontType2");
            dict1["BaseFont"] = Library.CreateName(font2.FontName);
            PDFDict dict2 = Library.CreateDict();
            dict2["Registry"] = Library.CreateString("Adobe");
            dict2["Ordering"] = Library.CreateString("Identity");
            dict2["Supplement"] = Library.CreateInteger(((long) 0));
            dict1["CIDSystemInfo"] = dict2;
            TTEncoding encoding1 = null;
            for (num2 = 0; ((num2 < font2.Encodings.Count) && (encoding1 == null)); num2 += 1)
            {
                encoding1 = ((TTEncoding) font2.Encodings[num2]);
                if ((encoding1.platformID != 3) || ((encoding1.specificID != 1) && (encoding1.specificID != 0)))
                {
                    encoding1 = null;
                }
            }
            if (encoding1 == null)
            {
                return null;
            }
            dict1["DW"] = Library.CreateInteger(((long) ((((double) font2.GetWidth(encoding1.GetGID(0))) * 1000f) / num1)));
            int num3 = 0;
            int num4 = encoding1.GetLastCharCode(ref num3);
            int num5 = encoding1.GetFirstCharCode(ref num3);
            PDFArray array1 = Library.CreateArray(0);
            if (num5 != 0)
            {
                array1.Add(Library.CreateInteger(((long) 0)));
                array2 = Library.CreateArray(0);
                array2.Add(Library.CreateInteger(((long) ((((double) font2.GetWidth(0, 3, 1)) * 1000f) / num1))));
                array1.Add(array2);
            }
            array1.Add(Library.CreateInteger(((long) num5)));
            array2 = Library.CreateArray(0);
            array2.Add(Library.CreateInteger(((long) ((((double) font2.GetWidth(num3)) * 1000f) / num1))));
            int num6 = num5;
            while ((num5 != num4))
            {
                num5 = encoding1.GetNextCharCode(num5, ref num3);
                if (num5 != (num6 + 1))
                {
                    array1.Add(array2);
                    array1.Add(Library.CreateInteger(((long) num5)));
                    array2 = Library.CreateArray(0);
                }
                num6 = num5;
                array2.Add(Library.CreateInteger(((long) ((((double) font2.GetWidth(num3)) * 1000f) / num1))));
            }
            array1.Add(array2);
            dict1["W"] = array1;
            Stream stream1 = new MemoryStream();
            int num7 = encoding1.GetFirstCharCode(ref num3);
            int num8 = 0;
            while ((num8 < num7))
            {
                stream1.WriteByte(0);
                stream1.WriteByte(0);
                num8 += 1;
            }
            stream1.WriteByte(((byte) (num3 / 256)));
            stream1.WriteByte(((byte) (num3 % 256)));
            num8 += 1;
            int num9 = encoding1.GetLastCharCode(ref num3);
            do
            {
                num7 = encoding1.GetNextCharCode(num7, ref num3);
                while ((num8 < num7))
                {
                    stream1.WriteByte(0);
                    stream1.WriteByte(0);
                    num8 += 1;
                }
                stream1.WriteByte(((byte) (num3 / 256)));
                stream1.WriteByte(((byte) (num3 % 256)));
                num8 += 1;
            }
            while ((num7 != num9));
            stream1.Position = ((long) 0);
            PDFDict dict3 = Library.CreateDict();
            dict3["Filter"] = Library.CreateName("FlateDecode");
            PDFStream stream2 = Library.CreateStream(stream1, dict3);
            dict1["CIDToGIDMap"] = doc.Indirects.New(stream2);
            PDFDict dict4 = Library.CreateDict();
            dict4["Type"] = Library.CreateName("FontDescriptor");
            dict4["FontName"] = Library.CreateName(font2.FontName);
            dict4["Flags"] = Library.CreateInteger(((long) 4));
            PDFArray array3 = Library.CreateArray(4);
            for (num10 = 0; (num10 < 4); num10 += 1)
            {
                array3[num10] = Library.CreateInteger(((long) font2.FontBBox[num10]));
            }
            dict4["FontBBox"] = array3;
            dict4["ItalicAngle"] = Library.CreateFixed(font2.ItalicAngle);
            dict4["Ascent"] = Library.CreateInteger(((long) font2.FontBBox[3]));
            dict4["Descent"] = Library.CreateInteger(((long) font2.FontBBox[1]));
            dict4["CapHeight"] = Library.CreateInteger(((long) font2.FontBBox[3]));
            dict4["StemV"] = Library.CreateInteger(((long) 0));
            if (((font2.EmbeddingRights == 0) || ((font2.EmbeddingRights & 8) != 0)) && embedFontFile)
            {
                font2.FontStream.Position = ((long) 0);
                dict3 = Library.CreateDict();
                dict3["Filter"] = Library.CreateName("FlateDecode");
                dict3["Length1"] = Library.CreateInteger(font2.FontStream.Length);
                dict4["FontFile2"] = doc.Indirects.New(Library.CreateStream(font2.FontStream, dict3));
            }
            dict1["FontDescriptor"] = doc.Indirects.New(dict4);
            PDFDict dict5 = Library.CreateDict();
            dict5["Type"] = Library.CreateName("Font");
            dict5["Subtype"] = Library.CreateName("Type0");
            dict5["BaseFont"] = Library.CreateName(font2.FontName);
            if (!isVertical)
            {
                dict5["Encoding"] = Library.CreateName("Identity-H");
            }
            else
            {
                dict5["Encoding"] = Library.CreateName("Identity-V");
            }
            PDFArray array4 = Library.CreateArray(1);
            array4[0] = doc.Indirects.New(dict1);
            dict5["DescendantFonts"] = array4;
            return new FontType0(dict5);
        }

        public bool EmbedFontFile(Stream fontStream)
        {
            PDFArray array1;
            PDFDict dict1;
            PDFDict dict2;
            Altsoft.FTMB.Font font1 = Altsoft.FTMB.Font.OpenFont(fontStream);
            if ((font1 == null) || !font1.GetType().Equals(typeof(TrueTypeFont)))
            {
                return false;
            }
            if (((font1.EmbeddingRights & 782) == 0) || ((font1.EmbeddingRights & 8) != 0))
            {
                array1 = (this.Dict["DescendantFonts"] as PDFArray);
                if (array1 == null)
                {
                    return false;
                }
                dict1 = (array1[0] as PDFDict);
                if (dict1 == null)
                {
                    return false;
                }
                dict1 = (dict1["FontDescriptor"] as PDFDict);
                if (dict1 == null)
                {
                    return false;
                }
                font1.FontStream.Position = ((long) 0);
                dict2 = Library.CreateDict();
                dict2["Filter"] = Library.CreateName("FlateDecode");
                dict2["Length1"] = Library.CreateInteger(font1.FontStream.Length);
                dict1["FontFile2"] = base.Direct.Doc.Indirects.New(Library.CreateStream(font1.FontStream, dict2));
                return true;
            }
            return false;
        }

        protected override void RetrieveWidths()
        {
            PDFObject obj1;
            PDFObject obj2;
            PDFObject obj3;
            PDFArray array3;
            int num3;
            int num4;
            int num5;
            int num6;
            double num7;
            int num8;
            PDFDict dict1 = ((PDFDict) base.Direct);
            PDFArray array1 = (dict1["DescendantFonts"] as PDFArray);
            if (array1 == null)
            {
                throw new ArgumentException("Bad DESCENDANTFONTS entry.");
            }
            dict1 = (array1[0] as PDFDict);
            if (dict1 == null)
            {
                throw new ArgumentException("Bad DESCENDANTFONTS entry.");
            }
            PDFNumeric numeric1 = (dict1["DW"] as PDFNumeric);
            if (numeric1 != null)
            {
                numeric1.DoubleValue;
            }
            PDFArray array2 = (dict1["W"] as PDFArray);
            if (array2 == null)
            {
                return;
            }
            int num1 = array2.Count;
            int num2 = 0;
            while ((num2 < num1))
            {
                obj1 = array2[num2];
                num2 += 1;
                obj2 = array2[num2];
                num2 += 1;
                if ((obj2 is PDFArray))
                {
                    array3 = (obj2 as PDFArray);
                    num3 = ((PDFNumeric) obj1).Int32Value;
                    for (num4 = 0; (num4 < array3.Count); num4 += 1)
                    {
                        this.mWidths[((ushort) (num3 + num4))] = ((PDFNumeric) array3[num4]).DoubleValue;
                    }
                    continue;
                }
                obj3 = array2[num2];
                num2 += 1;
                num5 = ((PDFNumeric) obj1).Int32Value;
                num6 = ((PDFNumeric) obj2).Int32Value;
                num7 = ((PDFNumeric) obj3).DoubleValue;
                for (num8 = num5; (num8 <= num6); num8 += 1)
                {
                    this.mWidths[((ushort) num8)] = num7;
                }
            }
        }

    }
}


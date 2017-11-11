namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using Altsoft.FTMB;
    using System;
    using System.Collections;
    using System.IO;

    public abstract class Font : Resource
    {
        // Methods
        static Font()
        {
            Altsoft.PDFO.Font.DictKeyName = "Font";
        }

        protected Font(PDFDirect d) : base(d)
        {
            PDFDict dict2;
            PDFArray array1;
            PDFArray array2;
            this.isWidthRead = false;
            this.isEncodingRead = false;
            this.mMatrix = new CTM(0.001f, 0f, 0f, 0.001f, 0f, 0f);
            this.mBBox = new Rect(-200f, -250f, 1050f, 1100f);
            PDFDict dict1 = null;
            if (this.SubType == EFontType.Type0)
            {
                array1 = (this.Dict["DescendantFonts"] as PDFArray);
                if (array1 != null)
                {
                    dict2 = (array1[0] as PDFDict);
                    if (dict2 != null)
                    {
                        dict1 = (dict2["FontDescriptor"] as PDFDict);
                    }
                }
            }
            else
            {
                dict1 = (this.Dict["FontDescriptor"] as PDFDict);
            }
            if (dict1 != null)
            {
                array2 = (dict1["FontBBox"] as PDFArray);
                if (array2 == null)
                {
                    throw new ArgumentException("Bad Font BBox");
                }
                this.mBBox = new PDFRect(array2);
            }
            this.mWidths = new Hashtable();
            this.mEncoding = new string[256];
        }

        public static Altsoft.PDFO.Font Create(Document doc, Stream fontstream, string encoding)
        {
            return Altsoft.PDFO.Font.Create(doc, fontstream, encoding, true);
        }

        public static Altsoft.PDFO.Font Create(Document doc, Stream fontstream, string encoding, bool embedFontFile)
        {
            Altsoft.FTMB.Font font1 = Altsoft.FTMB.Font.OpenFont(fontstream);
            FontType type1 = font1.FontType;
            if (type1 == FontType.TrueTypeFontT)
            {
                if (encoding == "Unicode")
                {
                    return FontType0.EmbedFont(doc, fontstream, encoding, embedFontFile);
                }
                return null;
            }
            return null;
        }

        internal static Resource Factory(PDFDirect d)
        {
            PDFDict dict1;
            string text1;
            Resource resource1;
            try
            {
                dict1 = (d as PDFDict);
                if (dict1 == null)
                {
                    throw new ArgumentException("Not a font DICTIONARY");
                }
                if (((PDFName) dict1["Type"]).Value != "Font")
                {
                    throw new ArgumentException("Not a FONT dictionary");
                }
                text1 = ((PDFName) dict1["Subtype"]).Value;
                if (text1 == "Type0")
                {
                    return new FontType0(d);
                }
                if (text1 == "Type1")
                {
                    return new FontType1(d);
                }
                if (text1 == "Type3")
                {
                    return new FontType3(d);
                }
                if (text1 == "TrueType")
                {
                    return new FontTrueType(d);
                }
                if (text1 == "MMType1")
                {
                    return new FontType1(d);
                }
                if (text1 == "CIDFontType0")
                {
                    return new FontType0(d);
                }
                if (text1 == "CIDFontType2")
                {
                    return new FontType0(d);
                }
                throw new PDFException("Unknown font SUBTYPE");
            }
            catch (NullReferenceException)
            {
                throw new ArgumentException("INVALID font dictionary");
            }
            return resource1;
        }

        public Stream GetFontStream()
        {
            PDFDict dict1;
            PDFArray array1;
            PDFDict dict2;
            int num1;
            if (this.IsStandardFont)
            {
                return null;
            }
            if (base.GetType().Equals(typeof(FontType0)))
            {
                dict1 = ((PDFDict) base.Direct);
                array1 = (dict1["DescendantFonts"] as PDFArray);
                if (array1 == null)
                {
                    throw new ArgumentException("Bad DESCENDANTFONTS entry.");
                }
                dict1 = (array1[0] as PDFDict);
                if (dict1 != null)
                {
                    goto Label_006E;
                }
                throw new ArgumentException("Bad DESCENDANTFONTS entry.");
            }
            dict1 = this.Dict;
        Label_006E:
            dict2 = (dict1["FontDescriptor"] as PDFDict);
            if (dict2 == null)
            {
                throw new ArgumentException("No FontDescriptor entry for non-standard font.");
            }
            PDFStream stream1 = (dict2["FontFile"] as PDFStream);
            if (stream1 == null)
            {
                stream1 = (dict2["FontFile2"] as PDFStream);
            }
            if (stream1 == null)
            {
                stream1 = (dict2["FontFile3"] as PDFStream);
            }
            if (stream1 == null)
            {
                return null;
            }
            MemoryStream stream2 = new MemoryStream();
            byte[] numArray1 = new byte[65536];
            Stream stream3 = stream1.Decode();
            goto Label_00F4;
        Label_00E8:
            stream2.Write(numArray1, 0, num1);
        Label_00F4:
            num1 = stream3.Read(numArray1, 0, 65536);
            if (num1 != 65536)
            {
                return stream2;
            }
            goto Label_00E8;
        }

        protected void RetrieveEncoding()
        {
            int num1;
            PDFArray array1;
            PDFInteger integer1;
            int num2;
            PDFName name2;
            if (this.isEncodingRead)
            {
                return;
            }
            string text1 = "";
            PDFName name1 = null;
            PDFDict dict1 = null;
            PDFObject obj1 = this.Dict["Encoding"];
            int[] numArray1 = null;
            if (obj1 != null)
            {
                name1 = (obj1 as PDFName);
                dict1 = (obj1 as PDFDict);
                if (name1 == null)
                {
                    if (dict1 == null)
                    {
                        throw new ArgumentException("Bad Encoding entry in the font dictionary");
                    }
                    name1 = (this.Dict["BaseEncoding"] as PDFName);
                    if (name1 == null)
                    {
                        throw new ArgumentException("BaseEncoding is not a name.");
                    }
                }
            }
            if (name1 != null)
            {
                text1 = name1.Value;
            }
            else if ((this.IsStandardFont && (this.BaseFont != "Symbol")) && (this.BaseFont != "ZapfDingbats"))
            {
                text1 = "StandardEncoding";
            }
            if (text1 == "")
            {
                goto Label_0172;
            }
            string text2 = text1;
            if (text2 == null)
            {
                goto Label_0167;
            }
            text2 = string.IsInterned(text2);
            if (text2 != "StandardEncoding")
            {
                if (text2 == "MacRomanEncoding")
                {
                    goto Label_0127;
                }
                if (text2 == "WinAnsiEncoding")
                {
                    goto Label_0137;
                }
                if (text2 == "PDFDocEncoding")
                {
                    goto Label_0147;
                }
                if (text2 == "MacExpertEncoding")
                {
                    goto Label_0157;
                }
                goto Label_0167;
            }
            this.mBaseEncoding = EEncoding.StandardEncoding;
            numArray1 = FontConstants.StandardIndex;
            goto Label_0172;
        Label_0127:
            this.mBaseEncoding = EEncoding.MacRomanEncoding;
            numArray1 = FontConstants.MacRomanIndex;
            goto Label_0172;
        Label_0137:
            this.mBaseEncoding = EEncoding.WinAnsiEncoding;
            numArray1 = FontConstants.WinAnsiIndex;
            goto Label_0172;
        Label_0147:
            this.mBaseEncoding = EEncoding.PDFDocEncoding;
            numArray1 = FontConstants.PDFDocIndex;
            goto Label_0172;
        Label_0157:
            this.mBaseEncoding = EEncoding.MacExpertEncoding;
            numArray1 = FontConstants.MacExpertIndex;
            goto Label_0172;
        Label_0167:
            throw new ArgumentException("Unknown encoding");
        Label_0172:
            if (this.IsStandardFont && ((this.BaseFont == "Symbol") || (this.BaseFont == "ZapfDingbats")))
            {
                if (this.BaseFont == "ZapfDingbats")
                {
                    this.mEncoding = FontConstants.ZapfDingbatsEncodingIndex;
                }
                else
                {
                    this.mEncoding = FontConstants.SymbolEncodingIndex;
                }
                this.Dict.Remove("Encoding");
            }
            else
            {
                for (num1 = 0; (num1 < numArray1.Length); num1 += 1)
                {
                    this.mEncoding[num1] = FontConstants.glyphPool[numArray1[num1]];
                }
            }
            if (dict1 != null)
            {
                array1 = (dict1["Differences", 1] as PDFArray);
                if (array1 != null)
                {
                    integer1 = (array1[0] as PDFInteger);
                    if (integer1 == null)
                    {
                        throw new ArgumentException("Bad differences array. Numeric data must be the first entry");
                    }
                    num2 = integer1.Int32Value;
                    foreach (PDFObject obj2 in array1)
                    {
                        if (typeof(PDFInteger) == obj2.GetType())
                        {
                            integer1 = (obj2 as PDFInteger);
                            num2 = integer1.Int32Value;
                            continue;
                        }
                        if ((256 < num2) && (0 > num2))
                        {
                            throw new ArgumentException("Bad entry in the differences array. Integer values greater than 256 are not allowed");
                        }
                        name2 = (obj2 as PDFName);
                        if (name2 == null)
                        {
                            throw new ArgumentException("Bad entry in the differences array. Only Integer and Name entryies allowed");
                        }
                        this.mEncoding[num2] = name2.Value;
                        num2 += 1;
                    }
                }
            }
            this.isEncodingRead = true;
        }

        protected virtual void RetrieveWidths()
        {
            PDFNumeric numeric1;
            int[] numArray1;
            string[] textArray1;
            int num2;
            bool flag1;
            int num3;
            int num4;
            bool flag2;
            int num5;
            PDFInteger integer1;
            if (<PrivateImplementationDetails>.$$method0x60006b9-1 == null)
            {
                Hashtable hashtable1 = new Hashtable(30, 0.5f);
                hashtable1.Add("Times-Roman", 0);
                Hashtable hashtable2 = new Hashtable(30, 0.5f);
                hashtable2.Add("Times-Italic", 1);
                Hashtable hashtable3 = new Hashtable(30, 0.5f);
                hashtable3.Add("Times-Bold", 2);
                Hashtable hashtable4 = new Hashtable(30, 0.5f);
                hashtable4.Add("Times-BoldItalic", 3);
                Hashtable hashtable5 = new Hashtable(30, 0.5f);
                hashtable5.Add("Helvetica", 4);
                Hashtable hashtable6 = new Hashtable(30, 0.5f);
                hashtable6.Add("Helvetica-Oblique", 5);
                Hashtable hashtable7 = new Hashtable(30, 0.5f);
                hashtable7.Add("Helvetica-Bold", 6);
                Hashtable hashtable8 = new Hashtable(30, 0.5f);
                hashtable8.Add("Helvetica-BoldOblique", 7);
                Hashtable hashtable9 = new Hashtable(30, 0.5f);
                hashtable9.Add("Courier", 8);
                Hashtable hashtable10 = new Hashtable(30, 0.5f);
                hashtable10.Add("Courier-Bold", 9);
                Hashtable hashtable11 = new Hashtable(30, 0.5f);
                hashtable11.Add("Courier-Oblique", 10);
                Hashtable hashtable12 = new Hashtable(30, 0.5f);
                hashtable12.Add("Courier-BoldOblique", 11);
                Hashtable hashtable13 = new Hashtable(30, 0.5f);
                hashtable13.Add("Symbol", 12);
                Hashtable hashtable14 = new Hashtable(30, 0.5f);
                hashtable14.Add("ZapfDingbats", 13);
                <PrivateImplementationDetails>.$$method0x60006b9-1 = new Hashtable(30, 0.5f);
            }
            if (this.isWidthRead)
            {
                return;
            }
            this.mMissingWidth = 0f;
            PDFDict dict1 = (this.Dict["FontDescriptor"] as PDFDict);
            if (dict1 != null)
            {
                numeric1 = (dict1["MissingWidth"] as PDFNumeric);
                if (numeric1 == null)
                {
                    throw new ArgumentException("Bad MissingWidth entry.");
                }
                this.mMissingWidth = numeric1.DoubleValue;
            }
            int num1 = 0;
            PDFArray array1 = (this.Dict["Widths"] as PDFArray);
            if (array1 != null)
            {
                goto Label_0451;
            }
            if (!this.IsStandardFont)
            {
                throw new ArgumentException("No Width entry for non-standard font.");
            }
            object obj1 = this.BaseFont;
            if (obj1 == null)
            {
                goto Label_036A;
            }
            obj1 = <PrivateImplementationDetails>.$$method0x60006b9-1[obj1];
            if (obj1 == null)
            {
                goto Label_036A;
            }
            switch (((int) obj1))
            {
                case 0:
                {
                    numArray1 = FontConstants.TimesRomanWidths;
                    goto Label_0375;
                }
                case 1:
                {
                    numArray1 = FontConstants.TimesItalicWidths;
                    goto Label_0375;
                }
                case 2:
                {
                    numArray1 = FontConstants.TimesBoldWidths;
                    goto Label_0375;
                }
                case 3:
                {
                    numArray1 = FontConstants.TimesBoldItalicWidths;
                    goto Label_0375;
                }
                case 4:
                case 5:
                {
                    numArray1 = FontConstants.HelveticaWidths;
                    goto Label_0375;
                }
                case 6:
                case 7:
                {
                    numArray1 = FontConstants.HelveticaBoldWidths;
                    goto Label_0375;
                }
                case 8:
                case 11:
                case 10:
                case 9:
                {
                    numArray1 = FontConstants.CourierWidths;
                    goto Label_0375;
                }
                case 12:
                case 13:
                {
                    if ("Symbol" != this.BaseFont)
                    {
                        goto Label_0283;
                    }
                    textArray1 = FontConstants.SymbolEncodingIndex;
                    numArray1 = FontConstants.SymbolWidthsExplicit;
                    goto Label_0291;
                }
            }
            goto Label_036A;
        Label_0283:
            textArray1 = FontConstants.ZapfDingbatsEncodingIndex;
            numArray1 = FontConstants.ZapfDingbatsWidthsExplicit;
        Label_0291:
            num2 = 0;
            while ((num2 < this.Encoding.Length))
            {
                flag1 = false;
                num3 = 0;
                while ((num3 < textArray1.Length))
                {
                    if (this.Encoding[num2] == textArray1[num3])
                    {
                        flag1 = true;
                        break;
                    }
                    num3 += 1;
                }
                if (flag1)
                {
                    this.mWidths[((ushort) num2)] = ((double) numArray1[num3]);
                }
                else
                {
                    this.mWidths[((ushort) num2)] = ((double) numArray1[num2]);
                }
                if (((double) this.mWidths[((ushort) num2)]) == 0f)
                {
                    this.mWidths[((ushort) num2)] = this.mMissingWidth;
                }
                num2 += 1;
            }
            this.isWidthRead = true;
            return;
        Label_036A:
            throw new ArgumentException("No such standard font for width substitude");
        Label_0375:
            num4 = 0;
            while ((num4 < this.Encoding.Length))
            {
                flag2 = false;
                num5 = 0;
                while ((num5 < FontConstants.glyphPool.Length))
                {
                    if (this.mEncoding[num4] == FontConstants.glyphPool[num5])
                    {
                        flag2 = true;
                        break;
                    }
                    num5 += 1;
                }
                if (flag2)
                {
                    this.mWidths[((ushort) num4)] = ((double) numArray1[num5]);
                }
                else
                {
                    this.mWidths[((ushort) num4)] = ((double) numArray1[num4]);
                }
                if (((double) this.mWidths[((ushort) num4)]) == 0f)
                {
                    this.mWidths[((ushort) num4)] = this.mMissingWidth;
                }
                num4 += 1;
            }
            goto Label_04F0;
        Label_0451:
            integer1 = (this.Dict["FirstChar"] as PDFInteger);
            if (integer1 == null)
            {
                throw new ArgumentException("FirstChar is not defined in non-standard font");
            }
            num1 = integer1.Int32Value;
            int num6 = 0;
            foreach (PDFNumeric numeric2 in array1)
            {
                if (numeric2 == null)
                {
                    throw new ArgumentException("Incorrect Widths entry.");
                }
                this.mWidths[((ushort) (num1 + num6))] = numeric2.DoubleValue;
                num6 += 1;
            }
        Label_04F0:
            this.isWidthRead = true;
        }


        // Properties
        public EEncoding BaseEncoding
        {
            get
            {
                if (!this.isEncodingRead)
                {
                    this.RetrieveEncoding();
                }
                return this.mBaseEncoding;
            }
        }

        public virtual string BaseFont
        {
            get
            {
                PDFObject obj1 = this.Dict["BaseFont", 1];
                if ((obj1 != null) && (PDFObjectType.tPDFName != obj1.PDFType))
                {
                    throw new ArgumentException("No required BASEFONT entry in the font dictionary");
                }
                PDFName name1 = (obj1 as PDFName);
                return name1.Value;
            }
        }

        public Rect BBox
        {
            get
            {
                return this.mBBox;
            }
        }

        public string[] Encoding
        {
            get
            {
                if (!this.isEncodingRead)
                {
                    this.RetrieveEncoding();
                }
                return this.mEncoding;
            }
        }

        public bool IsStandardFont
        {
            get
            {
                if (<PrivateImplementationDetails>.$$method0x60006ad-1 == null)
                {
                    Hashtable hashtable1 = new Hashtable(30, 0.5f);
                    hashtable1.Add("Courier", 0);
                    Hashtable hashtable2 = new Hashtable(30, 0.5f);
                    hashtable2.Add("Courier-Bold", 1);
                    Hashtable hashtable3 = new Hashtable(30, 0.5f);
                    hashtable3.Add("Courier-BoldOblique", 2);
                    Hashtable hashtable4 = new Hashtable(30, 0.5f);
                    hashtable4.Add("Courier-Oblique", 3);
                    Hashtable hashtable5 = new Hashtable(30, 0.5f);
                    hashtable5.Add("Helvetica", 4);
                    Hashtable hashtable6 = new Hashtable(30, 0.5f);
                    hashtable6.Add("Helvetica-Bold", 5);
                    Hashtable hashtable7 = new Hashtable(30, 0.5f);
                    hashtable7.Add("Helvetica-BoldOblique", 6);
                    Hashtable hashtable8 = new Hashtable(30, 0.5f);
                    hashtable8.Add("Helvetica-Oblique", 7);
                    Hashtable hashtable9 = new Hashtable(30, 0.5f);
                    hashtable9.Add("Times-Roman", 8);
                    Hashtable hashtable10 = new Hashtable(30, 0.5f);
                    hashtable10.Add("Times-Bold", 9);
                    Hashtable hashtable11 = new Hashtable(30, 0.5f);
                    hashtable11.Add("Times-Italic", 10);
                    Hashtable hashtable12 = new Hashtable(30, 0.5f);
                    hashtable12.Add("Times-BoldItalic", 11);
                    Hashtable hashtable13 = new Hashtable(30, 0.5f);
                    hashtable13.Add("Symbol", 12);
                    Hashtable hashtable14 = new Hashtable(30, 0.5f);
                    hashtable14.Add("ZapfDingbats", 13);
                    <PrivateImplementationDetails>.$$method0x60006ad-1 = new Hashtable(30, 0.5f);
                }
                object obj1 = this.BaseFont;
                if (obj1 == null)
                {
                    goto Label_0175;
                }
                obj1 = <PrivateImplementationDetails>.$$method0x60006ad-1[obj1];
                if (obj1 == null)
                {
                    goto Label_0175;
                }
                switch (((int) obj1))
                {
                    case 0:
                    case 13:
                    case 12:
                    case 11:
                    case 10:
                    case 9:
                    case 8:
                    case 7:
                    case 6:
                    case 5:
                    case 4:
                    case 3:
                    case 2:
                    case 1:
                    {
                        goto Label_0173;
                    }
                }
                goto Label_0175;
            Label_0173:
                return true;
            Label_0175:
                return false;
            }
        }

        public bool IsSymbolic
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsVerticalMode
        {
            get
            {
                return false;
            }
        }

        public CTM Matrix
        {
            get
            {
                return this.mMatrix;
            }
        }

        public double MissingWidth
        {
            get
            {
                return this.mMissingWidth;
            }
        }

        public EFontType SubType
        {
            get
            {
                PDFName name1 = (this.Dict["Subtype"] as PDFName);
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_0094;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "Type0")
                {
                    if (text1 == "Type1")
                    {
                        goto Label_0088;
                    }
                    if (text1 == "MMType1")
                    {
                        goto Label_008A;
                    }
                    if (text1 == "Type3")
                    {
                        goto Label_008C;
                    }
                    if (text1 == "TrueType")
                    {
                        goto Label_008E;
                    }
                    if (text1 == "CIDFontType2")
                    {
                        goto Label_0090;
                    }
                    if (text1 == "CIDFontType0")
                    {
                        goto Label_0092;
                    }
                    goto Label_0094;
                }
                return EFontType.Type0;
            Label_0088:
                return EFontType.Type1;
            Label_008A:
                return EFontType.MMType1;
            Label_008C:
                return EFontType.Type3;
            Label_008E:
                return EFontType.TrueType;
            Label_0090:
                return EFontType.CIDFontType2;
            Label_0092:
                return EFontType.CIDFontType0;
            Label_0094:
                throw new ArgumentException("Unknown font sub type");
            }
        }

        public Hashtable Widths
        {
            get
            {
                if (!this.isWidthRead)
                {
                    this.RetrieveWidths();
                }
                return this.mWidths;
            }
        }


        // Fields
        internal static readonly string DictKeyName;
        protected bool isEncodingRead;
        protected bool isWidthRead;
        protected EEncoding mBaseEncoding;
        protected Rect mBBox;
        protected string[] mEncoding;
        protected CTM mMatrix;
        protected double mMissingWidth;
        protected Hashtable mWidths;
    }
}


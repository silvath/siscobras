namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.Drawing;
    using System.IO;

    public class XObjectImage : XObject
    {
        // Methods
        internal XObjectImage(PDFDirect d) : base(d)
        {
            this.mCS = null;
            this.mMaskColorRange = null;
            this.mMask = null;
            this.mSMask = null;
            this.mDecode = null;
            this.mAlternates = null;
        }

        public static XObjectImage Create(Bitmap img, params string[] encoding)
        {
            return XObjectImage.Create(Library.Resources.Doc, img, encoding);
        }

        public static XObjectImage Create(Document doc, Bitmap img, params string[] encoding)
        {
            int num3;
            int num4;
            int num5;
            Color color1;
            int num6;
            PDFArray array1;
            int num7;
            int num8;
            PDFStream stream1 = Library.CreateStream();
            PDFDict dict1 = stream1.Dict;
            dict1["Width"] = PDF.O(img.Width);
            dict1["Height"] = PDF.O(img.Height);
            dict1["Subtype"] = PDF.N("Image");
            dict1["Type"] = PDF.N("XObject");
            byte[] numArray1 = null;
            BitArrayAccessor accessor1 = null;
            int num1 = 0;
            int num2 = 0;
            if (doc == null)
            {
                doc = Library.Resources.Doc;
            }
            XObjectImage image1 = ((XObjectImage) doc.Resources[doc.Indirects.New(stream1), typeof(XObjectImage)]);
            image1.ColorSpace = ColorSpaceDeviceRGB.Create();
            numArray1 = new byte[((3 * img.Width) * img.Height)];
            num1 = 8;
            num2 = (3 * img.Width);
            dict1["BitsPerComponent"] = PDF.O(8);
            for (num3 = 0; (num3 < img.Height); num3 += 1)
            {
                num4 = 0;
                accessor1 = new BitArrayAccessor(numArray1, ((num3 * num2) * 8), num1, false);
                for (num5 = 0; (num5 < img.Width); num5 += 1)
                {
                    color1 = img.GetPixel(num5, num3);
                    num6 = 0;
                    while ((num6 < 3))
                    {
                        num8 = num6;
                        switch (num8)
                        {
                            case 0:
                            {
                                int num9 = num4;
                                num4 = (num9 + 1);
                                accessor1[num4] = ((long) ((ulong) color1.R));
                                goto Label_0180;
                            }
                            case 1:
                            {
                                int num10 = num4;
                                num4 = (num10 + 1);
                                accessor1[num4] = ((long) ((ulong) color1.G));
                                goto Label_0180;
                            }
                            case 2:
                            {
                                goto Label_016B;
                            }
                        }
                        goto Label_0180;
                    Label_016B:
                        int num11 = num4;
                        num4 = (num11 + 1);
                        accessor1[num4] = ((long) ((ulong) color1.B));
                    Label_0180:
                        num6 += 1;
                    }
                }
            }
            MemoryStream stream2 = new MemoryStream(numArray1);
            if (encoding.Length > 0)
            {
                array1 = Library.CreateArray(encoding.Length);
                stream1.Dict["Filter"] = array1;
                for (num7 = 0; (num7 < encoding.Length); num7 += 1)
                {
                    array1[num7] = PDF.N(encoding[num7]);
                }
            }
            stream1.Encode(stream2);
            return image1;
        }


        // Properties
        public AlternateImageColl Alternates
        {
            get
            {
                if (this.mAlternates == null)
                {
                    this.mAlternates = new AlternateImageColl(this);
                }
                return this.mAlternates;
            }
        }

        public int BitsPerComponent
        {
            get
            {
                if (this.IsImageMask)
                {
                    return 1;
                }
                PDFInteger integer1 = (this.Dict["BitsPerComponent"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return integer1.Int32Value;
            }
            set
            {
                if ((((value != 1) && (value != 2)) && ((value != 4) && (value != 8))) && (value != 16))
                {
                    throw new ArgumentException("Bits per component should be one of the 1,2,4,8,16");
                }
                if (this.IsImageMask && (value != 1))
                {
                    throw new ArgumentException("Only 1 bit per component allowed for image masks");
                }
                this.Dict["BitsPerComponent"] = Library.CreateInteger(((long) value));
            }
        }

        public ColorSpace ColorSpace
        {
            get
            {
                PDFDirect direct1;
                if (this.mCS == null)
                {
                    direct1 = this.Dict["ColorSpace"].Direct;
                    if (direct1 == null)
                    {
                        return null;
                    }
                    if (this.Dict.Doc == null)
                    {
                        this.mCS = ((ColorSpace) ColorSpace.Factory(direct1));
                    }
                    else
                    {
                        this.mCS = ((ColorSpace) this.Dict.Doc.Resources[direct1, typeof(ColorSpace)]);
                    }
                }
                return this.mCS;
            }
            set
            {
                if (value == null)
                {
                    this.Dict.Remove("ColorSpace");
                }
                else
                {
                    this.Dict["ColorSpace"] = this.Dict.Doc.Resources.Add(value).Direct;
                }
                this.mCS = value;
            }
        }

        public DoubleMinMaxArray Decode
        {
            get
            {
                double[] numArray1;
                ColorSpaceLab lab1;
                ColorSpaceIndexed indexed1;
                int num1;
                double[] numArray2;
                if (this.mDecode == null)
                {
                    numArray1 = null;
                    if (this.ColorSpace == null)
                    {
                        numArray2 = new double[2];
                        numArray2[1] = 1f;
                        numArray1 = numArray2;
                    }
                    else if (this.ColorSpace.GetType().Equals(typeof(ColorSpaceLab)))
                    {
                        lab1 = (this.ColorSpace as ColorSpaceLab);
                        numArray2 = new double[6];
                        numArray2[1] = 100f;
                        numArray2[2] = lab1.RangeAMin;
                        numArray2[3] = lab1.RangeAMax;
                        numArray2[4] = lab1.RangeBMin;
                        numArray2[5] = lab1.RangeBMax;
                        numArray1 = numArray2;
                    }
                    else if (this.ColorSpace.GetType().Equals(typeof(ColorSpaceIndexed)))
                    {
                        indexed1 = (this.ColorSpace as ColorSpaceIndexed);
                        numArray2 = new double[2];
                        numArray2[1] = ((double) indexed1.Count);
                        numArray1 = numArray2;
                    }
                    else
                    {
                        numArray1 = new double[(this.ColorSpace.NrOfChannels * 2)];
                        for (num1 = 0; (num1 < numArray1.Length); num1 += 1)
                        {
                            numArray1[num1] = ((double) (num1 % 2));
                        }
                    }
                    this.mDecode = new DoubleMinMaxArray(new PDFDoubleArray(this.Dict, "Decode", false, numArray1));
                }
                return this.mDecode;
            }
            set
            {
                if (this.Decode == null)
                {
                    this.Dict["Decode"] = Library.CreateObject(false, value.LinearArray);
                    return;
                }
                this.Decode.Set(value);
            }
        }

        public int Height
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Height"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.Dict["Height"] = Library.CreateInteger(((long) value));
            }
        }

        public string ID
        {
            get
            {
                PDFString text1 = (this.Dict["ID"] as PDFString);
                if (text1 == null)
                {
                    return "";
                }
                return text1.Value;
            }
            set
            {
                PDFIndirect indirect1 = (this.Dict["ID", 0] as PDFIndirect);
                if (indirect1 == null)
                {
                    indirect1 = this.Dict.Doc.Indirects.New(Library.CreateString(value));
                    this.Dict["ID"] = indirect1;
                    return;
                }
                indirect1.Direct = Library.CreateString(value);
            }
        }

        public bool Interpolate
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["Interpolate"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["Interpolate"] = Library.CreateBoolean(value);
            }
        }

        public bool IsImageMask
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["ImageMask"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["ImageMask"] = Library.CreateBoolean(value);
            }
        }

        public XObjectImage Mask
        {
            get
            {
                PDFStream stream1;
                if (this.mMaskColorRange != null)
                {
                    return null;
                }
                if (this.mMask == null)
                {
                    stream1 = (this.Dict["Mask"] as PDFStream);
                    if (stream1 == null)
                    {
                        return null;
                    }
                    if (this.Dict.Doc == null)
                    {
                        this.mMask = ((XObjectImage) XObject.Factory(stream1));
                    }
                    else
                    {
                        this.mMask = ((XObjectImage) this.Dict.Doc.Resources[stream1, typeof(XObject)]);
                    }
                }
                return this.mMask;
            }
            set
            {
                this.Dict["Mask"] = value.Direct;
                this.mMask = value;
                this.mMaskColorRange = null;
            }
        }

        public IntMinMaxArray MaskColorRange
        {
            get
            {
                PDFArray array1;
                if (this.mMask != null)
                {
                    return null;
                }
                if (this.mMaskColorRange == null)
                {
                    array1 = (this.Dict["Mask"] as PDFArray);
                    if (array1 == null)
                    {
                        return null;
                    }
                    this.mMaskColorRange = new IntMinMaxArray(new PDFInt64Array(array1, array1.Count));
                }
                return this.mMaskColorRange;
            }
            set
            {
                this.Dict["Mask"] = (Library.CreateObject(false, value.LinearArray) as PDFArray);
                this.mMaskColorRange = null;
                this.mMask = null;
            }
        }

        public OPIDict13 OPI13
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public OPIDict20 OPI20
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public RenderIntent RenderIntent
        {
            get
            {
                int num1;
                PDFName name1 = (this.Dict["Intent"] as PDFName);
                if (name1 == null)
                {
                    return RenderIntent.Unknown;
                }
                string text1 = name1.Value;
                for (num1 = 0; (num1 < ExtGState.RIs.Length); num1 += 1)
                {
                    if (text1 == ExtGState.RIs[num1])
                    {
                        return ((RenderIntent) num1);
                    }
                }
                return RenderIntent.Unknown;
            }
            set
            {
                this.Dict["Intent"] = Library.CreateName(ExtGState.RIs[value]);
            }
        }

        public XObjectImage SMask
        {
            get
            {
                PDFStream stream1;
                if (this.mSMask == null)
                {
                    stream1 = (this.Dict["SMASK"] as PDFStream);
                    if (stream1 == null)
                    {
                        return null;
                    }
                    if (this.Dict.Doc == null)
                    {
                        this.mSMask = ((XObjectImage) XObject.Factory(stream1));
                    }
                    else
                    {
                        this.mSMask = ((XObjectImage) this.Dict.Doc.Resources[stream1, typeof(XObject)]);
                    }
                }
                return this.mSMask;
            }
            set
            {
                this.Dict["SMASK"] = value.Direct;
                this.mSMask = value;
            }
        }

        public int StructParent
        {
            get
            {
                PDFInteger integer1 = (this.Dict["StructParent"] as PDFInteger);
                if (integer1 == null)
                {
                    return -1;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.Dict["StructParent"] = Library.CreateInteger(((long) value));
            }
        }

        public int Width
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Width"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.Dict["Width"] = Library.CreateInteger(((long) value));
            }
        }


        // Fields
        private AlternateImageColl mAlternates;
        private ColorSpace mCS;
        private DoubleMinMaxArray mDecode;
        private XObjectImage mMask;
        private IntMinMaxArray mMaskColorRange;
        private XObjectImage mSMask;
    }
}


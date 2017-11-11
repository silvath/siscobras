namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.IO;

    public class ColorSpaceICCBased : ColorSpaceCIEBased
    {
        // Methods
        internal ColorSpaceICCBased(PDFDirect d) : base(d)
        {
            this.mRange = null;
        }

        public static ColorSpaceICCBased Create(Document doc, bool indirect, Stream profile, params string[] encoding)
        {
            PDFArray array2;
            int num2;
            PDFArray array1 = Library.CreateArray(2);
            array1[0] = PDF.N("ICCBased");
            PDFStream stream1 = Library.CreateStream();
            byte[] numArray1 = new byte[30];
            profile.Position = ((long) 0);
            int num1 = profile.Read(numArray1, 0, 30);
            if (num1 == 0)
            {
                throw new Exception("Empty ICC profile");
            }
            string text1 = Utils.BytesToString(numArray1);
            if (text1.IndexOf("GRAY") != -1)
            {
                stream1.Dict["N"] = Library.CreateInteger(((long) 1));
            }
            if (text1.IndexOf("RGB") != -1)
            {
                stream1.Dict["N"] = Library.CreateInteger(((long) 3));
            }
            if (text1.IndexOf("CMYK") != -1)
            {
                stream1.Dict["N"] = Library.CreateInteger(((long) 4));
            }
            if ((encoding != null) && (encoding.Length > 0))
            {
                array2 = Library.CreateArray(encoding.Length);
                stream1.Dict["Filter"] = array2;
                for (num2 = 0; (num2 < encoding.Length); num2 += 1)
                {
                    array2[num2] = PDF.N(encoding[num2]);
                }
            }
            stream1.Encode(profile);
            array1[1] = doc.Indirects.New(stream1);
            ColorSpaceICCBased based1 = (Resources.Get(array1, typeof(ColorSpaceICCBased)) as ColorSpaceICCBased);
            if (indirect)
            {
                doc.Indirects.New(array1);
            }
            return based1;
        }


        // Properties
        public ColorSpace Alternate
        {
            get
            {
                return (Resources.Get(this.Dict["Alternate"], typeof(ColorSpace)) as ColorSpace);
            }
            set
            {
                if (value != null)
                {
                    value = (((base.Direct.Doc == null) ? value : base.Direct.Doc.Resources.Add(value)) as ColorSpace);
                }
                if (value != null)
                {
                    this.Dict["Alternate"] = value.Direct;
                    return;
                }
                this.Dict.Remove("Alternate");
            }
        }

        public override PDFDict Dict
        {
            get
            {
                return ((PDFStream) ((PDFArray) this.mDirect)[1]).Dict;
            }
        }

        public PDFStream Metadata
        {
            get
            {
                return ((PDFStream) this.Dict["Metadata"]);
            }
            set
            {
                this.Dict["Metadata"] = value;
            }
        }

        public override int NrOfChannels
        {
            get
            {
                PDFInteger integer1 = (this.Dict["N"] as PDFInteger);
                if (integer1 == null)
                {
                    if (this.Alternate != null)
                    {
                        return this.Alternate.NrOfChannels;
                    }
                    return -1;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.Dict["N"] = PDF.O(value);
            }
        }

        public PDFStream Profile
        {
            get
            {
                return ((PDFStream) ((PDFArray) this.mDirect)[1]);
            }
            set
            {
                ((PDFArray) this.mDirect)[1] = value;
            }
        }

        public DoubleMinMaxArray Range
        {
            get
            {
                double[] numArray1;
                int num1;
                if (this.mRange == null)
                {
                    numArray1 = new double[(this.NrOfChannels * 2)];
                    for (num1 = 0; (num1 < this.NrOfChannels); num1 += 1)
                    {
                        numArray1[num1] = ((double) (num1 % 2));
                    }
                    this.mRange = new DoubleMinMaxArray(new PDFDoubleArray(this.Dict, "Range", false, numArray1));
                }
                return this.mRange;
            }
            set
            {
                if (this.Range.Count == value.Count)
                {
                    this.Range.Set(value);
                }
            }
        }

        public override string SubType
        {
            get
            {
                return "ICCBased";
            }
        }


        // Fields
        private DoubleMinMaxArray mRange;
    }
}


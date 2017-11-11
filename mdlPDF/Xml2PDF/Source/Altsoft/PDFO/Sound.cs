namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public class Sound : Resource
    {
        // Methods
        public Sound(PDFDirect direct) : base(direct)
        {
        }

        public static Sound Create(string filename, int sampling_rate)
        {
            PDFStream stream1 = Library.CreateStream(new FileStream(filename, FileMode.Open));
            stream1.Dict["R"] = Library.CreateFixed(((double) sampling_rate));
            return new Sound(stream1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new Sound(direct);
        }


        // Properties
        public int BitsPerSample
        {
            get
            {
                PDFInteger integer1 = (this.Dict["B"] as PDFInteger);
                if (integer1 != null)
                {
                    return integer1.Int32Value;
                }
                return 8;
            }
            set
            {
                this.Dict["BitsPerSample"] = Library.CreateInteger(((long) value));
            }
        }

        public string CompressionFormat
        {
            get
            {
                PDFName name1 = (this.Dict["CO"] as PDFName);
                if (name1 != null)
                {
                    return name1.Value;
                }
                return null;
            }
            set
            {
                this.Dict["CO"] = Library.CreateName(value);
            }
        }

        public EncodingFormat Encoding
        {
            get
            {
                PDFName name1 = (this.Dict["E"] as PDFName);
                if (name1 == null)
                {
                    goto Label_005B;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_005B;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "muLaw")
                {
                    if (text1 == "ALaw")
                    {
                        goto Label_0057;
                    }
                    if (text1 == "Signed")
                    {
                        goto Label_0059;
                    }
                    goto Label_005B;
                }
                return EncodingFormat.muLaw;
            Label_0057:
                return EncodingFormat.ALaw;
            Label_0059:
                return EncodingFormat.Signed;
            Label_005B:
                return EncodingFormat.Raw;
            }
            set
            {
                string text1 = "Raw";
                EncodingFormat format1 = value;
                switch (format1)
                {
                    case EncodingFormat.Signed:
                    {
                        goto Label_002E;
                    }
                    case EncodingFormat.muLaw:
                    {
                        text1 = "muLaw";
                        goto Label_0034;
                    }
                    case EncodingFormat.ALaw:
                    {
                        text1 = "ALaw";
                        goto Label_0034;
                    }
                }
                goto Label_0034;
            Label_002E:
                text1 = "Signed";
            Label_0034:
                this.Dict["E"] = Library.CreateName(text1);
            }
        }

        public int SamplingRate
        {
            get
            {
                return (this.Dict["R"] as PDFNumeric).Int32Value;
            }
            set
            {
                this.Dict["R"] = Library.CreateInteger(((long) value));
            }
        }

        public int SoundChannels
        {
            get
            {
                PDFInteger integer1 = (this.Dict["C"] as PDFInteger);
                if (integer1 != null)
                {
                    return integer1.Int32Value;
                }
                return 1;
            }
            set
            {
                this.Dict["C"] = Library.CreateInteger(((long) value));
            }
        }

        public string Type
        {
            get
            {
                return "Sound";
            }
        }

    }
}


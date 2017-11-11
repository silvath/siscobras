namespace Altsoft.PDFO
{
    using System;

    public class AppearanceCharacteristic : Resource
    {
        // Methods
        public AppearanceCharacteristic(PDFDirect direct) : base(direct)
        {
        }

        public static AppearanceCharacteristic Create()
        {
            PDFDict dict1 = Library.CreateDict();
            AppearanceCharacteristic characteristic1 = new AppearanceCharacteristic(dict1);
            double[] numArray1 = new double[3];
            numArray1[0] = 1f;
            characteristic1.BackGround = ColorSpaceIntensity.Create(numArray1);
            numArray1 = new double[3];
            numArray1[1] = 1f;
            characteristic1.BorderColor = ColorSpaceIntensity.Create(numArray1);
            characteristic1.NormalCaption = "normal caption";
            return characteristic1;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new AppearanceCharacteristic(direct);
        }


        // Properties
        public string AlternateCaption
        {
            get
            {
                PDFString text1 = (this.Dict["AC"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["AC"] = Library.CreateString(value);
            }
        }

        public XObjectForm AlternateIcon
        {
            get
            {
                PDFStream stream1 = (this.Dict["IX"] as PDFStream);
                if (stream1 == null)
                {
                    return null;
                }
                return (Resources.Get(stream1, typeof(XObjectForm)) as XObjectForm);
            }
            set
            {
                this.Dict["IX"] = value.Direct;
            }
        }

        public ColorSpaceIntensity BackGround
        {
            get
            {
                return (Resources.Get(this.Dict["BG"], typeof(ColorSpaceIntensity)) as ColorSpaceIntensity);
            }
            set
            {
                this.Dict["BG"] = value.Direct;
            }
        }

        public ColorSpaceIntensity BorderColor
        {
            get
            {
                return (Resources.Get(this.Dict["BC"], typeof(ColorSpaceIntensity)) as ColorSpaceIntensity);
            }
            set
            {
                this.Dict["BC"] = value.Direct;
            }
        }

        public IconFit IconFit
        {
            get
            {
                PDFDict dict1 = (this.Dict["IF"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(IconFit)) as IconFit);
            }
            set
            {
                this.Dict["IF"] = value.Direct;
            }
        }

        public string NormalCaption
        {
            get
            {
                PDFString text1 = (this.Dict["CA"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["CA"] = Library.CreateString(value);
            }
        }

        public XObjectForm NormalIcon
        {
            get
            {
                PDFStream stream1 = (this.Dict["I"] as PDFStream);
                if (stream1 == null)
                {
                    return null;
                }
                return (Resources.Get(stream1, typeof(XObjectForm)) as XObjectForm);
            }
            set
            {
                this.Dict["I"] = value.Direct;
            }
        }

        public string RolloverCaption
        {
            get
            {
                PDFString text1 = (this.Dict["RC"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["RC"] = Library.CreateString(value);
            }
        }

        public XObjectForm RolloverIcon
        {
            get
            {
                PDFStream stream1 = (this.Dict["RI"] as PDFStream);
                if (stream1 == null)
                {
                    return null;
                }
                return (Resources.Get(stream1, typeof(XObjectForm)) as XObjectForm);
            }
            set
            {
                this.Dict["RI"] = value.Direct;
            }
        }

        public int Rotate
        {
            get
            {
                PDFInteger integer1 = (this.Dict["R"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return integer1.Int32Value;
            }
            set
            {
                if ((((value % 90) != 0) || (value < 0)) || (value > 270))
                {
                    throw new ArgumentException("Rotate should be either 0,90,180 or 270");
                }
                this.Dict["R"] = Library.CreateInteger(((long) value));
            }
        }

        public ETextPositions TextPosition
        {
            get
            {
                PDFInteger integer1 = (this.Dict["TP"] as PDFInteger);
                if (integer1 == null)
                {
                    return ETextPositions.CaptionOnly;
                }
                return ((ETextPositions) integer1.Int32Value);
            }
            set
            {
                this.Dict["TP"] = Library.CreateInteger(((long) value));
            }
        }

    }
}


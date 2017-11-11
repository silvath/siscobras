namespace Altsoft.PDFO
{
    using System;

    public class MS_MHBE : Resource
    {
        // Methods
        public MS_MHBE(PDFDirect direct) : base(direct)
        {
        }

        public static MS_MHBE Create()
        {
            return MS_MHBE.Create(true);
        }

        public static MS_MHBE Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MS_MHBE(dict1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new MS_MHBE(direct);
        }


        // Properties
        public double BIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["B"] as PDFArray);
                }
                if (this.RGB == null)
                {
                    return NaNf;
                }
                return (this.RGB[2] as PDFFixed).DoubleValue;
            }
            set
            {
                if (value == NaNf)
                {
                    this.RGB = null;
                    this.Dict.Remove("B");
                    return;
                }
                this.RGB[2] = Library.CreateFixed(value);
            }
        }

        public FloatingWindowParams FloatingWindowParams
        {
            get
            {
                PDFDict dict1 = (this.Dict["F"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(FloatingWindowParams)) as FloatingWindowParams);
            }
            set
            {
                this.Dict["F"] = value.Dict;
            }
        }

        public double GIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["B"] as PDFArray);
                }
                if (this.RGB == null)
                {
                    return NaNf;
                }
                return (this.RGB[1] as PDFFixed).DoubleValue;
            }
            set
            {
                if (value == NaNf)
                {
                    this.RGB = null;
                    this.Dict.Remove("B");
                    return;
                }
                this.RGB[1] = Library.CreateFixed(value);
            }
        }

        public EMonitorSpecifier Monitor
        {
            get
            {
                PDFInteger integer1 = (this.Dict["M"] as PDFInteger);
                if (integer1 == null)
                {
                    return EMonitorSpecifier.largest_section;
                }
                return ((EMonitorSpecifier) integer1.Int32Value);
            }
            set
            {
                this.Dict["M"] = Library.CreateInteger(((long) value));
            }
        }

        public double Opacity
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["O"] as PDFFixed);
                if (fixed1 == null)
                {
                    return 1f;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["O"] = Library.CreateFixed(value);
            }
        }

        public double RIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["B"] as PDFArray);
                }
                if (this.RGB == null)
                {
                    return NaNf;
                }
                return (this.RGB[0] as PDFFixed).DoubleValue;
            }
            set
            {
                if (value == NaNf)
                {
                    this.RGB = null;
                    this.Dict.Remove("B");
                    return;
                }
                this.RGB[0] = Library.CreateFixed(value);
            }
        }

        public EWindowType WindowType
        {
            get
            {
                PDFInteger integer1 = (this.Dict["W"] as PDFInteger);
                if (integer1 == null)
                {
                    return EWindowType.ScreenAnnot;
                }
                return ((EWindowType) integer1.Int32Value);
            }
            set
            {
                this.Dict["W"] = Library.CreateInteger(((long) value));
            }
        }


        // Fields
        private PDFArray RGB;
    }
}


namespace Altsoft.PDFO
{
    using System;

    public class ColorSpaceDeviceCMYK : ColorSpaceDevice
    {
        // Methods
        internal ColorSpaceDeviceCMYK(PDFDirect d) : base(d)
        {
        }

        public static ColorSpaceDeviceCMYK Create()
        {
            return ColorSpaceDeviceCMYK.Create(false);
        }

        public static ColorSpaceDeviceCMYK Create(bool indirect)
        {
            ColorSpaceDeviceCMYK ecmyk1 = (Resources.Get(PDF.N("DeviceCMYK"), typeof(ColorSpaceDeviceCMYK)) as ColorSpaceDeviceCMYK);
            if (indirect)
            {
                Library.CreateIndirect(ecmyk1.Direct);
            }
            return ecmyk1;
        }


        // Properties
        public override int NrOfChannels
        {
            get
            {
                return 4;
            }
        }

        public override string SubType
        {
            get
            {
                return "DeviceCMYK";
            }
        }

    }
}


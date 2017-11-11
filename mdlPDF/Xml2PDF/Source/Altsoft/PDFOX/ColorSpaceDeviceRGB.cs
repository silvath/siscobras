namespace Altsoft.PDFO
{
    using System;

    public class ColorSpaceDeviceRGB : ColorSpaceDevice
    {
        // Methods
        internal ColorSpaceDeviceRGB(PDFDirect d) : base(d)
        {
        }

        public static ColorSpaceDeviceRGB Create()
        {
            return ColorSpaceDeviceRGB.Create(false);
        }

        public static ColorSpaceDeviceRGB Create(bool indirect)
        {
            ColorSpaceDeviceRGB ergb1 = (Resources.Get(PDF.N("DeviceRGB"), typeof(ColorSpaceDeviceRGB)) as ColorSpaceDeviceRGB);
            if (indirect)
            {
                Library.CreateIndirect(ergb1.Direct);
            }
            return ergb1;
        }


        // Properties
        public override int NrOfChannels
        {
            get
            {
                return 3;
            }
        }

        public override string SubType
        {
            get
            {
                return "DeviceRGB";
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;

    public class ColorSpaceDeviceGray : ColorSpaceDevice
    {
        // Methods
        internal ColorSpaceDeviceGray(PDFDirect d) : base(d)
        {
        }

        public static ColorSpaceDeviceGray Create()
        {
            return ColorSpaceDeviceGray.Create(false);
        }

        public static ColorSpaceDeviceGray Create(bool indirect)
        {
            ColorSpaceDeviceGray gray1 = (Resources.Get(PDF.N("DeviceGray"), typeof(ColorSpaceDeviceGray)) as ColorSpaceDeviceGray);
            if (indirect)
            {
                Library.CreateIndirect(gray1.Direct);
            }
            return gray1;
        }


        // Properties
        public override int NrOfChannels
        {
            get
            {
                return 1;
            }
        }

        public override string SubType
        {
            get
            {
                return "DeviceGray";
            }
        }

    }
}


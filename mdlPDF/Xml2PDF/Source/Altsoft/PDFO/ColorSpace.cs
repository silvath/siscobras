namespace Altsoft.PDFO
{
    using System;
    using System.Collections;

    public abstract class ColorSpace : Resource
    {
        // Methods
        static ColorSpace()
        {
            ColorSpace.DictKeyName = "ColorSpace";
        }

        internal ColorSpace(PDFDirect d) : base(d)
        {
        }

        internal static Resource Factory(PDFDirect d)
        {
            PDFArray array1;
            if (<PrivateImplementationDetails>.$$method0x6000404-1 == null)
            {
                Hashtable hashtable1 = new Hashtable(24, 0.5f);
                hashtable1.Add("DeviceGray", 0);
                Hashtable hashtable2 = new Hashtable(24, 0.5f);
                hashtable2.Add("DeviceRGB", 1);
                Hashtable hashtable3 = new Hashtable(24, 0.5f);
                hashtable3.Add("DeviceCMYK", 2);
                Hashtable hashtable4 = new Hashtable(24, 0.5f);
                hashtable4.Add("CalGray", 3);
                Hashtable hashtable5 = new Hashtable(24, 0.5f);
                hashtable5.Add("CalRGB", 4);
                Hashtable hashtable6 = new Hashtable(24, 0.5f);
                hashtable6.Add("Lab", 5);
                Hashtable hashtable7 = new Hashtable(24, 0.5f);
                hashtable7.Add("Indexed", 6);
                Hashtable hashtable8 = new Hashtable(24, 0.5f);
                hashtable8.Add("Separation", 7);
                Hashtable hashtable9 = new Hashtable(24, 0.5f);
                hashtable9.Add("DeviceN", 8);
                Hashtable hashtable10 = new Hashtable(24, 0.5f);
                hashtable10.Add("Pattern", 9);
                Hashtable hashtable11 = new Hashtable(24, 0.5f);
                hashtable11.Add("ICCBased", 10);
                <PrivateImplementationDetails>.$$method0x6000404-1 = new Hashtable(24, 0.5f);
            }
            PDFDirect direct1 = d;
            if (d.PDFType == PDFObjectType.tPDFArray)
            {
                array1 = ((PDFArray) d);
                if (array1.Count >= 1)
                {
                    direct1 = array1[0].Direct;
                }
                else
                {
                    return null;
                }
            }
            if ((direct1 == null) || (direct1.PDFType != PDFObjectType.tPDFName))
            {
                return null;
            }
            object obj1 = ((PDFName) direct1).Value;
            if (obj1 == null)
            {
                goto Label_01C3;
            }
            obj1 = <PrivateImplementationDetails>.$$method0x6000404-1[obj1];
            if (obj1 == null)
            {
                goto Label_01C3;
            }
            switch (((int) obj1))
            {
                case 0:
                {
                    goto Label_0176;
                }
                case 1:
                {
                    goto Label_017D;
                }
                case 2:
                {
                    goto Label_0184;
                }
                case 3:
                {
                    goto Label_018B;
                }
                case 4:
                {
                    goto Label_0192;
                }
                case 5:
                {
                    goto Label_0199;
                }
                case 6:
                {
                    goto Label_01A0;
                }
                case 7:
                {
                    goto Label_01A7;
                }
                case 8:
                {
                    goto Label_01AE;
                }
                case 9:
                {
                    goto Label_01B5;
                }
                case 10:
                {
                    goto Label_01BC;
                }
            }
            goto Label_01C3;
        Label_0176:
            return new ColorSpaceDeviceGray(d);
        Label_017D:
            return new ColorSpaceDeviceRGB(d);
        Label_0184:
            return new ColorSpaceDeviceCMYK(d);
        Label_018B:
            return new ColorSpaceCalGray(d);
        Label_0192:
            return new ColorSpaceCalRGB(d);
        Label_0199:
            return new ColorSpaceLab(d);
        Label_01A0:
            return new ColorSpaceIndexed(d);
        Label_01A7:
            return new ColorSpaceSeparation(d);
        Label_01AE:
            return new ColorSpaceDeviceN(d);
        Label_01B5:
            return new ColorSpacePattern(d);
        Label_01BC:
            return new ColorSpaceICCBased(d);
        Label_01C3:
            return null;
        }


        // Properties
        public virtual int NrOfChannels
        {
            get
            {
                return -1;
            }
            set
            {
            }
        }

        public abstract string SubType { get; }


        // Fields
        internal static readonly string DictKeyName;
    }
}


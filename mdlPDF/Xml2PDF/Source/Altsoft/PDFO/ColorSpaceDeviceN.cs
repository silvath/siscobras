namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class ColorSpaceDeviceN : ColorSpaceSpecial
    {
        // Methods
        internal ColorSpaceDeviceN(PDFDirect d) : base(d)
        {
            this.mSeparationNames = null;
            this.Colorants = new ColorSpaceDeviceNColorantsCollection(((PDFArray) d));
        }

        public static ColorSpaceDeviceN Create(bool indirect, params string[] sepNames)
        {
            PDFArray array1 = Library.CreateArray(4);
            array1[0] = PDF.N("DeviceN");
            array1[1] = Library.CreateObject(true, sepNames);
            ColorSpaceDeviceN en1 = (Resources.Get(array1, typeof(ColorSpaceDeviceN)) as ColorSpaceDeviceN);
            if (indirect)
            {
                Library.CreateIndirect(array1);
            }
            return en1;
        }


        // Properties
        protected override int mBaseCSIndex
        {
            get
            {
                return 2;
            }
        }

        public override int NrOfChannels
        {
            get
            {
                return ((PDFArray) ((PDFArray) base.Direct)[1]).Count;
            }
        }

        public StringArray SeparationNames
        {
            get
            {
                PDFArray array1;
                if (this.mSeparationNames == null)
                {
                    array1 = (((PDFArray) this.mDirect)[1] as PDFArray);
                    if (array1 != null)
                    {
                        this.mSeparationNames = new PDFNameArray(array1, array1.Count);
                    }
                }
                return this.mSeparationNames;
            }
            set
            {
                PDFArray array1;
                int num1;
                if (this.SeparationNames == null)
                {
                    array1 = Library.CreateArray(value.Count);
                    ((PDFArray) this.mDirect)[1] = array1;
                    for (num1 = 0; (num1 < value.Count); num1 += 1)
                    {
                        array1[num1] = Library.CreateName(value[num1]);
                    }
                    return;
                }
                this.SeparationNames.Set(value);
            }
        }

        public override string SubType
        {
            get
            {
                return "DeviceN";
            }
        }

        public Function TintTransform
        {
            get
            {
                return (Resources.Get(((PDFArray) this.mDirect)[3].Direct, typeof(Function)) as Function);
            }
            set
            {
                if (value != null)
                {
                    value = (((base.Direct.Doc == null) ? value : base.Direct.Doc.Resources.Add(value)) as Function);
                }
                if (value != null)
                {
                    ((PDFArray) this.mDirect)[3] = value.Direct;
                    return;
                }
                ((PDFArray) this.mDirect)[3] = Library.CreateNull();
            }
        }


        // Fields
        public readonly ColorSpaceDeviceNColorantsCollection Colorants;
        private PDFNameArray mSeparationNames;
    }
}


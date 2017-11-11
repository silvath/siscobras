namespace Altsoft.PDFO
{
    using System;

    public class ColorSpaceSeparation : ColorSpaceSpecial
    {
        // Methods
        internal ColorSpaceSeparation(PDFDirect d) : base(d)
        {
        }

        public static ColorSpaceSeparation Create(bool indirect, string name)
        {
            PDFArray array1 = Library.CreateArray(4);
            array1[0] = PDF.N("Separation");
            array1[1] = PDF.N(name);
            ColorSpaceSeparation separation1 = (Resources.Get(array1, typeof(ColorSpaceSeparation)) as ColorSpaceSeparation);
            if (indirect)
            {
                Library.CreateIndirect(array1);
            }
            return separation1;
        }

        public static ColorSpaceSeparation Create(bool indirect, string name, ColorSpace baseCS, Function tintTransform)
        {
            ColorSpaceSeparation separation1 = ColorSpaceSeparation.Create(indirect, name);
            separation1.Base = baseCS;
            separation1.TintTransform = tintTransform;
            return separation1;
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
                return 1;
            }
        }

        public string SeparationName
        {
            get
            {
                PDFName name1 = (((PDFArray) this.mDirect)[1] as PDFName);
                if (name1 == null)
                {
                    return "";
                }
                return name1.Value;
            }
            set
            {
                ((PDFArray) this.mDirect)[1] = Library.CreateName(value);
            }
        }

        public override string SubType
        {
            get
            {
                return "Separation";
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

    }
}


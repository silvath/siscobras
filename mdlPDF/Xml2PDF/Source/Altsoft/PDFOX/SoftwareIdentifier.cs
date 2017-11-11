namespace Altsoft.PDFO
{
    using System;

    public class SoftwareIdentifier : Resource
    {
        // Methods
        public SoftwareIdentifier(PDFDirect direct) : base(direct)
        {
        }

        public static SoftwareIdentifier Create(string URI)
        {
            return SoftwareIdentifier.Create(true, URI);
        }

        public static SoftwareIdentifier Create(bool indirect, string URI)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["U"] = Library.CreateName(URI);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new SoftwareIdentifier(dict1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new SoftwareIdentifier(direct);
        }


        // Properties
        public double[] HigherVersion
        {
            get
            {
                PDFArray array1 = (this.Dict["H"] as PDFArray);
                if (array1 == null)
                {
                    return new double[0];
                }
                double[] numArray1 = new double[array1.Count];
                array1.CopyTo(numArray1, 0);
                return numArray1;
            }
            set
            {
                this.Dict["H"] = Library.CreateArray(false, value);
            }
        }

        public double[] LowerVersion
        {
            get
            {
                PDFArray array1 = (this.Dict["L"] as PDFArray);
                if (array1 == null)
                {
                    return new double[1];
                }
                double[] numArray1 = new double[array1.Count];
                array1.CopyTo(numArray1, 0);
                return numArray1;
            }
            set
            {
                this.Dict["L"] = Library.CreateArray(false, value);
            }
        }

        public string URI
        {
            get
            {
                return (this.Dict["U"] as PDFString).Value;
            }
            set
            {
                this.Dict["U"] = Library.CreateString(value);
            }
        }

        public bool VersionGreater
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["LI"] as PDFBoolean);
                if (flag1 == null)
                {
                    return true;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["LI"] = Library.CreateBoolean(value);
            }
        }

        public bool VersionInterval
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["HI"] as PDFBoolean);
                if (flag1 == null)
                {
                    return true;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["HI"] = Library.CreateBoolean(value);
            }
        }

        public StringArrayResource WidgetStateArray
        {
            get
            {
                PDFArray array1 = (this.Dict["OS"] as PDFArray);
                if (array1 == null)
                {
                    return new StringArrayResource(Library.CreateArray());
                }
                return (Resources.Get(array1, typeof(StringArrayResource)) as StringArrayResource);
            }
            set
            {
                this.Dict["Opt"] = value.Direct;
            }
        }


        // Fields
        public const string Type = "SoftwareIdentifier";
    }
}


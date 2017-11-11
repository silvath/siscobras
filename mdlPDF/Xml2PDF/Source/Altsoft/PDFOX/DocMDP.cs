namespace Altsoft.PDFO
{
    using System;

    public class DocMDP : Resource
    {
        // Methods
        public DocMDP(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new DocMDP(direct);
        }


        // Properties
        public EAccessPermissions Permission
        {
            get
            {
                PDFInteger integer1 = (this.Dict["P"] as PDFInteger);
                if (integer1 == null)
                {
                    return EAccessPermissions.NoChanges;
                }
                return ((EAccessPermissions) integer1.Int32Value);
            }
            set
            {
                this.Dict["P"] = Library.CreateInteger(((long) value));
            }
        }

        public string Type
        {
            get
            {
                return "TransformParams";
            }
        }

        public double Version
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["V"] as PDFFixed);
                if (fixed1 == null)
                {
                    return 1f;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["V"] = Library.CreateFixed(value);
            }
        }

    }
}


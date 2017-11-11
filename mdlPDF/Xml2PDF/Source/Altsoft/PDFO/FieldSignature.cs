namespace Altsoft.PDFO
{
    using System;

    public class FieldSignature : FieldVariable
    {
        // Methods
        public FieldSignature(PDFDirect direct) : base(direct)
        {
        }


        // Properties
        public SignatureLock Lock
        {
            get
            {
                PDFDict dict1 = (this.Dict["Lock"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(SignatureLock)) as SignatureLock);
            }
            set
            {
                this.Dict["Lock"] = value.Dict;
            }
        }

        public SeedValue SeedValue
        {
            get
            {
                PDFDict dict1 = (this.Dict["SV"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(SeedValue)) as SeedValue);
            }
            set
            {
                this.Dict["SV"] = value.Dict;
            }
        }

        public Signature Signature
        {
            get
            {
                PDFDict dict1 = (this.Dict["V"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(Signature)) as Signature);
            }
            set
            {
                this.Dict["V"] = value.Dict;
            }
        }

    }
}


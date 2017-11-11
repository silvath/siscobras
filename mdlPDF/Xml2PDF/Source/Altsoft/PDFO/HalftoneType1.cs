namespace Altsoft.PDFO
{
    using System;

    public class HalftoneType1 : Halftone
    {
        // Methods
        public HalftoneType1(PDFDirect direct) : base(direct)
        {
        }


        // Properties
        public bool AccurateScreens
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["AccurateScreens"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["AccurateScreens"] = Library.CreateBoolean(value);
            }
        }

        public double Frequency
        {
            get
            {
                return (this.Dict["Frequency"] as PDFFixed).DoubleValue;
            }
            set
            {
                this.Dict["Frequency"] = Library.CreateFixed(value);
            }
        }

        public string IsSpotFunctionName
        {
            get
            {
                PDFName name1 = (this.Dict["SpotFunction"] as PDFName);
                if (name1 == null)
                {
                    return null;
                }
                return name1.Value;
            }
            set
            {
                this.Dict["SpotFunction"] = Library.CreateName(value);
            }
        }

        public string IsTranferFunctionIdentity
        {
            get
            {
                PDFName name1 = (this.Dict["TransferFunction"] as PDFName);
                if (name1 == null)
                {
                    return null;
                }
                return name1.Value;
            }
            set
            {
                this.Dict["TransferFunction"] = Library.CreateName(value);
            }
        }

        public Function SpotFunction
        {
            get
            {
                return (Resources.Get(this.Dict["SpotFunction"], typeof(Function)) as Function);
            }
            set
            {
                this.Dict["SpotFunction"] = value.Dict;
            }
        }

        public Function TransferFunction
        {
            get
            {
                PDFDirect direct1 = (this.Dict["TransferFunction"] as PDFDirect);
                if (direct1 == null)
                {
                    return null;
                }
                return (Resources.Get(direct1, typeof(Function)) as Function);
            }
            set
            {
                this.Dict["TransferFunction"] = value.Dict;
            }
        }

    }
}


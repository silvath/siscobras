namespace Altsoft.PDFO
{
    using System;

    public class FormField : Resource
    {
        // Methods
        public FormField(PDFDirect direct) : base(direct)
        {
        }

        internal static Resource Factory(PDFDirect direct)
        {
            return new FormField(direct);
        }


        // Properties
        public Action C
        {
            get
            {
                PDFDict dict1;
                if (this.mC == null)
                {
                    dict1 = (this.Dict["C"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mC = new Action(dict1);
                    }
                }
                return this.mC;
            }
            set
            {
                if (value.SubType != ActionType.JavaScript)
                {
                    throw new Exception("Illegal Action type");
                }
                this.mC = value;
                this.Dict["C"] = this.mC.Dict;
            }
        }

        public Action F
        {
            get
            {
                PDFDict dict1;
                if (this.mF == null)
                {
                    dict1 = (this.Dict["F"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mF = new Action(dict1);
                    }
                }
                return this.mF;
            }
            set
            {
                if (value.SubType != ActionType.JavaScript)
                {
                    throw new Exception("Illegal Action type");
                }
                this.mF = value;
                this.Dict["F"] = this.mF.Dict;
            }
        }

        public Action K
        {
            get
            {
                PDFDict dict1;
                if (this.mK == null)
                {
                    dict1 = (this.Dict["K"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mK = new Action(dict1);
                    }
                }
                return this.mK;
            }
            set
            {
                if (value.SubType != ActionType.JavaScript)
                {
                    throw new Exception("Illegal Action type");
                }
                this.mK = value;
                this.Dict["K"] = this.mK.Dict;
            }
        }

        public Action V
        {
            get
            {
                PDFDict dict1;
                if (this.mV == null)
                {
                    dict1 = (this.Dict["V"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mV = new Action(dict1);
                    }
                }
                return this.mV;
            }
            set
            {
                if (value.SubType != ActionType.JavaScript)
                {
                    throw new Exception("Illegal Action type");
                }
                this.mV = value;
                this.Dict["V"] = this.mV.Dict;
            }
        }


        // Fields
        private Action mC;
        private Action mF;
        private Action mK;
        private Action mV;
    }
}


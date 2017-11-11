namespace Altsoft.PDFO
{
    using System;

    public class DocumentCatalog : Resource
    {
        // Methods
        public DocumentCatalog(PDFDirect direct) : base(direct)
        {
        }

        internal static Resource Factory(PDFDirect direct)
        {
            return new DocumentCatalog(direct);
        }


        // Properties
        public Action DC
        {
            get
            {
                PDFDict dict1;
                if (this.mDC == null)
                {
                    dict1 = (this.Dict["DC"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mDC = new Action(dict1);
                    }
                }
                return this.mDC;
            }
            set
            {
                if (value.SubType != ActionType.JavaScript)
                {
                    throw new Exception("Illegal Action type");
                }
                this.mDC = value;
                this.Dict["DC"] = this.mDC.Dict;
            }
        }

        public Action DP
        {
            get
            {
                PDFDict dict1;
                if (this.mDP == null)
                {
                    dict1 = (this.Dict["DP"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mDP = new Action(dict1);
                    }
                }
                return this.mDP;
            }
            set
            {
                if (value.SubType != ActionType.JavaScript)
                {
                    throw new Exception("Illegal Action type");
                }
                this.mDP = value;
                this.Dict["DP"] = this.mDP.Dict;
            }
        }

        public Action DS
        {
            get
            {
                PDFDict dict1;
                if (this.mDS == null)
                {
                    dict1 = (this.Dict["DS"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mDS = new Action(dict1);
                    }
                }
                return this.mDS;
            }
            set
            {
                if (value.SubType != ActionType.JavaScript)
                {
                    throw new Exception("Illegal Action type");
                }
                this.mDS = value;
                this.Dict["DS"] = this.mDS.Dict;
            }
        }

        public Action WP
        {
            get
            {
                PDFDict dict1;
                if (this.mWP == null)
                {
                    dict1 = (this.Dict["WP"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mWP = new Action(dict1);
                    }
                }
                return this.mWP;
            }
            set
            {
                if (value.SubType != ActionType.JavaScript)
                {
                    throw new Exception("Illegal Action type");
                }
                this.mWP = value;
                this.Dict["WP"] = this.mWP.Dict;
            }
        }

        public Action WS
        {
            get
            {
                PDFDict dict1;
                if (this.mWS == null)
                {
                    dict1 = (this.Dict["WS"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mWS = new Action(dict1);
                    }
                }
                return this.mWS;
            }
            set
            {
                if (value.SubType != ActionType.JavaScript)
                {
                    throw new Exception("Illegal Action type");
                }
                this.mWS = value;
                this.Dict["WS"] = this.mWS.Dict;
            }
        }


        // Fields
        private Action mDC;
        private Action mDP;
        private Action mDS;
        private Action mWP;
        private Action mWS;
    }
}


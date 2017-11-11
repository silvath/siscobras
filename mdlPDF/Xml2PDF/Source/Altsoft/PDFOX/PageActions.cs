namespace Altsoft.PDFO
{
    using System;

    public class PageActions : Resource
    {
        // Methods
        public PageActions(PDFDirect direct) : base(direct)
        {
        }

        internal static Resource Factory(PDFDirect direct)
        {
            return new PageActions(direct);
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
                this.mC = value;
                this.Dict["C"] = this.mC.Dict;
            }
        }

        public Action O
        {
            get
            {
                PDFDict dict1;
                if (this.mO == null)
                {
                    dict1 = (this.Dict["O"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mO = new Action(dict1);
                    }
                }
                return this.mO;
            }
            set
            {
                this.mO = value;
                this.Dict["O"] = this.mO.Dict;
            }
        }


        // Fields
        private Action mC;
        private Action mO;
    }
}


namespace Altsoft.PDFO
{
    using System;

    public class AnnotationAdditionalActions : Resource
    {
        // Methods
        public AnnotationAdditionalActions() : base(Library.CreateDict())
        {
        }

        public AnnotationAdditionalActions(PDFDirect direct) : base(direct)
        {
        }

        internal static Resource Factory(PDFDirect direct)
        {
            return new AnnotationAdditionalActions(direct);
        }


        // Properties
        public Annotation Annotation
        {
            set
            {
                value.AdditionalActions = this;
            }
        }

        public Action Enter
        {
            get
            {
                PDFDict dict1;
                if (this.mE == null)
                {
                    dict1 = (this.Dict["E"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mE = new Action(dict1);
                    }
                }
                return this.mE;
            }
            set
            {
                this.mE = value;
                this.Dict["E"] = this.mE.Dict;
            }
        }

        public Action Exists
        {
            get
            {
                PDFDict dict1;
                if (this.mX == null)
                {
                    dict1 = (this.Dict["X"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mX = new Action(dict1);
                    }
                }
                return this.mX;
            }
            set
            {
                this.mX = value;
                this.Dict["X"] = this.mX.Dict;
            }
        }

        public Action FocusLost
        {
            get
            {
                PDFDict dict1;
                if (this.mBl == null)
                {
                    dict1 = (this.Dict["Bl"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mBl = new Action(dict1);
                    }
                }
                return this.mBl;
            }
            set
            {
                this.mBl = value;
                this.Dict["Bl"] = this.mBl.Dict;
            }
        }

        public Action FocusReceive
        {
            get
            {
                PDFDict dict1;
                if (this.mFo == null)
                {
                    dict1 = (this.Dict["Fo"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mFo = new Action(dict1);
                    }
                }
                return this.mFo;
            }
            set
            {
                this.mFo = value;
                this.Dict["Fo"] = this.mFo.Dict;
            }
        }

        public Action MouseDown
        {
            get
            {
                PDFDict dict1;
                if (this.mD == null)
                {
                    dict1 = (this.Dict["D"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mD = new Action(dict1);
                    }
                }
                return this.mD;
            }
            set
            {
                this.mD = value;
                this.Dict["D"] = this.mD.Dict;
            }
        }

        public Action MouseUp
        {
            get
            {
                PDFDict dict1;
                if (this.mU == null)
                {
                    dict1 = (this.Dict["U"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mU = new Action(dict1);
                    }
                }
                return this.mU;
            }
            set
            {
                this.mU = value;
                this.Dict["U"] = this.mU.Dict;
            }
        }

        public Action PageClose
        {
            get
            {
                PDFDict dict1;
                if (this.mPC == null)
                {
                    dict1 = (this.Dict["PC"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mPC = new Action(dict1);
                    }
                }
                return this.mPC;
            }
            set
            {
                this.mPC = value;
                this.Dict["PC"] = this.mPC.Dict;
            }
        }

        public Action PageInvisible
        {
            get
            {
                PDFDict dict1;
                if (this.mPI == null)
                {
                    dict1 = (this.Dict["PI"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mPI = new Action(dict1);
                    }
                }
                return this.mPI;
            }
            set
            {
                this.mPI = value;
                this.Dict["PI"] = this.mPI.Dict;
            }
        }

        public Action PageOpen
        {
            get
            {
                PDFDict dict1;
                if (this.mPO == null)
                {
                    dict1 = (this.Dict["PO"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mPO = new Action(dict1);
                    }
                }
                return this.mPO;
            }
            set
            {
                this.mPO = value;
                this.Dict["PO"] = this.mPO.Dict;
            }
        }

        public Action PageVisible
        {
            get
            {
                PDFDict dict1;
                if (this.mPV == null)
                {
                    dict1 = (this.Dict["PV"] as PDFDict);
                    if (dict1 != null)
                    {
                        this.mPV = new Action(dict1);
                    }
                }
                return this.mPV;
            }
            set
            {
                this.mPV = value;
                this.Dict["PV"] = this.mPV.Dict;
            }
        }


        // Fields
        private Action mBl;
        private Action mD;
        private Action mE;
        private Action mFo;
        private Action mPC;
        private Action mPI;
        private Action mPO;
        private Action mPV;
        private Action mU;
        private Action mX;
    }
}


namespace Altsoft.PDFO
{
    using System;

    public class InteractiveForm : Resource
    {
        // Methods
        public InteractiveForm(PDFDirect direct) : base(direct)
        {
            this.mRootFields = null;
            this.mCOFields = null;
            this.mResources = null;
        }

        public static InteractiveForm Create()
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Fields"] = Library.CreateArray(0);
            Library.CreateIndirect(dict1);
            return new InteractiveForm(dict1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new InteractiveForm(direct);
        }


        // Properties
        public FieldKids COFields
        {
            get
            {
                if (this.mCOFields == null)
                {
                    this.mCOFields = new FieldKids(this.Dict, "CO");
                }
                return this.mCOFields;
            }
            set
            {
                this.mCOFields = value;
                this.Dict["CO"] = this.mCOFields.mBaseDict;
            }
        }

        public string DefaultAppearance
        {
            get
            {
                PDFString text1 = (this.Dict["DA"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["DA"] = Library.CreateString(value);
            }
        }

        public DocResourceSet FormResources
        {
            get
            {
                if (this.mResources != null)
                {
                    return this.mResources;
                }
                return this.mResources;
            }
            set
            {
                this.mResources = value;
            }
        }

        public bool NeedAppearances
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["NeedAppearances"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["NeedAppearances"] = Library.CreateBoolean(value);
            }
        }

        public ETextAlign Quadding
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Q"] as PDFInteger);
                if (integer1 == null)
                {
                    return ETextAlign.LeftJustified;
                }
                return ((ETextAlign) integer1.Int32Value);
            }
            set
            {
                this.Dict["Q"] = Library.CreateInteger(((long) value));
            }
        }

        public FieldKids RootFields
        {
            get
            {
                if (this.mRootFields == null)
                {
                    this.mRootFields = new FieldKids(this.Dict, "Fields");
                }
                return this.mRootFields;
            }
            set
            {
                this.mRootFields = value;
                this.Dict["Fields"] = this.mRootFields.mBaseDict;
            }
        }


        // Fields
        private FieldKids mCOFields;
        private DocResourceSet mResources;
        private FieldKids mRootFields;
    }
}


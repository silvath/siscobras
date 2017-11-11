namespace Altsoft.PDFO
{
    using System;

    public class ActionResetForm : Action
    {
        // Methods
        public ActionResetForm(PDFDirect direct) : base(direct)
        {
            this.mFields = null;
        }

        public static ActionResetForm Create(EResetFormFlags Flags)
        {
            ActionResetForm form1 = ActionResetForm.Create(true);
            form1.FieldFlags = Flags;
            return form1;
        }

        public static ActionResetForm Create(FieldVarCollection arr)
        {
            ActionResetForm form1 = ActionResetForm.Create(true);
            form1.Fields = arr;
            return form1;
        }

        private static ActionResetForm Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("ResetForm");
            ActionResetForm form1 = (Resources.Get(dict1, typeof(ActionResetForm)) as ActionResetForm);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return form1;
        }

        public static ActionResetForm Create(FieldVarCollection arr, EResetFormFlags Flags)
        {
            ActionResetForm form1 = ActionResetForm.Create(true);
            form1.Fields = arr;
            form1.FieldFlags = Flags;
            return form1;
        }

        public static ActionResetForm Create(bool indirect, EResetFormFlags Flags)
        {
            ActionResetForm form1 = ActionResetForm.Create(indirect);
            form1.FieldFlags = Flags;
            return form1;
        }

        public static ActionResetForm Create(bool indirect, FieldVarCollection arr)
        {
            ActionResetForm form1 = ActionResetForm.Create(indirect);
            form1.Fields = arr;
            return form1;
        }

        public static ActionResetForm Create(bool indirect, FieldVarCollection arr, EResetFormFlags Flags)
        {
            ActionResetForm form1 = ActionResetForm.Create(indirect);
            form1.Fields = arr;
            form1.FieldFlags = Flags;
            return form1;
        }


        // Properties
        public EResetFormFlags FieldFlags
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Flags"] as PDFInteger);
                if (integer1 == null)
                {
                    return EResetFormFlags.None;
                }
                return ((EResetFormFlags) integer1.Int32Value);
            }
            set
            {
                this.Dict["Flags"] = Library.CreateInteger(((long) value));
            }
        }

        public FieldVarCollection Fields
        {
            get
            {
                if (this.mFields != null)
                {
                    return this.mFields;
                }
                PDFArray array1 = (this.Dict["Fields"] as PDFArray);
                if (array1 != null)
                {
                    this.mFields = new FieldVarCollection(this.Dict, "Fields", false);
                }
                return this.mFields;
            }
            set
            {
                this.mFields = value;
                this.Dict["Fields"] = this.mFields.mBaseDict[this.mFields.mBaseKeyName];
            }
        }


        // Fields
        private FieldVarCollection mFields;
        public const string Type = "ResetForm";
    }
}


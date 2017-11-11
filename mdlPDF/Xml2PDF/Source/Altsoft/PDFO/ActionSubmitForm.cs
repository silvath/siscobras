namespace Altsoft.PDFO
{
    using System;

    public class ActionSubmitForm : Action
    {
        // Methods
        public ActionSubmitForm(PDFDirect direct) : base(direct)
        {
            this.mFields = null;
        }

        public static ActionSubmitForm Create(FileSpec fs)
        {
            ActionSubmitForm form1 = ActionSubmitForm.Create(true);
            form1.URLFileSpec = fs;
            return form1;
        }

        private static ActionSubmitForm Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("SubmitForm");
            ActionSubmitForm form1 = (Resources.Get(dict1, typeof(ActionSubmitForm)) as ActionSubmitForm);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return form1;
        }

        public static ActionSubmitForm Create(FileSpec fs, ESubmitFormFlags Flags)
        {
            ActionSubmitForm form1 = ActionSubmitForm.Create(true);
            form1.URLFileSpec = fs;
            form1.FieldFlags = Flags;
            return form1;
        }

        public static ActionSubmitForm Create(FileSpec fs, FieldVarCollection arr)
        {
            ActionSubmitForm form1 = ActionSubmitForm.Create(true);
            form1.URLFileSpec = fs;
            form1.Fields = arr;
            return form1;
        }

        public static ActionSubmitForm Create(bool indirect, FileSpec fs)
        {
            ActionSubmitForm form1 = ActionSubmitForm.Create(indirect);
            form1.URLFileSpec = fs;
            return form1;
        }

        public static ActionSubmitForm Create(FileSpec fs, FieldVarCollection arr, ESubmitFormFlags Flags)
        {
            ActionSubmitForm form1 = ActionSubmitForm.Create(true);
            form1.URLFileSpec = fs;
            form1.Fields = arr;
            form1.FieldFlags = Flags;
            return form1;
        }

        public static ActionSubmitForm Create(bool indirect, FileSpec fs, ESubmitFormFlags Flags)
        {
            ActionSubmitForm form1 = ActionSubmitForm.Create(indirect);
            form1.URLFileSpec = fs;
            form1.FieldFlags = Flags;
            return form1;
        }

        public static ActionSubmitForm Create(bool indirect, FileSpec fs, FieldVarCollection arr)
        {
            ActionSubmitForm form1 = ActionSubmitForm.Create(indirect);
            form1.URLFileSpec = fs;
            form1.Fields = arr;
            return form1;
        }

        public static ActionSubmitForm Create(bool indirect, FileSpec fs, FieldVarCollection arr, ESubmitFormFlags Flags)
        {
            ActionSubmitForm form1 = ActionSubmitForm.Create(indirect);
            form1.URLFileSpec = fs;
            form1.Fields = arr;
            form1.FieldFlags = Flags;
            return form1;
        }


        // Properties
        public ESubmitFormFlags FieldFlags
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Flags"] as PDFInteger);
                if (integer1 == null)
                {
                    return ESubmitFormFlags.None;
                }
                return ((ESubmitFormFlags) integer1.Int32Value);
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

        public FileSpec URLFileSpec
        {
            get
            {
                return (Resources.Get(this.Dict["F"], typeof(FileSpec)) as FileSpec);
            }
            set
            {
                this.Dict["F"] = Library.CreateString(value.Path);
            }
        }


        // Fields
        private FieldVarCollection mFields;
        public const string Type = "SubmitForm";
    }
}


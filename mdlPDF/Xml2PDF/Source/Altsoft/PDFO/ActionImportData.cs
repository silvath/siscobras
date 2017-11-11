namespace Altsoft.PDFO
{
    using System;

    public class ActionImportData : Action
    {
        // Methods
        public ActionImportData(PDFDirect direct) : base(direct)
        {
        }

        public static ActionImportData Create(FileSpec fs)
        {
            ActionImportData data1 = ActionImportData.Create(true);
            data1.FileSpecification = fs;
            return data1;
        }

        private static ActionImportData Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("ImportData");
            ActionImportData data1 = (Resources.Get(dict1, typeof(ActionImportData)) as ActionImportData);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return data1;
        }

        public static ActionImportData Create(bool indirect, FileSpec fs)
        {
            ActionImportData data1 = ActionImportData.Create(indirect);
            data1.FileSpecification = fs;
            return data1;
        }


        // Properties
        public FileSpec FileSpecification
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
        public const string Type = "ImportData";
    }
}


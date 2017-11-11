namespace Altsoft.PDFO
{
    using System;

    public class ActionFirstPage : Action
    {
        // Methods
        public ActionFirstPage(PDFDirect direct) : base(direct)
        {
        }

        public static ActionFirstPage Create()
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Named");
            dict1["N"] = Library.CreateName("FirstPage");
            ActionFirstPage page1 = (Resources.Get(dict1, typeof(ActionFirstPage)) as ActionFirstPage);
            Library.CreateIndirect(dict1);
            return page1;
        }

        public static ActionFirstPage Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Named");
            dict1["N"] = Library.CreateName("FirstPage");
            ActionFirstPage page1 = (Resources.Get(dict1, typeof(ActionFirstPage)) as ActionFirstPage);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return page1;
        }


        // Fields
        public const string NameAction = "FirstPage";
        public const string Type = "Named";
    }
}


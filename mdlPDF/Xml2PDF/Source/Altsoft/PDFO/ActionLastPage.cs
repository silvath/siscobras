namespace Altsoft.PDFO
{
    using System;

    public class ActionLastPage : Action
    {
        // Methods
        public ActionLastPage(PDFDirect direct) : base(direct)
        {
        }

        public static ActionLastPage Create()
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Named");
            dict1["N"] = Library.CreateName("LastPage");
            ActionLastPage page1 = (Resources.Get(dict1, typeof(ActionLastPage)) as ActionLastPage);
            Library.CreateIndirect(dict1);
            return page1;
        }

        public static ActionLastPage Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Named");
            dict1["N"] = Library.CreateName("LastPage");
            ActionLastPage page1 = (Resources.Get(dict1, typeof(ActionLastPage)) as ActionLastPage);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return page1;
        }


        // Fields
        public const string NameAction = "LastPage";
        public const string Type = "Named";
    }
}


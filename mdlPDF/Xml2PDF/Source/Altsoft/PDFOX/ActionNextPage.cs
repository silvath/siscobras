namespace Altsoft.PDFO
{
    using System;

    public class ActionNextPage : Action
    {
        // Methods
        public ActionNextPage(PDFDirect direct) : base(direct)
        {
        }

        public static ActionNextPage Create()
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Named");
            dict1["N"] = Library.CreateName("NextPage");
            ActionNextPage page1 = (Resources.Get(dict1, typeof(ActionNextPage)) as ActionNextPage);
            Library.CreateIndirect(dict1);
            return page1;
        }

        public static ActionNextPage Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Named");
            dict1["N"] = Library.CreateName("NextPage");
            ActionNextPage page1 = (Resources.Get(dict1, typeof(ActionNextPage)) as ActionNextPage);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return page1;
        }


        // Fields
        public const string NameAction = "NextPage";
        public const string Type = "Named";
    }
}


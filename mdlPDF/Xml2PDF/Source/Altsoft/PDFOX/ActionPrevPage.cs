namespace Altsoft.PDFO
{
    using System;

    public class ActionPrevPage : Action
    {
        // Methods
        public ActionPrevPage(PDFDirect direct) : base(direct)
        {
        }

        public static ActionPrevPage Create()
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Named");
            dict1["N"] = Library.CreateName("PrevPage");
            ActionPrevPage page1 = (Resources.Get(dict1, typeof(ActionPrevPage)) as ActionPrevPage);
            Library.CreateIndirect(dict1);
            return page1;
        }

        public static ActionPrevPage Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Named");
            dict1["N"] = Library.CreateName("PrevPage");
            ActionPrevPage page1 = (Resources.Get(dict1, typeof(ActionPrevPage)) as ActionPrevPage);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return page1;
        }


        // Fields
        public const string NameAction = "PrevPage";
        public const string Type = "Named";
    }
}


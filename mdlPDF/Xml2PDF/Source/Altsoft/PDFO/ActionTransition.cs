namespace Altsoft.PDFO
{
    using System;

    public class ActionTransition : Action
    {
        // Methods
        public ActionTransition(PDFDirect direct) : base(direct)
        {
        }

        public static ActionTransition Create(Transition trans)
        {
            ActionTransition transition1 = ActionTransition.Create(true);
            transition1.Trans = trans;
            return transition1;
        }

        private static ActionTransition Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Trans");
            ActionTransition transition1 = (Resources.Get(dict1, typeof(ActionTransition)) as ActionTransition);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return transition1;
        }

        public static ActionTransition Create(bool indirect, Transition trans)
        {
            ActionTransition transition1 = ActionTransition.Create(indirect);
            transition1.Trans = trans;
            return transition1;
        }


        // Properties
        public Transition Trans
        {
            get
            {
                return (Resources.Get((this.Dict["Trans"] as PDFDict), typeof(Transition)) as Transition);
            }
            set
            {
                this.Dict["Trans"] = value.Dict;
            }
        }


        // Fields
        public const string Type = "Trans";
    }
}


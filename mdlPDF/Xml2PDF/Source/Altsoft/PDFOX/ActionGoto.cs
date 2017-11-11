namespace Altsoft.PDFO
{
    using System;

    public class ActionGoto : Action
    {
        // Methods
        public ActionGoto(PDFDirect direct) : base(direct)
        {
        }

        public static ActionGoto Create(LinkDestination dest)
        {
            ActionGoto goto1 = ActionGoto.Create(true);
            goto1.JumpDestination = dest;
            return goto1;
        }

        private static ActionGoto Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("GoTo");
            ActionGoto goto1 = (Resources.Get(dict1, typeof(ActionGoto)) as ActionGoto);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return goto1;
        }

        public static ActionGoto Create(bool indirect, LinkDestination dest)
        {
            ActionGoto goto1 = ActionGoto.Create(indirect);
            goto1.JumpDestination = dest;
            return goto1;
        }


        // Properties
        public LinkDestination JumpDestination
        {
            get
            {
                PDFDirect direct1 = (this.Dict["D"] as PDFDirect);
                return (Resources.Get(direct1, typeof(LinkDestination)) as LinkDestination);
            }
            set
            {
                this.Dict["D"] = value.Direct;
            }
        }


        // Fields
        public const string Type = "GoTo";
    }
}


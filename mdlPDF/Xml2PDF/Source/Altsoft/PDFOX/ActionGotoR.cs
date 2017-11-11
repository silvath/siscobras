namespace Altsoft.PDFO
{
    using System;

    public class ActionGotoR : Action
    {
        // Methods
        public ActionGotoR(PDFDirect direct) : base(direct)
        {
        }

        private static ActionGotoR Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("GoToR");
            ActionGotoR or1 = (Resources.Get(dict1, typeof(ActionGotoR)) as ActionGotoR);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return or1;
        }

        public static ActionGotoR Create(string file, LinkDestination dest)
        {
            ActionGotoR or1 = ActionGotoR.Create(true);
            or1.FileSpecification = new FileSpec(Library.CreateString(file));
            or1.JumpDestination = dest;
            return or1;
        }

        public static ActionGotoR Create(bool indirect, string file, LinkDestination dest)
        {
            ActionGotoR or1 = ActionGotoR.Create(indirect);
            or1.FileSpecification = new FileSpec(Library.CreateString(file));
            or1.JumpDestination = dest;
            return or1;
        }

        public static ActionGotoR Create(string file, LinkDestination dest, bool newWindow)
        {
            ActionGotoR or1 = ActionGotoR.Create(true);
            or1.FileSpecification = new FileSpec(Library.CreateString(file));
            or1.JumpDestination = dest;
            or1.NewWindow = newWindow;
            return or1;
        }

        public static ActionGotoR Create(bool indirect, string file, LinkDestination dest, bool newWindow)
        {
            ActionGotoR or1 = ActionGotoR.Create(indirect);
            or1.FileSpecification = new FileSpec(Library.CreateString(file));
            or1.JumpDestination = dest;
            or1.NewWindow = newWindow;
            return or1;
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

        public bool NewWindow
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["NewWindow"] as PDFBoolean);
                if (flag1 == null)
                {
                    return true;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["NewWindow"] = Library.CreateBoolean(value);
            }
        }


        // Fields
        public const string Type = "GoToR";
    }
}


namespace Altsoft.PDFO
{
    using System;

    public class ActionLaunch : Action
    {
        // Methods
        public ActionLaunch(PDFDirect direct) : base(direct)
        {
            this.mWinLaunch = null;
        }

        private static ActionLaunch Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Launch");
            ActionLaunch launch1 = (Resources.Get(dict1, typeof(ActionLaunch)) as ActionLaunch);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return launch1;
        }

        public static ActionLaunch Create(string file)
        {
            ActionLaunch launch1 = ActionLaunch.Create(true);
            launch1.FileSpecification = new FileSpec(Library.CreateString(file));
            return launch1;
        }

        public static ActionLaunch Create(bool indirect, FileSpec file)
        {
            ActionLaunch launch1 = ActionLaunch.Create(indirect);
            launch1.FileSpecification = file;
            return launch1;
        }

        public static ActionLaunch Create(string file, WindowsLaunch parms)
        {
            ActionLaunch launch1 = ActionLaunch.Create(true);
            launch1.FileSpecification = new FileSpec(Library.CreateString(file));
            launch1.WinLaunch = parms;
            return launch1;
        }

        public static ActionLaunch Create(bool indirect, string file, WindowsLaunch parms)
        {
            ActionLaunch launch1 = ActionLaunch.Create(indirect);
            launch1.FileSpecification = new FileSpec(Library.CreateString(file));
            launch1.WinLaunch = parms;
            return launch1;
        }

        public static ActionLaunch Create(string file, WindowsLaunch parms, bool newWindow)
        {
            ActionLaunch launch1 = ActionLaunch.Create(true);
            launch1.FileSpecification = new FileSpec(Library.CreateString(file));
            launch1.WinLaunch = parms;
            launch1.NewWindow = newWindow;
            return launch1;
        }

        public static ActionLaunch Create(bool indirect, string file, WindowsLaunch parms, bool newWindow)
        {
            ActionLaunch launch1 = ActionLaunch.Create(indirect);
            launch1.FileSpecification = new FileSpec(Library.CreateString(file));
            launch1.WinLaunch = parms;
            launch1.NewWindow = newWindow;
            return launch1;
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

        public WindowsLaunch WinLaunch
        {
            get
            {
                if (this.mWinLaunch != null)
                {
                    return this.mWinLaunch;
                }
                PDFDict dict1 = (this.Dict["Win"] as PDFDict);
                if (dict1 != null)
                {
                    this.mWinLaunch = new WindowsLaunch(dict1);
                }
                return this.mWinLaunch;
            }
            set
            {
                this.mWinLaunch = value;
                this.Dict["Win"] = value.Dict;
            }
        }


        // Fields
        private WindowsLaunch mWinLaunch;
        public const string Type = "Launch";
    }
}


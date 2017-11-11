namespace Altsoft.PDFO
{
    using System;

    public class WindowsLaunch
    {
        // Methods
        public WindowsLaunch(PDFDict dict)
        {
            this.mDict = dict;
        }


        // Properties
        public string DefaultDirectory
        {
            get
            {
                PDFString text1 = (this.mDict["D"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.mDict["D"] = Library.CreateString(value);
            }
        }

        public PDFDict Dict
        {
            get
            {
                return this.mDict;
            }
        }

        public string filename
        {
            get
            {
                PDFString text1 = (this.mDict["F"] as PDFString);
                return text1.Value;
            }
            set
            {
                this.mDict["F"] = Library.CreateString(value);
            }
        }

        public LaunchOperations operation
        {
            get
            {
                PDFString text1 = (this.mDict["O"] as PDFString);
                if (text1 == null)
                {
                    return LaunchOperations.open;
                }
                if (text1.Value == "Open")
                {
                    return LaunchOperations.open;
                }
                return LaunchOperations.print;
            }
            set
            {
                string text1 = "Open";
                if (value == LaunchOperations.print)
                {
                    text1 = "Print";
                }
                this.mDict["O"] = Library.CreateString(text1);
            }
        }

        public string parameter
        {
            get
            {
                PDFString text1 = (this.mDict["P"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.mDict["P"] = Library.CreateString(value);
            }
        }


        // Fields
        private PDFDict mDict;
    }
}


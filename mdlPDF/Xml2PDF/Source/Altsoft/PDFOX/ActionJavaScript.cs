namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public class ActionJavaScript : Action
    {
        // Methods
        public ActionJavaScript(PDFDirect direct) : base(direct)
        {
        }

        private static ActionJavaScript Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("JavaScript");
            ActionJavaScript script1 = (Resources.Get(dict1, typeof(ActionJavaScript)) as ActionJavaScript);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return script1;
        }

        public static ActionJavaScript Create(string JS)
        {
            ActionJavaScript script1 = ActionJavaScript.Create(true);
            script1.JavaScriptScript = JS;
            return script1;
        }

        public static ActionJavaScript Create(bool indirect, string JS)
        {
            ActionJavaScript script1 = ActionJavaScript.Create(indirect);
            script1.JavaScriptScript = JS;
            return script1;
        }


        // Properties
        public string JavaScriptScript
        {
            get
            {
                string text2;
                PDFObject obj1 = this.Dict["JS"];
                if (obj1 == null)
                {
                    return null;
                }
                if ((obj1 is PDFString))
                {
                    return (obj1 as PDFString).Value;
                }
                Stream stream1 = (obj1 as PDFStream).Decode();
                byte[] numArray1 = new byte[65536];
                char[] chArray1 = new char[65536];
                string text1 = null;
                while ((stream1.Read(numArray1, 0, 65536) != 0))
                {
                    numArray1.CopyTo(chArray1, 0);
                    text2 = new string(chArray1);
                    text1 = text1 + text2;
                }
                return text1;
            }
            set
            {
                this.Dict["JS"] = Library.CreateString(value);
            }
        }


        // Fields
        public const string Type = "JavaScript";
    }
}


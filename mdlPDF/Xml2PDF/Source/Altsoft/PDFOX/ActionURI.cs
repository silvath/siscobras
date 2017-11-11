namespace Altsoft.PDFO
{
    using System;

    public class ActionURI : Action
    {
        // Methods
        public ActionURI(PDFDirect direct) : base(direct)
        {
        }

        private static ActionURI Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("URI");
            ActionURI nuri1 = (Resources.Get(dict1, typeof(ActionURI)) as ActionURI);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return nuri1;
        }

        public static ActionURI Create(string uri)
        {
            ActionURI nuri1 = ActionURI.Create(true);
            nuri1.URI = uri;
            return nuri1;
        }

        public static ActionURI Create(bool indirect, string uri)
        {
            ActionURI nuri1 = ActionURI.Create(indirect);
            nuri1.URI = uri;
            return nuri1;
        }

        public static ActionURI Create(string uri, bool isMap)
        {
            ActionURI nuri1 = ActionURI.Create(true);
            nuri1.URI = uri;
            nuri1.IsMap = isMap;
            return nuri1;
        }

        public static ActionURI Create(bool indirect, string uri, bool isMap)
        {
            ActionURI nuri1 = ActionURI.Create(indirect);
            nuri1.URI = uri;
            nuri1.IsMap = isMap;
            return nuri1;
        }


        // Properties
        public bool IsMap
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["IsMap"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                if (!flag1.Value)
                {
                    return false;
                }
                return true;
            }
            set
            {
                this.Dict["IsMap"] = Library.CreateBoolean(value);
            }
        }

        public string URI
        {
            get
            {
                return (this.Dict["URI"] as PDFString).Value;
            }
            set
            {
                this.Dict["URI"] = Library.CreateString(value);
            }
        }


        // Fields
        public const string Type = "URI";
    }
}


namespace Altsoft.PDFO
{
    using System;

    public class ViewInfo : Resource
    {
        // Methods
        public ViewInfo(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new ViewInfo(direct);
        }


        // Properties
        public ETripleSwitch ViewState
        {
            get
            {
                PDFName name1 = (this.Dict["ViewState"] as PDFName);
                if (name1 == null)
                {
                    return ETripleSwitch.Unknown;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_004E;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "On")
                {
                    if (text1 == "Off")
                    {
                        goto Label_004C;
                    }
                    goto Label_004E;
                }
                return ETripleSwitch.On;
            Label_004C:
                return ETripleSwitch.Off;
            Label_004E:
                throw new Exception("Illegal prefferec state");
            }
            set
            {
                string text1 = "Off";
                ETripleSwitch switch1 = value;
                switch (switch1)
                {
                    case ETripleSwitch.On:
                    {
                        text1 = "On";
                        goto Label_0026;
                    }
                    case ETripleSwitch.Off:
                    {
                        goto Label_0020;
                    }
                }
                goto Label_0026;
            Label_0020:
                text1 = "Off";
            Label_0026:
                this.Dict["ViewState"] = Library.CreateName(text1);
            }
        }

    }
}


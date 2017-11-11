namespace Altsoft.PDFO
{
    using System;

    public class Export : Resource
    {
        // Methods
        public Export(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new Export(direct);
        }


        // Properties
        public EDoubleSwitch Preffered
        {
            get
            {
                PDFName name1 = (this.Dict["ExportState"] as PDFName);
                if (name1 == null)
                {
                    return EDoubleSwitch.Off;
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
                return EDoubleSwitch.On;
            Label_004C:
                return EDoubleSwitch.Off;
            Label_004E:
                throw new Exception("Unknown switch position");
            }
            set
            {
                string text1 = "Off";
                EDoubleSwitch switch1 = value;
                switch (switch1)
                {
                    case EDoubleSwitch.On:
                    {
                        text1 = "On";
                        goto Label_0026;
                    }
                    case EDoubleSwitch.Off:
                    {
                        goto Label_0020;
                    }
                }
                goto Label_0026;
            Label_0020:
                text1 = "Off";
            Label_0026:
                this.Dict["ExportState"] = Library.CreateName(text1);
            }
        }

    }
}


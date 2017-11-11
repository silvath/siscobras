namespace Altsoft.PDFO
{
    using System;

    public class LanguageSpecification : Resource
    {
        // Methods
        public LanguageSpecification(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new LanguageSpecification(direct);
        }


        // Properties
        public string Language
        {
            get
            {
                return (this.Dict["Lang"] as PDFString).Value;
            }
            set
            {
                this.Dict["Lang"] = Library.CreateString(value);
            }
        }

        public EDoubleSwitch Preffered
        {
            get
            {
                PDFName name1 = (this.Dict["Preffered"] as PDFName);
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
                throw new Exception("Illegal prefferec state");
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
                this.Dict["Preffered"] = Library.CreateName(text1);
            }
        }

    }
}


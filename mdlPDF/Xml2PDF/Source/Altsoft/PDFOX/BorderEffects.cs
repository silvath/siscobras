namespace Altsoft.PDFO
{
    using System;

    public class BorderEffects
    {
        // Methods
        public BorderEffects(PDFDict dict)
        {
            this.mDict = dict;
        }


        // Properties
        public EBorderEffect BorderEffect
        {
            get
            {
                PDFName name1 = (this.mDict["S"] as PDFName);
                if (name1 == null)
                {
                    return EBorderEffect.NoEffect;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_004E;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "S")
                {
                    if (text1 == "C")
                    {
                        goto Label_004C;
                    }
                    goto Label_004E;
                }
                return EBorderEffect.NoEffect;
            Label_004C:
                return EBorderEffect.cloudly;
            Label_004E:
                throw new Exception("Unknown border effect");
            }
            set
            {
                string text1 = "S";
                EBorderEffect effect1 = value;
                switch (effect1)
                {
                    case EBorderEffect.NoEffect:
                    {
                        text1 = "S";
                        goto Label_0026;
                    }
                    case EBorderEffect.cloudly:
                    {
                        goto Label_0020;
                    }
                }
                goto Label_0026;
            Label_0020:
                text1 = "C";
            Label_0026:
                this.mDict["S"] = Library.CreateString(text1);
            }
        }

        public PDFDict Dict
        {
            get
            {
                return this.mDict;
            }
            set
            {
                this.mDict = value;
            }
        }

        public int EffectIntensity
        {
            get
            {
                PDFNumeric numeric1 = (this.mDict["I"] as PDFNumeric);
                if (numeric1 == null)
                {
                    return 0;
                }
                return numeric1.Int32Value;
            }
            set
            {
                this.mDict["I"] = Library.CreateInteger(((long) value));
            }
        }


        // Fields
        private PDFDict mDict;
    }
}


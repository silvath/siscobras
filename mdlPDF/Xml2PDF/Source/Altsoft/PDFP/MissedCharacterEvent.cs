namespace Altsoft.PDFP
{
    using System;

    public class MissedCharacterEvent : PDFPainterEvent
    {
        // Methods
        public MissedCharacterEvent(int theLineNumber, string theTagName, char theCharacter, string theFontName) : base(theLineNumber, theTagName)
        {
            this.m_FontName = theFontName;
            this.m_Character = theCharacter;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            MissedCharacterEvent event1 = (obj as MissedCharacterEvent);
            if (event1 == null)
            {
                return false;
            }
            bool flag1 = this.m_Character.Equals(event1.Character);
            bool flag2 = false;
            if (this.m_FontName != null)
            {
                if ((event1.FontName != null) && this.m_FontName.Equals(event1.FontName))
                {
                    flag2 = true;
                }
            }
            else if (event1.FontName == null)
            {
                flag2 = true;
            }
            if (flag1)
            {
                return flag2;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            object[] objArray1 = new object[8];
            objArray1[0] = "font ";
            objArray1[1] = this.m_FontName;
            objArray1[2] = " has no char ";
            objArray1[3] = this.m_Character;
            objArray1[4] = "(unicode ";
            objArray1[5] = char.GetNumericValue(this.m_Character);
            objArray1[6] = ") in ";
            objArray1[7] = base.ToString();
            return objArray1;
        }


        // Properties
        public char Character
        {
            get
            {
                return this.m_Character;
            }
        }

        public string FontName
        {
            get
            {
                return this.m_FontName;
            }
        }


        // Fields
        protected char m_Character;
        protected string m_FontName;
    }
}


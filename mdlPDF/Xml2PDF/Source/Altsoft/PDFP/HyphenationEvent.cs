namespace Altsoft.PDFP
{
    using System;

    public class HyphenationEvent
    {
        // Methods
        public HyphenationEvent(string theCountry, string theLanguage)
        {
            this.m_Country = theCountry;
            this.m_Language = theLanguage;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            HyphenationEvent event1 = (obj as HyphenationEvent);
            if (event1 == null)
            {
                return false;
            }
            bool flag1 = false;
            bool flag2 = false;
            if (this.m_Country != null)
            {
                if ((event1.Country != null) && this.m_Country.Equals(event1.Country))
                {
                    flag1 = true;
                }
            }
            else if (event1.Country == null)
            {
                flag1 = true;
            }
            if (this.m_Language != null)
            {
                if ((event1.Language != null) && this.m_Language.Equals(event1.Language))
                {
                    flag2 = true;
                }
            }
            else if (event1.Language == null)
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
            return "for country=" + this.m_Country + " and language=" + this.m_Language;
        }


        // Properties
        public string Country
        {
            get
            {
                return this.m_Country;
            }
        }

        public string Language
        {
            get
            {
                return this.m_Language;
            }
        }


        // Fields
        protected string m_Country;
        protected string m_Language;
    }
}


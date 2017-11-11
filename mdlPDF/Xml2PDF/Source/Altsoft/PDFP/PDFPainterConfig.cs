namespace Altsoft.PDFP
{
    using System;

    public class PDFPainterConfig
    {
        // Methods
        public PDFPainterConfig()
        {
            this.m_Events = new PDFPainterEventTree();
        }

        public void AddEvent(int type, string theDescription)
        {
            this.m_Events.Add(type, theDescription);
        }

        public void AddEvent(int type, string theCountry, string theLanguage)
        {
            HyphenationEvent event1 = new HyphenationEvent(theCountry, theLanguage);
            this.m_Events.Add(type, event1);
        }

        public void AddEvent(int type, int theLineNumber, string theTagName, string theDescription)
        {
            DescribedPDFPainterEvent event1 = new DescribedPDFPainterEvent(theLineNumber, theTagName, theDescription);
            this.m_Events.Add(type, event1);
        }

        public void AddEvent(int type, int theLineNumber, string theTagName, char theCharacter, string theFontName)
        {
            MissedCharacterEvent event1 = new MissedCharacterEvent(theLineNumber, theTagName, theCharacter, theFontName);
            this.m_Events.Add(type, event1);
        }

        public override string ToString()
        {
            return this.Events.ToString();
        }


        // Properties
        public PDFPainterEventTree Events
        {
            get
            {
                return this.m_Events;
            }
        }


        // Fields
        protected PDFPainterEventTree m_Events;
    }
}


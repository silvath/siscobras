namespace Altsoft.PDFP
{
    using System;

    public class DescribedPDFPainterEvent : PDFPainterEvent
    {
        // Methods
        public DescribedPDFPainterEvent(int theLineNumber, string theTagName, string theDescription) : base(theLineNumber, theTagName)
        {
            this.m_Description = theDescription;
        }

        public override string ToString()
        {
            return this.m_Description + " in " + base.ToString();
        }


        // Properties
        public string Description
        {
            get
            {
                return this.m_Description;
            }
        }


        // Fields
        protected string m_Description;
    }
}


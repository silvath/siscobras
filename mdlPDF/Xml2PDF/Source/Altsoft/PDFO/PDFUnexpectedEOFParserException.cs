namespace Altsoft.PDFO
{
    using System;

    public class PDFUnexpectedEOFParserException : PDFParserException
    {
        // Methods
        public PDFUnexpectedEOFParserException() : base("Unexpected EOF found")
        {
        }

    }
}


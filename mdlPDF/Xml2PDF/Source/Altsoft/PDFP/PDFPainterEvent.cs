namespace Altsoft.PDFP
{
    using System;

    public class PDFPainterEvent
    {
        // Methods
        public PDFPainterEvent(int theLineNumber, string theTagName)
        {
            this.m_LineNumber = theLineNumber;
            this.m_TagName = theTagName;
        }

        public override string ToString()
        {
            object[] objArray1 = new object[4];
            objArray1[0] = "<";
            objArray1[1] = this.m_TagName;
            objArray1[2] = "...> at line ";
            objArray1[3] = this.m_LineNumber;
            return objArray1;
        }


        // Properties
        public int LineNumber
        {
            get
            {
                return this.m_LineNumber;
            }
        }

        public string TagName
        {
            get
            {
                return this.m_TagName;
            }
        }


        // Fields
        protected int m_LineNumber;
        protected string m_TagName;
    }
}


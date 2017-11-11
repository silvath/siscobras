namespace Altsoft.PDFP
{
    using System;

    [Serializable]
    public class PDFPainterErrorEventException : Exception
    {
        // Methods
        public PDFPainterErrorEventException(int theType, object theValue) : base(PDFPainterEventTree.TypeToString(theType))
        {
            this.m_Type = theType;
            this.m_Value = theValue;
        }


        // Properties
        public override string Message
        {
            get
            {
                string[] textArray1 = new string[5];
                textArray1[0] = "PDFPainter ERROR: ";
                textArray1[1] = PDFPainterEventTree.TypeToString(this.m_Type);
                textArray1[2] = " [";
                textArray1[3] = this.m_Value.ToString();
                textArray1[4] = "]";
                return textArray1;
            }
        }

        public int Type
        {
            get
            {
                return this.m_Type;
            }
        }

        public object Value
        {
            get
            {
                return this.m_Value;
            }
        }


        // Fields
        protected int m_Type;
        protected object m_Value;
    }
}


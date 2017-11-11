namespace Altsoft.PDFP
{
    using Altsoft.Common;
    using System;

    public class PDFPainterEventTreeRoot : EventTreeHashtableNode
    {
        // Methods
        public PDFPainterEventTreeRoot() : base(10001)
        {
        }


        // Properties
        public override string Title
        {
            get
            {
                return "PDFPainter warnings and errors";
            }
        }

    }
}


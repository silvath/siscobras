namespace Altsoft.PDFP
{
    using Altsoft.Common;
    using System;

    public class PDFPainterEventTreeNode : EventTreeArrayNode
    {
        // Methods
        public PDFPainterEventTreeNode(int type) : base(type)
        {
        }


        // Properties
        public override string Title
        {
            get
            {
                return PDFPainterEventTree.TypeToString(this.m_Type);
            }
        }

    }
}


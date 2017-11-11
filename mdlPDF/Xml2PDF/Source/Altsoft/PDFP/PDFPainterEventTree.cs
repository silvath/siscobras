namespace Altsoft.PDFP
{
    using Altsoft.Common;
    using System;

    public class PDFPainterEventTree : EventTree
    {
        // Methods
        public PDFPainterEventTree() : base(new PDFPainterEventTreeRoot())
        {
        }

        public override void Add(int type, object value)
        {
            PDFPainterEventTreeNode node1;
            if (PDFPainterEventTree.IsErrorType(type))
            {
                throw new PDFPainterErrorEventException(type, value);
            }
            if (this.m_Root.Contains(type))
            {
                node1 = (this.m_Root[type] as PDFPainterEventTreeNode);
                if (node1 == null)
                {
                    return;
                }
                if ((2 == type) || (1 == type))
                {
                    if (node1.Contains(value))
                    {
                        return;
                    }
                    node1.Add(value);
                    return;
                }
                node1.Add(value);
                return;
            }
            PDFPainterEventTreeNode node2 = new PDFPainterEventTreeNode(type);
            node2.Add(value);
            this.m_Root.Add(type, node2);
        }

        public static bool IsErrorType(int type)
        {
            int num1 = type;
            switch (num1)
            {
                case 0:
                case 2:
                case 1:
                {
                    goto Label_0016;
                }
            }
            goto Label_0018;
        Label_0016:
            return false;
        Label_0018:
            return true;
        }

        public static string TypeToString(int type)
        {
            string text1 = "";
            int num1 = type;
            switch (num1)
            {
                case 1:
                {
                    return text1 + "Undefined character";
                }
                case 2:
                {
                    return text1 + "Hyphenation file not found";
                }
            }
            return text1 + "Unknown error with id=" + type;
        }


        // Fields
        public const int t_PDFPAINTER_EVENT_TREE_ROOT = 10001;
        public const int w_HYPHENATION_FILE_NOT_FOUND = 2;
        public const int w_MISSED_CHARACTER = 1;
    }
}


namespace Altsoft.PDFO
{
    using System;

    public class XRefEntry
    {
        // Methods
        public XRefEntry()
        {
        }


        // Fields
        public bool dirty;
        public int generation;
        public int index;
        public PDFIndirect indirect;
        public long offset;
        public int type;
    }
}


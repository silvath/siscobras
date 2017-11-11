namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;
    using System.Collections;

    internal class XRefComparer : IComparer
    {
        // Methods
        public XRefComparer()
        {
        }

        public int Compare(object x, object y)
        {
            XRefEntry entry1 = ((XRefEntry) x);
            XRefEntry entry2 = ((XRefEntry) y);
            if (entry1.indirect == null)
            {
                if (entry2.indirect == null)
                {
                    return 0;
                }
                return -1;
            }
            if (entry2.indirect == null)
            {
                return 1;
            }
            return (entry1.indirect.Id - entry2.indirect.Id);
        }

    }
}


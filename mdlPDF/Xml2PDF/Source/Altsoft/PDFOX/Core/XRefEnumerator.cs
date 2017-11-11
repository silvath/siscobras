namespace Altsoft.PDFO.Core
{
    using Altsoft.PDFO;
    using System;
    using System.Collections;

    internal class XRefEnumerator : IEnumerator
    {
        // Methods
        internal XRefEnumerator(CoreDocument doc)
        {
            this.mDoc = doc;
            this.mCurr = 0;
        }

        public bool MoveNext()
        {
            XRefEntry entry1;
            int num1;
            goto Label_0047;
        Label_0002:
            entry1 = ((XRefEntry) this.mDoc.mXRef[this.mCurr]);
            if (entry1.type != 0)
            {
                if (entry1.indirect == null)
                {
                    entry1.indirect = new CorePDFIndirect(this.mDoc, this.mCurr);
                }
                return true;
            }
        Label_0047:
            num1 = (this.mCurr + 1);
            this.mCurr = num1;
            if (num1 >= this.mDoc.mXRef.Count)
            {
                return false;
            }
            goto Label_0002;
        }

        public void Reset()
        {
            this.mCurr = 0;
        }


        // Properties
        public object Current
        {
            get
            {
                if (this.mCurr == 0)
                {
                    return null;
                }
                return ((object) ((XRefEntry) this.mDoc.mXRef[this.mCurr]).indirect);
            }
        }


        // Fields
        private int mCurr;
        private CoreDocument mDoc;
    }
}


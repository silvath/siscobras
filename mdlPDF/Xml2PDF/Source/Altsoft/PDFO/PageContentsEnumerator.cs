namespace Altsoft.PDFO
{
    using System;
    using System.Collections;

    internal class PageContentsEnumerator : IEnumerator
    {
        // Methods
        internal PageContentsEnumerator(PageContents pc)
        {
            this.mPC = pc;
            this.mPos = 0;
        }

        public bool MoveNext()
        {
            int num1 = (this.mPos + 1);
            this.mPos = num1;
            return (num1 < this.mPC.Count);
        }

        public void Reset()
        {
            this.mPos = 0;
        }


        // Properties
        public object Current
        {
            get
            {
                return this.mPC[this.mPos];
            }
        }


        // Fields
        private PageContents mPC;
        private int mPos;
    }
}


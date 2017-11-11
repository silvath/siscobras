namespace Altsoft.PDFO
{
    using System;

    public class PDFSyntaxException : PDFException
    {
        // Methods
        public PDFSyntaxException(string msg) : base(msg)
        {
            this.mObj = null;
        }

        public PDFSyntaxException(PDFObject obj, string msg) : base(msg)
        {
            this.mObj = null;
            this.mObj = obj;
        }


        // Properties
        public PDFObject PDFObject
        {
            get
            {
                return this.mObj;
            }
        }


        // Fields
        private PDFObject mObj;
    }
}


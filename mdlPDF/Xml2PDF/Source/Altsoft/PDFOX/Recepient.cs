namespace Altsoft.PDFO
{
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Security.Cryptography.X509Certificates;

    public class Recepient : Resource
    {
        // Methods
        private Recepient(PDFDirect direct) : base(direct)
        {
            this.mCerts = new ArrayList();
        }

        public static Resource Factory(PDFDirect direct)
        {
            return null;
        }

        private bool Parse()
        {
            return true;
        }


        // Properties
        public int Count
        {
            get
            {
                return this.mCerts.Count;
            }
        }

        public X509Certificate this[int nr]
        {
            get
            {
                return (this.mCerts[nr] as X509Certificate);
            }
        }


        // Fields
        private ArrayList mCerts;
    }
}


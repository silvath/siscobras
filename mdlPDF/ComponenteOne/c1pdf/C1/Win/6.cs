namespace C1.Win
{
    using System;
    using System.ComponentModel;

    internal class 6 : License
    {
        // Methods
        internal 6(string licenseKey)
        {
            this.BM = false;
            this.BJ = licenseKey;
        }

        internal 6(string licenseKey, int year, int quarter)
        {
            this.BM = false;
            this.BJ = licenseKey;
            this.BK = year;
            this.BL = quarter;
            this.BM = true;
        }

        public override void Dispose()
        {
        }


        // Properties
        public override string LicenseKey
        {
            get
            {
                return this.BJ;
            }
        }

        public bool WV
        {
            get
            {
                return this.BM;
            }
        }

        public int WW
        {
            get
            {
                return this.BK;
            }
        }

        public int WX
        {
            get
            {
                return this.BL;
            }
        }


        // Fields
        private string BJ;
        private int BK;
        private int BL;
        private bool BM;
    }
}


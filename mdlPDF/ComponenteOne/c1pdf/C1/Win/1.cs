namespace C1.Win
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, Inherited=false, AllowMultiple=false)]
    internal class 1 : Attribute
    {
        // Methods
        public 1(string productCode, string productGUID)
        {
            this.BC = false;
            this.BA = productCode;
            this.BB = productGUID;
        }

        public 1(string productCode, string productGUID, bool alwaysDesignTime) : this(productCode, productGUID)
        {
            this.BC = alwaysDesignTime;
        }


        // Properties
        internal string WM
        {
            get
            {
                return this.BA;
            }
        }

        internal string WN
        {
            get
            {
                return this.BB;
            }
        }

        internal bool WO
        {
            get
            {
                return this.BC;
            }
        }


        // Fields
        private string BA;
        private string BB;
        private bool BC;
    }
}


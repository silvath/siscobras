namespace C1.Win
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, Inherited=false, AllowMultiple=false)]
    internal class 5 : Attribute
    {
        // Methods
        public 5(string supportURL, string newsgroupURL, string updatesURL)
        {
            if (supportURL != null)
            {
                this.BG = supportURL;
            }
            else
            {
                this.BG = "";
            }
            if (newsgroupURL != null)
            {
                this.BH = newsgroupURL;
            }
            else
            {
                this.BH = "";
            }
            if (updatesURL != null)
            {
                this.BI = updatesURL;
                return;
            }
            this.BI = "";
        }


        // Properties
        internal string WS
        {
            get
            {
                return this.BG;
            }
        }

        internal string WT
        {
            get
            {
                return this.BH;
            }
        }

        internal string WU
        {
            get
            {
                return this.BI;
            }
        }


        // Fields
        private string BG;
        private string BH;
        private string BI;
    }
}


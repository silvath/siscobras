namespace C1.Win
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, Inherited=false, AllowMultiple=true)]
    internal class 4 : Attribute
    {
        // Methods
        public 4(string code, string guid)
        {
            this.BE = code;
            this.BF = guid;
        }


        // Properties
        internal string WQ
        {
            get
            {
                return this.BE;
            }
        }

        internal string WR
        {
            get
            {
                return this.BF;
            }
        }


        // Fields
        private string BE;
        private string BF;
    }
}


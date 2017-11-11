namespace C1.Win
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, Inherited=false, AllowMultiple=false)]
    internal class 2 : Attribute
    {
        // Methods
        public 2(string studioGUID)
        {
            this.BD = studioGUID;
        }


        // Properties
        internal string WP
        {
            get
            {
                return this.BD;
            }
        }


        // Fields
        private string BD;
    }
}


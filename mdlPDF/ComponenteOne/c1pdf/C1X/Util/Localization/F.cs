namespace C1.Util.Localization
{
    using System;
    using System.ComponentModel;

    [AttributeUsage(AttributeTargets.All)]
    internal class F : CategoryAttribute
    {
        // Methods
        public F(string name) : base(name)
        {
            this.CN = null;
        }

        protected override string GetLocalizedString(string value)
        {
            if (this.CN != null)
            {
                return this.CN;
            }
            this.CN = G.2J(value);
            if (this.CN == null)
            {
                this.CN = value;
            }
            return this.CN;
        }


        // Fields
        private string CN;
    }
}


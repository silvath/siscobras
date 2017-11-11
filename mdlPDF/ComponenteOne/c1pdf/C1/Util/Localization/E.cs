namespace C1.Util.Localization
{
    using System;
    using System.ComponentModel;

    [AttributeUsage(AttributeTargets.All)]
    internal class E : DescriptionAttribute
    {
        // Methods
        public E(string key)
        {
            this.CM = null;
            this.CM = key;
            base.DescriptionValue = key;
        }

        public E(string key, string description)
        {
            this.CM = null;
            this.CM = key;
            base.DescriptionValue = description;
        }


        // Properties
        public override string Description
        {
            get
            {
                string text1;
                if (this.CM != null)
                {
                    text1 = G.2I(this.CM);
                    if (text1 != null)
                    {
                        base.DescriptionValue = text1;
                    }
                    this.CM = null;
                }
                return base.Description;
            }
        }


        // Fields
        private string CM;
    }
}


namespace Altsoft.PDFO
{
    using System;

    public class Properties : Resource
    {
        // Methods
        static Properties()
        {
            Properties.DictKeyName = "Properties";
        }

        public Properties(PDFDirect d) : base(d)
        {
        }

        internal static Resource Factory(PDFDirect d)
        {
            return new Properties(d);
        }


        // Fields
        internal static readonly string DictKeyName;
    }
}


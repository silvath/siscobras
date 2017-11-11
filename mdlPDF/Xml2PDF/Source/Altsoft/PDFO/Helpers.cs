namespace Altsoft.PDFO
{
    using System;

    public class Helpers
    {
        // Methods
        public Helpers()
        {
        }

        public static string FileSpecToFileName(PDFObject spec)
        {
            FileSpec spec1 = new FileSpec(spec.Direct);
            if (spec1.IsValid)
            {
                return spec1.Path;
            }
            return "";
        }

        public static ArgumentOutOfRangeException IsNameValid(string name)
        {
            return null;
        }

        public static string NtoAOctal(long val)
        {
            string text1 = "";
            while ((val != ((long) 0)))
            {
                text1 = text1 + (((long) 48) + (val % ((long) 8)));
                val = (val / ((long) 8));
            }
            return text1;
        }

    }
}


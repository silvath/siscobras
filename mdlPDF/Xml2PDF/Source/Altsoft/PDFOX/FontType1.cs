namespace Altsoft.PDFO
{
    using System;

    public class FontType1 : Font
    {
        // Methods
        public FontType1(PDFDirect d) : base(d)
        {
        }

        public static FontType1 Create(string name)
        {
            return FontType1.Create(Library.Resources.Doc, name);
        }

        public static FontType1 Create(Document doc, string name)
        {
            return (doc.Resources.Add(Library.Resources[typeof(Font), name]) as FontType1);
        }

    }
}


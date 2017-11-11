namespace Altsoft.PDFP
{
    using Altsoft.Common;
    using Altsoft.PDFO;
    using System;

    public interface IFontData
    {
        // Methods
        bool EmbedFontFile();

        Font GetFont();

        PDFIndirect GetFontInd();

        Rect GlyphBBoxRect(char c);

        double Height(char c);

        bool IsStandard();

        double Width(char c);


        // Properties
        Rect FontBBoxRect { get; }

        double XHeight { get; }

    }
}


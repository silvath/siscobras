namespace Altsoft.PDFO
{
    using System;

    [Flags]
    public enum ESubmitFormFlags
    {
        // Fields
        CanonnicalFormat = 512,
        EmbedForm = 4096,
        ExclFKey = 2048,
        ExclNonUserAnnots = 1024,
        ExportFormat = 4,
        GetMethod = 8,
        Include_Exclude = 1,
        IncludeAnnotations = 128,
        IncludeAppendSaves = 64,
        IncludeNoValueFields = 2,
        None = 0,
        SubmitInCoordinates = 16,
        SubmitPDF = 256,
        XFDF = 32
    }
}


namespace Altsoft.PDFO
{
    using System;

    [Flags]
    public enum DocOpenMode
    {
        // Fields
        Append = 4,
        Create = 256,
        MustCreate = 1280,
        Read = 1,
        ReadWrite = 3,
        Truncate = 512,
        Write = 2
    }
}


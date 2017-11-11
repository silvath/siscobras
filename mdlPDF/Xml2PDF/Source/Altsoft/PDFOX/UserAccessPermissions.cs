namespace Altsoft.PDFO
{
    using System;

    [Flags]
    public enum UserAccessPermissions
    {
        // Fields
        AllowAll = 4294967292,
        Assemble = 1024,
        CopyPaste = 16,
        Extract = 512,
        Interactive = 256,
        InteractiveAndModifyAnnots = 32,
        Modify = 8,
        Print = 4,
        PrintHQ = 2048,
        Reserved1 = 4294963392
    }
}


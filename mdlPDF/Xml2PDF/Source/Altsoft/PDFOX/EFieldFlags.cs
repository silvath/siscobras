namespace Altsoft.PDFO
{
    using System;

    [Flags]
    public enum EFieldFlags
    {
        // Fields
        Comb = 16777216,
        Combo = 2097152,
        CommitOnSellChange = 67108864,
        DoNotScroll = 8388608,
        DoNotSpellCheck = 4194304,
        Edit = 262144,
        FileSelect = 1048576,
        Multiline = 4096,
        MultiSelect = 2097152,
        NoExport = 4,
        None = 0,
        NoToggleToOff = 16384,
        Password = 8192,
        Pushbutton = 65536,
        Radio = 32768,
        RadioInUnison = 33554432,
        ReadOnly = 1,
        Required = 2,
        RichText = 134217728,
        Sort = 524288
    }
}


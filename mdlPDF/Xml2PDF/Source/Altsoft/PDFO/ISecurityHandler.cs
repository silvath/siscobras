namespace Altsoft.PDFO
{
    using System;

    public interface ISecurityHandler
    {
        // Methods
        string GetOwnerPassword();

        string GetUserPassword();

    }
}


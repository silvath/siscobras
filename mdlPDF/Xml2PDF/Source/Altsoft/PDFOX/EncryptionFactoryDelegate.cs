namespace Altsoft.PDFO
{
    using System;
    using System.Runtime.CompilerServices;

    public delegate IEncryption EncryptionFactoryDelegate(PDFDict encryptDict, ISecurityHandler sec);

}


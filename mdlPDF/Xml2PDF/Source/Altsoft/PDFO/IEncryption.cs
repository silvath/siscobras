namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public interface IEncryption
    {
        // Methods
        PDFDict CreateEncryptionDict(Document doc);

        Stream DecryptStream(Stream src, int id, int gene);

        byte[] DecryptString(PDFString src, int id, int gene);

        Stream EncryptStream(Stream src, int id, int gene);

        byte[] EncryptString(PDFString src, int id, int gene);


        // Properties
        PDFDict Dict { get; }

        string Filter { get; }

        int KeyLength { get; }

        uint UserPermissions { get; }

    }
}


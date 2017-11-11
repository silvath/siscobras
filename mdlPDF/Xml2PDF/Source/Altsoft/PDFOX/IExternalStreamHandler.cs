namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public interface IExternalStreamHandler
    {
        // Methods
        Stream GetReadStream(Document doc, FileSpec fs);

        void WriteStream(Document doc, FileSpec fs, Stream stm);

    }
}


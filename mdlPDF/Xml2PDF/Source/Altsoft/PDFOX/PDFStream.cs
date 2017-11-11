namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public interface PDFStream : PDFDirect, PDFObject, IDisposable, ICloneable
    {
        // Methods
        Stream ApplyDecodeFilters(PDFObject filter, PDFObject decodeParams);

        void ApplyEncodeFilters(Stream str, PDFObject fitler, PDFObject encodeParams);

        void ApplyEncodeFilters(Stream str, PDFObject fitler, PDFObject encodeParams, bool setDirectly);

        Stream Decode();

        Stream Decrypt();

        void Encode(Stream str);

        void Encode(Stream str, bool setDirectly);

        void Encrypt(Stream str);

        void Encrypt(Stream str, bool setDirectly);

        Stream GetRawStream();

        void SetRawStream(Stream str);

        void SetRawStream(Stream str, bool setDirectly);


        // Properties
        PDFDict Dict { get; }

        FileSpec FileSpec { get; }

        bool IsExternal { get; }

    }
}


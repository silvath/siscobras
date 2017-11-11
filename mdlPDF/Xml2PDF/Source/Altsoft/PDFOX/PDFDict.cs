namespace Altsoft.PDFO
{
    using System;
    using System.Collections;
    using System.Reflection;

    public interface PDFDict : PDFDirect, PDFObject, IDisposable, ICloneable, ICollection, IEnumerable
    {
        // Methods
        void Clear();

        bool ContainsKey(PDFName key);

        bool ContainsKey(string key);

        bool ContainsValue(PDFObject val);

        PDFObject Remove(PDFName key);

        PDFObject Remove(string key);


        // Properties
        PDFObject this[PDFName key, bool getDirect] { get; }

        PDFObject this[string key, bool getDirect] { get; }

        PDFObject this[PDFName key] { get; set; }

        PDFObject this[string key] { get; set; }

        ICollection Keys { get; }

        ICollection Values { get; }

    }
}


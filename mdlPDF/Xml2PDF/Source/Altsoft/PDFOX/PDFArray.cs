namespace Altsoft.PDFO
{
    using System;
    using System.Collections;
    using System.Reflection;

    public interface PDFArray : PDFDirect, PDFObject, IDisposable, ICloneable, ICollection, IEnumerable
    {
        // Methods
        void Add(PDFObject obj);

        void Clear();

        void Insert(int pos, PDFObject obj);

        void Remove(PDFObject obj);

        PDFObject RemoveAt(int index);


        // Properties
        PDFObject this[int index, bool getDirect] { get; }

        PDFObject this[int index] { get; set; }

    }
}


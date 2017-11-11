namespace Altsoft.PDFO
{
    using System;
    using System.Collections;
    using System.Reflection;

    public interface IndirectCollection : ICollection, IEnumerable
    {
        // Methods
        void Delete(int id);

        PDFIndirect New();

        PDFIndirect New(PDFDirect dir);


        // Properties
        PDFIndirect this[int id] { get; }

    }
}


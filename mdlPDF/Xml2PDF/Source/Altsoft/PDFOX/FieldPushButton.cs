namespace Altsoft.PDFO
{
    using System;

    public class FieldPushButton : Field
    {
        // Methods
        public FieldPushButton(PDFDirect direct) : base(direct)
        {
        }

        public static FieldPushButton Create(PDFDict dict, string partial_name)
        {
            dict["FT"] = Library.CreateName("Btn");
            dict["T"] = Library.CreateString(partial_name);
            dict["Ff"] = Library.CreateInteger(((long) 65536));
            return new FieldPushButton(dict);
        }

    }
}


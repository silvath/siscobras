namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class HalftoneType5 : Halftone
    {
        // Methods
        public HalftoneType5(PDFDirect direct) : base(direct)
        {
        }


        // Properties
        public Halftone Default
        {
            get
            {
                return (Resources.Get(this.Dict["Default"], typeof(Halftone)) as Halftone);
            }
            set
            {
                this.Dict["Default"] = value.Dict;
            }
        }

        public Halftone this[string colorant]
        {
            get
            {
                PDFDirect direct1 = (this.Dict[colorant] as PDFDirect);
                if (direct1 == null)
                {
                    return null;
                }
                return (Resources.Get(direct1, typeof(Halftone)) as Halftone);
            }
            set
            {
                this.Dict[colorant] = value.Dict;
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;

    public class MinScreenSize : Resource
    {
        // Methods
        public MinScreenSize(PDFDirect direct) : base(direct)
        {
            this.mDim = null;
        }

        public static MinScreenSize Create(int width, int height)
        {
            return MinScreenSize.Create(true, width, height);
        }

        public static MinScreenSize Create(bool indirect, int width, int height)
        {
            PDFDict dict1 = Library.CreateDict();
            PDFArray array1 = Library.CreateArray(2);
            array1[0] = Library.CreateInteger(((long) width));
            array1[1] = Library.CreateInteger(((long) height));
            dict1["V"] = array1;
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MinScreenSize(dict1);
        }

        public static MinScreenSize Create(int width, int height, EMonitorSpecifier monitor)
        {
            return MinScreenSize.Create(true, width, height, monitor);
        }

        public static MinScreenSize Create(bool indirect, int width, int height, EMonitorSpecifier monitor)
        {
            MinScreenSize size1 = MinScreenSize.Create(indirect, width, height);
            size1.MonitorSpecifier = monitor;
            return size1;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new MinScreenSize(direct);
        }


        // Properties
        public int MinHeight
        {
            get
            {
                if (this.mDim == null)
                {
                    this.mDim = (this.Dict["V"] as PDFArray);
                }
                return (this.mDim[1] as PDFInteger).Int32Value;
            }
            set
            {
                this.mDim[1] = Library.CreateInteger(((long) value));
            }
        }

        public int MinWidth
        {
            get
            {
                if (this.mDim == null)
                {
                    this.mDim = (this.Dict["V"] as PDFArray);
                }
                return (this.mDim[0] as PDFInteger).Int32Value;
            }
            set
            {
                this.mDim[0] = Library.CreateInteger(((long) value));
            }
        }

        public EMonitorSpecifier MonitorSpecifier
        {
            get
            {
                PDFInteger integer1 = (this.Dict["M"] as PDFInteger);
                if (integer1 == null)
                {
                    return EMonitorSpecifier.largest_section;
                }
                return ((EMonitorSpecifier) ((int) integer1.Value));
            }
            set
            {
                this.Dict["M"] = Library.CreateInteger(((long) value));
            }
        }

        public string Type
        {
            get
            {
                return "MinScreenSize";
            }
        }


        // Fields
        private PDFArray mDim;
    }
}


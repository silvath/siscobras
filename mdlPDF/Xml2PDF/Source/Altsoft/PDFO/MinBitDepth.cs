namespace Altsoft.PDFO
{
    using System;

    public class MinBitDepth : Resource
    {
        // Methods
        public MinBitDepth(PDFDirect direct) : base(direct)
        {
        }

        public static MinBitDepth Create(int depth)
        {
            return MinBitDepth.Create(true, depth);
        }

        public static MinBitDepth Create(bool indirect, int depth)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["V"] = Library.CreateInteger(((long) depth));
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MinBitDepth(dict1);
        }

        public static MinBitDepth Create(int depth, EMonitorSpecifier monitor)
        {
            return MinBitDepth.Create(true, depth, monitor);
        }

        public static MinBitDepth Create(bool indirect, int depth, EMonitorSpecifier monitor)
        {
            MinBitDepth depth1 = MinBitDepth.Create(indirect, depth);
            depth1.MonitorSpecifier = monitor;
            return depth1;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new MinBitDepth(direct);
        }


        // Properties
        public int MinimumScreenDepth
        {
            get
            {
                PDFInteger integer1 = (this.Dict["V"] as PDFInteger);
                if (integer1.Value < ((long) 0))
                {
                    throw new Exception("MinScreenDepth.Negative value not allowed");
                }
                return ((int) integer1.Value);
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("MinScreenDepth.Negative value not allowed");
                }
                this.Dict["V"] = Library.CreateInteger(((long) value));
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
                return "MinBitDepth";
            }
        }

    }
}


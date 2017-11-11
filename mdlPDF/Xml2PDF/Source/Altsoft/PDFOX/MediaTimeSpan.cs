namespace Altsoft.PDFO
{
    using System;

    public class MediaTimeSpan : Resource
    {
        // Methods
        public MediaTimeSpan(PDFDirect direct) : base(direct)
        {
        }

        public static MediaTimeSpan Create(double secNum)
        {
            return MediaTimeSpan.Create(true, secNum);
        }

        public static MediaTimeSpan Create(bool indirect, double secNum)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("S");
            dict1["V"] = Library.CreateFixed(secNum);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MediaTimeSpan(dict1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new MediaTimeSpan(direct);
        }


        // Properties
        public double SecondNumber
        {
            get
            {
                return (this.Dict["V"] as PDFFixed).DoubleValue;
            }
            set
            {
                this.Dict["V"] = Library.CreateFixed(value);
            }
        }


        // Fields
        public const string SubType = "S";
        public const string Type = "TimeSpan";
    }
}


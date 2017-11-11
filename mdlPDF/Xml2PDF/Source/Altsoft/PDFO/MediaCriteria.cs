namespace Altsoft.PDFO
{
    using System;

    public class MediaCriteria : Resource
    {
        // Methods
        public MediaCriteria(PDFDirect direct) : base(direct)
        {
        }

        public static MediaCriteria Create()
        {
            return MediaCriteria.Create(true);
        }

        public static MediaCriteria Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MediaCriteria(dict1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new MediaCriteria(direct);
        }


        // Properties
        public bool AudioDescriptionHeared
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["A"] as PDFBoolean);
                if (flag1 == null)
                {
                    return true;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["A"] = Library.CreateBoolean(value);
            }
        }

        public int BandWidth
        {
            get
            {
                PDFInteger integer1 = (this.Dict["R"] as PDFInteger);
                if (integer1 == null)
                {
                    return 2147483647;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.Dict["R"] = Library.CreateInteger(((long) value));
            }
        }

        public bool CaptionsViable
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["C"] as PDFBoolean);
                if (flag1 == null)
                {
                    return true;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["C"] = Library.CreateBoolean(value);
            }
        }

        public MinBitDepth MinimumBitDepth
        {
            get
            {
                PDFDict dict1 = (this.Dict["D"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MinBitDepth)) as MinBitDepth);
            }
            set
            {
                this.Dict["D"] = value.Dict;
            }
        }

        public MinScreenSize MinimumScreenSize
        {
            get
            {
                PDFDict dict1 = (this.Dict["Z"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MinScreenSize)) as MinScreenSize);
            }
            set
            {
                this.Dict["Z"] = value.Dict;
            }
        }

        public bool OverdubsHeared
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["O"] as PDFBoolean);
                if (flag1 == null)
                {
                    return true;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["O"] = Library.CreateBoolean(value);
            }
        }

        public bool SubTitlesViable
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["S"] as PDFBoolean);
                if (flag1 == null)
                {
                    return true;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["S"] = Library.CreateBoolean(value);
            }
        }

        public string Type
        {
            get
            {
                return "MediaCriteria";
            }
        }

    }
}


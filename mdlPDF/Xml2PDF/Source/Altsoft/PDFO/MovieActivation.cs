namespace Altsoft.PDFO
{
    using System;

    public class MovieActivation : Resource
    {
        // Methods
        public MovieActivation(PDFDirect direct) : base(direct)
        {
            this.mScale = null;
            this.mPosition = null;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new MovieActivation(direct);
        }


        // Properties
        public int Duration
        {
            get
            {
                return 1;
            }
        }

        public double HorPos
        {
            get
            {
                if (this.mPosition != null)
                {
                    return (this.mPosition[0] as PDFFixed).DoubleValue;
                }
                this.mPosition = (this.Dict["FWPosition"] as PDFArray);
                if (this.mPosition == null)
                {
                    return 0.5f;
                }
                return (this.mPosition[0] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mPosition == null)
                {
                    this.mPosition = Library.CreateArray(2);
                }
                this.mPosition[0] = Library.CreateFixed(value);
                this.Dict["FWPosition"] = this.mPosition;
            }
        }

        public PlayMode Mode
        {
            get
            {
                PDFName name1 = (this.Dict["Mode"] as PDFName);
                if (name1 == null)
                {
                    return PlayMode.Once;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_006C;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "Once")
                {
                    if (text1 == "Open")
                    {
                        goto Label_0066;
                    }
                    if (text1 == "Repeat")
                    {
                        goto Label_0068;
                    }
                    if (text1 == "Palindrome")
                    {
                        goto Label_006A;
                    }
                    goto Label_006C;
                }
                return PlayMode.Once;
            Label_0066:
                return PlayMode.Open;
            Label_0068:
                return PlayMode.Repeat;
            Label_006A:
                return PlayMode.Palindrome;
            Label_006C:
                throw new Exception("Illegal play mode");
            }
            set
            {
                string text1 = "Once";
                PlayMode mode1 = value;
                switch (mode1)
                {
                    case PlayMode.Once:
                    {
                        text1 = "Once";
                        goto Label_003E;
                    }
                    case PlayMode.Open:
                    {
                        text1 = "Open";
                        goto Label_003E;
                    }
                    case PlayMode.Repeat:
                    {
                        text1 = "Repeat";
                        goto Label_003E;
                    }
                    case PlayMode.Palindrome:
                    {
                        goto Label_0038;
                    }
                }
                goto Label_003E;
            Label_0038:
                text1 = "Palindrome";
            Label_003E:
                this.Dict["Mode"] = Library.CreateName(text1);
            }
        }

        public double Rate
        {
            get
            {
                PDFNumeric numeric1 = (this.Dict["Rate"] as PDFNumeric);
                if (numeric1 == null)
                {
                    return 1f;
                }
                return numeric1.DoubleValue;
            }
            set
            {
                this.Dict["Rate"] = Library.CreateFixed(value);
            }
        }

        public int ScaleDenumerator
        {
            get
            {
                if (this.mScale != null)
                {
                    return (this.mScale[1] as PDFInteger).Int32Value;
                }
                this.mScale = (this.Dict["FWScale"] as PDFArray);
                if (this.mScale == null)
                {
                    return 0;
                }
                return (this.mScale[1] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.mScale == null)
                {
                    this.mScale = Library.CreateArray(2);
                }
                this.mScale[1] = Library.CreateInteger(((long) value));
                this.Dict["FWScale"] = this.mScale;
            }
        }

        public int ScaleNumerator
        {
            get
            {
                if (this.mScale != null)
                {
                    return (this.mScale[0] as PDFInteger).Int32Value;
                }
                this.mScale = (this.Dict["FWScale"] as PDFArray);
                if (this.mScale == null)
                {
                    return 0;
                }
                return (this.mScale[0] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.mScale == null)
                {
                    this.mScale = Library.CreateArray(2);
                }
                this.mScale[0] = Library.CreateInteger(((long) value));
                this.Dict["FWScale"] = this.mScale;
            }
        }

        public bool ShowControls
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["ShowControls"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["ShowControls"] = Library.CreateBoolean(value);
            }
        }

        public int Start
        {
            get
            {
                return 1;
            }
        }

        public bool Synchronous
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["Synchronous"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["Synchronous"] = Library.CreateBoolean(value);
            }
        }

        public double VertPos
        {
            get
            {
                if (this.mPosition != null)
                {
                    return (this.mPosition[1] as PDFFixed).DoubleValue;
                }
                this.mPosition = (this.Dict["FWPosition"] as PDFArray);
                if (this.mPosition == null)
                {
                    return 0.5f;
                }
                return (this.mPosition[1] as PDFFixed).DoubleValue;
            }
            set
            {
                if (this.mPosition == null)
                {
                    this.mPosition = Library.CreateArray(2);
                }
                this.mPosition[1] = Library.CreateFixed(value);
                this.Dict["FWPosition"] = this.mPosition;
            }
        }

        public double Volume
        {
            get
            {
                PDFNumeric numeric1 = (this.Dict["Volume"] as PDFNumeric);
                if (numeric1 == null)
                {
                    return 1f;
                }
                return numeric1.DoubleValue;
            }
            set
            {
                this.Dict["Volume"] = Library.CreateFixed(value);
            }
        }


        // Fields
        private PDFArray mPosition;
        private PDFArray mScale;
    }
}


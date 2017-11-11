namespace Altsoft.PDFO
{
    using System;
    using System.Collections;

    public class Transition : Resource
    {
        // Methods
        private Transition(PDFDirect direct) : base(direct)
        {
        }

        internal static Resource Factory(PDFDirect direct)
        {
            return new Transition(direct);
        }


        // Properties
        public bool B
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["B"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["B"] = Library.CreateBoolean(value);
            }
        }

        public TransitionDimension Dimension
        {
            get
            {
                PDFName name1 = (this.Dict["DM"] as PDFName);
                if (name1 == null)
                {
                    return TransitionDimension.Horizontal;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_004E;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "V")
                {
                    if (text1 == "H")
                    {
                        goto Label_004C;
                    }
                    goto Label_004E;
                }
                return TransitionDimension.Vertical;
            Label_004C:
                return TransitionDimension.Horizontal;
            Label_004E:
                return TransitionDimension.Unknown;
            }
            set
            {
                TransitionDimension dimension1 = value;
                switch (dimension1)
                {
                    case TransitionDimension.Horizontal:
                    {
                        this.Dict["DM"] = PDF.N("H");
                    }
                    case TransitionDimension.Vertical:
                    {
                        this.Dict["DM"] = PDF.N("V");
                    }
                }
            }
        }

        public int Duration
        {
            get
            {
                PDFInteger integer1 = (this.Dict["D"] as PDFInteger);
                if (integer1 == null)
                {
                    return 1;
                }
                return ((int) integer1.Value);
            }
            set
            {
                this.Dict["D"] = Library.CreateInteger(((long) value));
            }
        }

        public TransitionDirection MotionDirection
        {
            get
            {
                PDFName name1 = (this.Dict["M"] as PDFName);
                if (name1 == null)
                {
                    return TransitionDirection.Inward;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_004E;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "I")
                {
                    if (text1 == "O")
                    {
                        goto Label_004C;
                    }
                    goto Label_004E;
                }
                return TransitionDirection.Inward;
            Label_004C:
                return TransitionDirection.Outward;
            Label_004E:
                return TransitionDirection.Unknown;
            }
            set
            {
                TransitionDirection direction1 = value;
                switch (direction1)
                {
                    case TransitionDirection.Inward:
                    {
                        this.Dict["M"] = PDF.N("I");
                    }
                    case TransitionDirection.Outward:
                    {
                        this.Dict["M"] = PDF.N("O");
                    }
                }
            }
        }

        public int MotionDirectionAngle
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Di"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return ((int) integer1.Value);
            }
            set
            {
                if (((value % 90) != 0) || (value != 315))
                {
                    throw new ArgumentOutOfRangeException("Illegal angle");
                }
                this.Dict["Di"] = Library.CreateInteger(((long) value));
            }
        }

        public double StartingScale
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["SS"] as PDFFixed);
                if (fixed1 == null)
                {
                    return 1f;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["SS"] = Library.CreateFixed(value);
            }
        }

        public TransitionStyle Style
        {
            get
            {
                if (<PrivateImplementationDetails>.$$method0x60008c0-1 == null)
                {
                    Hashtable hashtable1 = new Hashtable(26, 0.5f);
                    hashtable1.Add("Split", 0);
                    Hashtable hashtable2 = new Hashtable(26, 0.5f);
                    hashtable2.Add("Blinds", 1);
                    Hashtable hashtable3 = new Hashtable(26, 0.5f);
                    hashtable3.Add("Box", 2);
                    Hashtable hashtable4 = new Hashtable(26, 0.5f);
                    hashtable4.Add("Wipe", 3);
                    Hashtable hashtable5 = new Hashtable(26, 0.5f);
                    hashtable5.Add("Dissolve", 4);
                    Hashtable hashtable6 = new Hashtable(26, 0.5f);
                    hashtable6.Add("Glitter", 5);
                    Hashtable hashtable7 = new Hashtable(26, 0.5f);
                    hashtable7.Add("R", 6);
                    Hashtable hashtable8 = new Hashtable(26, 0.5f);
                    hashtable8.Add("Fly", 7);
                    Hashtable hashtable9 = new Hashtable(26, 0.5f);
                    hashtable9.Add("Push", 8);
                    Hashtable hashtable10 = new Hashtable(26, 0.5f);
                    hashtable10.Add("Cover", 9);
                    Hashtable hashtable11 = new Hashtable(26, 0.5f);
                    hashtable11.Add("Uncover", 10);
                    Hashtable hashtable12 = new Hashtable(26, 0.5f);
                    hashtable12.Add("Fade", 11);
                    <PrivateImplementationDetails>.$$method0x60008c0-1 = new Hashtable(26, 0.5f);
                }
                PDFString text1 = (this.Dict["S"] as PDFString);
                if (text1 == null)
                {
                    return TransitionStyle.R;
                }
                object obj1 = text1.Value;
                if (obj1 == null)
                {
                    goto Label_017E;
                }
                obj1 = <PrivateImplementationDetails>.$$method0x60008c0-1[obj1];
                if (obj1 == null)
                {
                    goto Label_017E;
                }
                switch (((int) obj1))
                {
                    case 0:
                    {
                        goto Label_0162;
                    }
                    case 1:
                    {
                        goto Label_0164;
                    }
                    case 2:
                    {
                        goto Label_0166;
                    }
                    case 3:
                    {
                        goto Label_0168;
                    }
                    case 4:
                    {
                        goto Label_016A;
                    }
                    case 5:
                    {
                        goto Label_016C;
                    }
                    case 6:
                    {
                        goto Label_016E;
                    }
                    case 7:
                    {
                        goto Label_0170;
                    }
                    case 8:
                    {
                        goto Label_0172;
                    }
                    case 9:
                    {
                        goto Label_0175;
                    }
                    case 10:
                    {
                        goto Label_0178;
                    }
                    case 11:
                    {
                        goto Label_017B;
                    }
                }
                goto Label_017E;
            Label_0162:
                return TransitionStyle.Split;
            Label_0164:
                return TransitionStyle.Blinds;
            Label_0166:
                return TransitionStyle.Box;
            Label_0168:
                return TransitionStyle.Wipe;
            Label_016A:
                return TransitionStyle.Dissolve;
            Label_016C:
                return TransitionStyle.Glitter;
            Label_016E:
                return TransitionStyle.R;
            Label_0170:
                return TransitionStyle.Fly;
            Label_0172:
                return TransitionStyle.Push;
            Label_0175:
                return TransitionStyle.Cover;
            Label_0178:
                return TransitionStyle.Uncover;
            Label_017B:
                return TransitionStyle.Fade;
            Label_017E:
                return TransitionStyle.Unknown;
            }
            set
            {
                TransitionStyle style1 = value;
                switch (style1)
                {
                    case TransitionStyle.Split:
                    {
                        this.Dict["S"] = PDF.N("Split");
                    }
                    case TransitionStyle.Blinds:
                    {
                        this.Dict["S"] = PDF.N("Blinds");
                    }
                    case TransitionStyle.Box:
                    {
                        this.Dict["S"] = PDF.N("Box");
                    }
                    case TransitionStyle.Wipe:
                    {
                        this.Dict["S"] = PDF.N("Wipe");
                    }
                    case TransitionStyle.Dissolve:
                    {
                        this.Dict["S"] = PDF.N("Dissolve");
                    }
                    case TransitionStyle.Glitter:
                    {
                        this.Dict["S"] = PDF.N("Glitter");
                    }
                    case TransitionStyle.R:
                    {
                        this.Dict["S"] = PDF.N("R");
                    }
                    case TransitionStyle.Fly:
                    {
                        this.Dict["S"] = PDF.N("Fly");
                    }
                    case TransitionStyle.Push:
                    {
                        this.Dict["S"] = PDF.N("Push");
                    }
                    case TransitionStyle.Cover:
                    {
                        this.Dict["S"] = PDF.N("Cover");
                    }
                    case TransitionStyle.Uncover:
                    {
                        this.Dict["S"] = PDF.N("Uncover");
                    }
                    case TransitionStyle.Fade:
                    {
                        this.Dict["S"] = PDF.N("Fade");
                    }
                }
            }
        }

    }
}


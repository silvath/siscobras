namespace Altsoft.PDFO
{
    using System;

    public class OutlineItem : Outlines
    {
        // Methods
        internal OutlineItem(PDFDirect direct) : base(direct)
        {
        }

        public static OutlineItem Create()
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Type"] = PDF.N("Outlines");
            dict1["Count"] = PDF.O(0);
            Library.CreateIndirect(dict1);
            return (Resources.Get(dict1, typeof(OutlineItem)) as OutlineItem);
        }

        public static OutlineItem Create(string title)
        {
            OutlineItem item1 = OutlineItem.Create();
            item1.Title = title;
            return item1;
        }

        public static OutlineItem Create(string title, Action action)
        {
            OutlineItem item1 = OutlineItem.Create();
            item1.Title = title;
            item1.Action = action;
            return item1;
        }

        public static OutlineItem Create(string title, LinkDestination dest)
        {
            OutlineItem item1 = OutlineItem.Create();
            item1.Title = title;
            item1.Destination = dest;
            return item1;
        }

        internal static Resource Factory(PDFDirect direct)
        {
            return new OutlineItem(direct);
        }


        // Properties
        public Action Action
        {
            get
            {
                PDFDict dict1 = (this.Dict["A"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(Action)) as Action);
            }
            set
            {
                this.Dict["A"] = value.Dict;
            }
        }

        public double BIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["C"] as PDFArray);
                }
                if (this.RGB == null)
                {
                    return NaNf;
                }
                return (this.RGB[2] as PDFFixed).DoubleValue;
            }
            set
            {
                if (value == NaNf)
                {
                    this.RGB = null;
                    this.Dict.Remove("C");
                    return;
                }
                if (this.RGB == null)
                {
                    this.RGB = Library.CreateArray(3);
                }
                this.RGB[2] = Library.CreateFixed(value);
                this.Dict["C"] = this.RGB;
            }
        }

        public LinkDestination Destination
        {
            get
            {
                PDFDirect direct1 = (this.Dict["Dest"] as PDFDirect);
                if (direct1 == null)
                {
                    return null;
                }
                return (Resources.Get(direct1, typeof(LinkDestination)) as LinkDestination);
            }
            set
            {
                this.Dict["Dest"] = value.Direct;
            }
        }

        public EOutlineItemFlags Flags
        {
            get
            {
                PDFInteger integer1 = (this.Dict["F"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                return ((EOutlineItemFlags) integer1.Int32Value);
            }
            set
            {
                this.Dict["F"] = Library.CreateInteger(((long) value));
            }
        }

        public double GIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["C"] as PDFArray);
                }
                if (this.RGB == null)
                {
                    return NaNf;
                }
                return (this.RGB[1] as PDFFixed).DoubleValue;
            }
            set
            {
                if (value == NaNf)
                {
                    this.RGB = null;
                    this.Dict.Remove("C");
                    return;
                }
                if (this.RGB == null)
                {
                    this.RGB = Library.CreateArray(3);
                }
                this.RGB[1] = Library.CreateFixed(value);
                this.Dict["C"] = this.RGB;
            }
        }

        public OutlineItem Next
        {
            get
            {
                PDFDirect direct1 = (this.Dict["Next"] as PDFDirect);
                if (direct1 == null)
                {
                    return null;
                }
                return (Resources.Get(direct1, typeof(OutlineItem)) as OutlineItem);
            }
            set
            {
                this.Dict["Next"] = value.Dict;
            }
        }

        public OutlineItem Parent
        {
            get
            {
                return (Resources.Get(this.Dict["Parent"], typeof(OutlineItem)) as OutlineItem);
            }
            set
            {
                this.Dict["Parent"] = value.Dict;
            }
        }

        public OutlineItem Prev
        {
            get
            {
                PDFDirect direct1 = (this.Dict["Prev"] as PDFDirect);
                if (direct1 == null)
                {
                    return null;
                }
                return (Resources.Get(direct1, typeof(OutlineItem)) as OutlineItem);
            }
            set
            {
                this.Dict["Prev"] = value.Dict;
            }
        }

        public double RIntensity
        {
            get
            {
                if (this.RGB == null)
                {
                    this.RGB = (this.Dict["C"] as PDFArray);
                }
                if (this.RGB == null)
                {
                    return NaNf;
                }
                return (this.RGB[0] as PDFFixed).DoubleValue;
            }
            set
            {
                if (value == NaNf)
                {
                    this.RGB = null;
                    this.Dict.Remove("C");
                    return;
                }
                if (this.RGB == null)
                {
                    this.RGB = Library.CreateArray(3);
                }
                this.RGB[0] = Library.CreateFixed(value);
                this.Dict["C"] = this.RGB;
            }
        }

        public string Title
        {
            get
            {
                byte num1;
                int num2;
                byte[] numArray1 = (this.Dict["Title"] as PDFString).Bytes;
                if ((numArray1[0] == 254) && (numArray1[1] == 255))
                {
                    for (num2 = 0; (num2 < (numArray1.Length / 2)); num2 += 1)
                    {
                        num1 = numArray1[(num2 * 2)];
                        numArray1[(num2 * 2)] = numArray1[((num2 * 2) + 1)];
                        numArray1[((num2 * 2) + 1)] = num1;
                    }
                    return Encoding.Unicode.GetString(numArray1, 2, (numArray1.Length - 2));
                }
                return Utils.BytesToString(numArray1);
            }
            set
            {
                byte num1;
                int num2;
                PDFString text1 = Library.CreateString("");
                byte[] numArray1 = new byte[((value.Length * 2) + 2)];
                numArray1[0] = 255;
                numArray1[1] = 254;
                Encoding.Unicode.GetBytes(value).CopyTo(numArray1, 2);
                for (num2 = 0; (num2 < (numArray1.Length / 2)); num2 += 1)
                {
                    num1 = numArray1[(num2 * 2)];
                    numArray1[(num2 * 2)] = numArray1[((num2 * 2) + 1)];
                    numArray1[((num2 * 2) + 1)] = num1;
                }
                text1.Bytes = numArray1;
                this.Dict["Title"] = text1;
            }
        }


        // Fields
        private PDFArray RGB;
    }
}


namespace Altsoft.PDFO
{
    using System;

    public class NavigationNode : Resource
    {
        // Methods
        public NavigationNode(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new NavigationNode(direct);
        }


        // Properties
        public double Duration
        {
            get
            {
                PDFFixed fixed1 = (this.Dict["Dur"] as PDFFixed);
                if (fixed1 == null)
                {
                    return NaNf;
                }
                return fixed1.DoubleValue;
            }
            set
            {
                this.Dict["Dur"] = Library.CreateFixed(value);
            }
        }

        public Action NavigateBackward
        {
            get
            {
                PDFDict dict1 = (this.Dict["PA"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(Action)) as Action);
            }
            set
            {
                this.Dict["PA"] = value.Dict;
            }
        }

        public Action NavigateForward
        {
            get
            {
                PDFDict dict1 = (this.Dict["NA"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(Action)) as Action);
            }
            set
            {
                this.Dict["NA"] = value.Dict;
            }
        }

        public NavigationNode NextNode
        {
            get
            {
                PDFDict dict1 = (this.Dict["Next"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(NavigationNode)) as NavigationNode);
            }
            set
            {
                this.Dict["Next"] = value.Dict;
            }
        }

        public NavigationNode PrevNode
        {
            get
            {
                PDFDict dict1 = (this.Dict["Prev"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(NavigationNode)) as NavigationNode);
            }
            set
            {
                this.Dict["Prev"] = value.Dict;
            }
        }


        // Fields
        public const string Type = "NavNode";
    }
}


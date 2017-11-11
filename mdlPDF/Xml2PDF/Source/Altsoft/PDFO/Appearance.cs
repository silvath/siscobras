namespace Altsoft.PDFO
{
    using System;

    public class Appearance : Resource
    {
        // Methods
        public Appearance(PDFDirect direct) : base(direct)
        {
        }

        public static Appearance Create()
        {
            PDFDict dict1 = Library.CreateDict();
            return new Appearance(dict1);
        }

        public static Appearance Create(XObjectForm normalAp)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["N"] = normalAp.Direct;
            return new Appearance(dict1);
        }

        public static Appearance Create(XObjectForm normalAp, XObjectForm downAp)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["N"] = normalAp.Direct;
            dict1["D"] = downAp.Direct;
            return new Appearance(dict1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new Appearance(direct);
        }

        public XObjectForm GetDownStateAppearance(string state)
        {
            PDFDict dict1 = (this.Dict["D"] as PDFDict);
            if ((dict1 == null) || !(dict1[state] is PDFStream))
            {
                return null;
            }
            return (Resources.Get((dict1[state] as PDFDirect), typeof(XObjectForm)) as XObjectForm);
        }

        public XObjectForm GetNormalStateAppearance(string state)
        {
            PDFDict dict1 = (this.Dict["N"] as PDFDict);
            if ((dict1 == null) || !(dict1[state] is PDFStream))
            {
                return null;
            }
            return (Resources.Get((dict1[state] as PDFDirect), typeof(XObjectForm)) as XObjectForm);
        }

        public void SetDownStateAppearance(string state, XObjectForm appearance)
        {
            PDFDict dict1 = (this.Dict["D"] as PDFDict);
            if (dict1 == null)
            {
                dict1 = Library.CreateDict();
                this.Dict["D"] = dict1;
            }
            dict1[state] = appearance.Direct;
        }

        public void SetNormalStateAppearance(string state, XObjectForm appearance)
        {
            PDFDict dict1 = (this.Dict["N"] as PDFDict);
            if (dict1 == null)
            {
                dict1 = Library.CreateDict();
                this.Dict["N"] = dict1;
            }
            dict1[state] = appearance.Direct;
        }


        // Properties
        public XObjectForm UnnamedDownAppearance
        {
            get
            {
                PDFDict dict1 = (this.Dict["D"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(XObjectForm)) as XObjectForm);
            }
            set
            {
                this.Dict["D"] = value.Direct;
            }
        }

        public XObjectForm UnnamedNormalAppearance
        {
            get
            {
                PDFDict dict1 = (this.Dict["N"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(XObjectForm)) as XObjectForm);
            }
            set
            {
                this.Dict["N"] = value.Direct;
            }
        }

    }
}


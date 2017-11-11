namespace Altsoft.PDFO
{
    using System;

    public class ViewerPreferences : Resource
    {
        // Methods
        public ViewerPreferences(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new ViewerPreferences(direct);
        }


        // Properties
        public bool CenterWindow
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["CenterWindow"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["CenterWindow"] = Library.CreateBoolean(value);
            }
        }

        public bool DisplayDocTitle
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["DisplayDocTitle"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["DisplayDocTitle"] = Library.CreateBoolean(value);
            }
        }

        public bool FitWindow
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["FitWindow"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["FitWindow"] = Library.CreateBoolean(value);
            }
        }

        public bool HideMenuBar
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["HideMenubar"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["HideMenubar"] = Library.CreateBoolean(value);
            }
        }

        public bool HideToolBar
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["HideToolbar"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["HideToolbar"] = Library.CreateBoolean(value);
            }
        }

        public bool HideWindowUI
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["HideWindowUI"] as PDFBoolean);
                if (flag1 == null)
                {
                    return false;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["HideWindowUI"] = Library.CreateBoolean(value);
            }
        }

        public bool Left2RightDirection
        {
            get
            {
                PDFName name1 = (this.Dict["Direction"] as PDFName);
                if ((name1 == null) || (name1.Value != "R2L"))
                {
                    return true;
                }
                return false;
            }
            set
            {
                if (value)
                {
                    this.Dict["Direction"] = Library.CreateName("L2R");
                    return;
                }
                this.Dict["Direction"] = Library.CreateName("R2L");
            }
        }

        public EPageMode NonFullScreenPageMode
        {
            get
            {
                PDFName name1 = (this.Dict["NonFullScreenPageMode"] as PDFName);
                if (name1 == null)
                {
                    return EPageMode.UseNone;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_005D;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "UseOutlines")
                {
                    if (text1 == "UseOS")
                    {
                        goto Label_0059;
                    }
                    if (text1 == "Thumbs")
                    {
                        goto Label_005B;
                    }
                    goto Label_005D;
                }
                return EPageMode.UseOutlines;
            Label_0059:
                return EPageMode.UseOC;
            Label_005B:
                return EPageMode.UseThumbs;
            Label_005D:
                return EPageMode.UseNone;
            }
            set
            {
                string text1 = "";
                EPageMode mode1 = value;
                switch (mode1)
                {
                    case EPageMode.UseOutlines:
                    {
                        text1 = "UseOutlines";
                        goto Label_003C;
                    }
                    case EPageMode.UseThumbs:
                    {
                        text1 = "Thumbs";
                        goto Label_003C;
                    }
                    case EPageMode.UseOC:
                    {
                        text1 = "UseOS";
                        goto Label_003C;
                    }
                }
                text1 = "UseNone";
            Label_003C:
                this.Dict["NonFullScreenPageMode"] = Library.CreateName(text1);
            }
        }

        public string PrintArea
        {
            get
            {
                PDFName name1 = (this.Dict["PrintArea"] as PDFName);
                if (name1 == null)
                {
                    return "CropBox";
                }
                return name1.Value;
            }
            set
            {
                this.Dict["PrintArea"] = Library.CreateName(value);
            }
        }

        public string PrintClip
        {
            get
            {
                PDFName name1 = (this.Dict["PrintClip"] as PDFName);
                if (name1 == null)
                {
                    return "CropBox";
                }
                return name1.Value;
            }
            set
            {
                this.Dict["PrintClip"] = Library.CreateName(value);
            }
        }

        public string ViewArea
        {
            get
            {
                PDFName name1 = (this.Dict["ViewArea"] as PDFName);
                if (name1 == null)
                {
                    return "CropBox";
                }
                return name1.Value;
            }
            set
            {
                this.Dict["ViewArea"] = Library.CreateName(value);
            }
        }

        public string ViewCLip
        {
            get
            {
                PDFName name1 = (this.Dict["ViewClip"] as PDFName);
                if (name1 == null)
                {
                    return "CropBox";
                }
                return name1.Value;
            }
            set
            {
                this.Dict["ViewClip"] = Library.CreateName(value);
            }
        }

    }
}


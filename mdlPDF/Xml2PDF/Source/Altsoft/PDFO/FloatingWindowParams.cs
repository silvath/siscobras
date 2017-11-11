namespace Altsoft.PDFO
{
    using System;

    public class FloatingWindowParams : Resource
    {
        // Methods
        public FloatingWindowParams(PDFDirect direct) : base(direct)
        {
        }

        public static FloatingWindowParams Create(int width, int height)
        {
            return FloatingWindowParams.Create(true, width, height);
        }

        public static FloatingWindowParams Create(bool indirect, int width, int height)
        {
            PDFDict dict1 = Library.CreateDict();
            PDFArray array1 = Library.CreateArray(2);
            array1[0] = Library.CreateInteger(((long) width));
            array1[1] = Library.CreateInteger(((long) height));
            dict1["D"] = array1;
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new FloatingWindowParams(dict1);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new FloatingWindowParams(direct);
        }


        // Properties
        public int Height
        {
            get
            {
                return ((this.Dict["D"] as PDFArray)[1] as PDFInteger).Int32Value;
            }
            set
            {
                (this.Dict["D"] as PDFArray)[1] = Library.CreateInteger(((long) value));
            }
        }

        public EOffscreenAction OffscreenAction
        {
            get
            {
                PDFInteger integer1 = (this.Dict["O"] as PDFInteger);
                if (integer1 == null)
                {
                    return EOffscreenAction.MoveOnScreen;
                }
                return ((EOffscreenAction) integer1.Int32Value);
            }
            set
            {
                this.Dict["O"] = Library.CreateInteger(((long) value));
            }
        }

        public ERelativeWindow RelativeWindow
        {
            get
            {
                PDFInteger integer1 = (this.Dict["RT"] as PDFInteger);
                if (integer1 == null)
                {
                    return ERelativeWindow.Document;
                }
                return ((ERelativeWindow) integer1.Int32Value);
            }
            set
            {
                this.Dict["RT"] = Library.CreateInteger(((long) value));
            }
        }

        public bool Title
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["T"] as PDFBoolean);
                if (flag1 == null)
                {
                    return true;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["T"] = Library.CreateBoolean(value);
            }
        }

        public StringArrayResource TitleBarText
        {
            get
            {
                PDFArray array1 = (this.Dict["TT"] as PDFArray);
                if (array1 == null)
                {
                    return null;
                }
                return (Resources.Get(array1, typeof(StringArrayResource)) as StringArrayResource);
            }
            set
            {
                this.Dict["TT"] = value.Direct;
            }
        }

        public bool UserClose
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["UC"] as PDFBoolean);
                if (flag1 == null)
                {
                    return true;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["UC"] = Library.CreateBoolean(value);
            }
        }

        public EUserResize UserResize
        {
            get
            {
                PDFInteger integer1 = (this.Dict["R"] as PDFInteger);
                if (integer1 == null)
                {
                    return EUserResize.NoResize;
                }
                return ((EUserResize) integer1.Int32Value);
            }
            set
            {
                this.Dict["R"] = Library.CreateInteger(((long) value));
            }
        }

        public int Width
        {
            get
            {
                return ((this.Dict["D"] as PDFArray)[0] as PDFInteger).Int32Value;
            }
            set
            {
                (this.Dict["D"] as PDFArray)[0] = Library.CreateInteger(((long) value));
            }
        }

        public EWindowLocation WindowLocation
        {
            get
            {
                PDFInteger integer1 = (this.Dict["P"] as PDFInteger);
                if (integer1 == null)
                {
                    return EWindowLocation.Center;
                }
                return ((EWindowLocation) integer1.Int32Value);
            }
            set
            {
                this.Dict["P"] = Library.CreateInteger(((long) value));
            }
        }


        // Fields
        public const string Type = "FWParams";
    }
}


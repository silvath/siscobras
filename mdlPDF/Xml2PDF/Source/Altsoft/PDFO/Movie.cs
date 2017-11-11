namespace Altsoft.PDFO
{
    using System;

    public class Movie : Resource
    {
        // Methods
        public Movie(PDFDirect direct) : base(direct)
        {
        }

        public static Movie Create(string filename)
        {
            Movie movie1 = new Movie(Library.CreateDict());
            movie1.FileSpecification = new FileSpec(Library.CreateString(filename));
            return movie1;
        }

        public static Movie Create(string filename, int rotate)
        {
            Movie movie1 = Movie.Create(filename);
            movie1.Rotate = rotate;
            return movie1;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new Movie(direct);
        }


        // Properties
        public FileSpec FileSpecification
        {
            get
            {
                return (Resources.Get(this.Dict["F"], typeof(FileSpec)) as FileSpec);
            }
            set
            {
                this.Dict["F"] = Library.CreateString(value.Path);
            }
        }

        public int Height
        {
            get
            {
                if (this.arr != null)
                {
                    return (this.arr[1] as PDFInteger).Int32Value;
                }
                this.arr = (this.Dict["Aspect"] as PDFArray);
                if (this.arr == null)
                {
                    return 0;
                }
                return (this.arr[1] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.arr == null)
                {
                    this.arr = Library.CreateArray(2);
                }
                this.arr[1] = Library.CreateInteger(((long) value));
                this.Dict["Aspect"] = this.arr;
            }
        }

        public XObjectImage Poster
        {
            get
            {
                PDFStream stream1 = (this.Dict["Poster"] as PDFStream);
                if (stream1 == null)
                {
                    return null;
                }
                return (Resources.Get(stream1, typeof(XObjectImage)) as XObjectImage);
            }
            set
            {
                if (value == null)
                {
                    this.Dict.Remove("Poster");
                    return;
                }
                this.Dict["Poster"] = value.Direct;
            }
        }

        public PosterDisplay PosterInfo
        {
            get
            {
                PDFObject obj1 = this.Dict["Poster"];
                if (obj1 == null)
                {
                    return PosterDisplay.notDisplayed;
                }
                if (obj1.PDFType == PDFObjectType.tPDFStream)
                {
                    return PosterDisplay.XObject;
                }
                if ((obj1 as PDFBoolean).Value)
                {
                    return PosterDisplay.retrieve;
                }
                return PosterDisplay.notDisplayed;
            }
            set
            {
                PosterDisplay display1 = value;
                switch (display1)
                {
                    case PosterDisplay.retrieve:
                    {
                        this.Dict["Poster"] = Library.CreateBoolean(true);
                    }
                    case PosterDisplay.notDisplayed:
                    {
                        this.Dict["Poster"] = Library.CreateBoolean(false);
                    }
                }
            }
        }

        public int Rotate
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Rotate"] as PDFInteger);
                if (integer1 == null)
                {
                    return 0;
                }
                if ((integer1.Int32Value % 90) != 0)
                {
                    throw new Exception("Illegal Rotate value");
                }
                return integer1.Int32Value;
            }
            set
            {
                if ((value % 90) != 0)
                {
                    throw new Exception("Illegal Rotate value");
                }
                this.Dict["Rotate"] = Library.CreateInteger(((long) value));
            }
        }

        public int Width
        {
            get
            {
                if (this.arr != null)
                {
                    return (this.arr[0] as PDFInteger).Int32Value;
                }
                this.arr = (this.Dict["Aspect"] as PDFArray);
                if (this.arr == null)
                {
                    return 0;
                }
                return (this.arr[0] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.arr == null)
                {
                    this.arr = Library.CreateArray(2);
                }
                this.arr[0] = Library.CreateInteger(((long) value));
                this.Dict["Aspect"] = this.arr;
            }
        }


        // Fields
        private PDFArray arr;
    }
}


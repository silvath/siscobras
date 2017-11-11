namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class quadrilateral : Resource
    {
        // Methods
        public quadrilateral(PDFDirect direct) : base(direct)
        {
            this.mArr = (direct as PDFArray);
        }

        internal static Resource Factory(PDFDirect direct)
        {
            return new quadrilateral(direct);
        }


        // Properties
        public int x1
        {
            get
            {
                if (this.mArr == null)
                {
                    return 2147483647;
                }
                return (this.mArr[0] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.mArr == null)
                {
                    this.mArr = Library.CreateArray(8);
                }
                this.mArr[0] = Library.CreateInteger(((long) value));
            }
        }

        public Point x1y1
        {
            get
            {
                if (this.mArr == null)
                {
                    return null;
                }
                return new Point(((double) (this.mArr[0] as PDFInteger).Int32Value), ((double) (this.mArr[1] as PDFInteger).Int32Value));
            }
            set
            {
                if (this.mArr == null)
                {
                    this.mArr = Library.CreateArray(8);
                }
                this.mArr[0] = Library.CreateInteger(((long) ((int) value.x)));
                this.mArr[1] = Library.CreateInteger(((long) ((int) value.y)));
            }
        }

        public int x2
        {
            get
            {
                if (this.mArr == null)
                {
                    return 2147483647;
                }
                return (this.mArr[2] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.mArr == null)
                {
                    this.mArr = Library.CreateArray(8);
                }
                this.mArr[2] = Library.CreateInteger(((long) value));
            }
        }

        public Point x2y2
        {
            get
            {
                if (this.mArr == null)
                {
                    return null;
                }
                return new Point(((double) (this.mArr[2] as PDFInteger).Int32Value), ((double) (this.mArr[3] as PDFInteger).Int32Value));
            }
            set
            {
                if (this.mArr == null)
                {
                    this.mArr = Library.CreateArray(8);
                }
                this.mArr[2] = Library.CreateInteger(((long) ((int) value.x)));
                this.mArr[3] = Library.CreateInteger(((long) ((int) value.y)));
            }
        }

        public int x3
        {
            get
            {
                if (this.mArr == null)
                {
                    return 2147483647;
                }
                return (this.mArr[4] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.mArr == null)
                {
                    this.mArr = Library.CreateArray(8);
                }
                this.mArr[4] = Library.CreateInteger(((long) value));
            }
        }

        public Point x3y3
        {
            get
            {
                if (this.mArr == null)
                {
                    return null;
                }
                return new Point(((double) (this.mArr[4] as PDFInteger).Int32Value), ((double) (this.mArr[5] as PDFInteger).Int32Value));
            }
            set
            {
                if (this.mArr == null)
                {
                    this.mArr = Library.CreateArray(8);
                }
                this.mArr[4] = Library.CreateInteger(((long) ((int) value.x)));
                this.mArr[5] = Library.CreateInteger(((long) ((int) value.y)));
            }
        }

        public int x4
        {
            get
            {
                if (this.mArr == null)
                {
                    return 2147483647;
                }
                return (this.mArr[6] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.mArr == null)
                {
                    this.mArr = Library.CreateArray(8);
                }
                this.mArr[6] = Library.CreateInteger(((long) value));
            }
        }

        public Point x4y4
        {
            get
            {
                if (this.mArr == null)
                {
                    return null;
                }
                return new Point(((double) (this.mArr[6] as PDFInteger).Int32Value), ((double) (this.mArr[7] as PDFInteger).Int32Value));
            }
            set
            {
                if (this.mArr == null)
                {
                    this.mArr = Library.CreateArray(8);
                }
                this.mArr[6] = Library.CreateInteger(((long) ((int) value.x)));
                this.mArr[7] = Library.CreateInteger(((long) ((int) value.y)));
            }
        }

        public int y1
        {
            get
            {
                if (this.mArr == null)
                {
                    return 2147483647;
                }
                return (this.mArr[1] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.mArr == null)
                {
                    this.mArr = Library.CreateArray(8);
                }
                this.mArr[1] = Library.CreateInteger(((long) value));
            }
        }

        public int y2
        {
            get
            {
                if (this.mArr == null)
                {
                    return 2147483647;
                }
                return (this.mArr[3] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.mArr == null)
                {
                    this.mArr = Library.CreateArray(8);
                }
                this.mArr[3] = Library.CreateInteger(((long) value));
            }
        }

        public int y3
        {
            get
            {
                if (this.mArr == null)
                {
                    return 2147483647;
                }
                return (this.mArr[5] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.mArr == null)
                {
                    this.mArr = Library.CreateArray(8);
                }
                this.mArr[5] = Library.CreateInteger(((long) value));
            }
        }

        public int y4
        {
            get
            {
                if (this.mArr == null)
                {
                    return 2147483647;
                }
                return (this.mArr[7] as PDFInteger).Int32Value;
            }
            set
            {
                if (this.mArr == null)
                {
                    this.mArr = Library.CreateArray(8);
                }
                this.mArr[7] = Library.CreateInteger(((long) value));
            }
        }


        // Fields
        private PDFArray mArr;
        private const int mObjSize = 8;
    }
}


namespace Altsoft.PDFO
{
    using System;

    public class TagPair : Resource
    {
        // Methods
        public TagPair(PDFDirect direct) : base(direct)
        {
            this.mArr = (direct as PDFArray);
        }

        internal static Resource Factory(PDFDirect direct)
        {
            return new TagPair(direct);
        }


        // Properties
        public int TagNumber
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
                    this.mArr = Library.CreateArray(2);
                }
                this.mArr[0] = Library.CreateInteger(((long) value));
            }
        }

        public string TagText
        {
            get
            {
                if (this.mArr == null)
                {
                    return null;
                }
                return (this.mArr[1] as PDFString).Value;
            }
            set
            {
                if (this.mArr == null)
                {
                    this.mArr = Library.CreateArray(2);
                }
                this.mArr[1] = Library.CreateString(value);
            }
        }


        // Fields
        private PDFArray mArr;
        private const int mObjSize = 2;
    }
}


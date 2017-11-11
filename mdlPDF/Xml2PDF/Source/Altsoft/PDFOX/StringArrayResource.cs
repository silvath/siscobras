namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class StringArrayResource : Resource
    {
        // Methods
        public StringArrayResource(PDFArray arr) : base(arr)
        {
            this.mArr = arr;
        }

        public void Add(string value)
        {
            this.mArr.Add(Library.CreateString(value));
        }

        public void RemoveAt(int index)
        {
            if (index < this.Count)
            {
                this.mArr.RemoveAt(index);
            }
        }


        // Properties
        public int Count
        {
            get
            {
                return this.mArr.Count;
            }
        }

        public string this[int index]
        {
            get
            {
                if (index < this.Count)
                {
                    return (this.mArr[index] as PDFString).Value;
                }
                return null;
            }
            set
            {
                if (index < this.Count)
                {
                    this.mArr[index] = Library.CreateString(value);
                }
            }
        }


        // Fields
        private PDFArray mArr;
    }
}


namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class ChoiceOpt : Resource
    {
        // Methods
        public ChoiceOpt(PDFArray arr) : base(arr)
        {
            this.mArr = arr;
        }

        public void Add(ChoiceOptItem value)
        {
            this.mArr.Add(value.Direct);
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new ChoiceOpt((direct as PDFArray));
        }

        public void RemoveAt(int index)
        {
            this.mArr.RemoveAt(index);
        }


        // Properties
        public int Count
        {
            get
            {
                return this.mArr.Count;
            }
        }

        public ChoiceOptItem this[int index]
        {
            get
            {
                if ((index < this.Count) && (this.mArr[index] is PDFDirect))
                {
                    return (base.Direct.Doc.Resources[(this.mArr[index] as PDFDirect), typeof(ChoiceOptItem)] as ChoiceOptItem);
                }
                return null;
            }
            set
            {
                if (index < this.Count)
                {
                    this.mArr[index] = base.Direct.Doc.Resources.Add(value).Direct;
                }
            }
        }


        // Fields
        private PDFArray mArr;
    }
}


namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class ActionsCollection : ComplexObjectArrayBase
    {
        // Methods
        internal ActionsCollection(PDFDict dict) : base(dict, "Next", true)
        {
            this.mDict = (dict["Next"] as PDFDict);
        }

        public void Add(Action value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(Action));
        }

        public void Remove(Action value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public PDFDict Dict
        {
            get
            {
                return this.mDict;
            }
        }

        public Action this[int index]
        {
            get
            {
                return (base._GetObject(index) as Action);
            }
            set
            {
                base._SetObject(index, value, value.Dict);
            }
        }


        // Fields
        private PDFDict mDict;
    }
}


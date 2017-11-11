namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class GroupStateCollection : ComplexObjectArrayBase
    {
        // Methods
        public GroupStateCollection(PDFDict dict, string key, bool single_value) : base(dict, key, single_value)
        {
        }

        public void Add(GroupState value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(GroupState));
        }

        public void Remove(GroupState value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public GroupState this[int index]
        {
            get
            {
                return (base._GetObject(index) as GroupState);
            }
            set
            {
                base._SetObject(index, value, value.Direct);
            }
        }

    }
}


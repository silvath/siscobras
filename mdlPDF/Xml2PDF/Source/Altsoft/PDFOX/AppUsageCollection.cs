namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class AppUsageCollection : ComplexObjectArrayBase
    {
        // Methods
        public AppUsageCollection(PDFDict dict, string key, bool single_value) : base(dict, key, single_value)
        {
        }

        public void Add(ApplicationUsage value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(ApplicationUsage));
        }

        public void Remove(ApplicationUsage value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public ApplicationUsage this[int index]
        {
            get
            {
                return (base._GetObject(index) as ApplicationUsage);
            }
            set
            {
                base._SetObject(index, value, value.Dict);
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class AnnotationVarCollection : ComplexObjectArrayBase
    {
        // Methods
        public AnnotationVarCollection(PDFDict dict, string key, bool single_value) : base(dict, key, single_value)
        {
        }

        public void Add(AnnotationVar value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(AnnotationVar));
        }

        public void Remove(AnnotationVar value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public AnnotationVar this[int index]
        {
            get
            {
                return (base._GetObject(index) as AnnotationVar);
            }
            set
            {
                base._SetObject(index, value, value.Direct.Indirect);
            }
        }

    }
}


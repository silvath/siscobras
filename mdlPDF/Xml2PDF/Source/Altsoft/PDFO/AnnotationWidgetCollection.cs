namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class AnnotationWidgetCollection : ComplexObjectArrayDirect
    {
        // Methods
        public AnnotationWidgetCollection(PDFDirect direct) : base(direct, false)
        {
        }

        public void Add(AnnotationWidget value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(AnnotationWidget));
        }

        public static AnnotationWidgetCollection Create()
        {
            return new AnnotationWidgetCollection(Library.CreateArray(0));
        }

        public void Remove(AnnotationWidget value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public AnnotationWidget this[int index]
        {
            get
            {
                return (base._GetObject(index) as AnnotationWidget);
            }
            set
            {
                base._SetObject(index, value, value.Direct.Indirect);
            }
        }

    }
}


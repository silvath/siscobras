namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public class MediaPlayerInfoCollection : ComplexObjectArrayBase
    {
        // Methods
        public MediaPlayerInfoCollection(PDFDict dict, string key, bool single_value) : base(dict, key, single_value)
        {
        }

        public void Add(MediaPlayerInfo value)
        {
            this[base.Count] = value;
        }

        internal override object ComplexObjectFactory(PDFDirect dict)
        {
            return Resources.Get(dict, typeof(MediaPlayerInfo));
        }

        public void Remove(MediaPlayerInfo value)
        {
            base._Remove(value);
        }

        public void RemoveAt(int index)
        {
            base._RemoveAt(index);
        }


        // Properties
        public MediaPlayerInfo this[int index]
        {
            get
            {
                return (base._GetObject(index) as MediaPlayerInfo);
            }
            set
            {
                base._SetObject(index, value, value.Direct);
            }
        }

    }
}


namespace Altsoft.PDFO
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class StreamEncodingRuleColl : ICollection, IEnumerable
    {
        // Methods
        internal StreamEncodingRuleColl()
        {
            this.mRules = new ArrayList();
        }

        public void Add(IStreamEncodingRule h)
        {
            this.mRules.Add(h);
        }

        public void Clear()
        {
            this.mRules.Clear();
        }

        public void CopyTo(Array array, int index)
        {
            int num1;
            for (num1 = 0; (num1 < this.Count); num1 += 1)
            {
                array.SetValue(this[num1], (index + num1));
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this.mRules.GetEnumerator();
        }

        public void Insert(int nr, IStreamEncodingRule h)
        {
            this.mRules.Insert(nr, h);
        }

        public void RemoveAt(int nr)
        {
            this.mRules.RemoveAt(nr);
        }

        public void RemoveByType(Type type)
        {
            int num1;
            for (num1 = 0; (num1 < this.mRules.Count); num1 += 1)
            {
                if (this.mRules[num1].GetType().Equals(type))
                {
                    this.mRules.RemoveAt(num1);
                }
            }
        }


        // Properties
        public int Count
        {
            get
            {
                return this.mRules.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return this.mRules.IsSynchronized;
            }
        }

        public IStreamEncodingRule this[int nr]
        {
            get
            {
                return ((IStreamEncodingRule) this.mRules[nr]);
            }
            set
            {
                this.mRules[nr] = ((object) value);
            }
        }

        public IStreamEncodingRule this[Type type]
        {
            get
            {
                foreach (IStreamEncodingRule rule1 in this.mRules)
                {
                    if (!rule1.GetType().Equals(type))
                    {
                        continue;
                    }
                    return rule1;
                }
                return null;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this.mRules.SyncRoot;
            }
        }


        // Fields
        private ArrayList mRules;
    }
}


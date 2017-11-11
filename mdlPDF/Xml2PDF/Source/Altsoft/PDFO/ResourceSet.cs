namespace Altsoft.PDFO
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class ResourceSet : ICollection, IEnumerable
    {
        // Methods
        public ResourceSet()
        {
            this.mCount = 0;
            this.mResources = new Hashtable();
        }

        public virtual void Add(string name, Resource res)
        {
            Type type1 = Resource.GetMajorType(res);
            Hashtable hashtable1 = ((Hashtable) this.mResources[type1]);
            if (hashtable1 == null)
            {
                hashtable1 = new Hashtable();
                this.mResources[type1] = hashtable1;
            }
            hashtable1[name] = res;
            this.mCount += 1;
        }

        public PDFDict AsAbstractDict(Document doc)
        {
            return null;
        }

        public virtual void Clear()
        {
            this.mResources.Clear();
        }

        public bool ContainsKey(Type resType, string name)
        {
            return (this[resType, name] != null);
        }

        public bool ContainsValue(Resource res)
        {
            foreach (DictionaryEntry entry1 in this)
            {
                if ((entry1.Key as PDFObject).UniqueID != res.Direct.UniqueID)
                {
                    continue;
                }
                return true;
            }
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            int num1 = index;
            foreach (object obj1 in this)
            {
                int num2 = num1;
                num1 = (num2 + 1);
                array.SetValue(obj1, num1);
            }
        }

        public virtual void Delete(Type resType, string name)
        {
            Hashtable hashtable1 = ((Hashtable) this.mResources[resType]);
            if ((hashtable1 != null) && (hashtable1[name] != null))
            {
                hashtable1.Remove(name);
                this.mCount -= 1;
            }
        }

        public virtual string GenerateUniqueResName(Type resType, string res_prefix)
        {
            string text1;
            if (res_prefix.Equals(""))
            {
                res_prefix = "RES";
            }
            int num1 = 0;
            Hashtable hashtable1 = ((Hashtable) this.mResources[resType]);
            if (hashtable1 == null)
            {
                goto Label_0052;
            }
            num1 = hashtable1.Count;
        Label_0032:
            text1 = res_prefix + num1.ToString();
            if (!this.ContainsKey(resType, text1))
            {
                return text1;
            }
            num1 += 1;
            goto Label_0032;
        Label_0052:
            return res_prefix + 48;
        }

        public IEnumerator GetEnumerator()
        {
            return new ResourceSetEnumerator(this.mResources);
        }

        public ResourceSet GetResourcesByType(params Type[] types)
        {
            Type type1;
            Type type2;
            Type[] typeArray1;
            int num1;
            ResourceSet set1 = new ResourceSet();
            foreach (DictionaryEntry entry1 in this)
            {
                type1 = entry1.Value.GetType();
                typeArray1 = types;
                for (num1 = 0; (num1 < typeArray1.Length); num1 += 1)
                {
                    type2 = typeArray1[num1];
                    if (type1.Equals(type2) || type1.IsSubclassOf(type2))
                    {
                        set1.Add(((string) entry1.Key), ((Resource) entry1.Value));
                        continue;
                    }
                }
            }
            return set1;
        }


        // Properties
        public int Count
        {
            get
            {
                return this.mCount;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public Resource this[Type resType, string name]
        {
            get
            {
                Hashtable hashtable1 = ((Hashtable) this.mResources[resType]);
                if (hashtable1 == null)
                {
                    return null;
                }
                return ((Resource) hashtable1[name]);
            }
        }

        public object SyncRoot
        {
            get
            {
                return null;
            }
        }


        // Fields
        private int mCount;
        private Hashtable mResources;

        // Nested Types
        private class ResourceSetEnumerator : IEnumerator
        {
            // Methods
            internal ResourceSetEnumerator(Hashtable res_map)
            {
                this.mMapsEnum = res_map.GetEnumerator();
                this.mResEnum = null;
            }

            private bool GetNextResMap()
            {
                Hashtable hashtable1 = null;
                while ((hashtable1 == null))
                {
                    if (!this.mMapsEnum.MoveNext())
                    {
                        return false;
                    }
                    hashtable1 = (this.mMapsEnum.Value as Hashtable);
                }
                this.mResEnum = hashtable1.GetEnumerator();
                return true;
            }

            public bool MoveNext()
            {
                if ((this.mResEnum == null) && !this.GetNextResMap())
                {
                    return false;
                }
                if (!this.mResEnum.MoveNext())
                {
                    goto Label_0030;
                }
                return true;
            Label_0021:
                if (this.mResEnum.MoveNext())
                {
                    return true;
                }
            Label_0030:
                if (!this.GetNextResMap())
                {
                    return false;
                }
                goto Label_0021;
            }

            public void Reset()
            {
                this.mMapsEnum.Reset();
                this.mResEnum = null;
            }


            // Properties
            public object Current
            {
                get
                {
                    if (this.mResEnum == null)
                    {
                        return null;
                    }
                    return this.mResEnum.Current;
                }
            }


            // Fields
            private IDictionaryEnumerator mMapsEnum;
            private IEnumerator mResEnum;
        }
    }
}


namespace Altsoft.PDFO
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class Resources
    {
        // Methods
        static Resources()
        {
            Resources.mAllResources = new Hashtable();
        }

        public Resources()
        {
        }

        private static Resource CreateResource(PDFDirect d, Type resType)
        {
            MethodInfo info1;
            object[] objArray1;
            try
            {
                while (!resType.Equals(typeof(object)))
                {
                    if (resType.Equals(typeof(Resource)))
                    {
                        return null;
                    }
                    if (!resType.IsSubclassOf(typeof(Resource)))
                    {
                        throw new ArgumentException("Resources should derive from Altsoft.PDFO.Resource", "resType");
                    }
                    info1 = resType.GetMethod("Factory", (BindingFlags.NonPublic | (BindingFlags.Public | BindingFlags.Static)));
                    if (info1 == null)
                    {
                        resType = resType.BaseType;
                        continue;
                    }
                    objArray1 = new object[1];
                    objArray1[0] = ((object) d);
                    return ((Resource) info1.Invoke(null, objArray1));
                }
            }
            catch (TargetInvocationException exception1)
            {
                throw exception1.InnerException;
            }
            throw new ArgumentException("Resources should have static method with signature (PDFDirect)", "resType");
        }

        public static Resource Get(PDFObject obj)
        {
            return ((Resource) Resources.mAllResources[obj.Direct.UniqueID]);
        }

        public static Resource Get(PDFObject obj, Type typ)
        {
            if (obj == null)
            {
                return null;
            }
            Resource resource1 = ((Resource) Resources.mAllResources[obj.Direct.UniqueID]);
            if (resource1 == null)
            {
                resource1 = Resources.CreateResource(obj.Direct, typ);
                if (resource1 != null)
                {
                    Resources.mAllResources[obj.Direct.UniqueID] = resource1;
                }
                return resource1;
            }
            Type type1 = resource1.GetType();
            if (!type1.Equals(typ) && !type1.IsSubclassOf(typ))
            {
                return null;
            }
            return resource1;
        }

        internal static void RemoveResourcesByDoc(Document doc)
        {
            ArrayList list1 = new ArrayList();
            foreach (DictionaryEntry entry1 in Resources.mAllResources)
            {
                if (((Resource) entry1.Value).Direct.Doc != doc)
                {
                    continue;
                }
                list1.Add(entry1.Key);
            }
            foreach (object obj1 in list1)
            {
                Resources.mAllResources.Remove(obj1);
            }
        }


        // Fields
        internal static Hashtable mAllResources;
    }
}


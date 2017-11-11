namespace Altsoft.PDFO
{
    using System;
    using System.Reflection;

    public abstract class Resource
    {
        // Methods
        protected Resource(PDFDirect d)
        {
            this.mDirect = d;
        }

        internal static string GetDictKeyName(object x)
        {
            FieldInfo info1;
            Type type1 = (x as Type);
            if (type1 == null)
            {
                type1 = x.GetType();
            }
            while (!type1.Equals(typeof(object)))
            {
                info1 = type1.GetField("DictKeyName", (BindingFlags.NonPublic | BindingFlags.Static));
                if (info1 == null)
                {
                    type1 = type1.BaseType;
                    continue;
                }
                return ((string) info1.GetValue(null));
            }
            return "";
        }

        internal static Type GetMajorType(Resource r)
        {
            FieldInfo info1;
            Type type1 = r.GetType();
            while (!type1.Equals(typeof(object)))
            {
                info1 = type1.GetField("DictKeyName", (BindingFlags.NonPublic | BindingFlags.Static));
                if (info1 == null)
                {
                    type1 = type1.BaseType;
                    continue;
                }
                return type1;
            }
            return null;
        }


        // Properties
        public virtual PDFDict Dict
        {
            get
            {
                PDFObjectType type1 = this.mDirect.PDFType;
                switch (type1)
                {
                    case PDFObjectType.tPDFDict:
                    {
                        goto Label_0022;
                    }
                    case PDFObjectType.tPDFArray:
                    {
                        goto Label_003F;
                    }
                    case PDFObjectType.tPDFStream:
                    {
                        goto Label_002E;
                    }
                }
                goto Label_003F;
            Label_0022:
                return ((PDFDict) this.mDirect);
            Label_002E:
                return ((PDFStream) this.mDirect).Dict;
            Label_003F:
                return null;
            }
        }

        public PDFDirect Direct
        {
            get
            {
                return this.mDirect;
            }
        }

        public Document Doc
        {
            get
            {
                PDFDirect direct1 = this.Direct;
                if (direct1 == null)
                {
                    return null;
                }
                return direct1.Doc;
            }
        }

        public virtual DocResourceSet Resources
        {
            get
            {
                return null;
            }
        }

        public string ResType
        {
            get
            {
                return Resource.GetDictKeyName(this);
            }
        }


        // Fields
        protected PDFDirect mDirect;
    }
}


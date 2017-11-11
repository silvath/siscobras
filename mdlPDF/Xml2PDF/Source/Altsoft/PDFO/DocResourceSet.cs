namespace Altsoft.PDFO
{
    using System;
    using System.Collections;

    public class DocResourceSet : ResourceSet
    {
        // Methods
        internal DocResourceSet(PDFDict resourceDict, PDFDict parentDict, DocResourceSet parent)
        {
            this.mParentDict = null;
            this.mParent = new WeakReference(null);
            this.mParentDict = parentDict;
            this.mResourceDict = resourceDict;
            this.mParent.Target = parent;
            if (this.mResourceDict == null)
            {
                return;
            }
            this.ScanResourceType(((PDFDict) resourceDict["ExtGState"]), typeof(ExtGState));
            this.ScanResourceType(((PDFDict) resourceDict["ColorSpace"]), typeof(ColorSpace));
            this.ScanResourceType(((PDFDict) resourceDict["Pattern"]), typeof(Pattern));
            this.ScanResourceType(((PDFDict) resourceDict["Shading"]), typeof(Shading));
            this.ScanResourceType(((PDFDict) resourceDict["XObject"]), typeof(XObject));
            this.ScanResourceType(((PDFDict) resourceDict["Font"]), typeof(Font));
            this.ScanResourceType(((PDFDict) resourceDict["Properties"]), typeof(Properties));
        }

        public override void Add(string name, Resource res)
        {
            PDFObject obj1;
            base.Add(name, res);
            if (this.mResourceDict == null)
            {
                obj1 = Library.CreateDict();
                this.mParentDict["Resources"] = obj1;
                this.mResourceDict = ((PDFDict) obj1);
            }
            PDFDict dict1 = null;
            string text1 = Resource.GetDictKeyName(res);
            if (text1 == "")
            {
                throw new PDFException("The resource being added is not a page resource");
            }
            dict1 = ((PDFDict) this.mResourceDict[text1]);
            if (dict1 == null)
            {
                obj1 = Library.CreateDict();
                this.mResourceDict[text1] = obj1;
                dict1 = ((PDFDict) obj1);
            }
            res = this.Doc.Resources.Add(res);
            if (res.Direct.IsIndirect)
            {
                dict1[name] = res.Direct.Indirect;
                return;
            }
            dict1[name] = dict1.Doc.Indirects.New(res.Direct);
        }

        public override void Clear()
        {
            base.Clear();
            if (this.mResourceDict != null)
            {
                this.mResourceDict.Clear();
            }
        }

        public override void Delete(Type resType, string name)
        {
            base.Delete(resType, name);
            if (this.mResourceDict == null)
            {
                return;
            }
            PDFDict dict1 = ((PDFDict) this.mResourceDict[Resource.GetDictKeyName(resType)]);
            if (dict1 == null)
            {
                return;
            }
            dict1.Remove(name);
        }

        private void ScanResourceType(PDFDict dict, Type resType)
        {
            Resource resource1;
            if (dict == null)
            {
                return;
            }
            foreach (DictionaryEntry entry1 in dict)
            {
                resource1 = this.mResourceDict.Doc.Resources[((PDFObject) entry1.Value), resType];
                if (resource1 == null)
                {
                    continue;
                }
                if (resource1.Resources != null)
                {
                    resource1.Resources.Parent = this;
                }
                base.Add(((PDFName) entry1.Key).Value, resource1);
            }
        }


        // Properties
        public Document Doc
        {
            get
            {
                return this.mParentDict.Doc;
            }
        }

        public DocResourceSet Parent
        {
            get
            {
                return ((DocResourceSet) this.mParent.Target);
            }
            set
            {
                this.mParent.Target = value;
            }
        }


        // Fields
        private WeakReference mParent;
        private PDFDict mParentDict;
        private PDFDict mResourceDict;
    }
}


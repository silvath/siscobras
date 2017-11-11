namespace Altsoft.PDFO
{
    using System;

    public class TreeRoot : Resource
    {
        // Methods
        public TreeRoot(PDFDirect direct) : base(direct)
        {
            this.mChildren = null;
            this.mParentTree = null;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new TreeRoot(direct);
        }


        // Properties
        public StructureElementCollection Children
        {
            get
            {
                if (this.mChildren != null)
                {
                    return this.mChildren;
                }
                PDFDirect direct1 = (this.Dict["K"] as PDFDirect);
                if (direct1 != null)
                {
                    this.mChildren = new StructureElementCollection(direct1, true);
                }
                return this.mChildren;
            }
            set
            {
                this.Dict["K"] = this.mChildren.mDirect;
            }
        }

        public NameTree IDTree
        {
            get
            {
                if (this.mIDTree != null)
                {
                    return this.mIDTree;
                }
                PDFDirect direct1 = (this.Dict["IDTree"] as PDFDirect);
                if (direct1 != null)
                {
                    this.mIDTree = new NameTree(this.Dict, "IDTree", 2147483647);
                }
                return this.mIDTree;
            }
            set
            {
                this.Dict["IDTree"] = this.mIDTree.Dict;
            }
        }

        public NumberTree ParentTree
        {
            get
            {
                if (this.mParentTree != null)
                {
                    return this.mParentTree;
                }
                PDFDirect direct1 = (this.Dict["ParentTree"] as PDFDirect);
                if (direct1 != null)
                {
                    this.mParentTree = new NumberTree(this.Dict, "ParentTree", 2147483647);
                }
                return this.mParentTree;
            }
            set
            {
                this.Dict["ParentTree"] = this.mParentTree.Dict;
            }
        }

        public int ParentTreeNextKey
        {
            get
            {
                PDFInteger integer1 = (this.Dict["ParentTreeNextKey"] as PDFInteger);
                if (integer1 == null)
                {
                    if (this.mParentTree == null)
                    {
                        return 0;
                    }
                    return this.mParentTree.Count;
                }
                return integer1.Int32Value;
            }
            set
            {
                this.Dict["ParentTreeNextKey"] = Library.CreateInteger(((long) value));
            }
        }


        // Fields
        private StructureElementCollection mChildren;
        private NameTree mIDTree;
        private NumberTree mParentTree;
        public const string Type = "StructTreeRoot";
    }
}


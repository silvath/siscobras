namespace Altsoft.PDFO
{
    using System;

    public class ActionHide : Action
    {
        // Methods
        public ActionHide(PDFDirect direct) : base(direct)
        {
            this.mAnnots = null;
        }

        public static ActionHide Create(AnnotationVarCollection annots)
        {
            ActionHide hide1 = ActionHide.Create(true);
            hide1.Annotations = annots;
            return hide1;
        }

        private static ActionHide Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Hide");
            ActionHide hide1 = (Resources.Get(dict1, typeof(ActionHide)) as ActionHide);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return hide1;
        }

        public static ActionHide Create(AnnotationVarCollection annots, bool hide)
        {
            ActionHide hide1 = ActionHide.Create(true);
            hide1.Annotations = annots;
            hide1.Hide = hide;
            return hide1;
        }

        public static ActionHide Create(bool indirect, AnnotationVar annot)
        {
            ActionHide hide1 = ActionHide.Create(indirect);
            AnnotationVarCollection collection1 = new AnnotationVarCollection(hide1.Dict, "T", true);
            collection1.Add(annot);
            hide1.Annotations = collection1;
            hide1.Hide = true;
            return hide1;
        }

        public static ActionHide Create(bool indirect, AnnotationVarCollection annots)
        {
            ActionHide hide1 = ActionHide.Create(indirect);
            hide1.Annotations = annots;
            return hide1;
        }

        public static ActionHide Create(bool indirect, AnnotationVarCollection annots, bool hide)
        {
            ActionHide hide1 = ActionHide.Create(indirect);
            hide1.Annotations = annots;
            hide1.Hide = hide;
            return hide1;
        }


        // Properties
        public AnnotationVarCollection Annotations
        {
            get
            {
                if (this.mAnnots != null)
                {
                    return this.mAnnots;
                }
                return new AnnotationVarCollection(this.Dict, "T", true);
            }
            set
            {
                this.mAnnots = value;
                this.Dict["T"] = value.mBaseDict[value.mBaseKeyName];
            }
        }

        public bool Hide
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["H"] as PDFBoolean);
                if (flag1 == null)
                {
                    return true;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["H"] = Library.CreateBoolean(value);
            }
        }


        // Fields
        private AnnotationVarCollection mAnnots;
        public const string Type = "Hide";
    }
}


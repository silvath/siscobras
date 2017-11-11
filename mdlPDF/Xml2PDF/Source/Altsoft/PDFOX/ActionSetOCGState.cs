namespace Altsoft.PDFO
{
    using System;

    public class ActionSetOCGState : Action
    {
        // Methods
        public ActionSetOCGState(PDFDirect direct) : base(direct)
        {
            this.mGroupState = null;
        }

        public static ActionSetOCGState Create(GroupStateCollection GSC)
        {
            ActionSetOCGState state1 = ActionSetOCGState.Create(true);
            state1.GroupStateCollection = GSC;
            return state1;
        }

        private static ActionSetOCGState Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("SetOCGState");
            ActionSetOCGState state1 = (Resources.Get(dict1, typeof(ActionSetOCGState)) as ActionSetOCGState);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return state1;
        }

        public static ActionSetOCGState Create(GroupStateCollection GSC, bool preserveRB)
        {
            ActionSetOCGState state1 = ActionSetOCGState.Create(true);
            state1.GroupStateCollection = GSC;
            state1.preserveRB = preserveRB;
            return state1;
        }

        public static ActionSetOCGState Create(bool indirect, GroupStateCollection GSC)
        {
            ActionSetOCGState state1 = ActionSetOCGState.Create(indirect);
            state1.GroupStateCollection = GSC;
            return state1;
        }

        public static ActionSetOCGState Create(bool indirect, GroupStateCollection GSC, bool preserveRB)
        {
            ActionSetOCGState state1 = ActionSetOCGState.Create(indirect);
            state1.GroupStateCollection = GSC;
            state1.preserveRB = preserveRB;
            return state1;
        }


        // Properties
        public GroupStateCollection GroupStateCollection
        {
            get
            {
                if (this.mGroupState != null)
                {
                    return null;
                }
                return new GroupStateCollection(this.Dict, "State", false);
            }
            set
            {
                this.mGroupState = value;
                this.Dict["State"] = value.mBaseDict[value.mBaseKeyName];
            }
        }

        public bool preserveRB
        {
            get
            {
                PDFBoolean flag1 = (this.Dict["preserveRB"] as PDFBoolean);
                if (flag1 == null)
                {
                    return true;
                }
                return flag1.Value;
            }
            set
            {
                this.Dict["preserveRB"] = Library.CreateBoolean(value);
            }
        }


        // Fields
        private GroupStateCollection mGroupState;
        public const string Type = "SetOCGState";
    }
}


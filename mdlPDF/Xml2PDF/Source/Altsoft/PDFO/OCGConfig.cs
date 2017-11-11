namespace Altsoft.PDFO
{
    using System;

    public class OCGConfig : Resource
    {
        // Methods
        public OCGConfig(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new OCGConfig(direct);
        }


        // Properties
        public EContentState BaseState
        {
            get
            {
                PDFName name1 = (this.Dict["BaseState"] as PDFName);
                if (name1 == null)
                {
                    return EContentState.ON;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_005D;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "On")
                {
                    if (text1 == "Off")
                    {
                        goto Label_0059;
                    }
                    if (text1 == "Unchanged")
                    {
                        goto Label_005B;
                    }
                    goto Label_005D;
                }
                return EContentState.ON;
            Label_0059:
                return EContentState.OFF;
            Label_005B:
                return EContentState.Unchanged;
            Label_005D:
                throw new Exception("Unknown content state");
            }
            set
            {
                string text1 = "";
                EContentState state1 = value;
                switch (state1)
                {
                    case EContentState.ON:
                    {
                        text1 = "On";
                        goto Label_0032;
                    }
                    case EContentState.OFF:
                    {
                        text1 = "Off";
                        goto Label_0032;
                    }
                    case EContentState.Unchanged:
                    {
                        goto Label_002C;
                    }
                }
                goto Label_0032;
            Label_002C:
                text1 = "Unchanged";
            Label_0032:
                this.Dict["BaseState"] = Library.CreateName(text1);
            }
        }

        public NameList ContentStates
        {
            get
            {
                if (this.mContStates != null)
                {
                    return this.mContStates;
                }
                PDFDict dict1 = (this.Dict["Intent"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return new NameList(dict1, "Intent", true);
            }
            set
            {
                this.mContStates = value;
            }
        }

        public string Creator
        {
            get
            {
                PDFString text1 = (this.Dict["Creator"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["Creator"] = Library.CreateString(value);
            }
        }

        public EListMode ListMode
        {
            get
            {
                PDFName name1 = (this.Dict["ListMode"] as PDFName);
                if (name1 == null)
                {
                    return EListMode.AllPages;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_004E;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "AllPages")
                {
                    if (text1 == "VisiblePages")
                    {
                        goto Label_004C;
                    }
                    goto Label_004E;
                }
                return EListMode.AllPages;
            Label_004C:
                return EListMode.VisiblePages;
            Label_004E:
                throw new Exception("Unknown list mode");
            }
            set
            {
                string text1 = "";
                EListMode mode1 = value;
                switch (mode1)
                {
                    case EListMode.AllPages:
                    {
                        text1 = "AllPages";
                        goto Label_0026;
                    }
                    case EListMode.VisiblePages:
                    {
                        goto Label_0020;
                    }
                }
                goto Label_0026;
            Label_0020:
                text1 = "VisiblePages";
            Label_0026:
                this.Dict["ListMode"] = Library.CreateName(text1);
            }
        }

        public string Name
        {
            get
            {
                PDFString text1 = (this.Dict["Name"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["Name"] = Library.CreateString(value);
            }
        }

        public OCGCollection OptContentCollectionOff
        {
            get
            {
                if (this.mOptContentOff != null)
                {
                    return null;
                }
                PDFObject obj1 = this.Dict["Off"];
                if (obj1 == null)
                {
                    return null;
                }
                return new OCGCollection(this.Dict, "Off", false);
            }
            set
            {
                this.mOptContentOff = value;
                this.Dict["Off"] = this.mOptContentOff.mBaseDict;
            }
        }

        public OCGCollection OptContentCollectionOn
        {
            get
            {
                if (this.mOptContentOn != null)
                {
                    return null;
                }
                PDFObject obj1 = this.Dict["On"];
                if (obj1 == null)
                {
                    return null;
                }
                return new OCGCollection(this.Dict, "On", false);
            }
            set
            {
                this.mOptContentOn = value;
                this.Dict["On"] = this.mOptContentOn.mBaseDict;
            }
        }

        public OCGArray Order
        {
            get
            {
                if (this.mOrder != null)
                {
                    return this.mOrder;
                }
                PDFDict dict1 = (this.Dict["Order"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return new OCGArray(dict1, true);
            }
            set
            {
                this.mOrder = value;
                this.Dict["Order"] = value.mDirect;
            }
        }

        public OCGArray RBGroups
        {
            get
            {
                if (this.mRBGroups != null)
                {
                    return this.mRBGroups;
                }
                PDFDict dict1 = (this.Dict["RBGroups"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return new OCGArray(dict1, false);
            }
            set
            {
                this.mRBGroups = value;
                this.Dict["RBGroups"] = value.mDirect;
            }
        }

        public AppUsageCollection UsageCollection
        {
            get
            {
                if (this.mUsageColl != null)
                {
                    return this.mUsageColl;
                }
                PDFDict dict1 = (this.Dict["AS"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return new AppUsageCollection(dict1, "AS", false);
            }
            set
            {
                this.mUsageColl = value;
            }
        }


        // Fields
        private NameList mContStates;
        private OCGCollection mOptContentOff;
        private OCGCollection mOptContentOn;
        private OCGArray mOrder;
        private OCGArray mRBGroups;
        private AppUsageCollection mUsageColl;
    }
}


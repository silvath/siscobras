namespace Altsoft.PDFO
{
    using System;

    public class UserInfo : Resource
    {
        // Methods
        public UserInfo(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new UserInfo(direct);
        }


        // Properties
        public NameList Users
        {
            get
            {
                if (this.mUsers != null)
                {
                    return this.mUsers;
                }
                PDFDict dict1 = (this.Dict["Name"] as PDFDict);
                return new NameList(dict1, "Name", true);
            }
            set
            {
                this.mUsers = value;
            }
        }

        public EUser UserType
        {
            get
            {
                PDFName name1 = (this.Dict["Type"] as PDFName);
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_0058;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "Ind")
                {
                    if (text1 == "Ttl")
                    {
                        goto Label_0054;
                    }
                    if (text1 == "Org")
                    {
                        goto Label_0056;
                    }
                    goto Label_0058;
                }
                return EUser.Individual;
            Label_0054:
                return EUser.Title;
            Label_0056:
                return EUser.Organisation;
            Label_0058:
                throw new Exception("Illegal user type state");
            }
            set
            {
                string text1 = "Ttl";
                EUser user1 = value;
                switch (user1)
                {
                    case EUser.Individual:
                    {
                        text1 = "Ind";
                        goto Label_0032;
                    }
                    case EUser.Title:
                    {
                        text1 = "Ttl";
                        goto Label_0032;
                    }
                    case EUser.Organisation:
                    {
                        goto Label_002C;
                    }
                }
                goto Label_0032;
            Label_002C:
                text1 = "Org";
            Label_0032:
                this.Dict["Type"] = Library.CreateName(text1);
            }
        }


        // Fields
        private NameList mUsers;
    }
}


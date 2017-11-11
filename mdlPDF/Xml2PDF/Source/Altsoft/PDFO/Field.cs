namespace Altsoft.PDFO
{
    using System;

    public class Field : Resource
    {
        // Methods
        public Field(PDFDirect direct) : base(direct)
        {
            this.mFieldKids = null;
        }

        public static Resource Factory(PDFDirect direct)
        {
            if (direct == null)
            {
                return null;
            }
            PDFDict dict1 = (direct as PDFDict);
            int num1 = 0;
            if (!(dict1["FT"] is PDFName))
            {
                while (((dict1["Parent"] is PDFDict) && !(dict1["FT"] is PDFName)))
                {
                    if ((dict1["Ff"] is PDFInteger))
                    {
                        num1 |= (dict1["Ff"] as PDFInteger).Int32Value;
                    }
                    dict1 = (dict1["Parent"] as PDFDict);
                }
            }
            PDFName name1 = (dict1["FT"] as PDFName);
            if (name1 == null)
            {
                return null;
            }
            string text1 = name1.Value;
            if (text1 == null)
            {
                goto Label_011C;
            }
            text1 = string.IsInterned(text1);
            if (text1 != "Btn")
            {
                if (text1 == "Tx")
                {
                    goto Label_0107;
                }
                if (text1 == "Ch")
                {
                    goto Label_010E;
                }
                if (text1 == "Sig")
                {
                    goto Label_0115;
                }
                goto Label_011C;
            }
            if ((num1 & 65536) != 0)
            {
                return new FieldPushButton(direct);
            }
            if ((num1 & 32768) != 0)
            {
                return new FieldRadioButton(direct);
            }
            return new FieldCheckBox(direct);
        Label_0107:
            return new FieldText(direct);
        Label_010E:
            return new FieldChoice(direct);
        Label_0115:
            return new FieldSignature(direct);
        Label_011C:
            return null;
        }


        // Properties
        public AnnotationAdditionalActions AdditionalActions
        {
            get
            {
                if (this.mAdditionalActions != null)
                {
                    return this.mAdditionalActions;
                }
                PDFDict dict1 = (this.Dict["AA"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(AnnotationAdditionalActions)) as AnnotationAdditionalActions);
            }
            set
            {
                this.mAdditionalActions = value;
                this.Dict["AA"] = this.mAdditionalActions.Dict;
            }
        }

        public string AlternateName
        {
            get
            {
                PDFString text1 = (this.Dict["TU"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["TU"] = Library.CreateString(value);
            }
        }

        public EFieldFlags FieldFlags
        {
            get
            {
                PDFInteger integer1 = (this.Dict["Ff"] as PDFInteger);
                if (integer1 == null)
                {
                    return EFieldFlags.None;
                }
                return ((EFieldFlags) integer1.Int32Value);
            }
            set
            {
                this.Dict["Ff"] = Library.CreateInteger(((long) value));
            }
        }

        public EFieldType FieldType
        {
            get
            {
                string text1 = (this.Dict["FT"] as PDFName).Value;
                if (text1 == null)
                {
                    goto Label_0065;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "Btn")
                {
                    if (text1 == "Tx")
                    {
                        goto Label_005F;
                    }
                    if (text1 == "Ch")
                    {
                        goto Label_0061;
                    }
                    if (text1 == "Sig")
                    {
                        goto Label_0063;
                    }
                    goto Label_0065;
                }
                return EFieldType.Button;
            Label_005F:
                return EFieldType.Text;
            Label_0061:
                return EFieldType.Choice;
            Label_0063:
                return EFieldType.Signature;
            Label_0065:
                throw new Exception("Unknown field type");
            }
            set
            {
                string text1 = "";
                EFieldType type1 = value;
                switch (type1)
                {
                    case EFieldType.Button:
                    {
                        text1 = "Btn";
                        goto Label_003E;
                    }
                    case EFieldType.Text:
                    {
                        text1 = "Tx";
                        goto Label_003E;
                    }
                    case EFieldType.Choice:
                    {
                        text1 = "Ch";
                        goto Label_003E;
                    }
                    case EFieldType.Signature:
                    {
                        goto Label_0038;
                    }
                }
                goto Label_003E;
            Label_0038:
                text1 = "Sig";
            Label_003E:
                this.Dict["FT"] = Library.CreateName(text1);
            }
        }

        public FieldKids Kids
        {
            get
            {
                if (this.mFieldKids == null)
                {
                    this.mFieldKids = new FieldKids(this.Dict, "Kids");
                }
                return this.mFieldKids;
            }
            set
            {
                this.mFieldKids = value;
                this.Dict["Kids"] = this.mFieldKids.mBaseDict;
            }
        }

        public string MappingName
        {
            get
            {
                PDFString text1 = (this.Dict["TM"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["TM"] = Library.CreateString(value);
            }
        }

        public Field Parent
        {
            get
            {
                PDFDict dict1 = (this.Dict["Parent"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(Field)) as Field);
            }
            set
            {
                this.Dict["Parent"] = value.Dict;
            }
        }

        public string PartialName
        {
            get
            {
                PDFString text1 = (this.Dict["T"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["T"] = Library.CreateString(value);
            }
        }


        // Fields
        private AnnotationAdditionalActions mAdditionalActions;
        private FieldKids mFieldKids;
    }
}


namespace Altsoft.PDFO
{
    using System;

    public class SignatureReference : Resource
    {
        // Methods
        public SignatureReference(PDFDirect direct) : base(direct)
        {
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new SignatureReference(direct);
        }


        // Properties
        public PDFObject Data
        {
            get
            {
                return this.Dict["Data"];
            }
            set
            {
                this.Dict["Data"] = value.Direct;
            }
        }

        public IntPair DigestLocation
        {
            get
            {
                PDFArray array1 = (this.Dict["DigestLocation"] as PDFArray);
                if (array1 == null)
                {
                    return null;
                }
                return (Resources.Get(array1, typeof(IntPair)) as IntPair);
            }
            set
            {
                this.Dict["DigestLocation"] = value.Direct;
            }
        }

        public EDigestMethod DigestMethod
        {
            get
            {
                PDFName name1 = (this.Dict["DigestMethod"] as PDFName);
                if (name1 == null)
                {
                    return EDigestMethod.MD5;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_004E;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "MD5")
                {
                    if (text1 == "SHA1")
                    {
                        goto Label_004C;
                    }
                    goto Label_004E;
                }
                return EDigestMethod.MD5;
            Label_004C:
                return EDigestMethod.SHA1;
            Label_004E:
                throw new Exception("Unknown digest method");
            }
            set
            {
                string text1 = "";
                EDigestMethod method1 = value;
                switch (method1)
                {
                    case EDigestMethod.MD5:
                    {
                        text1 = "MD5";
                        goto Label_0026;
                    }
                    case EDigestMethod.SHA1:
                    {
                        goto Label_0020;
                    }
                }
                goto Label_0026;
            Label_0020:
                text1 = "SHA1";
            Label_0026:
                this.Dict["DigestMethod"] = Library.CreateName(text1);
            }
        }

        public string DigestValue
        {
            get
            {
                return (this.Dict["DigestValue"] as PDFString).Value;
            }
            set
            {
                this.Dict["DigestValue"] = Library.CreateString(value);
            }
        }

        public DocMDP DocMDPTransformParams
        {
            get
            {
                if (this.TransformMethod != ETransformMethod.DocMDP)
                {
                    return null;
                }
                PDFDict dict1 = (this.Dict["TransformParams"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(DocMDP)) as DocMDP);
            }
            set
            {
                if (this.TransformMethod != ETransformMethod.DocMDP)
                {
                    return;
                }
                this.Dict["TransformParams"] = value.Dict;
            }
        }

        public FieldMDP FieldTransformParams
        {
            get
            {
                if (this.TransformMethod != ETransformMethod.FieldMDP)
                {
                    return null;
                }
                PDFDict dict1 = (this.Dict["TransformParams"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(FieldMDP)) as FieldMDP);
            }
            set
            {
                if (this.TransformMethod != ETransformMethod.FieldMDP)
                {
                    return;
                }
                this.Dict["TransformParams"] = value.Dict;
            }
        }

        public ETransformMethod TransformMethod
        {
            get
            {
                string text1 = (this.Dict["TransformMethod"] as PDFName).Value;
                if (text1 == null)
                {
                    goto Label_0065;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "DocMDP")
                {
                    if (text1 == "UR")
                    {
                        goto Label_005F;
                    }
                    if (text1 == "FiledMDP")
                    {
                        goto Label_0061;
                    }
                    if (text1 == "Identity")
                    {
                        goto Label_0063;
                    }
                    goto Label_0065;
                }
                return ETransformMethod.DocMDP;
            Label_005F:
                return ETransformMethod.UR;
            Label_0061:
                return ETransformMethod.FieldMDP;
            Label_0063:
                return ETransformMethod.Identity;
            Label_0065:
                throw new Exception("Unknown transform method");
            }
            set
            {
                string text1 = "";
                ETransformMethod method1 = value;
                switch (method1)
                {
                    case ETransformMethod.DocMDP:
                    {
                        text1 = "DocMDP";
                        goto Label_003E;
                    }
                    case ETransformMethod.UR:
                    {
                        text1 = "UR";
                        goto Label_003E;
                    }
                    case ETransformMethod.FieldMDP:
                    {
                        text1 = "FiledMDP";
                        goto Label_003E;
                    }
                    case ETransformMethod.Identity:
                    {
                        goto Label_0038;
                    }
                }
                goto Label_003E;
            Label_0038:
                text1 = "Identity";
            Label_003E:
                this.Dict["TransformMethod"] = Library.CreateName(text1);
            }
        }

        public string Type
        {
            get
            {
                return "SigRef";
            }
        }

        public UR URTransformParams
        {
            get
            {
                if (this.TransformMethod != ETransformMethod.UR)
                {
                    return null;
                }
                PDFDict dict1 = (this.Dict["TransformParams"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(UR)) as UR);
            }
            set
            {
                if (this.TransformMethod != ETransformMethod.UR)
                {
                    return;
                }
                this.Dict["TransformParams"] = value.Dict;
            }
        }

    }
}


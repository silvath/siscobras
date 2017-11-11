namespace Altsoft.PDFO
{
    using System;

    public class MediaPermissions : Resource
    {
        // Methods
        public MediaPermissions(PDFDirect direct) : base(direct)
        {
        }

        public static MediaPermissions Create()
        {
            return MediaPermissions.Create(true);
        }

        public static MediaPermissions Create(ETempFileOpt tfo)
        {
            return MediaPermissions.Create(true, tfo);
        }

        public static MediaPermissions Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return new MediaPermissions(dict1);
        }

        public static MediaPermissions Create(bool indirect, ETempFileOpt tfo)
        {
            MediaPermissions permissions1 = MediaPermissions.Create(indirect);
            permissions1.TempFileOption = tfo;
            return permissions1;
        }

        public static Resource Factory(PDFDirect direct)
        {
            return new MediaPermissions(direct);
        }


        // Properties
        public ETempFileOpt TempFileOption
        {
            get
            {
                PDFString text1 = (this.Dict["TF"] as PDFString);
                if (text1 == null)
                {
                    return ETempFileOpt.TempNever;
                }
                string text2 = text1.Value;
                if (text2 == null)
                {
                    goto Label_005D;
                }
                text2 = string.IsInterned(text2);
                if (text2 != "TEMPEXTRACT")
                {
                    if (text2 == "TEMPACCESS")
                    {
                        goto Label_0059;
                    }
                    if (text2 == "TEMPALWAYS")
                    {
                        goto Label_005B;
                    }
                    goto Label_005D;
                }
                return ETempFileOpt.TempExtract;
            Label_0059:
                return ETempFileOpt.TempAccess;
            Label_005B:
                return ETempFileOpt.TempAlways;
            Label_005D:
                return ETempFileOpt.TempNever;
            }
            set
            {
                string text1 = "";
                ETempFileOpt opt1 = value;
                switch (opt1)
                {
                    case ETempFileOpt.TempExtract:
                    {
                        text1 = "TEMPEXTRACT";
                        goto Label_003C;
                    }
                    case ETempFileOpt.TempAccess:
                    {
                        text1 = "TEMPACCESS";
                        goto Label_003C;
                    }
                    case ETempFileOpt.TempAlways:
                    {
                        text1 = "TEMPALWAYS";
                        goto Label_003C;
                    }
                }
                text1 = "TempNever";
            Label_003C:
                this.Dict["TF"] = Library.CreateString(text1);
            }
        }


        // Fields
        public const string Type = "MediaPermissions";
    }
}


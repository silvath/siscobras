namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationFileAttachment : AnnotationMarkup
    {
        // Methods
        public AnnotationFileAttachment(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationFileAttachment Create(Rect rect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("FileAttachment");
            AnnotationFileAttachment attachment1 = (Resources.Get(dict1, typeof(AnnotationFileAttachment)) as AnnotationFileAttachment);
            attachment1.Rect = rect;
            Library.CreateIndirect(dict1);
            return attachment1;
        }

        public static AnnotationFileAttachment Create(Rect rect, FileSpec file)
        {
            AnnotationFileAttachment attachment1 = AnnotationFileAttachment.Create(rect);
            attachment1.FileSpecification = file;
            return attachment1;
        }

        public static AnnotationFileAttachment Create(Rect rect, string filename)
        {
            AnnotationFileAttachment attachment1 = AnnotationFileAttachment.Create(rect);
            attachment1.FileSpecification = new FileSpec(Library.CreateString(filename));
            return attachment1;
        }

        public static AnnotationFileAttachment Create(Rect rect, FileSpec file, string iconname)
        {
            AnnotationFileAttachment attachment1 = AnnotationFileAttachment.Create(rect);
            attachment1.FileSpecification = file;
            attachment1.IconName = iconname;
            return attachment1;
        }


        // Properties
        public FileSpec FileSpecification
        {
            get
            {
                return (Resources.Get(this.Dict["FS"], typeof(FileSpec)) as FileSpec);
            }
            set
            {
                this.Dict["FS"] = Library.CreateString(value.Path);
            }
        }

        public string IconName
        {
            get
            {
                PDFName name1 = (this.Dict["Name"] as PDFName);
                if (name1 == null)
                {
                    return "Draft";
                }
                return name1.Value;
            }
            set
            {
                this.Dict["Name"] = Library.CreateName(value);
            }
        }


        // Fields
        public const string SubType = "FileAttachment";
    }
}


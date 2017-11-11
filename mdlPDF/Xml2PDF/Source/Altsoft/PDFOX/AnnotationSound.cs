namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationSound : AnnotationMarkup
    {
        // Methods
        public AnnotationSound(PDFDict dict) : base(dict)
        {
        }

        private static AnnotationSound Create(Rect rect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Sound");
            AnnotationSound sound1 = (Resources.Get(dict1, typeof(AnnotationSound)) as AnnotationSound);
            sound1.Rect = rect;
            Library.CreateIndirect(dict1);
            return sound1;
        }

        public static AnnotationSound Create(Rect rect, Sound sound)
        {
            AnnotationSound sound1 = AnnotationSound.Create(rect);
            sound1.sound = sound;
            return sound1;
        }

        public static AnnotationSound Create(Rect rect, Sound sound, string iconname)
        {
            AnnotationSound sound1 = AnnotationSound.Create(rect);
            sound1.SoundIcon = iconname;
            sound1.sound = sound;
            return sound1;
        }


        // Properties
        public Sound sound
        {
            get
            {
                PDFDict dict1 = (this.Dict["Sound"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(Sound)) as Sound);
            }
            set
            {
                this.Dict["Sound"] = value.Direct;
            }
        }

        public string SoundIcon
        {
            get
            {
                PDFName name1 = (this.Dict["Name"] as PDFName);
                if (name1 == null)
                {
                    return "Speaker";
                }
                return name1.Value;
            }
            set
            {
                this.Dict["Sound"] = Library.CreateName(value);
            }
        }


        // Fields
        public const string SubType = "Sound";
    }
}


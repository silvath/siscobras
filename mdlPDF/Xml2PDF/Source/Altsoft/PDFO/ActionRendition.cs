namespace Altsoft.PDFO
{
    using System;
    using System.IO;

    public class ActionRendition : Action
    {
        // Methods
        public ActionRendition(PDFDirect direct) : base(direct)
        {
        }

        private static ActionRendition Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Rendition");
            ActionRendition rendition1 = (Resources.Get(dict1, typeof(ActionRendition)) as ActionRendition);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return rendition1;
        }

        public static ActionRendition Create(string JS)
        {
            ActionRendition rendition1 = ActionRendition.Create(true);
            rendition1.JavaScriptScript = JS;
            return rendition1;
        }

        public static ActionRendition Create(bool indirect, string JS)
        {
            ActionRendition rendition1 = ActionRendition.Create(indirect);
            rendition1.JavaScriptScript = JS;
            return rendition1;
        }

        public static ActionRendition Create(EPlayOperation operation, Rendition rend, AnnotationScreen AS)
        {
            ActionRendition rendition1 = ActionRendition.Create(true);
            rendition1.Operation = operation;
            rendition1.Redition = rend;
            rendition1.ScreenAnnotation = AS;
            return rendition1;
        }

        public static ActionRendition Create(EPlayOperation operation, Rendition rend, AnnotationScreen AS, string JS)
        {
            ActionRendition rendition1 = ActionRendition.Create(true);
            rendition1.Operation = operation;
            rendition1.Redition = rend;
            rendition1.ScreenAnnotation = AS;
            rendition1.JavaScriptScript = JS;
            return rendition1;
        }

        public static ActionRendition Create(bool indirect, EPlayOperation operation, Rendition rend, AnnotationScreen AS)
        {
            ActionRendition rendition1 = ActionRendition.Create(indirect);
            rendition1.Operation = operation;
            rendition1.Redition = rend;
            rendition1.ScreenAnnotation = AS;
            return rendition1;
        }

        public static ActionRendition Create(bool indirect, EPlayOperation operation, Rendition rend, AnnotationScreen AS, string JS)
        {
            ActionRendition rendition1 = ActionRendition.Create(indirect);
            rendition1.Operation = operation;
            rendition1.Redition = rend;
            rendition1.ScreenAnnotation = AS;
            rendition1.JavaScriptScript = JS;
            return rendition1;
        }


        // Properties
        public string JavaScriptScript
        {
            get
            {
                string text2;
                PDFObject obj1 = this.Dict["JS"];
                if (obj1 == null)
                {
                    return null;
                }
                if ((obj1 is PDFString))
                {
                    return (obj1 as PDFString).Value;
                }
                Stream stream1 = (obj1 as PDFStream).Decode();
                byte[] numArray1 = new byte[65536];
                char[] chArray1 = new char[65536];
                string text1 = null;
                while ((stream1.Read(numArray1, 0, 65536) != 0))
                {
                    numArray1.CopyTo(chArray1, 0);
                    text2 = new string(chArray1);
                    text1 = text1 + text2;
                }
                return text1;
            }
            set
            {
                this.Dict["JS"] = Library.CreateString(value);
            }
        }

        public EPlayOperation Operation
        {
            get
            {
                PDFInteger integer1 = (this.Dict["OP"] as PDFInteger);
                if (integer1 == null)
                {
                    return EPlayOperation.notspecified;
                }
                return ((EPlayOperation) ((int) integer1.Value));
            }
            set
            {
                this.Dict["OP"] = Library.CreateInteger(((long) value));
            }
        }

        public Rendition Redition
        {
            get
            {
                PDFDict dict1 = (this.Dict["R"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(Rendition)) as Rendition);
            }
            set
            {
                this.Dict["R"] = value.Dict;
            }
        }

        public AnnotationScreen ScreenAnnotation
        {
            get
            {
                PDFDict dict1 = (this.Dict["AN"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(AnnotationScreen)) as AnnotationScreen);
            }
            set
            {
                this.Dict["AN"] = value.Dict;
            }
        }


        // Fields
        public const string Type = "Rendition";
    }
}


namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;
    using System.IO;

    public class XObjectForm : XObject
    {
        // Methods
        public XObjectForm(PDFDirect d) : base(d)
        {
            this.mResources = null;
            this.mLastModified = null;
        }

        public static XObjectForm Create()
        {
            int num1;
            string text1 = "/DeviceRGB cs 0.1 1.0 1.0 sc 0.0 4.00 40.00 20.00 re B";
            byte[] numArray1 = new byte[text1.Length];
            for (num1 = 0; (num1 < text1.Length); num1 += 1)
            {
                numArray1[num1] = ((byte) text1[num1]);
            }
            MemoryStream stream1 = new MemoryStream(numArray1);
            PDFStream stream2 = Library.CreateStream(stream1);
            stream2.Dict["Subtype"] = Library.CreateName("Form");
            XObjectForm form1 = new XObjectForm(stream2);
            form1.BBox = new Rect(0f, 0f, 50f, 50f);
            form1.CTM = new CTM(1f, 0f, 0f, 1f, 0f, 0f);
            return form1;
        }

        public static XObjectForm Create(PDFStream str, Rect bbox)
        {
            str.Dict["Subtype"] = Library.CreateName("Form");
            XObjectForm form1 = (Resources.Get(str, typeof(XObjectForm)) as XObjectForm);
            form1.BBox = bbox;
            return form1;
        }

        public static XObjectForm Create(string StrBody, Rect BBox)
        {
            int num1;
            byte[] numArray1 = new byte[StrBody.Length];
            for (num1 = 0; (num1 < StrBody.Length); num1 += 1)
            {
                numArray1[num1] = ((byte) StrBody[num1]);
            }
            MemoryStream stream1 = new MemoryStream(numArray1);
            PDFStream stream2 = Library.CreateStream(stream1);
            stream2.Dict["Subtype"] = Library.CreateName("Form");
            XObjectForm form1 = new XObjectForm(stream2);
            form1.BBox = BBox;
            form1.CTM = new CTM(1f, 0f, 0f, 1f, 0f, 0f);
            return form1;
        }


        // Properties
        public Rect BBox
        {
            get
            {
                double[] numArray1;
                if (this.mBBox == null)
                {
                    numArray1 = new double[4];
                    this.mBBox = new PDFRect(this.Dict, "BBox", numArray1);
                }
                return this.mBBox;
            }
            set
            {
                this.BBox.Set(value);
            }
        }

        public CTM CTM
        {
            get
            {
                double[] numArray1;
                if (this.mCTM == null)
                {
                    numArray1 = new double[6];
                    numArray1[2] = 1f;
                    numArray1[5] = 1f;
                    this.mCTM = new PDFCTM(this.Dict, "Matrix", numArray1);
                }
                return this.mCTM;
            }
            set
            {
                this.CTM.Set(value);
            }
        }

        public XObjectGroup Group
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Date LastModified
        {
            get
            {
                PDFString text1;
                if (this.mLastModified == null)
                {
                    text1 = (this.Dict["LastModified"] as PDFString);
                    this.mLastModified = new Date(text1);
                }
                return this.mLastModified;
            }
            set
            {
                this.Dict["LastModified"] = PDF.O(value.String);
                this.mLastModified = null;
            }
        }

        public override DocResourceSet Resources
        {
            get
            {
                if (this.mResources != null)
                {
                    return this.mResources;
                }
                if (this.Dict["Resources"] == null)
                {
                    return null;
                }
                return new DocResourceSet(((PDFDict) this.Dict["Resources"]), this.Dict, null);
            }
        }


        // Fields
        private PDFRect mBBox;
        private PDFCTM mCTM;
        private Date mLastModified;
        private DocResourceSet mResources;
        public const string SubType = "Form";
    }
}


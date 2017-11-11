namespace Altsoft.PDFP
{
    using Altsoft.Common;
    using Altsoft.PDFO;
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.IO;

    public abstract class PDFPForeignObject
    {
        // Methods
        public PDFPForeignObject()
        {
            this.FromSvg = false;
            this.SetToNotFound();
        }

        public PDFPForeignObject(string resID)
        {
            this.FromSvg = false;
            this.SetToNotFound();
            this.resourceID = resID;
        }

        public PDFPForeignObject(int type, Stream stream)
        {
            this.FromSvg = false;
            this.mType = type;
            this.m_Width = NaNf;
            this.m_Height = NaNf;
            this.Init(type, stream);
        }

        public PDFPForeignObject(int type, Stream stream, string resID)
        {
            this.FromSvg = false;
            this.mType = type;
            this.m_Width = NaNf;
            this.m_Height = NaNf;
            this.resourceID = resID;
            this.Init(type, stream);
        }

        protected int ContentDescription2Type(string description)
        {
            if ((description == null) || (string.Empty == description))
            {
                return 1;
            }
            string text1 = description.ToLower();
            if (text1.EndsWith("swf"))
            {
                return 2;
            }
            if (text1.EndsWith("aiff"))
            {
                return 7;
            }
            if (text1.EndsWith("au"))
            {
                return 8;
            }
            if (text1.EndsWith("avi"))
            {
                return 9;
            }
            if (text1.EndsWith("mid"))
            {
                return 10;
            }
            if (text1.EndsWith("mov"))
            {
                return 11;
            }
            if (text1.EndsWith("mp3"))
            {
                return 12;
            }
            if (text1.EndsWith("mp4"))
            {
                return 13;
            }
            if ((text1.EndsWith("mpeg") || text1.EndsWith("mpg")) || text1.EndsWith("mpe"))
            {
                return 14;
            }
            if (text1.EndsWith("smil"))
            {
                return 15;
            }
            if (text1.EndsWith("pdf"))
            {
                return 3;
            }
            if (text1.EndsWith("ps"))
            {
                return 4;
            }
            if (text1.EndsWith("eps"))
            {
                return 5;
            }
            if (text1.EndsWith("svg"))
            {
                return 6;
            }
            return 1;
        }

        protected string GenerateResourceID()
        {
            DateTime time1;
            if (this.resourceID.Equals(""))
            {
                time1 = DateTime.Now;
                this.resourceID = "XObj" + new Random(time1.Millisecond).Next();
            }
            return this.resourceID;
        }

        protected void Init(int type, Stream stream)
        {
            int num1;
            this.mType = type;
            try
            {
                num1 = this.mType;
                switch (num1)
                {
                    case 1:
                    {
                        this.ParseImage(stream);
                        return;
                    }
                    case 2:
                    {
                        this.ParseMultiMedia(stream, "application/x-shockwave-flash");
                        return;
                    }
                    case 3:
                    {
                        goto Label_0113;
                    }
                    case 4:
                    {
                        this.ParsePS(stream);
                        return;
                    }
                    case 5:
                    {
                        this.ParseEPS(stream);
                        return;
                    }
                    case 6:
                    {
                        this.ParseSVG(stream);
                        return;
                    }
                    case 7:
                    {
                        this.ParseMultiMedia(stream, "audio/aiff");
                        return;
                    }
                    case 8:
                    {
                        this.ParseMultiMedia(stream, "audio/basic");
                        return;
                    }
                    case 9:
                    {
                        this.ParseMultiMedia(stream, "video/avi");
                        return;
                    }
                    case 10:
                    {
                        this.ParseMultiMedia(stream, "audio/midi");
                        return;
                    }
                    case 11:
                    {
                        this.ParseMultiMedia(stream, "video/quicktime");
                        return;
                    }
                    case 12:
                    {
                        this.ParseMultiMedia(stream, "audio/x-mp3");
                        return;
                    }
                    case 13:
                    {
                        this.ParseMultiMedia(stream, "video/mp4");
                        return;
                    }
                    case 14:
                    {
                        this.ParseMultiMedia(stream, "video/mpeg");
                        return;
                    }
                    case 15:
                    {
                        this.ParseMultiMedia(stream, "application/smil");
                        return;
                    }
                }
            Label_0113:
                this.SetToNotFound();
            }
            catch (Exception)
            {
                this.SetToNotFound();
            }
        }

        public static bool IsMultiMediaType(int nType)
        {
            if ((((nType != 2) && (nType != 7)) && ((nType != 8) && (nType != 9))) && (((nType != 10) && (nType != 11)) && ((nType != 12) && (nType != 14))))
            {
                return (nType == 15);
            }
            return true;
        }

        protected void ParseContentDescription(string description)
        {
            this.mType = this.ContentDescription2Type(description);
        }

        protected void ParseEPS(Stream m_Stream)
        {
            StreamReader reader1 = new StreamReader(m_Stream, Encoding.ASCII);
            reader1.ReadLine();
            string text1 = reader1.ReadLine();
            reader1 = null;
            m_Stream.Position = ((long) 0);
            NumberFormatInfo info1 = new NumberFormatInfo();
            info1.NumberDecimalSeparator = ".";
            string text2 = text1.Remove(0, 15);
            char[] chArray1 = new char[1];
            chArray1[0] = ' ';
            string[] textArray1 = text2.Split(chArray1);
            Rect rect1 = new Rect(double.Parse(textArray1[0], info1), double.Parse(textArray1[1], info1), double.Parse(textArray1[2], info1), double.Parse(textArray1[3], info1));
            this.m_Width = rect1.Width;
            this.m_Height = rect1.Height;
            this.resourceSupport = rect1;
            this.resource = XObjectPS.Create(m_Stream);
        }

        protected void ParseImage(Stream m_Stream)
        {
            Bitmap bitmap1 = new Bitmap(m_Stream);
            string[] textArray1 = new string[1];
            textArray1[0] = "FlateDecode";
            this.resource = XObjectImage.Create(bitmap1, textArray1);
            this.m_Width = ((double) bitmap1.Width);
            this.m_Height = ((double) bitmap1.Height);
        }

        protected void ParseMultiMedia(Stream m_Stream, string sMediaType)
        {
            MediaPermissions permissions1 = MediaPermissions.Create(false, ETempFileOpt.TempAlways);
            MediaClipData data1 = MediaClipData.Create(FileSpec.Create(true, m_Stream, "<embedded content>"));
            data1.ExtDataType = sMediaType;
            data1.MediaPermissions = permissions1;
            MediaPlayParameters parameters1 = MediaPlayParameters.Create(false);
            PDFDict dict1 = Library.CreateDict();
            dict1["RC"] = PDF.O(0);
            dict1["F"] = PDF.O(0);
            PDFDict dict2 = Library.CreateDict();
            dict2["S"] = PDF.N("F");
            dict1["D"] = dict2;
            parameters1.BE = new MCS_MHBE(dict1);
            RenditionMedia media1 = RenditionMedia.Create(parameters1);
            media1.MediaClip = data1;
            this.resource = media1;
        }

        protected void ParsePS(Stream m_Stream)
        {
            this.resource = XObjectPS.Create(m_Stream);
        }

        protected abstract void ParseSVG(Stream m_Stream);

        protected void SetToNotFound()
        {
            this.mType = 0;
            this.resourceID = "";
            this.m_Width = 100f;
            this.m_Height = 100f;
        }

        protected abstract void SvgToPDF(Page page, Rect rect, PDFPainter painter);

        public virtual void ToPDF(Page page, Rect rect, PDFPainter painter)
        {
            double num1;
            double num2;
            double num3;
            double num4;
            Rect rect1;
            AnnotationScreen screen1;
            ActionRendition rendition1;
            AnnotationAdditionalActions actions1;
            double[] numArray1;
            if (this.mType == 0)
            {
                num1 = (rect.Width / 5f);
                num2 = (rect.Height / 5f);
                painter.q();
                painter.RG(0f, 0f, 0f).w(1f);
                painter.re(rect.x1, rect.y1, rect.Width, rect.Height);
                painter.S();
                painter.RG(1f, 0f, 0f).w((num1 / 2f));
                painter.m((rect.x1 + (1.2f * num1)), (rect.y1 + (1.2f * num2))).l((rect.x2 - (1.2f * num1)), (rect.y2 - (1.2f * num2))).m((rect.x1 + (1.2f * num1)), (rect.y2 - (1.2f * num2))).l((rect.x2 - (1.2f * num1)), (rect.y1 + (1.2f * num2)));
                painter.S();
                painter.Q();
                return;
            }
            if (1 == this.mType)
            {
                page.Resources.Add(this.ResourceID, (this.resource as XObjectImage));
                num3 = ((rect.Width != 0f) ? rect.Width : 1f);
                num4 = ((rect.Height != 0f) ? rect.Height : 1f);
                if (this.FromSvg)
                {
                    painter.q().cm(new CTM(num3, 0f, 0f, num4, rect.x1, (rect.y1 + rect.Height))).cm(new CTM(1f, 0f, 0f, -1f, 0f, 0f)).Do(this.ResourceID).Q();
                    return;
                }
                painter.q().cm(new CTM(num3, 0f, 0f, num4, rect.x1, rect.y1)).Do(this.ResourceID).Q();
                return;
            }
            if (4 == this.mType)
            {
                page.Resources.Add(this.ResourceID, (this.resource as XObjectPS));
                if (rect.Width != 0f)
                {
                    rect.Width;
                }
                if (rect.Height != 0f)
                {
                    rect.Height;
                }
                painter.q().re(rect).W().n().cm(new CTM(1f, 0f, 0f, 1f, rect.x1, rect.y1)).Do(this.ResourceID).Q();
                return;
            }
            if (5 == this.mType)
            {
                page.Resources.Add(this.ResourceID, (this.resource as XObjectPS));
                rect1 = (this.resourceSupport as Rect);
                if (rect.Width != 0f)
                {
                    rect.Width;
                }
                if (rect.Height != 0f)
                {
                    rect.Height;
                }
                painter.q().re(rect).W().n();
                painter.cm(new CTM((rect.Width / rect1.Width), 0f, 0f, (rect.Height / rect1.Height), (rect.x1 - ((rect1.x1 * rect.Width) / rect1.Width)), (rect.y1 - ((rect1.y1 * rect.Height) / rect1.Height))));
                painter.Do(this.ResourceID).Q();
                return;
            }
            if (6 == this.mType)
            {
                if (this.FromSvg)
                {
                    painter.q().cm(new CTM(1f, 0f, 0f, 1f, rect.x1, (rect.y1 + rect.Height))).cm(new CTM(1f, 0f, 0f, -1f, 0f, 0f));
                }
                this.SvgToPDF(page, rect, painter);
                if (!this.FromSvg)
                {
                    return;
                }
                painter.Q();
                return;
            }
            if (PDFPForeignObject.IsMultiMediaType(this.mType))
            {
                screen1 = AnnotationScreen.Create(rect);
                screen1.Flags = FlagsEnum.Print;
                screen1.Page = page;
                screen1.Border = new BorderCharact(0f, 0f, 0f);
                numArray1 = new double[1];
                numArray1[0] = 3f;
                screen1.BorderStyle = new BorderStyles(0f, EBorderStyle.Solid, numArray1);
                rendition1 = ActionRendition.Create(EPlayOperation.reassign_or_play, (this.resource as RenditionMedia), screen1);
                actions1 = new AnnotationAdditionalActions();
                actions1.PageVisible = rendition1;
                actions1.PageInvisible = rendition1;
                screen1.AdditionalActions = actions1;
                page.Annotations.Add(screen1);
            }
        }


        // Properties
        public bool HasDimensions
        {
            get
            {
                if ((this.mType != 1) && (this.mType != 5))
                {
                    return (this.mType == 0);
                }
                return true;
            }
        }

        public double Height
        {
            get
            {
                return this.m_Height;
            }
        }

        public string ResourceID
        {
            get
            {
                return this.GenerateResourceID();
            }
        }

        public int Type
        {
            get
            {
                return this.mType;
            }
        }

        public double Width
        {
            get
            {
                return this.m_Width;
            }
        }


        // Fields
        protected bool FromSvg;
        public const string key_AIFF = "audio/aiff";
        public const string key_AU = "audio/basic";
        public const string key_AVI = "video/avi";
        public const string key_MID = "audio/midi";
        public const string key_MOV = "video/quicktime";
        public const string key_MP3 = "audio/x-mp3";
        public const string key_MP4 = "video/mp4";
        public const string key_MPEG = "video/mpeg";
        public const string key_SMIL = "application/smil";
        public const string key_SWF = "application/x-shockwave-flash";
        protected double m_Height;
        protected double m_Width;
        protected int mType;
        protected object resource;
        protected string resourceID;
        protected object resourceSupport;
        public const int t_AIFF = 7;
        public const int t_AU = 8;
        public const int t_AVI = 9;
        public const int t_EPS = 5;
        public const int t_IMAGE = 1;
        public const int t_MID = 10;
        public const int t_MOV = 11;
        public const int t_MP3 = 12;
        public const int t_MP4 = 13;
        public const int t_MPEG = 14;
        public const int t_NOTFOUND = 0;
        public const int t_PDF = 3;
        public const int t_PS = 4;
        public const int t_SMIL = 15;
        public const int t_SVG = 6;
        public const int t_SWF = 2;
        public const string v_AIFF = "aiff";
        public const string v_AU = "au";
        public const string v_AVI = "avi";
        public const string v_EPS = "eps";
        public const string v_MID = "mid";
        public const string v_MOV = "mov";
        public const string v_MP3 = "mp3";
        public const string v_MP4 = "mp4";
        public const string v_MPE = "mpe";
        public const string v_MPEG = "mpeg";
        public const string v_MPG = "mpg";
        public const string v_PDF = "pdf";
        public const string v_PS = "ps";
        public const string v_SMIL = "smil";
        public const string v_SVG = "svg";
        public const string v_SWF = "swf";
    }
}


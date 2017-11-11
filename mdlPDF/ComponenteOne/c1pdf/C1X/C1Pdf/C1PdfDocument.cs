namespace C1.C1Pdf
{
    using C1.C1Pdf.Design;
    using C1.Util.Localization;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Printing;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;

    [Designer(typeof(PdfDocumentDesigner)), LicenseProvider(typeof(LicenseProvider)), ToolboxBitmap(typeof(C1PdfDocument))]
    public class C1PdfDocument : C1PdfDocumentBase
    {
        // Methods
        static C1PdfDocument()
        {
            C1PdfDocument.P1 = " -\t\n\r";
        }

        public C1PdfDocument()
        {
            this.P0 = Assembly.GetCallingAssembly();
            this.6O();
            this.6P(PaperKind.Letter, false);
        }

        public C1PdfDocument(PaperKind paperKind)
        {
            this.P0 = Assembly.GetCallingAssembly();
            this.6O();
            this.6P(paperKind, false);
        }

        public C1PdfDocument(SizeF pageSizeInPoints)
        {
            this.P0 = Assembly.GetCallingAssembly();
            this.6O();
            this.PageSize = pageSizeInPoints;
        }

        public C1PdfDocument(PaperKind paperKind, bool landscape)
        {
            this.P0 = Assembly.GetCallingAssembly();
            this.6O();
            this.6P(paperKind, landscape);
        }

        private void 6O()
        {
            if (C1PdfDocument.OY == null)
            {
                C1PdfDocument.OY = new StringFormat(StringFormat.GenericDefault);
                StringFormat format1 = C1PdfDocument.OY;
                C1PdfDocument.OY.FormatFlags = (format1.FormatFlags | StringFormatFlags.NoClip);
            }
            this.OX = FillMode.Alternate;
            this.OZ = null;
        }

        private void 6P(PaperKind 07V, bool 07W)
        {
            float single1;
            this.OV = 07V;
            this.OW = 07W;
            SizeF ef1 = C1PdfDocument.77(07V);
            if (07W)
            {
                single1 = ef1.Width;
                ef1.Width = ef1.Height;
                ef1.Height = single1;
            }
            base.PageSize = ef1;
        }

        internal void 6Q(Pen 07X, Brush 07Y)
        {
            base.SetPen(07X);
            base.SetBrush(07Y);
            base.UpdateResources(null);
            base.BeginPathInternal();
        }

        internal void 6R()
        {
            base.EndPathInternal();
        }

        internal void 6S(bool 07Z, bool 080, bool 081)
        {
            this.6T(07Z, 080, 081, this.OX);
        }

        internal void 6T(bool 082, bool 083, bool 084, FillMode 085)
        {
            base.FillStrokeInternal(082, 083, 084, 085);
        }

        internal void 6U(FillMode 086)
        {
            this.OX = 086;
        }

        internal void 6V(string 087, Font 088, Brush 089, PointF 08A, StringAlignment 08B, bool 08C)
        {
            if ((087 == null) || (087.Length == 0))
            {
                return;
            }
            base.SetFont(088);
            base.SetBrush(089);
            base.UpdateResources(088);
            base.UpdateResources(089);
            08A = this.72(08A);
            base.TextOut(087, 08A, 08B, 08C);
        }

        internal void 6W(0H 08D, RectangleF 08E, RectangleF 08F)
        {
            08E = this.73(08E);
            08F = this.73(08F);
            base.64(08D, 08E, 08F);
        }

        internal void 6X(Metafile 08G, RectangleF 08H, RectangleF 08I, bool 08J, bool 08K)
        {
            object[] objArray1;
            float[] singleArray2;
            if ((08H.Width == 0f) || (08H.Height == 0f))
            {
                return;
            }
            SizeF ef1 = C1PdfDocument.76(08G);
            if ((ef1.Width == 0f) || (ef1.Height == 0f))
            {
                return;
            }
            base.Write("q ", new object[0]);
            if (08I != 08H)
            {
                08I = this.73(08I);
                objArray1 = new object[4];
                objArray1[0] = base.6L(((double) 08I.X));
                objArray1[1] = base.6L(((double) 08I.Y));
                objArray1[2] = base.6L(((double) 08I.Width));
                objArray1[3] = base.6L(((double) 08I.Height));
                base.Write("{0} {1} {2} {3} re W n\r\n", objArray1);
                08I = this.73(08I);
            }
            float single1 = (08H.Width / ef1.Width);
            float single2 = (08H.Height / ef1.Height);
            float single3 = 08H.X;
            SizeF ef2 = this.PageSize;
            float single4 = ((ef2.Height * (1f - single2)) - 08H.Y);
            float[] singleArray1 = null;
            if (((single1 != 1f) || (single2 != 1f)) || ((single3 != 0f) || (single4 != 0f)))
            {
                objArray1 = new object[4];
                objArray1[0] = base.6M(((double) single1), true);
                objArray1[1] = base.6M(((double) single2), true);
                objArray1[2] = base.6M(((double) single3), true);
                objArray1[3] = base.6M(((double) single4), true);
                base.Write("{0} 0 0 {1} {2} {3} cm\r\n", objArray1);
                singleArray2 = new float[4];
                singleArray2[0] = single1;
                singleArray2[1] = single2;
                singleArray2[2] = single3;
                singleArray2[3] = single4;
                singleArray1 = singleArray2;
            }
            0M m1 = new 0M(this);
            m1.88(08G, 08J, 08K, singleArray1);
            base.Write("Q\r\n", new object[0]);
        }

        private 0Q 6Y(string 08L, Font 08M, Brush 08N)
        {
            0Q q1 = new 0Q();
            08L = this.6Z(08L);
            if (08L.StartsWith(@"{\rtf1"))
            {
                q1.Rtf = 08L;
                return q1;
            }
            q1.Clear();
            if ((08N is SolidBrush))
            {
                q1.ForeColor = ((SolidBrush) 08N).Color;
            }
            if (08M != null)
            {
                q1.Font = 08M;
            }
            q1.SelectedRtf = @"{\rtf1" + 08L + "}";
            return q1;
        }

        private string 6Z(string 08O)
        {
            int num1;
            if (!C1PdfDocumentBase.IsUnicodeText(08O))
            {
                return 08O;
            }
            StringBuilder builder1 = new StringBuilder();
            for (num1 = 0; (num1 < 08O.Length); num1 += 1)
            {
                if (08O[num1] > '\u00ff')
                {
                    builder1.AppendFormat(@"\u{0}?", 08O[num1]);
                }
                else
                {
                    builder1.Append(08O[num1]);
                }
            }
            return builder1.ToString();
        }

        private void 70(string 08P, int 08Q, int 08R, float 08S)
        {
            06 1;
            SizeF ef1 = this.PageSize;
            08S = (ef1.Height - 08S);
            if (this.O7.Count > 0)
            {
                1 = this.O7[(this.O7.Count - 1)];
                if (((1.NW == (08R - 1)) && (1.NX == 08Q)) && (1.NV == 08P))
                {
                    1.NW = 08R;
                    1.O0 = 08S;
                    return;
                }
            }
            this.O7.Add(new 06(08P, 08Q, base.Pages[08R], 08S));
        }

        private void 71(string 08T, int 08U, RectangleF 08V)
        {
            08V = this.73(08V);
            this.O8.Add(new 0K(08T, base.Pages[08U], 08V));
        }

        internal PointF 72(PointF 08W)
        {
            SizeF ef1 = this.PageSize;
            08W.Y = (ef1.Height - 08W.Y);
            return 08W;
        }

        internal RectangleF 73(RectangleF 08X)
        {
            PointF tf1 = this.72(08X.Location);
            08X.Y = (tf1.Y - 08X.Height);
            return 08X;
        }

        internal PointF[] 74(PointF[] 08Y)
        {
            int num1;
            PointF[] tfArray1 = new PointF[((uint) 08Y.Length)];
            for (num1 = 0; (num1 < 08Y.Length); num1 += 1)
            {
                tfArray1[num1] = this.72(08Y[num1]);
            }
            return tfArray1;
        }

        private static RectangleF 75(Image 08Z, RectangleF 090, ContentAlignment 091, ImageSizeModeEnum 092)
        {
            float single1;
            float single2;
            RectangleF ef2;
            SizeF ef1 = C1PdfDocument.76(08Z);
            ImageSizeModeEnum enum1 = 092;
            switch (enum1)
            {
                case ImageSizeModeEnum.Stretch:
                {
                    ef1.Width = 090.Width;
                    ef1.Height = 090.Height;
                    goto Label_00AA;
                }
                case ImageSizeModeEnum.Scale:
                {
                    single1 = (090.Width / ef1.Width);
                    single2 = (090.Height / ef1.Height);
                    if (Math.Abs(single1) >= Math.Abs(single2))
                    {
                        goto Label_007D;
                    }
                    single2 = (Math.Abs(single1) * ((float) Math.Sign(single2)));
                    goto Label_008C;
                }
            }
            goto Label_00AA;
        Label_007D:
            single1 = (Math.Abs(single2) * ((float) Math.Sign(single1)));
        Label_008C:
            SizeF* efPtr1 = &ef1;
            ef1.Width = (efPtr1.Width * single1);
            SizeF* efPtr2 = &ef1;
            ef1.Height = (efPtr2.Height * single2);
        Label_00AA:
            ef2 = new RectangleF(090.Location, ef1);
            float single3 = (090.Height - ef2.Height);
            if (Math.Sign(single3) != Math.Sign(090.Height))
            {
                single3 = 0f;
            }
            ContentAlignment alignment1 = 091;
            if (alignment1 <= ContentAlignment.MiddleRight)
            {
                if (((alignment1 == ContentAlignment.MiddleLeft) || (alignment1 == ContentAlignment.MiddleCenter)) || (alignment1 == ContentAlignment.MiddleRight))
                {
                    goto Label_0120;
                }
                goto Label_0148;
            }
            if (((alignment1 == ContentAlignment.BottomLeft) || (alignment1 == ContentAlignment.BottomCenter)) || (alignment1 == ContentAlignment.BottomRight))
            {
                goto Label_0138;
            }
            goto Label_0148;
        Label_0120:
            RectangleF* efPtr3 = &ef2;
            ef2.Y = (efPtr3.Y + (single3 / 2f));
            goto Label_0148;
        Label_0138:
            RectangleF* efPtr4 = &ef2;
            ef2.Y = (efPtr4.Y + single3);
        Label_0148:
            single3 = (090.Width - ef2.Width);
            if (Math.Sign(single3) != Math.Sign(090.Width))
            {
                single3 = 0f;
            }
            alignment1 = 091;
            if (alignment1 <= ContentAlignment.MiddleCenter)
            {
                switch (alignment1)
                {
                    case ContentAlignment.TopCenter:
                    {
                        goto Label_01B5;
                    }
                    case (ContentAlignment.TopCenter | ContentAlignment.TopLeft):
                    {
                        return ef2;
                    }
                    case ContentAlignment.TopRight:
                    {
                        goto Label_01CD;
                    }
                }
                if (alignment1 != ContentAlignment.MiddleCenter)
                {
                    return ef2;
                }
            }
            else
            {
                if (alignment1 == ContentAlignment.MiddleRight)
                {
                    goto Label_01CD;
                }
                if (alignment1 != ContentAlignment.BottomCenter)
                {
                    if (alignment1 != ContentAlignment.BottomRight)
                    {
                        return ef2;
                    }
                    goto Label_01CD;
                }
            }
        Label_01B5:
            RectangleF* efPtr5 = &ef2;
            ef2.X = (efPtr5.X + (single3 / 2f));
            return ef2;
        Label_01CD:
            RectangleF* efPtr6 = &ef2;
            ef2.X = (efPtr6.X + single3);
            return ef2;
        }

        internal static SizeF 76(Image 093)
        {
            float single1 = 093.HorizontalResolution;
            float single2 = 093.VerticalResolution;
            if (single1 == 0f)
            {
                single1 = 96f;
            }
            if (single2 == 0f)
            {
                single2 = 96f;
            }
            float single3 = ((float) Math.Round(((double) ((((float) 093.Width) * 72f) / single1)), 4));
            float single4 = ((float) Math.Round(((double) ((((float) 093.Height) * 72f) / single2)), 4));
            return new SizeF(single3, single4);
        }

        internal static SizeF 77(PaperKind 094)
        {
            PaperKind kind1 = 094;
            switch (kind1)
            {
                case PaperKind.Letter:
                {
                    goto Label_0547;
                }
                case PaperKind.LetterSmall:
                {
                    goto Label_0597;
                }
                case PaperKind.Tabloid:
                {
                    goto Label_0857;
                }
                case PaperKind.Ledger:
                {
                    goto Label_0517;
                }
                case PaperKind.Legal:
                {
                    goto Label_0527;
                }
                case PaperKind.Statement:
                {
                    goto Label_0847;
                }
                case PaperKind.Executive:
                {
                    goto Label_0467;
                }
                case PaperKind.A3:
                {
                    goto Label_01F7;
                }
                case PaperKind.A4:
                {
                    goto Label_0247;
                }
                case PaperKind.A4Small:
                {
                    goto Label_0287;
                }
                case PaperKind.A5:
                {
                    goto Label_02A7;
                }
                case PaperKind.B4:
                {
                    goto Label_0317;
                }
                case PaperKind.B5:
                {
                    goto Label_0347;
                }
                case PaperKind.Folio:
                {
                    goto Label_0477;
                }
                case PaperKind.Quarto:
                {
                    goto Label_07D7;
                }
                case PaperKind.Standard10x14:
                {
                    goto Label_07F7;
                }
                case PaperKind.Standard11x17:
                {
                    goto Label_0807;
                }
                case PaperKind.Note:
                {
                    goto Label_05C7;
                }
                case PaperKind.Number9Envelope:
                {
                    goto Label_0617;
                }
                case PaperKind.Number10Envelope:
                {
                    goto Label_05D7;
                }
                case PaperKind.Number11Envelope:
                {
                    goto Label_05E7;
                }
                case PaperKind.Number12Envelope:
                {
                    goto Label_05F7;
                }
                case PaperKind.Number14Envelope:
                {
                    goto Label_0607;
                }
                case PaperKind.CSheet:
                {
                    goto Label_0427;
                }
                case PaperKind.DSheet:
                {
                    goto Label_0447;
                }
                case PaperKind.ESheet:
                {
                    goto Label_0457;
                }
                case PaperKind.DLEnvelope:
                {
                    goto Label_0437;
                }
                case PaperKind.C5Envelope:
                {
                    goto Label_03F7;
                }
                case PaperKind.C3Envelope:
                {
                    goto Label_03D7;
                }
                case PaperKind.C4Envelope:
                {
                    goto Label_03E7;
                }
                case PaperKind.C6Envelope:
                {
                    goto Label_0417;
                }
                case PaperKind.C65Envelope:
                {
                    goto Label_0407;
                }
                case PaperKind.B4Envelope:
                {
                    goto Label_0327;
                }
                case PaperKind.B5Envelope:
                {
                    goto Label_0357;
                }
                case PaperKind.B6Envelope:
                {
                    goto Label_0397;
                }
                case PaperKind.ItalyEnvelope:
                {
                    goto Label_04C7;
                }
                case PaperKind.MonarchEnvelope:
                {
                    goto Label_05B7;
                }
                case PaperKind.PersonalEnvelope:
                {
                    goto Label_0627;
                }
                case PaperKind.USStandardFanfold:
                {
                    goto Label_0877;
                }
                case PaperKind.GermanStandardFanfold:
                {
                    goto Label_0497;
                }
                case PaperKind.GermanLegalFanfold:
                {
                    goto Label_0487;
                }
                case PaperKind.IsoB4:
                {
                    goto Label_04B7;
                }
                case PaperKind.JapanesePostcard:
                {
                    goto Label_04F7;
                }
                case PaperKind.Standard9x11:
                {
                    goto Label_0837;
                }
                case PaperKind.Standard10x11:
                {
                    goto Label_07E7;
                }
                case PaperKind.Standard15x11:
                {
                    goto Label_0827;
                }
                case PaperKind.InviteEnvelope:
                {
                    goto Label_04A7;
                }
                case (PaperKind.C65Envelope | PaperKind.Standard10x14):
                case PaperKind.JapaneseEnvelopeYouNumber4Rotated:
                case PaperKind.JapaneseEnvelopeYouNumber4:
                case PaperKind.JapaneseEnvelopeChouNumber4Rotated:
                case PaperKind.JapaneseEnvelopeChouNumber3Rotated:
                case PaperKind.JapaneseEnvelopeKakuNumber3Rotated:
                case PaperKind.JapaneseEnvelopeKakuNumber2Rotated:
                case PaperKind.JapaneseEnvelopeChouNumber4:
                case PaperKind.JapaneseEnvelopeChouNumber3:
                case PaperKind.JapaneseEnvelopeKakuNumber3:
                case PaperKind.JapaneseEnvelopeKakuNumber2:
                case (PaperKind.B4Envelope | PaperKind.Standard10x14):
                {
                    goto Label_0887;
                }
                case PaperKind.LetterExtra:
                {
                    goto Label_0557;
                }
                case PaperKind.LegalExtra:
                {
                    goto Label_0537;
                }
                case PaperKind.TabloidExtra:
                {
                    goto Label_0867;
                }
                case PaperKind.A4Extra:
                {
                    goto Label_0257;
                }
                case PaperKind.LetterTransverse:
                {
                    goto Label_05A7;
                }
                case PaperKind.A4Transverse:
                {
                    goto Label_0297;
                }
                case PaperKind.LetterExtraTransverse:
                {
                    goto Label_0567;
                }
                case PaperKind.APlus:
                {
                    goto Label_0307;
                }
                case PaperKind.BPlus:
                {
                    goto Label_03C7;
                }
                case PaperKind.LetterPlus:
                {
                    goto Label_0577;
                }
                case PaperKind.A4Plus:
                {
                    goto Label_0267;
                }
                case PaperKind.A5Transverse:
                {
                    goto Label_02D7;
                }
                case PaperKind.B5Transverse:
                {
                    goto Label_0387;
                }
                case PaperKind.A3Extra:
                {
                    goto Label_0207;
                }
                case PaperKind.A5Extra:
                {
                    goto Label_02B7;
                }
                case PaperKind.B5Extra:
                {
                    goto Label_0367;
                }
                case PaperKind.A2:
                {
                    goto Label_01E7;
                }
                case PaperKind.A3Transverse:
                {
                    goto Label_0237;
                }
                case PaperKind.A3ExtraTransverse:
                {
                    goto Label_0217;
                }
                case PaperKind.JapaneseDoublePostcard:
                {
                    goto Label_04D7;
                }
                case PaperKind.A6:
                {
                    goto Label_02E7;
                }
                case PaperKind.LetterRotated:
                {
                    goto Label_0587;
                }
                case PaperKind.A3Rotated:
                {
                    goto Label_0227;
                }
                case PaperKind.A4Rotated:
                {
                    goto Label_0277;
                }
                case PaperKind.A5Rotated:
                {
                    goto Label_02C7;
                }
                case PaperKind.B4JisRotated:
                {
                    goto Label_0337;
                }
                case PaperKind.B5JisRotated:
                {
                    goto Label_0377;
                }
                case PaperKind.JapanesePostcardRotated:
                {
                    goto Label_0507;
                }
                case PaperKind.JapaneseDoublePostcardRotated:
                {
                    goto Label_04E7;
                }
                case PaperKind.A6Rotated:
                {
                    goto Label_02F7;
                }
                case PaperKind.B6Jis:
                {
                    goto Label_03A7;
                }
                case PaperKind.B6JisRotated:
                {
                    goto Label_03B7;
                }
                case PaperKind.Standard12x11:
                {
                    goto Label_0817;
                }
                case PaperKind.Prc16K:
                {
                    goto Label_0637;
                }
                case PaperKind.Prc32K:
                {
                    goto Label_0657;
                }
                case PaperKind.Prc32KBig:
                {
                    goto Label_0667;
                }
                case PaperKind.PrcEnvelopeNumber1:
                {
                    goto Label_0697;
                }
                case PaperKind.PrcEnvelopeNumber2:
                {
                    goto Label_06D7;
                }
                case PaperKind.PrcEnvelopeNumber3:
                {
                    goto Label_06F7;
                }
                case PaperKind.PrcEnvelopeNumber4:
                {
                    goto Label_0717;
                }
                case PaperKind.PrcEnvelopeNumber5:
                {
                    goto Label_0737;
                }
                case PaperKind.PrcEnvelopeNumber6:
                {
                    goto Label_0757;
                }
                case PaperKind.PrcEnvelopeNumber7:
                {
                    goto Label_0777;
                }
                case PaperKind.PrcEnvelopeNumber8:
                {
                    goto Label_0797;
                }
                case PaperKind.PrcEnvelopeNumber9:
                {
                    goto Label_07B7;
                }
                case PaperKind.PrcEnvelopeNumber10:
                {
                    goto Label_06A7;
                }
                case PaperKind.Prc16KRotated:
                {
                    goto Label_0647;
                }
                case PaperKind.Prc32KRotated:
                {
                    goto Label_0687;
                }
                case PaperKind.Prc32KBigRotated:
                {
                    goto Label_0677;
                }
                case PaperKind.PrcEnvelopeNumber1Rotated:
                {
                    goto Label_06C7;
                }
                case PaperKind.PrcEnvelopeNumber2Rotated:
                {
                    goto Label_06E7;
                }
                case PaperKind.PrcEnvelopeNumber3Rotated:
                {
                    goto Label_0707;
                }
                case PaperKind.PrcEnvelopeNumber4Rotated:
                {
                    goto Label_0727;
                }
                case PaperKind.PrcEnvelopeNumber5Rotated:
                {
                    goto Label_0747;
                }
                case PaperKind.PrcEnvelopeNumber6Rotated:
                {
                    goto Label_0767;
                }
                case PaperKind.PrcEnvelopeNumber7Rotated:
                {
                    goto Label_0787;
                }
                case PaperKind.PrcEnvelopeNumber8Rotated:
                {
                    goto Label_07A7;
                }
                case PaperKind.PrcEnvelopeNumber9Rotated:
                {
                    goto Label_07C7;
                }
                case PaperKind.PrcEnvelopeNumber10Rotated:
                {
                    goto Label_06B7;
                }
            }
            goto Label_0887;
        Label_01E7:
            return new SizeF(1190.6f, 1683.8f);
        Label_01F7:
            return new SizeF(841.9f, 1190.6f);
        Label_0207:
            return new SizeF(912.8f, 1261.4f);
        Label_0217:
            return new SizeF(912.8f, 1261.4f);
        Label_0227:
            return new SizeF(1190.6f, 841.9f);
        Label_0237:
            return new SizeF(841.9f, 1190.6f);
        Label_0247:
            return new SizeF(595.3f, 841.9f);
        Label_0257:
            return new SizeF(669f, 912.8f);
        Label_0267:
            return new SizeF(595.3f, 935.4f);
        Label_0277:
            return new SizeF(841.9f, 595.3f);
        Label_0287:
            return new SizeF(595.3f, 841.9f);
        Label_0297:
            return new SizeF(595.3f, 841.9f);
        Label_02A7:
            return new SizeF(419.5f, 595.3f);
        Label_02B7:
            return new SizeF(493.2f, 666.1f);
        Label_02C7:
            return new SizeF(595.3f, 419.5f);
        Label_02D7:
            return new SizeF(419.5f, 595.3f);
        Label_02E7:
            return new SizeF(297.6f, 419.5f);
        Label_02F7:
            return new SizeF(419.5f, 297.6f);
        Label_0307:
            return new SizeF(643.5f, 1009.1f);
        Label_0317:
            return new SizeF(708.7f, 1000.6f);
        Label_0327:
            return new SizeF(708.7f, 1000.6f);
        Label_0337:
            return new SizeF(1031.8f, 728.5f);
        Label_0347:
            return new SizeF(498.9f, 708.7f);
        Label_0357:
            return new SizeF(498.9f, 708.7f);
        Label_0367:
            return new SizeF(569.8f, 782.4f);
        Label_0377:
            return new SizeF(728.5f, 515.9f);
        Label_0387:
            return new SizeF(515.9f, 728.5f);
        Label_0397:
            return new SizeF(498.9f, 354.3f);
        Label_03A7:
            return new SizeF(362.8f, 515.9f);
        Label_03B7:
            return new SizeF(515.9f, 362.8f);
        Label_03C7:
            return new SizeF(864.6f, 1380.5f);
        Label_03D7:
            return new SizeF(918.4f, 1298.3f);
        Label_03E7:
            return new SizeF(649.1f, 918.4f);
        Label_03F7:
            return new SizeF(459.2f, 649.1f);
        Label_0407:
            return new SizeF(323.1f, 649.1f);
        Label_0417:
            return new SizeF(323.1f, 459.2f);
        Label_0427:
            return new SizeF(1224f, 1584f);
        Label_0437:
            return new SizeF(311.8f, 623.6f);
        Label_0447:
            return new SizeF(1584f, 2448f);
        Label_0457:
            return new SizeF(2448f, 3168f);
        Label_0467:
            return new SizeF(522f, 756f);
        Label_0477:
            return new SizeF(612f, 936f);
        Label_0487:
            return new SizeF(612f, 936f);
        Label_0497:
            return new SizeF(612f, 864f);
        Label_04A7:
            return new SizeF(623.6f, 623.6f);
        Label_04B7:
            return new SizeF(708.7f, 1000.6f);
        Label_04C7:
            return new SizeF(311.8f, 652f);
        Label_04D7:
            return new SizeF(566.9f, 419.5f);
        Label_04E7:
            return new SizeF(419.5f, 566.9f);
        Label_04F7:
            return new SizeF(283.5f, 419.5f);
        Label_0507:
            return new SizeF(419.5f, 283.5f);
        Label_0517:
            return new SizeF(1224f, 792f);
        Label_0527:
            return new SizeF(612f, 1008f);
        Label_0537:
            return new SizeF(667.8f, 1080f);
        Label_0547:
            return new SizeF(612f, 792f);
        Label_0557:
            return new SizeF(667.8f, 864f);
        Label_0567:
            return new SizeF(667.8f, 864f);
        Label_0577:
            return new SizeF(612f, 933.1f);
        Label_0587:
            return new SizeF(792f, 612f);
        Label_0597:
            return new SizeF(612f, 792f);
        Label_05A7:
            return new SizeF(595.8f, 792f);
        Label_05B7:
            return new SizeF(279f, 540f);
        Label_05C7:
            return new SizeF(612f, 792f);
        Label_05D7:
            return new SizeF(297f, 684f);
        Label_05E7:
            return new SizeF(324f, 747f);
        Label_05F7:
            return new SizeF(342f, 792f);
        Label_0607:
            return new SizeF(360f, 828f);
        Label_0617:
            return new SizeF(243.7f, 639f);
        Label_0627:
            return new SizeF(261f, 468f);
        Label_0637:
            return new SizeF(413.9f, 609.4f);
        Label_0647:
            return new SizeF(413.9f, 609.4f);
        Label_0657:
            return new SizeF(275f, 428f);
        Label_0667:
            return new SizeF(275f, 428f);
        Label_0677:
            return new SizeF(275f, 428f);
        Label_0687:
            return new SizeF(275f, 428f);
        Label_0697:
            return new SizeF(289.1f, 467.7f);
        Label_06A7:
            return new SizeF(918.4f, 1298.3f);
        Label_06B7:
            return new SizeF(1298.3f, 918.4f);
        Label_06C7:
            return new SizeF(467.7f, 289.1f);
        Label_06D7:
            return new SizeF(289.1f, 498.9f);
        Label_06E7:
            return new SizeF(498.9f, 289.1f);
        Label_06F7:
            return new SizeF(354.3f, 498.9f);
        Label_0707:
            return new SizeF(498.9f, 354.3f);
        Label_0717:
            return new SizeF(311.8f, 589.6f);
        Label_0727:
            return new SizeF(589.6f, 311.8f);
        Label_0737:
            return new SizeF(311.8f, 623.6f);
        Label_0747:
            return new SizeF(623.6f, 311.8f);
        Label_0757:
            return new SizeF(340.2f, 652f);
        Label_0767:
            return new SizeF(652f, 340.2f);
        Label_0777:
            return new SizeF(453.5f, 652f);
        Label_0787:
            return new SizeF(652f, 453.5f);
        Label_0797:
            return new SizeF(340.2f, 875.9f);
        Label_07A7:
            return new SizeF(875.9f, 340.2f);
        Label_07B7:
            return new SizeF(649.1f, 918.4f);
        Label_07C7:
            return new SizeF(918.4f, 649.1f);
        Label_07D7:
            return new SizeF(609.4f, 779.5f);
        Label_07E7:
            return new SizeF(720f, 792f);
        Label_07F7:
            return new SizeF(720f, 1008f);
        Label_0807:
            return new SizeF(792f, 1224f);
        Label_0817:
            return new SizeF(864f, 792f);
        Label_0827:
            return new SizeF(1080f, 792f);
        Label_0837:
            return new SizeF(648f, 792f);
        Label_0847:
            return new SizeF(396f, 612f);
        Label_0857:
            return new SizeF(792f, 1224f);
        Label_0867:
            return new SizeF(841.7f, 1296f);
        Label_0877:
            return new SizeF(1071f, 792f);
        Label_0887:
            return C1PdfDocument.77(PaperKind.Letter);
        }

        private float 78(Font 095)
        {
            FontFamily family1 = 095.FontFamily;
            int num1 = family1.GetLineSpacing(095.Style);
            int num2 = family1.GetEmHeight(095.Style);
            return ((095.Size * ((float) num1)) / ((float) num2));
        }

        private static Point[] 79(string 096, Font 097, RectangleF 098, StringFormat 099)
        {
            int num4;
            char ch1;
            string text1;
            float single1;
            string text2;
            float single2;
            SizeF ef1;
            ArrayList list1 = new ArrayList();
            int num1 = -1;
            int num2 = 0;
            int num3 = 096.Length;
            bool flag1 = false;
            bool flag2 = ((099.FormatFlags & StringFormatFlags.NoWrap) == 0);
            for (num4 = 0; (num4 < num3); num4 += 1)
            {
                ch1 = 096[num4];
                if (C1PdfDocument.P1.IndexOf(ch1) >= 0)
                {
                    if (flag2)
                    {
                        text1 = 096.Substring(num2, ((num4 - num2) + 1));
                        ef1 = C1PdfDocumentBase.MeasureText(text1, 097);
                        single1 = ef1.Width;
                        flag1 = (single1 > 098.Width);
                    }
                    if (!flag1)
                    {
                        num1 = num4;
                    }
                    if ((ch1 == '\r') || (ch1 == '\n'))
                    {
                        if (flag1 && (num1 > -1))
                        {
                            list1.Add(new Point(num2, ((num1 - num2) + 1)));
                            num2 = (num1 + 1);
                        }
                        list1.Add(new Point(num2, (num4 - num2)));
                        if (((ch1 == '\r') && (num4 < num3)) && (096[(num4 + 1)] == '\n'))
                        {
                            num4 += 1;
                        }
                        num2 = (num4 + 1);
                        flag1 = false;
                        num1 = -1;
                    }
                    else if (flag1)
                    {
                        if (num1 < 0)
                        {
                            num1 = num4;
                        }
                        list1.Add(new Point(num2, ((num1 - num2) + 1)));
                        num2 = (num1 + 1);
                        num4 = num2;
                        flag1 = false;
                        num1 = -1;
                    }
                }
            }
            if (num2 < num3)
            {
                if (flag2 && !flag1)
                {
                    text2 = 096.Substring(num2, (num3 - num2));
                    ef1 = C1PdfDocumentBase.MeasureText(text2, 097);
                    single2 = ef1.Width;
                    flag1 = (single2 > 098.Width);
                }
                if (flag1 && (num1 > -1))
                {
                    list1.Add(new Point(num2, ((num1 - num2) + 1)));
                    num2 = (num1 + 1);
                }
                list1.Add(new Point(num2, (num3 - num2)));
            }
            return ((Point[]) list1.ToArray(typeof(Point)));
        }

        public void AddAttachment(string fileName, RectangleF rc)
        {
            this.AddAttachment(fileName, rc, AttachmentIconEnum.Paperclip, Color.Transparent);
        }

        public void AddAttachment(string fileName, RectangleF rc, AttachmentIconEnum icon, Color iconColor)
        {
            rc = this.73(rc);
            03 1 = new 03(fileName, base.Pages[base.CurrentPage], rc, icon, iconColor);
            this.OA.Add(1);
        }

        public virtual void AddBookmark(string text, int level, float y)
        {
            this.70(text, level, base.CurrentPage, y);
        }

        public void AddLink(string url, RectangleF rc)
        {
            this.71(url, base.CurrentPage, rc);
        }

        public void AddTarget(string name, RectangleF rc)
        {
            rc = this.73(rc);
            0L l1 = new 0L(name, base.Pages[base.CurrentPage], rc);
            this.O9.Add(l1);
        }

        public void DrawArc(Pen pen, RectangleF rc, float startAngle, float sweepAngle)
        {
            Color color1;
            if (pen != null)
            {
                color1 = pen.Color;
                if (!color1.Equals(Color.Transparent))
                {
                    goto Label_001E;
                }
            }
            return;
        Label_001E:
            base.SetPen(pen);
            base.UpdateResources(pen);
            rc = this.73(rc);
            base.PieArc(rc, startAngle, sweepAngle, false);
            this.6S(false, false, true);
        }

        public void DrawBezier(Pen pen, PointF start, PointF ctl1, PointF ctl2, PointF end)
        {
            PointF[] tfArray1 = new PointF[4];
            *(tfArray1) = start;
            tfArray1[1] = ctl1;
            tfArray1[2] = ctl2;
            tfArray1[3] = end;
            this.DrawBeziers(pen, tfArray1);
        }

        public void DrawBeziers(Pen pen, PointF[] points)
        {
            int num1;
            Color color1;
            if ((points.Length < 4) || ((points.Length % 3) != 1))
            {
                throw new InvalidOperationException("DrawBeziers requires a vector with 3n+1 points (n>=1).");
            }
            if (pen != null)
            {
                color1 = pen.Color;
                if (!color1.Equals(Color.Transparent))
                {
                    goto Label_0037;
                }
            }
            return;
        Label_0037:
            base.SetPen(pen);
            base.UpdateResources(pen);
            points = this.74(points);
            base.MoveTo(points[0].X, points[0].Y);
            for (num1 = 1; (num1 < (points.Length - 2)); num1 += 3)
            {
                base.CurveTo(points[num1].X, points[num1].Y, points[(num1 + 1)].X, points[(num1 + 1)].Y, points[(num1 + 2)].X, points[(num1 + 2)].Y);
            }
            this.6S(false, false, true);
        }

        public void DrawEllipse(Pen pen, RectangleF rc)
        {
            Color color1;
            if (pen != null)
            {
                color1 = pen.Color;
                if (!color1.Equals(Color.Transparent))
                {
                    goto Label_001E;
                }
            }
            return;
        Label_001E:
            base.SetPen(pen);
            base.UpdateResources(pen);
            rc = this.73(rc);
            base.Ellipse(rc);
            this.6S(false, false, true);
        }

        public void DrawEllipse(Pen pen, float x, float y, float width, float height)
        {
            this.DrawEllipse(pen, new RectangleF(x, y, width, height));
        }

        public void DrawImage(Image img, RectangleF rc)
        {
            this.DrawImage(img, rc, rc);
        }

        public void DrawImage(Image img, RectangleF rcImage, RectangleF rcClip)
        {
            Metafile metafile1 = (img as Metafile);
            if (metafile1 != null)
            {
                this.6X(metafile1, rcImage, rcClip, false, false);
                return;
            }
            this.6W(new 0H(img), rcImage, rcClip);
        }

        public void DrawImage(Image img, RectangleF rc, ContentAlignment align, ImageSizeModeEnum mode)
        {
            RectangleF ef1 = C1PdfDocument.75(img, rc, align, mode);
            this.DrawImage(img, ef1, rc);
        }

        public void DrawLine(Pen pen, PointF pt1, PointF pt2)
        {
            PointF[] tfArray1 = new PointF[2];
            *(tfArray1) = pt1;
            tfArray1[1] = pt2;
            this.DrawLines(pen, tfArray1);
        }

        public void DrawLine(Pen pen, float x1, float y1, float x2, float y2)
        {
            this.DrawLine(pen, new PointF(x1, y1), new PointF(x2, y2));
        }

        public void DrawLines(Pen pen, PointF[] points)
        {
            Color color1;
            if (pen != null)
            {
                color1 = pen.Color;
                if (!color1.Equals(Color.Transparent))
                {
                    goto Label_001E;
                }
            }
            return;
        Label_001E:
            base.SetPen(pen);
            base.UpdateResources(pen);
            points = this.74(points);
            base.Polygon(points);
            this.6S(false, false, true);
        }

        public void DrawPie(Pen pen, RectangleF rc, float startAngle, float sweepAngle)
        {
            Color color1;
            if (pen != null)
            {
                color1 = pen.Color;
                if (!color1.Equals(Color.Transparent))
                {
                    goto Label_001E;
                }
            }
            return;
        Label_001E:
            base.SetPen(pen);
            base.UpdateResources(pen);
            rc = this.73(rc);
            base.PieArc(rc, startAngle, sweepAngle, true);
            this.6S(true, false, true);
        }

        public void DrawPolygon(Pen pen, PointF[] points)
        {
            Color color1;
            if (pen != null)
            {
                color1 = pen.Color;
                if (!color1.Equals(Color.Transparent))
                {
                    goto Label_001E;
                }
            }
            return;
        Label_001E:
            base.SetPen(pen);
            base.UpdateResources(pen);
            points = this.74(points);
            base.Polygon(points);
            this.6S(true, false, true);
        }

        public void DrawRectangle(Pen pen, RectangleF rc)
        {
            Color color1;
            if (pen != null)
            {
                color1 = pen.Color;
                if (!color1.Equals(Color.Transparent))
                {
                    goto Label_001E;
                }
            }
            return;
        Label_001E:
            base.SetPen(pen);
            base.UpdateResources(pen);
            rc = this.73(rc);
            base.Rectangle(rc);
            this.6S(false, false, true);
        }

        public void DrawRectangle(Pen pen, RectangleF rc, SizeF corners)
        {
            Color color1;
            if (pen != null)
            {
                color1 = pen.Color;
                if (!color1.Equals(Color.Transparent))
                {
                    goto Label_001E;
                }
            }
            return;
        Label_001E:
            base.SetPen(pen);
            base.UpdateResources(pen);
            rc = this.73(rc);
            base.RoundRect(rc, corners);
            this.6S(true, false, true);
        }

        public void DrawRectangle(Pen pen, float x, float y, float width, float height)
        {
            this.DrawRectangle(pen, new RectangleF(x, y, width, height));
        }

        public int DrawString(string text, Font font, Brush brush, RectangleF rc)
        {
            return this.DrawString(text, font, brush, rc, C1PdfDocument.OY);
        }

        public int DrawString(string text, Font font, Brush brush, RectangleF rc, StringFormat sf)
        {
            bool flag3;
            float single1;
            PointF tf1;
            Point point1;
            string text1;
            object[] objArray1;
            int num2;
            if ((text == null) || (text.Length == 0))
            {
                return 1;
            }
            base.SetFont(font, text);
            base.SetBrush(brush);
            base.UpdateResources(font);
            base.UpdateResources(brush);
            rc = this.73(rc);
            bool flag1 = ((sf.FormatFlags & StringFormatFlags.NoClip) == 0);
            bool flag2 = ((sf.FormatFlags & StringFormatFlags.DirectionVertical) != 0);
            if (flag1 || flag2)
            {
                base.Write("q ", new object[0]);
            }
            if (flag2)
            {
                flag3 = ((sf.FormatFlags & StringFormatFlags.DirectionRightToLeft) != 0);
                using (Matrix matrix1 = new Matrix())
                {
                    matrix1.RotateAt((flag3 ? -90f : 90f), rc.Location);
                    objArray1 = new object[6];
                    objArray1[0] = base.6L(((double) matrix1.Elements[0]));
                    objArray1[1] = base.6L(((double) matrix1.Elements[1]));
                    objArray1[2] = base.6L(((double) matrix1.Elements[2]));
                    objArray1[3] = base.6L(((double) matrix1.Elements[3]));
                    objArray1[4] = base.6L(((double) matrix1.Elements[4]));
                    objArray1[5] = base.6L(((double) matrix1.Elements[5]));
                    base.Write("{0} {1} {2} {3} {4} {5} cm ", objArray1);
                }
                single1 = rc.Width;
                rc.Width = rc.Height;
                rc.Height = single1;
                if (flag3)
                {
                    RectangleF* efPtr1 = &rc;
                    rc.X = (efPtr1.X - rc.Width);
                }
                else
                {
                    RectangleF* efPtr2 = &rc;
                    rc.Y = (efPtr2.Y - rc.Height);
                }
            }
            tf1 = new PointF(rc.X, rc.Bottom);
            Point[] pointArray1 = C1PdfDocument.79(text, font, rc, sf);
            float single2 = this.78(font);
            if (sf.Alignment == StringAlignment.Near)
            {
                goto Label_0208;
            }
            StringAlignment alignment1 = sf.Alignment;
            switch (alignment1)
            {
                case StringAlignment.Center:
                {
                    goto Label_01ED;
                }
                case StringAlignment.Far:
                {
                    PointF* tfPtr1 = &tf1;
                    tf1.X = (tfPtr1.X + rc.Width);
                    goto Label_0208;
                }
            }
            goto Label_0208;
        Label_01ED:
            PointF* tfPtr2 = &tf1;
            tf1.X = (tfPtr2.X + (rc.Width / 2f));
        Label_0208:
            if (sf.LineAlignment == StringAlignment.Near)
            {
                goto Label_0274;
            }
            float single3 = (((float) pointArray1.Length) * single2);
            float single4 = (rc.Height - single3);
            if (single4 <= 0f)
            {
                goto Label_0274;
            }
            alignment1 = sf.LineAlignment;
            switch (alignment1)
            {
                case StringAlignment.Center:
                {
                    goto Label_025E;
                }
                case StringAlignment.Far:
                {
                    PointF* tfPtr3 = &tf1;
                    tf1.Y = (tfPtr3.Y - single4);
                    goto Label_0274;
                }
            }
            goto Label_0274;
        Label_025E:
            PointF* tfPtr4 = &tf1;
            tf1.Y = (tfPtr4.Y - (single4 / 2f));
        Label_0274:
            if (flag1)
            {
                objArray1 = new object[4];
                objArray1[0] = base.6L(((double) rc.X));
                objArray1[1] = base.6L(((double) rc.Y));
                objArray1[2] = base.6L(((double) rc.Width));
                objArray1[3] = base.6L(((double) rc.Height));
                base.Write("{0} {1} {2} {3} re W n\r\n", objArray1);
            }
            int num1 = text.Length;
            Point[] pointArray2 = pointArray1;
            for (num2 = 0; (num2 < pointArray2.Length); num2 += 1)
            {
                point1 = pointArray2[num2];
                text1 = text.Substring(point1.X, point1.Y);
                base.TextOut(text1, tf1, sf.Alignment, false);
                PointF* tfPtr5 = &tf1;
                tf1.Y = (tfPtr5.Y - single2);
                if (tf1.Y < (rc.Y + font.Size))
                {
                    num1 = (point1.X + point1.Y);
                    break;
                }
            }
            if (!flag1 && !flag2)
            {
                return num1;
            }
            base.Write("Q\r\n", new object[0]);
            return num1;
        }

        public void DrawStringRtf(string text, Font font, Brush brush, RectangleF rc)
        {
            if ((rc.Width <= 0f) || (rc.Height <= 0f))
            {
                return;
            }
            0Q q1 = this.6Y(text, font, brush);
            Metafile metafile1 = q1.9V(rc.Size);
            this.6X(metafile1, rc, rc, true, false);
            metafile1.Dispose();
            q1.Dispose();
        }

        public void FillArc(Brush brush, RectangleF rc, float startAngle, float sweepAngle)
        {
            Color color1;
            SolidBrush brush1 = (brush as SolidBrush);
            if (brush1 != null)
            {
                color1 = brush1.Color;
                if (!color1.Equals(Color.Transparent))
                {
                    goto Label_0025;
                }
            }
            return;
        Label_0025:
            base.SetBrush(brush);
            base.UpdateResources(brush);
            rc = this.73(rc);
            base.PieArc(rc, startAngle, sweepAngle, false);
            this.6S(true, true, false);
        }

        public void FillEllipse(Brush brush, RectangleF rc)
        {
            Color color1;
            SolidBrush brush1 = (brush as SolidBrush);
            if (brush1 != null)
            {
                color1 = brush1.Color;
                if (!color1.Equals(Color.Transparent))
                {
                    goto Label_0025;
                }
            }
            return;
        Label_0025:
            base.SetBrush(brush);
            base.UpdateResources(brush);
            rc = this.73(rc);
            base.Ellipse(rc);
            this.6S(false, true, false);
        }

        public void FillEllipse(Brush brush, float x, float y, float width, float height)
        {
            this.FillEllipse(brush, new RectangleF(x, y, width, height));
        }

        public void FillPie(Brush brush, RectangleF rc, float startAngle, float sweepAngle)
        {
            Color color1;
            SolidBrush brush1 = (brush as SolidBrush);
            if (brush1 != null)
            {
                color1 = brush1.Color;
                if (!color1.Equals(Color.Transparent))
                {
                    goto Label_0025;
                }
            }
            return;
        Label_0025:
            base.SetBrush(brush);
            base.UpdateResources(brush);
            rc = this.73(rc);
            base.PieArc(rc, startAngle, sweepAngle, true);
            this.6S(true, true, false);
        }

        public void FillPolygon(Brush brush, PointF[] points)
        {
            this.FillPolygon(brush, points, FillMode.Winding);
        }

        public void FillPolygon(Brush brush, PointF[] points, FillMode fillMode)
        {
            Color color1;
            SolidBrush brush1 = (brush as SolidBrush);
            if (brush1 != null)
            {
                color1 = brush1.Color;
                if (!color1.Equals(Color.Transparent))
                {
                    goto Label_0025;
                }
            }
            return;
        Label_0025:
            base.SetBrush(brush);
            base.UpdateResources(brush);
            points = this.74(points);
            base.Polygon(points);
            this.6T(true, true, false, fillMode);
        }

        public void FillRectangle(Brush brush, RectangleF rc)
        {
            Color color1;
            SolidBrush brush1 = (brush as SolidBrush);
            if (brush1 != null)
            {
                color1 = brush1.Color;
                if (!color1.Equals(Color.Transparent))
                {
                    goto Label_0025;
                }
            }
            return;
        Label_0025:
            base.SetBrush(brush);
            base.UpdateResources(brush);
            rc = this.73(rc);
            base.Rectangle(rc);
            this.6S(false, true, false);
        }

        public void FillRectangle(Brush brush, RectangleF rc, SizeF corners)
        {
            Color color1;
            SolidBrush brush1 = (brush as SolidBrush);
            if (brush1 != null)
            {
                color1 = brush1.Color;
                if (!color1.Equals(Color.Transparent))
                {
                    goto Label_0025;
                }
            }
            return;
        Label_0025:
            base.SetBrush(brush);
            base.UpdateResources(brush);
            rc = this.73(rc);
            base.RoundRect(rc, corners);
            this.6S(true, true, false);
        }

        public void FillRectangle(Brush brush, float x, float y, float width, float height)
        {
            this.FillRectangle(brush, new RectangleF(x, y, width, height));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Assembly GetCallingAssembly()
        {
            return this.P0;
        }

        public SizeF MeasureString(string text, Font font)
        {
            return this.MeasureString(text, font, -1f, StringFormat.GenericDefault);
        }

        public SizeF MeasureString(string text, Font font, float width)
        {
            return this.MeasureString(text, font, width, StringFormat.GenericDefault);
        }

        public SizeF MeasureString(string text, Font font, float width, StringFormat sf)
        {
            RectangleF ef1;
            if (width < 0f)
            {
                return C1PdfDocumentBase.MeasureText(text, font);
            }
            float single1 = this.78(font);
            ef1 = new RectangleF(0f, 0f, width, 2.147484E+09f);
            Point[] pointArray1 = C1PdfDocument.79(text, font, ef1, sf);
            float single2 = ((((float) pointArray1.Length) * single1) + 0.5f);
            return new SizeF(width, single2);
        }

        public SizeF MeasureStringRtf(string text, Font font, float width)
        {
            SizeF ef1;
            ef1 = new SizeF(width, 0f);
            using (0Q q1 = this.6Y(text, font, null))
            {
                ef1.Height = q1.9U(width);
                return ef1;
            }
            return ef1;
        }


        // Properties
        [DefaultValue(false), E("Landscape", "Gets or sets the default page orientation for the document.")]
        public bool Landscape
        {
            get
            {
                return this.OW;
            }
            set
            {
                this.6P(this.PaperKind, value);
            }
        }

        public override SizeF PageSize
        {
            get
            {
                return base.PageSize;
            }
            set
            {
                base.PageSize = value;
                this.OV = PaperKind.Custom;
                this.OW = false;
            }
        }

        [DefaultValue(1), E("PaperKind", "Gets or sets the default page size for the document.")]
        public PaperKind PaperKind
        {
            get
            {
                return this.OV;
            }
            set
            {
                this.6P(value, this.Landscape);
            }
        }


        // Fields
        private PaperKind OV;
        private bool OW;
        private FillMode OX;
        private static StringFormat OY;
        internal 08 OZ;
        private Assembly P0;
        private static string P1;

        // Nested Types
        internal delegate bool 08(C1PdfDocument document, 0M meta, EmfPlusRecordType recordType, int flags, BinaryReader br);

    }
}


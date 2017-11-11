namespace C1.C1Pdf
{
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.InteropServices;

    internal class 0M
    {
        // Methods
        internal 0M(C1PdfDocument doc)
        {
            this.TX = doc;
            this.U4 = new EnumerateMetafileProc(this.8A);
        }

        internal void 87(Metafile 0AN)
        {
            this.88(0AN, false, false, null);
        }

        internal void 88(Metafile 0AO, bool 0AP, bool 0AQ, float[] 0AR)
        {
            0AO = this.89(0AO);
            this.TY = new Hashtable();
            this.UB = ((SolidBrush) Brushes.Black);
            this.UC = ((SolidBrush) Brushes.Transparent);
            this.U9 = Brushes.Black;
            this.U8 = Pens.Black;
            this.UE = true;
            this.U1 = 0AP;
            this.U2 = 0AQ;
            this.U3 = 0AR;
            this.U0 = 0AO;
            this.TZ = new PointF(0AO.HorizontalResolution, 0AO.VerticalResolution);
            Bitmap bitmap1 = new Bitmap(5, 5);
            Graphics graphics1 = Graphics.FromImage(bitmap1);
            0T t1 = new 0T(false);
            this.UI = t1.Y6;
            0M.97(this.UI, 2);
            graphics1.EnumerateMetafile(0AO, PointF.Empty, this.U4);
            this.UI = IntPtr.Zero;
            this.TY.Clear();
            try
            {
                t1.Dispose();
            }
            catch
            {
            }
            try
            {
                graphics1.Dispose();
                bitmap1.Dispose();
            }
            catch
            {
            }
        }

        private Metafile 89(Metafile 0AS)
        {
            RectangleF ef2;
            IntPtr ptr1;
            Metafile metafile1;
            if (0AS.GetMetafileHeader().Type == MetafileType.Emf)
            {
                return 0AS;
            }
            SizeF ef1 = C1PdfDocument.76(0AS);
            ef2 = new RectangleF(PointF.Empty, ef1);
            using (Graphics graphics1 = Graphics.FromHwnd(IntPtr.Zero))
            {
                ptr1 = graphics1.GetHdc();
                metafile1 = new Metafile(ptr1, ef2, MetafileFrameUnit.Point, EmfType.EmfOnly);
                using (Graphics graphics2 = Graphics.FromImage(metafile1))
                {
                    graphics2.DrawImageUnscaled(0AS, 0, 0);
                }
                0AS = metafile1;
                graphics1.ReleaseHdc(ptr1);
            }
            return 0AS;
        }

        private bool 8A(EmfPlusRecordType 0AT, int 0AU, int 0AV, IntPtr 0AW, PlayRecordCallback 0AX)
        {
            bool flag1;
            int num1;
            RectangleF ef1;
            PointF tf1;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            SizeF ef2;
            RectangleF ef3;
            RectangleF ef4;
            PointF tf2;
            SizeF ef5;
            int num7;
            int num8;
            int num9;
            int num10;
            int num11;
            RectangleF ef6;
            RectangleF ef7;
            PointF tf3;
            SizeF ef8;
            int num12;
            int num13;
            object obj1;
            PointF tf4;
            RectangleF ef9;
            RectangleF ef10;
            RectangleF ef11;
            SizeF ef12;
            FillMode mode1;
            BinaryReader reader1 = null;
            byte[] numArray1 = null;
            if ((0AW != IntPtr.Zero) && (0AV > 0))
            {
                numArray1 = new byte[((uint) 0AV)];
                Marshal.Copy(0AW, numArray1, 0, 0AV);
                reader1 = new BinaryReader(new MemoryStream(numArray1));
            }
            if (this.TX.OZ != null)
            {
                flag1 = this.TX.OZ.Invoke(this.TX, this, 0AT, 0AU, reader1);
                if (reader1 != null)
                {
                    reader1.BaseStream.Position = ((long) 0);
                }
                if (!flag1)
                {
                    return true;
                }
            }
            EmfPlusRecordType type1 = 0AT;
            switch (type1)
            {
                case EmfPlusRecordType.EmfPolyBezier:
                {
                    this.8I(reader1, false, false);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfPolygon:
                {
                    this.8G(reader1, false, true, false);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfPolyline:
                {
                    this.8G(reader1, false, false, false);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfPolyBezierTo:
                {
                    this.8I(reader1, false, true);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfPolyLineTo:
                {
                    this.8G(reader1, false, false, true);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfPolyPolyline:
                {
                    this.8H(reader1, false, false);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfPolyPolygon:
                {
                    this.8H(reader1, false, true);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfSetWindowExtEx:
                case EmfPlusRecordType.EmfScaleWindowExtEx:
                case EmfPlusRecordType.EmfScaleViewportExtEx:
                case EmfPlusRecordType.EmfSetViewportOrgEx:
                case EmfPlusRecordType.EmfSetViewportExtEx:
                case EmfPlusRecordType.EmfSetWindowOrgEx:
                {
                    this.9G(0AT, reader1);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfSetBrushOrgEx:
                case EmfPlusRecordType.EmfPolyDraw16:
                case EmfPlusRecordType.EmfSetDIBitsToDevice:
                case EmfPlusRecordType.EmfPlgBlt:
                case EmfPlusRecordType.EmfMaskBlt:
                case EmfPlusRecordType.EmfExtSelectClipRgn:
                case EmfPlusRecordType.EmfPaintRgn:
                case EmfPlusRecordType.EmfInvertRgn:
                case EmfPlusRecordType.EmfFrameRgn:
                case EmfPlusRecordType.EmfFillRgn:
                case EmfPlusRecordType.EmfReserved069:
                case EmfPlusRecordType.EmfSelectClipPath:
                case EmfPlusRecordType.EmfWidenPath:
                case EmfPlusRecordType.EmfFlattenPath:
                case EmfPlusRecordType.EmfSetMiterLimit:
                case EmfPlusRecordType.EmfPolyDraw:
                case EmfPlusRecordType.EmfExtFloodFill:
                case EmfPlusRecordType.EmfRealizePalette:
                case EmfPlusRecordType.EmfResizePalette:
                case EmfPlusRecordType.EmfSetPaletteEntries:
                case EmfPlusRecordType.EmfCreatePalette:
                case EmfPlusRecordType.EmfSelectPalette:
                case EmfPlusRecordType.EmfAngleArc:
                case EmfPlusRecordType.EmfExcludeClipRect:
                case EmfPlusRecordType.EmfSetMetaRgn:
                case EmfPlusRecordType.EmfOffsetClipRgn:
                case EmfPlusRecordType.EmfSetColorAdjustment:
                case EmfPlusRecordType.EmfSetStretchBltMode:
                case EmfPlusRecordType.EmfSetROP2:
                case EmfPlusRecordType.EmfSetBkMode:
                case EmfPlusRecordType.EmfSetMapperFlags:
                case EmfPlusRecordType.EmfSetPixelV:
                case EmfPlusRecordType.EmfEof:
                {
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfSetMapMode:
                {
                    goto Label_07F6;
                }
                case EmfPlusRecordType.EmfSetPolyFillMode:
                {
                    mode1 = ((FillMode) ((reader1.ReadInt32() == 1) ? 0 : 1));
                    this.TX.6U(mode1);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfSetTextAlign:
                {
                    this.UA = reader1.ReadInt32();
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfSetTextColor:
                {
                    this.UB = new SolidBrush(ColorTranslator.FromWin32(reader1.ReadInt32()));
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfSetBkColor:
                {
                    this.UC = new SolidBrush(ColorTranslator.FromWin32(reader1.ReadInt32()));
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfMoveToEx:
                {
                    this.UD = this.8M(reader1);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfIntersectClipRect:
                {
                    this.U6 = this.8L(reader1);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfSaveDC:
                case EmfPlusRecordType.EmfRestoreDC:
                {
                    this.94(0AT, reader1);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfSetWorldTransform:
                case EmfPlusRecordType.EmfModifyWorldTransform:
                {
                    this.99(0AT, reader1);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfSelectObject:
                {
                    num1 = reader1.ReadInt32();
                    obj1 = (((((long) num1) & ((ulong) -2147483648)) != ((long) 0)) ? this.8V(num1) : this.TY[num1]);
                    if ((obj1 is 0N))
                    {
                        this.U7 = ((0N) obj1);
                    }
                    if ((obj1 is Brush))
                    {
                        this.U9 = ((Brush) obj1);
                    }
                    if (!(obj1 is Pen))
                    {
                        goto Label_07FD;
                    }
                    this.U8 = ((Pen) obj1);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfCreatePen:
                {
                    num1 = reader1.ReadInt32();
                    this.TY.Add(num1, this.8Q(reader1));
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfCreateBrushIndirect:
                {
                    num1 = reader1.ReadInt32();
                    this.TY.Add(num1, this.8P(reader1));
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfDeleteObject:
                {
                    num1 = reader1.ReadInt32();
                    if (!this.TY.Contains(num1))
                    {
                        goto Label_07FD;
                    }
                    this.TY.Remove(num1);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfEllipse:
                {
                    ef10 = this.8L(reader1);
                    this.TX.FillEllipse(this.U9, ef10);
                    this.TX.DrawEllipse(this.U8, ef10);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfRectangle:
                {
                    ef9 = this.8L(reader1);
                    this.TX.FillRectangle(this.U9, ef9);
                    this.TX.DrawRectangle(this.U8, ef9);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfRoundRect:
                {
                    ef11 = this.8L(reader1);
                    ef12 = this.8O(reader1);
                    SizeF* efPtr1 = &ef12;
                    ef12.Width = (efPtr1.Width / 2f);
                    SizeF* efPtr2 = &ef12;
                    ef12.Height = (efPtr2.Height / 2f);
                    this.TX.FillRectangle(this.U9, ef11, ef12);
                    this.TX.DrawRectangle(this.U8, ef11, ef12);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfRoundArc:
                case EmfPlusRecordType.EmfArcTo:
                case EmfPlusRecordType.EmfChord:
                {
                    this.8F(reader1, false);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfPie:
                {
                    this.8F(reader1, true);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfLineTo:
                {
                    tf4 = this.8M(reader1);
                    this.TX.DrawLine(this.U8, this.UD, tf4);
                    this.UD = tf4;
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfSetArcDirection:
                {
                    this.UE = (reader1.ReadInt32() == 2);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfBeginPath:
                case EmfPlusRecordType.EmfAbortPath:
                case EmfPlusRecordType.EmfStrokePath:
                case EmfPlusRecordType.EmfStrokeAndFillPath:
                case EmfPlusRecordType.EmfFillPath:
                case EmfPlusRecordType.EmfCloseFigure:
                case EmfPlusRecordType.EmfEndPath:
                {
                    this.8B(0AT);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfGdiComment:
                {
                    this.8C(reader1);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfBitBlt:
                {
                    ef7 = this.8K(reader1);
                    tf3 = this.8M(reader1);
                    ef8 = this.8O(reader1);
                    num12 = reader1.ReadInt32();
                    this.8M(reader1);
                    this.8U(reader1);
                    reader1.ReadInt32();
                    reader1.ReadInt32();
                    reader1.ReadInt32();
                    num13 = reader1.ReadInt32();
                    reader1.ReadInt32();
                    reader1.ReadInt32();
                    ef7 = new RectangleF(tf3, ef8);
                    if ((num12 != 15728673) || (num13 != 0))
                    {
                        goto Label_07FD;
                    }
                    this.TX.FillRectangle(this.U9, ef7);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfStretchBlt:
                {
                    ef4 = this.8K(reader1);
                    tf2 = this.8M(reader1);
                    ef5 = this.8O(reader1);
                    num7 = reader1.ReadInt32();
                    this.8M(reader1);
                    this.8U(reader1);
                    reader1.ReadInt32();
                    reader1.ReadInt32();
                    num8 = reader1.ReadInt32();
                    num9 = reader1.ReadInt32();
                    num10 = reader1.ReadInt32();
                    num11 = reader1.ReadInt32();
                    this.8O(reader1);
                    ef6 = new RectangleF(tf2, ef5);
                    if ((num7 == 15728673) && (num9 == 0))
                    {
                        this.TX.FillRectangle(this.U9, ef6);
                    }
                    if (((num7 != 13369376) && (num7 != 15597702)) || (num8 == 0))
                    {
                        goto Label_07FD;
                    }
                    this.8E(reader1, numArray1, ef6, ef4, num7, num8, num9, num10, num11);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfStretchDIBits:
                {
                    ef1 = this.8K(reader1);
                    tf1 = this.8M(reader1);
                    this.8M(reader1);
                    this.8O(reader1);
                    num2 = reader1.ReadInt32();
                    num3 = reader1.ReadInt32();
                    num4 = reader1.ReadInt32();
                    num5 = reader1.ReadInt32();
                    reader1.ReadInt32();
                    num6 = reader1.ReadInt32();
                    ef2 = this.8O(reader1);
                    ef3 = new RectangleF(tf1, ef2);
                    this.8E(reader1, numArray1, ef3, ef1, num6, num2, num3, num4, num5);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfExtCreateFontIndirect:
                {
                    num1 = reader1.ReadInt32();
                    this.TY.Add(num1, this.8T(reader1));
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfExtTextOutA:
                {
                    this.8D(reader1, false);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfExtTextOutW:
                {
                    this.8D(reader1, true);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfPolyBezier16:
                {
                    this.8I(reader1, true, false);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfPolygon16:
                {
                    this.8G(reader1, true, true, false);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfPolyline16:
                {
                    this.8G(reader1, true, false, false);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfPolyBezierTo16:
                {
                    this.8I(reader1, true, true);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfPolylineTo16:
                {
                    this.8G(reader1, true, false, true);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfPolyPolyline16:
                {
                    this.8H(reader1, true, false);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfPolyPolygon16:
                {
                    this.8H(reader1, true, true);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfCreateMonoBrush:
                case EmfPlusRecordType.EmfCreateDibPatternBrushPt:
                {
                    num1 = reader1.ReadInt32();
                    this.TY.Add(num1, this.U9);
                    goto Label_07FD;
                }
                case EmfPlusRecordType.EmfExtCreatePen:
                {
                    num1 = reader1.ReadInt32();
                    this.TY.Add(num1, this.8R(reader1));
                    goto Label_07FD;
                }
            }
            goto Label_07FD;
        Label_07F6:
            this.9I(reader1);
        Label_07FD:
            this.U5 = 0AT;
            return true;
        }

        private void 8B(EmfPlusRecordType 0AY)
        {
            EmfPlusRecordType type1 = 0AY;
            switch (type1)
            {
                case EmfPlusRecordType.EmfBeginPath:
                {
                    this.UF = false;
                    this.TX.6Q(this.U8, this.U9);
                }
                case EmfPlusRecordType.EmfEndPath:
                {
                    this.TX.6R();
                }
                case EmfPlusRecordType.EmfCloseFigure:
                {
                    this.UF = true;
                }
                case EmfPlusRecordType.EmfFillPath:
                {
                    this.TX.6S(this.UF, true, false);
                }
                case EmfPlusRecordType.EmfStrokeAndFillPath:
                {
                    this.TX.6S(this.UF, true, true);
                }
                case EmfPlusRecordType.EmfStrokePath:
                {
                    this.TX.6S(this.UF, false, true);
                }
            }
        }

        private void 8C(BinaryReader 0AZ)
        {
            string[] textArray1;
            int num4;
            string text2;
            int num5;
            string[] textArray2;
            string text3;
            char[] chArray1;
            int num1 = 0AZ.ReadInt32();
            if (num1 < 20)
            {
                return;
            }
            uint num2 = 0AZ.ReadUInt32();
            if (num2 != -2004353023)
            {
                return;
            }
            RectangleF ef1 = this.8L(0AZ);
            int num3 = 0AZ.ReadInt32();
            byte[] numArray1 = 0AZ.ReadBytes((2 * num3));
            string text1 = Encoding.Unicode.GetString(numArray1);
            ef1 = this.8J(ef1);
            if (text1.StartsWith("%PDFHdr|"))
            {
                try
                {
                    chArray1 = new char[1];
                    chArray1[0] = '|';
                    textArray1 = text1.Split(chArray1);
                    num4 = int.Parse(textArray1[1]);
                    text2 = textArray1[2];
                    for (num5 = 3; (num5 < textArray1.Length); num5 += 1)
                    {
                        text2 = text2 + "|" + textArray1[num5];
                    }
                    this.TX.AddBookmark(text2, num4, ef1.Y);
                    return;
                }
                catch
                {
                    return;
                }
                return;
            }
            if (text1.StartsWith("%PDFLink|"))
            {
                chArray1 = new char[1];
                chArray1[0] = '|';
                textArray2 = text1.Split(chArray1);
                text3 = ((textArray2.Length > 1) ? textArray2[1] : string.Empty);
                if (text3.Length <= 0)
                {
                    return;
                }
                this.TX.AddLink(text3, ef1);
                return;
            }
            if (!text1.StartsWith("%PDFName|"))
            {
                return;
            }
            chArray1 = new char[1];
            chArray1[0] = '|';
            string[] textArray3 = text1.Split(chArray1);
            string text4 = ((textArray3.Length > 1) ? textArray3[1] : string.Empty);
            if (text4.Length > 0)
            {
                this.TX.AddTarget(text4, ef1);
            }
        }

        private void 8D(BinaryReader 0B0, bool 0B1)
        {
            byte[] numArray1;
            int num4;
            byte[] numArray2;
            PointF tf2;
            RectangleF ef3;
            StringAlignment alignment1;
            bool flag2;
            object[] objArray1;
            RectangleF ef1 = this.8K(0B0);
            0B0.ReadInt32();
            0B0.ReadSingle();
            0B0.ReadSingle();
            PointF tf1 = this.8M(0B0);
            int num1 = 0B0.ReadInt32();
            int num2 = 0B0.ReadInt32();
            int num3 = 0B0.ReadInt32();
            RectangleF ef2 = this.8L(0B0);
            0B0.ReadInt32();
            if (((num3 & 2) != 0) && !this.U1)
            {
                this.TX.FillRectangle(this.UC, ef2);
            }
            if (num1 == 0)
            {
                return;
            }
            if (((num3 & 4) == 0) && (this.U2 || (this.U5 == EmfPlusRecordType.EmfIntersectClipRect)))
            {
                if (num3 == 0)
                {
                    ef2 = ef1;
                }
                if (this.U5 == EmfPlusRecordType.EmfIntersectClipRect)
                {
                    ef2 = this.U6;
                }
                num3 |= 4;
            }
            0B0.BaseStream.Position = ((long) (num2 - 8));
            string text1 = string.Empty;
            if (0B1)
            {
                numArray1 = 0B0.ReadBytes((2 * num1));
                for (num4 = 1; (num4 < numArray1.Length); num4 += 2)
                {
                    if (numArray1[num4] == 240)
                    {
                        numArray1[num4] = 0;
                    }
                }
                text1 = Encoding.Unicode.GetString(numArray1);
            }
            else
            {
                numArray2 = 0B0.ReadBytes(num1);
                text1 = Encoding.Default.GetString(numArray2);
            }
            if ((text1.Trim().Length == 0) || (this.U7 == null))
            {
                return;
            }
            bool flag1 = ((num3 & 4) != 0);
            if (flag1 || (this.U7.Y3 != 0f))
            {
                this.TX.Write("q ", new object[0]);
            }
            if (this.U7.Y3 != 0f)
            {
                using (Matrix matrix1 = new Matrix())
                {
                    tf2 = this.TX.72(tf1);
                    matrix1.RotateAt(this.U7.Y3, tf2);
                    objArray1 = new object[6];
                    objArray1[0] = this.TX.6L(((double) matrix1.Elements[0]));
                    objArray1[1] = this.TX.6L(((double) matrix1.Elements[1]));
                    objArray1[2] = this.TX.6L(((double) matrix1.Elements[2]));
                    objArray1[3] = this.TX.6L(((double) matrix1.Elements[3]));
                    objArray1[4] = this.TX.6L(((double) matrix1.Elements[4]));
                    objArray1[5] = this.TX.6L(((double) matrix1.Elements[5]));
                    this.TX.Write("{0} {1} {2} {3} {4} {5} cm\r\n", objArray1);
                }
            }
            if (flag1 && (this.U7.Y3 == 0f))
            {
                ef3 = this.TX.73(ef2);
                objArray1 = new object[4];
                objArray1[0] = this.TX.6L(((double) ef3.Left));
                objArray1[1] = this.TX.6L(((double) ef3.Top));
                objArray1[2] = this.TX.6L(((double) ef3.Width));
                objArray1[3] = this.TX.6L(((double) ef3.Height));
                this.TX.Write("{0} {1} {2} {3} re W n\r\n", objArray1);
            }
            if (text1.Length > 0)
            {
                alignment1 = StringAlignment.Near;
                if ((this.UA & 6) == 6)
                {
                    alignment1 = StringAlignment.Center;
                }
                else if ((this.UA & 2) == 2)
                {
                    alignment1 = StringAlignment.Far;
                }
                flag2 = ((this.UA & 24) != 0);
				// Metodo que imprime texto
                this.TX.6V(text1, 0N.op_Implicit(this.U7), this.UB, tf1, alignment1, flag2);
            }
            if (!flag1 && (this.U7.Y3 == 0f))
            {
                return;
            }
            this.TX.Write("Q\r\n", new object[0]);
        }

        private void 8E(BinaryReader 0B2, byte[] 0B3, RectangleF 0B4, RectangleF 0B5, int 0B6, int 0B7, int 0B8, int 0B9, int 0BA)
        {
            0I i1 = new 0I(0B2, 0B3, 0B7, 0B8, 0B9, 0BA);
            if (!i1.XY)
            {
                return;
            }
            if ((0B6 == 8913094) && i1.XZ)
            {
                this.UG = i1;
                return;
            }
            if ((this.UG != null) && (i1.Y0 == this.UG.Y0))
            {
                if (0B6 == 6684742)
                {
                    i1.7X(this.UG);
                    this.TX.63(this.UG);
                }
                if ((0B6 == 15597702) && i1.XZ)
                {
                    i1 = this.UG;
                }
            }
            this.TX.6W(i1, 0B4, 0B5);
            this.UG = null;
        }

        private void 8F(BinaryReader 0BB, bool 0BC)
        {
            RectangleF ef1 = this.8L(0BB);
            PointF tf1 = this.8M(0BB);
            PointF tf2 = this.8M(0BB);
            float single1 = (ef1.Width / 2f);
            float single2 = (ef1.Height / 2f);
            float single3 = (ef1.X + single1);
            float single4 = (ef1.Y + single2);
            float single5 = ((single2 > 0f) ? (single2 / single1) : 1f);
            float single6 = ((float) Math.Atan2(((double) (tf1.Y - single4)), ((double) (single5 * (tf1.X - single3)))));
            float single7 = ((float) Math.Atan2(((double) (tf2.Y - single4)), ((double) (single5 * (tf2.X - single3)))));
            single6 = ((float) Math.Round((((double) (single6 * 180f)) / 3.1415926535897931f), 4));
            single7 = ((float) Math.Round((((double) (single7 * 180f)) / 3.1415926535897931f), 4));
            if (!this.UE)
            {
                goto Label_0102;
            }
            while ((single7 > single6))
            {
                single7 -= 360f;
            }
            goto Label_0108;
        Label_00F8:
            single7 += 360f;
        Label_0102:
            if (single7 < single6)
            {
                goto Label_00F8;
            }
        Label_0108:
            if (0BC)
            {
                this.TX.FillPie(this.U9, ef1, single6, (single7 - single6));
                this.TX.DrawPie(this.U8, ef1, single6, (single7 - single6));
                return;
            }
            this.TX.FillArc(this.U9, ef1, single6, (single7 - single6));
            this.TX.DrawArc(this.U8, ef1, single6, (single7 - single6));
        }

        private void 8G(BinaryReader 0BD, bool 0BE, bool 0BF, bool 0BG)
        {
            int num3;
            this.8L(0BD);
            int num1 = 0BD.ReadInt32();
            if (0BG)
            {
                num1 += 1;
            }
            PointF[] tfArray1 = new PointF[((uint) num1)];
            int num2 = 0;
            if (0BG)
            {
                int num4 = num2;
                num2 = (num4 + 1);
                tfArray1[num2] = this.UD;
            }
            for (num3 = num2; (num3 < num1); num3 += 1)
            {
                tfArray1[num3] = (0BE ? this.8N(0BD) : this.8M(0BD));
            }
            if (0BF)
            {
                this.TX.FillPolygon(this.U9, tfArray1);
                this.TX.DrawPolygon(this.U8, tfArray1);
            }
            else
            {
                this.TX.DrawLines(this.U8, tfArray1);
            }
            if (0BG)
            {
                this.UD = tfArray1[(num1 - 1)];
            }
        }

        private void 8H(BinaryReader 0BH, bool 0BI, bool 0BJ)
        {
            int num2;
            int num3;
            int num4;
            PointF[] tfArray1;
            int num5;
            this.8L(0BH);
            int num1 = 0BH.ReadInt32();
            0BH.ReadInt32();
            int[] numArray1 = new int[((uint) num1)];
            for (num2 = 0; (num2 < num1); num2 += 1)
            {
                numArray1[num2] = 0BH.ReadInt32();
            }
            for (num3 = 0; (num3 < num1); num3 += 1)
            {
                num4 = numArray1[num3];
                tfArray1 = new PointF[((uint) num4)];
                for (num5 = 0; (num5 < num4); num5 += 1)
                {
                    tfArray1[num5] = (0BI ? this.8N(0BH) : this.8M(0BH));
                }
                if (0BJ)
                {
                    this.TX.FillPolygon(this.U9, tfArray1);
                    this.TX.DrawPolygon(this.U8, tfArray1);
                }
                else
                {
                    this.TX.DrawLines(this.U8, tfArray1);
                }
            }
        }

        private void 8I(BinaryReader 0BK, bool 0BL, bool 0BM)
        {
            int num3;
            this.8L(0BK);
            int num1 = 0BK.ReadInt32();
            if (0BM)
            {
                num1 += 1;
            }
            PointF[] tfArray1 = new PointF[((uint) num1)];
            int num2 = 0;
            if (0BM)
            {
                int num4 = num2;
                num2 = (num4 + 1);
                tfArray1[num2] = this.UD;
            }
            for (num3 = num2; (num3 < tfArray1.Length); num3 += 1)
            {
                tfArray1[num3] = (0BL ? this.8N(0BK) : this.8M(0BK));
            }
            this.TX.DrawBeziers(this.U8, tfArray1);
            if (0BM)
            {
                this.UD = tfArray1[(tfArray1.Length - 1)];
            }
        }

        internal RectangleF 8J(RectangleF 0BN)
        {
            if (this.U3 != null)
            {
                0BN = this.TX.73(0BN);
                0BN.X = ((0BN.X * this.U3[0]) + this.U3[2]);
                0BN.Y = ((0BN.Y * this.U3[1]) + this.U3[3]);
                RectangleF* efPtr1 = &0BN;
                0BN.Width = (efPtr1.Width * this.U3[0]);
                RectangleF* efPtr2 = &0BN;
                0BN.Height = (efPtr2.Height * this.U3[1]);
                0BN = this.TX.73(0BN);
            }
            return 0BN;
        }

        internal RectangleF 8K(BinaryReader 0BO)
        {
            float single1 = ((((float) 0BO.ReadInt32()) * 72f) / this.TZ.X);
            float single2 = ((((float) 0BO.ReadInt32()) * 72f) / this.TZ.Y);
            float single3 = ((((float) 0BO.ReadInt32()) * 72f) / this.TZ.X);
            float single4 = ((((float) 0BO.ReadInt32()) * 72f) / this.TZ.Y);
            return new RectangleF(single1, single2, ((single3 - single1) + 1f), ((single4 - single2) + 1f));
        }

        internal RectangleF 8L(BinaryReader 0BP)
        {
            PointF tf1 = this.8M(0BP);
            PointF tf2 = this.8M(0BP);
            return new RectangleF(tf1.X, tf1.Y, ((tf2.X - tf1.X) + 1f), ((tf2.Y - tf1.Y) + 1f));
        }

        internal PointF 8M(BinaryReader 0BQ)
        {
            Point point1 = Point.Empty;
            point1.X = 0BQ.ReadInt32();
            point1.Y = 0BQ.ReadInt32();
            return this.9K(Point.op_Implicit(point1));
        }

        internal PointF 8N(BinaryReader 0BR)
        {
            Point point1 = Point.Empty;
            point1.X = ((int) 0BR.ReadInt16());
            point1.Y = ((int) 0BR.ReadInt16());
            return this.9K(Point.op_Implicit(point1));
        }

        internal SizeF 8O(BinaryReader 0BS)
        {
            PointF tf1 = this.9K(PointF.Empty);
            PointF tf2 = this.8M(0BS);
            return new SizeF((tf2.X - tf1.X), (tf2.Y - tf1.Y));
        }

        private Brush 8P(BinaryReader 0BT)
        {
            int num1 = 0BT.ReadInt32();
            int num2 = 0BT.ReadInt32();
            0BT.ReadInt32();
            Color color1 = ((num1 == 1) ? Color.Transparent : ColorTranslator.FromWin32(num2));
            return new SolidBrush(color1);
        }

        private Pen 8Q(BinaryReader 0BU)
        {
            int num1 = 0BU.ReadInt32();
            SizeF ef1 = this.8O(0BU);
            int num2 = 0BU.ReadInt32();
            return this.8S(num2, ef1.Width, num1);
        }

        private Pen 8R(BinaryReader 0BV)
        {
            0BV.ReadInt32();
            0BV.ReadInt32();
            0BV.ReadInt32();
            0BV.ReadInt32();
            int num1 = 0BV.ReadInt32();
            int num2 = 0BV.ReadInt32();
            0BV.ReadInt32();
            int num3 = 0BV.ReadInt32();
            0BV.ReadInt32();
            0BV.ReadInt32();
            return this.8S(num3, this.9M(((float) num2)), num1);
        }

        private Pen 8S(int 0BW, float 0BX, int 0BY)
        {
            Color color1 = ((0BY == 5) ? Color.Transparent : ColorTranslator.FromWin32(0BW));
            Pen pen1 = new Pen(color1, 0BX);
            int num1 = 0BY;
            switch (num1)
            {
                case 1:
                {
                    pen1.DashStyle = DashStyle.Dash;
                    return pen1;
                }
                case 2:
                {
                    pen1.DashStyle = DashStyle.Dot;
                    return pen1;
                }
                case 3:
                {
                    pen1.DashStyle = DashStyle.DashDot;
                    return pen1;
                }
                case 4:
                {
                    pen1.DashStyle = DashStyle.DashDotDot;
                    return pen1;
                }
            }
            return pen1;
        }

        private 0N 8T(BinaryReader 0BZ)
        {
            return new 0N(this, 0BZ);
        }

        private float[] 8U(BinaryReader 0C0)
        {
            int num1;
            float[] singleArray1 = new float[6];
            for (num1 = 0; (num1 < singleArray1.Length); num1 += 1)
            {
                singleArray1[num1] = 0C0.ReadSingle();
            }
            return singleArray1;
        }

        private object 8V(int 0C1)
        {
            if (0M.UH == null)
            {
                0M.UH = new Hashtable();
                0M.UH.Add(0, Brushes.White);
                0M.UH.Add(1, Brushes.LightGray);
                0M.UH.Add(2, Brushes.Gray);
                0M.UH.Add(3, Brushes.DarkGray);
                0M.UH.Add(4, Brushes.Black);
                0M.UH.Add(5, Brushes.Transparent);
                0M.UH.Add(6, Pens.White);
                0M.UH.Add(7, Pens.Black);
                0M.UH.Add(8, Pens.Transparent);
                0M.UH.Add(10, Control.DefaultFont);
                0M.UH.Add(11, Control.DefaultFont);
                0M.UH.Add(12, Control.DefaultFont);
                0M.UH.Add(13, Control.DefaultFont);
                0M.UH.Add(14, Control.DefaultFont);
                0M.UH.Add(15, Control.DefaultFont);
                0M.UH.Add(16, Control.DefaultFont);
                0M.UH.Add(17, Control.DefaultFont);
                0M.UH.Add(18, Brushes.White);
                0M.UH.Add(19, Pens.White);
            }
            if ((((long) 0C1) & ((ulong) -2147483648)) != ((long) 0))
            {
                0C1 = (0C1 & 2147483647);
                return 0M.UH[0C1];
            }
            return null;
        }

        [DllImport("GDI32.DLL", EntryPoint="SaveDC")]
        private static extern IntPtr 8W(IntPtr 0C2);

        [DllImport("GDI32.DLL", EntryPoint="RestoreDC")]
        private static extern IntPtr 8X(IntPtr 0C3, int 0C4);

        [DllImport("GDI32.DLL", EntryPoint="GetTextAlign")]
        private static extern int 8Y(IntPtr 0C5);

        [DllImport("GDI32.DLL", EntryPoint="GetTextColor")]
        private static extern int 8Z(IntPtr 0C6);

        [DllImport("GDI32.DLL", EntryPoint="GetBkColor")]
        private static extern int 90(IntPtr 0C7);

        [DllImport("GDI32.DLL", EntryPoint="SetTextAlign")]
        private static extern int 91(IntPtr 0C8, int 0C9);

        [DllImport("GDI32.DLL", EntryPoint="SetTextColor")]
        private static extern int 92(IntPtr 0CA, int 0CB);

        [DllImport("GDI32.DLL", EntryPoint="SetBkColor")]
        private static extern int 93(IntPtr 0CC, int 0CD);

        private void 94(EmfPlusRecordType 0CE, BinaryReader 0CF)
        {
            IntPtr ptr1 = this.UI;
            EmfPlusRecordType type1 = 0CE;
            switch (type1)
            {
                case EmfPlusRecordType.EmfSaveDC:
                {
                    0M.91(ptr1, this.UA);
                    0M.92(ptr1, ColorTranslator.ToWin32(this.UB.Color));
                    0M.93(ptr1, ColorTranslator.ToWin32(this.UC.Color));
                    0M.8W(ptr1);
                }
                case EmfPlusRecordType.EmfRestoreDC:
                {
                    0M.8X(ptr1, 0CF.ReadInt32());
                    this.UA = 0M.8Y(ptr1);
                    this.UB = new SolidBrush(ColorTranslator.FromWin32(0M.8Z(ptr1)));
                    this.UC = new SolidBrush(ColorTranslator.FromWin32(0M.90(ptr1)));
                }
            }
        }

        [DllImport("GDI32.DLL", EntryPoint="SetWorldTransform")]
        private static extern int 95(IntPtr 0CG, float[] 0CH);

        [DllImport("GDI32.DLL", EntryPoint="ModifyWorldTransform")]
        private static extern int 96(IntPtr 0CI, float[] 0CJ, int 0CK);

        [DllImport("GDI32.DLL", EntryPoint="SetGraphicsMode")]
        private static extern int 97(IntPtr 0CL, int 0CM);

        [DllImport("GDI32.DLL", EntryPoint="GetGraphicsMode")]
        private static extern int 98(IntPtr 0CN);

        private void 99(EmfPlusRecordType 0CO, BinaryReader 0CP)
        {
            double num1;
            double num2;
            object[] objArray1;
            IntPtr ptr1 = this.UI;
            float[] singleArray1 = this.8U(0CP);
            EmfPlusRecordType type1 = 0CO;
            switch (type1)
            {
                case EmfPlusRecordType.EmfSetWorldTransform:
                {
                    0M.95(ptr1, singleArray1);
                    goto Label_003E;
                }
                case EmfPlusRecordType.EmfModifyWorldTransform:
                {
                    goto Label_0030;
                }
            }
            goto Label_003E;
        Label_0030:
            0M.96(ptr1, singleArray1, 0CP.ReadInt32());
        Label_003E:
            if (0M.98(this.UI) != 2)
            {
                num1 = ((double) ((singleArray1[4] * 72f) / this.TZ.X));
                num2 = ((double) ((-singleArray1[5] * 72f) / this.TZ.Y));
                objArray1 = new object[2];
                objArray1[0] = this.TX.6L(num1);
                objArray1[1] = this.TX.6L(num2);
                this.TX.Write("1 0 0 1 {0} {1} cm\r\n", objArray1);
            }
        }

        [DllImport("GDI32.DLL", EntryPoint="ScaleViewportExtEx")]
        private static extern int 9A(IntPtr 0CQ, int 0CR, int 0CS, int 0CT, int 0CU, IntPtr 0CV);

        [DllImport("GDI32.DLL", EntryPoint="ScaleWindowExtEx")]
        private static extern int 9B(IntPtr 0CW, int 0CX, int 0CY, int 0CZ, int 0D0, IntPtr 0D1);

        [DllImport("GDI32.DLL", EntryPoint="SetViewportExtEx")]
        private static extern int 9C(IntPtr 0D2, int 0D3, int 0D4, IntPtr 0D5);

        [DllImport("GDI32.DLL", EntryPoint="SetWindowExtEx")]
        private static extern int 9D(IntPtr 0D6, int 0D7, int 0D8, IntPtr 0D9);

        [DllImport("GDI32.DLL", EntryPoint="SetViewportOrgEx")]
        private static extern int 9E(IntPtr 0DA, int 0DB, int 0DC, IntPtr 0DD);

        [DllImport("GDI32.DLL", EntryPoint="SetWindowOrgEx")]
        private static extern int 9F(IntPtr 0DE, int 0DF, int 0DG, IntPtr 0DH);

        private void 9G(EmfPlusRecordType 0DI, BinaryReader 0DJ)
        {
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            IntPtr ptr1 = this.UI;
            EmfPlusRecordType type1 = 0DI;
            switch (type1)
            {
                case EmfPlusRecordType.EmfSetWindowExtEx:
                case EmfPlusRecordType.EmfSetViewportExtEx:
                {
                    num5 = 0DJ.ReadInt32();
                    num6 = 0DJ.ReadInt32();
                    if (0DI != EmfPlusRecordType.EmfSetViewportExtEx)
                    {
                        goto Label_00A3;
                    }
                    0M.9C(ptr1, num5, num6, IntPtr.Zero);
                    return;
                }
                case EmfPlusRecordType.EmfSetWindowOrgEx:
                case EmfPlusRecordType.EmfSetViewportOrgEx:
                {
                    num7 = 0DJ.ReadInt32();
                    num8 = 0DJ.ReadInt32();
                    if (0DI != EmfPlusRecordType.EmfSetViewportOrgEx)
                    {
                        goto Label_00DA;
                    }
                    0M.9E(ptr1, num7, num8, IntPtr.Zero);
                    return;
                }
            }
            switch (type1)
            {
                case EmfPlusRecordType.EmfScaleViewportExtEx:
                case EmfPlusRecordType.EmfScaleWindowExtEx:
                {
                    num1 = 0DJ.ReadInt32();
                    num2 = 0DJ.ReadInt32();
                    num3 = 0DJ.ReadInt32();
                    num4 = 0DJ.ReadInt32();
                    if (0DI != EmfPlusRecordType.EmfScaleViewportExtEx)
                    {
                        goto Label_006B;
                    }
                    0M.9A(ptr1, num1, num2, num3, num4, IntPtr.Zero);
                    return;
                }
            }
            return;
        Label_006B:
            0M.9B(ptr1, num1, num2, num3, num4, IntPtr.Zero);
            return;
        Label_00A3:
            0M.9D(ptr1, num5, num6, IntPtr.Zero);
            return;
        Label_00DA:
            0M.9F(ptr1, num7, num8, IntPtr.Zero);
        }

        [DllImport("GDI32.DLL", EntryPoint="SetMapMode")]
        private static extern IntPtr 9H(IntPtr 0DK, int 0DL);

        private void 9I(BinaryReader 0DM)
        {
            0M.9H(this.UI, 0DM.ReadInt32());
        }

        [DllImport("GDI32.DLL", EntryPoint="LPtoDP")]
        private static extern IntPtr 9J(IntPtr 0DN, ref Point 0DO, int 0DP);

        internal PointF 9K(PointF 0DQ)
        {
            Point point1 = Point.Truncate(0DQ);
            0M.9J(this.UI, ref point1, 1);
            0DQ.X = ((((float) point1.X) * 72f) / this.TZ.X);
            0DQ.Y = ((((float) point1.Y) * 72f) / this.TZ.Y);
            return 0DQ;
        }

        internal SizeF 9L(SizeF 0DR)
        {
            PointF tf1 = this.9K(PointF.Empty);
            PointF tf2 = this.9K(new PointF(0DR.Width, 0DR.Height));
            return new SizeF(Math.Abs((tf2.X - tf1.X)), Math.Abs((tf2.Y - tf1.Y)));
        }

        internal float 9M(float 0DS)
        {
            PointF tf1 = this.9K(PointF.Empty);
            PointF tf2 = this.9K(new PointF(0DS, 0DS));
            return Math.Abs((tf2.Y - tf1.Y));
        }

        internal RectangleF 9N(RectangleF 0DT)
        {
            0DT.Location = this.9K(0DT.Location);
            0DT.Size = this.9L(0DT.Size);
            return 0DT;
        }


        // Fields
        private const int ST = 2;
        private const int SU = 4;
        private const int SV = 1;
        private const int SW = 2;
        private const int SX = 24;
        private const int SY = 8;
        private const int SZ = 0;
        private const int T0 = 6;
        private const int T1 = 0;
        private const int T2 = 2;
        private const int T3 = 15;
        private const int T4 = 0;
        private const int T5 = 1;
        private const int T6 = 2;
        private const int T7 = 3;
        private const int T8 = 4;
        private const int T9 = 5;
        private const int TA = 1;
        private const int TB = 700;
        private const int TC = 1;
        private const int TD = 2;
        private const int TE = 1;
        private const int TF = 2;
        private const int TG = 1;
        private const int TH = 2;
        private const int TI = 13369376;
        private const int TJ = 15597702;
        private const int TK = 8913094;
        private const int TL = 6684742;
        private const int TM = 4457256;
        private const int TN = 3342344;
        private const int TO = 1114278;
        private const int TP = 12583114;
        private const int TQ = 12255782;
        private const int TR = 15728673;
        private const int TS = 16452105;
        private const int TT = 5898313;
        private const int TU = 5570569;
        private const int TV = 66;
        private const int TW = 16711778;
        private C1PdfDocument TX;
        private Hashtable TY;
        private PointF TZ;
        private Metafile U0;
        private bool U1;
        private bool U2;
        private float[] U3;
        private EnumerateMetafileProc U4;
        private EmfPlusRecordType U5;
        private RectangleF U6;
        private 0N U7;
        private Pen U8;
        private Brush U9;
        private int UA;
        private SolidBrush UB;
        private SolidBrush UC;
        private PointF UD;
        private bool UE;
        private bool UF;
        private 0I UG;
        private static Hashtable UH;
        private IntPtr UI;

        // Nested Types
        private class 0N : IDisposable
        {
            // Methods
            internal 0N(0M pdf, BinaryReader br)
            {
                PointF tf1;
                PointF tf2;
                0F f1 = new 0F();
                f1.RO = br.ReadInt32();
                f1.RP = br.ReadInt32();
                f1.RQ = br.ReadInt32();
                f1.RR = br.ReadInt32();
                f1.RS = br.ReadInt32();
                f1.RT = br.ReadByte();
                f1.RU = br.ReadByte();
                f1.RV = br.ReadByte();
                f1.RW = br.ReadByte();
                f1.RX = br.ReadByte();
                f1.RY = br.ReadByte();
                f1.RZ = br.ReadByte();
                f1.S0 = br.ReadByte();
                byte[] numArray1 = br.ReadBytes(64);
                f1.S1 = Encoding.Unicode.GetString(numArray1, 0, numArray1.Length);
                float single1 = pdf.9M(((float) Math.Abs(f1.RO)));
                FontStyle style1 = FontStyle.Regular;
                if (f1.RS >= 700)
                {
                    style1 |= FontStyle.Bold;
                }
                if (f1.RT != 0)
                {
                    style1 |= FontStyle.Italic;
                }
                if (f1.RU != 0)
                {
                    style1 |= FontStyle.Underline;
                }
                if (f1.RV != 0)
                {
                    style1 |= FontStyle.Strikeout;
                }
                this.UJ = new Font(f1.S1, single1, style1);
                if (f1.RQ != 0)
                {
                    tf1 = pdf.9K(PointF.Empty);
                    tf2 = pdf.9K(new PointF(0f, 100f));
                    if (tf2.Y < tf1.Y)
                    {
                        f1.RQ = -f1.RQ;
                    }
                }
                this.UK = ((float) (f1.RQ / 10));
            }

            private void 9O()
            {
                this.UJ.Dispose();
                this.UJ = null;
            }

            public static @implicit operator Font(0N mf)
            {
                return mf.UJ;
            }


            // Properties
            internal Font Y2
            {
                get
                {
                    return this.UJ;
                }
            }

            internal float Y3
            {
                get
                {
                    return this.UK;
                }
            }


            // Fields
            private Font UJ;
            private float UK;
        }
    }
}


namespace C1.C1Pdf
{
    using C1.C1Zip;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    internal class 0H
    {
        // Methods
        static 0H()
        {
            0H.S3 = Color.FromArgb(254, 254, 254);
        }

        internal 0H(Image image)
        {
            this.S5 = image;
        }

        internal virtual void 7T(C1PdfDocumentBase 0A6)
        {
            byte[] numArray1;
            MemoryStream stream1;
            this.S4 = 0A6.65("Image");
            if (((this.S5 is Bitmap) && (this.S5.PixelFormat == PixelFormat.Format1bppIndexed)) && ((this.S5.Width * this.S5.Height) < 1000000))
            {
                numArray1 = this.7W(((Bitmap) this.S5), 0A6.Compression);
                0A6.67();
                0A6.68("Type", "/XObject");
                0A6.68("Subtype", "/Image");
                0A6.68("Filter", "/FlateDecode");
                0A6.6A("Length", ((long) numArray1.Length));
                0A6.6A("Width", ((long) this.S5.Width));
                0A6.6A("Height", ((long) this.S5.Height));
                0A6.68("ColorSpace", "/DeviceGray");
                0A6.6A("BitsPerComponent", ((long) 1));
                0A6.6B();
                0A6.6E(this.S4, numArray1);
                0A6.66();
                return;
            }
            bool flag1 = ((bool) (Image.IsAlphaPixelFormat(this.S5.PixelFormat) ? 1 : this.S5.RawFormat.Equals(ImageFormat.Gif)));
            if ((this.S5 is Bitmap) && !flag1)
            {
                stream1 = new MemoryStream();
                this.7U(0A6, this.S5, stream1);
                numArray1 = stream1.ToArray();
                0A6.67();
                0A6.68("Type", "/XObject");
                0A6.68("Subtype", "/Image");
                0A6.68("Filter", "/DCTDecode");
                0A6.6A("Length", ((long) numArray1.Length));
                0A6.6A("Width", ((long) this.S5.Width));
                0A6.6A("Height", ((long) this.S5.Height));
                0A6.6A("BitsPerComponent", ((long) 8));
                0A6.68("ColorSpace", "/DeviceRGB");
                0A6.6B();
                0A6.6E(this.S4, numArray1);
                0A6.66();
                return;
            }
            Bitmap bitmap1 = this.7V(0A6.ImageQuality);
            numArray1 = this.7W(bitmap1, 0A6.Compression);
            0A6.67();
            0A6.68("Type", "/XObject");
            0A6.68("Subtype", "/Image");
            0A6.68("Filter", "/FlateDecode");
            0A6.6A("Length", ((long) numArray1.Length));
            0A6.6A("Width", ((long) bitmap1.Width));
            0A6.6A("Height", ((long) bitmap1.Height));
            0A6.6A("BitsPerComponent", ((long) 8));
            0A6.68("ColorSpace", "/DeviceRGB");
            0A6.68("Mask", this.S6);
            0A6.6B();
            0A6.6E(this.S4, numArray1);
            0A6.66();
        }

        private void 7U(C1PdfDocumentBase 0A7, Image 0A8, Stream 0A9)
        {
            ImageCodecInfo info2;
            EncoderParameters parameters1;
            int num2;
            ImageCodecInfo info1 = null;
            ImageCodecInfo[] infoArray1 = ImageCodecInfo.GetImageEncoders();
            for (num2 = 0; (num2 < infoArray1.Length); num2 += 1)
            {
                info2 = infoArray1[num2];
                if (info2.MimeType == "image/jpeg")
                {
                    info1 = info2;
                    break;
                }
            }
            if (info1 == null)
            {
                this.S5.Save(0A9, ImageFormat.Jpeg);
                return;
            }
            long num1 = ((long) 75);
            ImageQualityEnum enum1 = 0A7.ImageQuality;
            switch (enum1)
            {
                case ImageQualityEnum.Low:
                {
                    num1 = ((long) 25);
                    goto Label_0088;
                }
                case ImageQualityEnum.Medium:
                {
                    num1 = ((long) 50);
                    goto Label_0088;
                }
                case ImageQualityEnum.Default:
                {
                    num1 = ((long) 75);
                    goto Label_0088;
                }
                case ImageQualityEnum.High:
                {
                    goto Label_0084;
                }
            }
            goto Label_0088;
        Label_0084:
            num1 = ((long) 100);
        Label_0088:
            parameters1 = new EncoderParameters();
            parameters1.Param[0] = new EncoderParameter(Encoder.Quality, num1);
            0A8.Save(0A9, info1, parameters1);
        }

        protected Bitmap 7V(ImageQualityEnum 0AA)
        {
            double num2;
            int num1 = 4000000;
            ImageQualityEnum enum1 = 0AA;
            switch (enum1)
            {
                case ImageQualityEnum.Low:
                {
                    num1 = 490000;
                    goto Label_0040;
                }
                case ImageQualityEnum.Medium:
                {
                    num1 = 1000000;
                    goto Label_0040;
                }
                case ImageQualityEnum.Default:
                {
                    num1 = 4000000;
                    goto Label_0040;
                }
                case ImageQualityEnum.High:
                {
                    goto Label_003A;
                }
            }
            goto Label_0040;
        Label_003A:
            num1 = 9000000;
        Label_0040:
            num2 = 1f;
            Size size1 = this.S5.Size;
            if (((size1.Width > 0) && (size1.Height > 0)) && (num1 > 0))
            {
                num2 = (((double) num1) / ((double) (size1.Width * size1.Height)));
                if (num2 < 1f)
                {
                    size1.Width = ((int) (((double) size1.Width) * num2));
                    size1.Height = ((int) (((double) size1.Height) * num2));
                }
            }
            Bitmap bitmap1 = (this.S5 as Bitmap);
            if ((bitmap1 != null) && (num2 >= 1f))
            {
                return bitmap1;
            }
            return new Bitmap(this.S5, size1);
        }

        protected byte[] 7W(Bitmap 0AB, CompressionEnum 0AC)
        {
            byte num4;
            byte num5;
            int num6;
            int num7;
            Color color1;
            bool flag1;
            int num8;
            int num9;
            Color color2;
            int num10;
            int num11;
            int num12;
            int num13;
            MemoryStream stream1 = new MemoryStream();
            X x1 = new X(stream1, 0AC);
            BinaryWriter writer1 = new BinaryWriter(x1);
            int num1 = 0AB.Width;
            int num2 = 0AB.Height;
            this.S6 = null;
            int num3 = 0;
            byte[] numArray1 = new byte[8192];
            if (0AB.PixelFormat == PixelFormat.Format1bppIndexed)
            {
                num4 = 0;
                num5 = 128;
                for (num6 = 0; (num6 < num2); num6 += 1)
                {
                    for (num7 = 0; (num7 < num1); num7 += 1)
                    {
                        color1 = 0AB.GetPixel(num7, num6);
                        if ((color1.ToArgb() & 2184) != 0)
                        {
                            num4 |= num5;
                        }
                        num5 = (num5 >> 1);
                        if ((num5 == 0) || (num7 >= (num1 - 1)))
                        {
                            int num14 = num3;
                            num3 = (num14 + 1);
                            numArray1[num3] = num4;
                            num4 = 0;
                            num5 = 128;
                            if ((num3 + 1) > numArray1.Length)
                            {
                                writer1.Write(numArray1, 0, num3);
                                num3 = 0;
                            }
                        }
                    }
                }
                if (num3 > 0)
                {
                    writer1.Write(numArray1, 0, num3);
                }
            }
            else
            {
                flag1 = false;
                for (num8 = 0; (num8 < num2); num8 += 1)
                {
                    for (num9 = 0; (num9 < num1); num9 += 1)
                    {
                        color2 = 0AB.GetPixel(num9, num8);
                        if (color2.A == 0)
                        {
                            color2 = 0H.S3;
                            flag1 = true;
                        }
                        else
                        {
                            num10 = 8;
                            num11 = ((int) ((color2.R / num10) * num10));
                            num12 = ((int) ((color2.G / num10) * num10));
                            num13 = ((int) ((color2.B / num10) * num10));
                            color2 = Color.FromArgb(color2.A, num11, num12, num13);
                        }
                        int num15 = num3;
                        num3 = (num15 + 1);
                        numArray1[num3] = color2.R;
                        int num16 = num3;
                        num3 = (num16 + 1);
                        numArray1[num3] = color2.G;
                        int num17 = num3;
                        num3 = (num17 + 1);
                        numArray1[num3] = color2.B;
                        if ((num3 + 4) > numArray1.Length)
                        {
                            writer1.Write(numArray1, 0, num3);
                            num3 = 0;
                        }
                    }
                }
                if (num3 > 0)
                {
                    writer1.Write(numArray1, 0, num3);
                }
                if (flag1)
                {
                    this.S6 = string.Format("[{0} {0} {1} {1} {2} {2}]", 0H.S3.R, 0H.S3.G, 0H.S3.B);
                }
            }
            writer1.Close();
            return stream1.ToArray();
        }


        // Fields
        internal static Color S3;
        internal int S4;
        internal Image S5;
        internal string S6;
    }
}


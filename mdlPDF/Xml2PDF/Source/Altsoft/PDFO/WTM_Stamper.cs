namespace Altsoft.PDFO
{
    using System;
    using System.Globalization;
    using System.IO;

    public class WTM_Stamper
    {
        // Methods
        public WTM_Stamper(Document doc, bool bWMAsNewStream, bool bAdd_qQ_ToOrigSc)
        {
            if (doc == null)
            {
                throw new ArgumentException("Invalid document object");
            }
            this.m_sLogoFont = "WTM_F1";
            this.m_sNoteFont = "WTM_F2";
            this.m_sWTM_EGS = "WMT_EGS";
            this.m_bWMAsNewStream = bWMAsNewStream;
            this.m_bAdd_qQ_ToOrigSc = bAdd_qQ_ToOrigSc;
            this.mWTM_LogoFont = doc.Resources[this.BuildFontDict(doc, "Helvetica"), typeof(Font)];
            this.mNumberFormat = new NumberFormatInfo();
            this.mNumberFormat.NumberDecimalSeparator = ".";
            this.mNumberFormat.NumberGroupSeparator = "";
            this.mNumberFormat.NumberDecimalDigits = 5;
        }

        public void AddGrayTextMark()
        {
            double num1;
            double num2;
            if ((this.mPage.Rotate == 90) || (this.mPage.Rotate == 270))
            {
                num1 = this.mPage.CropBox.Height;
                num2 = this.mPage.CropBox.Width;
            }
            else
            {
                num2 = this.mPage.CropBox.Height;
                num1 = this.mPage.CropBox.Width;
            }
            double num3 = Math.Sqrt(((num1 * num1) + (num2 * num2)));
            double num4 = (num1 / num3);
            double num5 = (num2 / num3);
            double num6 = (num1 / (9f * num4));
            ((num1 - num2) / 2f);
            double num7 = (this.mPage.CropBox.Left + (num1 / 6f));
            double num8 = (this.mPage.CropBox.Bottom + (num2 / 6f));
            double num9 = (num8 + num6);
            double num10 = (num7 + ((3.5f * num6) * num4));
            string text1 = num4.ToString("N", this.mNumberFormat);
            string text2 = num5.ToString("N", this.mNumberFormat);
            object[] objArray1 = new object[7];
            objArray1[0] = text1;
            objArray1[1] = 32;
            objArray1[2] = text2;
            objArray1[3] = " -";
            objArray1[4] = text2;
            objArray1[5] = 32;
            objArray1[6] = text1;
            string text3 = objArray1;
            this.m_sContents = this.m_sContents + "\nq\n/" + this.m_sWTM_EGS + " gs\n";
            object obj1 = this.m_sContents;
            objArray1 = new object[4];
            objArray1[0] = obj1;
            objArray1[1] = "0.6 G 0.8 g\nBT\n/";
            objArray1[2] = this.m_sNoteFont;
            objArray1[3] = 32;
            this.m_sContents = objArray1;
            this.m_sContents = this.m_sContents + num6.ToString("N", this.mNumberFormat) + " Tf\n2 Tr\n";
            obj1 = this.m_sContents;
            objArray1 = new object[6];
            objArray1[0] = obj1;
            objArray1[1] = text3;
            objArray1[2] = 32;
            objArray1[3] = num7.ToString("N", this.mNumberFormat);
            objArray1[4] = 32;
            objArray1[5] = num9.ToString("N", this.mNumberFormat);
            this.m_sContents = objArray1;
            this.m_sContents = this.m_sContents + " Tm\n(Evaluation) Tj\n";
            obj1 = this.m_sContents;
            objArray1 = new object[6];
            objArray1[0] = obj1;
            objArray1[1] = text3;
            objArray1[2] = 32;
            objArray1[3] = num10.ToString("N", this.mNumberFormat);
            objArray1[4] = 32;
            objArray1[5] = num8.ToString("N", this.mNumberFormat);
            this.m_sContents = objArray1;
            this.m_sContents = this.m_sContents + " Tm\n(copy) Tj\n";
            this.m_sContents = this.m_sContents + "ET\nQ\n";
        }

        public void AddLinkAnnotation(double left, double bottom, double right, double top, PDFObject uri_action)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Type"] = Library.CreateName("Annot");
            dict1["Subtype"] = Library.CreateName("Link");
            PDFDict dict2 = Library.CreateDict();
            dict2["W"] = Library.CreateInteger(((long) 0));
            dict1["BS"] = dict2;
            PDFArray array1 = Library.CreateArray(0);
            array1.Add(Library.CreateFixed(0f));
            array1.Add(Library.CreateFixed(0f));
            array1.Add(Library.CreateFixed(0f));
            dict1["Border"] = array1;
            PDFArray array2 = Library.CreateArray(0);
            array2.Add(Library.CreateFixed(left));
            array2.Add(Library.CreateFixed(bottom));
            array2.Add(Library.CreateFixed(right));
            array2.Add(Library.CreateFixed(top));
            dict1["Rect"] = array2;
            if (uri_action != null)
            {
                dict1["A"] = uri_action;
            }
            Document document1 = this.mPage.Dict.Doc;
            PDFIndirect indirect1 = document1.Indirects.New(dict1);
            PDFArray array3 = null;
            PDFObject obj1 = this.mPage.Dict["Annots"];
            if ((obj1 != null) && (obj1.PDFType == PDFObjectType.tPDFArray))
            {
                array3 = ((PDFArray) obj1.Direct);
            }
            else
            {
                array3 = Library.CreateArray(0);
                this.mPage.Dict["Annots"] = array3;
            }
            array3.Add(indirect1);
        }

        public void AddLogo(PDFObject uri_action)
        {
            double num3;
            double num5;
            double num1 = 14f;
            double num2 = (num1 * 2.5f);
            int num9 = this.mPage.Rotate;
            if (num9 <= 90)
            {
                if (num9 == 0)
                {
                    goto Label_0053;
                }
                if (num9 == 90)
                {
                    goto Label_0089;
                }
                goto Label_0122;
            }
            if (num9 == 180)
            {
                goto Label_00BC;
            }
            if (num9 == 270)
            {
                goto Label_00EF;
            }
            goto Label_0122;
        Label_0053:
            num3 = this.mPage.CropBox.Left;
            double num4 = this.mPage.CropBox.Bottom;
            this.AddLinkAnnotation(num3, num4, (num3 + num2), (num4 + num1), uri_action);
            goto Label_012D;
        Label_0089:
            num3 = this.mPage.CropBox.Right;
            num4 = this.mPage.CropBox.Bottom;
            this.AddLinkAnnotation((num3 - num1), num4, num3, (num4 + num2), uri_action);
            goto Label_012D;
        Label_00BC:
            num3 = this.mPage.CropBox.Right;
            num4 = this.mPage.CropBox.Top;
            this.AddLinkAnnotation((num3 - num2), (num4 - num1), num3, num4, uri_action);
            goto Label_012D;
        Label_00EF:
            num3 = this.mPage.CropBox.Left;
            num4 = this.mPage.CropBox.Top;
            this.AddLinkAnnotation(num3, (num4 - num2), (num3 + num1), num4, uri_action);
            goto Label_012D;
        Label_0122:
            throw new FormatException("Rotate parameter should be a multiple of 90");
        Label_012D:
            num5 = (num2 / 250f);
            double num6 = (num1 / 100f);
            double num7 = (this.mPage.CropBox.Left - (num5 * 209f));
            double num8 = (this.mPage.CropBox.Bottom - (num6 * 321f));
            object obj1 = this.m_sContents;
            object[] objArray1 = new object[10];
            objArray1[0] = obj1;
            objArray1[1] = "\nq\n";
            objArray1[2] = num5.ToString("N", this.mNumberFormat);
            objArray1[3] = " 0 0 ";
            objArray1[4] = num6.ToString("N", this.mNumberFormat);
            objArray1[5] = 32;
            objArray1[6] = num7.ToString("N", this.mNumberFormat);
            objArray1[7] = 32;
            objArray1[8] = num8.ToString("N", this.mNumberFormat);
            objArray1[9] = " cm\n";
            this.m_sContents = objArray1;
            this.m_sContents = this.m_sContents + "\n0.39999 0 0 rg\n0.39999 0 0 RG\n\n0 i \n268.91992 417.52783 m\n331.41602 324.50391 l\n249.33594 324.79199 l\n280.51221 344.52002 l\n292.17578 325.43994 l\n329.75977 325.36816 l\n304.41602 362.52002 l\n280.65625 347.32813 l\n268.91992 370.15186 l\n";
            this.m_sContents = this.m_sContents + "246.38379 324.50391 l\n213.04785 324.50391 l\n268.91992 417.52783 l\nh\nf*";
            this.m_sContents = this.m_sContents + "\n303.91211 356.3999 m\n304.2002 356.3999 l\n305.56787 354.31201 l\n307.65625 351.07178 l\n311.75977 344.80811 l\n315 339.76807 l\n316.72803 337.17578 l\n318.88818 333.93604 l\n312.12012 329.90381 l\n309.09619 335.23193 l\n303.91211 334.94385 l\n";
            this.m_sContents = this.m_sContents + "303.91211 339.83984 l\n306.79199 340.05615 l\n303.91211 345.74414 l\n303.91211 345.67188 l\n303.91211 356.3999 l\n290.08789 333.57617 m\n293.11182 338.54395 l\n293.97607 339.98389 l\n294.76807 341.35205 l\n295.91992 343.2959 l\n297.14404 345.24023 l\n";
            this.m_sContents = this.m_sContents + "298.51221 347.61621 l\n299.73584 349.63184 l\n300.6001 351.14404 l\n301.53613 352.65625 l\n302.61621 354.38379 l\n303.83984 356.3999 l\n303.91211 356.3999 l\n303.91211 345.67188 l\n303.26416 344.52002 l\n";
            this.m_sContents = this.m_sContents + "302.68799 343.22412 l\n301.96777 341.71191 l\n300.95996 339.6958 l\n303.91211 339.83984 l\n303.91211 334.94385 l\n298.7998 334.58398 l\n298.2959 333.57617 l\n297.79199 332.42383 l\n297.14404 331.12793 l\n296.56787 329.90381 l\n290.08789 333.57617 l\nh\nf*";
            this.m_sContents = this.m_sContents + "\n330.26416 355.24805 m\n330.19189 349.34375 l\n330.12012 347.04004 l\n330.12012 344.52002 l\n330.12012 342.43213 l\n330.12012 336.88818 l\n331.27197 336.88818 332.64014 336.88818 334.36816 336.95996 c\n";
            this.m_sContents = this.m_sContents + "336.09619 337.03223 337.17578 337.03223 337.75195 337.03223 c\n337.75195 330.6958 l\n335.08789 330.76807 l\n330.62402 330.91211 l\n325.43994 330.98389 l\n322.34375 330.98389 l\n322.34375 333.50391 l\n322.41602 336.31201 l\n";
            this.m_sContents = this.m_sContents + "322.41602 342.64795 l\n322.34375 355.24805 l\n330.26416 355.24805 l\nh\nf*";
            this.m_sContents = this.m_sContents + "\n338.90381 355.104 m\n341.49609 354.95996 l\n344.73584 354.88818 l\n348.19189 354.88818 l\n351.35986 354.88818 l\n352.72803 354.88818 l\n353.95215 354.88818 l\n356.32813 354.88818 l\n357.55176 354.88818 l\n358.63184 354.95996 l\n";
            this.m_sContents = this.m_sContents + "361.58398 355.104 l\n361.58398 349.2002 l\n358.12793 349.27197 l\n354.09619 349.34375 l\n354.09619 346.68018 l\n354.09619 344.23193 l\n354.16797 340.12793 l\n354.16797 336.6001 l\n354.16797 331.05615 l\n346.39209 331.05615 l\n346.39209 340.05615 l\n";
            this.m_sContents = this.m_sContents + "346.39209 343.43994 l\n346.46387 349.34375 l\n338.90381 349.2002 l\n338.90381 355.104 l\nh\nf*";
            this.m_sContents = this.m_sContents + "\n364.60791 351.21582 m\n365.61621 352.22412 367.05615 353.16016 369.07178 354.09619 c\n371.01611 354.95996 373.46387 355.53613 376.27197 355.82422 c\n377.27979 350.13574 l\n376.41602 350.13574 375.76807 350.13574 375.33594 350.06396 c\n";
            this.m_sContents = this.m_sContents + "374.90381 350.06396 374.3999 349.99219 373.96777 349.91992 c\n373.46387 349.84814 373.03223 349.77588 372.81592 349.7041 c\n372.52783 349.63184 372.16797 349.48779 371.80811 349.34375 c\n371.16016 349.05615 370.87207 348.55176 370.87207 347.97607 c\n";
            this.m_sContents = this.m_sContents + "370.87207 347.68799 371.01611 347.3999 371.37598 347.18408 c\n371.73584 346.896 372.31201 346.53613 373.24805 346.104 c\n373.96777 345.74414 l\n374.54395 345.38379 l\n375.04785 345.09619 l\n377.56787 343.7998 378.86426 342.07178 378.86426 340.12793 c\n";
            this.m_sContents = this.m_sContents + "378.79199 339.55176 l\n378.79199 339.04785 l\n378.57617 337.96777 378.14404 336.95996 377.42383 336.02393 c\n";
            this.m_sContents = this.m_sContents + "\n376.63184 335.08789 375.6958 334.22412 374.3999 333.43213 c\n373.104 332.64014 371.66406 331.99219 370.00781 331.48779 c\n369.21582 331.27197 368.35205 331.05615 367.48779 330.83984 c\n366.55176 330.6958 365.61621 330.55176 364.60791 330.4082 c\n";
            this.m_sContents = this.m_sContents + "363.67188 336.24023 l\n365.47217 336.24023 367.12793 336.45605 368.49609 336.81592 c\n369.86426 337.24805 370.58398 337.896 370.58398 338.61621 c\n370.58398 338.97607 370.43994 339.26416 370.08008 339.55176 c\n369.72021 339.83984 369.35986 340.05615 369.07178 340.2002 c\n";
            this.m_sContents = this.m_sContents + "369 340.34375 368.64014 340.48779 368.13574 340.77588 c\n366.26416 341.92822 l\n363.81592 343.43994 362.66406 345.09619 362.66406 346.96777 c\n362.66406 347.75977 362.87988 348.55176 363.24023 349.34375 c\n363.6001 350.06396 364.03223 350.64014 364.60791 351.21582 c\nh\nf*";
            this.m_sContents = this.m_sContents + "\n395.42383 350.42383 m\n395.42383 350.42383 395.35205 350.42383 v\n395.35205 355.68018 l\n395.42383 355.68018 395.42383 355.68018 y\n397.87207 355.68018 399.81592 355.46387 401.18408 355.03223 c\n402.62402 354.6001 403.84814 354.02393 404.85596 353.3042 c\n";
            this.m_sContents = this.m_sContents + "405.43213 352.94385 405.86426 352.58398 406.2959 352.15186 c\n406.65625 351.72021 407.01611 351.28809 407.37598 350.71191 c\n408.02393 349.77588 408.52783 348.62402 408.88818 347.32813 c\n409.24805 345.95996 409.39209 344.5918 409.39209 343.22412 c\n";
            this.m_sContents = this.m_sContents + "409.39209 342.43213 409.31982 341.64014 409.17578 340.99219 c\n409.03223 340.27197 408.74414 339.47998 408.38379 338.61621 c\n407.73584 337.104 406.87207 335.73584 405.64795 334.58398 c\n404.49609 333.35986 403.05615 332.42383 401.32813 331.7041 c\n";
            this.m_sContents = this.m_sContents + "400.39209 331.34375 399.45605 331.05615 398.52002 330.83984 c\n";
            this.m_sContents = this.m_sContents + "\n397.58398 330.62402 396.57617 330.47998 395.42383 330.47998 c\n395.42383 330.47998 395.35205 330.47998 v\n395.35205 335.73584 l\n395.42383 335.73584 l\n396.86426 335.80811 397.94385 336.31201 398.73584 337.03223 c\n";
            this.m_sContents = this.m_sContents + "399.6001 337.82422 400.17578 338.68799 400.53613 339.76807 c\n400.68018 340.34375 400.82422 340.91992 400.896 341.49609 c\n400.96777 342 401.04004 342.57617 401.04004 343.22412 c\n401.04004 345.52783 400.53613 347.32813 399.6001 348.62402 c\n";
            this.m_sContents = this.m_sContents + "398.66406 349.84814 397.36816 350.42383 395.78418 350.42383 c\n395.42383 350.42383 l\n395.35205 350.42383 m\n394.84814 350.42383 394.41602 350.35205 393.98389 350.20801 c\n393.55176 350.06396 393.04785 349.77588 392.61621 349.41602 c\n";
            this.m_sContents = this.m_sContents + "391.75195 348.76807 391.03223 347.97607 390.6001 346.896 c\n390.31201 346.46387 390.09619 345.88818 389.95215 345.24023 c\n389.80811 344.66406 389.73584 344.01611 389.73584 343.22412 c\n";
            this.m_sContents = this.m_sContents + "\n389.73584 340.84814 390.24023 338.97607 391.24805 337.68018 c\n392.25586 336.38379 393.47998 335.73584 394.99219 335.73584 c\n395.35205 335.73584 l\n395.35205 330.47998 l\n393.26416 330.47998 391.39209 330.83984 389.66406 331.41602 c\n";
            this.m_sContents = this.m_sContents + "387.93604 331.99219 386.42383 332.85596 385.2002 333.93604 c\n383.90381 335.01611 382.96777 336.24023 382.31982 337.60791 c\n382.03223 338.25586 381.81592 338.97607 381.6001 339.76807 c\n381.45605 340.48779 381.38379 341.20801 381.38379 342 c\n";
            this.m_sContents = this.m_sContents + "381.45605 343.22412 l\n381.74414 345.88818 382.53613 348.12012 383.97607 349.99219 c\n385.34375 351.93604 387.07178 353.3042 389.16016 354.24023 c\n391.24805 355.24805 393.33594 355.68018 395.35205 355.68018 c\n395.35205 350.42383 l\nh\nf*";
            this.m_sContents = this.m_sContents + "\n414.28809 355.24805 m\n420.91211 355.39209 l\n429.12012 355.68018 l\n429.26416 350.13574 l\n421.7041 349.91992 l\n421.7041 344.5918 l\n425.16016 344.87988 l\n428.54395 345.02393 l\n428.68799 339.6958 l\n427.82422 339.6958 426.6001 339.6958 425.01611 339.6958 c\n";
            this.m_sContents = this.m_sContents + "423.43213 339.6958 422.35205 339.6958 421.7041 339.6958 c\n421.77588 331.05615 l\n414.28809 331.05615 l\n414.28809 335.01611 l\n414.35986 337.75195 l\n414.35986 340.77588 l\n414.35986 344.37598 l\n414.28809 355.24805 l\nh\nf*";
            this.m_sContents = this.m_sContents + "\n430.99219 355.104 m\n433.51221 354.95996 l\n436.75195 354.88818 l\n440.27979 354.88818 l\n443.37598 354.88818 l\n444.74414 354.88818 l\n445.96777 354.88818 l\n448.34375 354.88818 l\n";
            this.m_sContents = this.m_sContents + "449.56787 354.88818 l\n450.72021 354.95996 l\n453.6001 355.104 l\n453.6001 349.2002 l\n450.14404 349.27197 l\n446.11182 349.34375 l\n446.11182 346.68018 l\n446.18408 344.23193 l\n446.18408 340.12793 l\n";
            this.m_sContents = this.m_sContents + "446.25586 336.6001 l\n446.25586 331.05615 l\n438.4082 331.05615 l\n438.4082 340.05615 l\n438.47998 343.43994 l\n438.47998 349.34375 l\n430.99219 349.2002 l\n430.99219 355.104 l\nh\nf*\n";
            this.m_sContents = this.m_sContents + "Q\n";
        }

        public void AddTextLogo(PDFObject uri_action)
        {
            double num1;
            double num6;
            if ((this.mPage.Rotate == 90) || (this.mPage.Rotate == 270))
            {
                num1 = this.mPage.CropBox.Height;
                this.mPage.CropBox.Width;
            }
            else
            {
                this.mPage.CropBox.Height;
                num1 = this.mPage.CropBox.Width;
            }
            double num8 = 9f;
            double num3 = (num8 + 4f);
            double num2 = 122f;
            double num4 = ((this.mPage.CropBox.Left + num1) - num2);
            double num5 = (this.mPage.CropBox.Bottom + 3f);
            double num9 = 69f;
            double num10 = 25f;
            double num11 = ((num4 + num2) - num9);
            double num12 = (num11 + num10);
            double num13 = (num5 - 1.5f);
            int num14 = this.mPage.Rotate;
            if (num14 <= 90)
            {
                if (num14 == 0)
                {
                    goto Label_012D;
                }
                if (num14 == 90)
                {
                    goto Label_016D;
                }
                goto Label_0227;
            }
            if (num14 == 180)
            {
                goto Label_01AD;
            }
            if (num14 == 270)
            {
                goto Label_01EA;
            }
            goto Label_0227;
        Label_012D:
            num6 = (this.mPage.CropBox.Right - num9);
            double num7 = this.mPage.CropBox.Bottom;
            this.AddLinkAnnotation(num6, num7, (num6 + num10), (num7 + num3), uri_action);
            goto Label_0232;
        Label_016D:
            num6 = this.mPage.CropBox.Right;
            num7 = (this.mPage.CropBox.Top - num9);
            this.AddLinkAnnotation((num6 - num3), num7, num6, (num7 + num10), uri_action);
            goto Label_0232;
        Label_01AD:
            num6 = (this.mPage.CropBox.Left + num9);
            num7 = this.mPage.CropBox.Top;
            this.AddLinkAnnotation((num6 - num10), (num7 - num3), num6, num7, uri_action);
            goto Label_0232;
        Label_01EA:
            num6 = this.mPage.CropBox.Left;
            num7 = (this.mPage.CropBox.Bottom + num9);
            this.AddLinkAnnotation(num6, (num7 - num10), (num6 + num3), num7, uri_action);
            goto Label_0232;
        Label_0227:
            throw new FormatException("Rotate parameter should be a multiple of 90");
        Label_0232:
            this.m_sContents = this.m_sContents + "\nq\n0 g\n0 G\nBT\n/";
            object obj1 = this.m_sContents;
            object[] objArray1 = new object[5];
            objArray1[0] = obj1;
            objArray1[1] = this.m_sLogoFont;
            objArray1[2] = 32;
            objArray1[3] = num8.ToString("N", this.mNumberFormat);
            objArray1[4] = " Tf\n";
            this.m_sContents = objArray1;
            obj1 = this.m_sContents;
            objArray1 = new object[5];
            objArray1[0] = obj1;
            objArray1[1] = "1 0 0 1 ";
            objArray1[2] = num4.ToString("N", this.mNumberFormat);
            objArray1[3] = 32;
            objArray1[4] = num5.ToString("N", this.mNumberFormat);
            this.m_sContents = objArray1;
            this.m_sContents = this.m_sContents + " Tm\n(Produced by ) Tj\n";
            this.m_sContents = this.m_sContents + "0.39999 0 0 rg 0.39999 0 0 RG\n";
            this.m_sContents = this.m_sContents + "(Altsoft) Tj\n";
            this.m_sContents = this.m_sContents + "0 g 0 G\n";
            this.m_sContents = this.m_sContents + "( Xml2PDF) Tj\nET\n";
            this.m_sContents = this.m_sContents + "0.39999 0 0 rg 0.39999 0 0 RG\n";
            obj1 = this.m_sContents;
            objArray1 = new object[5];
            objArray1[0] = obj1;
            objArray1[1] = num11.ToString("N", this.mNumberFormat);
            objArray1[2] = 32;
            objArray1[3] = num13.ToString("N", this.mNumberFormat);
            objArray1[4] = " m\n";
            this.m_sContents = objArray1;
            obj1 = this.m_sContents;
            objArray1 = new object[5];
            objArray1[0] = obj1;
            objArray1[1] = num12.ToString("N", this.mNumberFormat);
            objArray1[2] = 32;
            objArray1[3] = num13.ToString("N", this.mNumberFormat);
            objArray1[4] = " l S\nQ\n";
            this.m_sContents = objArray1;
        }

        public void AddWatermarks(Page page)
        {
            PDFStream stream1;
            Stream stream2;
            PDFStream stream3;
            Stream stream4;
            PDFStream stream5;
            Stream stream6;
            PDFStream stream7;
            Stream stream8;
            object obj1;
            DateTime time1;
            this.m_sContents = "";
            if (this.m_bAdd_qQ_ToOrigSc)
            {
                this.m_sContents = this.m_sContents + "\nQ";
            }
            this.mPage = page;
            page.Resources.Add(this.m_sLogoFont, this.mWTM_LogoFont);
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("URI");
            dict1["URI"] = Library.CreateString("http://www.alt-soft.com/");
            PDFIndirect indirect1 = this.mPage.Dict.Doc.Indirects.New(dict1);
            int num1 = this.mPage.Rotate;
            double num2 = (this.mPage.CropBox.Left + (this.mPage.CropBox.Width / 2f));
            double num3 = (this.mPage.CropBox.Bottom + (this.mPage.CropBox.Height / 2f));
            double num4 = ((this.mPage.CropBox.Width - this.mPage.CropBox.Height) / 2f);
            int num5 = num1;
            if (num5 <= 90)
            {
                if (num5 == 0)
                {
                    goto Label_02F9;
                }
                if (num5 == 90)
                {
                    goto Label_015E;
                }
                goto Label_02EE;
            }
            if (num5 == 180)
            {
                goto Label_01E2;
            }
            if (num5 == 270)
            {
                goto Label_026E;
            }
            goto Label_02EE;
        Label_015E:
            obj1 = this.m_sContents;
            object[] objArray1 = new object[6];
            objArray1[0] = obj1;
            objArray1[1] = "0 1 -1 0 ";
            double num6 = ((num2 + num3) + num4);
            objArray1[2] = num6.ToString("N", this.mNumberFormat);
            objArray1[3] = 32;
            num6 = ((-num2 + num3) + num4);
            objArray1[4] = num6.ToString("N", this.mNumberFormat);
            objArray1[5] = " cm\n";
            this.m_sContents = objArray1;
            goto Label_02F9;
        Label_01E2:
            obj1 = this.m_sContents;
            objArray1 = new object[6];
            objArray1[0] = obj1;
            objArray1[1] = "-1 0 0 -1 ";
            num6 = (2f * num2);
            objArray1[2] = num6.ToString("N", this.mNumberFormat);
            objArray1[3] = 32;
            num6 = (2f * num3);
            objArray1[4] = num6.ToString("N", this.mNumberFormat);
            objArray1[5] = " cm\n";
            this.m_sContents = objArray1;
            goto Label_02F9;
        Label_026E:
            obj1 = this.m_sContents;
            objArray1 = new object[6];
            objArray1[0] = obj1;
            objArray1[1] = "0 -1 1 0 ";
            num6 = ((num2 - num3) - num4);
            objArray1[2] = num6.ToString("N", this.mNumberFormat);
            objArray1[3] = 32;
            num6 = ((num2 + num3) - num4);
            objArray1[4] = num6.ToString("N", this.mNumberFormat);
            objArray1[5] = " cm\n";
            this.m_sContents = objArray1;
            goto Label_02F9;
        Label_02EE:
            throw new FormatException("Rotate parameter should be a multiple of 90");
        Label_02F9:
            time1 = DateTime.Now;
            new Random(time1.Millisecond);
            this.AddLogo(indirect1);
            this.AddTextLogo(indirect1);
            PDFArray array1 = Library.CreateArray(1);
            array1[0] = Library.CreateName("FlateDecode");
            string text1 = "q\n";
            if (this.m_bAdd_qQ_ToOrigSc)
            {
                if (this.m_bWMAsNewStream)
                {
                    page.Contents.InsertStream(text1, 0);
                    stream1 = page.Contents.GetPDFStream(0);
                    stream2 = stream1.Decode();
                    stream1.Dict["Filter"] = page.Dict.Doc.CloneObject(array1);
                    stream1.Dict.Remove("DecodeParms");
                    stream1.Encode(stream2);
                }
                else
                {
                    page.Contents.AppendStream(text1, "", 0);
                    stream3 = page.Contents.GetPDFStream(0);
                    stream4 = stream3.Decode();
                    stream3.Dict["Filter"] = page.Dict.Doc.CloneObject(array1);
                    stream3.Dict.Remove("DecodeParms");
                    stream3.Encode(stream4);
                }
            }
            if (this.m_bWMAsNewStream)
            {
                page.Contents.AddStream(this.m_sContents);
                stream5 = page.Contents.GetPDFStream((page.Contents.Count - 1));
                stream6 = stream5.Decode();
                stream5.Dict["Filter"] = page.Dict.Doc.CloneObject(array1);
                stream5.Dict.Remove("DecodeParms");
                stream5.Encode(stream6);
            }
            else
            {
                page.Contents.AppendStream("", this.m_sContents, (page.Contents.Count - 1));
                stream7 = page.Contents.GetPDFStream((page.Contents.Count - 1));
                stream8 = stream7.Decode();
                stream7.Dict["Filter"] = page.Dict.Doc.CloneObject(array1);
                stream7.Dict.Remove("DecodeParms");
                stream7.Encode(stream8);
            }
            this.mPage = null;
        }

        private PDFIndirect BuildEGSDict(Document doc, double opacity)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Type"] = Library.CreateName("ExtGState");
            dict1["ca"] = Library.CreateFixed(opacity);
            dict1["CA"] = Library.CreateFixed(opacity);
            return doc.Indirects.New(dict1);
        }

        private PDFIndirect BuildFontDict(Document doc, string fontname)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Type"] = Library.CreateName("Font");
            dict1["Subtype"] = Library.CreateName("Type1");
            dict1["BaseFont"] = Library.CreateName(fontname);
            dict1["Encoding"] = Library.CreateName("WinAnsiEncoding");
            return doc.Indirects.New(dict1);
        }


        // Fields
        private bool m_bAdd_qQ_ToOrigSc;
        private bool m_bWMAsNewStream;
        private string m_sContents;
        private readonly string m_sLogoFont;
        private readonly string m_sNoteFont;
        private readonly string m_sWTM_EGS;
        private NumberFormatInfo mNumberFormat;
        private Page mPage;
        private Resource mWTM_LogoFont;
    }
}


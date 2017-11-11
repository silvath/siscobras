namespace Altsoft.PDFP
{
    using Altsoft.Common;
    using Altsoft.PDFO;
    using Altsoft.Xml;
    using Altsoft.XmlFO;
    using System;
    using System.Collections;
    using System.Globalization;
    using System.IO;

    public class PDFPainter
    {
        // Methods
        static PDFPainter()
        {
            char[] chArray1 = new char[1];
            chArray1[0] = '0';
            PDFPainter.doubleTrimEnd1 = chArray1;
            chArray1 = new char[1];
            chArray1[0] = '.';
            PDFPainter.doubleTrimEnd2 = chArray1;
        }

        public PDFPainter(Stream output)
        {
            this.GSStack = new Stack();
            this.roundCoeff = 0.552f;
            this.mConfig = new PDFPainterConfig();
            this.mOutput = output;
            this.PDFNumberFormatInfo = new NumberFormatInfo();
            this.PDFNumberFormatInfo.NumberDecimalSeparator = ".";
            this.CurrentGS.SetDefaults();
        }

        public static void AddDefaultRGB(Document doc)
        {
            int num1;
            if (doc == null)
            {
                return;
            }
            PDFDict dict1 = Library.CreateDict();
            double[] numArray1 = new double[3] { 0.95045f, 1f, 1.08905f };
            double[] numArray2 = new double[3] { 2.2f, 2.2f, 2.2f };
            double[] numArray3 = new double[9] { 0.4124f, 0.2126f, 0.0193f, 0.3576f, 0.7152f, 0.1192f, 0.1805f, 0.0722f, 0.9505f };
            dict1["WhitePoint"] = PDF.O(numArray1);
            dict1["Gamma"] = PDF.O(numArray2);
            dict1["Matrix"] = PDF.O(numArray3);
            PDFArray array1 = Library.CreateArray(2);
            array1[0] = Library.CreateName("CalRGB");
            array1[1] = dict1;
            PDFIndirect indirect1 = doc.Indirects.New(array1);
            Resource resource1 = doc.Resources[indirect1, typeof(ColorSpace)];
            for (num1 = 0; (num1 < doc.Pages.Count); num1 += 1)
            {
                doc.Pages[num1].Resources.Add("DefaultRGB", resource1);
            }
        }

        public PDFPainter b()
        {
            if (!this.CurrentGS.PathOpened)
            {
                return this;
            }
            this.Write("b\n");
            return this;
        }

        public PDFPainter B()
        {
            if (!this.CurrentGS.PathOpened)
            {
                return this;
            }
            this.Write("B\n");
            return this;
        }

        public PDFPainter B_()
        {
            if (!this.CurrentGS.PathOpened)
            {
                return this;
            }
            this.Write("B*\n");
            return this;
        }

        public PDFPainter BT()
        {
            if (!this.CurrentGS.TextOpened)
            {
                if (this.CurrentGS.PathOpened)
                {
                    this.n();
                }
                this.CurrentGS.TextOpened = true;
                this.Write("BT ");
            }
            return this;
        }

        public PDFPainter c(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            if (this.CurrentGS.TextOpened)
            {
                this.ET();
            }
            this.CurrentGS.PathOpened = true;
            object[] objArray1 = new object[7];
            objArray1[0] = x1;
            objArray1[1] = y1;
            objArray1[2] = x2;
            objArray1[3] = y2;
            objArray1[4] = x3;
            objArray1[5] = y3;
            objArray1[6] = "c\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter cm(CTM arg)
        {
            object[] objArray1;
            if (!this.Is_E_CTM(arg))
            {
                objArray1 = new object[7];
                objArray1[0] = arg[0, 0];
                objArray1[1] = arg[1, 0];
                objArray1[2] = arg[0, 1];
                objArray1[3] = arg[1, 1];
                objArray1[4] = arg[0, 2];
                objArray1[5] = arg[1, 2];
                objArray1[6] = "cm \n";
                this.Write(objArray1);
                this.CurrentGS.CTM = new CTM(Matrix.op_Multiply(arg, this.CurrentGS.CTM));
            }
            return this;
        }

        public PDFPainter Comment(string comment)
        {
            this.Write("%");
            this.Write(comment);
            this.NewLine();
            return this;
        }

        public PDFPainter cs_scn(string name, double cs1)
        {
            this.CurrentGS.RG_r = -1f;
            this.CurrentGS.RG_g = -1f;
            this.CurrentGS.RG_b = -1f;
            this.CurrentGS.rg_r = -1f;
            this.CurrentGS.rg_g = -1f;
            this.CurrentGS.rg_b = -1f;
            object[] objArray1 = new object[5];
            objArray1[0] = "/";
            objArray1[1] = name;
            objArray1[2] = " cs ";
            objArray1[3] = cs1;
            objArray1[4] = "scn\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter cs_scn(string name, double cs1, double cs2, double cs3)
        {
            this.CurrentGS.RG_r = -1f;
            this.CurrentGS.RG_g = -1f;
            this.CurrentGS.RG_b = -1f;
            this.CurrentGS.rg_r = -1f;
            this.CurrentGS.rg_g = -1f;
            this.CurrentGS.rg_b = -1f;
            object[] objArray1 = new object[7];
            objArray1[0] = "/";
            objArray1[1] = name;
            objArray1[2] = " cs ";
            objArray1[3] = cs1;
            objArray1[4] = cs2;
            objArray1[5] = cs3;
            objArray1[6] = "scn\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter cs_scn(string name, double cs1, double cs2, double cs3, double cs4)
        {
            this.CurrentGS.RG_r = -1f;
            this.CurrentGS.RG_g = -1f;
            this.CurrentGS.RG_b = -1f;
            this.CurrentGS.rg_r = -1f;
            this.CurrentGS.rg_g = -1f;
            this.CurrentGS.rg_b = -1f;
            object[] objArray1 = new object[8];
            objArray1[0] = "/";
            objArray1[1] = name;
            objArray1[2] = " cs ";
            objArray1[3] = cs1;
            objArray1[4] = cs2;
            objArray1[5] = cs3;
            objArray1[6] = cs4;
            objArray1[7] = "scn\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter CS_SCN(string name, double CS1)
        {
            this.CurrentGS.RG_r = -1f;
            this.CurrentGS.RG_g = -1f;
            this.CurrentGS.RG_b = -1f;
            this.CurrentGS.rg_r = -1f;
            this.CurrentGS.rg_g = -1f;
            this.CurrentGS.rg_b = -1f;
            object[] objArray1 = new object[5];
            objArray1[0] = "/";
            objArray1[1] = name;
            objArray1[2] = " CS ";
            objArray1[3] = CS1;
            objArray1[4] = "SCN\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter CS_SCN(string name, double CS1, double CS2, double CS3)
        {
            this.CurrentGS.RG_r = -1f;
            this.CurrentGS.RG_g = -1f;
            this.CurrentGS.RG_b = -1f;
            this.CurrentGS.rg_r = -1f;
            this.CurrentGS.rg_g = -1f;
            this.CurrentGS.rg_b = -1f;
            object[] objArray1 = new object[7];
            objArray1[0] = "/";
            objArray1[1] = name;
            objArray1[2] = " CS ";
            objArray1[3] = CS1;
            objArray1[4] = CS2;
            objArray1[5] = CS3;
            objArray1[6] = "SCN\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter CS_SCN(string name, double CS1, double CS2, double CS3, double CS4)
        {
            this.CurrentGS.RG_r = -1f;
            this.CurrentGS.RG_g = -1f;
            this.CurrentGS.RG_b = -1f;
            this.CurrentGS.rg_r = -1f;
            this.CurrentGS.rg_g = -1f;
            this.CurrentGS.rg_b = -1f;
            object[] objArray1 = new object[8];
            objArray1[0] = "/";
            objArray1[1] = name;
            objArray1[2] = " CS ";
            objArray1[3] = CS1;
            objArray1[4] = CS2;
            objArray1[5] = CS3;
            objArray1[6] = CS4;
            objArray1[7] = "SCN\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter d(params double[] args)
        {
            int num1;
            int num2;
            object[] objArray1;
            bool flag1 = true;
            if (args.Length != this.CurrentGS.d.Length)
            {
                flag1 = false;
            }
            else
            {
                for (num1 = 0; (num1 < args.Length); num1 += 1)
                {
                    if (Math.Abs((args[num1] - this.CurrentGS.d[num1])) > 0.001f)
                    {
                        flag1 = false;
                    }
                }
            }
            if (!flag1)
            {
                this.Write("[");
                for (num2 = 0; (num2 < (args.Length - 1)); num2 += 1)
                {
                    this.Write(args[num2]);
                }
                objArray1 = new object[3];
                objArray1[0] = "]";
                objArray1[1] = args[(args.Length - 1)];
                objArray1[2] = "d\n";
                this.Write(objArray1);
                this.CurrentGS.d = (args.Clone() as double[]);
            }
            return this;
        }

        public PDFPainter Do(string image)
        {
            if (this.CurrentGS.TextOpened)
            {
                this.ET();
            }
            object[] objArray1 = new object[2];
            objArray1[0] = "/" + image + " ";
            objArray1[1] = "Do\n";
            this.Write(objArray1);
            return this;
        }

        public void Error(string description, params string[] args)
        {
            int num1;
            for (num1 = 0; (num1 < args.Length); num1 += 1)
            {
                description = description.Replace("%" + (num1 + 1), args[num1]);
            }
            throw new Exception(description);
        }

        public PDFPainter ET()
        {
            if (this.CurrentGS.TextOpened)
            {
                this.CurrentGS.TextOpened = false;
                this.CurrentGS.tx = 0f;
                this.CurrentGS.ty = 0f;
                this.Write("ET\n");
            }
            return this;
        }

        public PDFPainter f()
        {
            if (!this.CurrentGS.PathOpened)
            {
                this.Error("Invalid f operator", new string[0]);
            }
            this.Write("f\n");
            return this;
        }

        public PDFPainter f_()
        {
            if (!this.CurrentGS.PathOpened)
            {
                this.Error("Invalid f operator", new string[0]);
            }
            this.Write("f*\n");
            return this;
        }

        public void Flush()
        {
            if (this.CurrentGS.TextOpened)
            {
                this.ET();
            }
            if (this.CurrentGS.PathOpened)
            {
                this.n();
            }
            while ((this.GSStack.Count > 0))
            {
                this.Q();
            }
        }

        public PDFPainter gs(string name)
        {
            this.Write("/" + name + " gs\n");
            return this;
        }

        public PDFPainter h()
        {
            if (!this.CurrentGS.PathOpened)
            {
                this.Error("Invalid h operator", new string[0]);
            }
            this.Write("h ");
            return this;
        }

        public bool Is_E_CTM(CTM arg)
        {
            if ((((arg[0, 0] == 1f) && (arg[1, 0] == 0f)) && ((arg[0, 1] == 0f) && (arg[1, 1] == 1f))) && (arg[0, 2] == 0f))
            {
                return (arg[1, 2] == 0f);
            }
            return false;
        }

        public PDFPainter j(double j)
        {
            object[] objArray1 = new object[2];
            objArray1[0] = j;
            objArray1[1] = "j ";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter J(double J)
        {
            object[] objArray1 = new object[2];
            objArray1[0] = J;
            objArray1[1] = "J ";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter l(Point pt)
        {
            return this.l(pt.x, pt.y);
        }

        public PDFPainter l(double x, double y)
        {
            if (this.CurrentGS.TextOpened)
            {
                this.ET();
            }
            this.CurrentGS.PathOpened = true;
            object[] objArray1 = new object[3];
            objArray1[0] = x;
            objArray1[1] = y;
            objArray1[2] = "l\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter m(Point pt)
        {
            return this.m(pt.x, pt.y);
        }

        public PDFPainter m(double x, double y)
        {
            if (this.CurrentGS.TextOpened)
            {
                this.ET();
            }
            this.CurrentGS.PathOpened = true;
            object[] objArray1 = new object[3];
            objArray1[0] = x;
            objArray1[1] = y;
            objArray1[2] = "m\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter M(double M)
        {
            object[] objArray1 = new object[2];
            objArray1[0] = M;
            objArray1[1] = "M ";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter n()
        {
            if (!this.CurrentGS.PathOpened)
            {
                this.Error("Invalid n operator", new string[0]);
            }
            this.CurrentGS.PathOpened = false;
            this.Write("n\n");
            return this;
        }

        public PDFPainter NewLine()
        {
            this.Write("\n");
            return this;
        }

        public PDFPainter q()
        {
            if (this.CurrentGS.TextOpened)
            {
                this.ET();
            }
            this.GSStack.Push(this.CurrentGS);
            this.Write("q\n");
            return this;
        }

        public PDFPainter Q()
        {
            if (this.CurrentGS.TextOpened)
            {
                this.ET();
            }
            if (this.GSStack.Count > 0)
            {
                this.Write("Q\n");
                this.CurrentGS = ((GS) this.GSStack.Pop());
            }
            else
            {
                this.Error("Invalid Q operator", new string[0]);
            }
            return this;
        }

        public PDFPainter re(Rect rect)
        {
            return this.re(rect.Left, rect.Bottom, rect.Width, rect.Height);
        }

        public PDFPainter re(double x, double y, double w, double h)
        {
            if (this.CurrentGS.TextOpened)
            {
                this.ET();
            }
            this.CurrentGS.PathOpened = true;
            object[] objArray1 = new object[5];
            objArray1[0] = x;
            objArray1[1] = y;
            objArray1[2] = w;
            objArray1[3] = h;
            objArray1[4] = "re\n";
            this.Write(objArray1);
            return this;
        }

        public void ReplaceWithNumberDecimalSeparator(ref string s)
        {
            NumberFormatInfo info1 = NumberFormatInfo.CurrentInfo;
            s = s.Replace(".", info1.NumberDecimalSeparator);
            s = s.Replace(",", info1.NumberDecimalSeparator);
        }

        public string ReverseN(string strValue, int n)
        {
            int num1;
            string text2;
            int num2;
            string text1 = null;
            for (num1 = 0; (num1 < (strValue.Length / n)); num1 += 1)
            {
                text2 = strValue.Substring(((strValue.Length - n) - (num1 * n)), n);
                text1 = text1 + text2;
            }
            for (num2 = 0; (num2 < text1.Length); num2 += 1)
            {
                if (text1[num2] == '\\')
                {
                    text1 = text1.Insert((num2 - 1), @"\");
                    text1 = text1.Remove((num2 + 1), 1);
                }
            }
            return text1;
        }

        public string ReverseString(string s)
        {
            int num2;
            int num4;
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            string text1 = null;
            bool flag1 = false;
            int num1 = -1;
            goto Label_00B5;
        Label_0018:
            num2 = s.IndexOf(")", num1);
            if (s[(num2 - 1)] == '\\')
            {
                num2 = s.IndexOf(")", (num2 + 1));
            }
            string text2 = s.Substring((num1 + 1), ((num2 - num1) - 1));
            text2 = this.ReverseN(text2, 1);
            list1.Add(text2);
            if (s.IndexOf("(", num2) != -1)
            {
                list2.Add(s.Substring((num2 + 1), ((s.IndexOf("(", (num2 + 1)) - num2) - 1)));
            }
            s = s.Remove((num1 + 1), ((num2 - num1) - 1));
        Label_00B5:
            num1 = s.IndexOf("(", (num1 + 1));
            if (num1 != -1)
            {
                goto Label_0018;
            }
            num1 = -1;
            goto Label_0141;
        Label_00D2:
            flag1 = true;
            int num3 = s.IndexOf(">", num1);
            string text3 = s.Substring((num1 + 1), ((num3 - num1) - 1));
            text3 = this.ReverseN(text3, 4);
            list1.Add(text3);
            if (s.IndexOf("<", (num3 + 1)) != -1)
            {
                list2.Add(s.Substring((num3 + 1), ((s.IndexOf("<", (num3 + 1)) - num3) - 1)));
            }
        Label_0141:
            num1 = s.IndexOf("<", (num1 + 1));
            if (num1 != -1)
            {
                goto Label_00D2;
            }
            for (num4 = (list1.Count - 1); (num4 > 0); num4 -= 1)
            {
                if (flag1)
                {
                    text1 = text1 + "<" + (list1[num4] as string) + ">";
                }
                else
                {
                    text1 = text1 + "(" + (list1[num4] as string) + ")";
                }
                text1 = text1 + list2[(num4 - 1)];
            }
            if (flag1)
            {
                return text1 + "<" + (list1[0] as string) + ">";
            }
            return text1 + "(" + (list1[0] as string) + ")";
        }

        public PDFPainter rg(XmlColorAttribute color)
        {
            if (color == null)
            {
                return this;
            }
            return this.rg(color.Red, color.Green, color.Blue);
        }

        public PDFPainter rg(double r, double g, double b)
        {
            object[] objArray1;
            if (((this.CurrentGS.rg_r != r) || (this.CurrentGS.rg_g != g)) || (this.CurrentGS.rg_b != b))
            {
                this.CurrentGS.rg_r = r;
                this.CurrentGS.rg_g = g;
                this.CurrentGS.rg_b = b;
                objArray1 = new object[4];
                objArray1[0] = r;
                objArray1[1] = g;
                objArray1[2] = b;
                objArray1[3] = "rg ";
                this.Write(objArray1);
            }
            return this;
        }

        public PDFPainter RG(XmlColorAttribute color)
        {
            if (color == null)
            {
                return this;
            }
            return this.RG(color.Red, color.Green, color.Blue);
        }

        public PDFPainter RG(double r, double g, double b)
        {
            object[] objArray1;
            if (((this.CurrentGS.RG_r != r) || (this.CurrentGS.RG_g != g)) || (this.CurrentGS.RG_b != b))
            {
                this.CurrentGS.RG_r = r;
                this.CurrentGS.RG_g = g;
                this.CurrentGS.RG_b = b;
                objArray1 = new object[4];
                objArray1[0] = r;
                objArray1[1] = g;
                objArray1[2] = b;
                objArray1[3] = "RG ";
                this.Write(objArray1);
            }
            return this;
        }

        public PDFPainter Round(double a, double b, double w)
        {
            return this.m((a + w), b).c((a + w), (b + (w * this.roundCoeff)), (a + (w * this.roundCoeff)), (b + w), a, (b + w)).NewLine().c((a - (w * this.roundCoeff)), (b + w), (a - w), (b + (w * this.roundCoeff)), (a - w), b).NewLine().c((a - w), (b - (w * this.roundCoeff)), (a - (w * this.roundCoeff)), (b - w), a, (b - w)).NewLine().c((a + (w * this.roundCoeff)), (b - w), (a + w), (b - (w * this.roundCoeff)), (a + w), b).NewLine();
        }

        public PDFPainter s()
        {
            if (!this.CurrentGS.PathOpened)
            {
                this.Error("Invalid s operator", new string[0]);
            }
            this.Write("s\n");
            return this;
        }

        public PDFPainter S()
        {
            if (!this.CurrentGS.PathOpened)
            {
                this.Error("Invalid S operator", new string[0]);
            }
            this.Write("S\n");
            return this;
        }

        public PDFPainter Tc(double c)
        {
            object[] objArray1 = new object[2];
            objArray1[0] = c;
            objArray1[1] = "Tc\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter Td(double x, double y)
        {
            object[] objArray1;
            if ((0f != x) || (0f != y))
            {
                this.BT();
                objArray1 = new object[3];
                objArray1[0] = x;
                objArray1[1] = y;
                objArray1[2] = "Td\n";
                this.Write(objArray1);
                this.CurrentGS.tx = (x + this.CurrentGS.tx);
                this.CurrentGS.ty = (y + this.CurrentGS.ty);
            }
            return this;
        }

        public PDFPainter Td_abs(double x, double y)
        {
            return this.Td((x - this.CurrentGS.tx), (y - this.CurrentGS.ty));
        }

        public PDFPainter Tf(string fontID, double fontSize)
        {
            object[] objArray1;
            if ((this.CurrentGS.FontID != fontID) || (Math.Abs((fontSize - this.CurrentGS.FontSize)) > 0.001f))
            {
                this.BT();
                objArray1 = new object[5];
                objArray1[0] = "/";
                objArray1[1] = fontID;
                objArray1[2] = " ";
                objArray1[3] = fontSize;
                objArray1[4] = "Tf ";
                this.Write(objArray1);
                this.CurrentGS.FontSize = fontSize;
                this.CurrentGS.FontID = fontID;
            }
            return this;
        }

        public PDFPainter Tj(string arg)
        {
            this.BT();
            object[] objArray1 = new object[2];
            objArray1[0] = arg;
            objArray1[1] = " Tj\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter TJ(string arg)
        {
            this.BT();
            object[] objArray1 = new object[2];
            objArray1[0] = arg;
            objArray1[1] = "TJ\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter Tm(CTM arg)
        {
            object[] objArray1;
            if (!this.Is_E_CTM(arg))
            {
                objArray1 = new object[7];
                objArray1[0] = arg[0, 0];
                objArray1[1] = arg[1, 0];
                objArray1[2] = arg[0, 1];
                objArray1[3] = arg[1, 1];
                objArray1[4] = arg[0, 2];
                objArray1[5] = arg[1, 2];
                objArray1[6] = "Tm \n";
                this.Write(objArray1);
            }
            return this;
        }

        public PDFPainter Tr(int r)
        {
            object[] objArray1;
            if ((r > -1) && (r < 8))
            {
                objArray1 = new object[2];
                objArray1[0] = r;
                objArray1[1] = "Tr\n";
                this.Write(objArray1);
            }
            return this;
        }

        public string Translate2Unicode(Font _font, string areaText, XslFoElement foElement, bool isStandart)
        {
            Font font1;
            byte[] numArray1;
            string text2;
            string[] textArray1;
            int num1;
            byte[] numArray2;
            int num2;
            char ch1;
            int[] numArray3;
            int num3;
            int num4;
            int num5;
            bool flag1;
            int num6;
            int num7;
            int num8;
            int num9;
            string text1 = null;
            if (isStandart)
            {
                font1 = _font;
                text2 = areaText;
                textArray1 = font1.Encoding;
                num1 = text2.Length;
                numArray2 = new byte[(num1 * 2)];
                num2 = 0;
                numArray3 = null;
                if (font1.BaseFont == "ZapfDingbats")
                {
                    numArray3 = FontConstants.ZapfDingbatsUnicodes;
                }
                if (font1.BaseFont == "Symbol")
                {
                    numArray3 = FontConstants.SymbolUnicodes;
                }
                num4 = 0;
                while ((num4 < num1))
                {
                    ch1 = text2[num4];
                    num5 = 0;
                    flag1 = true;
                    if (numArray3 == null)
                    {
                        while ((flag1 && (num5 < 380)))
                        {
                            if (ch1 == FontConstants.Unicodes[num5])
                            {
                                flag1 = false;
                            }
                            num5 += 1;
                        }
                        num3 = 0;
                        if (!flag1)
                        {
                            num5 -= 1;
                            flag1 = true;
                            while ((flag1 && (num3 < 256)))
                            {
                                if (FontConstants.glyphPool[num5] == textArray1[num3])
                                {
                                    flag1 = false;
                                }
                                num3 += 1;
                            }
                        }
                        if (!flag1)
                        {
                            num3 -= 1;
                        }
                        else if (((ch1 == '\b') || (ch1 == '\t')) || (((ch1 == '\n') || (ch1 == '\f')) || (ch1 == '\r')))
                        {
                            num3 = ((int) ch1);
                        }
                        else if (foElement == null)
                        {
                            this.mConfig.AddEvent(1, -1, "", ch1, font1.BaseFont);
                        }
                        else
                        {
                            this.mConfig.AddEvent(1, foElement.LineNumber, foElement.TagName, ch1, font1.BaseFont);
                        }
                    }
                    else
                    {
                        num5 = 0;
                        while (((num5 < numArray3.Length) && flag1))
                        {
                            if (numArray3[num5] == ch1)
                            {
                                flag1 = false;
                            }
                            num5 += 1;
                        }
                        if (!flag1)
                        {
                            num3 = (num5 - 1);
                        }
                        else
                        {
                            if (foElement != null)
                            {
                                this.mConfig.AddEvent(1, foElement.LineNumber, foElement.TagName, ch1, font1.BaseFont);
                            }
                            else
                            {
                                this.mConfig.AddEvent(1, -1, "", ch1, font1.BaseFont);
                            }
                            num3 = 0;
                        }
                    }
                    num9 = num3;
                    switch (num9)
                    {
                        case 8:
                        {
                            numArray2[num2] = 92;
                            numArray2[(num2 + 1)] = 98;
                            num2 += 2;
                            goto Label_02E5;
                        }
                        case 9:
                        {
                            numArray2[num2] = 92;
                            numArray2[(num2 + 1)] = 116;
                            num2 += 2;
                            goto Label_02E5;
                        }
                        case 10:
                        {
                            numArray2[num2] = 92;
                            numArray2[(num2 + 1)] = 110;
                            num2 += 2;
                            goto Label_02E5;
                        }
                        case 11:
                        {
                            goto Label_02D7;
                        }
                        case 12:
                        {
                            numArray2[num2] = 92;
                            numArray2[(num2 + 1)] = 102;
                            num2 += 2;
                            goto Label_02E5;
                        }
                        case 13:
                        {
                            numArray2[num2] = 92;
                            numArray2[(num2 + 1)] = 114;
                            num2 += 2;
                            goto Label_02E5;
                        }
                    }
                    switch (num9)
                    {
                        case 40:
                        {
                            numArray2[num2] = 92;
                            numArray2[(num2 + 1)] = 40;
                            num2 += 2;
                            goto Label_02E5;
                        }
                        case 41:
                        {
                            numArray2[num2] = 92;
                            numArray2[(num2 + 1)] = 41;
                            num2 += 2;
                            goto Label_02E5;
                        }
                    }
                    if (num9 == 92)
                    {
                        numArray2[num2] = 92;
                        numArray2[(num2 + 1)] = 92;
                        num2 += 2;
                        goto Label_02E5;
                    }
                Label_02D7:
                    numArray2[num2] = ((byte) num3);
                    num2 += 1;
                Label_02E5:
                    num4 += 1;
                }
                numArray1 = new byte[num2];
                for (num6 = 0; (num6 < num2); num6 += 1)
                {
                    numArray1[num6] = numArray2[num6];
                }
                text1 = "(";
                text1 = text1 + Utils.BytesToString(numArray1);
                return text1 + ")";
            }
            byte[] numArray4 = Encoding.Unicode.GetBytes(areaText);
            byte[] numArray5 = new byte[(numArray4.Length * 2)];
            for (num7 = 0; (((double) num7) < (((double) numArray4.Length) / 2f)); num7 += 1)
            {
                for (num8 = 0; (num8 < 2); num8 += 1)
                {
                    if ((numArray4[((2 * num7) + num8)] / 16) > 9)
                    {
                        numArray5[((4 * num7) + (2 * (1 - num8)))] = ((byte) ((65 + (numArray4[((2 * num7) + num8)] / 16)) - 10));
                    }
                    else
                    {
                        numArray5[((4 * num7) + (2 * (1 - num8)))] = ((byte) (48 + (numArray4[((2 * num7) + num8)] / 16)));
                    }
                    if ((numArray4[((2 * num7) + num8)] % 16) > 9)
                    {
                        numArray5[(((4 * num7) + (2 * (1 - num8))) + 1)] = ((byte) ((65 + (numArray4[((2 * num7) + num8)] % 16)) - 10));
                    }
                    else
                    {
                        numArray5[(((4 * num7) + (2 * (1 - num8))) + 1)] = ((byte) (48 + (numArray4[((2 * num7) + num8)] % 16)));
                    }
                }
            }
            text1 = "<";
            text1 = text1 + Encoding.UTF8.GetString(numArray5);
            return text1 + ">";
        }

        public PDFPainter Ts(double s)
        {
            object[] objArray1 = new object[2];
            objArray1[0] = s;
            objArray1[1] = "Ts\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter Tw(double w)
        {
            object[] objArray1 = new object[2];
            objArray1[0] = w;
            objArray1[1] = "Tw\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter v(double x2, double y2, double x3, double y3)
        {
            if (this.CurrentGS.TextOpened)
            {
                this.ET();
            }
            this.CurrentGS.PathOpened = true;
            object[] objArray1 = new object[5];
            objArray1[0] = x2;
            objArray1[1] = y2;
            objArray1[2] = x3;
            objArray1[3] = y3;
            objArray1[4] = "v\n";
            this.Write(objArray1);
            return this;
        }

        public PDFPainter w(double arg)
        {
            object[] objArray1;
            if (this.CurrentGS.w != arg)
            {
                objArray1 = new object[2];
                objArray1[0] = arg;
                objArray1[1] = "w ";
                this.Write(objArray1);
                this.CurrentGS.w = arg;
            }
            return this;
        }

        public PDFPainter W()
        {
            if (!this.CurrentGS.PathOpened)
            {
                this.Error("Invalid h operator", new string[0]);
            }
            this.Write("W\n");
            return this;
        }

        public PDFPainter W_()
        {
            if (!this.CurrentGS.PathOpened)
            {
                this.Error("Invalid h operator", new string[0]);
            }
            this.Write("W*\n");
            return this;
        }

        protected void Write(params object[] args)
        {
            object obj1;
            int num1;
            string[] textArray1;
            object[] objArray1 = args;
            for (num1 = 0; (num1 < objArray1.Length); num1 += 1)
            {
                obj1 = objArray1[num1];
                if (obj1.GetType() == typeof(string))
                {
                    this.Write(((string) obj1));
                }
                else if (obj1.GetType() == typeof(int))
                {
                    this.Write(((int) obj1));
                }
                else if (obj1.GetType() == typeof(double))
                {
                    this.Write(((double) obj1));
                }
                else if (obj1.GetType() == typeof(Point))
                {
                    this.Write(((Point) obj1));
                }
                else if (obj1.GetType() == typeof(Rect))
                {
                    this.Write(((Rect) obj1));
                }
                else
                {
                    textArray1 = new string[1];
                    textArray1[0] = obj1.GetType().ToString();
                    this.Error("Invalid argument for Write method - %1 not supported", textArray1);
                }
            }
        }

        protected void Write(Point pt)
        {
            object[] objArray1 = new object[2];
            objArray1[0] = pt.x;
            objArray1[1] = pt.y;
            this.Write(objArray1);
        }

        protected void Write(Rect rect)
        {
            object[] objArray1 = new object[4];
            objArray1[0] = rect.Left;
            objArray1[1] = rect.Bottom;
            objArray1[2] = rect.Width;
            objArray1[3] = rect.Height;
            this.Write(objArray1);
        }

        protected void Write(double arg)
        {
            string text1 = arg.ToString("F3", this.PDFNumberFormatInfo);
            if (text1.IndexOf(".") != -1)
            {
                text1 = text1.TrimEnd(PDFPainter.doubleTrimEnd1);
            }
            text1 = text1.TrimEnd(PDFPainter.doubleTrimEnd2);
            this.Write(text1 + " ");
        }

        protected void Write(int arg)
        {
            this.Write(arg.ToString() + " ");
        }

        protected void Write(string arg)
        {
            byte[] numArray1 = Utils.StringToBytes(arg);
            this.mOutput.Write(numArray1, 0, numArray1.Length);
        }

        public PDFPainter y(double x1, double y1, double x3, double y3)
        {
            if (this.CurrentGS.TextOpened)
            {
                this.ET();
            }
            this.CurrentGS.PathOpened = true;
            object[] objArray1 = new object[5];
            objArray1[0] = x1;
            objArray1[1] = y1;
            objArray1[2] = x3;
            objArray1[3] = y3;
            objArray1[4] = "y\n";
            this.Write(objArray1);
            return this;
        }


        // Properties
        public GS GetGS
        {
            get
            {
                return this.CurrentGS;
            }
        }

        public bool PathOpened
        {
            get
            {
                return this.CurrentGS.PathOpened;
            }
        }


        // Fields
        protected GS CurrentGS;
        protected static char[] doubleTrimEnd1;
        protected static char[] doubleTrimEnd2;
        protected Stack GSStack;
        public PDFPainterConfig mConfig;
        protected Stream mOutput;
        protected NumberFormatInfo PDFNumberFormatInfo;
        protected double roundCoeff;
    }
}


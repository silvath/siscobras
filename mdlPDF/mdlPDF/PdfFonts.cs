using System;
using PdfDocument;
using PdfTypes;
using System.Collections;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Text;

namespace PdfFonts
{
	#region PdfType1Font
	public class PdfType1Font:PdfFont
	{
		ushort[] FArray=new ushort[255];
		byte FFirstChar;
		byte FLastChar;
		
		public override void SetData(PdfDictionary Value)
		{			
			ushort DefaultWidth;
			PdfArray Widths;
			PdfNumber Fnumber;

            base.SetData(Value);			
			if(Data.PdfNumberByName("MissingWidth")!=null)
				DefaultWidth=(ushort)Data.PdfNumberByName("MissingWidth").Value;
			else
				DefaultWidth=0;
			for(int i=0;i<FArray.Length;i++)
				FArray[i]=DefaultWidth;

			FFirstChar=(byte)Data.PdfNumberByName("FirstChar").Value;
			FLastChar=(byte)Data.PdfNumberByName("LastChar").Value;

			Widths=Data.PdfArrayByName("Widths");
			for(int i=0;i<Widths.ItemCount-1;i++)
			{
				Fnumber=(PdfNumber)Widths[i];
				FArray[i+FFirstChar]=(ushort)Fnumber.Value;
			}
			Data.RemoveItem("Widths");
		}

		public PdfType1Font(PdfXRef AXref,string AName):base(AXref,AName)
		{
		}

		public override int GetCharWidth(string AText,int APos)
		{
			int index = (int)AText[APos];
			if (index >= FArray.Length)
				index = 254;
			return FArray[index];
		}
	}
	#endregion
	#region PdfTrueType
		public class PdfTrueTypeFont:PdfFont
		{
			#region Imports
				[DllImport("GDI32.DLL", EntryPoint="SelectObject")]
				private static extern IntPtr SelectObject(System.IntPtr ptr1,System.IntPtr ptr2);

				[DllImport("GDI32.DLL", EntryPoint="DeleteObject")]
				private static extern int DeleteObject(System.IntPtr ptr);

				[DllImport("GDI32.DLL", EntryPoint="GetOutlineTextMetrics")]
				private static extern int GetOutlineTextMetrics(System.IntPtr ptr,int nInt, ref struct0E oe);

				[DllImport("GDI32.DLL", EntryPoint="GetTextExtentPoint32")]
				private static extern bool GetTextExtentPoint32(System.IntPtr ptr, string strText, int nInt, ref System.Drawing.Size size);

				[DllImport("GDI32.DLL", EntryPoint="GetFontData")]
				private static extern int GetFontData(System.IntPtr ptr, int nValue, int nValue2, byte[] byData, int nValue3);

				[DllImport("GDI32.DLL", EntryPoint="GetCharWidth32")]
				private static extern bool GetCharWidth32(System.IntPtr ptr, int nValue, int nValueFinal, int[] data);
			#endregion
			#region Structs
				// Nested Types
				[StructLayout(LayoutKind.Sequential)]
				internal struct struct0B
				{
					// Fields
					internal int PT;
					internal int PU;
					internal int PV;
					internal int PW;
					internal int PX;
					internal int PY;
					internal int PZ;
					internal int Q0;
					internal int Q1;
					internal int Q2;
					internal int Q3;
					internal byte Q4;
					internal byte Q5;
					internal byte Q6;
					internal byte Q7;
					internal byte Q8;
					internal byte Q9;
					internal byte QA;
					internal byte QB;
					internal byte QC;
				}

				[StructLayout(LayoutKind.Sequential)]
				internal struct struct0C
				{
					// Fields
					internal int QD;
					internal int QE;
					internal int QF;
					internal int QG;
				}

				[StructLayout(LayoutKind.Sequential)]
				internal struct struct0D
				{
					// Fields
					internal byte QH;
					internal byte QI;
					internal byte QJ;
					internal byte QK;
					internal byte QL;
					internal byte QM;
					internal byte QN;
					internal byte QO;
					internal byte QP;
					internal byte QQ;
				}

				[StructLayout(LayoutKind.Sequential)]
				internal struct struct0E
				{
					// Fields
					internal int QR;
					internal struct0B QS;
					internal byte QT;
					internal struct0D QU;
					internal uint QV;
					internal uint QW;
					internal int QX;
					internal int QY;
					internal int QZ;
					internal uint R0;
					internal int R1;
					internal int R2;
					internal uint R3;
					internal uint R4;
					internal uint R5;
					internal struct0C R6;
					internal int R7;
					internal int R8;
					internal uint R9;
					internal uint RA;
					internal Point RB;
					internal Point RC;
					internal Point RD;
					internal Point RE;
					internal uint RF;
					internal int RG;
					internal int RH;
					internal int RI;
					internal IntPtr RJ;
					internal IntPtr RK;
					internal IntPtr RL;
					internal IntPtr RM;
				}
			#endregion

			#region Atributes
				struct0E PS = new struct0E();
				internal System.Drawing.Font PK;
				ushort[] FArray=new ushort[255];
				byte FFirstChar = 30;
				byte FLastChar = 255;
				int[] ARIAL_W_ARRAY=
					{
						278,278,355,556,556,889,667,191,333,333,389,584,278,333,
						278,278,556,556,556,556,556,556,556,556,556,556,278,278,584,584,
						584,556,1015,667,667,722,722,667,611,778,722,278,500,667,556,833,
						722,778,667,778,722,667,611,722,667,944,667,667,611,278,278,278,
						469,556,333,556,556,500,556,556,278,556,556,222,222,500,222,833,
						556,556,556,556,333,500,278,556,500,722,500,500,500,334,260,334,
						584,0,556,0,222,556,333,1000,556,556,333,1000,667,333,1000,0,
						611,0,0,222,222,333,333,350,556,1000,333,1000,500,333,944,0,
						500,667,0,333,556,556,556,556,260,556,333,737,370,556,584,0,
						737,333,400,584,333,333,333,556,537,278,333,333,365,556,834,834,
						834,611,667,667,667,667,667,667,1000,722,667,667,667,667,278,278,
						278,278,722,722,778,778,778,778,778,584,778,722,722,722,722,667,
						667,611,556,556,556,556,556,556,889,500,556,556,556,556,278,278,
						278,278,556,556,556,556,556,556,556,584,611,556,556,556,556,500,
						556,500
					};
			#endregion
			#region Properties
				internal bool XP
				{
					get
					{
						return (this.PS.QS.QC == 2);
					}
				}

				internal bool XQ
				{
					get
					{
						return ((this.PS.QS.QB & 1) != 1);
					}
				}

				internal bool XR
				{
					get
					{
						return ((this.PS.QS.QB & 64) == 64);
					}
				}

				internal bool XS
				{
					get
					{
						return ((this.PS.QS.QB & 32) == 32);
					}
				}

//				internal bool XT
//				{
//					get
//					{
//						return (this.PR != null);
//					}
//				}
//
//				internal bool XU
//				{
//					get
//					{
//						if (this.PR != null)
//						{
//							return this.PR.NA;
//						}
//						return false;
//					}
//					set
//					{
//						if (this.PR != null)
//						{
//							this.PR.NA = 09F;
//						}
//					}
//				}

//				internal bool XV
//				{
//					get
//					{
//						if (((this.PK != null) && this.PK.Bold) && ((this.PR != null) && this.PR.NA))
//						{
//							return !this.PR.XA;
//						}
//						return false;
//					}
//				}
//
//				internal bool XW
//				{
//					get
//					{
//						if (((this.PK != null) && this.PK.Italic) && ((this.PR != null) && this.PR.NA))
//						{
//							return !this.PR.XB;
//						}
//						return false;
//					}
//				}
			#endregion
			#region Constructors 
				public PdfTrueTypeFont(PdfXRef AXref,string AName):base(AXref,AName)
				{
					PdfDictionary FFont;
					PK = fntReturnFont(AName);
					if (PK != null)
					{
						vAdjustFontSize(PK);
						PdfDictionary dicFontDescriptor = dicCreateFontDescriptor(AXref,AName,PK);
						FFont=new PdfDictionary(AXref);
						AXref.AddObject(FFont);			
						FFont.AddItem("Type",new PdfName("Font"));
						FFont.AddItem("Subtype",new PdfName("TrueType"));
						FFont.AddItem("BaseFont",new PdfName(AName));
						FFont.AddInternalItem("FontDescriptor",dicFontDescriptor);
						FFont.AddItem("Encoding",new PdfName("WinAnsiEncoding"));
						FFont.AddItem("FirstChar",new PdfNumber(FFirstChar));
						FFont.AddItem("LastChar",new PdfNumber(FLastChar));

						PdfArray faWidths = new PdfArray(AXref,ARIAL_W_ARRAY);
						AXref.AddObject(faWidths);
						FFont.AddInternalItem("Widths",faWidths);

						SetData(FFont);
					}
				}
			#endregion
			#region Methods
				private PdfDictionary dicCreateFontDescriptor(PdfXRef AXref,string AName,System.Drawing.Font fntFont)
				{
					PdfDictionary dicFontDescriptor = new PdfDictionary(AXref);
					AXref.AddObject(dicFontDescriptor);
					dicFontDescriptor.AddItem("Type",new PdfName("FontDescriptor"));
					dicFontDescriptor.AddItem("FontName",new PdfName(AName));
					dicFontDescriptor.AddItem("Flags",new PdfNumber(this.nFlag()));
					dicFontDescriptor.AddItem("FontBBox",new PdfArray(AXref,this.aintFontBox()));
					dicFontDescriptor.AddItem("MissingWidth",new PdfNumber((long) this.PS.QS.PY));
					dicFontDescriptor.AddItem("StemV",new PdfNumber(((long) (this.PK.Bold ? 144 : 72))));
					dicFontDescriptor.AddItem("StemH",new PdfNumber(((long) (this.PK.Bold ? 144 : 72))));
					dicFontDescriptor.AddItem("ItalicAngle",new PdfNumber(((long) (this.PK.Italic ? (this.PS.QZ / 10) : 0))));
					dicFontDescriptor.AddItem("CapHeight",new PdfNumber((long) this.PS.R4));
					dicFontDescriptor.AddItem("XHeight",new PdfNumber((long) this.PS.R5));
					dicFontDescriptor.AddItem("Ascent",new PdfNumber((long) this.PS.R1));
					dicFontDescriptor.AddItem("Descent",new PdfNumber((long) this.PS.R2));
					dicFontDescriptor.AddItem("Leading",new PdfNumber((long) this.PS.QS.PX));
					dicFontDescriptor.AddItem("MaxWidth",new PdfNumber((long) this.PS.QS.PZ));
					dicFontDescriptor.AddItem("AvgWidth",new PdfNumber((long) this.PS.QS.PY));
					return(dicFontDescriptor);
				}

		        internal int nFlag()
				{
					int num1 = 0;
					if (this.XQ)
					{
						num1 |= 1;
					}
					if (!this.XS)
					{
						num1 |= 2;
					}
					if (this.XP)
					{
						num1 |= 4;
					}
					if (this.XR)
					{
						num1 |= 8;
					}
					if (!this.XP)
					{
						num1 |= 32;
					}
					if (this.PK.Italic)
					{
						num1 |= 64;
					}
					return num1;
				}

				internal int[] aintFontBox()
				{
					int num1 = this.PS.R6.QD;
					int num2 = this.PS.R6.QF;
					int num3 = this.PS.R6.QE;
					int num4 = this.PS.R6.QG;
					int[] objArray1 = new int[4];
					objArray1[0] = Math.Min(num1, num2);
					objArray1[1] = Math.Min(num3, num4);
					objArray1[2] = Math.Max(num1, num2);
					objArray1[3] = Math.Max(num3, num4);
					return(objArray1);
				}

				public override void SetData(PdfDictionary Value)
				{	
					base.SetData(Value);			
					FArray = new ushort[ARIAL_W_ARRAY.Length];
					for(int i =0; i < ARIAL_W_ARRAY.Length;i++)
						FArray[i] = (ushort)ARIAL_W_ARRAY[i];
//					ushort DefaultWidth;
//					PdfArray Widths;
//					PdfNumber Fnumber;
//
//					if(Data.PdfNumberByName("MissingWidth")!=null)
//						DefaultWidth=(ushort)Data.PdfNumberByName("MissingWidth").Value;
//					else
//						DefaultWidth=0;
//					for(int i=0;i<FArray.Length;i++)
//						FArray[i]=DefaultWidth;
//
//					FFirstChar=(byte)Data.PdfNumberByName("FirstChar").Value;
//					FLastChar=(byte)Data.PdfNumberByName("LastChar").Value;
//
//					Widths=Data.PdfArrayByName("Widths");
//					for(int i=0;i<Widths.ItemCount-1;i++)
//					{
//						Fnumber=(PdfNumber)Widths[i];
//						if (i+FFirstChar < FArray.Length)
//							FArray[i+FFirstChar]=(ushort)Fnumber.Value;
//					}
				}

				public override int GetCharWidth(string AText,int APos)
				{
					int index = (int)AText[APos];
					if (index >= FArray.Length)
						index = FArray.Length - 1;
					return FArray[index];
				}

				private System.Drawing.Font fntReturnFont(string strFontName)
				{
					System.Drawing.Font fntReturn = null;
					int nIndex = strFontName.IndexOf(",");
					if (nIndex == -1)
					{
						fntReturn = new System.Drawing.Font(strFontName,12);
					}else{
						if (strFontName.IndexOf("BoldItalic") > nIndex)
							fntReturn = new System.Drawing.Font(strFontName.Substring(0,nIndex),12,System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
						else if (strFontName.IndexOf("Bold") > nIndex)
							fntReturn = new System.Drawing.Font(strFontName.Substring(0,nIndex),12,System.Drawing.FontStyle.Bold);
						else if (strFontName.IndexOf("Italic") > nIndex)
							fntReturn = new System.Drawing.Font(strFontName.Substring(0,nIndex),12,System.Drawing.FontStyle.Italic);
					}
					return(fntReturn);
				}

				private void vAdjustFontSize(System.Drawing.Font fntFonte)
				{
					PS = new struct0E();
					PS.QR = 212;

					System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1,1);
					System.Drawing.Graphics graph = System.Drawing.Graphics.FromImage(bmp);
					float fUnit = (72000f / graph.DpiX);
					System.Drawing.Font fntUnit = new System.Drawing.Font(fntFonte.Name,fUnit,fntFonte.Style, System.Drawing.GraphicsUnit.Point);
					System.IntPtr ptr1 = graph.GetHdc();
					System.IntPtr ptr2 = fntUnit.ToHfont();
					System.IntPtr ptr3 = SelectObject(ptr1, ptr2);
					if (GetOutlineTextMetrics(ptr1, 212, ref PS) != 0)
					{
						ARIAL_W_ARRAY = new int[((uint) ((PS.QS.Q5 - PS.QS.Q4) + 1))];
						if (System.Environment.OSVersion.Platform >= PlatformID.Win32NT)
						{
							GetCharWidth32(ptr1, PS.QS.Q4, PS.QS.Q5, ARIAL_W_ARRAY);
						}
						else
						{
							System.Drawing.Size size1 = System.Drawing.Size.Empty;
							System.Text.StringBuilder strbMeasure = new System.Text.StringBuilder();
							for (int num1 = 0; (num1 < ARIAL_W_ARRAY.Length); num1 += 1)
							{
								strbMeasure.Length = 0;
								strbMeasure.Append(((char) (PS.QS.Q4 + num1)));
								GetTextExtentPoint32(ptr1, strbMeasure.ToString(), 1, ref size1);
								ARIAL_W_ARRAY[num1] = size1.Width;
							}
						}
					}
	                bool flag1 = ((PS.QW & 1) == 0);
	                if (flag1)
		            {
						int num2 = GetFontData(ptr1, 0, 0, null, 0);
				        //this.PQ = new byte[((uint) num2)];
						//GetFontData(ptr1, 0, 0, this.PQ, num2);
						//this.PR = new Y(this);
	                }
					SelectObject(ptr1, ptr3);
					DeleteObject(ptr2);
				    graph.ReleaseHdc(ptr1);
					fntUnit.Dispose();
					graph.Dispose();
					bmp.Dispose();
				}
			#endregion
		}
	#endregion

	#region PdfArial
		public class PdfArial:PdfType1Font
		{
			int[] ARIAL_W_ARRAY=
				{
					278,278,355,556,556,889,667,191,333,333,389,584,278,333,
					278,278,556,556,556,556,556,556,556,556,556,556,278,278,584,584,
					584,556,1015,667,667,722,722,667,611,778,722,278,500,667,556,833,
					722,778,667,778,722,667,611,722,667,944,667,667,611,278,278,278,
					469,556,333,556,556,500,556,556,278,556,556,222,222,500,222,833,
					556,556,556,556,333,500,278,556,500,722,500,500,500,334,260,334,
					584,0,556,0,222,556,333,1000,556,556,333,1000,667,333,1000,0,
					611,0,0,222,222,333,333,350,556,1000,333,1000,500,333,944,0,
					500,667,0,333,556,556,556,556,260,556,333,737,370,556,584,0,
					737,333,400,584,333,333,333,556,537,278,333,333,365,556,834,834,
					834,611,667,667,667,667,667,667,1000,722,667,667,667,667,278,278,
					278,278,722,722,778,778,778,778,778,584,778,722,722,722,722,667,
					667,611,556,556,556,556,556,556,889,500,556,556,556,556,278,278,
					278,278,556,556,556,556,556,556,556,584,611,556,556,556,556,500,
					556,500
				};

			public PdfArial(PdfXRef AXref,string AName):base(AXref,AName)
			{
				PdfArray FWidths;
				PdfDictionary FFont;

				FFont=new PdfDictionary(AXref);
				AXref.AddObject(FFont);			
				
				AddStrElements(FFont,Generic._String_Table());
				AddIntElements(FFont,Generic._Int_Table());
				FFont.AddItem("BaseFont",new PdfName("Helvetica"));
				
				FWidths=new PdfArray(AXref,ARIAL_W_ARRAY);
				FFont.AddInternalItem("Widths",FWidths);
				SetData(FFont);
			}
		}
	#endregion
	#region PdfArialBold
	public class PdfArialBold:PdfType1Font
	{
		int[] ARIAL_BOLD_W_ARRAY=
			{
				278,333,474,556,556,889,722,238,333,333,389,584,278,333,
				278,278,556,556,556,556,556,556,556,556,556,556,333,333,584,584,
				584,611,975,722,722,722,722,667,611,778,722,278,556,722,611,833,
				722,778,667,778,722,667,611,722,667,944,667,667,611,333,278,333,
				584,556,333,556,611,556,611,556,333,611,611,278,278,556,278,889,
				611,611,611,611,389,556,333,611,556,778,556,556,500,389,280,389,
				584,0,556,0,278,556,500,1000,556,556,333,1000,667,333,1000,0,
				611,0,0,278,278,500,500,350,556,1000,333,1000,556,333,944,0,
				500,667,0,333,556,556,556,556,280,556,333,737,370,556,584,0,
				737,333,400,584,333,333,333,611,556,278,333,333,365,556,834,834,
				834,611,722,722,722,722,722,722,1000,722,667,667,667,667,278,278,
				278,278,722,722,778,778,778,778,778,584,778,722,722,722,722,667,
				667,611,556,556,556,556,556,556,889,556,556,556,556,556,278,278,
				278,278,611,611,611,611,611,611,611,584,611,611,611,611,611,556,
				611,556
			};
		public PdfArialBold(PdfXRef AXref,string AName):base(AXref,AName)
		{
			PdfArray FWidths;
			PdfDictionary FFont;

			FFont=new PdfDictionary(AXref);
			AXref.AddObject(FFont);			
			
			AddStrElements(FFont,Generic._String_Table());
			AddIntElements(FFont,Generic._Int_Table());
			FFont.AddItem("BaseFont",new PdfName("Helvetica-Bold"));
			
			FWidths=new PdfArray(AXref,ARIAL_BOLD_W_ARRAY);
			FFont.AddInternalItem("Widths",FWidths);
			SetData(FFont);
		}
	}
	#endregion
	#region PdfArialboldItalic
	public class PdfArialBoldItalic:PdfType1Font
	{
		int[] ARIAL_BOLDITALIC_W_ARRAY=
			{
				278,333,474,556,556,889,722,238,333,333,389,584,278,333,
				278,278,556,556,556,556,556,556,556,556,556,556,333,333,584,584,
				584,611,975,722,722,722,722,667,611,778,722,278,556,722,611,833,
				722,778,667,778,722,667,611,722,667,944,667,667,611,333,278,333,
				584,556,333,556,611,556,611,556,333,611,611,278,278,556,278,889,
				611,611,611,611,389,556,333,611,556,778,556,556,500,389,280,389,
				584,0,556,0,278,556,500,1000,556,556,333,1000,667,333,1000,0,
				611,0,0,278,278,500,500,350,556,1000,333,1000,556,333,944,0,
				500,667,0,333,556,556,556,556,280,556,333,737,370,556,584,0,
				737,333,400,584,333,333,333,611,556,278,333,333,365,556,834,834,
				834,611,722,722,722,722,722,722,1000,722,667,667,667,667,278,278,
				278,278,722,722,778,778,778,778,778,584,778,722,722,722,722,667,
				667,611,556,556,556,556,556,556,889,556,556,556,556,556,278,278,
				278,278,611,611,611,611,611,611,611,584,611,611,611,611,611,556,
				611,556
			};

		public PdfArialBoldItalic(PdfXRef AXref,string AName):base(AXref,AName)
		{
			PdfArray FWidths;
			PdfDictionary FFont;

			FFont=new PdfDictionary(AXref);
			AXref.AddObject(FFont);			
			
			AddStrElements(FFont,Generic._String_Table());
			AddIntElements(FFont,Generic._Int_Table());
			FFont.AddItem("BaseFont",new PdfName("Helvetica-BoldOblique"));
			
			FWidths=new PdfArray(AXref,ARIAL_BOLDITALIC_W_ARRAY);
			FFont.AddInternalItem("Widths",FWidths);
			SetData(FFont);
		}
	}
	#endregion
	#region PdfArialItalic
	public class PdfArialItalic:PdfType1Font
	{
		int[] ARIAL_ITALIC_W_ARRAY=
			{
				278,278,355,556,556,889,667,191,333,333,389,584,278,333,
				278,278,556,556,556,556,556,556,556,556,556,556,278,278,584,584,
				584,556,1015,667,667,722,722,667,611,778,722,278,500,667,556,833,
				722,778,667,778,722,667,611,722,667,944,667,667,611,278,278,278,
				469,556,333,556,556,500,556,556,278,556,556,222,222,500,222,833,
				556,556,556,556,333,500,278,556,500,722,500,500,500,334,260,334,
				584,0,556,0,222,556,333,1000,556,556,333,1000,667,333,1000,0,
				611,0,0,222,222,333,333,350,556,1000,333,1000,500,333,944,0,
				500,667,0,333,556,556,556,556,260,556,333,737,370,556,584,0,
				737,333,400,584,333,333,333,556,537,278,333,333,365,556,834,834,
				834,611,667,667,667,667,667,667,1000,722,667,667,667,667,278,278,
				278,278,722,722,778,778,778,778,778,584,778,722,722,722,722,667,
				667,611,556,556,556,556,556,556,889,500,556,556,556,556,278,278,
				278,278,556,556,556,556,556,556,556,584,611,556,556,556,556,500,
				556,500
			};

		public PdfArialItalic(PdfXRef AXref,string AName):base(AXref,AName)
		{
			PdfArray FWidths;
			PdfDictionary FFont;

			FFont=new PdfDictionary(AXref);
			AXref.AddObject(FFont);			
			
			AddStrElements(FFont,Generic._String_Table());
			AddIntElements(FFont,Generic._Int_Table());
			FFont.AddItem("BaseFont",new PdfName("Helvetica-Oblique"));
			
			FWidths=new PdfArray(AXref,ARIAL_ITALIC_W_ARRAY);
			FFont.AddInternalItem("Widths",FWidths);
			SetData(FFont);
		}
	}
	#endregion

	#region PdfFixedWidth
	public class PdfFixedWidth:PdfType1Font
	{
		int[] FIXED_WIDTH_W_ARRAY=
			{
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600
			};

		public PdfFixedWidth(PdfXRef AXref,string AName):base(AXref,AName)
		{
			PdfArray FWidths;
			PdfDictionary FFont;

			FFont=new PdfDictionary(AXref);
			AXref.AddObject(FFont);			
			
			AddStrElements(FFont,Generic._String_Table());
			AddIntElements(FFont,Generic._Int_Table());
			FFont.AddItem("BaseFont",new PdfName("Courier"));
			
			FWidths=new PdfArray(AXref,FIXED_WIDTH_W_ARRAY);
			FFont.AddInternalItem("Widths",FWidths);
			SetData(FFont);
		}
	}
	#endregion
	#region PdfFixedWidthBold
	public class PdfFixedWidthBold:PdfType1Font
	{
		int[] FIXED_WIDTH_BOLD_W_ARRAY=
			{
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600
			};

		public PdfFixedWidthBold(PdfXRef AXref,string AName):base(AXref,AName)
		{
			PdfArray FWidths;
			PdfDictionary FFont;

			FFont=new PdfDictionary(AXref);
			AXref.AddObject(FFont);			
			
			AddStrElements(FFont,Generic._String_Table());
			AddIntElements(FFont,Generic._Int_Table());
			FFont.AddItem("BaseFont",new PdfName("Courier-Bold"));
			
			FWidths=new PdfArray(AXref,FIXED_WIDTH_BOLD_W_ARRAY);
			FFont.AddInternalItem("Widths",FWidths);
			SetData(FFont);
		}
	}
	#endregion
	#region PdfFixedWidthBoldItalic
	public class PdfFixedWidthBoldItalic:PdfType1Font
	{
		int[] FIXED_WIDTH_BOLDITALIC_W_ARRAY=
			{
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600
			};

		public PdfFixedWidthBoldItalic(PdfXRef AXref,string AName):base(AXref,AName)
		{
			PdfArray FWidths;
			PdfDictionary FFont;

			FFont=new PdfDictionary(AXref);
			AXref.AddObject(FFont);			
			
			AddStrElements(FFont,Generic._String_Table());
			AddIntElements(FFont,Generic._Int_Table());
			FFont.AddItem("BaseFont",new PdfName("Courier-BoldOblique"));
			
			FWidths=new PdfArray(AXref,FIXED_WIDTH_BOLDITALIC_W_ARRAY);
			FFont.AddInternalItem("Widths",FWidths);
			SetData(FFont);
		}
	}
	#endregion
	#region PdfFixedWidthItalic
	public class PdfFixedWidthItalic:PdfType1Font
	{
		int[] FIXED_WIDTH_ITALIC_W_ARRAY=
			{
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,
				600,600
			};

		public PdfFixedWidthItalic(PdfXRef AXref,string AName):base(AXref,AName)
		{
			PdfArray FWidths;
			PdfDictionary FFont;

			FFont=new PdfDictionary(AXref);
			AXref.AddObject(FFont);			
			
			AddStrElements(FFont,Generic._String_Table());
			AddIntElements(FFont,Generic._Int_Table());
			FFont.AddItem("BaseFont",new PdfName("Courier-Oblique"));
			
			FWidths=new PdfArray(AXref,FIXED_WIDTH_ITALIC_W_ARRAY);
			FFont.AddInternalItem("Widths",FWidths);
			SetData(FFont);
		}
	}
	#endregion

	#region PdfScript
	public class PdfScript:PdfType1Font
	{
		int[] SCRIPT_BBOX=
			{
				-184,-363,505,758
			};

		int[] SCRIPT_W_ARRAY=
			{
				323,202,323,424,404,485,525,202,283,283,323,525,202,525,202,444,
				404,404,404,404,404,404,404,404,404,404,202,202,485,525,485,364,
				545,404,465,404,465,404,404,465,485,343,303,485,384,667,485,424,
				505,444,505,404,384,485,465,566,485,465,424,283,283,283,444,323,
				222,323,283,222,323,202,162,303,303,141,141,283,162,505,364,283,
				303,303,263,222,182,303,303,424,323,303,283,283,162,283,485,202,
				202,202,202,202,202,202,202,202,202,202,202,202,202,202,202,202,
				202,222,202,202,202,202,202,202,202,202,202,202,202,202,202,202,
				202,202,222,384,283,465,162,283,404,283,323,404,404,404,283,404,
				404,404,404,404,404,384,424,404,404,404,283,404,404,404,404,364,
				404,404,404,404,404,404,566,404,404,404,404,404,343,343,343,343,
				465,485,424,424,424,424,424,323,404,485,485,485,485,465,444,444,
				323,323,323,323,323,323,384,222,202,202,202,202,141,141,141,141,
				283,364,283,283,283,283,283,404,283,303,303,303,303,303,384,303
			};

		public PdfScript(PdfXRef AXref,string AName):base(AXref,AName)
		{
			PdfArray FWidths;
			PdfDictionary FFont;
			PdfDictionary FFontDescriptor;

			FFont=new PdfDictionary(AXref);
			AXref.AddObject(FFont);			
			
			AddStrElements(FFont,Generic._String_Table());
			AddIntElements(FFont,Generic._Int_Table());
			FFont.AddItem("BaseFont",new PdfName("Script"));

			FFontDescriptor=new PdfDictionary(AXref);
			AXref.AddObject(FFontDescriptor);

			AddStrElements(FFontDescriptor,Generic._Script_String_Table());
			AddIntElements(FFontDescriptor,Generic._Script_Int_Table());
			FFontDescriptor.AddItem("FontBBox",new PdfArray(AXref,SCRIPT_BBOX));
			FFont.AddItem("FontDescriptor",FFontDescriptor);
			
			FWidths=new PdfArray(AXref,SCRIPT_W_ARRAY);
			FFont.AddItem("Widths",FWidths);
			SetData(FFont);
		}
	}
	#endregion

	#region PdfTimesBold
	public class PdfTimesBold:PdfType1Font
	{
		int[] TIMES_BOLD_W_ARRAY=
			{
				250,333,555,500,500,1000,833,278,333,333,500,570,250,333,
				250,278,500,500,500,500,500,500,500,500,500,500,333,333,570,570,
				570,500,930,722,667,722,722,667,611,778,778,389,500,778,667,944,
				722,778,611,778,722,556,667,722,722,1000,722,722,667,333,278,333,
				581,500,333,500,556,444,556,444,333,500,556,278,333,556,278,833,
				556,500,556,556,444,389,333,556,500,722,500,500,444,394,220,394,
				520,0,500,0,333,500,500,1000,500,500,333,1000,556,333,1000,0,
				667,0,0,333,333,500,500,350,500,1000,333,1000,389,333,722,0,
				444,722,0,333,500,500,500,500,220,500,333,747,300,500,570,0,
				747,333,400,570,300,300,333,556,540,250,333,300,330,500,750,750,
				750,500,722,722,722,722,722,722,1000,722,667,667,667,667,389,389,
				389,389,722,722,778,778,778,778,778,570,778,722,722,722,722,722,
				611,556,500,500,500,500,500,500,722,444,444,444,444,444,278,278,
				278,278,500,556,500,500,500,500,500,570,500,556,556,556,556,500,
				556,500
			};
		public PdfTimesBold(PdfXRef AXref,string AName):base(AXref,AName)
		{
			PdfArray FWidths;
			PdfDictionary FFont;

			FFont=new PdfDictionary(AXref);
			AXref.AddObject(FFont);			
			
			AddStrElements(FFont,Generic._String_Table());
			AddIntElements(FFont,Generic._Int_Table());
			FFont.AddItem("BaseFont",new PdfName("Times-Bold"));
			
			FWidths=new PdfArray(AXref,TIMES_BOLD_W_ARRAY);
			FFont.AddInternalItem("Widths",FWidths);
			SetData(FFont);
		}
	}
	#endregion
	#region PdfTimesBoldItalic
	public class PdfTimesBoldItalic:PdfType1Font
	{
		int[] TIMES_BOLDITALIC_W_ARRAY=
			{
				250,389,555,500,500,833,778,278,333,333,500,570,250,333,
				250,278,500,500,500,500,500,500,500,500,500,500,333,333,570,570,
				570,500,832,667,667,667,722,667,667,722,778,389,500,667,611,889,
				722,722,611,722,667,556,611,722,667,889,667,611,611,333,278,333,
				570,500,333,500,500,444,500,444,333,500,556,278,278,500,278,778,
				556,500,500,500,389,389,278,556,444,667,500,444,389,348,220,348,
				570,0,500,0,333,500,500,1000,500,500,333,1000,556,333,944,0,
				611,0,0,333,333,500,500,350,500,1000,333,1000,389,333,722,0,
				389,611,0,389,500,500,500,500,220,500,333,747,266,500,606,0,
				747,333,400,570,300,300,333,576,500,250,333,300,300,500,750,750,
				750,500,667,667,667,667,667,667,944,667,667,667,667,667,389,389,
				389,389,722,722,722,722,722,722,722,570,722,722,722,722,722,611,
				611,500,500,500,500,500,500,500,722,444,444,444,444,444,278,278,
				278,278,500,556,500,500,500,500,500,570,500,556,556,556,556,444,
				500,444
			};
		public PdfTimesBoldItalic(PdfXRef AXref,string AName):base(AXref,AName)
		{
			PdfArray FWidths;
			PdfDictionary FFont;

			FFont=new PdfDictionary(AXref);
			AXref.AddObject(FFont);			
			
			AddStrElements(FFont,Generic._String_Table());
			AddIntElements(FFont,Generic._Int_Table());
			FFont.AddItem("BaseFont",new PdfName("Times-BoldItalic"));
			
			FWidths=new PdfArray(AXref,TIMES_BOLDITALIC_W_ARRAY);
			FFont.AddInternalItem("Widths",FWidths);
			SetData(FFont);
		}
	}
	#endregion
	#region PdfTimesItalic
	public class PdfTimesItalic:PdfType1Font
	{
		int[] TIMES_ITALIC_W_ARRAY=
			{
				250,333,420,500,500,833,778,214,333,333,500,675,250,333,
				250,278,500,500,500,500,500,500,500,500,500,500,333,333,675,675,
				675,500,920,611,611,667,722,611,611,722,722,333,444,667,556,833,
				667,722,611,722,611,500,556,722,611,833,611,556,556,389,278,389,
				422,500,333,500,500,444,500,444,278,500,500,278,278,444,278,722,
				500,500,500,500,389,389,278,500,444,667,444,444,389,400,275,400,
				541,0,500,0,333,500,556,889,500,500,333,1000,500,333,944,0,
				556,0,0,333,333,556,556,350,500,889,333,980,389,333,667,0,
				389,556,0,389,500,500,500,500,275,500,333,760,276,500,675,0,
				760,333,400,675,300,300,333,500,523,250,333,300,310,500,750,750,
				750,500,611,611,611,611,611,611,889,667,611,611,611,611,333,333,
				333,333,722,667,722,722,722,722,722,675,722,722,722,722,722,556,
				611,500,500,500,500,500,500,500,667,444,444,444,444,444,278,278,
				278,278,500,500,500,500,500,500,500,675,500,500,500,500,500,444,
				500,444
			};
		public PdfTimesItalic(PdfXRef AXref,string AName):base(AXref,AName)
		{
			PdfArray FWidths;
			PdfDictionary FFont;

			FFont=new PdfDictionary(AXref);
			AXref.AddObject(FFont);			
			
			AddStrElements(FFont,Generic._String_Table());
			AddIntElements(FFont,Generic._Int_Table());
			FFont.AddItem("BaseFont",new PdfName("Times-Italic"));
			
			FWidths=new PdfArray(AXref,TIMES_ITALIC_W_ARRAY);
			FFont.AddInternalItem("Widths",FWidths);
			SetData(FFont);
		}
	}
	#endregion
	#region PdfTimesRoman
	public class PdfTimesRoman:PdfType1Font
	{
		int[] TIMES_ROMAN_W_ARRAY=
			{
				250,333,408,500,500,833,778,180,333,333,500,564,250,333,
				250,278,500,500,500,500,500,500,500,500,500,500,278,278,564,564,
				564,444,921,722,667,667,722,611,556,722,722,333,389,722,611,889,
				722,722,556,722,667,556,611,722,722,944,722,722,611,333,278,333,
				469,500,333,444,500,444,500,444,333,500,500,278,278,500,278,778,
				500,500,500,500,333,389,278,500,500,722,500,500,444,480,200,480,
				541,0,500,0,333,500,444,1000,500,500,333,1000,556,333,889,0,
				611,0,0,333,333,444,444,350,500,1000,333,980,389,333,722,0,
				444,722,0,333,500,500,500,500,200,500,333,760,276,500,564,0,
				760,333,400,564,300,300,333,500,453,250,333,300,310,500,750,750,
				750,444,722,722,722,722,722,722,889,667,611,611,611,611,333,333,
				333,333,722,722,722,722,722,722,722,564,722,722,722,722,722,722,
				556,500,444,444,444,444,444,444,667,444,444,444,444,444,278,278,
				278,278,500,500,500,500,500,500,500,564,500,500,500,500,500,500,
				500,500
			};
		public PdfTimesRoman(PdfXRef AXref,string AName):base(AXref,AName)
		{
			PdfArray FWidths;
			PdfDictionary FFont;

			FFont=new PdfDictionary(AXref);
			AXref.AddObject(FFont);			
			
			AddStrElements(FFont,Generic._String_Table());
			AddIntElements(FFont,Generic._Int_Table());
			FFont.AddItem("BaseFont",new PdfName("Times-Roman"));
			
			FWidths=new PdfArray(AXref,TIMES_ROMAN_W_ARRAY);
			FFont.AddInternalItem("Widths",FWidths);
			SetData(FFont);
		}
	}
	#endregion
}

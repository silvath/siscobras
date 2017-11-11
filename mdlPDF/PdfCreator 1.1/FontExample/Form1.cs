using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace FontExample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Report.SDReport sdReport1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private Report.SDPage sdPage1;
		private Report.SDLayoutPanel sdLayoutPanel1;
		private Report.SDLabel sdLabel1;
		private Report.SDRect sdRect1;
		private Report.SDText sdText1;
		private Report.SDText sdText2;
		private Report.SDText sdText3;
		private Report.SDText sdText4;
		private Report.SDText sdText5;
		private Report.SDText sdText6;
		private Report.SDText sdText7;
		private Report.SDText sdText8;
		private Report.SDText sdText9;
		private Report.SDText sdText10;
		private Report.SDText sdText11;
		private Report.SDText sdText12;
		private Report.SDText sdText13;
		private Report.SDText sdText14;
		private Report.SDText sdText15;
		private Report.SDText sdText16;
		private Report.SDText sdText17;
		private Report.SDText sdText18;
		private Report.SDText sdText19;
		private Report.SDText sdText20;
		private Report.SDText sdText21;
		private Report.SDText sdText22;
		private Report.SDRect sdRect2;
		private Report.SDText sdText23;
		private Report.SDText sdText24;
		private Report.SDText sdText25;
		private Report.SDText sdText26;
		private Report.SDText sdText27;
		private Report.SDText sdText28;
		private Report.SDText sdText29;
		private Report.SDText sdText30;
		private Report.SDText sdText31;
		private Report.SDText sdText32;
		private Report.SDText sdText33;
		private Report.SDText sdText34;
		private Report.SDText sdText35;
		private Report.SDText sdText36;
		private Report.SDLabel sdLabel2;
		private Report.SDLabel sdLabel3;
		private Report.SDText sdText37;
		private Report.SDLabel sdLabel4;
		private Report.SDText sdText39;
		private Report.SDLabel sdLabel5;
		private Report.SDText sdText40;
		private Report.SDRect sdRect3;
		private Report.SDText sdText41;
		private Report.SDText sdText42;
		private Report.SDLabel sdLabel6;
		private Report.SDText sdText43;
		private Report.SDText sdText44;
		private Report.SDText sdText45;
		private Report.SDText sdText46;
		private Report.SDText sdText47;
		private Report.SDText sdText48;
		private Report.SDText sdText38;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sdReport1 = new Report.SDReport();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.sdPage1 = new Report.SDPage();
			this.sdLayoutPanel1 = new Report.SDLayoutPanel();
			this.sdText47 = new Report.SDText();
			this.sdText48 = new Report.SDText();
			this.sdText45 = new Report.SDText();
			this.sdText46 = new Report.SDText();
			this.sdText43 = new Report.SDText();
			this.sdText44 = new Report.SDText();
			this.sdLabel6 = new Report.SDLabel();
			this.sdText41 = new Report.SDText();
			this.sdText42 = new Report.SDText();
			this.sdRect3 = new Report.SDRect();
			this.sdLabel5 = new Report.SDLabel();
			this.sdText40 = new Report.SDText();
			this.sdLabel4 = new Report.SDLabel();
			this.sdText39 = new Report.SDText();
			this.sdLabel3 = new Report.SDLabel();
			this.sdText37 = new Report.SDText();
			this.sdLabel2 = new Report.SDLabel();
			this.sdText38 = new Report.SDText();
			this.sdText35 = new Report.SDText();
			this.sdText36 = new Report.SDText();
			this.sdText33 = new Report.SDText();
			this.sdText34 = new Report.SDText();
			this.sdText31 = new Report.SDText();
			this.sdText32 = new Report.SDText();
			this.sdText29 = new Report.SDText();
			this.sdText30 = new Report.SDText();
			this.sdText27 = new Report.SDText();
			this.sdText28 = new Report.SDText();
			this.sdText25 = new Report.SDText();
			this.sdText26 = new Report.SDText();
			this.sdText23 = new Report.SDText();
			this.sdText24 = new Report.SDText();
			this.sdRect2 = new Report.SDRect();
			this.sdText21 = new Report.SDText();
			this.sdText22 = new Report.SDText();
			this.sdText19 = new Report.SDText();
			this.sdText20 = new Report.SDText();
			this.sdText17 = new Report.SDText();
			this.sdText18 = new Report.SDText();
			this.sdText15 = new Report.SDText();
			this.sdText16 = new Report.SDText();
			this.sdText13 = new Report.SDText();
			this.sdText14 = new Report.SDText();
			this.sdText11 = new Report.SDText();
			this.sdText12 = new Report.SDText();
			this.sdText9 = new Report.SDText();
			this.sdText10 = new Report.SDText();
			this.sdText8 = new Report.SDText();
			this.sdText7 = new Report.SDText();
			this.sdText6 = new Report.SDText();
			this.sdText5 = new Report.SDText();
			this.sdText4 = new Report.SDText();
			this.sdText3 = new Report.SDText();
			this.sdText2 = new Report.SDText();
			this.sdText1 = new Report.SDText();
			this.sdRect1 = new Report.SDRect();
			this.sdLabel1 = new Report.SDLabel();
			this.sdPage1.SuspendLayout();
			this.sdLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// sdReport1
			// 
			this.sdReport1.Author = null;
			this.sdReport1.CreationDate = new System.DateTime(2002, 12, 25, 0, 16, 37, 244);
			this.sdReport1.Creator = null;
			this.sdReport1.FileName = "default.pdf";
			this.sdReport1.Keywords = null;
			this.sdReport1.ModDate = new System.DateTime(((long)(0)));
			this.sdReport1.Subject = null;
			this.sdReport1.Title = null;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3});
			this.menuItem1.Text = "&File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Create &Pdf";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "E&xit";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileName = "FontExample.pdf";
			this.saveFileDialog1.Filter = "PDF Files|*.pdf|All Files|*.*";
			// 
			// sdPage1
			// 
			this.sdPage1.Controls.Add(this.sdLayoutPanel1);
			this.sdPage1.DockPadding.All = 32;
			this.sdPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage1.Location = new System.Drawing.Point(14, 11);
			this.sdPage1.Name = "sdPage1";
			this.sdPage1.Size = new System.Drawing.Size(600, 700);
			this.sdPage1.TabIndex = 0;
			this.sdPage1.Text = "sdPage1";
			// 
			// sdLayoutPanel1
			// 
			this.sdLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel1.Controls.Add(this.sdText47);
			this.sdLayoutPanel1.Controls.Add(this.sdText48);
			this.sdLayoutPanel1.Controls.Add(this.sdText45);
			this.sdLayoutPanel1.Controls.Add(this.sdText46);
			this.sdLayoutPanel1.Controls.Add(this.sdText43);
			this.sdLayoutPanel1.Controls.Add(this.sdText44);
			this.sdLayoutPanel1.Controls.Add(this.sdLabel6);
			this.sdLayoutPanel1.Controls.Add(this.sdText41);
			this.sdLayoutPanel1.Controls.Add(this.sdText42);
			this.sdLayoutPanel1.Controls.Add(this.sdRect3);
			this.sdLayoutPanel1.Controls.Add(this.sdLabel5);
			this.sdLayoutPanel1.Controls.Add(this.sdText40);
			this.sdLayoutPanel1.Controls.Add(this.sdLabel4);
			this.sdLayoutPanel1.Controls.Add(this.sdText39);
			this.sdLayoutPanel1.Controls.Add(this.sdLabel3);
			this.sdLayoutPanel1.Controls.Add(this.sdText37);
			this.sdLayoutPanel1.Controls.Add(this.sdLabel2);
			this.sdLayoutPanel1.Controls.Add(this.sdText38);
			this.sdLayoutPanel1.Controls.Add(this.sdText35);
			this.sdLayoutPanel1.Controls.Add(this.sdText36);
			this.sdLayoutPanel1.Controls.Add(this.sdText33);
			this.sdLayoutPanel1.Controls.Add(this.sdText34);
			this.sdLayoutPanel1.Controls.Add(this.sdText31);
			this.sdLayoutPanel1.Controls.Add(this.sdText32);
			this.sdLayoutPanel1.Controls.Add(this.sdText29);
			this.sdLayoutPanel1.Controls.Add(this.sdText30);
			this.sdLayoutPanel1.Controls.Add(this.sdText27);
			this.sdLayoutPanel1.Controls.Add(this.sdText28);
			this.sdLayoutPanel1.Controls.Add(this.sdText25);
			this.sdLayoutPanel1.Controls.Add(this.sdText26);
			this.sdLayoutPanel1.Controls.Add(this.sdText23);
			this.sdLayoutPanel1.Controls.Add(this.sdText24);
			this.sdLayoutPanel1.Controls.Add(this.sdRect2);
			this.sdLayoutPanel1.Controls.Add(this.sdText21);
			this.sdLayoutPanel1.Controls.Add(this.sdText22);
			this.sdLayoutPanel1.Controls.Add(this.sdText19);
			this.sdLayoutPanel1.Controls.Add(this.sdText20);
			this.sdLayoutPanel1.Controls.Add(this.sdText17);
			this.sdLayoutPanel1.Controls.Add(this.sdText18);
			this.sdLayoutPanel1.Controls.Add(this.sdText15);
			this.sdLayoutPanel1.Controls.Add(this.sdText16);
			this.sdLayoutPanel1.Controls.Add(this.sdText13);
			this.sdLayoutPanel1.Controls.Add(this.sdText14);
			this.sdLayoutPanel1.Controls.Add(this.sdText11);
			this.sdLayoutPanel1.Controls.Add(this.sdText12);
			this.sdLayoutPanel1.Controls.Add(this.sdText9);
			this.sdLayoutPanel1.Controls.Add(this.sdText10);
			this.sdLayoutPanel1.Controls.Add(this.sdText8);
			this.sdLayoutPanel1.Controls.Add(this.sdText7);
			this.sdLayoutPanel1.Controls.Add(this.sdText6);
			this.sdLayoutPanel1.Controls.Add(this.sdText5);
			this.sdLayoutPanel1.Controls.Add(this.sdText4);
			this.sdLayoutPanel1.Controls.Add(this.sdText3);
			this.sdLayoutPanel1.Controls.Add(this.sdText2);
			this.sdLayoutPanel1.Controls.Add(this.sdText1);
			this.sdLayoutPanel1.Controls.Add(this.sdRect1);
			this.sdLayoutPanel1.Controls.Add(this.sdLabel1);
			this.sdLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.sdLayoutPanel1.Name = "sdLayoutPanel1";
			this.sdLayoutPanel1.Size = new System.Drawing.Size(600, 700);
			this.sdLayoutPanel1.TabIndex = 0;
			this.sdLayoutPanel1.Text = "sdLayoutPanel1";
			// 
			// sdText47
			// 
			this.sdText47.CharSpace = 2F;
			this.sdText47.FontColor = System.Drawing.Color.Black;
			this.sdText47.FontName = Report.SdFontName.Arial;
			this.sdText47.FontSize = 16F;
			this.sdText47.Leading = 14F;
			this.sdText47.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText47.Location = new System.Drawing.Point(328, 616);
			this.sdText47.Name = "sdText47";
			this.sdText47.NodeValue = null;
			this.sdText47.Size = new System.Drawing.Size(224, 21);
			this.sdText47.TabIndex = 56;
			this.sdText47.WordSpace = 0F;
			// 
			// sdText48
			// 
			this.sdText48.CharSpace = 0F;
			this.sdText48.FontColor = System.Drawing.Color.Black;
			this.sdText48.FontName = Report.SdFontName.Arial;
			this.sdText48.FontSize = 9F;
			this.sdText48.Leading = 14F;
			this.sdText48.Lines = new string[] {
												   "CharSpace=2"};
			this.sdText48.Location = new System.Drawing.Point(328, 600);
			this.sdText48.Name = "sdText48";
			this.sdText48.NodeValue = null;
			this.sdText48.Size = new System.Drawing.Size(157, 14);
			this.sdText48.TabIndex = 55;
			this.sdText48.WordSpace = 0F;
			// 
			// sdText45
			// 
			this.sdText45.CharSpace = 0F;
			this.sdText45.FontColor = System.Drawing.Color.Black;
			this.sdText45.FontName = Report.SdFontName.Arial;
			this.sdText45.FontSize = 16F;
			this.sdText45.Leading = 14F;
			this.sdText45.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText45.Location = new System.Drawing.Point(328, 560);
			this.sdText45.Name = "sdText45";
			this.sdText45.NodeValue = null;
			this.sdText45.Size = new System.Drawing.Size(224, 21);
			this.sdText45.TabIndex = 54;
			this.sdText45.WordSpace = 0F;
			// 
			// sdText46
			// 
			this.sdText46.CharSpace = 0F;
			this.sdText46.FontColor = System.Drawing.Color.Black;
			this.sdText46.FontName = Report.SdFontName.Arial;
			this.sdText46.FontSize = 9F;
			this.sdText46.Leading = 14F;
			this.sdText46.Lines = new string[] {
												   "CharSpace=0(default)"};
			this.sdText46.Location = new System.Drawing.Point(328, 544);
			this.sdText46.Name = "sdText46";
			this.sdText46.NodeValue = null;
			this.sdText46.Size = new System.Drawing.Size(157, 14);
			this.sdText46.TabIndex = 53;
			this.sdText46.WordSpace = 0F;
			// 
			// sdText43
			// 
			this.sdText43.CharSpace = 0F;
			this.sdText43.FontBold = true;
			this.sdText43.FontColor = System.Drawing.Color.DarkOrange;
			this.sdText43.FontName = Report.SdFontName.Arial;
			this.sdText43.FontSize = 11F;
			this.sdText43.Leading = 12F;
			this.sdText43.Lines = new string[] {
												   "Sunday Monday Tuesday Wednesday Thursday Friday Saturday "};
			this.sdText43.Location = new System.Drawing.Point(24, 608);
			this.sdText43.Name = "sdText43";
			this.sdText43.NodeValue = null;
			this.sdText43.Size = new System.Drawing.Size(272, 32);
			this.sdText43.TabIndex = 52;
			this.sdText43.WordSpace = 10F;
			this.sdText43.WordWrap = true;
			// 
			// sdText44
			// 
			this.sdText44.CharSpace = 0F;
			this.sdText44.FontColor = System.Drawing.Color.Black;
			this.sdText44.FontName = Report.SdFontName.Arial;
			this.sdText44.FontSize = 9F;
			this.sdText44.Leading = 14F;
			this.sdText44.Lines = new string[] {
												   "WordWrap Text (Leading 12, WordSpace 10)"};
			this.sdText44.Location = new System.Drawing.Point(24, 592);
			this.sdText44.Name = "sdText44";
			this.sdText44.NodeValue = null;
			this.sdText44.Size = new System.Drawing.Size(192, 14);
			this.sdText44.TabIndex = 51;
			this.sdText44.WordSpace = 0F;
			// 
			// sdLabel6
			// 
			this.sdLabel6.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel6.CharSpace = 0F;
			this.sdLabel6.FontColor = System.Drawing.Color.Black;
			this.sdLabel6.FontName = Report.SdFontName.Arial;
			this.sdLabel6.FontSize = 9F;
			this.sdLabel6.Location = new System.Drawing.Point(-8, 670);
			this.sdLabel6.Name = "sdLabel6";
			this.sdLabel6.Size = new System.Drawing.Size(600, 30);
			this.sdLabel6.TabIndex = 50;
			this.sdLabel6.Text = "Copyright(C) 2002 Serdar Dirican";
			this.sdLabel6.WordSpace = 0F;
			// 
			// sdText41
			// 
			this.sdText41.CharSpace = 0F;
			this.sdText41.FontBold = true;
			this.sdText41.FontColor = System.Drawing.Color.DarkOrange;
			this.sdText41.FontName = Report.SdFontName.Arial;
			this.sdText41.FontSize = 11F;
			this.sdText41.Leading = 12F;
			this.sdText41.Lines = new string[] {
												   "Sunday Monday Tuesday Wednesday Thursday Friday Saturday "};
			this.sdText41.Location = new System.Drawing.Point(24, 560);
			this.sdText41.Name = "sdText41";
			this.sdText41.NodeValue = null;
			this.sdText41.Size = new System.Drawing.Size(256, 32);
			this.sdText41.TabIndex = 49;
			this.sdText41.WordSpace = 0F;
			this.sdText41.WordWrap = true;
			// 
			// sdText42
			// 
			this.sdText42.CharSpace = 0F;
			this.sdText42.FontColor = System.Drawing.Color.Black;
			this.sdText42.FontName = Report.SdFontName.Arial;
			this.sdText42.FontSize = 9F;
			this.sdText42.Leading = 14F;
			this.sdText42.Lines = new string[] {
												   "WordWrap Text (Leading 12)"};
			this.sdText42.Location = new System.Drawing.Point(24, 544);
			this.sdText42.Name = "sdText42";
			this.sdText42.NodeValue = null;
			this.sdText42.Size = new System.Drawing.Size(192, 14);
			this.sdText42.TabIndex = 48;
			this.sdText42.WordSpace = 0F;
			// 
			// sdRect3
			// 
			this.sdRect3.FillColor = System.Drawing.Color.Transparent;
			this.sdRect3.LineColor = System.Drawing.Color.Black;
			this.sdRect3.LineStyle = Report.PenStyle.Solid;
			this.sdRect3.LineWidth = 1F;
			this.sdRect3.Location = new System.Drawing.Point(8, 536);
			this.sdRect3.Name = "sdRect3";
			this.sdRect3.Size = new System.Drawing.Size(584, 104);
			this.sdRect3.TabIndex = 47;
			this.sdRect3.Text = "sdRect3";
			// 
			// sdLabel5
			// 
			this.sdLabel5.AlignJustified = true;
			this.sdLabel5.CharSpace = 0F;
			this.sdLabel5.FontBold = true;
			this.sdLabel5.FontColor = System.Drawing.Color.Green;
			this.sdLabel5.FontName = Report.SdFontName.TimesRoman;
			this.sdLabel5.FontSize = 12F;
			this.sdLabel5.Location = new System.Drawing.Point(320, 496);
			this.sdLabel5.Name = "sdLabel5";
			this.sdLabel5.Size = new System.Drawing.Size(240, 16);
			this.sdLabel5.TabIndex = 46;
			this.sdLabel5.Text = "The quick brown fox ate the lazy mouse";
			this.sdLabel5.WordSpace = 0F;
			// 
			// sdText40
			// 
			this.sdText40.CharSpace = 0F;
			this.sdText40.FontColor = System.Drawing.Color.Black;
			this.sdText40.FontName = Report.SdFontName.Arial;
			this.sdText40.FontSize = 9F;
			this.sdText40.Leading = 14F;
			this.sdText40.Lines = new string[] {
												   "AlignJustified"};
			this.sdText40.Location = new System.Drawing.Point(320, 480);
			this.sdText40.Name = "sdText40";
			this.sdText40.NodeValue = null;
			this.sdText40.Size = new System.Drawing.Size(157, 14);
			this.sdText40.TabIndex = 45;
			this.sdText40.WordSpace = 0F;
			// 
			// sdLabel4
			// 
			this.sdLabel4.Alignment = Report.SDAlignment.Center;
			this.sdLabel4.CharSpace = 0F;
			this.sdLabel4.FontBold = true;
			this.sdLabel4.FontColor = System.Drawing.Color.Green;
			this.sdLabel4.FontName = Report.SdFontName.TimesRoman;
			this.sdLabel4.FontSize = 12F;
			this.sdLabel4.Location = new System.Drawing.Point(320, 464);
			this.sdLabel4.Name = "sdLabel4";
			this.sdLabel4.Size = new System.Drawing.Size(240, 16);
			this.sdLabel4.TabIndex = 44;
			this.sdLabel4.Text = "The quick brown fox ate the lazy mouse";
			this.sdLabel4.WordSpace = 0F;
			// 
			// sdText39
			// 
			this.sdText39.CharSpace = 0F;
			this.sdText39.FontColor = System.Drawing.Color.Black;
			this.sdText39.FontName = Report.SdFontName.Arial;
			this.sdText39.FontSize = 9F;
			this.sdText39.Leading = 14F;
			this.sdText39.Lines = new string[] {
												   "Alignment Center"};
			this.sdText39.Location = new System.Drawing.Point(320, 448);
			this.sdText39.Name = "sdText39";
			this.sdText39.NodeValue = null;
			this.sdText39.Size = new System.Drawing.Size(157, 14);
			this.sdText39.TabIndex = 43;
			this.sdText39.WordSpace = 0F;
			// 
			// sdLabel3
			// 
			this.sdLabel3.Alignment = Report.SDAlignment.RightJustify;
			this.sdLabel3.CharSpace = 0F;
			this.sdLabel3.FontBold = true;
			this.sdLabel3.FontColor = System.Drawing.Color.Green;
			this.sdLabel3.FontName = Report.SdFontName.TimesRoman;
			this.sdLabel3.FontSize = 12F;
			this.sdLabel3.Location = new System.Drawing.Point(320, 432);
			this.sdLabel3.Name = "sdLabel3";
			this.sdLabel3.Size = new System.Drawing.Size(240, 16);
			this.sdLabel3.TabIndex = 42;
			this.sdLabel3.Text = "The quick brown fox ate the lazy mouse";
			this.sdLabel3.WordSpace = 0F;
			// 
			// sdText37
			// 
			this.sdText37.CharSpace = 0F;
			this.sdText37.FontColor = System.Drawing.Color.Black;
			this.sdText37.FontName = Report.SdFontName.Arial;
			this.sdText37.FontSize = 9F;
			this.sdText37.Leading = 14F;
			this.sdText37.Lines = new string[] {
												   "Alignment RightJustify"};
			this.sdText37.Location = new System.Drawing.Point(320, 416);
			this.sdText37.Name = "sdText37";
			this.sdText37.NodeValue = null;
			this.sdText37.Size = new System.Drawing.Size(157, 14);
			this.sdText37.TabIndex = 41;
			this.sdText37.WordSpace = 0F;
			// 
			// sdLabel2
			// 
			this.sdLabel2.CharSpace = 0F;
			this.sdLabel2.FontBold = true;
			this.sdLabel2.FontColor = System.Drawing.Color.Green;
			this.sdLabel2.FontName = Report.SdFontName.TimesRoman;
			this.sdLabel2.FontSize = 12F;
			this.sdLabel2.Location = new System.Drawing.Point(320, 400);
			this.sdLabel2.Name = "sdLabel2";
			this.sdLabel2.Size = new System.Drawing.Size(240, 16);
			this.sdLabel2.TabIndex = 40;
			this.sdLabel2.Text = "The quick brown fox ate the lazy mouse";
			this.sdLabel2.WordSpace = 0F;
			// 
			// sdText38
			// 
			this.sdText38.BackColor = System.Drawing.SystemColors.Window;
			this.sdText38.CharSpace = 0F;
			this.sdText38.FontColor = System.Drawing.Color.Black;
			this.sdText38.FontName = Report.SdFontName.Arial;
			this.sdText38.FontSize = 9F;
			this.sdText38.Leading = 14F;
			this.sdText38.Lines = new string[] {
												   "Alignment LeftJustify"};
			this.sdText38.Location = new System.Drawing.Point(320, 384);
			this.sdText38.Name = "sdText38";
			this.sdText38.NodeValue = null;
			this.sdText38.Size = new System.Drawing.Size(157, 14);
			this.sdText38.TabIndex = 39;
			this.sdText38.WordSpace = 0F;
			// 
			// sdText35
			// 
			this.sdText35.CharSpace = 0F;
			this.sdText35.FontColor = System.Drawing.Color.Blue;
			this.sdText35.FontName = Report.SdFontName.Arial;
			this.sdText35.FontSize = 18F;
			this.sdText35.Leading = 14F;
			this.sdText35.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText35.Location = new System.Drawing.Point(320, 344);
			this.sdText35.Name = "sdText35";
			this.sdText35.NodeValue = null;
			this.sdText35.Size = new System.Drawing.Size(216, 24);
			this.sdText35.TabIndex = 38;
			this.sdText35.WordSpace = 0F;
			// 
			// sdText36
			// 
			this.sdText36.CharSpace = 0F;
			this.sdText36.FontColor = System.Drawing.Color.Black;
			this.sdText36.FontName = Report.SdFontName.Arial;
			this.sdText36.FontSize = 9F;
			this.sdText36.Leading = 14F;
			this.sdText36.Lines = new string[] {
												   "FontColor Blue"};
			this.sdText36.Location = new System.Drawing.Point(320, 328);
			this.sdText36.Name = "sdText36";
			this.sdText36.NodeValue = null;
			this.sdText36.Size = new System.Drawing.Size(157, 14);
			this.sdText36.TabIndex = 37;
			this.sdText36.WordSpace = 0F;
			// 
			// sdText33
			// 
			this.sdText33.CharSpace = 0F;
			this.sdText33.FontColor = System.Drawing.Color.Red;
			this.sdText33.FontName = Report.SdFontName.Arial;
			this.sdText33.FontSize = 18F;
			this.sdText33.Leading = 14F;
			this.sdText33.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText33.Location = new System.Drawing.Point(320, 304);
			this.sdText33.Name = "sdText33";
			this.sdText33.NodeValue = null;
			this.sdText33.Size = new System.Drawing.Size(216, 24);
			this.sdText33.TabIndex = 36;
			this.sdText33.WordSpace = 0F;
			// 
			// sdText34
			// 
			this.sdText34.CharSpace = 0F;
			this.sdText34.FontColor = System.Drawing.Color.Black;
			this.sdText34.FontName = Report.SdFontName.Arial;
			this.sdText34.FontSize = 9F;
			this.sdText34.Leading = 14F;
			this.sdText34.Lines = new string[] {
												   "FontColor Red"};
			this.sdText34.Location = new System.Drawing.Point(320, 288);
			this.sdText34.Name = "sdText34";
			this.sdText34.NodeValue = null;
			this.sdText34.Size = new System.Drawing.Size(157, 14);
			this.sdText34.TabIndex = 35;
			this.sdText34.WordSpace = 0F;
			// 
			// sdText31
			// 
			this.sdText31.CharSpace = 0F;
			this.sdText31.FontColor = System.Drawing.Color.Black;
			this.sdText31.FontName = Report.SdFontName.Arial;
			this.sdText31.FontSize = 24F;
			this.sdText31.Leading = 14F;
			this.sdText31.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText31.Location = new System.Drawing.Point(320, 240);
			this.sdText31.Name = "sdText31";
			this.sdText31.NodeValue = null;
			this.sdText31.Size = new System.Drawing.Size(248, 32);
			this.sdText31.TabIndex = 34;
			this.sdText31.WordSpace = 0F;
			// 
			// sdText32
			// 
			this.sdText32.CharSpace = 0F;
			this.sdText32.FontColor = System.Drawing.Color.Black;
			this.sdText32.FontName = Report.SdFontName.Arial;
			this.sdText32.FontSize = 9F;
			this.sdText32.Leading = 14F;
			this.sdText32.Lines = new string[] {
												   "FontSize 24"};
			this.sdText32.Location = new System.Drawing.Point(320, 224);
			this.sdText32.Name = "sdText32";
			this.sdText32.NodeValue = null;
			this.sdText32.Size = new System.Drawing.Size(157, 14);
			this.sdText32.TabIndex = 33;
			this.sdText32.WordSpace = 0F;
			// 
			// sdText29
			// 
			this.sdText29.CharSpace = 0F;
			this.sdText29.FontColor = System.Drawing.Color.Black;
			this.sdText29.FontName = Report.SdFontName.Arial;
			this.sdText29.FontSize = 18F;
			this.sdText29.Leading = 14F;
			this.sdText29.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText29.Location = new System.Drawing.Point(320, 200);
			this.sdText29.Name = "sdText29";
			this.sdText29.NodeValue = null;
			this.sdText29.Size = new System.Drawing.Size(216, 24);
			this.sdText29.TabIndex = 32;
			this.sdText29.WordSpace = 0F;
			// 
			// sdText30
			// 
			this.sdText30.CharSpace = 0F;
			this.sdText30.FontColor = System.Drawing.Color.Black;
			this.sdText30.FontName = Report.SdFontName.Arial;
			this.sdText30.FontSize = 9F;
			this.sdText30.Leading = 14F;
			this.sdText30.Lines = new string[] {
												   "FontSize 18"};
			this.sdText30.Location = new System.Drawing.Point(320, 184);
			this.sdText30.Name = "sdText30";
			this.sdText30.NodeValue = null;
			this.sdText30.Size = new System.Drawing.Size(157, 14);
			this.sdText30.TabIndex = 31;
			this.sdText30.WordSpace = 0F;
			// 
			// sdText27
			// 
			this.sdText27.CharSpace = 0F;
			this.sdText27.FontColor = System.Drawing.Color.Black;
			this.sdText27.FontName = Report.SdFontName.Arial;
			this.sdText27.FontSize = 14F;
			this.sdText27.Leading = 14F;
			this.sdText27.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText27.Location = new System.Drawing.Point(320, 168);
			this.sdText27.Name = "sdText27";
			this.sdText27.NodeValue = null;
			this.sdText27.Size = new System.Drawing.Size(216, 16);
			this.sdText27.TabIndex = 30;
			this.sdText27.WordSpace = 0F;
			// 
			// sdText28
			// 
			this.sdText28.CharSpace = 0F;
			this.sdText28.FontColor = System.Drawing.Color.Black;
			this.sdText28.FontName = Report.SdFontName.Arial;
			this.sdText28.FontSize = 9F;
			this.sdText28.Leading = 14F;
			this.sdText28.Lines = new string[] {
												   "FontSize 14"};
			this.sdText28.Location = new System.Drawing.Point(320, 152);
			this.sdText28.Name = "sdText28";
			this.sdText28.NodeValue = null;
			this.sdText28.Size = new System.Drawing.Size(157, 14);
			this.sdText28.TabIndex = 29;
			this.sdText28.WordSpace = 0F;
			// 
			// sdText25
			// 
			this.sdText25.CharSpace = 0F;
			this.sdText25.FontColor = System.Drawing.Color.Black;
			this.sdText25.FontName = Report.SdFontName.Arial;
			this.sdText25.FontSize = 10F;
			this.sdText25.Leading = 14F;
			this.sdText25.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText25.Location = new System.Drawing.Point(320, 136);
			this.sdText25.Name = "sdText25";
			this.sdText25.NodeValue = null;
			this.sdText25.Size = new System.Drawing.Size(216, 16);
			this.sdText25.TabIndex = 28;
			this.sdText25.WordSpace = 0F;
			// 
			// sdText26
			// 
			this.sdText26.CharSpace = 0F;
			this.sdText26.FontColor = System.Drawing.Color.Black;
			this.sdText26.FontName = Report.SdFontName.Arial;
			this.sdText26.FontSize = 9F;
			this.sdText26.Leading = 14F;
			this.sdText26.Lines = new string[] {
												   "FontSize 10"};
			this.sdText26.Location = new System.Drawing.Point(320, 120);
			this.sdText26.Name = "sdText26";
			this.sdText26.NodeValue = null;
			this.sdText26.Size = new System.Drawing.Size(157, 14);
			this.sdText26.TabIndex = 27;
			this.sdText26.WordSpace = 0F;
			// 
			// sdText23
			// 
			this.sdText23.CharSpace = 0F;
			this.sdText23.FontColor = System.Drawing.Color.Black;
			this.sdText23.FontName = Report.SdFontName.Arial;
			this.sdText23.FontSize = 8F;
			this.sdText23.Leading = 14F;
			this.sdText23.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText23.Location = new System.Drawing.Point(320, 104);
			this.sdText23.Name = "sdText23";
			this.sdText23.NodeValue = null;
			this.sdText23.Size = new System.Drawing.Size(216, 16);
			this.sdText23.TabIndex = 26;
			this.sdText23.WordSpace = 0F;
			// 
			// sdText24
			// 
			this.sdText24.CharSpace = 0F;
			this.sdText24.FontColor = System.Drawing.Color.Black;
			this.sdText24.FontName = Report.SdFontName.Arial;
			this.sdText24.FontSize = 9F;
			this.sdText24.Leading = 14F;
			this.sdText24.Lines = new string[] {
												   "FontSize 8"};
			this.sdText24.Location = new System.Drawing.Point(320, 88);
			this.sdText24.Name = "sdText24";
			this.sdText24.NodeValue = null;
			this.sdText24.Size = new System.Drawing.Size(157, 14);
			this.sdText24.TabIndex = 25;
			this.sdText24.WordSpace = 0F;
			// 
			// sdRect2
			// 
			this.sdRect2.FillColor = System.Drawing.Color.Transparent;
			this.sdRect2.LineColor = System.Drawing.Color.Black;
			this.sdRect2.LineStyle = Report.PenStyle.Solid;
			this.sdRect2.LineWidth = 1F;
			this.sdRect2.Location = new System.Drawing.Point(296, 80);
			this.sdRect2.Name = "sdRect2";
			this.sdRect2.Size = new System.Drawing.Size(296, 441);
			this.sdRect2.TabIndex = 24;
			this.sdRect2.Text = "sdRect2";
			// 
			// sdText21
			// 
			this.sdText21.CharSpace = 0F;
			this.sdText21.FontBold = true;
			this.sdText21.FontColor = System.Drawing.Color.Black;
			this.sdText21.FontItalic = true;
			this.sdText21.FontName = Report.SdFontName.TimesRoman;
			this.sdText21.FontSize = 16F;
			this.sdText21.Leading = 14F;
			this.sdText21.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText21.Location = new System.Drawing.Point(24, 496);
			this.sdText21.Name = "sdText21";
			this.sdText21.NodeValue = null;
			this.sdText21.Size = new System.Drawing.Size(216, 21);
			this.sdText21.TabIndex = 23;
			this.sdText21.WordSpace = 0F;
			// 
			// sdText22
			// 
			this.sdText22.CharSpace = 0F;
			this.sdText22.FontColor = System.Drawing.Color.Black;
			this.sdText22.FontName = Report.SdFontName.Arial;
			this.sdText22.FontSize = 9F;
			this.sdText22.Leading = 14F;
			this.sdText22.Lines = new string[] {
												   "Times-BoldItalic"};
			this.sdText22.Location = new System.Drawing.Point(24, 480);
			this.sdText22.Name = "sdText22";
			this.sdText22.NodeValue = null;
			this.sdText22.Size = new System.Drawing.Size(157, 14);
			this.sdText22.TabIndex = 22;
			this.sdText22.WordSpace = 0F;
			// 
			// sdText19
			// 
			this.sdText19.CharSpace = 0F;
			this.sdText19.FontBold = true;
			this.sdText19.FontColor = System.Drawing.Color.Black;
			this.sdText19.FontItalic = true;
			this.sdText19.FontName = Report.SdFontName.Arial;
			this.sdText19.FontSize = 16F;
			this.sdText19.Leading = 14F;
			this.sdText19.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText19.Location = new System.Drawing.Point(24, 456);
			this.sdText19.Name = "sdText19";
			this.sdText19.NodeValue = null;
			this.sdText19.Size = new System.Drawing.Size(216, 21);
			this.sdText19.TabIndex = 21;
			this.sdText19.WordSpace = 0F;
			// 
			// sdText20
			// 
			this.sdText20.CharSpace = 0F;
			this.sdText20.FontColor = System.Drawing.Color.Black;
			this.sdText20.FontName = Report.SdFontName.Arial;
			this.sdText20.FontSize = 9F;
			this.sdText20.Leading = 14F;
			this.sdText20.Lines = new string[] {
												   "Arial-BoldItalic"};
			this.sdText20.Location = new System.Drawing.Point(24, 440);
			this.sdText20.Name = "sdText20";
			this.sdText20.NodeValue = null;
			this.sdText20.Size = new System.Drawing.Size(157, 14);
			this.sdText20.TabIndex = 20;
			this.sdText20.WordSpace = 0F;
			// 
			// sdText17
			// 
			this.sdText17.CharSpace = 0F;
			this.sdText17.FontColor = System.Drawing.Color.Black;
			this.sdText17.FontItalic = true;
			this.sdText17.FontName = Report.SdFontName.FixedWidth;
			this.sdText17.FontSize = 16F;
			this.sdText17.Leading = 14F;
			this.sdText17.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText17.Location = new System.Drawing.Point(24, 416);
			this.sdText17.Name = "sdText17";
			this.sdText17.NodeValue = null;
			this.sdText17.Size = new System.Drawing.Size(216, 21);
			this.sdText17.TabIndex = 19;
			this.sdText17.WordSpace = 0F;
			// 
			// sdText18
			// 
			this.sdText18.CharSpace = 0F;
			this.sdText18.FontColor = System.Drawing.Color.Black;
			this.sdText18.FontName = Report.SdFontName.Arial;
			this.sdText18.FontSize = 9F;
			this.sdText18.Leading = 14F;
			this.sdText18.Lines = new string[] {
												   "FixedWidth-Italic"};
			this.sdText18.Location = new System.Drawing.Point(24, 400);
			this.sdText18.Name = "sdText18";
			this.sdText18.NodeValue = null;
			this.sdText18.Size = new System.Drawing.Size(157, 14);
			this.sdText18.TabIndex = 18;
			this.sdText18.WordSpace = 0F;
			// 
			// sdText15
			// 
			this.sdText15.CharSpace = 0F;
			this.sdText15.FontColor = System.Drawing.Color.Black;
			this.sdText15.FontItalic = true;
			this.sdText15.FontName = Report.SdFontName.TimesRoman;
			this.sdText15.FontSize = 16F;
			this.sdText15.Leading = 14F;
			this.sdText15.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText15.Location = new System.Drawing.Point(24, 376);
			this.sdText15.Name = "sdText15";
			this.sdText15.NodeValue = null;
			this.sdText15.Size = new System.Drawing.Size(216, 21);
			this.sdText15.TabIndex = 17;
			this.sdText15.WordSpace = 0F;
			// 
			// sdText16
			// 
			this.sdText16.CharSpace = 0F;
			this.sdText16.FontColor = System.Drawing.Color.Black;
			this.sdText16.FontName = Report.SdFontName.Arial;
			this.sdText16.FontSize = 9F;
			this.sdText16.Leading = 14F;
			this.sdText16.Lines = new string[] {
												   "Times-Italic"};
			this.sdText16.Location = new System.Drawing.Point(24, 360);
			this.sdText16.Name = "sdText16";
			this.sdText16.NodeValue = null;
			this.sdText16.Size = new System.Drawing.Size(157, 14);
			this.sdText16.TabIndex = 16;
			this.sdText16.WordSpace = 0F;
			// 
			// sdText13
			// 
			this.sdText13.CharSpace = 0F;
			this.sdText13.FontColor = System.Drawing.Color.Black;
			this.sdText13.FontItalic = true;
			this.sdText13.FontName = Report.SdFontName.Arial;
			this.sdText13.FontSize = 16F;
			this.sdText13.Leading = 14F;
			this.sdText13.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText13.Location = new System.Drawing.Point(24, 336);
			this.sdText13.Name = "sdText13";
			this.sdText13.NodeValue = null;
			this.sdText13.Size = new System.Drawing.Size(216, 21);
			this.sdText13.TabIndex = 15;
			this.sdText13.WordSpace = 0F;
			// 
			// sdText14
			// 
			this.sdText14.CharSpace = 0F;
			this.sdText14.FontColor = System.Drawing.Color.Black;
			this.sdText14.FontName = Report.SdFontName.Arial;
			this.sdText14.FontSize = 9F;
			this.sdText14.Leading = 14F;
			this.sdText14.Lines = new string[] {
												   "Arial-Italic"};
			this.sdText14.Location = new System.Drawing.Point(24, 320);
			this.sdText14.Name = "sdText14";
			this.sdText14.NodeValue = null;
			this.sdText14.Size = new System.Drawing.Size(157, 14);
			this.sdText14.TabIndex = 14;
			this.sdText14.WordSpace = 0F;
			// 
			// sdText11
			// 
			this.sdText11.CharSpace = 0F;
			this.sdText11.FontBold = true;
			this.sdText11.FontColor = System.Drawing.Color.Black;
			this.sdText11.FontName = Report.SdFontName.FixedWidth;
			this.sdText11.FontSize = 16F;
			this.sdText11.Leading = 14F;
			this.sdText11.Lines = new string[] {
												   "ABCDEFGabcdefg12345"};
			this.sdText11.Location = new System.Drawing.Point(24, 296);
			this.sdText11.Name = "sdText11";
			this.sdText11.NodeValue = null;
			this.sdText11.Size = new System.Drawing.Size(216, 21);
			this.sdText11.TabIndex = 13;
			this.sdText11.WordSpace = 0F;
			// 
			// sdText12
			// 
			this.sdText12.CharSpace = 0F;
			this.sdText12.FontColor = System.Drawing.Color.Black;
			this.sdText12.FontName = Report.SdFontName.Arial;
			this.sdText12.FontSize = 9F;
			this.sdText12.Leading = 14F;
			this.sdText12.Lines = new string[] {
												   "FixedWidth-Bold"};
			this.sdText12.Location = new System.Drawing.Point(24, 280);
			this.sdText12.Name = "sdText12";
			this.sdText12.NodeValue = null;
			this.sdText12.Size = new System.Drawing.Size(157, 14);
			this.sdText12.TabIndex = 12;
			this.sdText12.WordSpace = 0F;
			// 
			// sdText9
			// 
			this.sdText9.CharSpace = 0F;
			this.sdText9.FontBold = true;
			this.sdText9.FontColor = System.Drawing.Color.Black;
			this.sdText9.FontName = Report.SdFontName.TimesRoman;
			this.sdText9.FontSize = 16F;
			this.sdText9.Leading = 14F;
			this.sdText9.Lines = new string[] {
												  "ABCDEFGabcdefg12345"};
			this.sdText9.Location = new System.Drawing.Point(24, 256);
			this.sdText9.Name = "sdText9";
			this.sdText9.NodeValue = null;
			this.sdText9.Size = new System.Drawing.Size(216, 21);
			this.sdText9.TabIndex = 11;
			this.sdText9.WordSpace = 0F;
			// 
			// sdText10
			// 
			this.sdText10.CharSpace = 0F;
			this.sdText10.FontColor = System.Drawing.Color.Black;
			this.sdText10.FontName = Report.SdFontName.Arial;
			this.sdText10.FontSize = 9F;
			this.sdText10.Leading = 14F;
			this.sdText10.Lines = new string[] {
												   "Times-Bold"};
			this.sdText10.Location = new System.Drawing.Point(24, 240);
			this.sdText10.Name = "sdText10";
			this.sdText10.NodeValue = null;
			this.sdText10.Size = new System.Drawing.Size(157, 14);
			this.sdText10.TabIndex = 10;
			this.sdText10.WordSpace = 0F;
			// 
			// sdText8
			// 
			this.sdText8.CharSpace = 0F;
			this.sdText8.FontBold = true;
			this.sdText8.FontColor = System.Drawing.Color.Black;
			this.sdText8.FontName = Report.SdFontName.Arial;
			this.sdText8.FontSize = 16F;
			this.sdText8.Leading = 14F;
			this.sdText8.Lines = new string[] {
												  "ABCDEFGabcdefg12345"};
			this.sdText8.Location = new System.Drawing.Point(24, 216);
			this.sdText8.Name = "sdText8";
			this.sdText8.NodeValue = null;
			this.sdText8.Size = new System.Drawing.Size(216, 21);
			this.sdText8.TabIndex = 9;
			this.sdText8.WordSpace = 0F;
			// 
			// sdText7
			// 
			this.sdText7.CharSpace = 0F;
			this.sdText7.FontColor = System.Drawing.Color.Black;
			this.sdText7.FontName = Report.SdFontName.Arial;
			this.sdText7.FontSize = 9F;
			this.sdText7.Leading = 14F;
			this.sdText7.Lines = new string[] {
												  "Arial-Bold"};
			this.sdText7.Location = new System.Drawing.Point(24, 200);
			this.sdText7.Name = "sdText7";
			this.sdText7.NodeValue = null;
			this.sdText7.Size = new System.Drawing.Size(157, 14);
			this.sdText7.TabIndex = 8;
			this.sdText7.WordSpace = 0F;
			// 
			// sdText6
			// 
			this.sdText6.CharSpace = 0F;
			this.sdText6.FontColor = System.Drawing.Color.Black;
			this.sdText6.FontName = Report.SdFontName.FixedWidth;
			this.sdText6.FontSize = 16F;
			this.sdText6.Leading = 14F;
			this.sdText6.Lines = new string[] {
												  "ABCDEFGabcdefg12345"};
			this.sdText6.Location = new System.Drawing.Point(24, 176);
			this.sdText6.Name = "sdText6";
			this.sdText6.NodeValue = null;
			this.sdText6.Size = new System.Drawing.Size(216, 21);
			this.sdText6.TabIndex = 7;
			this.sdText6.WordSpace = 0F;
			// 
			// sdText5
			// 
			this.sdText5.CharSpace = 0F;
			this.sdText5.FontColor = System.Drawing.Color.Black;
			this.sdText5.FontName = Report.SdFontName.Arial;
			this.sdText5.FontSize = 9F;
			this.sdText5.Leading = 14F;
			this.sdText5.Lines = new string[] {
												  "FixedWidth"};
			this.sdText5.Location = new System.Drawing.Point(24, 160);
			this.sdText5.Name = "sdText5";
			this.sdText5.NodeValue = null;
			this.sdText5.Size = new System.Drawing.Size(157, 14);
			this.sdText5.TabIndex = 6;
			this.sdText5.WordSpace = 0F;
			// 
			// sdText4
			// 
			this.sdText4.CharSpace = 0F;
			this.sdText4.FontColor = System.Drawing.Color.Black;
			this.sdText4.FontName = Report.SdFontName.TimesRoman;
			this.sdText4.FontSize = 16F;
			this.sdText4.Leading = 14F;
			this.sdText4.Lines = new string[] {
												  "ABCDEFGabcdefg12345"};
			this.sdText4.Location = new System.Drawing.Point(24, 136);
			this.sdText4.Name = "sdText4";
			this.sdText4.NodeValue = null;
			this.sdText4.Size = new System.Drawing.Size(216, 21);
			this.sdText4.TabIndex = 5;
			this.sdText4.WordSpace = 0F;
			// 
			// sdText3
			// 
			this.sdText3.CharSpace = 0F;
			this.sdText3.FontColor = System.Drawing.Color.Black;
			this.sdText3.FontName = Report.SdFontName.Arial;
			this.sdText3.FontSize = 9F;
			this.sdText3.Leading = 14F;
			this.sdText3.Lines = new string[] {
												  "TimesRoman"};
			this.sdText3.Location = new System.Drawing.Point(24, 120);
			this.sdText3.Name = "sdText3";
			this.sdText3.NodeValue = null;
			this.sdText3.Size = new System.Drawing.Size(157, 14);
			this.sdText3.TabIndex = 4;
			this.sdText3.WordSpace = 0F;
			// 
			// sdText2
			// 
			this.sdText2.CharSpace = 0F;
			this.sdText2.FontColor = System.Drawing.Color.Black;
			this.sdText2.FontName = Report.SdFontName.Arial;
			this.sdText2.FontSize = 16F;
			this.sdText2.Leading = 14F;
			this.sdText2.Lines = new string[] {
												  "ABCDEFGabcdefg12345"};
			this.sdText2.Location = new System.Drawing.Point(24, 104);
			this.sdText2.Name = "sdText2";
			this.sdText2.NodeValue = null;
			this.sdText2.Size = new System.Drawing.Size(216, 21);
			this.sdText2.TabIndex = 3;
			this.sdText2.WordSpace = 0F;
			// 
			// sdText1
			// 
			this.sdText1.CharSpace = 0F;
			this.sdText1.FontColor = System.Drawing.Color.Black;
			this.sdText1.FontName = Report.SdFontName.Arial;
			this.sdText1.FontSize = 9F;
			this.sdText1.Leading = 14F;
			this.sdText1.Lines = new string[] {
												  "Arial"};
			this.sdText1.Location = new System.Drawing.Point(24, 88);
			this.sdText1.Name = "sdText1";
			this.sdText1.NodeValue = null;
			this.sdText1.Size = new System.Drawing.Size(157, 14);
			this.sdText1.TabIndex = 2;
			this.sdText1.WordSpace = 0F;
			// 
			// sdRect1
			// 
			this.sdRect1.FillColor = System.Drawing.Color.Transparent;
			this.sdRect1.LineColor = System.Drawing.Color.Black;
			this.sdRect1.LineStyle = Report.PenStyle.Solid;
			this.sdRect1.LineWidth = 1F;
			this.sdRect1.Location = new System.Drawing.Point(8, 80);
			this.sdRect1.Name = "sdRect1";
			this.sdRect1.Size = new System.Drawing.Size(272, 441);
			this.sdRect1.TabIndex = 1;
			this.sdRect1.Text = "sdRect1";
			// 
			// sdLabel1
			// 
			this.sdLabel1.Alignment = Report.SDAlignment.Center;
			this.sdLabel1.CharSpace = 0F;
			this.sdLabel1.FontBold = true;
			this.sdLabel1.FontColor = System.Drawing.Color.Black;
			this.sdLabel1.FontName = Report.SdFontName.Arial;
			this.sdLabel1.FontSize = 24F;
			this.sdLabel1.Location = new System.Drawing.Point(32, 40);
			this.sdLabel1.Name = "sdLabel1";
			this.sdLabel1.Size = new System.Drawing.Size(560, 30);
			this.sdLabel1.TabIndex = 0;
			this.sdLabel1.Text = "PdfCreator Font Example";
			this.sdLabel1.WordSpace = 0F;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(647, 633);
			this.Controls.Add(this.sdPage1);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FontExample";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.sdPage1.ResumeLayout(false);
			this.sdLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			if(saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				sdReport1.FileName=saveFileDialog1.FileName;
				sdReport1.BeginDoc();
				sdReport1.Print(sdPage1);
				sdReport1.EndDoc();
			}
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}

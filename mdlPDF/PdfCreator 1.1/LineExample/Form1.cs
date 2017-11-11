using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace LineExample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Report.SDReport sdReport1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private Report.SDPage sdPage1;
		private System.Windows.Forms.MenuItem menuItem1;
		private Report.SDLayoutPanel sdLayoutPanel1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private Report.SDText sdText1;
		private Report.SDText sdText2;
		private Report.SDRect sdRect1;
		private Report.SDRect sdRect2;
		private Report.SDText sdText3;
		private Report.SDRect sdRect3;
		private Report.SDText sdText4;
		private Report.SDRect sdRect4;
		private Report.SDText sdText5;
		private Report.SDRect sdRect5;
		private Report.SDText sdText6;
		private Report.SDRect sdRect6;
		private Report.SDText sdText7;
		private Report.SDRect sdRect7;
		private Report.SDText sdText8;
		private Report.SDRect sdRect8;
		private Report.SDText sdText9;
		private Report.SDRect sdRect9;
		private Report.SDText sdText10;
		private Report.SDRect sdRect10;
		private Report.SDText sdText11;
		private Report.SDRect sdRect11;
		private Report.SDText sdText12;
		private Report.SDRect sdRect12;
		private Report.SDText sdText13;
		private Report.SDRect sdRect13;
		private Report.SDText sdText14;
		private Report.SDRect sdRect14;
		private Report.SDText sdText15;
		private Report.SDRect sdRect15;
		private Report.SDText sdText16;
		private Report.SDRect sdRect16;
		private Report.SDText sdText17;
		private Report.SDRect sdRect17;
		private Report.SDText sdText18;
		private Report.SDRect sdRect18;
		private Report.SDText sdText19;
		private Report.SDRect sdRect19;
		private Report.SDText sdText20;
		private Report.SDRect sdRect20;
		private Report.SDText sdText21;
		private Report.SDRect sdRect21;
		private Report.SDText sdText22;
		private Report.SDText sdText23;
		private Report.SDRect sdRect22;
		private Report.SDText sdText24;
		private Report.SDRect sdRect23;
		private Report.SDText sdText25;
		private Report.SDRect sdRect24;
		private Report.SDText sdText26;
		private Report.SDRect sdRect25;
		private Report.SDText sdText27;
		private Report.SDRect sdRect26;
		private Report.SDText sdText28;
		private Report.SDRect sdRect27;
		private Report.SDText sdText29;
		private Report.SDRect sdRect28;
		private Report.SDText sdText30;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
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
			this.sdPage1 = new Report.SDPage();
			this.sdLayoutPanel1 = new Report.SDLayoutPanel();
			this.sdText30 = new Report.SDText();
			this.sdText29 = new Report.SDText();
			this.sdRect28 = new Report.SDRect();
			this.sdText28 = new Report.SDText();
			this.sdRect27 = new Report.SDRect();
			this.sdText27 = new Report.SDText();
			this.sdRect26 = new Report.SDRect();
			this.sdText26 = new Report.SDText();
			this.sdRect25 = new Report.SDRect();
			this.sdText25 = new Report.SDText();
			this.sdRect24 = new Report.SDRect();
			this.sdText24 = new Report.SDText();
			this.sdRect23 = new Report.SDRect();
			this.sdText23 = new Report.SDText();
			this.sdRect22 = new Report.SDRect();
			this.sdText22 = new Report.SDText();
			this.sdRect21 = new Report.SDRect();
			this.sdRect16 = new Report.SDRect();
			this.sdText17 = new Report.SDText();
			this.sdRect17 = new Report.SDRect();
			this.sdText18 = new Report.SDText();
			this.sdRect18 = new Report.SDRect();
			this.sdText19 = new Report.SDText();
			this.sdRect19 = new Report.SDRect();
			this.sdText20 = new Report.SDText();
			this.sdRect20 = new Report.SDRect();
			this.sdText21 = new Report.SDText();
			this.sdRect11 = new Report.SDRect();
			this.sdText12 = new Report.SDText();
			this.sdRect12 = new Report.SDRect();
			this.sdText13 = new Report.SDText();
			this.sdRect13 = new Report.SDRect();
			this.sdText14 = new Report.SDText();
			this.sdRect14 = new Report.SDRect();
			this.sdText15 = new Report.SDText();
			this.sdRect15 = new Report.SDRect();
			this.sdText16 = new Report.SDText();
			this.sdRect10 = new Report.SDRect();
			this.sdText11 = new Report.SDText();
			this.sdRect9 = new Report.SDRect();
			this.sdText10 = new Report.SDText();
			this.sdRect8 = new Report.SDRect();
			this.sdText9 = new Report.SDText();
			this.sdRect7 = new Report.SDRect();
			this.sdText8 = new Report.SDText();
			this.sdRect6 = new Report.SDRect();
			this.sdText7 = new Report.SDText();
			this.sdRect5 = new Report.SDRect();
			this.sdText6 = new Report.SDText();
			this.sdRect4 = new Report.SDRect();
			this.sdText5 = new Report.SDText();
			this.sdRect3 = new Report.SDRect();
			this.sdText4 = new Report.SDText();
			this.sdRect2 = new Report.SDRect();
			this.sdText3 = new Report.SDText();
			this.sdRect1 = new Report.SDRect();
			this.sdText2 = new Report.SDText();
			this.sdText1 = new Report.SDText();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.sdPage1.SuspendLayout();
			this.sdLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// sdReport1
			// 
			this.sdReport1.Author = null;
			this.sdReport1.CreationDate = new System.DateTime(2002, 12, 26, 1, 33, 10, 383);
			this.sdReport1.Creator = null;
			this.sdReport1.FileName = "default.pdf";
			this.sdReport1.Keywords = null;
			this.sdReport1.ModDate = new System.DateTime(((long)(0)));
			this.sdReport1.Subject = null;
			this.sdReport1.Title = "PdfCreator Line Demo";
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
			// sdPage1
			// 
			this.sdPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.sdLayoutPanel1});
			this.sdPage1.DockPadding.All = 32;
			this.sdPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage1.Location = new System.Drawing.Point(11, 14);
			this.sdPage1.Name = "sdPage1";
			this.sdPage1.Size = new System.Drawing.Size(600, 700);
			this.sdPage1.TabIndex = 0;
			this.sdPage1.Text = "sdPage1";
			// 
			// sdLayoutPanel1
			// 
			this.sdLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.sdText30,
																						 this.sdText29,
																						 this.sdRect28,
																						 this.sdText28,
																						 this.sdRect27,
																						 this.sdText27,
																						 this.sdRect26,
																						 this.sdText26,
																						 this.sdRect25,
																						 this.sdText25,
																						 this.sdRect24,
																						 this.sdText24,
																						 this.sdRect23,
																						 this.sdText23,
																						 this.sdRect22,
																						 this.sdText22,
																						 this.sdRect21,
																						 this.sdRect16,
																						 this.sdText17,
																						 this.sdRect17,
																						 this.sdText18,
																						 this.sdRect18,
																						 this.sdText19,
																						 this.sdRect19,
																						 this.sdText20,
																						 this.sdRect20,
																						 this.sdText21,
																						 this.sdRect11,
																						 this.sdText12,
																						 this.sdRect12,
																						 this.sdText13,
																						 this.sdRect13,
																						 this.sdText14,
																						 this.sdRect14,
																						 this.sdText15,
																						 this.sdRect15,
																						 this.sdText16,
																						 this.sdRect10,
																						 this.sdText11,
																						 this.sdRect9,
																						 this.sdText10,
																						 this.sdRect8,
																						 this.sdText9,
																						 this.sdRect7,
																						 this.sdText8,
																						 this.sdRect6,
																						 this.sdText7,
																						 this.sdRect5,
																						 this.sdText6,
																						 this.sdRect4,
																						 this.sdText5,
																						 this.sdRect3,
																						 this.sdText4,
																						 this.sdRect2,
																						 this.sdText3,
																						 this.sdRect1,
																						 this.sdText2,
																						 this.sdText1});
			this.sdLayoutPanel1.Location = new System.Drawing.Point(33, 33);
			this.sdLayoutPanel1.Name = "sdLayoutPanel1";
			this.sdLayoutPanel1.Size = new System.Drawing.Size(534, 634);
			this.sdLayoutPanel1.TabIndex = 0;
			this.sdLayoutPanel1.Text = "sdLayoutPanel1";
			// 
			// sdText30
			// 
			this.sdText30.CharSpace = 0F;
			this.sdText30.FontColor = System.Drawing.Color.Black;
			this.sdText30.FontName = Report.SdFontName.Arial;
			this.sdText30.FontSize = 9F;
			this.sdText30.Leading = 14F;
			this.sdText30.Lines = new string[] {
												   "copyright (c) 2002 Serdar Dirican"};
			this.sdText30.Location = new System.Drawing.Point(344, 608);
			this.sdText30.Name = "sdText30";
			this.sdText30.Size = new System.Drawing.Size(144, 16);
			this.sdText30.TabIndex = 57;
			this.sdText30.WordSpace = 0F;
			// 
			// sdText29
			// 
			this.sdText29.CharSpace = 0F;
			this.sdText29.FontColor = System.Drawing.Color.Black;
			this.sdText29.FontName = Report.SdFontName.Arial;
			this.sdText29.FontSize = 9F;
			this.sdText29.Leading = 12F;
			this.sdText29.Lines = new string[] {
												   "LineWidth 3, LineStyle Solid",
												   "LineColor Purple, FillColor Aqua"};
			this.sdText29.Location = new System.Drawing.Point(296, 536);
			this.sdText29.Name = "sdText29";
			this.sdText29.Size = new System.Drawing.Size(188, 25);
			this.sdText29.TabIndex = 56;
			this.sdText29.WordSpace = 0F;
			// 
			// sdRect28
			// 
			this.sdRect28.FillColor = System.Drawing.Color.Aqua;
			this.sdRect28.LineColor = System.Drawing.Color.Purple;
			this.sdRect28.LineStyle = Report.PenStyle.Solid;
			this.sdRect28.LineWidth = 3F;
			this.sdRect28.Location = new System.Drawing.Point(288, 528);
			this.sdRect28.Name = "sdRect28";
			this.sdRect28.Size = new System.Drawing.Size(210, 40);
			this.sdRect28.TabIndex = 55;
			this.sdRect28.Text = "sdRect28";
			// 
			// sdText28
			// 
			this.sdText28.CharSpace = 0F;
			this.sdText28.FontColor = System.Drawing.Color.Black;
			this.sdText28.FontName = Report.SdFontName.Arial;
			this.sdText28.FontSize = 9F;
			this.sdText28.Leading = 12F;
			this.sdText28.Lines = new string[] {
												   "LineWidth 2, LineStyle Dot",
												   "LineColor Blue, FillColor Lime"};
			this.sdText28.Location = new System.Drawing.Point(296, 488);
			this.sdText28.Name = "sdText28";
			this.sdText28.Size = new System.Drawing.Size(188, 25);
			this.sdText28.TabIndex = 54;
			this.sdText28.WordSpace = 0F;
			// 
			// sdRect27
			// 
			this.sdRect27.FillColor = System.Drawing.Color.Lime;
			this.sdRect27.LineColor = System.Drawing.Color.Blue;
			this.sdRect27.LineStyle = Report.PenStyle.Dot;
			this.sdRect27.LineWidth = 2F;
			this.sdRect27.Location = new System.Drawing.Point(288, 480);
			this.sdRect27.Name = "sdRect27";
			this.sdRect27.Size = new System.Drawing.Size(210, 40);
			this.sdRect27.TabIndex = 53;
			this.sdRect27.Text = "sdRect27";
			// 
			// sdText27
			// 
			this.sdText27.CharSpace = 0F;
			this.sdText27.FontColor = System.Drawing.Color.Black;
			this.sdText27.FontName = Report.SdFontName.Arial;
			this.sdText27.FontSize = 9F;
			this.sdText27.Leading = 12F;
			this.sdText27.Lines = new string[] {
												   "LineWidth 1, LineStyle Solid",
												   "LineColor Transparent, FillColor Aqua"};
			this.sdText27.Location = new System.Drawing.Point(296, 440);
			this.sdText27.Name = "sdText27";
			this.sdText27.Size = new System.Drawing.Size(188, 25);
			this.sdText27.TabIndex = 52;
			this.sdText27.WordSpace = 0F;
			// 
			// sdRect26
			// 
			this.sdRect26.FillColor = System.Drawing.Color.Aqua;
			this.sdRect26.LineColor = System.Drawing.Color.Transparent;
			this.sdRect26.LineStyle = Report.PenStyle.Solid;
			this.sdRect26.LineWidth = 1F;
			this.sdRect26.Location = new System.Drawing.Point(288, 432);
			this.sdRect26.Name = "sdRect26";
			this.sdRect26.Size = new System.Drawing.Size(210, 40);
			this.sdRect26.TabIndex = 51;
			this.sdRect26.Text = "sdRect26";
			// 
			// sdText26
			// 
			this.sdText26.CharSpace = 0F;
			this.sdText26.FontColor = System.Drawing.Color.Black;
			this.sdText26.FontName = Report.SdFontName.Arial;
			this.sdText26.FontSize = 9F;
			this.sdText26.Leading = 12F;
			this.sdText26.Lines = new string[] {
												   "LineWidth 1, LineStyle Dot",
												   "LineColor Black, FillColor Lime"};
			this.sdText26.Location = new System.Drawing.Point(296, 392);
			this.sdText26.Name = "sdText26";
			this.sdText26.Size = new System.Drawing.Size(188, 25);
			this.sdText26.TabIndex = 50;
			this.sdText26.WordSpace = 0F;
			// 
			// sdRect25
			// 
			this.sdRect25.FillColor = System.Drawing.Color.Lime;
			this.sdRect25.LineColor = System.Drawing.Color.Black;
			this.sdRect25.LineStyle = Report.PenStyle.Dot;
			this.sdRect25.LineWidth = 1F;
			this.sdRect25.Location = new System.Drawing.Point(288, 384);
			this.sdRect25.Name = "sdRect25";
			this.sdRect25.Size = new System.Drawing.Size(210, 40);
			this.sdRect25.TabIndex = 49;
			this.sdRect25.Text = "sdRect25";
			// 
			// sdText25
			// 
			this.sdText25.CharSpace = 0F;
			this.sdText25.FontColor = System.Drawing.Color.Black;
			this.sdText25.FontName = Report.SdFontName.Arial;
			this.sdText25.FontSize = 9F;
			this.sdText25.Leading = 12F;
			this.sdText25.Lines = new string[] {
												   "LineWidth 2, LineStyle DashDot",
												   "LineColor Red, FillColor Yellow"};
			this.sdText25.Location = new System.Drawing.Point(40, 536);
			this.sdText25.Name = "sdText25";
			this.sdText25.Size = new System.Drawing.Size(188, 25);
			this.sdText25.TabIndex = 48;
			this.sdText25.WordSpace = 0F;
			// 
			// sdRect24
			// 
			this.sdRect24.FillColor = System.Drawing.Color.Yellow;
			this.sdRect24.LineColor = System.Drawing.Color.Red;
			this.sdRect24.LineStyle = Report.PenStyle.DashDot;
			this.sdRect24.LineWidth = 2F;
			this.sdRect24.Location = new System.Drawing.Point(32, 528);
			this.sdRect24.Name = "sdRect24";
			this.sdRect24.Size = new System.Drawing.Size(210, 40);
			this.sdRect24.TabIndex = 47;
			this.sdRect24.Text = "sdRect24";
			// 
			// sdText24
			// 
			this.sdText24.CharSpace = 0F;
			this.sdText24.FontColor = System.Drawing.Color.Black;
			this.sdText24.FontName = Report.SdFontName.Arial;
			this.sdText24.FontSize = 9F;
			this.sdText24.Leading = 12F;
			this.sdText24.Lines = new string[] {
												   "LineWidth 2, LineStyle Solid",
												   "LineColor Navy, FillColor Transparent"};
			this.sdText24.Location = new System.Drawing.Point(40, 488);
			this.sdText24.Name = "sdText24";
			this.sdText24.Size = new System.Drawing.Size(188, 25);
			this.sdText24.TabIndex = 46;
			this.sdText24.WordSpace = 0F;
			// 
			// sdRect23
			// 
			this.sdRect23.FillColor = System.Drawing.Color.Transparent;
			this.sdRect23.LineColor = System.Drawing.Color.Navy;
			this.sdRect23.LineStyle = Report.PenStyle.Solid;
			this.sdRect23.LineWidth = 2F;
			this.sdRect23.Location = new System.Drawing.Point(32, 480);
			this.sdRect23.Name = "sdRect23";
			this.sdRect23.Size = new System.Drawing.Size(210, 40);
			this.sdRect23.TabIndex = 45;
			this.sdRect23.Text = "sdRect23";
			// 
			// sdText23
			// 
			this.sdText23.CharSpace = 0F;
			this.sdText23.FontColor = System.Drawing.Color.Black;
			this.sdText23.FontName = Report.SdFontName.Arial;
			this.sdText23.FontSize = 9F;
			this.sdText23.Leading = 12F;
			this.sdText23.Lines = new string[] {
												   "LineWidth 1, LineStyle Solid",
												   "LineColor Navy, FillColor Yellow"};
			this.sdText23.Location = new System.Drawing.Point(40, 440);
			this.sdText23.Name = "sdText23";
			this.sdText23.Size = new System.Drawing.Size(188, 25);
			this.sdText23.TabIndex = 44;
			this.sdText23.WordSpace = 0F;
			// 
			// sdRect22
			// 
			this.sdRect22.FillColor = System.Drawing.Color.Yellow;
			this.sdRect22.LineColor = System.Drawing.Color.Navy;
			this.sdRect22.LineStyle = Report.PenStyle.Solid;
			this.sdRect22.LineWidth = 1F;
			this.sdRect22.Location = new System.Drawing.Point(32, 432);
			this.sdRect22.Name = "sdRect22";
			this.sdRect22.Size = new System.Drawing.Size(210, 40);
			this.sdRect22.TabIndex = 43;
			this.sdRect22.Text = "sdRect22";
			// 
			// sdText22
			// 
			this.sdText22.BackColor = System.Drawing.SystemColors.Window;
			this.sdText22.CharSpace = 0F;
			this.sdText22.FontColor = System.Drawing.Color.Black;
			this.sdText22.FontName = Report.SdFontName.Arial;
			this.sdText22.FontSize = 9F;
			this.sdText22.Leading = 12F;
			this.sdText22.Lines = new string[] {
												   "LineWidth 1, LineStyle Solid",
												   "LineColor Black, FillColor Transparent"};
			this.sdText22.Location = new System.Drawing.Point(40, 392);
			this.sdText22.Name = "sdText22";
			this.sdText22.Size = new System.Drawing.Size(188, 25);
			this.sdText22.TabIndex = 42;
			this.sdText22.WordSpace = 0F;
			// 
			// sdRect21
			// 
			this.sdRect21.FillColor = System.Drawing.Color.Transparent;
			this.sdRect21.LineColor = System.Drawing.Color.Black;
			this.sdRect21.LineStyle = Report.PenStyle.Solid;
			this.sdRect21.LineWidth = 1F;
			this.sdRect21.Location = new System.Drawing.Point(32, 384);
			this.sdRect21.Name = "sdRect21";
			this.sdRect21.Size = new System.Drawing.Size(210, 40);
			this.sdRect21.TabIndex = 41;
			this.sdRect21.Text = "sdRect21";
			// 
			// sdRect16
			// 
			this.sdRect16.DrawLine = true;
			this.sdRect16.FillColor = System.Drawing.Color.Transparent;
			this.sdRect16.LineColor = System.Drawing.Color.Blue;
			this.sdRect16.LineStyle = Report.PenStyle.Dot;
			this.sdRect16.LineWidth = 4F;
			this.sdRect16.Location = new System.Drawing.Point(288, 360);
			this.sdRect16.Name = "sdRect16";
			this.sdRect16.Size = new System.Drawing.Size(210, 5);
			this.sdRect16.TabIndex = 40;
			this.sdRect16.Text = "sdRect16";
			// 
			// sdText17
			// 
			this.sdText17.CharSpace = 0F;
			this.sdText17.FontColor = System.Drawing.Color.Black;
			this.sdText17.FontName = Report.SdFontName.Arial;
			this.sdText17.FontSize = 9F;
			this.sdText17.Leading = 14F;
			this.sdText17.Lines = new string[] {
												   "LineWidth 4, LineStyle Dot, LineColor Blue"};
			this.sdText17.Location = new System.Drawing.Point(288, 344);
			this.sdText17.Name = "sdText17";
			this.sdText17.Size = new System.Drawing.Size(208, 14);
			this.sdText17.TabIndex = 39;
			this.sdText17.WordSpace = 0F;
			// 
			// sdRect17
			// 
			this.sdRect17.DrawLine = true;
			this.sdRect17.FillColor = System.Drawing.Color.Transparent;
			this.sdRect17.LineColor = System.Drawing.Color.Blue;
			this.sdRect17.LineStyle = Report.PenStyle.DashDotDot;
			this.sdRect17.LineWidth = 4F;
			this.sdRect17.Location = new System.Drawing.Point(288, 328);
			this.sdRect17.Name = "sdRect17";
			this.sdRect17.Size = new System.Drawing.Size(210, 5);
			this.sdRect17.TabIndex = 38;
			this.sdRect17.Text = "sdRect17";
			// 
			// sdText18
			// 
			this.sdText18.CharSpace = 0F;
			this.sdText18.FontColor = System.Drawing.Color.Black;
			this.sdText18.FontName = Report.SdFontName.Arial;
			this.sdText18.FontSize = 9F;
			this.sdText18.Leading = 14F;
			this.sdText18.Lines = new string[] {
												   "LineWidth 4, LineStyle DashDotDot, LineColor Blue"};
			this.sdText18.Location = new System.Drawing.Point(288, 312);
			this.sdText18.Name = "sdText18";
			this.sdText18.Size = new System.Drawing.Size(208, 14);
			this.sdText18.TabIndex = 37;
			this.sdText18.WordSpace = 0F;
			// 
			// sdRect18
			// 
			this.sdRect18.DrawLine = true;
			this.sdRect18.FillColor = System.Drawing.Color.Transparent;
			this.sdRect18.LineColor = System.Drawing.Color.Blue;
			this.sdRect18.LineStyle = Report.PenStyle.DashDot;
			this.sdRect18.LineWidth = 4F;
			this.sdRect18.Location = new System.Drawing.Point(288, 296);
			this.sdRect18.Name = "sdRect18";
			this.sdRect18.Size = new System.Drawing.Size(210, 5);
			this.sdRect18.TabIndex = 36;
			this.sdRect18.Text = "sdRect18";
			// 
			// sdText19
			// 
			this.sdText19.CharSpace = 0F;
			this.sdText19.FontColor = System.Drawing.Color.Black;
			this.sdText19.FontName = Report.SdFontName.Arial;
			this.sdText19.FontSize = 9F;
			this.sdText19.Leading = 14F;
			this.sdText19.Lines = new string[] {
												   "LineWidth 4, LineStyle DashDot, LineColor Blue"};
			this.sdText19.Location = new System.Drawing.Point(288, 280);
			this.sdText19.Name = "sdText19";
			this.sdText19.Size = new System.Drawing.Size(208, 14);
			this.sdText19.TabIndex = 35;
			this.sdText19.WordSpace = 0F;
			// 
			// sdRect19
			// 
			this.sdRect19.DrawLine = true;
			this.sdRect19.FillColor = System.Drawing.Color.Transparent;
			this.sdRect19.LineColor = System.Drawing.Color.Blue;
			this.sdRect19.LineStyle = Report.PenStyle.Dash;
			this.sdRect19.LineWidth = 4F;
			this.sdRect19.Location = new System.Drawing.Point(288, 264);
			this.sdRect19.Name = "sdRect19";
			this.sdRect19.Size = new System.Drawing.Size(210, 5);
			this.sdRect19.TabIndex = 34;
			this.sdRect19.Text = "sdRect19";
			// 
			// sdText20
			// 
			this.sdText20.CharSpace = 0F;
			this.sdText20.FontColor = System.Drawing.Color.Black;
			this.sdText20.FontName = Report.SdFontName.Arial;
			this.sdText20.FontSize = 9F;
			this.sdText20.Leading = 14F;
			this.sdText20.Lines = new string[] {
												   "LineWidth 4, LineStyle Dash, LineColor Blue"};
			this.sdText20.Location = new System.Drawing.Point(288, 248);
			this.sdText20.Name = "sdText20";
			this.sdText20.Size = new System.Drawing.Size(208, 14);
			this.sdText20.TabIndex = 33;
			this.sdText20.WordSpace = 0F;
			// 
			// sdRect20
			// 
			this.sdRect20.DrawLine = true;
			this.sdRect20.FillColor = System.Drawing.Color.Transparent;
			this.sdRect20.LineColor = System.Drawing.Color.Blue;
			this.sdRect20.LineStyle = Report.PenStyle.Solid;
			this.sdRect20.LineWidth = 4F;
			this.sdRect20.Location = new System.Drawing.Point(288, 232);
			this.sdRect20.Name = "sdRect20";
			this.sdRect20.Size = new System.Drawing.Size(210, 5);
			this.sdRect20.TabIndex = 32;
			this.sdRect20.Text = "sdRect20";
			// 
			// sdText21
			// 
			this.sdText21.CharSpace = 0F;
			this.sdText21.FontColor = System.Drawing.Color.Black;
			this.sdText21.FontName = Report.SdFontName.Arial;
			this.sdText21.FontSize = 9F;
			this.sdText21.Leading = 14F;
			this.sdText21.Lines = new string[] {
												   "LineWidth 4, LineStyle Solid, LineColor Blue"};
			this.sdText21.Location = new System.Drawing.Point(288, 216);
			this.sdText21.Name = "sdText21";
			this.sdText21.Size = new System.Drawing.Size(208, 14);
			this.sdText21.TabIndex = 31;
			this.sdText21.WordSpace = 0F;
			// 
			// sdRect11
			// 
			this.sdRect11.DrawLine = true;
			this.sdRect11.FillColor = System.Drawing.Color.Transparent;
			this.sdRect11.LineColor = System.Drawing.Color.Black;
			this.sdRect11.LineStyle = Report.PenStyle.Dot;
			this.sdRect11.LineWidth = 3F;
			this.sdRect11.Location = new System.Drawing.Point(288, 192);
			this.sdRect11.Name = "sdRect11";
			this.sdRect11.Size = new System.Drawing.Size(210, 4);
			this.sdRect11.TabIndex = 30;
			this.sdRect11.Text = "sdRect11";
			// 
			// sdText12
			// 
			this.sdText12.CharSpace = 0F;
			this.sdText12.FontColor = System.Drawing.Color.Black;
			this.sdText12.FontName = Report.SdFontName.Arial;
			this.sdText12.FontSize = 9F;
			this.sdText12.Leading = 14F;
			this.sdText12.Lines = new string[] {
												   "LineWidth 3, LineStyle Dot"};
			this.sdText12.Location = new System.Drawing.Point(288, 176);
			this.sdText12.Name = "sdText12";
			this.sdText12.Size = new System.Drawing.Size(165, 14);
			this.sdText12.TabIndex = 29;
			this.sdText12.WordSpace = 0F;
			// 
			// sdRect12
			// 
			this.sdRect12.DrawLine = true;
			this.sdRect12.FillColor = System.Drawing.Color.Transparent;
			this.sdRect12.LineColor = System.Drawing.Color.Black;
			this.sdRect12.LineStyle = Report.PenStyle.DashDotDot;
			this.sdRect12.LineWidth = 3F;
			this.sdRect12.Location = new System.Drawing.Point(288, 160);
			this.sdRect12.Name = "sdRect12";
			this.sdRect12.Size = new System.Drawing.Size(210, 4);
			this.sdRect12.TabIndex = 28;
			this.sdRect12.Text = "sdRect12";
			// 
			// sdText13
			// 
			this.sdText13.CharSpace = 0F;
			this.sdText13.FontColor = System.Drawing.Color.Black;
			this.sdText13.FontName = Report.SdFontName.Arial;
			this.sdText13.FontSize = 9F;
			this.sdText13.Leading = 14F;
			this.sdText13.Lines = new string[] {
												   "LineWidth 3, LineStyle DashDotDot"};
			this.sdText13.Location = new System.Drawing.Point(288, 144);
			this.sdText13.Name = "sdText13";
			this.sdText13.Size = new System.Drawing.Size(165, 14);
			this.sdText13.TabIndex = 27;
			this.sdText13.WordSpace = 0F;
			// 
			// sdRect13
			// 
			this.sdRect13.DrawLine = true;
			this.sdRect13.FillColor = System.Drawing.Color.Transparent;
			this.sdRect13.LineColor = System.Drawing.Color.Black;
			this.sdRect13.LineStyle = Report.PenStyle.DashDot;
			this.sdRect13.LineWidth = 3F;
			this.sdRect13.Location = new System.Drawing.Point(288, 128);
			this.sdRect13.Name = "sdRect13";
			this.sdRect13.Size = new System.Drawing.Size(210, 4);
			this.sdRect13.TabIndex = 26;
			this.sdRect13.Text = "sdRect13";
			// 
			// sdText14
			// 
			this.sdText14.CharSpace = 0F;
			this.sdText14.FontColor = System.Drawing.Color.Black;
			this.sdText14.FontName = Report.SdFontName.Arial;
			this.sdText14.FontSize = 9F;
			this.sdText14.Leading = 14F;
			this.sdText14.Lines = new string[] {
												   "LineWidth 3, LineStyle DashDot"};
			this.sdText14.Location = new System.Drawing.Point(288, 112);
			this.sdText14.Name = "sdText14";
			this.sdText14.Size = new System.Drawing.Size(165, 14);
			this.sdText14.TabIndex = 25;
			this.sdText14.WordSpace = 0F;
			// 
			// sdRect14
			// 
			this.sdRect14.DrawLine = true;
			this.sdRect14.FillColor = System.Drawing.Color.Transparent;
			this.sdRect14.LineColor = System.Drawing.Color.Black;
			this.sdRect14.LineStyle = Report.PenStyle.Dash;
			this.sdRect14.LineWidth = 3F;
			this.sdRect14.Location = new System.Drawing.Point(288, 96);
			this.sdRect14.Name = "sdRect14";
			this.sdRect14.Size = new System.Drawing.Size(210, 4);
			this.sdRect14.TabIndex = 24;
			this.sdRect14.Text = "sdRect14";
			// 
			// sdText15
			// 
			this.sdText15.CharSpace = 0F;
			this.sdText15.FontColor = System.Drawing.Color.Black;
			this.sdText15.FontName = Report.SdFontName.Arial;
			this.sdText15.FontSize = 9F;
			this.sdText15.Leading = 14F;
			this.sdText15.Lines = new string[] {
												   "LineWidth 3, LineStyle Dash"};
			this.sdText15.Location = new System.Drawing.Point(288, 80);
			this.sdText15.Name = "sdText15";
			this.sdText15.Size = new System.Drawing.Size(165, 14);
			this.sdText15.TabIndex = 23;
			this.sdText15.WordSpace = 0F;
			// 
			// sdRect15
			// 
			this.sdRect15.DrawLine = true;
			this.sdRect15.FillColor = System.Drawing.Color.Transparent;
			this.sdRect15.LineColor = System.Drawing.Color.Black;
			this.sdRect15.LineStyle = Report.PenStyle.Solid;
			this.sdRect15.LineWidth = 3F;
			this.sdRect15.Location = new System.Drawing.Point(288, 64);
			this.sdRect15.Name = "sdRect15";
			this.sdRect15.Size = new System.Drawing.Size(210, 4);
			this.sdRect15.TabIndex = 22;
			this.sdRect15.Text = "sdRect15";
			// 
			// sdText16
			// 
			this.sdText16.CharSpace = 0F;
			this.sdText16.FontColor = System.Drawing.Color.Black;
			this.sdText16.FontName = Report.SdFontName.Arial;
			this.sdText16.FontSize = 9F;
			this.sdText16.Leading = 14F;
			this.sdText16.Lines = new string[] {
												   "LineWidth 3, LineStyle Solid"};
			this.sdText16.Location = new System.Drawing.Point(288, 48);
			this.sdText16.Name = "sdText16";
			this.sdText16.Size = new System.Drawing.Size(165, 14);
			this.sdText16.TabIndex = 21;
			this.sdText16.WordSpace = 0F;
			// 
			// sdRect10
			// 
			this.sdRect10.DrawLine = true;
			this.sdRect10.FillColor = System.Drawing.Color.Transparent;
			this.sdRect10.LineColor = System.Drawing.Color.Blue;
			this.sdRect10.LineStyle = Report.PenStyle.Dot;
			this.sdRect10.LineWidth = 2F;
			this.sdRect10.Location = new System.Drawing.Point(32, 360);
			this.sdRect10.Name = "sdRect10";
			this.sdRect10.Size = new System.Drawing.Size(210, 3);
			this.sdRect10.TabIndex = 20;
			this.sdRect10.Text = "sdRect10";
			// 
			// sdText11
			// 
			this.sdText11.CharSpace = 0F;
			this.sdText11.FontColor = System.Drawing.Color.Black;
			this.sdText11.FontName = Report.SdFontName.Arial;
			this.sdText11.FontSize = 9F;
			this.sdText11.Leading = 14F;
			this.sdText11.Lines = new string[] {
												   "LineWidth 2, LineStyle Dot, LineColor Blue"};
			this.sdText11.Location = new System.Drawing.Point(32, 344);
			this.sdText11.Name = "sdText11";
			this.sdText11.Size = new System.Drawing.Size(208, 14);
			this.sdText11.TabIndex = 19;
			this.sdText11.WordSpace = 0F;
			// 
			// sdRect9
			// 
			this.sdRect9.DrawLine = true;
			this.sdRect9.FillColor = System.Drawing.Color.Transparent;
			this.sdRect9.LineColor = System.Drawing.Color.Blue;
			this.sdRect9.LineStyle = Report.PenStyle.DashDotDot;
			this.sdRect9.LineWidth = 2F;
			this.sdRect9.Location = new System.Drawing.Point(32, 328);
			this.sdRect9.Name = "sdRect9";
			this.sdRect9.Size = new System.Drawing.Size(210, 3);
			this.sdRect9.TabIndex = 18;
			this.sdRect9.Text = "sdRect9";
			// 
			// sdText10
			// 
			this.sdText10.CharSpace = 0F;
			this.sdText10.FontColor = System.Drawing.Color.Black;
			this.sdText10.FontName = Report.SdFontName.Arial;
			this.sdText10.FontSize = 9F;
			this.sdText10.Leading = 14F;
			this.sdText10.Lines = new string[] {
												   "LineWidth 2, LineStyle DashDotDot, LineColor Blue"};
			this.sdText10.Location = new System.Drawing.Point(32, 312);
			this.sdText10.Name = "sdText10";
			this.sdText10.Size = new System.Drawing.Size(208, 14);
			this.sdText10.TabIndex = 17;
			this.sdText10.WordSpace = 0F;
			// 
			// sdRect8
			// 
			this.sdRect8.DrawLine = true;
			this.sdRect8.FillColor = System.Drawing.Color.Transparent;
			this.sdRect8.LineColor = System.Drawing.Color.Blue;
			this.sdRect8.LineStyle = Report.PenStyle.DashDot;
			this.sdRect8.LineWidth = 2F;
			this.sdRect8.Location = new System.Drawing.Point(32, 296);
			this.sdRect8.Name = "sdRect8";
			this.sdRect8.Size = new System.Drawing.Size(210, 3);
			this.sdRect8.TabIndex = 16;
			this.sdRect8.Text = "sdRect8";
			// 
			// sdText9
			// 
			this.sdText9.CharSpace = 0F;
			this.sdText9.FontColor = System.Drawing.Color.Black;
			this.sdText9.FontName = Report.SdFontName.Arial;
			this.sdText9.FontSize = 9F;
			this.sdText9.Leading = 14F;
			this.sdText9.Lines = new string[] {
												  "LineWidth 2, LineStyle DashDot, LineColor Blue"};
			this.sdText9.Location = new System.Drawing.Point(32, 280);
			this.sdText9.Name = "sdText9";
			this.sdText9.Size = new System.Drawing.Size(208, 14);
			this.sdText9.TabIndex = 15;
			this.sdText9.WordSpace = 0F;
			// 
			// sdRect7
			// 
			this.sdRect7.DrawLine = true;
			this.sdRect7.FillColor = System.Drawing.Color.Transparent;
			this.sdRect7.LineColor = System.Drawing.Color.Blue;
			this.sdRect7.LineStyle = Report.PenStyle.Dash;
			this.sdRect7.LineWidth = 2F;
			this.sdRect7.Location = new System.Drawing.Point(32, 264);
			this.sdRect7.Name = "sdRect7";
			this.sdRect7.Size = new System.Drawing.Size(210, 3);
			this.sdRect7.TabIndex = 14;
			this.sdRect7.Text = "sdRect7";
			// 
			// sdText8
			// 
			this.sdText8.CharSpace = 0F;
			this.sdText8.FontColor = System.Drawing.Color.Black;
			this.sdText8.FontName = Report.SdFontName.Arial;
			this.sdText8.FontSize = 9F;
			this.sdText8.Leading = 14F;
			this.sdText8.Lines = new string[] {
												  "LineWidth 2, LineStyle Dash, LineColor Blue"};
			this.sdText8.Location = new System.Drawing.Point(32, 248);
			this.sdText8.Name = "sdText8";
			this.sdText8.Size = new System.Drawing.Size(208, 14);
			this.sdText8.TabIndex = 13;
			this.sdText8.WordSpace = 0F;
			// 
			// sdRect6
			// 
			this.sdRect6.DrawLine = true;
			this.sdRect6.FillColor = System.Drawing.Color.Transparent;
			this.sdRect6.LineColor = System.Drawing.Color.Blue;
			this.sdRect6.LineStyle = Report.PenStyle.Solid;
			this.sdRect6.LineWidth = 2F;
			this.sdRect6.Location = new System.Drawing.Point(32, 232);
			this.sdRect6.Name = "sdRect6";
			this.sdRect6.Size = new System.Drawing.Size(210, 3);
			this.sdRect6.TabIndex = 12;
			this.sdRect6.Text = "sdRect6";
			// 
			// sdText7
			// 
			this.sdText7.CharSpace = 0F;
			this.sdText7.FontColor = System.Drawing.Color.Black;
			this.sdText7.FontName = Report.SdFontName.Arial;
			this.sdText7.FontSize = 9F;
			this.sdText7.Leading = 14F;
			this.sdText7.Lines = new string[] {
												  "LineWidth 2, LineStyle Solid, LineColor Blue"};
			this.sdText7.Location = new System.Drawing.Point(32, 216);
			this.sdText7.Name = "sdText7";
			this.sdText7.Size = new System.Drawing.Size(208, 14);
			this.sdText7.TabIndex = 11;
			this.sdText7.WordSpace = 0F;
			// 
			// sdRect5
			// 
			this.sdRect5.DrawLine = true;
			this.sdRect5.FillColor = System.Drawing.Color.Transparent;
			this.sdRect5.LineColor = System.Drawing.Color.Black;
			this.sdRect5.LineStyle = Report.PenStyle.Dot;
			this.sdRect5.LineWidth = 0F;
			this.sdRect5.Location = new System.Drawing.Point(32, 192);
			this.sdRect5.Name = "sdRect5";
			this.sdRect5.Size = new System.Drawing.Size(210, 1);
			this.sdRect5.TabIndex = 10;
			this.sdRect5.Text = "sdRect5";
			// 
			// sdText6
			// 
			this.sdText6.CharSpace = 0F;
			this.sdText6.FontColor = System.Drawing.Color.Black;
			this.sdText6.FontName = Report.SdFontName.Arial;
			this.sdText6.FontSize = 9F;
			this.sdText6.Leading = 14F;
			this.sdText6.Lines = new string[] {
												  "LineWidth 0, LineStyle Dot"};
			this.sdText6.Location = new System.Drawing.Point(32, 176);
			this.sdText6.Name = "sdText6";
			this.sdText6.Size = new System.Drawing.Size(165, 14);
			this.sdText6.TabIndex = 9;
			this.sdText6.WordSpace = 0F;
			// 
			// sdRect4
			// 
			this.sdRect4.DrawLine = true;
			this.sdRect4.FillColor = System.Drawing.Color.Transparent;
			this.sdRect4.LineColor = System.Drawing.Color.Black;
			this.sdRect4.LineStyle = Report.PenStyle.DashDotDot;
			this.sdRect4.LineWidth = 0F;
			this.sdRect4.Location = new System.Drawing.Point(32, 160);
			this.sdRect4.Name = "sdRect4";
			this.sdRect4.Size = new System.Drawing.Size(210, 1);
			this.sdRect4.TabIndex = 8;
			this.sdRect4.Text = "sdRect4";
			// 
			// sdText5
			// 
			this.sdText5.CharSpace = 0F;
			this.sdText5.FontColor = System.Drawing.Color.Black;
			this.sdText5.FontName = Report.SdFontName.Arial;
			this.sdText5.FontSize = 9F;
			this.sdText5.Leading = 14F;
			this.sdText5.Lines = new string[] {
												  "LineWidth 0, LineStyle DashDotDot"};
			this.sdText5.Location = new System.Drawing.Point(32, 144);
			this.sdText5.Name = "sdText5";
			this.sdText5.Size = new System.Drawing.Size(165, 14);
			this.sdText5.TabIndex = 7;
			this.sdText5.WordSpace = 0F;
			// 
			// sdRect3
			// 
			this.sdRect3.DrawLine = true;
			this.sdRect3.FillColor = System.Drawing.Color.Transparent;
			this.sdRect3.LineColor = System.Drawing.Color.Black;
			this.sdRect3.LineStyle = Report.PenStyle.DashDot;
			this.sdRect3.LineWidth = 0F;
			this.sdRect3.Location = new System.Drawing.Point(32, 128);
			this.sdRect3.Name = "sdRect3";
			this.sdRect3.Size = new System.Drawing.Size(210, 1);
			this.sdRect3.TabIndex = 6;
			this.sdRect3.Text = "sdRect3";
			// 
			// sdText4
			// 
			this.sdText4.CharSpace = 0F;
			this.sdText4.FontColor = System.Drawing.Color.Black;
			this.sdText4.FontName = Report.SdFontName.Arial;
			this.sdText4.FontSize = 9F;
			this.sdText4.Leading = 14F;
			this.sdText4.Lines = new string[] {
												  "LineWidth 0, LineStyle DashDot"};
			this.sdText4.Location = new System.Drawing.Point(32, 112);
			this.sdText4.Name = "sdText4";
			this.sdText4.Size = new System.Drawing.Size(165, 14);
			this.sdText4.TabIndex = 5;
			this.sdText4.WordSpace = 0F;
			// 
			// sdRect2
			// 
			this.sdRect2.DrawLine = true;
			this.sdRect2.FillColor = System.Drawing.Color.Transparent;
			this.sdRect2.LineColor = System.Drawing.Color.Black;
			this.sdRect2.LineStyle = Report.PenStyle.Dash;
			this.sdRect2.LineWidth = 0F;
			this.sdRect2.Location = new System.Drawing.Point(32, 96);
			this.sdRect2.Name = "sdRect2";
			this.sdRect2.Size = new System.Drawing.Size(210, 1);
			this.sdRect2.TabIndex = 4;
			this.sdRect2.Text = "sdRect2";
			// 
			// sdText3
			// 
			this.sdText3.CharSpace = 0F;
			this.sdText3.FontColor = System.Drawing.Color.Black;
			this.sdText3.FontName = Report.SdFontName.Arial;
			this.sdText3.FontSize = 9F;
			this.sdText3.Leading = 14F;
			this.sdText3.Lines = new string[] {
												  "LineWidth 0, LineStyle Dash"};
			this.sdText3.Location = new System.Drawing.Point(32, 80);
			this.sdText3.Name = "sdText3";
			this.sdText3.Size = new System.Drawing.Size(165, 14);
			this.sdText3.TabIndex = 3;
			this.sdText3.WordSpace = 0F;
			// 
			// sdRect1
			// 
			this.sdRect1.DrawLine = true;
			this.sdRect1.FillColor = System.Drawing.Color.Transparent;
			this.sdRect1.LineColor = System.Drawing.Color.Black;
			this.sdRect1.LineStyle = Report.PenStyle.Solid;
			this.sdRect1.LineWidth = 0F;
			this.sdRect1.Location = new System.Drawing.Point(32, 64);
			this.sdRect1.Name = "sdRect1";
			this.sdRect1.Size = new System.Drawing.Size(210, 1);
			this.sdRect1.TabIndex = 2;
			this.sdRect1.Text = "sdRect1";
			// 
			// sdText2
			// 
			this.sdText2.CharSpace = 0F;
			this.sdText2.FontColor = System.Drawing.Color.Black;
			this.sdText2.FontName = Report.SdFontName.Arial;
			this.sdText2.FontSize = 9F;
			this.sdText2.Leading = 14F;
			this.sdText2.Lines = new string[] {
												  "LineWidth 0, LineStyle Solid"};
			this.sdText2.Location = new System.Drawing.Point(32, 48);
			this.sdText2.Name = "sdText2";
			this.sdText2.Size = new System.Drawing.Size(165, 14);
			this.sdText2.TabIndex = 1;
			this.sdText2.WordSpace = 0F;
			// 
			// sdText1
			// 
			this.sdText1.CharSpace = 0F;
			this.sdText1.FontBold = true;
			this.sdText1.FontColor = System.Drawing.Color.Black;
			this.sdText1.FontName = Report.SdFontName.Arial;
			this.sdText1.FontSize = 24F;
			this.sdText1.Leading = 14F;
			this.sdText1.Lines = new string[] {
												  "PdfCreator Line Example"};
			this.sdText1.Location = new System.Drawing.Point(128, 8);
			this.sdText1.Name = "sdText1";
			this.sdText1.Size = new System.Drawing.Size(292, 30);
			this.sdText1.TabIndex = 0;
			this.sdText1.WordSpace = 0F;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileName = "LineExample.pdf";
			this.saveFileDialog1.Filter = "PDF Files|*.pdf|All Files|*.*";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(380, 274);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.sdPage1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
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

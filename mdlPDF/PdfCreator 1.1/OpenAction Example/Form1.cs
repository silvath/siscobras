using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using Report;

namespace OpenAction_Example
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Report.SDReport sdReport1;
		private Report.SDPage sdPage1;
		private Report.SDLayoutPanel sdLayoutPanel1;
		private Report.SDLabel sdLabel1;
		private Report.SDLabel sdLabel2;
		private Report.SDLabel sdLabel3;
		private Report.SDLabel sdLabel4;
		private Report.SDLabel sdLabel5;
		private Report.SDLabel sdLabel6;
		private Report.SDLabel sdLabel7;
		private Report.SDLabel sdLabel8;
		private Report.SDLabel sdLabel9;
		private Report.SDLabel sdLabel10;
		private Report.SDLabel sdLabel11;
		private Report.SDLabel sdLabel12;
		private Report.SDLabel sdLabel19;
		private Report.SDLabel sdLabel20;
		private Report.SDLabel sdLabel21;
		private Report.SDLabel sdLabel22;
		private Report.SDLabel sdLabel23;
		private Report.SDLabel sdLabel24;
		private System.Windows.Forms.NumericUpDown numLeft;
		private System.Windows.Forms.NumericUpDown numTop;
		private System.Windows.Forms.NumericUpDown numRight;
		private System.Windows.Forms.NumericUpDown numBottom;
		private System.Windows.Forms.NumericUpDown numZoom;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label6;
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
			this.button1 = new System.Windows.Forms.Button();
			this.numLeft = new System.Windows.Forms.NumericUpDown();
			this.numTop = new System.Windows.Forms.NumericUpDown();
			this.numRight = new System.Windows.Forms.NumericUpDown();
			this.numBottom = new System.Windows.Forms.NumericUpDown();
			this.numZoom = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.sdReport1 = new Report.SDReport();
			this.sdPage1 = new Report.SDPage();
			this.sdLayoutPanel1 = new Report.SDLayoutPanel();
			this.sdLabel19 = new Report.SDLabel();
			this.sdLabel20 = new Report.SDLabel();
			this.sdLabel21 = new Report.SDLabel();
			this.sdLabel22 = new Report.SDLabel();
			this.sdLabel23 = new Report.SDLabel();
			this.sdLabel24 = new Report.SDLabel();
			this.sdLabel7 = new Report.SDLabel();
			this.sdLabel8 = new Report.SDLabel();
			this.sdLabel9 = new Report.SDLabel();
			this.sdLabel10 = new Report.SDLabel();
			this.sdLabel11 = new Report.SDLabel();
			this.sdLabel12 = new Report.SDLabel();
			this.sdLabel4 = new Report.SDLabel();
			this.sdLabel5 = new Report.SDLabel();
			this.sdLabel6 = new Report.SDLabel();
			this.sdLabel3 = new Report.SDLabel();
			this.sdLabel2 = new Report.SDLabel();
			this.sdLabel1 = new Report.SDLabel();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numLeft)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numTop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBottom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numZoom)).BeginInit();
			this.sdPage1.SuspendLayout();
			this.sdLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 8);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "CreatePdf";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// numLeft
			// 
			this.numLeft.Location = new System.Drawing.Point(48, 48);
			this.numLeft.Minimum = new System.Decimal(new int[] {
																	50,
																	0,
																	0,
																	-2147483648});
			this.numLeft.Name = "numLeft";
			this.numLeft.Size = new System.Drawing.Size(72, 20);
			this.numLeft.TabIndex = 1;
			this.numLeft.Value = new System.Decimal(new int[] {
																  10,
																  0,
																  0,
																  -2147483648});
			// 
			// numTop
			// 
			this.numTop.Location = new System.Drawing.Point(48, 80);
			this.numTop.Minimum = new System.Decimal(new int[] {
																   50,
																   0,
																   0,
																   -2147483648});
			this.numTop.Name = "numTop";
			this.numTop.Size = new System.Drawing.Size(72, 20);
			this.numTop.TabIndex = 2;
			this.numTop.Value = new System.Decimal(new int[] {
																 10,
																 0,
																 0,
																 -2147483648});
			// 
			// numRight
			// 
			this.numRight.Location = new System.Drawing.Point(48, 112);
			this.numRight.Maximum = new System.Decimal(new int[] {
																	 700,
																	 0,
																	 0,
																	 0});
			this.numRight.Name = "numRight";
			this.numRight.Size = new System.Drawing.Size(72, 20);
			this.numRight.TabIndex = 3;
			this.numRight.Value = new System.Decimal(new int[] {
																   610,
																   0,
																   0,
																   0});
			// 
			// numBottom
			// 
			this.numBottom.Location = new System.Drawing.Point(48, 144);
			this.numBottom.Maximum = new System.Decimal(new int[] {
																	  500,
																	  0,
																	  0,
																	  0});
			this.numBottom.Name = "numBottom";
			this.numBottom.Size = new System.Drawing.Size(72, 20);
			this.numBottom.TabIndex = 4;
			this.numBottom.Value = new System.Decimal(new int[] {
																	400,
																	0,
																	0,
																	0});
			// 
			// numZoom
			// 
			this.numZoom.Enabled = false;
			this.numZoom.Location = new System.Drawing.Point(48, 176);
			this.numZoom.Name = "numZoom";
			this.numZoom.Size = new System.Drawing.Size(72, 20);
			this.numZoom.TabIndex = 5;
			this.numZoom.Value = new System.Decimal(new int[] {
																  100,
																  0,
																  0,
																  0});
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "Left";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Top";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "Right";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Bottom";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 176);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "Zoom";
			// 
			// sdReport1
			// 
			this.sdReport1.Author = null;
			this.sdReport1.CreationDate = new System.DateTime(2002, 12, 26, 15, 40, 8, 546);
			this.sdReport1.Creator = null;
			this.sdReport1.FileName = "default.pdf";
			this.sdReport1.Keywords = null;
			this.sdReport1.ModDate = new System.DateTime(((long)(0)));
			this.sdReport1.Subject = null;
			this.sdReport1.Title = null;
			// 
			// sdPage1
			// 
			this.sdPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.sdLayoutPanel1});
			this.sdPage1.DockPadding.All = 32;
			this.sdPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage1.Location = new System.Drawing.Point(0, 248);
			this.sdPage1.Name = "sdPage1";
			this.sdPage1.Size = new System.Drawing.Size(596, 842);
			this.sdPage1.TabIndex = 12;
			this.sdPage1.Text = "sdPage1";
			this.sdPage1.Visible = false;
			this.sdPage1.PrintPage += new Report.SDPrintPageEvent(this.sdPage1_PrintPage);
			// 
			// sdLayoutPanel1
			// 
			this.sdLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.sdLabel19,
																						 this.sdLabel20,
																						 this.sdLabel21,
																						 this.sdLabel22,
																						 this.sdLabel23,
																						 this.sdLabel24,
																						 this.sdLabel7,
																						 this.sdLabel8,
																						 this.sdLabel9,
																						 this.sdLabel10,
																						 this.sdLabel11,
																						 this.sdLabel12,
																						 this.sdLabel4,
																						 this.sdLabel5,
																						 this.sdLabel6,
																						 this.sdLabel3,
																						 this.sdLabel2,
																						 this.sdLabel1});
			this.sdLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel1.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel1.Name = "sdLayoutPanel1";
			this.sdLayoutPanel1.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel1.TabIndex = 0;
			this.sdLayoutPanel1.Text = "sdLayoutPanel1";
			// 
			// sdLabel19
			// 
			this.sdLabel19.CharSpace = 1F;
			this.sdLabel19.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(170)));
			this.sdLabel19.FontName = Report.SdFontName.Arial;
			this.sdLabel19.FontSize = 30F;
			this.sdLabel19.Location = new System.Drawing.Point(8, 720);
			this.sdLabel19.Name = "sdLabel19";
			this.sdLabel19.Size = new System.Drawing.Size(504, 30);
			this.sdLabel19.TabIndex = 17;
			this.sdLabel19.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel19.WordSpace = 0F;
			// 
			// sdLabel20
			// 
			this.sdLabel20.CharSpace = 1F;
			this.sdLabel20.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(160)));
			this.sdLabel20.FontName = Report.SdFontName.Arial;
			this.sdLabel20.FontSize = 30F;
			this.sdLabel20.Location = new System.Drawing.Point(8, 680);
			this.sdLabel20.Name = "sdLabel20";
			this.sdLabel20.Size = new System.Drawing.Size(504, 30);
			this.sdLabel20.TabIndex = 16;
			this.sdLabel20.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel20.WordSpace = 0F;
			// 
			// sdLabel21
			// 
			this.sdLabel21.CharSpace = 1F;
			this.sdLabel21.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(150)));
			this.sdLabel21.FontName = Report.SdFontName.Arial;
			this.sdLabel21.FontSize = 30F;
			this.sdLabel21.Location = new System.Drawing.Point(8, 640);
			this.sdLabel21.Name = "sdLabel21";
			this.sdLabel21.Size = new System.Drawing.Size(504, 30);
			this.sdLabel21.TabIndex = 15;
			this.sdLabel21.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel21.WordSpace = 0F;
			// 
			// sdLabel22
			// 
			this.sdLabel22.CharSpace = 1F;
			this.sdLabel22.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(140)));
			this.sdLabel22.FontName = Report.SdFontName.Arial;
			this.sdLabel22.FontSize = 30F;
			this.sdLabel22.Location = new System.Drawing.Point(8, 600);
			this.sdLabel22.Name = "sdLabel22";
			this.sdLabel22.Size = new System.Drawing.Size(504, 30);
			this.sdLabel22.TabIndex = 14;
			this.sdLabel22.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel22.WordSpace = 0F;
			// 
			// sdLabel23
			// 
			this.sdLabel23.CharSpace = 1F;
			this.sdLabel23.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(130)));
			this.sdLabel23.FontName = Report.SdFontName.Arial;
			this.sdLabel23.FontSize = 30F;
			this.sdLabel23.Location = new System.Drawing.Point(8, 560);
			this.sdLabel23.Name = "sdLabel23";
			this.sdLabel23.Size = new System.Drawing.Size(504, 30);
			this.sdLabel23.TabIndex = 13;
			this.sdLabel23.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel23.WordSpace = 0F;
			// 
			// sdLabel24
			// 
			this.sdLabel24.CharSpace = 1F;
			this.sdLabel24.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(120)));
			this.sdLabel24.FontName = Report.SdFontName.Arial;
			this.sdLabel24.FontSize = 30F;
			this.sdLabel24.Location = new System.Drawing.Point(8, 520);
			this.sdLabel24.Name = "sdLabel24";
			this.sdLabel24.Size = new System.Drawing.Size(504, 30);
			this.sdLabel24.TabIndex = 12;
			this.sdLabel24.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel24.WordSpace = 0F;
			// 
			// sdLabel7
			// 
			this.sdLabel7.CharSpace = 1F;
			this.sdLabel7.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(110)));
			this.sdLabel7.FontName = Report.SdFontName.Arial;
			this.sdLabel7.FontSize = 30F;
			this.sdLabel7.Location = new System.Drawing.Point(8, 480);
			this.sdLabel7.Name = "sdLabel7";
			this.sdLabel7.Size = new System.Drawing.Size(504, 30);
			this.sdLabel7.TabIndex = 11;
			this.sdLabel7.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel7.WordSpace = 0F;
			// 
			// sdLabel8
			// 
			this.sdLabel8.CharSpace = 1F;
			this.sdLabel8.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(100)));
			this.sdLabel8.FontName = Report.SdFontName.Arial;
			this.sdLabel8.FontSize = 30F;
			this.sdLabel8.Location = new System.Drawing.Point(8, 440);
			this.sdLabel8.Name = "sdLabel8";
			this.sdLabel8.Size = new System.Drawing.Size(504, 30);
			this.sdLabel8.TabIndex = 10;
			this.sdLabel8.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel8.WordSpace = 0F;
			// 
			// sdLabel9
			// 
			this.sdLabel9.CharSpace = 1F;
			this.sdLabel9.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(90)));
			this.sdLabel9.FontName = Report.SdFontName.Arial;
			this.sdLabel9.FontSize = 30F;
			this.sdLabel9.Location = new System.Drawing.Point(8, 400);
			this.sdLabel9.Name = "sdLabel9";
			this.sdLabel9.Size = new System.Drawing.Size(504, 30);
			this.sdLabel9.TabIndex = 9;
			this.sdLabel9.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel9.WordSpace = 0F;
			// 
			// sdLabel10
			// 
			this.sdLabel10.CharSpace = 1F;
			this.sdLabel10.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(80)));
			this.sdLabel10.FontName = Report.SdFontName.Arial;
			this.sdLabel10.FontSize = 30F;
			this.sdLabel10.Location = new System.Drawing.Point(8, 360);
			this.sdLabel10.Name = "sdLabel10";
			this.sdLabel10.Size = new System.Drawing.Size(504, 30);
			this.sdLabel10.TabIndex = 8;
			this.sdLabel10.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel10.WordSpace = 0F;
			// 
			// sdLabel11
			// 
			this.sdLabel11.CharSpace = 1F;
			this.sdLabel11.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(70)));
			this.sdLabel11.FontName = Report.SdFontName.Arial;
			this.sdLabel11.FontSize = 30F;
			this.sdLabel11.Location = new System.Drawing.Point(8, 320);
			this.sdLabel11.Name = "sdLabel11";
			this.sdLabel11.Size = new System.Drawing.Size(504, 30);
			this.sdLabel11.TabIndex = 7;
			this.sdLabel11.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel11.WordSpace = 0F;
			// 
			// sdLabel12
			// 
			this.sdLabel12.CharSpace = 1F;
			this.sdLabel12.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(60)));
			this.sdLabel12.FontName = Report.SdFontName.Arial;
			this.sdLabel12.FontSize = 30F;
			this.sdLabel12.Location = new System.Drawing.Point(8, 280);
			this.sdLabel12.Name = "sdLabel12";
			this.sdLabel12.Size = new System.Drawing.Size(504, 30);
			this.sdLabel12.TabIndex = 6;
			this.sdLabel12.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel12.WordSpace = 0F;
			// 
			// sdLabel4
			// 
			this.sdLabel4.CharSpace = 1F;
			this.sdLabel4.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(50)));
			this.sdLabel4.FontName = Report.SdFontName.Arial;
			this.sdLabel4.FontSize = 30F;
			this.sdLabel4.Location = new System.Drawing.Point(8, 240);
			this.sdLabel4.Name = "sdLabel4";
			this.sdLabel4.Size = new System.Drawing.Size(504, 30);
			this.sdLabel4.TabIndex = 5;
			this.sdLabel4.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel4.WordSpace = 0F;
			// 
			// sdLabel5
			// 
			this.sdLabel5.CharSpace = 1F;
			this.sdLabel5.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(40)));
			this.sdLabel5.FontName = Report.SdFontName.Arial;
			this.sdLabel5.FontSize = 30F;
			this.sdLabel5.Location = new System.Drawing.Point(8, 200);
			this.sdLabel5.Name = "sdLabel5";
			this.sdLabel5.Size = new System.Drawing.Size(504, 30);
			this.sdLabel5.TabIndex = 4;
			this.sdLabel5.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel5.WordSpace = 0F;
			// 
			// sdLabel6
			// 
			this.sdLabel6.CharSpace = 1F;
			this.sdLabel6.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(30)));
			this.sdLabel6.FontName = Report.SdFontName.Arial;
			this.sdLabel6.FontSize = 30F;
			this.sdLabel6.Location = new System.Drawing.Point(8, 160);
			this.sdLabel6.Name = "sdLabel6";
			this.sdLabel6.Size = new System.Drawing.Size(504, 30);
			this.sdLabel6.TabIndex = 3;
			this.sdLabel6.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel6.WordSpace = 0F;
			// 
			// sdLabel3
			// 
			this.sdLabel3.CharSpace = 1F;
			this.sdLabel3.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(20)));
			this.sdLabel3.FontName = Report.SdFontName.Arial;
			this.sdLabel3.FontSize = 30F;
			this.sdLabel3.Location = new System.Drawing.Point(8, 120);
			this.sdLabel3.Name = "sdLabel3";
			this.sdLabel3.Size = new System.Drawing.Size(504, 30);
			this.sdLabel3.TabIndex = 2;
			this.sdLabel3.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel3.WordSpace = 0F;
			// 
			// sdLabel2
			// 
			this.sdLabel2.CharSpace = 1F;
			this.sdLabel2.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(10)));
			this.sdLabel2.FontName = Report.SdFontName.Arial;
			this.sdLabel2.FontSize = 30F;
			this.sdLabel2.Location = new System.Drawing.Point(8, 80);
			this.sdLabel2.Name = "sdLabel2";
			this.sdLabel2.Size = new System.Drawing.Size(504, 30);
			this.sdLabel2.TabIndex = 1;
			this.sdLabel2.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel2.WordSpace = 0F;
			// 
			// sdLabel1
			// 
			this.sdLabel1.CharSpace = 1F;
			this.sdLabel1.FontColor = System.Drawing.Color.Black;
			this.sdLabel1.FontName = Report.SdFontName.Arial;
			this.sdLabel1.FontSize = 30F;
			this.sdLabel1.Location = new System.Drawing.Point(8, 40);
			this.sdLabel1.Name = "sdLabel1";
			this.sdLabel1.Size = new System.Drawing.Size(504, 30);
			this.sdLabel1.TabIndex = 0;
			this.sdLabel1.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel1.WordSpace = 0F;
			// 
			// comboBox1
			// 
			this.comboBox1.Items.AddRange(new object[] {
														   "XYZ",
														   "Fit",
														   "FitH",
														   "FitV",
														   "FitR",
														   "FitB",
														   "FitBH",
														   "FitBV"});
			this.comboBox1.Location = new System.Drawing.Point(168, 96);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(168, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(120, 16);
			this.label6.TabIndex = 13;
			this.label6.Text = "Destination Type";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 238);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label6,
																		  this.sdPage1,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.numZoom,
																		  this.numBottom,
																		  this.numRight,
																		  this.numTop,
																		  this.numLeft,
																		  this.button1,
																		  this.comboBox1});
			this.Name = "Form1";
			this.Text = "Form1";			
			((System.ComponentModel.ISupportInitialize)(this.numLeft)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numTop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBottom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numZoom)).EndInit();
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			sdReport1.BeginDoc();
			sdReport1.Print(sdPage1);
			sdReport1.EndDoc();
			
			Process Acro=Process.Start("default.pdf");
			Acro.WaitForExit();
			Acro.Close();
		}

		private void sdPage1_PrintPage(object sender, Report.SDPrintPageEventArgs arg)
		{
			SDDestination Dest;			
			Dest=sdReport1.CreateDestination();
			Dest.DestinationType=(PdfDestinationType)comboBox1.SelectedIndex;
			Dest.Left=(int)numLeft.Value;
			Dest.Top=(int)numTop.Value;
			Dest.Right=(int)numRight.Value;
			Dest.Bottom=(int)numBottom.Value;
			Dest.Zoom=(int)numZoom.Value/100;
			sdReport1.OpenAction(Dest);
		}
		
		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int selectedindex=comboBox1.SelectedIndex;
			switch(selectedindex)
			{
				case 0:
					numTop.Enabled=true;
					numLeft.Enabled=true;
					numZoom.Enabled=true;
					numRight.Enabled=false;
					numBottom.Enabled=false;
					break;
				case 1:
					numTop.Enabled=false;
					numLeft.Enabled=false;
					numZoom.Enabled=false;
					numRight.Enabled=false;
					numBottom.Enabled=false;
					break;
				case 2:
					numTop.Enabled=true;
					numLeft.Enabled=false;
					numZoom.Enabled=false;
					numRight.Enabled=false;
					numBottom.Enabled=false;
					break;
				case 3:
					numTop.Enabled=false;
					numLeft.Enabled=true;
					numZoom.Enabled=false;
					numRight.Enabled=false;
					numBottom.Enabled=false;
					break;
				case 4:
					numTop.Enabled=true;
					numLeft.Enabled=true;
					numZoom.Enabled=false;
					numRight.Enabled=true;
					numBottom.Enabled=true;
					break;
				case 5:
					goto case 1;
				case 6:
					goto case 2;
				case 7:
					goto case 3;
			}
		}
	}
}

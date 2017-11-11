using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Report;
using System.Diagnostics;

namespace PageLayoutMode_Example
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Report.SDPage sdPage1;
		private Report.SDLayoutPanel sdLayoutPanel1;
		private Report.SDLabel sdLabel19;
		private Report.SDLabel sdLabel20;
		private Report.SDLabel sdLabel21;
		private Report.SDLabel sdLabel22;
		private Report.SDLabel sdLabel23;
		private Report.SDLabel sdLabel24;
		private Report.SDLabel sdLabel7;
		private Report.SDLabel sdLabel8;
		private Report.SDLabel sdLabel9;
		private Report.SDLabel sdLabel10;
		private Report.SDLabel sdLabel11;
		private Report.SDLabel sdLabel12;
		private Report.SDLabel sdLabel4;
		private Report.SDLabel sdLabel5;
		private Report.SDLabel sdLabel6;
		private Report.SDLabel sdLabel3;
		private Report.SDLabel sdLabel2;
		private Report.SDLabel sdLabel1;
		private Report.SDPage sdPage2;
		private Report.SDLayoutPanel sdLayoutPanel2;
		private Report.SDLabel sdLabel13;
		private Report.SDLabel sdLabel14;
		private Report.SDLabel sdLabel15;
		private Report.SDLabel sdLabel16;
		private Report.SDLabel sdLabel17;
		private Report.SDLabel sdLabel18;
		private Report.SDLabel sdLabel25;
		private Report.SDLabel sdLabel26;
		private Report.SDLabel sdLabel27;
		private Report.SDLabel sdLabel28;
		private Report.SDLabel sdLabel29;
		private Report.SDLabel sdLabel30;
		private Report.SDLabel sdLabel31;
		private Report.SDLabel sdLabel32;
		private Report.SDLabel sdLabel33;
		private Report.SDLabel sdLabel34;
		private Report.SDLabel sdLabel35;
		private Report.SDLabel sdLabel36;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
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
			this.sdPage2 = new Report.SDPage();
			this.sdLayoutPanel2 = new Report.SDLayoutPanel();
			this.sdLabel13 = new Report.SDLabel();
			this.sdLabel14 = new Report.SDLabel();
			this.sdLabel15 = new Report.SDLabel();
			this.sdLabel16 = new Report.SDLabel();
			this.sdLabel17 = new Report.SDLabel();
			this.sdLabel18 = new Report.SDLabel();
			this.sdLabel25 = new Report.SDLabel();
			this.sdLabel26 = new Report.SDLabel();
			this.sdLabel27 = new Report.SDLabel();
			this.sdLabel28 = new Report.SDLabel();
			this.sdLabel29 = new Report.SDLabel();
			this.sdLabel30 = new Report.SDLabel();
			this.sdLabel31 = new Report.SDLabel();
			this.sdLabel32 = new Report.SDLabel();
			this.sdLabel33 = new Report.SDLabel();
			this.sdLabel34 = new Report.SDLabel();
			this.sdLabel35 = new Report.SDLabel();
			this.sdLabel36 = new Report.SDLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.sdPage1.SuspendLayout();
			this.sdLayoutPanel1.SuspendLayout();
			this.sdPage2.SuspendLayout();
			this.sdLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// sdPage1
			// 
			this.sdPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.sdLayoutPanel1});
			this.sdPage1.DockPadding.All = 32;
			this.sdPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage1.Location = new System.Drawing.Point(0, 264);
			this.sdPage1.Name = "sdPage1";
			this.sdPage1.Size = new System.Drawing.Size(596, 842);
			this.sdPage1.TabIndex = 13;
			this.sdPage1.Text = "sdPage1";
			this.sdPage1.Visible = false;
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
			// sdPage2
			// 
			this.sdPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.sdLayoutPanel2});
			this.sdPage2.DockPadding.All = 32;
			this.sdPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage2.Location = new System.Drawing.Point(0, 264);
			this.sdPage2.Name = "sdPage2";
			this.sdPage2.Size = new System.Drawing.Size(596, 842);
			this.sdPage2.TabIndex = 14;
			this.sdPage2.Text = "sdPage2";
			this.sdPage2.Visible = false;
			// 
			// sdLayoutPanel2
			// 
			this.sdLayoutPanel2.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.sdLabel13,
																						 this.sdLabel14,
																						 this.sdLabel15,
																						 this.sdLabel16,
																						 this.sdLabel17,
																						 this.sdLabel18,
																						 this.sdLabel25,
																						 this.sdLabel26,
																						 this.sdLabel27,
																						 this.sdLabel28,
																						 this.sdLabel29,
																						 this.sdLabel30,
																						 this.sdLabel31,
																						 this.sdLabel32,
																						 this.sdLabel33,
																						 this.sdLabel34,
																						 this.sdLabel35,
																						 this.sdLabel36});
			this.sdLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel2.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel2.Name = "sdLayoutPanel2";
			this.sdLayoutPanel2.Size = new System.Drawing.Size(532, 778);
			this.sdLayoutPanel2.TabIndex = 0;
			this.sdLayoutPanel2.Text = "sdLayoutPanel1";
			// 
			// sdLabel13
			// 
			this.sdLabel13.CharSpace = 1F;
			this.sdLabel13.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(170)));
			this.sdLabel13.FontName = Report.SdFontName.Arial;
			this.sdLabel13.FontSize = 30F;
			this.sdLabel13.Location = new System.Drawing.Point(8, 720);
			this.sdLabel13.Name = "sdLabel13";
			this.sdLabel13.Size = new System.Drawing.Size(504, 30);
			this.sdLabel13.TabIndex = 17;
			this.sdLabel13.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel13.WordSpace = 0F;
			// 
			// sdLabel14
			// 
			this.sdLabel14.CharSpace = 1F;
			this.sdLabel14.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(160)));
			this.sdLabel14.FontName = Report.SdFontName.Arial;
			this.sdLabel14.FontSize = 30F;
			this.sdLabel14.Location = new System.Drawing.Point(8, 680);
			this.sdLabel14.Name = "sdLabel14";
			this.sdLabel14.Size = new System.Drawing.Size(504, 30);
			this.sdLabel14.TabIndex = 16;
			this.sdLabel14.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel14.WordSpace = 0F;
			// 
			// sdLabel15
			// 
			this.sdLabel15.CharSpace = 1F;
			this.sdLabel15.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(150)));
			this.sdLabel15.FontName = Report.SdFontName.Arial;
			this.sdLabel15.FontSize = 30F;
			this.sdLabel15.Location = new System.Drawing.Point(8, 640);
			this.sdLabel15.Name = "sdLabel15";
			this.sdLabel15.Size = new System.Drawing.Size(504, 30);
			this.sdLabel15.TabIndex = 15;
			this.sdLabel15.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel15.WordSpace = 0F;
			// 
			// sdLabel16
			// 
			this.sdLabel16.CharSpace = 1F;
			this.sdLabel16.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(140)));
			this.sdLabel16.FontName = Report.SdFontName.Arial;
			this.sdLabel16.FontSize = 30F;
			this.sdLabel16.Location = new System.Drawing.Point(8, 600);
			this.sdLabel16.Name = "sdLabel16";
			this.sdLabel16.Size = new System.Drawing.Size(504, 30);
			this.sdLabel16.TabIndex = 14;
			this.sdLabel16.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel16.WordSpace = 0F;
			// 
			// sdLabel17
			// 
			this.sdLabel17.CharSpace = 1F;
			this.sdLabel17.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(130)));
			this.sdLabel17.FontName = Report.SdFontName.Arial;
			this.sdLabel17.FontSize = 30F;
			this.sdLabel17.Location = new System.Drawing.Point(8, 560);
			this.sdLabel17.Name = "sdLabel17";
			this.sdLabel17.Size = new System.Drawing.Size(504, 30);
			this.sdLabel17.TabIndex = 13;
			this.sdLabel17.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel17.WordSpace = 0F;
			// 
			// sdLabel18
			// 
			this.sdLabel18.CharSpace = 1F;
			this.sdLabel18.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(120)));
			this.sdLabel18.FontName = Report.SdFontName.Arial;
			this.sdLabel18.FontSize = 30F;
			this.sdLabel18.Location = new System.Drawing.Point(8, 520);
			this.sdLabel18.Name = "sdLabel18";
			this.sdLabel18.Size = new System.Drawing.Size(504, 30);
			this.sdLabel18.TabIndex = 12;
			this.sdLabel18.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel18.WordSpace = 0F;
			// 
			// sdLabel25
			// 
			this.sdLabel25.CharSpace = 1F;
			this.sdLabel25.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(110)));
			this.sdLabel25.FontName = Report.SdFontName.Arial;
			this.sdLabel25.FontSize = 30F;
			this.sdLabel25.Location = new System.Drawing.Point(8, 480);
			this.sdLabel25.Name = "sdLabel25";
			this.sdLabel25.Size = new System.Drawing.Size(504, 30);
			this.sdLabel25.TabIndex = 11;
			this.sdLabel25.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel25.WordSpace = 0F;
			// 
			// sdLabel26
			// 
			this.sdLabel26.CharSpace = 1F;
			this.sdLabel26.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(100)));
			this.sdLabel26.FontName = Report.SdFontName.Arial;
			this.sdLabel26.FontSize = 30F;
			this.sdLabel26.Location = new System.Drawing.Point(8, 440);
			this.sdLabel26.Name = "sdLabel26";
			this.sdLabel26.Size = new System.Drawing.Size(504, 30);
			this.sdLabel26.TabIndex = 10;
			this.sdLabel26.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel26.WordSpace = 0F;
			// 
			// sdLabel27
			// 
			this.sdLabel27.CharSpace = 1F;
			this.sdLabel27.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(90)));
			this.sdLabel27.FontName = Report.SdFontName.Arial;
			this.sdLabel27.FontSize = 30F;
			this.sdLabel27.Location = new System.Drawing.Point(8, 400);
			this.sdLabel27.Name = "sdLabel27";
			this.sdLabel27.Size = new System.Drawing.Size(504, 30);
			this.sdLabel27.TabIndex = 9;
			this.sdLabel27.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel27.WordSpace = 0F;
			// 
			// sdLabel28
			// 
			this.sdLabel28.CharSpace = 1F;
			this.sdLabel28.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(80)));
			this.sdLabel28.FontName = Report.SdFontName.Arial;
			this.sdLabel28.FontSize = 30F;
			this.sdLabel28.Location = new System.Drawing.Point(8, 360);
			this.sdLabel28.Name = "sdLabel28";
			this.sdLabel28.Size = new System.Drawing.Size(504, 30);
			this.sdLabel28.TabIndex = 8;
			this.sdLabel28.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel28.WordSpace = 0F;
			// 
			// sdLabel29
			// 
			this.sdLabel29.CharSpace = 1F;
			this.sdLabel29.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(70)));
			this.sdLabel29.FontName = Report.SdFontName.Arial;
			this.sdLabel29.FontSize = 30F;
			this.sdLabel29.Location = new System.Drawing.Point(8, 320);
			this.sdLabel29.Name = "sdLabel29";
			this.sdLabel29.Size = new System.Drawing.Size(504, 30);
			this.sdLabel29.TabIndex = 7;
			this.sdLabel29.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel29.WordSpace = 0F;
			// 
			// sdLabel30
			// 
			this.sdLabel30.CharSpace = 1F;
			this.sdLabel30.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(60)));
			this.sdLabel30.FontName = Report.SdFontName.Arial;
			this.sdLabel30.FontSize = 30F;
			this.sdLabel30.Location = new System.Drawing.Point(8, 280);
			this.sdLabel30.Name = "sdLabel30";
			this.sdLabel30.Size = new System.Drawing.Size(504, 30);
			this.sdLabel30.TabIndex = 6;
			this.sdLabel30.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel30.WordSpace = 0F;
			// 
			// sdLabel31
			// 
			this.sdLabel31.CharSpace = 1F;
			this.sdLabel31.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(50)));
			this.sdLabel31.FontName = Report.SdFontName.Arial;
			this.sdLabel31.FontSize = 30F;
			this.sdLabel31.Location = new System.Drawing.Point(8, 240);
			this.sdLabel31.Name = "sdLabel31";
			this.sdLabel31.Size = new System.Drawing.Size(504, 30);
			this.sdLabel31.TabIndex = 5;
			this.sdLabel31.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel31.WordSpace = 0F;
			// 
			// sdLabel32
			// 
			this.sdLabel32.CharSpace = 1F;
			this.sdLabel32.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(40)));
			this.sdLabel32.FontName = Report.SdFontName.Arial;
			this.sdLabel32.FontSize = 30F;
			this.sdLabel32.Location = new System.Drawing.Point(8, 200);
			this.sdLabel32.Name = "sdLabel32";
			this.sdLabel32.Size = new System.Drawing.Size(504, 30);
			this.sdLabel32.TabIndex = 4;
			this.sdLabel32.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel32.WordSpace = 0F;
			// 
			// sdLabel33
			// 
			this.sdLabel33.CharSpace = 1F;
			this.sdLabel33.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(30)));
			this.sdLabel33.FontName = Report.SdFontName.Arial;
			this.sdLabel33.FontSize = 30F;
			this.sdLabel33.Location = new System.Drawing.Point(8, 160);
			this.sdLabel33.Name = "sdLabel33";
			this.sdLabel33.Size = new System.Drawing.Size(504, 30);
			this.sdLabel33.TabIndex = 3;
			this.sdLabel33.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel33.WordSpace = 0F;
			// 
			// sdLabel34
			// 
			this.sdLabel34.CharSpace = 1F;
			this.sdLabel34.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(20)));
			this.sdLabel34.FontName = Report.SdFontName.Arial;
			this.sdLabel34.FontSize = 30F;
			this.sdLabel34.Location = new System.Drawing.Point(8, 120);
			this.sdLabel34.Name = "sdLabel34";
			this.sdLabel34.Size = new System.Drawing.Size(504, 30);
			this.sdLabel34.TabIndex = 2;
			this.sdLabel34.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel34.WordSpace = 0F;
			// 
			// sdLabel35
			// 
			this.sdLabel35.CharSpace = 1F;
			this.sdLabel35.FontColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(10)));
			this.sdLabel35.FontName = Report.SdFontName.Arial;
			this.sdLabel35.FontSize = 30F;
			this.sdLabel35.Location = new System.Drawing.Point(8, 80);
			this.sdLabel35.Name = "sdLabel35";
			this.sdLabel35.Size = new System.Drawing.Size(504, 30);
			this.sdLabel35.TabIndex = 1;
			this.sdLabel35.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel35.WordSpace = 0F;
			// 
			// sdLabel36
			// 
			this.sdLabel36.CharSpace = 1F;
			this.sdLabel36.FontColor = System.Drawing.Color.Black;
			this.sdLabel36.FontName = Report.SdFontName.Arial;
			this.sdLabel36.FontSize = 30F;
			this.sdLabel36.Location = new System.Drawing.Point(8, 40);
			this.sdLabel36.Name = "sdLabel36";
			this.sdLabel36.Size = new System.Drawing.Size(504, 30);
			this.sdLabel36.TabIndex = 0;
			this.sdLabel36.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			this.sdLabel36.WordSpace = 0F;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 24);
			this.button1.Name = "button1";
			this.button1.TabIndex = 15;
			this.button1.Text = "CreatePdf";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Items.AddRange(new object[] {
														   "SinglePage",
														   "OneColumn",
														   "TwoColumnLeft",
														   "TwoColumnRight"});
			this.comboBox1.Location = new System.Drawing.Point(16, 112);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 16;
			// 
			// comboBox2
			// 
			this.comboBox2.Items.AddRange(new object[] {
														   "UseNone",
														   "UseOutLines",
														   "UseThumbs",
														   "FullScreen"});
			this.comboBox2.Location = new System.Drawing.Point(152, 112);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(121, 21);
			this.comboBox2.TabIndex = 17;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 80);
			this.label1.Name = "label1";
			this.label1.TabIndex = 18;
			this.label1.Text = "Page Layout";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(152, 80);
			this.label2.Name = "label2";
			this.label2.TabIndex = 19;
			this.label2.Text = "Page Mode";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(408, 262);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label2,
																		  this.label1,
																		  this.comboBox2,
																		  this.comboBox1,
																		  this.button1,
																		  this.sdPage2,
																		  this.sdPage1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.sdPage1.ResumeLayout(false);
			this.sdLayoutPanel1.ResumeLayout(false);
			this.sdPage2.ResumeLayout(false);
			this.sdLayoutPanel2.ResumeLayout(false);
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
			SDReport sdReport1=new SDReport();
			sdReport1.PageLayout=(SDPageLayout)comboBox1.SelectedIndex;
			sdReport1.PageMode=(SDPageMode)comboBox2.SelectedIndex;
			sdReport1.BeginDoc();
			sdReport1.Print(sdPage1);
			sdReport1.Print(sdPage2);
			sdReport1.Print(sdPage1);
			sdReport1.Print(sdPage2);
			sdReport1.EndDoc();
			sdReport1.Dispose();

			Process acro=Process.Start("default.pdf");
			acro.WaitForExit();
			acro.Close();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			comboBox1.SelectedIndex=0;
			comboBox2.SelectedIndex=0;
		}
	}
}

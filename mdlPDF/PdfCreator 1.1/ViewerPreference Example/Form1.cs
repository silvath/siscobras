using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace ViewerPreference_Example
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Report.SDReport sdReport1;
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
		private System.Windows.Forms.CheckBox Toolbar;
		private System.Windows.Forms.CheckBox Menubar;
		private System.Windows.Forms.CheckBox WindowUI;
		private System.Windows.Forms.CheckBox FitWindow;
		private System.Windows.Forms.CheckBox CenterWindow;
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
			this.Toolbar = new System.Windows.Forms.CheckBox();
			this.Menubar = new System.Windows.Forms.CheckBox();
			this.WindowUI = new System.Windows.Forms.CheckBox();
			this.FitWindow = new System.Windows.Forms.CheckBox();
			this.CenterWindow = new System.Windows.Forms.CheckBox();
			this.sdPage2.SuspendLayout();
			this.sdLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// sdReport1
			// 
			this.sdReport1.Author = null;
			this.sdReport1.CreationDate = new System.DateTime(2002, 12, 27, 2, 9, 53, 10);
			this.sdReport1.Creator = null;
			this.sdReport1.FileName = "default.pdf";
			this.sdReport1.Keywords = null;
			this.sdReport1.ModDate = new System.DateTime(((long)(0)));
			this.sdReport1.Subject = null;
			this.sdReport1.Title = null;
			// 
			// sdPage2
			// 
			this.sdPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.sdLayoutPanel2});
			this.sdPage2.DockPadding.All = 32;
			this.sdPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage2.Location = new System.Drawing.Point(0, 240);
			this.sdPage2.Name = "sdPage2";
			this.sdPage2.Size = new System.Drawing.Size(596, 842);
			this.sdPage2.TabIndex = 15;
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
			this.button1.Location = new System.Drawing.Point(32, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(136, 23);
			this.button1.TabIndex = 16;
			this.button1.Text = "CreatePdf";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Toolbar
			// 
			this.Toolbar.Location = new System.Drawing.Point(24, 72);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.TabIndex = 17;
			this.Toolbar.Text = "HideToolbar";
			// 
			// Menubar
			// 
			this.Menubar.Location = new System.Drawing.Point(24, 96);
			this.Menubar.Name = "Menubar";
			this.Menubar.TabIndex = 18;
			this.Menubar.Text = "HideMenubar";
			// 
			// WindowUI
			// 
			this.WindowUI.Location = new System.Drawing.Point(24, 120);
			this.WindowUI.Name = "WindowUI";
			this.WindowUI.TabIndex = 19;
			this.WindowUI.Text = "HideWindowUI";
			// 
			// FitWindow
			// 
			this.FitWindow.Location = new System.Drawing.Point(24, 144);
			this.FitWindow.Name = "FitWindow";
			this.FitWindow.TabIndex = 20;
			this.FitWindow.Text = "FitWindow";
			// 
			// CenterWindow
			// 
			this.CenterWindow.Location = new System.Drawing.Point(24, 168);
			this.CenterWindow.Name = "CenterWindow";
			this.CenterWindow.TabIndex = 21;
			this.CenterWindow.Text = "CenterWindow";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 238);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.CenterWindow,
																		  this.FitWindow,
																		  this.WindowUI,
																		  this.Menubar,
																		  this.Toolbar,
																		  this.button1,
																		  this.sdPage2});
			this.Name = "Form1";
			this.Text = "Form1";
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
			if(Toolbar.Checked==true)
				sdReport1.ViewerPreference.HideToolbar=true;
			else
				sdReport1.ViewerPreference.HideToolbar=false;

			if(Menubar.Checked==true)
				sdReport1.ViewerPreference.HideMenubar=true;
			else
				sdReport1.ViewerPreference.HideMenubar=false;

			if(WindowUI.Checked==true)
				sdReport1.ViewerPreference.HideWindowUI=true;
			else
				sdReport1.ViewerPreference.HideWindowUI=false;

			if(FitWindow.Checked==true)
				sdReport1.ViewerPreference.FitWindow=true;
			else
				sdReport1.ViewerPreference.FitWindow=false;

			if(CenterWindow.Checked==true)
				sdReport1.ViewerPreference.CenterWindow=true;
			else
				sdReport1.ViewerPreference.CenterWindow=false;

			sdReport1.BeginDoc();
			sdReport1.Print(sdPage2);
			sdReport1.EndDoc();

			Process acro=Process.Start("default.pdf");
			acro.WaitForExit();
			acro.Close();
		}
	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MultiSizePages_Example
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
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private Report.SDPage sdPage1;
		private Report.SDLayoutPanel sdLayoutPanel1;
		private Report.SDText sdText1;
		private Report.SDPage sdPage2;
		private Report.SDLayoutPanel sdLayoutPanel2;
		private Report.SDText sdText2;
		private Report.SDPage sdPage3;
		private Report.SDLayoutPanel sdLayoutPanel3;
		private Report.SDText sdText3;
		private Report.SDPage sdPage4;
		private Report.SDLayoutPanel sdLayoutPanel4;
		private Report.SDText sdText4;
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.sdPage1 = new Report.SDPage();
			this.sdLayoutPanel1 = new Report.SDLayoutPanel();
			this.sdText1 = new Report.SDText();
			this.sdPage2 = new Report.SDPage();
			this.sdLayoutPanel2 = new Report.SDLayoutPanel();
			this.sdText2 = new Report.SDText();
			this.sdPage3 = new Report.SDPage();
			this.sdLayoutPanel3 = new Report.SDLayoutPanel();
			this.sdText3 = new Report.SDText();
			this.sdPage4 = new Report.SDPage();
			this.sdLayoutPanel4 = new Report.SDLayoutPanel();
			this.sdText4 = new Report.SDText();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.sdPage1.SuspendLayout();
			this.sdLayoutPanel1.SuspendLayout();
			this.sdPage2.SuspendLayout();
			this.sdLayoutPanel2.SuspendLayout();
			this.sdPage3.SuspendLayout();
			this.sdLayoutPanel3.SuspendLayout();
			this.sdPage4.SuspendLayout();
			this.sdLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// sdReport1
			// 
			this.sdReport1.Author = "Serdar Dirican";
			this.sdReport1.CreationDate = new System.DateTime(2002, 12, 26, 15, 7, 18, 203);
			this.sdReport1.Creator = "MultiSizePages Demo";
			this.sdReport1.FileName = "MultiSizePages.pdf";
			this.sdReport1.Keywords = null;
			this.sdReport1.ModDate = new System.DateTime(((long)(0)));
			this.sdReport1.PageMode = Report.SDPageMode.UseThumbs;
			this.sdReport1.Subject = null;
			this.sdReport1.Title = "PdfCreator MultiSizePages Example";
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
			this.saveFileDialog1.FileName = "MultiSizePages.pdf";
			this.saveFileDialog1.Filter = "PDF Files|*.pdf|All Files|*.*";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.tabPage1,
																					  this.tabPage2,
																					  this.tabPage3,
																					  this.tabPage4});
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(480, 449);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.sdPage1});
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(472, 423);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.sdPage2});
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(472, 423);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.sdPage3});
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(472, 423);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "tabPage3";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.sdPage4});
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(472, 423);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "tabPage4";
			// 
			// sdPage1
			// 
			this.sdPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.sdLayoutPanel1});
			this.sdPage1.DockPadding.All = 32;
			this.sdPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage1.Location = new System.Drawing.Point(8, 8);
			this.sdPage1.Name = "sdPage1";
			this.sdPage1.Size = new System.Drawing.Size(300, 400);
			this.sdPage1.TabIndex = 0;
			this.sdPage1.Text = "sdPage1";
			// 
			// sdLayoutPanel1
			// 
			this.sdLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.sdText1});
			this.sdLayoutPanel1.Location = new System.Drawing.Point(32, 40);
			this.sdLayoutPanel1.Name = "sdLayoutPanel1";
			this.sdLayoutPanel1.Size = new System.Drawing.Size(216, 312);
			this.sdLayoutPanel1.TabIndex = 0;
			this.sdLayoutPanel1.Text = "sdLayoutPanel1";
			// 
			// sdText1
			// 
			this.sdText1.CharSpace = 0F;
			this.sdText1.FontBold = true;
			this.sdText1.FontColor = System.Drawing.Color.Black;
			this.sdText1.FontName = Report.SdFontName.Arial;
			this.sdText1.FontSize = 22F;
			this.sdText1.Leading = 24F;
			this.sdText1.Lines = new string[] {
												  "PageWidth=300",
												  "PageHeight=400"};
			this.sdText1.Location = new System.Drawing.Point(16, 40);
			this.sdText1.Name = "sdText1";
			this.sdText1.Size = new System.Drawing.Size(184, 136);
			this.sdText1.TabIndex = 0;
			this.sdText1.WordSpace = 0F;
			// 
			// sdPage2
			// 
			this.sdPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.sdLayoutPanel2});
			this.sdPage2.DockPadding.All = 32;
			this.sdPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage2.Location = new System.Drawing.Point(8, 8);
			this.sdPage2.Name = "sdPage2";
			this.sdPage2.Size = new System.Drawing.Size(300, 600);
			this.sdPage2.TabIndex = 0;
			this.sdPage2.Text = "sdPage2";
			// 
			// sdLayoutPanel2
			// 
			this.sdLayoutPanel2.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.sdText2});
			this.sdLayoutPanel2.Location = new System.Drawing.Point(24, 32);
			this.sdLayoutPanel2.Name = "sdLayoutPanel2";
			this.sdLayoutPanel2.Size = new System.Drawing.Size(216, 312);
			this.sdLayoutPanel2.TabIndex = 1;
			this.sdLayoutPanel2.Text = "sdLayoutPanel2";
			// 
			// sdText2
			// 
			this.sdText2.CharSpace = 0F;
			this.sdText2.FontBold = true;
			this.sdText2.FontColor = System.Drawing.Color.Black;
			this.sdText2.FontName = Report.SdFontName.Arial;
			this.sdText2.FontSize = 22F;
			this.sdText2.Leading = 24F;
			this.sdText2.Lines = new string[] {
												  "PageWidth=300",
												  "PageHeight=600"};
			this.sdText2.Location = new System.Drawing.Point(16, 40);
			this.sdText2.Name = "sdText2";
			this.sdText2.Size = new System.Drawing.Size(184, 136);
			this.sdText2.TabIndex = 0;
			this.sdText2.WordSpace = 0F;
			// 
			// sdPage3
			// 
			this.sdPage3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.sdLayoutPanel3});
			this.sdPage3.DockPadding.All = 32;
			this.sdPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage3.Location = new System.Drawing.Point(8, 8);
			this.sdPage3.Name = "sdPage3";
			this.sdPage3.Size = new System.Drawing.Size(400, 400);
			this.sdPage3.TabIndex = 0;
			this.sdPage3.Text = "sdPage3";
			// 
			// sdLayoutPanel3
			// 
			this.sdLayoutPanel3.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.sdText3});
			this.sdLayoutPanel3.Location = new System.Drawing.Point(92, 44);
			this.sdLayoutPanel3.Name = "sdLayoutPanel3";
			this.sdLayoutPanel3.Size = new System.Drawing.Size(216, 312);
			this.sdLayoutPanel3.TabIndex = 1;
			this.sdLayoutPanel3.Text = "sdLayoutPanel3";
			// 
			// sdText3
			// 
			this.sdText3.CharSpace = 0F;
			this.sdText3.FontBold = true;
			this.sdText3.FontColor = System.Drawing.Color.Black;
			this.sdText3.FontName = Report.SdFontName.Arial;
			this.sdText3.FontSize = 22F;
			this.sdText3.Leading = 24F;
			this.sdText3.Lines = new string[] {
												  "PageWidth=400",
												  "PageHeight=400"};
			this.sdText3.Location = new System.Drawing.Point(16, 40);
			this.sdText3.Name = "sdText3";
			this.sdText3.Size = new System.Drawing.Size(184, 136);
			this.sdText3.TabIndex = 0;
			this.sdText3.WordSpace = 0F;
			// 
			// sdPage4
			// 
			this.sdPage4.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.sdLayoutPanel4});
			this.sdPage4.DockPadding.All = 32;
			this.sdPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage4.Location = new System.Drawing.Point(8, 8);
			this.sdPage4.Name = "sdPage4";
			this.sdPage4.Size = new System.Drawing.Size(600, 400);
			this.sdPage4.TabIndex = 0;
			this.sdPage4.Text = "sdPage4";
			// 
			// sdLayoutPanel4
			// 
			this.sdLayoutPanel4.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel4.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.sdText4});
			this.sdLayoutPanel4.Location = new System.Drawing.Point(64, 32);
			this.sdLayoutPanel4.Name = "sdLayoutPanel4";
			this.sdLayoutPanel4.Size = new System.Drawing.Size(216, 312);
			this.sdLayoutPanel4.TabIndex = 1;
			this.sdLayoutPanel4.Text = "sdLayoutPanel4";
			// 
			// sdText4
			// 
			this.sdText4.CharSpace = 0F;
			this.sdText4.FontBold = true;
			this.sdText4.FontColor = System.Drawing.Color.Black;
			this.sdText4.FontName = Report.SdFontName.Arial;
			this.sdText4.FontSize = 22F;
			this.sdText4.Leading = 24F;
			this.sdText4.Lines = new string[] {
												  "PageWidth=600",
												  "PageHeight=400"};
			this.sdText4.Location = new System.Drawing.Point(16, 40);
			this.sdText4.Name = "sdText4";
			this.sdText4.Size = new System.Drawing.Size(184, 136);
			this.sdText4.TabIndex = 0;
			this.sdText4.WordSpace = 0F;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 449);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tabControl1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.sdPage1.ResumeLayout(false);
			this.sdLayoutPanel1.ResumeLayout(false);
			this.sdPage2.ResumeLayout(false);
			this.sdLayoutPanel2.ResumeLayout(false);
			this.sdPage3.ResumeLayout(false);
			this.sdLayoutPanel3.ResumeLayout(false);
			this.sdPage4.ResumeLayout(false);
			this.sdLayoutPanel4.ResumeLayout(false);
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
			if(saveFileDialog1.ShowDialog()==DialogResult.OK)
			{
				sdReport1.BeginDoc();
				sdReport1.Print(sdPage1);
				sdReport1.Print(sdPage2);
				sdReport1.Print(sdPage3);
				sdReport1.Print(sdPage4);
				sdReport1.EndDoc();
			}
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}

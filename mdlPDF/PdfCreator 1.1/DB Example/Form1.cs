using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace DB_Example
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		OleDbConnection conn;		
		OleDbCommand command;
		OleDbDataAdapter adapter;
		DataSet dataset;
		int Pos=0;


		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private Report.SDReport sdReport1;
		private Report.SDPage sdPage1;
		private Report.SDLayoutPanel sdLayoutPanel1;
		private Report.SDText sdText1;
		private Report.SDRect sdRect1;
		private Report.SDLayoutPanel sdLayoutPanel2;
		private Report.SDRect sdRect2;
		private Report.SDGridPanel sdGridPanel1;
		private Report.SDText sdText2;
		private Report.SDText sdText3;
		private Report.SDText sdText4;
		private Report.SDText sdText5;
		private Report.SDText sdText6;
		private Report.SDLabel sdLabel1;
		private Report.SDLabel sdLabel2;
		private Report.SDLabel sdLabel3;
		private Report.SDLabel sdLabel4;
		private Report.SDLabel sdLabel5;
		
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
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.sdReport1 = new Report.SDReport();
			this.sdPage1 = new Report.SDPage();
			this.sdGridPanel1 = new Report.SDGridPanel();
			this.sdLabel5 = new Report.SDLabel();
			this.sdLabel4 = new Report.SDLabel();
			this.sdLabel3 = new Report.SDLabel();
			this.sdLabel2 = new Report.SDLabel();
			this.sdLabel1 = new Report.SDLabel();
			this.sdLayoutPanel2 = new Report.SDLayoutPanel();
			this.sdText6 = new Report.SDText();
			this.sdText5 = new Report.SDText();
			this.sdText4 = new Report.SDText();
			this.sdText3 = new Report.SDText();
			this.sdRect2 = new Report.SDRect();
			this.sdText2 = new Report.SDText();
			this.sdLayoutPanel1 = new Report.SDLayoutPanel();
			this.sdRect1 = new Report.SDRect();
			this.sdText1 = new Report.SDText();
			this.sdPage1.SuspendLayout();
			this.sdGridPanel1.SuspendLayout();
			this.sdLayoutPanel2.SuspendLayout();
			this.sdLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 165);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(653, 22);
			this.statusBar1.TabIndex = 0;
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
			this.menuItem2.Text = "Create &PDF";
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
			this.saveFileDialog1.Filter = "PDF Files|*.pdf|All Files|*.*";
			// 
			// sdReport1
			// 
			this.sdReport1.Author = "Serdar Dirican";
			this.sdReport1.CreationDate = new System.DateTime(2002, 12, 31, 3, 37, 14, 488);
			this.sdReport1.Creator = "DB Example";
			this.sdReport1.FileName = "default.pdf";
			this.sdReport1.Keywords = null;
			this.sdReport1.ModDate = new System.DateTime(((long)(0)));
			this.sdReport1.Subject = null;
			this.sdReport1.Title = "PdfCreator DB Example";
			// 
			// sdPage1
			// 
			this.sdPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.sdGridPanel1,
																				  this.sdLayoutPanel2,
																				  this.sdLayoutPanel1});
			this.sdPage1.DockPadding.All = 32;
			this.sdPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage1.Location = new System.Drawing.Point(8, 6);
			this.sdPage1.Name = "sdPage1";
			this.sdPage1.Size = new System.Drawing.Size(600, 700);
			this.sdPage1.TabIndex = 1;
			this.sdPage1.Text = "sdPage1";
			this.sdPage1.Visible = false;
			// 
			// sdGridPanel1
			// 
			this.sdGridPanel1.BackColor = System.Drawing.SystemColors.Window;
			this.sdGridPanel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.sdLabel5,
																					   this.sdLabel4,
																					   this.sdLabel3,
																					   this.sdLabel2,
																					   this.sdLabel1});
			this.sdGridPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdGridPanel1.Location = new System.Drawing.Point(32, 91);
			this.sdGridPanel1.Name = "sdGridPanel1";
			this.sdGridPanel1.Size = new System.Drawing.Size(536, 577);
			this.sdGridPanel1.TabIndex = 2;
			this.sdGridPanel1.TableColCount = 1;
			this.sdGridPanel1.TableRowCount = 28;
			this.sdGridPanel1.BeforePrintChild += new Report.SDPrintChildPanelEvent(this.sdGridPanel1_BeforePrintChild);
			// 
			// sdLabel5
			// 
			this.sdLabel5.CharSpace = 0F;
			this.sdLabel5.FontColor = System.Drawing.Color.Black;
			this.sdLabel5.FontName = Report.SdFontName.Arial;
			this.sdLabel5.FontSize = 12F;
			this.sdLabel5.Location = new System.Drawing.Point(468, 5);
			this.sdLabel5.Name = "sdLabel5";
			this.sdLabel5.Size = new System.Drawing.Size(66, 15);
			this.sdLabel5.TabIndex = 4;
			this.sdLabel5.Text = "State";
			this.sdLabel5.WordSpace = 0F;
			// 
			// sdLabel4
			// 
			this.sdLabel4.CharSpace = 0F;
			this.sdLabel4.FontColor = System.Drawing.Color.Black;
			this.sdLabel4.FontName = Report.SdFontName.Arial;
			this.sdLabel4.FontSize = 12F;
			this.sdLabel4.Location = new System.Drawing.Point(381, 5);
			this.sdLabel4.Name = "sdLabel4";
			this.sdLabel4.Size = new System.Drawing.Size(86, 15);
			this.sdLabel4.TabIndex = 3;
			this.sdLabel4.Text = "City";
			this.sdLabel4.WordSpace = 0F;
			// 
			// sdLabel3
			// 
			this.sdLabel3.CharSpace = 0F;
			this.sdLabel3.FontColor = System.Drawing.Color.Black;
			this.sdLabel3.FontName = Report.SdFontName.Arial;
			this.sdLabel3.FontSize = 12F;
			this.sdLabel3.Location = new System.Drawing.Point(224, 5);
			this.sdLabel3.Name = "sdLabel3";
			this.sdLabel3.Size = new System.Drawing.Size(157, 15);
			this.sdLabel3.TabIndex = 2;
			this.sdLabel3.Text = "Addr1";
			this.sdLabel3.WordSpace = 0F;
			// 
			// sdLabel2
			// 
			this.sdLabel2.CharSpace = 0F;
			this.sdLabel2.FontColor = System.Drawing.Color.Black;
			this.sdLabel2.FontName = Report.SdFontName.Arial;
			this.sdLabel2.FontSize = 12F;
			this.sdLabel2.Location = new System.Drawing.Point(50, 5);
			this.sdLabel2.Name = "sdLabel2";
			this.sdLabel2.Size = new System.Drawing.Size(175, 15);
			this.sdLabel2.TabIndex = 1;
			this.sdLabel2.Text = "Company";
			this.sdLabel2.WordSpace = 0F;
			// 
			// sdLabel1
			// 
			this.sdLabel1.CharSpace = 0F;
			this.sdLabel1.FontColor = System.Drawing.Color.Black;
			this.sdLabel1.FontName = Report.SdFontName.Arial;
			this.sdLabel1.FontSize = 12F;
			this.sdLabel1.Location = new System.Drawing.Point(0, 5);
			this.sdLabel1.Name = "sdLabel1";
			this.sdLabel1.Size = new System.Drawing.Size(50, 15);
			this.sdLabel1.TabIndex = 0;
			this.sdLabel1.Text = "Custno";
			this.sdLabel1.WordSpace = 0F;
			// 
			// sdLayoutPanel2
			// 
			this.sdLayoutPanel2.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.sdText6,
																						 this.sdText5,
																						 this.sdText4,
																						 this.sdText3,
																						 this.sdRect2,
																						 this.sdText2});
			this.sdLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.sdLayoutPanel2.Location = new System.Drawing.Point(32, 66);
			this.sdLayoutPanel2.Name = "sdLayoutPanel2";
			this.sdLayoutPanel2.Size = new System.Drawing.Size(536, 25);
			this.sdLayoutPanel2.TabIndex = 1;
			// 
			// sdText6
			// 
			this.sdText6.CharSpace = 0F;
			this.sdText6.FontBold = true;
			this.sdText6.FontColor = System.Drawing.Color.Navy;
			this.sdText6.FontItalic = true;
			this.sdText6.FontName = Report.SdFontName.TimesRoman;
			this.sdText6.FontSize = 12F;
			this.sdText6.Leading = 14F;
			this.sdText6.Lines = new string[] {
												  "State"};
			this.sdText6.Location = new System.Drawing.Point(469, 8);
			this.sdText6.Name = "sdText6";
			this.sdText6.Size = new System.Drawing.Size(66, 15);
			this.sdText6.TabIndex = 4;
			this.sdText6.WordSpace = 0F;
			// 
			// sdText5
			// 
			this.sdText5.CharSpace = 0F;
			this.sdText5.FontBold = true;
			this.sdText5.FontColor = System.Drawing.Color.Navy;
			this.sdText5.FontItalic = true;
			this.sdText5.FontName = Report.SdFontName.TimesRoman;
			this.sdText5.FontSize = 12F;
			this.sdText5.Leading = 14F;
			this.sdText5.Lines = new string[] {
												  "Addr1"};
			this.sdText5.Location = new System.Drawing.Point(224, 8);
			this.sdText5.Name = "sdText5";
			this.sdText5.Size = new System.Drawing.Size(157, 15);
			this.sdText5.TabIndex = 3;
			this.sdText5.WordSpace = 0F;
			// 
			// sdText4
			// 
			this.sdText4.CharSpace = 0F;
			this.sdText4.FontBold = true;
			this.sdText4.FontColor = System.Drawing.Color.Navy;
			this.sdText4.FontItalic = true;
			this.sdText4.FontName = Report.SdFontName.TimesRoman;
			this.sdText4.FontSize = 12F;
			this.sdText4.Leading = 14F;
			this.sdText4.Lines = new string[] {
												  "City"};
			this.sdText4.Location = new System.Drawing.Point(381, 8);
			this.sdText4.Name = "sdText4";
			this.sdText4.Size = new System.Drawing.Size(86, 15);
			this.sdText4.TabIndex = 2;
			this.sdText4.WordSpace = 0F;
			// 
			// sdText3
			// 
			this.sdText3.CharSpace = 0F;
			this.sdText3.FontBold = true;
			this.sdText3.FontColor = System.Drawing.Color.Navy;
			this.sdText3.FontItalic = true;
			this.sdText3.FontName = Report.SdFontName.TimesRoman;
			this.sdText3.FontSize = 12F;
			this.sdText3.Leading = 14F;
			this.sdText3.Lines = new string[] {
												  "Company"};
			this.sdText3.Location = new System.Drawing.Point(50, 8);
			this.sdText3.Name = "sdText3";
			this.sdText3.Size = new System.Drawing.Size(175, 15);
			this.sdText3.TabIndex = 1;
			this.sdText3.WordSpace = 0F;
			// 
			// sdRect2
			// 
			this.sdRect2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdRect2.DrawLine = true;
			this.sdRect2.FillColor = System.Drawing.Color.Transparent;
			this.sdRect2.LineColor = System.Drawing.Color.Black;
			this.sdRect2.LineStyle = Report.PenStyle.Solid;
			this.sdRect2.LineWidth = 2F;
			this.sdRect2.Location = new System.Drawing.Point(0, 22);
			this.sdRect2.Name = "sdRect2";
			this.sdRect2.Size = new System.Drawing.Size(536, 3);
			this.sdRect2.TabIndex = 0;
			this.sdRect2.Text = "sdRect2";
			// 
			// sdText2
			// 
			this.sdText2.CharSpace = 0F;
			this.sdText2.FontBold = true;
			this.sdText2.FontColor = System.Drawing.Color.Navy;
			this.sdText2.FontItalic = true;
			this.sdText2.FontName = Report.SdFontName.TimesRoman;
			this.sdText2.FontSize = 12F;
			this.sdText2.Leading = 14F;
			this.sdText2.Lines = new string[] {
												  "CustNo."};
			this.sdText2.Location = new System.Drawing.Point(0, 8);
			this.sdText2.Name = "sdText2";
			this.sdText2.Size = new System.Drawing.Size(50, 15);
			this.sdText2.TabIndex = 0;
			this.sdText2.WordSpace = 0F;
			// 
			// sdLayoutPanel1
			// 
			this.sdLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.sdRect1,
																						 this.sdText1});
			this.sdLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.sdLayoutPanel1.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel1.Name = "sdLayoutPanel1";
			this.sdLayoutPanel1.Size = new System.Drawing.Size(536, 34);
			this.sdLayoutPanel1.TabIndex = 0;
			this.sdLayoutPanel1.Text = "sdLayoutPanel1";
			// 
			// sdRect1
			// 
			this.sdRect1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sdRect1.DrawLine = true;
			this.sdRect1.FillColor = System.Drawing.Color.Transparent;
			this.sdRect1.LineColor = System.Drawing.Color.Black;
			this.sdRect1.LineStyle = Report.PenStyle.Solid;
			this.sdRect1.LineWidth = 2F;
			this.sdRect1.Location = new System.Drawing.Point(0, 31);
			this.sdRect1.Name = "sdRect1";
			this.sdRect1.Size = new System.Drawing.Size(536, 3);
			this.sdRect1.TabIndex = 1;
			this.sdRect1.Text = "sdRect1";
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
												  "PdfCreator DBExample"};
			this.sdText1.Location = new System.Drawing.Point(146, 0);
			this.sdText1.Name = "sdText1";
			this.sdText1.Size = new System.Drawing.Size(270, 30);
			this.sdText1.TabIndex = 0;
			this.sdText1.WordSpace = 0F;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(653, 187);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.statusBar1,
																		  this.sdPage1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.sdPage1.ResumeLayout(false);
			this.sdGridPanel1.ResumeLayout(false);
			this.sdLayoutPanel2.ResumeLayout(false);
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

		private void sdGridPanel1_BeforePrintChild(object sender, Report.SDPrintChildPanelEventArgs arg)
		{
			if(Pos<dataset.Tables[0].Rows.Count)
			{
				sdLabel3.Text=dataset.Tables[0].Rows[Pos].ItemArray.GetValue(0).ToString();
				sdLabel2.Text=dataset.Tables[0].Rows[Pos].ItemArray.GetValue(1).ToString();
				sdLabel4.Text=dataset.Tables[0].Rows[Pos].ItemArray.GetValue(2).ToString();
				sdLabel1.Text=dataset.Tables[0].Rows[Pos].ItemArray.GetValue(3).ToString();
				sdLabel5.Text=dataset.Tables[0].Rows[Pos].ItemArray.GetValue(4).ToString();
				Pos++;
			}
			else
			{
				sdLabel1.Printable=false;
				sdLabel2.Printable=false;
				sdLabel3.Printable=false;
				sdLabel4.Printable=false;
				sdLabel5.Printable=false;
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			
			conn=new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=../../vt1.mdb");
			command=new OleDbCommand("SELECT Addr1, Company, City, CustNo, State FROM customer",conn);
			adapter=new OleDbDataAdapter();
			dataset=new DataSet();
			conn.Open();
			saveFileDialog1.FileName="DbExample.pdf";
			if(saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				sdReport1.FileName=saveFileDialog1.FileName;
				sdReport1.BeginDoc();
				adapter.SelectCommand=command;				
				adapter.Fill(dataset,"customer");				
				while(Pos<dataset.Tables[0].Rows.Count)
					sdReport1.Print(sdPage1);
				conn.Close();
				sdReport1.EndDoc();
			}
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}

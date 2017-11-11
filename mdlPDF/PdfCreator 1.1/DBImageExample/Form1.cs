using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using Report;
using System.IO;

namespace DBImageExample
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
		SDOutlineEntry FOutline;
		string S;
		int FPage;

		private System.Windows.Forms.Panel panel1;
		private Report.SDPage sdPage1;
		private Report.SDLayoutPanel sdLayoutPanel1;
		private Report.SDLabel sdLabel1;
		private Report.SDGridPanel sdGridPanel1;
		private Report.SDRect sdRect1;
		private Report.SDLabel sdLabel3;
		private Report.SDImage ProductPicture;
		private Report.SDLabel lblName;
		private Report.SDText textBriefDesck;
		private Report.SDLabel lblItemNo;
		private Report.SDReport sdReport1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.StatusBar statusBar1;
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.sdPage1 = new Report.SDPage();
			this.sdGridPanel1 = new Report.SDGridPanel();
			this.lblItemNo = new Report.SDLabel();
			this.sdLabel3 = new Report.SDLabel();
			this.textBriefDesck = new Report.SDText();
			this.lblName = new Report.SDLabel();
			this.ProductPicture = new Report.SDImage();
			this.sdRect1 = new Report.SDRect();
			this.sdLayoutPanel1 = new Report.SDLayoutPanel();
			this.sdLabel1 = new Report.SDLabel();
			this.sdReport1 = new Report.SDReport();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.panel1.SuspendLayout();
			this.sdPage1.SuspendLayout();
			this.sdGridPanel1.SuspendLayout();
			this.sdLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.sdPage1});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(544, 266);
			this.panel1.TabIndex = 0;
			// 
			// sdPage1
			// 
			this.sdPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.sdGridPanel1,
																				  this.sdLayoutPanel1});
			this.sdPage1.DockPadding.All = 32;
			this.sdPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage1.Location = new System.Drawing.Point(8, 8);
			this.sdPage1.Name = "sdPage1";
			this.sdPage1.Size = new System.Drawing.Size(600, 700);
			this.sdPage1.TabIndex = 0;
			this.sdPage1.Text = "sdPage1";
			this.sdPage1.Visible = false;
			this.sdPage1.PrintPage += new Report.SDPrintPageEvent(this.sdPage1_PrintPage);
			// 
			// sdGridPanel1
			// 
			this.sdGridPanel1.BackColor = System.Drawing.SystemColors.Window;
			this.sdGridPanel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.lblItemNo,
																					   this.sdLabel3,
																					   this.textBriefDesck,
																					   this.lblName,
																					   this.ProductPicture,
																					   this.sdRect1});
			this.sdGridPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdGridPanel1.Location = new System.Drawing.Point(32, 80);
			this.sdGridPanel1.Name = "sdGridPanel1";
			this.sdGridPanel1.Size = new System.Drawing.Size(536, 588);
			this.sdGridPanel1.TabIndex = 1;
			this.sdGridPanel1.TableColCount = 2;
			this.sdGridPanel1.TableRowCount = 3;
			this.sdGridPanel1.Text = "sdGridPanel1";
			this.sdGridPanel1.BeforePrintChild += new Report.SDPrintChildPanelEvent(this.sdGridPanel1_BeforePrintChild);
			// 
			// lblItemNo
			// 
			this.lblItemNo.CharSpace = 0F;
			this.lblItemNo.FontColor = System.Drawing.Color.Black;
			this.lblItemNo.FontName = Report.SdFontName.Arial;
			this.lblItemNo.FontSize = 12F;
			this.lblItemNo.Location = new System.Drawing.Point(192, 40);
			this.lblItemNo.Name = "lblItemNo";
			this.lblItemNo.Size = new System.Drawing.Size(64, 30);
			this.lblItemNo.TabIndex = 5;
			this.lblItemNo.Text = "lblItemNo";
			this.lblItemNo.WordSpace = 0F;
			// 
			// sdLabel3
			// 
			this.sdLabel3.CharSpace = 0F;
			this.sdLabel3.FontBold = true;
			this.sdLabel3.FontColor = System.Drawing.Color.Black;
			this.sdLabel3.FontName = Report.SdFontName.Arial;
			this.sdLabel3.FontSize = 12F;
			this.sdLabel3.Location = new System.Drawing.Point(192, 8);
			this.sdLabel3.Name = "sdLabel3";
			this.sdLabel3.Size = new System.Drawing.Size(56, 24);
			this.sdLabel3.TabIndex = 4;
			this.sdLabel3.Text = "Item No";
			this.sdLabel3.WordSpace = 0F;
			// 
			// textBriefDesck
			// 
			this.textBriefDesck.CharSpace = 0F;
			this.textBriefDesck.FontColor = System.Drawing.Color.Black;
			this.textBriefDesck.FontName = Report.SdFontName.Arial;
			this.textBriefDesck.FontSize = 12F;
			this.textBriefDesck.Leading = 14F;
			this.textBriefDesck.Lines = new string[] {
														 "Briefdesck"};
			this.textBriefDesck.Location = new System.Drawing.Point(8, 166);
			this.textBriefDesck.Name = "textBriefDesck";
			this.textBriefDesck.Size = new System.Drawing.Size(256, 30);
			this.textBriefDesck.TabIndex = 3;
			this.textBriefDesck.WordSpace = 0F;
			this.textBriefDesck.WordWrap = true;
			// 
			// lblName
			// 
			this.lblName.CharSpace = 0F;
			this.lblName.FontBold = true;
			this.lblName.FontColor = System.Drawing.Color.Navy;
			this.lblName.FontName = Report.SdFontName.Arial;
			this.lblName.FontSize = 14F;
			this.lblName.Location = new System.Drawing.Point(8, 136);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(248, 30);
			this.lblName.TabIndex = 2;
			this.lblName.Text = "Name";
			this.lblName.WordSpace = 0F;
			// 
			// ProductPicture
			// 
			this.ProductPicture.Location = new System.Drawing.Point(16, 8);
			this.ProductPicture.Name = "ProductPicture";
			this.ProductPicture.Picture = null;
			this.ProductPicture.SharedImage = false;
			this.ProductPicture.Size = new System.Drawing.Size(140, 115);
			this.ProductPicture.TabIndex = 1;
			// 
			// sdRect1
			// 
			this.sdRect1.FillColor = System.Drawing.Color.Transparent;
			this.sdRect1.LineColor = System.Drawing.Color.Black;
			this.sdRect1.LineStyle = Report.PenStyle.Solid;
			this.sdRect1.LineWidth = 0F;
			this.sdRect1.Location = new System.Drawing.Point(8, 0);
			this.sdRect1.Name = "sdRect1";
			this.sdRect1.Size = new System.Drawing.Size(160, 128);
			this.sdRect1.TabIndex = 0;
			this.sdRect1.Text = "sdRect1";
			// 
			// sdLayoutPanel1
			// 
			this.sdLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.sdLabel1});
			this.sdLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.sdLayoutPanel1.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel1.Name = "sdLayoutPanel1";
			this.sdLayoutPanel1.Size = new System.Drawing.Size(536, 48);
			this.sdLayoutPanel1.TabIndex = 0;
			this.sdLayoutPanel1.Text = "sdLayoutPanel1";
			// 
			// sdLabel1
			// 
			this.sdLabel1.CharSpace = 0F;
			this.sdLabel1.FontBold = true;
			this.sdLabel1.FontColor = System.Drawing.Color.Black;
			this.sdLabel1.FontName = Report.SdFontName.Arial;
			this.sdLabel1.FontSize = 24F;
			this.sdLabel1.Location = new System.Drawing.Point(80, 8);
			this.sdLabel1.Name = "sdLabel1";
			this.sdLabel1.Size = new System.Drawing.Size(400, 30);
			this.sdLabel1.TabIndex = 0;
			this.sdLabel1.Text = "PdfCreator DBImage Example";
			this.sdLabel1.WordSpace = 0F;
			// 
			// sdReport1
			// 
			this.sdReport1.Author = "Serdar Dirican";
			this.sdReport1.CreationDate = new System.DateTime(2003, 1, 31, 6, 10, 28, 791);
			this.sdReport1.Creator = "DBImage Example";
			this.sdReport1.FileName = "";
			this.sdReport1.Keywords = null;
			this.sdReport1.ModDate = new System.DateTime(((long)(0)));
			this.sdReport1.PageLayout = Report.SDPageLayout.OneColumn;
			this.sdReport1.PageMode = Report.SDPageMode.UseOutlines;
			this.sdReport1.Subject = null;
			this.sdReport1.Title = "PdfCreator DBImage Example";
			this.sdReport1.UseOutlines = true;
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
			this.saveFileDialog1.Filter = "PDF Files|*.pdf|All Files|*.*";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 244);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(544, 22);
			this.statusBar1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.statusBar1,
																		  this.panel1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.sdPage1.ResumeLayout(false);
			this.sdGridPanel1.ResumeLayout(false);
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

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			conn=new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=../../storeDB.mdb");
			command=new OleDbCommand("SELECT Products.* FROM Products",conn);
			adapter=new OleDbDataAdapter();
			dataset=new DataSet();
		
			S=Path.GetFullPath(@"../../image");
			conn.Open();
			saveFileDialog1.FileName="DBImageExample.pdf";
			if(saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				sdReport1.FileName=saveFileDialog1.FileName;
				sdReport1.BeginDoc();
				adapter.SelectCommand=command;				
				adapter.Fill(dataset,"customer");				
				while(Pos<dataset.Tables[0].Rows.Count)
					sdReport1.Print(sdPage1);

				statusBar1.Text="Writing document...";
				conn.Close();
				sdReport1.EndDoc();
				statusBar1.Text="End...";
			}
		}

		private void sdPage1_PrintPage(object sender, Report.SDPrintPageEventArgs arg)
		{
			Report.SDDestination Dest;
			if(sdReport1.PageNumber==1)
			{				
				Dest=sdReport1.CreateDestination();
				Dest.DestinationType=Report.PdfDestinationType.XYZ;
				Dest.Zoom=1;
				sdReport1.OpenAction(Dest);
			}
			FOutline=sdReport1.OutlineRoot.AddChild();
			FOutline.Dest=sdReport1.CreateDestination();
			FOutline.Dest.Top=0;
			FOutline.Title="Page "+sdReport1.PageNumber.ToString();
		}

		private void sdGridPanel1_BeforePrintChild(object sender, Report.SDPrintChildPanelEventArgs arg)
		{
			SDOutlineEntry Fentry;			
			if(Pos<dataset.Tables[0].Rows.Count)
			{
				FPage++;
				statusBar1.Text="Creating page "+FPage.ToString();

				lblItemNo.Text=dataset.Tables[0].Rows[Pos].ItemArray.GetValue(0).ToString();
				lblName.Text=dataset.Tables[0].Rows[Pos].ItemArray.GetValue(1).ToString();
				ProductPicture.Picture=new Bitmap(S+"//"+dataset.Tables[0].Rows[Pos].ItemArray.GetValue(2).ToString());
				textBriefDesck.Lines[0]=dataset.Tables[0].Rows[Pos].ItemArray.GetValue(3).ToString();
				Pos++;

				Fentry=FOutline.AddChild();
				Fentry.Dest=sdReport1.CreateDestination();
				Fentry.Dest.Top=arg.Rect.Top;
				Fentry.Dest.Left=arg.Rect.Left;
				Fentry.Title=lblName.Text;
			}
			else
			{
				lblItemNo.Printable=false;
				lblName.Printable=false;
				ProductPicture.Printable=false;
				textBriefDesck.Printable=false;
				sdRect1.Printable=false;
				sdLabel3.Printable=false;
			}
		}
	}
}

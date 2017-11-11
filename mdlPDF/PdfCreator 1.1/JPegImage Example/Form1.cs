using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace JPegImage_Example
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Report.SDReport sdReport1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private Report.SDPage sdPage1;
		private Report.SDLayoutPanel sdLayoutPanel1;
		private Report.SDLabel sdLabel1;
		private Report.SDLayoutPanel sdLayoutPanel2;
		private Report.SDJPegImage sdjPegImage1;
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.sdPage1 = new Report.SDPage();
			this.sdLayoutPanel1 = new Report.SDLayoutPanel();
			this.sdLabel1 = new Report.SDLabel();
			this.sdLayoutPanel2 = new Report.SDLayoutPanel();
			this.sdjPegImage1 = new Report.SDJPegImage();
			this.panel1.SuspendLayout();
			this.sdPage1.SuspendLayout();
			this.sdLayoutPanel1.SuspendLayout();
			this.sdLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// sdReport1
			// 
			this.sdReport1.Author = "Serdar Dirican";
			this.sdReport1.CreationDate = new System.DateTime(2003, 1, 24, 3, 43, 58, 390);
			this.sdReport1.Creator = "JPegImage Example";
			this.sdReport1.FileName = "default.pdf";
			this.sdReport1.Keywords = null;
			this.sdReport1.ModDate = new System.DateTime(((long)(0)));
			this.sdReport1.Subject = null;
			this.sdReport1.Title = null;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.button1,
																				 this.button2,
																				 this.checkBox1});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(292, 32);
			this.panel1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "Show Pdf";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(80, 0);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Load Picture";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(168, 0);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "Stretch";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "JPEG Image File (*.jpg)|*.jpg|JPEG Image File (*.jpeg)|*.jpeg";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "pdf";
			this.saveFileDialog1.FileName = "doc1";
			// 
			// sdPage1
			// 
			this.sdPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.sdLayoutPanel2,
																				  this.sdLayoutPanel1});
			this.sdPage1.DockPadding.All = 32;
			this.sdPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdPage1.Location = new System.Drawing.Point(8, 48);
			this.sdPage1.Name = "sdPage1";
			this.sdPage1.Size = new System.Drawing.Size(700, 873);
			this.sdPage1.TabIndex = 1;
			this.sdPage1.Text = "sdPage1";
			this.sdPage1.PrintPage += new Report.SDPrintPageEvent(this.sdPage1_PrintPage);
			// 
			// sdLayoutPanel1
			// 
			this.sdLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.sdLabel1});
			this.sdLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.sdLayoutPanel1.Location = new System.Drawing.Point(32, 32);
			this.sdLayoutPanel1.Name = "sdLayoutPanel1";
			this.sdLayoutPanel1.Size = new System.Drawing.Size(636, 22);
			this.sdLayoutPanel1.TabIndex = 0;
			// 
			// sdLabel1
			// 
			this.sdLabel1.CharSpace = 0F;
			this.sdLabel1.FontColor = System.Drawing.Color.Black;
			this.sdLabel1.FontName = Report.SdFontName.Arial;
			this.sdLabel1.FontSize = 12F;
			this.sdLabel1.Location = new System.Drawing.Point(2, 2);
			this.sdLabel1.Name = "sdLabel1";
			this.sdLabel1.Size = new System.Drawing.Size(635, 17);
			this.sdLabel1.TabIndex = 0;
			this.sdLabel1.Text = "PdfCreator Jpeg Image Example";
			this.sdLabel1.WordSpace = 0F;
			// 
			// sdLayoutPanel2
			// 
			this.sdLayoutPanel2.BackColor = System.Drawing.SystemColors.Window;
			this.sdLayoutPanel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.sdjPegImage1});
			this.sdLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sdLayoutPanel2.Location = new System.Drawing.Point(32, 54);
			this.sdLayoutPanel2.Name = "sdLayoutPanel2";
			this.sdLayoutPanel2.Size = new System.Drawing.Size(636, 787);
			this.sdLayoutPanel2.TabIndex = 1;
			// 
			// sdjPegImage1
			// 
			this.sdjPegImage1.BackColor = System.Drawing.SystemColors.Window;
			this.sdjPegImage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.sdjPegImage1.Location = new System.Drawing.Point(16, 6);
			this.sdjPegImage1.Name = "sdjPegImage1";
			this.sdjPegImage1.Picture = null;
			this.sdjPegImage1.Size = new System.Drawing.Size(603, 780);
			this.sdjPegImage1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.sdPage1,
																		  this.panel1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.sdPage1.ResumeLayout(false);
			this.sdLayoutPanel1.ResumeLayout(false);
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

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			sdjPegImage1.Stretch=checkBox1.Checked;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			saveFileDialog1.FileName=openFileDialog1.FileName+".pdf";
			if(saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				sdReport1.FileName=saveFileDialog1.FileName;
				sdReport1.BeginDoc();
				sdReport1.Print(sdPage1);
				sdReport1.EndDoc();

				Process acro=Process.Start(saveFileDialog1.FileName);
				acro.WaitForExit();
				acro.Close();
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog()==DialogResult.OK)
			{
				sdjPegImage1.Picture=new Bitmap(openFileDialog1.FileName);
				sdLabel1.Text=openFileDialog1.FileName;
				sdjPegImage1.Refresh();
			}
		}

		private void sdPage1_PrintPage(object sender, Report.SDPrintPageEventArgs arg)
		{
			Report.SDDestination Dest;
			Dest=sdReport1.CreateDestination();
			Dest.DestinationType=Report.PdfDestinationType.XYZ;
			Dest.Left=-10;
			Dest.Top=-10;
			Dest.Zoom=1;
			sdReport1.OpenAction(Dest);
		}
	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace executavel
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private mdlComponentesGraficos.TextBox textBox1;
		private mdlComponentesGraficos.TextBox textBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private mdlComponentesGraficos.TextBox textBox3;
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
			this.textBox1 = new mdlComponentesGraficos.TextBox();
			this.textBox2 = new mdlComponentesGraficos.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox3 = new mdlComponentesGraficos.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(15, 22);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(681, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "Texto Plano";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(15, 97);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(681, 20);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(23, 58);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "Cifrar";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(23, 133);
			this.button2.Name = "button2";
			this.button2.TabIndex = 3;
			this.button2.Text = "Decifrar";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(15, 172);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(681, 20);
			this.textBox3.TabIndex = 4;
			this.textBox3.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(730, 215);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cifrador/Decifrador SISCOBRAS";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			textBox2.Text = mdlCriptografia.clsCriptografia.strCifraString(textBox1.Text);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			textBox3.Text = mdlCriptografia.clsCriptografia.strDecifraString(textBox2.Text);
		}
	}
}

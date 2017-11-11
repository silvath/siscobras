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
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.pictureBox1.Location = new System.Drawing.Point(8, 24);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(448, 224);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// comboBox1
			// 
			this.comboBox1.Items.AddRange(new object[] {
														   "Assistente",
														   "FormFixo",
														   "Preferencias",
														   "Splash",
														   "Registro"});
			this.comboBox1.Location = new System.Drawing.Point(160, 264);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(224, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Text = "Assistente";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(208, 304);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "Testar";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 421);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Form1";
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
			if (comboBox1.Text == "Assistente")
			{
				pictureBox1.Image = mdlControladoraImagens.clsControladoraImagens.retornaImagem(mdlControladoraImagens.LOCALIMAGEM.ASSISTENTE);
			}
			else if (comboBox1.Text == "FormFixo")
			{
				pictureBox1.Image = mdlControladoraImagens.clsControladoraImagens.retornaImagem(mdlControladoraImagens.LOCALIMAGEM.FORMFIXO);
			}
			else if (comboBox1.Text == "Preferencias")
			{
				pictureBox1.Image = mdlControladoraImagens.clsControladoraImagens.retornaImagem(mdlControladoraImagens.LOCALIMAGEM.PREFERENCIAS);
			}
			else if (comboBox1.Text == "Splash")
			{
				pictureBox1.Image = mdlControladoraImagens.clsControladoraImagens.retornaImagem(mdlControladoraImagens.LOCALIMAGEM.SPLASH);
			}
			else if (comboBox1.Text == "Registro")
			{
				pictureBox1.Image = mdlControladoraImagens.clsControladoraImagens.retornaImagem(mdlControladoraImagens.LOCALIMAGEM.REGISTRO);
			}
			else
			{
				pictureBox1.Image = null;
			}
		}
	}
}

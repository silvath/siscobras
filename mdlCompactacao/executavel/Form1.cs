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
		mdlTratamentoErro.clsTratamentoErro m_clsErro = new mdlTratamentoErro.clsTratamentoErro();
		private mdlComponentesGraficos.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(96, 48);
			this.textBox1.Mask = false;
			this.textBox1.MaskText = "";
			this.textBox1.Name = "textBox1";
			this.textBox1.OnlyNumbers = false;
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "Nomezip";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(112, 144);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "Criar Zip";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(112, 176);
			this.button2.Name = "button2";
			this.button2.TabIndex = 2;
			this.button2.Text = "Unzipar";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(112, 208);
			this.button3.Name = "button3";
			this.button3.TabIndex = 3;
			this.button3.Text = "Arquivos";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
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
			System.Collections.ArrayList listaArquivos = new System.Collections.ArrayList();
			System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();
			fileDialog.Multiselect = true;
			if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				foreach (string files in fileDialog.FileNames)
				{
					listaArquivos.Add(files);
				}
				if (textBox1.Text.Trim() != "")
				{
					mdlCompactacao.clsCompactacao cls_Zip = new mdlCompactacao.clsCompactacao(ref m_clsErro);
					cls_Zip.compacta(ref listaArquivos,textBox1.Text.Trim(), mdlCompactacao.NIVELCOMPACTACAO.MAXIMO);
				}
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			string strSavedDir = System.Environment.CurrentDirectory;
			System.Environment.CurrentDirectory = "C:\\TEMP\\";

			System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();
			fileDialog.Multiselect = false;
			if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				mdlCompactacao.clsCompactacao cls_Zip = new mdlCompactacao.clsCompactacao(ref m_clsErro);
				cls_Zip.descompacta(fileDialog.FileName);
			}

			System.Environment.CurrentDirectory = strSavedDir;
		}
		private void button3_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();
			fileDialog.Multiselect = false;
			if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				mdlCompactacao.clsCompactacao cls_Zip = new mdlCompactacao.clsCompactacao(ref m_clsErro);
				string[] arrayTeste = cls_Zip.retornaListaDeArquivos(fileDialog.FileName);
				foreach (string strFileName in arrayTeste)
				{
					MessageBox.Show(strFileName, this.Text);
				}
			}
		}
	}
}

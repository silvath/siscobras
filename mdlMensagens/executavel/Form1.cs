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
		#region MAIN
			/// <summary>
			/// The main entry point for the application.
			/// </summary>
			[STAThread]
			static void Main() 
			{
				Application.Run(new Form1());
			}
		#endregion

		#region Atributes
			private System.Windows.Forms.Button button1;
			private System.Windows.Forms.Button button2;
			private System.Windows.Forms.Button button3;
			private System.Windows.Forms.Button button4;
			private System.Windows.Forms.Button button5;
			private System.Windows.Forms.GroupBox m_gbRepositorioMensagens;
			private System.Windows.Forms.TextBox m_txtRepositorioRetorno;
			private System.Windows.Forms.Label m_lbRepositorioRetorno;
			private System.Windows.Forms.Label m_lbRepositorioCultura;
			private System.Windows.Forms.Label m_lbRepositorioMensagem;
			private System.Windows.Forms.ComboBox m_cbRepositorioCultura;
			private System.Windows.Forms.ComboBox m_cbRepositorioMensagem;
		private System.Windows.Forms.Button m_btGetMensagemCultura;
		private System.Windows.Forms.Button m_btGetMensagem;
			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors 
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
		#endregion
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.m_gbRepositorioMensagens = new System.Windows.Forms.GroupBox();
			this.m_btGetMensagem = new System.Windows.Forms.Button();
			this.m_cbRepositorioMensagem = new System.Windows.Forms.ComboBox();
			this.m_lbRepositorioMensagem = new System.Windows.Forms.Label();
			this.m_lbRepositorioCultura = new System.Windows.Forms.Label();
			this.m_cbRepositorioCultura = new System.Windows.Forms.ComboBox();
			this.m_lbRepositorioRetorno = new System.Windows.Forms.Label();
			this.m_txtRepositorioRetorno = new System.Windows.Forms.TextBox();
			this.m_btGetMensagemCultura = new System.Windows.Forms.Button();
			this.m_gbRepositorioMensagens.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 8);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "Normal";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 32);
			this.button2.Name = "button2";
			this.button2.TabIndex = 1;
			this.button2.Text = "Error";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 56);
			this.button3.Name = "button3";
			this.button3.TabIndex = 2;
			this.button3.Text = "Exclamation";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(8, 80);
			this.button4.Name = "button4";
			this.button4.TabIndex = 3;
			this.button4.Text = "Information";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(8, 104);
			this.button5.Name = "button5";
			this.button5.TabIndex = 4;
			this.button5.Text = "Question";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// m_gbRepositorioMensagens
			// 
			this.m_gbRepositorioMensagens.Controls.Add(this.m_btGetMensagem);
			this.m_gbRepositorioMensagens.Controls.Add(this.m_cbRepositorioMensagem);
			this.m_gbRepositorioMensagens.Controls.Add(this.m_lbRepositorioMensagem);
			this.m_gbRepositorioMensagens.Controls.Add(this.m_lbRepositorioCultura);
			this.m_gbRepositorioMensagens.Controls.Add(this.m_cbRepositorioCultura);
			this.m_gbRepositorioMensagens.Controls.Add(this.m_lbRepositorioRetorno);
			this.m_gbRepositorioMensagens.Controls.Add(this.m_txtRepositorioRetorno);
			this.m_gbRepositorioMensagens.Controls.Add(this.m_btGetMensagemCultura);
			this.m_gbRepositorioMensagens.Location = new System.Drawing.Point(101, 2);
			this.m_gbRepositorioMensagens.Name = "m_gbRepositorioMensagens";
			this.m_gbRepositorioMensagens.Size = new System.Drawing.Size(499, 134);
			this.m_gbRepositorioMensagens.TabIndex = 5;
			this.m_gbRepositorioMensagens.TabStop = false;
			this.m_gbRepositorioMensagens.Text = "Repositório";
			// 
			// m_btGetMensagem
			// 
			this.m_btGetMensagem.Location = new System.Drawing.Point(268, 67);
			this.m_btGetMensagem.Name = "m_btGetMensagem";
			this.m_btGetMensagem.Size = new System.Drawing.Size(96, 32);
			this.m_btGetMensagem.TabIndex = 7;
			this.m_btGetMensagem.Text = "Get ";
			this.m_btGetMensagem.Click += new System.EventHandler(this.m_btGetMensagem_Click_1);
			// 
			// m_cbRepositorioMensagem
			// 
			this.m_cbRepositorioMensagem.Location = new System.Drawing.Point(81, 43);
			this.m_cbRepositorioMensagem.Name = "m_cbRepositorioMensagem";
			this.m_cbRepositorioMensagem.Size = new System.Drawing.Size(400, 21);
			this.m_cbRepositorioMensagem.TabIndex = 6;
			// 
			// m_lbRepositorioMensagem
			// 
			this.m_lbRepositorioMensagem.Location = new System.Drawing.Point(8, 48);
			this.m_lbRepositorioMensagem.Name = "m_lbRepositorioMensagem";
			this.m_lbRepositorioMensagem.Size = new System.Drawing.Size(64, 16);
			this.m_lbRepositorioMensagem.TabIndex = 5;
			this.m_lbRepositorioMensagem.Text = "Mensagem:";
			// 
			// m_lbRepositorioCultura
			// 
			this.m_lbRepositorioCultura.Location = new System.Drawing.Point(8, 24);
			this.m_lbRepositorioCultura.Name = "m_lbRepositorioCultura";
			this.m_lbRepositorioCultura.Size = new System.Drawing.Size(48, 16);
			this.m_lbRepositorioCultura.TabIndex = 4;
			this.m_lbRepositorioCultura.Text = "Cultura:";
			// 
			// m_cbRepositorioCultura
			// 
			this.m_cbRepositorioCultura.Location = new System.Drawing.Point(80, 20);
			this.m_cbRepositorioCultura.Name = "m_cbRepositorioCultura";
			this.m_cbRepositorioCultura.Size = new System.Drawing.Size(400, 21);
			this.m_cbRepositorioCultura.TabIndex = 3;
			// 
			// m_lbRepositorioRetorno
			// 
			this.m_lbRepositorioRetorno.Location = new System.Drawing.Point(11, 109);
			this.m_lbRepositorioRetorno.Name = "m_lbRepositorioRetorno";
			this.m_lbRepositorioRetorno.Size = new System.Drawing.Size(48, 16);
			this.m_lbRepositorioRetorno.TabIndex = 2;
			this.m_lbRepositorioRetorno.Text = "Retorno";
			// 
			// m_txtRepositorioRetorno
			// 
			this.m_txtRepositorioRetorno.Location = new System.Drawing.Point(61, 104);
			this.m_txtRepositorioRetorno.Name = "m_txtRepositorioRetorno";
			this.m_txtRepositorioRetorno.Size = new System.Drawing.Size(427, 20);
			this.m_txtRepositorioRetorno.TabIndex = 1;
			this.m_txtRepositorioRetorno.Text = "";
			// 
			// m_btGetMensagemCultura
			// 
			this.m_btGetMensagemCultura.Location = new System.Drawing.Point(168, 67);
			this.m_btGetMensagemCultura.Name = "m_btGetMensagemCultura";
			this.m_btGetMensagemCultura.Size = new System.Drawing.Size(96, 32);
			this.m_btGetMensagemCultura.TabIndex = 0;
			this.m_btGetMensagemCultura.Text = "Get (Cult)";
			this.m_btGetMensagemCultura.Click += new System.EventHandler(this.m_btGetMensagem_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(608, 189);
			this.Controls.Add(this.m_gbRepositorioMensagens);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.m_gbRepositorioMensagens.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			private void Form1_Load(object sender, System.EventArgs e)
			{
				vRefreshCulturas();
				vRefreshMensagens();
			}
		#endregion

		#region Show
			private void button1_Click(object sender, System.EventArgs e)
			{
				mdlMensagens.clsMensagens.Show ("oies \n teste");
				mdlMensagens.clsMensagens.Show ("teste");
				mdlMensagens.clsMensagens.Show ("Você deve informar a Razao Social do blah blah blah blahVocê deve informar a Razao Social do blah blah blah blahVocê deve informar a Razao Social do blah blah blah blahVocê deve informar a Razao Social do blah blah blah blah0\n\nblah blah blah blah blah blah blah\nisso deveria quebrar linhas");
			}

			private void button2_Click(object sender, System.EventArgs e)
			{
//				mdlMensagens.clsMensagens.ShowError ("teste fsdh fjsdhf sdf hsdfh sdf sdjfhsdhfhjsdfh sdfh jsdhf dsf sdh fsd");
				//mdlMensagens.clsMensagens.ShowError ("Você deve informar a Razao Social do blah blah blah blahVocê deve informar a Razao Social do blah blah blah blahVocê deve informar a Razao Social do blah blah blah blahVocê deve informar a Razao Social do blah blah blah blah0\n\nblah blah blah blah blah blah blah\nisso deveria quebrar linhas");
				string strMsg = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlSysControladoraModulos_clsSysControladoraModulos_ResponsavelParte2);
				mdlMensagens.clsMensagens.ShowError ("xuxa" + strMsg);
			}

			private void button3_Click(object sender, System.EventArgs e)
			{
				mdlMensagens.clsMensagens.ShowExclamation ("teste");
			}

			private void button4_Click(object sender, System.EventArgs e)
			{
				mdlMensagens.clsMensagens.ShowInformation ("teste");
			}

			private void button5_Click(object sender, System.EventArgs e)
			{
				//mdlMensagens.clsMensagens.ShowQuestion ("teste");
				mdlMensagens.clsMensagens.ShowError("Ocorreu um problema ao tentar imprimir o documento." + System.Environment.NewLine + "Verifique se sua impressora esta ligada.");
			}
		#endregion
		#region Mensagens
			private void vRefreshMensagens()
			{
				m_cbRepositorioMensagem.Items.Clear();
				foreach(string strMensagem in (System.Enum.GetNames(mdlMensagens.Mensagem.Siscobras_clsSiscobras_SistemaNaoConsegueAcessarBD.GetType())))
					m_cbRepositorioMensagem.Items.Add(strMensagem);
				m_cbRepositorioMensagem.Text = "Siscobras_clsSiscobras_SistemaPrecisaDefinirUmBD";
			}

			private void vRefreshCulturas()
			{
				m_cbRepositorioCultura.Items.Clear();
				m_cbRepositorioCultura.Items.Add("pt-BR");
				m_cbRepositorioCultura.Items.Add("en");
				m_cbRepositorioCultura.Text = "en";
			}

			private void m_btGetMensagem_Click(object sender, System.EventArgs e)
			{
				// Trocando a Cultura 
				System.Globalization.CultureInfo ciCulture = new System.Globalization.CultureInfo(m_cbRepositorioCultura.Text);
				// Buscando a Mensagem
				mdlMensagens.Mensagem enumMensagem = (mdlMensagens.Mensagem)Enum.Parse(mdlMensagens.Mensagem.Siscobras_clsSiscobras_SistemaNaoConsegueAcessarBD.GetType() ,m_cbRepositorioMensagem.Text);
			 	m_txtRepositorioRetorno.Text = mdlMensagens.clsRepositorioMensagens.GetMensagem(ciCulture,enumMensagem);
			}

			private void m_btGetMensagem_Click_1(object sender, System.EventArgs e)
			{
				// Buscando a Mensagem
				mdlMensagens.Mensagem enumMensagem = (mdlMensagens.Mensagem)Enum.Parse(mdlMensagens.Mensagem.Siscobras_clsSiscobras_SistemaNaoConsegueAcessarBD.GetType() ,m_cbRepositorioMensagem.Text);
				m_txtRepositorioRetorno.Text = mdlMensagens.clsRepositorioMensagens.GetMensagem(enumMensagem);
			}
		#endregion

		private void button6_Click(object sender, System.EventArgs e)
		{
			System.IO.FileStream fsIcone;

			fsIcone = new System.IO.FileStream ("c:\\temp\\error.bmp", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			System.Drawing.SystemIcons.Error.Save(fsIcone);
			fsIcone.Flush();
			fsIcone.Close();

			fsIcone = new System.IO.FileStream ("c:\\temp\\exclamation.bmp", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			System.Drawing.SystemIcons.Exclamation.Save(fsIcone);
			fsIcone.Flush();
			fsIcone.Close();

			fsIcone = new System.IO.FileStream ("c:\\temp\\question.bmp", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			System.Drawing.SystemIcons.Question.Save(fsIcone);
			fsIcone.Flush();
			fsIcone.Close();

			fsIcone = new System.IO.FileStream ("c:\\temp\\information.bmp", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			System.Drawing.SystemIcons.Information.Save(fsIcone);
			fsIcone.Flush();
			fsIcone.Close();
		}

	}
}

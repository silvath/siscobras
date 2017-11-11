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
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbArquivoIni;
			private System.Windows.Forms.Label m_lbPathArquivo;
			private System.Windows.Forms.TextBox m_txtPathArquivoIni;
			private System.Windows.Forms.Label m_lbSessao;
			private System.Windows.Forms.TextBox m_txtSessao;
			private System.Windows.Forms.Label m_lbVariavel;
			private System.Windows.Forms.TextBox m_txtVariavel;
			private System.Windows.Forms.Label m_lbValor;
			private System.Windows.Forms.Label m_lbValorDefault;
			private System.Windows.Forms.TextBox m_txtValor;
			private System.Windows.Forms.TextBox m_txtValorDefault;
			private System.Windows.Forms.Button m_btColoca;
			private System.Windows.Forms.Button m_btRetorna;
		private System.Windows.Forms.TextBox m_txtRetorno;
		private System.Windows.Forms.Label m_lbRetorno;
		private System.Windows.Forms.Button m_btArquivoExiste;
		private System.Windows.Forms.Button m_btArquivoValido;
		private System.Windows.Forms.Button m_btCriaArquivo;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public Form1()
			{
				InitializeComponent();
			}

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
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_lbRetorno = new System.Windows.Forms.Label();
			this.m_gbArquivoIni = new System.Windows.Forms.GroupBox();
			this.m_btRetorna = new System.Windows.Forms.Button();
			this.m_btColoca = new System.Windows.Forms.Button();
			this.m_txtValorDefault = new System.Windows.Forms.TextBox();
			this.m_lbValorDefault = new System.Windows.Forms.Label();
			this.m_txtValor = new System.Windows.Forms.TextBox();
			this.m_lbValor = new System.Windows.Forms.Label();
			this.m_txtVariavel = new System.Windows.Forms.TextBox();
			this.m_lbVariavel = new System.Windows.Forms.Label();
			this.m_txtSessao = new System.Windows.Forms.TextBox();
			this.m_lbSessao = new System.Windows.Forms.Label();
			this.m_txtPathArquivoIni = new System.Windows.Forms.TextBox();
			this.m_lbPathArquivo = new System.Windows.Forms.Label();
			this.m_btArquivoValido = new System.Windows.Forms.Button();
			this.m_btCriaArquivo = new System.Windows.Forms.Button();
			this.m_btArquivoExiste = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbArquivoIni.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_txtRetorno);
			this.m_gbGeral.Controls.Add(this.m_lbRetorno);
			this.m_gbGeral.Controls.Add(this.m_gbArquivoIni);
			this.m_gbGeral.Location = new System.Drawing.Point(8, 8);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(680, 376);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_txtRetorno
			// 
			this.m_txtRetorno.Location = new System.Drawing.Point(64, 344);
			this.m_txtRetorno.Name = "m_txtRetorno";
			this.m_txtRetorno.Size = new System.Drawing.Size(600, 20);
			this.m_txtRetorno.TabIndex = 3;
			this.m_txtRetorno.Text = "";
			// 
			// m_lbRetorno
			// 
			this.m_lbRetorno.Location = new System.Drawing.Point(16, 344);
			this.m_lbRetorno.Name = "m_lbRetorno";
			this.m_lbRetorno.Size = new System.Drawing.Size(48, 16);
			this.m_lbRetorno.TabIndex = 2;
			this.m_lbRetorno.Text = "Retorno:";
			// 
			// m_gbArquivoIni
			// 
			this.m_gbArquivoIni.Controls.Add(this.m_btArquivoExiste);
			this.m_gbArquivoIni.Controls.Add(this.m_btCriaArquivo);
			this.m_gbArquivoIni.Controls.Add(this.m_btArquivoValido);
			this.m_gbArquivoIni.Controls.Add(this.m_btRetorna);
			this.m_gbArquivoIni.Controls.Add(this.m_btColoca);
			this.m_gbArquivoIni.Controls.Add(this.m_txtValorDefault);
			this.m_gbArquivoIni.Controls.Add(this.m_lbValorDefault);
			this.m_gbArquivoIni.Controls.Add(this.m_txtValor);
			this.m_gbArquivoIni.Controls.Add(this.m_lbValor);
			this.m_gbArquivoIni.Controls.Add(this.m_txtVariavel);
			this.m_gbArquivoIni.Controls.Add(this.m_lbVariavel);
			this.m_gbArquivoIni.Controls.Add(this.m_txtSessao);
			this.m_gbArquivoIni.Controls.Add(this.m_lbSessao);
			this.m_gbArquivoIni.Controls.Add(this.m_txtPathArquivoIni);
			this.m_gbArquivoIni.Controls.Add(this.m_lbPathArquivo);
			this.m_gbArquivoIni.Location = new System.Drawing.Point(8, 16);
			this.m_gbArquivoIni.Name = "m_gbArquivoIni";
			this.m_gbArquivoIni.Size = new System.Drawing.Size(344, 280);
			this.m_gbArquivoIni.TabIndex = 0;
			this.m_gbArquivoIni.TabStop = false;
			this.m_gbArquivoIni.Text = "Arquivos Ini XML";
			// 
			// m_btRetorna
			// 
			this.m_btRetorna.Location = new System.Drawing.Point(264, 240);
			this.m_btRetorna.Name = "m_btRetorna";
			this.m_btRetorna.Size = new System.Drawing.Size(72, 32);
			this.m_btRetorna.TabIndex = 11;
			this.m_btRetorna.Text = "Retorna";
			this.m_btRetorna.Click += new System.EventHandler(this.m_btRetorna_Click);
			// 
			// m_btColoca
			// 
			this.m_btColoca.Location = new System.Drawing.Point(184, 240);
			this.m_btColoca.Name = "m_btColoca";
			this.m_btColoca.Size = new System.Drawing.Size(72, 32);
			this.m_btColoca.TabIndex = 10;
			this.m_btColoca.Text = "Coloca";
			this.m_btColoca.Click += new System.EventHandler(this.m_btColoca_Click);
			// 
			// m_txtValorDefault
			// 
			this.m_txtValorDefault.Location = new System.Drawing.Point(104, 160);
			this.m_txtValorDefault.Name = "m_txtValorDefault";
			this.m_txtValorDefault.Size = new System.Drawing.Size(168, 20);
			this.m_txtValorDefault.TabIndex = 9;
			this.m_txtValorDefault.Text = "";
			// 
			// m_lbValorDefault
			// 
			this.m_lbValorDefault.Location = new System.Drawing.Point(16, 160);
			this.m_lbValorDefault.Name = "m_lbValorDefault";
			this.m_lbValorDefault.Size = new System.Drawing.Size(80, 16);
			this.m_lbValorDefault.TabIndex = 8;
			this.m_lbValorDefault.Text = "Valor Default:";
			// 
			// m_txtValor
			// 
			this.m_txtValor.Location = new System.Drawing.Point(104, 136);
			this.m_txtValor.Name = "m_txtValor";
			this.m_txtValor.Size = new System.Drawing.Size(168, 20);
			this.m_txtValor.TabIndex = 7;
			this.m_txtValor.Text = "";
			// 
			// m_lbValor
			// 
			this.m_lbValor.Location = new System.Drawing.Point(16, 136);
			this.m_lbValor.Name = "m_lbValor";
			this.m_lbValor.Size = new System.Drawing.Size(48, 16);
			this.m_lbValor.TabIndex = 6;
			this.m_lbValor.Text = "Valor:";
			// 
			// m_txtVariavel
			// 
			this.m_txtVariavel.Location = new System.Drawing.Point(104, 112);
			this.m_txtVariavel.Name = "m_txtVariavel";
			this.m_txtVariavel.Size = new System.Drawing.Size(168, 20);
			this.m_txtVariavel.TabIndex = 5;
			this.m_txtVariavel.Text = "DataBaseAccess";
			// 
			// m_lbVariavel
			// 
			this.m_lbVariavel.Location = new System.Drawing.Point(16, 112);
			this.m_lbVariavel.Name = "m_lbVariavel";
			this.m_lbVariavel.Size = new System.Drawing.Size(48, 16);
			this.m_lbVariavel.TabIndex = 4;
			this.m_lbVariavel.Text = "Variável:";
			// 
			// m_txtSessao
			// 
			this.m_txtSessao.Location = new System.Drawing.Point(104, 85);
			this.m_txtSessao.Name = "m_txtSessao";
			this.m_txtSessao.Size = new System.Drawing.Size(168, 20);
			this.m_txtSessao.TabIndex = 3;
			this.m_txtSessao.Text = "Siscobras";
			// 
			// m_lbSessao
			// 
			this.m_lbSessao.Location = new System.Drawing.Point(16, 88);
			this.m_lbSessao.Name = "m_lbSessao";
			this.m_lbSessao.Size = new System.Drawing.Size(48, 16);
			this.m_lbSessao.TabIndex = 2;
			this.m_lbSessao.Text = "Sessão:";
			// 
			// m_txtPathArquivoIni
			// 
			this.m_txtPathArquivoIni.Location = new System.Drawing.Point(88, 24);
			this.m_txtPathArquivoIni.Name = "m_txtPathArquivoIni";
			this.m_txtPathArquivoIni.Size = new System.Drawing.Size(248, 20);
			this.m_txtPathArquivoIni.TabIndex = 1;
			this.m_txtPathArquivoIni.Text = "C:\\Projetos\\Siscobras\\Binarios\\Sisco.xml";
			// 
			// m_lbPathArquivo
			// 
			this.m_lbPathArquivo.Location = new System.Drawing.Point(15, 26);
			this.m_lbPathArquivo.Name = "m_lbPathArquivo";
			this.m_lbPathArquivo.Size = new System.Drawing.Size(73, 16);
			this.m_lbPathArquivo.TabIndex = 0;
			this.m_lbPathArquivo.Text = "Path arquivo:";
			// 
			// m_btArquivoValido
			// 
			this.m_btArquivoValido.Location = new System.Drawing.Point(8, 240);
			this.m_btArquivoValido.Name = "m_btArquivoValido";
			this.m_btArquivoValido.Size = new System.Drawing.Size(72, 32);
			this.m_btArquivoValido.TabIndex = 12;
			this.m_btArquivoValido.Text = "Arquivo Valido";
			this.m_btArquivoValido.Click += new System.EventHandler(this.m_btArquivoValido_Click);
			// 
			// m_btCriaArquivo
			// 
			this.m_btCriaArquivo.Location = new System.Drawing.Point(96, 240);
			this.m_btCriaArquivo.Name = "m_btCriaArquivo";
			this.m_btCriaArquivo.Size = new System.Drawing.Size(72, 32);
			this.m_btCriaArquivo.TabIndex = 13;
			this.m_btCriaArquivo.Text = "Cria Arquivo";
			this.m_btCriaArquivo.Click += new System.EventHandler(this.m_btCriaArquivo_Click);
			// 
			// m_btArquivoExiste
			// 
			this.m_btArquivoExiste.Location = new System.Drawing.Point(8, 200);
			this.m_btArquivoExiste.Name = "m_btArquivoExiste";
			this.m_btArquivoExiste.Size = new System.Drawing.Size(72, 32);
			this.m_btArquivoExiste.TabIndex = 14;
			this.m_btArquivoExiste.Text = "Arquivo Existe";
			this.m_btArquivoExiste.Click += new System.EventHandler(this.m_btArquivoExiste_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 390);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manipulação de Arquivos";
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbArquivoIni.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Negocio
			private void m_btArquivoExiste_Click(object sender, System.EventArgs e)
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_arq_Ini = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_txtPathArquivoIni.Text);		
       			m_txtRetorno.Text = cls_arq_Ini.bArquivoExiste().ToString();
			}

			private void m_btArquivoValido_Click(object sender, System.EventArgs e)
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_arq_Ini = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_txtPathArquivoIni.Text);					
				m_txtRetorno.Text = cls_arq_Ini.bArquivoValido().ToString();
			}

			private void m_btCriaArquivo_Click(object sender, System.EventArgs e)
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_arq_Ini = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_txtPathArquivoIni.Text);		
				m_txtRetorno.Text = cls_arq_Ini.bCriaArquivo().ToString();
			}

			private void m_btColoca_Click(object sender, System.EventArgs e)
			{
	            mdlManipuladorArquivo.clsManipuladorArquivoIni cls_arq_Ini = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_txtPathArquivoIni.Text);		
				m_txtRetorno.Text = cls_arq_Ini.colocaValor(m_txtSessao.Text,m_txtVariavel.Text,m_txtValor.Text).ToString();
			}
			private void m_btRetorna_Click(object sender, System.EventArgs e)
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_arq_Ini = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_txtPathArquivoIni.Text);		
				if (m_txtValorDefault.Text == "")
				{
					m_txtRetorno.Text = cls_arq_Ini.retornaValor(m_txtSessao.Text,m_txtVariavel.Text).ToString();
				}else{
					m_txtRetorno.Text = cls_arq_Ini.retornaValor(m_txtSessao.Text,m_txtVariavel.Text,m_txtValorDefault.Text).ToString();
				}
			}
		#endregion

	}
}

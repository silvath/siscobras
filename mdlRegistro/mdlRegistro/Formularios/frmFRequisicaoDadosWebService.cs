using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRegistro
{
	/// <summary>
	/// Summary description for frmFRequisicaoDadosWebService.
	/// </summary>
	internal class frmFRequisicaoDadosWebService : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate bool delCallRequisicaoDadosWebService(bool bShowErrors);
		#endregion
		#region Events 
			public event delCallRequisicaoDadosWebService eCallRequisicaoDadosWebService;
		#endregion
		#region Events Methods
			protected virtual bool OnCallRequisicaoDadosWebService()
			{
				bool bRetorno = false;
				if (eCallRequisicaoDadosWebService != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					bRetorno = eCallRequisicaoDadosWebService(true);
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
				return(bRetorno);
			}
		#endregion
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro = null;
			private string m_strEnderecoExecutavel = "";
				
			private mdlRegistro.Resposta m_enumResposta = mdlRegistro.Resposta.Cancelar;

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.ComponentModel.IContainer components;
			private System.Windows.Forms.Label m_lbInformacaoConectadoInternet;
			private System.Windows.Forms.Label m_lbInformacoesPerguntaEnviarDados;
			internal System.Windows.Forms.Button m_btContinuar;
		private System.Windows.Forms.LinkLabel m_llbProxy;
			internal System.Windows.Forms.Button m_btCancelar;
		#endregion
		#region Constructors and Destructors
			public frmFRequisicaoDadosWebService(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,string strEnderecoExecutavel)
			{
				m_cls_ter_TratadorErro = cls_ter_TratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				InitializeComponent();
			}

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if(components != null)
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRequisicaoDadosWebService));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_llbProxy = new System.Windows.Forms.LinkLabel();
			this.m_lbInformacaoConectadoInternet = new System.Windows.Forms.Label();
			this.m_lbInformacoesPerguntaEnviarDados = new System.Windows.Forms.Label();
			this.m_btContinuar = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_llbProxy);
			this.m_gbGeral.Controls.Add(this.m_lbInformacaoConectadoInternet);
			this.m_gbGeral.Controls.Add(this.m_lbInformacoesPerguntaEnviarDados);
			this.m_gbGeral.Controls.Add(this.m_btContinuar);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(3, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(373, 139);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_llbProxy
			// 
			this.m_llbProxy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llbProxy.Location = new System.Drawing.Point(48, 80);
			this.m_llbProxy.Name = "m_llbProxy";
			this.m_llbProxy.Size = new System.Drawing.Size(272, 16);
			this.m_llbProxy.TabIndex = 25;
			this.m_llbProxy.TabStop = true;
			this.m_llbProxy.Text = "Clique aqui caso necessite configurar o proxy.";
			this.m_llbProxy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llbProxy_LinkClicked);
			// 
			// m_lbInformacaoConectadoInternet
			// 
			this.m_lbInformacaoConectadoInternet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbInformacaoConectadoInternet.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbInformacaoConectadoInternet.Location = new System.Drawing.Point(72, 48);
			this.m_lbInformacaoConectadoInternet.Name = "m_lbInformacaoConectadoInternet";
			this.m_lbInformacaoConectadoInternet.Size = new System.Drawing.Size(216, 16);
			this.m_lbInformacaoConectadoInternet.TabIndex = 23;
			this.m_lbInformacaoConectadoInternet.Text = "Você deve estar conectado à internet.";
			// 
			// m_lbInformacoesPerguntaEnviarDados
			// 
			this.m_lbInformacoesPerguntaEnviarDados.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbInformacoesPerguntaEnviarDados.Location = new System.Drawing.Point(6, 14);
			this.m_lbInformacoesPerguntaEnviarDados.Name = "m_lbInformacoesPerguntaEnviarDados";
			this.m_lbInformacoesPerguntaEnviarDados.Size = new System.Drawing.Size(360, 24);
			this.m_lbInformacoesPerguntaEnviarDados.TabIndex = 22;
			this.m_lbInformacoesPerguntaEnviarDados.Text = "Seu Siscobras necessita sincronizar-se com o servidor.";
			// 
			// m_btContinuar
			// 
			this.m_btContinuar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContinuar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btContinuar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btContinuar.Image = ((System.Drawing.Image)(resources.GetObject("m_btContinuar.Image")));
			this.m_btContinuar.Location = new System.Drawing.Point(189, 106);
			this.m_btContinuar.Name = "m_btContinuar";
			this.m_btContinuar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btContinuar.Size = new System.Drawing.Size(57, 25);
			this.m_btContinuar.TabIndex = 2;
			this.m_ttDica.SetToolTip(this.m_btContinuar, "Continuar");
			this.m_btContinuar.Click += new System.EventHandler(this.m_btContinuar_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(125, 106);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 3;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Continuar mais tarde");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFRequisicaoDadosWebService
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(378, 144);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRequisicaoDadosWebService";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Requisição de dados ao servidor";
			this.Load += new System.EventHandler(this.frmFRequisicaoDadosWebService_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formularios
				private void frmFRequisicaoDadosWebService_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
				}
			#endregion
			#region LinkLabels
				private void m_llbProxy_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
				{
					System.Diagnostics.Process proc = new System.Diagnostics.Process();
					proc.StartInfo = new System.Diagnostics.ProcessStartInfo (m_strEnderecoExecutavel + clsRegistro.CONFIGEXE);
					proc.StartInfo.WorkingDirectory = m_strEnderecoExecutavel;
					proc.Start();
					m_enumResposta = mdlRegistro.Resposta.Cancelar;
					this.Close();
				}
			#endregion
			#region Botoes
				private void m_btVoltar_Click(object sender, System.EventArgs e)
				{
					m_enumResposta = mdlRegistro.Resposta.Voltar;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_enumResposta = mdlRegistro.Resposta.Cancelar;
					this.Close();
				}

				private void m_btContinuar_Click(object sender, System.EventArgs e)
				{
					if (OnCallRequisicaoDadosWebService())
					{
						m_enumResposta = mdlRegistro.Resposta.Continuar;
						this.Close();
					}
				}
			#endregion
		#endregion
		#region Cores
		private void vMostraCor()
		{
			mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","CoresSecundarias");
			this.BackColor = clsPaletaCores.retornaCorAtual();
			for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
			{
				this.Controls[nCont].BackColor = this.BackColor;
				for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
				{
					if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.Panel"))
						this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

					for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
					{
						if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.ComboBox"))
							this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
					}
				}
			}
		}
		#endregion

		#region RetornaDados
			public void vRetornaDados(out mdlRegistro.Resposta enumResposta)
			{
				enumResposta = m_enumResposta;
			}
		#endregion
	}
}

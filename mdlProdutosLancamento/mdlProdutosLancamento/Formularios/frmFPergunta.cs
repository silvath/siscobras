using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosLancamento
{
	/// <summary>
	/// Summary description for frmFPergunta.
	/// </summary>
	internal class frmFPergunta : System.Windows.Forms.Form
	{
		#region Atributes
			// ***************************************************************************************************
			// Atributos
			// ***************************************************************************************************
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel;
			internal mdlProdutosLancamento.RespostaPergunta m_enumResposta = mdlProdutosLancamento.RespostaPergunta.Nenhuma;

		    private System.Collections.ArrayList m_arlBotoes;
			private System.Collections.ArrayList m_arlBotoesTexts;

			private string m_strPergunta;
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.ComponentModel.Container components = null;
			// ***************************************************************************************************
		#endregion
		#region Constructor and Destructors
			public frmFPergunta(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,string strEnderecoExecutavel,string strPergunta,ref System.Collections.ArrayList arlBotoes,ref System.Collections.ArrayList arlBotoesTexts)
			{
				m_cls_ter_tratadorErro = tratadorErro; 
				m_strEnderecoExecutavel = strEnderecoExecutavel;

				m_arlBotoes = arlBotoes;
				m_arlBotoesTexts = arlBotoesTexts;

				m_strPergunta = strPergunta;

				InitializeComponent();

				ModificaInterfaceGrafica();
				MostraCor();
			}

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
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Location = new System.Drawing.Point(5, 1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(472, 88);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// frmFPergunta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(482, 95);
			this.ControlBox = false;
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmFPergunta";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Aviso";
			this.ResumeLayout(false);

		}
		#endregion

		#region Cores
			private void MostraCor()
			{
				try
				{
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","Produtos");
					this.BackColor = clsPaletaCores.retornaCorAtual();
					for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
					{
						this.Controls[nCont].BackColor = this.BackColor;
						for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
						{
							if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentes.compListView") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.TreeView"))
								this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

							for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
							{
								if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentes.compListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.TreeView"))
									this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
							}
						}
					}
				}
				catch (Exception erro)
				{
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}

			private void TrocaCor()
			{
				try
				{
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","Produtos");
					clsPaletaCores.mostraCorAtual();
					MostraCor();
				}
				catch (Exception erro)
				{
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}
		#endregion
		#region Modificações Interface Grafica
			private void ModificaInterfaceGrafica()
			{
				m_gbGeral.Controls.Clear();
				int nPosXBotao = -1;
				int nPosYBotao = -1;
				int nIncrementoPosXBotao = 5;
				int nWidthBotao = 80;
				int nHeightBotao = 40;

				// Inserindo a Pergunta 
				System.Windows.Forms.Label m_lbPergunta = new System.Windows.Forms.Label();
				m_lbPergunta.Name = "m_lbPergunta";
				m_lbPergunta.Text = m_strPergunta;
				m_lbPergunta.Location = new System.Drawing.Point(10,8);
				m_lbPergunta.Size = new System.Drawing.Size(m_gbGeral.Width - (m_gbGeral.Location.X + 10),m_gbGeral.Height - (m_gbGeral.Location.Y + 50));
				m_lbPergunta.Font = new System.Drawing.Font("Arial",10,System.Drawing.FontStyle.Bold);
				m_lbPergunta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				m_gbGeral.Controls.Add(m_lbPergunta);

				// Setando posicoes do botao 
				int nEspacoOcupar = (m_arlBotoes.Count * nWidthBotao) + ((m_arlBotoes.Count - 1) * nIncrementoPosXBotao);
				nPosXBotao = (int)((m_gbGeral.Width - nEspacoOcupar) / 2);
				nPosYBotao = m_gbGeral.Height - (m_gbGeral.Location.Y + 45);

				// Botoes
				for(int nCont = 0 ; nCont < m_arlBotoes.Count; nCont++)
				{
					System.Windows.Forms.Button m_btBotao = new System.Windows.Forms.Button();
					m_btBotao.Name = m_arlBotoesTexts[nCont].ToString();
					m_btBotao.Text = m_arlBotoesTexts[nCont].ToString();
					m_btBotao.Location = new System.Drawing.Point(nPosXBotao,nPosYBotao);
					m_btBotao.Size = new System.Drawing.Size(nWidthBotao,nHeightBotao);
					m_btBotao.Cursor = System.Windows.Forms.Cursors.Hand;
					m_btBotao.Font = new System.Drawing.Font("Arial",10,System.Drawing.FontStyle.Bold);
					m_gbGeral.Controls.Add(m_btBotao);
					m_btBotao.BringToFront();
					m_btBotao.Click += new System.EventHandler(BotaoClicado);
					nPosXBotao += (nIncrementoPosXBotao + nWidthBotao);
				} 
			}
		#endregion

		#region Eventos
			private void BotaoClicado(Object sender,System.EventArgs e)
			{
				string strNomeBotao = ((System.Windows.Forms.Button)sender).Text;
				for (int nCont = 0;nCont < m_arlBotoesTexts.Count;nCont++)
				{
					if ((string)(m_arlBotoesTexts[nCont]) == strNomeBotao)
					{
						m_enumResposta = (mdlProdutosLancamento.RespostaPergunta)m_arlBotoes[nCont];
                        break;
					}
				}
				if (m_enumResposta != mdlProdutosLancamento.RespostaPergunta.Nenhuma)
				{
					this.Close();
				}
			}
		#endregion
	}
}

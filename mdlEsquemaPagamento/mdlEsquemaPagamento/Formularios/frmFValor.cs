using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlEsquemaPagamento
{
	/// <summary>
	/// Summary description for frmFValor.
	/// </summary>
	internal class frmFValor : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributes
			mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		    string m_strEnderecoExecutavel;
			private clsCalculoPorcentagens m_cls_cal_Porcentagens;
			private bool m_bAtivado = true;
			public bool m_bModificado = false;
		 
		    private double m_dValorTotal = 0;
			private double m_dSaldo = 0;
		    private double m_dPorcentagemMaxima = 0;

			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.Label m_lbPorcentagem;
			internal System.Windows.Forms.Label m_lbSimboloMoeda;
			public mdlComponentesGraficos.TextBox m_txtPorcentagem;
			internal System.Windows.Forms.Label m_lbCorresponde;
			internal System.Windows.Forms.Label m_lbInfoGeral;
			public mdlComponentesGraficos.TextBox m_txtValor;
			internal System.Windows.Forms.Label m_lbValor;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor and Destructors
			public frmFValor(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string strEnderecoExecutavel, double valorTotalNew, double saldoNew, double valorAtual, string strSimboloMoeda)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;

				InitializeComponent();

		        m_dValorTotal = valorTotalNew;
				m_dSaldo = saldoNew;
				m_lbSimboloMoeda.Text = strSimboloMoeda;
				m_cls_cal_Porcentagens = new clsCalculoPorcentagens(m_dValorTotal);
				m_dPorcentagemMaxima = mdlConversao.clsTruncamento.dTrunca(((m_dSaldo * 100) / m_dValorTotal),mdlConstantes.clsConstantes.DEFAULT_PRECISAO);
				if (valorAtual == -1)
					valorAtual = m_dSaldo;
				MostraValor(valorAtual);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFValor));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_lbPorcentagem = new System.Windows.Forms.Label();
			this.m_lbSimboloMoeda = new System.Windows.Forms.Label();
			this.m_txtPorcentagem = new mdlComponentesGraficos.TextBox();
			this.m_lbCorresponde = new System.Windows.Forms.Label();
			this.m_lbInfoGeral = new System.Windows.Forms.Label();
			this.m_txtValor = new mdlComponentesGraficos.TextBox();
			this.m_lbValor = new System.Windows.Forms.Label();
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_lbPorcentagem);
			this.m_gbGeral.Controls.Add(this.m_lbSimboloMoeda);
			this.m_gbGeral.Controls.Add(this.m_txtPorcentagem);
			this.m_gbGeral.Controls.Add(this.m_lbCorresponde);
			this.m_gbGeral.Controls.Add(this.m_lbInfoGeral);
			this.m_gbGeral.Controls.Add(this.m_txtValor);
			this.m_gbGeral.Controls.Add(this.m_lbValor);
			this.m_gbGeral.Location = new System.Drawing.Point(4, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(528, 96);
			this.m_gbGeral.TabIndex = 3;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(203, 66);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 83;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(267, 66);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 84;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_lbPorcentagem
			// 
			this.m_lbPorcentagem.Location = new System.Drawing.Point(360, 40);
			this.m_lbPorcentagem.Name = "m_lbPorcentagem";
			this.m_lbPorcentagem.Size = new System.Drawing.Size(16, 16);
			this.m_lbPorcentagem.TabIndex = 82;
			this.m_lbPorcentagem.Text = "%";
			// 
			// m_lbSimboloMoeda
			// 
			this.m_lbSimboloMoeda.Location = new System.Drawing.Point(56, 41);
			this.m_lbSimboloMoeda.Name = "m_lbSimboloMoeda";
			this.m_lbSimboloMoeda.Size = new System.Drawing.Size(40, 16);
			this.m_lbSimboloMoeda.TabIndex = 81;
			this.m_lbSimboloMoeda.Text = "$";
			this.m_lbSimboloMoeda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txtPorcentagem
			// 
			this.m_txtPorcentagem.AcceptsReturn = true;
			this.m_txtPorcentagem.AutoSize = false;
			this.m_txtPorcentagem.BackColor = System.Drawing.SystemColors.Window;
			this.m_txtPorcentagem.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.m_txtPorcentagem.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtPorcentagem.ForeColor = System.Drawing.SystemColors.WindowText;
			this.m_txtPorcentagem.Location = new System.Drawing.Point(320, 40);
			this.m_txtPorcentagem.MaxLength = 50;
			this.m_txtPorcentagem.Name = "m_txtPorcentagem";
			this.m_txtPorcentagem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_txtPorcentagem.Size = new System.Drawing.Size(32, 19);
			this.m_txtPorcentagem.TabIndex = 2;
			this.m_txtPorcentagem.Text = "";
			this.m_txtPorcentagem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_txtPorcentagem_MouseUp);
			this.m_txtPorcentagem.TextChanged += new System.EventHandler(this.m_txtPorcentagem_TextChanged);
			this.m_txtPorcentagem.Enter += new System.EventHandler(this.m_txtPorcentagem_Enter);
			// 
			// m_lbCorresponde
			// 
			this.m_lbCorresponde.Location = new System.Drawing.Point(216, 40);
			this.m_lbCorresponde.Name = "m_lbCorresponde";
			this.m_lbCorresponde.Size = new System.Drawing.Size(96, 16);
			this.m_lbCorresponde.TabIndex = 80;
			this.m_lbCorresponde.Text = "que corresponde";
			// 
			// m_lbInfoGeral
			// 
			this.m_lbInfoGeral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbInfoGeral.Location = new System.Drawing.Point(16, 16);
			this.m_lbInfoGeral.Name = "m_lbInfoGeral";
			this.m_lbInfoGeral.Size = new System.Drawing.Size(504, 24);
			this.m_lbInfoGeral.TabIndex = 78;
			this.m_lbInfoGeral.Text = "Você pode especificar um valor ou uma porcentagem para a modalidade escolhida.";
			// 
			// m_txtValor
			// 
			this.m_txtValor.AcceptsReturn = true;
			this.m_txtValor.AutoSize = false;
			this.m_txtValor.BackColor = System.Drawing.SystemColors.Window;
			this.m_txtValor.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.m_txtValor.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtValor.ForeColor = System.Drawing.SystemColors.WindowText;
			this.m_txtValor.Location = new System.Drawing.Point(95, 39);
			this.m_txtValor.MaxLength = 50;
			this.m_txtValor.Name = "m_txtValor";
			this.m_txtValor.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_txtValor.Size = new System.Drawing.Size(112, 19);
			this.m_txtValor.TabIndex = 1;
			this.m_txtValor.Text = "";
			this.m_txtValor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_txtValor_MouseUp);
			this.m_txtValor.TextChanged += new System.EventHandler(this.m_txtValor_TextChanged);
			this.m_txtValor.Enter += new System.EventHandler(this.m_txtValor_Enter);
			// 
			// m_lbValor
			// 
			this.m_lbValor.Location = new System.Drawing.Point(16, 42);
			this.m_lbValor.Name = "m_lbValor";
			this.m_lbValor.Size = new System.Drawing.Size(43, 16);
			this.m_lbValor.TabIndex = 12;
			this.m_lbValor.Text = "Valor:";
			// 
			// frmFValor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 102);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmFValor";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Escolha o valor";
			this.Load += new System.EventHandler(this.frmFValor_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFValor_Load(object sender, System.EventArgs e)
				{
					MostraCor();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_txtValor.Text == "")
					{
						vMensagemValorInvalido();
						MostraValor(dRetornaValorCorrespondentePorcentagem(m_dPorcentagemMaxima));
						MostraPorcentagem(m_dPorcentagemMaxima);
						m_txtValor.SelectAll();
					}else{
						m_bModificado = true;
						this.Close();
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
			#region TextBoxes
				private void m_txtValor_Enter(object sender, System.EventArgs e)
				{
					m_txtValor.SelectAll();
				}

				private void m_txtPorcentagem_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
				{
					m_txtPorcentagem.SelectAll();
				}

				private void m_txtValor_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
				{
					m_txtValor.SelectAll();
				}

				private void m_txtValor_TextChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{
		                m_bAtivado = false;
						if (m_txtValor.Text.Trim() != "")
						{
							try
							{
								double dValor = Double.Parse(m_txtValor.Text);
								if ((dValor > 0) && (dValor <= m_dSaldo))
								{
									MostraPorcentagem(dRetornaPorcentagemCorrespondenteValor(dValor));
								}
								else
								{
									vMensagemValorInvalido();
									MostraValor(m_dSaldo);
									MostraPorcentagem(dRetornaPorcentagemCorrespondenteValor(m_dSaldo));
									m_txtValor.SelectAll();
								}
							}
							catch
							{
								vMensagemValorInvalido();
								MostraValor(m_dSaldo);
								MostraPorcentagem(dRetornaPorcentagemCorrespondenteValor(m_dSaldo));
								m_txtValor.SelectAll();
							}
						}else{
							m_txtPorcentagem.Text = "";
						}
						m_bAtivado = true;
					}
				}

				private void m_txtPorcentagem_Enter(object sender, System.EventArgs e)
				{
					m_txtPorcentagem.SelectAll();
				}

				private void m_txtPorcentagem_TextChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{
						m_bAtivado = false;
						if (m_txtPorcentagem.Text.Trim() != "")
						{
							try
							{
								double dValor = Double.Parse(m_txtPorcentagem.Text);
								if ((dValor > 0) && (dValor <= m_dPorcentagemMaxima))
								{
									MostraValor(dRetornaValorCorrespondentePorcentagem(dValor));
								}
								else
								{
									vMensagemValorInvalido();
									MostraValor(dRetornaValorCorrespondentePorcentagem(m_dPorcentagemMaxima));
									MostraPorcentagem(m_dPorcentagemMaxima);
									m_txtValor.SelectAll();
								}
							}
							catch
							{
								vMensagemValorInvalido();
								MostraValor(dRetornaValorCorrespondentePorcentagem(m_dPorcentagemMaxima));
								MostraPorcentagem(m_dPorcentagemMaxima);
								m_txtValor.SelectAll();
							}
						}else{
							m_txtValor.Text = "";
						}
						m_bAtivado = true;
					}
				}
			#endregion
		#endregion

		#region Mensagens
			private void vMensagemValorInvalido()
			{
				string strMensagem = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEsquemaPagamento_frmFValor_ValorInvalido).Replace("<PAR1>",m_dSaldo.ToString());
				mdlMensagens.clsMensagens.ShowInformation(strMensagem);
			}
		#endregion

		#region Cores Formulario
			private void MostraCor()
			{
				try
				{
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
					this.BackColor = clsPaletaCores.retornaCorAtual();
					for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
					{
						this.Controls[nCont].BackColor = this.BackColor;
						for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
						{
							if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox"))
								this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

							for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
							{
								if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.TextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TextBox"))
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
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
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
		#region Interface
			private void MostraValor(double valor)
			{
				if (valor > 1000)
					this.m_txtValor.Text = valor.ToString();	
				else
					this.m_txtValor.Text = valor.ToString();	
			}

			private void MostraPorcentagem(double valor)
			{
				if (valor > 1000)
					this.m_txtPorcentagem.Text = valor.ToString();	
				else
					this.m_txtPorcentagem.Text = valor.ToString();	
			}
		#endregion
		#region Calculos
			private double dRetornaPorcentagemCorrespondenteValor(double dValor)
			{
				m_cls_cal_Porcentagens.bRemove("");
				m_cls_cal_Porcentagens.bAdiciona("",dValor);
				return(m_cls_cal_Porcentagens.dPorcentagem(""));
			}

			private double dRetornaValorCorrespondentePorcentagem(double dPorcentagem)
			{
				double dValor = System.Math.Round((m_dValorTotal * dPorcentagem) / 100,clsEsquemaPagamento.MAXDECIMALS);
				return (System.Math.Round(dValor,2));
			}
		#endregion
		#region Retorno
			public void retornaValores(out double dPorcentagem)
			{
				m_cls_cal_Porcentagens.bRemove("");
				m_cls_cal_Porcentagens.bAdiciona("",double.Parse(m_txtValor.Text));
				dPorcentagem = m_cls_cal_Porcentagens.dPorcentagemExata("");
			}
		#endregion 
	}
}

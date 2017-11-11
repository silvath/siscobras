using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlEsquemaPagamento
{
	/// <summary>
	/// Summary description for frmFValorPostecipado.
	/// </summary>
	internal class frmFValorPostecipado : System.Windows.Forms.Form
	{
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			private string m_strEnderecoExecutavel = "";
			private clsCalculoPorcentagens m_cls_cal_Porcentagens;
			private bool m_bAtivado = true;
			public bool m_bModificado = false;
			
			private double m_dValorTotal = 0;
			private double m_dSaldo = 0;
			private double m_dPorcentagemMaxima = 0;
			private int m_nPostQuantTempo = 0;
			private UnidadeTempo m_enumPostUnidadeTempo; 
			private DocumentoCondicao m_enumPostCondicao;
			private int m_nPostQuantParcelas = 0; 
			private int m_nPostIntervalo = 0;

			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Label m_lbPrimeira;
			internal System.Windows.Forms.Button m_btCondicao;
			internal System.Windows.Forms.Button m_btUnidadeTempo2;
			public mdlComponentesGraficos.TextBox m_txtIntervalo;
			internal System.Windows.Forms.Label m_lbParcelas;
			public mdlComponentesGraficos.TextBox m_txtQuantParcelas;
			internal System.Windows.Forms.Button m_btUnidadeTempo;
			public mdlComponentesGraficos.TextBox m_txtTempo;
			internal System.Windows.Forms.Label m_lbApos;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.Label m_lbPorcentagem;
			internal System.Windows.Forms.Label m_lbSimboloMoeda;
			public mdlComponentesGraficos.TextBox m_txtPorcentagem;
			internal System.Windows.Forms.Label m_lbCorresponde;
			internal System.Windows.Forms.Label m_lbInfoGeral;
			public mdlComponentesGraficos.TextBox m_txtValor;
			internal System.Windows.Forms.Label m_lbValor;
			internal System.Windows.Forms.Label m_lbDividido;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor and Destructors
			internal frmFValorPostecipado(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string strEnderecoExecutavel, double dvalorTotalNew , double saldoNew, double valorAtual, string strSimboloMoeda, int nQuantTempo, UnidadeTempo enumUnidadeTempo, DocumentoCondicao enumCondicao, int nParcelas, int nIntervalo)
			{
				InitializeComponent();
		        m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_dValorTotal = dvalorTotalNew;
				m_cls_cal_Porcentagens = new clsCalculoPorcentagens(m_dValorTotal);
				m_dSaldo = saldoNew;
				m_lbSimboloMoeda.Text = strSimboloMoeda;
				m_dPorcentagemMaxima = mdlConversao.clsTruncamento.dTrunca(((m_dSaldo * 100) / m_dValorTotal),mdlConstantes.clsConstantes.DEFAULT_PRECISAO);
				m_nPostQuantTempo = nQuantTempo;
				m_enumPostUnidadeTempo = enumUnidadeTempo;
				m_enumPostCondicao = enumCondicao;
				m_nPostQuantParcelas = nParcelas;
				m_nPostIntervalo = nIntervalo;
				valorAtual = m_dSaldo;
				MostraValor(valorAtual);
				MostraOpcoesPostecipado();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFValorPostecipado));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_lbPrimeira = new System.Windows.Forms.Label();
			this.m_btCondicao = new System.Windows.Forms.Button();
			this.m_btUnidadeTempo2 = new System.Windows.Forms.Button();
			this.m_txtIntervalo = new mdlComponentesGraficos.TextBox();
			this.m_lbParcelas = new System.Windows.Forms.Label();
			this.m_txtQuantParcelas = new mdlComponentesGraficos.TextBox();
			this.m_btUnidadeTempo = new System.Windows.Forms.Button();
			this.m_txtTempo = new mdlComponentesGraficos.TextBox();
			this.m_lbApos = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_lbPorcentagem = new System.Windows.Forms.Label();
			this.m_lbSimboloMoeda = new System.Windows.Forms.Label();
			this.m_txtPorcentagem = new mdlComponentesGraficos.TextBox();
			this.m_lbCorresponde = new System.Windows.Forms.Label();
			this.m_lbInfoGeral = new System.Windows.Forms.Label();
			this.m_txtValor = new mdlComponentesGraficos.TextBox();
			this.m_lbValor = new System.Windows.Forms.Label();
			this.m_lbDividido = new System.Windows.Forms.Label();
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_lbPrimeira);
			this.m_gbGeral.Controls.Add(this.m_btCondicao);
			this.m_gbGeral.Controls.Add(this.m_btUnidadeTempo2);
			this.m_gbGeral.Controls.Add(this.m_txtIntervalo);
			this.m_gbGeral.Controls.Add(this.m_lbParcelas);
			this.m_gbGeral.Controls.Add(this.m_txtQuantParcelas);
			this.m_gbGeral.Controls.Add(this.m_btUnidadeTempo);
			this.m_gbGeral.Controls.Add(this.m_txtTempo);
			this.m_gbGeral.Controls.Add(this.m_lbApos);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_lbPorcentagem);
			this.m_gbGeral.Controls.Add(this.m_lbSimboloMoeda);
			this.m_gbGeral.Controls.Add(this.m_txtPorcentagem);
			this.m_gbGeral.Controls.Add(this.m_lbCorresponde);
			this.m_gbGeral.Controls.Add(this.m_lbInfoGeral);
			this.m_gbGeral.Controls.Add(this.m_txtValor);
			this.m_gbGeral.Controls.Add(this.m_lbValor);
			this.m_gbGeral.Controls.Add(this.m_lbDividido);
			this.m_gbGeral.Location = new System.Drawing.Point(6, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(442, 145);
			this.m_gbGeral.TabIndex = 4;
			this.m_gbGeral.TabStop = false;
			// 
			// m_lbPrimeira
			// 
			this.m_lbPrimeira.Location = new System.Drawing.Point(16, 87);
			this.m_lbPrimeira.Name = "m_lbPrimeira";
			this.m_lbPrimeira.Size = new System.Drawing.Size(96, 16);
			this.m_lbPrimeira.TabIndex = 93;
			this.m_lbPrimeira.Text = "Sendo a primeira :";
			// 
			// m_btCondicao
			// 
			this.m_btCondicao.Location = new System.Drawing.Point(312, 88);
			this.m_btCondicao.Name = "m_btCondicao";
			this.m_btCondicao.Size = new System.Drawing.Size(96, 20);
			this.m_btCondicao.TabIndex = 8;
			this.m_btCondicao.Text = "conhecimento";
			this.m_btCondicao.Click += new System.EventHandler(this.m_btCondicao_Click);
			// 
			// m_btUnidadeTempo2
			// 
			this.m_btUnidadeTempo2.Location = new System.Drawing.Point(364, 63);
			this.m_btUnidadeTempo2.Name = "m_btUnidadeTempo2";
			this.m_btUnidadeTempo2.Size = new System.Drawing.Size(72, 20);
			this.m_btUnidadeTempo2.TabIndex = 5;
			this.m_btUnidadeTempo2.Text = "dia(s)";
			this.m_btUnidadeTempo2.Click += new System.EventHandler(this.m_btUnidadeTempo2_Click);
			// 
			// m_txtIntervalo
			// 
			this.m_txtIntervalo.AcceptsReturn = true;
			this.m_txtIntervalo.AutoSize = false;
			this.m_txtIntervalo.BackColor = System.Drawing.SystemColors.Window;
			this.m_txtIntervalo.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.m_txtIntervalo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtIntervalo.ForeColor = System.Drawing.SystemColors.WindowText;
			this.m_txtIntervalo.Location = new System.Drawing.Point(318, 63);
			this.m_txtIntervalo.MaxLength = 50;
			this.m_txtIntervalo.Name = "m_txtIntervalo";
			this.m_txtIntervalo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_txtIntervalo.Size = new System.Drawing.Size(40, 19);
			this.m_txtIntervalo.TabIndex = 4;
			this.m_txtIntervalo.Text = "0";
			this.m_txtIntervalo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtIntervalo.TextChanged += new System.EventHandler(this.m_txtIntervalo_TextChanged);
			// 
			// m_lbParcelas
			// 
			this.m_lbParcelas.Location = new System.Drawing.Point(169, 64);
			this.m_lbParcelas.Name = "m_lbParcelas";
			this.m_lbParcelas.Size = new System.Drawing.Size(151, 16);
			this.m_lbParcelas.TabIndex = 92;
			this.m_lbParcelas.Text = "parcela(s), com intervalo de:";
			// 
			// m_txtQuantParcelas
			// 
			this.m_txtQuantParcelas.AcceptsReturn = true;
			this.m_txtQuantParcelas.AutoSize = false;
			this.m_txtQuantParcelas.BackColor = System.Drawing.SystemColors.Window;
			this.m_txtQuantParcelas.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.m_txtQuantParcelas.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtQuantParcelas.ForeColor = System.Drawing.SystemColors.WindowText;
			this.m_txtQuantParcelas.Location = new System.Drawing.Point(126, 64);
			this.m_txtQuantParcelas.MaxLength = 50;
			this.m_txtQuantParcelas.Name = "m_txtQuantParcelas";
			this.m_txtQuantParcelas.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_txtQuantParcelas.Size = new System.Drawing.Size(40, 19);
			this.m_txtQuantParcelas.TabIndex = 3;
			this.m_txtQuantParcelas.Text = "1";
			this.m_txtQuantParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtQuantParcelas.TextChanged += new System.EventHandler(this.m_txtQuantParcelas_TextChanged);
			// 
			// m_btUnidadeTempo
			// 
			this.m_btUnidadeTempo.Location = new System.Drawing.Point(200, 88);
			this.m_btUnidadeTempo.Name = "m_btUnidadeTempo";
			this.m_btUnidadeTempo.Size = new System.Drawing.Size(72, 20);
			this.m_btUnidadeTempo.TabIndex = 7;
			this.m_btUnidadeTempo.Text = "dia(s)";
			this.m_btUnidadeTempo.Click += new System.EventHandler(this.m_btUnidadeTempo_Click);
			// 
			// m_txtTempo
			// 
			this.m_txtTempo.AcceptsReturn = true;
			this.m_txtTempo.AutoSize = false;
			this.m_txtTempo.BackColor = System.Drawing.SystemColors.Window;
			this.m_txtTempo.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.m_txtTempo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtTempo.ForeColor = System.Drawing.SystemColors.WindowText;
			this.m_txtTempo.Location = new System.Drawing.Point(112, 88);
			this.m_txtTempo.MaxLength = 50;
			this.m_txtTempo.Name = "m_txtTempo";
			this.m_txtTempo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_txtTempo.Size = new System.Drawing.Size(80, 19);
			this.m_txtTempo.TabIndex = 6;
			this.m_txtTempo.Text = "30";
			this.m_txtTempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtTempo.TextChanged += new System.EventHandler(this.m_txtTempo_TextChanged);
			// 
			// m_lbApos
			// 
			this.m_lbApos.Location = new System.Drawing.Point(276, 91);
			this.m_lbApos.Name = "m_lbApos";
			this.m_lbApos.Size = new System.Drawing.Size(32, 16);
			this.m_lbApos.TabIndex = 91;
			this.m_lbApos.Text = "após";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(168, 115);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 9;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(232, 115);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 10;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_lbPorcentagem
			// 
			this.m_lbPorcentagem.Location = new System.Drawing.Point(360, 32);
			this.m_lbPorcentagem.Name = "m_lbPorcentagem";
			this.m_lbPorcentagem.Size = new System.Drawing.Size(32, 16);
			this.m_lbPorcentagem.TabIndex = 82;
			this.m_lbPorcentagem.Text = "% ) .";
			// 
			// m_lbSimboloMoeda
			// 
			this.m_lbSimboloMoeda.Location = new System.Drawing.Point(54, 33);
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
			this.m_txtPorcentagem.Location = new System.Drawing.Point(320, 30);
			this.m_txtPorcentagem.MaxLength = 50;
			this.m_txtPorcentagem.Name = "m_txtPorcentagem";
			this.m_txtPorcentagem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_txtPorcentagem.Size = new System.Drawing.Size(32, 19);
			this.m_txtPorcentagem.TabIndex = 2;
			this.m_txtPorcentagem.Text = "";
			this.m_txtPorcentagem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_txtPorcentagem_MouseUp);
			this.m_txtPorcentagem.TextChanged += new System.EventHandler(this.m_txtPorcentagem_TextChanged);
			// 
			// m_lbCorresponde
			// 
			this.m_lbCorresponde.Location = new System.Drawing.Point(216, 32);
			this.m_lbCorresponde.Name = "m_lbCorresponde";
			this.m_lbCorresponde.Size = new System.Drawing.Size(96, 16);
			this.m_lbCorresponde.TabIndex = 80;
			this.m_lbCorresponde.Text = "( que corresponde";
			// 
			// m_lbInfoGeral
			// 
			this.m_lbInfoGeral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.m_lbInfoGeral.Location = new System.Drawing.Point(16, 13);
			this.m_lbInfoGeral.Name = "m_lbInfoGeral";
			this.m_lbInfoGeral.Size = new System.Drawing.Size(424, 19);
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
			this.m_txtValor.Location = new System.Drawing.Point(95, 31);
			this.m_txtValor.MaxLength = 50;
			this.m_txtValor.Name = "m_txtValor";
			this.m_txtValor.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_txtValor.Size = new System.Drawing.Size(112, 19);
			this.m_txtValor.TabIndex = 1;
			this.m_txtValor.Text = "";
			this.m_txtValor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_txtValor_MouseUp);
			this.m_txtValor.TextChanged += new System.EventHandler(this.m_txtValor_TextChanged);
			// 
			// m_lbValor
			// 
			this.m_lbValor.Location = new System.Drawing.Point(16, 32);
			this.m_lbValor.Name = "m_lbValor";
			this.m_lbValor.Size = new System.Drawing.Size(43, 16);
			this.m_lbValor.TabIndex = 12;
			this.m_lbValor.Text = "Valor:";
			// 
			// m_lbDividido
			// 
			this.m_lbDividido.Location = new System.Drawing.Point(16, 66);
			this.m_lbDividido.Name = "m_lbDividido";
			this.m_lbDividido.Size = new System.Drawing.Size(120, 16);
			this.m_lbDividido.TabIndex = 94;
			this.m_lbDividido.Text = "Valor este dividido em";
			// 
			// frmFValorPostecipado
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(456, 150);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmFValorPostecipado";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Escolha o valor e os prazos das parcelas";
			this.Load += new System.EventHandler(this.frmFValorPostecipado_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formularios
				private void frmFValorPostecipado_Load(object sender, System.EventArgs e)
				{
					this.MostraCor();
				}
			#endregion
			#region Botoes
				private void m_btCondicao_Click(object sender, System.EventArgs e)
				{
					switch(m_enumPostCondicao)
					{
						case DocumentoCondicao.Fatura:
							m_enumPostCondicao = DocumentoCondicao.Conhecimento;
							break;
						case DocumentoCondicao.Conhecimento:
							m_enumPostCondicao = DocumentoCondicao.Saque;
							break;
						case DocumentoCondicao.Saque:
							m_enumPostCondicao = DocumentoCondicao.Aceite;
							break;
						case DocumentoCondicao.Aceite:
							m_enumPostCondicao = DocumentoCondicao.Fatura;
							break;
					}
					MostraOpcoesPostecipado();
				}

				private void m_btUnidadeTempo2_Click(object sender, System.EventArgs e)
				{
					switch(m_enumPostUnidadeTempo)
					{
						case UnidadeTempo.Dia:
							m_enumPostUnidadeTempo = UnidadeTempo.Mes;
							break;

						case UnidadeTempo.Mes:
							m_enumPostUnidadeTempo = UnidadeTempo.Dia;
							break;
					}
		            MostraOpcoesPostecipado();
				}

				private void m_btUnidadeTempo_Click(object sender, System.EventArgs e)
				{
					switch(m_enumPostUnidadeTempo)
					{
						case UnidadeTempo.Dia:
							m_enumPostUnidadeTempo = UnidadeTempo.Mes;
							break;

						case UnidadeTempo.Mes:
							m_enumPostUnidadeTempo = UnidadeTempo.Dia;
							break;
					}
					MostraOpcoesPostecipado();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_txtValor.Text == "")
					{
						vMensagemValorInvalido();
						MostraValor(m_dSaldo);
						MostraPorcentagem(dRetornaPorcentagemCorrespondenteValor(m_dSaldo));
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
				private void m_txtValor_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
				{
					m_txtValor.SelectAll();
				}

				private void m_txtPorcentagem_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
				{
					m_txtPorcentagem.SelectAll();
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
						}
						else
						{
							m_txtPorcentagem.Text = "";
						}
						m_bAtivado = true;
					}
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
						}
						else
						{
							m_txtValor.Text = "";
						}
						m_bAtivado = true;
					}
				}

				private void m_txtQuantParcelas_TextChanged(object sender, System.EventArgs e)
				{
					try
					{
						m_nPostQuantParcelas = Int32.Parse(m_txtQuantParcelas.Text);
					}catch{
						m_nPostQuantParcelas = 1;
					}
					if (m_nPostQuantParcelas == 0)
					{
						m_txtQuantParcelas.Focus();
					}
					else
					{
						MostraOpcoesPostecipado();
					}
				}

				private void m_txtIntervalo_TextChanged(object sender, System.EventArgs e)
				{
					try
					{
						m_nPostIntervalo = Int32.Parse(m_txtIntervalo.Text);
					}catch{
						m_nPostIntervalo = 0;
					}
					MostraOpcoesPostecipado();
				}

				private void m_txtTempo_TextChanged(object sender, System.EventArgs e)
				{
					try
					{
						m_nPostQuantTempo = Int32.Parse(m_txtTempo.Text);
					}catch{
						m_nPostQuantTempo = 30;
					}
					MostraOpcoesPostecipado();
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
							if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentes.compTextNumber") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox"))
								this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

							for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
							{
								if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentes.compTextNumber") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TextBox"))
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

			private void MostraOpcoesPostecipado()
			{
				this.m_txtQuantParcelas.Text = m_nPostQuantParcelas.ToString();
				if (m_nPostQuantParcelas > 1)
				{
					m_txtIntervalo.Enabled = true;
					m_txtIntervalo.Text = m_nPostIntervalo.ToString();
				}else{
					m_txtIntervalo.Enabled = false;
					m_txtIntervalo.Text = "0";
				}
				m_txtTempo.Text = m_nPostQuantTempo.ToString();
				switch(m_enumPostUnidadeTempo)
				{
					case UnidadeTempo.Dia:
						m_btUnidadeTempo.Text = "dia(s)";
						m_btUnidadeTempo2.Text = "dia(s)";
						break;
					case UnidadeTempo.Mes:
						m_btUnidadeTempo.Text = "mes(es)";
						m_btUnidadeTempo2.Text = "mes(es)";
						break;
				}
				switch(m_enumPostCondicao)
				{
					case DocumentoCondicao.Fatura:
						m_btCondicao.Text = "fatura";
						break;
					case DocumentoCondicao.Conhecimento:
						m_btCondicao.Text = "conhecimento";
						break;
					case DocumentoCondicao.Aceite:
						m_btCondicao.Text = "aceite";
						break;
					case DocumentoCondicao.Saque:
						m_btCondicao.Text = "saque";
						break;
				}
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
			internal void retornaValores(out double dPorcentagem,out int nQuantTempo,out UnidadeTempo enumUnidadeTempo, out DocumentoCondicao enumCondicao, out int nQuantParcelas , out int nIntervalo)
			{
				m_cls_cal_Porcentagens.bRemove("");
				m_cls_cal_Porcentagens.bAdiciona("",double.Parse(m_txtValor.Text));
				dPorcentagem = m_cls_cal_Porcentagens.dPorcentagemExata("");
				nQuantTempo = m_nPostQuantTempo;
				enumUnidadeTempo = m_enumPostUnidadeTempo;
				enumCondicao = m_enumPostCondicao;
				nQuantParcelas = m_nPostQuantParcelas;
				nIntervalo = m_nPostIntervalo;
			}
		#endregion

	}
}

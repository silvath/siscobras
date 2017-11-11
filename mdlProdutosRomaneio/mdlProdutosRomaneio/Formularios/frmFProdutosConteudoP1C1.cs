using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosRomaneio
{
	/// <summary>
	/// Summary description for frmFEmbalagemInserindoProdutosP1E1.
	/// </summary>
	internal class frmFProdutosConteudoP1C1 : System.Windows.Forms.Form
	{
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel;

			private string m_strDescricaoProduto = "";
			private double m_dQuantidadeDefaultProduto = 0;
			private double m_dQuantidadeRestanteProduto = 0;
			private string m_strUnidadeQuantidade = "";
			private string m_strIdEmbalagem = "";

			private double m_dQuantidade = 0;
			private double m_dPesoLiquido = 0;
			private int m_nUnidadeMassaPesoLiquido = 0;
			private bool bCanChange = true;
        
			public bool m_bModificado = false;

			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Label m_lbProduto;
			private System.Windows.Forms.TextBox m_txtEmbalagem;
			private System.Windows.Forms.Label m_lbEmbalagem;
			private System.Windows.Forms.Label m_lbQuantidade;
			private mdlComponentesGraficos.TextBox m_txtQuantidade;
			private System.Windows.Forms.TextBox m_txtProduto;
			internal System.Windows.Forms.Button m_btUnidadeMassaPesoLiquido;
			private System.Windows.Forms.Label m_lbUnidadeQuantidade;
			private System.Windows.Forms.Label m_lbPesoLiquidoUnitario;
			private mdlComponentesGraficos.TextBox m_txtPesoLiquidoTotal;
			private System.Windows.Forms.Label m_lbPesoLiquidoTotal;
			private mdlComponentesGraficos.TextBox m_txtPesoLiquidoUnitario;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Delegates
			public delegate string delCallCarregaDadosInterfaceUnidadeMassaPesoLiquido(int nIdUnidadeMassa);
		#endregion
		#region Events
				public event delCallCarregaDadosInterfaceUnidadeMassaPesoLiquido eCallCarregaDadosInterfaceUnidadeMassaPesoLiquido;
		#endregion
		#region Events Methods
				protected virtual void OnCallCarregaDadosInterfaceUnidadeMassaPesoLiquido()
				{
					string strRetorno = "";
					if (eCallCarregaDadosInterfaceUnidadeMassaPesoLiquido != null)
					{
						strRetorno = eCallCarregaDadosInterfaceUnidadeMassaPesoLiquido(m_nUnidadeMassaPesoLiquido);
					}
					this.m_btUnidadeMassaPesoLiquido.Text = strRetorno;
				}
		#endregion
		#region Constructors and Destructors
			public frmFProdutosConteudoP1C1(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string strEnderecoExecutavel,string strDescricaoProduto, string strIdEmbalagem,double dQuantidadeDefaultProduto, double dQuantidadeRestanteProduto,string strUnidadeQuantidade,double dPesoLiquido,int nIdUnidadeMassaPesoLiquido)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_strDescricaoProduto = strDescricaoProduto;
				m_dQuantidadeDefaultProduto = dQuantidadeDefaultProduto;
				m_dQuantidadeRestanteProduto = dQuantidadeRestanteProduto;
				m_strUnidadeQuantidade = strUnidadeQuantidade;
				m_strIdEmbalagem = strIdEmbalagem;
				m_dPesoLiquido = dPesoLiquido;  
				m_nUnidadeMassaPesoLiquido = nIdUnidadeMassaPesoLiquido;

				InitializeComponent();

				m_txtProduto.Text = m_strDescricaoProduto;
				m_txtEmbalagem.Text = m_strIdEmbalagem;
				m_txtQuantidade.Text = m_dQuantidadeDefaultProduto.ToString();
				m_txtPesoLiquidoTotal.Text = m_dPesoLiquido.ToString();
				m_lbUnidadeQuantidade.Text = m_strUnidadeQuantidade;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutosConteudoP1C1));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_txtPesoLiquidoUnitario = new mdlComponentesGraficos.TextBox();
			this.m_lbUnidadeQuantidade = new System.Windows.Forms.Label();
			this.m_btUnidadeMassaPesoLiquido = new System.Windows.Forms.Button();
			this.m_txtQuantidade = new mdlComponentesGraficos.TextBox();
			this.m_lbQuantidade = new System.Windows.Forms.Label();
			this.m_txtProduto = new System.Windows.Forms.TextBox();
			this.m_lbProduto = new System.Windows.Forms.Label();
			this.m_txtEmbalagem = new System.Windows.Forms.TextBox();
			this.m_lbEmbalagem = new System.Windows.Forms.Label();
			this.m_txtPesoLiquidoTotal = new mdlComponentesGraficos.TextBox();
			this.m_lbPesoLiquidoUnitario = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_lbPesoLiquidoTotal = new System.Windows.Forms.Label();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_txtPesoLiquidoUnitario);
			this.m_gbGeral.Controls.Add(this.m_lbUnidadeQuantidade);
			this.m_gbGeral.Controls.Add(this.m_btUnidadeMassaPesoLiquido);
			this.m_gbGeral.Controls.Add(this.m_txtQuantidade);
			this.m_gbGeral.Controls.Add(this.m_lbQuantidade);
			this.m_gbGeral.Controls.Add(this.m_txtProduto);
			this.m_gbGeral.Controls.Add(this.m_lbProduto);
			this.m_gbGeral.Controls.Add(this.m_txtEmbalagem);
			this.m_gbGeral.Controls.Add(this.m_lbEmbalagem);
			this.m_gbGeral.Controls.Add(this.m_txtPesoLiquidoTotal);
			this.m_gbGeral.Controls.Add(this.m_lbPesoLiquidoUnitario);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_lbPesoLiquidoTotal);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -3);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(652, 121);
			this.m_gbGeral.TabIndex = 5;
			this.m_gbGeral.TabStop = false;
			// 
			// m_txtPesoLiquidoUnitario
			// 
			this.m_txtPesoLiquidoUnitario.Location = new System.Drawing.Point(308, 65);
			this.m_txtPesoLiquidoUnitario.Name = "m_txtPesoLiquidoUnitario";
			this.m_txtPesoLiquidoUnitario.OnlyNumbers = true;
			this.m_txtPesoLiquidoUnitario.Size = new System.Drawing.Size(96, 20);
			this.m_txtPesoLiquidoUnitario.TabIndex = 2;
			this.m_txtPesoLiquidoUnitario.Text = "";
			this.m_txtPesoLiquidoUnitario.TextChanged += new System.EventHandler(this.m_txtPesoLiquidoUnitario_TextChanged);
			// 
			// m_lbUnidadeQuantidade
			// 
			this.m_lbUnidadeQuantidade.Location = new System.Drawing.Point(156, 68);
			this.m_lbUnidadeQuantidade.Name = "m_lbUnidadeQuantidade";
			this.m_lbUnidadeQuantidade.Size = new System.Drawing.Size(40, 16);
			this.m_lbUnidadeQuantidade.TabIndex = 78;
			this.m_lbUnidadeQuantidade.Text = "pc";
			// 
			// m_btUnidadeMassaPesoLiquido
			// 
			this.m_btUnidadeMassaPesoLiquido.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeMassaPesoLiquido.Location = new System.Drawing.Point(603, 65);
			this.m_btUnidadeMassaPesoLiquido.Name = "m_btUnidadeMassaPesoLiquido";
			this.m_btUnidadeMassaPesoLiquido.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadeMassaPesoLiquido.TabIndex = 77;
			this.m_btUnidadeMassaPesoLiquido.Text = "cm";
			this.m_btUnidadeMassaPesoLiquido.Click += new System.EventHandler(this.m_btUnidadeMassaPesoLiquido_Click);
			// 
			// m_txtQuantidade
			// 
			this.m_txtQuantidade.Location = new System.Drawing.Point(80, 66);
			this.m_txtQuantidade.Name = "m_txtQuantidade";
			this.m_txtQuantidade.OnlyNumbers = true;
			this.m_txtQuantidade.Size = new System.Drawing.Size(72, 20);
			this.m_txtQuantidade.TabIndex = 1;
			this.m_txtQuantidade.Text = "";
			this.m_txtQuantidade.TextChanged += new System.EventHandler(this.m_txtQuantidade_TextChanged);
			// 
			// m_lbQuantidade
			// 
			this.m_lbQuantidade.Location = new System.Drawing.Point(6, 70);
			this.m_lbQuantidade.Name = "m_lbQuantidade";
			this.m_lbQuantidade.Size = new System.Drawing.Size(80, 16);
			this.m_lbQuantidade.TabIndex = 74;
			this.m_lbQuantidade.Text = "Quantidade:";
			// 
			// m_txtProduto
			// 
			this.m_txtProduto.Location = new System.Drawing.Point(80, 13);
			this.m_txtProduto.Name = "m_txtProduto";
			this.m_txtProduto.ReadOnly = true;
			this.m_txtProduto.Size = new System.Drawing.Size(560, 20);
			this.m_txtProduto.TabIndex = 76;
			this.m_txtProduto.Text = "";
			// 
			// m_lbProduto
			// 
			this.m_lbProduto.Location = new System.Drawing.Point(7, 16);
			this.m_lbProduto.Name = "m_lbProduto";
			this.m_lbProduto.Size = new System.Drawing.Size(48, 16);
			this.m_lbProduto.TabIndex = 75;
			this.m_lbProduto.Text = "Produto:";
			// 
			// m_txtEmbalagem
			// 
			this.m_txtEmbalagem.Location = new System.Drawing.Point(80, 40);
			this.m_txtEmbalagem.Name = "m_txtEmbalagem";
			this.m_txtEmbalagem.ReadOnly = true;
			this.m_txtEmbalagem.Size = new System.Drawing.Size(560, 20);
			this.m_txtEmbalagem.TabIndex = 72;
			this.m_txtEmbalagem.Text = "";
			// 
			// m_lbEmbalagem
			// 
			this.m_lbEmbalagem.Location = new System.Drawing.Point(5, 43);
			this.m_lbEmbalagem.Name = "m_lbEmbalagem";
			this.m_lbEmbalagem.Size = new System.Drawing.Size(72, 16);
			this.m_lbEmbalagem.TabIndex = 71;
			this.m_lbEmbalagem.Text = "Embalagem:";
			// 
			// m_txtPesoLiquidoTotal
			// 
			this.m_txtPesoLiquidoTotal.Location = new System.Drawing.Point(504, 66);
			this.m_txtPesoLiquidoTotal.Name = "m_txtPesoLiquidoTotal";
			this.m_txtPesoLiquidoTotal.OnlyNumbers = true;
			this.m_txtPesoLiquidoTotal.Size = new System.Drawing.Size(96, 20);
			this.m_txtPesoLiquidoTotal.TabIndex = 3;
			this.m_txtPesoLiquidoTotal.Text = "";
			this.m_txtPesoLiquidoTotal.Leave += new System.EventHandler(this.m_txtPesoLiquidoTotal_Leave);
			// 
			// m_lbPesoLiquidoUnitario
			// 
			this.m_lbPesoLiquidoUnitario.Location = new System.Drawing.Point(199, 69);
			this.m_lbPesoLiquidoUnitario.Name = "m_lbPesoLiquidoUnitario";
			this.m_lbPesoLiquidoUnitario.Size = new System.Drawing.Size(120, 16);
			this.m_lbPesoLiquidoUnitario.TabIndex = 70;
			this.m_lbPesoLiquidoUnitario.Text = "Peso Liquido Unitário:";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(264, 91);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 4;
			this.m_ttDica.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(328, 91);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 5;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_lbPesoLiquidoTotal
			// 
			this.m_lbPesoLiquidoTotal.Location = new System.Drawing.Point(407, 69);
			this.m_lbPesoLiquidoTotal.Name = "m_lbPesoLiquidoTotal";
			this.m_lbPesoLiquidoTotal.Size = new System.Drawing.Size(104, 16);
			this.m_lbPesoLiquidoTotal.TabIndex = 79;
			this.m_lbPesoLiquidoTotal.Text = "Peso Liquido Total:";
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFProdutosConteudoP1C1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(658, 120);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmFProdutosConteudoP1C1";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Embalando Produto";
			this.Load += new System.EventHandler(this.frmFEmbalagemInserindoProdutosP1E1_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
			#region Formulario
				private void frmFEmbalagemInserindoProdutosP1E1_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					OnCallCarregaDadosInterfaceUnidadeMassaPesoLiquido();
				}
			#endregion
			#region Botoes
				private void m_btUnidadeMassaPesoLiquido_Click(object sender, System.EventArgs e)
				{
                    m_nUnidadeMassaPesoLiquido = clsProdutosRomaneio.nRetornaProximaUnidadeMassa(m_nUnidadeMassaPesoLiquido);
					OnCallCarregaDadosInterfaceUnidadeMassaPesoLiquido();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					string strMensagem = "";
					double dQuantidade = 0;
					if (m_txtQuantidade.Text != "")
					{
						if (m_txtPesoLiquidoTotal.Text.Trim() == "")
						{
							m_txtPesoLiquidoTotal.Text = "0";
						}
						dQuantidade = Double.Parse(m_txtQuantidade.Text);
						if (dQuantidade <= m_dQuantidadeRestanteProduto)
						{
							m_dQuantidade = dQuantidade;
							m_dPesoLiquido = Double.Parse(m_txtPesoLiquidoTotal.Text);
							m_bModificado = true;
							this.Close();
						}
						else
						{
							strMensagem = "A quantidade nao pode ser maior que: " + m_dQuantidadeRestanteProduto.ToString();
						}
					}else{
						strMensagem = "Você deve preencher a quantidade.";
					}
					if (!m_bModificado)
					{
						mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFProdutosConteudoP1C1_MensagemOK).Replace("TAG",strMensagem));
                        //MessageBox.Show(strMensagem,"Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
			#region TextBoxes
				private void m_txtQuantidade_TextChanged(object sender, System.EventArgs e)
				{
					if (bCanChange)
					{
						if (m_txtQuantidade.Text.Trim() != "")
						{
							double dQuantidade = Double.Parse(m_txtQuantidade.Text.Trim());
							double dPesoLiquidoUnitario = 0;
							double dPesoLiquidoTotal = 0;
							if (m_txtPesoLiquidoUnitario.Text.Trim() != "")
							{
								// Peso Liquido Unitario SIM
								if (m_txtPesoLiquidoTotal.Text.Trim() != "")
								{
									// Peso Liquido Unitario SIM / Peso Liquido Total SIM
									dPesoLiquidoUnitario = Double.Parse(m_txtPesoLiquidoUnitario.Text.Trim());
									vPesoLiquidoTotal(dPesoLiquidoUnitario * dQuantidade);
								}
								else
								{
									// Peso Liquido Unitario SIM / Peso Liquido Total NAO
									dPesoLiquidoUnitario = Double.Parse(m_txtPesoLiquidoUnitario.Text.Trim());
									vPesoLiquidoTotal(dPesoLiquidoUnitario * dQuantidade);
								}
							}
							else
							{
								// Peso Liquido Unitario NAO
								if (m_txtPesoLiquidoTotal.Text.Trim() != "")
								{
									// Peso Liquido Unitario NAO / Peso Liquido Total SIM
									if (dQuantidade > 0)
									{
										dPesoLiquidoTotal = Double.Parse(m_txtPesoLiquidoTotal.Text.Trim());
										vPesoLiquidoUnitario(dPesoLiquidoTotal / dQuantidade);
									}
								}
							}
						}
					}
				}

				private void m_txtPesoLiquidoUnitario_TextChanged(object sender, System.EventArgs e)
				{
					if (bCanChange)
					{
						if (m_txtQuantidade.Text.Trim() != "")
						{
							double dQuantidade = Double.Parse(m_txtQuantidade.Text.Trim());
							double dPesoLiquidoUnitario = 0;
							if (m_txtPesoLiquidoUnitario.Text.Trim() != "")
							{
								try
								{
									dPesoLiquidoUnitario = Double.Parse(m_txtPesoLiquidoUnitario.Text.Trim());
								}
								catch
								{
									dPesoLiquidoUnitario = 0;
								}
								vPesoLiquidoTotal(dPesoLiquidoUnitario * dQuantidade);
							}
						}
					}
				}

				private void m_txtPesoLiquidoTotal_Leave(object sender, System.EventArgs e)
				{
					if (bCanChange)
					{
						if (m_txtQuantidade.Text.Trim() != "")
						{
							double dQuantidade = Double.Parse(m_txtQuantidade.Text.Trim());
							double dPesoLiquidoTotal = 0;
							if ((dQuantidade > 0) && (m_txtPesoLiquidoTotal.Text.Trim() != ""))
							{
								try
								{
									dPesoLiquidoTotal = Double.Parse(m_txtPesoLiquidoTotal.Text.Trim());
								}
								catch
								{
									dPesoLiquidoTotal = 0;
								}
								vPesoLiquidoUnitario(dPesoLiquidoTotal / dQuantidade);
							}
						}
					}
				}

				private void vPesoLiquidoUnitario(double dValor)
				{
					bCanChange = false;
					m_txtPesoLiquidoUnitario.Text = mdlConversao.clsTruncamento.dTrunca(dValor,clsProdutosRomaneio.PRECISAO_PESOLIQUIDO_TOTAL,4).ToString("R");
					bCanChange = true;
				}

				private void vPesoLiquidoTotal(double dValor)
				{
					bCanChange = false;
					m_txtPesoLiquidoTotal.Text = mdlConversao.clsTruncamento.dTrunca(dValor,clsProdutosRomaneio.PRECISAO_PESOLIQUIDO_TOTAL).ToString("R");
					bCanChange = true;
				}
			#endregion
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
							if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TreeView"))
								this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

							for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
							{
								if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TreeView"))
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

		#region Retorno
			public void RetornaValores(out double dQuantidade,out double dPesoLiquido,out int nUnidadeMassaPesoLiquido)
			{
				dQuantidade = m_dQuantidade;
				dPesoLiquido = m_dPesoLiquido;
				nUnidadeMassaPesoLiquido = m_nUnidadeMassaPesoLiquido;
			}
		#endregion 

	}
}

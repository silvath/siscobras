using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosRomaneio
{
	/// <summary>
	/// Summary description for frmFProdutosConteudoP1CN.
	/// </summary>
	internal class frmFProdutosConteudoP1CN : System.Windows.Forms.Form
	{
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			private int m_nIdExportador = -1;
			private string m_strIdPE = "";
			private string m_strEnderecoExecutavel = "";
		
			private bool m_bVolume = false;

			private int m_nIdOrdemProduto = 0;
			private string m_strDescricaoProduto = "";
			private double m_dQuantidadeTotalProduto = 0;
			private int m_nUnidadeMassaPesoLiquido = 0;
			private System.Collections.ArrayList m_arlEmbalagens;  
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos m_typDatSetTbProdutosRomaneioEmbalagensProdutos;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos m_typDatSetTbProdutosRomaneioVolumesProdutos;
			
			private string m_strUltimaEmbalagem = "";

			public bool m_bModificado = false;

			internal System.Windows.Forms.GroupBox m_gbGeral;
			private mdlComponentesGraficos.TextBox m_txtPesoLiquidoUnitario;
			private System.Windows.Forms.Label m_lbUnidadeQuantidade;
			internal System.Windows.Forms.Button m_btUnidadeMassaPesoLiquido;
			private mdlComponentesGraficos.TextBox m_txtQuantidade;
			private System.Windows.Forms.Label m_lbQuantidade;
			private System.Windows.Forms.TextBox m_txtProduto;
			private System.Windows.Forms.Label m_lbProduto;
			private mdlComponentesGraficos.TextBox m_txtPesoLiquidoTotal;
			private System.Windows.Forms.Label m_lbPesoLiquidoUnitario;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Label m_lbPesoLiquidoTotal;
			private System.Windows.Forms.Label m_lbEmbalagens;
			private mdlComponentesGraficos.ListView m_lvEmbalagens;
			private System.Windows.Forms.ColumnHeader m_colhEmbalagem;
			private System.ComponentModel.Container components = null;
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
		#region Constructor and Destructors
			public frmFProdutosConteudoP1CN(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string strEnderecoExecutavel,int nIdExportador,string strIdPE,bool bVolume,int nIdOrdemProduto,string strDescricaoProduto,double dQuantidadeTotalProduto,ref System.Collections.ArrayList arlEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos)
			{
				InitializeComponent();
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPE = strIdPE;
				m_bVolume = bVolume;
				m_nIdOrdemProduto = nIdOrdemProduto;
				m_strDescricaoProduto = strDescricaoProduto;
				m_dQuantidadeTotalProduto = dQuantidadeTotalProduto;
				m_arlEmbalagens = arlEmbalagens;
				m_typDatSetTbProdutosRomaneioEmbalagensProdutos = typDatSetTbProdutosRomaneioEmbalagensProdutos;
				m_typDatSetTbProdutosRomaneioVolumesProdutos = typDatSetTbProdutosRomaneioVolumesProdutos;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutosConteudoP1CN));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_lvEmbalagens = new mdlComponentesGraficos.ListView();
			this.m_colhEmbalagem = new System.Windows.Forms.ColumnHeader();
			this.m_txtPesoLiquidoUnitario = new mdlComponentesGraficos.TextBox();
			this.m_lbUnidadeQuantidade = new System.Windows.Forms.Label();
			this.m_btUnidadeMassaPesoLiquido = new System.Windows.Forms.Button();
			this.m_txtQuantidade = new mdlComponentesGraficos.TextBox();
			this.m_lbQuantidade = new System.Windows.Forms.Label();
			this.m_txtProduto = new System.Windows.Forms.TextBox();
			this.m_lbProduto = new System.Windows.Forms.Label();
			this.m_lbEmbalagens = new System.Windows.Forms.Label();
			this.m_txtPesoLiquidoTotal = new mdlComponentesGraficos.TextBox();
			this.m_lbPesoLiquidoUnitario = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_lbPesoLiquidoTotal = new System.Windows.Forms.Label();
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_lvEmbalagens);
			this.m_gbGeral.Controls.Add(this.m_txtPesoLiquidoUnitario);
			this.m_gbGeral.Controls.Add(this.m_lbUnidadeQuantidade);
			this.m_gbGeral.Controls.Add(this.m_btUnidadeMassaPesoLiquido);
			this.m_gbGeral.Controls.Add(this.m_txtQuantidade);
			this.m_gbGeral.Controls.Add(this.m_lbQuantidade);
			this.m_gbGeral.Controls.Add(this.m_txtProduto);
			this.m_gbGeral.Controls.Add(this.m_lbProduto);
			this.m_gbGeral.Controls.Add(this.m_lbEmbalagens);
			this.m_gbGeral.Controls.Add(this.m_txtPesoLiquidoTotal);
			this.m_gbGeral.Controls.Add(this.m_lbPesoLiquidoUnitario);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_lbPesoLiquidoTotal);
			this.m_gbGeral.Location = new System.Drawing.Point(8, 8);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(652, 200);
			this.m_gbGeral.TabIndex = 6;
			this.m_gbGeral.TabStop = false;
			// 
			// m_lvEmbalagens
			// 
			this.m_lvEmbalagens.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.m_colhEmbalagem});
			this.m_lvEmbalagens.FullRowSelect = true;
			this.m_lvEmbalagens.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvEmbalagens.HideSelection = false;
			this.m_lvEmbalagens.Location = new System.Drawing.Point(80, 40);
			this.m_lvEmbalagens.MultiSelect = false;
			this.m_lvEmbalagens.Name = "m_lvEmbalagens";
			this.m_lvEmbalagens.Size = new System.Drawing.Size(560, 96);
			this.m_lvEmbalagens.TabIndex = 80;
			this.m_lvEmbalagens.View = System.Windows.Forms.View.Details;
			this.m_lvEmbalagens.SelectedIndexChanged += new System.EventHandler(this.m_lvEmbalagens_SelectedIndexChanged);
			// 
			// m_colhEmbalagem
			// 
			this.m_colhEmbalagem.Text = "Embalagem";
			this.m_colhEmbalagem.Width = 555;
			// 
			// m_txtPesoLiquidoUnitario
			// 
			this.m_txtPesoLiquidoUnitario.Location = new System.Drawing.Point(308, 141);
			this.m_txtPesoLiquidoUnitario.Name = "m_txtPesoLiquidoUnitario";
			this.m_txtPesoLiquidoUnitario.OnlyNumbers = true;
			this.m_txtPesoLiquidoUnitario.Size = new System.Drawing.Size(96, 20);
			this.m_txtPesoLiquidoUnitario.TabIndex = 2;
			this.m_txtPesoLiquidoUnitario.Text = "";
			this.m_txtPesoLiquidoUnitario.TextChanged += new System.EventHandler(this.m_txtPesoLiquidoUnitario_TextChanged);
			// 
			// m_lbUnidadeQuantidade
			// 
			this.m_lbUnidadeQuantidade.Location = new System.Drawing.Point(156, 144);
			this.m_lbUnidadeQuantidade.Name = "m_lbUnidadeQuantidade";
			this.m_lbUnidadeQuantidade.Size = new System.Drawing.Size(40, 16);
			this.m_lbUnidadeQuantidade.TabIndex = 78;
			this.m_lbUnidadeQuantidade.Text = "pc";
			// 
			// m_btUnidadeMassaPesoLiquido
			// 
			this.m_btUnidadeMassaPesoLiquido.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadeMassaPesoLiquido.Location = new System.Drawing.Point(603, 141);
			this.m_btUnidadeMassaPesoLiquido.Name = "m_btUnidadeMassaPesoLiquido";
			this.m_btUnidadeMassaPesoLiquido.Size = new System.Drawing.Size(37, 24);
			this.m_btUnidadeMassaPesoLiquido.TabIndex = 77;
			this.m_btUnidadeMassaPesoLiquido.Text = "cm";
			this.m_btUnidadeMassaPesoLiquido.Click += new System.EventHandler(this.m_btUnidadeMassaPesoLiquido_Click);
			// 
			// m_txtQuantidade
			// 
			this.m_txtQuantidade.EnterGotoNextControl = false;
			this.m_txtQuantidade.Location = new System.Drawing.Point(80, 142);
			this.m_txtQuantidade.Name = "m_txtQuantidade";
			this.m_txtQuantidade.OnlyNumbers = true;
			this.m_txtQuantidade.Size = new System.Drawing.Size(72, 20);
			this.m_txtQuantidade.TabIndex = 1;
			this.m_txtQuantidade.Text = "";
			this.m_txtQuantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtQuantidade_KeyDown);
			this.m_txtQuantidade.TextChanged += new System.EventHandler(this.m_txtQuantidade_TextChanged);
			// 
			// m_lbQuantidade
			// 
			this.m_lbQuantidade.Location = new System.Drawing.Point(6, 145);
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
			// m_lbEmbalagens
			// 
			this.m_lbEmbalagens.Location = new System.Drawing.Point(7, 42);
			this.m_lbEmbalagens.Name = "m_lbEmbalagens";
			this.m_lbEmbalagens.Size = new System.Drawing.Size(72, 16);
			this.m_lbEmbalagens.TabIndex = 71;
			this.m_lbEmbalagens.Text = "Embalagens:";
			// 
			// m_txtPesoLiquidoTotal
			// 
			this.m_txtPesoLiquidoTotal.EnterGotoNextControl = false;
			this.m_txtPesoLiquidoTotal.Location = new System.Drawing.Point(504, 142);
			this.m_txtPesoLiquidoTotal.Name = "m_txtPesoLiquidoTotal";
			this.m_txtPesoLiquidoTotal.OnlyNumbers = true;
			this.m_txtPesoLiquidoTotal.Size = new System.Drawing.Size(96, 20);
			this.m_txtPesoLiquidoTotal.TabIndex = 3;
			this.m_txtPesoLiquidoTotal.Text = "";
			this.m_txtPesoLiquidoTotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPesoLiquidoTotal_KeyDown);
			this.m_txtPesoLiquidoTotal.Leave += new System.EventHandler(this.m_txtPesoLiquidoTotal_Leave);
			// 
			// m_lbPesoLiquidoUnitario
			// 
			this.m_lbPesoLiquidoUnitario.Location = new System.Drawing.Point(199, 145);
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
			this.m_btOk.Location = new System.Drawing.Point(264, 168);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 4;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(328, 168);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 5;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_lbPesoLiquidoTotal
			// 
			this.m_lbPesoLiquidoTotal.Location = new System.Drawing.Point(407, 145);
			this.m_lbPesoLiquidoTotal.Name = "m_lbPesoLiquidoTotal";
			this.m_lbPesoLiquidoTotal.Size = new System.Drawing.Size(104, 16);
			this.m_lbPesoLiquidoTotal.TabIndex = 79;
			this.m_lbPesoLiquidoTotal.Text = "Peso Liquido Total:";
			// 
			// frmFProdutosConteudoP1CN
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(672, 214);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmFProdutosConteudoP1CN";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Embalando Produtos";
			this.Load += new System.EventHandler(this.frmFProdutosConteudoP1CN_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFProdutosConteudoP1CN_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					vRefreshInterface();
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
					m_bModificado = true;
					this.Close();
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

				private void m_txtPesoLiquidoUnitario_TextChanged(object sender, System.EventArgs e)
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
							}catch{
								dPesoLiquidoUnitario = 0;
							}
							vPesoLiquidoTotal(dPesoLiquidoUnitario * dQuantidade);
						}
					}
				}

				private void m_txtPesoLiquidoTotal_Leave(object sender, System.EventArgs e)
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
							}catch{
								dPesoLiquidoTotal = 0;
							}
							vPesoLiquidoUnitario(dPesoLiquidoTotal / dQuantidade);
						}
					}
				}


				private void m_txtQuantidade_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
				{
					if (e.KeyCode == System.Windows.Forms.Keys.Enter)
					{
						m_txtPesoLiquidoUnitario.Focus();
					}
				}

				private void m_txtPesoLiquidoTotal_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
				{
					if (e.KeyCode == System.Windows.Forms.Keys.Enter)
					{
						if (m_lvEmbalagens.SelectedItems.Count > 0)
						{
							int nIndex = m_lvEmbalagens.Items.IndexOf(m_lvEmbalagens.SelectedItems[0]);
							if (nIndex < (m_lvEmbalagens.Items.Count - 1))
							{
								System.Windows.Forms.ListViewItem lviEmbalagem = m_lvEmbalagens.Items[(nIndex + 1)];
								lviEmbalagem.Selected = true;
								m_txtQuantidade.Focus();
							}
							else
							{
								m_lvEmbalagens.Items[0].Selected = true;
								m_btOk.Focus();
							}
						}
						else
						{
							m_btOk.Focus();
						}
					}
				}

				private void vPesoLiquidoUnitario(double dValor)
				{
					m_txtPesoLiquidoUnitario.Text = mdlConversao.clsTruncamento.dTrunca(dValor,clsProdutosRomaneio.PRECISAO_PESOLIQUIDO_TOTAL,4).ToString("R");
				}

				private void vPesoLiquidoTotal(double dValor)
				{
					m_txtPesoLiquidoTotal.Text = mdlConversao.clsTruncamento.dTrunca(dValor,clsProdutosRomaneio.PRECISAO_PESOLIQUIDO_TOTAL).ToString("R");
				}
			#endregion
			#region ListView
				private void m_lvEmbalagens_SelectedIndexChanged(object sender, System.EventArgs e)
				{
					if (m_lvEmbalagens.SelectedItems.Count > 0)
					{
						string strEmbalagem = m_lvEmbalagens.SelectedItems[0].Text;
						if (m_strUltimaEmbalagem != "")
						{
							double dQuantidade = 0;
							if (m_txtQuantidade.Text.Trim() != "")
								dQuantidade = Double.Parse(m_txtQuantidade.Text.Trim());
							double dPesoLiquido = 0;
							if (m_txtPesoLiquidoUnitario.Text.Trim() != "")
								dPesoLiquido = Double.Parse(m_txtPesoLiquidoUnitario.Text.Trim());
							if (dQuantidade <= (dRetornaQuantidadeRestante() + dRetornaQuantidadeProdutoEmbalagem(strEmbalagem)))
								vInsereProdutoEmbalagem(m_strUltimaEmbalagem,dQuantidade,dPesoLiquido,m_nUnidadeMassaPesoLiquido);
						}
						m_strUltimaEmbalagem = strEmbalagem;
						m_txtQuantidade.Text = (dRetornaQuantidadeRestante() + dRetornaQuantidadeProdutoEmbalagem(strEmbalagem)).ToString();
					}
				}
			#endregion
		#endregion
		#region Cores Formulario
			private void vMostraCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
				this.BackColor = clsPaletaCores.retornaCorAtual();
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					ctrControleChild = this.Controls[nCont];
					vPaintControl(ref ctrControleChild,this.BackColor);
				}
			}

			private void vPaintControl(ref System.Windows.Forms.Control ctrControle,System.Drawing.Color clrBackColor)
			{
				switch(ctrControle.GetType().ToString())
				{
					case "mdlComponentesGraficos.ListView":
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TextBox":
						break;

					default:
						ctrControle.BackColor = clrBackColor;
						break;
				}
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < ctrControle.Controls.Count; nCont++)
				{
					ctrControleChild = ctrControle.Controls[nCont];
					vPaintControl(ref ctrControleChild,clrBackColor);
				}
			}
		#endregion
		#region Refresh
			private void vRefreshInterface()
			{
				m_txtProduto.Text = m_strDescricaoProduto;
				vRefreshEmbalagens();
			}

			private void vRefreshEmbalagens()
			{
				m_lvEmbalagens.Items.Clear();
				for(int i = 0; i < m_arlEmbalagens.Count;i++)
				{
					m_lvEmbalagens.Items.Add(m_arlEmbalagens[i].ToString());
				}
				if (m_lvEmbalagens.Items.Count > 0)
					m_lvEmbalagens.Items[0].Selected = true;
			}
		#endregion

		#region ProdutoFatura
			private double dRetornaQuantidadeRestante()
			{
				double dRetorno = m_dQuantidadeTotalProduto;
				// Embalagens
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutoEmbalagem in m_typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows)
				{
					if (dtrwProdutoEmbalagem.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwProdutoEmbalagem.nIdOrdemProduto == m_nIdOrdemProduto)
						{
							dRetorno = System.Math.Round(dRetorno - dtrwProdutoEmbalagem.dQuantidade,8);
						}
					}
				}
 				// Volumes
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutoVolume in m_typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows)
				{
					if (dtrwProdutoVolume.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwProdutoVolume.nIdOrdemProduto == m_nIdOrdemProduto)
						{
							dRetorno = System.Math.Round(dRetorno - dtrwProdutoVolume.dQuantidade,8);
						}
					}
				}
				return(dRetorno);
			}
		#endregion
		#region Embalagem
			private double dRetornaQuantidadeProdutoEmbalagem(string m_strEmbalagem)
			{
				double dRetorno = 0;
				if (!m_bVolume)
				{
					// Embalagem
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutoEmbalagem in m_typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows)
					{
						if (dtrwProdutoEmbalagem.RowState != System.Data.DataRowState.Deleted)
						{
							if ((dtrwProdutoEmbalagem.strIdEmbalagem == m_strEmbalagem) && (dtrwProdutoEmbalagem.nIdOrdemProduto == m_nIdOrdemProduto))
							{
								dRetorno = dtrwProdutoEmbalagem.dQuantidade;
								break;
							}
						}
					}
				}
				else
				{
					// Volume
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutoVolume in m_typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows)
					{
						if (dtrwProdutoVolume.RowState != System.Data.DataRowState.Deleted)
						{
							if ((dtrwProdutoVolume.strNumeroVolume == m_strEmbalagem) && (dtrwProdutoVolume.nIdOrdemProduto == m_nIdOrdemProduto))
							{
								dRetorno = dtrwProdutoVolume.dQuantidade;
								break;
							}
						}
					}
				}
				return(dRetorno);
			}

			private void vInsereProdutoEmbalagem(string strEmbalagem,double dQuantidade,double dPesoLiquido,int nUnidadeMassa)
			{
				if (!m_bVolume) // Embalagem
					vInsereProdutoEmbalagemEmbalagem(strEmbalagem,dQuantidade,dPesoLiquido,nUnidadeMassa);
				else // Volume 
					vInsereProdutoEmbalagemVolume(strEmbalagem,dQuantidade,dPesoLiquido,nUnidadeMassa);
		   }

			private void vInsereProdutoEmbalagemEmbalagem(string strEmbalagem,double dQuantidade,double dPesoLiquido,int nUnidadeMassa)
			{
				// COLOCAR CODIGO 
			}

			private void vInsereProdutoEmbalagemVolume(string strEmbalagem,double dQuantidade,double dPesoLiquido,int nUnidadeMassa)
			{
				bool bMustAdd = true;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutoVolume in m_typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows)
				{
					if (dtrwProdutoVolume.RowState != System.Data.DataRowState.Deleted)
					{
						if ((dtrwProdutoVolume.idExportador == m_nIdExportador) && (dtrwProdutoVolume.idPE == m_strIdPE) && (dtrwProdutoVolume.strNumeroVolume == strEmbalagem) && (dtrwProdutoVolume.nIdOrdemProduto == m_nIdOrdemProduto))
						{
							dtrwProdutoVolume.dQuantidade = dQuantidade;
							dtrwProdutoVolume.dPesoLiquido = dPesoLiquido;
							dtrwProdutoVolume.nUnidadeMassaPesoLiquido = nUnidadeMassa;
							bMustAdd = false;
							break;
						}
					}
				}
				if (bMustAdd)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProduto = m_typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.NewtbProdutosRomaneioVolumesProdutosRow();

					dtrwProduto.idExportador = m_nIdExportador;
					dtrwProduto.idPE = m_strIdPE;
					dtrwProduto.strNumeroVolume = strEmbalagem;
					dtrwProduto.nIdOrdemProduto = m_nIdOrdemProduto;
					dtrwProduto.dQuantidade = dQuantidade;
					dtrwProduto.dPesoLiquido = dPesoLiquido;
					dtrwProduto.nUnidadeMassaPesoLiquido = nUnidadeMassa;

					m_typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows.Add(dtrwProduto);
				}
			}
		#endregion

		#region Retorno
		#endregion
	}
}

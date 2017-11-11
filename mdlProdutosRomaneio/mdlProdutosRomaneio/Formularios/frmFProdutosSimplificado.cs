using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosRomaneio
{
	/// <summary>
	/// Summary description for frmFProdutosSimplificado.
	/// </summary>
	internal class frmFProdutosSimplificado : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDadosInterfaceProdutosFatura(ref mdlComponentesGraficos.TreeView tvProdutosFatura);
			public delegate void delCallCarregaDadosInterfaceProdutosRomaneio(ref mdlComponentesGraficos.ListView lvProdutosVolume);
			public delegate void delCallCarregaDadosFaturaComercial(out string strPesoLiquido,out string strPesoBruto);
			public delegate void delCallCarregaDadosRomaneio(out string strPesoLiquido,out string strPesoBruto,out double dDiferencaPesoLiquido,out double dDiferencaPesoBruto);
			public delegate bool delCallShowDialogVinculo(int nIdOrdem);
			public delegate bool delCallShowDialogVinculoEditar(int nIdOrdem);
			public delegate bool delCallVinculoRemover(int nIdOrdem);
			public delegate bool delCallTrocaOrdemProdutos(int nIdOrdem1,int nIdOrdem2);
			public delegate bool delCallSalvaDados();
			public delegate bool delCallShowDialogAutomatico();
		#endregion
		#region Events
			public event delCallCarregaDadosInterfaceProdutosFatura eCallCarregaDadosInterfaceProdutosFatura;
			public event delCallCarregaDadosInterfaceProdutosRomaneio eCallCarregaDadosInterfaceProdutosRomaneio;
			public event delCallCarregaDadosFaturaComercial eCallCarregaDadosFaturaComercial;
			public event delCallCarregaDadosRomaneio eCallCarregaDadosRomaneio;
			public event delCallShowDialogVinculo eCallShowDialogVinculo;
			public event delCallShowDialogVinculoEditar eCallShowDialogVinculoEditar;
			public event delCallVinculoRemover eCallVinculoRemover;
			public event delCallTrocaOrdemProdutos eCallTrocaOrdemProdutos;
			public event delCallSalvaDados eCallSalvaDados;
			public event delCallShowDialogAutomatico eCallShowDialogAutomatico;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDadosInterfaceProdutosFatura()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallCarregaDadosInterfaceProdutosFatura != null)
					eCallCarregaDadosInterfaceProdutosFatura(ref m_tvProdutosFatura);
				OnCallCarregaDadosRomaneio();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallCarregaDadosInterfaceProdutosRomaneio()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallCarregaDadosInterfaceProdutosRomaneio != null)
					eCallCarregaDadosInterfaceProdutosRomaneio(ref m_lvProdutosRomaneio);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallCarregaDadosFaturaComercial()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallCarregaDadosFaturaComercial != null)
				{
					string strPesoLiquido, strPesoBruto;
					eCallCarregaDadosFaturaComercial(out strPesoLiquido,out strPesoBruto);
					m_txtPesoLiquidoFaturaComercial.Text = strPesoLiquido;
					m_txtPesoBrutoFaturaComercial.Text = strPesoBruto;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallCarregaDadosRomaneio()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallCarregaDadosRomaneio != null)
				{
					string strPesoLiquido, strPesoBruto;
					double dDiferencaPesoLiquido,dDiferencaPesoBruto;
					eCallCarregaDadosRomaneio(out strPesoLiquido,out strPesoBruto,out dDiferencaPesoLiquido,out dDiferencaPesoBruto);
												
					// Peso Liquido 
					m_txtPesoLiquidoRomaneio.Text = strPesoLiquido;
					if (dDiferencaPesoLiquido == 0)
					{
						m_lbPesoLiquidoRomaneio.ForeColor = m_clrNeutral;
					}
					else
					{
						if (dDiferencaPesoLiquido > 0)
						{
							m_lbPesoLiquidoRomaneio.ForeColor = m_clrPositive;
						}
						else
						{
							m_lbPesoLiquidoRomaneio.ForeColor = m_clrNegative;
						}
					}

					// Peso Bruto
					m_txtPesoBrutoRomaneio.Text = strPesoBruto;
					if (dDiferencaPesoBruto == 0)
					{
						m_lbPesoBrutoRomaneio.ForeColor = m_clrNeutral;
					}
					else
					{
						if (dDiferencaPesoBruto > 0)
						{
							m_lbPesoBrutoRomaneio.ForeColor = m_clrPositive;
						}
						else
						{
							m_lbPesoBrutoRomaneio.ForeColor = m_clrNegative;
						}
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallShowDialogVinculo()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallShowDialogVinculo != null)
				{
					if (m_tvProdutosFatura.SelectedNode != null)
					{
						bRetorno = eCallShowDialogVinculo(Int32.Parse(m_tvProdutosFatura.SelectedNode.Tag.ToString()));
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallShowDialogVinculoEditar()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallShowDialogVinculoEditar != null)
				{
					if (m_lvProdutosRomaneio.SelectedItems.Count > 0)
					{
						bRetorno = eCallShowDialogVinculoEditar(Int32.Parse(m_lvProdutosRomaneio.SelectedItems[0].Tag.ToString()));
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallVinculoRemover()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallVinculoRemover != null)
				{
					if (m_lvProdutosRomaneio.SelectedItems.Count > 0)
					{
						bRetorno = eCallVinculoRemover(Int32.Parse(m_lvProdutosRomaneio.SelectedItems[0].Tag.ToString()));
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallTrocaOrdemProdutos(int nIdOrdem1,int nIdOrdem2)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallTrocaOrdemProdutos != null)
					bRetorno = eCallTrocaOrdemProdutos(nIdOrdem1,nIdOrdem2);
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallPesosCorretos()
			{
				bool bRetorno = false;
				if (eCallCarregaDadosRomaneio != null)
				{
					string strPesoLiquido, strPesoBruto;
					double dDiferencaPesoLiquido,dDiferencaPesoBruto;
					eCallCarregaDadosRomaneio(out strPesoLiquido,out strPesoBruto,out dDiferencaPesoLiquido,out dDiferencaPesoBruto);
					if ((dDiferencaPesoLiquido == 0) && (dDiferencaPesoBruto == 0))
					{
						bRetorno = true;
					}
					else
					{
						if (mdlMensagens.clsMensagens.ShowQuestion(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFProdutos_PesosRomaneioNaoBatemComFatura)) == System.Windows.Forms.DialogResult.Yes)
						{
							bRetorno = true;
						}
					}
				}
				return(bRetorno);
			}

			protected virtual bool OnCallSalvaDados()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallSalvaDados != null)
					bRetorno = eCallSalvaDados();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallShowDialogAutomatico()
			{
				if (eCallShowDialogAutomatico == null)
					return(false);
				return(eCallShowDialogAutomatico());
			}
		#endregion

		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel;

			public bool m_bModificado = false;
			public bool m_bResposta = false;

			//private bool m_bShowBalloonTips = true;

			private System.Drawing.Color m_clrPositive = System.Drawing.Color.DarkSalmon;
			private System.Drawing.Color m_clrNeutral = System.Drawing.Color.Green;
			private System.Drawing.Color m_clrNegative = System.Drawing.Color.Red;
		private System.ComponentModel.IContainer components;
			internal System.Windows.Forms.GroupBox m_gbProdutosFaturaComercial;
			private mdlComponentesGraficos.TreeView m_tvProdutosFatura;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbInformacoes;
			private System.Windows.Forms.GroupBox m_gbRomaneio;
			private System.Windows.Forms.TextBox m_txtPesoBrutoRomaneio;
			private System.Windows.Forms.Label m_lbPesoBrutoRomaneio;
			private System.Windows.Forms.TextBox m_txtPesoLiquidoRomaneio;
			private System.Windows.Forms.Label m_lbPesoLiquidoRomaneio;
			private System.Windows.Forms.GroupBox m_gbFaturaComercial;
			private System.Windows.Forms.TextBox m_txtPesoBrutoFaturaComercial;
			private System.Windows.Forms.Label m_lbPesoBrutoFaturaComercial;
			private System.Windows.Forms.TextBox m_txtPesoLiquidoFaturaComercial;
			private System.Windows.Forms.Label m_lbPesoLiquidoFaturaComercial;
			private System.Windows.Forms.GroupBox m_gbProdutosRomaneio;
			private mdlComponentesGraficos.ListView m_lvProdutosRomaneio;
			public System.Windows.Forms.Button m_btProdutoAcima;
			public System.Windows.Forms.Button m_btProdutoAbaixo;
			private System.Windows.Forms.Button m_btProdutoDesvincula;
			private System.Windows.Forms.Button m_btProdutoVincula;
		private System.Windows.Forms.ColumnHeader m_colhQuantidadeProduto;
		private System.Windows.Forms.ColumnHeader m_colhQuantidadeVolumes;
		private System.Windows.Forms.ColumnHeader m_colhProduto;
		private System.Windows.Forms.ToolTip m_ttDicas;
		private System.Windows.Forms.Button m_btAutomatico;
			private System.Windows.Forms.GroupBox m_gbGeral;
		#endregion
		#region Constuctors and Destructors
			public frmFProdutosSimplificado(ref mdlTratamentoErro.clsTratamentoErro TratadorErro, string strEnderecoExecutavel)
			{
				m_cls_ter_tratadorErro = TratadorErro;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutosSimplificado));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btAutomatico = new System.Windows.Forms.Button();
			this.m_btProdutoDesvincula = new System.Windows.Forms.Button();
			this.m_btProdutoVincula = new System.Windows.Forms.Button();
			this.m_gbProdutosRomaneio = new System.Windows.Forms.GroupBox();
			this.m_btProdutoAcima = new System.Windows.Forms.Button();
			this.m_btProdutoAbaixo = new System.Windows.Forms.Button();
			this.m_lvProdutosRomaneio = new mdlComponentesGraficos.ListView();
			this.m_colhQuantidadeProduto = new System.Windows.Forms.ColumnHeader();
			this.m_colhQuantidadeVolumes = new System.Windows.Forms.ColumnHeader();
			this.m_colhProduto = new System.Windows.Forms.ColumnHeader();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_gbRomaneio = new System.Windows.Forms.GroupBox();
			this.m_txtPesoBrutoRomaneio = new System.Windows.Forms.TextBox();
			this.m_lbPesoBrutoRomaneio = new System.Windows.Forms.Label();
			this.m_txtPesoLiquidoRomaneio = new System.Windows.Forms.TextBox();
			this.m_lbPesoLiquidoRomaneio = new System.Windows.Forms.Label();
			this.m_gbFaturaComercial = new System.Windows.Forms.GroupBox();
			this.m_txtPesoBrutoFaturaComercial = new System.Windows.Forms.TextBox();
			this.m_lbPesoBrutoFaturaComercial = new System.Windows.Forms.Label();
			this.m_txtPesoLiquidoFaturaComercial = new System.Windows.Forms.TextBox();
			this.m_lbPesoLiquidoFaturaComercial = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbProdutosFaturaComercial = new System.Windows.Forms.GroupBox();
			this.m_tvProdutosFatura = new mdlComponentesGraficos.TreeView();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbProdutosRomaneio.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.m_gbRomaneio.SuspendLayout();
			this.m_gbFaturaComercial.SuspendLayout();
			this.m_gbProdutosFaturaComercial.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_btAutomatico);
			this.m_gbGeral.Controls.Add(this.m_btProdutoDesvincula);
			this.m_gbGeral.Controls.Add(this.m_btProdutoVincula);
			this.m_gbGeral.Controls.Add(this.m_gbProdutosRomaneio);
			this.m_gbGeral.Controls.Add(this.m_gbInformacoes);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbProdutosFaturaComercial);
			this.m_gbGeral.Location = new System.Drawing.Point(3, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(738, 489);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btAutomatico
			// 
			this.m_btAutomatico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btAutomatico.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btAutomatico.Image = ((System.Drawing.Image)(resources.GetObject("m_btAutomatico.Image")));
			this.m_btAutomatico.Location = new System.Drawing.Point(704, 200);
			this.m_btAutomatico.Name = "m_btAutomatico";
			this.m_btAutomatico.Size = new System.Drawing.Size(25, 25);
			this.m_btAutomatico.TabIndex = 16;
			this.m_ttDicas.SetToolTip(this.m_btAutomatico, "Automatizar o preenchimento do Romaneio");
			this.m_btAutomatico.Click += new System.EventHandler(this.m_btAutomatico_Click);
			// 
			// m_btProdutoDesvincula
			// 
			this.m_btProdutoDesvincula.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutoDesvincula.Image = ((System.Drawing.Image)(resources.GetObject("m_btProdutoDesvincula.Image")));
			this.m_btProdutoDesvincula.Location = new System.Drawing.Point(376, 195);
			this.m_btProdutoDesvincula.Name = "m_btProdutoDesvincula";
			this.m_btProdutoDesvincula.Size = new System.Drawing.Size(60, 40);
			this.m_btProdutoDesvincula.TabIndex = 13;
			this.m_ttDicas.SetToolTip(this.m_btProdutoDesvincula, "Remover o produto no romaneio");
			this.m_btProdutoDesvincula.Click += new System.EventHandler(this.m_btProdutoDesvincula_Click);
			// 
			// m_btProdutoVincula
			// 
			this.m_btProdutoVincula.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutoVincula.Image = ((System.Drawing.Image)(resources.GetObject("m_btProdutoVincula.Image")));
			this.m_btProdutoVincula.Location = new System.Drawing.Point(304, 195);
			this.m_btProdutoVincula.Name = "m_btProdutoVincula";
			this.m_btProdutoVincula.Size = new System.Drawing.Size(60, 40);
			this.m_btProdutoVincula.TabIndex = 12;
			this.m_ttDicas.SetToolTip(this.m_btProdutoVincula, "Inserir o produto no romaneio");
			this.m_btProdutoVincula.Click += new System.EventHandler(this.m_btProdutoVincula_Click);
			// 
			// m_gbProdutosRomaneio
			// 
			this.m_gbProdutosRomaneio.Controls.Add(this.m_btProdutoAcima);
			this.m_gbProdutosRomaneio.Controls.Add(this.m_btProdutoAbaixo);
			this.m_gbProdutosRomaneio.Controls.Add(this.m_lvProdutosRomaneio);
			this.m_gbProdutosRomaneio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbProdutosRomaneio.Location = new System.Drawing.Point(8, 232);
			this.m_gbProdutosRomaneio.Name = "m_gbProdutosRomaneio";
			this.m_gbProdutosRomaneio.Size = new System.Drawing.Size(720, 168);
			this.m_gbProdutosRomaneio.TabIndex = 11;
			this.m_gbProdutosRomaneio.TabStop = false;
			this.m_gbProdutosRomaneio.Text = "Produtos Vinculados ao Romaneio";
			// 
			// m_btProdutoAcima
			// 
			this.m_btProdutoAcima.BackColor = System.Drawing.SystemColors.Control;
			this.m_btProdutoAcima.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutoAcima.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btProdutoAcima.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btProdutoAcima.Image = ((System.Drawing.Image)(resources.GetObject("m_btProdutoAcima.Image")));
			this.m_btProdutoAcima.Location = new System.Drawing.Point(4, 56);
			this.m_btProdutoAcima.Name = "m_btProdutoAcima";
			this.m_btProdutoAcima.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btProdutoAcima.Size = new System.Drawing.Size(25, 25);
			this.m_btProdutoAcima.TabIndex = 62;
			this.m_ttDicas.SetToolTip(this.m_btProdutoAcima, "Mover o produto selecionado para cima");
			this.m_btProdutoAcima.Click += new System.EventHandler(this.m_btProdutoAcima_Click);
			// 
			// m_btProdutoAbaixo
			// 
			this.m_btProdutoAbaixo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btProdutoAbaixo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutoAbaixo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btProdutoAbaixo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btProdutoAbaixo.Image = ((System.Drawing.Image)(resources.GetObject("m_btProdutoAbaixo.Image")));
			this.m_btProdutoAbaixo.Location = new System.Drawing.Point(4, 88);
			this.m_btProdutoAbaixo.Name = "m_btProdutoAbaixo";
			this.m_btProdutoAbaixo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btProdutoAbaixo.Size = new System.Drawing.Size(25, 25);
			this.m_btProdutoAbaixo.TabIndex = 63;
			this.m_ttDicas.SetToolTip(this.m_btProdutoAbaixo, "Mover o produto selecionado para baixo");
			this.m_btProdutoAbaixo.Click += new System.EventHandler(this.m_btProdutoAbaixo_Click);
			// 
			// m_lvProdutosRomaneio
			// 
			this.m_lvProdutosRomaneio.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								   this.m_colhQuantidadeProduto,
																								   this.m_colhQuantidadeVolumes,
																								   this.m_colhProduto});
			this.m_lvProdutosRomaneio.FullRowSelect = true;
			this.m_lvProdutosRomaneio.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lvProdutosRomaneio.HideSelection = false;
			this.m_lvProdutosRomaneio.Location = new System.Drawing.Point(32, 16);
			this.m_lvProdutosRomaneio.MultiSelect = false;
			this.m_lvProdutosRomaneio.Name = "m_lvProdutosRomaneio";
			this.m_lvProdutosRomaneio.Size = new System.Drawing.Size(680, 144);
			this.m_lvProdutosRomaneio.TabIndex = 0;
			this.m_lvProdutosRomaneio.View = System.Windows.Forms.View.Details;
			this.m_lvProdutosRomaneio.DoubleClick += new System.EventHandler(this.m_lvProdutosRomaneio_DoubleClick);
			// 
			// m_colhQuantidadeProduto
			// 
			this.m_colhQuantidadeProduto.Text = "Quantidade Produto";
			this.m_colhQuantidadeProduto.Width = 123;
			// 
			// m_colhQuantidadeVolumes
			// 
			this.m_colhQuantidadeVolumes.Text = "Quantidade Volumes";
			this.m_colhQuantidadeVolumes.Width = 128;
			// 
			// m_colhProduto
			// 
			this.m_colhProduto.Text = "Produto";
			this.m_colhProduto.Width = 422;
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Controls.Add(this.m_gbRomaneio);
			this.m_gbInformacoes.Controls.Add(this.m_gbFaturaComercial);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(9, 400);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(720, 56);
			this.m_gbInformacoes.TabIndex = 10;
			this.m_gbInformacoes.TabStop = false;
			this.m_gbInformacoes.Text = "Informações";
			// 
			// m_gbRomaneio
			// 
			this.m_gbRomaneio.Controls.Add(this.m_txtPesoBrutoRomaneio);
			this.m_gbRomaneio.Controls.Add(this.m_lbPesoBrutoRomaneio);
			this.m_gbRomaneio.Controls.Add(this.m_txtPesoLiquidoRomaneio);
			this.m_gbRomaneio.Controls.Add(this.m_lbPesoLiquidoRomaneio);
			this.m_gbRomaneio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbRomaneio.Location = new System.Drawing.Point(363, 12);
			this.m_gbRomaneio.Name = "m_gbRomaneio";
			this.m_gbRomaneio.Size = new System.Drawing.Size(345, 38);
			this.m_gbRomaneio.TabIndex = 1;
			this.m_gbRomaneio.TabStop = false;
			this.m_gbRomaneio.Text = "Romaneio";
			// 
			// m_txtPesoBrutoRomaneio
			// 
			this.m_txtPesoBrutoRomaneio.Location = new System.Drawing.Point(241, 12);
			this.m_txtPesoBrutoRomaneio.Name = "m_txtPesoBrutoRomaneio";
			this.m_txtPesoBrutoRomaneio.ReadOnly = true;
			this.m_txtPesoBrutoRomaneio.Size = new System.Drawing.Size(87, 20);
			this.m_txtPesoBrutoRomaneio.TabIndex = 3;
			this.m_txtPesoBrutoRomaneio.Text = "";
			// 
			// m_lbPesoBrutoRomaneio
			// 
			this.m_lbPesoBrutoRomaneio.Location = new System.Drawing.Point(175, 15);
			this.m_lbPesoBrutoRomaneio.Name = "m_lbPesoBrutoRomaneio";
			this.m_lbPesoBrutoRomaneio.Size = new System.Drawing.Size(80, 16);
			this.m_lbPesoBrutoRomaneio.TabIndex = 2;
			this.m_lbPesoBrutoRomaneio.Text = "Peso Bruto:";
			// 
			// m_txtPesoLiquidoRomaneio
			// 
			this.m_txtPesoLiquidoRomaneio.Location = new System.Drawing.Point(81, 12);
			this.m_txtPesoLiquidoRomaneio.Name = "m_txtPesoLiquidoRomaneio";
			this.m_txtPesoLiquidoRomaneio.ReadOnly = true;
			this.m_txtPesoLiquidoRomaneio.Size = new System.Drawing.Size(87, 20);
			this.m_txtPesoLiquidoRomaneio.TabIndex = 1;
			this.m_txtPesoLiquidoRomaneio.Text = "";
			// 
			// m_lbPesoLiquidoRomaneio
			// 
			this.m_lbPesoLiquidoRomaneio.Location = new System.Drawing.Point(9, 15);
			this.m_lbPesoLiquidoRomaneio.Name = "m_lbPesoLiquidoRomaneio";
			this.m_lbPesoLiquidoRomaneio.Size = new System.Drawing.Size(80, 16);
			this.m_lbPesoLiquidoRomaneio.TabIndex = 0;
			this.m_lbPesoLiquidoRomaneio.Text = "Peso Líquido:";
			// 
			// m_gbFaturaComercial
			// 
			this.m_gbFaturaComercial.Controls.Add(this.m_txtPesoBrutoFaturaComercial);
			this.m_gbFaturaComercial.Controls.Add(this.m_lbPesoBrutoFaturaComercial);
			this.m_gbFaturaComercial.Controls.Add(this.m_txtPesoLiquidoFaturaComercial);
			this.m_gbFaturaComercial.Controls.Add(this.m_lbPesoLiquidoFaturaComercial);
			this.m_gbFaturaComercial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFaturaComercial.Location = new System.Drawing.Point(7, 12);
			this.m_gbFaturaComercial.Name = "m_gbFaturaComercial";
			this.m_gbFaturaComercial.Size = new System.Drawing.Size(345, 38);
			this.m_gbFaturaComercial.TabIndex = 0;
			this.m_gbFaturaComercial.TabStop = false;
			this.m_gbFaturaComercial.Text = "Fatura Comercial";
			// 
			// m_txtPesoBrutoFaturaComercial
			// 
			this.m_txtPesoBrutoFaturaComercial.Location = new System.Drawing.Point(241, 12);
			this.m_txtPesoBrutoFaturaComercial.Name = "m_txtPesoBrutoFaturaComercial";
			this.m_txtPesoBrutoFaturaComercial.ReadOnly = true;
			this.m_txtPesoBrutoFaturaComercial.Size = new System.Drawing.Size(87, 20);
			this.m_txtPesoBrutoFaturaComercial.TabIndex = 3;
			this.m_txtPesoBrutoFaturaComercial.Text = "";
			// 
			// m_lbPesoBrutoFaturaComercial
			// 
			this.m_lbPesoBrutoFaturaComercial.Location = new System.Drawing.Point(175, 15);
			this.m_lbPesoBrutoFaturaComercial.Name = "m_lbPesoBrutoFaturaComercial";
			this.m_lbPesoBrutoFaturaComercial.Size = new System.Drawing.Size(80, 16);
			this.m_lbPesoBrutoFaturaComercial.TabIndex = 2;
			this.m_lbPesoBrutoFaturaComercial.Text = "Peso Bruto:";
			// 
			// m_txtPesoLiquidoFaturaComercial
			// 
			this.m_txtPesoLiquidoFaturaComercial.Location = new System.Drawing.Point(81, 12);
			this.m_txtPesoLiquidoFaturaComercial.Name = "m_txtPesoLiquidoFaturaComercial";
			this.m_txtPesoLiquidoFaturaComercial.ReadOnly = true;
			this.m_txtPesoLiquidoFaturaComercial.Size = new System.Drawing.Size(87, 20);
			this.m_txtPesoLiquidoFaturaComercial.TabIndex = 1;
			this.m_txtPesoLiquidoFaturaComercial.Text = "";
			// 
			// m_lbPesoLiquidoFaturaComercial
			// 
			this.m_lbPesoLiquidoFaturaComercial.Location = new System.Drawing.Point(9, 15);
			this.m_lbPesoLiquidoFaturaComercial.Name = "m_lbPesoLiquidoFaturaComercial";
			this.m_lbPesoLiquidoFaturaComercial.Size = new System.Drawing.Size(80, 16);
			this.m_lbPesoLiquidoFaturaComercial.TabIndex = 0;
			this.m_lbPesoLiquidoFaturaComercial.Text = "Peso Líquido:";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(308, 459);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 8;
			this.m_ttDicas.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(372, 459);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 9;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbProdutosFaturaComercial
			// 
			this.m_gbProdutosFaturaComercial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbProdutosFaturaComercial.Controls.Add(this.m_tvProdutosFatura);
			this.m_gbProdutosFaturaComercial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbProdutosFaturaComercial.Location = new System.Drawing.Point(5, 8);
			this.m_gbProdutosFaturaComercial.Name = "m_gbProdutosFaturaComercial";
			this.m_gbProdutosFaturaComercial.Size = new System.Drawing.Size(728, 184);
			this.m_gbProdutosFaturaComercial.TabIndex = 2;
			this.m_gbProdutosFaturaComercial.TabStop = false;
			this.m_gbProdutosFaturaComercial.Text = "Produtos ";
			// 
			// m_tvProdutosFatura
			// 
			this.m_tvProdutosFatura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tvProdutosFatura.HideSelection = false;
			this.m_tvProdutosFatura.ImageIndex = -1;
			this.m_tvProdutosFatura.Location = new System.Drawing.Point(8, 15);
			this.m_tvProdutosFatura.Name = "m_tvProdutosFatura";
			this.m_tvProdutosFatura.SelectedImageIndex = -1;
			this.m_tvProdutosFatura.Size = new System.Drawing.Size(712, 161);
			this.m_tvProdutosFatura.TabIndex = 0;
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFProdutosSimplificado
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(744, 496);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutosSimplificado";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lançamento dos produtos no romaneio.";
			this.Load += new System.EventHandler(this.frmFProdutosSimplificado_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbProdutosRomaneio.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.m_gbRomaneio.ResumeLayout(false);
			this.m_gbFaturaComercial.ResumeLayout(false);
			this.m_gbProdutosFaturaComercial.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFProdutosSimplificado_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallCarregaDadosInterfaceProdutosFatura();
					OnCallCarregaDadosInterfaceProdutosRomaneio();
					OnCallCarregaDadosFaturaComercial();
					OnCallCarregaDadosRomaneio();
				}
			#endregion
			#region ListView
				private void m_lvProdutosRomaneio_DoubleClick(object sender, System.EventArgs e)
				{
					if (OnCallShowDialogVinculoEditar())
					{
						OnCallCarregaDadosInterfaceProdutosFatura();
						OnCallCarregaDadosInterfaceProdutosRomaneio();
					}
				}
			#endregion
			#region Botoes
				private void m_btProdutoVincula_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowDialogVinculo())
					{
						OnCallCarregaDadosInterfaceProdutosFatura();
						OnCallCarregaDadosInterfaceProdutosRomaneio();
					}
				}

				private void m_btProdutoDesvincula_Click(object sender, System.EventArgs e)
				{
					if (OnCallVinculoRemover())
					{
						OnCallCarregaDadosInterfaceProdutosFatura();
						OnCallCarregaDadosInterfaceProdutosRomaneio();
					}
				}

				private void m_btProdutoAcima_Click(object sender, System.EventArgs e)
				{
                    vMoveProdutoParaCima();				
				}

				private void m_btProdutoAbaixo_Click(object sender, System.EventArgs e)
				{
					vMoveProdutoParaBaixo();				
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (OnCallPesosCorretos())
						if (this.m_bModificado = OnCallSalvaDados())
							this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.m_bModificado = false;
					this.Close();
				}

				private void m_btAutomatico_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowDialogAutomatico())
					{
						OnCallCarregaDadosInterfaceProdutosFatura();
						OnCallCarregaDadosInterfaceProdutosRomaneio();
					}
				}
			#endregion
		#endregion

		#region Cores
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
					case "mdlComponentesGraficos.TreeView":
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
		#region TrocaOrdemProdutos
			private void vMoveProdutoParaCima()
			{
				if ((m_lvProdutosRomaneio.SelectedItems.Count > 0) && (m_lvProdutosRomaneio.Items.Count > 1))
				{
					int nIdIndex = m_lvProdutosRomaneio.SelectedItems[0].Index;
					if (nIdIndex > 0)
					{
						if (OnCallTrocaOrdemProdutos(Int32.Parse(m_lvProdutosRomaneio.Items[nIdIndex].Tag.ToString()),Int32.Parse(m_lvProdutosRomaneio.Items[nIdIndex - 1].Tag.ToString())))
						{
							OnCallCarregaDadosInterfaceProdutosRomaneio();
							m_lvProdutosRomaneio.Items[nIdIndex - 1].Selected = true;
						}
					}
				}
			}

			private void vMoveProdutoParaBaixo()
			{
				if ((m_lvProdutosRomaneio.SelectedItems.Count > 0) && (m_lvProdutosRomaneio.Items.Count > 1))
				{
					int nIdIndex = m_lvProdutosRomaneio.SelectedItems[0].Index;
					if (nIdIndex < (m_lvProdutosRomaneio.Items.Count - 1))
					{
						if (OnCallTrocaOrdemProdutos(Int32.Parse(m_lvProdutosRomaneio.Items[nIdIndex].Tag.ToString()),Int32.Parse(m_lvProdutosRomaneio.Items[nIdIndex + 1].Tag.ToString())))
						{
							OnCallCarregaDadosInterfaceProdutosRomaneio();
							m_lvProdutosRomaneio.Items[nIdIndex + 1].Selected = true;
						}
					}
				}
			}
		#endregion

	}
}

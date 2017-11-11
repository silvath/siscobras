using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosCertificadoOrigem.Formularios
{
	/// <summary>
	/// Summary description for frmFProdutosFormARE.
	/// </summary>
	public class frmFProdutosFormARE : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate bool delCallShowRE();
			public delegate void delCallRefreshRE(ref System.Windows.Forms.ListView lvREs);
			public delegate void delCallRefreshProdutosNaoVinculados(ref System.Windows.Forms.ListView lvProdutosNaoVinculados);
			public delegate void delCallRefreshProdutosVinculados(int nIdRe,ref System.Windows.Forms.ListView lvProdutosVinculados);
			public delegate void delCallFormAREConfigure(ref mdlComponentesGraficos.DataGrid dgFormARE);
			public delegate void delCallRefreshFormARE(ref mdlComponentesGraficos.DataGrid dgFormARE);
			public delegate bool delCallProdutoVincula(int nIdRe,int[] nIdOrdemProduto);
			public delegate bool delCallProdutoDesvincula(int[] nIdOrdemProduto);
			public delegate bool delCallPossuiProdutosSemClassificacaoTarifaria();
			public delegate bool delCallShowClassificacaoTarifaria();
			public delegate bool delCallCarregaTamanhoColunas(out int nTamanhoColunaRENumero,out int nTamanhoColunaREData,out int nTamanhoColunaNCM,out int nTamanhoColunaValorFOB,out int nTamanhoColunaPesoLiquido);
			public delegate bool delCallSalvaTamanhoColunas(int nTamanhoColunaRENumero,int nTamanhoColunaREData,int nTamanhoColunaNCM,int nTamanhoColunaValorFOB,int nTamanhoColunaPesoLiquido);
		#endregion
		#region Events
			public event delCallShowRE eCallShowRE;
			public event delCallRefreshRE eCallRefreshRE;
			public event delCallRefreshProdutosNaoVinculados eCallRefreshProdutosNaoVinculados;
			public event delCallRefreshProdutosVinculados eCallRefreshProdutosVinculados;
			public event delCallFormAREConfigure eCallFormAREConfigure;
			public event delCallRefreshFormARE eCallRefreshFormARE;
			public event delCallProdutoVincula eCallProdutoVincula;
			public event delCallProdutoDesvincula eCallProdutoDesvincula;
			public event delCallPossuiProdutosSemClassificacaoTarifaria eCallPossuiProdutosSemClassificacaoTarifaria;
			public event delCallShowClassificacaoTarifaria eCallShowClassificacaoTarifaria;
			public event delCallCarregaTamanhoColunas eCallCarregaTamanhoColunas;
			public event delCallSalvaTamanhoColunas eCallSalvaTamanhoColunas;
		#endregion
		#region Events Methods
			protected bool OnCallShowRE()
			{
				if (eCallShowRE == null)
					return(false);
				return(eCallShowRE());
			}

			protected void OnCallRefreshRE()
			{
				if (eCallRefreshRE != null)
				{
					eCallRefreshRE(ref m_lvREs);
					if (m_lvREs.Items.Count > 0)
						m_lvREs.Items[0].Selected = true;
				}
			}

			protected void OnCallRefreshProdutosNaoVinculados()
			{
				if (eCallRefreshProdutosNaoVinculados != null)
					eCallRefreshProdutosNaoVinculados(ref m_lvProdutosNaoVinculados);
			}

			protected void OnCallRefreshProdutosVinculados()
			{
				if (eCallRefreshProdutosVinculados != null)
				{
					int nIdRe = -1;
					if (m_lvREs.SelectedItems.Count > 0)
						nIdRe = Int32.Parse(m_lvREs.SelectedItems[0].Tag.ToString());
					eCallRefreshProdutosVinculados(nIdRe,ref m_lvProdutosVinculados);
				}
			}

			protected void OnCallFormAREConfigure()
			{
				if (eCallFormAREConfigure != null)
					eCallFormAREConfigure(ref m_dgFormARE);
			}

			protected void OnCallRefreshFormARE()
			{
				if (eCallRefreshFormARE != null)
					eCallRefreshFormARE(ref m_dgFormARE);
			}

			protected bool OnCallProdutoVincula()
			{
				if (eCallProdutoVincula == null)
					return(false);
				if (m_lvREs.SelectedItems.Count == 0)
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve primeiro selecionar um RE");
					return(false);
				}
				if (m_lvProdutosNaoVinculados.SelectedItems.Count == 0)
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve primeiro selecionar um produto a vincular");
					return(false);
				}
				int[] nIdProdutos = new int[m_lvProdutosNaoVinculados.SelectedItems.Count];
				for(int i = 0;i < m_lvProdutosNaoVinculados.SelectedItems.Count;i++)
					nIdProdutos[i] = Int32.Parse(m_lvProdutosNaoVinculados.SelectedItems[i].Tag.ToString());
				return(eCallProdutoVincula(Int32.Parse(m_lvREs.SelectedItems[0].Tag.ToString()),nIdProdutos));
			} 

			protected bool OnCallProdutoDesvincula()
			{
				if (eCallProdutoDesvincula == null)
					return(false);
				if (m_lvProdutosVinculados.SelectedItems.Count == 0)
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve primeiro selecionar um produto a desvincular");
					return(false);
				}
				int[] nIdProdutos = new int[m_lvProdutosVinculados.SelectedItems.Count];
				for(int i = 0;i < m_lvProdutosVinculados.SelectedItems.Count;i++)
					nIdProdutos[i] = Int32.Parse(m_lvProdutosVinculados.SelectedItems[i].Tag.ToString());
				return(eCallProdutoDesvincula(nIdProdutos));
			}
	
			private  bool OnCallPossuiProdutosSemClassificacaoTarifaria()
			{
				if (eCallPossuiProdutosSemClassificacaoTarifaria == null)
					return(false);
				return(eCallPossuiProdutosSemClassificacaoTarifaria());
			}

			private bool OnCallShowClassificacaoTarifaria()
			{
				if (eCallShowClassificacaoTarifaria == null)
					return(false);
				return(eCallShowClassificacaoTarifaria());
			}

			private bool OnCallCarregaTamanhoColunas()
			{
				if (eCallCarregaTamanhoColunas == null)
					return(false);
				int nTamanhoColunaRENumero,nTamanhoColunaREData,nTamanhoColunaNCM,nTamanhoColunaValorFOB,nTamanhoColunaPesoLiquido;
				if (!eCallCarregaTamanhoColunas(out nTamanhoColunaRENumero,out nTamanhoColunaREData,out nTamanhoColunaNCM,out nTamanhoColunaValorFOB,out nTamanhoColunaPesoLiquido))
					return(false);
				m_dgFormARE.TableStyles[0].GridColumnStyles[1].Width = GetCharacter2Pixel(nTamanhoColunaRENumero);
				m_dgFormARE.TableStyles[0].GridColumnStyles[2].Width = GetCharacter2Pixel(nTamanhoColunaREData);
				m_dgFormARE.TableStyles[0].GridColumnStyles[3].Width = GetCharacter2Pixel(nTamanhoColunaNCM);
				m_dgFormARE.TableStyles[0].GridColumnStyles[4].Width = GetCharacter2Pixel(nTamanhoColunaValorFOB);
				m_dgFormARE.TableStyles[0].GridColumnStyles[5].Width = GetCharacter2Pixel(nTamanhoColunaPesoLiquido);
                return(true);
			}

			public bool OnCallSalvaTamanhoColunas()
			{
				if (eCallSalvaTamanhoColunas == null)
					return(false);
				int nTamanhoColunaRENumero,nTamanhoColunaREData,nTamanhoColunaNCM,nTamanhoColunaValorFOB,nTamanhoColunaPesoLiquido;
				nTamanhoColunaRENumero = GetPixel2Character(m_dgFormARE.TableStyles[0].GridColumnStyles[1].Width);
				nTamanhoColunaREData = GetPixel2Character(m_dgFormARE.TableStyles[0].GridColumnStyles[2].Width);
				nTamanhoColunaNCM = GetPixel2Character(m_dgFormARE.TableStyles[0].GridColumnStyles[3].Width);
				nTamanhoColunaValorFOB = GetPixel2Character(m_dgFormARE.TableStyles[0].GridColumnStyles[4].Width);
				nTamanhoColunaPesoLiquido = GetPixel2Character(m_dgFormARE.TableStyles[0].GridColumnStyles[5].Width);
				return(eCallSalvaTamanhoColunas(nTamanhoColunaRENumero,nTamanhoColunaREData,nTamanhoColunaNCM,nTamanhoColunaValorFOB,nTamanhoColunaPesoLiquido));
			} 
		#endregion

		#region Atributes
			private bool m_bConfirmed = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_ggProdutos;
			private System.Windows.Forms.GroupBox m_gbDetalhesRE;
			private System.Windows.Forms.ListView m_lvREs;
			private System.Windows.Forms.GroupBox m_gbREs;
			private System.Windows.Forms.GroupBox m_gbProdutosVinculados;
			private System.Windows.Forms.GroupBox groupBox1;
			private System.Windows.Forms.Button m_btRetiraProduto;
			private System.Windows.Forms.Button m_btInsereProduto;
			private System.Windows.Forms.ListView m_lvProdutosVinculados;
			private System.Windows.Forms.ListView m_lvProdutosNaoVinculados;
			private mdlComponentesGraficos.DataGrid m_dgFormARE;
		public System.Windows.Forms.Button m_btREEditar;
		private System.Windows.Forms.ColumnHeader m_colhNcm;
		private System.Windows.Forms.ColumnHeader m_colhDescricao;
		private System.Windows.Forms.ColumnHeader m_colhNcmV;
		private System.Windows.Forms.ColumnHeader m_colhDescricaoV;
		private System.Windows.Forms.Button m_btVincular;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Properties
			public bool Confirmed
			{
				get
				{
					return(m_bConfirmed);
				}
			}			
		#endregion
		#region Constructors
			public frmFProdutosFormARE(string strEnderecoExecutavel)
			{
				InitializeComponent();
				vMostraCor(strEnderecoExecutavel);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutosFormARE));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbDetalhesRE = new System.Windows.Forms.GroupBox();
			this.m_dgFormARE = new mdlComponentesGraficos.DataGrid();
			this.m_ggProdutos = new System.Windows.Forms.GroupBox();
			this.m_btVincular = new System.Windows.Forms.Button();
			this.m_gbProdutosVinculados = new System.Windows.Forms.GroupBox();
			this.m_lvProdutosVinculados = new System.Windows.Forms.ListView();
			this.m_colhNcmV = new System.Windows.Forms.ColumnHeader();
			this.m_colhDescricaoV = new System.Windows.Forms.ColumnHeader();
			this.m_gbREs = new System.Windows.Forms.GroupBox();
			this.m_btREEditar = new System.Windows.Forms.Button();
			this.m_lvREs = new System.Windows.Forms.ListView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_lvProdutosNaoVinculados = new System.Windows.Forms.ListView();
			this.m_colhNcm = new System.Windows.Forms.ColumnHeader();
			this.m_colhDescricao = new System.Windows.Forms.ColumnHeader();
			this.m_btInsereProduto = new System.Windows.Forms.Button();
			this.m_btRetiraProduto = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.m_gbDetalhesRE.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dgFormARE)).BeginInit();
			this.m_ggProdutos.SuspendLayout();
			this.m_gbProdutosVinculados.SuspendLayout();
			this.m_gbREs.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbDetalhesRE);
			this.m_gbMain.Controls.Add(this.m_ggProdutos);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Location = new System.Drawing.Point(7, 1);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(680, 528);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbDetalhesRE
			// 
			this.m_gbDetalhesRE.Controls.Add(this.m_dgFormARE);
			this.m_gbDetalhesRE.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbDetalhesRE.Location = new System.Drawing.Point(8, 343);
			this.m_gbDetalhesRE.Name = "m_gbDetalhesRE";
			this.m_gbDetalhesRE.Size = new System.Drawing.Size(656, 153);
			this.m_gbDetalhesRE.TabIndex = 19;
			this.m_gbDetalhesRE.TabStop = false;
			this.m_gbDetalhesRE.Text = "Detalhes";
			// 
			// m_dgFormARE
			// 
			this.m_dgFormARE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_dgFormARE.DataMember = "";
			this.m_dgFormARE.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.m_dgFormARE.Location = new System.Drawing.Point(8, 17);
			this.m_dgFormARE.Name = "m_dgFormARE";
			this.m_dgFormARE.Size = new System.Drawing.Size(640, 129);
			this.m_dgFormARE.TabIndex = 0;
			// 
			// m_ggProdutos
			// 
			this.m_ggProdutos.Controls.Add(this.m_btVincular);
			this.m_ggProdutos.Controls.Add(this.m_gbProdutosVinculados);
			this.m_ggProdutos.Controls.Add(this.m_gbREs);
			this.m_ggProdutos.Controls.Add(this.groupBox1);
			this.m_ggProdutos.Controls.Add(this.m_btInsereProduto);
			this.m_ggProdutos.Controls.Add(this.m_btRetiraProduto);
			this.m_ggProdutos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ggProdutos.Location = new System.Drawing.Point(5, 9);
			this.m_ggProdutos.Name = "m_ggProdutos";
			this.m_ggProdutos.Size = new System.Drawing.Size(667, 359);
			this.m_ggProdutos.TabIndex = 18;
			this.m_ggProdutos.TabStop = false;
			// 
			// m_btVincular
			// 
			this.m_btVincular.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVincular.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btVincular.ForeColor = System.Drawing.Color.Black;
			this.m_btVincular.Location = new System.Drawing.Point(511, 174);
			this.m_btVincular.Name = "m_btVincular";
			this.m_btVincular.Size = new System.Drawing.Size(144, 24);
			this.m_btVincular.TabIndex = 23;
			this.m_btVincular.Text = "Classificação Tarifária";
			this.m_btVincular.Click += new System.EventHandler(this.m_btVincular_Click);
			// 
			// m_gbProdutosVinculados
			// 
			this.m_gbProdutosVinculados.Controls.Add(this.m_lvProdutosVinculados);
			this.m_gbProdutosVinculados.Location = new System.Drawing.Point(6, 208);
			this.m_gbProdutosVinculados.Name = "m_gbProdutosVinculados";
			this.m_gbProdutosVinculados.Size = new System.Drawing.Size(656, 128);
			this.m_gbProdutosVinculados.TabIndex = 2;
			this.m_gbProdutosVinculados.TabStop = false;
			this.m_gbProdutosVinculados.Text = "Produtos Vinculados ao RE ";
			// 
			// m_lvProdutosVinculados
			// 
			this.m_lvProdutosVinculados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvProdutosVinculados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									 this.m_colhNcmV,
																									 this.m_colhDescricaoV});
			this.m_lvProdutosVinculados.FullRowSelect = true;
			this.m_lvProdutosVinculados.HideSelection = false;
			this.m_lvProdutosVinculados.Location = new System.Drawing.Point(8, 16);
			this.m_lvProdutosVinculados.Name = "m_lvProdutosVinculados";
			this.m_lvProdutosVinculados.Size = new System.Drawing.Size(640, 104);
			this.m_lvProdutosVinculados.TabIndex = 0;
			this.m_lvProdutosVinculados.View = System.Windows.Forms.View.Details;
			// 
			// m_colhNcmV
			// 
			this.m_colhNcmV.Text = "Ncm";
			this.m_colhNcmV.Width = 88;
			// 
			// m_colhDescricaoV
			// 
			this.m_colhDescricaoV.Text = "Descrição";
			this.m_colhDescricaoV.Width = 543;
			// 
			// m_gbREs
			// 
			this.m_gbREs.Controls.Add(this.m_btREEditar);
			this.m_gbREs.Controls.Add(this.m_lvREs);
			this.m_gbREs.Location = new System.Drawing.Point(8, 8);
			this.m_gbREs.Name = "m_gbREs";
			this.m_gbREs.Size = new System.Drawing.Size(160, 152);
			this.m_gbREs.TabIndex = 1;
			this.m_gbREs.TabStop = false;
			this.m_gbREs.Text = "RE\'s";
			// 
			// m_btREEditar
			// 
			this.m_btREEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btREEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btREEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btREEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btREEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btREEditar.Image")));
			this.m_btREEditar.Location = new System.Drawing.Point(66, 10);
			this.m_btREEditar.Name = "m_btREEditar";
			this.m_btREEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btREEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btREEditar.TabIndex = 23;
			this.m_btREEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btREEditar.Click += new System.EventHandler(this.m_btREEditar_Click);
			// 
			// m_lvREs
			// 
			this.m_lvREs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvREs.HideSelection = false;
			this.m_lvREs.Location = new System.Drawing.Point(8, 40);
			this.m_lvREs.Name = "m_lvREs";
			this.m_lvREs.Size = new System.Drawing.Size(144, 104);
			this.m_lvREs.TabIndex = 0;
			this.m_lvREs.View = System.Windows.Forms.View.List;
			this.m_lvREs.DoubleClick += new System.EventHandler(this.m_lvREs_DoubleClick);
			this.m_lvREs.SelectedIndexChanged += new System.EventHandler(this.m_lvREs_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_lvProdutosNaoVinculados);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(176, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(480, 152);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Produtos nao Vinculados";
			// 
			// m_lvProdutosNaoVinculados
			// 
			this.m_lvProdutosNaoVinculados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvProdutosNaoVinculados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																										this.m_colhNcm,
																										this.m_colhDescricao});
			this.m_lvProdutosNaoVinculados.FullRowSelect = true;
			this.m_lvProdutosNaoVinculados.HideSelection = false;
			this.m_lvProdutosNaoVinculados.Location = new System.Drawing.Point(8, 16);
			this.m_lvProdutosNaoVinculados.Name = "m_lvProdutosNaoVinculados";
			this.m_lvProdutosNaoVinculados.Size = new System.Drawing.Size(464, 128);
			this.m_lvProdutosNaoVinculados.TabIndex = 0;
			this.m_lvProdutosNaoVinculados.View = System.Windows.Forms.View.Details;
			// 
			// m_colhNcm
			// 
			this.m_colhNcm.Text = "Ncm";
			this.m_colhNcm.Width = 86;
			// 
			// m_colhDescricao
			// 
			this.m_colhDescricao.Text = "Descrição";
			this.m_colhDescricao.Width = 365;
			// 
			// m_btInsereProduto
			// 
			this.m_btInsereProduto.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btInsereProduto.Image = ((System.Drawing.Image)(resources.GetObject("m_btInsereProduto.Image")));
			this.m_btInsereProduto.Location = new System.Drawing.Point(105, 166);
			this.m_btInsereProduto.Name = "m_btInsereProduto";
			this.m_btInsereProduto.Size = new System.Drawing.Size(60, 40);
			this.m_btInsereProduto.TabIndex = 21;
			this.m_btInsereProduto.Click += new System.EventHandler(this.m_btInsereProduto_Click);
			// 
			// m_btRetiraProduto
			// 
			this.m_btRetiraProduto.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btRetiraProduto.Image = ((System.Drawing.Image)(resources.GetObject("m_btRetiraProduto.Image")));
			this.m_btRetiraProduto.Location = new System.Drawing.Point(177, 166);
			this.m_btRetiraProduto.Name = "m_btRetiraProduto";
			this.m_btRetiraProduto.Size = new System.Drawing.Size(60, 40);
			this.m_btRetiraProduto.TabIndex = 22;
			this.m_btRetiraProduto.Click += new System.EventHandler(this.m_btRetiraProduto_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(279, 497);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 16;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(343, 497);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 17;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFProdutosFormARE
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(694, 536);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutosFormARE";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form A";
			this.Load += new System.EventHandler(this.frmFProdutosFormARE_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbDetalhesRE.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_dgFormARE)).EndInit();
			this.m_ggProdutos.ResumeLayout(false);
			this.m_gbProdutosVinculados.ResumeLayout(false);
			this.m_gbREs.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
			#region Form
				private void frmFProdutosFormARE_Load(object sender, System.EventArgs e)
				{
					OnCallFormAREConfigure();
					OnCallRefreshRE();
					OnCallRefreshProdutosNaoVinculados();
					OnCallRefreshFormARE();
					RefreshCorVinculacao();
					OnCallCarregaTamanhoColunas();
				}
			#endregion
			#region ListView
				private void m_lvREs_DoubleClick(object sender, System.EventArgs e)
				{
					if (OnCallShowRE())
						OnCallRefreshRE();
				}

				private void m_lvREs_SelectedIndexChanged(object sender, System.EventArgs e)
				{
					OnCallRefreshProdutosVinculados();
				}
			#endregion
			#region Buttons
				private void m_btREEditar_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowRE())
						OnCallRefreshRE();
				}

				private void m_btVincular_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowClassificacaoTarifaria())
					{
						OnCallRefreshProdutosNaoVinculados();
						RefreshCorVinculacao();
					}
				}

				private void m_btInsereProduto_Click(object sender, System.EventArgs e)
				{
					if (OnCallProdutoVincula())
					{
						OnCallRefreshProdutosNaoVinculados();
						OnCallRefreshProdutosVinculados();
						OnCallRefreshFormARE();
					}
				}

				private void m_btRetiraProduto_Click(object sender, System.EventArgs e)
				{
					if (OnCallProdutoDesvincula())
					{
						OnCallRefreshProdutosNaoVinculados();
						OnCallRefreshProdutosVinculados();
						OnCallRefreshFormARE();
					}
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					OnCallSalvaTamanhoColunas();
					m_bConfirmed = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bConfirmed = false;
					this.Close();
				}
			#endregion
		#endregion

		#region Cores

			private void RefreshCorVinculacao()
			{
				if (OnCallPossuiProdutosSemClassificacaoTarifaria())
					m_btVincular.BackColor = System.Drawing.Color.Red;
				else
					m_btVincular.BackColor = System.Drawing.Color.Green;
			}
			private void vMostraCor(string strEnderecoExecutavel)
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME,"SiscobrasCorSecundaria");
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
					case "System.Windows.Forms.ListView":
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TextBox":
					case "mdlComponentesGraficos.TreeView":
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

		#region Tamanho
			public int GetCharacter2Pixel(int valor)
			{
				return(valor * 4);
			}

			public int GetPixel2Character(int valor)
			{
				return((int)valor / 4);
			}
		#endregion

	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlTec.Formularios
{
	/// <summary>
	/// Summary description for frmFTec.
	/// </summary>
	public class frmFTec : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate bool delCallCarregaDados(out System.DateTime dtDataAtualizacao);
			public delegate bool delCallPesquisar(string strPesquisar);
			public delegate bool delCallPesquisarParar();
			public delegate bool delCallInsere(string srCodigo,string strDescricao);
			public delegate bool delCallDetalhar(System.Windows.Forms.TreeView tvTec,string strCodigo);
			public delegate bool delCallNesh(string strCodigo,string strDescricao);
			public delegate bool delCallAliquotas(string strCodigo,string strDescricao);
			public delegate bool delCallCadastrar(string strCodigo,string strPosicao,string strClassificacaoTarifaria);
			public delegate void delCallShowDialogDatasAtualizacoes();
			public delegate void delCallShowDialogInformacoes(string strDescricao);
			public delegate void delCallShowDialogPesquisaInformacoes();
		#endregion
		#region Events
			public event delCallCarregaDados eCallCarregaDados;
			public event delCallPesquisar eCallPesquisar;
			public event delCallPesquisarParar eCallPesquisarParar;
			public event delCallInsere eCallInsere;
			public event delCallDetalhar eCallDetalhar;
			public event delCallNesh eCallNesh;
			public event delCallAliquotas eCallAliquotas;
			public event delCallCadastrar eCallCadastrar;
			public event delCallShowDialogDatasAtualizacoes eCallShowDialogDatasAtualizacoes;
			public event delCallShowDialogInformacoes eCallShowDialogInformacoes;
			public event delCallShowDialogPesquisaInformacoes eCallShowDialogPesquisaInformacoes;
		#endregion
		#region Events Methods
			protected virtual bool OnCallCarregaDados()
			{
				if (eCallCarregaDados == null)
					return(false);
				System.DateTime dtDataAtualizacao;
				if (eCallCarregaDados(out dtDataAtualizacao))
				{
					this.Text = "Siscobras - TEC Siscobras (Atualizado em: " + dtDataAtualizacao.ToString("dd/MMM/yyyy") + " )";
					m_lbAtualizacao.Text = "Última atualização: " + dtDataAtualizacao.ToString("dd/MMM/yyyy");
					return(true);
				}
				return(false);
			}

			protected virtual bool OnCallPesquisar()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (m_txtProcurar.Text.Trim() != "")
				{
					if (eCallPesquisar != null)
						bRetorno = eCallPesquisar(m_txtProcurar.Text);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				if (!bRetorno)
					mdlMensagens.clsMensagens.ShowInformation("Nenhum resultado foi encontrado.");
				return(bRetorno);
			}

			protected virtual bool OnCallPesquisarParar()
			{
				if (eCallPesquisarParar == null)
					return(false);
				return(eCallPesquisarParar());
			}

			protected virtual bool OnCallInsere()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (m_lvResultado.SelectedItems.Count > 0)
				{
					if (eCallInsere != null)
						bRetorno = eCallInsere(m_lvResultado.SelectedItems[0].Tag.ToString(),m_lvResultado.SelectedItems[0].SubItems[1].Text);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected void OnCallDetalhar()
			{
				string strCodigo = "";
				if (m_tvTec.SelectedNode != null)
					strCodigo = m_tvTec.SelectedNode.Tag.ToString();
				if (eCallDetalhar != null)
					eCallDetalhar(m_tvTec,strCodigo);
			}

			protected bool OnCallNesh()
			{
				if (eCallNesh == null)
					return(false);
				if (m_tvTec.SelectedNode == null)
					return(false);
				if (m_tvTec.SelectedNode.Tag.ToString().Length  == 8)
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve selecionar um capítulo ou posição para visualizar a nesh.");
					return(false);
				}
				return(eCallNesh(m_tvTec.SelectedNode.Tag.ToString(),m_tvTec.SelectedNode.Text));
			}
	
			protected bool OnCallAliquotas()
			{
				if (eCallAliquotas == null)
					return(false);
				if (m_tvTec.SelectedNode == null)
					return(false);
				if (m_tvTec.SelectedNode.Tag.ToString().Length  != 8)
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve selecionar uma classificação tarifaria para visualizar as aliquotas.");
					return(false);
				}
				return(eCallAliquotas(m_tvTec.SelectedNode.Tag.ToString(),m_tvTec.SelectedNode.Text));
			}

			protected bool OnCallCadastrar()
			{
				if (eCallCadastrar == null)
					return(false);
				if ((m_tvTec.SelectedNode == null) || (m_tvTec.SelectedNode.Tag.ToString().Length  != 8))
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve selecionar uma classificação tarifaria para cadastra-la.");
					return(false);
				}
				return(eCallCadastrar(m_tvTec.SelectedNode.Tag.ToString(),m_tvTec.SelectedNode.Parent.Text.Substring(7),m_tvTec.SelectedNode.Text.Substring(11)));
			}

			protected void OnCallShowDialogDatasAtualizacoes()
			{
				if (eCallShowDialogDatasAtualizacoes != null)
					eCallShowDialogDatasAtualizacoes();
			}

			protected void OnCallShowDialogInformacoes()
			{
				if (eCallShowDialogInformacoes != null)
					eCallShowDialogInformacoes(GetTreeViewText());
			}

			protected void OnCallShowDialogPesquisaInformacoes()
			{
				if (eCallShowDialogPesquisaInformacoes != null)
					eCallShowDialogPesquisaInformacoes();
			}
		#endregion

		#region Atributes
			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.TreeView m_tvTec;
			private System.Windows.Forms.GroupBox m_gbTec;
			private System.Windows.Forms.GroupBox m_gbPesquisar;
			private System.Windows.Forms.Label m_lbProcurar;
			private System.Windows.Forms.TextBox m_txtProcurar;
			private System.Windows.Forms.GroupBox m_gbResultado;
			private System.Windows.Forms.ListView m_lvResultado;
			private System.Windows.Forms.ImageList m_ilIcones;
			private System.Windows.Forms.Button m_btExcluir;
			private System.Windows.Forms.Button m_btPesquisa;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.Windows.Forms.ColumnHeader m_colhCodigo;
			private System.Windows.Forms.ColumnHeader m_colhDenominacao;
			private System.Windows.Forms.Button m_btImpostos;
			private System.Windows.Forms.Button m_btNesh;
			private System.Windows.Forms.Button m_btAprofundar;
			private System.Windows.Forms.Button m_btCadastrar;
			private System.Windows.Forms.GroupBox m_gbBanner;
			private System.Windows.Forms.Button m_btInsere;
			private System.Windows.Forms.PictureBox m_pic;
			private System.Windows.Forms.GroupBox m_gbClassificacao;
			private System.Windows.Forms.RadioButton m_rdbtNcm;
			private System.Windows.Forms.RadioButton m_rdbtNaladi;
			private System.Windows.Forms.GroupBox m_gbInformacoes;
			private System.Windows.Forms.Label m_lbAtualizacao;
			private System.Windows.Forms.Label m_lbFonte;
		private System.Windows.Forms.LinkLabel m_llbAtualizacoes;
		private System.Windows.Forms.Button m_btPesquisaParar;
		private System.Windows.Forms.Button m_btCopiar;
		private System.Windows.Forms.LinkLabel m_llbDicasPesquisa;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public System.Windows.Forms.ListView Pesquisa
			{
				get
				{
					return(m_lvResultado);
				}
			}

			public System.Windows.Forms.TreeView Tec
			{
				get
				{
					return(m_tvTec);
				}
			}

			public bool PossibilidadeCadastrarClassificacaoTarifaria
			{
				set
				{
					m_btCadastrar.Visible = value;
				}
				get
				{
					return(m_btCadastrar.Visible);
				}
			}

			public System.Drawing.Image Banner
			{
				set
				{
					m_pic.Image = value;
					vMostraCor();
				}
			}

			public bool IsNcm
			{
				get
				{
					return(m_rdbtNcm.Checked);
				}
			}
		#endregion
		#region Constructors
			public frmFTec(string strEnderecoExecutavel)
			{
				InitializeComponent();
				vMostraCor();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFTec));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_llbAtualizacoes = new System.Windows.Forms.LinkLabel();
			this.m_lbFonte = new System.Windows.Forms.Label();
			this.m_lbAtualizacao = new System.Windows.Forms.Label();
			this.m_gbClassificacao = new System.Windows.Forms.GroupBox();
			this.m_rdbtNaladi = new System.Windows.Forms.RadioButton();
			this.m_rdbtNcm = new System.Windows.Forms.RadioButton();
			this.m_gbBanner = new System.Windows.Forms.GroupBox();
			this.m_pic = new System.Windows.Forms.PictureBox();
			this.m_gbResultado = new System.Windows.Forms.GroupBox();
			this.m_btPesquisaParar = new System.Windows.Forms.Button();
			this.m_btInsere = new System.Windows.Forms.Button();
			this.m_ilIcones = new System.Windows.Forms.ImageList(this.components);
			this.m_lvResultado = new System.Windows.Forms.ListView();
			this.m_colhCodigo = new System.Windows.Forms.ColumnHeader();
			this.m_colhDenominacao = new System.Windows.Forms.ColumnHeader();
			this.m_gbPesquisar = new System.Windows.Forms.GroupBox();
			this.m_llbDicasPesquisa = new System.Windows.Forms.LinkLabel();
			this.m_btPesquisa = new System.Windows.Forms.Button();
			this.m_txtProcurar = new System.Windows.Forms.TextBox();
			this.m_lbProcurar = new System.Windows.Forms.Label();
			this.m_gbTec = new System.Windows.Forms.GroupBox();
			this.m_btCopiar = new System.Windows.Forms.Button();
			this.m_btCadastrar = new System.Windows.Forms.Button();
			this.m_btAprofundar = new System.Windows.Forms.Button();
			this.m_btNesh = new System.Windows.Forms.Button();
			this.m_btImpostos = new System.Windows.Forms.Button();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_tvTec = new System.Windows.Forms.TreeView();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbMain.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.m_gbClassificacao.SuspendLayout();
			this.m_gbBanner.SuspendLayout();
			this.m_gbResultado.SuspendLayout();
			this.m_gbPesquisar.SuspendLayout();
			this.m_gbTec.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbInformacoes);
			this.m_gbMain.Controls.Add(this.m_gbClassificacao);
			this.m_gbMain.Controls.Add(this.m_gbBanner);
			this.m_gbMain.Controls.Add(this.m_gbResultado);
			this.m_gbMain.Controls.Add(this.m_gbPesquisar);
			this.m_gbMain.Controls.Add(this.m_gbTec);
			this.m_gbMain.Location = new System.Drawing.Point(6, 0);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(682, 516);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbInformacoes.Controls.Add(this.m_llbAtualizacoes);
			this.m_gbInformacoes.Controls.Add(this.m_lbFonte);
			this.m_gbInformacoes.Controls.Add(this.m_lbAtualizacao);
			this.m_gbInformacoes.Location = new System.Drawing.Point(308, 64);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(364, 56);
			this.m_gbInformacoes.TabIndex = 8;
			this.m_gbInformacoes.TabStop = false;
			// 
			// m_llbAtualizacoes
			// 
			this.m_llbAtualizacoes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llbAtualizacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llbAtualizacoes.Location = new System.Drawing.Point(8, 34);
			this.m_llbAtualizacoes.Name = "m_llbAtualizacoes";
			this.m_llbAtualizacoes.Size = new System.Drawing.Size(152, 16);
			this.m_llbAtualizacoes.TabIndex = 8;
			this.m_llbAtualizacoes.TabStop = true;
			this.m_llbAtualizacoes.Text = "Datas das atualizações ";
			this.m_llbAtualizacoes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llbAtualizacoes_LinkClicked);
			// 
			// m_lbFonte
			// 
			this.m_lbFonte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbFonte.ForeColor = System.Drawing.Color.Green;
			this.m_lbFonte.Location = new System.Drawing.Point(240, 8);
			this.m_lbFonte.Name = "m_lbFonte";
			this.m_lbFonte.Size = new System.Drawing.Size(112, 14);
			this.m_lbFonte.TabIndex = 7;
			this.m_lbFonte.Text = "Fonte: Siscomex";
			// 
			// m_lbAtualizacao
			// 
			this.m_lbAtualizacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbAtualizacao.ForeColor = System.Drawing.Color.DarkRed;
			this.m_lbAtualizacao.Location = new System.Drawing.Point(7, 9);
			this.m_lbAtualizacao.Name = "m_lbAtualizacao";
			this.m_lbAtualizacao.Size = new System.Drawing.Size(233, 23);
			this.m_lbAtualizacao.TabIndex = 6;
			this.m_lbAtualizacao.Text = "Última atualização: Carregando . . . ";
			// 
			// m_gbClassificacao
			// 
			this.m_gbClassificacao.Controls.Add(this.m_rdbtNaladi);
			this.m_gbClassificacao.Controls.Add(this.m_rdbtNcm);
			this.m_gbClassificacao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbClassificacao.Location = new System.Drawing.Point(120, 64);
			this.m_gbClassificacao.Name = "m_gbClassificacao";
			this.m_gbClassificacao.Size = new System.Drawing.Size(184, 56);
			this.m_gbClassificacao.TabIndex = 7;
			this.m_gbClassificacao.TabStop = false;
			this.m_gbClassificacao.Text = "Classificação Tarifária";
			// 
			// m_rdbtNaladi
			// 
			this.m_rdbtNaladi.Location = new System.Drawing.Point(15, 33);
			this.m_rdbtNaladi.Name = "m_rdbtNaladi";
			this.m_rdbtNaladi.Size = new System.Drawing.Size(144, 16);
			this.m_rdbtNaladi.TabIndex = 1;
			this.m_rdbtNaladi.Text = "Naladi";
			this.m_rdbtNaladi.CheckedChanged += new System.EventHandler(this.m_rdbtNaladi_CheckedChanged);
			// 
			// m_rdbtNcm
			// 
			this.m_rdbtNcm.Checked = true;
			this.m_rdbtNcm.Location = new System.Drawing.Point(16, 16);
			this.m_rdbtNcm.Name = "m_rdbtNcm";
			this.m_rdbtNcm.Size = new System.Drawing.Size(144, 16);
			this.m_rdbtNcm.TabIndex = 0;
			this.m_rdbtNcm.TabStop = true;
			this.m_rdbtNcm.Text = "NCM";
			this.m_rdbtNcm.CheckedChanged += new System.EventHandler(this.m_rdbtNcm_CheckedChanged);
			// 
			// m_gbBanner
			// 
			this.m_gbBanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_gbBanner.Controls.Add(this.m_pic);
			this.m_gbBanner.Location = new System.Drawing.Point(6, 9);
			this.m_gbBanner.Name = "m_gbBanner";
			this.m_gbBanner.Size = new System.Drawing.Size(108, 504);
			this.m_gbBanner.TabIndex = 6;
			this.m_gbBanner.TabStop = false;
			// 
			// m_pic
			// 
			this.m_pic.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_pic.Image = ((System.Drawing.Image)(resources.GetObject("m_pic.Image")));
			this.m_pic.Location = new System.Drawing.Point(6, 12);
			this.m_pic.Name = "m_pic";
			this.m_pic.Size = new System.Drawing.Size(95, 480);
			this.m_pic.TabIndex = 0;
			this.m_pic.TabStop = false;
			this.m_pic.Click += new System.EventHandler(this.m_pic_Click);
			// 
			// m_gbResultado
			// 
			this.m_gbResultado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbResultado.Controls.Add(this.m_btPesquisaParar);
			this.m_gbResultado.Controls.Add(this.m_btInsere);
			this.m_gbResultado.Controls.Add(this.m_lvResultado);
			this.m_gbResultado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbResultado.Location = new System.Drawing.Point(120, 120);
			this.m_gbResultado.Name = "m_gbResultado";
			this.m_gbResultado.Size = new System.Drawing.Size(552, 168);
			this.m_gbResultado.TabIndex = 3;
			this.m_gbResultado.TabStop = false;
			this.m_gbResultado.Text = "Resultados Pesquisa";
			// 
			// m_btPesquisaParar
			// 
			this.m_btPesquisaParar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btPesquisaParar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btPesquisaParar.Image = ((System.Drawing.Image)(resources.GetObject("m_btPesquisaParar.Image")));
			this.m_btPesquisaParar.Location = new System.Drawing.Point(520, 19);
			this.m_btPesquisaParar.Name = "m_btPesquisaParar";
			this.m_btPesquisaParar.Size = new System.Drawing.Size(25, 25);
			this.m_btPesquisaParar.TabIndex = 7;
			this.m_ttDica.SetToolTip(this.m_btPesquisaParar, "Parar pesquisa");
			this.m_btPesquisaParar.Click += new System.EventHandler(this.m_btPesquisaParar_Click);
			// 
			// m_btInsere
			// 
			this.m_btInsere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btInsere.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btInsere.ImageIndex = 0;
			this.m_btInsere.ImageList = this.m_ilIcones;
			this.m_btInsere.Location = new System.Drawing.Point(520, 79);
			this.m_btInsere.Name = "m_btInsere";
			this.m_btInsere.Size = new System.Drawing.Size(25, 25);
			this.m_btInsere.TabIndex = 5;
			this.m_ttDica.SetToolTip(this.m_btInsere, "Enviar para lista de Classificacao Tarifaria");
			this.m_btInsere.Click += new System.EventHandler(this.m_btInsere_Click);
			// 
			// m_ilIcones
			// 
			this.m_ilIcones.ImageSize = new System.Drawing.Size(20, 20);
			this.m_ilIcones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilIcones.ImageStream")));
			this.m_ilIcones.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_lvResultado
			// 
			this.m_lvResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvResultado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.m_colhCodigo,
																							this.m_colhDenominacao});
			this.m_lvResultado.FullRowSelect = true;
			this.m_lvResultado.HideSelection = false;
			this.m_lvResultado.Location = new System.Drawing.Point(7, 16);
			this.m_lvResultado.Name = "m_lvResultado";
			this.m_lvResultado.Size = new System.Drawing.Size(505, 144);
			this.m_lvResultado.TabIndex = 0;
			this.m_lvResultado.View = System.Windows.Forms.View.Details;
			// 
			// m_colhCodigo
			// 
			this.m_colhCodigo.Text = "Código";
			this.m_colhCodigo.Width = 81;
			// 
			// m_colhDenominacao
			// 
			this.m_colhDenominacao.Text = "Denominação";
			this.m_colhDenominacao.Width = 415;
			// 
			// m_gbPesquisar
			// 
			this.m_gbPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbPesquisar.Controls.Add(this.m_llbDicasPesquisa);
			this.m_gbPesquisar.Controls.Add(this.m_btPesquisa);
			this.m_gbPesquisar.Controls.Add(this.m_txtProcurar);
			this.m_gbPesquisar.Controls.Add(this.m_lbProcurar);
			this.m_gbPesquisar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbPesquisar.Location = new System.Drawing.Point(120, 9);
			this.m_gbPesquisar.Name = "m_gbPesquisar";
			this.m_gbPesquisar.Size = new System.Drawing.Size(552, 55);
			this.m_gbPesquisar.TabIndex = 2;
			this.m_gbPesquisar.TabStop = false;
			this.m_gbPesquisar.Text = "Pesquisar";
			// 
			// m_llbDicasPesquisa
			// 
			this.m_llbDicasPesquisa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llbDicasPesquisa.Location = new System.Drawing.Point(84, 34);
			this.m_llbDicasPesquisa.Name = "m_llbDicasPesquisa";
			this.m_llbDicasPesquisa.Size = new System.Drawing.Size(160, 16);
			this.m_llbDicasPesquisa.TabIndex = 3;
			this.m_llbDicasPesquisa.TabStop = true;
			this.m_llbDicasPesquisa.Text = "Dicas de Pesquisa";
			this.m_llbDicasPesquisa.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llbDicasPesquisa_LinkClicked);
			// 
			// m_btPesquisa
			// 
			this.m_btPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btPesquisa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btPesquisa.ImageIndex = 2;
			this.m_btPesquisa.ImageList = this.m_ilIcones;
			this.m_btPesquisa.Location = new System.Drawing.Point(523, 9);
			this.m_btPesquisa.Name = "m_btPesquisa";
			this.m_btPesquisa.Size = new System.Drawing.Size(25, 25);
			this.m_btPesquisa.TabIndex = 2;
			this.m_ttDica.SetToolTip(this.m_btPesquisa, "Submeter à Pesquisa");
			this.m_btPesquisa.Click += new System.EventHandler(this.m_btPesquisa_Click);
			// 
			// m_txtProcurar
			// 
			this.m_txtProcurar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtProcurar.Location = new System.Drawing.Point(85, 12);
			this.m_txtProcurar.Name = "m_txtProcurar";
			this.m_txtProcurar.Size = new System.Drawing.Size(433, 20);
			this.m_txtProcurar.TabIndex = 1;
			this.m_txtProcurar.Text = "";
			this.m_txtProcurar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtProcurar_KeyDown);
			// 
			// m_lbProcurar
			// 
			this.m_lbProcurar.Location = new System.Drawing.Point(6, 15);
			this.m_lbProcurar.Name = "m_lbProcurar";
			this.m_lbProcurar.Size = new System.Drawing.Size(80, 16);
			this.m_lbProcurar.TabIndex = 0;
			this.m_lbProcurar.Text = "Procurar por:";
			// 
			// m_gbTec
			// 
			this.m_gbTec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbTec.Controls.Add(this.m_btCopiar);
			this.m_gbTec.Controls.Add(this.m_btCadastrar);
			this.m_gbTec.Controls.Add(this.m_btAprofundar);
			this.m_gbTec.Controls.Add(this.m_btNesh);
			this.m_gbTec.Controls.Add(this.m_btImpostos);
			this.m_gbTec.Controls.Add(this.m_btExcluir);
			this.m_gbTec.Controls.Add(this.m_tvTec);
			this.m_gbTec.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbTec.Location = new System.Drawing.Point(120, 289);
			this.m_gbTec.Name = "m_gbTec";
			this.m_gbTec.Size = new System.Drawing.Size(552, 224);
			this.m_gbTec.TabIndex = 1;
			this.m_gbTec.TabStop = false;
			this.m_gbTec.Text = "Classificação Tarifária";
			// 
			// m_btCopiar
			// 
			this.m_btCopiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btCopiar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCopiar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCopiar.Image")));
			this.m_btCopiar.Location = new System.Drawing.Point(523, 125);
			this.m_btCopiar.Name = "m_btCopiar";
			this.m_btCopiar.Size = new System.Drawing.Size(25, 25);
			this.m_btCopiar.TabIndex = 11;
			this.m_ttDica.SetToolTip(this.m_btCopiar, "Copiar");
			this.m_btCopiar.Click += new System.EventHandler(this.m_btCopiar_Click);
			// 
			// m_btCadastrar
			// 
			this.m_btCadastrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btCadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCadastrar.Enabled = false;
			this.m_btCadastrar.ImageIndex = 6;
			this.m_btCadastrar.ImageList = this.m_ilIcones;
			this.m_btCadastrar.Location = new System.Drawing.Point(523, 75);
			this.m_btCadastrar.Name = "m_btCadastrar";
			this.m_btCadastrar.Size = new System.Drawing.Size(25, 25);
			this.m_btCadastrar.TabIndex = 10;
			this.m_ttDica.SetToolTip(this.m_btCadastrar, "Cadastrar esta Classificação Tarifária");
			this.m_btCadastrar.Click += new System.EventHandler(this.m_btCadastrar_Click);
			// 
			// m_btAprofundar
			// 
			this.m_btAprofundar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btAprofundar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btAprofundar.Image = ((System.Drawing.Image)(resources.GetObject("m_btAprofundar.Image")));
			this.m_btAprofundar.Location = new System.Drawing.Point(523, 19);
			this.m_btAprofundar.Name = "m_btAprofundar";
			this.m_btAprofundar.Size = new System.Drawing.Size(25, 25);
			this.m_btAprofundar.TabIndex = 9;
			this.m_ttDica.SetToolTip(this.m_btAprofundar, "Detalhar SubNiveis");
			this.m_btAprofundar.Click += new System.EventHandler(this.m_btAprofundar_Click);
			// 
			// m_btNesh
			// 
			this.m_btNesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btNesh.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNesh.Enabled = false;
			this.m_btNesh.Image = ((System.Drawing.Image)(resources.GetObject("m_btNesh.Image")));
			this.m_btNesh.Location = new System.Drawing.Point(523, 152);
			this.m_btNesh.Name = "m_btNesh";
			this.m_btNesh.Size = new System.Drawing.Size(25, 25);
			this.m_btNesh.TabIndex = 8;
			this.m_ttDica.SetToolTip(this.m_btNesh, "Nesh – Notas Explicativas do Sistema Harmonizado");
			this.m_btNesh.Click += new System.EventHandler(this.m_btNesh_Click);
			// 
			// m_btImpostos
			// 
			this.m_btImpostos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btImpostos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImpostos.Enabled = false;
			this.m_btImpostos.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.m_btImpostos.ImageIndex = 3;
			this.m_btImpostos.ImageList = this.m_ilIcones;
			this.m_btImpostos.Location = new System.Drawing.Point(523, 180);
			this.m_btImpostos.Name = "m_btImpostos";
			this.m_btImpostos.Size = new System.Drawing.Size(25, 25);
			this.m_btImpostos.TabIndex = 7;
			this.m_ttDica.SetToolTip(this.m_btImpostos, "Aliquotas");
			this.m_btImpostos.Click += new System.EventHandler(this.m_btImpostos_Click);
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Enabled = false;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(523, 48);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 6;
			this.m_ttDica.SetToolTip(this.m_btExcluir, "Remover");
			this.m_btExcluir.Click += new System.EventHandler(this.m_btExcluir_Click);
			// 
			// m_tvTec
			// 
			this.m_tvTec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tvTec.HideSelection = false;
			this.m_tvTec.ImageIndex = -1;
			this.m_tvTec.Location = new System.Drawing.Point(5, 18);
			this.m_tvTec.Name = "m_tvTec";
			this.m_tvTec.SelectedImageIndex = -1;
			this.m_tvTec.Size = new System.Drawing.Size(514, 198);
			this.m_tvTec.TabIndex = 0;
			this.m_tvTec.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_tvTec_AfterSelect);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFTec
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(694, 523);
			this.Controls.Add(this.m_gbMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(700, 550);
			this.Name = "frmFTec";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Siscobras - TEC Siscobras ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmFTec_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.m_gbClassificacao.ResumeLayout(false);
			this.m_gbBanner.ResumeLayout(false);
			this.m_gbResultado.ResumeLayout(false);
			this.m_gbPesquisar.ResumeLayout(false);
			this.m_gbTec.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Cores
			private void vMostraCor()
			{
				this.BackColor = mdlComponentesGraficos.Painter.GetFirstColor((System.Drawing.Image)this.m_pic.Image.Clone());
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					ctrControleChild = this.Controls[nCont];
					vPaintControl(ref ctrControleChild,this.BackColor);
				}
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
					case "System.Windows.Forms.TextBox":
					case "System.Windows.Forms.TreeView":
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

		#region Eventos
			#region Form
				private void frmFTec_Load(object sender, System.EventArgs e)
				{
					CarregaDados();
				}
			#endregion
			#region PictureBox
				private void m_pic_Click(object sender, System.EventArgs e)
				{
					clsTec.ExecuteLink("http://www.siscobras.com.br");
				}
			#endregion
			#region TreeView
				private void m_tvTec_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
				{
					if (m_tvTec.SelectedNode == null)
					{
						m_btExcluir.Enabled = false;
						m_btNesh.Enabled = false;
						m_btImpostos.Enabled = false;
						m_btCadastrar.Enabled = false;
					}else{
						m_btExcluir.Enabled = true;
						string strCodigo = m_tvTec.SelectedNode.Tag.ToString();
						if (strCodigo.Length != 8)
						{
							m_btNesh.Enabled = true;
							m_btImpostos.Enabled = false;
							m_btAprofundar.Enabled = true;
							m_btCadastrar.Enabled = false;
						}else{
							m_btNesh.Enabled = false;
							m_btImpostos.Enabled = m_rdbtNcm.Checked;
							m_btAprofundar.Enabled = false;
							m_btCadastrar.Enabled = true;
						}
   					}
				}
			#endregion
			#region LinkLabel
				private void m_llbAtualizacoes_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
				{
					OnCallShowDialogDatasAtualizacoes();
				}

				private void m_llbDicasPesquisa_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
				{
					OnCallShowDialogPesquisaInformacoes();
				}
			#endregion
			#region RadioButtons
			private void m_rdbtNcm_CheckedChanged(object sender, System.EventArgs e)
			{
				Clear();
			}

			private void m_rdbtNaladi_CheckedChanged(object sender, System.EventArgs e)
			{
				Clear();
			}
			#endregion
			#region TextBoxes
				private void m_txtProcurar_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
				{
					if (e.KeyCode == System.Windows.Forms.Keys.Enter)
						OnCallPesquisar();
					e.Handled = false;
				}
			#endregion
			#region Botoes
				private void m_btAprofundar_Click(object sender, System.EventArgs e)
				{
					OnCallDetalhar();
				}

				private void m_btPesquisa_Click(object sender, System.EventArgs e)
				{
					OnCallPesquisar();
				}

				private void m_btPesquisaParar_Click(object sender, System.EventArgs e)
				{
					OnCallPesquisarParar();
				}

				private void m_btInsere_Click(object sender, System.EventArgs e)
				{
					OnCallInsere();
				}

				private void m_btNesh_Click(object sender, System.EventArgs e)
				{
					OnCallNesh();
				}

				private void m_btImpostos_Click(object sender, System.EventArgs e)
				{
					OnCallAliquotas();
				}

				private void m_btCopiar_Click(object sender, System.EventArgs e)
				{
					OnCallShowDialogInformacoes();
				}

				private void m_btExcluir_Click(object sender, System.EventArgs e)
				{
					RemoveTec();
				}

				private void m_btCadastrar_Click(object sender, System.EventArgs e)
				{
                    OnCallCadastrar();				
				}
			#endregion
		#endregion

		#region CarregaDados
			private void CarregaDados()
			{
				System.Threading.Thread threadCarregaDados = new System.Threading.Thread(new System.Threading.ThreadStart(CarregaDadosStart));
				threadCarregaDados.Start();
			}

			private void CarregaDadosStart()
			{
				OnCallCarregaDados();
			}
		#endregion
		#region SubNiveis
			private void CarregaSubNiveis()
			{
				System.Threading.Thread threadCarregaDados = new System.Threading.Thread(new System.Threading.ThreadStart(OnCallDetalhar));
				threadCarregaDados.Start();
			}
		#endregion
		#region Tec
			private void RemoveTec()
			{
				if (m_tvTec.SelectedNode != null)
				{
					m_tvTec.SelectedNode.Remove();
				}else{
					for(int i = m_tvTec.Nodes.Count - 1;i>=0;i--)
						m_tvTec.Nodes[i].Remove();
				}
			}
		#endregion
		#region Clear
			private void Clear()
			{
				m_lvResultado.Items.Clear();
				m_tvTec.Nodes.Clear();
			}
		#endregion
		#region TreeView
			private string GetTreeViewText()
			{
				System.Text.StringBuilder strbText = new System.Text.StringBuilder();
				for(int i = 0; i < m_tvTec.Nodes.Count;i++)
				{
					System.Windows.Forms.TreeNode tvNode = m_tvTec.Nodes[i];
					strbText.Append(tvNode.Text);
					strbText.Append(System.Environment.NewLine);
					for(int j = 0; j < tvNode.Nodes.Count;j++)
					{
						System.Windows.Forms.TreeNode tvNodeJ = tvNode.Nodes[j];
						strbText.Append("\t");
						strbText.Append(tvNodeJ.Text);
						strbText.Append(System.Environment.NewLine);
						for(int k = 0; k < tvNodeJ.Nodes.Count;k++)
						{
							System.Windows.Forms.TreeNode tvNodeK = tvNodeJ.Nodes[k];
							strbText.Append("\t");
							strbText.Append("\t");
							strbText.Append(tvNodeK.Text);
							strbText.Append(System.Environment.NewLine);
						}
					}
				}
				return(strbText.ToString());
			}
		#endregion
	}
}

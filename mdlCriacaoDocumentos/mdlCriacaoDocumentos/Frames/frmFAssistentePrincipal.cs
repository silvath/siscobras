using System;
using System.Collections;

namespace mdlCriacaoDocumentos.Frames
{
	/// <summary>
	/// Summary description for frmFAssistentePrincipal.
	/// </summary>
	internal class frmFAssistentePrincipal : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		public bool m_bModificado = false;
		private bool m_bMostrarDiretoPrincipal = false;

		private bool m_bLoad = true;

		private enum ORDEM { IDIOMA, MOEDA, IMPORTADOR, PRODUTOS, PESOS, NUMEROORDEMCOMPRA, INCOTERMS, LOCAIS, CONDICOESPAGAMENTOS, BANCOS, OBSERVACOES, NUMEROFATURA, ASSINATURA };
		private ORDEM m_enumOrdem = ORDEM.IDIOMA;

		private System.Windows.Forms.LinkLabelLinkClickedEventArgs m_llevents_Args = new System.Windows.Forms.LinkLabelLinkClickedEventArgs(null);
		
		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		internal System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.PictureBox m_pbOkIdioma;
		private System.Windows.Forms.LinkLabel m_llIdioma;
		private System.Windows.Forms.PictureBox m_pbOkMoeda;
		private System.Windows.Forms.LinkLabel m_llMoeda;
		private System.Windows.Forms.LinkLabel m_llImportador;
		private System.Windows.Forms.LinkLabel m_llProdutos;
		private System.Windows.Forms.LinkLabel m_llPesos;
		private System.Windows.Forms.LinkLabel m_llNumeroOrdemCompra;
		private System.Windows.Forms.LinkLabel m_llIncoterm;
		private System.Windows.Forms.LinkLabel m_llLocais;
		private System.Windows.Forms.LinkLabel m_llCondicoesPagamento;
		private System.Windows.Forms.LinkLabel m_llObservacoes;
		private System.Windows.Forms.PictureBox m_pbOkObservacoes;
		private System.Windows.Forms.PictureBox m_pbOkCondicoesPagamento;
		private System.Windows.Forms.PictureBox m_pbOkLocais;
		private System.Windows.Forms.PictureBox m_pbOkIncoterms;
		private System.Windows.Forms.PictureBox m_pbOkNumeroOrdemCompra;
		private System.Windows.Forms.PictureBox m_pbOkPesos;
		private System.Windows.Forms.PictureBox m_pbOkProdutos;
		private System.Windows.Forms.PictureBox m_pbOkImportador;
		private System.Windows.Forms.LinkLabel m_llNumeroFatura;
		private System.Windows.Forms.PictureBox m_pbOkNumeroFatura;
		private System.Windows.Forms.PictureBox m_pbNOKIdioma;
		private System.Windows.Forms.PictureBox m_pbNOKMoeda;
		private System.Windows.Forms.PictureBox m_pbNOKImportador;
		private System.Windows.Forms.PictureBox m_pbNOKProdutos;
		private System.Windows.Forms.PictureBox m_pbNOKPesos;
		private System.Windows.Forms.PictureBox m_pbNOKNumeroOrdemCompra;
		private System.Windows.Forms.PictureBox m_pbNOKIncoterms;
		private System.Windows.Forms.PictureBox m_pbNOKLocais;
		private System.Windows.Forms.PictureBox m_pbNOKCondicoesPagamento;
		private System.Windows.Forms.PictureBox m_pbNOKObservacoes;
		private System.Windows.Forms.PictureBox m_pbNOKNumeroFatura;
		private System.Windows.Forms.PictureBox m_pbBanner;
		private System.Windows.Forms.ToolTip m_ttAssistente;
		private System.Windows.Forms.LinkLabel m_llAssinatura;
		private System.Windows.Forms.PictureBox m_pbOKAssinatura;
		private System.Windows.Forms.PictureBox m_pbNOKAssinatura;
		private System.Windows.Forms.Timer m_tmAssistente;
		private System.Windows.Forms.LinkLabel m_llBancoImportador;
		private System.Windows.Forms.PictureBox m_pbOkBancoImportador;
		private System.Windows.Forms.PictureBox m_pbNOKBancoImportador;
		private System.Windows.Forms.LinkLabel m_llBancoExportador;
		private System.Windows.Forms.PictureBox m_pbOkBancoExportador;
		private System.Windows.Forms.PictureBox m_pbNOKBancoExportador;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFAssistentePrincipal(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
		}
		public frmFAssistentePrincipal(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel, string strMostrarDiretoPrincipal)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			try
			{
				m_bMostrarDiretoPrincipal = Boolean.Parse(strMostrarDiretoPrincipal);
			}
			catch
			{
				m_bMostrarDiretoPrincipal = false;
			}
			m_pbOkNumeroFatura.Visible = false;
			m_llNumeroFatura.LinkVisited = false;
			m_pbNOKNumeroFatura.Visible = true;
		}
		public frmFAssistentePrincipal(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel, bool bMostrarOkNumeroFatura)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_pbOkNumeroFatura.Visible = bMostrarOkNumeroFatura;
			m_llNumeroFatura.LinkVisited = bMostrarOkNumeroFatura;
			if (m_llNumeroFatura.LinkVisited)
				m_ttAssistente.SetToolTip(m_llNumeroFatura,"Item visitado");
			else
				m_ttAssistente.SetToolTip(m_llNumeroFatura,"Item não visitado");
			m_pbNOKNumeroFatura.Visible = !bMostrarOkNumeroFatura;
		}
		public frmFAssistentePrincipal(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel, bool bMostrarOkNumeroFatura, bool bTodosOk)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_pbOkNumeroFatura.Visible = bMostrarOkNumeroFatura;
			m_pbNOKNumeroFatura.Visible = !bMostrarOkNumeroFatura;
			if (bTodosOk)
				todosOkVisiveis();
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

		#region Delegates
		// Interface
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.FormFlutuante formAssistentePrincipal, ref System.Windows.Forms.GroupBox gbFields);
		// Cliques
		public delegate void delCallSelecionaNumeroFaturaComercial(ref System.Windows.Forms.PictureBox pbOkNumeroFatura, ref System.Windows.Forms.PictureBox pbNOKNumeroFatura);
		public delegate void delCallSelecionaNumeroFatura(ref System.Windows.Forms.PictureBox pbOkNumeroFatura);
		public delegate void delCallSelecionaIdioma(ref System.Windows.Forms.PictureBox pbOkIdioma, ref System.Windows.Forms.PictureBox pbNOKIdioma);
		public delegate void delCallSelecionaMoeda(ref System.Windows.Forms.PictureBox pbOkMoeda, ref System.Windows.Forms.PictureBox pbNOKMoeda);
		public delegate void delCallSelecionaImportador(ref System.Windows.Forms.PictureBox pbOkIImportador, ref System.Windows.Forms.PictureBox pbNOKImportador);
		public delegate void delCallSelecionaProdutos(ref System.Windows.Forms.PictureBox pbOkProdutos, ref System.Windows.Forms.PictureBox pbNOKProdutos);
		public delegate void delCallSelecionaPesos(ref System.Windows.Forms.PictureBox pbOkPesos, ref System.Windows.Forms.PictureBox pbNOKPesos);
		public delegate void delCallSelecionaNumeroOrdemCompra(ref System.Windows.Forms.PictureBox pbOkNumeroOrdemCompra, ref System.Windows.Forms.PictureBox pbNOKNumeroOrdemCompra);
		public delegate void delCallSelecionaIncoterm(ref System.Windows.Forms.PictureBox pbOkIncoterm, ref System.Windows.Forms.PictureBox pbNOKIncoterm);
		public delegate void delCallSelecionaLocais(ref System.Windows.Forms.PictureBox pbOkLocais, ref System.Windows.Forms.PictureBox pbNOKLocais);
		public delegate void delCallSelecionaCondicoesPagamento(ref System.Windows.Forms.PictureBox pbOkCondicoesPagamento, ref System.Windows.Forms.PictureBox pbNOKCondicoesPagamento);
		public delegate void delCallSelecionaBancoImportador(ref System.Windows.Forms.PictureBox pbOkBancos, ref System.Windows.Forms.PictureBox pbNOKBancos);
		public delegate void delCallSelecionaBancoExportador(ref System.Windows.Forms.PictureBox pbOkBancos, ref System.Windows.Forms.PictureBox pbNOKBancos);
		public delegate void delCallSelecionaObservacoes(ref System.Windows.Forms.PictureBox pbOkObservacoes, ref System.Windows.Forms.PictureBox pbNOKObservacoes);
		public delegate void delCallSelecionaAssinatura(ref System.Windows.Forms.PictureBox pbOkAssinatura, ref System.Windows.Forms.PictureBox pbNOKAssinatura);
		// Delegate para o Banner
		public delegate void delCallAlteraBanner(ref System.Windows.Forms.PictureBox pbBanner);
		public delegate void delCallClickBanner();
		#endregion
		#region Events
		// Interface
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		// cliques
		public event delCallSelecionaNumeroFaturaComercial eCallSelecionaNumeroFaturaComercial;
		public event delCallSelecionaNumeroFatura eCallSelecionaNumeroFatura;
		public event delCallSelecionaIdioma eCallSelecionaIdioma;
		public event delCallSelecionaMoeda eCallSelecionaMoeda;
		public event delCallSelecionaImportador eCallSelecionaImportador;
		public event delCallSelecionaProdutos eCallSelecionaProdutos;
		public event delCallSelecionaPesos eCallSelecionaPesos;
		public event delCallSelecionaNumeroOrdemCompra eCallSelecionaNumeroOrdemCompra;
		public event delCallSelecionaIncoterm eCallSelecionaIncoterm;
		public event delCallSelecionaLocais eCallSelecionaLocais;
		public event delCallSelecionaCondicoesPagamento eCallSelecionaCondicoesPagamento;
		public event delCallSelecionaBancoImportador eCallSelecionaBancoImportador;
		public event delCallSelecionaBancoExportador eCallSelecionaBancoExportador;
		public event delCallSelecionaObservacoes eCallSelecionaObservacoes;
		public event delCallSelecionaAssinatura eCallSelecionaAssinatura;
		// Eventos Alterar Banner
		public event delCallAlteraBanner eCallAlteraBanner;
		public event delCallClickBanner eCallClickBanner;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			mdlComponentesGraficos.FormFlutuante referenciaThis = (mdlComponentesGraficos.FormFlutuante)this;
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref referenciaThis, ref m_gbFields);
		}
		protected virtual void OnCallSelecionaNumeroFatura()
		{
			if (eCallSelecionaNumeroFatura != null)
				eCallSelecionaNumeroFatura(ref m_pbOkNumeroFatura);
			else if (eCallSelecionaNumeroFaturaComercial != null)
				eCallSelecionaNumeroFaturaComercial(ref m_pbOkNumeroFatura, ref m_pbNOKNumeroFatura);
		}
		protected virtual void OnCallSelecionaIdioma()
		{
			if (eCallSelecionaIdioma != null)
				eCallSelecionaIdioma(ref m_pbOkIdioma, ref m_pbNOKIdioma);
		}
		protected virtual void OnCallSelecionaMoeda()
		{
			if (eCallSelecionaMoeda != null)
				eCallSelecionaMoeda(ref m_pbOkMoeda, ref m_pbNOKMoeda);
		}
		protected virtual void OnCallSelecionaImportador()
		{
			if (eCallSelecionaImportador != null)
				eCallSelecionaImportador(ref m_pbOkImportador, ref m_pbNOKImportador);
		}
		protected virtual void OnCallSelecionaProdutos()
		{
			if (eCallSelecionaProdutos != null)
				eCallSelecionaProdutos(ref m_pbOkProdutos, ref m_pbNOKProdutos);
		}
		protected virtual void OnCallSelecionaPesos()
		{
			if (eCallSelecionaPesos != null)
				eCallSelecionaPesos(ref m_pbOkPesos, ref m_pbNOKPesos);
		}
		protected virtual void OnCallSelecionaNumeroOrdemCompra()
		{
			if (eCallSelecionaNumeroOrdemCompra != null)
				eCallSelecionaNumeroOrdemCompra(ref m_pbOkNumeroOrdemCompra, ref m_pbNOKNumeroOrdemCompra);
		}
		protected virtual void OnCallSelecionaIncoterm()
		{
			if (eCallSelecionaIncoterm != null)
				eCallSelecionaIncoterm(ref m_pbOkIncoterms, ref m_pbNOKIncoterms);
		}
		protected virtual void OnCallSelecionaLocais()
		{
			if (eCallSelecionaLocais != null)
				eCallSelecionaLocais(ref m_pbOkLocais, ref m_pbNOKLocais);
		}
		protected virtual void OnCallSelecionaCondicoesPagamento()
		{
			if (eCallSelecionaCondicoesPagamento != null)
				eCallSelecionaCondicoesPagamento(ref m_pbOkCondicoesPagamento, ref m_pbNOKCondicoesPagamento);
		}
		protected virtual void OnCallSelecionaBancoImportador()
		{
			if (eCallSelecionaBancoImportador != null)
				eCallSelecionaBancoImportador(ref m_pbOkBancoImportador, ref m_pbNOKBancoImportador);
		}
		protected virtual void OnCallSelecionaBancoExportador()
		{
			if (eCallSelecionaBancoExportador != null)
				eCallSelecionaBancoExportador(ref m_pbOkBancoExportador, ref m_pbNOKBancoExportador);
		}
		protected virtual void OnCallSelecionaObservacoes()
		{
			if (eCallSelecionaObservacoes != null)
				eCallSelecionaObservacoes(ref m_pbOkObservacoes, ref m_pbNOKObservacoes);
		}
		protected virtual void OnCallSelecionaAssinatura()
		{
			if (eCallSelecionaAssinatura != null)
				eCallSelecionaAssinatura(ref m_pbOKAssinatura, ref m_pbNOKAssinatura);
		}
		protected virtual void OnCallAlteraBanner()
		{
			if (eCallAlteraBanner != null)
				eCallAlteraBanner(ref this.m_pbBanner);
		}
		protected virtual void OnCallClickBanner()
		{
			if (eCallClickBanner != null)
				eCallClickBanner();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFAssistentePrincipal));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_llBancoExportador = new System.Windows.Forms.LinkLabel();
			this.m_llAssinatura = new System.Windows.Forms.LinkLabel();
			this.m_pbOKAssinatura = new System.Windows.Forms.PictureBox();
			this.m_pbNOKAssinatura = new System.Windows.Forms.PictureBox();
			this.m_pbBanner = new System.Windows.Forms.PictureBox();
			this.m_llNumeroFatura = new System.Windows.Forms.LinkLabel();
			this.m_llObservacoes = new System.Windows.Forms.LinkLabel();
			this.m_llBancoImportador = new System.Windows.Forms.LinkLabel();
			this.m_llCondicoesPagamento = new System.Windows.Forms.LinkLabel();
			this.m_llLocais = new System.Windows.Forms.LinkLabel();
			this.m_llIncoterm = new System.Windows.Forms.LinkLabel();
			this.m_llNumeroOrdemCompra = new System.Windows.Forms.LinkLabel();
			this.m_llPesos = new System.Windows.Forms.LinkLabel();
			this.m_llProdutos = new System.Windows.Forms.LinkLabel();
			this.m_llImportador = new System.Windows.Forms.LinkLabel();
			this.m_llMoeda = new System.Windows.Forms.LinkLabel();
			this.m_llIdioma = new System.Windows.Forms.LinkLabel();
			this.m_pbOkPesos = new System.Windows.Forms.PictureBox();
			this.m_pbOkProdutos = new System.Windows.Forms.PictureBox();
			this.m_pbOkImportador = new System.Windows.Forms.PictureBox();
			this.m_pbOkMoeda = new System.Windows.Forms.PictureBox();
			this.m_pbOkIdioma = new System.Windows.Forms.PictureBox();
			this.m_pbOkNumeroOrdemCompra = new System.Windows.Forms.PictureBox();
			this.m_pbOkIncoterms = new System.Windows.Forms.PictureBox();
			this.m_pbOkLocais = new System.Windows.Forms.PictureBox();
			this.m_pbOkCondicoesPagamento = new System.Windows.Forms.PictureBox();
			this.m_pbOkObservacoes = new System.Windows.Forms.PictureBox();
			this.m_pbOkNumeroFatura = new System.Windows.Forms.PictureBox();
			this.m_pbNOKPesos = new System.Windows.Forms.PictureBox();
			this.m_pbNOKProdutos = new System.Windows.Forms.PictureBox();
			this.m_pbNOKImportador = new System.Windows.Forms.PictureBox();
			this.m_pbNOKMoeda = new System.Windows.Forms.PictureBox();
			this.m_pbNOKIdioma = new System.Windows.Forms.PictureBox();
			this.m_pbNOKNumeroOrdemCompra = new System.Windows.Forms.PictureBox();
			this.m_pbNOKIncoterms = new System.Windows.Forms.PictureBox();
			this.m_pbNOKLocais = new System.Windows.Forms.PictureBox();
			this.m_pbNOKCondicoesPagamento = new System.Windows.Forms.PictureBox();
			this.m_pbNOKObservacoes = new System.Windows.Forms.PictureBox();
			this.m_pbNOKNumeroFatura = new System.Windows.Forms.PictureBox();
			this.m_pbOkBancoImportador = new System.Windows.Forms.PictureBox();
			this.m_pbNOKBancoImportador = new System.Windows.Forms.PictureBox();
			this.m_pbOkBancoExportador = new System.Windows.Forms.PictureBox();
			this.m_pbNOKBancoExportador = new System.Windows.Forms.PictureBox();
			this.m_ttAssistente = new System.Windows.Forms.ToolTip(this.components);
			this.m_tmAssistente = new System.Windows.Forms.Timer(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(454, 405);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(167, 374);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 10;
			this.m_ttAssistente.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(231, 374);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 11;
			this.m_ttAssistente.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 12;
			this.m_ttAssistente.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_llBancoExportador);
			this.m_gbFields.Controls.Add(this.m_llAssinatura);
			this.m_gbFields.Controls.Add(this.m_pbOKAssinatura);
			this.m_gbFields.Controls.Add(this.m_pbNOKAssinatura);
			this.m_gbFields.Controls.Add(this.m_pbBanner);
			this.m_gbFields.Controls.Add(this.m_llNumeroFatura);
			this.m_gbFields.Controls.Add(this.m_llObservacoes);
			this.m_gbFields.Controls.Add(this.m_llBancoImportador);
			this.m_gbFields.Controls.Add(this.m_llCondicoesPagamento);
			this.m_gbFields.Controls.Add(this.m_llLocais);
			this.m_gbFields.Controls.Add(this.m_llIncoterm);
			this.m_gbFields.Controls.Add(this.m_llNumeroOrdemCompra);
			this.m_gbFields.Controls.Add(this.m_llPesos);
			this.m_gbFields.Controls.Add(this.m_llProdutos);
			this.m_gbFields.Controls.Add(this.m_llImportador);
			this.m_gbFields.Controls.Add(this.m_llMoeda);
			this.m_gbFields.Controls.Add(this.m_llIdioma);
			this.m_gbFields.Controls.Add(this.m_pbOkPesos);
			this.m_gbFields.Controls.Add(this.m_pbOkProdutos);
			this.m_gbFields.Controls.Add(this.m_pbOkImportador);
			this.m_gbFields.Controls.Add(this.m_pbOkMoeda);
			this.m_gbFields.Controls.Add(this.m_pbOkIdioma);
			this.m_gbFields.Controls.Add(this.m_pbOkNumeroOrdemCompra);
			this.m_gbFields.Controls.Add(this.m_pbOkIncoterms);
			this.m_gbFields.Controls.Add(this.m_pbOkLocais);
			this.m_gbFields.Controls.Add(this.m_pbOkCondicoesPagamento);
			this.m_gbFields.Controls.Add(this.m_pbOkObservacoes);
			this.m_gbFields.Controls.Add(this.m_pbOkNumeroFatura);
			this.m_gbFields.Controls.Add(this.m_pbNOKPesos);
			this.m_gbFields.Controls.Add(this.m_pbNOKProdutos);
			this.m_gbFields.Controls.Add(this.m_pbNOKImportador);
			this.m_gbFields.Controls.Add(this.m_pbNOKMoeda);
			this.m_gbFields.Controls.Add(this.m_pbNOKIdioma);
			this.m_gbFields.Controls.Add(this.m_pbNOKNumeroOrdemCompra);
			this.m_gbFields.Controls.Add(this.m_pbNOKIncoterms);
			this.m_gbFields.Controls.Add(this.m_pbNOKLocais);
			this.m_gbFields.Controls.Add(this.m_pbNOKCondicoesPagamento);
			this.m_gbFields.Controls.Add(this.m_pbNOKObservacoes);
			this.m_gbFields.Controls.Add(this.m_pbNOKNumeroFatura);
			this.m_gbFields.Controls.Add(this.m_pbOkBancoImportador);
			this.m_gbFields.Controls.Add(this.m_pbNOKBancoImportador);
			this.m_gbFields.Controls.Add(this.m_pbOkBancoExportador);
			this.m_gbFields.Controls.Add(this.m_pbNOKBancoExportador);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(438, 361);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Itens";
			// 
			// m_llBancoExportador
			// 
			this.m_llBancoExportador.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llBancoExportador.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llBancoExportador.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llBancoExportador.LinkColor = System.Drawing.Color.Red;
			this.m_llBancoExportador.Location = new System.Drawing.Point(29, 260);
			this.m_llBancoExportador.Name = "m_llBancoExportador";
			this.m_llBancoExportador.Size = new System.Drawing.Size(131, 20);
			this.m_llBancoExportador.TabIndex = 40;
			this.m_llBancoExportador.TabStop = true;
			this.m_llBancoExportador.Text = "Banco do Exportador";
			this.m_ttAssistente.SetToolTip(this.m_llBancoExportador, "Item não visitado");
			this.m_llBancoExportador.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llBancoExportador.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llBancoExportador_LinkClicked);
			// 
			// m_llAssinatura
			// 
			this.m_llAssinatura.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llAssinatura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llAssinatura.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llAssinatura.LinkColor = System.Drawing.Color.Red;
			this.m_llAssinatura.Location = new System.Drawing.Point(29, 308);
			this.m_llAssinatura.Name = "m_llAssinatura";
			this.m_llAssinatura.Size = new System.Drawing.Size(69, 20);
			this.m_llAssinatura.TabIndex = 38;
			this.m_llAssinatura.TabStop = true;
			this.m_llAssinatura.Text = "Assinatura";
			this.m_ttAssistente.SetToolTip(this.m_llAssinatura, "Item não visitado");
			this.m_llAssinatura.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llAssinatura.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llAssinatura_LinkClicked);
			// 
			// m_pbOKAssinatura
			// 
			this.m_pbOKAssinatura.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOKAssinatura.Image")));
			this.m_pbOKAssinatura.Location = new System.Drawing.Point(8, 310);
			this.m_pbOKAssinatura.Name = "m_pbOKAssinatura";
			this.m_pbOKAssinatura.Size = new System.Drawing.Size(16, 16);
			this.m_pbOKAssinatura.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOKAssinatura.TabIndex = 37;
			this.m_pbOKAssinatura.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOKAssinatura, "Item completo");
			this.m_pbOKAssinatura.Visible = false;
			// 
			// m_pbNOKAssinatura
			// 
			this.m_pbNOKAssinatura.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKAssinatura.Image")));
			this.m_pbNOKAssinatura.Location = new System.Drawing.Point(8, 310);
			this.m_pbNOKAssinatura.Name = "m_pbNOKAssinatura";
			this.m_pbNOKAssinatura.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKAssinatura.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKAssinatura.TabIndex = 39;
			this.m_pbNOKAssinatura.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKAssinatura, "Item não completo");
			// 
			// m_pbBanner
			// 
			this.m_pbBanner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_pbBanner.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.m_pbBanner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_pbBanner.BackgroundImage")));
			this.m_pbBanner.Location = new System.Drawing.Point(219, 15);
			this.m_pbBanner.Name = "m_pbBanner";
			this.m_pbBanner.Size = new System.Drawing.Size(210, 338);
			this.m_pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbBanner.TabIndex = 36;
			this.m_pbBanner.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbBanner, "www.portaldoexportador.com.br");
			this.m_pbBanner.Click += new System.EventHandler(this.m_pbBanner_Click);
			this.m_pbBanner.MouseEnter += new System.EventHandler(this.m_pbBanner_MouseEnter);
			this.m_pbBanner.MouseLeave += new System.EventHandler(this.m_pbBanner_MouseLeave);
			// 
			// m_llNumeroFatura
			// 
			this.m_llNumeroFatura.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llNumeroFatura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llNumeroFatura.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llNumeroFatura.LinkColor = System.Drawing.Color.Red;
			this.m_llNumeroFatura.Location = new System.Drawing.Point(29, 332);
			this.m_llNumeroFatura.Name = "m_llNumeroFatura";
			this.m_llNumeroFatura.Size = new System.Drawing.Size(113, 20);
			this.m_llNumeroFatura.TabIndex = 23;
			this.m_llNumeroFatura.TabStop = true;
			this.m_llNumeroFatura.Text = "Número da Fatura";
			this.m_ttAssistente.SetToolTip(this.m_llNumeroFatura, "Item não visitado");
			this.m_llNumeroFatura.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llNumeroFatura.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llNumeroFatura_LinkClicked);
			// 
			// m_llObservacoes
			// 
			this.m_llObservacoes.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llObservacoes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llObservacoes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llObservacoes.LinkColor = System.Drawing.Color.Red;
			this.m_llObservacoes.Location = new System.Drawing.Point(29, 284);
			this.m_llObservacoes.Name = "m_llObservacoes";
			this.m_llObservacoes.Size = new System.Drawing.Size(84, 20);
			this.m_llObservacoes.TabIndex = 21;
			this.m_llObservacoes.TabStop = true;
			this.m_llObservacoes.Text = "Observações";
			this.m_ttAssistente.SetToolTip(this.m_llObservacoes, "Item não visitado");
			this.m_llObservacoes.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llObservacoes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llObservacoes_LinkClicked);
			// 
			// m_llBancoImportador
			// 
			this.m_llBancoImportador.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llBancoImportador.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llBancoImportador.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llBancoImportador.LinkColor = System.Drawing.Color.Red;
			this.m_llBancoImportador.Location = new System.Drawing.Point(29, 236);
			this.m_llBancoImportador.Name = "m_llBancoImportador";
			this.m_llBancoImportador.Size = new System.Drawing.Size(130, 20);
			this.m_llBancoImportador.TabIndex = 19;
			this.m_llBancoImportador.TabStop = true;
			this.m_llBancoImportador.Text = "Banco do Importador";
			this.m_ttAssistente.SetToolTip(this.m_llBancoImportador, "Item não visitado");
			this.m_llBancoImportador.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llBancoImportador.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llBancoImportador_LinkClicked);
			// 
			// m_llCondicoesPagamento
			// 
			this.m_llCondicoesPagamento.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llCondicoesPagamento.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llCondicoesPagamento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llCondicoesPagamento.LinkColor = System.Drawing.Color.Red;
			this.m_llCondicoesPagamento.Location = new System.Drawing.Point(29, 212);
			this.m_llCondicoesPagamento.Name = "m_llCondicoesPagamento";
			this.m_llCondicoesPagamento.Size = new System.Drawing.Size(159, 20);
			this.m_llCondicoesPagamento.TabIndex = 17;
			this.m_llCondicoesPagamento.TabStop = true;
			this.m_llCondicoesPagamento.Text = "Condições de Pagamento";
			this.m_ttAssistente.SetToolTip(this.m_llCondicoesPagamento, "Item não visitado");
			this.m_llCondicoesPagamento.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llCondicoesPagamento.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llCondicoesPagamento_LinkClicked);
			// 
			// m_llLocais
			// 
			this.m_llLocais.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llLocais.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llLocais.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llLocais.LinkColor = System.Drawing.Color.Red;
			this.m_llLocais.Location = new System.Drawing.Point(29, 188);
			this.m_llLocais.Name = "m_llLocais";
			this.m_llLocais.Size = new System.Drawing.Size(44, 20);
			this.m_llLocais.TabIndex = 15;
			this.m_llLocais.TabStop = true;
			this.m_llLocais.Text = "Locais";
			this.m_ttAssistente.SetToolTip(this.m_llLocais, "Item não visitado");
			this.m_llLocais.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llLocais.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llLocais_LinkClicked);
			// 
			// m_llIncoterm
			// 
			this.m_llIncoterm.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llIncoterm.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llIncoterm.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llIncoterm.LinkColor = System.Drawing.Color.Red;
			this.m_llIncoterm.Location = new System.Drawing.Point(29, 164);
			this.m_llIncoterm.Name = "m_llIncoterm";
			this.m_llIncoterm.Size = new System.Drawing.Size(64, 20);
			this.m_llIncoterm.TabIndex = 13;
			this.m_llIncoterm.TabStop = true;
			this.m_llIncoterm.Text = "Incoterms";
			this.m_ttAssistente.SetToolTip(this.m_llIncoterm, "Item não visitado");
			this.m_llIncoterm.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llIncoterm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llIncoterm_LinkClicked);
			// 
			// m_llNumeroOrdemCompra
			// 
			this.m_llNumeroOrdemCompra.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llNumeroOrdemCompra.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llNumeroOrdemCompra.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llNumeroOrdemCompra.LinkColor = System.Drawing.Color.Red;
			this.m_llNumeroOrdemCompra.Location = new System.Drawing.Point(29, 140);
			this.m_llNumeroOrdemCompra.Name = "m_llNumeroOrdemCompra";
			this.m_llNumeroOrdemCompra.Size = new System.Drawing.Size(167, 20);
			this.m_llNumeroOrdemCompra.TabIndex = 11;
			this.m_llNumeroOrdemCompra.TabStop = true;
			this.m_llNumeroOrdemCompra.Text = "Número Ordem de Compra";
			this.m_ttAssistente.SetToolTip(this.m_llNumeroOrdemCompra, "Item não visitado");
			this.m_llNumeroOrdemCompra.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llNumeroOrdemCompra.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llNumeroOrdemCompra_LinkClicked);
			// 
			// m_llPesos
			// 
			this.m_llPesos.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llPesos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llPesos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llPesos.LinkColor = System.Drawing.Color.Red;
			this.m_llPesos.Location = new System.Drawing.Point(29, 116);
			this.m_llPesos.Name = "m_llPesos";
			this.m_llPesos.Size = new System.Drawing.Size(42, 20);
			this.m_llPesos.TabIndex = 9;
			this.m_llPesos.TabStop = true;
			this.m_llPesos.Text = "Pesos";
			this.m_ttAssistente.SetToolTip(this.m_llPesos, "Item não visitado");
			this.m_llPesos.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llPesos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llPesos_LinkClicked);
			// 
			// m_llProdutos
			// 
			this.m_llProdutos.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llProdutos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llProdutos.LinkColor = System.Drawing.Color.Red;
			this.m_llProdutos.Location = new System.Drawing.Point(29, 92);
			this.m_llProdutos.Name = "m_llProdutos";
			this.m_llProdutos.Size = new System.Drawing.Size(119, 20);
			this.m_llProdutos.TabIndex = 7;
			this.m_llProdutos.TabStop = true;
			this.m_llProdutos.Text = "Produtos";
			this.m_ttAssistente.SetToolTip(this.m_llProdutos, "Item não visitado");
			this.m_llProdutos.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llProdutos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llProdutos_LinkClicked);
			// 
			// m_llImportador
			// 
			this.m_llImportador.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llImportador.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llImportador.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llImportador.LinkColor = System.Drawing.Color.Red;
			this.m_llImportador.Location = new System.Drawing.Point(29, 68);
			this.m_llImportador.Name = "m_llImportador";
			this.m_llImportador.Size = new System.Drawing.Size(131, 20);
			this.m_llImportador.TabIndex = 5;
			this.m_llImportador.TabStop = true;
			this.m_llImportador.Text = "Importador";
			this.m_ttAssistente.SetToolTip(this.m_llImportador, "Item não visitado");
			this.m_llImportador.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llImportador.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llImportador_LinkClicked);
			// 
			// m_llMoeda
			// 
			this.m_llMoeda.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llMoeda.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llMoeda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llMoeda.LinkColor = System.Drawing.Color.Red;
			this.m_llMoeda.Location = new System.Drawing.Point(29, 44);
			this.m_llMoeda.Name = "m_llMoeda";
			this.m_llMoeda.Size = new System.Drawing.Size(107, 20);
			this.m_llMoeda.TabIndex = 3;
			this.m_llMoeda.TabStop = true;
			this.m_llMoeda.Text = "Moeda";
			this.m_ttAssistente.SetToolTip(this.m_llMoeda, "Item não visitado");
			this.m_llMoeda.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llMoeda.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llMoeda_LinkClicked);
			// 
			// m_llIdioma
			// 
			this.m_llIdioma.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llIdioma.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llIdioma.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llIdioma.LinkColor = System.Drawing.Color.Red;
			this.m_llIdioma.Location = new System.Drawing.Point(29, 20);
			this.m_llIdioma.Name = "m_llIdioma";
			this.m_llIdioma.Size = new System.Drawing.Size(106, 20);
			this.m_llIdioma.TabIndex = 1;
			this.m_llIdioma.TabStop = true;
			this.m_llIdioma.Text = "Idioma";
			this.m_ttAssistente.SetToolTip(this.m_llIdioma, "Item não visitado");
			this.m_llIdioma.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llIdioma.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llIdioma_LinkClicked);
			// 
			// m_pbOkPesos
			// 
			this.m_pbOkPesos.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkPesos.Image")));
			this.m_pbOkPesos.Location = new System.Drawing.Point(8, 118);
			this.m_pbOkPesos.Name = "m_pbOkPesos";
			this.m_pbOkPesos.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkPesos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkPesos.TabIndex = 8;
			this.m_pbOkPesos.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkPesos, "Item completo");
			this.m_pbOkPesos.Visible = false;
			// 
			// m_pbOkProdutos
			// 
			this.m_pbOkProdutos.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkProdutos.Image")));
			this.m_pbOkProdutos.Location = new System.Drawing.Point(8, 94);
			this.m_pbOkProdutos.Name = "m_pbOkProdutos";
			this.m_pbOkProdutos.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkProdutos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkProdutos.TabIndex = 6;
			this.m_pbOkProdutos.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkProdutos, "Item completo");
			this.m_pbOkProdutos.Visible = false;
			// 
			// m_pbOkImportador
			// 
			this.m_pbOkImportador.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkImportador.Image")));
			this.m_pbOkImportador.Location = new System.Drawing.Point(8, 70);
			this.m_pbOkImportador.Name = "m_pbOkImportador";
			this.m_pbOkImportador.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkImportador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkImportador.TabIndex = 4;
			this.m_pbOkImportador.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkImportador, "Item completo");
			this.m_pbOkImportador.Visible = false;
			// 
			// m_pbOkMoeda
			// 
			this.m_pbOkMoeda.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkMoeda.Image")));
			this.m_pbOkMoeda.Location = new System.Drawing.Point(8, 46);
			this.m_pbOkMoeda.Name = "m_pbOkMoeda";
			this.m_pbOkMoeda.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkMoeda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkMoeda.TabIndex = 2;
			this.m_pbOkMoeda.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkMoeda, "Item completo");
			this.m_pbOkMoeda.Visible = false;
			// 
			// m_pbOkIdioma
			// 
			this.m_pbOkIdioma.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkIdioma.Image")));
			this.m_pbOkIdioma.Location = new System.Drawing.Point(8, 22);
			this.m_pbOkIdioma.Name = "m_pbOkIdioma";
			this.m_pbOkIdioma.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkIdioma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkIdioma.TabIndex = 0;
			this.m_pbOkIdioma.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkIdioma, "Item completo");
			this.m_pbOkIdioma.Visible = false;
			// 
			// m_pbOkNumeroOrdemCompra
			// 
			this.m_pbOkNumeroOrdemCompra.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkNumeroOrdemCompra.Image")));
			this.m_pbOkNumeroOrdemCompra.Location = new System.Drawing.Point(8, 142);
			this.m_pbOkNumeroOrdemCompra.Name = "m_pbOkNumeroOrdemCompra";
			this.m_pbOkNumeroOrdemCompra.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkNumeroOrdemCompra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkNumeroOrdemCompra.TabIndex = 10;
			this.m_pbOkNumeroOrdemCompra.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkNumeroOrdemCompra, "Item completo");
			this.m_pbOkNumeroOrdemCompra.Visible = false;
			// 
			// m_pbOkIncoterms
			// 
			this.m_pbOkIncoterms.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkIncoterms.Image")));
			this.m_pbOkIncoterms.Location = new System.Drawing.Point(8, 166);
			this.m_pbOkIncoterms.Name = "m_pbOkIncoterms";
			this.m_pbOkIncoterms.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkIncoterms.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkIncoterms.TabIndex = 12;
			this.m_pbOkIncoterms.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkIncoterms, "Item completo");
			this.m_pbOkIncoterms.Visible = false;
			// 
			// m_pbOkLocais
			// 
			this.m_pbOkLocais.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkLocais.Image")));
			this.m_pbOkLocais.Location = new System.Drawing.Point(8, 190);
			this.m_pbOkLocais.Name = "m_pbOkLocais";
			this.m_pbOkLocais.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkLocais.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkLocais.TabIndex = 14;
			this.m_pbOkLocais.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkLocais, "Item completo");
			this.m_pbOkLocais.Visible = false;
			// 
			// m_pbOkCondicoesPagamento
			// 
			this.m_pbOkCondicoesPagamento.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkCondicoesPagamento.Image")));
			this.m_pbOkCondicoesPagamento.Location = new System.Drawing.Point(8, 214);
			this.m_pbOkCondicoesPagamento.Name = "m_pbOkCondicoesPagamento";
			this.m_pbOkCondicoesPagamento.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkCondicoesPagamento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkCondicoesPagamento.TabIndex = 16;
			this.m_pbOkCondicoesPagamento.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkCondicoesPagamento, "Item completo");
			this.m_pbOkCondicoesPagamento.Visible = false;
			// 
			// m_pbOkObservacoes
			// 
			this.m_pbOkObservacoes.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkObservacoes.Image")));
			this.m_pbOkObservacoes.Location = new System.Drawing.Point(8, 286);
			this.m_pbOkObservacoes.Name = "m_pbOkObservacoes";
			this.m_pbOkObservacoes.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkObservacoes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkObservacoes.TabIndex = 20;
			this.m_pbOkObservacoes.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkObservacoes, "Item completo");
			this.m_pbOkObservacoes.Visible = false;
			// 
			// m_pbOkNumeroFatura
			// 
			this.m_pbOkNumeroFatura.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkNumeroFatura.Image")));
			this.m_pbOkNumeroFatura.Location = new System.Drawing.Point(8, 334);
			this.m_pbOkNumeroFatura.Name = "m_pbOkNumeroFatura";
			this.m_pbOkNumeroFatura.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkNumeroFatura.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkNumeroFatura.TabIndex = 22;
			this.m_pbOkNumeroFatura.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkNumeroFatura, "Item completo");
			// 
			// m_pbNOKPesos
			// 
			this.m_pbNOKPesos.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKPesos.Image")));
			this.m_pbNOKPesos.Location = new System.Drawing.Point(8, 118);
			this.m_pbNOKPesos.Name = "m_pbNOKPesos";
			this.m_pbNOKPesos.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKPesos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKPesos.TabIndex = 28;
			this.m_pbNOKPesos.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKPesos, "Item não completo");
			// 
			// m_pbNOKProdutos
			// 
			this.m_pbNOKProdutos.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKProdutos.Image")));
			this.m_pbNOKProdutos.Location = new System.Drawing.Point(8, 94);
			this.m_pbNOKProdutos.Name = "m_pbNOKProdutos";
			this.m_pbNOKProdutos.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKProdutos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKProdutos.TabIndex = 27;
			this.m_pbNOKProdutos.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKProdutos, "Item não completo");
			// 
			// m_pbNOKImportador
			// 
			this.m_pbNOKImportador.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKImportador.Image")));
			this.m_pbNOKImportador.Location = new System.Drawing.Point(8, 70);
			this.m_pbNOKImportador.Name = "m_pbNOKImportador";
			this.m_pbNOKImportador.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKImportador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKImportador.TabIndex = 26;
			this.m_pbNOKImportador.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKImportador, "Item não completo");
			// 
			// m_pbNOKMoeda
			// 
			this.m_pbNOKMoeda.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKMoeda.Image")));
			this.m_pbNOKMoeda.Location = new System.Drawing.Point(8, 46);
			this.m_pbNOKMoeda.Name = "m_pbNOKMoeda";
			this.m_pbNOKMoeda.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKMoeda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKMoeda.TabIndex = 25;
			this.m_pbNOKMoeda.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKMoeda, "Item não completo");
			// 
			// m_pbNOKIdioma
			// 
			this.m_pbNOKIdioma.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKIdioma.Image")));
			this.m_pbNOKIdioma.Location = new System.Drawing.Point(8, 22);
			this.m_pbNOKIdioma.Name = "m_pbNOKIdioma";
			this.m_pbNOKIdioma.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKIdioma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKIdioma.TabIndex = 24;
			this.m_pbNOKIdioma.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKIdioma, "Item não completo");
			// 
			// m_pbNOKNumeroOrdemCompra
			// 
			this.m_pbNOKNumeroOrdemCompra.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKNumeroOrdemCompra.Image")));
			this.m_pbNOKNumeroOrdemCompra.Location = new System.Drawing.Point(8, 142);
			this.m_pbNOKNumeroOrdemCompra.Name = "m_pbNOKNumeroOrdemCompra";
			this.m_pbNOKNumeroOrdemCompra.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKNumeroOrdemCompra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKNumeroOrdemCompra.TabIndex = 29;
			this.m_pbNOKNumeroOrdemCompra.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKNumeroOrdemCompra, "Item não completo");
			// 
			// m_pbNOKIncoterms
			// 
			this.m_pbNOKIncoterms.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKIncoterms.Image")));
			this.m_pbNOKIncoterms.Location = new System.Drawing.Point(8, 166);
			this.m_pbNOKIncoterms.Name = "m_pbNOKIncoterms";
			this.m_pbNOKIncoterms.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKIncoterms.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKIncoterms.TabIndex = 30;
			this.m_pbNOKIncoterms.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKIncoterms, "Item não completo");
			// 
			// m_pbNOKLocais
			// 
			this.m_pbNOKLocais.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKLocais.Image")));
			this.m_pbNOKLocais.Location = new System.Drawing.Point(8, 190);
			this.m_pbNOKLocais.Name = "m_pbNOKLocais";
			this.m_pbNOKLocais.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKLocais.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKLocais.TabIndex = 31;
			this.m_pbNOKLocais.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKLocais, "Item não completo");
			// 
			// m_pbNOKCondicoesPagamento
			// 
			this.m_pbNOKCondicoesPagamento.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKCondicoesPagamento.Image")));
			this.m_pbNOKCondicoesPagamento.Location = new System.Drawing.Point(8, 214);
			this.m_pbNOKCondicoesPagamento.Name = "m_pbNOKCondicoesPagamento";
			this.m_pbNOKCondicoesPagamento.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKCondicoesPagamento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKCondicoesPagamento.TabIndex = 32;
			this.m_pbNOKCondicoesPagamento.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKCondicoesPagamento, "Item não completo");
			// 
			// m_pbNOKObservacoes
			// 
			this.m_pbNOKObservacoes.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKObservacoes.Image")));
			this.m_pbNOKObservacoes.Location = new System.Drawing.Point(8, 286);
			this.m_pbNOKObservacoes.Name = "m_pbNOKObservacoes";
			this.m_pbNOKObservacoes.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKObservacoes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKObservacoes.TabIndex = 34;
			this.m_pbNOKObservacoes.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKObservacoes, "Item não completo");
			// 
			// m_pbNOKNumeroFatura
			// 
			this.m_pbNOKNumeroFatura.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKNumeroFatura.Image")));
			this.m_pbNOKNumeroFatura.Location = new System.Drawing.Point(8, 334);
			this.m_pbNOKNumeroFatura.Name = "m_pbNOKNumeroFatura";
			this.m_pbNOKNumeroFatura.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKNumeroFatura.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKNumeroFatura.TabIndex = 35;
			this.m_pbNOKNumeroFatura.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKNumeroFatura, "Item não completo");
			this.m_pbNOKNumeroFatura.Visible = false;
			// 
			// m_pbOkBancoImportador
			// 
			this.m_pbOkBancoImportador.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkBancoImportador.Image")));
			this.m_pbOkBancoImportador.Location = new System.Drawing.Point(8, 238);
			this.m_pbOkBancoImportador.Name = "m_pbOkBancoImportador";
			this.m_pbOkBancoImportador.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkBancoImportador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkBancoImportador.TabIndex = 18;
			this.m_pbOkBancoImportador.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkBancoImportador, "Item completo");
			this.m_pbOkBancoImportador.Visible = false;
			// 
			// m_pbNOKBancoImportador
			// 
			this.m_pbNOKBancoImportador.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKBancoImportador.Image")));
			this.m_pbNOKBancoImportador.Location = new System.Drawing.Point(8, 238);
			this.m_pbNOKBancoImportador.Name = "m_pbNOKBancoImportador";
			this.m_pbNOKBancoImportador.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKBancoImportador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKBancoImportador.TabIndex = 33;
			this.m_pbNOKBancoImportador.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKBancoImportador, "Item não completo");
			// 
			// m_pbOkBancoExportador
			// 
			this.m_pbOkBancoExportador.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkBancoExportador.Image")));
			this.m_pbOkBancoExportador.Location = new System.Drawing.Point(8, 262);
			this.m_pbOkBancoExportador.Name = "m_pbOkBancoExportador";
			this.m_pbOkBancoExportador.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkBancoExportador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkBancoExportador.TabIndex = 41;
			this.m_pbOkBancoExportador.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkBancoExportador, "Item completo");
			this.m_pbOkBancoExportador.Visible = false;
			// 
			// m_pbNOKBancoExportador
			// 
			this.m_pbNOKBancoExportador.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKBancoExportador.Image")));
			this.m_pbNOKBancoExportador.Location = new System.Drawing.Point(8, 262);
			this.m_pbNOKBancoExportador.Name = "m_pbNOKBancoExportador";
			this.m_pbNOKBancoExportador.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKBancoExportador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKBancoExportador.TabIndex = 42;
			this.m_pbNOKBancoExportador.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKBancoExportador, "Item não completo");
			// 
			// m_ttAssistente
			// 
			this.m_ttAssistente.AutomaticDelay = 100;
			this.m_ttAssistente.AutoPopDelay = 5000;
			this.m_ttAssistente.InitialDelay = 100;
			this.m_ttAssistente.ReshowDelay = 20;
			// 
			// m_tmAssistente
			// 
			this.m_tmAssistente.Enabled = true;
			this.m_tmAssistente.Interval = 2000;
			this.m_tmAssistente.Tick += new System.EventHandler(this.m_tmAssistente_Tick);
			// 
			// frmFAssistentePrincipal
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(458, 407);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFAssistentePrincipal";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Assistente";
			this.Load += new System.EventHandler(this.frmFAssistentePrincipal_Load);
			this.Activated += new System.EventHandler(this.frmFAssistentePrincipal_Activated);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		#region Trocar Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		private void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				controlPaletaCores.mostraCorAtual();
				mostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Mostrar Cor
		/// <summary>
		/// Mostra a cor do Formulario Controlado
		/// </summary>
		public void mostraCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				this.BackColor = controlPaletaDeCores.retornaCorAtual();
				for (int cont = 0; cont < this.Controls.Count; cont++) 
				{
					this.Controls[cont].BackColor = this.BackColor;
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ListView") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox"))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
							}
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
		#endregion
		#endregion

		#region Checagem
		private bool checaOks()
		{
			if (m_pbOkBancoImportador.Visible)
				if (m_pbOkBancoExportador.Visible)
					if (m_pbOkCondicoesPagamento.Visible)
						if (m_pbOkIdioma.Visible)
							if (m_pbOkImportador.Visible)
								if (m_pbOkIncoterms.Visible)
									if (m_pbOkLocais.Visible)
										if (m_pbOkMoeda.Visible)
											if (m_pbOkNumeroOrdemCompra.Visible)
												if (m_pbOkObservacoes.Visible)
													if (m_pbOkPesos.Visible)
														if (m_pbOkProdutos.Visible)
															if (m_pbOkNumeroFatura.Visible)
																if (m_pbOKAssinatura.Visible)
																	return true;

			return false;
		}
		#endregion
		#region Botões OK e Cancelar
		private void setaPosicaoEVisibilidadeBotoesOkeCancelar()
		{
			if (m_bMostrarDiretoPrincipal)
			{
				m_btCancelar.Visible = false;
				m_btOk.SetBounds(m_btOk.Location.X + 32, m_btOk.Location.Y, m_btOk.Bounds.Width, m_btOk.Bounds.Height);
			}
		}
		#endregion
		#region Todos OK
		private void todosOkVisiveis()
		{
			m_pbOKAssinatura.Visible = true;
			m_pbOkBancoImportador.Visible = true;
			m_pbOkBancoExportador.Visible = true;
			m_pbOkCondicoesPagamento.Visible = true;
			m_pbOkIdioma.Visible = true;
			m_pbOkImportador.Visible = true;
			m_pbOkIncoterms.Visible = true;
			m_pbOkLocais.Visible = true;
			m_pbOkMoeda.Visible = true;
			m_pbOkNumeroFatura.Visible = true;
			m_pbOkNumeroOrdemCompra.Visible = true;
			m_pbOkObservacoes.Visible = true;
			m_pbOkPesos.Visible = true;
			m_pbOkProdutos.Visible = true;
			// NOK
			m_pbNOKAssinatura.Visible = false;
			m_pbNOKBancoImportador.Visible = false;
			m_pbNOKBancoExportador.Visible = false;
			m_pbNOKCondicoesPagamento.Visible = false;
			m_pbNOKIdioma.Visible = false;
			m_pbNOKImportador.Visible = false;
			m_pbNOKIncoterms.Visible = false;
			m_pbNOKLocais.Visible = false;
			m_pbNOKMoeda.Visible = false;
			m_pbNOKNumeroFatura.Visible = false;
			m_pbNOKNumeroOrdemCompra.Visible = false;
			m_pbNOKObservacoes.Visible = false;
			m_pbNOKPesos.Visible = false;
			m_pbNOKProdutos.Visible = false;
		}
		#endregion

		#region Get & Set
		public void setToolTipBanner(string strToolTip)
		{
			m_ttAssistente.SetToolTip(m_pbBanner, strToolTip);
		}
		public void setaEstadoAssistente(bool bIdioma, bool bMoeda, bool bImportador, bool bProdutos, bool bPesos, bool bOrdemCompra, bool bIncoterms, bool bLocais, bool bCondicoesPagamento, bool bBancoImportador, bool bBancoExportador, bool bObservacoes, bool bNumeroFatura, bool bAssinatura)
		{
			#region Idioma
			if (bIdioma)
			{
				m_pbNOKIdioma.Visible = false;
				m_pbOkIdioma.Visible = true;
				m_llIdioma.LinkVisited = true;
				m_ttAssistente.SetToolTip(m_llIdioma, "Item visitado");
			}
			#endregion
			#region Moeda
			if (bMoeda)
			{
				m_pbNOKMoeda.Visible = false;
				m_pbOkMoeda.Visible = true;
				m_llMoeda.LinkVisited = true;
				m_ttAssistente.SetToolTip(m_llMoeda, "Item visitado");
			}
			#endregion
			#region Importador
			if (bImportador)
			{
				m_pbNOKImportador.Visible = false;
				m_pbOkImportador.Visible = true;
				m_llImportador.LinkVisited = true;
				m_ttAssistente.SetToolTip(m_llImportador, "Item visitado");
			}
			#endregion
			#region Produtos
			if (bProdutos)
			{
				m_pbNOKProdutos.Visible = false;
				m_pbOkProdutos.Visible = true;
				m_llProdutos.LinkVisited = true;
				m_ttAssistente.SetToolTip(m_llProdutos, "Item visitado");
			}
			#endregion
			#region Pesos
			if (bPesos)
			{
				m_pbNOKPesos.Visible = false;
				m_pbOkPesos.Visible = true;
				m_llPesos.LinkVisited = true;
				m_ttAssistente.SetToolTip(m_llPesos, "Item visitado");
			}
			#endregion
			#region Ordem Compra
			if (bOrdemCompra)
			{
				m_pbNOKNumeroOrdemCompra.Visible = false;
				m_pbOkNumeroOrdemCompra.Visible = true;
				m_llNumeroOrdemCompra.LinkVisited = true;
				m_ttAssistente.SetToolTip(m_llNumeroOrdemCompra, "Item visitado");
			}
			#endregion
			#region Incoterms
			if (bIncoterms)
			{
				m_pbNOKIncoterms.Visible = false;
				m_pbOkIncoterms.Visible = true;
				m_llIncoterm.LinkVisited = true;
				m_ttAssistente.SetToolTip(m_llIncoterm, "Item visitado");
			}
			#endregion
			#region Locais
			if (bLocais)
			{
				m_pbNOKLocais.Visible = false;
				m_pbOkLocais.Visible = true;
				m_llLocais.LinkVisited = true;
				m_ttAssistente.SetToolTip(m_llLocais, "Item visitado");
			}
			#endregion
			#region Condições de Pagamento
			if (bCondicoesPagamento)
			{
				m_pbNOKCondicoesPagamento.Visible = false;
				m_pbOkCondicoesPagamento.Visible = true;
				m_llCondicoesPagamento.LinkVisited = true;
				m_ttAssistente.SetToolTip(m_llCondicoesPagamento, "Item visitado");
			}
			#endregion
			#region BancoImportador
			if (bBancoImportador)
			{
				m_pbNOKBancoImportador.Visible = false;
				m_pbOkBancoImportador.Visible = true;
				m_llBancoImportador.LinkVisited = true;
				m_ttAssistente.SetToolTip(m_llBancoImportador, "Item visitado");
			}
			#endregion
			#region BancoExportador
			if (bBancoExportador)
			{
				m_pbNOKBancoExportador.Visible = false;
				m_pbOkBancoExportador.Visible = true;
				m_llBancoExportador.LinkVisited = true;
				m_ttAssistente.SetToolTip(m_llBancoExportador, "Item visitado");
			}
			#endregion
			#region Observações
			if (bObservacoes)
			{
				m_pbNOKObservacoes.Visible = false;
				m_pbOkObservacoes.Visible = true;
				m_llObservacoes.LinkVisited = true;
				m_ttAssistente.SetToolTip(m_llObservacoes, "Item visitado");
			}
			#endregion
			#region Número Fatura
			if (bNumeroFatura)
			{
				m_pbNOKNumeroFatura.Visible = false;
				m_pbOkNumeroFatura.Visible = true;
				m_llNumeroFatura.LinkVisited = true;
				m_ttAssistente.SetToolTip(m_llNumeroFatura, "Item visitado");
			}
			#endregion
			#region Assinatura
			if (bAssinatura)
			{
				m_pbNOKAssinatura.Visible = false;
				m_pbOKAssinatura.Visible = true;
				m_llAssinatura.LinkVisited = true;
				m_ttAssistente.SetToolTip(m_llAssinatura, "Item visitado");
			}
			#endregion
		}
		#endregion

		#region Eventos
		#region Links
		#region Numero da Fatura
		private void m_llNumeroFatura_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.NUMEROFATURA;
			OnCallSelecionaNumeroFatura();
			m_llNumeroFatura.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llNumeroFatura, "Item visitado");
			this.mostraCor();
		}
		#endregion
		#region Idioma
		private void m_llIdioma_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.IDIOMA;
			OnCallSelecionaIdioma();
			m_llIdioma.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llIdioma, "Item visitado");
			this.mostraCor();
			if (m_pbOkIdioma.Visible && m_pbNOKMoeda.Visible)
				m_llMoeda_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Moeda
		private void m_llMoeda_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.MOEDA;
			OnCallSelecionaMoeda();
			m_llMoeda.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llMoeda, "Item visitado");
			this.mostraCor();
			if (m_pbOkMoeda.Visible && m_pbNOKImportador.Visible)
				m_llImportador_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Importador
		private void m_llImportador_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.IMPORTADOR;
			OnCallSelecionaImportador();
			m_llImportador.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llImportador, "Item visitado");
			this.mostraCor();
			if (m_pbOkImportador.Visible && m_pbNOKProdutos.Visible)
				m_llProdutos_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Produtos
		private void m_llProdutos_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.PRODUTOS;
			OnCallSelecionaProdutos();
			m_llProdutos.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llProdutos, "Item visitado");
			this.mostraCor();
			if (m_pbOkProdutos.Visible && m_pbNOKPesos.Visible)
				m_llPesos_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Pesos
		private void m_llPesos_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.PESOS;
			OnCallSelecionaPesos();
			m_llPesos.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llPesos, "Item visitado");
			this.mostraCor();
			if (m_pbOkPesos.Visible && m_pbNOKNumeroOrdemCompra.Visible)
				m_llNumeroOrdemCompra_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Numero Ordem Compra
		private void m_llNumeroOrdemCompra_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.NUMEROORDEMCOMPRA;
			OnCallSelecionaNumeroOrdemCompra();
			m_llNumeroOrdemCompra.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llNumeroOrdemCompra, "Item visitado");
			this.mostraCor();
			if (m_pbOkNumeroOrdemCompra.Visible && m_pbNOKIncoterms.Visible)
				m_llIncoterm_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Incoterms
		private void m_llIncoterm_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.INCOTERMS;
			OnCallSelecionaIncoterm();
			m_llIncoterm.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llIncoterm, "Item visitado");
			this.mostraCor();
			if (m_pbOkIncoterms.Visible && m_pbNOKLocais.Visible)
				m_llLocais_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Locais
		private void m_llLocais_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.LOCAIS;
			OnCallSelecionaLocais();
			m_llLocais.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llLocais, "Item visitado");
			this.mostraCor();
			if (m_pbOkLocais.Visible && m_pbNOKCondicoesPagamento.Visible)
				m_llCondicoesPagamento_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Condições de Pagamento
		private void m_llCondicoesPagamento_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.CONDICOESPAGAMENTOS;
			OnCallSelecionaCondicoesPagamento();
			m_llCondicoesPagamento.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llCondicoesPagamento, "Item visitado");
			this.mostraCor();
			if (m_pbOkCondicoesPagamento.Visible && m_pbNOKBancoImportador.Visible)
				m_llBancoImportador_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region BancoImportador
		private void m_llBancoImportador_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.BANCOS;
			OnCallSelecionaBancoImportador();
			m_llBancoImportador.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llBancoImportador, "Item visitado");
			this.mostraCor();
			if (m_pbOkBancoImportador.Visible && m_pbNOKBancoExportador.Visible)
				m_llBancoExportador_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region BancoExportador
		private void m_llBancoExportador_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.BANCOS;
			OnCallSelecionaBancoExportador();
			m_llBancoExportador.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llBancoExportador, "Item visitado");
			this.mostraCor();
			if (m_pbOkBancoExportador.Visible && m_pbNOKObservacoes.Visible)
				m_llObservacoes_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Observações
		private void m_llObservacoes_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.OBSERVACOES;
			OnCallSelecionaObservacoes();
			m_llObservacoes.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llObservacoes, "Item visitado");
			this.mostraCor();
			if (m_pbOkObservacoes.Visible && m_pbNOKAssinatura.Visible)
				m_llAssinatura_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Assinatura
		private void m_llAssinatura_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.ASSINATURA;
			OnCallSelecionaAssinatura();
			m_llAssinatura.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llAssinatura, "Item visitado");
			this.mostraCor();
			if (m_pbOKAssinatura.Visible && m_pbNOKNumeroFatura.Visible)
				m_llNumeroFatura_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#endregion
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.trocaCor();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Load
		private void frmFAssistentePrincipal_Load(object sender, System.EventArgs e)
		{
			OnCallCarregaDadosInterface();
			this.mostraCor();
			this.m_tmAssistente.Enabled = true;
			this.m_tmAssistente.Start();
			OnCallAlteraBanner();
			setaPosicaoEVisibilidadeBotoesOkeCancelar();
		}
		#endregion
		#region OK
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_bModificado = true;
				this.Close();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#region Tick
		private void m_tmAssistente_Tick(object sender, System.EventArgs e)
		{
			try
			{
				OnCallAlteraBanner();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banner Mouse Enter
		private void m_pbBanner_MouseEnter(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.Hand;
				if ((m_tmAssistente != null) && (m_tmAssistente.Enabled))
					this.m_tmAssistente.Stop();
				//this.m_tmContas.Enabled = false;
			}
			catch
			{
			}
		}
		#endregion
		#region Banner Mouse Leave
		private void m_pbBanner_MouseLeave(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				if (m_tmAssistente != null)
					this.m_tmAssistente.Start();
				//this.m_tmContas.Enabled = true;
			}
			catch
			{
			}
		}
		#endregion
		#region Banner Click
		private void m_pbBanner_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			OnCallClickBanner();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Activated
		private void frmFAssistentePrincipal_Activated(object sender, System.EventArgs e)
		{
			if (m_bLoad == true)
			{
				m_bLoad = false;
				if (m_bMostrarDiretoPrincipal == false)
					this.m_llIdioma_LinkClicked(sender, m_llevents_Args);
				m_bMostrarDiretoPrincipal = true;
			}
		}
		#endregion
		#endregion
	}
}

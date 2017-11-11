using System;
using System.Collections;

namespace mdlCriacaoDocumentos.Frames
{
	/// <summary>
	/// Summary description for frmFAssistenteBordero.
	/// </summary>
	internal class frmFAssistenteBordero : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		public bool m_bModificado = false;

		private bool m_bLoad = true;

		private bool m_bComecarAssistente = true;

		private enum ORDEM { NUMERO, BANCOEXPORTADOR, BANCOIMPORTADOR, DOCUMENTOS, DATAEMBARQUE, DESCRICAOMERCADORIAS, PAGAMENTO, CONTRATOCAMBIO, COBRANCA };
		private ORDEM m_enumOrdem = ORDEM.NUMERO;

		private System.Windows.Forms.LinkLabelLinkClickedEventArgs m_llevents_Args = new System.Windows.Forms.LinkLabelLinkClickedEventArgs(null);

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		internal System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.PictureBox m_pbBanner;
		private System.Windows.Forms.LinkLabel m_llPagamento;
		private System.Windows.Forms.LinkLabel m_llDescricaoMercadorias;
		private System.Windows.Forms.LinkLabel m_llDataEmbarque;
		private System.Windows.Forms.LinkLabel m_llDocumentos;
		private System.Windows.Forms.LinkLabel m_llBancoImportador;
		private System.Windows.Forms.LinkLabel m_llBancoExportador;
		private System.Windows.Forms.LinkLabel m_llNumero;
		private System.Windows.Forms.PictureBox m_pbNOKPagamento;
		private System.Windows.Forms.PictureBox m_pbNOKDescricaoMercadorias;
		private System.Windows.Forms.PictureBox m_pbNOKDataEmbarque;
		private System.Windows.Forms.PictureBox m_pbNOKDocumentos;
		private System.Windows.Forms.PictureBox m_pbNOKBancoImportador;
		private System.Windows.Forms.PictureBox m_pbNOKBancoExportador;
		private System.Windows.Forms.PictureBox m_pbNOKNumero;
		private System.Windows.Forms.PictureBox m_pbOkPagamento;
		private System.Windows.Forms.PictureBox m_pbOkDescricaoMercadorias;
		private System.Windows.Forms.PictureBox m_pbOkDataEmbarque;
		private System.Windows.Forms.PictureBox m_pbOkDocumentos;
		private System.Windows.Forms.PictureBox m_pbOkBancoImportador;
		private System.Windows.Forms.PictureBox m_pbOkBancoExportador;
		private System.Windows.Forms.PictureBox m_pbOkNumero;
		private System.Windows.Forms.ToolTip m_ttAssistente;
		private System.Windows.Forms.Timer m_tmAssistente;
		private System.Windows.Forms.LinkLabel m_llContratoCambio;
		private System.Windows.Forms.PictureBox m_pbOkContratoCambio;
		private System.Windows.Forms.PictureBox m_pbNOKContratoCambio;
		private System.Windows.Forms.LinkLabel m_llCobranca;
		private System.Windows.Forms.PictureBox m_pbOkCobranca;
		private System.Windows.Forms.PictureBox m_pbNOKCobranca;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFAssistenteBordero(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
		}
		public frmFAssistenteBordero(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel, bool bComecarAssistente, bool bTodosOk)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_bComecarAssistente = bComecarAssistente;
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
		// Cliques
		public delegate void delCallSelecionaNumero(ref System.Windows.Forms.PictureBox pbOkNumero, ref System.Windows.Forms.PictureBox pbNOKNumero);
		public delegate void delCallSelecionaBancoExportador(ref System.Windows.Forms.PictureBox pbOkBancoExportador, ref System.Windows.Forms.PictureBox pbNOkBancoExportador);
		public delegate void delCallSelecionaBancoImportador(ref System.Windows.Forms.PictureBox pbOkBancoImportador, ref System.Windows.Forms.PictureBox pbNOKBancoImportador);
		public delegate void delCallSelecionaDocumentos(ref System.Windows.Forms.PictureBox pbOkDocumentos, ref System.Windows.Forms.PictureBox pbNOKDocumentos);
		public delegate void delCallSelecionaDataEmbarque(ref System.Windows.Forms.PictureBox pbOkDataEmbarque, ref System.Windows.Forms.PictureBox pbNOKDataEmbarque);
		public delegate void delCallSelecionaDescricaoMercadorias(ref System.Windows.Forms.PictureBox pbOkDescricaoMercadorias, ref System.Windows.Forms.PictureBox pbNOKDescricaoMercadorias);
		public delegate void delCallSelecionaPagamento(ref System.Windows.Forms.PictureBox pbOkPagamento, ref System.Windows.Forms.PictureBox pbNOKPagamento);
		public delegate void delCallSelecionaContratoCambio(ref System.Windows.Forms.PictureBox pbOkContratoCambio, ref System.Windows.Forms.PictureBox pbNOKContratoCambio);
		public delegate void delCallSelecionaCobranca(ref System.Windows.Forms.PictureBox pbOkCobranca, ref System.Windows.Forms.PictureBox pbNOKCobranca);
		// Delegate para o Banner
		public delegate void delCallAlteraBanner(ref System.Windows.Forms.PictureBox pbBanner);
		public delegate void delCallClickBanner();
		#endregion
		#region Events
		public event delCallSelecionaNumero eCallSelecionaNumero;
		public event delCallSelecionaBancoExportador eCallSelecionaBancoExportador;
		public event delCallSelecionaBancoImportador eCallSelecionaBancoImportador;
		public event delCallSelecionaDocumentos eCallSelecionaDocumentos;
		public event delCallSelecionaDataEmbarque eCallSelecionaDataEmbarque;
		public event delCallSelecionaDescricaoMercadorias eCallSelecionaDescricaoMercadorias;
		public event delCallSelecionaPagamento eCallSelecionaPagamento;
		public event delCallSelecionaContratoCambio eCallSelecionaContratoCambio;
		public event delCallSelecionaCobranca eCallSelecionaCobranca;
		// Eventos Alterar Banner
		public event delCallAlteraBanner eCallAlteraBanner;
		public event delCallClickBanner eCallClickBanner;
		#endregion
		#region Events Methods
		protected virtual void OnCallSelecionaNumero()
		{
			if (eCallSelecionaNumero != null)
				eCallSelecionaNumero(ref m_pbOkNumero, ref m_pbNOKNumero);
		}
		protected virtual void OnCallSelecionaBancoExportador()
		{
			if (eCallSelecionaBancoExportador != null)
				eCallSelecionaBancoExportador(ref m_pbOkBancoExportador, ref m_pbNOKBancoExportador);
		}
		protected virtual void OnCallSelecionaBancoImportador()
		{
			if (eCallSelecionaBancoImportador != null)
				eCallSelecionaBancoImportador(ref m_pbOkBancoImportador, ref m_pbNOKBancoImportador);
		}
		protected virtual void OnCallSelecionaDocumentos()
		{
			if (eCallSelecionaDocumentos != null)
				eCallSelecionaDocumentos(ref m_pbOkDocumentos, ref m_pbNOKDocumentos);
		}
		protected virtual void OnCallSelecionaDataEmbarque()
		{
			if (eCallSelecionaDataEmbarque != null)
				eCallSelecionaDataEmbarque(ref m_pbOkDataEmbarque, ref m_pbNOKDataEmbarque);
		}
		protected virtual void OnCallSelecionaDescricaoMercadorias()
		{
			if (eCallSelecionaDescricaoMercadorias != null)
				eCallSelecionaDescricaoMercadorias(ref m_pbOkDescricaoMercadorias, ref m_pbNOKDescricaoMercadorias);
		}
		protected virtual void OnCallSelecionaPagamento()
		{
			if (eCallSelecionaPagamento != null)
				eCallSelecionaPagamento(ref m_pbOkPagamento, ref m_pbNOKPagamento);
		}
		protected virtual void OnCallSelecionaContratoCambio()
		{
			if (eCallSelecionaContratoCambio != null)
				eCallSelecionaContratoCambio(ref m_pbOkContratoCambio, ref m_pbNOKContratoCambio);
		}
		protected virtual void OnCallSelecionaCobranca()
		{
			if (eCallSelecionaCobranca != null)
				eCallSelecionaCobranca(ref m_pbOkCobranca, ref m_pbNOKCobranca);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFAssistenteBordero));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_llCobranca = new System.Windows.Forms.LinkLabel();
			this.m_llContratoCambio = new System.Windows.Forms.LinkLabel();
			this.m_pbBanner = new System.Windows.Forms.PictureBox();
			this.m_llPagamento = new System.Windows.Forms.LinkLabel();
			this.m_llDescricaoMercadorias = new System.Windows.Forms.LinkLabel();
			this.m_llDataEmbarque = new System.Windows.Forms.LinkLabel();
			this.m_llDocumentos = new System.Windows.Forms.LinkLabel();
			this.m_llBancoImportador = new System.Windows.Forms.LinkLabel();
			this.m_llBancoExportador = new System.Windows.Forms.LinkLabel();
			this.m_llNumero = new System.Windows.Forms.LinkLabel();
			this.m_pbOkNumero = new System.Windows.Forms.PictureBox();
			this.m_pbOkBancoExportador = new System.Windows.Forms.PictureBox();
			this.m_pbOkBancoImportador = new System.Windows.Forms.PictureBox();
			this.m_pbOkDocumentos = new System.Windows.Forms.PictureBox();
			this.m_pbOkDataEmbarque = new System.Windows.Forms.PictureBox();
			this.m_pbOkDescricaoMercadorias = new System.Windows.Forms.PictureBox();
			this.m_pbNOKNumero = new System.Windows.Forms.PictureBox();
			this.m_pbNOKBancoExportador = new System.Windows.Forms.PictureBox();
			this.m_pbNOKBancoImportador = new System.Windows.Forms.PictureBox();
			this.m_pbNOKDocumentos = new System.Windows.Forms.PictureBox();
			this.m_pbNOKDataEmbarque = new System.Windows.Forms.PictureBox();
			this.m_pbNOKDescricaoMercadorias = new System.Windows.Forms.PictureBox();
			this.m_pbOkPagamento = new System.Windows.Forms.PictureBox();
			this.m_pbNOKPagamento = new System.Windows.Forms.PictureBox();
			this.m_pbOkContratoCambio = new System.Windows.Forms.PictureBox();
			this.m_pbNOKContratoCambio = new System.Windows.Forms.PictureBox();
			this.m_pbOkCobranca = new System.Windows.Forms.PictureBox();
			this.m_pbNOKCobranca = new System.Windows.Forms.PictureBox();
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
			this.m_gbFrame.Size = new System.Drawing.Size(454, 357);
			this.m_gbFrame.TabIndex = 1;
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
			this.m_btOk.Location = new System.Drawing.Point(199, 326);
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
			this.m_btCancelar.Location = new System.Drawing.Point(231, 326);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 11;
			this.m_ttAssistente.SetToolTip(this.m_btCancelar, "Fechar");
			this.m_btCancelar.Visible = false;
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
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_llCobranca);
			this.m_gbFields.Controls.Add(this.m_llContratoCambio);
			this.m_gbFields.Controls.Add(this.m_pbBanner);
			this.m_gbFields.Controls.Add(this.m_llPagamento);
			this.m_gbFields.Controls.Add(this.m_llDescricaoMercadorias);
			this.m_gbFields.Controls.Add(this.m_llDataEmbarque);
			this.m_gbFields.Controls.Add(this.m_llDocumentos);
			this.m_gbFields.Controls.Add(this.m_llBancoImportador);
			this.m_gbFields.Controls.Add(this.m_llBancoExportador);
			this.m_gbFields.Controls.Add(this.m_llNumero);
			this.m_gbFields.Controls.Add(this.m_pbOkNumero);
			this.m_gbFields.Controls.Add(this.m_pbOkBancoExportador);
			this.m_gbFields.Controls.Add(this.m_pbOkBancoImportador);
			this.m_gbFields.Controls.Add(this.m_pbOkDocumentos);
			this.m_gbFields.Controls.Add(this.m_pbOkDataEmbarque);
			this.m_gbFields.Controls.Add(this.m_pbOkDescricaoMercadorias);
			this.m_gbFields.Controls.Add(this.m_pbNOKNumero);
			this.m_gbFields.Controls.Add(this.m_pbNOKBancoExportador);
			this.m_gbFields.Controls.Add(this.m_pbNOKBancoImportador);
			this.m_gbFields.Controls.Add(this.m_pbNOKDocumentos);
			this.m_gbFields.Controls.Add(this.m_pbNOKDataEmbarque);
			this.m_gbFields.Controls.Add(this.m_pbNOKDescricaoMercadorias);
			this.m_gbFields.Controls.Add(this.m_pbOkPagamento);
			this.m_gbFields.Controls.Add(this.m_pbNOKPagamento);
			this.m_gbFields.Controls.Add(this.m_pbOkContratoCambio);
			this.m_gbFields.Controls.Add(this.m_pbNOKContratoCambio);
			this.m_gbFields.Controls.Add(this.m_pbOkCobranca);
			this.m_gbFields.Controls.Add(this.m_pbNOKCobranca);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(438, 313);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Selecione";
			// 
			// m_llCobranca
			// 
			this.m_llCobranca.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llCobranca.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llCobranca.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llCobranca.LinkColor = System.Drawing.Color.Red;
			this.m_llCobranca.Location = new System.Drawing.Point(29, 212);
			this.m_llCobranca.Name = "m_llCobranca";
			this.m_llCobranca.Size = new System.Drawing.Size(63, 20);
			this.m_llCobranca.TabIndex = 40;
			this.m_llCobranca.TabStop = true;
			this.m_llCobranca.Text = "Cobrança";
			this.m_ttAssistente.SetToolTip(this.m_llCobranca, "Item não visitado");
			this.m_llCobranca.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llCobranca.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llCobranca_LinkClicked);
			// 
			// m_llContratoCambio
			// 
			this.m_llContratoCambio.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llContratoCambio.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llContratoCambio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llContratoCambio.LinkColor = System.Drawing.Color.Red;
			this.m_llContratoCambio.Location = new System.Drawing.Point(29, 188);
			this.m_llContratoCambio.Name = "m_llContratoCambio";
			this.m_llContratoCambio.Size = new System.Drawing.Size(125, 20);
			this.m_llContratoCambio.TabIndex = 37;
			this.m_llContratoCambio.TabStop = true;
			this.m_llContratoCambio.Text = "Contrato de Câmbio";
			this.m_ttAssistente.SetToolTip(this.m_llContratoCambio, "Item não visitado");
			this.m_llContratoCambio.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llContratoCambio.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llContratoCambio_LinkClicked);
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
			this.m_pbBanner.Size = new System.Drawing.Size(210, 290);
			this.m_pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbBanner.TabIndex = 36;
			this.m_pbBanner.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbBanner, "www.portaldoexportador.com.br");
			this.m_pbBanner.Click += new System.EventHandler(this.m_pbBanner_Click);
			this.m_pbBanner.MouseEnter += new System.EventHandler(this.m_pbBanner_MouseEnter);
			this.m_pbBanner.MouseLeave += new System.EventHandler(this.m_pbBanner_MouseLeave);
			// 
			// m_llPagamento
			// 
			this.m_llPagamento.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llPagamento.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llPagamento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llPagamento.LinkColor = System.Drawing.Color.Red;
			this.m_llPagamento.Location = new System.Drawing.Point(29, 164);
			this.m_llPagamento.Name = "m_llPagamento";
			this.m_llPagamento.Size = new System.Drawing.Size(73, 20);
			this.m_llPagamento.TabIndex = 13;
			this.m_llPagamento.TabStop = true;
			this.m_llPagamento.Text = "Pagamento";
			this.m_ttAssistente.SetToolTip(this.m_llPagamento, "Item não visitado");
			this.m_llPagamento.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llPagamento.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llPagamento_LinkClicked);
			// 
			// m_llDescricaoMercadorias
			// 
			this.m_llDescricaoMercadorias.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llDescricaoMercadorias.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llDescricaoMercadorias.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llDescricaoMercadorias.LinkColor = System.Drawing.Color.Red;
			this.m_llDescricaoMercadorias.Location = new System.Drawing.Point(29, 140);
			this.m_llDescricaoMercadorias.Name = "m_llDescricaoMercadorias";
			this.m_llDescricaoMercadorias.Size = new System.Drawing.Size(190, 20);
			this.m_llDescricaoMercadorias.TabIndex = 11;
			this.m_llDescricaoMercadorias.TabStop = true;
			this.m_llDescricaoMercadorias.Text = "Descrição Geral da Mercadoria";
			this.m_ttAssistente.SetToolTip(this.m_llDescricaoMercadorias, "Item não visitado");
			this.m_llDescricaoMercadorias.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llDescricaoMercadorias.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llDescricaoMercadorias_LinkClicked);
			// 
			// m_llDataEmbarque
			// 
			this.m_llDataEmbarque.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llDataEmbarque.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llDataEmbarque.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llDataEmbarque.LinkColor = System.Drawing.Color.Red;
			this.m_llDataEmbarque.Location = new System.Drawing.Point(29, 116);
			this.m_llDataEmbarque.Name = "m_llDataEmbarque";
			this.m_llDataEmbarque.Size = new System.Drawing.Size(117, 20);
			this.m_llDataEmbarque.TabIndex = 9;
			this.m_llDataEmbarque.TabStop = true;
			this.m_llDataEmbarque.Text = "Data de Embarque";
			this.m_ttAssistente.SetToolTip(this.m_llDataEmbarque, "Item não visitado");
			this.m_llDataEmbarque.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llDataEmbarque.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llDataEmbarque_LinkClicked);
			// 
			// m_llDocumentos
			// 
			this.m_llDocumentos.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llDocumentos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llDocumentos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llDocumentos.LinkColor = System.Drawing.Color.Red;
			this.m_llDocumentos.Location = new System.Drawing.Point(29, 92);
			this.m_llDocumentos.Name = "m_llDocumentos";
			this.m_llDocumentos.Size = new System.Drawing.Size(145, 20);
			this.m_llDocumentos.TabIndex = 7;
			this.m_llDocumentos.TabStop = true;
			this.m_llDocumentos.Text = "Documentos Em Anexo";
			this.m_ttAssistente.SetToolTip(this.m_llDocumentos, "Item não visitado");
			this.m_llDocumentos.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llDocumentos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llDocumentos_LinkClicked);
			// 
			// m_llBancoImportador
			// 
			this.m_llBancoImportador.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llBancoImportador.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llBancoImportador.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llBancoImportador.LinkColor = System.Drawing.Color.Red;
			this.m_llBancoImportador.Location = new System.Drawing.Point(29, 68);
			this.m_llBancoImportador.Name = "m_llBancoImportador";
			this.m_llBancoImportador.Size = new System.Drawing.Size(130, 20);
			this.m_llBancoImportador.TabIndex = 5;
			this.m_llBancoImportador.TabStop = true;
			this.m_llBancoImportador.Text = "Banco do Importador";
			this.m_ttAssistente.SetToolTip(this.m_llBancoImportador, "Item não visitado");
			this.m_llBancoImportador.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llBancoImportador.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llBancoImportador_LinkClicked);
			// 
			// m_llBancoExportador
			// 
			this.m_llBancoExportador.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llBancoExportador.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llBancoExportador.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llBancoExportador.LinkColor = System.Drawing.Color.Red;
			this.m_llBancoExportador.Location = new System.Drawing.Point(29, 44);
			this.m_llBancoExportador.Name = "m_llBancoExportador";
			this.m_llBancoExportador.Size = new System.Drawing.Size(131, 20);
			this.m_llBancoExportador.TabIndex = 3;
			this.m_llBancoExportador.TabStop = true;
			this.m_llBancoExportador.Text = "Banco do Exportador";
			this.m_ttAssistente.SetToolTip(this.m_llBancoExportador, "Item não visitado");
			this.m_llBancoExportador.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llBancoExportador.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llBancoExportador_LinkClicked);
			// 
			// m_llNumero
			// 
			this.m_llNumero.ActiveLinkColor = System.Drawing.Color.Black;
			this.m_llNumero.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_llNumero.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_llNumero.LinkColor = System.Drawing.Color.Red;
			this.m_llNumero.Location = new System.Drawing.Point(29, 20);
			this.m_llNumero.Name = "m_llNumero";
			this.m_llNumero.Size = new System.Drawing.Size(106, 20);
			this.m_llNumero.TabIndex = 1;
			this.m_llNumero.TabStop = true;
			this.m_llNumero.Text = "Número";
			this.m_ttAssistente.SetToolTip(this.m_llNumero, "Item não visitado");
			this.m_llNumero.VisitedLinkColor = System.Drawing.Color.Green;
			this.m_llNumero.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llNumero_LinkClicked);
			// 
			// m_pbOkNumero
			// 
			this.m_pbOkNumero.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkNumero.Image")));
			this.m_pbOkNumero.Location = new System.Drawing.Point(8, 22);
			this.m_pbOkNumero.Name = "m_pbOkNumero";
			this.m_pbOkNumero.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkNumero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkNumero.TabIndex = 0;
			this.m_pbOkNumero.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkNumero, "Item completo");
			this.m_pbOkNumero.Visible = false;
			// 
			// m_pbOkBancoExportador
			// 
			this.m_pbOkBancoExportador.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkBancoExportador.Image")));
			this.m_pbOkBancoExportador.Location = new System.Drawing.Point(8, 46);
			this.m_pbOkBancoExportador.Name = "m_pbOkBancoExportador";
			this.m_pbOkBancoExportador.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkBancoExportador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkBancoExportador.TabIndex = 2;
			this.m_pbOkBancoExportador.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkBancoExportador, "Item completo");
			this.m_pbOkBancoExportador.Visible = false;
			// 
			// m_pbOkBancoImportador
			// 
			this.m_pbOkBancoImportador.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkBancoImportador.Image")));
			this.m_pbOkBancoImportador.Location = new System.Drawing.Point(8, 70);
			this.m_pbOkBancoImportador.Name = "m_pbOkBancoImportador";
			this.m_pbOkBancoImportador.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkBancoImportador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkBancoImportador.TabIndex = 4;
			this.m_pbOkBancoImportador.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkBancoImportador, "Item completo");
			this.m_pbOkBancoImportador.Visible = false;
			// 
			// m_pbOkDocumentos
			// 
			this.m_pbOkDocumentos.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkDocumentos.Image")));
			this.m_pbOkDocumentos.Location = new System.Drawing.Point(8, 94);
			this.m_pbOkDocumentos.Name = "m_pbOkDocumentos";
			this.m_pbOkDocumentos.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkDocumentos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkDocumentos.TabIndex = 6;
			this.m_pbOkDocumentos.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkDocumentos, "Item completo");
			this.m_pbOkDocumentos.Visible = false;
			// 
			// m_pbOkDataEmbarque
			// 
			this.m_pbOkDataEmbarque.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkDataEmbarque.Image")));
			this.m_pbOkDataEmbarque.Location = new System.Drawing.Point(8, 118);
			this.m_pbOkDataEmbarque.Name = "m_pbOkDataEmbarque";
			this.m_pbOkDataEmbarque.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkDataEmbarque.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkDataEmbarque.TabIndex = 8;
			this.m_pbOkDataEmbarque.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkDataEmbarque, "Item completo");
			this.m_pbOkDataEmbarque.Visible = false;
			// 
			// m_pbOkDescricaoMercadorias
			// 
			this.m_pbOkDescricaoMercadorias.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkDescricaoMercadorias.Image")));
			this.m_pbOkDescricaoMercadorias.Location = new System.Drawing.Point(8, 142);
			this.m_pbOkDescricaoMercadorias.Name = "m_pbOkDescricaoMercadorias";
			this.m_pbOkDescricaoMercadorias.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkDescricaoMercadorias.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkDescricaoMercadorias.TabIndex = 10;
			this.m_pbOkDescricaoMercadorias.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkDescricaoMercadorias, "Item completo");
			this.m_pbOkDescricaoMercadorias.Visible = false;
			// 
			// m_pbNOKNumero
			// 
			this.m_pbNOKNumero.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKNumero.Image")));
			this.m_pbNOKNumero.Location = new System.Drawing.Point(8, 22);
			this.m_pbNOKNumero.Name = "m_pbNOKNumero";
			this.m_pbNOKNumero.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKNumero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKNumero.TabIndex = 24;
			this.m_pbNOKNumero.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKNumero, "Item não completo");
			// 
			// m_pbNOKBancoExportador
			// 
			this.m_pbNOKBancoExportador.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKBancoExportador.Image")));
			this.m_pbNOKBancoExportador.Location = new System.Drawing.Point(8, 46);
			this.m_pbNOKBancoExportador.Name = "m_pbNOKBancoExportador";
			this.m_pbNOKBancoExportador.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKBancoExportador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKBancoExportador.TabIndex = 25;
			this.m_pbNOKBancoExportador.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKBancoExportador, "Item não completo");
			// 
			// m_pbNOKBancoImportador
			// 
			this.m_pbNOKBancoImportador.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKBancoImportador.Image")));
			this.m_pbNOKBancoImportador.Location = new System.Drawing.Point(8, 70);
			this.m_pbNOKBancoImportador.Name = "m_pbNOKBancoImportador";
			this.m_pbNOKBancoImportador.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKBancoImportador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKBancoImportador.TabIndex = 26;
			this.m_pbNOKBancoImportador.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKBancoImportador, "Item não completo");
			// 
			// m_pbNOKDocumentos
			// 
			this.m_pbNOKDocumentos.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKDocumentos.Image")));
			this.m_pbNOKDocumentos.Location = new System.Drawing.Point(8, 94);
			this.m_pbNOKDocumentos.Name = "m_pbNOKDocumentos";
			this.m_pbNOKDocumentos.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKDocumentos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKDocumentos.TabIndex = 27;
			this.m_pbNOKDocumentos.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKDocumentos, "Item não completo");
			// 
			// m_pbNOKDataEmbarque
			// 
			this.m_pbNOKDataEmbarque.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKDataEmbarque.Image")));
			this.m_pbNOKDataEmbarque.Location = new System.Drawing.Point(8, 118);
			this.m_pbNOKDataEmbarque.Name = "m_pbNOKDataEmbarque";
			this.m_pbNOKDataEmbarque.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKDataEmbarque.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKDataEmbarque.TabIndex = 28;
			this.m_pbNOKDataEmbarque.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKDataEmbarque, "Item não completo");
			// 
			// m_pbNOKDescricaoMercadorias
			// 
			this.m_pbNOKDescricaoMercadorias.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKDescricaoMercadorias.Image")));
			this.m_pbNOKDescricaoMercadorias.Location = new System.Drawing.Point(8, 142);
			this.m_pbNOKDescricaoMercadorias.Name = "m_pbNOKDescricaoMercadorias";
			this.m_pbNOKDescricaoMercadorias.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKDescricaoMercadorias.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKDescricaoMercadorias.TabIndex = 29;
			this.m_pbNOKDescricaoMercadorias.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKDescricaoMercadorias, "Item não completo");
			// 
			// m_pbOkPagamento
			// 
			this.m_pbOkPagamento.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkPagamento.Image")));
			this.m_pbOkPagamento.Location = new System.Drawing.Point(8, 166);
			this.m_pbOkPagamento.Name = "m_pbOkPagamento";
			this.m_pbOkPagamento.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkPagamento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkPagamento.TabIndex = 12;
			this.m_pbOkPagamento.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkPagamento, "Item completo");
			this.m_pbOkPagamento.Visible = false;
			// 
			// m_pbNOKPagamento
			// 
			this.m_pbNOKPagamento.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKPagamento.Image")));
			this.m_pbNOKPagamento.Location = new System.Drawing.Point(8, 166);
			this.m_pbNOKPagamento.Name = "m_pbNOKPagamento";
			this.m_pbNOKPagamento.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKPagamento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKPagamento.TabIndex = 30;
			this.m_pbNOKPagamento.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKPagamento, "Item não completo");
			// 
			// m_pbOkContratoCambio
			// 
			this.m_pbOkContratoCambio.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkContratoCambio.Image")));
			this.m_pbOkContratoCambio.Location = new System.Drawing.Point(8, 190);
			this.m_pbOkContratoCambio.Name = "m_pbOkContratoCambio";
			this.m_pbOkContratoCambio.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkContratoCambio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkContratoCambio.TabIndex = 38;
			this.m_pbOkContratoCambio.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkContratoCambio, "Item completo");
			this.m_pbOkContratoCambio.Visible = false;
			// 
			// m_pbNOKContratoCambio
			// 
			this.m_pbNOKContratoCambio.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKContratoCambio.Image")));
			this.m_pbNOKContratoCambio.Location = new System.Drawing.Point(8, 190);
			this.m_pbNOKContratoCambio.Name = "m_pbNOKContratoCambio";
			this.m_pbNOKContratoCambio.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKContratoCambio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKContratoCambio.TabIndex = 39;
			this.m_pbNOKContratoCambio.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKContratoCambio, "Item não completo");
			// 
			// m_pbOkCobranca
			// 
			this.m_pbOkCobranca.Image = ((System.Drawing.Image)(resources.GetObject("m_pbOkCobranca.Image")));
			this.m_pbOkCobranca.Location = new System.Drawing.Point(8, 214);
			this.m_pbOkCobranca.Name = "m_pbOkCobranca";
			this.m_pbOkCobranca.Size = new System.Drawing.Size(16, 16);
			this.m_pbOkCobranca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbOkCobranca.TabIndex = 41;
			this.m_pbOkCobranca.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbOkCobranca, "Item completo");
			this.m_pbOkCobranca.Visible = false;
			// 
			// m_pbNOKCobranca
			// 
			this.m_pbNOKCobranca.Image = ((System.Drawing.Image)(resources.GetObject("m_pbNOKCobranca.Image")));
			this.m_pbNOKCobranca.Location = new System.Drawing.Point(8, 214);
			this.m_pbNOKCobranca.Name = "m_pbNOKCobranca";
			this.m_pbNOKCobranca.Size = new System.Drawing.Size(16, 16);
			this.m_pbNOKCobranca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_pbNOKCobranca.TabIndex = 42;
			this.m_pbNOKCobranca.TabStop = false;
			this.m_ttAssistente.SetToolTip(this.m_pbNOKCobranca, "Item não completo");
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
			// frmFAssistenteBordero
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(458, 359);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFAssistenteBordero";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Assistente";
			this.Load += new System.EventHandler(this.frmFAssistenteBordero_Load);
			this.Activated += new System.EventHandler(this.frmFAssistenteBordero_Activated);
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

		#region Todos OK
		private void todosOkVisiveis()
		{
			m_pbOkNumero.Visible = true;
			m_pbOkBancoExportador.Visible = true;
			m_pbOkBancoImportador.Visible = true;
			m_pbOkDocumentos.Visible = true;
			m_pbOkDataEmbarque.Visible = true;
			m_pbOkDescricaoMercadorias.Visible = true;
			m_pbOkPagamento.Visible = true;
			m_pbOkContratoCambio.Visible = true;
			// NOK
			m_pbNOKNumero.Visible = false;
			m_pbNOKBancoExportador.Visible = false;
			m_pbNOKBancoImportador.Visible = false;
			m_pbNOKDocumentos.Visible = false;
			m_pbNOKDataEmbarque.Visible = false;
			m_pbNOKDescricaoMercadorias.Visible = false;
			m_pbNOKPagamento.Visible = false;
			m_pbNOKContratoCambio.Visible = false;
		}
		#endregion

		#region Get & Set
		public void setaEstadoAssistente(bool bNumero, bool bBancoExportador, bool bBancoImportador, bool bDocumentos, bool bDataEmbarque, bool bDescricaoMercadorias, bool bPagamento, bool bContratoCambio, bool bCobranca)
		{
			try
			{
				#region Número
				if (bNumero)
				{
					m_pbNOKNumero.Visible = false;
					m_pbOkNumero.Visible = true;
					m_llNumero.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llNumero, "Item visitado");
				}
				#endregion
				#region Banco Exportador
				if (bBancoExportador)
				{
					m_pbNOKBancoExportador.Visible = false;
					m_pbOkBancoExportador.Visible = true;
					m_llBancoExportador.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llBancoExportador, "Item visitado");
				}
				#endregion
				#region Banco Importador
				if (bBancoImportador)
				{
					m_pbNOKBancoImportador.Visible = false;
					m_pbOkBancoImportador.Visible = true;
					m_llBancoImportador.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llBancoImportador, "Item visitado");
				}
				#endregion
				#region Documentos
				if (bDocumentos)
				{
					m_pbNOKDocumentos.Visible = false;
					m_pbOkDocumentos.Visible = true;
					m_llDocumentos.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llDocumentos, "Item visitado");
				}
				#endregion
				#region Data Embarque
				if (bDataEmbarque)
				{
					m_pbNOKDataEmbarque.Visible = false;
					m_pbOkDataEmbarque.Visible = true;
					m_llDataEmbarque.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llDataEmbarque, "Item visitado");
				}
				#endregion
				#region Descrição Mercadorias
				if (bDescricaoMercadorias)
				{
					m_pbNOKDescricaoMercadorias.Visible = false;
					m_pbOkDescricaoMercadorias.Visible = true;
					m_llDescricaoMercadorias.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llDescricaoMercadorias, "Item visitado");
				}
				#endregion
				#region Pagamento
				if (bPagamento)
				{
					m_pbNOKPagamento.Visible = false;
					m_pbOkPagamento.Visible = true;
					m_llPagamento.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llPagamento, "Item visitado");
				}
				#endregion
				#region ContratoCambio
				if (bContratoCambio)
				{
					m_pbNOKContratoCambio.Visible = false;
					m_pbOkContratoCambio.Visible = true;
					m_llContratoCambio.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llContratoCambio, "Item visitado");
				}
				#endregion
				#region Cobrança
				if (bCobranca)
				{
					m_pbNOKCobranca.Visible = false;
					m_pbOkCobranca.Visible = true;
					m_llCobranca.LinkVisited = true;
					m_ttAssistente.SetToolTip(m_llCobranca, "Item visitado");
				}
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		public void setToolTipBanner(string strToolTip)
		{
			m_ttAssistente.SetToolTip(m_pbBanner, strToolTip);
		}
		#endregion
		
		#region Eventos
		#region Links
		#region Número
		private void m_llNumero_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.NUMERO;
			OnCallSelecionaNumero();
			m_llNumero.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llNumero, "Item visitado");
			this.mostraCor();
			if (m_pbOkNumero.Visible && m_pbNOKBancoExportador.Visible)
				m_llBancoExportador_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Banco Exportador
		private void m_llBancoExportador_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.BANCOEXPORTADOR;
			OnCallSelecionaBancoExportador();
			m_llBancoExportador.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llBancoExportador, "Item visitado");
			this.mostraCor();
			if (m_pbOkBancoExportador.Visible && m_pbNOKBancoImportador.Visible)
				m_llBancoImportador_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Banco Importador
		private void m_llBancoImportador_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.BANCOIMPORTADOR;
			OnCallSelecionaBancoImportador();
			m_llBancoImportador.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llBancoImportador, "Item visitado");
			this.mostraCor();
			if (m_pbOkBancoImportador.Visible && m_pbNOKDocumentos.Visible)
				m_llDocumentos_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Documentos
		private void m_llDocumentos_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.DOCUMENTOS;
			OnCallSelecionaDocumentos();
			m_llDocumentos.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llDocumentos, "Item visitado");
			this.mostraCor();
			if (m_pbOkDocumentos.Visible && m_pbNOKDataEmbarque.Visible)
				m_llDataEmbarque_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Data Embarque
		private void m_llDataEmbarque_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.DATAEMBARQUE;
			OnCallSelecionaDataEmbarque();
			m_llDataEmbarque.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llDataEmbarque, "Item visitado");
			this.mostraCor();
			if (m_pbOkDataEmbarque.Visible && m_pbNOKDescricaoMercadorias.Visible)
				m_llDescricaoMercadorias_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Descrição Mercadorias
		private void m_llDescricaoMercadorias_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.DESCRICAOMERCADORIAS;
			OnCallSelecionaDescricaoMercadorias();
			m_llDescricaoMercadorias.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llDescricaoMercadorias, "Item visitado");
			this.mostraCor();
			if (m_pbOkDescricaoMercadorias.Visible && m_pbNOKPagamento.Visible)
				m_llPagamento_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Pagamento
		private void m_llPagamento_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.PAGAMENTO;
			OnCallSelecionaPagamento();
			m_llPagamento.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llPagamento, "Item visitado");
			this.mostraCor();
			if (m_pbOkPagamento.Visible && m_pbNOKContratoCambio.Visible)
				m_llContratoCambio_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region ContratoCambio
		private void m_llContratoCambio_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.CONTRATOCAMBIO;
			OnCallSelecionaContratoCambio();
			m_llContratoCambio.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llContratoCambio, "Item visitado");
			this.mostraCor();
			if (m_pbOkContratoCambio.Visible && m_pbNOKCobranca.Visible)
				m_llCobranca_LinkClicked(sender, m_llevents_Args);
		}
		#endregion
		#region Cobrança
		private void m_llCobranca_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_enumOrdem = ORDEM.COBRANCA;
			OnCallSelecionaCobranca();
			m_llCobranca.LinkVisited = true;
			m_ttAssistente.SetToolTip(m_llCobranca, "Item visitado");
			this.mostraCor();
		}
		#endregion
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			m_bModificado = false;
			this.Close();
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			m_bModificado = true;
			this.Close();
		}
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
		private void frmFAssistenteBordero_Load(object sender, System.EventArgs e)
		{
			this.mostraCor();
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
		private void frmFAssistenteBordero_Activated(object sender, System.EventArgs e)
		{
			if (m_bLoad == true)
			{
				m_bLoad = false;
				if (m_bComecarAssistente)
				{
					if (m_pbNOKNumero.Visible)
						this.m_llNumero_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKBancoExportador.Visible)
						this.m_llBancoExportador_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKBancoImportador.Visible)
						this.m_llBancoImportador_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKDocumentos.Visible)
						this.m_llDocumentos_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKDataEmbarque.Visible)
						this.m_llDataEmbarque_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKDescricaoMercadorias.Visible)
						this.m_llDescricaoMercadorias_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKPagamento.Visible)
						this.m_llPagamento_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKContratoCambio.Visible)
						this.m_llContratoCambio_LinkClicked(sender, m_llevents_Args);
					else if (m_pbNOKCobranca.Visible)
						this.m_llCobranca_LinkClicked(sender, m_llevents_Args);
				}
			}
		}
		#endregion
		#endregion
	}
}

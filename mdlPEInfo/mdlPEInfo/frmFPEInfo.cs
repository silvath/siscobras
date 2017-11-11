using System;
using System.Drawing;
using System.Collections;

namespace mdlPEInfo
{
	/// <summary>
	/// Summary description for frmFPEInfo.
	/// </summary>
	internal class frmFPEInfo : mdlComponentesGraficos.FormFixo
	{
		#region Delegate
		// Delegate para BD
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallSetaToolTip();
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosBD(bool bModificado);
		// Impressão
		public delegate void delCallImprimeSumario();
		public delegate void delCallImprimeFaturaProforma();
		public delegate void delCallImprimeFaturaComercial();
		public delegate void delCallImprimeCertificadosOrigem();
		public delegate void delCallImprimeReserva();
		public delegate void delCallImprimeInstrucoesEmbarque();
		public delegate void delCallImprimeGuiaEntrada();
		public delegate void delCallImprimeRomaneio();
		public delegate void delCallImprimeSaque();
		public delegate void delCallImprimeBordero();
		public delegate void delCallImprimeTodos();

		#endregion
		#region Events
		// Eventos BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallSetaToolTip eCallSetaToolTip;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		// Impressão
		public event delCallImprimeSumario eCallImprimeSumario;
		public event delCallImprimeFaturaProforma eCallImprimeFaturaProforma;
		public event delCallImprimeFaturaComercial eCallImprimeFaturaComercial;
		public event delCallImprimeCertificadosOrigem eCallImprimeCertificadosOrigem;
		public event delCallImprimeReserva eCallImprimeReserva;
		public event delCallImprimeInstrucoesEmbarque eCallImprimeInstrucoesEmbarque;
		public event delCallImprimeGuiaEntrada eCallImprimeGuiaEntrada;
		public event delCallImprimeRomaneio eCallImprimeRomaneio;
		public event delCallImprimeSaque eCallImprimeSaque;
		public event delCallImprimeBordero eCallImprimeBordero;
		public event delCallImprimeTodos eCallImprimeTodos;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		}
		protected virtual void OnCallSetaToolTip()
		{
			if (eCallSetaToolTip != null)
				eCallSetaToolTip();
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bModificado);
		}
		protected virtual void OnCallImprimeSumario()
		{
			if (eCallImprimeSumario != null)
				eCallImprimeSumario();
		}
		protected virtual void OnCallImprimeFaturaProforma()
		{
			if (eCallImprimeFaturaProforma != null)
				eCallImprimeFaturaProforma();
		}
		protected virtual void OnCallImprimeFaturaComercial()
		{
			if (eCallImprimeFaturaComercial != null)
				eCallImprimeFaturaComercial();
		}

		protected virtual void OnCallImprimeCertificadosOrigem()
		{
			if (eCallImprimeCertificadosOrigem != null)
				eCallImprimeCertificadosOrigem();
		}

		protected virtual void OnCallImprimeReserva()
		{
			if (eCallImprimeReserva != null)
				eCallImprimeReserva();
		}

		protected virtual void OnCallImprimeInstrucoesEmbarque()
		{
			if (eCallImprimeInstrucoesEmbarque != null)
				eCallImprimeInstrucoesEmbarque();
		}

		protected virtual void OnCallImprimeGuiaEntrada()
		{
			if (eCallImprimeGuiaEntrada != null)
				eCallImprimeGuiaEntrada();
		}

		protected virtual void OnCallImprimeRomaneio()
		{
			if (eCallImprimeRomaneio != null)
				eCallImprimeRomaneio();
		}

		protected virtual void OnCallImprimeSaque()
		{
			if (eCallImprimeSaque != null)
				eCallImprimeSaque();
		}

		protected virtual void OnCallImprimeBordero()
		{
			if (eCallImprimeBordero != null)
				eCallImprimeBordero();
		}

		protected virtual void OnCallImprimeTodos()
		{
			if (eCallImprimeTodos != null)
				eCallImprimeTodos();
		}
		#endregion

		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		private bool m_bModificado = false;

		protected mdlComponentesGraficos.MessageBalloon m_mgblBalaoToolTip = null;
		private bool m_bMostrarBaloes = true;

		internal System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.Label m_lSaque;
		private System.Windows.Forms.Label m_lRomaneio;
		private System.Windows.Forms.Label m_lCertificadoOrigem;
		private System.Windows.Forms.Label m_lFaturaComercial;
		private System.Windows.Forms.Label m_lFaturaProforma;
		internal System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Label m_lOrdemEmbarque;
		private System.Windows.Forms.Label m_lBordero;
		private System.Windows.Forms.ToolTip m_ttStatus;
		private System.Windows.Forms.Label m_lPE;
		private System.Windows.Forms.Timer m_tmPEInfo;
		private System.Windows.Forms.GroupBox m_gbImpressao;
		private System.Windows.Forms.GroupBox m_gbBanner;
		private System.Windows.Forms.Label m_lbSumario;
		private System.Windows.Forms.PictureBox m_picBanner;
		private System.Windows.Forms.Button m_btImpressaoPE;
		private System.Windows.Forms.Button m_btImpressaoSumario;
		private System.Windows.Forms.Button m_btImpressaoFaturaProforma;
		private System.Windows.Forms.Button m_btImpressaoFaturaComercial;
		private System.Windows.Forms.Button m_btImpressaoCertificadoOrigem;
		private System.Windows.Forms.Button m_btImpressaoOrdemEmbarque;
		private System.Windows.Forms.Button m_btImpressaoRomaneio;
		private System.Windows.Forms.Button m_btImpressaoSaque;
		private System.Windows.Forms.Button m_btImpressaoBordero;
		private System.Windows.Forms.Button m_btImpressaoReserva;
		private System.Windows.Forms.Label m_lbImpressaoReserva;
		private System.Windows.Forms.Button m_btImpressaoGuiaEntrada;
		private System.Windows.Forms.Label m_lbImpressaoGuiaEntrada;
		private System.ComponentModel.IContainer components;
		#endregion
		#region Construtors and Destrutors
		public frmFPEInfo(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
		}
		public frmFPEInfo(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel, bool bMostrarBaloes)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_bMostrarBaloes = bMostrarBaloes;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFPEInfo));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_gbBanner = new System.Windows.Forms.GroupBox();
			this.m_picBanner = new System.Windows.Forms.PictureBox();
			this.m_gbImpressao = new System.Windows.Forms.GroupBox();
			this.m_btImpressaoGuiaEntrada = new System.Windows.Forms.Button();
			this.m_lbImpressaoGuiaEntrada = new System.Windows.Forms.Label();
			this.m_btImpressaoReserva = new System.Windows.Forms.Button();
			this.m_lbImpressaoReserva = new System.Windows.Forms.Label();
			this.m_btImpressaoBordero = new System.Windows.Forms.Button();
			this.m_btImpressaoSaque = new System.Windows.Forms.Button();
			this.m_btImpressaoRomaneio = new System.Windows.Forms.Button();
			this.m_btImpressaoOrdemEmbarque = new System.Windows.Forms.Button();
			this.m_btImpressaoCertificadoOrigem = new System.Windows.Forms.Button();
			this.m_btImpressaoFaturaComercial = new System.Windows.Forms.Button();
			this.m_btImpressaoFaturaProforma = new System.Windows.Forms.Button();
			this.m_btImpressaoSumario = new System.Windows.Forms.Button();
			this.m_btImpressaoPE = new System.Windows.Forms.Button();
			this.m_lbSumario = new System.Windows.Forms.Label();
			this.m_lPE = new System.Windows.Forms.Label();
			this.m_lFaturaProforma = new System.Windows.Forms.Label();
			this.m_lBordero = new System.Windows.Forms.Label();
			this.m_lSaque = new System.Windows.Forms.Label();
			this.m_lOrdemEmbarque = new System.Windows.Forms.Label();
			this.m_lFaturaComercial = new System.Windows.Forms.Label();
			this.m_lCertificadoOrigem = new System.Windows.Forms.Label();
			this.m_lRomaneio = new System.Windows.Forms.Label();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_ttStatus = new System.Windows.Forms.ToolTip(this.components);
			this.m_tmPEInfo = new System.Windows.Forms.Timer(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbBanner.SuspendLayout();
			this.m_gbImpressao.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_gbBanner);
			this.m_gbFrame.Controls.Add(this.m_gbImpressao);
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Location = new System.Drawing.Point(73, -1);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(719, 599);
			this.m_gbFrame.TabIndex = 1;
			this.m_gbFrame.TabStop = false;
			this.m_gbFrame.Text = "Informações do PE";
			// 
			// m_gbBanner
			// 
			this.m_gbBanner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbBanner.Controls.Add(this.m_picBanner);
			this.m_gbBanner.Location = new System.Drawing.Point(290, 82);
			this.m_gbBanner.Name = "m_gbBanner";
			this.m_gbBanner.Size = new System.Drawing.Size(422, 510);
			this.m_gbBanner.TabIndex = 170;
			this.m_gbBanner.TabStop = false;
			// 
			// m_picBanner
			// 
			this.m_picBanner.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_picBanner.Location = new System.Drawing.Point(8, 157);
			this.m_picBanner.Name = "m_picBanner";
			this.m_picBanner.Size = new System.Drawing.Size(408, 283);
			this.m_picBanner.TabIndex = 0;
			this.m_picBanner.TabStop = false;
			// 
			// m_gbImpressao
			// 
			this.m_gbImpressao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_gbImpressao.Controls.Add(this.m_btImpressaoGuiaEntrada);
			this.m_gbImpressao.Controls.Add(this.m_lbImpressaoGuiaEntrada);
			this.m_gbImpressao.Controls.Add(this.m_btImpressaoReserva);
			this.m_gbImpressao.Controls.Add(this.m_lbImpressaoReserva);
			this.m_gbImpressao.Controls.Add(this.m_btImpressaoBordero);
			this.m_gbImpressao.Controls.Add(this.m_btImpressaoSaque);
			this.m_gbImpressao.Controls.Add(this.m_btImpressaoRomaneio);
			this.m_gbImpressao.Controls.Add(this.m_btImpressaoOrdemEmbarque);
			this.m_gbImpressao.Controls.Add(this.m_btImpressaoCertificadoOrigem);
			this.m_gbImpressao.Controls.Add(this.m_btImpressaoFaturaComercial);
			this.m_gbImpressao.Controls.Add(this.m_btImpressaoFaturaProforma);
			this.m_gbImpressao.Controls.Add(this.m_btImpressaoSumario);
			this.m_gbImpressao.Controls.Add(this.m_btImpressaoPE);
			this.m_gbImpressao.Controls.Add(this.m_lbSumario);
			this.m_gbImpressao.Controls.Add(this.m_lPE);
			this.m_gbImpressao.Controls.Add(this.m_lFaturaProforma);
			this.m_gbImpressao.Controls.Add(this.m_lBordero);
			this.m_gbImpressao.Controls.Add(this.m_lSaque);
			this.m_gbImpressao.Controls.Add(this.m_lOrdemEmbarque);
			this.m_gbImpressao.Controls.Add(this.m_lFaturaComercial);
			this.m_gbImpressao.Controls.Add(this.m_lCertificadoOrigem);
			this.m_gbImpressao.Controls.Add(this.m_lRomaneio);
			this.m_gbImpressao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbImpressao.Location = new System.Drawing.Point(8, 85);
			this.m_gbImpressao.Name = "m_gbImpressao";
			this.m_gbImpressao.Size = new System.Drawing.Size(280, 510);
			this.m_gbImpressao.TabIndex = 169;
			this.m_gbImpressao.TabStop = false;
			this.m_gbImpressao.Text = "Processo de Exportação";
			// 
			// m_btImpressaoGuiaEntrada
			// 
			this.m_btImpressaoGuiaEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImpressaoGuiaEntrada.Image = ((System.Drawing.Image)(resources.GetObject("m_btImpressaoGuiaEntrada.Image")));
			this.m_btImpressaoGuiaEntrada.Location = new System.Drawing.Point(36, 256);
			this.m_btImpressaoGuiaEntrada.Name = "m_btImpressaoGuiaEntrada";
			this.m_btImpressaoGuiaEntrada.Size = new System.Drawing.Size(25, 25);
			this.m_btImpressaoGuiaEntrada.TabIndex = 183;
			this.m_btImpressaoGuiaEntrada.Click += new System.EventHandler(this.m_btImpressaoGuiaEntrada_Click);
			// 
			// m_lbImpressaoGuiaEntrada
			// 
			this.m_lbImpressaoGuiaEntrada.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbImpressaoGuiaEntrada.Location = new System.Drawing.Point(64, 264);
			this.m_lbImpressaoGuiaEntrada.Name = "m_lbImpressaoGuiaEntrada";
			this.m_lbImpressaoGuiaEntrada.Size = new System.Drawing.Size(138, 16);
			this.m_lbImpressaoGuiaEntrada.TabIndex = 182;
			this.m_lbImpressaoGuiaEntrada.Text = "Guia de Entrada";
			// 
			// m_btImpressaoReserva
			// 
			this.m_btImpressaoReserva.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImpressaoReserva.Image = ((System.Drawing.Image)(resources.GetObject("m_btImpressaoReserva.Image")));
			this.m_btImpressaoReserva.Location = new System.Drawing.Point(36, 192);
			this.m_btImpressaoReserva.Name = "m_btImpressaoReserva";
			this.m_btImpressaoReserva.Size = new System.Drawing.Size(25, 25);
			this.m_btImpressaoReserva.TabIndex = 181;
			this.m_btImpressaoReserva.Click += new System.EventHandler(this.m_btImpressaoReserva_Click);
			// 
			// m_lbImpressaoReserva
			// 
			this.m_lbImpressaoReserva.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbImpressaoReserva.Location = new System.Drawing.Point(64, 200);
			this.m_lbImpressaoReserva.Name = "m_lbImpressaoReserva";
			this.m_lbImpressaoReserva.Size = new System.Drawing.Size(138, 16);
			this.m_lbImpressaoReserva.TabIndex = 180;
			this.m_lbImpressaoReserva.Text = "Reserva";
			// 
			// m_btImpressaoBordero
			// 
			this.m_btImpressaoBordero.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImpressaoBordero.Image = ((System.Drawing.Image)(resources.GetObject("m_btImpressaoBordero.Image")));
			this.m_btImpressaoBordero.Location = new System.Drawing.Point(36, 360);
			this.m_btImpressaoBordero.Name = "m_btImpressaoBordero";
			this.m_btImpressaoBordero.Size = new System.Drawing.Size(25, 25);
			this.m_btImpressaoBordero.TabIndex = 179;
			this.m_btImpressaoBordero.Click += new System.EventHandler(this.m_btImpressaoBordero_Click);
			// 
			// m_btImpressaoSaque
			// 
			this.m_btImpressaoSaque.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImpressaoSaque.Image = ((System.Drawing.Image)(resources.GetObject("m_btImpressaoSaque.Image")));
			this.m_btImpressaoSaque.Location = new System.Drawing.Point(36, 320);
			this.m_btImpressaoSaque.Name = "m_btImpressaoSaque";
			this.m_btImpressaoSaque.Size = new System.Drawing.Size(25, 25);
			this.m_btImpressaoSaque.TabIndex = 178;
			this.m_btImpressaoSaque.Click += new System.EventHandler(this.m_btImpressaoSaque_Click);
			// 
			// m_btImpressaoRomaneio
			// 
			this.m_btImpressaoRomaneio.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImpressaoRomaneio.Image = ((System.Drawing.Image)(resources.GetObject("m_btImpressaoRomaneio.Image")));
			this.m_btImpressaoRomaneio.Location = new System.Drawing.Point(36, 288);
			this.m_btImpressaoRomaneio.Name = "m_btImpressaoRomaneio";
			this.m_btImpressaoRomaneio.Size = new System.Drawing.Size(25, 25);
			this.m_btImpressaoRomaneio.TabIndex = 177;
			this.m_btImpressaoRomaneio.Click += new System.EventHandler(this.m_btImpressaoRomaneio_Click);
			// 
			// m_btImpressaoOrdemEmbarque
			// 
			this.m_btImpressaoOrdemEmbarque.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImpressaoOrdemEmbarque.Image = ((System.Drawing.Image)(resources.GetObject("m_btImpressaoOrdemEmbarque.Image")));
			this.m_btImpressaoOrdemEmbarque.Location = new System.Drawing.Point(36, 224);
			this.m_btImpressaoOrdemEmbarque.Name = "m_btImpressaoOrdemEmbarque";
			this.m_btImpressaoOrdemEmbarque.Size = new System.Drawing.Size(25, 25);
			this.m_btImpressaoOrdemEmbarque.TabIndex = 176;
			this.m_btImpressaoOrdemEmbarque.Click += new System.EventHandler(this.m_btImpressaoOrdemEmbarque_Click);
			// 
			// m_btImpressaoCertificadoOrigem
			// 
			this.m_btImpressaoCertificadoOrigem.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImpressaoCertificadoOrigem.Image = ((System.Drawing.Image)(resources.GetObject("m_btImpressaoCertificadoOrigem.Image")));
			this.m_btImpressaoCertificadoOrigem.Location = new System.Drawing.Point(36, 160);
			this.m_btImpressaoCertificadoOrigem.Name = "m_btImpressaoCertificadoOrigem";
			this.m_btImpressaoCertificadoOrigem.Size = new System.Drawing.Size(25, 25);
			this.m_btImpressaoCertificadoOrigem.TabIndex = 175;
			this.m_btImpressaoCertificadoOrigem.Click += new System.EventHandler(this.m_btImpressaoCertificadoOrigem_Click);
			// 
			// m_btImpressaoFaturaComercial
			// 
			this.m_btImpressaoFaturaComercial.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImpressaoFaturaComercial.Image = ((System.Drawing.Image)(resources.GetObject("m_btImpressaoFaturaComercial.Image")));
			this.m_btImpressaoFaturaComercial.Location = new System.Drawing.Point(36, 128);
			this.m_btImpressaoFaturaComercial.Name = "m_btImpressaoFaturaComercial";
			this.m_btImpressaoFaturaComercial.Size = new System.Drawing.Size(25, 25);
			this.m_btImpressaoFaturaComercial.TabIndex = 174;
			this.m_btImpressaoFaturaComercial.Click += new System.EventHandler(this.m_btImpressaoFaturaComercial_Click);
			// 
			// m_btImpressaoFaturaProforma
			// 
			this.m_btImpressaoFaturaProforma.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImpressaoFaturaProforma.Image = ((System.Drawing.Image)(resources.GetObject("m_btImpressaoFaturaProforma.Image")));
			this.m_btImpressaoFaturaProforma.Location = new System.Drawing.Point(36, 96);
			this.m_btImpressaoFaturaProforma.Name = "m_btImpressaoFaturaProforma";
			this.m_btImpressaoFaturaProforma.Size = new System.Drawing.Size(25, 25);
			this.m_btImpressaoFaturaProforma.TabIndex = 173;
			this.m_btImpressaoFaturaProforma.Click += new System.EventHandler(this.m_btImpressaoFaturaProforma_Click);
			// 
			// m_btImpressaoSumario
			// 
			this.m_btImpressaoSumario.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImpressaoSumario.Image = ((System.Drawing.Image)(resources.GetObject("m_btImpressaoSumario.Image")));
			this.m_btImpressaoSumario.Location = new System.Drawing.Point(36, 56);
			this.m_btImpressaoSumario.Name = "m_btImpressaoSumario";
			this.m_btImpressaoSumario.Size = new System.Drawing.Size(25, 25);
			this.m_btImpressaoSumario.TabIndex = 172;
			this.m_btImpressaoSumario.Click += new System.EventHandler(this.m_btImpressaoSumario_Click);
			// 
			// m_btImpressaoPE
			// 
			this.m_btImpressaoPE.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImpressaoPE.Image = ((System.Drawing.Image)(resources.GetObject("m_btImpressaoPE.Image")));
			this.m_btImpressaoPE.Location = new System.Drawing.Point(36, 24);
			this.m_btImpressaoPE.Name = "m_btImpressaoPE";
			this.m_btImpressaoPE.Size = new System.Drawing.Size(25, 25);
			this.m_btImpressaoPE.TabIndex = 171;
			this.m_btImpressaoPE.Click += new System.EventHandler(this.m_btImpressaoPE_Click);
			// 
			// m_lbSumario
			// 
			this.m_lbSumario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSumario.Location = new System.Drawing.Point(64, 64);
			this.m_lbSumario.Name = "m_lbSumario";
			this.m_lbSumario.Size = new System.Drawing.Size(153, 16);
			this.m_lbSumario.TabIndex = 169;
			this.m_lbSumario.Text = "Sumario";
			// 
			// m_lPE
			// 
			this.m_lPE.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPE.Location = new System.Drawing.Point(67, 32);
			this.m_lPE.Name = "m_lPE";
			this.m_lPE.Size = new System.Drawing.Size(192, 16);
			this.m_lPE.TabIndex = 166;
			this.m_lPE.Text = "Processo de Exportação (PE)";
			// 
			// m_lFaturaProforma
			// 
			this.m_lFaturaProforma.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFaturaProforma.Location = new System.Drawing.Point(64, 96);
			this.m_lFaturaProforma.Name = "m_lFaturaProforma";
			this.m_lFaturaProforma.Size = new System.Drawing.Size(153, 16);
			this.m_lFaturaProforma.TabIndex = 123;
			this.m_lFaturaProforma.Text = "Fatura Proforma";
			// 
			// m_lBordero
			// 
			this.m_lBordero.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lBordero.Location = new System.Drawing.Point(64, 360);
			this.m_lBordero.Name = "m_lBordero";
			this.m_lBordero.Size = new System.Drawing.Size(144, 16);
			this.m_lBordero.TabIndex = 137;
			this.m_lBordero.Text = "Bordero";
			// 
			// m_lSaque
			// 
			this.m_lSaque.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSaque.Location = new System.Drawing.Point(64, 328);
			this.m_lSaque.Name = "m_lSaque";
			this.m_lSaque.Size = new System.Drawing.Size(144, 16);
			this.m_lSaque.TabIndex = 130;
			this.m_lSaque.Text = "Saque";
			// 
			// m_lOrdemEmbarque
			// 
			this.m_lOrdemEmbarque.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lOrdemEmbarque.Location = new System.Drawing.Point(64, 232);
			this.m_lOrdemEmbarque.Name = "m_lOrdemEmbarque";
			this.m_lOrdemEmbarque.Size = new System.Drawing.Size(138, 16);
			this.m_lOrdemEmbarque.TabIndex = 126;
			this.m_lOrdemEmbarque.Text = "Ordem de Embarque";
			// 
			// m_lFaturaComercial
			// 
			this.m_lFaturaComercial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFaturaComercial.Location = new System.Drawing.Point(64, 128);
			this.m_lFaturaComercial.Name = "m_lFaturaComercial";
			this.m_lFaturaComercial.Size = new System.Drawing.Size(145, 16);
			this.m_lFaturaComercial.TabIndex = 124;
			this.m_lFaturaComercial.Text = "Fatura Comercial";
			// 
			// m_lCertificadoOrigem
			// 
			this.m_lCertificadoOrigem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCertificadoOrigem.Location = new System.Drawing.Point(64, 168);
			this.m_lCertificadoOrigem.Name = "m_lCertificadoOrigem";
			this.m_lCertificadoOrigem.Size = new System.Drawing.Size(160, 16);
			this.m_lCertificadoOrigem.TabIndex = 125;
			this.m_lCertificadoOrigem.Text = "Certificado de Origem";
			// 
			// m_lRomaneio
			// 
			this.m_lRomaneio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lRomaneio.Location = new System.Drawing.Point(64, 296);
			this.m_lRomaneio.Name = "m_lRomaneio";
			this.m_lRomaneio.Size = new System.Drawing.Size(145, 16);
			this.m_lRomaneio.TabIndex = 129;
			this.m_lRomaneio.Text = "Romaneio";
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(3, 12);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 109;
			this.m_ttStatus.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_ttStatus
			// 
			this.m_ttStatus.AutomaticDelay = 100;
			this.m_ttStatus.AutoPopDelay = 5000;
			this.m_ttStatus.InitialDelay = 100;
			this.m_ttStatus.ReshowDelay = 20;
			// 
			// m_tmPEInfo
			// 
			this.m_tmPEInfo.Enabled = true;
			this.m_tmPEInfo.Interval = 500;
			this.m_tmPEInfo.Tick += new System.EventHandler(this.m_tmPEInfo_Tick);
			// 
			// frmFPEInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.ControlBox = false;
			this.Controls.Add(this.m_gbFrame);
			this.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFPEInfo";
			this.ShowInTaskbar = false;
			this.Text = "frmFPEInfo";
			this.Load += new System.EventHandler(this.frmFPEInfo_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbBanner.ResumeLayout(false);
			this.m_gbImpressao.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
		#region Load
		private void frmFPEInfo_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.mostraCor();
				this.SetBounds(this.MdiParent.Bounds.X,this.MdiParent.Bounds.Y,this.MdiParent.Bounds.Width - 13,this.MdiParent.Bounds.Height - 40);
				m_tmPEInfo.Start();
				vResizeImage();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Impressões
		#region Bordero
		private void m_pbImpressaoBR_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			this.Refresh();
			OnCallImprimeBordero();
			this.Refresh();
			OnCallSetaToolTip();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#endregion
		#region Tick
		private void m_tmPEInfo_Tick(object sender, System.EventArgs e)
		{
			m_tmPEInfo.Stop();
			fechaBalao();
			mostraBalao(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlPEInfo_frmFPEInfo_Imprimir.ToString()).Replace("TAG",System.Environment.NewLine), (System.Windows.Forms.Control)m_gbFrame);
		}
		#endregion
		#region Botoes
			private void m_btTrocarCor_Click(object sender, System.EventArgs e)
			{
				this.trocaCor();
			}

			private void m_btImpressaoPE_Click(object sender, System.EventArgs e)
			{
				vImprimePe();
			}

			private void m_btImpressaoSumario_Click(object sender, System.EventArgs e)
			{
				vImprimeSumario();
			}

			private void m_btImpressaoFaturaProforma_Click(object sender, System.EventArgs e)
			{
				vImprimeFaturaProforma();
			}

			private void m_btImpressaoFaturaComercial_Click(object sender, System.EventArgs e)
			{
				vImprimeFaturaComercial();
			}

			private void m_btImpressaoCertificadoOrigem_Click(object sender, System.EventArgs e)
			{
				vImprimeCertificadosOrigem();
			}

			private void m_btImpressaoOrdemEmbarque_Click(object sender, System.EventArgs e)
			{
				vImprimeOrdemEmbarque();
			}

			private void m_btImpressaoRomaneio_Click(object sender, System.EventArgs e)
			{
				vImprimeRomaneio();
			
			}

			private void m_btImpressaoSaque_Click(object sender, System.EventArgs e)
			{
				vImprimeSaque();
			}

			private void m_btImpressaoBordero_Click(object sender, System.EventArgs e)
			{
				vImprimeBordero();
			}

			private void m_btImpressaoReserva_Click(object sender, System.EventArgs e)
			{
				vImprimeReserva();
			
			}

			private void m_btImpressaoGuiaEntrada_Click(object sender, System.EventArgs e)
			{
				vImprimeGuiaEntrada();
			}
		#endregion
		#endregion

		#region	Cor
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
					if ((this.Controls[cont].GetType().ToString() != "mdlComponentes.compTextBox") &&
						(this.Controls[cont].GetType().ToString() != "mdlComponentes.compTextNumber") &&
						(this.Controls[cont].GetType().ToString() != "mdlComponentesGraficos.ListView"))
					{
						this.Controls[cont].BackColor = this.BackColor;
					}
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") &&
							(this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber") &&
							(this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentesGraficos.ListView"))
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
		#region Get & Set
		public void setHabilitacaoBotoes(bool bHabilitaFP, bool bHabilitaCO,bool bHabilitaReserva,bool bHabilitaOE,bool bHabilitaGuiaEntrada, bool bHabilitaRM, bool bHabilitaSQ, bool bHabilitaBD)
		{
			m_btImpressaoFaturaProforma.Enabled = m_lFaturaProforma.Enabled = bHabilitaFP;
			m_btImpressaoCertificadoOrigem.Enabled = m_lCertificadoOrigem.Enabled = bHabilitaCO;
			m_btImpressaoReserva.Enabled = m_lbImpressaoReserva.Enabled = bHabilitaReserva;
			m_btImpressaoOrdemEmbarque.Enabled = m_lOrdemEmbarque.Enabled = bHabilitaOE;
			m_btImpressaoGuiaEntrada.Enabled = m_lbImpressaoGuiaEntrada.Enabled = bHabilitaGuiaEntrada;
			m_btImpressaoRomaneio.Enabled = m_lRomaneio.Enabled = bHabilitaRM;
			m_btImpressaoSaque.Enabled = m_lSaque.Enabled = bHabilitaSQ;
			m_btImpressaoBordero.Enabled = m_lBordero.Enabled = bHabilitaBD;
		}
		public void setToolTipProforma(string strToolTip)
		{
			this.m_ttStatus.SetToolTip(m_btImpressaoFaturaProforma, strToolTip);
		}
		public void setToolTipComercial(string strToolTip)
		{
			this.m_ttStatus.SetToolTip(m_btImpressaoFaturaComercial, strToolTip);
		}
		public void setToolTipCertificadosOrigem(string strToolTip)
		{
			this.m_ttStatus.SetToolTip(m_btImpressaoCertificadoOrigem, strToolTip);
		}
		public void setToolTipOrdemEmbarque(string strToolTip)
		{
			this.m_ttStatus.SetToolTip(m_btImpressaoOrdemEmbarque, strToolTip);
		}
		public void setToolTipRomaneio(string strToolTip)
		{
			this.m_ttStatus.SetToolTip(m_btImpressaoRomaneio, strToolTip);
		}
		public void setToolTipSaque(string strToolTip)
		{
			this.m_ttStatus.SetToolTip(m_btImpressaoSaque, strToolTip);
		}
		public void setToolTipBordero(string strToolTip)
		{
			this.m_ttStatus.SetToolTip(m_btImpressaoBordero, strToolTip);
		}
		#endregion
		#region Impressao
			private void vImprimePe()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				OnCallImprimeTodos();
				this.Refresh();
				OnCallSetaToolTip();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void vImprimeFaturaProforma()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				OnCallImprimeFaturaProforma();
				this.Refresh();
				OnCallSetaToolTip();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void vImprimeFaturaComercial()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				OnCallImprimeFaturaComercial();
				this.Refresh();
				OnCallSetaToolTip();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void vImprimeCertificadosOrigem()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				OnCallImprimeCertificadosOrigem();
				this.Refresh();
				OnCallSetaToolTip();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void vImprimeRomaneio()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				OnCallImprimeRomaneio();
				this.Refresh();
				OnCallSetaToolTip();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void vImprimeSaque()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				OnCallImprimeSaque();
				this.Refresh();
				OnCallSetaToolTip();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void vImprimeReserva()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				OnCallImprimeReserva();
				this.Refresh();
				OnCallSetaToolTip();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void vImprimeOrdemEmbarque()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				OnCallImprimeInstrucoesEmbarque();
				this.Refresh();
				OnCallSetaToolTip();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void vImprimeGuiaEntrada()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				OnCallImprimeGuiaEntrada();
				this.Refresh();
				OnCallSetaToolTip();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void vImprimeBordero()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				OnCallImprimeBordero();
				this.Refresh();
				OnCallSetaToolTip();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void vImprimeSumario()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				OnCallImprimeSumario();
				this.Refresh();
				OnCallSetaToolTip();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion

		#region Métodos Show Balão
		public void fechaBalao()
		{
			try
			{
				if (m_mgblBalaoToolTip != null)
					m_mgblBalaoToolTip.Close();
			}
			catch
			{
			}
		}
		public void mostraBalao(string strMensagem, System.Windows.Forms.Control ctrlBalao)
		{
			try
			{
				if (m_mgblBalaoToolTip != null)
					m_mgblBalaoToolTip.Close();
				if (m_bMostrarBaloes)
				{
					m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
					m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
					m_mgblBalaoToolTip.Content = strMensagem;
					m_mgblBalaoToolTip.Icon = System.Drawing.SystemIcons.Information;
					m_mgblBalaoToolTip.CloseOnMouseClick = true;
					m_mgblBalaoToolTip.CloseOnDeactivate = false;
					m_mgblBalaoToolTip.CloseOnKeyPress = false;
					m_mgblBalaoToolTip.ShowBalloon((System.Windows.Forms.Control)ctrlBalao);
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Resize Image
			private void vResizeImage()
			{
				// Height
				m_picBanner.Top = (m_gbBanner.Height / 2) - (m_picBanner.Height / 2);

				// Width
				m_picBanner.Left = (m_gbBanner.Width / 2) - (m_picBanner.Width / 2);


			}
		#endregion
	}
}

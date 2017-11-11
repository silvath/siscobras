using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace executavel
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		#region MAIN
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		#endregion

		#region Atributos
		mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
		mdlTratamentoErro.clsTratamentoErro	m_cls_tre_tratadorErro = new mdlTratamentoErro.clsTratamentoErro();
		private System.Windows.Forms.GroupBox m_gbGeral;
		private System.Windows.Forms.GroupBox m_gbParametros;
		private System.Windows.Forms.GroupBox m_gbRetorno;
		private System.Windows.Forms.TextBox m_txtRetorno;
		private System.Windows.Forms.Label m_lbRetorno;
		private System.Windows.Forms.GroupBox m_gbMoeda;
		private System.Windows.Forms.Button m_btCotacao;
		private System.Windows.Forms.GroupBox m_gbBD;
		private System.Windows.Forms.GroupBox m_gbConfiguracao;
		private System.Windows.Forms.TextBox m_txtPath;
		private System.Windows.Forms.Label m_lbPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_txtDataBaseName;
		private System.Windows.Forms.GroupBox m_gbTipoAcesso;
		private System.Windows.Forms.RadioButton m_rbMySql;
		private System.Windows.Forms.RadioButton m_rbJet40;
		private System.Windows.Forms.GroupBox m_gbLogin;
		private System.Windows.Forms.TextBox m_txtPassword;
		private System.Windows.Forms.TextBox m_txtUser;
		private System.Windows.Forms.Label m_lbPassword;
		private System.Windows.Forms.Label m_lbUser;
		private System.Windows.Forms.TextBox m_txtHost;
		private System.Windows.Forms.Label m_lbHost;
		private System.Windows.Forms.Label m_lIdExportador;
		private mdlComponentesGraficos.TextBox m_tbIdExportador;
		public System.Windows.Forms.ImageList m_ilBandeiras;
		private System.Windows.Forms.Button m_btComercial;
		private System.Windows.Forms.Button m_btBordero;
		private System.Windows.Forms.Label label2;
		private mdlComponentesGraficos.TextBox m_txtIdPe;
		private System.Windows.Forms.Button m_btInstrucoesEmbarque;
		private System.Windows.Forms.Button m_btCtExistente;
		private System.Windows.Forms.RadioButton m_rbSqlServer;
		private System.Windows.Forms.TextBox m_txtPortSqlServer;
		private System.Windows.Forms.Label m_lbPortSqlServer;
		private System.Windows.Forms.Button m_btRomaneio;
		private mdlComponentesGraficos.TextBox m_txtIdPeDestino;
		private System.Windows.Forms.Label m_lbPeDestino;
		private System.Windows.Forms.Button m_btCopiaPe;
		private System.Windows.Forms.Button m_btCopiaPeCotacao;
		private System.Windows.Forms.GroupBox m_gbAssistente;
		private System.Windows.Forms.Button m_btAssistenteReserva;
		private System.Windows.Forms.Button m_btAssistenteOrdemEmbarque;
		private System.Windows.Forms.Button m_btAssistenteGuiaEntrada;
		private System.Windows.Forms.TextBox m_txtPortMysql;
		private System.Windows.Forms.Label m_lbPortMysql;
		private System.Windows.Forms.Button m_btAssistenteSaque;
		private System.Windows.Forms.Button m_btAssistenteCOMercosul;
		private System.Windows.Forms.Button m_btAssistenteBordero;
		private System.Windows.Forms.Button m_btAssistenteFaturaComercial;
		private System.Windows.Forms.Button m_btAssistenteFaturaCotacao;
		private System.Windows.Forms.Button m_btRomaneioProdutos;
		private System.ComponentModel.IContainer components = null;
		#endregion
		#region Constructor e Destructor
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbAssistente = new System.Windows.Forms.GroupBox();
			this.m_btAssistenteFaturaCotacao = new System.Windows.Forms.Button();
			this.m_btAssistenteFaturaComercial = new System.Windows.Forms.Button();
			this.m_btAssistenteBordero = new System.Windows.Forms.Button();
			this.m_btAssistenteCOMercosul = new System.Windows.Forms.Button();
			this.m_btAssistenteSaque = new System.Windows.Forms.Button();
			this.m_btAssistenteGuiaEntrada = new System.Windows.Forms.Button();
			this.m_btAssistenteOrdemEmbarque = new System.Windows.Forms.Button();
			this.m_btAssistenteReserva = new System.Windows.Forms.Button();
			this.m_gbParametros = new System.Windows.Forms.GroupBox();
			this.m_txtIdPeDestino = new mdlComponentesGraficos.TextBox();
			this.m_lbPeDestino = new System.Windows.Forms.Label();
			this.m_txtIdPe = new mdlComponentesGraficos.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_tbIdExportador = new mdlComponentesGraficos.TextBox();
			this.m_lIdExportador = new System.Windows.Forms.Label();
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_lbRetorno = new System.Windows.Forms.Label();
			this.m_gbMoeda = new System.Windows.Forms.GroupBox();
			this.m_btCopiaPeCotacao = new System.Windows.Forms.Button();
			this.m_btCopiaPe = new System.Windows.Forms.Button();
			this.m_btRomaneio = new System.Windows.Forms.Button();
			this.m_btCtExistente = new System.Windows.Forms.Button();
			this.m_btInstrucoesEmbarque = new System.Windows.Forms.Button();
			this.m_btBordero = new System.Windows.Forms.Button();
			this.m_btComercial = new System.Windows.Forms.Button();
			this.m_btCotacao = new System.Windows.Forms.Button();
			this.m_gbBD = new System.Windows.Forms.GroupBox();
			this.m_gbConfiguracao = new System.Windows.Forms.GroupBox();
			this.m_txtPath = new System.Windows.Forms.TextBox();
			this.m_lbPath = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtDataBaseName = new System.Windows.Forms.TextBox();
			this.m_gbTipoAcesso = new System.Windows.Forms.GroupBox();
			this.m_txtPortMysql = new System.Windows.Forms.TextBox();
			this.m_lbPortMysql = new System.Windows.Forms.Label();
			this.m_txtPortSqlServer = new System.Windows.Forms.TextBox();
			this.m_lbPortSqlServer = new System.Windows.Forms.Label();
			this.m_rbSqlServer = new System.Windows.Forms.RadioButton();
			this.m_rbMySql = new System.Windows.Forms.RadioButton();
			this.m_rbJet40 = new System.Windows.Forms.RadioButton();
			this.m_gbLogin = new System.Windows.Forms.GroupBox();
			this.m_txtHost = new System.Windows.Forms.TextBox();
			this.m_lbHost = new System.Windows.Forms.Label();
			this.m_txtPassword = new System.Windows.Forms.TextBox();
			this.m_txtUser = new System.Windows.Forms.TextBox();
			this.m_lbPassword = new System.Windows.Forms.Label();
			this.m_lbUser = new System.Windows.Forms.Label();
			this.m_ilBandeiras = new System.Windows.Forms.ImageList(this.components);
			this.m_btRomaneioProdutos = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbAssistente.SuspendLayout();
			this.m_gbParametros.SuspendLayout();
			this.m_gbRetorno.SuspendLayout();
			this.m_gbMoeda.SuspendLayout();
			this.m_gbBD.SuspendLayout();
			this.m_gbConfiguracao.SuspendLayout();
			this.m_gbTipoAcesso.SuspendLayout();
			this.m_gbLogin.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbAssistente);
			this.m_gbGeral.Controls.Add(this.m_gbParametros);
			this.m_gbGeral.Controls.Add(this.m_gbRetorno);
			this.m_gbGeral.Controls.Add(this.m_gbMoeda);
			this.m_gbGeral.Controls.Add(this.m_gbBD);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(615, 657);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbAssistente
			// 
			this.m_gbAssistente.Controls.Add(this.m_btRomaneioProdutos);
			this.m_gbAssistente.Controls.Add(this.m_btAssistenteFaturaCotacao);
			this.m_gbAssistente.Controls.Add(this.m_btAssistenteFaturaComercial);
			this.m_gbAssistente.Controls.Add(this.m_btAssistenteBordero);
			this.m_gbAssistente.Controls.Add(this.m_btAssistenteCOMercosul);
			this.m_gbAssistente.Controls.Add(this.m_btAssistenteSaque);
			this.m_gbAssistente.Controls.Add(this.m_btAssistenteGuiaEntrada);
			this.m_gbAssistente.Controls.Add(this.m_btAssistenteOrdemEmbarque);
			this.m_gbAssistente.Controls.Add(this.m_btAssistenteReserva);
			this.m_gbAssistente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbAssistente.Location = new System.Drawing.Point(8, 432);
			this.m_gbAssistente.Name = "m_gbAssistente";
			this.m_gbAssistente.Size = new System.Drawing.Size(600, 144);
			this.m_gbAssistente.TabIndex = 4;
			this.m_gbAssistente.TabStop = false;
			this.m_gbAssistente.Text = "Assistente";
			// 
			// m_btAssistenteFaturaCotacao
			// 
			this.m_btAssistenteFaturaCotacao.Location = new System.Drawing.Point(8, 80);
			this.m_btAssistenteFaturaCotacao.Name = "m_btAssistenteFaturaCotacao";
			this.m_btAssistenteFaturaCotacao.Size = new System.Drawing.Size(81, 32);
			this.m_btAssistenteFaturaCotacao.TabIndex = 8;
			this.m_btAssistenteFaturaCotacao.Text = "Fatura Cotacao";
			this.m_btAssistenteFaturaCotacao.Click += new System.EventHandler(this.m_btAssistenteFaturaCotacao_Click);
			// 
			// m_btAssistenteFaturaComercial
			// 
			this.m_btAssistenteFaturaComercial.Location = new System.Drawing.Point(89, 80);
			this.m_btAssistenteFaturaComercial.Name = "m_btAssistenteFaturaComercial";
			this.m_btAssistenteFaturaComercial.Size = new System.Drawing.Size(81, 32);
			this.m_btAssistenteFaturaComercial.TabIndex = 7;
			this.m_btAssistenteFaturaComercial.Text = "Fatura Comercial";
			this.m_btAssistenteFaturaComercial.Click += new System.EventHandler(this.m_btAssistenteFaturaComercial_Click);
			// 
			// m_btAssistenteBordero
			// 
			this.m_btAssistenteBordero.Location = new System.Drawing.Point(340, 16);
			this.m_btAssistenteBordero.Name = "m_btAssistenteBordero";
			this.m_btAssistenteBordero.Size = new System.Drawing.Size(81, 32);
			this.m_btAssistenteBordero.TabIndex = 6;
			this.m_btAssistenteBordero.Text = "Bordero";
			this.m_btAssistenteBordero.Click += new System.EventHandler(this.m_btAssistenteBordero_Click);
			// 
			// m_btAssistenteCOMercosul
			// 
			this.m_btAssistenteCOMercosul.Location = new System.Drawing.Point(7, 49);
			this.m_btAssistenteCOMercosul.Name = "m_btAssistenteCOMercosul";
			this.m_btAssistenteCOMercosul.Size = new System.Drawing.Size(81, 32);
			this.m_btAssistenteCOMercosul.TabIndex = 5;
			this.m_btAssistenteCOMercosul.Text = "CO Mercosul";
			this.m_btAssistenteCOMercosul.Click += new System.EventHandler(this.m_btAssistenteCOMercosul_Click);
			// 
			// m_btAssistenteSaque
			// 
			this.m_btAssistenteSaque.Location = new System.Drawing.Point(257, 16);
			this.m_btAssistenteSaque.Name = "m_btAssistenteSaque";
			this.m_btAssistenteSaque.Size = new System.Drawing.Size(80, 32);
			this.m_btAssistenteSaque.TabIndex = 4;
			this.m_btAssistenteSaque.Text = "Saque";
			this.m_btAssistenteSaque.Click += new System.EventHandler(this.m_btAssistenteSaque_Click);
			// 
			// m_btAssistenteGuiaEntrada
			// 
			this.m_btAssistenteGuiaEntrada.Location = new System.Drawing.Point(174, 16);
			this.m_btAssistenteGuiaEntrada.Name = "m_btAssistenteGuiaEntrada";
			this.m_btAssistenteGuiaEntrada.Size = new System.Drawing.Size(80, 32);
			this.m_btAssistenteGuiaEntrada.TabIndex = 3;
			this.m_btAssistenteGuiaEntrada.Text = "Guia Entrada";
			this.m_btAssistenteGuiaEntrada.Click += new System.EventHandler(this.m_btAssistenteGuiaEntrada_Click);
			// 
			// m_btAssistenteOrdemEmbarque
			// 
			this.m_btAssistenteOrdemEmbarque.Location = new System.Drawing.Point(91, 16);
			this.m_btAssistenteOrdemEmbarque.Name = "m_btAssistenteOrdemEmbarque";
			this.m_btAssistenteOrdemEmbarque.Size = new System.Drawing.Size(80, 32);
			this.m_btAssistenteOrdemEmbarque.TabIndex = 2;
			this.m_btAssistenteOrdemEmbarque.Text = "Ord. Embarque";
			this.m_btAssistenteOrdemEmbarque.Click += new System.EventHandler(this.m_btAssistenteOrdemEmbarque_Click);
			// 
			// m_btAssistenteReserva
			// 
			this.m_btAssistenteReserva.Location = new System.Drawing.Point(8, 16);
			this.m_btAssistenteReserva.Name = "m_btAssistenteReserva";
			this.m_btAssistenteReserva.Size = new System.Drawing.Size(80, 32);
			this.m_btAssistenteReserva.TabIndex = 1;
			this.m_btAssistenteReserva.Text = "Reserva";
			this.m_btAssistenteReserva.Click += new System.EventHandler(this.m_btAssistenteReserva_Click);
			// 
			// m_gbParametros
			// 
			this.m_gbParametros.Controls.Add(this.m_txtIdPeDestino);
			this.m_gbParametros.Controls.Add(this.m_lbPeDestino);
			this.m_gbParametros.Controls.Add(this.m_txtIdPe);
			this.m_gbParametros.Controls.Add(this.label2);
			this.m_gbParametros.Controls.Add(this.m_tbIdExportador);
			this.m_gbParametros.Controls.Add(this.m_lIdExportador);
			this.m_gbParametros.Location = new System.Drawing.Point(8, 248);
			this.m_gbParametros.Name = "m_gbParametros";
			this.m_gbParametros.Size = new System.Drawing.Size(600, 80);
			this.m_gbParametros.TabIndex = 3;
			this.m_gbParametros.TabStop = false;
			this.m_gbParametros.Text = "Parametros";
			// 
			// m_txtIdPeDestino
			// 
			this.m_txtIdPeDestino.Location = new System.Drawing.Point(348, 17);
			this.m_txtIdPeDestino.Name = "m_txtIdPeDestino";
			this.m_txtIdPeDestino.Size = new System.Drawing.Size(48, 20);
			this.m_txtIdPeDestino.TabIndex = 5;
			this.m_txtIdPeDestino.Text = "999";
			this.m_txtIdPeDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbPeDestino
			// 
			this.m_lbPeDestino.Location = new System.Drawing.Point(276, 20);
			this.m_lbPeDestino.Name = "m_lbPeDestino";
			this.m_lbPeDestino.Size = new System.Drawing.Size(72, 16);
			this.m_lbPeDestino.TabIndex = 4;
			this.m_lbPeDestino.Text = "IdPEDestino:";
			// 
			// m_txtIdPe
			// 
			this.m_txtIdPe.Location = new System.Drawing.Point(214, 17);
			this.m_txtIdPe.Name = "m_txtIdPe";
			this.m_txtIdPe.Size = new System.Drawing.Size(48, 20);
			this.m_txtIdPe.TabIndex = 3;
			this.m_txtIdPe.Text = "001";
			this.m_txtIdPe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(147, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "IdPEOrigem:";
			// 
			// m_tbIdExportador
			// 
			this.m_tbIdExportador.Location = new System.Drawing.Point(86, 18);
			this.m_tbIdExportador.Name = "m_tbIdExportador";
			this.m_tbIdExportador.Size = new System.Drawing.Size(48, 20);
			this.m_tbIdExportador.TabIndex = 1;
			this.m_tbIdExportador.Text = "1";
			this.m_tbIdExportador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lIdExportador
			// 
			this.m_lIdExportador.Location = new System.Drawing.Point(14, 21);
			this.m_lIdExportador.Name = "m_lIdExportador";
			this.m_lIdExportador.Size = new System.Drawing.Size(72, 16);
			this.m_lIdExportador.TabIndex = 0;
			this.m_lIdExportador.Text = "IdExportador";
			// 
			// m_gbRetorno
			// 
			this.m_gbRetorno.Controls.Add(this.m_txtRetorno);
			this.m_gbRetorno.Controls.Add(this.m_lbRetorno);
			this.m_gbRetorno.Location = new System.Drawing.Point(8, 600);
			this.m_gbRetorno.Name = "m_gbRetorno";
			this.m_gbRetorno.Size = new System.Drawing.Size(600, 48);
			this.m_gbRetorno.TabIndex = 2;
			this.m_gbRetorno.TabStop = false;
			this.m_gbRetorno.Text = "Retorno";
			// 
			// m_txtRetorno
			// 
			this.m_txtRetorno.Location = new System.Drawing.Point(79, 19);
			this.m_txtRetorno.Name = "m_txtRetorno";
			this.m_txtRetorno.Size = new System.Drawing.Size(504, 20);
			this.m_txtRetorno.TabIndex = 5;
			this.m_txtRetorno.Text = "";
			// 
			// m_lbRetorno
			// 
			this.m_lbRetorno.Location = new System.Drawing.Point(24, 24);
			this.m_lbRetorno.Name = "m_lbRetorno";
			this.m_lbRetorno.Size = new System.Drawing.Size(56, 16);
			this.m_lbRetorno.TabIndex = 4;
			this.m_lbRetorno.Text = "Retorno:";
			// 
			// m_gbMoeda
			// 
			this.m_gbMoeda.Controls.Add(this.m_btCopiaPeCotacao);
			this.m_gbMoeda.Controls.Add(this.m_btCopiaPe);
			this.m_gbMoeda.Controls.Add(this.m_btRomaneio);
			this.m_gbMoeda.Controls.Add(this.m_btCtExistente);
			this.m_gbMoeda.Controls.Add(this.m_btInstrucoesEmbarque);
			this.m_gbMoeda.Controls.Add(this.m_btBordero);
			this.m_gbMoeda.Controls.Add(this.m_btComercial);
			this.m_gbMoeda.Controls.Add(this.m_btCotacao);
			this.m_gbMoeda.Location = new System.Drawing.Point(8, 328);
			this.m_gbMoeda.Name = "m_gbMoeda";
			this.m_gbMoeda.Size = new System.Drawing.Size(600, 104);
			this.m_gbMoeda.TabIndex = 1;
			this.m_gbMoeda.TabStop = false;
			this.m_gbMoeda.Text = "Criação Documentos";
			// 
			// m_btCopiaPeCotacao
			// 
			this.m_btCopiaPeCotacao.Location = new System.Drawing.Point(105, 18);
			this.m_btCopiaPeCotacao.Name = "m_btCopiaPeCotacao";
			this.m_btCopiaPeCotacao.Size = new System.Drawing.Size(96, 32);
			this.m_btCopiaPeCotacao.TabIndex = 7;
			this.m_btCopiaPeCotacao.Text = "CopiaPeCot";
			this.m_btCopiaPeCotacao.Click += new System.EventHandler(this.m_btCopiaPeCotacao_Click);
			// 
			// m_btCopiaPe
			// 
			this.m_btCopiaPe.Location = new System.Drawing.Point(8, 18);
			this.m_btCopiaPe.Name = "m_btCopiaPe";
			this.m_btCopiaPe.Size = new System.Drawing.Size(96, 32);
			this.m_btCopiaPe.TabIndex = 6;
			this.m_btCopiaPe.Text = "CopiaPe";
			this.m_btCopiaPe.Click += new System.EventHandler(this.m_btCopiaPe_Click);
			// 
			// m_btRomaneio
			// 
			this.m_btRomaneio.Location = new System.Drawing.Point(498, 64);
			this.m_btRomaneio.Name = "m_btRomaneio";
			this.m_btRomaneio.Size = new System.Drawing.Size(96, 32);
			this.m_btRomaneio.TabIndex = 5;
			this.m_btRomaneio.Text = "Romaneio";
			this.m_btRomaneio.Click += new System.EventHandler(this.m_btRomaneio_Click);
			// 
			// m_btCtExistente
			// 
			this.m_btCtExistente.Location = new System.Drawing.Point(399, 64);
			this.m_btCtExistente.Name = "m_btCtExistente";
			this.m_btCtExistente.Size = new System.Drawing.Size(96, 32);
			this.m_btCtExistente.TabIndex = 4;
			this.m_btCtExistente.Text = "Cotação Existente";
			this.m_btCtExistente.Click += new System.EventHandler(this.m_btCtExistente_Click);
			// 
			// m_btInstrucoesEmbarque
			// 
			this.m_btInstrucoesEmbarque.Location = new System.Drawing.Point(301, 64);
			this.m_btInstrucoesEmbarque.Name = "m_btInstrucoesEmbarque";
			this.m_btInstrucoesEmbarque.Size = new System.Drawing.Size(96, 32);
			this.m_btInstrucoesEmbarque.TabIndex = 3;
			this.m_btInstrucoesEmbarque.Text = "Instruções Embarque";
			this.m_btInstrucoesEmbarque.Click += new System.EventHandler(this.m_btInstrucoesEmbarque_Click);
			// 
			// m_btBordero
			// 
			this.m_btBordero.Location = new System.Drawing.Point(203, 64);
			this.m_btBordero.Name = "m_btBordero";
			this.m_btBordero.Size = new System.Drawing.Size(96, 32);
			this.m_btBordero.TabIndex = 2;
			this.m_btBordero.Text = "Borderô";
			this.m_btBordero.Click += new System.EventHandler(this.m_btBordero_Click);
			// 
			// m_btComercial
			// 
			this.m_btComercial.Location = new System.Drawing.Point(105, 64);
			this.m_btComercial.Name = "m_btComercial";
			this.m_btComercial.Size = new System.Drawing.Size(96, 32);
			this.m_btComercial.TabIndex = 1;
			this.m_btComercial.Text = "Comercial";
			this.m_btComercial.Click += new System.EventHandler(this.m_btComercial_Click);
			// 
			// m_btCotacao
			// 
			this.m_btCotacao.Location = new System.Drawing.Point(8, 64);
			this.m_btCotacao.Name = "m_btCotacao";
			this.m_btCotacao.Size = new System.Drawing.Size(96, 32);
			this.m_btCotacao.TabIndex = 0;
			this.m_btCotacao.Text = "Cotação";
			this.m_btCotacao.Click += new System.EventHandler(this.m_btCotacao_Click);
			// 
			// m_gbBD
			// 
			this.m_gbBD.Controls.Add(this.m_gbConfiguracao);
			this.m_gbBD.Controls.Add(this.m_gbTipoAcesso);
			this.m_gbBD.Controls.Add(this.m_gbLogin);
			this.m_gbBD.Location = new System.Drawing.Point(8, 16);
			this.m_gbBD.Name = "m_gbBD";
			this.m_gbBD.Size = new System.Drawing.Size(600, 232);
			this.m_gbBD.TabIndex = 0;
			this.m_gbBD.TabStop = false;
			this.m_gbBD.Text = "Acesso Banco Dados";
			// 
			// m_gbConfiguracao
			// 
			this.m_gbConfiguracao.Controls.Add(this.m_txtPath);
			this.m_gbConfiguracao.Controls.Add(this.m_lbPath);
			this.m_gbConfiguracao.Controls.Add(this.label1);
			this.m_gbConfiguracao.Controls.Add(this.m_txtDataBaseName);
			this.m_gbConfiguracao.Location = new System.Drawing.Point(8, 16);
			this.m_gbConfiguracao.Name = "m_gbConfiguracao";
			this.m_gbConfiguracao.Size = new System.Drawing.Size(384, 72);
			this.m_gbConfiguracao.TabIndex = 11;
			this.m_gbConfiguracao.TabStop = false;
			this.m_gbConfiguracao.Text = "Configuracao";
			// 
			// m_txtPath
			// 
			this.m_txtPath.Location = new System.Drawing.Point(108, 20);
			this.m_txtPath.Name = "m_txtPath";
			this.m_txtPath.Size = new System.Drawing.Size(264, 20);
			this.m_txtPath.TabIndex = 2;
			this.m_txtPath.Text = "C:\\Projetos\\Siscobras\\Binarios\\";
			// 
			// m_lbPath
			// 
			this.m_lbPath.Location = new System.Drawing.Point(12, 20);
			this.m_lbPath.Name = "m_lbPath";
			this.m_lbPath.Size = new System.Drawing.Size(40, 16);
			this.m_lbPath.TabIndex = 0;
			this.m_lbPath.Text = "Path";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "DataBaseName";
			// 
			// m_txtDataBaseName
			// 
			this.m_txtDataBaseName.Location = new System.Drawing.Point(108, 44);
			this.m_txtDataBaseName.Name = "m_txtDataBaseName";
			this.m_txtDataBaseName.Size = new System.Drawing.Size(264, 20);
			this.m_txtDataBaseName.TabIndex = 3;
			this.m_txtDataBaseName.Text = "Siscobras";
			// 
			// m_gbTipoAcesso
			// 
			this.m_gbTipoAcesso.Controls.Add(this.m_txtPortMysql);
			this.m_gbTipoAcesso.Controls.Add(this.m_lbPortMysql);
			this.m_gbTipoAcesso.Controls.Add(this.m_txtPortSqlServer);
			this.m_gbTipoAcesso.Controls.Add(this.m_lbPortSqlServer);
			this.m_gbTipoAcesso.Controls.Add(this.m_rbSqlServer);
			this.m_gbTipoAcesso.Controls.Add(this.m_rbMySql);
			this.m_gbTipoAcesso.Controls.Add(this.m_rbJet40);
			this.m_gbTipoAcesso.Location = new System.Drawing.Point(7, 94);
			this.m_gbTipoAcesso.Name = "m_gbTipoAcesso";
			this.m_gbTipoAcesso.Size = new System.Drawing.Size(577, 128);
			this.m_gbTipoAcesso.TabIndex = 10;
			this.m_gbTipoAcesso.TabStop = false;
			this.m_gbTipoAcesso.Text = "Tipo Acesso";
			// 
			// m_txtPortMysql
			// 
			this.m_txtPortMysql.Location = new System.Drawing.Point(127, 25);
			this.m_txtPortMysql.Name = "m_txtPortMysql";
			this.m_txtPortMysql.Size = new System.Drawing.Size(40, 20);
			this.m_txtPortMysql.TabIndex = 12;
			this.m_txtPortMysql.Text = "3306";
			// 
			// m_lbPortMysql
			// 
			this.m_lbPortMysql.Location = new System.Drawing.Point(101, 30);
			this.m_lbPortMysql.Name = "m_lbPortMysql";
			this.m_lbPortMysql.Size = new System.Drawing.Size(28, 16);
			this.m_lbPortMysql.TabIndex = 11;
			this.m_lbPortMysql.Text = "Port:";
			// 
			// m_txtPortSqlServer
			// 
			this.m_txtPortSqlServer.Location = new System.Drawing.Point(128, 47);
			this.m_txtPortSqlServer.Name = "m_txtPortSqlServer";
			this.m_txtPortSqlServer.Size = new System.Drawing.Size(40, 20);
			this.m_txtPortSqlServer.TabIndex = 10;
			this.m_txtPortSqlServer.Text = "1433";
			// 
			// m_lbPortSqlServer
			// 
			this.m_lbPortSqlServer.Location = new System.Drawing.Point(100, 50);
			this.m_lbPortSqlServer.Name = "m_lbPortSqlServer";
			this.m_lbPortSqlServer.Size = new System.Drawing.Size(28, 16);
			this.m_lbPortSqlServer.TabIndex = 9;
			this.m_lbPortSqlServer.Text = "Port:";
			// 
			// m_rbSqlServer
			// 
			this.m_rbSqlServer.Checked = true;
			this.m_rbSqlServer.Location = new System.Drawing.Point(24, 49);
			this.m_rbSqlServer.Name = "m_rbSqlServer";
			this.m_rbSqlServer.Size = new System.Drawing.Size(72, 16);
			this.m_rbSqlServer.TabIndex = 6;
			this.m_rbSqlServer.TabStop = true;
			this.m_rbSqlServer.Text = "SqlServer";
			// 
			// m_rbMySql
			// 
			this.m_rbMySql.Location = new System.Drawing.Point(24, 32);
			this.m_rbMySql.Name = "m_rbMySql";
			this.m_rbMySql.Size = new System.Drawing.Size(56, 16);
			this.m_rbMySql.TabIndex = 5;
			this.m_rbMySql.Text = "MySql";
			// 
			// m_rbJet40
			// 
			this.m_rbJet40.Location = new System.Drawing.Point(24, 16);
			this.m_rbJet40.Name = "m_rbJet40";
			this.m_rbJet40.Size = new System.Drawing.Size(200, 16);
			this.m_rbJet40.TabIndex = 4;
			this.m_rbJet40.Text = "Jet40";
			// 
			// m_gbLogin
			// 
			this.m_gbLogin.Controls.Add(this.m_txtHost);
			this.m_gbLogin.Controls.Add(this.m_lbHost);
			this.m_gbLogin.Controls.Add(this.m_txtPassword);
			this.m_gbLogin.Controls.Add(this.m_txtUser);
			this.m_gbLogin.Controls.Add(this.m_lbPassword);
			this.m_gbLogin.Controls.Add(this.m_lbUser);
			this.m_gbLogin.Location = new System.Drawing.Point(396, 8);
			this.m_gbLogin.Name = "m_gbLogin";
			this.m_gbLogin.Size = new System.Drawing.Size(192, 80);
			this.m_gbLogin.TabIndex = 9;
			this.m_gbLogin.TabStop = false;
			this.m_gbLogin.Text = "Login";
			// 
			// m_txtHost
			// 
			this.m_txtHost.Location = new System.Drawing.Point(62, 12);
			this.m_txtHost.Name = "m_txtHost";
			this.m_txtHost.Size = new System.Drawing.Size(122, 20);
			this.m_txtHost.TabIndex = 10;
			this.m_txtHost.Text = "127.0.0.1";
			// 
			// m_lbHost
			// 
			this.m_lbHost.Location = new System.Drawing.Point(7, 20);
			this.m_lbHost.Name = "m_lbHost";
			this.m_lbHost.Size = new System.Drawing.Size(32, 16);
			this.m_lbHost.TabIndex = 9;
			this.m_lbHost.Text = "Host";
			// 
			// m_txtPassword
			// 
			this.m_txtPassword.Location = new System.Drawing.Point(62, 55);
			this.m_txtPassword.Name = "m_txtPassword";
			this.m_txtPassword.Size = new System.Drawing.Size(122, 20);
			this.m_txtPassword.TabIndex = 8;
			this.m_txtPassword.Text = "Siscobras";
			// 
			// m_txtUser
			// 
			this.m_txtUser.Location = new System.Drawing.Point(62, 34);
			this.m_txtUser.Name = "m_txtUser";
			this.m_txtUser.Size = new System.Drawing.Size(122, 20);
			this.m_txtUser.TabIndex = 7;
			this.m_txtUser.Text = "Siscobras";
			// 
			// m_lbPassword
			// 
			this.m_lbPassword.Location = new System.Drawing.Point(7, 57);
			this.m_lbPassword.Name = "m_lbPassword";
			this.m_lbPassword.Size = new System.Drawing.Size(56, 16);
			this.m_lbPassword.TabIndex = 6;
			this.m_lbPassword.Text = "Password";
			// 
			// m_lbUser
			// 
			this.m_lbUser.Location = new System.Drawing.Point(8, 40);
			this.m_lbUser.Name = "m_lbUser";
			this.m_lbUser.Size = new System.Drawing.Size(32, 16);
			this.m_lbUser.TabIndex = 5;
			this.m_lbUser.Text = "User";
			// 
			// m_ilBandeiras
			// 
			this.m_ilBandeiras.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilBandeiras.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBandeiras.ImageStream")));
			this.m_ilBandeiras.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_btRomaneioProdutos
			// 
			this.m_btRomaneioProdutos.Location = new System.Drawing.Point(255, 80);
			this.m_btRomaneioProdutos.Name = "m_btRomaneioProdutos";
			this.m_btRomaneioProdutos.Size = new System.Drawing.Size(81, 32);
			this.m_btRomaneioProdutos.TabIndex = 9;
			this.m_btRomaneioProdutos.Text = "Romaneio Produtos";
			this.m_btRomaneioProdutos.Click += new System.EventHandler(this.m_btRomaneioProdutos_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 661);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Criacao de Documentos";
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbAssistente.ResumeLayout(false);
			this.m_gbParametros.ResumeLayout(false);
			this.m_gbRetorno.ResumeLayout(false);
			this.m_gbMoeda.ResumeLayout(false);
			this.m_gbBD.ResumeLayout(false);
			this.m_gbConfiguracao.ResumeLayout(false);
			this.m_gbTipoAcesso.ResumeLayout(false);
			this.m_gbLogin.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region DataBase
		private void CreateDataBase()
		{
			try
			{
				if (m_rbJet40.Checked)
					m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessOleDbJet40(ref m_cls_tre_tratadorErro,m_txtPath.Text + m_txtDataBaseName.Text + ".mdb",m_txtUser.Text,m_txtPassword.Text);
				if (m_rbMySql.Checked)
					m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtPortMysql.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);
				if (m_rbSqlServer.Checked)
					m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessSqlServer(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtPortSqlServer.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);

				m_cls_dba_ConnectionBD.ShowDialogsErrors = true;
				m_cls_dba_ConnectionBD.SystemMode = mdlDataBaseAccess.Mode.Developer;
			}
			catch
			{
			}
		}
		#endregion

		#region Eventos
			private void m_btCopiaPe_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				CreateDataBase();
				mdlCriacaoDocumentos.PE.clsProcessoExportacaoCopia obj = new mdlCriacaoDocumentos.PE.clsProcessoExportacaoCopia(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD);
				m_txtRetorno.Text = obj.bCopia(Int32.Parse(m_tbIdExportador.Text),m_txtIdPe.Text,m_txtIdPeDestino.Text).ToString();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_btCopiaPeCotacao_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				CreateDataBase();
				mdlCriacaoDocumentos.PE.clsProcessoExportacaoCopia obj = new mdlCriacaoDocumentos.PE.clsProcessoExportacaoCopia(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD);
				m_txtRetorno.Text = obj.bCopiaCotacao(Int32.Parse(m_tbIdExportador.Text),m_txtIdPe.Text,m_txtIdPeDestino.Text).ToString();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_btCotacao_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.clsCriacao teste = new mdlCriacaoDocumentos.Faturas.clsCriacaoCotacao(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD,m_txtPath.Text, Int32.Parse(m_tbIdExportador.Text),ref m_ilBandeiras);
				teste.cadastraDocumento();
			}
			private void m_btComercial_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.clsCriacao teste = new mdlCriacaoDocumentos.Faturas.clsCriacaoProcesso(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD,m_txtPath.Text, Int32.Parse(m_tbIdExportador.Text),ref m_ilBandeiras);
				teste.cadastraDocumento();
				m_txtRetorno.Text = teste.CODIGORETORNO.ToString();
			}
			private void m_btBordero_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.Bordero.clsCriacaoBordero teste = new mdlCriacaoDocumentos.Bordero.clsCriacaoBordero(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD,m_txtPath.Text, Int32.Parse(m_tbIdExportador.Text), m_txtIdPe.Text,ref m_ilBandeiras);
				teste.ShowDialog();
			}
			private void m_btInstrucoesEmbarque_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.InstrucoesEmbarque.clsCriacaoInstrucoesEmbarque teste = new mdlCriacaoDocumentos.InstrucoesEmbarque.clsCriacaoInstrucoesEmbarque(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD,m_txtPath.Text, Int32.Parse(m_tbIdExportador.Text), m_txtIdPe.Text,ref m_ilBandeiras);
				teste.ShowDialog();
			}
			private void m_btCtExistente_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.clsCriacao teste = new mdlCriacaoDocumentos.Faturas.clsCriacaoCotacao(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD,m_txtPath.Text, Int32.Parse(m_tbIdExportador.Text), m_txtIdPe.Text,ref m_ilBandeiras);
				teste.ShowAssistente();
			}

			private void m_btRomaneio_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.Romaneio.clsCriacaoRomaneio teste = new mdlCriacaoDocumentos.Romaneio.clsCriacaoRomaneio(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD,m_txtPath.Text, Int32.Parse(m_tbIdExportador.Text), m_txtIdPe.Text,ref m_ilBandeiras);
				teste.ShowDialogPrincipal();
			}
		#endregion
		#region Assistentes
			private void m_btAssistenteFaturaCotacao_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.Assistentes.clsAssistente obj = new mdlCriacaoDocumentos.Assistentes.clsAssistenteFaturaCotacao(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_tbIdExportador.Text),m_txtIdPe.Text);
				obj.ShowDialog();
			}
			private void m_btAssistenteFaturaComercial_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.Assistentes.clsAssistente obj = new mdlCriacaoDocumentos.Assistentes.clsAssistenteFaturaComercial(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_tbIdExportador.Text),m_txtIdPe.Text);
				obj.ShowDialog();
			}

			private void m_btAssistenteReserva_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.Assistentes.clsAssistente obj = new mdlCriacaoDocumentos.Assistentes.clsAssistenteReserva(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_tbIdExportador.Text),m_txtIdPe.Text);
				obj.ShowDialog();
			}

			private void m_btAssistenteOrdemEmbarque_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.Assistentes.clsAssistente obj = new mdlCriacaoDocumentos.Assistentes.clsAssistenteOrdemEmbarque(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_tbIdExportador.Text),m_txtIdPe.Text);
				obj.ShowDialog();
			}

			private void m_btAssistenteGuiaEntrada_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.Assistentes.clsAssistente obj = new mdlCriacaoDocumentos.Assistentes.clsAssistenteGuiaEntrada(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_tbIdExportador.Text),m_txtIdPe.Text);
				obj.ShowDialog();
			}

			private void m_btAssistenteSaque_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.Assistentes.clsAssistente obj = new mdlCriacaoDocumentos.Assistentes.clsAssistenteSaque(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_tbIdExportador.Text),m_txtIdPe.Text);
				obj.ShowDialog();
			}

			private void m_btAssistenteCOMercosul_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.Assistentes.clsAssistente obj = new mdlCriacaoDocumentos.Assistentes.clsAssistenteCOMercosul(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_tbIdExportador.Text),m_txtIdPe.Text);
				obj.ShowDialog();
			}

			private void m_btAssistenteBordero_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.Assistentes.clsAssistente obj = new mdlCriacaoDocumentos.Assistentes.clsAssistenteBordero(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_tbIdExportador.Text),m_txtIdPe.Text);
				obj.ShowDialog();
			}

			private void m_btRomaneioProdutos_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlCriacaoDocumentos.Assistentes.clsAssistente obj = new mdlCriacaoDocumentos.Assistentes.clsAssistenteRomaneioProdutos(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_tbIdExportador.Text),m_txtIdPe.Text);
				obj.ShowDialog();
			}
		#endregion
	}
}

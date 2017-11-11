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
			private System.Windows.Forms.TextBox m_txtIdCodigo;
			private System.Windows.Forms.TextBox m_txtIdExportador;
			private System.Windows.Forms.Label m_lbIdCodigo;
			private System.Windows.Forms.Label m_lbIdExportador;
			private System.Windows.Forms.GroupBox m_gbRetorno;
			private System.Windows.Forms.TextBox m_txtRetorno;
			private System.Windows.Forms.Label m_lbRetorno;
			private System.Windows.Forms.GroupBox m_gbMoeda;
			private System.Windows.Forms.Button m_btComercial;
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
			private System.Windows.Forms.Button m_btProforma;
		private System.Windows.Forms.RadioButton m_rbSqlServer;
		private System.Windows.Forms.TextBox m_txtPortSqlServer;
		private System.Windows.Forms.Label m_lbPortSqlServer;
		private System.Windows.Forms.Button m_btManipulador;
		private System.Windows.Forms.Button m_btValorEXW;
		private System.Windows.Forms.Button m_btValorFob;
		private System.Windows.Forms.Button m_btValorFatura;
		private System.Windows.Forms.GroupBox m_gbSaque;
		private System.Windows.Forms.Button m_btSaqueCarrega;
		private System.Windows.Forms.Button m_btSaqueSalva;
		private System.Windows.Forms.Label m_lbSaqueValor;
		private System.Windows.Forms.TextBox m_txtSaqueValor;
		private System.Windows.Forms.Button m_btstrValorFatura;
		private System.Windows.Forms.Button m_btSaqueValor;
		private System.Windows.Forms.Button m_btSaqueValorExtenso;
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
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbSaque = new System.Windows.Forms.GroupBox();
			this.m_txtSaqueValor = new System.Windows.Forms.TextBox();
			this.m_lbSaqueValor = new System.Windows.Forms.Label();
			this.m_btSaqueSalva = new System.Windows.Forms.Button();
			this.m_btSaqueCarrega = new System.Windows.Forms.Button();
			this.m_gbParametros = new System.Windows.Forms.GroupBox();
			this.m_txtIdCodigo = new System.Windows.Forms.TextBox();
			this.m_txtIdExportador = new System.Windows.Forms.TextBox();
			this.m_lbIdCodigo = new System.Windows.Forms.Label();
			this.m_lbIdExportador = new System.Windows.Forms.Label();
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_lbRetorno = new System.Windows.Forms.Label();
			this.m_gbMoeda = new System.Windows.Forms.GroupBox();
			this.m_btstrValorFatura = new System.Windows.Forms.Button();
			this.m_btValorFob = new System.Windows.Forms.Button();
			this.m_btValorEXW = new System.Windows.Forms.Button();
			this.m_btManipulador = new System.Windows.Forms.Button();
			this.m_btProforma = new System.Windows.Forms.Button();
			this.m_btComercial = new System.Windows.Forms.Button();
			this.m_btCotacao = new System.Windows.Forms.Button();
			this.m_btValorFatura = new System.Windows.Forms.Button();
			this.m_gbBD = new System.Windows.Forms.GroupBox();
			this.m_gbConfiguracao = new System.Windows.Forms.GroupBox();
			this.m_txtPath = new System.Windows.Forms.TextBox();
			this.m_lbPath = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtDataBaseName = new System.Windows.Forms.TextBox();
			this.m_gbTipoAcesso = new System.Windows.Forms.GroupBox();
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
			this.m_btSaqueValor = new System.Windows.Forms.Button();
			this.m_btSaqueValorExtenso = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbSaque.SuspendLayout();
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
			this.m_gbGeral.Controls.Add(this.m_gbSaque);
			this.m_gbGeral.Controls.Add(this.m_gbParametros);
			this.m_gbGeral.Controls.Add(this.m_gbRetorno);
			this.m_gbGeral.Controls.Add(this.m_gbMoeda);
			this.m_gbGeral.Controls.Add(this.m_gbBD);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(615, 538);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbSaque
			// 
			this.m_gbSaque.Controls.Add(this.m_txtSaqueValor);
			this.m_gbSaque.Controls.Add(this.m_lbSaqueValor);
			this.m_gbSaque.Controls.Add(this.m_btSaqueSalva);
			this.m_gbSaque.Controls.Add(this.m_btSaqueCarrega);
			this.m_gbSaque.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.m_gbSaque.Location = new System.Drawing.Point(352, 249);
			this.m_gbSaque.Name = "m_gbSaque";
			this.m_gbSaque.Size = new System.Drawing.Size(256, 80);
			this.m_gbSaque.TabIndex = 4;
			this.m_gbSaque.TabStop = false;
			this.m_gbSaque.Text = "Saque";
			// 
			// m_txtSaqueValor
			// 
			this.m_txtSaqueValor.Location = new System.Drawing.Point(128, 17);
			this.m_txtSaqueValor.Name = "m_txtSaqueValor";
			this.m_txtSaqueValor.Size = new System.Drawing.Size(120, 20);
			this.m_txtSaqueValor.TabIndex = 10;
			this.m_txtSaqueValor.Text = "0";
			this.m_txtSaqueValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbSaqueValor
			// 
			this.m_lbSaqueValor.Location = new System.Drawing.Point(88, 21);
			this.m_lbSaqueValor.Name = "m_lbSaqueValor";
			this.m_lbSaqueValor.Size = new System.Drawing.Size(41, 16);
			this.m_lbSaqueValor.TabIndex = 9;
			this.m_lbSaqueValor.Text = "Valor:";
			// 
			// m_btSaqueSalva
			// 
			this.m_btSaqueSalva.Location = new System.Drawing.Point(8, 44);
			this.m_btSaqueSalva.Name = "m_btSaqueSalva";
			this.m_btSaqueSalva.Size = new System.Drawing.Size(72, 24);
			this.m_btSaqueSalva.TabIndex = 2;
			this.m_btSaqueSalva.Text = "Salva";
			this.m_btSaqueSalva.Click += new System.EventHandler(this.m_btSaqueSalva_Click);
			// 
			// m_btSaqueCarrega
			// 
			this.m_btSaqueCarrega.Location = new System.Drawing.Point(8, 16);
			this.m_btSaqueCarrega.Name = "m_btSaqueCarrega";
			this.m_btSaqueCarrega.Size = new System.Drawing.Size(72, 24);
			this.m_btSaqueCarrega.TabIndex = 1;
			this.m_btSaqueCarrega.Text = "Carrega";
			this.m_btSaqueCarrega.Click += new System.EventHandler(this.m_btSaqueCarrega_Click);
			// 
			// m_gbParametros
			// 
			this.m_gbParametros.Controls.Add(this.m_txtIdCodigo);
			this.m_gbParametros.Controls.Add(this.m_txtIdExportador);
			this.m_gbParametros.Controls.Add(this.m_lbIdCodigo);
			this.m_gbParametros.Controls.Add(this.m_lbIdExportador);
			this.m_gbParametros.Location = new System.Drawing.Point(8, 248);
			this.m_gbParametros.Name = "m_gbParametros";
			this.m_gbParametros.Size = new System.Drawing.Size(280, 80);
			this.m_gbParametros.TabIndex = 3;
			this.m_gbParametros.TabStop = false;
			this.m_gbParametros.Text = "Parametros";
			// 
			// m_txtIdCodigo
			// 
			this.m_txtIdCodigo.Location = new System.Drawing.Point(108, 47);
			this.m_txtIdCodigo.Name = "m_txtIdCodigo";
			this.m_txtIdCodigo.Size = new System.Drawing.Size(91, 20);
			this.m_txtIdCodigo.TabIndex = 7;
			this.m_txtIdCodigo.Text = "001";
			this.m_txtIdCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_txtIdExportador
			// 
			this.m_txtIdExportador.Location = new System.Drawing.Point(108, 23);
			this.m_txtIdExportador.Name = "m_txtIdExportador";
			this.m_txtIdExportador.Size = new System.Drawing.Size(91, 20);
			this.m_txtIdExportador.TabIndex = 6;
			this.m_txtIdExportador.Text = "1";
			this.m_txtIdExportador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbIdCodigo
			// 
			this.m_lbIdCodigo.Location = new System.Drawing.Point(13, 46);
			this.m_lbIdCodigo.Name = "m_lbIdCodigo";
			this.m_lbIdCodigo.Size = new System.Drawing.Size(88, 16);
			this.m_lbIdCodigo.TabIndex = 5;
			this.m_lbIdCodigo.Text = "idCodigo";
			// 
			// m_lbIdExportador
			// 
			this.m_lbIdExportador.Location = new System.Drawing.Point(14, 27);
			this.m_lbIdExportador.Name = "m_lbIdExportador";
			this.m_lbIdExportador.Size = new System.Drawing.Size(75, 16);
			this.m_lbIdExportador.TabIndex = 4;
			this.m_lbIdExportador.Text = "idExportador";
			// 
			// m_gbRetorno
			// 
			this.m_gbRetorno.Controls.Add(this.m_txtRetorno);
			this.m_gbRetorno.Controls.Add(this.m_lbRetorno);
			this.m_gbRetorno.Location = new System.Drawing.Point(8, 456);
			this.m_gbRetorno.Name = "m_gbRetorno";
			this.m_gbRetorno.Size = new System.Drawing.Size(600, 72);
			this.m_gbRetorno.TabIndex = 2;
			this.m_gbRetorno.TabStop = false;
			this.m_gbRetorno.Text = "Retorno";
			// 
			// m_txtRetorno
			// 
			this.m_txtRetorno.Location = new System.Drawing.Point(76, 15);
			this.m_txtRetorno.Multiline = true;
			this.m_txtRetorno.Name = "m_txtRetorno";
			this.m_txtRetorno.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtRetorno.Size = new System.Drawing.Size(504, 49);
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
			this.m_gbMoeda.Controls.Add(this.m_btSaqueValorExtenso);
			this.m_gbMoeda.Controls.Add(this.m_btSaqueValor);
			this.m_gbMoeda.Controls.Add(this.m_btstrValorFatura);
			this.m_gbMoeda.Controls.Add(this.m_btValorFob);
			this.m_gbMoeda.Controls.Add(this.m_btValorEXW);
			this.m_gbMoeda.Controls.Add(this.m_btManipulador);
			this.m_gbMoeda.Controls.Add(this.m_btProforma);
			this.m_gbMoeda.Controls.Add(this.m_btComercial);
			this.m_gbMoeda.Controls.Add(this.m_btCotacao);
			this.m_gbMoeda.Controls.Add(this.m_btValorFatura);
			this.m_gbMoeda.Location = new System.Drawing.Point(8, 328);
			this.m_gbMoeda.Name = "m_gbMoeda";
			this.m_gbMoeda.Size = new System.Drawing.Size(600, 120);
			this.m_gbMoeda.TabIndex = 1;
			this.m_gbMoeda.TabStop = false;
			this.m_gbMoeda.Text = "Negocio";
			// 
			// m_btstrValorFatura
			// 
			this.m_btstrValorFatura.Location = new System.Drawing.Point(515, 19);
			this.m_btstrValorFatura.Name = "m_btstrValorFatura";
			this.m_btstrValorFatura.Size = new System.Drawing.Size(72, 32);
			this.m_btstrValorFatura.TabIndex = 8;
			this.m_btstrValorFatura.Text = "str Valor Fatura";
			this.m_btstrValorFatura.Click += new System.EventHandler(this.m_btstrValorFatura_Click);
			// 
			// m_btValorFob
			// 
			this.m_btValorFob.Location = new System.Drawing.Point(370, 20);
			this.m_btValorFob.Name = "m_btValorFob";
			this.m_btValorFob.Size = new System.Drawing.Size(72, 32);
			this.m_btValorFob.TabIndex = 6;
			this.m_btValorFob.Text = "Valor FOB";
			this.m_btValorFob.Click += new System.EventHandler(this.m_btValorFob_Click);
			// 
			// m_btValorEXW
			// 
			this.m_btValorEXW.Location = new System.Drawing.Point(295, 20);
			this.m_btValorEXW.Name = "m_btValorEXW";
			this.m_btValorEXW.Size = new System.Drawing.Size(72, 32);
			this.m_btValorEXW.TabIndex = 5;
			this.m_btValorEXW.Text = "Valor EXW";
			this.m_btValorEXW.Click += new System.EventHandler(this.m_btValorEXW_Click);
			// 
			// m_btManipulador
			// 
			this.m_btManipulador.Location = new System.Drawing.Point(221, 20);
			this.m_btManipulador.Name = "m_btManipulador";
			this.m_btManipulador.Size = new System.Drawing.Size(72, 32);
			this.m_btManipulador.TabIndex = 4;
			this.m_btManipulador.Text = "Valor Fatura";
			this.m_btManipulador.Click += new System.EventHandler(this.m_btManipulador_Click);
			// 
			// m_btProforma
			// 
			this.m_btProforma.Location = new System.Drawing.Point(79, 20);
			this.m_btProforma.Name = "m_btProforma";
			this.m_btProforma.Size = new System.Drawing.Size(68, 32);
			this.m_btProforma.TabIndex = 3;
			this.m_btProforma.Text = "Proforma";
			this.m_btProforma.Click += new System.EventHandler(this.m_btProforma_Click);
			// 
			// m_btComercial
			// 
			this.m_btComercial.Location = new System.Drawing.Point(149, 20);
			this.m_btComercial.Name = "m_btComercial";
			this.m_btComercial.Size = new System.Drawing.Size(72, 32);
			this.m_btComercial.TabIndex = 2;
			this.m_btComercial.Text = "Comercial";
			this.m_btComercial.Click += new System.EventHandler(this.m_btComercial_Click);
			// 
			// m_btCotacao
			// 
			this.m_btCotacao.Location = new System.Drawing.Point(5, 20);
			this.m_btCotacao.Name = "m_btCotacao";
			this.m_btCotacao.Size = new System.Drawing.Size(72, 32);
			this.m_btCotacao.TabIndex = 0;
			this.m_btCotacao.Text = "Cotacao";
			this.m_btCotacao.Click += new System.EventHandler(this.m_btCotacao_Click);
			// 
			// m_btValorFatura
			// 
			this.m_btValorFatura.Location = new System.Drawing.Point(442, 20);
			this.m_btValorFatura.Name = "m_btValorFatura";
			this.m_btValorFatura.Size = new System.Drawing.Size(72, 32);
			this.m_btValorFatura.TabIndex = 7;
			this.m_btValorFatura.Text = "Valor Fatura";
			this.m_btValorFatura.Click += new System.EventHandler(this.m_btValorFatura_Click);
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
			// m_txtPortSqlServer
			// 
			this.m_txtPortSqlServer.Location = new System.Drawing.Point(127, 48);
			this.m_txtPortSqlServer.Name = "m_txtPortSqlServer";
			this.m_txtPortSqlServer.Size = new System.Drawing.Size(51, 20);
			this.m_txtPortSqlServer.TabIndex = 10;
			this.m_txtPortSqlServer.Text = "1433";
			// 
			// m_lbPortSqlServer
			// 
			this.m_lbPortSqlServer.Location = new System.Drawing.Point(99, 51);
			this.m_lbPortSqlServer.Name = "m_lbPortSqlServer";
			this.m_lbPortSqlServer.Size = new System.Drawing.Size(37, 16);
			this.m_lbPortSqlServer.TabIndex = 9;
			this.m_lbPortSqlServer.Text = "Port:";
			// 
			// m_rbSqlServer
			// 
			this.m_rbSqlServer.Checked = true;
			this.m_rbSqlServer.Location = new System.Drawing.Point(25, 50);
			this.m_rbSqlServer.Name = "m_rbSqlServer";
			this.m_rbSqlServer.Size = new System.Drawing.Size(79, 16);
			this.m_rbSqlServer.TabIndex = 6;
			this.m_rbSqlServer.TabStop = true;
			this.m_rbSqlServer.Text = "SqlServer";
			// 
			// m_rbMySql
			// 
			this.m_rbMySql.Location = new System.Drawing.Point(24, 32);
			this.m_rbMySql.Name = "m_rbMySql";
			this.m_rbMySql.Size = new System.Drawing.Size(200, 16);
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
			this.m_txtHost.Text = "CRON";
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
			this.m_txtPassword.Text = "siscobras";
			// 
			// m_txtUser
			// 
			this.m_txtUser.Location = new System.Drawing.Point(62, 34);
			this.m_txtUser.Name = "m_txtUser";
			this.m_txtUser.Size = new System.Drawing.Size(122, 20);
			this.m_txtUser.TabIndex = 7;
			this.m_txtUser.Text = "siscobras";
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
			// m_btSaqueValor
			// 
			this.m_btSaqueValor.Location = new System.Drawing.Point(4, 54);
			this.m_btSaqueValor.Name = "m_btSaqueValor";
			this.m_btSaqueValor.Size = new System.Drawing.Size(72, 32);
			this.m_btSaqueValor.TabIndex = 9;
			this.m_btSaqueValor.Text = "Saque - Valor";
			this.m_btSaqueValor.Click += new System.EventHandler(this.m_btSaqueValor_Click);
			// 
			// m_btSaqueValorExtenso
			// 
			this.m_btSaqueValorExtenso.Location = new System.Drawing.Point(78, 54);
			this.m_btSaqueValorExtenso.Name = "m_btSaqueValorExtenso";
			this.m_btSaqueValorExtenso.Size = new System.Drawing.Size(72, 32);
			this.m_btSaqueValorExtenso.TabIndex = 10;
			this.m_btSaqueValorExtenso.Text = "Saque - Valor Extenso";
			this.m_btSaqueValorExtenso.Click += new System.EventHandler(this.m_btSaqueValorExtenso_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 542);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Incoterms";
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbSaque.ResumeLayout(false);
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
			if (m_rbJet40.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessOleDbJet40(ref m_cls_tre_tratadorErro,m_txtPath.Text + m_txtDataBaseName.Text + ".mdb",m_txtUser.Text,m_txtPassword.Text);
//			if (m_rbMySql.Checked)
//				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtUser.Text,m_txtPassword.Text,m_txtDataBaseName.Text);
			if (m_rbSqlServer.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessSqlServer(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtPortSqlServer.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);

			m_cls_dba_ConnectionBD.SystemMode = mdlDataBaseAccess.Mode.Developer;
			m_cls_dba_ConnectionBD.ShowDialogsErrors = true;
		}
		#endregion

		#region Eventos
        	private void m_btCotacao_Click(object sender, System.EventArgs e)
			{
				string strLocal, strMeioTransporte, strTextoOutros;
				double dSubTotal, dDesconto, dSubTotalComDesconto, dFreteInterno, dFreteInternacional, dSeguro, dOutros, dTotal;
				bool bRatear, bRatearDesconto;
				CreateDataBase();
                mdlIncoterm.clsIncoterm modIncoterm = new mdlIncoterm.Faturas.clsIncotermCotacao(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modIncoterm.retornaValores(out strMeioTransporte, out dSubTotal, out dDesconto, out bRatearDesconto, out dSubTotalComDesconto, out dFreteInterno, out dFreteInternacional, out dSeguro, out strTextoOutros, out dOutros, out dTotal, out bRatear, out strLocal);
				this.m_txtRetorno.Text = "Local: " + strLocal;
				modIncoterm.ShowDialog();
				modIncoterm.retornaValores(out strMeioTransporte, out dSubTotal, out dDesconto, out bRatearDesconto, out dSubTotalComDesconto, out dFreteInterno, out dFreteInternacional, out dSeguro, out strTextoOutros, out dOutros, out dTotal, out bRatear, out strLocal);
				this.m_txtRetorno.Text = "Local: " + strLocal;
			}

			private void m_btComercial_Click(object sender, System.EventArgs e)
			{
				string strLocal, strMeioTransporte, strTextoOutros;
				double dSubTotal, dDesconto, dSubTotalComDesconto, dFreteInterno, dFreteInternacional, dSeguro, dOutros, dTotal;
				bool bRatear, bRatearDesconto;
				CreateDataBase();
				mdlIncoterm.clsIncoterm modIncoterm = new mdlIncoterm.Faturas.clsIncotermComercial(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modIncoterm.retornaValores(out strMeioTransporte, out dSubTotal, out dDesconto, out bRatearDesconto, out dSubTotalComDesconto, out dFreteInterno, out dFreteInternacional, out dSeguro, out strTextoOutros, out dOutros, out dTotal, out bRatear, out strLocal);
				this.m_txtRetorno.Text = "Local: " + strLocal;
				modIncoterm.ShowDialog();
				modIncoterm.retornaValores(out strMeioTransporte, out dSubTotal, out dDesconto, out bRatearDesconto, out dSubTotalComDesconto, out dFreteInterno, out dFreteInternacional, out dSeguro, out strTextoOutros, out dOutros, out dTotal, out bRatear, out strLocal);
				this.m_txtRetorno.Text = "Local: " + strLocal;
			}

			private void m_btProforma_Click(object sender, System.EventArgs e)
			{
				string strLocal, strMeioTransporte, strTextoOutros;
				double dSubTotal, dDesconto, dSubTotalComDesconto, dFreteInterno, dFreteInternacional, dSeguro, dOutros, dTotal;
				bool bRatear, bRatearDesconto;
				CreateDataBase();
				mdlIncoterm.clsIncoterm modIncoterm = new mdlIncoterm.Faturas.clsIncotermProforma(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modIncoterm.retornaValores(out strMeioTransporte, out dSubTotal, out dDesconto, out bRatearDesconto, out dSubTotalComDesconto, out dFreteInterno, out dFreteInternacional, out dSeguro, out strTextoOutros, out dOutros, out dTotal, out bRatear, out strLocal);
				this.m_txtRetorno.Text = "Local: " + strLocal;
				modIncoterm.ShowDialog();
				modIncoterm.retornaValores(out strMeioTransporte, out dSubTotal, out dDesconto, out bRatearDesconto, out dSubTotalComDesconto, out dFreteInterno, out dFreteInternacional, out dSeguro, out strTextoOutros, out dOutros, out dTotal, out bRatear, out strLocal);
				this.m_txtRetorno.Text = "Local: " + strLocal;
			}

			private void m_btManipulador_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlIncoterm.clsManipuladorValor cls_obj = new mdlIncoterm.clsManipuladorValor(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				System.Collections.ArrayList arlIdOrdem,arlPrecoUnitario,arlQuantidade;
				cls_obj.vRetornaValores(out arlIdOrdem,out arlPrecoUnitario,out arlQuantidade);
				m_txtRetorno.Text = "";
				for(int i = 0; i < arlIdOrdem.Count;i++)
					m_txtRetorno.Text += arlIdOrdem[i].ToString() + " -> $" + arlPrecoUnitario[i].ToString() + "  qte: " + arlQuantidade[i].ToString() + System.Environment.NewLine;
			}

			private void m_btValorEXW_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlIncoterm.clsManipuladorValor cls_obj = new mdlIncoterm.clsManipuladorValor(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				System.Collections.ArrayList arlIdOrdem,arlPrecoUnitario;
				cls_obj.FaturaOutput = false;
				cls_obj.IncotermRetorno = mdlConstantes.Incoterm.EXW;
				cls_obj.vRetornaValores(out arlIdOrdem,out arlPrecoUnitario);
				m_txtRetorno.Text = "";
				for(int i = 0; i < arlIdOrdem.Count;i++)
					m_txtRetorno.Text += arlIdOrdem[i].ToString() + " -> " + arlPrecoUnitario[i].ToString() + System.Environment.NewLine;
			}

			private void m_btValorFob_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlIncoterm.clsManipuladorValor cls_obj = new mdlIncoterm.clsManipuladorValor(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				System.Collections.ArrayList arlIdOrdem,arlPrecoUnitario;
				cls_obj.FaturaOutput = false;
				cls_obj.IncotermRetorno = mdlConstantes.Incoterm.FOB;
				cls_obj.vRetornaValores(out arlIdOrdem,out arlPrecoUnitario);
				m_txtRetorno.Text = "";
				for(int i = 0; i < arlIdOrdem.Count;i++)
					m_txtRetorno.Text += arlIdOrdem[i].ToString() + " -> " + arlPrecoUnitario[i].ToString() + System.Environment.NewLine;
			}

			private void m_btValorFatura_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlIncoterm.clsManipuladorValor cls_obj = new mdlIncoterm.clsManipuladorValor(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				double dValorFatura;
				cls_obj.vRetornaValores(out dValorFatura);
				m_txtRetorno.Text = dValorFatura.ToString();
			}

			private void m_btstrValorFatura_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlIncoterm.clsManipuladorValor cls_obj = new mdlIncoterm.clsManipuladorValor(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				string strValorFatura;
				cls_obj.vRetornaValores(out strValorFatura);
				m_txtRetorno.Text = strValorFatura;
			}
		#endregion

		#region Saque
		private void m_btSaqueCarrega_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlIncoterm.clsManipuladorValor objMan = new mdlIncoterm.clsManipuladorValor(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
			m_txtSaqueValor.Text = objMan.dCarregaValorSaque().ToString();
		}

		private void m_btSaqueSalva_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlIncoterm.clsManipuladorValor objMan = new mdlIncoterm.clsManipuladorValor(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
			m_txtRetorno.Text = objMan.bSalvaValorSaque(double.Parse(m_txtSaqueValor.Text)).ToString();
		}

		private void m_btSaqueValor_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_btSaqueValorExtenso_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlIncoterm.clsManipuladorValorSaque objMan = new mdlIncoterm.clsManipuladorValorSaque(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
			m_txtRetorno.Text = objMan.bShowDialogValorExtenso().ToString();
		}

		#endregion
	}
}
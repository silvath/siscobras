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
			public System.Windows.Forms.ImageList m_ilBandeiras;
			private System.ComponentModel.IContainer components;

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
			private System.Windows.Forms.TextBox m_txtHost;
			private System.Windows.Forms.Label m_lbHost;
			private System.Windows.Forms.TextBox m_txtPassword;
			private System.Windows.Forms.TextBox m_txtUser;
			private System.Windows.Forms.Label m_lbPassword;
		private System.Windows.Forms.Button m_btProforma;
		private System.Windows.Forms.TextBox m_txtRetornoPar;
		private System.Windows.Forms.Label m_lbRetornoPar;
		private System.Windows.Forms.RadioButton m_rbSqlServer;
		private System.Windows.Forms.TextBox m_txtPortSqlServer;
		private System.Windows.Forms.Label m_lbPortSqlServer;
		private System.Windows.Forms.Button m_btCondicaoPagamentoSaque;
		private System.Windows.Forms.Button m_btCalculos;
		private System.Windows.Forms.Label m_lbRetornoCalculos;
		private System.Windows.Forms.TextBox m_txtRetornoCalculos;
			private System.Windows.Forms.Label m_lbUser;
		#endregion
		#region Constructor e Destructor
			public Form1()
			{
				InitializeComponent();
			}

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
			this.m_gbParametros = new System.Windows.Forms.GroupBox();
			this.m_txtIdCodigo = new System.Windows.Forms.TextBox();
			this.m_txtIdExportador = new System.Windows.Forms.TextBox();
			this.m_lbIdCodigo = new System.Windows.Forms.Label();
			this.m_lbIdExportador = new System.Windows.Forms.Label();
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_txtRetornoPar = new System.Windows.Forms.TextBox();
			this.m_lbRetornoPar = new System.Windows.Forms.Label();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_lbRetorno = new System.Windows.Forms.Label();
			this.m_gbMoeda = new System.Windows.Forms.GroupBox();
			this.m_btCondicaoPagamentoSaque = new System.Windows.Forms.Button();
			this.m_btProforma = new System.Windows.Forms.Button();
			this.m_btComercial = new System.Windows.Forms.Button();
			this.m_btCotacao = new System.Windows.Forms.Button();
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
			this.m_ilBandeiras = new System.Windows.Forms.ImageList(this.components);
			this.m_btCalculos = new System.Windows.Forms.Button();
			this.m_lbRetornoCalculos = new System.Windows.Forms.Label();
			this.m_txtRetornoCalculos = new System.Windows.Forms.TextBox();
			this.m_gbGeral.SuspendLayout();
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
			this.m_gbGeral.Controls.Add(this.m_gbParametros);
			this.m_gbGeral.Controls.Add(this.m_gbRetorno);
			this.m_gbGeral.Controls.Add(this.m_gbMoeda);
			this.m_gbGeral.Controls.Add(this.m_gbBD);
			this.m_gbGeral.Location = new System.Drawing.Point(5, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(615, 577);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbParametros
			// 
			this.m_gbParametros.Controls.Add(this.m_txtIdCodigo);
			this.m_gbParametros.Controls.Add(this.m_txtIdExportador);
			this.m_gbParametros.Controls.Add(this.m_lbIdCodigo);
			this.m_gbParametros.Controls.Add(this.m_lbIdExportador);
			this.m_gbParametros.Location = new System.Drawing.Point(8, 201);
			this.m_gbParametros.Name = "m_gbParametros";
			this.m_gbParametros.Size = new System.Drawing.Size(600, 80);
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
			this.m_gbRetorno.Controls.Add(this.m_txtRetornoCalculos);
			this.m_gbRetorno.Controls.Add(this.m_lbRetornoCalculos);
			this.m_gbRetorno.Controls.Add(this.m_txtRetornoPar);
			this.m_gbRetorno.Controls.Add(this.m_lbRetornoPar);
			this.m_gbRetorno.Controls.Add(this.m_txtRetorno);
			this.m_gbRetorno.Controls.Add(this.m_lbRetorno);
			this.m_gbRetorno.Location = new System.Drawing.Point(8, 344);
			this.m_gbRetorno.Name = "m_gbRetorno";
			this.m_gbRetorno.Size = new System.Drawing.Size(600, 224);
			this.m_gbRetorno.TabIndex = 2;
			this.m_gbRetorno.TabStop = false;
			this.m_gbRetorno.Text = "Retorno";
			// 
			// m_txtRetornoPar
			// 
			this.m_txtRetornoPar.Location = new System.Drawing.Point(78, 46);
			this.m_txtRetornoPar.Name = "m_txtRetornoPar";
			this.m_txtRetornoPar.Size = new System.Drawing.Size(504, 20);
			this.m_txtRetornoPar.TabIndex = 7;
			this.m_txtRetornoPar.Text = "";
			// 
			// m_lbRetornoPar
			// 
			this.m_lbRetornoPar.Location = new System.Drawing.Point(7, 48);
			this.m_lbRetornoPar.Name = "m_lbRetornoPar";
			this.m_lbRetornoPar.Size = new System.Drawing.Size(72, 16);
			this.m_lbRetornoPar.TabIndex = 6;
			this.m_lbRetornoPar.Text = "Retorno Par:";
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
			this.m_gbMoeda.Controls.Add(this.m_btCalculos);
			this.m_gbMoeda.Controls.Add(this.m_btCondicaoPagamentoSaque);
			this.m_gbMoeda.Controls.Add(this.m_btProforma);
			this.m_gbMoeda.Controls.Add(this.m_btComercial);
			this.m_gbMoeda.Controls.Add(this.m_btCotacao);
			this.m_gbMoeda.Location = new System.Drawing.Point(8, 279);
			this.m_gbMoeda.Name = "m_gbMoeda";
			this.m_gbMoeda.Size = new System.Drawing.Size(600, 62);
			this.m_gbMoeda.TabIndex = 1;
			this.m_gbMoeda.TabStop = false;
			this.m_gbMoeda.Text = "Esquema Pagamento";
			// 
			// m_btCondicaoPagamentoSaque
			// 
			this.m_btCondicaoPagamentoSaque.Location = new System.Drawing.Point(323, 20);
			this.m_btCondicaoPagamentoSaque.Name = "m_btCondicaoPagamentoSaque";
			this.m_btCondicaoPagamentoSaque.Size = new System.Drawing.Size(96, 32);
			this.m_btCondicaoPagamentoSaque.TabIndex = 4;
			this.m_btCondicaoPagamentoSaque.Text = "Saque";
			this.m_btCondicaoPagamentoSaque.Click += new System.EventHandler(this.m_btCondicaoPagamentoSaque_Click);
			// 
			// m_btProforma
			// 
			this.m_btProforma.Location = new System.Drawing.Point(120, 20);
			this.m_btProforma.Name = "m_btProforma";
			this.m_btProforma.Size = new System.Drawing.Size(96, 32);
			this.m_btProforma.TabIndex = 3;
			this.m_btProforma.Text = "Proforma";
			this.m_btProforma.Click += new System.EventHandler(this.m_btProforma_Click);
			// 
			// m_btComercial
			// 
			this.m_btComercial.Location = new System.Drawing.Point(224, 20);
			this.m_btComercial.Name = "m_btComercial";
			this.m_btComercial.Size = new System.Drawing.Size(96, 32);
			this.m_btComercial.TabIndex = 2;
			this.m_btComercial.Text = "Comercial";
			this.m_btComercial.Click += new System.EventHandler(this.m_btComercial_Click);
			// 
			// m_btCotacao
			// 
			this.m_btCotacao.Location = new System.Drawing.Point(16, 20);
			this.m_btCotacao.Name = "m_btCotacao";
			this.m_btCotacao.Size = new System.Drawing.Size(96, 32);
			this.m_btCotacao.TabIndex = 0;
			this.m_btCotacao.Text = "Cotacao";
			this.m_btCotacao.Click += new System.EventHandler(this.m_btCotacao_Click);
			// 
			// m_gbBD
			// 
			this.m_gbBD.Controls.Add(this.m_gbConfiguracao);
			this.m_gbBD.Controls.Add(this.m_gbTipoAcesso);
			this.m_gbBD.Controls.Add(this.m_gbLogin);
			this.m_gbBD.Location = new System.Drawing.Point(8, 16);
			this.m_gbBD.Name = "m_gbBD";
			this.m_gbBD.Size = new System.Drawing.Size(600, 192);
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
			this.m_gbTipoAcesso.Size = new System.Drawing.Size(577, 90);
			this.m_gbTipoAcesso.TabIndex = 10;
			this.m_gbTipoAcesso.TabStop = false;
			this.m_gbTipoAcesso.Text = "Tipo Acesso";
			// 
			// m_txtPortSqlServer
			// 
			this.m_txtPortSqlServer.Location = new System.Drawing.Point(137, 45);
			this.m_txtPortSqlServer.Name = "m_txtPortSqlServer";
			this.m_txtPortSqlServer.Size = new System.Drawing.Size(39, 20);
			this.m_txtPortSqlServer.TabIndex = 10;
			this.m_txtPortSqlServer.Text = "1433";
			// 
			// m_lbPortSqlServer
			// 
			this.m_lbPortSqlServer.Location = new System.Drawing.Point(104, 48);
			this.m_lbPortSqlServer.Name = "m_lbPortSqlServer";
			this.m_lbPortSqlServer.Size = new System.Drawing.Size(32, 16);
			this.m_lbPortSqlServer.TabIndex = 9;
			this.m_lbPortSqlServer.Text = "Port:";
			// 
			// m_rbSqlServer
			// 
			this.m_rbSqlServer.Checked = true;
			this.m_rbSqlServer.Location = new System.Drawing.Point(24, 48);
			this.m_rbSqlServer.Name = "m_rbSqlServer";
			this.m_rbSqlServer.Size = new System.Drawing.Size(80, 16);
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
			// m_ilBandeiras
			// 
			this.m_ilBandeiras.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilBandeiras.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBandeiras.ImageStream")));
			this.m_ilBandeiras.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_btCalculos
			// 
			this.m_btCalculos.Location = new System.Drawing.Point(498, 20);
			this.m_btCalculos.Name = "m_btCalculos";
			this.m_btCalculos.Size = new System.Drawing.Size(96, 32);
			this.m_btCalculos.TabIndex = 5;
			this.m_btCalculos.Text = "Calculos";
			this.m_btCalculos.Click += new System.EventHandler(this.m_btCalculos_Click);
			// 
			// m_lbRetornoCalculos
			// 
			this.m_lbRetornoCalculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbRetornoCalculos.Location = new System.Drawing.Point(8, 72);
			this.m_lbRetornoCalculos.Name = "m_lbRetornoCalculos";
			this.m_lbRetornoCalculos.Size = new System.Drawing.Size(104, 16);
			this.m_lbRetornoCalculos.TabIndex = 8;
			this.m_lbRetornoCalculos.Text = "Retorno Calculos:";
			// 
			// m_txtRetornoCalculos
			// 
			this.m_txtRetornoCalculos.Location = new System.Drawing.Point(120, 72);
			this.m_txtRetornoCalculos.Multiline = true;
			this.m_txtRetornoCalculos.Name = "m_txtRetornoCalculos";
			this.m_txtRetornoCalculos.Size = new System.Drawing.Size(464, 144);
			this.m_txtRetornoCalculos.TabIndex = 9;
			this.m_txtRetornoCalculos.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 581);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Esquema de Pagamento";
			this.m_gbGeral.ResumeLayout(false);
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

		#region Eventos
		private void Form1_Load(object sender, System.EventArgs e)
		{
		}
		#endregion
		#region DataBase
		private void CreateDataBase()
		{
			if (m_rbJet40.Checked)
			{
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessOleDbJet40(ref m_cls_tre_tratadorErro,m_txtPath.Text + m_txtDataBaseName.Text + ".mdb",m_txtUser.Text,m_txtPassword.Text);
			}
			if (m_rbMySql.Checked)
			{
				//m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtUser.Text,m_txtPassword.Text,m_txtDataBaseName.Text);
			}
			if (m_rbSqlServer.Checked)
			{
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessSqlServer(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtPortSqlServer.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);
			}
		}
		#endregion
		#region Negocio 
		private void m_btCotacao_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlEsquemaPagamento.clsEsquemaPagamento esquemaPagamento = new mdlEsquemaPagamento.clsEsquemaPagamentoFaturaCotacao(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,ref m_ilBandeiras,Int32.Parse(m_txtIdExportador.Text),m_txtIdCodigo.Text);
			esquemaPagamento.ShowDialog();
			if (esquemaPagamento.m_bModificado)
			{
				string strRetorno;
				esquemaPagamento.retornaValores(out strRetorno);
				m_txtRetorno.Text = strRetorno;

			}
			esquemaPagamento = null;
		}

		private void m_btProforma_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlEsquemaPagamento.clsEsquemaPagamento esquemaPagamento = new mdlEsquemaPagamento.clsEsquemaPagamentoFaturaProforma(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,ref m_ilBandeiras,Int32.Parse(m_txtIdExportador.Text),m_txtIdCodigo.Text);
			esquemaPagamento.ShowDialog();
			if (esquemaPagamento.m_bModificado)
			{
				string strRetorno;
				esquemaPagamento.retornaValores(out strRetorno);
				m_txtRetorno.Text = strRetorno;
			}
			esquemaPagamento = null;
		}

		private void m_btComercial_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlEsquemaPagamento.clsEsquemaPagamento esquemaPagamento = new mdlEsquemaPagamento.clsEsquemaPagamentoFaturaComercial(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,ref m_ilBandeiras,Int32.Parse(m_txtIdExportador.Text),m_txtIdCodigo.Text);
			esquemaPagamento.ShowDialog();
			if (esquemaPagamento.m_bModificado)
			{
				string strRetorno;
				esquemaPagamento.retornaValores(out strRetorno);
				m_txtRetorno.Text = strRetorno;
				double dCondAntecipado;
				double dCondAvista;
				double dCondPostecipado;
				bool bCondSemCoberturaCambial;
				bool bCondConsignacao;
				mdlEsquemaPagamento.Modalidade enumModAntecipado;
				mdlEsquemaPagamento.Modalidade enumModAvista;
				mdlEsquemaPagamento.Modalidade enumModPostecipado;
				int nPostQuantTempo;
				mdlEsquemaPagamento.UnidadeTempo enumPostUnidadeTempo;
				mdlEsquemaPagamento.DocumentoCondicao enumPostCondicao;
				int nPostQuantParcelas;
				int nPostIntervalo;
				esquemaPagamento.retornaValores(out dCondAntecipado,out dCondAvista,out dCondPostecipado,out bCondSemCoberturaCambial,out bCondConsignacao,out enumModAntecipado,out enumModAvista,out enumModPostecipado,out nPostQuantTempo,out enumPostUnidadeTempo,out enumPostCondicao,out nPostQuantParcelas,out nPostIntervalo);
				m_txtRetornoPar.Text = dCondAntecipado.ToString() + " " + dCondAvista.ToString() + " " + dCondPostecipado.ToString() + " " + bCondSemCoberturaCambial.ToString() + " " + bCondConsignacao.ToString() + " " + enumModAntecipado.ToString() + " " + enumModAvista.ToString() + " " + enumModPostecipado.ToString() + " " + nPostQuantTempo.ToString() + " " + enumPostUnidadeTempo.ToString() + " " + enumPostCondicao.ToString() + " " + nPostQuantParcelas.ToString() + " " + nPostIntervalo.ToString();
			}
			esquemaPagamento = null;
		}

		private void m_btCondicaoPagamentoSaque_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlEsquemaPagamento.clsEsquemaPagamentoSaque obj = new mdlEsquemaPagamento.clsEsquemaPagamentoSaque(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_txtIdExportador.Text),m_txtIdCodigo.Text);
			obj.ShowDialog();
			m_txtRetorno.Text = obj.CondicaoPagamento;
		}

		private void m_btCalculos_Click(object sender, System.EventArgs e)
		{
			const string ANTECIPADO = "Antecipado";
			const string AVISTA = "A Vista";
			const string POSTECIPADO = "Postecipado";
			CreateDataBase();
			mdlEsquemaPagamento.clsCalculoPorcentagens objCalculo = new mdlEsquemaPagamento.clsCalculoPorcentagens(18050);
			objCalculo.bAdiciona(ANTECIPADO,5000);
			objCalculo.bAdiciona(AVISTA,7000);
			objCalculo.bAdiciona(POSTECIPADO,6050);

			System.Text.StringBuilder objRetorno = new System.Text.StringBuilder();
			objRetorno.Append("Valor Total: " + objCalculo.ValorTotal.ToString() + " com Saldo: " + objCalculo.Saldo.ToString() + System.Environment.NewLine);
			objRetorno.Append(objCalculo.dValor(ANTECIPADO).ToString() + " " + ANTECIPADO + System.Environment.NewLine);
			objRetorno.Append("  - PorcentagemExata: " + objCalculo.dPorcentagemExata(ANTECIPADO) + System.Environment.NewLine);
			objRetorno.Append("  - Porcentagem         : " + objCalculo.dPorcentagem(ANTECIPADO) + System.Environment.NewLine);
			objRetorno.Append(objCalculo.dValor(AVISTA).ToString() + " " + AVISTA + System.Environment.NewLine);
			objRetorno.Append("  - PorcentagemExata: " + objCalculo.dPorcentagemExata(AVISTA) + System.Environment.NewLine);
			objRetorno.Append("  - Porcentagem         : " + objCalculo.dPorcentagem(AVISTA) + System.Environment.NewLine);
			objRetorno.Append(objCalculo.dValor(POSTECIPADO).ToString() + " " + POSTECIPADO + System.Environment.NewLine);
			objRetorno.Append("  - PorcentagemExata: " + objCalculo.dPorcentagemExata(POSTECIPADO) + System.Environment.NewLine);
			objRetorno.Append("  - Porcentagem         : " + objCalculo.dPorcentagem(POSTECIPADO) + System.Environment.NewLine);
			m_txtRetornoCalculos.Text = objRetorno.ToString();
		}
		#endregion
	}
}

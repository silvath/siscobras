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
		private System.Windows.Forms.TextBox m_txtIdExportador;
		private System.Windows.Forms.Label m_lbIdExportador;
		private System.Windows.Forms.GroupBox m_gbRetorno;
		private System.Windows.Forms.TextBox m_txtRetorno;
		private System.Windows.Forms.GroupBox m_gbMoeda;
		private System.Windows.Forms.Button m_btComercial;
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
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ImageList m_ilBandeiras;
		private System.Windows.Forms.TextBox m_tbIdPE;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.RadioButton m_rbSqlServer;
		private System.Windows.Forms.TextBox m_txtPortSqlServer;
		private System.Windows.Forms.Label m_lbPortSqlServer;
		private System.Windows.Forms.Button m_btEspacamento;
		private System.Windows.Forms.Button m_btFormARE;
		private System.ComponentModel.IContainer components;
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
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_btFormARE = new System.Windows.Forms.Button();
			this.m_btEspacamento = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.m_gbParametros = new System.Windows.Forms.GroupBox();
			this.m_tbIdPE = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtIdExportador = new System.Windows.Forms.TextBox();
			this.m_lbIdExportador = new System.Windows.Forms.Label();
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_gbMoeda = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.m_btProforma = new System.Windows.Forms.Button();
			this.m_btComercial = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
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
			this.m_gbGeral.SuspendLayout();
			this.groupBox1.SuspendLayout();
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
			this.m_gbGeral.Controls.Add(this.groupBox1);
			this.m_gbGeral.Controls.Add(this.m_gbParametros);
			this.m_gbGeral.Controls.Add(this.m_gbRetorno);
			this.m_gbGeral.Controls.Add(this.m_gbMoeda);
			this.m_gbGeral.Controls.Add(this.m_gbBD);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(615, 557);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.m_btFormARE);
			this.groupBox1.Controls.Add(this.m_btEspacamento);
			this.groupBox1.Controls.Add(this.button4);
			this.groupBox1.Controls.Add(this.button5);
			this.groupBox1.Controls.Add(this.button8);
			this.groupBox1.Location = new System.Drawing.Point(7, 390);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(600, 62);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Certificados sem norma";
			// 
			// m_btFormARE
			// 
			this.m_btFormARE.Location = new System.Drawing.Point(360, 20);
			this.m_btFormARE.Name = "m_btFormARE";
			this.m_btFormARE.Size = new System.Drawing.Size(96, 32);
			this.m_btFormARE.TabIndex = 8;
			this.m_btFormARE.Text = "Form A RE";
			this.m_btFormARE.Click += new System.EventHandler(this.m_btFormAIngles_Click);
			// 
			// m_btEspacamento
			// 
			this.m_btEspacamento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEspacamento.Location = new System.Drawing.Point(496, 16);
			this.m_btEspacamento.Name = "m_btEspacamento";
			this.m_btEspacamento.Size = new System.Drawing.Size(96, 32);
			this.m_btEspacamento.TabIndex = 7;
			this.m_btEspacamento.Text = "Espacamento";
			this.m_btEspacamento.Click += new System.EventHandler(this.m_btEspacamento_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(260, 20);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(96, 32);
			this.button4.TabIndex = 6;
			this.button4.Text = "Form A";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(160, 20);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(96, 32);
			this.button5.TabIndex = 5;
			this.button5.Text = "Anexo III";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(64, 20);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(96, 32);
			this.button8.TabIndex = 4;
			this.button8.Text = "Comum";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// m_gbParametros
			// 
			this.m_gbParametros.Controls.Add(this.m_tbIdPE);
			this.m_gbParametros.Controls.Add(this.label3);
			this.m_gbParametros.Controls.Add(this.m_txtIdExportador);
			this.m_gbParametros.Controls.Add(this.m_lbIdExportador);
			this.m_gbParametros.Location = new System.Drawing.Point(8, 248);
			this.m_gbParametros.Name = "m_gbParametros";
			this.m_gbParametros.Size = new System.Drawing.Size(600, 80);
			this.m_gbParametros.TabIndex = 3;
			this.m_gbParametros.TabStop = false;
			this.m_gbParametros.Text = "Parametros";
			// 
			// m_tbIdPE
			// 
			this.m_tbIdPE.Location = new System.Drawing.Point(108, 34);
			this.m_tbIdPE.Name = "m_tbIdPE";
			this.m_tbIdPE.Size = new System.Drawing.Size(91, 20);
			this.m_tbIdPE.TabIndex = 10;
			this.m_tbIdPE.Text = "001";
			this.m_tbIdPE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(15, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "IdPE";
			// 
			// m_txtIdExportador
			// 
			this.m_txtIdExportador.Location = new System.Drawing.Point(108, 13);
			this.m_txtIdExportador.Name = "m_txtIdExportador";
			this.m_txtIdExportador.Size = new System.Drawing.Size(91, 20);
			this.m_txtIdExportador.TabIndex = 6;
			this.m_txtIdExportador.Text = "1";
			this.m_txtIdExportador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbIdExportador
			// 
			this.m_lbIdExportador.Location = new System.Drawing.Point(14, 17);
			this.m_lbIdExportador.Name = "m_lbIdExportador";
			this.m_lbIdExportador.Size = new System.Drawing.Size(75, 16);
			this.m_lbIdExportador.TabIndex = 4;
			this.m_lbIdExportador.Text = "idExportador";
			// 
			// m_gbRetorno
			// 
			this.m_gbRetorno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbRetorno.Controls.Add(this.m_txtRetorno);
			this.m_gbRetorno.Location = new System.Drawing.Point(8, 456);
			this.m_gbRetorno.Name = "m_gbRetorno";
			this.m_gbRetorno.Size = new System.Drawing.Size(600, 88);
			this.m_gbRetorno.TabIndex = 2;
			this.m_gbRetorno.TabStop = false;
			this.m_gbRetorno.Text = "Retorno";
			// 
			// m_txtRetorno
			// 
			this.m_txtRetorno.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtRetorno.Location = new System.Drawing.Point(16, 19);
			this.m_txtRetorno.Multiline = true;
			this.m_txtRetorno.Name = "m_txtRetorno";
			this.m_txtRetorno.Size = new System.Drawing.Size(560, 61);
			this.m_txtRetorno.TabIndex = 5;
			this.m_txtRetorno.Text = "";
			// 
			// m_gbMoeda
			// 
			this.m_gbMoeda.Controls.Add(this.button3);
			this.m_gbMoeda.Controls.Add(this.button1);
			this.m_gbMoeda.Controls.Add(this.m_btProforma);
			this.m_gbMoeda.Controls.Add(this.m_btComercial);
			this.m_gbMoeda.Controls.Add(this.button2);
			this.m_gbMoeda.Location = new System.Drawing.Point(8, 328);
			this.m_gbMoeda.Name = "m_gbMoeda";
			this.m_gbMoeda.Size = new System.Drawing.Size(600, 62);
			this.m_gbMoeda.TabIndex = 1;
			this.m_gbMoeda.TabStop = false;
			this.m_gbMoeda.Text = "Certificados com norma";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(484, 20);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 32);
			this.button3.TabIndex = 6;
			this.button3.Text = "Mercosul Chile";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(368, 20);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 5;
			this.button1.Text = "Mercosul Bolívia";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// m_btProforma
			// 
			this.m_btProforma.Location = new System.Drawing.Point(16, 20);
			this.m_btProforma.Name = "m_btProforma";
			this.m_btProforma.Size = new System.Drawing.Size(96, 32);
			this.m_btProforma.TabIndex = 3;
			this.m_btProforma.Text = "Mercosul";
			this.m_btProforma.Click += new System.EventHandler(this.m_btProforma_Click);
			// 
			// m_btComercial
			// 
			this.m_btComercial.Location = new System.Drawing.Point(136, 20);
			this.m_btComercial.Name = "m_btComercial";
			this.m_btComercial.Size = new System.Drawing.Size(96, 32);
			this.m_btComercial.TabIndex = 2;
			this.m_btComercial.Text = "Aladi Aptr 04";
			this.m_btComercial.Click += new System.EventHandler(this.m_btComercial_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(252, 20);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 32);
			this.button2.TabIndex = 4;
			this.button2.Text = "Aladi Ace 39";
			this.button2.Click += new System.EventHandler(this.button2_Click);
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
			this.m_txtPath.Text = "F:\\Projetos\\Siscobras\\Binarios\\";
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
			this.m_txtPortSqlServer.Location = new System.Drawing.Point(132, 45);
			this.m_txtPortSqlServer.Name = "m_txtPortSqlServer";
			this.m_txtPortSqlServer.Size = new System.Drawing.Size(48, 20);
			this.m_txtPortSqlServer.TabIndex = 10;
			this.m_txtPortSqlServer.Text = "1433";
			// 
			// m_lbPortSqlServer
			// 
			this.m_lbPortSqlServer.Location = new System.Drawing.Point(102, 49);
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
			this.m_rbSqlServer.Size = new System.Drawing.Size(72, 16);
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
			this.m_ilBandeiras.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 560);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Produtos Certificado de Origem";
			this.m_gbGeral.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
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
			m_cls_dba_ConnectionBD.ShowDialogsErrors = true;
			m_cls_dba_ConnectionBD.SystemMode = mdlDataBaseAccess.Mode.Developer;
		}
		#endregion

		#region Eventos
		private void m_btComercial_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem teste = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemAladiAptr04(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_tbIdPE.Text, ref m_ilBandeiras);
//			teste.retornaValores(out strRetorno);
//			m_txtRetorno.Text = "Retorno: " + strRetorno;
			teste.ShowDialog();
//			teste.retornaValores(out strRetorno);
//			m_txtRetorno.Text = "Retorno: " + strRetorno;
		}
		private void m_btProforma_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem teste = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosul(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_tbIdPE.Text, ref m_ilBandeiras);
			//			teste.retornaValores(out strRetorno);
			//			m_txtRetorno.Text = "Retorno: " + strRetorno;
			teste.ShowDialog();
			//			teste.retornaValores(out strRetorno);
			//			m_txtRetorno.Text = "Retorno: " + strRetorno;
		}
		private void button2_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem teste = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulAce39(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_tbIdPE.Text, ref m_ilBandeiras);
			//			teste.retornaValores(out strRetorno);
			//			m_txtRetorno.Text = "Retorno: " + strRetorno;
			teste.ShowDialog();
			//			teste.retornaValores(out strRetorno);
			//			m_txtRetorno.Text = "Retorno: " + strRetorno;
		}
		private void button1_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem teste = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulBolivia(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_tbIdPE.Text, ref m_ilBandeiras);
			//			teste.retornaValores(out strRetorno);
			//			m_txtRetorno.Text = "Retorno: " + strRetorno;
			teste.ShowDialog();
			//			teste.retornaValores(out strRetorno);
			//			m_txtRetorno.Text = "Retorno: " + strRetorno;
		}
		private void button3_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem teste = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulChile(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_tbIdPE.Text, ref m_ilBandeiras);
			//			teste.retornaValores(out strRetorno);
			//			m_txtRetorno.Text = "Retorno: " + strRetorno;
			teste.ShowDialog();
			//			teste.retornaValores(out strRetorno);
			//			m_txtRetorno.Text = "Retorno: " + strRetorno;
		}
		private void button5_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem teste = new mdlProdutosCertificadoOrigem.SemNormas.clsProdutosCertificadoOrigemAnexoIII(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_tbIdPE.Text, ref m_ilBandeiras);
			//			teste.retornaValores(out strRetorno);
			//			m_txtRetorno.Text = "Retorno: " + strRetorno;
			teste.ShowDialog();
			//			teste.retornaValores(out strRetorno);
			//			m_txtRetorno.Text = "Retorno: " + strRetorno;		
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem teste = new mdlProdutosCertificadoOrigem.SemNormas.clsProdutosCertificadoOrigemComum(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_tbIdPE.Text, ref m_ilBandeiras);
			//			teste.retornaValores(out strRetorno);
			//			m_txtRetorno.Text = "Retorno: " + strRetorno;
			teste.ShowDialog();
			//			teste.retornaValores(out strRetorno);
			//			m_txtRetorno.Text = "Retorno: " + strRetorno;
		}
		private void button4_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlProdutosCertificadoOrigem.clsProdutosFormA obj = new mdlProdutosCertificadoOrigem.clsProdutosFormA(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_tbIdPE.Text);
			obj.ShowDialog();
		}

		private void m_btFormAIngles_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlProdutosCertificadoOrigem.clsProdutosFormARE obj = new mdlProdutosCertificadoOrigem.clsProdutosFormARE(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_tbIdPE.Text);
			obj.ShowDialog();
			m_txtRetorno.Text = obj.GetFormARE(0);
		}
		#endregion

		#region Negocio
			private void m_btEspacamento_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlProdutosCertificadoOrigem.clsEspacamento obj = new mdlProdutosCertificadoOrigem.clsEspacamento(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_tbIdPE.Text,(int)mdlConstantes.CertificadoOrigem.Mercosul);
				obj.ShowDialog();
				m_txtRetorno.Text = obj.Normas;
			}
		#endregion
	}
}

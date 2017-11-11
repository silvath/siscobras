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

		// Bandeiras
		private System.Windows.Forms.ImageList m_ilBandeiras;
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
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button m_btBordero;
		private System.Windows.Forms.Button m_btSumario;
		private System.Windows.Forms.Button m_btBorderoSecundario;
		private System.Windows.Forms.TextBox m_txtIdBancoExportador;
		private System.Windows.Forms.RadioButton m_rSqlServer;
		private System.Windows.Forms.TextBox m_txtPortSqlServer;
		private System.Windows.Forms.Label m_lbPortSqlServer;
		private System.Windows.Forms.TextBox m_txtPortMySql;
		private System.Windows.Forms.Label label3;
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
			this.m_gbParametros = new System.Windows.Forms.GroupBox();
			this.m_txtIdBancoExportador = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtIdCodigo = new System.Windows.Forms.TextBox();
			this.m_txtIdExportador = new System.Windows.Forms.TextBox();
			this.m_lbIdCodigo = new System.Windows.Forms.Label();
			this.m_lbIdExportador = new System.Windows.Forms.Label();
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_lbRetorno = new System.Windows.Forms.Label();
			this.m_gbMoeda = new System.Windows.Forms.GroupBox();
			this.m_btBorderoSecundario = new System.Windows.Forms.Button();
			this.m_btSumario = new System.Windows.Forms.Button();
			this.m_btBordero = new System.Windows.Forms.Button();
			this.m_gbBD = new System.Windows.Forms.GroupBox();
			this.m_gbConfiguracao = new System.Windows.Forms.GroupBox();
			this.m_txtPath = new System.Windows.Forms.TextBox();
			this.m_lbPath = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtDataBaseName = new System.Windows.Forms.TextBox();
			this.m_gbTipoAcesso = new System.Windows.Forms.GroupBox();
			this.m_txtPortMySql = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtPortSqlServer = new System.Windows.Forms.TextBox();
			this.m_lbPortSqlServer = new System.Windows.Forms.Label();
			this.m_rSqlServer = new System.Windows.Forms.RadioButton();
			this.m_rbMySql = new System.Windows.Forms.RadioButton();
			this.m_rbJet40 = new System.Windows.Forms.RadioButton();
			this.m_gbLogin = new System.Windows.Forms.GroupBox();
			this.m_txtHost = new System.Windows.Forms.TextBox();
			this.m_lbHost = new System.Windows.Forms.Label();
			this.m_txtPassword = new System.Windows.Forms.TextBox();
			this.m_txtUser = new System.Windows.Forms.TextBox();
			this.m_lbPassword = new System.Windows.Forms.Label();
			this.m_lbUser = new System.Windows.Forms.Label();
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
			this.m_gbGeral.Controls.Add(this.m_gbParametros);
			this.m_gbGeral.Controls.Add(this.m_gbRetorno);
			this.m_gbGeral.Controls.Add(this.m_gbMoeda);
			this.m_gbGeral.Controls.Add(this.m_gbBD);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(615, 450);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbParametros
			// 
			this.m_gbParametros.Controls.Add(this.m_txtIdBancoExportador);
			this.m_gbParametros.Controls.Add(this.label2);
			this.m_gbParametros.Controls.Add(this.m_txtIdCodigo);
			this.m_gbParametros.Controls.Add(this.m_txtIdExportador);
			this.m_gbParametros.Controls.Add(this.m_lbIdCodigo);
			this.m_gbParametros.Controls.Add(this.m_lbIdExportador);
			this.m_gbParametros.Location = new System.Drawing.Point(8, 202);
			this.m_gbParametros.Name = "m_gbParametros";
			this.m_gbParametros.Size = new System.Drawing.Size(600, 80);
			this.m_gbParametros.TabIndex = 3;
			this.m_gbParametros.TabStop = false;
			this.m_gbParametros.Text = "Parametros";
			// 
			// m_txtIdBancoExportador
			// 
			this.m_txtIdBancoExportador.Location = new System.Drawing.Point(456, 22);
			this.m_txtIdBancoExportador.Name = "m_txtIdBancoExportador";
			this.m_txtIdBancoExportador.Size = new System.Drawing.Size(91, 20);
			this.m_txtIdBancoExportador.TabIndex = 9;
			this.m_txtIdBancoExportador.Text = "1";
			this.m_txtIdBancoExportador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(336, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "idBancoExportador";
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
			this.m_gbRetorno.Location = new System.Drawing.Point(8, 344);
			this.m_gbRetorno.Name = "m_gbRetorno";
			this.m_gbRetorno.Size = new System.Drawing.Size(600, 96);
			this.m_gbRetorno.TabIndex = 2;
			this.m_gbRetorno.TabStop = false;
			this.m_gbRetorno.Text = "Retorno";
			// 
			// m_txtRetorno
			// 
			this.m_txtRetorno.Location = new System.Drawing.Point(79, 15);
			this.m_txtRetorno.Multiline = true;
			this.m_txtRetorno.Name = "m_txtRetorno";
			this.m_txtRetorno.Size = new System.Drawing.Size(504, 73);
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
			this.m_gbMoeda.Controls.Add(this.m_btBorderoSecundario);
			this.m_gbMoeda.Controls.Add(this.m_btSumario);
			this.m_gbMoeda.Controls.Add(this.m_btBordero);
			this.m_gbMoeda.Location = new System.Drawing.Point(8, 280);
			this.m_gbMoeda.Name = "m_gbMoeda";
			this.m_gbMoeda.Size = new System.Drawing.Size(600, 62);
			this.m_gbMoeda.TabIndex = 1;
			this.m_gbMoeda.TabStop = false;
			this.m_gbMoeda.Text = "Instru��es de Embarque";
			// 
			// m_btBorderoSecundario
			// 
			this.m_btBorderoSecundario.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btBorderoSecundario.Location = new System.Drawing.Point(149, 20);
			this.m_btBorderoSecundario.Name = "m_btBorderoSecundario";
			this.m_btBorderoSecundario.Size = new System.Drawing.Size(96, 32);
			this.m_btBorderoSecundario.TabIndex = 4;
			this.m_btBorderoSecundario.Text = "Border� Secund�rio";
			this.m_btBorderoSecundario.Click += new System.EventHandler(this.m_btBorderoSecundario_Click);
			// 
			// m_btSumario
			// 
			this.m_btSumario.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSumario.Location = new System.Drawing.Point(355, 20);
			this.m_btSumario.Name = "m_btSumario";
			this.m_btSumario.Size = new System.Drawing.Size(96, 32);
			this.m_btSumario.TabIndex = 3;
			this.m_btSumario.Text = "Sum�rio";
			this.m_btSumario.Click += new System.EventHandler(this.m_btSumario_Click);
			// 
			// m_btBordero
			// 
			this.m_btBordero.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btBordero.Location = new System.Drawing.Point(252, 20);
			this.m_btBordero.Name = "m_btBordero";
			this.m_btBordero.Size = new System.Drawing.Size(96, 32);
			this.m_btBordero.TabIndex = 2;
			this.m_btBordero.Text = "Border�";
			this.m_btBordero.Click += new System.EventHandler(this.m_btBordero_Click);
			// 
			// m_gbBD
			// 
			this.m_gbBD.Controls.Add(this.m_gbConfiguracao);
			this.m_gbBD.Controls.Add(this.m_gbTipoAcesso);
			this.m_gbBD.Controls.Add(this.m_gbLogin);
			this.m_gbBD.Location = new System.Drawing.Point(8, 16);
			this.m_gbBD.Name = "m_gbBD";
			this.m_gbBD.Size = new System.Drawing.Size(600, 184);
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
			this.m_gbTipoAcesso.Controls.Add(this.m_txtPortMySql);
			this.m_gbTipoAcesso.Controls.Add(this.label3);
			this.m_gbTipoAcesso.Controls.Add(this.m_txtPortSqlServer);
			this.m_gbTipoAcesso.Controls.Add(this.m_lbPortSqlServer);
			this.m_gbTipoAcesso.Controls.Add(this.m_rSqlServer);
			this.m_gbTipoAcesso.Controls.Add(this.m_rbMySql);
			this.m_gbTipoAcesso.Controls.Add(this.m_rbJet40);
			this.m_gbTipoAcesso.Location = new System.Drawing.Point(7, 94);
			this.m_gbTipoAcesso.Name = "m_gbTipoAcesso";
			this.m_gbTipoAcesso.Size = new System.Drawing.Size(577, 82);
			this.m_gbTipoAcesso.TabIndex = 10;
			this.m_gbTipoAcesso.TabStop = false;
			this.m_gbTipoAcesso.Text = "Tipo Acesso";
			// 
			// m_txtPortMySql
			// 
			this.m_txtPortMySql.Location = new System.Drawing.Point(128, 23);
			this.m_txtPortMySql.Name = "m_txtPortMySql";
			this.m_txtPortMySql.Size = new System.Drawing.Size(40, 20);
			this.m_txtPortMySql.TabIndex = 12;
			this.m_txtPortMySql.Text = "3306";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(97, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 16);
			this.label3.TabIndex = 11;
			this.label3.Text = "Port:";
			// 
			// m_txtPortSqlServer
			// 
			this.m_txtPortSqlServer.Location = new System.Drawing.Point(127, 45);
			this.m_txtPortSqlServer.Name = "m_txtPortSqlServer";
			this.m_txtPortSqlServer.Size = new System.Drawing.Size(40, 20);
			this.m_txtPortSqlServer.TabIndex = 10;
			this.m_txtPortSqlServer.Text = "1433";
			// 
			// m_lbPortSqlServer
			// 
			this.m_lbPortSqlServer.Location = new System.Drawing.Point(96, 49);
			this.m_lbPortSqlServer.Name = "m_lbPortSqlServer";
			this.m_lbPortSqlServer.Size = new System.Drawing.Size(32, 16);
			this.m_lbPortSqlServer.TabIndex = 9;
			this.m_lbPortSqlServer.Text = "Port:";
			// 
			// m_rSqlServer
			// 
			this.m_rSqlServer.Checked = true;
			this.m_rSqlServer.Location = new System.Drawing.Point(24, 48);
			this.m_rSqlServer.Name = "m_rSqlServer";
			this.m_rSqlServer.Size = new System.Drawing.Size(72, 16);
			this.m_rSqlServer.TabIndex = 6;
			this.m_rSqlServer.TabStop = true;
			this.m_rSqlServer.Text = "SqlServer";
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
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 454);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Documentos";
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

		#region DataBase
		private void CreateDataBase()
		{
			if (m_rbJet40.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessOleDbJet40(ref m_cls_tre_tratadorErro,m_txtPath.Text + m_txtDataBaseName.Text + ".mdb",m_txtUser.Text,m_txtPassword.Text);
			if (m_rSqlServer.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessSqlServer(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtPortSqlServer.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);
			m_cls_dba_ConnectionBD.ShowDialogsErrors = true;
			m_cls_dba_ConnectionBD.SystemMode = mdlDataBaseAccess.Mode.Developer;
		}
		#endregion

		#region Eventos
		private void m_btBordero_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();

			mdlDocumentacao.clsDocumentacao obj = new mdlDocumentacao.clsDocumentacao(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
			obj.CERTIFICADOORIGEM = true;
			obj.FATURACOMERCIAL = true;
			obj.FITOSANITARIO = true;
			obj.CERTIFICADOANALISE = true;
			obj.CERTIFICADOPESO = true;
			obj.SAQUE = true;
			obj.SEGURO = true;
			obj.ROMANEIO = true;
			obj.CONHECIMENTOEMBARQUE = true;
			obj.ShowDialog();
			string strFaturaComercial, strQtdeDocOriginaisFC, strQtdeDocCopiasFC, strQtdeDocTotalFC;
			string strConhecimentoEmbarque, strQtdeDocOriginaisCE, strQtdeDocCopiasCE, strQtdeDocTotalCE;
			string strSeguro, strQtdeDocOriginaisSG, strQtdeDocCopiasSG, strQtdeDocTotalSG;
			string strCertificadoOrigem, strQtdeDocOriginaisCO, strQtdeDocCopiasCO, strQtdeDocTotalCO;
			string strRomaneio, strQtdeDocOriginaisRM, strQtdeDocCopiasRM, strQtdeDocTotalRM;
			string strCertificadoPeso, strQtdeDocOriginaisCP, strQtdeDocCopiasCP, strQtdeDocTotalCP;
			string strCertificadoAnalise, strQtdeDocOriginaisCA, strQtdeDocCopiasCA, strQtdeDocTotalCA;
			string strSaque, strQtdeDocOriginaisSQ, strQtdeDocCopiasSQ, strQtdeDocTotalSQ;
			string strFitoSanitario, strQtdeDocOriginaisFS, strQtdeDocCopiasFS, strQtdeDocTotalFS;
			obj.retornaValores(out strFaturaComercial, out strQtdeDocOriginaisFC, out strQtdeDocCopiasFC, out strQtdeDocTotalFC,
			out strConhecimentoEmbarque, out strQtdeDocOriginaisCE, out strQtdeDocCopiasCE, out strQtdeDocTotalCE,
			out strSeguro, out strQtdeDocOriginaisSG, out strQtdeDocCopiasSG, out strQtdeDocTotalSG,
			out strCertificadoOrigem, out strQtdeDocOriginaisCO, out strQtdeDocCopiasCO, out strQtdeDocTotalCO,
			out strRomaneio, out strQtdeDocOriginaisRM, out strQtdeDocCopiasRM, out strQtdeDocTotalRM,
			out strCertificadoPeso, out strQtdeDocOriginaisCP, out strQtdeDocCopiasCP, out strQtdeDocTotalCP,
			out strCertificadoAnalise, out strQtdeDocOriginaisCA, out strQtdeDocCopiasCA, out strQtdeDocTotalCA,
			out strSaque, out strQtdeDocOriginaisSQ, out strQtdeDocCopiasSQ, out strQtdeDocTotalSQ,
			out strFitoSanitario, out strQtdeDocOriginaisFS, out strQtdeDocCopiasFS, out strQtdeDocTotalFS);
			System.Text.StringBuilder strbText = new System.Text.StringBuilder();
			strbText.Append("CO: " + strCertificadoOrigem + " " + strQtdeDocOriginaisCO + " " + strQtdeDocCopiasCO + " " + strQtdeDocTotalCO);
			m_txtRetorno.Text = strbText.ToString();
		}

		private void m_btSumario_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();

			mdlDocumentacao.clsDocumentacaoSumario obj = new mdlDocumentacao.clsDocumentacaoSumario(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
			obj.ShowDialog();
		}

		private void m_btBorderoSecundario_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();

			mdlDocumentacao.clsDocumentacaoBorderoSecundario obj = new mdlDocumentacao.clsDocumentacaoBorderoSecundario(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text, Int32.Parse(m_txtIdBancoExportador.Text));
			obj.ShowDialog();
		}
		#endregion
	}
}

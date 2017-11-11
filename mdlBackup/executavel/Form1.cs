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
		private System.Windows.Forms.GroupBox m_gbRetorno;
		private System.Windows.Forms.TextBox m_txtRetorno;
		private System.Windows.Forms.Label m_lbRetorno;
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
		private System.Windows.Forms.Button m_btVerificaQuantidadeBackups;
		private System.Windows.Forms.Button m_btBackup;
		private System.Windows.Forms.Button m_btRestaura;
		private System.Windows.Forms.RadioButton m_rbSqlServer;
		private System.Windows.Forms.TextBox m_txtPortSqlServer;
		private System.Windows.Forms.Label m_lbPortSqlServer;
		private System.Windows.Forms.TextBox m_txtPathBackup;
		private System.Windows.Forms.Label m_lbPathBackup;
		private System.Windows.Forms.TextBox m_txtArquivo;
		private System.Windows.Forms.Label m_lbArquivo;
		private System.Windows.Forms.GroupBox m_gbNegocio;
		private System.Windows.Forms.Button m_btCriaBackupCasoNecessario;
		private System.Windows.Forms.TextBox m_txtPortMysql;
		private System.Windows.Forms.Label m_lbPortMysql;
		private System.Windows.Forms.Button m_btRestauraInterface;
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
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbParametros = new System.Windows.Forms.GroupBox();
			this.m_txtArquivo = new System.Windows.Forms.TextBox();
			this.m_lbArquivo = new System.Windows.Forms.Label();
			this.m_txtPathBackup = new System.Windows.Forms.TextBox();
			this.m_lbPathBackup = new System.Windows.Forms.Label();
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_lbRetorno = new System.Windows.Forms.Label();
			this.m_gbNegocio = new System.Windows.Forms.GroupBox();
			this.m_btRestauraInterface = new System.Windows.Forms.Button();
			this.m_btCriaBackupCasoNecessario = new System.Windows.Forms.Button();
			this.m_btVerificaQuantidadeBackups = new System.Windows.Forms.Button();
			this.m_btBackup = new System.Windows.Forms.Button();
			this.m_btRestaura = new System.Windows.Forms.Button();
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
			this.m_gbGeral.SuspendLayout();
			this.m_gbParametros.SuspendLayout();
			this.m_gbRetorno.SuspendLayout();
			this.m_gbNegocio.SuspendLayout();
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
			this.m_gbGeral.Controls.Add(this.m_gbNegocio);
			this.m_gbGeral.Controls.Add(this.m_gbBD);
			this.m_gbGeral.Location = new System.Drawing.Point(5, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(615, 450);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbParametros
			// 
			this.m_gbParametros.Controls.Add(this.m_txtArquivo);
			this.m_gbParametros.Controls.Add(this.m_lbArquivo);
			this.m_gbParametros.Controls.Add(this.m_txtPathBackup);
			this.m_gbParametros.Controls.Add(this.m_lbPathBackup);
			this.m_gbParametros.Location = new System.Drawing.Point(8, 248);
			this.m_gbParametros.Name = "m_gbParametros";
			this.m_gbParametros.Size = new System.Drawing.Size(600, 80);
			this.m_gbParametros.TabIndex = 3;
			this.m_gbParametros.TabStop = false;
			this.m_gbParametros.Text = "Parametros";
			// 
			// m_txtArquivo
			// 
			this.m_txtArquivo.Location = new System.Drawing.Point(59, 40);
			this.m_txtArquivo.Name = "m_txtArquivo";
			this.m_txtArquivo.Size = new System.Drawing.Size(517, 20);
			this.m_txtArquivo.TabIndex = 9;
			this.m_txtArquivo.Text = "Restaurar.bkp";
			// 
			// m_lbArquivo
			// 
			this.m_lbArquivo.Location = new System.Drawing.Point(8, 41);
			this.m_lbArquivo.Name = "m_lbArquivo";
			this.m_lbArquivo.Size = new System.Drawing.Size(40, 16);
			this.m_lbArquivo.TabIndex = 8;
			this.m_lbArquivo.Text = "Arquivo:";
			// 
			// m_txtPathBackup
			// 
			this.m_txtPathBackup.Location = new System.Drawing.Point(59, 14);
			this.m_txtPathBackup.Name = "m_txtPathBackup";
			this.m_txtPathBackup.Size = new System.Drawing.Size(517, 20);
			this.m_txtPathBackup.TabIndex = 7;
			this.m_txtPathBackup.Text = "C:\\";
			// 
			// m_lbPathBackup
			// 
			this.m_lbPathBackup.Location = new System.Drawing.Point(9, 17);
			this.m_lbPathBackup.Name = "m_lbPathBackup";
			this.m_lbPathBackup.Size = new System.Drawing.Size(35, 16);
			this.m_lbPathBackup.TabIndex = 5;
			this.m_lbPathBackup.Text = "Path:";
			// 
			// m_gbRetorno
			// 
			this.m_gbRetorno.Controls.Add(this.m_txtRetorno);
			this.m_gbRetorno.Controls.Add(this.m_lbRetorno);
			this.m_gbRetorno.Location = new System.Drawing.Point(8, 392);
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
			// m_gbNegocio
			// 
			this.m_gbNegocio.Controls.Add(this.m_btRestauraInterface);
			this.m_gbNegocio.Controls.Add(this.m_btCriaBackupCasoNecessario);
			this.m_gbNegocio.Controls.Add(this.m_btVerificaQuantidadeBackups);
			this.m_gbNegocio.Controls.Add(this.m_btBackup);
			this.m_gbNegocio.Controls.Add(this.m_btRestaura);
			this.m_gbNegocio.Location = new System.Drawing.Point(8, 328);
			this.m_gbNegocio.Name = "m_gbNegocio";
			this.m_gbNegocio.Size = new System.Drawing.Size(600, 62);
			this.m_gbNegocio.TabIndex = 1;
			this.m_gbNegocio.TabStop = false;
			this.m_gbNegocio.Text = "Negocio";
			// 
			// m_btRestauraInterface
			// 
			this.m_btRestauraInterface.Location = new System.Drawing.Point(498, 19);
			this.m_btRestauraInterface.Name = "m_btRestauraInterface";
			this.m_btRestauraInterface.Size = new System.Drawing.Size(96, 32);
			this.m_btRestauraInterface.TabIndex = 7;
			this.m_btRestauraInterface.Text = "Interface Restaura";
			this.m_btRestauraInterface.Click += new System.EventHandler(this.m_btRestauraInterface_Click);
			// 
			// m_btCriaBackupCasoNecessario
			// 
			this.m_btCriaBackupCasoNecessario.Location = new System.Drawing.Point(317, 19);
			this.m_btCriaBackupCasoNecessario.Name = "m_btCriaBackupCasoNecessario";
			this.m_btCriaBackupCasoNecessario.Size = new System.Drawing.Size(96, 32);
			this.m_btCriaBackupCasoNecessario.TabIndex = 6;
			this.m_btCriaBackupCasoNecessario.Text = "Cria Backup CN";
			this.m_btCriaBackupCasoNecessario.Click += new System.EventHandler(this.m_btCriaBackupCasoNecessario_Click);
			// 
			// m_btVerificaQuantidadeBackups
			// 
			this.m_btVerificaQuantidadeBackups.Location = new System.Drawing.Point(16, 19);
			this.m_btVerificaQuantidadeBackups.Name = "m_btVerificaQuantidadeBackups";
			this.m_btVerificaQuantidadeBackups.Size = new System.Drawing.Size(96, 32);
			this.m_btVerificaQuantidadeBackups.TabIndex = 5;
			this.m_btVerificaQuantidadeBackups.Text = "Verifica QTDE Backups";
			this.m_btVerificaQuantidadeBackups.Click += new System.EventHandler(this.m_btQuantidadeBackups_Click);
			// 
			// m_btBackup
			// 
			this.m_btBackup.Location = new System.Drawing.Point(216, 19);
			this.m_btBackup.Name = "m_btBackup";
			this.m_btBackup.Size = new System.Drawing.Size(96, 32);
			this.m_btBackup.TabIndex = 4;
			this.m_btBackup.Text = "Cria Backup";
			this.m_btBackup.Click += new System.EventHandler(this.m_btBackup_Click);
			// 
			// m_btRestaura
			// 
			this.m_btRestaura.Location = new System.Drawing.Point(116, 19);
			this.m_btRestaura.Name = "m_btRestaura";
			this.m_btRestaura.Size = new System.Drawing.Size(96, 32);
			this.m_btRestaura.TabIndex = 3;
			this.m_btRestaura.Text = "Restaura Backup";
			this.m_btRestaura.Click += new System.EventHandler(this.m_btRestaura_Click);
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
			this.m_txtPortMysql.Location = new System.Drawing.Point(138, 25);
			this.m_txtPortMysql.Name = "m_txtPortMysql";
			this.m_txtPortMysql.Size = new System.Drawing.Size(48, 20);
			this.m_txtPortMysql.TabIndex = 12;
			this.m_txtPortMysql.Text = "3306";
			// 
			// m_lbPortMysql
			// 
			this.m_lbPortMysql.Location = new System.Drawing.Point(106, 31);
			this.m_lbPortMysql.Name = "m_lbPortMysql";
			this.m_lbPortMysql.Size = new System.Drawing.Size(31, 16);
			this.m_lbPortMysql.TabIndex = 11;
			this.m_lbPortMysql.Text = "Port:";
			// 
			// m_txtPortSqlServer
			// 
			this.m_txtPortSqlServer.Location = new System.Drawing.Point(139, 47);
			this.m_txtPortSqlServer.Name = "m_txtPortSqlServer";
			this.m_txtPortSqlServer.Size = new System.Drawing.Size(48, 20);
			this.m_txtPortSqlServer.TabIndex = 10;
			this.m_txtPortSqlServer.Text = "1433";
			// 
			// m_lbPortSqlServer
			// 
			this.m_lbPortSqlServer.Location = new System.Drawing.Point(106, 50);
			this.m_lbPortSqlServer.Name = "m_lbPortSqlServer";
			this.m_lbPortSqlServer.Size = new System.Drawing.Size(31, 16);
			this.m_lbPortSqlServer.TabIndex = 9;
			this.m_lbPortSqlServer.Text = "Port:";
			// 
			// m_rbSqlServer
			// 
			this.m_rbSqlServer.Location = new System.Drawing.Point(24, 48);
			this.m_rbSqlServer.Name = "m_rbSqlServer";
			this.m_rbSqlServer.Size = new System.Drawing.Size(80, 16);
			this.m_rbSqlServer.TabIndex = 6;
			this.m_rbSqlServer.Text = "SqlServer";
			// 
			// m_rbMySql
			// 
			this.m_rbMySql.Checked = true;
			this.m_rbMySql.Location = new System.Drawing.Point(24, 32);
			this.m_rbMySql.Name = "m_rbMySql";
			this.m_rbMySql.Size = new System.Drawing.Size(72, 16);
			this.m_rbMySql.TabIndex = 5;
			this.m_rbMySql.TabStop = true;
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
			this.m_ilBandeiras.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 454);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Backup";
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbParametros.ResumeLayout(false);
			this.m_gbRetorno.ResumeLayout(false);
			this.m_gbNegocio.ResumeLayout(false);
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
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessOleDbJet40(ref m_cls_tre_tratadorErro,m_txtPath.Text + m_txtDataBaseName.Text + ".mdb",m_txtUser.Text,m_txtPassword.Text);
			if (m_rbMySql.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtPortMysql.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);
			if (m_rbSqlServer.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessSqlServer(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtPortSqlServer.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);

			if (m_cls_dba_ConnectionBD != null)
			{
				m_cls_dba_ConnectionBD.ShowDialogsErrors = true;
				m_cls_dba_ConnectionBD.SystemMode = mdlDataBaseAccess.Mode.Developer;
				m_cls_dba_ConnectionBD.Log = true;
			}
		}
		#endregion

		#region Negocio 
		private void m_btQuantidadeBackups_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlBackup.clsBackup obj = new mdlBackup.clsBackup(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text);
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			obj.criaBackupSeNecessario();
			this.Cursor = System.Windows.Forms.Cursors.Default;
			mdlBackup.clsBackup.verificarQtdeBackup(ref m_cls_dba_ConnectionBD,m_txtPathBackup.Text);
		}

		private void m_btRestaura_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlBackup.clsBackup obj = new mdlBackup.clsBackup(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text,m_txtPathBackup.Text,m_txtArquivo.Text);
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			m_txtRetorno.Text = obj.bRestauraBackup().ToString();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void m_btBackup_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlBackup.clsBackup obj = new mdlBackup.clsBackup(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, m_txtPathBackup.Text, m_txtArquivo.Text);
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			m_txtRetorno.Text = obj.bCriaBackup().ToString();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void m_btCriaBackupCasoNecessario_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlBackup.clsBackup obj = new mdlBackup.clsBackup(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text);
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			obj.criaBackupSeNecessario();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void m_btRestauraInterface_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlBackup.clsBackupRestore obj = new mdlBackup.clsBackupRestore(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text);
			obj.ShowDialog();
		}

		#endregion
	}
}

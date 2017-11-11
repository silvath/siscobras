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
		private System.Windows.Forms.GroupBox m_gbRetorno;
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
		private System.Windows.Forms.TextBox m_txtHost;
		private System.Windows.Forms.Label m_lbHost;
		private System.Windows.Forms.TextBox m_txtPassword;
		private System.Windows.Forms.TextBox m_txtUser;
		private System.Windows.Forms.Label m_lbPassword;
		private System.Windows.Forms.Button m_btCarregaDados;
		private System.Windows.Forms.Button m_btShowDialog;
		private System.Windows.Forms.Button m_btReset;
		internal System.Windows.Forms.TreeView m_tvRetorno;
		private mdlComponentesGraficos.ComboBox m_cbRelatorio;
		private System.Windows.Forms.Label m_lbRelatorio;
		private System.Windows.Forms.TextBox m_txtPagina;
		private System.Windows.Forms.Label m_lbIdioma;
		private System.Windows.Forms.Label m_lbPagina;
		private System.Windows.Forms.TextBox m_txtIdCodigo;
		private System.Windows.Forms.TextBox m_txtIdExportador;
		private System.Windows.Forms.Label m_lbIdCodigo;
		private System.Windows.Forms.Label m_lbIdExportador;
		private System.Windows.Forms.GroupBox m_gbParametros;
		private mdlComponentesGraficos.ComboBox m_cbIdioma;
		private System.Windows.Forms.RadioButton m_rbSqlServer;
		private System.Windows.Forms.TextBox m_txtPortSqlServer;
		private System.Windows.Forms.Label m_lbPortSqlServer;
		private System.Windows.Forms.TextBox m_txtPortMySql;
		private System.Windows.Forms.Label label2;
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
			this.m_cbIdioma = new mdlComponentesGraficos.ComboBox();
			this.m_cbRelatorio = new mdlComponentesGraficos.ComboBox();
			this.m_lbRelatorio = new System.Windows.Forms.Label();
			this.m_txtPagina = new System.Windows.Forms.TextBox();
			this.m_lbIdioma = new System.Windows.Forms.Label();
			this.m_lbPagina = new System.Windows.Forms.Label();
			this.m_txtIdCodigo = new System.Windows.Forms.TextBox();
			this.m_txtIdExportador = new System.Windows.Forms.TextBox();
			this.m_lbIdCodigo = new System.Windows.Forms.Label();
			this.m_lbIdExportador = new System.Windows.Forms.Label();
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_tvRetorno = new System.Windows.Forms.TreeView();
			this.m_gbBD = new System.Windows.Forms.GroupBox();
			this.m_gbConfiguracao = new System.Windows.Forms.GroupBox();
			this.m_txtPath = new System.Windows.Forms.TextBox();
			this.m_lbPath = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtDataBaseName = new System.Windows.Forms.TextBox();
			this.m_gbTipoAcesso = new System.Windows.Forms.GroupBox();
			this.m_txtPortMySql = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtPortSqlServer = new System.Windows.Forms.TextBox();
			this.m_lbPortSqlServer = new System.Windows.Forms.Label();
			this.m_rbSqlServer = new System.Windows.Forms.RadioButton();
			this.m_btReset = new System.Windows.Forms.Button();
			this.m_rbMySql = new System.Windows.Forms.RadioButton();
			this.m_rbJet40 = new System.Windows.Forms.RadioButton();
			this.m_gbLogin = new System.Windows.Forms.GroupBox();
			this.m_txtHost = new System.Windows.Forms.TextBox();
			this.m_lbHost = new System.Windows.Forms.Label();
			this.m_txtPassword = new System.Windows.Forms.TextBox();
			this.m_txtUser = new System.Windows.Forms.TextBox();
			this.m_lbPassword = new System.Windows.Forms.Label();
			this.m_lbUser = new System.Windows.Forms.Label();
			this.m_gbMoeda = new System.Windows.Forms.GroupBox();
			this.m_btShowDialog = new System.Windows.Forms.Button();
			this.m_btCarregaDados = new System.Windows.Forms.Button();
			this.m_ilBandeiras = new System.Windows.Forms.ImageList(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbParametros.SuspendLayout();
			this.m_gbRetorno.SuspendLayout();
			this.m_gbBD.SuspendLayout();
			this.m_gbConfiguracao.SuspendLayout();
			this.m_gbTipoAcesso.SuspendLayout();
			this.m_gbLogin.SuspendLayout();
			this.m_gbMoeda.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbParametros);
			this.m_gbGeral.Controls.Add(this.m_gbRetorno);
			this.m_gbGeral.Controls.Add(this.m_gbBD);
			this.m_gbGeral.Controls.Add(this.m_gbMoeda);
			this.m_gbGeral.Location = new System.Drawing.Point(5, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(867, 633);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbParametros
			// 
			this.m_gbParametros.Controls.Add(this.m_cbIdioma);
			this.m_gbParametros.Controls.Add(this.m_cbRelatorio);
			this.m_gbParametros.Controls.Add(this.m_lbRelatorio);
			this.m_gbParametros.Controls.Add(this.m_txtPagina);
			this.m_gbParametros.Controls.Add(this.m_lbIdioma);
			this.m_gbParametros.Controls.Add(this.m_lbPagina);
			this.m_gbParametros.Controls.Add(this.m_txtIdCodigo);
			this.m_gbParametros.Controls.Add(this.m_txtIdExportador);
			this.m_gbParametros.Controls.Add(this.m_lbIdCodigo);
			this.m_gbParametros.Controls.Add(this.m_lbIdExportador);
			this.m_gbParametros.Location = new System.Drawing.Point(8, 248);
			this.m_gbParametros.Name = "m_gbParametros";
			this.m_gbParametros.Size = new System.Drawing.Size(848, 80);
			this.m_gbParametros.TabIndex = 3;
			this.m_gbParametros.TabStop = false;
			this.m_gbParametros.Text = "Parametros";
			// 
			// m_cbIdioma
			// 
			this.m_cbIdioma.ItemHeight = 13;
			this.m_cbIdioma.Location = new System.Drawing.Point(240, 48);
			this.m_cbIdioma.Name = "m_cbIdioma";
			this.m_cbIdioma.Size = new System.Drawing.Size(120, 21);
			this.m_cbIdioma.TabIndex = 14;
			// 
			// m_cbRelatorio
			// 
			this.m_cbRelatorio.ItemHeight = 13;
			this.m_cbRelatorio.Location = new System.Drawing.Point(445, 20);
			this.m_cbRelatorio.Name = "m_cbRelatorio";
			this.m_cbRelatorio.Size = new System.Drawing.Size(195, 21);
			this.m_cbRelatorio.TabIndex = 13;
			// 
			// m_lbRelatorio
			// 
			this.m_lbRelatorio.Location = new System.Drawing.Point(384, 22);
			this.m_lbRelatorio.Name = "m_lbRelatorio";
			this.m_lbRelatorio.Size = new System.Drawing.Size(88, 16);
			this.m_lbRelatorio.TabIndex = 12;
			this.m_lbRelatorio.Text = "Relatorio";
			// 
			// m_txtPagina
			// 
			this.m_txtPagina.Location = new System.Drawing.Point(240, 23);
			this.m_txtPagina.Name = "m_txtPagina";
			this.m_txtPagina.Size = new System.Drawing.Size(120, 20);
			this.m_txtPagina.TabIndex = 10;
			this.m_txtPagina.Text = "1";
			this.m_txtPagina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbIdioma
			// 
			this.m_lbIdioma.Location = new System.Drawing.Point(193, 46);
			this.m_lbIdioma.Name = "m_lbIdioma";
			this.m_lbIdioma.Size = new System.Drawing.Size(88, 16);
			this.m_lbIdioma.TabIndex = 9;
			this.m_lbIdioma.Text = "Idioma";
			// 
			// m_lbPagina
			// 
			this.m_lbPagina.Location = new System.Drawing.Point(193, 27);
			this.m_lbPagina.Name = "m_lbPagina";
			this.m_lbPagina.Size = new System.Drawing.Size(75, 16);
			this.m_lbPagina.TabIndex = 8;
			this.m_lbPagina.Text = "Pagina";
			// 
			// m_txtIdCodigo
			// 
			this.m_txtIdCodigo.Location = new System.Drawing.Point(88, 47);
			this.m_txtIdCodigo.Name = "m_txtIdCodigo";
			this.m_txtIdCodigo.Size = new System.Drawing.Size(91, 20);
			this.m_txtIdCodigo.TabIndex = 7;
			this.m_txtIdCodigo.Text = "158";
			this.m_txtIdCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_txtIdExportador
			// 
			this.m_txtIdExportador.Location = new System.Drawing.Point(87, 23);
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
			this.m_gbRetorno.Controls.Add(this.m_tvRetorno);
			this.m_gbRetorno.Location = new System.Drawing.Point(8, 392);
			this.m_gbRetorno.Name = "m_gbRetorno";
			this.m_gbRetorno.Size = new System.Drawing.Size(848, 232);
			this.m_gbRetorno.TabIndex = 2;
			this.m_gbRetorno.TabStop = false;
			this.m_gbRetorno.Text = "Retorno";
			// 
			// m_tvRetorno
			// 
			this.m_tvRetorno.ImageIndex = -1;
			this.m_tvRetorno.Location = new System.Drawing.Point(8, 16);
			this.m_tvRetorno.Name = "m_tvRetorno";
			this.m_tvRetorno.SelectedImageIndex = -1;
			this.m_tvRetorno.Size = new System.Drawing.Size(832, 208);
			this.m_tvRetorno.TabIndex = 3;
			// 
			// m_gbBD
			// 
			this.m_gbBD.Controls.Add(this.m_gbConfiguracao);
			this.m_gbBD.Controls.Add(this.m_gbTipoAcesso);
			this.m_gbBD.Controls.Add(this.m_gbLogin);
			this.m_gbBD.Location = new System.Drawing.Point(8, 16);
			this.m_gbBD.Name = "m_gbBD";
			this.m_gbBD.Size = new System.Drawing.Size(848, 232);
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
			this.m_txtDataBaseName.Text = "JP";
			// 
			// m_gbTipoAcesso
			// 
			this.m_gbTipoAcesso.Controls.Add(this.m_txtPortMySql);
			this.m_gbTipoAcesso.Controls.Add(this.label2);
			this.m_gbTipoAcesso.Controls.Add(this.m_txtPortSqlServer);
			this.m_gbTipoAcesso.Controls.Add(this.m_lbPortSqlServer);
			this.m_gbTipoAcesso.Controls.Add(this.m_rbSqlServer);
			this.m_gbTipoAcesso.Controls.Add(this.m_btReset);
			this.m_gbTipoAcesso.Controls.Add(this.m_rbMySql);
			this.m_gbTipoAcesso.Controls.Add(this.m_rbJet40);
			this.m_gbTipoAcesso.Location = new System.Drawing.Point(7, 94);
			this.m_gbTipoAcesso.Name = "m_gbTipoAcesso";
			this.m_gbTipoAcesso.Size = new System.Drawing.Size(833, 128);
			this.m_gbTipoAcesso.TabIndex = 10;
			this.m_gbTipoAcesso.TabStop = false;
			this.m_gbTipoAcesso.Text = "Tipo Acesso";
			// 
			// m_txtPortMySql
			// 
			this.m_txtPortMySql.Location = new System.Drawing.Point(164, 23);
			this.m_txtPortMySql.Name = "m_txtPortMySql";
			this.m_txtPortMySql.Size = new System.Drawing.Size(74, 20);
			this.m_txtPortMySql.TabIndex = 12;
			this.m_txtPortMySql.Text = "3306";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(124, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "Port:";
			// 
			// m_txtPortSqlServer
			// 
			this.m_txtPortSqlServer.Location = new System.Drawing.Point(164, 47);
			this.m_txtPortSqlServer.Name = "m_txtPortSqlServer";
			this.m_txtPortSqlServer.Size = new System.Drawing.Size(74, 20);
			this.m_txtPortSqlServer.TabIndex = 10;
			this.m_txtPortSqlServer.Text = "1433";
			// 
			// m_lbPortSqlServer
			// 
			this.m_lbPortSqlServer.Location = new System.Drawing.Point(126, 50);
			this.m_lbPortSqlServer.Name = "m_lbPortSqlServer";
			this.m_lbPortSqlServer.Size = new System.Drawing.Size(34, 16);
			this.m_lbPortSqlServer.TabIndex = 9;
			this.m_lbPortSqlServer.Text = "Port:";
			// 
			// m_rbSqlServer
			// 
			this.m_rbSqlServer.Checked = true;
			this.m_rbSqlServer.Location = new System.Drawing.Point(24, 49);
			this.m_rbSqlServer.Name = "m_rbSqlServer";
			this.m_rbSqlServer.Size = new System.Drawing.Size(96, 16);
			this.m_rbSqlServer.TabIndex = 7;
			this.m_rbSqlServer.TabStop = true;
			this.m_rbSqlServer.Text = "SqlServer";
			// 
			// m_btReset
			// 
			this.m_btReset.Location = new System.Drawing.Point(7, 89);
			this.m_btReset.Name = "m_btReset";
			this.m_btReset.Size = new System.Drawing.Size(96, 32);
			this.m_btReset.TabIndex = 6;
			this.m_btReset.Text = "Reset Parametros";
			this.m_btReset.Click += new System.EventHandler(this.m_btReset_Click);
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
			this.m_gbLogin.Size = new System.Drawing.Size(444, 80);
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
			this.m_txtPassword.Text = "JP";
			// 
			// m_txtUser
			// 
			this.m_txtUser.Location = new System.Drawing.Point(62, 34);
			this.m_txtUser.Name = "m_txtUser";
			this.m_txtUser.Size = new System.Drawing.Size(122, 20);
			this.m_txtUser.TabIndex = 7;
			this.m_txtUser.Text = "JP";
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
			// m_gbMoeda
			// 
			this.m_gbMoeda.Controls.Add(this.m_btShowDialog);
			this.m_gbMoeda.Controls.Add(this.m_btCarregaDados);
			this.m_gbMoeda.Location = new System.Drawing.Point(8, 328);
			this.m_gbMoeda.Name = "m_gbMoeda";
			this.m_gbMoeda.Size = new System.Drawing.Size(848, 62);
			this.m_gbMoeda.TabIndex = 1;
			this.m_gbMoeda.TabStop = false;
			this.m_gbMoeda.Text = "Negócio";
			// 
			// m_btShowDialog
			// 
			this.m_btShowDialog.Location = new System.Drawing.Point(111, 18);
			this.m_btShowDialog.Name = "m_btShowDialog";
			this.m_btShowDialog.Size = new System.Drawing.Size(96, 32);
			this.m_btShowDialog.TabIndex = 3;
			this.m_btShowDialog.Text = "Show Dialog";
			this.m_btShowDialog.Click += new System.EventHandler(this.m_btShowDialog_Click);
			// 
			// m_btCarregaDados
			// 
			this.m_btCarregaDados.Location = new System.Drawing.Point(9, 19);
			this.m_btCarregaDados.Name = "m_btCarregaDados";
			this.m_btCarregaDados.Size = new System.Drawing.Size(96, 32);
			this.m_btCarregaDados.TabIndex = 2;
			this.m_btCarregaDados.Text = "Carrega Dados";
			this.m_btCarregaDados.Click += new System.EventHandler(this.m_btCarregaDados_Click);
			// 
			// m_ilBandeiras
			// 
			this.m_ilBandeiras.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilBandeiras.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(880, 638);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Area Produtos";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbParametros.ResumeLayout(false);
			this.m_gbRetorno.ResumeLayout(false);
			this.m_gbBD.ResumeLayout(false);
			this.m_gbConfiguracao.ResumeLayout(false);
			this.m_gbTipoAcesso.ResumeLayout(false);
			this.m_gbLogin.ResumeLayout(false);
			this.m_gbMoeda.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
		private void Form1_Load(object sender, System.EventArgs e)
		{
			RefreshParametros();
		}
		private void m_btReset_Click(object sender, System.EventArgs e)
		{
			RefreshParametros();
		}

		#endregion

		#region DataBase
		private void CreateDataBase()
		{
			if (m_rbJet40.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessOleDbJet40(ref m_cls_tre_tratadorErro,m_txtPath.Text + m_txtDataBaseName.Text + ".mdb",m_txtUser.Text,m_txtPassword.Text);
			if (m_rbMySql.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtPortMySql.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);
			if (m_rbSqlServer.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessSqlServer(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtPortSqlServer.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);
			m_cls_dba_ConnectionBD.ShowDialogsErrors = true;
			m_cls_dba_ConnectionBD.SystemMode = mdlDataBaseAccess.Mode.Developer;

		}
		#endregion

		#region Parametros
		private void RefreshParametros()
		{
			CreateDataBase();
			RefreshIdiomas();
			RefreshRelatorios();
		}
		#endregion
		#region Idioma
		private void RefreshIdiomas()
		{
			m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
			mdlDataBaseAccess.Tabelas.XsdTbIdiomas typDatSetIdiomas = m_cls_dba_ConnectionBD.GetTbIdiomas(null,null,null,null,null);            
			mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow dtrwIdioma = null;
			m_cbIdioma.Clear();
			for (int nCont = 0; nCont < typDatSetIdiomas.tbIdiomas.Rows.Count;nCont++)
			{
				dtrwIdioma = (mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow)typDatSetIdiomas.tbIdiomas.Rows[nCont];
				m_cbIdioma.AddItem(dtrwIdioma.mstrIdioma,dtrwIdioma.idIdioma);
			}
			m_cbIdioma.Text = "Português";
		}
		#endregion
		#region Relatorios
		private void RefreshRelatorios()
		{
			m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioTipo typDatSetTbRelatorioTipo = m_cls_dba_ConnectionBD.GetTbRelatorioTipo(null,null,null,null,null);            
			mdlDataBaseAccess.Tabelas.XsdTbRelatorioTipo.tbRelatorioTipoRow dtrwRelatorio = null;
			m_cbRelatorio.Clear();
			for (int nCont = 0; nCont < typDatSetTbRelatorioTipo.tbRelatorioTipo.Rows.Count;nCont++)
			{
				dtrwRelatorio = (mdlDataBaseAccess.Tabelas.XsdTbRelatorioTipo.tbRelatorioTipoRow)typDatSetTbRelatorioTipo.tbRelatorioTipo.Rows[nCont];
				m_cbRelatorio.AddItem(dtrwRelatorio.strNomeRelatorio,dtrwRelatorio.nIdTipo);
			}
			m_cbRelatorio.AddItem("Romaneio - Volume",25);
			m_cbRelatorio.AddItem("Romaneio - Simplificado",26);
			m_cbRelatorio.AddItem("Bordero Secundario",24);
			m_cbRelatorio.AddItem("FormA",30);

			m_cbRelatorio.Text = "Fatura Comercial";
		}
		#endregion

		#region Preenchimento da TreeView 
		private void PreencheTreeView(ref System.Collections.ArrayList arlUtilizar)
		{
			System.Windows.Forms.TreeNode tvnNodoColunaAtual,tvnNodoRegistroAtual;
			mdlRelatoriosCallBackAreaProdutos.DataStruct structData;

	        // Limpando a Area Retorno
			m_tvRetorno.Nodes.Clear();

			// Verificando se o retorno da lista nao eh vazio 
			if (arlUtilizar != null)
			{ 
				for (int nCont = 0; nCont < arlUtilizar.Count;nCont++)
				{
					tvnNodoColunaAtual = m_tvRetorno.Nodes.Add(((System.Collections.ArrayList)arlUtilizar[nCont])[0].ToString());
					for (int nContRegistros = 1; nContRegistros < ((System.Collections.ArrayList)arlUtilizar[nCont]).Count;nContRegistros++)
					{
						structData = (mdlRelatoriosCallBackAreaProdutos.DataStruct)((System.Collections.ArrayList)arlUtilizar[nCont])[nContRegistros];
						tvnNodoRegistroAtual = tvnNodoColunaAtual.Nodes.Add(nContRegistros + " - " + structData.strText);
						tvnNodoRegistroAtual.Nodes.Add(structData.nHeight.ToString());
						tvnNodoRegistroAtual.Nodes.Add(structData.nWidth.ToString());
						if (structData.fntText == null)
							tvnNodoRegistroAtual.Nodes.Add("Nothing");
						else
							tvnNodoRegistroAtual.Nodes.Add(structData.fntText.Name.ToString());
					}
				}
			}
		}
		#endregion

		#region Negocio 
		private void m_btCarregaDados_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			// Relatorio
			Object obj = m_cbRelatorio.ReturnObjectSelectedItem();
			if (obj != null)
			{
				int nIdRelatorio = Int32.Parse(obj.ToString());
				mdlRelatoriosCallBackAreaProdutos.clsRelatoriosCallBackAreaProdutos callBack = new mdlRelatoriosCallBackAreaProdutos.clsRelatoriosCallBackAreaProdutos(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
				callBack.ListaIDsCamposAreaProdutos = new int[]{197,297}; 
				System.DateTime dttmAntes = System.DateTime.Now;
				System.Collections.ArrayList arlRetorno = callBack.arlRetornaDadosAreaProdutos(Int32.Parse(m_txtIdExportador.Text),m_txtIdCodigo.Text,nIdRelatorio);
				this.Text = "Tempo = " + System.DateTime.Now.Subtract(dttmAntes).TotalMilliseconds.ToString() + " Milisegundos";
				PreencheTreeView(ref arlRetorno);
			}
		}

		private void m_btShowDialog_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			// Relatorio
			Object obj = m_cbRelatorio.ReturnObjectSelectedItem();
			if (obj != null)
			{
				int nIdRelatorio = Int32.Parse(obj.ToString());
				int nStatus = 0;
				mdlRelatoriosCallBackAreaProdutos.clsRelatoriosCallBackAreaProdutos callBack = new mdlRelatoriosCallBackAreaProdutos.clsRelatoriosCallBackAreaProdutos(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
				System.DateTime dttmAntes = System.DateTime.Now;
				System.Collections.ArrayList arlRetorno = callBack.arlShowDialog(Int32.Parse(m_txtIdExportador.Text),m_txtIdCodigo.Text,nIdRelatorio,ref nStatus);
				this.Text = "Tempo = " + System.DateTime.Now.Subtract(dttmAntes).TotalMilliseconds.ToString() + " Milisegundos";
	            m_tvRetorno.Nodes.Clear();
				m_tvRetorno.Nodes.Add(nStatus.ToString());

			}
		}
		#endregion
	}
}

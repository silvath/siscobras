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

			mdlControladoraWindowsServices.clsManagerWSSiscoMensagem m_cls_mws_SiscoMensage = null;

			private System.Windows.Forms.GroupBox m_gbGeral;
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
			private System.Windows.Forms.RadioButton m_rbSqlServer;
			private System.Windows.Forms.TextBox m_txtPortSqlServer;
			private System.Windows.Forms.Label m_lbPortSqlServer;
			private System.Windows.Forms.CheckBox m_ckLog;
			private System.Windows.Forms.GroupBox m_gbWindowsService;
			private System.Windows.Forms.Button m_btWSSiscoMensagemStart;
			private System.Windows.Forms.GroupBox m_gbWindowsServiceInit;
			private System.Windows.Forms.GroupBox m_gbWindowsServiceState;
			private System.Windows.Forms.Button m_btWSSiscoMensagemInitNever;
			private System.Windows.Forms.Button m_btWSSiscoMensagemInitSiscobras;
			private System.Windows.Forms.Button m_btWSSiscoMensagemInitComputer;
			private System.Windows.Forms.Label m_lbInit;
			private System.Windows.Forms.GroupBox m_gbWindowsServiceInstall;
			private System.Windows.Forms.Label m_lbInstaled;
			private System.Windows.Forms.Button m_btWSSiscoMensagemInstaledInstall;
			private System.Windows.Forms.Button m_btWSSiscoMensagemInstaledUninstall;
			private System.Windows.Forms.Button m_btWSSiscoMensagemStop;
			private System.Windows.Forms.Button m_btWSSiscoMensagemPause;
			private System.Windows.Forms.Label m_lbState;
			private System.Windows.Forms.Button m_btWSSiscoMensagemContinue;
		private System.Windows.Forms.Timer m_tSiscoMensagem;
		private System.Windows.Forms.Button m_btWSSiscoMensagemClose;
		private System.Windows.Forms.GroupBox m_gbWindowsServiceStatic;
		private System.Windows.Forms.Button m_btWindowsServiceStaticSupport;
		private System.Windows.Forms.CheckBox m_ckAlwaysApp;
		private System.Windows.Forms.GroupBox m_gbControladoraMensagens;
		private System.Windows.Forms.Label m_lbControladoraMensagensState;
		private System.Windows.Forms.Button m_btControladoraMensagensContinue;
		private System.Windows.Forms.Button m_btControladoraMensagensStart;
		private System.Windows.Forms.Button m_btControladoraMensagensStop;
		private System.Windows.Forms.Button m_btControladoraMensagensPause;
		private System.Windows.Forms.Button m_btControladoraMensagensClose;
		private System.Windows.Forms.Button m_btInstallUtil;
			private System.ComponentModel.IContainer components = null;
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
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_lbRetorno = new System.Windows.Forms.Label();
			this.m_gbMoeda = new System.Windows.Forms.GroupBox();
			this.m_gbControladoraMensagens = new System.Windows.Forms.GroupBox();
			this.m_btControladoraMensagensContinue = new System.Windows.Forms.Button();
			this.m_btControladoraMensagensStart = new System.Windows.Forms.Button();
			this.m_btControladoraMensagensStop = new System.Windows.Forms.Button();
			this.m_btControladoraMensagensPause = new System.Windows.Forms.Button();
			this.m_btControladoraMensagensClose = new System.Windows.Forms.Button();
			this.m_lbControladoraMensagensState = new System.Windows.Forms.Label();
			this.m_gbWindowsServiceStatic = new System.Windows.Forms.GroupBox();
			this.m_btInstallUtil = new System.Windows.Forms.Button();
			this.m_btWindowsServiceStaticSupport = new System.Windows.Forms.Button();
			this.m_gbWindowsService = new System.Windows.Forms.GroupBox();
			this.m_gbWindowsServiceInstall = new System.Windows.Forms.GroupBox();
			this.m_lbInstaled = new System.Windows.Forms.Label();
			this.m_btWSSiscoMensagemInstaledInstall = new System.Windows.Forms.Button();
			this.m_btWSSiscoMensagemInstaledUninstall = new System.Windows.Forms.Button();
			this.m_gbWindowsServiceState = new System.Windows.Forms.GroupBox();
			this.m_btWSSiscoMensagemContinue = new System.Windows.Forms.Button();
			this.m_lbState = new System.Windows.Forms.Label();
			this.m_btWSSiscoMensagemStart = new System.Windows.Forms.Button();
			this.m_btWSSiscoMensagemStop = new System.Windows.Forms.Button();
			this.m_btWSSiscoMensagemPause = new System.Windows.Forms.Button();
			this.m_btWSSiscoMensagemClose = new System.Windows.Forms.Button();
			this.m_gbWindowsServiceInit = new System.Windows.Forms.GroupBox();
			this.m_lbInit = new System.Windows.Forms.Label();
			this.m_btWSSiscoMensagemInitNever = new System.Windows.Forms.Button();
			this.m_btWSSiscoMensagemInitSiscobras = new System.Windows.Forms.Button();
			this.m_btWSSiscoMensagemInitComputer = new System.Windows.Forms.Button();
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
			this.m_ckLog = new System.Windows.Forms.CheckBox();
			this.m_ckAlwaysApp = new System.Windows.Forms.CheckBox();
			this.m_gbLogin = new System.Windows.Forms.GroupBox();
			this.m_txtHost = new System.Windows.Forms.TextBox();
			this.m_lbHost = new System.Windows.Forms.Label();
			this.m_txtPassword = new System.Windows.Forms.TextBox();
			this.m_txtUser = new System.Windows.Forms.TextBox();
			this.m_lbPassword = new System.Windows.Forms.Label();
			this.m_lbUser = new System.Windows.Forms.Label();
			this.m_tSiscoMensagem = new System.Windows.Forms.Timer(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbRetorno.SuspendLayout();
			this.m_gbMoeda.SuspendLayout();
			this.m_gbControladoraMensagens.SuspendLayout();
			this.m_gbWindowsServiceStatic.SuspendLayout();
			this.m_gbWindowsService.SuspendLayout();
			this.m_gbWindowsServiceInstall.SuspendLayout();
			this.m_gbWindowsServiceState.SuspendLayout();
			this.m_gbWindowsServiceInit.SuspendLayout();
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
			this.m_gbGeral.Controls.Add(this.m_gbRetorno);
			this.m_gbGeral.Controls.Add(this.m_gbMoeda);
			this.m_gbGeral.Controls.Add(this.m_gbBD);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(636, 602);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbRetorno
			// 
			this.m_gbRetorno.Controls.Add(this.m_txtRetorno);
			this.m_gbRetorno.Controls.Add(this.m_lbRetorno);
			this.m_gbRetorno.Location = new System.Drawing.Point(8, 547);
			this.m_gbRetorno.Name = "m_gbRetorno";
			this.m_gbRetorno.Size = new System.Drawing.Size(624, 48);
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
			this.m_gbMoeda.Controls.Add(this.m_gbControladoraMensagens);
			this.m_gbMoeda.Controls.Add(this.m_gbWindowsServiceStatic);
			this.m_gbMoeda.Controls.Add(this.m_gbWindowsService);
			this.m_gbMoeda.Location = new System.Drawing.Point(8, 200);
			this.m_gbMoeda.Name = "m_gbMoeda";
			this.m_gbMoeda.Size = new System.Drawing.Size(624, 344);
			this.m_gbMoeda.TabIndex = 1;
			this.m_gbMoeda.TabStop = false;
			this.m_gbMoeda.Text = "Negocio";
			// 
			// m_gbControladoraMensagens
			// 
			this.m_gbControladoraMensagens.Controls.Add(this.m_btControladoraMensagensContinue);
			this.m_gbControladoraMensagens.Controls.Add(this.m_btControladoraMensagensStart);
			this.m_gbControladoraMensagens.Controls.Add(this.m_btControladoraMensagensStop);
			this.m_gbControladoraMensagens.Controls.Add(this.m_btControladoraMensagensPause);
			this.m_gbControladoraMensagens.Controls.Add(this.m_btControladoraMensagensClose);
			this.m_gbControladoraMensagens.Controls.Add(this.m_lbControladoraMensagensState);
			this.m_gbControladoraMensagens.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbControladoraMensagens.Location = new System.Drawing.Point(7, 275);
			this.m_gbControladoraMensagens.Name = "m_gbControladoraMensagens";
			this.m_gbControladoraMensagens.Size = new System.Drawing.Size(609, 61);
			this.m_gbControladoraMensagens.TabIndex = 15;
			this.m_gbControladoraMensagens.TabStop = false;
			this.m_gbControladoraMensagens.Text = "Controladora Mensagens";
			// 
			// m_btControladoraMensagensContinue
			// 
			this.m_btControladoraMensagensContinue.Location = new System.Drawing.Point(318, 16);
			this.m_btControladoraMensagensContinue.Name = "m_btControladoraMensagensContinue";
			this.m_btControladoraMensagensContinue.Size = new System.Drawing.Size(80, 40);
			this.m_btControladoraMensagensContinue.TabIndex = 22;
			this.m_btControladoraMensagensContinue.Text = "Continue";
			this.m_btControladoraMensagensContinue.Click += new System.EventHandler(this.m_btControladoraMensagensContinue_Click);
			// 
			// m_btControladoraMensagensStart
			// 
			this.m_btControladoraMensagensStart.Location = new System.Drawing.Point(150, 16);
			this.m_btControladoraMensagensStart.Name = "m_btControladoraMensagensStart";
			this.m_btControladoraMensagensStart.Size = new System.Drawing.Size(80, 40);
			this.m_btControladoraMensagensStart.TabIndex = 18;
			this.m_btControladoraMensagensStart.Text = "Start";
			this.m_btControladoraMensagensStart.Click += new System.EventHandler(this.m_btControladoraMensagensStart_Click);
			// 
			// m_btControladoraMensagensStop
			// 
			this.m_btControladoraMensagensStop.Location = new System.Drawing.Point(401, 15);
			this.m_btControladoraMensagensStop.Name = "m_btControladoraMensagensStop";
			this.m_btControladoraMensagensStop.Size = new System.Drawing.Size(80, 40);
			this.m_btControladoraMensagensStop.TabIndex = 19;
			this.m_btControladoraMensagensStop.Text = "Stop";
			this.m_btControladoraMensagensStop.Click += new System.EventHandler(this.m_btControladoraMensagensStop_Click);
			// 
			// m_btControladoraMensagensPause
			// 
			this.m_btControladoraMensagensPause.Location = new System.Drawing.Point(233, 16);
			this.m_btControladoraMensagensPause.Name = "m_btControladoraMensagensPause";
			this.m_btControladoraMensagensPause.Size = new System.Drawing.Size(80, 40);
			this.m_btControladoraMensagensPause.TabIndex = 20;
			this.m_btControladoraMensagensPause.Text = "Pause";
			this.m_btControladoraMensagensPause.Click += new System.EventHandler(this.m_btControladoraMensagensPause_Click);
			// 
			// m_btControladoraMensagensClose
			// 
			this.m_btControladoraMensagensClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btControladoraMensagensClose.Location = new System.Drawing.Point(486, 15);
			this.m_btControladoraMensagensClose.Name = "m_btControladoraMensagensClose";
			this.m_btControladoraMensagensClose.Size = new System.Drawing.Size(80, 40);
			this.m_btControladoraMensagensClose.TabIndex = 21;
			this.m_btControladoraMensagensClose.Text = "Close";
			this.m_btControladoraMensagensClose.Click += new System.EventHandler(this.m_btControladoraMensagensClose_Click);
			// 
			// m_lbControladoraMensagensState
			// 
			this.m_lbControladoraMensagensState.Location = new System.Drawing.Point(13, 23);
			this.m_lbControladoraMensagensState.Name = "m_lbControladoraMensagensState";
			this.m_lbControladoraMensagensState.Size = new System.Drawing.Size(111, 16);
			this.m_lbControladoraMensagensState.TabIndex = 17;
			// 
			// m_gbWindowsServiceStatic
			// 
			this.m_gbWindowsServiceStatic.Controls.Add(this.m_btInstallUtil);
			this.m_gbWindowsServiceStatic.Controls.Add(this.m_btWindowsServiceStaticSupport);
			this.m_gbWindowsServiceStatic.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbWindowsServiceStatic.Location = new System.Drawing.Point(8, 16);
			this.m_gbWindowsServiceStatic.Name = "m_gbWindowsServiceStatic";
			this.m_gbWindowsServiceStatic.Size = new System.Drawing.Size(608, 64);
			this.m_gbWindowsServiceStatic.TabIndex = 14;
			this.m_gbWindowsServiceStatic.TabStop = false;
			this.m_gbWindowsServiceStatic.Text = "Windows Service";
			// 
			// m_btInstallUtil
			// 
			this.m_btInstallUtil.Location = new System.Drawing.Point(8, 16);
			this.m_btInstallUtil.Name = "m_btInstallUtil";
			this.m_btInstallUtil.Size = new System.Drawing.Size(80, 40);
			this.m_btInstallUtil.TabIndex = 11;
			this.m_btInstallUtil.Text = "InstallUtil";
			this.m_btInstallUtil.Click += new System.EventHandler(this.m_btInstallUtil_Click);
			// 
			// m_btWindowsServiceStaticSupport
			// 
			this.m_btWindowsServiceStaticSupport.Location = new System.Drawing.Point(96, 16);
			this.m_btWindowsServiceStaticSupport.Name = "m_btWindowsServiceStaticSupport";
			this.m_btWindowsServiceStaticSupport.Size = new System.Drawing.Size(80, 40);
			this.m_btWindowsServiceStaticSupport.TabIndex = 10;
			this.m_btWindowsServiceStaticSupport.Text = "Support";
			this.m_btWindowsServiceStaticSupport.Click += new System.EventHandler(this.m_btWindowsServiceStaticSupport_Click);
			// 
			// m_gbWindowsService
			// 
			this.m_gbWindowsService.Controls.Add(this.m_gbWindowsServiceInstall);
			this.m_gbWindowsService.Controls.Add(this.m_gbWindowsServiceState);
			this.m_gbWindowsService.Controls.Add(this.m_gbWindowsServiceInit);
			this.m_gbWindowsService.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbWindowsService.Location = new System.Drawing.Point(8, 85);
			this.m_gbWindowsService.Name = "m_gbWindowsService";
			this.m_gbWindowsService.Size = new System.Drawing.Size(608, 191);
			this.m_gbWindowsService.TabIndex = 13;
			this.m_gbWindowsService.TabStop = false;
			this.m_gbWindowsService.Text = "Windows Service - SiscoMensagem";
			// 
			// m_gbWindowsServiceInstall
			// 
			this.m_gbWindowsServiceInstall.Controls.Add(this.m_lbInstaled);
			this.m_gbWindowsServiceInstall.Controls.Add(this.m_btWSSiscoMensagemInstaledInstall);
			this.m_gbWindowsServiceInstall.Controls.Add(this.m_btWSSiscoMensagemInstaledUninstall);
			this.m_gbWindowsServiceInstall.Location = new System.Drawing.Point(8, 16);
			this.m_gbWindowsServiceInstall.Name = "m_gbWindowsServiceInstall";
			this.m_gbWindowsServiceInstall.Size = new System.Drawing.Size(592, 56);
			this.m_gbWindowsServiceInstall.TabIndex = 14;
			this.m_gbWindowsServiceInstall.TabStop = false;
			this.m_gbWindowsServiceInstall.Text = "Install";
			// 
			// m_lbInstaled
			// 
			this.m_lbInstaled.Location = new System.Drawing.Point(15, 24);
			this.m_lbInstaled.Name = "m_lbInstaled";
			this.m_lbInstaled.Size = new System.Drawing.Size(97, 16);
			this.m_lbInstaled.TabIndex = 15;
			// 
			// m_btWSSiscoMensagemInstaledInstall
			// 
			this.m_btWSSiscoMensagemInstaledInstall.Location = new System.Drawing.Point(203, 10);
			this.m_btWSSiscoMensagemInstaledInstall.Name = "m_btWSSiscoMensagemInstaledInstall";
			this.m_btWSSiscoMensagemInstaledInstall.Size = new System.Drawing.Size(106, 40);
			this.m_btWSSiscoMensagemInstaledInstall.TabIndex = 12;
			this.m_btWSSiscoMensagemInstaledInstall.Text = "Install";
			this.m_btWSSiscoMensagemInstaledInstall.Click += new System.EventHandler(this.m_btWSSiscoMensagemInstaledInstall_Click);
			// 
			// m_btWSSiscoMensagemInstaledUninstall
			// 
			this.m_btWSSiscoMensagemInstaledUninstall.Location = new System.Drawing.Point(315, 10);
			this.m_btWSSiscoMensagemInstaledUninstall.Name = "m_btWSSiscoMensagemInstaledUninstall";
			this.m_btWSSiscoMensagemInstaledUninstall.Size = new System.Drawing.Size(106, 40);
			this.m_btWSSiscoMensagemInstaledUninstall.TabIndex = 13;
			this.m_btWSSiscoMensagemInstaledUninstall.Text = "Uninstall";
			this.m_btWSSiscoMensagemInstaledUninstall.Click += new System.EventHandler(this.m_btWSSiscoMensagemInstaledUninstall_Click);
			// 
			// m_gbWindowsServiceState
			// 
			this.m_gbWindowsServiceState.Controls.Add(this.m_btWSSiscoMensagemContinue);
			this.m_gbWindowsServiceState.Controls.Add(this.m_lbState);
			this.m_gbWindowsServiceState.Controls.Add(this.m_btWSSiscoMensagemStart);
			this.m_gbWindowsServiceState.Controls.Add(this.m_btWSSiscoMensagemStop);
			this.m_gbWindowsServiceState.Controls.Add(this.m_btWSSiscoMensagemPause);
			this.m_gbWindowsServiceState.Controls.Add(this.m_btWSSiscoMensagemClose);
			this.m_gbWindowsServiceState.Location = new System.Drawing.Point(8, 128);
			this.m_gbWindowsServiceState.Name = "m_gbWindowsServiceState";
			this.m_gbWindowsServiceState.Size = new System.Drawing.Size(592, 56);
			this.m_gbWindowsServiceState.TabIndex = 13;
			this.m_gbWindowsServiceState.TabStop = false;
			this.m_gbWindowsServiceState.Text = "State";
			// 
			// m_btWSSiscoMensagemContinue
			// 
			this.m_btWSSiscoMensagemContinue.Location = new System.Drawing.Point(296, 11);
			this.m_btWSSiscoMensagemContinue.Name = "m_btWSSiscoMensagemContinue";
			this.m_btWSSiscoMensagemContinue.Size = new System.Drawing.Size(80, 40);
			this.m_btWSSiscoMensagemContinue.TabIndex = 17;
			this.m_btWSSiscoMensagemContinue.Text = "Continue";
			this.m_btWSSiscoMensagemContinue.Click += new System.EventHandler(this.m_btWSSiscoMensagemContinue_Click);
			// 
			// m_lbState
			// 
			this.m_lbState.Location = new System.Drawing.Point(9, 24);
			this.m_lbState.Name = "m_lbState";
			this.m_lbState.Size = new System.Drawing.Size(111, 16);
			this.m_lbState.TabIndex = 16;
			// 
			// m_btWSSiscoMensagemStart
			// 
			this.m_btWSSiscoMensagemStart.Location = new System.Drawing.Point(128, 11);
			this.m_btWSSiscoMensagemStart.Name = "m_btWSSiscoMensagemStart";
			this.m_btWSSiscoMensagemStart.Size = new System.Drawing.Size(80, 40);
			this.m_btWSSiscoMensagemStart.TabIndex = 9;
			this.m_btWSSiscoMensagemStart.Text = "Start";
			this.m_btWSSiscoMensagemStart.Click += new System.EventHandler(this.m_btWSSiscoMensagemStart_Click);
			// 
			// m_btWSSiscoMensagemStop
			// 
			this.m_btWSSiscoMensagemStop.Location = new System.Drawing.Point(380, 10);
			this.m_btWSSiscoMensagemStop.Name = "m_btWSSiscoMensagemStop";
			this.m_btWSSiscoMensagemStop.Size = new System.Drawing.Size(80, 40);
			this.m_btWSSiscoMensagemStop.TabIndex = 10;
			this.m_btWSSiscoMensagemStop.Text = "Stop";
			this.m_btWSSiscoMensagemStop.Click += new System.EventHandler(this.m_btWSSiscoMensagemStop_Click);
			// 
			// m_btWSSiscoMensagemPause
			// 
			this.m_btWSSiscoMensagemPause.Location = new System.Drawing.Point(211, 11);
			this.m_btWSSiscoMensagemPause.Name = "m_btWSSiscoMensagemPause";
			this.m_btWSSiscoMensagemPause.Size = new System.Drawing.Size(80, 40);
			this.m_btWSSiscoMensagemPause.TabIndex = 11;
			this.m_btWSSiscoMensagemPause.Text = "Pause";
			this.m_btWSSiscoMensagemPause.Click += new System.EventHandler(this.m_btWSSiscoMensagemPause_Click);
			// 
			// m_btWSSiscoMensagemClose
			// 
			this.m_btWSSiscoMensagemClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btWSSiscoMensagemClose.Location = new System.Drawing.Point(465, 10);
			this.m_btWSSiscoMensagemClose.Name = "m_btWSSiscoMensagemClose";
			this.m_btWSSiscoMensagemClose.Size = new System.Drawing.Size(80, 40);
			this.m_btWSSiscoMensagemClose.TabIndex = 14;
			this.m_btWSSiscoMensagemClose.Text = "Close";
			this.m_btWSSiscoMensagemClose.Click += new System.EventHandler(this.m_btWSSiscoMensagemClose_Click);
			// 
			// m_gbWindowsServiceInit
			// 
			this.m_gbWindowsServiceInit.Controls.Add(this.m_lbInit);
			this.m_gbWindowsServiceInit.Controls.Add(this.m_btWSSiscoMensagemInitNever);
			this.m_gbWindowsServiceInit.Controls.Add(this.m_btWSSiscoMensagemInitSiscobras);
			this.m_gbWindowsServiceInit.Controls.Add(this.m_btWSSiscoMensagemInitComputer);
			this.m_gbWindowsServiceInit.Location = new System.Drawing.Point(8, 72);
			this.m_gbWindowsServiceInit.Name = "m_gbWindowsServiceInit";
			this.m_gbWindowsServiceInit.Size = new System.Drawing.Size(592, 56);
			this.m_gbWindowsServiceInit.TabIndex = 12;
			this.m_gbWindowsServiceInit.TabStop = false;
			this.m_gbWindowsServiceInit.Text = "Init";
			// 
			// m_lbInit
			// 
			this.m_lbInit.Location = new System.Drawing.Point(15, 24);
			this.m_lbInit.Name = "m_lbInit";
			this.m_lbInit.Size = new System.Drawing.Size(97, 16);
			this.m_lbInit.TabIndex = 15;
			// 
			// m_btWSSiscoMensagemInitNever
			// 
			this.m_btWSSiscoMensagemInitNever.Location = new System.Drawing.Point(203, 10);
			this.m_btWSSiscoMensagemInitNever.Name = "m_btWSSiscoMensagemInitNever";
			this.m_btWSSiscoMensagemInitNever.Size = new System.Drawing.Size(106, 40);
			this.m_btWSSiscoMensagemInitNever.TabIndex = 12;
			this.m_btWSSiscoMensagemInitNever.Text = "Never";
			this.m_btWSSiscoMensagemInitNever.Click += new System.EventHandler(this.m_btWSSiscoMensagemInitNever_Click);
			// 
			// m_btWSSiscoMensagemInitSiscobras
			// 
			this.m_btWSSiscoMensagemInitSiscobras.Location = new System.Drawing.Point(315, 10);
			this.m_btWSSiscoMensagemInitSiscobras.Name = "m_btWSSiscoMensagemInitSiscobras";
			this.m_btWSSiscoMensagemInitSiscobras.Size = new System.Drawing.Size(106, 40);
			this.m_btWSSiscoMensagemInitSiscobras.TabIndex = 13;
			this.m_btWSSiscoMensagemInitSiscobras.Text = "Siscobras";
			this.m_btWSSiscoMensagemInitSiscobras.Click += new System.EventHandler(this.m_btWSSiscoMensagemInitSiscobras_Click);
			// 
			// m_btWSSiscoMensagemInitComputer
			// 
			this.m_btWSSiscoMensagemInitComputer.Location = new System.Drawing.Point(427, 10);
			this.m_btWSSiscoMensagemInitComputer.Name = "m_btWSSiscoMensagemInitComputer";
			this.m_btWSSiscoMensagemInitComputer.Size = new System.Drawing.Size(106, 40);
			this.m_btWSSiscoMensagemInitComputer.TabIndex = 14;
			this.m_btWSSiscoMensagemInitComputer.Text = "Computer";
			this.m_btWSSiscoMensagemInitComputer.Click += new System.EventHandler(this.m_btWSSiscoMensagemInitComputer_Click);
			// 
			// m_gbBD
			// 
			this.m_gbBD.Controls.Add(this.m_gbConfiguracao);
			this.m_gbBD.Controls.Add(this.m_gbTipoAcesso);
			this.m_gbBD.Controls.Add(this.m_gbLogin);
			this.m_gbBD.Location = new System.Drawing.Point(8, 16);
			this.m_gbBD.Name = "m_gbBD";
			this.m_gbBD.Size = new System.Drawing.Size(624, 184);
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
			this.m_gbTipoAcesso.Controls.Add(this.m_ckLog);
			this.m_gbTipoAcesso.Controls.Add(this.m_ckAlwaysApp);
			this.m_gbTipoAcesso.Location = new System.Drawing.Point(7, 94);
			this.m_gbTipoAcesso.Name = "m_gbTipoAcesso";
			this.m_gbTipoAcesso.Size = new System.Drawing.Size(609, 82);
			this.m_gbTipoAcesso.TabIndex = 10;
			this.m_gbTipoAcesso.TabStop = false;
			this.m_gbTipoAcesso.Text = "Tipo Acesso";
			// 
			// m_txtPortSqlServer
			// 
			this.m_txtPortSqlServer.Location = new System.Drawing.Point(125, 45);
			this.m_txtPortSqlServer.Name = "m_txtPortSqlServer";
			this.m_txtPortSqlServer.Size = new System.Drawing.Size(43, 20);
			this.m_txtPortSqlServer.TabIndex = 10;
			this.m_txtPortSqlServer.Text = "1433";
			// 
			// m_lbPortSqlServer
			// 
			this.m_lbPortSqlServer.Location = new System.Drawing.Point(97, 49);
			this.m_lbPortSqlServer.Name = "m_lbPortSqlServer";
			this.m_lbPortSqlServer.Size = new System.Drawing.Size(32, 16);
			this.m_lbPortSqlServer.TabIndex = 9;
			this.m_lbPortSqlServer.Text = "Port:";
			// 
			// m_rbSqlServer
			// 
			this.m_rbSqlServer.Checked = true;
			this.m_rbSqlServer.Location = new System.Drawing.Point(24, 47);
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
			// m_ckLog
			// 
			this.m_ckLog.Checked = true;
			this.m_ckLog.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckLog.Location = new System.Drawing.Point(400, 56);
			this.m_ckLog.Name = "m_ckLog";
			this.m_ckLog.Size = new System.Drawing.Size(168, 16);
			this.m_ckLog.TabIndex = 12;
			this.m_ckLog.Text = "Log";
			// 
			// m_ckAlwaysApp
			// 
			this.m_ckAlwaysApp.Location = new System.Drawing.Point(400, 38);
			this.m_ckAlwaysApp.Name = "m_ckAlwaysApp";
			this.m_ckAlwaysApp.Size = new System.Drawing.Size(136, 16);
			this.m_ckAlwaysApp.TabIndex = 11;
			this.m_ckAlwaysApp.Text = "AlwaysApp";
			this.m_ckAlwaysApp.CheckedChanged += new System.EventHandler(this.m_ckAlwaysApp_CheckedChanged);
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
			this.m_gbLogin.Size = new System.Drawing.Size(220, 80);
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
			// m_tSiscoMensagem
			// 
			this.m_tSiscoMensagem.Interval = 3000;
			this.m_tSiscoMensagem.Tick += new System.EventHandler(this.m_tSiscoMensagem_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(648, 606);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Controladora Mensagems";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbRetorno.ResumeLayout(false);
			this.m_gbMoeda.ResumeLayout(false);
			this.m_gbControladoraMensagens.ResumeLayout(false);
			this.m_gbWindowsServiceStatic.ResumeLayout(false);
			this.m_gbWindowsService.ResumeLayout(false);
			this.m_gbWindowsServiceInstall.ResumeLayout(false);
			this.m_gbWindowsServiceState.ResumeLayout(false);
			this.m_gbWindowsServiceInit.ResumeLayout(false);
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
			if (m_rbSqlServer.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessSqlServer(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtPortSqlServer.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);

			m_cls_dba_ConnectionBD.ShowDialogsErrors = true;
			m_cls_dba_ConnectionBD.SystemMode = mdlDataBaseAccess.Mode.Developer;
		}
		#endregion
		#region Eventos
			#region Formulario
				private void Form1_Load(object sender, System.EventArgs e)
				{
					vRefreshWindowsService();
				}
			#endregion
			#region Timer
				private void m_tSiscoMensagem_Tick(object sender, System.EventArgs e)
				{
					vRefreshWindowsService();
				}
			#endregion
			#region CheckBoxes
				private void m_ckAlwaysApp_CheckedChanged(object sender, System.EventArgs e)
				{
					vRefreshWindowsService();
				}
			#endregion
		#endregion

		#region Negocio
			#region Static WindowsService
				private void m_btInstallUtil_Click(object sender, System.EventArgs e)
				{
					System.Windows.Forms.MessageBox.Show(System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory() + "InstallUtil.exe");
				}

				private void m_btWindowsServiceStaticSupport_Click(object sender, System.EventArgs e)
				{
					m_txtRetorno.Text = mdlControladoraWindowsServices.clsManagerWindowsService.bWindowsServiceSupport().ToString();
					m_cls_mws_SiscoMensage = null;
				}
			#endregion
			#region WindowsService
			#region Object
			private void vCreateManagerWindowsService()
			{
				if (m_cls_mws_SiscoMensage == null)
					m_cls_mws_SiscoMensage = new mdlControladoraWindowsServices.clsManagerWSSiscoMensagem(m_txtPath.Text);
				m_cls_mws_SiscoMensage.AlwaysApp = m_ckAlwaysApp.Checked;
			}
			#endregion
			#region Install
			private void vRefreshWindowsService()
			{
				try
				{
					vCreateManagerWindowsService();
					if (m_cls_mws_SiscoMensage.bInstaled())
						m_lbInstaled.Text = "Sim";
					else
						m_lbInstaled.Text = "Não";
					m_lbInit.Text = m_cls_mws_SiscoMensage.Initialization.ToString();
					m_lbState.Text = m_cls_mws_SiscoMensage.State.ToString();
					m_lbControladoraMensagensState.Text = m_cls_mws_SiscoMensage.StateControladoraMensagens.ToString();
				}catch{

				}
			}

			private void m_btWSSiscoMensagemInstaledInstall_Click(object sender, System.EventArgs e)
			{
				vCreateManagerWindowsService();
				m_cls_mws_SiscoMensage.bInstall();
				vRefreshWindowsService();
			}
			private void m_btWSSiscoMensagemInstaledUninstall_Click(object sender, System.EventArgs e)
			{
				vCreateManagerWindowsService();
				m_cls_mws_SiscoMensage.bUninstall();
				vRefreshWindowsService();
			}
			#endregion
			#region Init
			private void m_btWSSiscoMensagemInitNever_Click(object sender, System.EventArgs e)
			{
				vCreateManagerWindowsService();
				m_cls_mws_SiscoMensage.Initialization = mdlConstantes.SiscoMensagemInit.Never;
				vRefreshWindowsService();
						
			}
			private void m_btWSSiscoMensagemInitSiscobras_Click(object sender, System.EventArgs e)
			{
				vCreateManagerWindowsService();
				m_cls_mws_SiscoMensage.Initialization = mdlConstantes.SiscoMensagemInit.Siscobras;
				vRefreshWindowsService();
			}

			private void m_btWSSiscoMensagemInitComputer_Click(object sender, System.EventArgs e)
			{
				vCreateManagerWindowsService();
				m_cls_mws_SiscoMensage.Initialization = mdlConstantes.SiscoMensagemInit.ComputerStartup;
				vRefreshWindowsService();
			}
			#endregion
			#region State
			private void m_btWSSiscoMensagemStart_Click(object sender, System.EventArgs e)
			{
				vCreateManagerWindowsService();
				m_cls_mws_SiscoMensage.bStart();
				vRefreshWindowsService();
			}
			private void m_btWSSiscoMensagemPause_Click(object sender, System.EventArgs e)
			{
				vCreateManagerWindowsService();
				m_cls_mws_SiscoMensage.bPause();
				vRefreshWindowsService();
			}

			private void m_btWSSiscoMensagemContinue_Click(object sender, System.EventArgs e)
			{
				vCreateManagerWindowsService();
				m_cls_mws_SiscoMensage.bContinue();
				vRefreshWindowsService();
			}

			private void m_btWSSiscoMensagemStop_Click(object sender, System.EventArgs e)
			{
				vCreateManagerWindowsService();
				m_cls_mws_SiscoMensage.bStop();
				vRefreshWindowsService();
			}
			#endregion
			#region Close
				private void m_btWSSiscoMensagemClose_Click(object sender, System.EventArgs e)
				{
					vCreateManagerWindowsService();
					m_cls_mws_SiscoMensage.bClose();
					vRefreshWindowsService();
				}
			#endregion
			#endregion
			#region ControladoraMensagens
				private void m_btControladoraMensagensStart_Click(object sender, System.EventArgs e)
				{
					vCreateManagerWindowsService();
					m_cls_mws_SiscoMensage.bStart();
					vRefreshWindowsService();
				}

				private void m_btControladoraMensagensPause_Click(object sender, System.EventArgs e)
				{
					vCreateManagerWindowsService();
					m_cls_mws_SiscoMensage.bPause();
					vRefreshWindowsService();
				}

				private void m_btControladoraMensagensContinue_Click(object sender, System.EventArgs e)
				{
					vCreateManagerWindowsService();
					m_cls_mws_SiscoMensage.bContinue();
					vRefreshWindowsService();
				}

				private void m_btControladoraMensagensStop_Click(object sender, System.EventArgs e)
				{
					vCreateManagerWindowsService();
					m_cls_mws_SiscoMensage.bStop();
					vRefreshWindowsService();
				}

				private void m_btControladoraMensagensClose_Click(object sender, System.EventArgs e)
				{
					vCreateManagerWindowsService();
					m_cls_mws_SiscoMensage.bClose();
					vRefreshWindowsService();
				}
			#endregion
		#endregion
	}
}

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
		private System.Windows.Forms.TextBox m_txtFileKey;
		private System.Windows.Forms.Label m_lbFileKey;
		private System.Windows.Forms.Button m_btFileKeyGenerate;
		private System.Windows.Forms.Button m_btFileKeyCheck;
		private System.Windows.Forms.Button m_btShowDialogCadastro;
		private System.Windows.Forms.Button m_btShowDialogEnviarDados;
		private System.Windows.Forms.Label m_lbKeyTime;
		private System.Windows.Forms.TextBox m_txtKeyTime;
		private System.Windows.Forms.DateTimePicker m_dpDataHoje;
		private System.Windows.Forms.Label m_lbDataHoje;
		private System.Windows.Forms.Label m_lbDataAtualizacao;
		private System.Windows.Forms.Label m_lbDataVencimento;
		private System.Windows.Forms.DateTimePicker m_dpDataAtualizacao;
		private System.Windows.Forms.DateTimePicker m_dpDataVencimento;
		private System.Windows.Forms.Button m_btTimeKeyGenerate;
		private System.Windows.Forms.Button m_btTimeKeyReturn;
		private System.Windows.Forms.Button m_btEnumRegistroOK;
		private System.Windows.Forms.Button m_btBRegistroOK;
		private System.Windows.Forms.Button m_btRequisicaoDados;
		private System.Windows.Forms.Button m_btSincronizaDados;
		private System.Windows.Forms.TextBox m_txtIdCliente;
		private System.Windows.Forms.Label m_lbIdCliente;
		private System.Windows.Forms.RadioButton m_rbSqlServer;
		private System.Windows.Forms.TextBox m_txtPortSqlServer;
		private System.Windows.Forms.Label m_lbPortSqlServer;
		private System.Windows.Forms.Button m_btMaquinaDados;
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
			this.m_txtIdCliente = new System.Windows.Forms.TextBox();
			this.m_lbIdCliente = new System.Windows.Forms.Label();
			this.m_dpDataVencimento = new System.Windows.Forms.DateTimePicker();
			this.m_dpDataAtualizacao = new System.Windows.Forms.DateTimePicker();
			this.m_dpDataHoje = new System.Windows.Forms.DateTimePicker();
			this.m_lbDataVencimento = new System.Windows.Forms.Label();
			this.m_lbDataAtualizacao = new System.Windows.Forms.Label();
			this.m_lbDataHoje = new System.Windows.Forms.Label();
			this.m_txtKeyTime = new System.Windows.Forms.TextBox();
			this.m_lbKeyTime = new System.Windows.Forms.Label();
			this.m_txtFileKey = new System.Windows.Forms.TextBox();
			this.m_lbFileKey = new System.Windows.Forms.Label();
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_lbRetorno = new System.Windows.Forms.Label();
			this.m_gbMoeda = new System.Windows.Forms.GroupBox();
			this.m_btMaquinaDados = new System.Windows.Forms.Button();
			this.m_btSincronizaDados = new System.Windows.Forms.Button();
			this.m_btRequisicaoDados = new System.Windows.Forms.Button();
			this.m_btBRegistroOK = new System.Windows.Forms.Button();
			this.m_btTimeKeyReturn = new System.Windows.Forms.Button();
			this.m_btTimeKeyGenerate = new System.Windows.Forms.Button();
			this.m_btShowDialogEnviarDados = new System.Windows.Forms.Button();
			this.m_btShowDialogCadastro = new System.Windows.Forms.Button();
			this.m_btFileKeyCheck = new System.Windows.Forms.Button();
			this.m_btFileKeyGenerate = new System.Windows.Forms.Button();
			this.m_btEnumRegistroOK = new System.Windows.Forms.Button();
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
			this.m_gbGeral.Location = new System.Drawing.Point(2, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(646, 568);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbParametros
			// 
			this.m_gbParametros.Controls.Add(this.m_txtIdCliente);
			this.m_gbParametros.Controls.Add(this.m_lbIdCliente);
			this.m_gbParametros.Controls.Add(this.m_dpDataVencimento);
			this.m_gbParametros.Controls.Add(this.m_dpDataAtualizacao);
			this.m_gbParametros.Controls.Add(this.m_dpDataHoje);
			this.m_gbParametros.Controls.Add(this.m_lbDataVencimento);
			this.m_gbParametros.Controls.Add(this.m_lbDataAtualizacao);
			this.m_gbParametros.Controls.Add(this.m_lbDataHoje);
			this.m_gbParametros.Controls.Add(this.m_txtKeyTime);
			this.m_gbParametros.Controls.Add(this.m_lbKeyTime);
			this.m_gbParametros.Controls.Add(this.m_txtFileKey);
			this.m_gbParametros.Controls.Add(this.m_lbFileKey);
			this.m_gbParametros.Location = new System.Drawing.Point(8, 248);
			this.m_gbParametros.Name = "m_gbParametros";
			this.m_gbParametros.Size = new System.Drawing.Size(632, 120);
			this.m_gbParametros.TabIndex = 3;
			this.m_gbParametros.TabStop = false;
			this.m_gbParametros.Text = "Parametros";
			// 
			// m_txtIdCliente
			// 
			this.m_txtIdCliente.Location = new System.Drawing.Point(592, 92);
			this.m_txtIdCliente.Name = "m_txtIdCliente";
			this.m_txtIdCliente.Size = new System.Drawing.Size(32, 20);
			this.m_txtIdCliente.TabIndex = 10;
			this.m_txtIdCliente.Text = "1";
			// 
			// m_lbIdCliente
			// 
			this.m_lbIdCliente.Location = new System.Drawing.Point(544, 97);
			this.m_lbIdCliente.Name = "m_lbIdCliente";
			this.m_lbIdCliente.Size = new System.Drawing.Size(56, 16);
			this.m_lbIdCliente.TabIndex = 11;
			this.m_lbIdCliente.Text = "IdCliente:";
			// 
			// m_dpDataVencimento
			// 
			this.m_dpDataVencimento.CustomFormat = "";
			this.m_dpDataVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_dpDataVencimento.Location = new System.Drawing.Point(438, 45);
			this.m_dpDataVencimento.Name = "m_dpDataVencimento";
			this.m_dpDataVencimento.Size = new System.Drawing.Size(88, 20);
			this.m_dpDataVencimento.TabIndex = 9;
			// 
			// m_dpDataAtualizacao
			// 
			this.m_dpDataAtualizacao.CustomFormat = "";
			this.m_dpDataAtualizacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_dpDataAtualizacao.Location = new System.Drawing.Point(248, 45);
			this.m_dpDataAtualizacao.Name = "m_dpDataAtualizacao";
			this.m_dpDataAtualizacao.Size = new System.Drawing.Size(88, 20);
			this.m_dpDataAtualizacao.TabIndex = 8;
			// 
			// m_dpDataHoje
			// 
			this.m_dpDataHoje.CustomFormat = "";
			this.m_dpDataHoje.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_dpDataHoje.Location = new System.Drawing.Point(66, 45);
			this.m_dpDataHoje.Name = "m_dpDataHoje";
			this.m_dpDataHoje.Size = new System.Drawing.Size(88, 20);
			this.m_dpDataHoje.TabIndex = 7;
			// 
			// m_lbDataVencimento
			// 
			this.m_lbDataVencimento.Location = new System.Drawing.Point(346, 48);
			this.m_lbDataVencimento.Name = "m_lbDataVencimento";
			this.m_lbDataVencimento.Size = new System.Drawing.Size(96, 16);
			this.m_lbDataVencimento.TabIndex = 6;
			this.m_lbDataVencimento.Text = "DataVencimento:";
			// 
			// m_lbDataAtualizacao
			// 
			this.m_lbDataAtualizacao.Location = new System.Drawing.Point(160, 48);
			this.m_lbDataAtualizacao.Name = "m_lbDataAtualizacao";
			this.m_lbDataAtualizacao.Size = new System.Drawing.Size(96, 16);
			this.m_lbDataAtualizacao.TabIndex = 5;
			this.m_lbDataAtualizacao.Text = "DataAtualizacao:";
			// 
			// m_lbDataHoje
			// 
			this.m_lbDataHoje.Location = new System.Drawing.Point(10, 47);
			this.m_lbDataHoje.Name = "m_lbDataHoje";
			this.m_lbDataHoje.Size = new System.Drawing.Size(56, 16);
			this.m_lbDataHoje.TabIndex = 4;
			this.m_lbDataHoje.Text = "DataHoje:";
			// 
			// m_txtKeyTime
			// 
			this.m_txtKeyTime.Location = new System.Drawing.Point(64, 17);
			this.m_txtKeyTime.Name = "m_txtKeyTime";
			this.m_txtKeyTime.Size = new System.Drawing.Size(560, 20);
			this.m_txtKeyTime.TabIndex = 2;
			this.m_txtKeyTime.Text = "xSlZ/8QfyFAM85panwPnc4Z5b/4qh3YdKqeoTStIv2Y4Wdaa5rkNZsZgzllobbp29r5ZmLvF95AiSiqSE" +
				"w3k7w==";
			// 
			// m_lbKeyTime
			// 
			this.m_lbKeyTime.Location = new System.Drawing.Point(8, 16);
			this.m_lbKeyTime.Name = "m_lbKeyTime";
			this.m_lbKeyTime.Size = new System.Drawing.Size(56, 16);
			this.m_lbKeyTime.TabIndex = 3;
			this.m_lbKeyTime.Text = "KeyTime:";
			// 
			// m_txtFileKey
			// 
			this.m_txtFileKey.Location = new System.Drawing.Point(49, 87);
			this.m_txtFileKey.Name = "m_txtFileKey";
			this.m_txtFileKey.Size = new System.Drawing.Size(152, 20);
			this.m_txtFileKey.TabIndex = 0;
			this.m_txtFileKey.Text = "Thiago";
			// 
			// m_lbFileKey
			// 
			this.m_lbFileKey.Location = new System.Drawing.Point(8, 90);
			this.m_lbFileKey.Name = "m_lbFileKey";
			this.m_lbFileKey.Size = new System.Drawing.Size(48, 16);
			this.m_lbFileKey.TabIndex = 1;
			this.m_lbFileKey.Text = "FileKey:";
			// 
			// m_gbRetorno
			// 
			this.m_gbRetorno.Controls.Add(this.m_txtRetorno);
			this.m_gbRetorno.Controls.Add(this.m_lbRetorno);
			this.m_gbRetorno.Location = new System.Drawing.Point(8, 512);
			this.m_gbRetorno.Name = "m_gbRetorno";
			this.m_gbRetorno.Size = new System.Drawing.Size(632, 48);
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
			this.m_gbMoeda.Controls.Add(this.m_btMaquinaDados);
			this.m_gbMoeda.Controls.Add(this.m_btSincronizaDados);
			this.m_gbMoeda.Controls.Add(this.m_btRequisicaoDados);
			this.m_gbMoeda.Controls.Add(this.m_btBRegistroOK);
			this.m_gbMoeda.Controls.Add(this.m_btTimeKeyReturn);
			this.m_gbMoeda.Controls.Add(this.m_btTimeKeyGenerate);
			this.m_gbMoeda.Controls.Add(this.m_btShowDialogEnviarDados);
			this.m_gbMoeda.Controls.Add(this.m_btShowDialogCadastro);
			this.m_gbMoeda.Controls.Add(this.m_btFileKeyCheck);
			this.m_gbMoeda.Controls.Add(this.m_btFileKeyGenerate);
			this.m_gbMoeda.Controls.Add(this.m_btEnumRegistroOK);
			this.m_gbMoeda.Location = new System.Drawing.Point(8, 368);
			this.m_gbMoeda.Name = "m_gbMoeda";
			this.m_gbMoeda.Size = new System.Drawing.Size(632, 144);
			this.m_gbMoeda.TabIndex = 1;
			this.m_gbMoeda.TabStop = false;
			this.m_gbMoeda.Text = "Negocio";
			// 
			// m_btMaquinaDados
			// 
			this.m_btMaquinaDados.Location = new System.Drawing.Point(256, 104);
			this.m_btMaquinaDados.Name = "m_btMaquinaDados";
			this.m_btMaquinaDados.Size = new System.Drawing.Size(120, 32);
			this.m_btMaquinaDados.TabIndex = 12;
			this.m_btMaquinaDados.Text = "Máquina Dados";
			this.m_btMaquinaDados.Click += new System.EventHandler(this.m_btMaquinaDados_Click);
			// 
			// m_btSincronizaDados
			// 
			this.m_btSincronizaDados.Location = new System.Drawing.Point(9, 105);
			this.m_btSincronizaDados.Name = "m_btSincronizaDados";
			this.m_btSincronizaDados.Size = new System.Drawing.Size(120, 32);
			this.m_btSincronizaDados.TabIndex = 11;
			this.m_btSincronizaDados.Text = "SincronizaDados";
			this.m_btSincronizaDados.Click += new System.EventHandler(this.m_btSincronizaDados_Click);
			// 
			// m_btRequisicaoDados
			// 
			this.m_btRequisicaoDados.Location = new System.Drawing.Point(256, 51);
			this.m_btRequisicaoDados.Name = "m_btRequisicaoDados";
			this.m_btRequisicaoDados.Size = new System.Drawing.Size(120, 32);
			this.m_btRequisicaoDados.TabIndex = 10;
			this.m_btRequisicaoDados.Text = "Requisicao Dados";
			this.m_btRequisicaoDados.Click += new System.EventHandler(this.m_btRequisicaoDados_Click);
			// 
			// m_btBRegistroOK
			// 
			this.m_btBRegistroOK.Location = new System.Drawing.Point(8, 16);
			this.m_btBRegistroOK.Name = "m_btBRegistroOK";
			this.m_btBRegistroOK.Size = new System.Drawing.Size(104, 32);
			this.m_btBRegistroOK.TabIndex = 9;
			this.m_btBRegistroOK.Text = "bRegistroOK";
			this.m_btBRegistroOK.Click += new System.EventHandler(this.m_btBRegistroOK_Click);
			// 
			// m_btTimeKeyReturn
			// 
			this.m_btTimeKeyReturn.Location = new System.Drawing.Point(495, 107);
			this.m_btTimeKeyReturn.Name = "m_btTimeKeyReturn";
			this.m_btTimeKeyReturn.Size = new System.Drawing.Size(128, 31);
			this.m_btTimeKeyReturn.TabIndex = 8;
			this.m_btTimeKeyReturn.Text = "TimeKeyReturn";
			this.m_btTimeKeyReturn.Click += new System.EventHandler(this.m_btTimeKeyReturn_Click);
			// 
			// m_btTimeKeyGenerate
			// 
			this.m_btTimeKeyGenerate.Location = new System.Drawing.Point(495, 75);
			this.m_btTimeKeyGenerate.Name = "m_btTimeKeyGenerate";
			this.m_btTimeKeyGenerate.Size = new System.Drawing.Size(128, 31);
			this.m_btTimeKeyGenerate.TabIndex = 7;
			this.m_btTimeKeyGenerate.Text = "TimeKeyGenerate";
			this.m_btTimeKeyGenerate.Click += new System.EventHandler(this.m_btTimeKeyGenerate_Click);
			// 
			// m_btShowDialogEnviarDados
			// 
			this.m_btShowDialogEnviarDados.Location = new System.Drawing.Point(132, 51);
			this.m_btShowDialogEnviarDados.Name = "m_btShowDialogEnviarDados";
			this.m_btShowDialogEnviarDados.Size = new System.Drawing.Size(120, 32);
			this.m_btShowDialogEnviarDados.TabIndex = 6;
			this.m_btShowDialogEnviarDados.Text = "ShowDialogEnviarDados";
			this.m_btShowDialogEnviarDados.Click += new System.EventHandler(this.m_btShowDialogEnviarDados_Click);
			// 
			// m_btShowDialogCadastro
			// 
			this.m_btShowDialogCadastro.Location = new System.Drawing.Point(8, 51);
			this.m_btShowDialogCadastro.Name = "m_btShowDialogCadastro";
			this.m_btShowDialogCadastro.Size = new System.Drawing.Size(120, 32);
			this.m_btShowDialogCadastro.TabIndex = 5;
			this.m_btShowDialogCadastro.Text = "ShowDialogCadastro";
			this.m_btShowDialogCadastro.Click += new System.EventHandler(this.m_btShowDialogCadastro_Click);
			// 
			// m_btFileKeyCheck
			// 
			this.m_btFileKeyCheck.Location = new System.Drawing.Point(495, 43);
			this.m_btFileKeyCheck.Name = "m_btFileKeyCheck";
			this.m_btFileKeyCheck.Size = new System.Drawing.Size(128, 31);
			this.m_btFileKeyCheck.TabIndex = 4;
			this.m_btFileKeyCheck.Text = "FileKeyCheck";
			this.m_btFileKeyCheck.Click += new System.EventHandler(this.m_btFileKeyCheck_Click);
			// 
			// m_btFileKeyGenerate
			// 
			this.m_btFileKeyGenerate.Location = new System.Drawing.Point(495, 11);
			this.m_btFileKeyGenerate.Name = "m_btFileKeyGenerate";
			this.m_btFileKeyGenerate.Size = new System.Drawing.Size(128, 31);
			this.m_btFileKeyGenerate.TabIndex = 3;
			this.m_btFileKeyGenerate.Text = "FileKeyGenerate";
			this.m_btFileKeyGenerate.Click += new System.EventHandler(this.m_btFileKeyGenerate_Click);
			// 
			// m_btEnumRegistroOK
			// 
			this.m_btEnumRegistroOK.Location = new System.Drawing.Point(115, 16);
			this.m_btEnumRegistroOK.Name = "m_btEnumRegistroOK";
			this.m_btEnumRegistroOK.Size = new System.Drawing.Size(104, 32);
			this.m_btEnumRegistroOK.TabIndex = 2;
			this.m_btEnumRegistroOK.Text = "enumRegistroOK";
			this.m_btEnumRegistroOK.Click += new System.EventHandler(this.m_btEnumRegistroOk_Click);
			// 
			// m_gbBD
			// 
			this.m_gbBD.Controls.Add(this.m_gbConfiguracao);
			this.m_gbBD.Controls.Add(this.m_gbTipoAcesso);
			this.m_gbBD.Controls.Add(this.m_gbLogin);
			this.m_gbBD.Location = new System.Drawing.Point(8, 16);
			this.m_gbBD.Name = "m_gbBD";
			this.m_gbBD.Size = new System.Drawing.Size(624, 232);
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
			this.m_txtPortSqlServer.Location = new System.Drawing.Point(134, 45);
			this.m_txtPortSqlServer.Name = "m_txtPortSqlServer";
			this.m_txtPortSqlServer.Size = new System.Drawing.Size(64, 20);
			this.m_txtPortSqlServer.TabIndex = 10;
			this.m_txtPortSqlServer.Text = "1433";
			// 
			// m_lbPortSqlServer
			// 
			this.m_lbPortSqlServer.Location = new System.Drawing.Point(102, 48);
			this.m_lbPortSqlServer.Name = "m_lbPortSqlServer";
			this.m_lbPortSqlServer.Size = new System.Drawing.Size(34, 16);
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
			// m_ilBandeiras
			// 
			this.m_ilBandeiras.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilBandeiras.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 574);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Registro";
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
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessOleDbJet40(ref m_cls_tre_tratadorErro,m_txtPath.Text + m_txtDataBaseName.Text + ".mdb",m_txtUser.Text,m_txtPassword.Text);
//			if (m_rbMySql.Checked)
				//m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtUser.Text,m_txtPassword.Text,m_txtDataBaseName.Text);
			if (m_rbSqlServer.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessSqlServer(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtPortSqlServer.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);
			m_cls_dba_ConnectionBD.ShowDialogsErrors = true;
			m_cls_dba_ConnectionBD.SystemMode = mdlDataBaseAccess.Mode.Developer;
		}
		#endregion

		#region Negocio 
			#region bRegistroOK
				private void m_btBRegistroOK_Click(object sender, System.EventArgs e)
				{
					CreateDataBase();
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlRegistro.clsRegistro obj = new mdlRegistro.clsRegistro(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
					m_txtRetorno.Text = obj.bRegistroOK().ToString();
					this.Cursor = System.Windows.Forms.Cursors.Default;
					obj = null;
				}
			#endregion
			#region EnumRegistroOk
				private void m_btEnumRegistroOk_Click(object sender, System.EventArgs e)
				{
					CreateDataBase();
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlRegistro.clsRegistro obj = new mdlRegistro.clsRegistro(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
					m_txtRetorno.Text = obj.enumRegistroOK().ToString();
					this.Cursor = System.Windows.Forms.Cursors.Default;
					obj = null;
				}
			#endregion
			#region KeyFile 
				private void m_btFileKeyGenerate_Click(object sender, System.EventArgs e)
				{
					CreateDataBase();
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlRegistro.clsRegistro obj = new mdlRegistro.clsRegistro(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
					m_txtRetorno.Text = obj.bKeyFileGenerate(m_txtFileKey.Text).ToString();
					this.Cursor = System.Windows.Forms.Cursors.Default;
					obj = null;
				}

				private void m_btFileKeyCheck_Click(object sender, System.EventArgs e)
				{
					CreateDataBase();
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlRegistro.clsRegistro obj = new mdlRegistro.clsRegistro(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
					m_txtRetorno.Text = obj.bKeyFileCheck(m_txtFileKey.Text).ToString();
					this.Cursor = System.Windows.Forms.Cursors.Default;
					obj = null;
				}

				private void m_btMaquinaDados_Click(object sender, System.EventArgs e)
				{
					CreateDataBase();
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlRegistro.clsRegistro obj = new mdlRegistro.clsRegistro(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
					m_txtRetorno.Text = obj.bMaquinaDadosOk().ToString();
					this.Cursor = System.Windows.Forms.Cursors.Default;
					obj = null;
				}
			#endregion
			#region TimeKey
				private void m_btTimeKeyGenerate_Click(object sender, System.EventArgs e)
				{
					CreateDataBase();
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlRegistro.clsRegistro obj = new mdlRegistro.clsRegistro(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
					string strKeyTime = "";
					obj.vKeyTimeGenerate(out strKeyTime,m_dpDataHoje.Value,m_dpDataAtualizacao.Value,m_dpDataVencimento.Value);
					m_txtKeyTime.Text = strKeyTime;
					this.Cursor = System.Windows.Forms.Cursors.Default;
					obj = null;
				}

				private void m_btTimeKeyReturn_Click(object sender, System.EventArgs e)
				{				
					CreateDataBase();
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlRegistro.clsRegistro obj = new mdlRegistro.clsRegistro(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
					System.DateTime dtHoje;
					System.DateTime dtAtualizacao;
					System.DateTime dtVencimento;
					m_txtRetorno.Text = obj.bKeyTimeReturn(m_txtKeyTime.Text,out dtHoje,out dtAtualizacao,out dtVencimento).ToString();
					m_dpDataHoje.Value = dtHoje;
					m_dpDataAtualizacao.Value = dtAtualizacao;
			        m_dpDataVencimento.Value = dtVencimento;
					this.Cursor = System.Windows.Forms.Cursors.Default;
					obj = null;
				}
			#endregion
			#region ShowDialogCadastro
		private void m_btShowDialogCadastro_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			mdlRegistro.clsRegistro obj = new mdlRegistro.clsRegistro(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
			m_txtRetorno.Text = obj.ShowDialogCadastro().ToString();
			this.Cursor = System.Windows.Forms.Cursors.Default;
			obj = null;
		}
		#endregion
			#region ShowDialogEnviarDados
			private void m_btShowDialogEnviarDados_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				mdlRegistro.clsRegistro obj = new mdlRegistro.clsRegistro(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
				m_txtRetorno.Text = obj.ShowDialogEnvioDadosCadastro().ToString();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				obj = null;
			}
		#endregion
			#region Requisicao Dados
				private void m_btRequisicaoDados_Click(object sender, System.EventArgs e)
				{
					CreateDataBase();
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlRegistro.clsRegistro obj = new mdlRegistro.clsRegistro(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
					m_txtRetorno.Text = obj.bRequisicaoDadosWebService(false).ToString();
					this.Cursor = System.Windows.Forms.Cursors.Default;
					obj = null;
				}
			#endregion

			#region Sincronizacao
				private void m_btSincronizaDados_Click(object sender, System.EventArgs e)
				{
					CreateDataBase();
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlRegistro.clsRegistro obj = new mdlRegistro.clsRegistro(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
					mdlRegistro.clsRegistroWebService objWeb = new mdlRegistro.clsRegistroWebService(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
					obj.vSincronizaDados(Int32.Parse(m_txtIdCliente.Text),ref objWeb);;
					this.Cursor = System.Windows.Forms.Cursors.Default;
					obj = null;
				}
			#endregion
		#endregion
	}
}

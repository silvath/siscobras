using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlDataBaseConfig
{
	/// <summary>
	/// Summary description for frmFDataBaseConfigMySqlAdmin.
	/// </summary>
	public class frmFDataBaseConfigMySqlAdmin : System.Windows.Forms.Form
	{
		#region Delegates
		public delegate System.Drawing.Color delCallCarregaCor();
		public delegate void delCallCarregaDados(string strAdminUser,string strAdminPassword,out bool bServer,out bool bSqlServer,out bool bDataBase,out bool bUser,out bool bUserAssociated,out bool bDataBaseUpdated,out bool bDefaultData);
		public delegate bool delCallServer(out string strReturn);
		public delegate bool delCallMySql(string strAdminUser,string strAdminPassword,out string strReturn);
		public delegate bool delCallDataBase(string strAdminUser,string strAdminPassword,out string strReturn);
		public delegate bool delCallUser(string strAdminUser,string strAdminPassword,out string strReturn);
		public delegate bool delCallUserAssociated(string strAdminUser,string strAdminPassword,out string strReturn);
		public delegate bool delCallDataBaseUpdated(string strAdminUser,string strAdminPassword,out string strReturn);
		public delegate bool delCallDefaultData(out string strReturn);
		#endregion
		#region Events
		public event delCallCarregaCor eCallCarregaCor;
		public event delCallCarregaDados eCallCarregaDados;
		public event delCallServer eCallServer;
		public event delCallMySql eCallMySql;
		public event delCallDataBase eCallDataBase;
		public event delCallUser eCallUser;
		public event delCallUserAssociated eCallUserAssociated;
		public event delCallDataBaseUpdated eCallDataBaseUpdated;
		public event delCallDefaultData eCallDefaultData;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaCor()
		{
			if (eCallCarregaCor != null)
			{
				m_clrFundo = eCallCarregaCor();
			}
		}

		protected virtual void OnCallCarregaDados()
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			if (eCallCarregaDados != null)
			{
				bool bServer,bSqlServer,bDataBase,bUser,bUserAssociated,bDataBaseUpdated,bDefaultData;
				eCallCarregaDados(m_txtAdminUser.Text,m_txtAdminPassword.Text,out bServer,out bSqlServer,out bDataBase,out bUser,out bUserAssociated,out bDataBaseUpdated,out bDefaultData);
				// Server 
				if (m_ckServer.Checked = bServer)
					m_ckServer.ForeColor = m_clrYes;
				else
					m_ckServer.ForeColor = m_clrNo;

				// SqlServer 
				if (m_ckSqlServer.Checked = bSqlServer)
					m_ckSqlServer.ForeColor = m_clrYes;
				else
					m_ckSqlServer.ForeColor = m_clrNo;

				// DataBase
				if (m_ckDataBase.Checked = bDataBase)
					m_ckDataBase.ForeColor = m_clrYes;
				else
					m_ckDataBase.ForeColor = m_clrNo;

				// User
				if (m_ckUser.Checked = bUser)
					m_ckUser.ForeColor = m_clrYes;
				else
					m_ckUser.ForeColor = m_clrNo;

				// User Associated
				if (m_ckUserAssociated.Checked = bUserAssociated)
					m_ckUserAssociated.ForeColor = m_clrYes;
				else
					m_ckUserAssociated.ForeColor = m_clrNo;

				// DataBaseUpdated
				if (m_ckDataBaseUpdated.Checked = bDataBaseUpdated)
					m_ckDataBaseUpdated.ForeColor = m_clrYes;
				else
					m_ckDataBaseUpdated.ForeColor = m_clrNo;

				// DefaultData 
				if (m_ckData.Checked = bDefaultData)
					m_ckData.ForeColor = m_clrYes;
				else
					m_ckData.ForeColor = m_clrNo;
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		protected virtual bool OnCallServer(out string strReturn)
		{
			bool bReturn = false;
			strReturn = "";
			if (eCallServer != null)
				bReturn = eCallServer(out strReturn);
			return(bReturn);
		}

		protected virtual bool OnCallMySql(out string strReturn)
		{
			bool bReturn = false;
			strReturn = "";
			if (eCallMySql != null)
				bReturn = eCallMySql(m_txtAdminUser.Text,m_txtAdminPassword.Text,out strReturn);
			return(bReturn);
		}

		protected virtual bool OnCallDataBase(out string strReturn)
		{
			bool bReturn = false;
			strReturn = "";
			if (eCallDataBase != null)
				bReturn = eCallDataBase(m_txtAdminUser.Text,m_txtAdminPassword.Text,out strReturn);
			return(bReturn);
		}

		protected virtual bool OnCallUser(out string strReturn)
		{
			bool bReturn = false;
			strReturn = "";
			if (eCallUser != null)
				bReturn = eCallUser(m_txtAdminUser.Text,m_txtAdminPassword.Text,out strReturn);
			return(bReturn);
		}

		protected virtual bool OnCallUserAssociated(out string strReturn)
		{
			bool bReturn = false;
			strReturn = "";
			if (eCallUserAssociated != null)
				bReturn = eCallUserAssociated(m_txtAdminUser.Text,m_txtAdminPassword.Text,out strReturn);
			return(bReturn);
		}

		protected virtual bool OnCallDataBaseUpdated(out string strReturn)
		{
			bool bReturn = false;
			strReturn = "";
			if (eCallDataBaseUpdated != null)
				bReturn = eCallDataBaseUpdated(m_txtAdminUser.Text,m_txtAdminPassword.Text,out strReturn);
			return(bReturn);
		}

		protected virtual bool OnCallDefaultData(out string strReturn)
		{
			bool bReturn = false;
			strReturn = "";
			if (eCallDefaultData != null)
				bReturn = eCallDefaultData(out strReturn);
			return(bReturn);
		}
		#endregion

		#region Atributes
		private System.Drawing.Color m_clrFundo = System.Drawing.Color.Green;

		private System.Drawing.Color m_clrYes = System.Drawing.Color.Green;
		private System.Drawing.Color m_clrNo = System.Drawing.Color.Red;

		private System.Windows.Forms.Label m_lbDataBaseName;
		private mdlComponentesGraficos.TextBox m_txtDataBaseName;
		private System.Windows.Forms.Label m_lbPort;
		private mdlComponentesGraficos.TextBox m_txtPort;
		private System.Windows.Forms.Label m_lbPassword;
		private mdlComponentesGraficos.TextBox m_txtPassword;
		private System.Windows.Forms.Label m_lbUser;
		private mdlComponentesGraficos.TextBox m_txtUser;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.GroupBox m_gbMain;
		private System.Windows.Forms.GroupBox m_gbConfig;
		private System.Windows.Forms.Label m_lbServidor;
		private mdlComponentesGraficos.TextBox m_txtServidor;
		private System.Windows.Forms.GroupBox m_gbInformacoes;
		private System.Windows.Forms.GroupBox m_gbAdmin;
		private System.Windows.Forms.Label m_lbAdminPassword;
		private mdlComponentesGraficos.TextBox m_txtAdminPassword;
		private System.Windows.Forms.Label m_lbAdminUser;
		private System.Windows.Forms.CheckBox m_ckServer;
		private System.Windows.Forms.CheckBox m_ckSqlServer;
		private System.Windows.Forms.CheckBox m_ckDataBase;
		private System.Windows.Forms.CheckBox m_ckUser;
		private System.Windows.Forms.CheckBox m_ckDataBaseUpdated;
		private System.Windows.Forms.CheckBox m_ckData;
		private System.Windows.Forms.CheckBox m_ckUserAssociated;
		private System.Windows.Forms.ToolTip m_ttDicas;
		private System.ComponentModel.IContainer components;
		private mdlComponentesGraficos.TextBox m_txtAdminUser;
		#endregion
		#region Constructors and Destructors
		public frmFDataBaseConfigMySqlAdmin(string strHost,string strPort,string strDataBaseName,string strUser,string strPassword)
		{
			InitializeComponent();
			m_txtServidor.Text = strHost;
			m_txtPort.Text = strPort;
			m_txtDataBaseName.Text = strDataBaseName;
			m_txtUser.Text = strUser;
			m_txtPassword.Text = strPassword;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFDataBaseConfigMySqlAdmin));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_ckData = new System.Windows.Forms.CheckBox();
			this.m_ckDataBaseUpdated = new System.Windows.Forms.CheckBox();
			this.m_ckUserAssociated = new System.Windows.Forms.CheckBox();
			this.m_ckUser = new System.Windows.Forms.CheckBox();
			this.m_ckDataBase = new System.Windows.Forms.CheckBox();
			this.m_ckSqlServer = new System.Windows.Forms.CheckBox();
			this.m_ckServer = new System.Windows.Forms.CheckBox();
			this.m_gbConfig = new System.Windows.Forms.GroupBox();
			this.m_gbAdmin = new System.Windows.Forms.GroupBox();
			this.m_lbAdminPassword = new System.Windows.Forms.Label();
			this.m_txtAdminPassword = new mdlComponentesGraficos.TextBox();
			this.m_lbAdminUser = new System.Windows.Forms.Label();
			this.m_txtAdminUser = new mdlComponentesGraficos.TextBox();
			this.m_lbServidor = new System.Windows.Forms.Label();
			this.m_txtServidor = new mdlComponentesGraficos.TextBox();
			this.m_lbDataBaseName = new System.Windows.Forms.Label();
			this.m_txtDataBaseName = new mdlComponentesGraficos.TextBox();
			this.m_lbPort = new System.Windows.Forms.Label();
			this.m_txtPort = new mdlComponentesGraficos.TextBox();
			this.m_lbPassword = new System.Windows.Forms.Label();
			this.m_txtPassword = new mdlComponentesGraficos.TextBox();
			this.m_lbUser = new System.Windows.Forms.Label();
			this.m_txtUser = new mdlComponentesGraficos.TextBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbMain.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.m_gbConfig.SuspendLayout();
			this.m_gbAdmin.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbInformacoes);
			this.m_gbMain.Controls.Add(this.m_gbConfig);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Location = new System.Drawing.Point(4, 0);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(273, 388);
			this.m_gbMain.TabIndex = 4;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Controls.Add(this.m_ckData);
			this.m_gbInformacoes.Controls.Add(this.m_ckDataBaseUpdated);
			this.m_gbInformacoes.Controls.Add(this.m_ckUserAssociated);
			this.m_gbInformacoes.Controls.Add(this.m_ckUser);
			this.m_gbInformacoes.Controls.Add(this.m_ckDataBase);
			this.m_gbInformacoes.Controls.Add(this.m_ckSqlServer);
			this.m_gbInformacoes.Controls.Add(this.m_ckServer);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(5, 215);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(259, 137);
			this.m_gbInformacoes.TabIndex = 79;
			this.m_gbInformacoes.TabStop = false;
			this.m_gbInformacoes.Text = "Informações";
			// 
			// m_ckData
			// 
			this.m_ckData.Enabled = false;
			this.m_ckData.Location = new System.Drawing.Point(7, 112);
			this.m_ckData.Name = "m_ckData";
			this.m_ckData.Size = new System.Drawing.Size(231, 16);
			this.m_ckData.TabIndex = 96;
			this.m_ckData.Text = "Dados iniciais.";
			// 
			// m_ckDataBaseUpdated
			// 
			this.m_ckDataBaseUpdated.Enabled = false;
			this.m_ckDataBaseUpdated.Location = new System.Drawing.Point(7, 96);
			this.m_ckDataBaseUpdated.Name = "m_ckDataBaseUpdated";
			this.m_ckDataBaseUpdated.Size = new System.Drawing.Size(231, 16);
			this.m_ckDataBaseUpdated.TabIndex = 95;
			this.m_ckDataBaseUpdated.Text = "Banco de dados atualizado.";
			// 
			// m_ckUserAssociated
			// 
			this.m_ckUserAssociated.Enabled = false;
			this.m_ckUserAssociated.Location = new System.Drawing.Point(7, 79);
			this.m_ckUserAssociated.Name = "m_ckUserAssociated";
			this.m_ckUserAssociated.Size = new System.Drawing.Size(231, 16);
			this.m_ckUserAssociated.TabIndex = 94;
			this.m_ckUserAssociated.Text = "Usuário vinculado ao banco de dados.";
			// 
			// m_ckUser
			// 
			this.m_ckUser.Enabled = false;
			this.m_ckUser.Location = new System.Drawing.Point(7, 64);
			this.m_ckUser.Name = "m_ckUser";
			this.m_ckUser.Size = new System.Drawing.Size(225, 16);
			this.m_ckUser.TabIndex = 93;
			this.m_ckUser.Text = "Usuário encontrado.";
			// 
			// m_ckDataBase
			// 
			this.m_ckDataBase.Enabled = false;
			this.m_ckDataBase.Location = new System.Drawing.Point(7, 48);
			this.m_ckDataBase.Name = "m_ckDataBase";
			this.m_ckDataBase.Size = new System.Drawing.Size(225, 16);
			this.m_ckDataBase.TabIndex = 92;
			this.m_ckDataBase.Text = "Banco de dados encontrado.";
			// 
			// m_ckSqlServer
			// 
			this.m_ckSqlServer.Enabled = false;
			this.m_ckSqlServer.Location = new System.Drawing.Point(7, 32);
			this.m_ckSqlServer.Name = "m_ckSqlServer";
			this.m_ckSqlServer.Size = new System.Drawing.Size(225, 16);
			this.m_ckSqlServer.TabIndex = 91;
			this.m_ckSqlServer.Text = "Máquina rodando servidor MySql.";
			// 
			// m_ckServer
			// 
			this.m_ckServer.Enabled = false;
			this.m_ckServer.Location = new System.Drawing.Point(7, 17);
			this.m_ckServer.Name = "m_ckServer";
			this.m_ckServer.Size = new System.Drawing.Size(225, 16);
			this.m_ckServer.TabIndex = 90;
			this.m_ckServer.Text = "Máquina do servidor encontrada.";
			// 
			// m_gbConfig
			// 
			this.m_gbConfig.Controls.Add(this.m_gbAdmin);
			this.m_gbConfig.Controls.Add(this.m_lbServidor);
			this.m_gbConfig.Controls.Add(this.m_txtServidor);
			this.m_gbConfig.Controls.Add(this.m_lbDataBaseName);
			this.m_gbConfig.Controls.Add(this.m_txtDataBaseName);
			this.m_gbConfig.Controls.Add(this.m_lbPort);
			this.m_gbConfig.Controls.Add(this.m_txtPort);
			this.m_gbConfig.Controls.Add(this.m_lbPassword);
			this.m_gbConfig.Controls.Add(this.m_txtPassword);
			this.m_gbConfig.Controls.Add(this.m_lbUser);
			this.m_gbConfig.Controls.Add(this.m_txtUser);
			this.m_gbConfig.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbConfig.Location = new System.Drawing.Point(6, 7);
			this.m_gbConfig.Name = "m_gbConfig";
			this.m_gbConfig.Size = new System.Drawing.Size(258, 209);
			this.m_gbConfig.TabIndex = 78;
			this.m_gbConfig.TabStop = false;
			this.m_gbConfig.Text = "Configurações";
			// 
			// m_gbAdmin
			// 
			this.m_gbAdmin.Controls.Add(this.m_lbAdminPassword);
			this.m_gbAdmin.Controls.Add(this.m_txtAdminPassword);
			this.m_gbAdmin.Controls.Add(this.m_lbAdminUser);
			this.m_gbAdmin.Controls.Add(this.m_txtAdminUser);
			this.m_gbAdmin.Location = new System.Drawing.Point(5, 136);
			this.m_gbAdmin.Name = "m_gbAdmin";
			this.m_gbAdmin.Size = new System.Drawing.Size(248, 64);
			this.m_gbAdmin.TabIndex = 10;
			this.m_gbAdmin.TabStop = false;
			this.m_gbAdmin.Text = "Administrador";
			// 
			// m_lbAdminPassword
			// 
			this.m_lbAdminPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbAdminPassword.Location = new System.Drawing.Point(6, 35);
			this.m_lbAdminPassword.Name = "m_lbAdminPassword";
			this.m_lbAdminPassword.Size = new System.Drawing.Size(56, 16);
			this.m_lbAdminPassword.TabIndex = 6;
			this.m_lbAdminPassword.Text = "Senha:";
			// 
			// m_txtAdminPassword
			// 
			this.m_txtAdminPassword.Location = new System.Drawing.Point(98, 33);
			this.m_txtAdminPassword.Name = "m_txtAdminPassword";
			this.m_txtAdminPassword.PasswordChar = '*';
			this.m_txtAdminPassword.Size = new System.Drawing.Size(144, 20);
			this.m_txtAdminPassword.TabIndex = 7;
			this.m_txtAdminPassword.Text = "";
			// 
			// m_lbAdminUser
			// 
			this.m_lbAdminUser.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbAdminUser.Location = new System.Drawing.Point(6, 17);
			this.m_lbAdminUser.Name = "m_lbAdminUser";
			this.m_lbAdminUser.Size = new System.Drawing.Size(56, 16);
			this.m_lbAdminUser.TabIndex = 4;
			this.m_lbAdminUser.Text = "Usuário:";
			// 
			// m_txtAdminUser
			// 
			this.m_txtAdminUser.Location = new System.Drawing.Point(98, 10);
			this.m_txtAdminUser.Name = "m_txtAdminUser";
			this.m_txtAdminUser.Size = new System.Drawing.Size(144, 20);
			this.m_txtAdminUser.TabIndex = 5;
			this.m_txtAdminUser.Text = "";
			// 
			// m_lbServidor
			// 
			this.m_lbServidor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbServidor.Location = new System.Drawing.Point(8, 24);
			this.m_lbServidor.Name = "m_lbServidor";
			this.m_lbServidor.Size = new System.Drawing.Size(96, 16);
			this.m_lbServidor.TabIndex = 9;
			this.m_lbServidor.Text = "Servidor:";
			// 
			// m_txtServidor
			// 
			this.m_txtServidor.Location = new System.Drawing.Point(104, 20);
			this.m_txtServidor.Name = "m_txtServidor";
			this.m_txtServidor.ReadOnly = true;
			this.m_txtServidor.Size = new System.Drawing.Size(144, 20);
			this.m_txtServidor.TabIndex = 8;
			this.m_txtServidor.Text = "";
			// 
			// m_lbDataBaseName
			// 
			this.m_lbDataBaseName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbDataBaseName.Location = new System.Drawing.Point(8, 66);
			this.m_lbDataBaseName.Name = "m_lbDataBaseName";
			this.m_lbDataBaseName.Size = new System.Drawing.Size(96, 16);
			this.m_lbDataBaseName.TabIndex = 7;
			this.m_lbDataBaseName.Text = "Base de Dados:";
			// 
			// m_txtDataBaseName
			// 
			this.m_txtDataBaseName.Location = new System.Drawing.Point(104, 64);
			this.m_txtDataBaseName.Name = "m_txtDataBaseName";
			this.m_txtDataBaseName.ReadOnly = true;
			this.m_txtDataBaseName.Size = new System.Drawing.Size(144, 20);
			this.m_txtDataBaseName.TabIndex = 1;
			this.m_txtDataBaseName.Text = "";
			// 
			// m_lbPort
			// 
			this.m_lbPort.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbPort.Location = new System.Drawing.Point(8, 44);
			this.m_lbPort.Name = "m_lbPort";
			this.m_lbPort.Size = new System.Drawing.Size(136, 16);
			this.m_lbPort.TabIndex = 5;
			this.m_lbPort.Text = "Porta de Comunicação:";
			// 
			// m_txtPort
			// 
			this.m_txtPort.Location = new System.Drawing.Point(144, 42);
			this.m_txtPort.Name = "m_txtPort";
			this.m_txtPort.OnlyNumbers = true;
			this.m_txtPort.ReadOnly = true;
			this.m_txtPort.Size = new System.Drawing.Size(104, 20);
			this.m_txtPort.TabIndex = 4;
			this.m_txtPort.Text = "";
			this.m_txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbPassword
			// 
			this.m_lbPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbPassword.Location = new System.Drawing.Point(9, 108);
			this.m_lbPassword.Name = "m_lbPassword";
			this.m_lbPassword.Size = new System.Drawing.Size(56, 16);
			this.m_lbPassword.TabIndex = 3;
			this.m_lbPassword.Text = "Senha:";
			// 
			// m_txtPassword
			// 
			this.m_txtPassword.Location = new System.Drawing.Point(104, 106);
			this.m_txtPassword.Name = "m_txtPassword";
			this.m_txtPassword.PasswordChar = '*';
			this.m_txtPassword.ReadOnly = true;
			this.m_txtPassword.Size = new System.Drawing.Size(144, 20);
			this.m_txtPassword.TabIndex = 3;
			this.m_txtPassword.Text = "";
			// 
			// m_lbUser
			// 
			this.m_lbUser.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbUser.Location = new System.Drawing.Point(8, 86);
			this.m_lbUser.Name = "m_lbUser";
			this.m_lbUser.Size = new System.Drawing.Size(56, 16);
			this.m_lbUser.TabIndex = 1;
			this.m_lbUser.Text = "Usuário:";
			// 
			// m_txtUser
			// 
			this.m_txtUser.Location = new System.Drawing.Point(104, 85);
			this.m_txtUser.Name = "m_txtUser";
			this.m_txtUser.ReadOnly = true;
			this.m_txtUser.Size = new System.Drawing.Size(144, 20);
			this.m_txtUser.TabIndex = 2;
			this.m_txtUser.Text = "";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(78, 356);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 5;
			this.m_ttDicas.SetToolTip(this.m_btOk, "Instalar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(142, 356);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 6;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFDataBaseConfigMySqlAdmin
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(280, 392);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFDataBaseConfigMySqlAdmin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MySql";
			this.Load += new System.EventHandler(this.frmFDataBaseConfigSqlServerAdmin_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.m_gbConfig.ResumeLayout(false);
			this.m_gbAdmin.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
		#region Formulario
		private void frmFDataBaseConfigSqlServerAdmin_Load(object sender, System.EventArgs e)
		{
			OnCallCarregaCor();
			vMostraCor();
			OnCallCarregaDados();
		}
		#endregion
		#region Botoes
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			if (m_ckData.Checked)
			{
				this.Close();
			}
			else
			{
				if (bInstall())
					mdlMensagens.clsMensagens.ShowInformation("Banco de dados criado e inicializado com sucesso.");
			}
		}

		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#endregion

		#region Cores
		private void vMostraCor()
		{
			this.BackColor = m_clrFundo;
			System.Windows.Forms.Control ctrControleChild;
			for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
			{
				ctrControleChild = this.Controls[nCont];
				vPaintControl(ref ctrControleChild,this.BackColor);
			}
		}

		private void vPaintControl(ref System.Windows.Forms.Control ctrControle,System.Drawing.Color clrBackColor)
		{
			switch(ctrControle.GetType().ToString())
			{
				case "mdlComponentesGraficos.ListView":
				case "System.Windows.Forms.ListView":
				case "mdlComponentesGraficos.ComboBox":
				case "mdlComponentesGraficos.TextBox":
					break;

				default:
					ctrControle.BackColor = clrBackColor;
					break;
			}
			System.Windows.Forms.Control ctrControleChild;
			for (int nCont = 0 ;nCont < ctrControle.Controls.Count; nCont++)
			{
				ctrControleChild = ctrControle.Controls[nCont];
				vPaintControl(ref ctrControleChild,clrBackColor);
			}
		}
		#endregion

		#region Install
		private bool bInstall()
		{
			bool bReturn = false;
			string strReturn = "";

			if (eCallCarregaDados != null)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bInstall = true;
				while(bInstall)
				{ 
					bInstall = false;
					bool bServer,bMySql,bDataBase,bUser,bUserAssociated,bDataBaseUpdated,bDefaultData;
					eCallCarregaDados(m_txtAdminUser.Text,m_txtAdminPassword.Text,out bServer,out bMySql,out bDataBase,out bUser,out bUserAssociated,out bDataBaseUpdated,out bDefaultData);
					// Server
					if (!bServer)
					{
						bInstall = OnCallServer(out strReturn);
						if (!bInstall)
							break;
					}

					// Mysql
					if (!bMySql)
					{
						bInstall = OnCallMySql(out strReturn);
						if (!bInstall)
							break;
					}

					// DataBase
					if (!bDataBase)
					{
						bInstall = OnCallDataBase(out strReturn);
						if (!bInstall)
							break;
					}
						
					// User
					if (!bUser)
					{
						bInstall = OnCallUser(out strReturn);
						if (!bInstall)
							break;
					}
						
					// UserAssociated
					if (!bUserAssociated)
					{
						bInstall = OnCallUserAssociated(out strReturn);
						if (!bInstall)
							break;
					}
						
					// DataBaseUpdated
					if (!bDataBaseUpdated)
					{
						bInstall = OnCallDataBaseUpdated(out strReturn);
						if (!bInstall)
							break;
					}
						
					// Default Data
					if (!bDataBase)
					{
						bInstall = OnCallDefaultData(out strReturn);
						if (!bInstall)
							break;
					}
					bReturn = bDefaultData;
				}
				OnCallCarregaDados();
				if(strReturn != "")
					mdlMensagens.clsMensagens.ShowInformation(strReturn);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			return(bReturn);
		}
		#endregion
	}
}

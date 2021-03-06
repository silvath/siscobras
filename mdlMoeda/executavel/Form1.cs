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
			[STAThread]
			static void Main() 
			{
				Application.Run(new Form1());
			}
		#endregion

		#region Atributos
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbBD;
			private System.Windows.Forms.GroupBox m_gbMoeda;
			private System.Windows.Forms.Label m_lbPath;
			private System.Windows.Forms.Label label1;
			private System.Windows.Forms.TextBox m_txtPath;
			private System.Windows.Forms.TextBox m_txtDataBaseName;
			private System.Windows.Forms.RadioButton m_rbJet40;
			private System.Windows.Forms.RadioButton m_rbMySql;
			private System.Windows.Forms.GroupBox m_gbRetorno;
			private System.Windows.Forms.TextBox m_txtRetorno;
			private System.Windows.Forms.Button m_btCotacao;
			private System.Windows.Forms.Button m_btProforma;
			private System.Windows.Forms.Button m_btComercial;
			private System.Windows.Forms.Button m_btGeral;
			private System.Windows.Forms.Label m_lbRetorno;
			private System.ComponentModel.Container components = null;

		    mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
		private System.Windows.Forms.GroupBox m_gbParametros;
		private System.Windows.Forms.Label m_lbIdCodigo;
		private System.Windows.Forms.Label m_lbIdExportador;
		private System.Windows.Forms.TextBox m_txtIdCodigo;
		private System.Windows.Forms.TextBox m_txtIdExportador;
		private System.Windows.Forms.GroupBox m_gbLogin;
		private System.Windows.Forms.TextBox m_txtPassword;
		private System.Windows.Forms.TextBox m_txtUser;
		private System.Windows.Forms.Label m_lbPassword;
		private System.Windows.Forms.Label m_lbUser;
		private System.Windows.Forms.GroupBox m_gbTipoAcesso;
		private System.Windows.Forms.GroupBox m_gbConfiguracao;
		private System.Windows.Forms.Label m_lbHost;
		private System.Windows.Forms.TextBox m_txtHost;
            mdlTratamentoErro.clsTratamentoErro	m_cls_tre_tratadorErro = new mdlTratamentoErro.clsTratamentoErro();
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
			this.m_txtIdCodigo = new System.Windows.Forms.TextBox();
			this.m_txtIdExportador = new System.Windows.Forms.TextBox();
			this.m_lbIdCodigo = new System.Windows.Forms.Label();
			this.m_lbIdExportador = new System.Windows.Forms.Label();
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_lbRetorno = new System.Windows.Forms.Label();
			this.m_gbMoeda = new System.Windows.Forms.GroupBox();
			this.m_btGeral = new System.Windows.Forms.Button();
			this.m_btComercial = new System.Windows.Forms.Button();
			this.m_btProforma = new System.Windows.Forms.Button();
			this.m_btCotacao = new System.Windows.Forms.Button();
			this.m_gbBD = new System.Windows.Forms.GroupBox();
			this.m_gbConfiguracao = new System.Windows.Forms.GroupBox();
			this.m_txtPath = new System.Windows.Forms.TextBox();
			this.m_lbPath = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtDataBaseName = new System.Windows.Forms.TextBox();
			this.m_gbTipoAcesso = new System.Windows.Forms.GroupBox();
			this.m_rbMySql = new System.Windows.Forms.RadioButton();
			this.m_rbJet40 = new System.Windows.Forms.RadioButton();
			this.m_gbLogin = new System.Windows.Forms.GroupBox();
			this.m_txtPassword = new System.Windows.Forms.TextBox();
			this.m_txtUser = new System.Windows.Forms.TextBox();
			this.m_lbPassword = new System.Windows.Forms.Label();
			this.m_lbUser = new System.Windows.Forms.Label();
			this.m_txtHost = new System.Windows.Forms.TextBox();
			this.m_lbHost = new System.Windows.Forms.Label();
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
			this.m_gbGeral.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.m_gbParametros,
																					this.m_gbRetorno,
																					this.m_gbMoeda,
																					this.m_gbBD});
			this.m_gbGeral.Location = new System.Drawing.Point(9, 6);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(615, 450);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbParametros
			// 
			this.m_gbParametros.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.m_txtIdCodigo,
																						 this.m_txtIdExportador,
																						 this.m_lbIdCodigo,
																						 this.m_lbIdExportador});
			this.m_gbParametros.Location = new System.Drawing.Point(8, 248);
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
			this.m_txtIdCodigo.Text = "1";
			this.m_txtIdCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_txtIdExportador
			// 
			this.m_txtIdExportador.Location = new System.Drawing.Point(108, 23);
			this.m_txtIdExportador.Name = "m_txtIdExportador";
			this.m_txtIdExportador.Size = new System.Drawing.Size(91, 20);
			this.m_txtIdExportador.TabIndex = 6;
			this.m_txtIdExportador.Text = "5";
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
			this.m_gbRetorno.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.m_txtRetorno,
																					  this.m_lbRetorno});
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
			// m_gbMoeda
			// 
			this.m_gbMoeda.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.m_btGeral,
																					this.m_btComercial,
																					this.m_btProforma,
																					this.m_btCotacao});
			this.m_gbMoeda.Location = new System.Drawing.Point(8, 328);
			this.m_gbMoeda.Name = "m_gbMoeda";
			this.m_gbMoeda.Size = new System.Drawing.Size(600, 62);
			this.m_gbMoeda.TabIndex = 1;
			this.m_gbMoeda.TabStop = false;
			this.m_gbMoeda.Text = "Moeda";
			// 
			// m_btGeral
			// 
			this.m_btGeral.Location = new System.Drawing.Point(392, 20);
			this.m_btGeral.Name = "m_btGeral";
			this.m_btGeral.Size = new System.Drawing.Size(96, 32);
			this.m_btGeral.TabIndex = 3;
			this.m_btGeral.Text = "Geral";
			this.m_btGeral.Click += new System.EventHandler(this.m_btGeral_Click);
			// 
			// m_btComercial
			// 
			this.m_btComercial.Location = new System.Drawing.Point(288, 20);
			this.m_btComercial.Name = "m_btComercial";
			this.m_btComercial.Size = new System.Drawing.Size(96, 32);
			this.m_btComercial.TabIndex = 2;
			this.m_btComercial.Text = "Comercial";
			this.m_btComercial.Click += new System.EventHandler(this.m_btComercial_Click);
			// 
			// m_btProforma
			// 
			this.m_btProforma.Location = new System.Drawing.Point(184, 20);
			this.m_btProforma.Name = "m_btProforma";
			this.m_btProforma.Size = new System.Drawing.Size(96, 32);
			this.m_btProforma.TabIndex = 1;
			this.m_btProforma.Text = "Proforma";
			this.m_btProforma.Click += new System.EventHandler(this.m_btProforma_Click);
			// 
			// m_btCotacao
			// 
			this.m_btCotacao.Location = new System.Drawing.Point(80, 20);
			this.m_btCotacao.Name = "m_btCotacao";
			this.m_btCotacao.Size = new System.Drawing.Size(96, 32);
			this.m_btCotacao.TabIndex = 0;
			this.m_btCotacao.Text = "Cotacao";
			this.m_btCotacao.Click += new System.EventHandler(this.m_btCotacao_Click);
			// 
			// m_gbBD
			// 
			this.m_gbBD.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.m_gbConfiguracao,
																				 this.m_gbTipoAcesso,
																				 this.m_gbLogin});
			this.m_gbBD.Location = new System.Drawing.Point(8, 16);
			this.m_gbBD.Name = "m_gbBD";
			this.m_gbBD.Size = new System.Drawing.Size(600, 232);
			this.m_gbBD.TabIndex = 0;
			this.m_gbBD.TabStop = false;
			this.m_gbBD.Text = "Acesso Banco Dados";
			// 
			// m_gbConfiguracao
			// 
			this.m_gbConfiguracao.Controls.AddRange(new System.Windows.Forms.Control[] {
																						   this.m_txtPath,
																						   this.m_lbPath,
																						   this.label1,
																						   this.m_txtDataBaseName});
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
			this.m_gbTipoAcesso.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.m_rbMySql,
																						 this.m_rbJet40});
			this.m_gbTipoAcesso.Location = new System.Drawing.Point(7, 94);
			this.m_gbTipoAcesso.Name = "m_gbTipoAcesso";
			this.m_gbTipoAcesso.Size = new System.Drawing.Size(577, 128);
			this.m_gbTipoAcesso.TabIndex = 10;
			this.m_gbTipoAcesso.TabStop = false;
			this.m_gbTipoAcesso.Text = "Tipo Acesso";
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
			this.m_rbJet40.Checked = true;
			this.m_rbJet40.Location = new System.Drawing.Point(24, 16);
			this.m_rbJet40.Name = "m_rbJet40";
			this.m_rbJet40.Size = new System.Drawing.Size(200, 16);
			this.m_rbJet40.TabIndex = 4;
			this.m_rbJet40.TabStop = true;
			this.m_rbJet40.Text = "Jet40";
			// 
			// m_gbLogin
			// 
			this.m_gbLogin.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.m_txtHost,
																					this.m_lbHost,
																					this.m_txtPassword,
																					this.m_txtUser,
																					this.m_lbPassword,
																					this.m_lbUser});
			this.m_gbLogin.Location = new System.Drawing.Point(396, 8);
			this.m_gbLogin.Name = "m_gbLogin";
			this.m_gbLogin.Size = new System.Drawing.Size(192, 80);
			this.m_gbLogin.TabIndex = 9;
			this.m_gbLogin.TabStop = false;
			this.m_gbLogin.Text = "Login";
			// 
			// m_txtPassword
			// 
			this.m_txtPassword.Location = new System.Drawing.Point(61, 54);
			this.m_txtPassword.Name = "m_txtPassword";
			this.m_txtPassword.Size = new System.Drawing.Size(122, 20);
			this.m_txtPassword.TabIndex = 8;
			this.m_txtPassword.Text = "siscobras";
			// 
			// m_txtUser
			// 
			this.m_txtUser.Location = new System.Drawing.Point(61, 30);
			this.m_txtUser.Name = "m_txtUser";
			this.m_txtUser.Size = new System.Drawing.Size(122, 20);
			this.m_txtUser.TabIndex = 7;
			this.m_txtUser.Text = "siscobras";
			// 
			// m_lbPassword
			// 
			this.m_lbPassword.Location = new System.Drawing.Point(6, 57);
			this.m_lbPassword.Name = "m_lbPassword";
			this.m_lbPassword.Size = new System.Drawing.Size(56, 16);
			this.m_lbPassword.TabIndex = 6;
			this.m_lbPassword.Text = "Password";
			// 
			// m_lbUser
			// 
			this.m_lbUser.Location = new System.Drawing.Point(7, 36);
			this.m_lbUser.Name = "m_lbUser";
			this.m_lbUser.Size = new System.Drawing.Size(32, 16);
			this.m_lbUser.TabIndex = 5;
			this.m_lbUser.Text = "User";
			// 
			// m_txtHost
			// 
			this.m_txtHost.Location = new System.Drawing.Point(61, 9);
			this.m_txtHost.Name = "m_txtHost";
			this.m_txtHost.Size = new System.Drawing.Size(122, 20);
			this.m_txtHost.TabIndex = 10;
			this.m_txtHost.Text = "127.0.0.1";
			// 
			// m_lbHost
			// 
			this.m_lbHost.Location = new System.Drawing.Point(8, 14);
			this.m_lbHost.Name = "m_lbHost";
			this.m_lbHost.Size = new System.Drawing.Size(32, 16);
			this.m_lbHost.TabIndex = 9;
			this.m_lbHost.Text = "Host";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 462);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_gbGeral});
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Moeda";
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
				{
					m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessOleDbJet40(ref m_cls_tre_tratadorErro,m_txtPath.Text + m_txtDataBaseName.Text + ".mdb",m_txtUser.Text,m_txtPassword.Text);
				}
				if (m_rbMySql.Checked)
				{
					//m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtUser.Text,m_txtPassword.Text,m_txtDataBaseName.Text);
				}
			}
		#endregion

		#region Eventos
			private void m_btCotacao_Click(object sender, System.EventArgs e)
			{
				int nIdMoeda;
				string strDescricao;
				string strSimbolo;
				bool bMostrarSimboloMoeda;
				CreateDataBase();
				mdlMoeda.clsMoeda modMoeda = new mdlMoeda.clsMoedaCotacao(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_txtIdExportador.Text),m_txtIdCodigo.Text);
				modMoeda.retornaValores(out nIdMoeda,out strDescricao,out strSimbolo,out bMostrarSimboloMoeda);
				this.m_txtRetorno.Text = nIdMoeda + " " + strDescricao + " " + strSimbolo;
				modMoeda.ShowDialog();
				if (modMoeda.m_bModificado)
				{
					modMoeda.retornaValores(out nIdMoeda,out strDescricao,out strSimbolo,out bMostrarSimboloMoeda);
					this.m_txtRetorno.Text = nIdMoeda + " " + strDescricao + " " + strSimbolo;
				}
	
			}

			private void m_btProforma_Click(object sender, System.EventArgs e)
			{
				int nIdMoeda;
				string strDescricao;
				string strSimbolo;
				bool bMostrarSimboloMoeda;
				CreateDataBase();
				mdlMoeda.clsMoeda modMoeda = new mdlMoeda.clsMoedaProforma(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_txtIdExportador.Text),m_txtIdCodigo.Text);
				modMoeda.retornaValores(out nIdMoeda,out strDescricao,out strSimbolo,out bMostrarSimboloMoeda);
				this.m_txtRetorno.Text = nIdMoeda + " " + strDescricao + " " + strSimbolo;
				modMoeda.ShowDialog();
				if (modMoeda.m_bModificado)
				{					
					modMoeda.retornaValores(out nIdMoeda,out strDescricao,out strSimbolo,out bMostrarSimboloMoeda);
					this.m_txtRetorno.Text = nIdMoeda + " " + strDescricao + " " + strSimbolo;
				}
			}

			private void m_btComercial_Click(object sender, System.EventArgs e)
			{
				int nIdMoeda;
				string strDescricao;
				string strSimbolo;
				bool bMostrarSimboloMoeda;
				CreateDataBase();
				mdlMoeda.clsMoeda modMoeda = new mdlMoeda.clsMoedaComercial(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_txtIdExportador.Text),m_txtIdCodigo.Text);
				modMoeda.retornaValores(out nIdMoeda,out strDescricao,out strSimbolo,out bMostrarSimboloMoeda);
                this.m_txtRetorno.Text = nIdMoeda + " " + strDescricao + " " + strSimbolo +  " Testando esta merda: " + mdlMoeda.clsMoeda.strReturnCurrencyFormated(nIdMoeda, (double)50.60, bMostrarSimboloMoeda);
				modMoeda.ShowDialog();
				if (modMoeda.m_bModificado)
				{
					modMoeda.retornaValores(out nIdMoeda,out strDescricao,out strSimbolo,out bMostrarSimboloMoeda);
					this.m_txtRetorno.Text = nIdMoeda + " " + strDescricao + " " + strSimbolo;
				}else{
					this.m_txtRetorno.Text = "";
				}
			}

			private void m_btGeral_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlMoeda.clsMoeda modMoeda = new mdlMoeda.clsMoedaGeral(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
				modMoeda.ShowDialog();
				if (modMoeda.m_bModificado)
				{
					int nIdMoeda;
					string strDescricao;
					string strSimbolo;
					bool bMostrarSimboloMoeda;
					modMoeda.retornaValores(out nIdMoeda,out strDescricao,out strSimbolo,out bMostrarSimboloMoeda);
					this.m_txtRetorno.Text = nIdMoeda + " " + strDescricao + " " + strSimbolo;
				}
			}

		#endregion 
	}
}

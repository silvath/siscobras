using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace executavel
{
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
		public System.Windows.Forms.ImageList m_ilBandeiras;
		private System.ComponentModel.IContainer components;

		mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
		mdlTratamentoErro.clsTratamentoErro m_cls_tre_tratadorErro;

		private System.Windows.Forms.GroupBox m_gbGeral;
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox m_txtNome;
		private System.Windows.Forms.TextBox m_txtNumParam;
		private System.Windows.Forms.Button m_btnIniciar;
		private System.Windows.Forms.ListBox m_lstMedicoes;
		private System.Windows.Forms.Button m_btnFinalizar;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListBox m_lstLog;
		private System.Windows.Forms.CheckBox m_chkMedicao;
		private System.Windows.Forms.Label m_lbUser;
		#endregion
		#region Constructor e Destructor
		public Form1()
		{
			m_cls_dba_ConnectionBD = null;
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
			this.m_txtHost = new System.Windows.Forms.TextBox();
			this.m_lbHost = new System.Windows.Forms.Label();
			this.m_txtPassword = new System.Windows.Forms.TextBox();
			this.m_txtUser = new System.Windows.Forms.TextBox();
			this.m_lbPassword = new System.Windows.Forms.Label();
			this.m_lbUser = new System.Windows.Forms.Label();
			this.m_ilBandeiras = new System.Windows.Forms.ImageList(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtNome = new System.Windows.Forms.TextBox();
			this.m_txtNumParam = new System.Windows.Forms.TextBox();
			this.m_btnIniciar = new System.Windows.Forms.Button();
			this.m_lstMedicoes = new System.Windows.Forms.ListBox();
			this.m_chkMedicao = new System.Windows.Forms.CheckBox();
			this.m_btnFinalizar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.m_lstLog = new System.Windows.Forms.ListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.m_gbGeral.SuspendLayout();
			this.m_gbBD.SuspendLayout();
			this.m_gbConfiguracao.SuspendLayout();
			this.m_gbTipoAcesso.SuspendLayout();
			this.m_gbLogin.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.groupBox1);
			this.m_gbGeral.Controls.Add(this.m_gbBD);
			this.m_gbGeral.Location = new System.Drawing.Point(5, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(615, 473);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbBD
			// 
			this.m_gbBD.Controls.Add(this.m_gbConfiguracao);
			this.m_gbBD.Controls.Add(this.m_gbTipoAcesso);
			this.m_gbBD.Controls.Add(this.m_gbLogin);
			this.m_gbBD.Location = new System.Drawing.Point(8, 16);
			this.m_gbBD.Name = "m_gbBD";
			this.m_gbBD.Size = new System.Drawing.Size(600, 160);
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
			this.m_gbTipoAcesso.Controls.Add(this.m_rbMySql);
			this.m_gbTipoAcesso.Controls.Add(this.m_rbJet40);
			this.m_gbTipoAcesso.Location = new System.Drawing.Point(7, 94);
			this.m_gbTipoAcesso.Name = "m_gbTipoAcesso";
			this.m_gbTipoAcesso.Size = new System.Drawing.Size(585, 58);
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.m_lstLog);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.m_btnFinalizar);
			this.groupBox1.Controls.Add(this.m_chkMedicao);
			this.groupBox1.Controls.Add(this.m_lstMedicoes);
			this.groupBox1.Controls.Add(this.m_btnIniciar);
			this.groupBox1.Controls.Add(this.m_txtNumParam);
			this.groupBox1.Controls.Add(this.m_txtNome);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(8, 184);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(600, 280);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Medidor de Tempo";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(42, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Nome:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 1;
			this.label3.Text = "# parâmetros:";
			// 
			// m_txtNome
			// 
			this.m_txtNome.Location = new System.Drawing.Point(81, 22);
			this.m_txtNome.Name = "m_txtNome";
			this.m_txtNome.Size = new System.Drawing.Size(431, 20);
			this.m_txtNome.TabIndex = 2;
			this.m_txtNome.Text = "";
			// 
			// m_txtNumParam
			// 
			this.m_txtNumParam.Location = new System.Drawing.Point(80, 48);
			this.m_txtNumParam.Name = "m_txtNumParam";
			this.m_txtNumParam.Size = new System.Drawing.Size(432, 20);
			this.m_txtNumParam.TabIndex = 3;
			this.m_txtNumParam.Text = "";
			// 
			// m_btnIniciar
			// 
			this.m_btnIniciar.Location = new System.Drawing.Point(518, 22);
			this.m_btnIniciar.Name = "m_btnIniciar";
			this.m_btnIniciar.TabIndex = 4;
			this.m_btnIniciar.Text = "Iniciar";
			this.m_btnIniciar.Click += new System.EventHandler(this.m_btnIniciar_Click);
			// 
			// m_lstMedicoes
			// 
			this.m_lstMedicoes.Location = new System.Drawing.Point(12, 97);
			this.m_lstMedicoes.Name = "m_lstMedicoes";
			this.m_lstMedicoes.Size = new System.Drawing.Size(580, 56);
			this.m_lstMedicoes.TabIndex = 5;
			// 
			// m_chkMedicao
			// 
			this.m_chkMedicao.Location = new System.Drawing.Point(376, 248);
			this.m_chkMedicao.Name = "m_chkMedicao";
			this.m_chkMedicao.Size = new System.Drawing.Size(128, 24);
			this.m_chkMedicao.TabIndex = 6;
			this.m_chkMedicao.Text = "Finalizar a medição?";
			// 
			// m_btnFinalizar
			// 
			this.m_btnFinalizar.Enabled = false;
			this.m_btnFinalizar.Location = new System.Drawing.Point(519, 248);
			this.m_btnFinalizar.Name = "m_btnFinalizar";
			this.m_btnFinalizar.TabIndex = 7;
			this.m_btnFinalizar.Text = "Finalizar";
			this.m_btnFinalizar.Click += new System.EventHandler(this.m_btnFinalizar_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 74);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "Medições:";
			// 
			// m_lstLog
			// 
			this.m_lstLog.Location = new System.Drawing.Point(11, 183);
			this.m_lstLog.Name = "m_lstLog";
			this.m_lstLog.Size = new System.Drawing.Size(580, 56);
			this.m_lstLog.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 160);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "Log:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 477);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Atualização do Sistema";
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbBD.ResumeLayout(false);
			this.m_gbConfiguracao.ResumeLayout(false);
			this.m_gbTipoAcesso.ResumeLayout(false);
			this.m_gbLogin.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
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
			if (m_cls_dba_ConnectionBD == null) 
			{
				if (m_rbJet40.Checked)
					m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessOleDbJet40(ref m_cls_tre_tratadorErro, m_txtPath.Text + m_txtDataBaseName.Text + ".mdb", m_txtUser.Text, m_txtPassword.Text);
				//if (m_rbMySql.Checked)
					//m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtUser.Text,m_txtPassword.Text,m_txtDataBaseName.Text);
			}
		}
		#endregion

		#region Negocio 
		private void InicializaMedidorTempo() 
		{
			mdlMedidorTempo.clsMedidorTempo.Init (ref m_cls_dba_ConnectionBD, Application.ExecutablePath);
		}

		private void m_btnIniciar_Click(object sender, System.EventArgs e)
		{
			object[] arrParametros;
			int nParam;

			CreateDataBase();
			InicializaMedidorTempo();

			try 
			{
				nParam = System.Int32.Parse (m_txtNumParam.Text);
			} 
			catch (System.Exception) 
			{
				return;
			}

			arrParametros = new object[nParam];
			for (int i = 0; i < arrParametros.Length; i++) 
			{
				arrParametros[i] = "Parâmetro" + i.ToString();
			}

			if (m_txtNome.Text.Length > 0) 
			{
				if (mdlMedidorTempo.clsMedidorTempo.IniciaMedicao (m_txtNome.Text, arrParametros)) {
					m_lstMedicoes.Items.Add (m_txtNome.Text);
					m_btnFinalizar.Enabled = true;
				}
			}
		}

		private void m_btnFinalizar_Click(object sender, System.EventArgs e)
		{
			object[] arrValores;
			int nParam;

			try 
			{
				nParam = System.Int32.Parse (m_txtNumParam.Text);
			} 
			catch (System.Exception) 
			{
				return;
			}

			arrValores = new object[nParam];
			for (int i = 0; i < arrValores.Length; i++) 
			{
				arrValores[i] = "Valor" + i.ToString();
			}

			if (m_txtNome.Text.Length > 0) 
			{
				if (mdlMedidorTempo.clsMedidorTempo.FinalizaMedicao (m_txtNome.Text, m_chkMedicao.Checked, arrValores)) 
				{
//					m_lstLog.Items.Add (strLog);

					if (m_chkMedicao.Checked) 
					{
						for (int i = 0; i < m_lstMedicoes.Items.Count; i++) 
						{
							if (m_lstMedicoes.Items[i].ToString() == m_txtNome.Text) 
							{
								m_lstMedicoes.Items.RemoveAt (i);
								break;
							}
						}
						m_btnFinalizar.Enabled = m_lstMedicoes.Items.Count > 0;
					}
				}
			}
		}
		#endregion
	}
}

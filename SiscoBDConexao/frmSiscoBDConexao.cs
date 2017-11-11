using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SiscoBDConexao
{
	/// <summary>
	/// Summary description for frmSiscoBDConexao.
	/// </summary>
	public class frmSiscoBDConexao : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate string delCallServidor(string strHost);
			public delegate string delCallServidorSqlServer(string strHost,string strPort,string strUser,string strPassword);
			public delegate string delCallServidorSqlServerAdmin(string strHost,string strPort,string strAdminUser,string strAdminPassword);
			public delegate string delCallServidorSqlServerWindows(string strHost,string strPort);
		#endregion
		#region Events
			public event delCallServidor eCallServidor;
			public event delCallServidorSqlServer eCallServidorSqlServer;
			public event delCallServidorSqlServerAdmin eCallServidorSqlServerAdmin;
			public event delCallServidorSqlServerWindows eCallServidorSqlServerWindows;
		#endregion
		#region Events Methods
			private string OnCallServidor()
			{
				if (eCallServidor == null)
					return("Erro");
				return(eCallServidor(m_txtServidor.Text));
			}

			private string OnCallServidorSqlServer()
			{
				if (m_rdbtUsuario.Checked)
					return(eCallServidorSqlServer(m_txtServidor.Text,m_txtPorta.Text,m_txtUsuario.Text,m_txtSenha.Text));
				else if (m_rdbtAdmin.Checked)
   					return(eCallServidorSqlServerAdmin(m_txtServidor.Text,m_txtPorta.Text,m_txtAdminUser.Text,m_txtAdminSenha.Text));
				else if (m_rdbtWindows.Checked)
					return(eCallServidorSqlServerWindows(m_txtServidor.Text,m_txtPorta.Text));
				return("Falha: Nenhuma Opcao de Autenticacao escolhida");
			}
		#endregion

		#region Atributes
			private System.ComponentModel.Container components = null;
			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.GroupBox m_gbOutput;
			private System.Windows.Forms.RichTextBox m_rtbOutput;
			private System.Windows.Forms.GroupBox m_gbBaseDados;
			private System.Windows.Forms.RadioButton m_rdbtSqlServer;
			private System.Windows.Forms.Label label1;
			private System.Windows.Forms.GroupBox m_gbConfiguracoes;
			private System.Windows.Forms.GroupBox m_gbOperacoes;
			private System.Windows.Forms.TextBox m_txtServidor;
			private System.Windows.Forms.Label label2;
			private System.Windows.Forms.Label label3;
			private System.Windows.Forms.Label label4;
			private System.Windows.Forms.TextBox m_txtPorta;
			private System.Windows.Forms.TextBox m_txtBaseDados;
			private System.Windows.Forms.TextBox m_txtUsuario;
			private System.Windows.Forms.TextBox m_txtSenha;
			private System.Windows.Forms.Label m_lbSenha;
		private System.Windows.Forms.Button m_btServidorBaseDados;
		private System.Windows.Forms.GroupBox m_gbAdmin;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox m_txtAdminSenha;
		private System.Windows.Forms.TextBox m_txtAdminUser;
		private System.Windows.Forms.GroupBox m_gbAutenticacao;
		private System.Windows.Forms.RadioButton m_rdbtUsuario;
		private System.Windows.Forms.RadioButton m_rdbtAdmin;
		private System.Windows.Forms.RadioButton m_rdbtWindows;
			private System.Windows.Forms.Button m_btServidor;
		#endregion
		#region Constructors
			public frmSiscoBDConexao()
			{
				InitializeComponent();
			}

			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSiscoBDConexao));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbOperacoes = new System.Windows.Forms.GroupBox();
			this.m_btServidorBaseDados = new System.Windows.Forms.Button();
			this.m_btServidor = new System.Windows.Forms.Button();
			this.m_gbConfiguracoes = new System.Windows.Forms.GroupBox();
			this.m_txtSenha = new System.Windows.Forms.TextBox();
			this.m_lbSenha = new System.Windows.Forms.Label();
			this.m_txtUsuario = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.m_txtBaseDados = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtPorta = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtServidor = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_gbBaseDados = new System.Windows.Forms.GroupBox();
			this.m_rdbtSqlServer = new System.Windows.Forms.RadioButton();
			this.m_gbOutput = new System.Windows.Forms.GroupBox();
			this.m_rtbOutput = new System.Windows.Forms.RichTextBox();
			this.m_gbAdmin = new System.Windows.Forms.GroupBox();
			this.m_txtAdminSenha = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.m_txtAdminUser = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.m_gbAutenticacao = new System.Windows.Forms.GroupBox();
			this.m_rdbtUsuario = new System.Windows.Forms.RadioButton();
			this.m_rdbtAdmin = new System.Windows.Forms.RadioButton();
			this.m_rdbtWindows = new System.Windows.Forms.RadioButton();
			this.m_gbMain.SuspendLayout();
			this.m_gbOperacoes.SuspendLayout();
			this.m_gbConfiguracoes.SuspendLayout();
			this.m_gbBaseDados.SuspendLayout();
			this.m_gbOutput.SuspendLayout();
			this.m_gbAdmin.SuspendLayout();
			this.m_gbAutenticacao.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbAutenticacao);
			this.m_gbMain.Controls.Add(this.m_gbOperacoes);
			this.m_gbMain.Controls.Add(this.m_gbConfiguracoes);
			this.m_gbMain.Controls.Add(this.m_gbBaseDados);
			this.m_gbMain.Controls.Add(this.m_gbOutput);
			this.m_gbMain.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMain.Location = new System.Drawing.Point(6, 2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(681, 460);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbOperacoes
			// 
			this.m_gbOperacoes.Controls.Add(this.m_btServidorBaseDados);
			this.m_gbOperacoes.Controls.Add(this.m_btServidor);
			this.m_gbOperacoes.Location = new System.Drawing.Point(8, 152);
			this.m_gbOperacoes.Name = "m_gbOperacoes";
			this.m_gbOperacoes.Size = new System.Drawing.Size(664, 104);
			this.m_gbOperacoes.TabIndex = 5;
			this.m_gbOperacoes.TabStop = false;
			this.m_gbOperacoes.Text = "Operações";
			// 
			// m_btServidorBaseDados
			// 
			this.m_btServidorBaseDados.Location = new System.Drawing.Point(8, 42);
			this.m_btServidorBaseDados.Name = "m_btServidorBaseDados";
			this.m_btServidorBaseDados.Size = new System.Drawing.Size(152, 24);
			this.m_btServidorBaseDados.TabIndex = 1;
			this.m_btServidorBaseDados.Text = "Servidor Base Dados";
			this.m_btServidorBaseDados.Click += new System.EventHandler(this.m_btServidorBaseDados_Click);
			// 
			// m_btServidor
			// 
			this.m_btServidor.Location = new System.Drawing.Point(8, 16);
			this.m_btServidor.Name = "m_btServidor";
			this.m_btServidor.Size = new System.Drawing.Size(152, 24);
			this.m_btServidor.TabIndex = 0;
			this.m_btServidor.Text = "Maquina Servidora";
			this.m_btServidor.Click += new System.EventHandler(this.m_btServidor_Click);
			// 
			// m_gbConfiguracoes
			// 
			this.m_gbConfiguracoes.Controls.Add(this.m_gbAdmin);
			this.m_gbConfiguracoes.Controls.Add(this.m_txtSenha);
			this.m_gbConfiguracoes.Controls.Add(this.m_lbSenha);
			this.m_gbConfiguracoes.Controls.Add(this.m_txtUsuario);
			this.m_gbConfiguracoes.Controls.Add(this.label4);
			this.m_gbConfiguracoes.Controls.Add(this.m_txtBaseDados);
			this.m_gbConfiguracoes.Controls.Add(this.label3);
			this.m_gbConfiguracoes.Controls.Add(this.m_txtPorta);
			this.m_gbConfiguracoes.Controls.Add(this.label2);
			this.m_gbConfiguracoes.Controls.Add(this.m_txtServidor);
			this.m_gbConfiguracoes.Controls.Add(this.label1);
			this.m_gbConfiguracoes.Location = new System.Drawing.Point(272, 8);
			this.m_gbConfiguracoes.Name = "m_gbConfiguracoes";
			this.m_gbConfiguracoes.Size = new System.Drawing.Size(400, 144);
			this.m_gbConfiguracoes.TabIndex = 4;
			this.m_gbConfiguracoes.TabStop = false;
			this.m_gbConfiguracoes.Text = "Configuracoes";
			// 
			// m_txtSenha
			// 
			this.m_txtSenha.Location = new System.Drawing.Point(73, 107);
			this.m_txtSenha.Name = "m_txtSenha";
			this.m_txtSenha.Size = new System.Drawing.Size(112, 20);
			this.m_txtSenha.TabIndex = 10;
			this.m_txtSenha.Text = "Siscobras";
			// 
			// m_lbSenha
			// 
			this.m_lbSenha.Location = new System.Drawing.Point(7, 109);
			this.m_lbSenha.Name = "m_lbSenha";
			this.m_lbSenha.Size = new System.Drawing.Size(72, 16);
			this.m_lbSenha.TabIndex = 11;
			this.m_lbSenha.Text = "Senha:";
			// 
			// m_txtUsuario
			// 
			this.m_txtUsuario.Location = new System.Drawing.Point(73, 85);
			this.m_txtUsuario.Name = "m_txtUsuario";
			this.m_txtUsuario.Size = new System.Drawing.Size(112, 20);
			this.m_txtUsuario.TabIndex = 8;
			this.m_txtUsuario.Text = "Siscobras";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 87);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "Usuario:";
			// 
			// m_txtBaseDados
			// 
			this.m_txtBaseDados.Location = new System.Drawing.Point(73, 62);
			this.m_txtBaseDados.Name = "m_txtBaseDados";
			this.m_txtBaseDados.Size = new System.Drawing.Size(112, 20);
			this.m_txtBaseDados.TabIndex = 6;
			this.m_txtBaseDados.Text = "Siscobras";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(5, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "BaseDados:";
			// 
			// m_txtPorta
			// 
			this.m_txtPorta.Location = new System.Drawing.Point(73, 42);
			this.m_txtPorta.Name = "m_txtPorta";
			this.m_txtPorta.Size = new System.Drawing.Size(112, 20);
			this.m_txtPorta.TabIndex = 4;
			this.m_txtPorta.Text = "1433";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Porta:";
			// 
			// m_txtServidor
			// 
			this.m_txtServidor.Location = new System.Drawing.Point(73, 20);
			this.m_txtServidor.Name = "m_txtServidor";
			this.m_txtServidor.Size = new System.Drawing.Size(112, 20);
			this.m_txtServidor.TabIndex = 2;
			this.m_txtServidor.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Servidor:";
			// 
			// m_gbBaseDados
			// 
			this.m_gbBaseDados.Controls.Add(this.m_rdbtSqlServer);
			this.m_gbBaseDados.Location = new System.Drawing.Point(7, 8);
			this.m_gbBaseDados.Name = "m_gbBaseDados";
			this.m_gbBaseDados.Size = new System.Drawing.Size(153, 144);
			this.m_gbBaseDados.TabIndex = 1;
			this.m_gbBaseDados.TabStop = false;
			this.m_gbBaseDados.Text = "Base de Dados";
			// 
			// m_rdbtSqlServer
			// 
			this.m_rdbtSqlServer.Checked = true;
			this.m_rdbtSqlServer.Location = new System.Drawing.Point(8, 24);
			this.m_rdbtSqlServer.Name = "m_rdbtSqlServer";
			this.m_rdbtSqlServer.Size = new System.Drawing.Size(136, 16);
			this.m_rdbtSqlServer.TabIndex = 0;
			this.m_rdbtSqlServer.TabStop = true;
			this.m_rdbtSqlServer.Text = "MSDE / SqlServer";
			// 
			// m_gbOutput
			// 
			this.m_gbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbOutput.Controls.Add(this.m_rtbOutput);
			this.m_gbOutput.Location = new System.Drawing.Point(8, 256);
			this.m_gbOutput.Name = "m_gbOutput";
			this.m_gbOutput.Size = new System.Drawing.Size(668, 192);
			this.m_gbOutput.TabIndex = 0;
			this.m_gbOutput.TabStop = false;
			this.m_gbOutput.Text = "Saida";
			// 
			// m_rtbOutput
			// 
			this.m_rtbOutput.Location = new System.Drawing.Point(8, 16);
			this.m_rtbOutput.Name = "m_rtbOutput";
			this.m_rtbOutput.ReadOnly = true;
			this.m_rtbOutput.Size = new System.Drawing.Size(648, 168);
			this.m_rtbOutput.TabIndex = 0;
			this.m_rtbOutput.Text = "";
			// 
			// m_gbAdmin
			// 
			this.m_gbAdmin.Controls.Add(this.m_txtAdminSenha);
			this.m_gbAdmin.Controls.Add(this.label5);
			this.m_gbAdmin.Controls.Add(this.m_txtAdminUser);
			this.m_gbAdmin.Controls.Add(this.label6);
			this.m_gbAdmin.Location = new System.Drawing.Point(192, 8);
			this.m_gbAdmin.Name = "m_gbAdmin";
			this.m_gbAdmin.Size = new System.Drawing.Size(200, 96);
			this.m_gbAdmin.TabIndex = 12;
			this.m_gbAdmin.TabStop = false;
			this.m_gbAdmin.Text = "Admin";
			// 
			// m_txtAdminSenha
			// 
			this.m_txtAdminSenha.Location = new System.Drawing.Point(80, 42);
			this.m_txtAdminSenha.Name = "m_txtAdminSenha";
			this.m_txtAdminSenha.Size = new System.Drawing.Size(112, 20);
			this.m_txtAdminSenha.TabIndex = 14;
			this.m_txtAdminSenha.Text = "Siscobras";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 44);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 15;
			this.label5.Text = "Senha:";
			// 
			// m_txtAdminUser
			// 
			this.m_txtAdminUser.Location = new System.Drawing.Point(80, 18);
			this.m_txtAdminUser.Name = "m_txtAdminUser";
			this.m_txtAdminUser.Size = new System.Drawing.Size(112, 20);
			this.m_txtAdminUser.TabIndex = 12;
			this.m_txtAdminUser.Text = "sa";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 13;
			this.label6.Text = "Usuario:";
			// 
			// m_gbAutenticacao
			// 
			this.m_gbAutenticacao.Controls.Add(this.m_rdbtWindows);
			this.m_gbAutenticacao.Controls.Add(this.m_rdbtAdmin);
			this.m_gbAutenticacao.Controls.Add(this.m_rdbtUsuario);
			this.m_gbAutenticacao.Location = new System.Drawing.Point(163, 7);
			this.m_gbAutenticacao.Name = "m_gbAutenticacao";
			this.m_gbAutenticacao.Size = new System.Drawing.Size(104, 145);
			this.m_gbAutenticacao.TabIndex = 6;
			this.m_gbAutenticacao.TabStop = false;
			this.m_gbAutenticacao.Text = "Autenticacao";
			// 
			// m_rdbtUsuario
			// 
			this.m_rdbtUsuario.Checked = true;
			this.m_rdbtUsuario.Location = new System.Drawing.Point(9, 19);
			this.m_rdbtUsuario.Name = "m_rdbtUsuario";
			this.m_rdbtUsuario.Size = new System.Drawing.Size(88, 16);
			this.m_rdbtUsuario.TabIndex = 0;
			this.m_rdbtUsuario.TabStop = true;
			this.m_rdbtUsuario.Text = "Usuario";
			// 
			// m_rdbtAdmin
			// 
			this.m_rdbtAdmin.Location = new System.Drawing.Point(10, 37);
			this.m_rdbtAdmin.Name = "m_rdbtAdmin";
			this.m_rdbtAdmin.Size = new System.Drawing.Size(88, 16);
			this.m_rdbtAdmin.TabIndex = 1;
			this.m_rdbtAdmin.Text = "Admin";
			// 
			// m_rdbtWindows
			// 
			this.m_rdbtWindows.Location = new System.Drawing.Point(10, 56);
			this.m_rdbtWindows.Name = "m_rdbtWindows";
			this.m_rdbtWindows.Size = new System.Drawing.Size(88, 16);
			this.m_rdbtWindows.TabIndex = 2;
			this.m_rdbtWindows.Text = "Windows";
			// 
			// frmSiscoBDConexao
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(694, 468);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSiscoBDConexao";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SiscoBDConexao";
			this.m_gbMain.ResumeLayout(false);
			this.m_gbOperacoes.ResumeLayout(false);
			this.m_gbConfiguracoes.ResumeLayout(false);
			this.m_gbBaseDados.ResumeLayout(false);
			this.m_gbOutput.ResumeLayout(false);
			this.m_gbAdmin.ResumeLayout(false);
			this.m_gbAutenticacao.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
			#region Buttons
				private void m_btServidor_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_rtbOutput.Text = OnCallServidor();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_btServidorBaseDados_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_rtbOutput.Text = OnCallServidorSqlServer();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
		#endregion
	}
}

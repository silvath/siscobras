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

		#region Constantes
			private const string AUTENTICACAO_NENHUMA = "Nenhuma";
			private const string AUTENTICACAO_AUTOMATICA = "Automatica";
			private const string AUTENTICACAO_DIGEST_MD5 = "Digest_MD5";
			private const string AUTENTICACAO_CRAM_MD5 = "Cram_MD5";
			private const string AUTENTICACAO_LOGIN = "LOGIN";
		#endregion
		#region Atributos

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.Label m_lCampoMensagem;
		private System.Windows.Forms.Label m_lCampoMensagemHTML;
		private System.Windows.Forms.Label m_lCampoRetorno;
		private System.Windows.Forms.Button m_btSocket;
		private System.Windows.Forms.TextBox m_txtDestinatario;
		private System.Windows.Forms.TextBox m_txtRemetente;
		private System.Windows.Forms.Label m_lbDestinatarios;
		private System.Windows.Forms.Label m_lbRemetente;
		private System.Windows.Forms.TextBox m_txtMensagemHTML;
		private System.Windows.Forms.TextBox m_txtMensagem;
		private System.Windows.Forms.TextBox m_txtAssunto;
		private System.Windows.Forms.TextBox m_txtArquivo;
		private System.Windows.Forms.Label m_lbAssunto;
		private System.Windows.Forms.Label m_lbArquivo;
		private System.Windows.Forms.TextBox m_txtRetorno;
		private System.Windows.Forms.GroupBox m_gbSMTP;
		private System.Windows.Forms.TextBox m_txtServidorSMTP;
		private System.Windows.Forms.Label m_lbServidor;
		private System.Windows.Forms.Label m_lbPorta;
		private System.Windows.Forms.TextBox m_txtPortaSMTP;
		private System.Windows.Forms.TextBox m_txtTimeOutSMTP;
		private System.Windows.Forms.Label m_lbTimeOut;
		private System.Windows.Forms.GroupBox m_gbAutenticacao;
		private System.Windows.Forms.TextBox m_txtAuthUser;
		private System.Windows.Forms.Label m_lbUser;
		private System.Windows.Forms.TextBox m_txtAuthPassword;
		private System.Windows.Forms.Label m_lbPass;
		private System.Windows.Forms.Label m_lbAuth;
		private System.Windows.Forms.ComboBox m_cbTipoAutenticacao;
		private System.Windows.Forms.Button m_btCryptoMD5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor and Destructors
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btCryptoMD5 = new System.Windows.Forms.Button();
			this.m_gbSMTP = new System.Windows.Forms.GroupBox();
			this.m_gbAutenticacao = new System.Windows.Forms.GroupBox();
			this.m_lbAuth = new System.Windows.Forms.Label();
			this.m_cbTipoAutenticacao = new System.Windows.Forms.ComboBox();
			this.m_txtAuthPassword = new System.Windows.Forms.TextBox();
			this.m_lbPass = new System.Windows.Forms.Label();
			this.m_txtAuthUser = new System.Windows.Forms.TextBox();
			this.m_lbUser = new System.Windows.Forms.Label();
			this.m_txtTimeOutSMTP = new System.Windows.Forms.TextBox();
			this.m_lbTimeOut = new System.Windows.Forms.Label();
			this.m_txtPortaSMTP = new System.Windows.Forms.TextBox();
			this.m_lbPorta = new System.Windows.Forms.Label();
			this.m_txtServidorSMTP = new System.Windows.Forms.TextBox();
			this.m_lbServidor = new System.Windows.Forms.Label();
			this.m_txtMensagemHTML = new System.Windows.Forms.TextBox();
			this.m_txtMensagem = new System.Windows.Forms.TextBox();
			this.m_btSocket = new System.Windows.Forms.Button();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_txtAssunto = new System.Windows.Forms.TextBox();
			this.m_txtArquivo = new System.Windows.Forms.TextBox();
			this.m_txtDestinatario = new System.Windows.Forms.TextBox();
			this.m_txtRemetente = new System.Windows.Forms.TextBox();
			this.m_lCampoRetorno = new System.Windows.Forms.Label();
			this.m_lCampoMensagemHTML = new System.Windows.Forms.Label();
			this.m_lCampoMensagem = new System.Windows.Forms.Label();
			this.m_lbAssunto = new System.Windows.Forms.Label();
			this.m_lbArquivo = new System.Windows.Forms.Label();
			this.m_lbDestinatarios = new System.Windows.Forms.Label();
			this.m_lbRemetente = new System.Windows.Forms.Label();
			this.m_gbFrame.SuspendLayout();
			this.m_gbSMTP.SuspendLayout();
			this.m_gbAutenticacao.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Controls.Add(this.m_btCryptoMD5);
			this.m_gbFrame.Controls.Add(this.m_gbSMTP);
			this.m_gbFrame.Controls.Add(this.m_txtMensagemHTML);
			this.m_gbFrame.Controls.Add(this.m_txtMensagem);
			this.m_gbFrame.Controls.Add(this.m_btSocket);
			this.m_gbFrame.Controls.Add(this.m_txtRetorno);
			this.m_gbFrame.Controls.Add(this.m_txtAssunto);
			this.m_gbFrame.Controls.Add(this.m_txtArquivo);
			this.m_gbFrame.Controls.Add(this.m_txtDestinatario);
			this.m_gbFrame.Controls.Add(this.m_txtRemetente);
			this.m_gbFrame.Controls.Add(this.m_lCampoRetorno);
			this.m_gbFrame.Controls.Add(this.m_lCampoMensagemHTML);
			this.m_gbFrame.Controls.Add(this.m_lCampoMensagem);
			this.m_gbFrame.Controls.Add(this.m_lbAssunto);
			this.m_gbFrame.Controls.Add(this.m_lbArquivo);
			this.m_gbFrame.Controls.Add(this.m_lbDestinatarios);
			this.m_gbFrame.Controls.Add(this.m_lbRemetente);
			this.m_gbFrame.Location = new System.Drawing.Point(2, -5);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(412, 573);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btCryptoMD5
			// 
			this.m_btCryptoMD5.Location = new System.Drawing.Point(9, 495);
			this.m_btCryptoMD5.Name = "m_btCryptoMD5";
			this.m_btCryptoMD5.Size = new System.Drawing.Size(64, 40);
			this.m_btCryptoMD5.TabIndex = 19;
			this.m_btCryptoMD5.Text = "MD5";
			this.m_btCryptoMD5.Click += new System.EventHandler(this.m_btCryptoMD5_Click);
			// 
			// m_gbSMTP
			// 
			this.m_gbSMTP.Controls.Add(this.m_gbAutenticacao);
			this.m_gbSMTP.Controls.Add(this.m_txtTimeOutSMTP);
			this.m_gbSMTP.Controls.Add(this.m_lbTimeOut);
			this.m_gbSMTP.Controls.Add(this.m_txtPortaSMTP);
			this.m_gbSMTP.Controls.Add(this.m_lbPorta);
			this.m_gbSMTP.Controls.Add(this.m_txtServidorSMTP);
			this.m_gbSMTP.Controls.Add(this.m_lbServidor);
			this.m_gbSMTP.Location = new System.Drawing.Point(9, 16);
			this.m_gbSMTP.Name = "m_gbSMTP";
			this.m_gbSMTP.Size = new System.Drawing.Size(392, 112);
			this.m_gbSMTP.TabIndex = 18;
			this.m_gbSMTP.TabStop = false;
			this.m_gbSMTP.Text = "SMTP";
			// 
			// m_gbAutenticacao
			// 
			this.m_gbAutenticacao.Controls.Add(this.m_lbAuth);
			this.m_gbAutenticacao.Controls.Add(this.m_cbTipoAutenticacao);
			this.m_gbAutenticacao.Controls.Add(this.m_txtAuthPassword);
			this.m_gbAutenticacao.Controls.Add(this.m_lbPass);
			this.m_gbAutenticacao.Controls.Add(this.m_txtAuthUser);
			this.m_gbAutenticacao.Controls.Add(this.m_lbUser);
			this.m_gbAutenticacao.Location = new System.Drawing.Point(200, 8);
			this.m_gbAutenticacao.Name = "m_gbAutenticacao";
			this.m_gbAutenticacao.Size = new System.Drawing.Size(184, 96);
			this.m_gbAutenticacao.TabIndex = 15;
			this.m_gbAutenticacao.TabStop = false;
			this.m_gbAutenticacao.Text = "Autenticação";
			// 
			// m_lbAuth
			// 
			this.m_lbAuth.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbAuth.Location = new System.Drawing.Point(8, 22);
			this.m_lbAuth.Name = "m_lbAuth";
			this.m_lbAuth.Size = new System.Drawing.Size(32, 13);
			this.m_lbAuth.TabIndex = 17;
			this.m_lbAuth.Text = "Auth:";
			// 
			// m_cbTipoAutenticacao
			// 
			this.m_cbTipoAutenticacao.Location = new System.Drawing.Point(41, 16);
			this.m_cbTipoAutenticacao.Name = "m_cbTipoAutenticacao";
			this.m_cbTipoAutenticacao.Size = new System.Drawing.Size(136, 21);
			this.m_cbTipoAutenticacao.TabIndex = 16;
			// 
			// m_txtAuthPassword
			// 
			this.m_txtAuthPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtAuthPassword.Location = new System.Drawing.Point(40, 66);
			this.m_txtAuthPassword.Name = "m_txtAuthPassword";
			this.m_txtAuthPassword.PasswordChar = '*';
			this.m_txtAuthPassword.Size = new System.Drawing.Size(137, 20);
			this.m_txtAuthPassword.TabIndex = 15;
			this.m_txtAuthPassword.Text = "thsilva";
			// 
			// m_lbPass
			// 
			this.m_lbPass.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbPass.Location = new System.Drawing.Point(8, 66);
			this.m_lbPass.Name = "m_lbPass";
			this.m_lbPass.Size = new System.Drawing.Size(32, 13);
			this.m_lbPass.TabIndex = 14;
			this.m_lbPass.Text = "Pass:";
			// 
			// m_txtAuthUser
			// 
			this.m_txtAuthUser.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtAuthUser.Location = new System.Drawing.Point(39, 42);
			this.m_txtAuthUser.Name = "m_txtAuthUser";
			this.m_txtAuthUser.Size = new System.Drawing.Size(137, 20);
			this.m_txtAuthUser.TabIndex = 13;
			this.m_txtAuthUser.Text = "ths@siscobras.com.br";
			// 
			// m_lbUser
			// 
			this.m_lbUser.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbUser.Location = new System.Drawing.Point(7, 45);
			this.m_lbUser.Name = "m_lbUser";
			this.m_lbUser.Size = new System.Drawing.Size(32, 13);
			this.m_lbUser.TabIndex = 12;
			this.m_lbUser.Text = "User:";
			// 
			// m_txtTimeOutSMTP
			// 
			this.m_txtTimeOutSMTP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtTimeOutSMTP.Location = new System.Drawing.Point(56, 55);
			this.m_txtTimeOutSMTP.Name = "m_txtTimeOutSMTP";
			this.m_txtTimeOutSMTP.Size = new System.Drawing.Size(136, 20);
			this.m_txtTimeOutSMTP.TabIndex = 13;
			this.m_txtTimeOutSMTP.Text = "30";
			this.m_txtTimeOutSMTP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbTimeOut
			// 
			this.m_lbTimeOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTimeOut.Location = new System.Drawing.Point(7, 56);
			this.m_lbTimeOut.Name = "m_lbTimeOut";
			this.m_lbTimeOut.Size = new System.Drawing.Size(66, 13);
			this.m_lbTimeOut.TabIndex = 12;
			this.m_lbTimeOut.Text = "TIMEOUT:";
			// 
			// m_txtPortaSMTP
			// 
			this.m_txtPortaSMTP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtPortaSMTP.Location = new System.Drawing.Point(57, 35);
			this.m_txtPortaSMTP.Name = "m_txtPortaSMTP";
			this.m_txtPortaSMTP.Size = new System.Drawing.Size(135, 20);
			this.m_txtPortaSMTP.TabIndex = 11;
			this.m_txtPortaSMTP.Text = "25";
			this.m_txtPortaSMTP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbPorta
			// 
			this.m_lbPorta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbPorta.Location = new System.Drawing.Point(9, 36);
			this.m_lbPorta.Name = "m_lbPorta";
			this.m_lbPorta.Size = new System.Drawing.Size(39, 13);
			this.m_lbPorta.TabIndex = 10;
			this.m_lbPorta.Text = "Porta:";
			// 
			// m_txtServidorSMTP
			// 
			this.m_txtServidorSMTP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtServidorSMTP.Location = new System.Drawing.Point(57, 13);
			this.m_txtServidorSMTP.Name = "m_txtServidorSMTP";
			this.m_txtServidorSMTP.Size = new System.Drawing.Size(135, 20);
			this.m_txtServidorSMTP.TabIndex = 9;
			this.m_txtServidorSMTP.Text = "smtp.siscobras.com.br";
			// 
			// m_lbServidor
			// 
			this.m_lbServidor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbServidor.Location = new System.Drawing.Point(8, 18);
			this.m_lbServidor.Name = "m_lbServidor";
			this.m_lbServidor.Size = new System.Drawing.Size(48, 13);
			this.m_lbServidor.TabIndex = 8;
			this.m_lbServidor.Text = "Servidor:";
			// 
			// m_txtMensagemHTML
			// 
			this.m_txtMensagemHTML.Location = new System.Drawing.Point(8, 377);
			this.m_txtMensagemHTML.Multiline = true;
			this.m_txtMensagemHTML.Name = "m_txtMensagemHTML";
			this.m_txtMensagemHTML.Size = new System.Drawing.Size(396, 107);
			this.m_txtMensagemHTML.TabIndex = 17;
			this.m_txtMensagemHTML.Text = "";
			// 
			// m_txtMensagem
			// 
			this.m_txtMensagem.Location = new System.Drawing.Point(8, 246);
			this.m_txtMensagem.Multiline = true;
			this.m_txtMensagem.Name = "m_txtMensagem";
			this.m_txtMensagem.Size = new System.Drawing.Size(396, 107);
			this.m_txtMensagem.TabIndex = 16;
			this.m_txtMensagem.Text = "ths@siscobras.com.br";
			// 
			// m_btSocket
			// 
			this.m_btSocket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btSocket.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btSocket.Location = new System.Drawing.Point(128, 496);
			this.m_btSocket.Name = "m_btSocket";
			this.m_btSocket.Size = new System.Drawing.Size(144, 40);
			this.m_btSocket.TabIndex = 15;
			this.m_btSocket.Text = "Enviar E-mail Socket";
			this.m_btSocket.Click += new System.EventHandler(this.m_btSocket_Click);
			// 
			// m_txtRetorno
			// 
			this.m_txtRetorno.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtRetorno.Location = new System.Drawing.Point(64, 542);
			this.m_txtRetorno.Name = "m_txtRetorno";
			this.m_txtRetorno.Size = new System.Drawing.Size(340, 20);
			this.m_txtRetorno.TabIndex = 13;
			this.m_txtRetorno.Text = "";
			// 
			// m_txtAssunto
			// 
			this.m_txtAssunto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtAssunto.Location = new System.Drawing.Point(80, 210);
			this.m_txtAssunto.Name = "m_txtAssunto";
			this.m_txtAssunto.Size = new System.Drawing.Size(320, 20);
			this.m_txtAssunto.TabIndex = 10;
			this.m_txtAssunto.Text = "ths@inf.ufsc.br";
			// 
			// m_txtArquivo
			// 
			this.m_txtArquivo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtArquivo.Location = new System.Drawing.Point(80, 185);
			this.m_txtArquivo.Name = "m_txtArquivo";
			this.m_txtArquivo.Size = new System.Drawing.Size(320, 20);
			this.m_txtArquivo.TabIndex = 9;
			this.m_txtArquivo.Text = "";
			// 
			// m_txtDestinatario
			// 
			this.m_txtDestinatario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtDestinatario.Location = new System.Drawing.Point(80, 160);
			this.m_txtDestinatario.Name = "m_txtDestinatario";
			this.m_txtDestinatario.Size = new System.Drawing.Size(320, 20);
			this.m_txtDestinatario.TabIndex = 8;
			this.m_txtDestinatario.Text = "ths@despacho.com.br";
			// 
			// m_txtRemetente
			// 
			this.m_txtRemetente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtRemetente.Location = new System.Drawing.Point(80, 135);
			this.m_txtRemetente.Name = "m_txtRemetente";
			this.m_txtRemetente.Size = new System.Drawing.Size(320, 20);
			this.m_txtRemetente.TabIndex = 7;
			this.m_txtRemetente.Text = "ths@siscobras.com.br";
			// 
			// m_lCampoRetorno
			// 
			this.m_lCampoRetorno.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCampoRetorno.Location = new System.Drawing.Point(8, 542);
			this.m_lCampoRetorno.Name = "m_lCampoRetorno";
			this.m_lCampoRetorno.Size = new System.Drawing.Size(48, 14);
			this.m_lCampoRetorno.TabIndex = 6;
			this.m_lCampoRetorno.Text = "Retorno:";
			// 
			// m_lCampoMensagemHTML
			// 
			this.m_lCampoMensagemHTML.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCampoMensagemHTML.Location = new System.Drawing.Point(8, 358);
			this.m_lCampoMensagemHTML.Name = "m_lCampoMensagemHTML";
			this.m_lCampoMensagemHTML.Size = new System.Drawing.Size(94, 14);
			this.m_lCampoMensagemHTML.TabIndex = 5;
			this.m_lCampoMensagemHTML.Text = "MensagemHTML:";
			// 
			// m_lCampoMensagem
			// 
			this.m_lCampoMensagem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCampoMensagem.Location = new System.Drawing.Point(9, 229);
			this.m_lCampoMensagem.Name = "m_lCampoMensagem";
			this.m_lCampoMensagem.Size = new System.Drawing.Size(63, 14);
			this.m_lCampoMensagem.TabIndex = 4;
			this.m_lCampoMensagem.Text = "Mensagem:";
			// 
			// m_lbAssunto
			// 
			this.m_lbAssunto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbAssunto.Location = new System.Drawing.Point(8, 210);
			this.m_lbAssunto.Name = "m_lbAssunto";
			this.m_lbAssunto.Size = new System.Drawing.Size(48, 14);
			this.m_lbAssunto.TabIndex = 3;
			this.m_lbAssunto.Text = "Assunto:";
			// 
			// m_lbArquivo
			// 
			this.m_lbArquivo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbArquivo.Location = new System.Drawing.Point(8, 185);
			this.m_lbArquivo.Name = "m_lbArquivo";
			this.m_lbArquivo.Size = new System.Drawing.Size(46, 14);
			this.m_lbArquivo.TabIndex = 2;
			this.m_lbArquivo.Text = "Arquivo:";
			// 
			// m_lbDestinatarios
			// 
			this.m_lbDestinatarios.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbDestinatarios.Location = new System.Drawing.Point(8, 160);
			this.m_lbDestinatarios.Name = "m_lbDestinatarios";
			this.m_lbDestinatarios.Size = new System.Drawing.Size(72, 12);
			this.m_lbDestinatarios.TabIndex = 1;
			this.m_lbDestinatarios.Text = "Destinatarios:";
			// 
			// m_lbRemetente
			// 
			this.m_lbRemetente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbRemetente.Location = new System.Drawing.Point(8, 135);
			this.m_lbRemetente.Name = "m_lbRemetente";
			this.m_lbRemetente.Size = new System.Drawing.Size(64, 13);
			this.m_lbRemetente.TabIndex = 0;
			this.m_lbRemetente.Text = "Remetente:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 574);
			this.Controls.Add(this.m_gbFrame);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Siscobras Email";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbSMTP.ResumeLayout(false);
			this.m_gbAutenticacao.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void Form1_Load(object sender, System.EventArgs e)
				{
					vRefreshAutenticacao();
				}
			#endregion
		#endregion
		#region cbAutenticacao
			private void vRefreshAutenticacao()
			{
                m_cbTipoAutenticacao.Items.Clear();
				m_cbTipoAutenticacao.Items.Add(AUTENTICACAO_NENHUMA);
				m_cbTipoAutenticacao.Items.Add(AUTENTICACAO_AUTOMATICA);
				m_cbTipoAutenticacao.Items.Add(AUTENTICACAO_DIGEST_MD5);
				m_cbTipoAutenticacao.Items.Add(AUTENTICACAO_CRAM_MD5);
				m_cbTipoAutenticacao.Items.Add(AUTENTICACAO_LOGIN);
				m_cbTipoAutenticacao.Text = AUTENTICACAO_NENHUMA;
			}
		#endregion

		#region Envio Email
		private void m_btSocket_Click(object sender, System.EventArgs e)
		{
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			m_txtRetorno.Text = "";

			mdlEmail.clsEmailSocket objEmail = new mdlEmail.clsEmailSocket();

			// SMTP
			objEmail.SMTP = m_txtServidorSMTP.Text;	
			objEmail.Porta = Int32.Parse(m_txtPortaSMTP.Text);
			objEmail.TIMEOUT = Int32.Parse(m_txtTimeOutSMTP.Text);

			// Autenticacao
			switch(m_cbTipoAutenticacao.Text)
			{
				case AUTENTICACAO_NENHUMA:
					objEmail.AutenticacaoTipo = mdlEmail.AUTENTICACAO.Nenhuma;
					break;
				case AUTENTICACAO_AUTOMATICA:
					objEmail.AutenticacaoTipo = mdlEmail.AUTENTICACAO.Automatica;
					break;
				case AUTENTICACAO_DIGEST_MD5:
					objEmail.AutenticacaoTipo = mdlEmail.AUTENTICACAO.DIGEST_MD5;
					break;
				case AUTENTICACAO_CRAM_MD5:
					objEmail.AutenticacaoTipo = mdlEmail.AUTENTICACAO.CRAM_MD5;
					break;
				case AUTENTICACAO_LOGIN:
					objEmail.AutenticacaoTipo = mdlEmail.AUTENTICACAO.LOGIN;
					break;
				default:
					objEmail.AutenticacaoTipo = mdlEmail.AUTENTICACAO.Nenhuma;
					break;
			}
			objEmail.UsuarioAutenticacao = m_txtAuthUser.Text;
			objEmail.SenhaAutenticacao = m_txtAuthPassword.Text;

			// Remetente
			objEmail.Remetente = m_txtRemetente.Text;

			// Destinatario
			System.Collections.ArrayList arlDestinatarios = new System.Collections.ArrayList();
			string strDestinatarios = m_txtDestinatario.Text;
			int nPos;
			while (strDestinatarios != "")
			{
				if ((nPos = strDestinatarios.IndexOf(";")) >= 0)
				{
					arlDestinatarios.Add(strDestinatarios.Substring(0,nPos));
					strDestinatarios = strDestinatarios.Substring(nPos + 1);
				}else{
					arlDestinatarios.Add(strDestinatarios);
					strDestinatarios = "";
				}
			}
			objEmail.Destinatarios = arlDestinatarios;

			// Assunto 
			objEmail.Assunto = m_txtAssunto.Text;
			objEmail.Assunto = System.DateTime.Now.ToString();

			// Mensagem 
			objEmail.Mensagem = m_txtMensagem.Text;

			// Mensagem HTML
			objEmail.MensagemHTML = m_txtMensagemHTML.Text;

			// Arquivos Atachados 
			if (m_txtArquivo.Text != "")
			{
				System.Collections.ArrayList arlArquivos = new System.Collections.ArrayList();
				arlArquivos.Add(m_txtArquivo.Text);
				objEmail.ArquivosAtachados = arlArquivos;
			}

			m_txtRetorno.Text = objEmail.strEnviaEmail();

			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion

		#region MD5
			private void m_btCryptoMD5_Click(object sender, System.EventArgs e)
			{
				mdlEmail.clsEmailSocket objEmail = new mdlEmail.clsEmailSocket();
				m_txtRetorno.Text = objEmail.strComputeHashMD5(m_txtArquivo.Text);
			}
		#endregion

	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlTratamentoErro.Formularios
{
	/// <summary>
	/// Summary description for frmFInformacoesProblema.
	/// </summary>
	public class frmFInformacoesProblema : System.Windows.Forms.Form
	{
		#region Atributos
			internal System.Windows.Forms.Label lbInfo;
			internal System.Windows.Forms.Button btOk;
			internal System.Windows.Forms.Label m_lbCodigoCliente;
			private System.Windows.Forms.TextBox m_txtCodigoCliente;
			private System.Windows.Forms.GroupBox m_gbInformacoesCliente;
			internal System.Windows.Forms.Label m_lbNomeMaquina;
			private System.Windows.Forms.TextBox m_txtNomeMaquina;
			internal System.Windows.Forms.Label label1;
			private System.Windows.Forms.TextBox m_txtNomeUsuario;
			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Label m_lbVersaoServidor;
			private System.Windows.Forms.TextBox m_txtVersaoServidor;
			internal System.Windows.Forms.Label label2;
			private System.Windows.Forms.TextBox m_txtVersaoCliente;
			private System.Windows.Forms.GroupBox m_gbInformacoesDiscrepancia;
			internal System.Windows.Forms.Label m_lbExceptionSource;
			private System.Windows.Forms.TextBox m_txtExceptionSource;
			internal System.Windows.Forms.Label m_lbExceptionMessage;
			private System.Windows.Forms.TextBox m_txtExceptionMessage;
			internal System.Windows.Forms.Label m_lbExceptionStackTrace;
			private System.Windows.Forms.TextBox m_txtExceptionStackTrace;
			internal System.Windows.Forms.Label m_lbExceptionHelpLink;
			private System.Windows.Forms.TextBox m_txtExceptionHelpLink;
			internal System.Windows.Forms.Label m_lbExceptionString;
			private System.Windows.Forms.TextBox m_txtExceptionString;
		internal System.Windows.Forms.Label m_lbExceptionTargetSite;
		private System.Windows.Forms.TextBox m_txtExceptionTargetSite;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Delegates
			public delegate mdlDataBaseAccess.Tabelas.XsdTbErros.tbErrosRow delCallCarregaInformacoes();
		#endregion
		#region Events
			public event delCallCarregaInformacoes eCallCarregaInformacoes;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaInformacoes()
			{
				if (eCallCarregaInformacoes != null)
				{
					mdlDataBaseAccess.Tabelas.XsdTbErros.tbErrosRow dtrwDados = eCallCarregaInformacoes();
					if (dtrwDados != null)
					{
						m_txtCodigoCliente.Text = dtrwDados.mstrCodigoCliente;
						m_txtNomeMaquina.Text = dtrwDados.mstrNomeMaquina;
						m_txtNomeUsuario.Text = dtrwDados.mstrUsuario;
						m_txtVersaoServidor.Text = dtrwDados.strVersaoServidor;
						m_txtVersaoCliente.Text = dtrwDados.strVersaoCliente;

						m_txtExceptionSource.Text = dtrwDados.mstrExceptionSource;
						m_txtExceptionMessage.Text = dtrwDados.mstrExceptionMessage;
						m_txtExceptionStackTrace.Text = dtrwDados.mstrExceptionStackTrace;
						m_txtExceptionTargetSite.Text = dtrwDados.mstrExceptionTargetSite;
						m_txtExceptionHelpLink.Text = dtrwDados.mstrExceptionHelpLink;
						m_txtExceptionString.Text = dtrwDados.mstrExceptionString;
					}
				}
			}
		#endregion
		#region Constructors and Destructors
			public frmFInformacoesProblema()
			{
				InitializeComponent();
			}

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFInformacoesProblema));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbInformacoesDiscrepancia = new System.Windows.Forms.GroupBox();
			this.m_lbExceptionTargetSite = new System.Windows.Forms.Label();
			this.m_txtExceptionTargetSite = new System.Windows.Forms.TextBox();
			this.m_lbExceptionString = new System.Windows.Forms.Label();
			this.m_txtExceptionString = new System.Windows.Forms.TextBox();
			this.m_lbExceptionHelpLink = new System.Windows.Forms.Label();
			this.m_txtExceptionHelpLink = new System.Windows.Forms.TextBox();
			this.m_lbExceptionStackTrace = new System.Windows.Forms.Label();
			this.m_txtExceptionStackTrace = new System.Windows.Forms.TextBox();
			this.m_lbExceptionMessage = new System.Windows.Forms.Label();
			this.m_txtExceptionMessage = new System.Windows.Forms.TextBox();
			this.m_lbExceptionSource = new System.Windows.Forms.Label();
			this.m_txtExceptionSource = new System.Windows.Forms.TextBox();
			this.m_gbInformacoesCliente = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtVersaoCliente = new System.Windows.Forms.TextBox();
			this.m_lbVersaoServidor = new System.Windows.Forms.Label();
			this.m_txtVersaoServidor = new System.Windows.Forms.TextBox();
			this.m_txtNomeUsuario = new System.Windows.Forms.TextBox();
			this.m_lbNomeMaquina = new System.Windows.Forms.Label();
			this.m_txtNomeMaquina = new System.Windows.Forms.TextBox();
			this.m_lbCodigoCliente = new System.Windows.Forms.Label();
			this.m_txtCodigoCliente = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbInfo = new System.Windows.Forms.Label();
			this.btOk = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbInformacoesDiscrepancia.SuspendLayout();
			this.m_gbInformacoesCliente.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.BackColor = System.Drawing.SystemColors.Control;
			this.m_gbGeral.Controls.Add(this.m_gbInformacoesDiscrepancia);
			this.m_gbGeral.Controls.Add(this.m_gbInformacoesCliente);
			this.m_gbGeral.Controls.Add(this.lbInfo);
			this.m_gbGeral.Controls.Add(this.btOk);
			this.m_gbGeral.Location = new System.Drawing.Point(5, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(491, 400);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbInformacoesDiscrepancia
			// 
			this.m_gbInformacoesDiscrepancia.Controls.Add(this.m_lbExceptionTargetSite);
			this.m_gbInformacoesDiscrepancia.Controls.Add(this.m_txtExceptionTargetSite);
			this.m_gbInformacoesDiscrepancia.Controls.Add(this.m_lbExceptionString);
			this.m_gbInformacoesDiscrepancia.Controls.Add(this.m_txtExceptionString);
			this.m_gbInformacoesDiscrepancia.Controls.Add(this.m_lbExceptionHelpLink);
			this.m_gbInformacoesDiscrepancia.Controls.Add(this.m_txtExceptionHelpLink);
			this.m_gbInformacoesDiscrepancia.Controls.Add(this.m_lbExceptionStackTrace);
			this.m_gbInformacoesDiscrepancia.Controls.Add(this.m_txtExceptionStackTrace);
			this.m_gbInformacoesDiscrepancia.Controls.Add(this.m_lbExceptionMessage);
			this.m_gbInformacoesDiscrepancia.Controls.Add(this.m_txtExceptionMessage);
			this.m_gbInformacoesDiscrepancia.Controls.Add(this.m_lbExceptionSource);
			this.m_gbInformacoesDiscrepancia.Controls.Add(this.m_txtExceptionSource);
			this.m_gbInformacoesDiscrepancia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoesDiscrepancia.Location = new System.Drawing.Point(8, 122);
			this.m_gbInformacoesDiscrepancia.Name = "m_gbInformacoesDiscrepancia";
			this.m_gbInformacoesDiscrepancia.Size = new System.Drawing.Size(477, 238);
			this.m_gbInformacoesDiscrepancia.TabIndex = 9;
			this.m_gbInformacoesDiscrepancia.TabStop = false;
			this.m_gbInformacoesDiscrepancia.Text = "Discrepância";
			// 
			// m_lbExceptionTargetSite
			// 
			this.m_lbExceptionTargetSite.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbExceptionTargetSite.Location = new System.Drawing.Point(10, 89);
			this.m_lbExceptionTargetSite.Name = "m_lbExceptionTargetSite";
			this.m_lbExceptionTargetSite.Size = new System.Drawing.Size(80, 16);
			this.m_lbExceptionTargetSite.TabIndex = 24;
			this.m_lbExceptionTargetSite.Text = "Método:";
			// 
			// m_txtExceptionTargetSite
			// 
			this.m_txtExceptionTargetSite.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtExceptionTargetSite.Location = new System.Drawing.Point(103, 87);
			this.m_txtExceptionTargetSite.Name = "m_txtExceptionTargetSite";
			this.m_txtExceptionTargetSite.ReadOnly = true;
			this.m_txtExceptionTargetSite.Size = new System.Drawing.Size(369, 20);
			this.m_txtExceptionTargetSite.TabIndex = 25;
			this.m_txtExceptionTargetSite.Text = "";
			// 
			// m_lbExceptionString
			// 
			this.m_lbExceptionString.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbExceptionString.Location = new System.Drawing.Point(10, 133);
			this.m_lbExceptionString.Name = "m_lbExceptionString";
			this.m_lbExceptionString.Size = new System.Drawing.Size(80, 16);
			this.m_lbExceptionString.TabIndex = 22;
			this.m_lbExceptionString.Text = "Descrição:";
			// 
			// m_txtExceptionString
			// 
			this.m_txtExceptionString.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtExceptionString.Location = new System.Drawing.Point(103, 131);
			this.m_txtExceptionString.Multiline = true;
			this.m_txtExceptionString.Name = "m_txtExceptionString";
			this.m_txtExceptionString.ReadOnly = true;
			this.m_txtExceptionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtExceptionString.Size = new System.Drawing.Size(369, 101);
			this.m_txtExceptionString.TabIndex = 23;
			this.m_txtExceptionString.Text = "";
			// 
			// m_lbExceptionHelpLink
			// 
			this.m_lbExceptionHelpLink.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbExceptionHelpLink.Location = new System.Drawing.Point(10, 111);
			this.m_lbExceptionHelpLink.Name = "m_lbExceptionHelpLink";
			this.m_lbExceptionHelpLink.Size = new System.Drawing.Size(80, 16);
			this.m_lbExceptionHelpLink.TabIndex = 20;
			this.m_lbExceptionHelpLink.Text = "Ajuda:";
			// 
			// m_txtExceptionHelpLink
			// 
			this.m_txtExceptionHelpLink.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtExceptionHelpLink.Location = new System.Drawing.Point(103, 109);
			this.m_txtExceptionHelpLink.Name = "m_txtExceptionHelpLink";
			this.m_txtExceptionHelpLink.ReadOnly = true;
			this.m_txtExceptionHelpLink.Size = new System.Drawing.Size(369, 20);
			this.m_txtExceptionHelpLink.TabIndex = 21;
			this.m_txtExceptionHelpLink.Text = "";
			// 
			// m_lbExceptionStackTrace
			// 
			this.m_lbExceptionStackTrace.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbExceptionStackTrace.Location = new System.Drawing.Point(11, 68);
			this.m_lbExceptionStackTrace.Name = "m_lbExceptionStackTrace";
			this.m_lbExceptionStackTrace.Size = new System.Drawing.Size(80, 16);
			this.m_lbExceptionStackTrace.TabIndex = 18;
			this.m_lbExceptionStackTrace.Text = "Objeto:";
			// 
			// m_txtExceptionStackTrace
			// 
			this.m_txtExceptionStackTrace.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtExceptionStackTrace.Location = new System.Drawing.Point(103, 66);
			this.m_txtExceptionStackTrace.Name = "m_txtExceptionStackTrace";
			this.m_txtExceptionStackTrace.ReadOnly = true;
			this.m_txtExceptionStackTrace.Size = new System.Drawing.Size(369, 20);
			this.m_txtExceptionStackTrace.TabIndex = 19;
			this.m_txtExceptionStackTrace.Text = "";
			// 
			// m_lbExceptionMessage
			// 
			this.m_lbExceptionMessage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbExceptionMessage.Location = new System.Drawing.Point(8, 46);
			this.m_lbExceptionMessage.Name = "m_lbExceptionMessage";
			this.m_lbExceptionMessage.Size = new System.Drawing.Size(80, 16);
			this.m_lbExceptionMessage.TabIndex = 16;
			this.m_lbExceptionMessage.Text = "Mensagem:";
			// 
			// m_txtExceptionMessage
			// 
			this.m_txtExceptionMessage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtExceptionMessage.Location = new System.Drawing.Point(103, 44);
			this.m_txtExceptionMessage.Name = "m_txtExceptionMessage";
			this.m_txtExceptionMessage.ReadOnly = true;
			this.m_txtExceptionMessage.Size = new System.Drawing.Size(369, 20);
			this.m_txtExceptionMessage.TabIndex = 17;
			this.m_txtExceptionMessage.Text = "";
			// 
			// m_lbExceptionSource
			// 
			this.m_lbExceptionSource.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbExceptionSource.Location = new System.Drawing.Point(8, 24);
			this.m_lbExceptionSource.Name = "m_lbExceptionSource";
			this.m_lbExceptionSource.Size = new System.Drawing.Size(80, 16);
			this.m_lbExceptionSource.TabIndex = 14;
			this.m_lbExceptionSource.Text = "Plataforma:";
			// 
			// m_txtExceptionSource
			// 
			this.m_txtExceptionSource.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtExceptionSource.Location = new System.Drawing.Point(103, 22);
			this.m_txtExceptionSource.Name = "m_txtExceptionSource";
			this.m_txtExceptionSource.ReadOnly = true;
			this.m_txtExceptionSource.Size = new System.Drawing.Size(369, 20);
			this.m_txtExceptionSource.TabIndex = 15;
			this.m_txtExceptionSource.Text = "";
			// 
			// m_gbInformacoesCliente
			// 
			this.m_gbInformacoesCliente.Controls.Add(this.label2);
			this.m_gbInformacoesCliente.Controls.Add(this.m_txtVersaoCliente);
			this.m_gbInformacoesCliente.Controls.Add(this.m_lbVersaoServidor);
			this.m_gbInformacoesCliente.Controls.Add(this.m_txtVersaoServidor);
			this.m_gbInformacoesCliente.Controls.Add(this.m_txtNomeUsuario);
			this.m_gbInformacoesCliente.Controls.Add(this.m_lbNomeMaquina);
			this.m_gbInformacoesCliente.Controls.Add(this.m_txtNomeMaquina);
			this.m_gbInformacoesCliente.Controls.Add(this.m_lbCodigoCliente);
			this.m_gbInformacoesCliente.Controls.Add(this.m_txtCodigoCliente);
			this.m_gbInformacoesCliente.Controls.Add(this.label1);
			this.m_gbInformacoesCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoesCliente.Location = new System.Drawing.Point(7, 30);
			this.m_gbInformacoesCliente.Name = "m_gbInformacoesCliente";
			this.m_gbInformacoesCliente.Size = new System.Drawing.Size(477, 90);
			this.m_gbInformacoesCliente.TabIndex = 8;
			this.m_gbInformacoesCliente.TabStop = false;
			this.m_gbInformacoesCliente.Text = "Identificação";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(240, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 16);
			this.label2.TabIndex = 14;
			this.label2.Text = "Versão Cliente:";
			// 
			// m_txtVersaoCliente
			// 
			this.m_txtVersaoCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtVersaoCliente.Location = new System.Drawing.Point(336, 63);
			this.m_txtVersaoCliente.Name = "m_txtVersaoCliente";
			this.m_txtVersaoCliente.ReadOnly = true;
			this.m_txtVersaoCliente.Size = new System.Drawing.Size(134, 20);
			this.m_txtVersaoCliente.TabIndex = 15;
			this.m_txtVersaoCliente.Text = "";
			// 
			// m_lbVersaoServidor
			// 
			this.m_lbVersaoServidor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbVersaoServidor.Location = new System.Drawing.Point(4, 62);
			this.m_lbVersaoServidor.Name = "m_lbVersaoServidor";
			this.m_lbVersaoServidor.Size = new System.Drawing.Size(96, 16);
			this.m_lbVersaoServidor.TabIndex = 12;
			this.m_lbVersaoServidor.Text = "Versão Servidor:";
			// 
			// m_txtVersaoServidor
			// 
			this.m_txtVersaoServidor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtVersaoServidor.Location = new System.Drawing.Point(103, 61);
			this.m_txtVersaoServidor.Name = "m_txtVersaoServidor";
			this.m_txtVersaoServidor.ReadOnly = true;
			this.m_txtVersaoServidor.Size = new System.Drawing.Size(134, 20);
			this.m_txtVersaoServidor.TabIndex = 13;
			this.m_txtVersaoServidor.Text = "";
			// 
			// m_txtNomeUsuario
			// 
			this.m_txtNomeUsuario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtNomeUsuario.Location = new System.Drawing.Point(335, 37);
			this.m_txtNomeUsuario.Name = "m_txtNomeUsuario";
			this.m_txtNomeUsuario.ReadOnly = true;
			this.m_txtNomeUsuario.Size = new System.Drawing.Size(134, 20);
			this.m_txtNomeUsuario.TabIndex = 11;
			this.m_txtNomeUsuario.Text = "";
			// 
			// m_lbNomeMaquina
			// 
			this.m_lbNomeMaquina.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbNomeMaquina.Location = new System.Drawing.Point(7, 40);
			this.m_lbNomeMaquina.Name = "m_lbNomeMaquina";
			this.m_lbNomeMaquina.Size = new System.Drawing.Size(96, 16);
			this.m_lbNomeMaquina.TabIndex = 8;
			this.m_lbNomeMaquina.Text = "Máquina:";
			// 
			// m_txtNomeMaquina
			// 
			this.m_txtNomeMaquina.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtNomeMaquina.Location = new System.Drawing.Point(103, 38);
			this.m_txtNomeMaquina.Name = "m_txtNomeMaquina";
			this.m_txtNomeMaquina.ReadOnly = true;
			this.m_txtNomeMaquina.Size = new System.Drawing.Size(134, 20);
			this.m_txtNomeMaquina.TabIndex = 9;
			this.m_txtNomeMaquina.Text = "";
			// 
			// m_lbCodigoCliente
			// 
			this.m_lbCodigoCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbCodigoCliente.Location = new System.Drawing.Point(7, 19);
			this.m_lbCodigoCliente.Name = "m_lbCodigoCliente";
			this.m_lbCodigoCliente.Size = new System.Drawing.Size(96, 16);
			this.m_lbCodigoCliente.TabIndex = 3;
			this.m_lbCodigoCliente.Text = "Código Cliente:";
			// 
			// m_txtCodigoCliente
			// 
			this.m_txtCodigoCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtCodigoCliente.Location = new System.Drawing.Point(103, 16);
			this.m_txtCodigoCliente.Name = "m_txtCodigoCliente";
			this.m_txtCodigoCliente.ReadOnly = true;
			this.m_txtCodigoCliente.Size = new System.Drawing.Size(134, 20);
			this.m_txtCodigoCliente.TabIndex = 7;
			this.m_txtCodigoCliente.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(243, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "Usuário:";
			// 
			// lbInfo
			// 
			this.lbInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbInfo.Location = new System.Drawing.Point(110, 13);
			this.lbInfo.Name = "lbInfo";
			this.lbInfo.Size = new System.Drawing.Size(276, 24);
			this.lbInfo.TabIndex = 5;
			this.lbInfo.Text = "Informações da discrepância encontrada";
			// 
			// btOk
			// 
			this.btOk.Location = new System.Drawing.Point(198, 363);
			this.btOk.Name = "btOk";
			this.btOk.Size = new System.Drawing.Size(88, 32);
			this.btOk.TabIndex = 2;
			this.btOk.Text = "&Fechar";
			this.btOk.Click += new System.EventHandler(this.btOk_Click);
			// 
			// frmFInformacoesProblema
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(502, 406);
			this.ControlBox = false;
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmFInformacoesProblema";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.frmFInformacoesProblema_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbInformacoesDiscrepancia.ResumeLayout(false);
			this.m_gbInformacoesCliente.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
			#region Formulario
				private void frmFInformacoesProblema_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaInformacoes();
				}
			#endregion
			#region Botoes
				private void btOk_Click(object sender, System.EventArgs e)
				{
					this.Close();
				}
			#endregion
		#endregion
	}
}

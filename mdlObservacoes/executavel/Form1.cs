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

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbParametros;
			private System.Windows.Forms.TextBox m_txtIdCodigo;
			private System.Windows.Forms.TextBox m_txtIdExportador;
			private System.Windows.Forms.Label m_lbIdCodigo;
			private System.Windows.Forms.Label m_lbIdExportador;
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
			private System.Windows.Forms.TextBox m_txtIdImportador;
			private System.Windows.Forms.Label label2;
			private System.Windows.Forms.ImageList m_ilBandeiras;
		private System.Windows.Forms.GroupBox m_gbCO;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button m_btProforma;
		private System.Windows.Forms.Button m_btComercial;
		private System.Windows.Forms.Button m_btCotacao;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.RadioButton m_rbSqlServer;
		private System.Windows.Forms.TextBox m_txtPortSqlServer;
		private System.Windows.Forms.Label m_lbPortSqlServer;
		private System.Windows.Forms.Button m_btRomaneio;
		private System.Windows.Forms.Button m_btCOVolumes;
		private System.Windows.Forms.TextBox m_txtTipoRelatorio;
		private System.Windows.Forms.Label m_lbTipoRelatorio;
		private System.Windows.Forms.Button m_btCODestino;
		private System.Windows.Forms.Button m_btPE;
		private System.Windows.Forms.Button m_btCartaCredito;
		private System.Windows.Forms.GroupBox m_gbGuiaEntrada;
		private System.Windows.Forms.Button m_btGuiaEntradaLocalizacao;
			private System.ComponentModel.IContainer components = null;
		#endregion
		#region Constructor e Destructor
			public Form1()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbParametros = new System.Windows.Forms.GroupBox();
			this.m_txtTipoRelatorio = new System.Windows.Forms.TextBox();
			this.m_lbTipoRelatorio = new System.Windows.Forms.Label();
			this.m_txtIdImportador = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtIdCodigo = new System.Windows.Forms.TextBox();
			this.m_txtIdExportador = new System.Windows.Forms.TextBox();
			this.m_lbIdCodigo = new System.Windows.Forms.Label();
			this.m_lbIdExportador = new System.Windows.Forms.Label();
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_lbRetorno = new System.Windows.Forms.Label();
			this.m_gbMoeda = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button12 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.m_gbCO = new System.Windows.Forms.GroupBox();
			this.m_btCODestino = new System.Windows.Forms.Button();
			this.m_btCOVolumes = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_btCartaCredito = new System.Windows.Forms.Button();
			this.m_btPE = new System.Windows.Forms.Button();
			this.m_btRomaneio = new System.Windows.Forms.Button();
			this.m_btProforma = new System.Windows.Forms.Button();
			this.m_btComercial = new System.Windows.Forms.Button();
			this.m_btCotacao = new System.Windows.Forms.Button();
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
			this.m_gbGuiaEntrada = new System.Windows.Forms.GroupBox();
			this.m_btGuiaEntradaLocalizacao = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbParametros.SuspendLayout();
			this.m_gbRetorno.SuspendLayout();
			this.m_gbMoeda.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.m_gbCO.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.m_gbBD.SuspendLayout();
			this.m_gbConfiguracao.SuspendLayout();
			this.m_gbTipoAcesso.SuspendLayout();
			this.m_gbLogin.SuspendLayout();
			this.m_gbGuiaEntrada.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbParametros);
			this.m_gbGeral.Controls.Add(this.m_gbRetorno);
			this.m_gbGeral.Controls.Add(this.m_gbMoeda);
			this.m_gbGeral.Controls.Add(this.m_gbBD);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(615, 682);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbParametros
			// 
			this.m_gbParametros.Controls.Add(this.m_txtTipoRelatorio);
			this.m_gbParametros.Controls.Add(this.m_lbTipoRelatorio);
			this.m_gbParametros.Controls.Add(this.m_txtIdImportador);
			this.m_gbParametros.Controls.Add(this.label2);
			this.m_gbParametros.Controls.Add(this.m_txtIdCodigo);
			this.m_gbParametros.Controls.Add(this.m_txtIdExportador);
			this.m_gbParametros.Controls.Add(this.m_lbIdCodigo);
			this.m_gbParametros.Controls.Add(this.m_lbIdExportador);
			this.m_gbParametros.Location = new System.Drawing.Point(8, 248);
			this.m_gbParametros.Name = "m_gbParametros";
			this.m_gbParametros.Size = new System.Drawing.Size(600, 80);
			this.m_gbParametros.TabIndex = 3;
			this.m_gbParametros.TabStop = false;
			this.m_gbParametros.Text = "Parametros";
			// 
			// m_txtTipoRelatorio
			// 
			this.m_txtTipoRelatorio.Location = new System.Drawing.Point(457, 48);
			this.m_txtTipoRelatorio.Name = "m_txtTipoRelatorio";
			this.m_txtTipoRelatorio.Size = new System.Drawing.Size(91, 20);
			this.m_txtTipoRelatorio.TabIndex = 11;
			this.m_txtTipoRelatorio.Text = "4";
			this.m_txtTipoRelatorio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbTipoRelatorio
			// 
			this.m_lbTipoRelatorio.Location = new System.Drawing.Point(372, 49);
			this.m_lbTipoRelatorio.Name = "m_lbTipoRelatorio";
			this.m_lbTipoRelatorio.Size = new System.Drawing.Size(87, 16);
			this.m_lbTipoRelatorio.TabIndex = 10;
			this.m_lbTipoRelatorio.Text = "nIdTipoRelatorio";
			// 
			// m_txtIdImportador
			// 
			this.m_txtIdImportador.Location = new System.Drawing.Point(456, 22);
			this.m_txtIdImportador.Name = "m_txtIdImportador";
			this.m_txtIdImportador.Size = new System.Drawing.Size(91, 20);
			this.m_txtIdImportador.TabIndex = 9;
			this.m_txtIdImportador.Text = "0";
			this.m_txtIdImportador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(376, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "idImportador";
			// 
			// m_txtIdCodigo
			// 
			this.m_txtIdCodigo.Location = new System.Drawing.Point(108, 47);
			this.m_txtIdCodigo.Name = "m_txtIdCodigo";
			this.m_txtIdCodigo.Size = new System.Drawing.Size(91, 20);
			this.m_txtIdCodigo.TabIndex = 7;
			this.m_txtIdCodigo.Text = "001";
			this.m_txtIdCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_txtIdExportador
			// 
			this.m_txtIdExportador.Location = new System.Drawing.Point(108, 23);
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
			this.m_gbRetorno.Controls.Add(this.m_txtRetorno);
			this.m_gbRetorno.Controls.Add(this.m_lbRetorno);
			this.m_gbRetorno.Location = new System.Drawing.Point(8, 630);
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
			this.m_gbMoeda.Controls.Add(this.m_gbGuiaEntrada);
			this.m_gbMoeda.Controls.Add(this.groupBox2);
			this.m_gbMoeda.Controls.Add(this.m_gbCO);
			this.m_gbMoeda.Controls.Add(this.groupBox1);
			this.m_gbMoeda.Location = new System.Drawing.Point(8, 328);
			this.m_gbMoeda.Name = "m_gbMoeda";
			this.m_gbMoeda.Size = new System.Drawing.Size(600, 298);
			this.m_gbMoeda.TabIndex = 1;
			this.m_gbMoeda.TabStop = false;
			this.m_gbMoeda.Text = "Observa��es";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button12);
			this.groupBox2.Controls.Add(this.button13);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.button10);
			this.groupBox2.Controls.Add(this.button11);
			this.groupBox2.Location = new System.Drawing.Point(8, 180);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(584, 57);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Instru��es Embarque";
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(468, 16);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(96, 32);
			this.button12.TabIndex = 9;
			this.button12.Text = "Notificar 2";
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(356, 16);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(96, 32);
			this.button13.TabIndex = 8;
			this.button13.Text = "Notificar 1";
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(244, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 7;
			this.button1.Text = "Descri��o Geral Mercadorias";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(132, 16);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(96, 32);
			this.button10.TabIndex = 6;
			this.button10.Text = "C�digo Tarif�rio";
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(20, 16);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(96, 32);
			this.button11.TabIndex = 5;
			this.button11.Text = "Observa��es";
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// m_gbCO
			// 
			this.m_gbCO.Controls.Add(this.m_btCODestino);
			this.m_gbCO.Controls.Add(this.m_btCOVolumes);
			this.m_gbCO.Controls.Add(this.button6);
			this.m_gbCO.Controls.Add(this.button7);
			this.m_gbCO.Controls.Add(this.button8);
			this.m_gbCO.Controls.Add(this.button9);
			this.m_gbCO.Controls.Add(this.button2);
			this.m_gbCO.Controls.Add(this.button3);
			this.m_gbCO.Controls.Add(this.button4);
			this.m_gbCO.Controls.Add(this.button5);
			this.m_gbCO.Location = new System.Drawing.Point(8, 77);
			this.m_gbCO.Name = "m_gbCO";
			this.m_gbCO.Size = new System.Drawing.Size(584, 104);
			this.m_gbCO.TabIndex = 5;
			this.m_gbCO.TabStop = false;
			this.m_gbCO.Text = "Certificados de Origem";
			// 
			// m_btCODestino
			// 
			this.m_btCODestino.Location = new System.Drawing.Point(422, 64);
			this.m_btCODestino.Name = "m_btCODestino";
			this.m_btCODestino.Size = new System.Drawing.Size(96, 32);
			this.m_btCODestino.TabIndex = 14;
			this.m_btCODestino.Text = "CO Destino";
			this.m_btCODestino.Click += new System.EventHandler(this.m_btCODestino_Click);
			// 
			// m_btCOVolumes
			// 
			this.m_btCOVolumes.Location = new System.Drawing.Point(422, 16);
			this.m_btCOVolumes.Name = "m_btCOVolumes";
			this.m_btCOVolumes.Size = new System.Drawing.Size(96, 32);
			this.m_btCOVolumes.TabIndex = 13;
			this.m_btCOVolumes.Text = "CO Volumes";
			this.m_btCOVolumes.Click += new System.EventHandler(this.m_btCOVolumes_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(320, 64);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(96, 32);
			this.button6.TabIndex = 12;
			this.button6.Text = "Form A";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(216, 64);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(96, 32);
			this.button7.TabIndex = 11;
			this.button7.Text = "Comum";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(112, 64);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(96, 32);
			this.button8.TabIndex = 10;
			this.button8.Text = "Anexo III";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(8, 64);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(96, 32);
			this.button9.TabIndex = 9;
			this.button9.Text = "AladiAce39";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(320, 18);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 32);
			this.button2.TabIndex = 8;
			this.button2.Text = "AladiAptr04";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(216, 18);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 32);
			this.button3.TabIndex = 7;
			this.button3.Text = "Mercosul Chile";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(112, 18);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(96, 32);
			this.button4.TabIndex = 6;
			this.button4.Text = "Mercosul Bol�via";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(8, 18);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(96, 32);
			this.button5.TabIndex = 5;
			this.button5.Text = "Mercosul";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_btCartaCredito);
			this.groupBox1.Controls.Add(this.m_btPE);
			this.groupBox1.Controls.Add(this.m_btRomaneio);
			this.groupBox1.Controls.Add(this.m_btProforma);
			this.groupBox1.Controls.Add(this.m_btComercial);
			this.groupBox1.Controls.Add(this.m_btCotacao);
			this.groupBox1.Location = new System.Drawing.Point(8, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(584, 57);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Faturas";
			// 
			// m_btCartaCredito
			// 
			this.m_btCartaCredito.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCartaCredito.Location = new System.Drawing.Point(393, 16);
			this.m_btCartaCredito.Name = "m_btCartaCredito";
			this.m_btCartaCredito.Size = new System.Drawing.Size(87, 32);
			this.m_btCartaCredito.TabIndex = 10;
			this.m_btCartaCredito.Text = "Carta Credito";
			this.m_btCartaCredito.Click += new System.EventHandler(this.m_btCartaCredito_Click);
			// 
			// m_btPE
			// 
			this.m_btPE.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btPE.Location = new System.Drawing.Point(296, 16);
			this.m_btPE.Name = "m_btPE";
			this.m_btPE.Size = new System.Drawing.Size(96, 32);
			this.m_btPE.TabIndex = 9;
			this.m_btPE.Text = "PE";
			this.m_btPE.Click += new System.EventHandler(this.m_btPE_Click);
			// 
			// m_btRomaneio
			// 
			this.m_btRomaneio.Location = new System.Drawing.Point(484, 15);
			this.m_btRomaneio.Name = "m_btRomaneio";
			this.m_btRomaneio.Size = new System.Drawing.Size(96, 32);
			this.m_btRomaneio.TabIndex = 8;
			this.m_btRomaneio.Text = "Romaneio";
			this.m_btRomaneio.Click += new System.EventHandler(this.m_btRomaneio_Click);
			// 
			// m_btProforma
			// 
			this.m_btProforma.Location = new System.Drawing.Point(200, 16);
			this.m_btProforma.Name = "m_btProforma";
			this.m_btProforma.Size = new System.Drawing.Size(96, 32);
			this.m_btProforma.TabIndex = 7;
			this.m_btProforma.Text = "Proforma";
			this.m_btProforma.Click += new System.EventHandler(this.m_btProforma_Click);
			// 
			// m_btComercial
			// 
			this.m_btComercial.Location = new System.Drawing.Point(104, 16);
			this.m_btComercial.Name = "m_btComercial";
			this.m_btComercial.Size = new System.Drawing.Size(96, 32);
			this.m_btComercial.TabIndex = 6;
			this.m_btComercial.Text = "Comercial";
			this.m_btComercial.Click += new System.EventHandler(this.m_btComercial_Click);
			// 
			// m_btCotacao
			// 
			this.m_btCotacao.Location = new System.Drawing.Point(6, 16);
			this.m_btCotacao.Name = "m_btCotacao";
			this.m_btCotacao.Size = new System.Drawing.Size(96, 32);
			this.m_btCotacao.TabIndex = 5;
			this.m_btCotacao.Text = "Cotacao";
			this.m_btCotacao.Click += new System.EventHandler(this.m_btCotacao_Click);
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
			this.m_txtPortSqlServer.Location = new System.Drawing.Point(129, 45);
			this.m_txtPortSqlServer.Name = "m_txtPortSqlServer";
			this.m_txtPortSqlServer.Size = new System.Drawing.Size(39, 20);
			this.m_txtPortSqlServer.TabIndex = 10;
			this.m_txtPortSqlServer.Text = "1433";
			// 
			// m_lbPortSqlServer
			// 
			this.m_lbPortSqlServer.Location = new System.Drawing.Point(104, 48);
			this.m_lbPortSqlServer.Name = "m_lbPortSqlServer";
			this.m_lbPortSqlServer.Size = new System.Drawing.Size(32, 16);
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
			this.m_ilBandeiras.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBandeiras.ImageStream")));
			this.m_ilBandeiras.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_gbGuiaEntrada
			// 
			this.m_gbGuiaEntrada.Controls.Add(this.m_btGuiaEntradaLocalizacao);
			this.m_gbGuiaEntrada.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbGuiaEntrada.Location = new System.Drawing.Point(8, 239);
			this.m_gbGuiaEntrada.Name = "m_gbGuiaEntrada";
			this.m_gbGuiaEntrada.Size = new System.Drawing.Size(584, 53);
			this.m_gbGuiaEntrada.TabIndex = 8;
			this.m_gbGuiaEntrada.TabStop = false;
			this.m_gbGuiaEntrada.Text = "Guia de Entrada";
			// 
			// m_btGuiaEntradaLocalizacao
			// 
			this.m_btGuiaEntradaLocalizacao.Location = new System.Drawing.Point(5, 17);
			this.m_btGuiaEntradaLocalizacao.Name = "m_btGuiaEntradaLocalizacao";
			this.m_btGuiaEntradaLocalizacao.Size = new System.Drawing.Size(96, 32);
			this.m_btGuiaEntradaLocalizacao.TabIndex = 6;
			this.m_btGuiaEntradaLocalizacao.Text = "Localizacao";
			this.m_btGuiaEntradaLocalizacao.Click += new System.EventHandler(this.m_btGuiaEntradaLocalizacao_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 685);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Observacoes";
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbParametros.ResumeLayout(false);
			this.m_gbRetorno.ResumeLayout(false);
			this.m_gbMoeda.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.m_gbCO.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.m_gbBD.ResumeLayout(false);
			this.m_gbConfiguracao.ResumeLayout(false);
			this.m_gbTipoAcesso.ResumeLayout(false);
			this.m_gbLogin.ResumeLayout(false);
			this.m_gbGuiaEntrada.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region DataBase
		private void CreateDataBase()
		{
			if (m_rbJet40.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessOleDbJet40(ref m_cls_tre_tratadorErro,m_txtPath.Text + m_txtDataBaseName.Text + ".mdb",m_txtUser.Text,m_txtPassword.Text);
//			if (m_rbMySql.Checked)
//				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtUser.Text,m_txtPassword.Text,m_txtDataBaseName.Text);
			if (m_rbSqlServer.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessSqlServer(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtPortSqlServer.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);
			m_cls_dba_ConnectionBD.ShowDialogsErrors = true;
			m_cls_dba_ConnectionBD.SystemMode = mdlDataBaseAccess.Mode.Developer;

		}
		#endregion

		#region Eventos
			#region Diversos
        	private void m_btCotacao_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.clsObservacoes modObservacoesFaturas = new mdlObservacoes.Faturas.clsObservacoesFaturaCotacao(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesFaturas.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesFaturas.ShowDialog();
				modObservacoesFaturas.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void m_btComercial_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.clsObservacoes modObservacoesFaturas = new mdlObservacoes.Faturas.clsObservacoesFaturaComercial(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesFaturas.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesFaturas.ShowDialog();
				modObservacoesFaturas.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void m_btProforma_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.clsObservacoes modObservacoesFaturas = new mdlObservacoes.Faturas.clsObservacoesFaturaProforma(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesFaturas.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesFaturas.ShowDialog();
				modObservacoesFaturas.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void m_btRomaneio_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.clsObservacoes modObservacoesFaturas = new mdlObservacoes.Romaneio.clsObservacoesRomaneio(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesFaturas.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesFaturas.ShowDialog();
				modObservacoesFaturas.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void button5_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.CO.clsObservacoesCO modObservacoesCO = new mdlObservacoes.CO.clsObservacoesCOMercosul(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesCO.ShowDialog();
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void button4_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.CO.clsObservacoesCO modObservacoesCO = new mdlObservacoes.CO.clsObservacoesCOMercosulBolivia(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesCO.ShowDialog();
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void button3_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.CO.clsObservacoesCO modObservacoesCO = new mdlObservacoes.CO.clsObservacoesCOMercosulChile(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesCO.ShowDialog();
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void button2_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.CO.clsObservacoesCO modObservacoesCO = new mdlObservacoes.CO.clsObservacoesCOAladiAptr04(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesCO.ShowDialog();
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void button9_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.CO.clsObservacoesCO modObservacoesCO = new mdlObservacoes.CO.clsObservacoesCOAladiAce39(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesCO.ShowDialog();
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void button8_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.CO.clsObservacoesCO modObservacoesCO = new mdlObservacoes.CO.clsObservacoesCOAnexoIII(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesCO.ShowDialog();
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void button7_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.CO.clsObservacoesCO modObservacoesCO = new mdlObservacoes.CO.clsObservacoesCOComum(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesCO.ShowDialog();
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void button6_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.CO.clsObservacoesCO modObservacoesCO = new mdlObservacoes.CO.clsObservacoesCOFormA(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesCO.ShowDialog();
				modObservacoesCO.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}
			private void button11_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.clsObservacoes modObservacoesInstEmbarque = new mdlObservacoes.InstrucoesEmbarque.clsObservacoesInstrucoesEmbarque(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesInstEmbarque.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesInstEmbarque.ShowDialog();
				modObservacoesInstEmbarque.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void button10_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.clsObservacoes modObservacoesInstEmbarque = new mdlObservacoes.InstrucoesEmbarque.clsInstrucoesEmbarqueCodigoTarifario(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesInstEmbarque.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesInstEmbarque.ShowDialog();
				modObservacoesInstEmbarque.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void button1_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.clsObservacoes modObservacoesInstEmbarque = new mdlObservacoes.InstrucoesEmbarque.clsInstrucoesEmbarqueDescricaoGeralMercadoria(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesInstEmbarque.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesInstEmbarque.ShowDialog();
				modObservacoesInstEmbarque.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void button13_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.clsObservacoes modObservacoesInstEmbarque = new mdlObservacoes.InstrucoesEmbarque.clsInstrucoesEmbarqueNotificar1(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesInstEmbarque.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesInstEmbarque.ShowDialog();
				modObservacoesInstEmbarque.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void button12_Click(object sender, System.EventArgs e)
			{
				string strObservacoes;
				this.m_txtRetorno.Text = "";
				CreateDataBase();
				mdlObservacoes.clsObservacoes modObservacoesInstEmbarque = new mdlObservacoes.InstrucoesEmbarque.clsInstrucoesEmbarqueNotificar2(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				modObservacoesInstEmbarque.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
				modObservacoesInstEmbarque.ShowDialog();
				modObservacoesInstEmbarque.retornaValores(out strObservacoes);
				this.m_txtRetorno.Text = "Observa��o: " + strObservacoes;
			}

			private void m_btCOVolumes_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CO.clsObservacoesCOVolumes(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text,Int32.Parse(m_txtTipoRelatorio.Text));
				obj.ShowDialog();
			}

			private void m_btCODestino_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CO.clsObservacoesCODestino(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text,Int32.Parse(m_txtTipoRelatorio.Text));
				obj.ShowDialog();
			}

			private void m_btPE_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlObservacoes.clsObservacoes obj = new mdlObservacoes.PE.clsObservacoesPE(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				obj.ShowDialog();
			}

			private void m_btCartaCredito_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CartaCredito.clsObservacoesCartaCredito(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				obj.ShowDialog();
			}
		#endregion
		#region Guia Entrada
			private void m_btGuiaEntradaLocalizacao_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlObservacoes.clsObservacoes obj = new mdlObservacoes.GuiaEntrada.clsGuiaEntradaLocalizacao(ref m_cls_tre_tratadorErro, ref m_cls_dba_ConnectionBD, m_txtPath.Text, Int32.Parse(m_txtIdExportador.Text), m_txtIdCodigo.Text);
				obj.ShowDialog();
			}
		#endregion
		#endregion

	}
}
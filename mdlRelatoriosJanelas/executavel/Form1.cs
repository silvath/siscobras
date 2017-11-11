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
		private System.Windows.Forms.TextBox m_txtHost;
		private System.Windows.Forms.Label m_lbHost;
		private System.Windows.Forms.TextBox m_txtPassword;
		private System.Windows.Forms.TextBox m_txtUser;
		private System.Windows.Forms.Label m_lbPassword;
		private System.Windows.Forms.TextBox m_txtIdIdioma;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_txtIdTipo;
		private System.Windows.Forms.Label m_lbIdRelatorio;
		private System.Windows.Forms.Label m_lbIdTipo;
		private System.Windows.Forms.TextBox m_txtIdRelatorio;
		private System.Windows.Forms.Button m_btCaneta;
		private System.Windows.Forms.Button m_btCores;
		private System.Windows.Forms.Button m_btImagens;
		private System.Windows.Forms.Button m_btImportar;
		private System.Windows.Forms.Button m_btMargens;
		private System.Windows.Forms.Button m_btObjetoCirculo;
		private System.Windows.Forms.Button m_btObjetoLinha;
		private System.Windows.Forms.Button m_btObjRetangulo;
		private System.Windows.Forms.Button m_btObjTexto;
		private System.Windows.Forms.Button m_btObjTextoDB;
		internal System.Windows.Forms.PictureBox m_picImagem;
		private System.Windows.Forms.Button m_btObjetoRelatorio;
		private System.Windows.Forms.Button m_btSalvarComo;
		private System.Windows.Forms.Button m_btVisualizarItens;
		private System.Windows.Forms.Button m_btTeclasAtalho;
		private System.Windows.Forms.Button m_btTrocarRelatorio;
		private System.Windows.Forms.CheckBox m_ckRelatoriosPadrao;
		private System.Windows.Forms.RadioButton m_rbSqlServer;
		private System.Windows.Forms.TextBox m_txtPortSqlServer;
		private System.Windows.Forms.Label m_lbPortSqlSever;
		private System.Windows.Forms.TextBox m_txtPortMysql;
		private System.Windows.Forms.Label label3;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbParametros = new System.Windows.Forms.GroupBox();
			this.m_picImagem = new System.Windows.Forms.PictureBox();
			this.m_txtIdRelatorio = new System.Windows.Forms.TextBox();
			this.m_lbIdRelatorio = new System.Windows.Forms.Label();
			this.m_txtIdTipo = new System.Windows.Forms.TextBox();
			this.m_lbIdTipo = new System.Windows.Forms.Label();
			this.m_txtIdIdioma = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtIdCodigo = new System.Windows.Forms.TextBox();
			this.m_txtIdExportador = new System.Windows.Forms.TextBox();
			this.m_lbIdCodigo = new System.Windows.Forms.Label();
			this.m_lbIdExportador = new System.Windows.Forms.Label();
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_lbRetorno = new System.Windows.Forms.Label();
			this.m_gbMoeda = new System.Windows.Forms.GroupBox();
			this.m_ckRelatoriosPadrao = new System.Windows.Forms.CheckBox();
			this.m_btTrocarRelatorio = new System.Windows.Forms.Button();
			this.m_btTeclasAtalho = new System.Windows.Forms.Button();
			this.m_btVisualizarItens = new System.Windows.Forms.Button();
			this.m_btSalvarComo = new System.Windows.Forms.Button();
			this.m_btObjetoRelatorio = new System.Windows.Forms.Button();
			this.m_btObjTextoDB = new System.Windows.Forms.Button();
			this.m_btObjTexto = new System.Windows.Forms.Button();
			this.m_btObjRetangulo = new System.Windows.Forms.Button();
			this.m_btObjetoLinha = new System.Windows.Forms.Button();
			this.m_btObjetoCirculo = new System.Windows.Forms.Button();
			this.m_btMargens = new System.Windows.Forms.Button();
			this.m_btImportar = new System.Windows.Forms.Button();
			this.m_btImagens = new System.Windows.Forms.Button();
			this.m_btCores = new System.Windows.Forms.Button();
			this.m_btCaneta = new System.Windows.Forms.Button();
			this.m_gbBD = new System.Windows.Forms.GroupBox();
			this.m_gbConfiguracao = new System.Windows.Forms.GroupBox();
			this.m_txtPath = new System.Windows.Forms.TextBox();
			this.m_lbPath = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtDataBaseName = new System.Windows.Forms.TextBox();
			this.m_gbTipoAcesso = new System.Windows.Forms.GroupBox();
			this.m_txtPortMysql = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtPortSqlServer = new System.Windows.Forms.TextBox();
			this.m_lbPortSqlSever = new System.Windows.Forms.Label();
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
			this.m_gbGeral.Location = new System.Drawing.Point(5, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(615, 529);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbParametros
			// 
			this.m_gbParametros.Controls.Add(this.m_picImagem);
			this.m_gbParametros.Controls.Add(this.m_txtIdRelatorio);
			this.m_gbParametros.Controls.Add(this.m_lbIdRelatorio);
			this.m_gbParametros.Controls.Add(this.m_txtIdTipo);
			this.m_gbParametros.Controls.Add(this.m_lbIdTipo);
			this.m_gbParametros.Controls.Add(this.m_txtIdIdioma);
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
			// m_picImagem
			// 
			this.m_picImagem.Image = ((System.Drawing.Image)(resources.GetObject("m_picImagem.Image")));
			this.m_picImagem.Location = new System.Drawing.Point(206, 46);
			this.m_picImagem.Name = "m_picImagem";
			this.m_picImagem.Size = new System.Drawing.Size(16, 16);
			this.m_picImagem.TabIndex = 20;
			this.m_picImagem.TabStop = false;
			// 
			// m_txtIdRelatorio
			// 
			this.m_txtIdRelatorio.Location = new System.Drawing.Point(454, 46);
			this.m_txtIdRelatorio.Name = "m_txtIdRelatorio";
			this.m_txtIdRelatorio.Size = new System.Drawing.Size(91, 20);
			this.m_txtIdRelatorio.TabIndex = 13;
			this.m_txtIdRelatorio.Text = "1";
			this.m_txtIdRelatorio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtIdRelatorio.TextChanged += new System.EventHandler(this.m_txtIdRelatorio_TextChanged);
			// 
			// m_lbIdRelatorio
			// 
			this.m_lbIdRelatorio.Location = new System.Drawing.Point(375, 49);
			this.m_lbIdRelatorio.Name = "m_lbIdRelatorio";
			this.m_lbIdRelatorio.Size = new System.Drawing.Size(75, 16);
			this.m_lbIdRelatorio.TabIndex = 12;
			this.m_lbIdRelatorio.Text = "idRelatorio";
			// 
			// m_txtIdTipo
			// 
			this.m_txtIdTipo.Location = new System.Drawing.Point(454, 21);
			this.m_txtIdTipo.Name = "m_txtIdTipo";
			this.m_txtIdTipo.Size = new System.Drawing.Size(91, 20);
			this.m_txtIdTipo.TabIndex = 11;
			this.m_txtIdTipo.Text = "3";
			this.m_txtIdTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbIdTipo
			// 
			this.m_lbIdTipo.Location = new System.Drawing.Point(374, 21);
			this.m_lbIdTipo.Name = "m_lbIdTipo";
			this.m_lbIdTipo.Size = new System.Drawing.Size(75, 16);
			this.m_lbIdTipo.TabIndex = 10;
			this.m_lbIdTipo.Text = "idTipo";
			// 
			// m_txtIdIdioma
			// 
			this.m_txtIdIdioma.Location = new System.Drawing.Point(257, 20);
			this.m_txtIdIdioma.Name = "m_txtIdIdioma";
			this.m_txtIdIdioma.Size = new System.Drawing.Size(91, 20);
			this.m_txtIdIdioma.TabIndex = 9;
			this.m_txtIdIdioma.Text = "3";
			this.m_txtIdIdioma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(200, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "idIdioma";
			// 
			// m_txtIdCodigo
			// 
			this.m_txtIdCodigo.Location = new System.Drawing.Point(94, 46);
			this.m_txtIdCodigo.Name = "m_txtIdCodigo";
			this.m_txtIdCodigo.Size = new System.Drawing.Size(91, 20);
			this.m_txtIdCodigo.TabIndex = 7;
			this.m_txtIdCodigo.Text = "001";
			this.m_txtIdCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_txtIdExportador
			// 
			this.m_txtIdExportador.Location = new System.Drawing.Point(94, 22);
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
			this.m_gbRetorno.Location = new System.Drawing.Point(8, 472);
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
			this.m_gbMoeda.Controls.Add(this.m_ckRelatoriosPadrao);
			this.m_gbMoeda.Controls.Add(this.m_btTrocarRelatorio);
			this.m_gbMoeda.Controls.Add(this.m_btTeclasAtalho);
			this.m_gbMoeda.Controls.Add(this.m_btVisualizarItens);
			this.m_gbMoeda.Controls.Add(this.m_btSalvarComo);
			this.m_gbMoeda.Controls.Add(this.m_btObjetoRelatorio);
			this.m_gbMoeda.Controls.Add(this.m_btObjTextoDB);
			this.m_gbMoeda.Controls.Add(this.m_btObjTexto);
			this.m_gbMoeda.Controls.Add(this.m_btObjRetangulo);
			this.m_gbMoeda.Controls.Add(this.m_btObjetoLinha);
			this.m_gbMoeda.Controls.Add(this.m_btObjetoCirculo);
			this.m_gbMoeda.Controls.Add(this.m_btMargens);
			this.m_gbMoeda.Controls.Add(this.m_btImportar);
			this.m_gbMoeda.Controls.Add(this.m_btImagens);
			this.m_gbMoeda.Controls.Add(this.m_btCores);
			this.m_gbMoeda.Controls.Add(this.m_btCaneta);
			this.m_gbMoeda.Location = new System.Drawing.Point(8, 328);
			this.m_gbMoeda.Name = "m_gbMoeda";
			this.m_gbMoeda.Size = new System.Drawing.Size(600, 144);
			this.m_gbMoeda.TabIndex = 1;
			this.m_gbMoeda.TabStop = false;
			this.m_gbMoeda.Text = "Negócio";
			// 
			// m_ckRelatoriosPadrao
			// 
			this.m_ckRelatoriosPadrao.Location = new System.Drawing.Point(514, 16);
			this.m_ckRelatoriosPadrao.Name = "m_ckRelatoriosPadrao";
			this.m_ckRelatoriosPadrao.Size = new System.Drawing.Size(80, 32);
			this.m_ckRelatoriosPadrao.TabIndex = 17;
			this.m_ckRelatoriosPadrao.Text = "Relatorios Padrao";
			// 
			// m_btTrocarRelatorio
			// 
			this.m_btTrocarRelatorio.Location = new System.Drawing.Point(309, 90);
			this.m_btTrocarRelatorio.Name = "m_btTrocarRelatorio";
			this.m_btTrocarRelatorio.Size = new System.Drawing.Size(96, 32);
			this.m_btTrocarRelatorio.TabIndex = 16;
			this.m_btTrocarRelatorio.Text = "Trocar Relatorio";
			this.m_btTrocarRelatorio.Click += new System.EventHandler(this.m_btTrocarRelatorio_Click);
			// 
			// m_btTeclasAtalho
			// 
			this.m_btTeclasAtalho.Location = new System.Drawing.Point(208, 91);
			this.m_btTeclasAtalho.Name = "m_btTeclasAtalho";
			this.m_btTeclasAtalho.Size = new System.Drawing.Size(96, 32);
			this.m_btTeclasAtalho.TabIndex = 15;
			this.m_btTeclasAtalho.Text = "Teclas Atalho";
			this.m_btTeclasAtalho.Click += new System.EventHandler(this.m_btTeclasAtalho_Click);
			// 
			// m_btVisualizarItens
			// 
			this.m_btVisualizarItens.Location = new System.Drawing.Point(410, 90);
			this.m_btVisualizarItens.Name = "m_btVisualizarItens";
			this.m_btVisualizarItens.Size = new System.Drawing.Size(96, 32);
			this.m_btVisualizarItens.TabIndex = 14;
			this.m_btVisualizarItens.Text = "Visualizar Itens";
			this.m_btVisualizarItens.Click += new System.EventHandler(this.m_btVisualizarItens_Click);
			// 
			// m_btSalvarComo
			// 
			this.m_btSalvarComo.Location = new System.Drawing.Point(108, 91);
			this.m_btSalvarComo.Name = "m_btSalvarComo";
			this.m_btSalvarComo.Size = new System.Drawing.Size(96, 32);
			this.m_btSalvarComo.TabIndex = 13;
			this.m_btSalvarComo.Text = "Salvar Como";
			this.m_btSalvarComo.Click += new System.EventHandler(this.m_btSalvarComo_Click);
			// 
			// m_btObjetoRelatorio
			// 
			this.m_btObjetoRelatorio.Location = new System.Drawing.Point(8, 91);
			this.m_btObjetoRelatorio.Name = "m_btObjetoRelatorio";
			this.m_btObjetoRelatorio.Size = new System.Drawing.Size(96, 32);
			this.m_btObjetoRelatorio.TabIndex = 12;
			this.m_btObjetoRelatorio.Text = "Obj Relatorio";
			this.m_btObjetoRelatorio.Click += new System.EventHandler(this.m_btObjetoRelatorio_Click);
			// 
			// m_btObjTextoDB
			// 
			this.m_btObjTextoDB.Location = new System.Drawing.Point(410, 55);
			this.m_btObjTextoDB.Name = "m_btObjTextoDB";
			this.m_btObjTextoDB.Size = new System.Drawing.Size(96, 32);
			this.m_btObjTextoDB.TabIndex = 11;
			this.m_btObjTextoDB.Text = "Obj Texto DB";
			this.m_btObjTextoDB.Click += new System.EventHandler(this.m_btObjTextoDB_Click);
			// 
			// m_btObjTexto
			// 
			this.m_btObjTexto.Location = new System.Drawing.Point(309, 55);
			this.m_btObjTexto.Name = "m_btObjTexto";
			this.m_btObjTexto.Size = new System.Drawing.Size(96, 32);
			this.m_btObjTexto.TabIndex = 10;
			this.m_btObjTexto.Text = "Obj Texto";
			this.m_btObjTexto.Click += new System.EventHandler(this.m_btObjTexto_Click);
			// 
			// m_btObjRetangulo
			// 
			this.m_btObjRetangulo.Location = new System.Drawing.Point(208, 56);
			this.m_btObjRetangulo.Name = "m_btObjRetangulo";
			this.m_btObjRetangulo.Size = new System.Drawing.Size(96, 32);
			this.m_btObjRetangulo.TabIndex = 9;
			this.m_btObjRetangulo.Text = "Obj Retangulo";
			this.m_btObjRetangulo.Click += new System.EventHandler(this.m_btObjRetangulo_Click);
			// 
			// m_btObjetoLinha
			// 
			this.m_btObjetoLinha.Location = new System.Drawing.Point(109, 56);
			this.m_btObjetoLinha.Name = "m_btObjetoLinha";
			this.m_btObjetoLinha.Size = new System.Drawing.Size(96, 32);
			this.m_btObjetoLinha.TabIndex = 8;
			this.m_btObjetoLinha.Text = "Obj Linha";
			this.m_btObjetoLinha.Click += new System.EventHandler(this.m_btObjetoLinha_Click);
			// 
			// m_btObjetoCirculo
			// 
			this.m_btObjetoCirculo.Location = new System.Drawing.Point(8, 56);
			this.m_btObjetoCirculo.Name = "m_btObjetoCirculo";
			this.m_btObjetoCirculo.Size = new System.Drawing.Size(96, 32);
			this.m_btObjetoCirculo.TabIndex = 7;
			this.m_btObjetoCirculo.Text = "Obj Circulo";
			this.m_btObjetoCirculo.Click += new System.EventHandler(this.m_btObjetoCirculo_Click);
			// 
			// m_btMargens
			// 
			this.m_btMargens.Location = new System.Drawing.Point(411, 17);
			this.m_btMargens.Name = "m_btMargens";
			this.m_btMargens.Size = new System.Drawing.Size(96, 32);
			this.m_btMargens.TabIndex = 6;
			this.m_btMargens.Text = "Margens";
			this.m_btMargens.Click += new System.EventHandler(this.m_btMargens_Click);
			// 
			// m_btImportar
			// 
			this.m_btImportar.Location = new System.Drawing.Point(310, 18);
			this.m_btImportar.Name = "m_btImportar";
			this.m_btImportar.Size = new System.Drawing.Size(96, 32);
			this.m_btImportar.TabIndex = 5;
			this.m_btImportar.Text = "Importar";
			this.m_btImportar.Click += new System.EventHandler(this.m_btImportar_Click);
			// 
			// m_btImagens
			// 
			this.m_btImagens.Location = new System.Drawing.Point(209, 19);
			this.m_btImagens.Name = "m_btImagens";
			this.m_btImagens.Size = new System.Drawing.Size(96, 32);
			this.m_btImagens.TabIndex = 4;
			this.m_btImagens.Text = "Imagens";
			this.m_btImagens.Click += new System.EventHandler(this.m_btImagens_Click);
			// 
			// m_btCores
			// 
			this.m_btCores.Location = new System.Drawing.Point(110, 19);
			this.m_btCores.Name = "m_btCores";
			this.m_btCores.Size = new System.Drawing.Size(96, 32);
			this.m_btCores.TabIndex = 3;
			this.m_btCores.Text = "Cores";
			this.m_btCores.Click += new System.EventHandler(this.m_btCores_Click);
			// 
			// m_btCaneta
			// 
			this.m_btCaneta.Location = new System.Drawing.Point(9, 19);
			this.m_btCaneta.Name = "m_btCaneta";
			this.m_btCaneta.Size = new System.Drawing.Size(96, 32);
			this.m_btCaneta.TabIndex = 2;
			this.m_btCaneta.Text = "Caneta";
			this.m_btCaneta.Click += new System.EventHandler(this.m_btCaneta_Click);
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
			this.m_gbTipoAcesso.Controls.Add(this.m_txtPortMysql);
			this.m_gbTipoAcesso.Controls.Add(this.label3);
			this.m_gbTipoAcesso.Controls.Add(this.m_txtPortSqlServer);
			this.m_gbTipoAcesso.Controls.Add(this.m_lbPortSqlSever);
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
			// m_txtPortMysql
			// 
			this.m_txtPortMysql.Location = new System.Drawing.Point(130, 29);
			this.m_txtPortMysql.Name = "m_txtPortMysql";
			this.m_txtPortMysql.Size = new System.Drawing.Size(56, 20);
			this.m_txtPortMysql.TabIndex = 12;
			this.m_txtPortMysql.Text = "3306";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(100, 31);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 16);
			this.label3.TabIndex = 11;
			this.label3.Text = "Port:";
			// 
			// m_txtPortSqlServer
			// 
			this.m_txtPortSqlServer.Location = new System.Drawing.Point(130, 49);
			this.m_txtPortSqlServer.Name = "m_txtPortSqlServer";
			this.m_txtPortSqlServer.Size = new System.Drawing.Size(56, 20);
			this.m_txtPortSqlServer.TabIndex = 10;
			this.m_txtPortSqlServer.Text = "1433";
			// 
			// m_lbPortSqlSever
			// 
			this.m_lbPortSqlSever.Location = new System.Drawing.Point(99, 52);
			this.m_lbPortSqlSever.Name = "m_lbPortSqlSever";
			this.m_lbPortSqlSever.Size = new System.Drawing.Size(32, 16);
			this.m_lbPortSqlSever.TabIndex = 9;
			this.m_lbPortSqlSever.Text = "Port:";
			// 
			// m_rbSqlServer
			// 
			this.m_rbSqlServer.Checked = true;
			this.m_rbSqlServer.Location = new System.Drawing.Point(24, 51);
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
			this.m_rbMySql.Size = new System.Drawing.Size(64, 16);
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
			this.m_txtPassword.Text = "Siscobras";
			// 
			// m_txtUser
			// 
			this.m_txtUser.Location = new System.Drawing.Point(62, 34);
			this.m_txtUser.Name = "m_txtUser";
			this.m_txtUser.Size = new System.Drawing.Size(122, 20);
			this.m_txtUser.TabIndex = 7;
			this.m_txtUser.Text = "Siscobras";
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
			this.ClientSize = new System.Drawing.Size(624, 534);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Janelas dos Relatorios";
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
			if (m_rbMySql.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtPortMysql.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);
			if (m_rbSqlServer.Checked)
				m_cls_dba_ConnectionBD = new mdlDataBaseAccess.clsDataBaseAccessSqlServer(ref m_cls_tre_tratadorErro,m_txtHost.Text,m_txtPortSqlServer.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);
			m_cls_dba_ConnectionBD.ShowDialogsErrors = true;
			m_cls_dba_ConnectionBD.SystemMode = mdlDataBaseAccess.Mode.Developer;
		}
		#endregion

		#region Negocio 
		#region Caneta 
		private void m_btCaneta_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlRelatoriosJanelas.frmFRelatoriosCaneta formFCaneta = new mdlRelatoriosJanelas.frmFRelatoriosCaneta(ref m_cls_tre_tratadorErro,m_txtPath.Text,1,System.Drawing.Drawing2D.DashStyle.Custom,System.Drawing.Color.Black);
			formFCaneta.ShowDialog();
		}
		#endregion
		#region Cores
		private void m_btCores_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlRelatoriosJanelas.frmFRelatoriosCores formFCores = new mdlRelatoriosJanelas.frmFRelatoriosCores(ref m_cls_tre_tratadorErro,m_txtPath.Text,System.Drawing.Color.White,System.Drawing.Color.White,System.Drawing.Color.White,System.Drawing.Color.White,System.Drawing.Color.White,System.Drawing.Color.White,System.Drawing.Color.White);
			formFCores.ShowDialog();
		}
		#endregion
		#region Imagens 
		private void m_btImagens_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlRelatoriosJanelas.frmFRelatoriosImagens formFImagens = new mdlRelatoriosJanelas.frmFRelatoriosImagens(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text);
			formFImagens.ShowDialog();
			if (formFImagens.m_bModificado)
			{
				int nIdImagem;
				System.Drawing.Image imgImagem;
				formFImagens.RetornaValores(out nIdImagem,out imgImagem);
                m_txtRetorno.Text = "Indice da Imagem no BD: " + nIdImagem.ToString();
			}
		}
		#endregion
		#region Importar
		private void m_btImportar_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlRelatoriosJanelas.frmFRelatoriosImportar formFImportar = new mdlRelatoriosJanelas.frmFRelatoriosImportar(ref m_cls_tre_tratadorErro,m_txtPath.Text);
			formFImportar.ShowDialog();
		}
		#endregion
		#region Margens 
		private void m_btMargens_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlRelatoriosJanelas.frmFRelatoriosMargens formFMargens = new mdlRelatoriosJanelas.frmFRelatoriosMargens(ref m_cls_tre_tratadorErro,m_txtPath.Text,1,2,3,4);
			formFMargens.ShowDialog();
		}
		#endregion
		#region Obj Circulo
		private void m_btObjetoCirculo_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoCirculo formFObj = new mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoCirculo(ref m_cls_tre_tratadorErro,m_txtPath.Text,true);
			formFObj.ShowDialog();
		}
		#endregion
		#region Obj Linha
		private void m_btObjetoLinha_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoLinha formFObj = new mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoLinha(ref m_cls_tre_tratadorErro,m_txtPath.Text,true);
			formFObj.ShowDialog();
		}
		#endregion
		#region Obj Retangulo
		private void m_btObjRetangulo_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoRetangulo formFObj = new mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoRetangulo(ref m_cls_tre_tratadorErro,m_txtPath.Text,true);
			formFObj.ShowDialog();
		}
		#endregion
		#region Obj Texto
		private void m_btObjTexto_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			System.Drawing.Font fntFonte = new System.Drawing.Font("Arial",8);
			mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoTexto formFObj = new mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoTexto(ref m_cls_tre_tratadorErro,m_txtPath.Text,"Texto",System.Drawing.Color.Black.ToArgb(),fntFonte,true);
			formFObj.ShowDialog();
			if (formFObj.m_bModificado)
			{
				string strTexto;
				System.Drawing.Color clrCor; 
				bool bVisivelImpressao;
				formFObj.RetornaValores(out strTexto,out clrCor,out fntFonte,out bVisivelImpressao);
				m_txtRetorno.Text = strTexto + " # " + clrCor.ToString() + " # " + fntFonte.ToString() + " # " + bVisivelImpressao;
			}
		}
		#endregion
		#region Obj Texto DB
		private void m_btObjTextoDB_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoTextoDB formFObj = new mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoTextoDB(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_txtIdExportador.Text),Int32.Parse(m_txtIdTipo.Text),Int32.Parse(m_txtIdIdioma.Text), m_txtIdCodigo.Text,System.Drawing.Color.Black,System.Drawing.Color.Blue,System.Drawing.Color.White,m_picImagem.Image,true,false,false,1,false,1,System.Drawing.Color.Black.ToArgb(),new System.Drawing.Font("Arial",8),true);
			formFObj.ShowDialog();
			if (formFObj.m_bModificado)
			{
				int nIdCampoBD,nAlinhamento,nFormatoNumero;
				string strTexto;
				System.Drawing.Font fntFonte;
				System.Drawing.Color clrCor;
				bool bVisivelImpressao,bCallBack,bPertenceAreaProdutos,bAlinhamentoInferiorAreaProdutos,bImprimirSomenteUltimaPagina;
				formFObj.RetornaValores(out nIdCampoBD,out strTexto, out fntFonte,out  clrCor,out bVisivelImpressao, out bCallBack, out bPertenceAreaProdutos,out bAlinhamentoInferiorAreaProdutos, out nAlinhamento, out bImprimirSomenteUltimaPagina, out nFormatoNumero);
				m_txtRetorno.Text = fntFonte.ToString();
			}
		}
		#endregion
		#region Obj Relatorio
			private void m_btObjetoRelatorio_Click(object sender, System.EventArgs e)
			{
				CreateDataBase();
				mdlRelatoriosJanelas.frmFRelatoriosPropriedadesRelatorio formFObj = new mdlRelatoriosJanelas.frmFRelatoriosPropriedadesRelatorio(ref m_cls_tre_tratadorErro,m_txtPath.Text,System.Drawing.Color.White,System.Drawing.Color.Blue,0,0,0,0,819,1158,0);
				formFObj.ShowDialog();
				if (formFObj.m_bModificado)
				{
					int nAcima,nDireita,nAbaixo,nEsquerda,nLargura,nAltura,nDisposicao;
					formFObj.RetornaValores(out nAcima,out nDireita,out nAbaixo,out nEsquerda,out nLargura,out nAltura,out nDisposicao);
					string strRetorno = "";
					strRetorno += " MAcima: " + nAcima.ToString();
					strRetorno += " MDireita: " + nDireita.ToString();
					strRetorno += " MAbaixo: " + nAbaixo.ToString();
					strRetorno += " MEsquerda: " + nEsquerda.ToString();
					strRetorno += " MAltura: " + nAltura.ToString();
					strRetorno += " MLargura: " + nLargura.ToString();
					m_txtRetorno.Text = strRetorno;
				}
			}
		#endregion
		#region SalvarComo
		private void m_btSalvarComo_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlRelatoriosJanelas.frmFRelatoriosSalvarComo formFObj = new mdlRelatoriosJanelas.frmFRelatoriosSalvarComo(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD,m_txtPath.Text,Int32.Parse(m_txtIdExportador.Text),Int32.Parse(m_txtIdTipo.Text),m_ckRelatoriosPadrao.Checked);
			formFObj.ShowDialog();
			if (formFObj.m_bModificado)
			{
				bool bReportAlreadExists;
				bool bReportDefault;
				int nIdRelatorio;
				string strNomeRelatorio;
				formFObj.RetornaValores(out bReportAlreadExists,out bReportDefault,out nIdRelatorio,out strNomeRelatorio);
				m_txtRetorno.Text = " AlreadyExists: " + bReportAlreadExists.ToString() + " ReportDefault: " + bReportDefault + " " + nIdRelatorio.ToString() + " " + strNomeRelatorio;
			}

		}
		#endregion
		#region TeclasAtalho
		private void m_btTeclasAtalho_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			System.Collections.ArrayList arlTeclasAtalhoNome = new System.Collections.ArrayList();
			System.Collections.ArrayList arlTeclasAtalhoTeclas = new System.Collections.ArrayList();
			System.Collections.ArrayList arlTeclasAtalhoNomeNoIni = new System.Collections.ArrayList();
			System.Collections.ArrayList arlTeclasAtalhoAcoes = new System.Collections.ArrayList();

			arlTeclasAtalhoNome.Add("Apagar");
			System.Windows.Forms.KeyEventArgs key = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S);
			arlTeclasAtalhoTeclas.Add(key);
			arlTeclasAtalhoNomeNoIni.Add("DELETE");
			arlTeclasAtalhoAcoes.Add(1);

			mdlRelatoriosJanelas.frmFRelatoriosTeclasAtalho formFObj = new mdlRelatoriosJanelas.frmFRelatoriosTeclasAtalho(ref m_cls_tre_tratadorErro,m_txtPath.Text,ref arlTeclasAtalhoNome,ref arlTeclasAtalhoTeclas,ref arlTeclasAtalhoNomeNoIni,ref arlTeclasAtalhoAcoes);
			formFObj.ShowDialog();
			if (formFObj.m_bModificado)
			{
				formFObj.vRetornaValores(out arlTeclasAtalhoTeclas);
			}
			m_txtRetorno.Text = "";
			for(int nCont = 0 ; nCont < arlTeclasAtalhoNome.Count;nCont++)
			{
				m_txtRetorno.Text += arlTeclasAtalhoNome[nCont].ToString();
				m_txtRetorno.Text += " ";
				m_txtRetorno.Text += ((System.Windows.Forms.KeyEventArgs)arlTeclasAtalhoTeclas[nCont]).KeyData.ToString();
			}
		}
		#endregion
		#region Trocar Relatorio
			private void m_btTrocarRelatorio_Click(object sender, System.EventArgs e)
			{
				int idRelatorio = -1;
				CreateDataBase();
				mdlRelatoriosJanelas.frmFRelatoriosTrocaRelatorio formFObj = new mdlRelatoriosJanelas.frmFRelatoriosTrocaRelatorio(ref m_cls_tre_tratadorErro,ref m_cls_dba_ConnectionBD, m_txtPath.Text,Int32.Parse(m_txtIdExportador.Text),Int32.Parse(m_txtIdTipo.Text));
				formFObj.RetornaValores(out idRelatorio);
				m_txtIdRelatorio.Text = idRelatorio.ToString();
				formFObj.ShowDialog();
				formFObj.RetornaValores(out idRelatorio);
				m_txtIdRelatorio.Text = idRelatorio.ToString();

			}
		#endregion
		#region Visualizar Itens
		private void m_btVisualizarItens_Click(object sender, System.EventArgs e)
		{
			CreateDataBase();
			mdlRelatoriosJanelas.frmFRelatoriosVisualizacaoItens formFObj = new mdlRelatoriosJanelas.frmFRelatoriosVisualizacaoItens(ref m_cls_tre_tratadorErro,m_txtPath.Text,true,false,true,false,true,false,true,false,true,false);
			formFObj.ShowDialog();
		}
		#endregion

		private void m_txtIdRelatorio_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		#endregion
	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DrawingCanvasPackage;
using ReportCanvasPackage;
using mdlTratamentoErro;

namespace executavel
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmPrincipal : System.Windows.Forms.Form
	{
		#region Atributos
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
			protected clsTratamentoErro m_tratadorErro = null;
			protected string m_strEnderecoExecutavel = "";
			protected int m_nIdExportador = -1;
			protected int m_nIdTipo = -1;
			protected string m_strIdCodigo = "";
			protected int m_nIdRel = -1;

			private System.ComponentModel.IContainer components;
			private System.Windows.Forms.MenuItem menuItem1;
			private System.Windows.Forms.MenuItem mitLinha;
			private System.Windows.Forms.MenuItem mitRetangulo;
			private System.Windows.Forms.MenuItem mitCirculo;
			private System.Windows.Forms.MenuItem menuItem5;
			private System.Windows.Forms.MenuItem menuItem6;
			private System.Windows.Forms.MenuItem mitCorCaneta;
			private System.Windows.Forms.MenuItem mitEspessura;
			private System.Windows.Forms.MenuItem menuItem10;
			private System.Windows.Forms.MenuItem mitCorFundo;
			private System.Windows.Forms.MenuItem menuItem12;
			private System.Windows.Forms.MenuItem mitEstiloCaneta;
			private System.Windows.Forms.MainMenu menu;
			private System.Windows.Forms.ColorDialog dlgCor;
			private System.Windows.Forms.MenuItem menuItem2;
			private System.Windows.Forms.MenuItem mitNenhum;
			private System.Windows.Forms.MenuItem mitEstiloCanetaPonto;
			private System.Windows.Forms.MenuItem mitEstiloCanetaTraco;
			private System.Windows.Forms.MenuItem mitEstiloCanetaTracoPonto;
			private System.Windows.Forms.MenuItem mitEstiloCanetaTracoPontoPonto;
			private System.Windows.Forms.MenuItem menuItem3;
			private System.Windows.Forms.MenuItem mitSelecao;
			private System.Windows.Forms.MenuItem mitOpaco;
			private System.Windows.Forms.MenuItem menuItem4;
			private System.Windows.Forms.MenuItem mitGrade;
			private System.Windows.Forms.MenuItem menuItem8;
			private System.Windows.Forms.MenuItem mitLivre;
			private System.Windows.Forms.MenuItem mitHorizontal;
			private System.Windows.Forms.MenuItem mitVertical;
			private System.Windows.Forms.MenuItem mitFundo;
			private System.Windows.Forms.MenuItem mitTexto;
			private System.Windows.Forms.MenuItem mitImagem;
			private System.Windows.Forms.OpenFileDialog dlgAbrir;
			private System.Windows.Forms.MenuItem menuItem7;
			private System.Windows.Forms.MenuItem menuItem9;
			private System.Windows.Forms.FontDialog dlgFonte;
			private System.Windows.Forms.MenuItem mitFonte;
			private System.Windows.Forms.MenuItem menuItem11;
			private System.Windows.Forms.MenuItem menuItem13;
			private System.Windows.Forms.MenuItem mitRecuar;
			private System.Windows.Forms.MenuItem mitAvancar;
			private System.Windows.Forms.MenuItem menuItem15;
			private System.Windows.Forms.MenuItem menuItem16;
			private System.Windows.Forms.MenuItem mitAgrupar;
			private System.Windows.Forms.MenuItem mitDesagrupar;
			private System.Windows.Forms.MenuItem menuItem14;
			private System.Windows.Forms.MenuItem mitExcluir;
			private System.Windows.Forms.MenuItem menuItem17;
			private System.Windows.Forms.MenuItem mitDesfazer;
			private System.Windows.Forms.MenuItem mitRefazer;
			private System.Windows.Forms.MenuItem menuItem18;
			private System.Windows.Forms.MenuItem mitMaisZoom;
			private System.Windows.Forms.MenuItem mitMenosZoom;
			private ReportCanvasPackage.ReportCanvas canvas;
			private System.Windows.Forms.MenuItem menuItem19;
			private System.Windows.Forms.MenuItem mitAbrir;
			private System.Windows.Forms.MenuItem menuItem21;
			private System.Windows.Forms.MenuItem mitSair;

			protected MouseEventHandler me = null;
			private System.Windows.Forms.MenuItem mitMargens;
			private System.Windows.Forms.MenuItem menuItem20;
			private System.Windows.Forms.MenuItem mitAreaProd;
			private System.Windows.Forms.MenuItem mitCampoBD;
			private System.Windows.Forms.MenuItem menuItem22;
			private System.Windows.Forms.MenuItem mitDelAreaProd;
			private System.Windows.Forms.MenuItem mitExibirAreaProd;
			private System.Windows.Forms.MenuItem menuItem23;
			private System.Windows.Forms.MenuItem mitCorAreaPRod;
			private System.Windows.Forms.MenuItem mitCorBDText;
			private System.Windows.Forms.MenuItem mitCorMargem;
			private System.Windows.Forms.MenuItem mitLimparSel;
			private System.Windows.Forms.MenuItem menuItem25;
			private System.Windows.Forms.MenuItem menuItem24;
			private System.Windows.Forms.MenuItem mitMostrarLinhas;
			private System.Windows.Forms.MenuItem mitMostraRet;
			private System.Windows.Forms.MenuItem mitMostraCirc;
			private System.Windows.Forms.MenuItem mitMostraTexto;
			private System.Windows.Forms.MenuItem mitMostraImagem;
			private System.Windows.Forms.MenuItem mitMostraCampoBD;
			private System.Windows.Forms.MenuItem menuItem26;
			private System.Windows.Forms.MenuItem mitSalvarRelat;
			private System.Windows.Forms.MenuItem menuItem27;
			private System.Windows.Forms.MenuItem mitLimparRelat;
			private System.Windows.Forms.MenuItem mitSalvarComo;
			private System.Windows.Forms.MenuItem mitCorNotPrint;
			private System.Windows.Forms.MenuItem mitCorHL;

			private System.Windows.Forms.MenuItem mitMargem;
			private System.Windows.Forms.MenuItem mitMargemEsq;
			private System.Windows.Forms.MenuItem mitMargemDir;
			private System.Windows.Forms.MenuItem mitMargemCima;
			private System.Windows.Forms.MenuItem mitMargemBaixo;
			private System.Windows.Forms.MenuItem menuItem28;
			private System.Windows.Forms.MenuItem mitExcluirRel;
			private System.Windows.Forms.MenuItem menuItem29;
			private System.Windows.Forms.MenuItem mitViewMode;
			private System.Windows.Forms.MenuItem menuItem30;
			private System.Windows.Forms.MenuItem mitAnterior;
			private System.Windows.Forms.MenuItem mitProxima;
			private System.Windows.Forms.MenuItem mitPrimeira;
			private System.Windows.Forms.MenuItem mitUltima;
			private System.Windows.Forms.MenuItem mirImprimir;
			private System.Windows.Forms.MenuItem menuItem32;
			private System.Windows.Forms.MenuItem menuItem31;
			private System.Windows.Forms.MenuItem menuItem33;
			private System.Windows.Forms.MenuItem mitAlinEsq;
			private System.Windows.Forms.MenuItem mitAligDireita;
			private System.Windows.Forms.MenuItem mitAligCentr;
			private System.Windows.Forms.MenuItem mitSelTudo;
			private System.Windows.Forms.MenuItem menuItem34;
			private System.Windows.Forms.MenuItem mitHor;
			private System.Windows.Forms.MenuItem mitVert;
			private System.Windows.Forms.MenuItem mitSalvar;
			private System.Windows.Forms.MenuItem mitTCB;
			private System.Windows.Forms.MenuItem mirImagem;
			private System.Windows.Forms.MenuItem menuItem35;
		private System.Windows.Forms.MenuItem m_miPDF;
			private System.Windows.Forms.MenuItem mitFCB;

		#endregion
		#region Constructor and Destructors
			public frmPrincipal(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionBD,string strEnderecoExecutavel,int nIdExportador,int nIdTipoRelatorio,string strIdCodigo)
			{
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();
				m_cls_dba_ConnectionBD = cls_dba_ConnectionBD;
				m_tratadorErro = new clsTratamentoErro();
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_nIdTipo = nIdTipoRelatorio;
			    m_strIdCodigo = strIdCodigo;
				this.me = new MouseEventHandler( fmrPrincipal_MouseMove );
				this.mitEstiloCanetaPonto.Click += new System.EventHandler( this.mitEstiloCaneta_Click );
				this.mitEstiloCanetaTraco.Click += new System.EventHandler( this.mitEstiloCaneta_Click );
				this.mitEstiloCanetaTracoPonto.Click += new System.EventHandler( this.mitEstiloCaneta_Click );
				this.mitEstiloCanetaTracoPontoPonto.Click += new System.EventHandler( this.mitEstiloCaneta_Click );
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
			this.menu = new System.Windows.Forms.MainMenu();
			this.menuItem35 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.mitAbrir = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.mitSalvarRelat = new System.Windows.Forms.MenuItem();
			this.mitSalvarComo = new System.Windows.Forms.MenuItem();
			this.menuItem26 = new System.Windows.Forms.MenuItem();
			this.mitExcluirRel = new System.Windows.Forms.MenuItem();
			this.menuItem28 = new System.Windows.Forms.MenuItem();
			this.mirImagem = new System.Windows.Forms.MenuItem();
			this.mirImprimir = new System.Windows.Forms.MenuItem();
			this.menuItem32 = new System.Windows.Forms.MenuItem();
			this.mitSair = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mitSelecao = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mitLinha = new System.Windows.Forms.MenuItem();
			this.mitRetangulo = new System.Windows.Forms.MenuItem();
			this.mitCirculo = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.mitTexto = new System.Windows.Forms.MenuItem();
			this.mitImagem = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mitAreaProd = new System.Windows.Forms.MenuItem();
			this.mitCampoBD = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.mitNenhum = new System.Windows.Forms.MenuItem();
			this.menuItem29 = new System.Windows.Forms.MenuItem();
			this.mitViewMode = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mitGrade = new System.Windows.Forms.MenuItem();
			this.mitMargens = new System.Windows.Forms.MenuItem();
			this.mitExibirAreaProd = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.mitMostrarLinhas = new System.Windows.Forms.MenuItem();
			this.mitMostraRet = new System.Windows.Forms.MenuItem();
			this.mitMostraCirc = new System.Windows.Forms.MenuItem();
			this.mitMostraTexto = new System.Windows.Forms.MenuItem();
			this.mitMostraImagem = new System.Windows.Forms.MenuItem();
			this.mitMostraCampoBD = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.mitCorCaneta = new System.Windows.Forms.MenuItem();
			this.mitEspessura = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.mitEstiloCaneta = new System.Windows.Forms.MenuItem();
			this.mitEstiloCanetaPonto = new System.Windows.Forms.MenuItem();
			this.mitEstiloCanetaTraco = new System.Windows.Forms.MenuItem();
			this.mitEstiloCanetaTracoPonto = new System.Windows.Forms.MenuItem();
			this.mitEstiloCanetaTracoPontoPonto = new System.Windows.Forms.MenuItem();
			this.mitFundo = new System.Windows.Forms.MenuItem();
			this.mitCorFundo = new System.Windows.Forms.MenuItem();
			this.mitOpaco = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.mitLivre = new System.Windows.Forms.MenuItem();
			this.mitHorizontal = new System.Windows.Forms.MenuItem();
			this.mitVertical = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.mitFonte = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.mitCorAreaPRod = new System.Windows.Forms.MenuItem();
			this.mitCorBDText = new System.Windows.Forms.MenuItem();
			this.mitCorMargem = new System.Windows.Forms.MenuItem();
			this.mitCorNotPrint = new System.Windows.Forms.MenuItem();
			this.mitCorHL = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.mitLimparSel = new System.Windows.Forms.MenuItem();
			this.mitSelTudo = new System.Windows.Forms.MenuItem();
			this.menuItem25 = new System.Windows.Forms.MenuItem();
			this.menuItem34 = new System.Windows.Forms.MenuItem();
			this.mitHor = new System.Windows.Forms.MenuItem();
			this.mitVert = new System.Windows.Forms.MenuItem();
			this.menuItem33 = new System.Windows.Forms.MenuItem();
			this.mitAlinEsq = new System.Windows.Forms.MenuItem();
			this.mitAligDireita = new System.Windows.Forms.MenuItem();
			this.mitAligCentr = new System.Windows.Forms.MenuItem();
			this.menuItem31 = new System.Windows.Forms.MenuItem();
			this.mitTCB = new System.Windows.Forms.MenuItem();
			this.mitFCB = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.mitRecuar = new System.Windows.Forms.MenuItem();
			this.mitAvancar = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.mitAgrupar = new System.Windows.Forms.MenuItem();
			this.mitDesagrupar = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.mitExcluir = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.mitDesfazer = new System.Windows.Forms.MenuItem();
			this.mitRefazer = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.mitMaisZoom = new System.Windows.Forms.MenuItem();
			this.mitMenosZoom = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.mitDelAreaProd = new System.Windows.Forms.MenuItem();
			this.menuItem27 = new System.Windows.Forms.MenuItem();
			this.mitLimparRelat = new System.Windows.Forms.MenuItem();
			this.mitMargem = new System.Windows.Forms.MenuItem();
			this.mitMargemEsq = new System.Windows.Forms.MenuItem();
			this.mitMargemDir = new System.Windows.Forms.MenuItem();
			this.mitMargemCima = new System.Windows.Forms.MenuItem();
			this.mitMargemBaixo = new System.Windows.Forms.MenuItem();
			this.menuItem30 = new System.Windows.Forms.MenuItem();
			this.mitPrimeira = new System.Windows.Forms.MenuItem();
			this.mitAnterior = new System.Windows.Forms.MenuItem();
			this.mitProxima = new System.Windows.Forms.MenuItem();
			this.mitUltima = new System.Windows.Forms.MenuItem();
			this.mitSalvar = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.dlgCor = new System.Windows.Forms.ColorDialog();
			this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
			this.dlgFonte = new System.Windows.Forms.FontDialog();
			this.m_miPDF = new System.Windows.Forms.MenuItem();
			// 
			// menu
			// 
			this.menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				 this.menuItem35,
																				 this.menuItem19,
																				 this.menuItem1,
																				 this.menuItem4,
																				 this.menuItem5,
																				 this.menuItem11,
																				 this.mitMargem,
																				 this.menuItem30,
																				 this.menuItem15});
			// 
			// menuItem35
			// 
			this.menuItem35.Index = 0;
			this.menuItem35.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.menuItem35.Text = "Canvas";
			this.menuItem35.Click += new System.EventHandler(this.menuItem35_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 1;
			this.menuItem19.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mitAbrir,
																					   this.menuItem21,
																					   this.mitSalvarRelat,
																					   this.mitSalvarComo,
																					   this.menuItem26,
																					   this.mitExcluirRel,
																					   this.menuItem28,
																					   this.mirImagem,
																					   this.mirImprimir,
																					   this.menuItem32,
																					   this.mitSair});
			this.menuItem19.Text = "&Arquivo";
			// 
			// mitAbrir
			// 
			this.mitAbrir.Index = 0;
			this.mitAbrir.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.mitAbrir.Text = "&Abrir Relatório...";
			this.mitAbrir.Click += new System.EventHandler(this.mitAbrir_Click);
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 1;
			this.menuItem21.Text = "-";
			// 
			// mitSalvarRelat
			// 
			this.mitSalvarRelat.Index = 2;
			this.mitSalvarRelat.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.mitSalvarRelat.Text = "Sal&var";
			this.mitSalvarRelat.Click += new System.EventHandler(this.mitSalvarRelat_Click);
			// 
			// mitSalvarComo
			// 
			this.mitSalvarComo.Index = 3;
			this.mitSalvarComo.Text = "Salvar co&mo...";
			this.mitSalvarComo.Click += new System.EventHandler(this.mitSalvarComo_Click);
			// 
			// menuItem26
			// 
			this.menuItem26.Index = 4;
			this.menuItem26.Text = "-";
			// 
			// mitExcluirRel
			// 
			this.mitExcluirRel.Index = 5;
			this.mitExcluirRel.Text = "E&xcluir";
			this.mitExcluirRel.Click += new System.EventHandler(this.mitExcluirRel_Click);
			// 
			// menuItem28
			// 
			this.menuItem28.Index = 6;
			this.menuItem28.Text = "-";
			// 
			// mirImagem
			// 
			this.mirImagem.Index = 7;
			this.mirImagem.Text = "Imagem";
			this.mirImagem.Click += new System.EventHandler(this.mirImagem_Click);
			// 
			// mirImprimir
			// 
			this.mirImprimir.Index = 8;
			this.mirImprimir.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
			this.mirImprimir.Text = "Imprimir...";
			this.mirImprimir.Click += new System.EventHandler(this.mirImprimir_Click);
			// 
			// menuItem32
			// 
			this.menuItem32.Index = 9;
			this.menuItem32.Text = "-";
			// 
			// mitSair
			// 
			this.mitSair.Index = 10;
			this.mitSair.Shortcut = System.Windows.Forms.Shortcut.CtrlQ;
			this.mitSair.Text = "&Sair";
			this.mitSair.Click += new System.EventHandler(this.mitSair_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 2;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mitSelecao,
																					  this.menuItem3,
																					  this.mitLinha,
																					  this.mitRetangulo,
																					  this.mitCirculo,
																					  this.menuItem7,
																					  this.mitTexto,
																					  this.mitImagem,
																					  this.menuItem2,
																					  this.mitAreaProd,
																					  this.mitCampoBD,
																					  this.menuItem20,
																					  this.mitNenhum,
																					  this.menuItem29,
																					  this.mitViewMode});
			this.menuItem1.Text = "&Ferramenta";
			// 
			// mitSelecao
			// 
			this.mitSelecao.Index = 0;
			this.mitSelecao.Text = "Seleção";
			this.mitSelecao.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "-";
			// 
			// mitLinha
			// 
			this.mitLinha.Index = 2;
			this.mitLinha.Text = "Linha";
			this.mitLinha.Click += new System.EventHandler(this.mitLinha_Click);
			// 
			// mitRetangulo
			// 
			this.mitRetangulo.Index = 3;
			this.mitRetangulo.Text = "Retangulo";
			this.mitRetangulo.Click += new System.EventHandler(this.mitRetangulo_Click);
			// 
			// mitCirculo
			// 
			this.mitCirculo.Index = 4;
			this.mitCirculo.Text = "Círculo";
			this.mitCirculo.Click += new System.EventHandler(this.mitCirculo_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 5;
			this.menuItem7.Text = "-";
			// 
			// mitTexto
			// 
			this.mitTexto.Index = 6;
			this.mitTexto.Text = "Texto...";
			this.mitTexto.Click += new System.EventHandler(this.mitTexto_Click);
			// 
			// mitImagem
			// 
			this.mitImagem.Index = 7;
			this.mitImagem.Text = "Imagem...";
			this.mitImagem.Click += new System.EventHandler(this.mitImagem_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 8;
			this.menuItem2.Text = "-";
			// 
			// mitAreaProd
			// 
			this.mitAreaProd.Index = 9;
			this.mitAreaProd.Text = "Área de produtos";
			this.mitAreaProd.Click += new System.EventHandler(this.mitAreaProd_Click);
			// 
			// mitCampoBD
			// 
			this.mitCampoBD.Index = 10;
			this.mitCampoBD.Text = "Campo do BD ...";
			this.mitCampoBD.Click += new System.EventHandler(this.mitCampoBD_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 11;
			this.menuItem20.Text = "-";
			// 
			// mitNenhum
			// 
			this.mitNenhum.Index = 12;
			this.mitNenhum.Text = "Nenhum";
			this.mitNenhum.Click += new System.EventHandler(this.mitNenhum_Click);
			// 
			// menuItem29
			// 
			this.menuItem29.Index = 13;
			this.menuItem29.Text = "-";
			// 
			// mitViewMode
			// 
			this.mitViewMode.Index = 14;
			this.mitViewMode.Shortcut = System.Windows.Forms.Shortcut.F9;
			this.mitViewMode.Text = "Modo de &visualização";
			this.mitViewMode.Click += new System.EventHandler(this.mitViewMode_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mitGrade,
																					  this.mitMargens,
																					  this.mitExibirAreaProd,
																					  this.menuItem24,
																					  this.mitMostrarLinhas,
																					  this.mitMostraRet,
																					  this.mitMostraCirc,
																					  this.mitMostraTexto,
																					  this.mitMostraImagem,
																					  this.mitMostraCampoBD});
			this.menuItem4.Text = "E&xibir";
			// 
			// mitGrade
			// 
			this.mitGrade.Index = 0;
			this.mitGrade.Text = "&Grade";
			this.mitGrade.Click += new System.EventHandler(this.mitGrade_Click);
			// 
			// mitMargens
			// 
			this.mitMargens.Index = 1;
			this.mitMargens.Text = "&Margens";
			this.mitMargens.Click += new System.EventHandler(this.mitMargens_Click);
			// 
			// mitExibirAreaProd
			// 
			this.mitExibirAreaProd.Index = 2;
			this.mitExibirAreaProd.Text = "Área de &produtos";
			this.mitExibirAreaProd.Click += new System.EventHandler(this.mitExibirAreaProd_Click);
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 3;
			this.menuItem24.Text = "-";
			// 
			// mitMostrarLinhas
			// 
			this.mitMostrarLinhas.Checked = true;
			this.mitMostrarLinhas.Index = 4;
			this.mitMostrarLinhas.Text = "Linhas";
			this.mitMostrarLinhas.Click += new System.EventHandler(this.mitMostrarLinhas_Click);
			// 
			// mitMostraRet
			// 
			this.mitMostraRet.Checked = true;
			this.mitMostraRet.Index = 5;
			this.mitMostraRet.Text = "Retângulos";
			this.mitMostraRet.Click += new System.EventHandler(this.mitMostraRet_Click);
			// 
			// mitMostraCirc
			// 
			this.mitMostraCirc.Checked = true;
			this.mitMostraCirc.Index = 6;
			this.mitMostraCirc.Text = "Círculos";
			this.mitMostraCirc.Click += new System.EventHandler(this.mitMostraCirc_Click);
			// 
			// mitMostraTexto
			// 
			this.mitMostraTexto.Checked = true;
			this.mitMostraTexto.Index = 7;
			this.mitMostraTexto.Text = "Textos";
			this.mitMostraTexto.Click += new System.EventHandler(this.mitMostraTexto_Click);
			// 
			// mitMostraImagem
			// 
			this.mitMostraImagem.Checked = true;
			this.mitMostraImagem.Index = 8;
			this.mitMostraImagem.Text = "Imagens";
			this.mitMostraImagem.Click += new System.EventHandler(this.mitMostraImagem_Click);
			// 
			// mitMostraCampoBD
			// 
			this.mitMostraCampoBD.Checked = true;
			this.mitMostraCampoBD.Index = 9;
			this.mitMostraCampoBD.Text = "Campo de BD";
			this.mitMostraCampoBD.Click += new System.EventHandler(this.mitMostraCampoBD_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 4;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem6,
																					  this.mitFundo,
																					  this.menuItem8,
																					  this.menuItem9,
																					  this.menuItem23});
			this.menuItem5.Text = "Estilos";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 0;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mitCorCaneta,
																					  this.mitEspessura,
																					  this.menuItem10});
			this.menuItem6.Text = "Caneta";
			// 
			// mitCorCaneta
			// 
			this.mitCorCaneta.Index = 0;
			this.mitCorCaneta.Text = "Cor...";
			this.mitCorCaneta.Click += new System.EventHandler(this.mitCorCaneta_Click);
			// 
			// mitEspessura
			// 
			this.mitEspessura.Index = 1;
			this.mitEspessura.Text = "Espessura";
			this.mitEspessura.Click += new System.EventHandler(this.mitEspessura_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 2;
			this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mitEstiloCaneta,
																					   this.mitEstiloCanetaPonto,
																					   this.mitEstiloCanetaTraco,
																					   this.mitEstiloCanetaTracoPonto,
																					   this.mitEstiloCanetaTracoPontoPonto});
			this.menuItem10.Text = "Estilo";
			// 
			// mitEstiloCaneta
			// 
			this.mitEstiloCaneta.Checked = true;
			this.mitEstiloCaneta.Index = 0;
			this.mitEstiloCaneta.Text = "Sólido";
			this.mitEstiloCaneta.Click += new System.EventHandler(this.mitEstiloCaneta_Click);
			// 
			// mitEstiloCanetaPonto
			// 
			this.mitEstiloCanetaPonto.Index = 1;
			this.mitEstiloCanetaPonto.Text = "Ponto";
			// 
			// mitEstiloCanetaTraco
			// 
			this.mitEstiloCanetaTraco.Index = 2;
			this.mitEstiloCanetaTraco.Text = "Traço";
			// 
			// mitEstiloCanetaTracoPonto
			// 
			this.mitEstiloCanetaTracoPonto.Index = 3;
			this.mitEstiloCanetaTracoPonto.Text = "Traço-Ponto";
			// 
			// mitEstiloCanetaTracoPontoPonto
			// 
			this.mitEstiloCanetaTracoPontoPonto.Index = 4;
			this.mitEstiloCanetaTracoPontoPonto.Text = "Traço-Ponto-Ponto";
			// 
			// mitFundo
			// 
			this.mitFundo.Index = 1;
			this.mitFundo.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mitCorFundo,
																					 this.mitOpaco,
																					 this.menuItem12});
			this.mitFundo.Text = "Fundo";
			// 
			// mitCorFundo
			// 
			this.mitCorFundo.Index = 0;
			this.mitCorFundo.Text = "Cor...";
			this.mitCorFundo.Click += new System.EventHandler(this.mitCorFundo_Click);
			// 
			// mitOpaco
			// 
			this.mitOpaco.Index = 1;
			this.mitOpaco.Text = "Opaco";
			this.mitOpaco.Click += new System.EventHandler(this.mitOpaco_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 2;
			this.menuItem12.Text = "Padrão";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 2;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mitLivre,
																					  this.mitHorizontal,
																					  this.mitVertical});
			this.menuItem8.Text = "Linha";
			// 
			// mitLivre
			// 
			this.mitLivre.Checked = true;
			this.mitLivre.Index = 0;
			this.mitLivre.RadioCheck = true;
			this.mitLivre.Text = "Livre";
			this.mitLivre.Click += new System.EventHandler(this.mitLivre_Click);
			// 
			// mitHorizontal
			// 
			this.mitHorizontal.Index = 1;
			this.mitHorizontal.RadioCheck = true;
			this.mitHorizontal.Text = "Horizontal";
			this.mitHorizontal.Click += new System.EventHandler(this.mitHorizontal_Click);
			// 
			// mitVertical
			// 
			this.mitVertical.Index = 2;
			this.mitVertical.RadioCheck = true;
			this.mitVertical.Text = "Vertical";
			this.mitVertical.Click += new System.EventHandler(this.mitVertical_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 3;
			this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mitFonte});
			this.menuItem9.Text = "Texto";
			// 
			// mitFonte
			// 
			this.mitFonte.Index = 0;
			this.mitFonte.Text = "Fonte...";
			this.mitFonte.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem23
			// 
			this.menuItem23.Index = 4;
			this.menuItem23.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mitCorAreaPRod,
																					   this.mitCorBDText,
																					   this.mitCorMargem,
																					   this.mitCorNotPrint,
																					   this.mitCorHL});
			this.menuItem23.Text = "Cores";
			// 
			// mitCorAreaPRod
			// 
			this.mitCorAreaPRod.Index = 0;
			this.mitCorAreaPRod.Text = "Área de produtos...";
			this.mitCorAreaPRod.Click += new System.EventHandler(this.mitCorAreaPRod_Click);
			// 
			// mitCorBDText
			// 
			this.mitCorBDText.Index = 1;
			this.mitCorBDText.Text = "Fundo de Texto de BD...";
			this.mitCorBDText.Click += new System.EventHandler(this.mitCorBDText_Click);
			// 
			// mitCorMargem
			// 
			this.mitCorMargem.Index = 2;
			this.mitCorMargem.Text = "Margem...";
			this.mitCorMargem.Click += new System.EventHandler(this.mitCorMargem_Click);
			// 
			// mitCorNotPrint
			// 
			this.mitCorNotPrint.Index = 3;
			this.mitCorNotPrint.Text = "Objetos não imprimíveis...";
			this.mitCorNotPrint.Click += new System.EventHandler(this.mitCorNotPrint_Click);
			// 
			// mitCorHL
			// 
			this.mitCorHL.Index = 4;
			this.mitCorHL.Text = "Highlight...";
			this.mitCorHL.Click += new System.EventHandler(this.mitCorHL_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 5;
			this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mitLimparSel,
																					   this.mitSelTudo,
																					   this.menuItem25,
																					   this.menuItem34,
																					   this.menuItem33,
																					   this.menuItem31,
																					   this.mitTCB,
																					   this.mitFCB,
																					   this.menuItem13,
																					   this.mitRecuar,
																					   this.mitAvancar,
																					   this.menuItem16,
																					   this.mitAgrupar,
																					   this.mitDesagrupar,
																					   this.menuItem14,
																					   this.mitExcluir,
																					   this.menuItem17,
																					   this.mitDesfazer,
																					   this.mitRefazer,
																					   this.menuItem18,
																					   this.mitMaisZoom,
																					   this.mitMenosZoom,
																					   this.menuItem22,
																					   this.mitDelAreaProd,
																					   this.menuItem27,
																					   this.mitLimparRelat});
			this.menuItem11.Text = "Operações";
			// 
			// mitLimparSel
			// 
			this.mitLimparSel.Index = 0;
			this.mitLimparSel.Text = "Limpar seleção";
			this.mitLimparSel.Click += new System.EventHandler(this.mitLimparSel_Click);
			// 
			// mitSelTudo
			// 
			this.mitSelTudo.Index = 1;
			this.mitSelTudo.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
			this.mitSelTudo.Text = "Selecionar &tudo";
			this.mitSelTudo.Click += new System.EventHandler(this.mitSelTudo_Click);
			// 
			// menuItem25
			// 
			this.menuItem25.Index = 2;
			this.menuItem25.Text = "-";
			// 
			// menuItem34
			// 
			this.menuItem34.Index = 3;
			this.menuItem34.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mitHor,
																					   this.mitVert});
			this.menuItem34.Text = "Espaçamento";
			// 
			// mitHor
			// 
			this.mitHor.Index = 0;
			this.mitHor.Text = "Horizontal";
			this.mitHor.Click += new System.EventHandler(this.mitHor_Click);
			// 
			// mitVert
			// 
			this.mitVert.Index = 1;
			this.mitVert.Text = "Vertical";
			this.mitVert.Click += new System.EventHandler(this.mitVert_Click);
			// 
			// menuItem33
			// 
			this.menuItem33.Index = 4;
			this.menuItem33.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mitAlinEsq,
																					   this.mitAligDireita,
																					   this.mitAligCentr});
			this.menuItem33.Text = "Alinhamento";
			// 
			// mitAlinEsq
			// 
			this.mitAlinEsq.Index = 0;
			this.mitAlinEsq.Text = "&Esquerda";
			this.mitAlinEsq.Click += new System.EventHandler(this.mitAlinEsq_Click);
			// 
			// mitAligDireita
			// 
			this.mitAligDireita.Index = 1;
			this.mitAligDireita.Text = "&Direita";
			this.mitAligDireita.Click += new System.EventHandler(this.mitAligDireita_Click);
			// 
			// mitAligCentr
			// 
			this.mitAligCentr.Index = 2;
			this.mitAligCentr.Text = "&Centralizado";
			this.mitAligCentr.Click += new System.EventHandler(this.mitAligCentr_Click);
			// 
			// menuItem31
			// 
			this.menuItem31.Index = 5;
			this.menuItem31.Text = "-";
			// 
			// mitTCB
			// 
			this.mitTCB.Index = 6;
			this.mitTCB.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.mitTCB.Text = "To ClipBoard";
			this.mitTCB.Click += new System.EventHandler(this.mitTCB_Click);
			// 
			// mitFCB
			// 
			this.mitFCB.Index = 7;
			this.mitFCB.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
			this.mitFCB.Text = "From ClipBoard";
			this.mitFCB.Click += new System.EventHandler(this.mitFCB_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 8;
			this.menuItem13.Text = "-";
			// 
			// mitRecuar
			// 
			this.mitRecuar.Index = 9;
			this.mitRecuar.Text = "";
			// 
			// mitAvancar
			// 
			this.mitAvancar.Index = 10;
			this.mitAvancar.Text = "";
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 11;
			this.menuItem16.Text = "-";
			// 
			// mitAgrupar
			// 
			this.mitAgrupar.Index = 12;
			this.mitAgrupar.Text = "&Agrupar";
			this.mitAgrupar.Click += new System.EventHandler(this.mitAgrupar_Click);
			// 
			// mitDesagrupar
			// 
			this.mitDesagrupar.Index = 13;
			this.mitDesagrupar.Text = "&Desagrupar";
			this.mitDesagrupar.Click += new System.EventHandler(this.mitDesagrupar_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 14;
			this.menuItem14.Text = "-";
			// 
			// mitExcluir
			// 
			this.mitExcluir.Index = 15;
			this.mitExcluir.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.mitExcluir.Text = "&Excluir";
			this.mitExcluir.Click += new System.EventHandler(this.mitExcluir_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 16;
			this.menuItem17.Text = "-";
			// 
			// mitDesfazer
			// 
			this.mitDesfazer.Index = 17;
			this.mitDesfazer.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
			this.mitDesfazer.Text = "Desfazer";
			this.mitDesfazer.Click += new System.EventHandler(this.mitDesfazer_Click);
			// 
			// mitRefazer
			// 
			this.mitRefazer.Index = 18;
			this.mitRefazer.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftZ;
			this.mitRefazer.Text = "Refazer";
			this.mitRefazer.Click += new System.EventHandler(this.mitRefazer_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 19;
			this.menuItem18.Text = "-";
			// 
			// mitMaisZoom
			// 
			this.mitMaisZoom.Index = 20;
			this.mitMaisZoom.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.mitMaisZoom.Text = "Mais Zoom";
			this.mitMaisZoom.Click += new System.EventHandler(this.mitMaisZoom_Click);
			// 
			// mitMenosZoom
			// 
			this.mitMenosZoom.Index = 21;
			this.mitMenosZoom.Shortcut = System.Windows.Forms.Shortcut.F4;
			this.mitMenosZoom.Text = "Menos Zoom";
			this.mitMenosZoom.Click += new System.EventHandler(this.mitMenosZoom_Click);
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 22;
			this.menuItem22.Text = "-";
			// 
			// mitDelAreaProd
			// 
			this.mitDelAreaProd.Index = 23;
			this.mitDelAreaProd.Text = "Remover Área de Produtos";
			this.mitDelAreaProd.Click += new System.EventHandler(this.mitDelAreaProd_Click);
			// 
			// menuItem27
			// 
			this.menuItem27.Index = 24;
			this.menuItem27.Text = "-";
			// 
			// mitLimparRelat
			// 
			this.mitLimparRelat.Index = 25;
			this.mitLimparRelat.Text = "&Limpar relatório";
			this.mitLimparRelat.Click += new System.EventHandler(this.mitLimparRelat_Click);
			// 
			// mitMargem
			// 
			this.mitMargem.Index = 6;
			this.mitMargem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mitMargemEsq,
																					  this.mitMargemDir,
																					  this.mitMargemCima,
																					  this.mitMargemBaixo});
			this.mitMargem.Text = "&Margem";
			// 
			// mitMargemEsq
			// 
			this.mitMargemEsq.Index = 0;
			this.mitMargemEsq.Text = "Esquerda...";
			this.mitMargemEsq.Click += new System.EventHandler(this.mitMargemEsq_Click);
			// 
			// mitMargemDir
			// 
			this.mitMargemDir.Index = 1;
			this.mitMargemDir.Text = "Direita...";
			this.mitMargemDir.Click += new System.EventHandler(this.mitMargemDir_Click);
			// 
			// mitMargemCima
			// 
			this.mitMargemCima.Index = 2;
			this.mitMargemCima.Text = "Cima...";
			this.mitMargemCima.Click += new System.EventHandler(this.mitMargemCima_Click);
			// 
			// mitMargemBaixo
			// 
			this.mitMargemBaixo.Index = 3;
			this.mitMargemBaixo.Text = "Baixo...";
			this.mitMargemBaixo.Click += new System.EventHandler(this.mitMargemBaixo_Click);
			// 
			// menuItem30
			// 
			this.menuItem30.Index = 7;
			this.menuItem30.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mitPrimeira,
																					   this.mitAnterior,
																					   this.mitProxima,
																					   this.mitUltima,
																					   this.mitSalvar,
																					   this.m_miPDF});
			this.menuItem30.Text = "Páginas";
			// 
			// mitPrimeira
			// 
			this.mitPrimeira.Index = 0;
			this.mitPrimeira.Text = "Primeira";
			this.mitPrimeira.Click += new System.EventHandler(this.mitPrimeira_Click);
			// 
			// mitAnterior
			// 
			this.mitAnterior.Index = 1;
			this.mitAnterior.Text = "Anterior";
			this.mitAnterior.Click += new System.EventHandler(this.mitAnterior_Click);
			// 
			// mitProxima
			// 
			this.mitProxima.Index = 2;
			this.mitProxima.Text = "Próxima";
			this.mitProxima.Click += new System.EventHandler(this.menuItem32_Click);
			// 
			// mitUltima
			// 
			this.mitUltima.Index = 3;
			this.mitUltima.Text = "Última";
			this.mitUltima.Click += new System.EventHandler(this.mitUltima_Click);
			// 
			// mitSalvar
			// 
			this.mitSalvar.Index = 4;
			this.mitSalvar.Text = "Salvar";
			this.mitSalvar.Click += new System.EventHandler(this.mitSalvar_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 8;
			this.menuItem15.Text = "GC";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// dlgCor
			// 
			this.dlgCor.FullOpen = true;
			// 
			// dlgAbrir
			// 
			this.dlgAbrir.Filter = "JPEG|*.jpg|GIF|*.gif|Bitmap|*.bmp";
			// 
			// dlgFonte
			// 
			this.dlgFonte.ShowColor = true;
			// 
			// m_miPDF
			// 
			this.m_miPDF.Index = 5;
			this.m_miPDF.Text = "PDF";
			this.m_miPDF.Click += new System.EventHandler(this.m_miPDF_Click);
			// 
			// frmPrincipal
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(984, 729);
			this.Menu = this.menu;
			this.Name = "frmPrincipal";
			this.Text = "Teste de Componentes";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrincipal_KeyDown);

		}
		#endregion

		#region Eventos 
			#region Formulario
				protected void fmrPrincipal_MouseMove(Object sender, MouseEventArgs ex)
				{
					double dZoom = canvas.dGetZoom();
					String strZoom = String.Format( "{0:N}", dZoom);
					Text = "Página: (X, Y) = (" + canvas.MousePos.X + ", " + canvas.MousePos.Y 
						+ ") Tela: (X, Y) = (" + ex.X + ", " + ex.Y
						+ ") ZOOM = " + strZoom + "%";
				}

				private void frmPrincipal_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
				{
					bool NaoPodeMover = false;
					if (canvas != null)
						canvas.bMoveWindow( e.KeyCode, ref NaoPodeMover );
				}
			#endregion
		#endregion
		#region Metodos
			private void LimpaFerramentas()
			{
				mitSelecao.Checked = false;
				mitLinha.Checked = false;
				mitRetangulo.Checked = false;
				mitCirculo.Checked = false;
				mitNenhum.Checked = false;
				mitAreaProd.Checked = false;
				mitViewMode.Checked = false;
			}
		#endregion
		#region Menus Itens
		private void menuItem35_Click(object sender, System.EventArgs e)
		{
			this.canvas = new ReportCanvasPackage.ReportCanvas(this.components);

			canvas.SetDataBaseAccess( ref m_cls_dba_ConnectionBD); 
			canvas.SetEnderecoExecutavel(m_strEnderecoExecutavel);
			canvas.SetIdCodigo(m_strIdCodigo);
			canvas.SetTratadorDeErro( ref m_tratadorErro );
			this.canvas.MouseMove += this.me;
			((ReportCanvasPackage.ReportCanvas)canvas).eCallPropertiesBoxObjectTextDB +=new ReportCanvasPackage.ReportCanvas.delCallPropertiesBoxObjectTextDB(frmPrincipal_eCallPropertiesBoxObjectTextDB);
			// 
			// canvas
			// 
			this.canvas.BackColor = System.Drawing.Color.White;
			this.canvas.BackgroundColor = System.Drawing.Color.White;
			this.canvas.BackgroundColorLabel = System.Drawing.Color.LightGreen;
			this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.canvas.CurrentSubTool = ReportCanvasPackage.SubTool.None;
			this.canvas.CurrentTool = DrawingCanvasPackage.Tool.None;
			this.canvas.DBAlinhamento = 0;
			this.canvas.DBAlinhamentoInferiorAreaProdutos = false;
			this.canvas.DBCallBack = false;
			this.canvas.DBFormatoNumero = 0;
			this.canvas.DBIdCampo = 0;
			this.canvas.DBImprimirSomenteUltimaPagina = false;
			this.canvas.DBPertenceAreaProdutos = false;
			this.canvas.DBTextColor = System.Drawing.Color.LemonChiffon;
			this.canvas.HighlightColor = System.Drawing.SystemColors.Highlight;
			this.canvas.IdCodigo = "1";
			this.canvas.ImageToInsert = null;
			this.canvas.ImageToInsertIndex = 0;
			this.canvas.LineType = DrawingCanvasPackage.LineStyle.Free;
			this.canvas.Location = new System.Drawing.Point(-56, 8);
			this.canvas.MarginColor = System.Drawing.Color.LightSeaGreen;
			this.canvas.MousePos = new System.Drawing.Point(0, 0);
			this.canvas.Name = "canvas";
			this.canvas.NotPrintableColor = System.Drawing.SystemColors.InactiveCaption;
			this.canvas.ObjectPrintable = true;
			this.canvas.ObjetoVisivelImpressao = false;
			this.canvas.OpaqueObject = false;
			this.canvas.Orientation = 0;
			this.canvas.PageSize = new System.Drawing.Size(400, 800);
			this.canvas.PenColor = System.Drawing.Color.Black;
			this.canvas.PenStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.canvas.PenWidth = 1;
			this.canvas.ProductAreaColor = System.Drawing.Color.Azure;
			this.canvas.SelectionColor = System.Drawing.Color.Blue;
			this.canvas.ShowCircles = true;
			this.canvas.ShowDBText = true;
			this.canvas.ShowDBTextDados = true;
			this.canvas.ShowGrid = false;
			this.canvas.ShowImage = true;
			this.canvas.ShowLines = true;
			this.canvas.ShowMargins = false;
			this.canvas.ShowProductArea = false;
			this.canvas.ShowRectangles = true;
			this.canvas.ShowText = true;
			this.canvas.Size = new System.Drawing.Size(1032, 680);
			this.canvas.TabIndex = 0;
			this.canvas.TabStop = false;
			this.canvas.TextColor = System.Drawing.Color.Black;
			this.canvas.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.canvas.TextString = null;

			this.Controls.Add(this.canvas);
		}

		private void mitLinha_Click(object sender, System.EventArgs e)
		{
			LimpaFerramentas();
			mitLinha.Checked = true;
			canvas.CurrentTool = DrawingCanvasPackage.Tool.Line;
		}

		private void mitRetangulo_Click(object sender, System.EventArgs e)
		{
			LimpaFerramentas();
			mitRetangulo.Checked = true;
			canvas.CurrentTool = DrawingCanvasPackage.Tool.Rectangle;
		}

		private void mitCirculo_Click(object sender, System.EventArgs e)
		{
			LimpaFerramentas();
			mitCirculo.Checked = true;
			canvas.CurrentTool = DrawingCanvasPackage.Tool.Circle;
		}

		private void mitNenhum_Click(object sender, System.EventArgs e)
		{
			LimpaFerramentas();
			mitNenhum.Checked = true;
			canvas.CurrentTool = DrawingCanvasPackage.Tool.None;
		}

		private void mitCorCaneta_Click(object sender, System.EventArgs e)
		{
			dlgCor.Color = canvas.PenColor;
			if ( dlgCor.ShowDialog() == DialogResult.OK )
			{
				canvas.PenColor = dlgCor.Color;
			}
		}

		private void mitCorFundo_Click(object sender, System.EventArgs e)
		{
			dlgCor.Color = canvas.BackgroundColor;
			if ( dlgCor.ShowDialog() == DialogResult.OK) 
			{
				canvas.BackgroundColor = dlgCor.Color;
			}
		}

		private void mitEstiloCaneta_Click(object sender, System.EventArgs e) 
		{
			int nIndiceMenu = ((MenuItem)sender).Index;
			mitEstiloCaneta.Checked = false;
			mitEstiloCanetaTraco.Checked = false;
			mitEstiloCanetaTracoPonto.Checked = false;
			mitEstiloCanetaTracoPontoPonto.Checked = false;
			mitEstiloCanetaPonto.Checked = false;

			if ( mitEstiloCaneta.Index == nIndiceMenu )
			{
				mitEstiloCaneta.Checked = true;
				canvas.PenStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			} 
			else if ( mitEstiloCanetaPonto.Index == nIndiceMenu )
			{
				mitEstiloCanetaPonto.Checked = true;
				canvas.PenStyle = System.Drawing.Drawing2D.DashStyle.Dot;
			} 
			else if ( mitEstiloCanetaTraco.Index == nIndiceMenu )
			{
				mitEstiloCanetaTraco.Checked = true;
				canvas.PenStyle = System.Drawing.Drawing2D.DashStyle.Dash;
			}
			else if ( mitEstiloCanetaTracoPonto.Index == nIndiceMenu )
			{
				mitEstiloCanetaTracoPonto.Checked = true;
				canvas.PenStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
			} 
			else if ( mitEstiloCanetaTracoPontoPonto.Index == nIndiceMenu )
			{
				mitEstiloCanetaTracoPontoPonto.Checked = true;
				canvas.PenStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
			}
		}

		private void mitEspessura_Click(object sender, System.EventArgs e)
		{
			String strEspessura;
			strEspessura = "X";

			while ( IsNumeric(strEspessura) == false )
			{
				frmInput dlgInput = new frmInput("graf", "Espessura da caneta:", canvas.PenWidth.ToString() );
				dlgInput.ShowDialog();
				strEspessura = dlgInput.getEntrada();
			}
		
			canvas.PenWidth = Int32.Parse(strEspessura);
		}

		private bool IsNumeric( String strNum )
		{
			
			for ( int i = 0; i < strNum.Length; i++ )
				if ( Char.IsNumber(strNum, i) == false )
					return( false );

			return( true );
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			LimpaFerramentas();
			mitSelecao.Checked = true;
			canvas.CurrentTool = DrawingCanvasPackage.Tool.Selection;
			canvas.CurrentSubTool = ReportCanvasPackage.SubTool.None;
		}

		private void mitAreaProd_Click(object sender, System.EventArgs e)
		{
			LimpaFerramentas();
			mitAreaProd.Checked = true;
			canvas.CurrentTool = DrawingCanvasPackage.Tool.Selection;
			canvas.CurrentSubTool = ReportCanvasPackage.SubTool.ProductArea;
		}

		private void mitOpaco_Click(object sender, System.EventArgs e)
		{
			mitOpaco.Checked = !mitOpaco.Checked;
			canvas.OpaqueObject = mitOpaco.Checked;
		}

		private void mitGrade_Click(object sender, System.EventArgs e)
		{
			mitGrade.Checked = !mitGrade.Checked;
			canvas.ShowGrid = mitGrade.Checked;
		}

		private void mitLivre_Click(object sender, System.EventArgs e)
		{
			mitLivre.Checked = true;
			mitVertical.Checked = false;
			mitHorizontal.Checked = false;
			
			canvas.LineType = DrawingCanvasPackage.LineStyle.Free;
		}

		private void mitVertical_Click(object sender, System.EventArgs e)
		{
			mitLivre.Checked = false;
			mitVertical.Checked = true;
			mitHorizontal.Checked = false;
			
			canvas.LineType = DrawingCanvasPackage.LineStyle.Vertical;
		}

		private void mitHorizontal_Click(object sender, System.EventArgs e)
		{
			mitLivre.Checked = false;
			mitVertical.Checked = false;
			mitHorizontal.Checked = true;
			
			canvas.LineType = DrawingCanvasPackage.LineStyle.Horizontal;		
		}

		private void mitTexto_Click(object sender, System.EventArgs e)
		{
			frmInput dlgInput = new frmInput("graf", "Espessura da caneta:", "Texto" );
			if ( dlgInput.ShowDialog() == DialogResult.OK )
			{
				canvas.ClearSelection(false);
				canvas.CurrentTool = DrawingCanvasPackage.Tool.Text;
				canvas.CurrentSubTool = ReportCanvasPackage.SubTool.None;
				canvas.TextString = dlgInput.getEntrada();
			}
		}

		private void mitImagem_Click(object sender, System.EventArgs e)
		{
			if ( dlgAbrir.ShowDialog() == DialogResult.OK )
			{
				canvas.CurrentTool = DrawingCanvasPackage.Tool.Image;
				if (System.IO.File.Exists(dlgAbrir.FileName))
				{
					canvas.ImageToInsert = System.Drawing.Image.FromFile(dlgAbrir.FileName);
					canvas.ImageToInsertIndex = canvas.ImageToInsertIndex + 1;
				}
			}
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			dlgFonte.Font = canvas.TextFont;
			if ( dlgFonte.ShowDialog() == DialogResult.OK )
			{
				canvas.TextFont = dlgFonte.Font;
				canvas.TextColor = dlgFonte.Color;
			}
		}

		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			GC.Collect();
		}

		private void mitAgrupar_Click(object sender, System.EventArgs e)
		{
			canvas.bGroupObjects();
		}

		private void mitDesagrupar_Click(object sender, System.EventArgs e)
		{
			canvas.bUngroupObjects();
		}

		private void mitExcluir_Click(object sender, System.EventArgs e)
		{
			canvas.bDeleteObj();
		}

		private void mitDesfazer_Click(object sender, System.EventArgs e)
		{
			canvas.bUndo();
		}

		private void mitRefazer_Click(object sender, System.EventArgs e)
		{
			canvas.bRedo();
		}

		private void mitMaisZoom_Click(object sender, System.EventArgs e)
		{
			canvas.bMoreZoom();
		}

		private void mitMenosZoom_Click(object sender, System.EventArgs e)
		{
			canvas.bLessZoom();
		}

		private void mitSair_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void mitAbrir_Click(object sender, System.EventArgs e)
		{
			frmAbrirRelatorio abrir = new frmAbrirRelatorio( ref m_cls_dba_ConnectionBD);
			if ( abrir.ShowDialog() == DialogResult.OK )
			{
				m_nIdExportador = abrir.nIdExportador();
				m_nIdRel = abrir.nIdRelatorio();
				m_nIdTipo = abrir.nIdTipo();
				canvas.IdCodigo = m_strIdCodigo;
				if ( canvas.bAbrirRelatorio(abrir.nIdExportador(), abrir.nIdTipo(), abrir.nIdRelatorio() ) == false )
					System.Windows.Forms.MessageBox.Show( "Não foi possível abrir o relatório: Relatório não existente." );
			}
		}

		private void mitMargens_Click(object sender, System.EventArgs e)
		{
			mitMargens.Checked = !mitMargens.Checked;
			canvas.ShowMargins = mitMargens.Checked;
		}

		private void mitDelAreaProd_Click(object sender, System.EventArgs e)
		{
			canvas.RemoveProductArea( true );
		}

		private void mitExibirAreaProd_Click(object sender, System.EventArgs e)
		{
			mitExibirAreaProd.Checked = !mitExibirAreaProd.Checked;
			canvas.ShowProductArea = mitExibirAreaProd.Checked;
		}

		private void mitCorMargem_Click(object sender, System.EventArgs e)
		{
			dlgCor.Color = canvas.MarginColor;
			if ( dlgCor.ShowDialog() == DialogResult.OK) 
			{
				canvas.MarginColor = dlgCor.Color;
			}
		}

		private void mitCorAreaPRod_Click(object sender, System.EventArgs e)
		{
			dlgCor.Color = canvas.ProductAreaColor;
			if ( dlgCor.ShowDialog() == DialogResult.OK) 
			{
				canvas.ProductAreaColor = dlgCor.Color;
			}		
		}

		private void mitCorBDText_Click(object sender, System.EventArgs e)
		{
			dlgCor.Color = canvas.DBTextColor;
			if ( dlgCor.ShowDialog() == DialogResult.OK) 
			{
				canvas.DBTextColor = dlgCor.Color;
			}
		
		}

		private void mitCampoBD_Click(object sender, System.EventArgs e)
		{
			canvas.ClearSelection(false);
			canvas.CurrentTool = DrawingCanvasPackage.Tool.Text;
			canvas.CurrentSubTool = ReportCanvasPackage.SubTool.DBText;
		}

		private void mitLimparSel_Click(object sender, System.EventArgs e)
		{
			canvas.ClearSelection(true);
		}

		private void mitMostrarLinhas_Click(object sender, System.EventArgs e)
		{
			mitMostrarLinhas.Checked = !mitMostrarLinhas.Checked;
			canvas.ShowLines = mitMostrarLinhas.Checked;
		}

		private void mitMostraRet_Click(object sender, System.EventArgs e)
		{
			mitMostraRet.Checked = !mitMostraRet.Checked;
			canvas.ShowRectangles = mitMostraRet.Checked;		
		}

		private void mitMostraCirc_Click(object sender, System.EventArgs e)
		{
			mitMostraCirc.Checked = !mitMostraCirc.Checked;
			canvas.ShowCircles = mitMostraCirc.Checked;		
		}

		private void mitMostraTexto_Click(object sender, System.EventArgs e)
		{
			mitMostraTexto.Checked = !mitMostraTexto.Checked;
			canvas.ShowText = mitMostraTexto.Checked;		
		}

		private void mitMostraImagem_Click(object sender, System.EventArgs e)
		{
			mitMostraImagem.Checked = !mitMostraImagem.Checked;
			canvas.ShowImage = mitMostraImagem.Checked;		
		}

		private void mitMostraCampoBD_Click(object sender, System.EventArgs e)
		{
			mitMostraCampoBD.Checked = !mitMostraCampoBD.Checked;
			canvas.ShowDBText = mitMostraCampoBD.Checked;		
		}

		private void mitLimparRelat_Click(object sender, System.EventArgs e)
		{
			canvas.ClearData( true );	
		}

		private void mitCorNotPrint_Click(object sender, System.EventArgs e)
		{
			dlgCor.Color = canvas.NotPrintableColor;
			if ( dlgCor.ShowDialog() == DialogResult.OK) 
			{
				canvas.NotPrintableColor = dlgCor.Color;
			}
		}

		private void mitCorHL_Click(object sender, System.EventArgs e)
		{
			dlgCor.Color = canvas.HighlightColor;
			if ( dlgCor.ShowDialog() == DialogResult.OK) 
			{
				canvas.HighlightColor = dlgCor.Color;
			}		
		}

		private void mitSalvarRelat_Click(object sender, System.EventArgs e)
		{			
			if ( canvas.bSalvarRelatorio( m_nIdExportador, m_nIdTipo, m_nIdRel ) == false )
				System.Windows.Forms.MessageBox.Show( "Não foi possível salvar o relatório." );
		}

		private void mitMargemEsq_Click(object sender, System.EventArgs e)
		{
			frmInput dlgInput = new frmInput("graf", "Margem esquerda", canvas.GetLeftMargin().ToString() );
			if ( dlgInput.ShowDialog() == DialogResult.OK )
			{
				canvas.ClearSelection(false);
				canvas.SetMargins( Int32.Parse(dlgInput.getEntrada()), canvas.GetTopMargin(), canvas.GetRightMargin(), canvas.GetBottomMargin(), true );
			}
		}

		private void mitMargemDir_Click(object sender, System.EventArgs e)
		{
			frmInput dlgInput = new frmInput("graf", "Margem direita", canvas.GetRightMargin().ToString() );
			if ( dlgInput.ShowDialog() == DialogResult.OK )
			{
				canvas.ClearSelection(false);
				canvas.SetMargins( canvas.GetLeftMargin(), canvas.GetTopMargin(), Int32.Parse(dlgInput.getEntrada()), canvas.GetBottomMargin(), true );
			}
		}

		private void mitMargemCima_Click(object sender, System.EventArgs e)
		{
			frmInput dlgInput = new frmInput("graf", "Margem de cima", canvas.GetTopMargin().ToString() );
			if ( dlgInput.ShowDialog() == DialogResult.OK )
			{
				canvas.ClearSelection(false);
				canvas.SetMargins( canvas.GetLeftMargin(), Int32.Parse(dlgInput.getEntrada()), canvas.GetRightMargin(), canvas.GetBottomMargin(), true );
			}
		}

		private void mitMargemBaixo_Click(object sender, System.EventArgs e)
		{
			frmInput dlgInput = new frmInput("graf", "Margem de cima", canvas.GetBottomMargin().ToString() );
			if ( dlgInput.ShowDialog() == DialogResult.OK )
			{
				canvas.ClearSelection(false);
				canvas.SetMargins( canvas.GetLeftMargin(), canvas.GetTopMargin(), canvas.GetRightMargin(), Int32.Parse(dlgInput.getEntrada()), true );
			}
		}

		private void mitSalvarComo_Click(object sender, System.EventArgs e)
		{
			frmInput dlgInput = new frmInput("graf", "Nome relatório", "NOVO_TESTE_RELATORIO" );
			if ( dlgInput.ShowDialog() == DialogResult.OK )
			{
				if ( canvas.bSalvarRelatorioComo( m_nIdExportador, m_nIdTipo,dlgInput.getReportDefault(), dlgInput.getEntrada() ) == false )
					System.Windows.Forms.MessageBox.Show( "Não foi possível salvar o relatório." );		
			}
		}

		private void mitExcluirRel_Click(object sender, System.EventArgs e)
		{
			if ( canvas.bDeleteReport() == false )
				System.Windows.Forms.MessageBox.Show( "Não foi possível excluir o relatório." );
		}

		private void mitViewMode_Click(object sender, System.EventArgs e)
		{
			bool bTroca = !mitViewMode.Checked;
			LimpaFerramentas();
			canvas.CurrentTool = Tool.None;
			canvas.CurrentSubTool = SubTool.None;
			mitViewMode.Checked = bTroca;
			canvas.SetViewMode( bTroca );
		}

		private void mitPrimeira_Click(object sender, System.EventArgs e)
		{
			canvas.bFirstPage();
		}

		private void mitAnterior_Click(object sender, System.EventArgs e)
		{
			canvas.bPreviousPage();
		}

		private void menuItem32_Click(object sender, System.EventArgs e)
		{
			canvas.bNextPage();
		}

		private void mitUltima_Click(object sender, System.EventArgs e)
		{
			canvas.bLastPage();
		}

		private void mirImprimir_Click(object sender, System.EventArgs e)
		{
			canvas.bPrintReport( true );
		}

		private void mirImagem_Click(object sender, System.EventArgs e)
		{
			System.Drawing.Image imgReport = null;
			if (canvas.bReturnPageImage(0,ref imgReport))
			{
				imgReport.Save("C:\\ImagemTeste.jpg");
			}
		}

		private void mitAlinEsq_Click(object sender, System.EventArgs e)
		{
			canvas.bAlignObjects( Alignment.Left, true );
		}

		private void mitAligDireita_Click(object sender, System.EventArgs e)
		{
			canvas.bAlignObjects( Alignment.Right, true );
		}

		private void mitAligCentr_Click(object sender, System.EventArgs e)
		{
			canvas.bAlignObjects( Alignment.Center, true );
		}

		private void mitSelTudo_Click(object sender, System.EventArgs e)
		{
			canvas.bSelectAll( true );
		}

		private void mitHor_Click(object sender, System.EventArgs e)
		{
			canvas.bSetSpacing( Spacing.Horizontal, true );
		}

		private void mitVert_Click(object sender, System.EventArgs e)
		{
			canvas.bSetSpacing( Spacing.Vertical, true );
		}

		private void mitSalvar_Click(object sender, System.EventArgs e)
		{
			frmInput dlgInput = new frmInput("Salvando Imagem", "Path para Salvar o Arquivo", "C:\\foto.bmp" );
			if ( dlgInput.ShowDialog() == DialogResult.OK )
			{
				if (System.IO.File.Exists(dlgInput.getEntrada()))
					System.IO.File.Delete(dlgInput.getEntrada());

				System.Drawing.Image imagem = null;
				if (canvas.bReturnPageImage(canvas.nCurrentPage(),ref imagem))
				{
					imagem.Save(dlgInput.getEntrada());
				}
			}
		}

		private void mitTCB_Click(object sender, System.EventArgs e)
		{
			canvas.bCopyToClipBoard();
		}

		private void mitFCB_Click(object sender, System.EventArgs e)
		{
			canvas.bCopyFromClipBoard();
		}

		private void m_miPDF_Click(object sender, System.EventArgs e)
		{
			frmInput dlgInput = new frmInput("Salvando Imagem", "Path para Salvar o Arquivo", "C:\\manipulador.pdf" );
			if ( dlgInput.ShowDialog() == DialogResult.OK )
			{
				mdlPDF.clsPDF obj = new mdlPDF.clsPDF();
				obj.bAdicionaPagina();
				if (canvas.bReturnPage(canvas.nCurrentPage(),ref obj))
					obj.bSalvar(dlgInput.getEntrada());
			}
		}
		#endregion

		#region IdRelatorio
			private int nRetornaProximoIdRelatorio()
			{
				int nRetorno = 1;
				return(nRetorno);
			}
		#endregion

		#region Events
			private void frmPrincipal_eCallPropertiesBoxObjectTextDB(object sender, EventArgs e)
			{
				canvas.ClearSelection(true);
				int idCampoBD = 199;
				string Texto = "Texto Alinhado DIREITA";
				System.Drawing.Color Cor = System.Drawing.Color.Black;
				System.Drawing.Font fntFonte = new Font("Arial",8);
				bool VisivelImpressao = true;
				bool CallBack = true;
				bool PertenceAreaProdutos = false;
				bool AlinhamentoInferiorAreaProdutos = false;
				int Alinhamento = 2;
				bool ImprimirSomenteUltimaPagina = false;
				int FormatoNumero = 0;
				canvas.DBIdCampo = idCampoBD;
				canvas.TextString = Texto;
				fntFonte = new System.Drawing.Font(fntFonte.Name,(int)fntFonte.Size,fntFonte.Style);

				canvas.TextFont = fntFonte; 
				canvas.TextColor = Cor;
				canvas.ObjectPrintable = VisivelImpressao;
				canvas.ObjetoVisivelImpressao = VisivelImpressao;
				canvas.DBCallBack = CallBack;
				canvas.DBPertenceAreaProdutos = PertenceAreaProdutos;
				canvas.DBAlinhamentoInferiorAreaProdutos = AlinhamentoInferiorAreaProdutos;
				canvas.DBAlinhamento = Alinhamento;
				canvas.DBImprimirSomenteUltimaPagina = ImprimirSomenteUltimaPagina;
				canvas.DBFormatoNumero = FormatoNumero;

				canvas.m_bCancelActualAction = false;

			}
		#endregion
	}
}

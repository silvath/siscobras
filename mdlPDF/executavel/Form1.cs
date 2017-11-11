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

		#region Atributes
			private mdlPDF.clsPDF m_pdfDocumento = new mdlPDF.clsPDF();
			
			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.GroupBox m_gbTexto;
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.Label m_lbArquivo;
			private System.Windows.Forms.TextBox m_txtArquivoSalvar;
			private System.Windows.Forms.Label m_lbTexto;
			private System.Windows.Forms.TextBox m_txtTexto;
			private System.Windows.Forms.TextBox m_txtFonte;
			private System.Windows.Forms.Label m_lbFonte;
			private System.Windows.Forms.TextBox m_txtFonteTamanho;
			private System.Windows.Forms.Label m_lbFonteTamanho;
			private System.Windows.Forms.GroupBox m_gbLinha;
			private System.Windows.Forms.Label m_lbLinhaX1;
			private System.Windows.Forms.Button m_btSalvar;
			private System.Windows.Forms.Button m_btPaginaNova;
		private System.Windows.Forms.Button m_btTextoInsere;
		private System.Windows.Forms.TextBox m_txtLinhaX1;
		private System.Windows.Forms.TextBox m_txtLinhaY1;
		private System.Windows.Forms.Label m_lbLinhaY1;
		private System.Windows.Forms.TextBox m_txtLinhaY2;
		private System.Windows.Forms.Label m_lbLinhaY2;
		private System.Windows.Forms.TextBox m_txtLinhaX2;
		private System.Windows.Forms.Label m_lbLinhaX2;
		private System.Windows.Forms.Button m_btLinhaInsere;
		private System.Windows.Forms.GroupBox m_gbRetangulo;
		private System.Windows.Forms.Button m_btRetanguloInsere;
		private System.Windows.Forms.TextBox m_txtRetanguloY2;
		private System.Windows.Forms.Label m_lbRetanguloY2;
		private System.Windows.Forms.TextBox m_txtRetanguloX2;
		private System.Windows.Forms.Label m_lbRetanguloX2;
		private System.Windows.Forms.TextBox m_txtRetanguloY1;
		private System.Windows.Forms.Label m_lbRetanguloY1;
		private System.Windows.Forms.TextBox m_txtRetanguloX1;
		private System.Windows.Forms.Label m_lbRetanguloX1;
		private System.Windows.Forms.TextBox m_txtTextoY1;
		private System.Windows.Forms.Label m_lbTextoY1;
		private System.Windows.Forms.TextBox m_txtTextoX1;
		private System.Windows.Forms.Label m_lbTextoX1;
		private System.Windows.Forms.GroupBox m_gbImagem;
		private System.Windows.Forms.TextBox m_txtImagemY1;
		private System.Windows.Forms.Label m_lbImagemY1;
		private System.Windows.Forms.TextBox m_txtImagemX1;
		private System.Windows.Forms.Label m_lbImagemX1;
		private System.Windows.Forms.Button m_btImagemInsere;
		private System.Windows.Forms.TextBox m_txtImagemArquivo;
		private System.Windows.Forms.Label m_lbImagemArquivo;
		private System.Windows.Forms.Button m_btRelatorio;
		private System.Windows.Forms.GroupBox m_gbCirculo;
		private System.Windows.Forms.TextBox m_txtCirculoHeight;
		private System.Windows.Forms.Label m_lbCirculoHeight;
		private System.Windows.Forms.TextBox m_txtCirculoWidth;
		private System.Windows.Forms.Label m_lbCirculoWidth;
		private System.Windows.Forms.TextBox m_txtCirculoY1;
		private System.Windows.Forms.Label m_lbCirculoY1;
		private System.Windows.Forms.TextBox m_txtCirculoX1;
		private System.Windows.Forms.Label m_lbCirculoX1;
		private System.Windows.Forms.Button m_btCirculoInsere;
		private System.Windows.Forms.Button m_btAbrir;
		private System.Windows.Forms.GroupBox m_gbMarcadores;
		private System.Windows.Forms.TextBox m_txtMarcadoresPagina;
		private System.Windows.Forms.Label m_lbMarcadoresPagina;
		private System.Windows.Forms.Button m_btMarcadoresInsere;
		private System.Windows.Forms.TextBox m_txtMarcadoresTitulo;
		private System.Windows.Forms.Label m_lbMarcadoresTitulo;
		private System.Windows.Forms.Button m_btMarcadoresInserePagina;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public Form1()
			{
				InitializeComponent();
				m_pdfDocumento.bAdicionaPagina();
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
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbMarcadores = new System.Windows.Forms.GroupBox();
			this.m_btMarcadoresInserePagina = new System.Windows.Forms.Button();
			this.m_txtMarcadoresPagina = new System.Windows.Forms.TextBox();
			this.m_lbMarcadoresPagina = new System.Windows.Forms.Label();
			this.m_btMarcadoresInsere = new System.Windows.Forms.Button();
			this.m_txtMarcadoresTitulo = new System.Windows.Forms.TextBox();
			this.m_lbMarcadoresTitulo = new System.Windows.Forms.Label();
			this.m_gbCirculo = new System.Windows.Forms.GroupBox();
			this.m_btCirculoInsere = new System.Windows.Forms.Button();
			this.m_txtCirculoHeight = new System.Windows.Forms.TextBox();
			this.m_lbCirculoHeight = new System.Windows.Forms.Label();
			this.m_txtCirculoWidth = new System.Windows.Forms.TextBox();
			this.m_lbCirculoWidth = new System.Windows.Forms.Label();
			this.m_txtCirculoY1 = new System.Windows.Forms.TextBox();
			this.m_lbCirculoY1 = new System.Windows.Forms.Label();
			this.m_txtCirculoX1 = new System.Windows.Forms.TextBox();
			this.m_lbCirculoX1 = new System.Windows.Forms.Label();
			this.m_gbImagem = new System.Windows.Forms.GroupBox();
			this.m_txtImagemY1 = new System.Windows.Forms.TextBox();
			this.m_lbImagemY1 = new System.Windows.Forms.Label();
			this.m_txtImagemX1 = new System.Windows.Forms.TextBox();
			this.m_lbImagemX1 = new System.Windows.Forms.Label();
			this.m_btImagemInsere = new System.Windows.Forms.Button();
			this.m_txtImagemArquivo = new System.Windows.Forms.TextBox();
			this.m_lbImagemArquivo = new System.Windows.Forms.Label();
			this.m_gbRetangulo = new System.Windows.Forms.GroupBox();
			this.m_btRetanguloInsere = new System.Windows.Forms.Button();
			this.m_txtRetanguloY2 = new System.Windows.Forms.TextBox();
			this.m_lbRetanguloY2 = new System.Windows.Forms.Label();
			this.m_txtRetanguloX2 = new System.Windows.Forms.TextBox();
			this.m_lbRetanguloX2 = new System.Windows.Forms.Label();
			this.m_txtRetanguloY1 = new System.Windows.Forms.TextBox();
			this.m_lbRetanguloY1 = new System.Windows.Forms.Label();
			this.m_txtRetanguloX1 = new System.Windows.Forms.TextBox();
			this.m_lbRetanguloX1 = new System.Windows.Forms.Label();
			this.m_gbLinha = new System.Windows.Forms.GroupBox();
			this.m_btLinhaInsere = new System.Windows.Forms.Button();
			this.m_txtLinhaY2 = new System.Windows.Forms.TextBox();
			this.m_lbLinhaY2 = new System.Windows.Forms.Label();
			this.m_txtLinhaX2 = new System.Windows.Forms.TextBox();
			this.m_lbLinhaX2 = new System.Windows.Forms.Label();
			this.m_txtLinhaY1 = new System.Windows.Forms.TextBox();
			this.m_lbLinhaY1 = new System.Windows.Forms.Label();
			this.m_txtLinhaX1 = new System.Windows.Forms.TextBox();
			this.m_lbLinhaX1 = new System.Windows.Forms.Label();
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btAbrir = new System.Windows.Forms.Button();
			this.m_btRelatorio = new System.Windows.Forms.Button();
			this.m_btPaginaNova = new System.Windows.Forms.Button();
			this.m_btSalvar = new System.Windows.Forms.Button();
			this.m_txtArquivoSalvar = new System.Windows.Forms.TextBox();
			this.m_lbArquivo = new System.Windows.Forms.Label();
			this.m_gbTexto = new System.Windows.Forms.GroupBox();
			this.m_txtTextoY1 = new System.Windows.Forms.TextBox();
			this.m_lbTextoY1 = new System.Windows.Forms.Label();
			this.m_txtTextoX1 = new System.Windows.Forms.TextBox();
			this.m_lbTextoX1 = new System.Windows.Forms.Label();
			this.m_btTextoInsere = new System.Windows.Forms.Button();
			this.m_txtFonteTamanho = new System.Windows.Forms.TextBox();
			this.m_lbFonteTamanho = new System.Windows.Forms.Label();
			this.m_txtFonte = new System.Windows.Forms.TextBox();
			this.m_lbFonte = new System.Windows.Forms.Label();
			this.m_txtTexto = new System.Windows.Forms.TextBox();
			this.m_lbTexto = new System.Windows.Forms.Label();
			this.m_gbMain.SuspendLayout();
			this.m_gbMarcadores.SuspendLayout();
			this.m_gbCirculo.SuspendLayout();
			this.m_gbImagem.SuspendLayout();
			this.m_gbRetangulo.SuspendLayout();
			this.m_gbLinha.SuspendLayout();
			this.m_gbGeral.SuspendLayout();
			this.m_gbTexto.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbMarcadores);
			this.m_gbMain.Controls.Add(this.m_gbCirculo);
			this.m_gbMain.Controls.Add(this.m_gbImagem);
			this.m_gbMain.Controls.Add(this.m_gbRetangulo);
			this.m_gbMain.Controls.Add(this.m_gbLinha);
			this.m_gbMain.Controls.Add(this.m_gbGeral);
			this.m_gbMain.Controls.Add(this.m_gbTexto);
			this.m_gbMain.Location = new System.Drawing.Point(3, -3);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(460, 480);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbMarcadores
			// 
			this.m_gbMarcadores.Controls.Add(this.m_btMarcadoresInserePagina);
			this.m_gbMarcadores.Controls.Add(this.m_txtMarcadoresPagina);
			this.m_gbMarcadores.Controls.Add(this.m_lbMarcadoresPagina);
			this.m_gbMarcadores.Controls.Add(this.m_btMarcadoresInsere);
			this.m_gbMarcadores.Controls.Add(this.m_txtMarcadoresTitulo);
			this.m_gbMarcadores.Controls.Add(this.m_lbMarcadoresTitulo);
			this.m_gbMarcadores.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMarcadores.Location = new System.Drawing.Point(5, 403);
			this.m_gbMarcadores.Name = "m_gbMarcadores";
			this.m_gbMarcadores.Size = new System.Drawing.Size(450, 69);
			this.m_gbMarcadores.TabIndex = 6;
			this.m_gbMarcadores.TabStop = false;
			this.m_gbMarcadores.Text = "Marcadores";
			// 
			// m_btMarcadoresInserePagina
			// 
			this.m_btMarcadoresInserePagina.Location = new System.Drawing.Point(233, 36);
			this.m_btMarcadoresInserePagina.Name = "m_btMarcadoresInserePagina";
			this.m_btMarcadoresInserePagina.Size = new System.Drawing.Size(104, 24);
			this.m_btMarcadoresInserePagina.TabIndex = 13;
			this.m_btMarcadoresInserePagina.Text = "Insere P";
			this.m_btMarcadoresInserePagina.Click += new System.EventHandler(this.m_btMarcadoresInserePagina_Click);
			// 
			// m_txtMarcadoresPagina
			// 
			this.m_txtMarcadoresPagina.Location = new System.Drawing.Point(55, 36);
			this.m_txtMarcadoresPagina.Name = "m_txtMarcadoresPagina";
			this.m_txtMarcadoresPagina.Size = new System.Drawing.Size(32, 20);
			this.m_txtMarcadoresPagina.TabIndex = 12;
			this.m_txtMarcadoresPagina.Text = "1";
			this.m_txtMarcadoresPagina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbMarcadoresPagina
			// 
			this.m_lbMarcadoresPagina.Location = new System.Drawing.Point(10, 40);
			this.m_lbMarcadoresPagina.Name = "m_lbMarcadoresPagina";
			this.m_lbMarcadoresPagina.Size = new System.Drawing.Size(46, 16);
			this.m_lbMarcadoresPagina.TabIndex = 11;
			this.m_lbMarcadoresPagina.Text = "P醙ina:";
			// 
			// m_btMarcadoresInsere
			// 
			this.m_btMarcadoresInsere.Location = new System.Drawing.Point(340, 36);
			this.m_btMarcadoresInsere.Name = "m_btMarcadoresInsere";
			this.m_btMarcadoresInsere.Size = new System.Drawing.Size(104, 24);
			this.m_btMarcadoresInsere.TabIndex = 8;
			this.m_btMarcadoresInsere.Text = "Insere";
			this.m_btMarcadoresInsere.Click += new System.EventHandler(this.m_btMarcadoresInsere_Click);
			// 
			// m_txtMarcadoresTitulo
			// 
			this.m_txtMarcadoresTitulo.Location = new System.Drawing.Point(48, 13);
			this.m_txtMarcadoresTitulo.Name = "m_txtMarcadoresTitulo";
			this.m_txtMarcadoresTitulo.Size = new System.Drawing.Size(392, 20);
			this.m_txtMarcadoresTitulo.TabIndex = 3;
			this.m_txtMarcadoresTitulo.Text = "标准中文, 第一级, 第一册";
			// 
			// m_lbMarcadoresTitulo
			// 
			this.m_lbMarcadoresTitulo.Location = new System.Drawing.Point(7, 17);
			this.m_lbMarcadoresTitulo.Name = "m_lbMarcadoresTitulo";
			this.m_lbMarcadoresTitulo.Size = new System.Drawing.Size(41, 16);
			this.m_lbMarcadoresTitulo.TabIndex = 2;
			this.m_lbMarcadoresTitulo.Text = "Titulo:";
			// 
			// m_gbCirculo
			// 
			this.m_gbCirculo.Controls.Add(this.m_btCirculoInsere);
			this.m_gbCirculo.Controls.Add(this.m_txtCirculoHeight);
			this.m_gbCirculo.Controls.Add(this.m_lbCirculoHeight);
			this.m_gbCirculo.Controls.Add(this.m_txtCirculoWidth);
			this.m_gbCirculo.Controls.Add(this.m_lbCirculoWidth);
			this.m_gbCirculo.Controls.Add(this.m_txtCirculoY1);
			this.m_gbCirculo.Controls.Add(this.m_lbCirculoY1);
			this.m_gbCirculo.Controls.Add(this.m_txtCirculoX1);
			this.m_gbCirculo.Controls.Add(this.m_lbCirculoX1);
			this.m_gbCirculo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbCirculo.Location = new System.Drawing.Point(5, 192);
			this.m_gbCirculo.Name = "m_gbCirculo";
			this.m_gbCirculo.Size = new System.Drawing.Size(450, 40);
			this.m_gbCirculo.TabIndex = 5;
			this.m_gbCirculo.TabStop = false;
			this.m_gbCirculo.Text = "Circulo";
			// 
			// m_btCirculoInsere
			// 
			this.m_btCirculoInsere.Location = new System.Drawing.Point(341, 11);
			this.m_btCirculoInsere.Name = "m_btCirculoInsere";
			this.m_btCirculoInsere.Size = new System.Drawing.Size(104, 24);
			this.m_btCirculoInsere.TabIndex = 15;
			this.m_btCirculoInsere.Text = "Insere";
			this.m_btCirculoInsere.Click += new System.EventHandler(this.m_btCirculoInsere_Click);
			// 
			// m_txtCirculoHeight
			// 
			this.m_txtCirculoHeight.Location = new System.Drawing.Point(272, 13);
			this.m_txtCirculoHeight.Name = "m_txtCirculoHeight";
			this.m_txtCirculoHeight.Size = new System.Drawing.Size(32, 20);
			this.m_txtCirculoHeight.TabIndex = 14;
			this.m_txtCirculoHeight.Text = "30";
			this.m_txtCirculoHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbCirculoHeight
			// 
			this.m_lbCirculoHeight.Location = new System.Drawing.Point(216, 16);
			this.m_lbCirculoHeight.Name = "m_lbCirculoHeight";
			this.m_lbCirculoHeight.Size = new System.Drawing.Size(40, 16);
			this.m_lbCirculoHeight.TabIndex = 13;
			this.m_lbCirculoHeight.Text = "Height";
			// 
			// m_txtCirculoWidth
			// 
			this.m_txtCirculoWidth.Location = new System.Drawing.Point(174, 13);
			this.m_txtCirculoWidth.Name = "m_txtCirculoWidth";
			this.m_txtCirculoWidth.Size = new System.Drawing.Size(32, 20);
			this.m_txtCirculoWidth.TabIndex = 12;
			this.m_txtCirculoWidth.Text = "30";
			this.m_txtCirculoWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbCirculoWidth
			// 
			this.m_lbCirculoWidth.Location = new System.Drawing.Point(136, 16);
			this.m_lbCirculoWidth.Name = "m_lbCirculoWidth";
			this.m_lbCirculoWidth.Size = new System.Drawing.Size(40, 16);
			this.m_lbCirculoWidth.TabIndex = 11;
			this.m_lbCirculoWidth.Text = "Width";
			// 
			// m_txtCirculoY1
			// 
			this.m_txtCirculoY1.Location = new System.Drawing.Point(95, 13);
			this.m_txtCirculoY1.Name = "m_txtCirculoY1";
			this.m_txtCirculoY1.Size = new System.Drawing.Size(32, 20);
			this.m_txtCirculoY1.TabIndex = 10;
			this.m_txtCirculoY1.Text = "80";
			this.m_txtCirculoY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbCirculoY1
			// 
			this.m_lbCirculoY1.Location = new System.Drawing.Point(71, 16);
			this.m_lbCirculoY1.Name = "m_lbCirculoY1";
			this.m_lbCirculoY1.Size = new System.Drawing.Size(24, 16);
			this.m_lbCirculoY1.TabIndex = 9;
			this.m_lbCirculoY1.Text = "Y1:";
			// 
			// m_txtCirculoX1
			// 
			this.m_txtCirculoX1.Location = new System.Drawing.Point(32, 13);
			this.m_txtCirculoX1.Name = "m_txtCirculoX1";
			this.m_txtCirculoX1.Size = new System.Drawing.Size(32, 20);
			this.m_txtCirculoX1.TabIndex = 8;
			this.m_txtCirculoX1.Text = "30";
			this.m_txtCirculoX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbCirculoX1
			// 
			this.m_lbCirculoX1.Location = new System.Drawing.Point(8, 16);
			this.m_lbCirculoX1.Name = "m_lbCirculoX1";
			this.m_lbCirculoX1.Size = new System.Drawing.Size(24, 16);
			this.m_lbCirculoX1.TabIndex = 0;
			this.m_lbCirculoX1.Text = "X1:";
			// 
			// m_gbImagem
			// 
			this.m_gbImagem.Controls.Add(this.m_txtImagemY1);
			this.m_gbImagem.Controls.Add(this.m_lbImagemY1);
			this.m_gbImagem.Controls.Add(this.m_txtImagemX1);
			this.m_gbImagem.Controls.Add(this.m_lbImagemX1);
			this.m_gbImagem.Controls.Add(this.m_btImagemInsere);
			this.m_gbImagem.Controls.Add(this.m_txtImagemArquivo);
			this.m_gbImagem.Controls.Add(this.m_lbImagemArquivo);
			this.m_gbImagem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbImagem.Location = new System.Drawing.Point(5, 336);
			this.m_gbImagem.Name = "m_gbImagem";
			this.m_gbImagem.Size = new System.Drawing.Size(450, 65);
			this.m_gbImagem.TabIndex = 4;
			this.m_gbImagem.TabStop = false;
			this.m_gbImagem.Text = "Imagem";
			// 
			// m_txtImagemY1
			// 
			this.m_txtImagemY1.Location = new System.Drawing.Point(96, 36);
			this.m_txtImagemY1.Name = "m_txtImagemY1";
			this.m_txtImagemY1.Size = new System.Drawing.Size(32, 20);
			this.m_txtImagemY1.TabIndex = 14;
			this.m_txtImagemY1.Text = "10";
			this.m_txtImagemY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbImagemY1
			// 
			this.m_lbImagemY1.Location = new System.Drawing.Point(72, 40);
			this.m_lbImagemY1.Name = "m_lbImagemY1";
			this.m_lbImagemY1.Size = new System.Drawing.Size(24, 16);
			this.m_lbImagemY1.TabIndex = 13;
			this.m_lbImagemY1.Text = "Y1:";
			// 
			// m_txtImagemX1
			// 
			this.m_txtImagemX1.Location = new System.Drawing.Point(33, 36);
			this.m_txtImagemX1.Name = "m_txtImagemX1";
			this.m_txtImagemX1.Size = new System.Drawing.Size(32, 20);
			this.m_txtImagemX1.TabIndex = 12;
			this.m_txtImagemX1.Text = "10";
			this.m_txtImagemX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbImagemX1
			// 
			this.m_lbImagemX1.Location = new System.Drawing.Point(10, 40);
			this.m_lbImagemX1.Name = "m_lbImagemX1";
			this.m_lbImagemX1.Size = new System.Drawing.Size(24, 16);
			this.m_lbImagemX1.TabIndex = 11;
			this.m_lbImagemX1.Text = "X1:";
			// 
			// m_btImagemInsere
			// 
			this.m_btImagemInsere.Location = new System.Drawing.Point(340, 36);
			this.m_btImagemInsere.Name = "m_btImagemInsere";
			this.m_btImagemInsere.Size = new System.Drawing.Size(104, 24);
			this.m_btImagemInsere.TabIndex = 8;
			this.m_btImagemInsere.Text = "Insere";
			this.m_btImagemInsere.Click += new System.EventHandler(this.m_btImagemInsere_Click);
			// 
			// m_txtImagemArquivo
			// 
			this.m_txtImagemArquivo.Location = new System.Drawing.Point(64, 13);
			this.m_txtImagemArquivo.Name = "m_txtImagemArquivo";
			this.m_txtImagemArquivo.Size = new System.Drawing.Size(376, 20);
			this.m_txtImagemArquivo.TabIndex = 3;
			this.m_txtImagemArquivo.Text = "C:\\imagem.bmp";
			// 
			// m_lbImagemArquivo
			// 
			this.m_lbImagemArquivo.Location = new System.Drawing.Point(7, 17);
			this.m_lbImagemArquivo.Name = "m_lbImagemArquivo";
			this.m_lbImagemArquivo.Size = new System.Drawing.Size(57, 16);
			this.m_lbImagemArquivo.TabIndex = 2;
			this.m_lbImagemArquivo.Text = "Arquivo:";
			// 
			// m_gbRetangulo
			// 
			this.m_gbRetangulo.Controls.Add(this.m_btRetanguloInsere);
			this.m_gbRetangulo.Controls.Add(this.m_txtRetanguloY2);
			this.m_gbRetangulo.Controls.Add(this.m_lbRetanguloY2);
			this.m_gbRetangulo.Controls.Add(this.m_txtRetanguloX2);
			this.m_gbRetangulo.Controls.Add(this.m_lbRetanguloX2);
			this.m_gbRetangulo.Controls.Add(this.m_txtRetanguloY1);
			this.m_gbRetangulo.Controls.Add(this.m_lbRetanguloY1);
			this.m_gbRetangulo.Controls.Add(this.m_txtRetanguloX1);
			this.m_gbRetangulo.Controls.Add(this.m_lbRetanguloX1);
			this.m_gbRetangulo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbRetangulo.Location = new System.Drawing.Point(5, 152);
			this.m_gbRetangulo.Name = "m_gbRetangulo";
			this.m_gbRetangulo.Size = new System.Drawing.Size(450, 40);
			this.m_gbRetangulo.TabIndex = 3;
			this.m_gbRetangulo.TabStop = false;
			this.m_gbRetangulo.Text = "Retangulo";
			// 
			// m_btRetanguloInsere
			// 
			this.m_btRetanguloInsere.Location = new System.Drawing.Point(341, 11);
			this.m_btRetanguloInsere.Name = "m_btRetanguloInsere";
			this.m_btRetanguloInsere.Size = new System.Drawing.Size(104, 24);
			this.m_btRetanguloInsere.TabIndex = 15;
			this.m_btRetanguloInsere.Text = "Insere";
			this.m_btRetanguloInsere.Click += new System.EventHandler(this.m_btRetanguloInsere_Click);
			// 
			// m_txtRetanguloY2
			// 
			this.m_txtRetanguloY2.Location = new System.Drawing.Point(240, 13);
			this.m_txtRetanguloY2.Name = "m_txtRetanguloY2";
			this.m_txtRetanguloY2.Size = new System.Drawing.Size(32, 20);
			this.m_txtRetanguloY2.TabIndex = 14;
			this.m_txtRetanguloY2.Text = "20";
			this.m_txtRetanguloY2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbRetanguloY2
			// 
			this.m_lbRetanguloY2.Location = new System.Drawing.Point(216, 16);
			this.m_lbRetanguloY2.Name = "m_lbRetanguloY2";
			this.m_lbRetanguloY2.Size = new System.Drawing.Size(24, 16);
			this.m_lbRetanguloY2.TabIndex = 13;
			this.m_lbRetanguloY2.Text = "Y1:";
			// 
			// m_txtRetanguloX2
			// 
			this.m_txtRetanguloX2.Location = new System.Drawing.Point(174, 13);
			this.m_txtRetanguloX2.Name = "m_txtRetanguloX2";
			this.m_txtRetanguloX2.Size = new System.Drawing.Size(32, 20);
			this.m_txtRetanguloX2.TabIndex = 12;
			this.m_txtRetanguloX2.Text = "20";
			this.m_txtRetanguloX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbRetanguloX2
			// 
			this.m_lbRetanguloX2.Location = new System.Drawing.Point(152, 16);
			this.m_lbRetanguloX2.Name = "m_lbRetanguloX2";
			this.m_lbRetanguloX2.Size = new System.Drawing.Size(24, 16);
			this.m_lbRetanguloX2.TabIndex = 11;
			this.m_lbRetanguloX2.Text = "X2:";
			// 
			// m_txtRetanguloY1
			// 
			this.m_txtRetanguloY1.Location = new System.Drawing.Point(95, 13);
			this.m_txtRetanguloY1.Name = "m_txtRetanguloY1";
			this.m_txtRetanguloY1.Size = new System.Drawing.Size(32, 20);
			this.m_txtRetanguloY1.TabIndex = 10;
			this.m_txtRetanguloY1.Text = "30";
			this.m_txtRetanguloY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbRetanguloY1
			// 
			this.m_lbRetanguloY1.Location = new System.Drawing.Point(71, 16);
			this.m_lbRetanguloY1.Name = "m_lbRetanguloY1";
			this.m_lbRetanguloY1.Size = new System.Drawing.Size(24, 16);
			this.m_lbRetanguloY1.TabIndex = 9;
			this.m_lbRetanguloY1.Text = "Y1:";
			// 
			// m_txtRetanguloX1
			// 
			this.m_txtRetanguloX1.Location = new System.Drawing.Point(32, 13);
			this.m_txtRetanguloX1.Name = "m_txtRetanguloX1";
			this.m_txtRetanguloX1.Size = new System.Drawing.Size(32, 20);
			this.m_txtRetanguloX1.TabIndex = 8;
			this.m_txtRetanguloX1.Text = "30";
			this.m_txtRetanguloX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbRetanguloX1
			// 
			this.m_lbRetanguloX1.Location = new System.Drawing.Point(8, 16);
			this.m_lbRetanguloX1.Name = "m_lbRetanguloX1";
			this.m_lbRetanguloX1.Size = new System.Drawing.Size(24, 16);
			this.m_lbRetanguloX1.TabIndex = 0;
			this.m_lbRetanguloX1.Text = "X1:";
			// 
			// m_gbLinha
			// 
			this.m_gbLinha.Controls.Add(this.m_btLinhaInsere);
			this.m_gbLinha.Controls.Add(this.m_txtLinhaY2);
			this.m_gbLinha.Controls.Add(this.m_lbLinhaY2);
			this.m_gbLinha.Controls.Add(this.m_txtLinhaX2);
			this.m_gbLinha.Controls.Add(this.m_lbLinhaX2);
			this.m_gbLinha.Controls.Add(this.m_txtLinhaY1);
			this.m_gbLinha.Controls.Add(this.m_lbLinhaY1);
			this.m_gbLinha.Controls.Add(this.m_txtLinhaX1);
			this.m_gbLinha.Controls.Add(this.m_lbLinhaX1);
			this.m_gbLinha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbLinha.Location = new System.Drawing.Point(6, 112);
			this.m_gbLinha.Name = "m_gbLinha";
			this.m_gbLinha.Size = new System.Drawing.Size(450, 40);
			this.m_gbLinha.TabIndex = 2;
			this.m_gbLinha.TabStop = false;
			this.m_gbLinha.Text = "Linha";
			// 
			// m_btLinhaInsere
			// 
			this.m_btLinhaInsere.Location = new System.Drawing.Point(341, 11);
			this.m_btLinhaInsere.Name = "m_btLinhaInsere";
			this.m_btLinhaInsere.Size = new System.Drawing.Size(104, 24);
			this.m_btLinhaInsere.TabIndex = 15;
			this.m_btLinhaInsere.Text = "Insere";
			this.m_btLinhaInsere.Click += new System.EventHandler(this.m_btLinhaInsere_Click);
			// 
			// m_txtLinhaY2
			// 
			this.m_txtLinhaY2.Location = new System.Drawing.Point(240, 13);
			this.m_txtLinhaY2.Name = "m_txtLinhaY2";
			this.m_txtLinhaY2.Size = new System.Drawing.Size(32, 20);
			this.m_txtLinhaY2.TabIndex = 14;
			this.m_txtLinhaY2.Text = "30";
			this.m_txtLinhaY2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbLinhaY2
			// 
			this.m_lbLinhaY2.Location = new System.Drawing.Point(216, 16);
			this.m_lbLinhaY2.Name = "m_lbLinhaY2";
			this.m_lbLinhaY2.Size = new System.Drawing.Size(24, 16);
			this.m_lbLinhaY2.TabIndex = 13;
			this.m_lbLinhaY2.Text = "Y1:";
			// 
			// m_txtLinhaX2
			// 
			this.m_txtLinhaX2.Location = new System.Drawing.Point(174, 13);
			this.m_txtLinhaX2.Name = "m_txtLinhaX2";
			this.m_txtLinhaX2.Size = new System.Drawing.Size(32, 20);
			this.m_txtLinhaX2.TabIndex = 12;
			this.m_txtLinhaX2.Text = "0";
			this.m_txtLinhaX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbLinhaX2
			// 
			this.m_lbLinhaX2.Location = new System.Drawing.Point(152, 16);
			this.m_lbLinhaX2.Name = "m_lbLinhaX2";
			this.m_lbLinhaX2.Size = new System.Drawing.Size(24, 16);
			this.m_lbLinhaX2.TabIndex = 11;
			this.m_lbLinhaX2.Text = "X2:";
			// 
			// m_txtLinhaY1
			// 
			this.m_txtLinhaY1.Location = new System.Drawing.Point(95, 13);
			this.m_txtLinhaY1.Name = "m_txtLinhaY1";
			this.m_txtLinhaY1.Size = new System.Drawing.Size(32, 20);
			this.m_txtLinhaY1.TabIndex = 10;
			this.m_txtLinhaY1.Text = "0";
			this.m_txtLinhaY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbLinhaY1
			// 
			this.m_lbLinhaY1.Location = new System.Drawing.Point(71, 16);
			this.m_lbLinhaY1.Name = "m_lbLinhaY1";
			this.m_lbLinhaY1.Size = new System.Drawing.Size(24, 16);
			this.m_lbLinhaY1.TabIndex = 9;
			this.m_lbLinhaY1.Text = "Y1:";
			// 
			// m_txtLinhaX1
			// 
			this.m_txtLinhaX1.Location = new System.Drawing.Point(32, 13);
			this.m_txtLinhaX1.Name = "m_txtLinhaX1";
			this.m_txtLinhaX1.Size = new System.Drawing.Size(32, 20);
			this.m_txtLinhaX1.TabIndex = 8;
			this.m_txtLinhaX1.Text = "0";
			this.m_txtLinhaX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbLinhaX1
			// 
			this.m_lbLinhaX1.Location = new System.Drawing.Point(8, 16);
			this.m_lbLinhaX1.Name = "m_lbLinhaX1";
			this.m_lbLinhaX1.Size = new System.Drawing.Size(24, 16);
			this.m_lbLinhaX1.TabIndex = 0;
			this.m_lbLinhaX1.Text = "X1:";
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_btAbrir);
			this.m_gbGeral.Controls.Add(this.m_btRelatorio);
			this.m_gbGeral.Controls.Add(this.m_btPaginaNova);
			this.m_gbGeral.Controls.Add(this.m_btSalvar);
			this.m_gbGeral.Controls.Add(this.m_txtArquivoSalvar);
			this.m_gbGeral.Controls.Add(this.m_lbArquivo);
			this.m_gbGeral.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbGeral.Location = new System.Drawing.Point(6, 11);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(450, 85);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			this.m_gbGeral.Text = "Geral";
			// 
			// m_btAbrir
			// 
			this.m_btAbrir.Location = new System.Drawing.Point(356, 40);
			this.m_btAbrir.Name = "m_btAbrir";
			this.m_btAbrir.Size = new System.Drawing.Size(56, 32);
			this.m_btAbrir.TabIndex = 6;
			this.m_btAbrir.Text = "Abrir";
			this.m_btAbrir.Click += new System.EventHandler(this.m_btAbrir_Click);
			// 
			// m_btRelatorio
			// 
			this.m_btRelatorio.Location = new System.Drawing.Point(232, 40);
			this.m_btRelatorio.Name = "m_btRelatorio";
			this.m_btRelatorio.Size = new System.Drawing.Size(64, 32);
			this.m_btRelatorio.TabIndex = 5;
			this.m_btRelatorio.Text = "Relat髍io";
			this.m_btRelatorio.Click += new System.EventHandler(this.m_btRelatorio_Click);
			// 
			// m_btPaginaNova
			// 
			this.m_btPaginaNova.Location = new System.Drawing.Point(8, 40);
			this.m_btPaginaNova.Name = "m_btPaginaNova";
			this.m_btPaginaNova.Size = new System.Drawing.Size(56, 32);
			this.m_btPaginaNova.TabIndex = 4;
			this.m_btPaginaNova.Text = "Nova P醙ina";
			this.m_btPaginaNova.Click += new System.EventHandler(this.m_btPaginaNova_Click);
			// 
			// m_btSalvar
			// 
			this.m_btSalvar.Location = new System.Drawing.Point(298, 40);
			this.m_btSalvar.Name = "m_btSalvar";
			this.m_btSalvar.Size = new System.Drawing.Size(56, 32);
			this.m_btSalvar.TabIndex = 2;
			this.m_btSalvar.Text = "Salvar";
			this.m_btSalvar.Click += new System.EventHandler(this.m_btSalvar_Click);
			// 
			// m_txtArquivoSalvar
			// 
			this.m_txtArquivoSalvar.Location = new System.Drawing.Point(104, 15);
			this.m_txtArquivoSalvar.Name = "m_txtArquivoSalvar";
			this.m_txtArquivoSalvar.Size = new System.Drawing.Size(328, 20);
			this.m_txtArquivoSalvar.TabIndex = 1;
			this.m_txtArquivoSalvar.Text = "C:\\mdlPDF.pdf";
			// 
			// m_lbArquivo
			// 
			this.m_lbArquivo.Location = new System.Drawing.Point(8, 15);
			this.m_lbArquivo.Name = "m_lbArquivo";
			this.m_lbArquivo.Size = new System.Drawing.Size(96, 16);
			this.m_lbArquivo.TabIndex = 0;
			this.m_lbArquivo.Text = "Arquivo Salvar :";
			// 
			// m_gbTexto
			// 
			this.m_gbTexto.Controls.Add(this.m_txtTextoY1);
			this.m_gbTexto.Controls.Add(this.m_lbTextoY1);
			this.m_gbTexto.Controls.Add(this.m_txtTextoX1);
			this.m_gbTexto.Controls.Add(this.m_lbTextoX1);
			this.m_gbTexto.Controls.Add(this.m_btTextoInsere);
			this.m_gbTexto.Controls.Add(this.m_txtFonteTamanho);
			this.m_gbTexto.Controls.Add(this.m_lbFonteTamanho);
			this.m_gbTexto.Controls.Add(this.m_txtFonte);
			this.m_gbTexto.Controls.Add(this.m_lbFonte);
			this.m_gbTexto.Controls.Add(this.m_txtTexto);
			this.m_gbTexto.Controls.Add(this.m_lbTexto);
			this.m_gbTexto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbTexto.Location = new System.Drawing.Point(6, 248);
			this.m_gbTexto.Name = "m_gbTexto";
			this.m_gbTexto.Size = new System.Drawing.Size(450, 89);
			this.m_gbTexto.TabIndex = 0;
			this.m_gbTexto.TabStop = false;
			this.m_gbTexto.Text = "Texto";
			// 
			// m_txtTextoY1
			// 
			this.m_txtTextoY1.Location = new System.Drawing.Point(96, 60);
			this.m_txtTextoY1.Name = "m_txtTextoY1";
			this.m_txtTextoY1.Size = new System.Drawing.Size(32, 20);
			this.m_txtTextoY1.TabIndex = 14;
			this.m_txtTextoY1.Text = "20";
			this.m_txtTextoY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbTextoY1
			// 
			this.m_lbTextoY1.Location = new System.Drawing.Point(72, 64);
			this.m_lbTextoY1.Name = "m_lbTextoY1";
			this.m_lbTextoY1.Size = new System.Drawing.Size(24, 16);
			this.m_lbTextoY1.TabIndex = 13;
			this.m_lbTextoY1.Text = "Y1:";
			// 
			// m_txtTextoX1
			// 
			this.m_txtTextoX1.Location = new System.Drawing.Point(33, 60);
			this.m_txtTextoX1.Name = "m_txtTextoX1";
			this.m_txtTextoX1.Size = new System.Drawing.Size(32, 20);
			this.m_txtTextoX1.TabIndex = 12;
			this.m_txtTextoX1.Text = "20";
			this.m_txtTextoX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbTextoX1
			// 
			this.m_lbTextoX1.Location = new System.Drawing.Point(10, 63);
			this.m_lbTextoX1.Name = "m_lbTextoX1";
			this.m_lbTextoX1.Size = new System.Drawing.Size(24, 16);
			this.m_lbTextoX1.TabIndex = 11;
			this.m_lbTextoX1.Text = "X1:";
			// 
			// m_btTextoInsere
			// 
			this.m_btTextoInsere.Location = new System.Drawing.Point(340, 36);
			this.m_btTextoInsere.Name = "m_btTextoInsere";
			this.m_btTextoInsere.Size = new System.Drawing.Size(104, 24);
			this.m_btTextoInsere.TabIndex = 8;
			this.m_btTextoInsere.Text = "Insere";
			this.m_btTextoInsere.Click += new System.EventHandler(this.m_btTextoInsere_Click);
			// 
			// m_txtFonteTamanho
			// 
			this.m_txtFonteTamanho.Location = new System.Drawing.Point(233, 35);
			this.m_txtFonteTamanho.Name = "m_txtFonteTamanho";
			this.m_txtFonteTamanho.Size = new System.Drawing.Size(39, 20);
			this.m_txtFonteTamanho.TabIndex = 7;
			this.m_txtFonteTamanho.Text = "12";
			this.m_txtFonteTamanho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbFonteTamanho
			// 
			this.m_lbFonteTamanho.Location = new System.Drawing.Point(174, 37);
			this.m_lbFonteTamanho.Name = "m_lbFonteTamanho";
			this.m_lbFonteTamanho.Size = new System.Drawing.Size(65, 16);
			this.m_lbFonteTamanho.TabIndex = 6;
			this.m_lbFonteTamanho.Text = "Tamanho:";
			// 
			// m_txtFonte
			// 
			this.m_txtFonte.Location = new System.Drawing.Point(49, 35);
			this.m_txtFonte.Name = "m_txtFonte";
			this.m_txtFonte.Size = new System.Drawing.Size(119, 20);
			this.m_txtFonte.TabIndex = 5;
			this.m_txtFonte.Text = "Arial Black";
			// 
			// m_lbFonte
			// 
			this.m_lbFonte.Location = new System.Drawing.Point(7, 37);
			this.m_lbFonte.Name = "m_lbFonte";
			this.m_lbFonte.Size = new System.Drawing.Size(48, 16);
			this.m_lbFonte.TabIndex = 4;
			this.m_lbFonte.Text = "Fonte:";
			// 
			// m_txtTexto
			// 
			this.m_txtTexto.Location = new System.Drawing.Point(50, 13);
			this.m_txtTexto.Name = "m_txtTexto";
			this.m_txtTexto.Size = new System.Drawing.Size(390, 20);
			this.m_txtTexto.TabIndex = 3;
			this.m_txtTexto.Text = "Primeira Linha";
			// 
			// m_lbTexto
			// 
			this.m_lbTexto.Location = new System.Drawing.Point(7, 17);
			this.m_lbTexto.Name = "m_lbTexto";
			this.m_lbTexto.Size = new System.Drawing.Size(48, 16);
			this.m_lbTexto.TabIndex = 2;
			this.m_lbTexto.Text = "Texto:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(466, 479);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PDF";
			this.m_gbMain.ResumeLayout(false);
			this.m_gbMarcadores.ResumeLayout(false);
			this.m_gbCirculo.ResumeLayout(false);
			this.m_gbImagem.ResumeLayout(false);
			this.m_gbRetangulo.ResumeLayout(false);
			this.m_gbLinha.ResumeLayout(false);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbTexto.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Geral
				private void m_btPaginaNova_Click(object sender, System.EventArgs e)
				{
					m_pdfDocumento.bAdicionaPagina();
				}

				private void m_btSalvar_Click(object sender, System.EventArgs e)
				{
					m_pdfDocumento.bSalvar(m_txtArquivoSalvar.Text);
				}

				private void m_btRelatorio_Click(object sender, System.EventArgs e)
				{
					m_pdfDocumento.bAdicionaPagina();
					m_pdfDocumento.bAdicionaTexto("Batang",new System.Drawing.Font("Batang",16,System.Drawing.FontStyle.Regular),System.Drawing.Color.Black,10,30);
				}

				private void m_btAbrir_Click(object sender, System.EventArgs e)
				{
					if (System.IO.File.Exists(m_txtArquivoSalvar.Text))
					{
						System.Diagnostics.Process proc = new System.Diagnostics.Process();
						proc.StartInfo.FileName = m_txtArquivoSalvar.Text; 
						proc.StartInfo.CreateNoWindow = true;
						proc.Start();
					}
				}
			#endregion
			#region Marcadores
				private void m_btMarcadoresInsere_Click(object sender, System.EventArgs e)
				{
					m_pdfDocumento.nAdicionaMarcador(m_txtMarcadoresTitulo.Text);
				}

				private void m_btMarcadoresInserePagina_Click(object sender, System.EventArgs e)
				{
					
				}
			#endregion

			#region Linha
				private void m_btLinhaInsere_Click(object sender, System.EventArgs e)
				{
					m_pdfDocumento.bAdicionaLinha(new System.Drawing.Pen(System.Drawing.Color.Black,.1f),new System.Drawing.Point(Int32.Parse(m_txtLinhaX1.Text),Int32.Parse(m_txtLinhaY1.Text)),new System.Drawing.Point(Int32.Parse(m_txtLinhaX2.Text),Int32.Parse(m_txtLinhaY2.Text)));
				}
			#endregion
			#region Retangulo
				private void m_btRetanguloInsere_Click(object sender, System.EventArgs e)
				{
					m_pdfDocumento.bAdicionaRetangulo(new System.Drawing.Pen(System.Drawing.Color.Black,1),new System.Drawing.Rectangle(Int32.Parse(m_txtRetanguloX1.Text),Int32.Parse(m_txtRetanguloY1.Text),Int32.Parse(m_txtRetanguloX2.Text),Int32.Parse(m_txtRetanguloY2.Text)));
				}
			#endregion
			#region Circulo
				private void m_btCirculoInsere_Click(object sender, System.EventArgs e)
				{
					m_pdfDocumento.bAdicionaCirculo(new System.Drawing.Pen(System.Drawing.Color.Black,1),new System.Drawing.Rectangle(Int32.Parse(m_txtCirculoX1.Text),Int32.Parse(m_txtCirculoY1.Text),Int32.Parse(m_txtCirculoWidth.Text),Int32.Parse(m_txtCirculoHeight.Text)));
				}
			#endregion
			#region Texto
				private void m_btTextoInsere_Click(object sender, System.EventArgs e)
				{
					m_txtTexto.Text = "Primeira Linha" + System.Environment.NewLine + "Segunda Linha";
					m_pdfDocumento.bAdicionaTexto(m_txtTexto.Text,new System.Drawing.Font(m_txtFonte.Text,float.Parse(m_txtFonteTamanho.Text)),System.Drawing.Color.Blue,double.Parse(m_txtTextoX1.Text),double.Parse(m_txtTextoY1.Text));
				}
			#endregion
			#region Imagem
				private void m_btImagemInsere_Click(object sender, System.EventArgs e)
				{
					if (System.IO.File.Exists(m_txtImagemArquivo.Text))
						m_pdfDocumento.bAdicionaImagem(new System.Drawing.Bitmap(m_txtImagemArquivo.Text),new System.Drawing.Rectangle(100,100,400,400));
				}
			#endregion
		#endregion 
	}
}

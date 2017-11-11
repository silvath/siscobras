using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosCertificadosOrigem
{
	/// <summary>
	/// Summary description for frmRelatoriosCertificadosOrigem.
	/// </summary>
	public class frmRelatoriosCertificadosOrigem : mdlRelatoriosBase.frmRelatoriosBase
	{
		#region Constantes
			private const int MERCOSUL = 1;
			private const int BOLIVIA = 2;
			private const int CHILE = 3;
			private const int APTR04 = 4;
			private const int ACE39 = 5;
			private const int ANEXOIII = 6;	
			private const int COMUM = 7;
			private const int ACE59 = 29;
			private const int FORMA = 30;

			private const int RELATORIO_CO_MERCOSUL = 4;
			private const int RELATORIO_CO_BOLIVIA = 5;
			private const int RELATORIO_CO_CHILE = 6;
			private const int RELATORIO_CO_APTR04 = 7;
			private const int RELATORIO_CO_ACE39 = 8;
			private const int RELATORIO_CO_ANEXOIII = 9;	
			private const int RELATORIO_CO_COMUM = 10;
			private const int RELATORIO_CO_ACE59 = 29;
			private const int RELATORIO_CO_FORMA = 30;
		#endregion 
        #region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem m_typDatSetTbProdutosCertificadosOrigem = null;
		private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem m_typDatSetTbCertificadosOrigem = null;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		private mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores = null;
		private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes = null;

		private int m_nPaisImportador = -1;
		private int m_nCertOrig1 = -1;
		private int m_nCertOrig2 = -1;
		private int m_nCertOrig3 = -1;
		private int m_nCertOrig4 = -1;
		private int m_nCertOrig5 = -1;

		public int TIPOCERTIFICADO
		{
			set
			{
				m_nTipoRelatorio = value;
				if (!bCarregaIdRelatorio())
					carregaIdRelatorioDefault();
			}
		}

		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.CheckBox m_ckCertOrigem1;
		private System.Windows.Forms.CheckBox m_ckCertOrigem2;
		private System.Windows.Forms.CheckBox m_ckCertOrigem3;
		private System.Windows.Forms.PictureBox m_picBandeira;
		private System.Windows.Forms.ImageList m_ilCertificados;
		private System.Windows.Forms.Button m_btAssistente;
		private System.Windows.Forms.Button m_btConfiguracoes;
		private System.Windows.Forms.CheckBox m_ckCertOrigem5;
		private System.Windows.Forms.CheckBox m_ckCertOrigem4;
		#endregion
		#region Constructor e Desctructor
		public frmRelatoriosCertificadosOrigem(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD, ref System.Windows.Forms.Form mdiParent,string strEnderecoExecutavel,int nIdExportador,string strIdPE) : base(ref tratadorErro,ref conexaoBD, ref mdiParent,strEnderecoExecutavel,4,nIdExportador,strIdPE)
		{
			InitializeComponent();
			bResizeForm();
			m_strSessaoArquivoConfiguracao = "SiscobrasCorSecundaria";
			m_btIdioma.Visible = false;
			refreshInterface();
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRelatoriosCertificadosOrigem));
			this.m_ckCertOrigem1 = new System.Windows.Forms.CheckBox();
			this.m_ckCertOrigem2 = new System.Windows.Forms.CheckBox();
			this.m_ckCertOrigem3 = new System.Windows.Forms.CheckBox();
			this.m_picBandeira = new System.Windows.Forms.PictureBox();
			this.m_ilCertificados = new System.Windows.Forms.ImageList(this.components);
			this.m_ckCertOrigem4 = new System.Windows.Forms.CheckBox();
			this.m_btAssistente = new System.Windows.Forms.Button();
			this.m_btConfiguracoes = new System.Windows.Forms.Button();
			this.m_ckCertOrigem5 = new System.Windows.Forms.CheckBox();
			this.m_gbBarraSuperior.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_ilBandeiras
			// 
			this.m_ilBandeiras.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBandeiras.ImageStream")));
			// 
			// m_rcRelatorio
			// 
			this.m_rcRelatorio.Name = "m_rcRelatorio";
			// 
			// m_btEnviarImagemEmail
			// 
			this.m_btEnviarImagemEmail.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btEnviarImagemEmail.Name = "m_btEnviarImagemEmail";
			this.m_ttDica.SetToolTip(this.m_btEnviarImagemEmail, "Enviar via e-mail ");
			// 
			// m_btIdioma
			// 
			this.m_btIdioma.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btIdioma.Name = "m_btIdioma";
			this.m_ttDica.SetToolTip(this.m_btIdioma, "Alterar idioma ");
			// 
			// m_btSalvarImagem
			// 
			this.m_btSalvarImagem.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btSalvarImagem.Name = "m_btSalvarImagem";
			this.m_ttDica.SetToolTip(this.m_btSalvarImagem, "Salvar imagem");
			// 
			// m_btModoEdicao
			// 
			this.m_btModoEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btModoEdicao.Name = "m_btModoEdicao";
			this.m_ttDica.SetToolTip(this.m_btModoEdicao, "Editar formato");
			// 
			// m_btTrocarRelatorio
			// 
			this.m_btTrocarRelatorio.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btTrocarRelatorio.Name = "m_btTrocarRelatorio";
			this.m_ttDica.SetToolTip(this.m_btTrocarRelatorio, "Trocar formato ");
			// 
			// m_btUltimaPagina
			// 
			this.m_btUltimaPagina.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btUltimaPagina.Name = "m_btUltimaPagina";
			this.m_ttDica.SetToolTip(this.m_btUltimaPagina, "Ultima página");
			// 
			// m_btPrimeiraPagima
			// 
			this.m_btPrimeiraPagima.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btPrimeiraPagima.Name = "m_btPrimeiraPagima";
			this.m_ttDica.SetToolTip(this.m_btPrimeiraPagima, "Primeira página");
			// 
			// m_lbPaginaAtual
			// 
			this.m_lbPaginaAtual.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_lbPaginaAtual.Name = "m_lbPaginaAtual";
			// 
			// m_btPaginaAnterior
			// 
			this.m_btPaginaAnterior.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btPaginaAnterior.Name = "m_btPaginaAnterior";
			this.m_ttDica.SetToolTip(this.m_btPaginaAnterior, "Página anterior");
			// 
			// m_btProximaPagina
			// 
			this.m_btProximaPagina.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btProximaPagina.Name = "m_btProximaPagina";
			this.m_ttDica.SetToolTip(this.m_btProximaPagina, "Página posterior");
			// 
			// m_vsbVertical
			// 
			this.m_vsbVertical.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_vsbVertical.Name = "m_vsbVertical";
			// 
			// m_hsbHorizontal
			// 
			this.m_hsbHorizontal.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_hsbHorizontal.Name = "m_hsbHorizontal";
			// 
			// m_btZoomMenos
			// 
			this.m_btZoomMenos.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btZoomMenos.Name = "m_btZoomMenos";
			// 
			// m_btZoomMais
			// 
			this.m_btZoomMais.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btZoomMais.Name = "m_btZoomMais";
			// 
			// m_gbBarraSuperior
			// 
			this.m_gbBarraSuperior.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_gbBarraSuperior.Controls.Add(this.m_ckCertOrigem5);
			this.m_gbBarraSuperior.Controls.Add(this.m_btConfiguracoes);
			this.m_gbBarraSuperior.Controls.Add(this.m_btAssistente);
			this.m_gbBarraSuperior.Controls.Add(this.m_ckCertOrigem4);
			this.m_gbBarraSuperior.Controls.Add(this.m_ckCertOrigem3);
			this.m_gbBarraSuperior.Controls.Add(this.m_ckCertOrigem2);
			this.m_gbBarraSuperior.Controls.Add(this.m_ckCertOrigem1);
			this.m_gbBarraSuperior.Name = "m_gbBarraSuperior";
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_ckCertOrigem1, 0);
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_ckCertOrigem2, 0);
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_ckCertOrigem3, 0);
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_ckCertOrigem4, 0);
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_btAssistente, 0);
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_btConfiguracoes, 0);
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_ckCertOrigem5, 0);
			// 
			// m_gbBarraInferior
			// 
			this.m_gbBarraInferior.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_gbBarraInferior.Name = "m_gbBarraInferior";
			// 
			// m_btImprimir
			// 
			this.m_btImprimir.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btImprimir.Name = "m_btImprimir";
			// 
			// m_gbBarraInferiorEdicao
			// 
			this.m_gbBarraInferiorEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_gbBarraInferiorEdicao.Name = "m_gbBarraInferiorEdicao";
			// 
			// m_gbBarraSuperiorEdicao
			// 
			this.m_gbBarraSuperiorEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_gbBarraSuperiorEdicao.Name = "m_gbBarraSuperiorEdicao";
			// 
			// m_btModoVisualizacao
			// 
			this.m_btModoVisualizacao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btModoVisualizacao.Name = "m_btModoVisualizacao";
			// 
			// m_btZoomMaisEdicao
			// 
			this.m_btZoomMaisEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btZoomMaisEdicao.Name = "m_btZoomMaisEdicao";
			// 
			// m_btZoomMenosEdicao
			// 
			this.m_btZoomMenosEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btZoomMenosEdicao.Name = "m_btZoomMenosEdicao";
			// 
			// m_btSalvarEdicao
			// 
			this.m_btSalvarEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btSalvarEdicao.Name = "m_btSalvarEdicao";
			// 
			// m_btTrocarRelatorioEdicao
			// 
			this.m_btTrocarRelatorioEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btTrocarRelatorioEdicao.Name = "m_btTrocarRelatorioEdicao";
			// 
			// m_btSalvarComoEdicao
			// 
			this.m_btSalvarComoEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btSalvarComoEdicao.Name = "m_btSalvarComoEdicao";
			// 
			// m_btNovoEdicao
			// 
			this.m_btNovoEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btNovoEdicao.Name = "m_btNovoEdicao";
			// 
			// m_btMargensEdicao
			// 
			this.m_btMargensEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btMargensEdicao.Name = "m_btMargensEdicao";
			// 
			// m_btExcluirEdicao
			// 
			this.m_btExcluirEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btExcluirEdicao.Name = "m_btExcluirEdicao";
			// 
			// m_btZoomNormal
			// 
			this.m_btZoomNormal.Name = "m_btZoomNormal";
			// 
			// m_btImportar
			// 
			this.m_btImportar.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btImportar.Name = "m_btImportar";
			// 
			// m_btExportar
			// 
			this.m_btExportar.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btExportar.Name = "m_btExportar";
			// 
			// m_ckCertOrigem1
			// 
			this.m_ckCertOrigem1.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckCertOrigem1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckCertOrigem1.Image = ((System.Drawing.Image)(resources.GetObject("m_ckCertOrigem1.Image")));
			this.m_ckCertOrigem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_ckCertOrigem1.Location = new System.Drawing.Point(67, 8);
			this.m_ckCertOrigem1.Name = "m_ckCertOrigem1";
			this.m_ckCertOrigem1.Size = new System.Drawing.Size(125, 25);
			this.m_ckCertOrigem1.TabIndex = 58;
			this.m_ckCertOrigem1.Text = "Certificado 1";
			this.m_ckCertOrigem1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ckCertOrigem1.CheckedChanged += new System.EventHandler(this.m_ckCertOrigem1_CheckedChanged);
			// 
			// m_ckCertOrigem2
			// 
			this.m_ckCertOrigem2.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckCertOrigem2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckCertOrigem2.Image = ((System.Drawing.Image)(resources.GetObject("m_ckCertOrigem2.Image")));
			this.m_ckCertOrigem2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_ckCertOrigem2.Location = new System.Drawing.Point(192, 8);
			this.m_ckCertOrigem2.Name = "m_ckCertOrigem2";
			this.m_ckCertOrigem2.Size = new System.Drawing.Size(125, 25);
			this.m_ckCertOrigem2.TabIndex = 59;
			this.m_ckCertOrigem2.Text = "Certificado 2";
			this.m_ckCertOrigem2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ckCertOrigem2.CheckedChanged += new System.EventHandler(this.m_ckCertOrigem2_CheckedChanged);
			// 
			// m_ckCertOrigem3
			// 
			this.m_ckCertOrigem3.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckCertOrigem3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckCertOrigem3.Image = ((System.Drawing.Image)(resources.GetObject("m_ckCertOrigem3.Image")));
			this.m_ckCertOrigem3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_ckCertOrigem3.Location = new System.Drawing.Point(318, 8);
			this.m_ckCertOrigem3.Name = "m_ckCertOrigem3";
			this.m_ckCertOrigem3.Size = new System.Drawing.Size(125, 25);
			this.m_ckCertOrigem3.TabIndex = 60;
			this.m_ckCertOrigem3.Text = "Certificado 3";
			this.m_ckCertOrigem3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ckCertOrigem3.CheckedChanged += new System.EventHandler(this.m_ckCertOrigem3_CheckedChanged);
			// 
			// m_picBandeira
			// 
			this.m_picBandeira.Image = ((System.Drawing.Image)(resources.GetObject("m_picBandeira.Image")));
			this.m_picBandeira.Location = new System.Drawing.Point(103, 91);
			this.m_picBandeira.Name = "m_picBandeira";
			this.m_picBandeira.Size = new System.Drawing.Size(625, 493);
			this.m_picBandeira.TabIndex = 9;
			this.m_picBandeira.TabStop = false;
			// 
			// m_ilCertificados
			// 
			this.m_ilCertificados.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilCertificados.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilCertificados.ImageStream")));
			this.m_ilCertificados.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_ckCertOrigem4
			// 
			this.m_ckCertOrigem4.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckCertOrigem4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckCertOrigem4.Image = ((System.Drawing.Image)(resources.GetObject("m_ckCertOrigem4.Image")));
			this.m_ckCertOrigem4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_ckCertOrigem4.Location = new System.Drawing.Point(443, 8);
			this.m_ckCertOrigem4.Name = "m_ckCertOrigem4";
			this.m_ckCertOrigem4.Size = new System.Drawing.Size(125, 25);
			this.m_ckCertOrigem4.TabIndex = 61;
			this.m_ckCertOrigem4.Text = "Certificado 4";
			this.m_ckCertOrigem4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ckCertOrigem4.CheckedChanged += new System.EventHandler(this.m_ckCertOrigem4_CheckedChanged);
			// 
			// m_btAssistente
			// 
			this.m_btAssistente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btAssistente.Image = ((System.Drawing.Image)(resources.GetObject("m_btAssistente.Image")));
			this.m_btAssistente.Location = new System.Drawing.Point(16, 10);
			this.m_btAssistente.Name = "m_btAssistente";
			this.m_btAssistente.Size = new System.Drawing.Size(24, 24);
			this.m_btAssistente.TabIndex = 62;
			this.m_ttDica.SetToolTip(this.m_btAssistente, "Assistente");
			this.m_btAssistente.Click += new System.EventHandler(this.m_btAssistente_Click);
			// 
			// m_btConfiguracoes
			// 
			this.m_btConfiguracoes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btConfiguracoes.Image = ((System.Drawing.Image)(resources.GetObject("m_btConfiguracoes.Image")));
			this.m_btConfiguracoes.Location = new System.Drawing.Point(40, 10);
			this.m_btConfiguracoes.Name = "m_btConfiguracoes";
			this.m_btConfiguracoes.Size = new System.Drawing.Size(24, 24);
			this.m_btConfiguracoes.TabIndex = 63;
			this.m_ttDica.SetToolTip(this.m_btConfiguracoes, "Configurações");
			this.m_btConfiguracoes.Click += new System.EventHandler(this.m_btConfiguracoes_Click);
			// 
			// m_ckCertOrigem5
			// 
			this.m_ckCertOrigem5.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckCertOrigem5.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckCertOrigem5.Image = ((System.Drawing.Image)(resources.GetObject("m_ckCertOrigem5.Image")));
			this.m_ckCertOrigem5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_ckCertOrigem5.Location = new System.Drawing.Point(568, 8);
			this.m_ckCertOrigem5.Name = "m_ckCertOrigem5";
			this.m_ckCertOrigem5.Size = new System.Drawing.Size(125, 25);
			this.m_ckCertOrigem5.TabIndex = 64;
			this.m_ckCertOrigem5.Text = "Certificado 5";
			this.m_ckCertOrigem5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ckCertOrigem5.CheckedChanged += new System.EventHandler(this.m_ckCertOrigem5_CheckedChanged);
			// 
			// frmRelatoriosCertificadosOrigem
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.ClientSize = new System.Drawing.Size(798, 598);
			this.Controls.Add(this.m_picBandeira);
			this.Name = "frmRelatoriosCertificadosOrigem";
			this.Load += new System.EventHandler(this.frmRelatoriosCertificadosOrigem_Load);
			this.Controls.SetChildIndex(this.m_gbBarraSuperior, 0);
			this.Controls.SetChildIndex(this.m_gbBarraInferior, 0);
			this.Controls.SetChildIndex(this.m_gbBarraInferiorEdicao, 0);
			this.Controls.SetChildIndex(this.m_gbBarraSuperiorEdicao, 0);
			this.Controls.SetChildIndex(this.m_picBandeira, 0);
			this.Controls.SetChildIndex(this.m_rcRelatorio, 0);
			this.Controls.SetChildIndex(this.m_vsbVertical, 0);
			this.Controls.SetChildIndex(this.m_hsbHorizontal, 0);
			this.m_gbBarraSuperior.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#region Eventos do Formulário
		private void frmRelatoriosCertificadosOrigem_Load(object sender, System.EventArgs e)
		{
			vMostraCor();
            carregaIdImportador();
            verificaSePaisImportadorFoiTrocado();
			refreshCertificados();
		}

		private void carregaIdImportador()
		{
			try
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
				mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo, arlCondicaoTipo, arlCondicaoValor,null,null);
				if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
					arlCondicaoCampo.Clear();
					arlCondicaoTipo.Clear();
					arlCondicaoValor.Clear();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					if (!dtrwRowTbFaturasComerciais.IsidImportadorNull())
					{
						arlCondicaoCampo.Add("idImportador");
						arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicaoValor.Add(dtrwRowTbFaturasComerciais.idImportador);


						m_typDatSetTbImportadores = m_cls_dba_ConnectionDB.GetTbImportadores(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
						if (m_typDatSetTbImportadores.tbImportadores.Rows.Count > 0)
						{
							dtrwRowTbImportadores = (mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow)m_typDatSetTbImportadores.tbImportadores.Rows[0];
							if (!dtrwRowTbImportadores.IsidPaisCliNull())
                                m_nPaisImportador = dtrwRowTbImportadores.idPaisCli;
							else
								m_nPaisImportador = -1;
						}
					}

				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void verificaSePaisImportadorFoiTrocado()
		{
			try
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwTbCertificadosOrigem;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwTbProdutosCertificadosOrigem;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_typDatSetTbPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);

				if (m_typDatSetTbPes.tbPEs.Rows.Count > 0)
				{
					dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
					if ((dtrwTbPes.IsnIdUltimoPaisImportadorNull()) || (dtrwTbPes.nIdUltimoPaisImportador != m_nPaisImportador))
					{
						dtrwTbPes.nIdUltimoPaisImportador = m_nPaisImportador;
						m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetTbPes);
						m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
						for (int nCount = 0; nCount < m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count; nCount++)
						{
							dtrwTbCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows[nCount];
							dtrwTbCertificadosOrigem.Delete();
						}
						m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
						
						m_typDatSetTbProdutosCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
						for (int nCount = 0; nCount < m_typDatSetTbProdutosCertificadosOrigem.tbProdutosCertificadoOrigem.Rows.Count; nCount++)
						{
							dtrwTbProdutosCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)m_typDatSetTbProdutosCertificadosOrigem.tbProdutosCertificadoOrigem.Rows[nCount];
							dtrwTbProdutosCertificadosOrigem.Delete();
						}
						m_cls_dba_ConnectionDB.SetTbProdutosCertificadoOrigem(m_typDatSetTbProdutosCertificadosOrigem);
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
        #endregion
		#region Métodos Referentes aos Botoes dos Certificados
			private void m_ckCertOrigem1_CheckedChanged(object sender, System.EventArgs e)
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					m_ckCertOrigem2.Checked = false;
					m_ckCertOrigem3.Checked = false;
					m_ckCertOrigem4.Checked = false;
					m_ckCertOrigem5.Checked = false;

					if (m_ckCertOrigem1.Checked){
						Cursor = System.Windows.Forms.Cursors.WaitCursor;
						switch(m_nCertOrig1)
						{
							case MERCOSUL:
								m_nTipoRelatorio = RELATORIO_CO_MERCOSUL;
								break;
							case BOLIVIA:
								m_nTipoRelatorio = RELATORIO_CO_BOLIVIA;
								break;
							case CHILE:
								m_nTipoRelatorio = RELATORIO_CO_CHILE;
								break;
							case APTR04:
								m_nTipoRelatorio = RELATORIO_CO_APTR04;
								break;
							case ACE39:
								m_nTipoRelatorio = RELATORIO_CO_ACE39;
								break;
							case ANEXOIII:
								m_nTipoRelatorio = RELATORIO_CO_ANEXOIII;
								break;
							case COMUM:
								m_nTipoRelatorio = RELATORIO_CO_COMUM;
								break;
							case FORMA:
								m_nTipoRelatorio = RELATORIO_CO_FORMA;
								break;
							case ACE59:
								m_nTipoRelatorio = RELATORIO_CO_ACE59;
								break;
						}
						if (!bCarregaIdRelatorio())
							carregaIdRelatorioDefault();
						if (bCriaRegistroCertificado(m_nCertOrig1))
							System.Threading.Thread.Sleep(1000);
//						bool bTemProdutos = bPrecisaAtivarAreaProdutos();
//						mdlProdutosVinculacao.clsProdutosVinculacao objProd;
//						if ((m_nTipoRelatorio == RELATORIO_CO_MERCOSUL) || (m_nTipoRelatorio == RELATORIO_CO_COMUM))
//							objProd = new mdlProdutosVinculacao.Faturas.clsProdutosVinculacaoComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, 1, m_nIdIdioma, ref m_ilBandeiras);
//						else
//							objProd = new mdlProdutosVinculacao.Faturas.clsProdutosVinculacaoComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, 2, m_nIdIdioma, ref m_ilBandeiras);
//						if (objProd.necessitaVincular())
//							mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRelatoriosCertificadosOrigem_frmFRelatoriosCertificadosOrigem_NecessitaVincular), System.Windows.Forms.MessageBoxButtons.OK);
//						if (!bTemProdutos)
//						{
//							insereProdutosNoCertificado(m_nCertOrig1);
//						}
						bMostrarRelatorio();
//						if (bTemProdutos)
//						{
//							refreshInterface();
//							m_rcRelatorio.MostrarAreaProdutos();
//						}
						Cursor = System.Windows.Forms.Cursors.Default;
					}
                    refreshInterface();
					m_bAtivado = true;
				}			
			}

			private void m_ckCertOrigem2_CheckedChanged(object sender, System.EventArgs e)
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					m_ckCertOrigem1.Checked = false;
					m_ckCertOrigem3.Checked = false;
					m_ckCertOrigem4.Checked = false;
					m_ckCertOrigem5.Checked = false;

					if (m_ckCertOrigem2.Checked)
					{
						Cursor = System.Windows.Forms.Cursors.WaitCursor;
						switch(m_nCertOrig2)
						{
							case MERCOSUL:
								m_nTipoRelatorio = RELATORIO_CO_MERCOSUL;
								break;
							case BOLIVIA:
								m_nTipoRelatorio = RELATORIO_CO_BOLIVIA;
								break;
							case CHILE:
								m_nTipoRelatorio = RELATORIO_CO_CHILE;
								break;
							case APTR04:
								m_nTipoRelatorio = RELATORIO_CO_APTR04;
								break;
							case ACE39:
								m_nTipoRelatorio = RELATORIO_CO_ACE39;
								break;
							case ANEXOIII:
								m_nTipoRelatorio = RELATORIO_CO_ANEXOIII;
								break;
							case COMUM:
								m_nTipoRelatorio = RELATORIO_CO_COMUM;
								break;
							case FORMA:
								m_nTipoRelatorio = RELATORIO_CO_FORMA;
								break;
							case ACE59:
								m_nTipoRelatorio = RELATORIO_CO_ACE59;
								break;
						}
						if (!bCarregaIdRelatorio())
							carregaIdRelatorioDefault();
						if (bCriaRegistroCertificado(m_nCertOrig2))
							System.Threading.Thread.Sleep(1000);
//						bool bTemProdutos = bPrecisaAtivarAreaProdutos();
//						mdlProdutosVinculacao.clsProdutosVinculacao objProd;
//						if ((m_nTipoRelatorio == RELATORIO_CO_MERCOSUL) || (m_nTipoRelatorio == RELATORIO_CO_COMUM))
//							objProd = new mdlProdutosVinculacao.Faturas.clsProdutosVinculacaoComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, 1, m_nIdIdioma, ref m_ilBandeiras);
//						else
//							objProd = new mdlProdutosVinculacao.Faturas.clsProdutosVinculacaoComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, 2, m_nIdIdioma, ref m_ilBandeiras);
//						if (objProd.necessitaVincular())
//							mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRelatoriosCertificadosOrigem_frmFRelatoriosCertificadosOrigem_NecessitaVincular), System.Windows.Forms.MessageBoxButtons.OK);
//						if (!bTemProdutos)
//						{
//							insereProdutosNoCertificado(m_nCertOrig2);
//						}
						bMostrarRelatorio();
//						if (bTemProdutos)
//						{
//							refreshInterface();
//							m_rcRelatorio.MostrarAreaProdutos();
//						}
						Cursor = System.Windows.Forms.Cursors.Default;
					}
					refreshInterface();
					m_bAtivado = true;
				}			
			}

			private void m_ckCertOrigem3_CheckedChanged(object sender, System.EventArgs e)
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					m_ckCertOrigem1.Checked = false;
					m_ckCertOrigem2.Checked = false;
					m_ckCertOrigem4.Checked = false;
					m_ckCertOrigem5.Checked = false;

					if (m_ckCertOrigem3.Checked)
					{
						Cursor = System.Windows.Forms.Cursors.WaitCursor;
						switch(m_nCertOrig3)
						{
							case MERCOSUL:
								m_nTipoRelatorio = RELATORIO_CO_MERCOSUL;
								break;
							case BOLIVIA:
								m_nTipoRelatorio = RELATORIO_CO_BOLIVIA;
								break;
							case CHILE:
								m_nTipoRelatorio = RELATORIO_CO_CHILE;
								break;
							case APTR04:
								m_nTipoRelatorio = RELATORIO_CO_APTR04;
								break;
							case ACE39:
								m_nTipoRelatorio = RELATORIO_CO_ACE39;
								break;
							case ANEXOIII:
								m_nTipoRelatorio = RELATORIO_CO_ANEXOIII;
								break;
							case COMUM:
								m_nTipoRelatorio = RELATORIO_CO_COMUM;
								break;
							case FORMA:
								m_nTipoRelatorio = RELATORIO_CO_FORMA;
								break;
							case ACE59:
								m_nTipoRelatorio = RELATORIO_CO_ACE59;
								break;
						}
						if (!bCarregaIdRelatorio())
							carregaIdRelatorioDefault();
						if (bCriaRegistroCertificado(m_nCertOrig3))
							System.Threading.Thread.Sleep(1000);
//						bool bTemProdutos = bPrecisaAtivarAreaProdutos();
//						mdlProdutosVinculacao.clsProdutosVinculacao objProd;
//						if ((m_nTipoRelatorio == RELATORIO_CO_MERCOSUL) || (m_nTipoRelatorio == RELATORIO_CO_COMUM))
//							objProd = new mdlProdutosVinculacao.Faturas.clsProdutosVinculacaoComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, 1, m_nIdIdioma, ref m_ilBandeiras);
//						else
//							objProd = new mdlProdutosVinculacao.Faturas.clsProdutosVinculacaoComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, 2, m_nIdIdioma, ref m_ilBandeiras);
//						if (objProd.necessitaVincular())
//							mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRelatoriosCertificadosOrigem_frmFRelatoriosCertificadosOrigem_NecessitaVincular), System.Windows.Forms.MessageBoxButtons.OK);
//						if (!bTemProdutos)
//						{
//							insereProdutosNoCertificado(m_nCertOrig3);
//						}
						bMostrarRelatorio();
//						if (bTemProdutos)
//						{
//							refreshInterface();
//							m_rcRelatorio.MostrarAreaProdutos();
//						}
						Cursor = System.Windows.Forms.Cursors.Default;
					}
					refreshInterface();
					m_bAtivado = true;
				}			
			}
			private void m_ckCertOrigem4_CheckedChanged(object sender, System.EventArgs e)
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					m_ckCertOrigem1.Checked = false;
					m_ckCertOrigem2.Checked = false;
					m_ckCertOrigem3.Checked = false;
					m_ckCertOrigem5.Checked = false;

					if (m_ckCertOrigem4.Checked)
					{
						Cursor = System.Windows.Forms.Cursors.WaitCursor;
						switch(m_nCertOrig4)
						{
							case MERCOSUL:
								m_nTipoRelatorio = RELATORIO_CO_MERCOSUL;
								break;
							case BOLIVIA:
								m_nTipoRelatorio = RELATORIO_CO_BOLIVIA;
								break;
							case CHILE:
								m_nTipoRelatorio = RELATORIO_CO_CHILE;
								break;
							case APTR04:
								m_nTipoRelatorio = RELATORIO_CO_APTR04;
								break;
							case ACE39:
								m_nTipoRelatorio = RELATORIO_CO_ACE39;
								break;
							case ANEXOIII:
								m_nTipoRelatorio = RELATORIO_CO_ANEXOIII;
								break;
							case COMUM:
								m_nTipoRelatorio = RELATORIO_CO_COMUM;
								break;
							case FORMA:
								m_nTipoRelatorio = RELATORIO_CO_FORMA;
								break;
							case ACE59:
								m_nTipoRelatorio = RELATORIO_CO_ACE59;
								break;
						}
						if (!bCarregaIdRelatorio())
							carregaIdRelatorioDefault();
						if (bCriaRegistroCertificado(m_nCertOrig4))
							System.Threading.Thread.Sleep(1000);
//						bool bTemProdutos = bPrecisaAtivarAreaProdutos();
//						mdlProdutosVinculacao.clsProdutosVinculacao objProd;
//						if ((m_nTipoRelatorio == RELATORIO_CO_MERCOSUL) || (m_nTipoRelatorio == RELATORIO_CO_COMUM))
//							objProd = new mdlProdutosVinculacao.Faturas.clsProdutosVinculacaoComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, 1, m_nIdIdioma, ref m_ilBandeiras);
//						else
//							objProd = new mdlProdutosVinculacao.Faturas.clsProdutosVinculacaoComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, 2, m_nIdIdioma, ref m_ilBandeiras);
//						if (objProd.necessitaVincular())
//							mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRelatoriosCertificadosOrigem_frmFRelatoriosCertificadosOrigem_NecessitaVincular), System.Windows.Forms.MessageBoxButtons.OK);
//						if (!bTemProdutos)
//						{
//							insereProdutosNoCertificado(m_nCertOrig4);
//						}
						bMostrarRelatorio();
//						if (bTemProdutos)
//						{
//							refreshInterface();
//							m_rcRelatorio.MostrarAreaProdutos();
//						}
						Cursor = System.Windows.Forms.Cursors.Default;
					}
					refreshInterface();
					m_bAtivado = true;
				}
			}

			private void m_ckCertOrigem5_CheckedChanged(object sender, System.EventArgs e)
			{
				if (m_bAtivado)
				{
					m_bAtivado = false;
					m_ckCertOrigem1.Checked = false;
					m_ckCertOrigem2.Checked = false;
					m_ckCertOrigem3.Checked = false;
					m_ckCertOrigem4.Checked = false;

					if (m_ckCertOrigem5.Checked)
					{
						Cursor = System.Windows.Forms.Cursors.WaitCursor;
						switch(m_nCertOrig5)
						{
							case MERCOSUL:
								m_nTipoRelatorio = RELATORIO_CO_MERCOSUL;
								break;
							case BOLIVIA:
								m_nTipoRelatorio = RELATORIO_CO_BOLIVIA;
								break;
							case CHILE:
								m_nTipoRelatorio = RELATORIO_CO_CHILE;
								break;
							case APTR04:
								m_nTipoRelatorio = RELATORIO_CO_APTR04;
								break;
							case ACE39:
								m_nTipoRelatorio = RELATORIO_CO_ACE39;
								break;
							case ANEXOIII:
								m_nTipoRelatorio = RELATORIO_CO_ANEXOIII;
								break;
							case COMUM:
								m_nTipoRelatorio = RELATORIO_CO_COMUM;
								break;
							case FORMA:
								m_nTipoRelatorio = RELATORIO_CO_FORMA;
								break;
							case ACE59:
								m_nTipoRelatorio = RELATORIO_CO_ACE59;
								break;
						}
						if (!bCarregaIdRelatorio())
							carregaIdRelatorioDefault();
						if (bCriaRegistroCertificado(m_nCertOrig5))
							System.Threading.Thread.Sleep(1000);
						//						bool bTemProdutos = bPrecisaAtivarAreaProdutos();
						//						mdlProdutosVinculacao.clsProdutosVinculacao objProd;
						//						if ((m_nTipoRelatorio == RELATORIO_CO_MERCOSUL) || (m_nTipoRelatorio == RELATORIO_CO_COMUM))
						//							objProd = new mdlProdutosVinculacao.Faturas.clsProdutosVinculacaoComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, 1, m_nIdIdioma, ref m_ilBandeiras);
						//						else
						//							objProd = new mdlProdutosVinculacao.Faturas.clsProdutosVinculacaoComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, 2, m_nIdIdioma, ref m_ilBandeiras);
						//						if (objProd.necessitaVincular())
						//							mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRelatoriosCertificadosOrigem_frmFRelatoriosCertificadosOrigem_NecessitaVincular), System.Windows.Forms.MessageBoxButtons.OK);
						//						if (!bTemProdutos)
						//						{
						//							insereProdutosNoCertificado(m_nCertOrig4);
						//						}
						bMostrarRelatorio();
						//						if (bTemProdutos)
						//						{
						//							refreshInterface();
						//							m_rcRelatorio.MostrarAreaProdutos();
						//						}
						Cursor = System.Windows.Forms.Cursors.Default;
					}
					refreshInterface();
					m_bAtivado = true;
				}
			}
		#endregion
		#region Métodos Referentes a Criação do Registro do Certificado
			/// <summary>
			///  Cria o registro do Certficado de origem no banco de dados caso ele nao exista 
			/// </summary>
			/// <param name="tipoCertificado"></param>
			/// <returns></returns>
			private bool bCriaRegistroCertificado(int tipoCertificado)
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwTbCertificadosOrigem;
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo, arlCondicaoTipo, arlCondicaoValor, null, null);
				if (m_typDatSetTbPes.tbPEs.Rows.Count > 0)
				{
					dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
					dtrwTbPes.nIdUltimoPaisImportador = m_nPaisImportador;
				}

				arlCondicaoCampo.Add("nIdTipoCO");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);

				bool bRetorno = false;				
				System.DateTime dtHoje = System.DateTime.Now;

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				switch (tipoCertificado)
				{
					case MERCOSUL:
						arlCondicaoValor.Add(1);
						m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
						if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count == 0)
						{
							dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.NewtbCertificadosOrigemRow();
							dtrwTbCertificadosOrigem.idExportador = m_nIdExportador;
							dtrwTbCertificadosOrigem.idPE = m_strIdCodigo;
							dtrwTbCertificadosOrigem.nIdTipoCO = 1;
							dtrwTbCertificadosOrigem.nIdRelatorio = m_nIdRelatorio;
							dtrwTbCertificadosOrigem.dtDataCO = dtHoje;
							dtrwTbCertificadosOrigem.nImpressoes = 0;
							m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.AddtbCertificadosOrigemRow(dtrwTbCertificadosOrigem);
							m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
							bRetorno = true;
						}
						break;
					case BOLIVIA:
						arlCondicaoValor.Add(2);
						m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
						if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count == 0)
						{
							dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.NewtbCertificadosOrigemRow();
							dtrwTbCertificadosOrigem.idExportador = m_nIdExportador;
							dtrwTbCertificadosOrigem.idPE = m_strIdCodigo;
							dtrwTbCertificadosOrigem.nIdTipoCO = 2;
							dtrwTbCertificadosOrigem.nIdRelatorio = m_nIdRelatorio;
							dtrwTbCertificadosOrigem.dtDataCO = dtHoje;
							dtrwTbCertificadosOrigem.nImpressoes = 0;
							m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.AddtbCertificadosOrigemRow(dtrwTbCertificadosOrigem);
							m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
							bRetorno = true;
						}
						break;
					case CHILE:
						arlCondicaoValor.Add(3);
						m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
						if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count == 0)
						{
							dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.NewtbCertificadosOrigemRow();
							dtrwTbCertificadosOrigem.idExportador = m_nIdExportador;
							dtrwTbCertificadosOrigem.idPE = m_strIdCodigo;
							dtrwTbCertificadosOrigem.nIdTipoCO = 3;
							dtrwTbCertificadosOrigem.nIdRelatorio = m_nIdRelatorio;
							dtrwTbCertificadosOrigem.dtDataCO = dtHoje;
							dtrwTbCertificadosOrigem.nImpressoes = 0;
							m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.AddtbCertificadosOrigemRow(dtrwTbCertificadosOrigem);
							m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
							bRetorno = true;
						}
						break;
					case APTR04:
						arlCondicaoValor.Add(4);
						m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
						if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count == 0)
						{
							dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.NewtbCertificadosOrigemRow();
							dtrwTbCertificadosOrigem.idExportador = m_nIdExportador;
							dtrwTbCertificadosOrigem.idPE = m_strIdCodigo;
							dtrwTbCertificadosOrigem.nIdTipoCO = 4;
							dtrwTbCertificadosOrigem.nIdRelatorio = m_nIdRelatorio;
							dtrwTbCertificadosOrigem.dtDataCO = dtHoje;
							dtrwTbCertificadosOrigem.nImpressoes = 0;
							m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.AddtbCertificadosOrigemRow(dtrwTbCertificadosOrigem);
							m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
							bRetorno = true;
						}
						break;
					case ACE39:
						arlCondicaoValor.Add(5);
						m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
						if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count == 0)
						{
							dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.NewtbCertificadosOrigemRow();
							dtrwTbCertificadosOrigem.idExportador = m_nIdExportador;
							dtrwTbCertificadosOrigem.idPE = m_strIdCodigo;
							dtrwTbCertificadosOrigem.nIdTipoCO = 5;
							dtrwTbCertificadosOrigem.nIdRelatorio = m_nIdRelatorio;
							dtrwTbCertificadosOrigem.dtDataCO = dtHoje;
							dtrwTbCertificadosOrigem.nImpressoes = 0;
							m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.AddtbCertificadosOrigemRow(dtrwTbCertificadosOrigem);
							m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
							bRetorno = true;
						}
						break;
					case ANEXOIII:
						arlCondicaoValor.Add(6);
						m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
						if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count == 0)
						{
							dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.NewtbCertificadosOrigemRow();
							dtrwTbCertificadosOrigem.idExportador = m_nIdExportador;
							dtrwTbCertificadosOrigem.idPE = m_strIdCodigo;
							dtrwTbCertificadosOrigem.nIdTipoCO = 6;
							dtrwTbCertificadosOrigem.nIdRelatorio = m_nIdRelatorio;
							dtrwTbCertificadosOrigem.dtDataCO = dtHoje;
							dtrwTbCertificadosOrigem.nImpressoes = 0;
							m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.AddtbCertificadosOrigemRow(dtrwTbCertificadosOrigem);
							m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
							bRetorno = true;
						}
						break;
					case COMUM:
						arlCondicaoValor.Add(7);
						m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
						if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count == 0)
						{
							dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.NewtbCertificadosOrigemRow();
							dtrwTbCertificadosOrigem.idExportador = m_nIdExportador;
							dtrwTbCertificadosOrigem.idPE = m_strIdCodigo;
							dtrwTbCertificadosOrigem.nIdTipoCO = 7;
							dtrwTbCertificadosOrigem.nIdRelatorio = m_nIdRelatorio;
							dtrwTbCertificadosOrigem.dtDataCO = dtHoje;
							dtrwTbCertificadosOrigem.nImpressoes = 0;
							m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.AddtbCertificadosOrigemRow(dtrwTbCertificadosOrigem);
							m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
							bRetorno = true;
						}
						break;
					case FORMA:
						arlCondicaoValor.Add(30);
						m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
						if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count == 0)
						{
							dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.NewtbCertificadosOrigemRow();
							dtrwTbCertificadosOrigem.idExportador = m_nIdExportador;
							dtrwTbCertificadosOrigem.idPE = m_strIdCodigo;
							dtrwTbCertificadosOrigem.nIdTipoCO = 30;
							dtrwTbCertificadosOrigem.nIdRelatorio = m_nIdRelatorio;
							dtrwTbCertificadosOrigem.dtDataCO = dtHoje;
							dtrwTbCertificadosOrigem.nImpressoes = 0;
							m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.AddtbCertificadosOrigemRow(dtrwTbCertificadosOrigem);
							m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
							bRetorno = true;
						}
						break;
					case ACE59:
						arlCondicaoValor.Add(29);
						m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
						if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count == 0)
						{
							dtrwTbCertificadosOrigem = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.NewtbCertificadosOrigemRow();
							dtrwTbCertificadosOrigem.idExportador = m_nIdExportador;
							dtrwTbCertificadosOrigem.idPE = m_strIdCodigo;
							dtrwTbCertificadosOrigem.nIdTipoCO = 29;
							dtrwTbCertificadosOrigem.nIdRelatorio = m_nIdRelatorio;
							dtrwTbCertificadosOrigem.dtDataCO = dtHoje;
							dtrwTbCertificadosOrigem.nImpressoes = 0;
							m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.AddtbCertificadosOrigemRow(dtrwTbCertificadosOrigem);
							m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
							bRetorno = true;
						}
						break;
				}
				if ((bRetorno) && (m_typDatSetTbPes != null))
					m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetTbPes);
				else
					m_typDatSetTbPes = null;
				return (bRetorno);
			}
		#endregion
		#region Métodos Referentes aos Certificados
			private void refreshInterface()
			{
				if (!m_ckCertOrigem1.Checked && !m_ckCertOrigem2.Checked && !m_ckCertOrigem3.Checked && !m_ckCertOrigem4.Checked && !m_ckCertOrigem5.Checked)
				{
					m_btAssistente.Enabled = false;
					m_btConfiguracoes.Enabled = false;

					// Relatorio
					m_rcRelatorio.Visible = false;

					// Imagem
					m_picBandeira.Visible = true;	
					m_picBandeira.SetBounds(m_picBandeira.Location.X, m_gbBarraSuperior.Location.Y + m_gbBarraSuperior.Height + 2, m_picBandeira.Width, m_picBandeira.Height);

					// Scroll Bars 
					m_vsbVertical.Visible = false;
					m_hsbHorizontal.Visible = false;

					// Barra Inferior 
					m_gbBarraInferior.Visible = false;

				}else{

					m_btAssistente.Enabled = true;
					m_btConfiguracoes.Enabled = true;

					// Relatorio
					m_rcRelatorio.Visible = true;

					// Imagem
					m_picBandeira.Visible = false;

					// Scroll Bars 
					m_vsbVertical.Visible = true;
					m_hsbHorizontal.Visible = true;

					// Barra Inferior 
					m_gbBarraInferior.Visible = true;
				}
			}
			private void refreshCertificados()
			{
				#region Países//Certificados
				switch(m_nPaisImportador)
				{
					case 63: // Argentina
						m_nCertOrig1 = MERCOSUL;
						m_nCertOrig2 = APTR04;
						m_nCertOrig3 = COMUM;
						m_nCertOrig4 = FORMA; 
						m_nCertOrig5 = -1;
					break;
					case 586: // Paraguai
						m_nCertOrig1 = MERCOSUL;
						m_nCertOrig2 = APTR04;
						m_nCertOrig3 = COMUM;
						m_nCertOrig4 = FORMA; 
						m_nCertOrig5 = -1;
					break;
					case 845: // Uruguai 
						m_nCertOrig1 = MERCOSUL;
						m_nCertOrig2 = APTR04;
						m_nCertOrig3 = COMUM;
						m_nCertOrig4 = FORMA; 
						m_nCertOrig5 = -1;
					break;
					case 158: // Chile 
						m_nCertOrig1 = CHILE;
						m_nCertOrig2 = APTR04;
						m_nCertOrig3 = COMUM;
						m_nCertOrig4 = FORMA; 
						m_nCertOrig5 = -1;
						break;
					case 97: // Bolivia 
						m_nCertOrig1 = BOLIVIA;
						m_nCertOrig2 = APTR04;
						m_nCertOrig3 = COMUM;
						m_nCertOrig4 = FORMA; 
						m_nCertOrig5 = -1;
						break;
					case 169: // Colombia 
						m_nCertOrig1 = APTR04;
						m_nCertOrig2 = ACE39;
						m_nCertOrig3 = COMUM;
						m_nCertOrig4 = ACE59; 
						m_nCertOrig5 = FORMA;
						break;
					case 239: // equador
						m_nCertOrig1 = APTR04;
						m_nCertOrig2 = ACE39;
						m_nCertOrig3 = COMUM;
						m_nCertOrig4 = ACE59; 
						m_nCertOrig5 = FORMA;
						break;
					case 589 : // peru
						m_nCertOrig1 = APTR04;
						m_nCertOrig2 = ACE39;
						m_nCertOrig3 = COMUM;
						m_nCertOrig4 = FORMA;
						m_nCertOrig5 = -1;
						break;
					case 850: // venezuela
						m_nCertOrig1 = APTR04;
						m_nCertOrig2 = ACE39;
						m_nCertOrig3 = COMUM;
						m_nCertOrig4 = ACE59; 
						m_nCertOrig5 = FORMA;
						break;
					case 199: // Cuba
						m_nCertOrig1 = APTR04;
						m_nCertOrig2 = COMUM;
						m_nCertOrig3 = FORMA;
						m_nCertOrig4 = -1;
						m_nCertOrig5 = -1;
						break;
					case 493: // Mexico 
						m_nCertOrig1 = APTR04; 
						m_nCertOrig2 = COMUM;
						m_nCertOrig3 = FORMA;
						m_nCertOrig4 = -1;
						m_nCertOrig5 = -1;
						break;
					case -1: // Nenhum idEscolhido
						m_nCertOrig1 = -1;
						m_nCertOrig2 = -1;
						m_nCertOrig3 = -1;
						m_nCertOrig4 = -1;
						m_nCertOrig5 = -1;
						break;
					default: // Resto dos Paises
						m_nCertOrig1 = COMUM;
						m_nCertOrig2 = FORMA;
						m_nCertOrig3 = -1;
						m_nCertOrig4 = -1;
						m_nCertOrig5 = -1;
						break;
				}
				#endregion
				#region m_nCertOrig1
				switch(m_nCertOrig1)
				{
					case MERCOSUL:
						m_ckCertOrigem1.Text = "Mercosul";
						m_ckCertOrigem1.Visible = true;
						m_ckCertOrigem1.Image = m_ilCertificados.Images[MERCOSUL - 1];
						break;
					case CHILE:
						m_ckCertOrigem1.Text = "Chile";
						m_ckCertOrigem1.Visible = true;
						m_ckCertOrigem1.Image = m_ilCertificados.Images[CHILE - 1];
						break;
					case BOLIVIA:
						m_ckCertOrigem1.Text = "Bolívia";
						m_ckCertOrigem1.Visible = true;
						m_ckCertOrigem1.Image = m_ilCertificados.Images[BOLIVIA - 1];
						break;
					case APTR04:
						m_ckCertOrigem1.Text = "Aladi - Aptr04";
						m_ckCertOrigem1.Visible = true;
						m_ckCertOrigem1.Image = m_ilCertificados.Images[APTR04 - 1];
						break;
					case ACE39:
						m_ckCertOrigem1.Text = "Aladi - Ace39";
						m_ckCertOrigem1.Visible = true;
						m_ckCertOrigem1.Image = m_ilCertificados.Images[ACE39 - 1];
						break;
					case ANEXOIII:
						m_ckCertOrigem1.Text = "AnexoIII";
						m_ckCertOrigem1.Visible = true;
						m_ckCertOrigem1.Image = m_ilCertificados.Images[ANEXOIII - 1];
						break;
					case COMUM:
						m_ckCertOrigem1.Text = "Comum";
						m_ckCertOrigem1.Visible = true;
						m_ckCertOrigem1.Image = m_ilCertificados.Images[COMUM - 1];
						break;
					case FORMA:
						m_ckCertOrigem1.Text = "Form A";
						m_ckCertOrigem1.Visible = true;
						m_ckCertOrigem1.Image = m_ilCertificados.Images[COMUM - 1];
						break;
					case ACE59:
						m_ckCertOrigem1.Text = "Aladi - Ace59";
						m_ckCertOrigem1.Visible = true;
						m_ckCertOrigem1.Image = m_ilCertificados.Images[ACE39 - 1];
						break;
					default:
						m_ckCertOrigem1.Visible = false;
						break;
				}
				#endregion
				#region m_nCertOrig2
				switch(m_nCertOrig2)
				{
					case MERCOSUL:
						m_ckCertOrigem2.Text = "Mercosul";
						m_ckCertOrigem2.Visible = true;
						m_ckCertOrigem2.Image = m_ilCertificados.Images[MERCOSUL - 1];
						break;
					case CHILE:
						m_ckCertOrigem2.Text = "Chile";
						m_ckCertOrigem2.Visible = true;
						m_ckCertOrigem2.Image = m_ilCertificados.Images[CHILE - 1];
						break;
					case BOLIVIA:
						m_ckCertOrigem2.Text = "Bolívia";
						m_ckCertOrigem2.Visible = true;
						m_ckCertOrigem2.Image = m_ilCertificados.Images[BOLIVIA - 1];
						break;
					case APTR04:
						m_ckCertOrigem2.Text = "Aladi - Aptr04";
						m_ckCertOrigem2.Visible = true;
						m_ckCertOrigem2.Image = m_ilCertificados.Images[APTR04 - 1];
						break;
					case ACE39:
						m_ckCertOrigem2.Text = "Aladi - Ace39";
						m_ckCertOrigem2.Visible = true;
						m_ckCertOrigem2.Image = m_ilCertificados.Images[ACE39 - 1];
						break;
					case ANEXOIII:
						m_ckCertOrigem2.Text = "AnexoIII";
						m_ckCertOrigem2.Visible = true;
						m_ckCertOrigem2.Image = m_ilCertificados.Images[ANEXOIII - 1];
						break;
					case COMUM:
						m_ckCertOrigem2.Text = "Comum";
						m_ckCertOrigem2.Visible = true;
						m_ckCertOrigem2.Image = m_ilCertificados.Images[COMUM - 1];
						break;
					case FORMA:
						m_ckCertOrigem2.Text = "Form A";
						m_ckCertOrigem2.Visible = true;
						m_ckCertOrigem2.Image = m_ilCertificados.Images[COMUM - 1];
						break;
					case ACE59:
						m_ckCertOrigem2.Text = "Aladi - Ace59";
						m_ckCertOrigem2.Visible = true;
						m_ckCertOrigem2.Image = m_ilCertificados.Images[ACE39 - 1];
						break;
					default:
						m_ckCertOrigem2.Visible = false;
						break;
				}
				#endregion
				#region m_nCertOrig3
				switch(m_nCertOrig3)
				{
					case MERCOSUL:
						m_ckCertOrigem3.Text = "Mercosul";
						m_ckCertOrigem3.Visible = true;
						m_ckCertOrigem3.Image = m_ilCertificados.Images[MERCOSUL - 1];
						break;
					case CHILE:
						m_ckCertOrigem3.Text = "Chile";
						m_ckCertOrigem3.Visible = true;
						m_ckCertOrigem3.Image = m_ilCertificados.Images[CHILE - 1];
						break;
					case BOLIVIA:
						m_ckCertOrigem3.Text = "Bolívia";
						m_ckCertOrigem3.Visible = true;
						m_ckCertOrigem3.Image = m_ilCertificados.Images[BOLIVIA - 1];
						break;
					case APTR04:
						m_ckCertOrigem3.Text = "Aladi - Aptr04";
						m_ckCertOrigem3.Visible = true;
						m_ckCertOrigem3.Image = m_ilCertificados.Images[APTR04 - 1];
						break;
					case ACE39:
						m_ckCertOrigem3.Text = "Aladi - Ace39";
						m_ckCertOrigem3.Visible = true;
						m_ckCertOrigem3.Image = m_ilCertificados.Images[ACE39 - 1];
						break;
					case ANEXOIII:
						m_ckCertOrigem3.Text = "AnexoIII";
						m_ckCertOrigem3.Visible = true;
						m_ckCertOrigem3.Image = m_ilCertificados.Images[ANEXOIII - 1];
						break;
					case COMUM:
						m_ckCertOrigem3.Text = "Comum";
						m_ckCertOrigem3.Visible = true;
						m_ckCertOrigem3.Image = m_ilCertificados.Images[COMUM - 1];
						break;
					case FORMA:
						m_ckCertOrigem3.Text = "Form A";
						m_ckCertOrigem3.Visible = true;
						m_ckCertOrigem3.Image = m_ilCertificados.Images[COMUM - 1];
						break;
					case ACE59:
						m_ckCertOrigem3.Text = "Aladi - Ace59";
						m_ckCertOrigem3.Visible = true;
						m_ckCertOrigem3.Image = m_ilCertificados.Images[ACE39 - 1];
						break;
					default:
						m_ckCertOrigem3.Visible = false;
						break;
				}
				#endregion
				#region m_nCertOrig4
				switch(m_nCertOrig4)
				{
					case MERCOSUL:
						m_ckCertOrigem4.Text = "Mercosul";
						m_ckCertOrigem4.Visible = true;
						m_ckCertOrigem4.Image = m_ilCertificados.Images[MERCOSUL - 1];
						break;
					case CHILE:
						m_ckCertOrigem4.Text = "Chile";
						m_ckCertOrigem4.Visible = true;
						m_ckCertOrigem4.Image = m_ilCertificados.Images[CHILE - 1];
						break;
					case BOLIVIA:
						m_ckCertOrigem4.Text = "Bolívia";
						m_ckCertOrigem4.Visible = true;
						m_ckCertOrigem4.Image = m_ilCertificados.Images[BOLIVIA - 1];
						break;
					case APTR04:
						m_ckCertOrigem4.Text = "Aladi - Aptr04";
						m_ckCertOrigem4.Visible = true;
						m_ckCertOrigem4.Image = m_ilCertificados.Images[APTR04 - 1];
						break;
					case ACE39:
						m_ckCertOrigem4.Text = "Aladi - Ace39";
						m_ckCertOrigem4.Visible = true;
						m_ckCertOrigem4.Image = m_ilCertificados.Images[ACE39 - 1];
						break;
					case ANEXOIII:
						m_ckCertOrigem4.Text = "AnexoIII";
						m_ckCertOrigem4.Visible = true;
						m_ckCertOrigem4.Image = m_ilCertificados.Images[ANEXOIII - 1];
						break;
					case COMUM:
						m_ckCertOrigem4.Text = "Comum";
						m_ckCertOrigem4.Visible = true;
						m_ckCertOrigem4.Image = m_ilCertificados.Images[COMUM - 1];
						break;
					case FORMA:
						m_ckCertOrigem4.Text = "Form A";
						m_ckCertOrigem4.Visible = true;
						m_ckCertOrigem4.Image = m_ilCertificados.Images[COMUM - 1];
						break;
					case ACE59:
						m_ckCertOrigem4.Text = "Aladi - Ace59";
						m_ckCertOrigem4.Visible = true;
						m_ckCertOrigem4.Image = m_ilCertificados.Images[ACE39 - 1];
						break;
					default:
						m_ckCertOrigem4.Visible = false;
						break;
				}
				#endregion
				#region m_nCertOrig5
				switch(m_nCertOrig5)
				{
					case MERCOSUL:
						m_ckCertOrigem5.Text = "Mercosul";
						m_ckCertOrigem5.Visible = true;
						m_ckCertOrigem5.Image = m_ilCertificados.Images[MERCOSUL - 1];
						break;
					case CHILE:
						m_ckCertOrigem5.Text = "Chile";
						m_ckCertOrigem5.Visible = true;
						m_ckCertOrigem5.Image = m_ilCertificados.Images[CHILE - 1];
						break;
					case BOLIVIA:
						m_ckCertOrigem5.Text = "Bolívia";
						m_ckCertOrigem5.Visible = true;
						m_ckCertOrigem5.Image = m_ilCertificados.Images[BOLIVIA - 1];
						break;
					case APTR04:
						m_ckCertOrigem5.Text = "Aladi - Aptr04";
						m_ckCertOrigem5.Visible = true;
						m_ckCertOrigem5.Image = m_ilCertificados.Images[APTR04 - 1];
						break;
					case ACE39:
						m_ckCertOrigem5.Text = "Aladi - Ace39";
						m_ckCertOrigem5.Visible = true;
						m_ckCertOrigem5.Image = m_ilCertificados.Images[ACE39 - 1];
						break;
					case ANEXOIII:
						m_ckCertOrigem5.Text = "AnexoIII";
						m_ckCertOrigem5.Visible = true;
						m_ckCertOrigem5.Image = m_ilCertificados.Images[ANEXOIII - 1];
						break;
					case COMUM:
						m_ckCertOrigem5.Text = "Comum";
						m_ckCertOrigem5.Visible = true;
						m_ckCertOrigem5.Image = m_ilCertificados.Images[COMUM - 1];
						break;
					case FORMA:
						m_ckCertOrigem5.Text = "Form A";
						m_ckCertOrigem5.Visible = true;
						m_ckCertOrigem5.Image = m_ilCertificados.Images[COMUM - 1];
						break;
					case ACE59:
						m_ckCertOrigem5.Text = "Aladi - Ace59";
						m_ckCertOrigem5.Visible = true;
						m_ckCertOrigem5.Image = m_ilCertificados.Images[ACE39 - 1];
						break;
					default:
						m_ckCertOrigem5.Visible = false;
						break;
				}
				#endregion
			}
		#endregion 
		#region Lançando Produtos no Certificado
		private void insereProdutosNoCertificado(int nIdTipoCO)
		{
			try
			{
				mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem objProd = null;
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				switch(nIdTipoCO)
				{
					case MERCOSUL:
						objProd = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosul(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, ref m_ilBandeiras);
						objProd.ShowDialog();
						break;
					case BOLIVIA:
						objProd = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulBolivia(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, ref m_ilBandeiras);
						objProd.ShowDialog();
						break;
					case CHILE:
						objProd = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulChile(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, ref m_ilBandeiras);
						objProd.ShowDialog();
						break;
					case APTR04:
						objProd = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemAladiAptr04(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, ref m_ilBandeiras);
						objProd.ShowDialog();
						break;
					case ACE39:
						objProd = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulAce39(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, ref m_ilBandeiras);
						objProd.ShowDialog();
						break;
					case ANEXOIII:
						objProd = new mdlProdutosCertificadoOrigem.SemNormas.clsProdutosCertificadoOrigemAnexoIII(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, ref m_ilBandeiras);
						objProd.ShowDialog();
						break;
					case COMUM:
						objProd = new mdlProdutosCertificadoOrigem.SemNormas.clsProdutosCertificadoOrigemComum(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, ref m_ilBandeiras);
						objProd.ShowDialog();
						break;
					case FORMA:
						objProd = new mdlProdutosCertificadoOrigem.SemNormas.clsProdutosCertificadoOrigemFormA(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, ref m_ilBandeiras);
						objProd.ShowDialog();
						break;
					case ACE59:
						objProd = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulAce59(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, ref m_ilBandeiras);
						objProd.ShowDialog();
						break;
				}
				if ((objProd != null) && (objProd.m_bModificado))
					m_rcRelatorio.RefreshRelatorio();
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Métodos Referentes a ativação da Área de Produtos
		private bool bPrecisaAtivarAreaProdutos()
		{
            bool bRetorno = false;
			try
			{
				int nIdTipoCO = -1;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				arlCondicaoCampo.Add("idTipoCO");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				switch (m_nTipoRelatorio)
				{
					case 4: nIdTipoCO = 1;
						break;
					case 5: nIdTipoCO = 2;
						break;
					case 6: nIdTipoCO = 3;
						break;
					case 7: nIdTipoCO = 4;
						break;
					case 8: nIdTipoCO = 5;
						break;
					case 9: nIdTipoCO = 6;
						break;
					case 10: nIdTipoCO = 7;
						break;
					case 22: nIdTipoCO = 8;
						break;
					case 29:
						nIdTipoCO = 29;
						break;
					case 30:
						nIdTipoCO = 30;
						break;
				}
				arlCondicaoValor.Add(nIdTipoCO);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbProdutosCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbProdutosCertificadosOrigem.tbProdutosCertificadoOrigem.Rows.Count > 0)
					bRetorno = true;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return (bRetorno);
		} 
		#endregion
		#region Métodos SobreEscritos

		public override bool bCarregaIdRelatorio()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwRowTbCertificadosOrigem;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				arlCondicaoCampo.Add("nIdTipoCO");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				switch(m_nTipoRelatorio)
				{
					case RELATORIO_CO_MERCOSUL:
						arlCondicaoValor.Add(MERCOSUL);
						break;
					case RELATORIO_CO_BOLIVIA:
						arlCondicaoValor.Add(BOLIVIA);
						break;
					case RELATORIO_CO_CHILE:
						arlCondicaoValor.Add(CHILE);
						break;
					case RELATORIO_CO_APTR04:
						arlCondicaoValor.Add(APTR04);
						break;
					case RELATORIO_CO_ACE39:
						arlCondicaoValor.Add(ACE39);
						break;
					case RELATORIO_CO_ANEXOIII:
						arlCondicaoValor.Add(ANEXOIII);
						break;
					case RELATORIO_CO_COMUM:
						arlCondicaoValor.Add(COMUM);
						break;
					case RELATORIO_CO_FORMA:
						arlCondicaoValor.Add(FORMA);
						break;
					case RELATORIO_CO_ACE59:
						arlCondicaoValor.Add(ACE59);
						break;
				}
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
				{
					dtrwRowTbCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows[0];
					if (!dtrwRowTbCertificadosOrigem.IsnIdRelatorioNull())
                        m_nIdRelatorio = dtrwRowTbCertificadosOrigem.nIdRelatorio;
					else
						m_nIdRelatorio = -1;
					return bRelatorioExiste();
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;
		}

		protected override bool bSalvaIdRelatorio()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwRowTbCertificadosOrigem;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				arlCondicaoCampo.Add("nIdTipoCO");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				switch(m_nTipoRelatorio)
				{
					case RELATORIO_CO_MERCOSUL:
						arlCondicaoValor.Add(MERCOSUL);
						break;
					case RELATORIO_CO_BOLIVIA:
						arlCondicaoValor.Add(BOLIVIA);
						break;
					case RELATORIO_CO_CHILE:
						arlCondicaoValor.Add(CHILE);
						break;
					case RELATORIO_CO_APTR04:
						arlCondicaoValor.Add(APTR04);
						break;
					case RELATORIO_CO_ACE39:
						arlCondicaoValor.Add(ACE39);
						break;
					case RELATORIO_CO_ANEXOIII:
						arlCondicaoValor.Add(ANEXOIII);
						break;
					case RELATORIO_CO_COMUM:
						arlCondicaoValor.Add(COMUM);
						break;
					case RELATORIO_CO_FORMA:
						arlCondicaoValor.Add(FORMA);
						break;
					case RELATORIO_CO_ACE59:
						arlCondicaoValor.Add(ACE59);
						break;
				}
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
				{
					dtrwRowTbCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows[0];
					dtrwRowTbCertificadosOrigem.nIdRelatorio = m_nIdRelatorio;
					m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
					return true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;
		}

		protected override bool bTrocarIdioma()
		{
			return true;
		}

		public override bool bCarregaIdIdioma()
		{
			m_nIdIdioma = 1;
			return true;
		}
		protected override void vIncrementaNumeroImpressoes()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwRowTbCertificadosOrigem;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				arlCondicaoCampo.Add("nIdTipoCO");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				switch(m_nTipoRelatorio)
				{
					case RELATORIO_CO_MERCOSUL:
						arlCondicaoValor.Add(MERCOSUL);
						break;
					case RELATORIO_CO_BOLIVIA:
						arlCondicaoValor.Add(BOLIVIA);
						break;
					case RELATORIO_CO_CHILE:
						arlCondicaoValor.Add(CHILE);
						break;
					case RELATORIO_CO_APTR04:
						arlCondicaoValor.Add(APTR04);
						break;
					case RELATORIO_CO_ACE39:
						arlCondicaoValor.Add(ACE39);
						break;
					case RELATORIO_CO_ANEXOIII:
						arlCondicaoValor.Add(ANEXOIII);
						break;
					case RELATORIO_CO_COMUM:
						arlCondicaoValor.Add(COMUM);
						break;
					case RELATORIO_CO_FORMA:
						arlCondicaoValor.Add(FORMA);
						break;
					case RELATORIO_CO_ACE59:
						arlCondicaoValor.Add(ACE59);
						break;
				}
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
				{
					dtrwRowTbCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows[0];
					if (!dtrwRowTbCertificadosOrigem.IsnImpressoesNull())
						dtrwRowTbCertificadosOrigem.nImpressoes++;
					else
						dtrwRowTbCertificadosOrigem.nImpressoes = 1;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		#endregion

		#region Eventos
			#region Botoes
				private void m_btAssistente_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlCriacaoDocumentos.Assistentes.clsAssistente cls_Assistente = null;
					switch(m_nTipoRelatorio)
					{
						case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosul:
							cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteCOMercosul(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
							break;
						case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosulBO:
							cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteCOBolivia(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
							break;
						case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosulCH:
							cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteCOMercosulChile(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
							break;
						case (int)mdlConstantes.Relatorio.CertificadoOrigemAladiAptr04:
							cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteCOAladiAptr04(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
							break;
						case (int)mdlConstantes.Relatorio.CertificadoOrigemAladiAce39:
							cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteCOAladiAce39(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
							break;
						case (int)mdlConstantes.Relatorio.CertificadoOrigemComum:
							cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteCOComum(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
							break;
						case (int)mdlConstantes.Relatorio.CertificadoOrigemAladiAce59:
							//TODO:Work over here
							//cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteCOComum(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
							break;
					}
					if (cls_Assistente != null)
					{
						if(cls_Assistente.ShowDialog())
							bMostrarRelatorio();
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_btConfiguracoes_Click(object sender, System.EventArgs e)
				{
					if (ShowDialogConfiguracoes())
					{
						bMostrarRelatorio();
					}
				}
			#endregion
		#endregion

		#region ShowDialogConfiguracoes
			private bool ShowDialogConfiguracoes()
			{
				frmFConfiguracoes formFConfiguracoes = new frmFConfiguracoes(m_strEnderecoExecutavel);
				bool bMostrarProdutos,bMostrarProdutosFilhos;
				bCarregaDadosConfiguracao(out bMostrarProdutos,out bMostrarProdutosFilhos);
				formFConfiguracoes.MostrarProdutos = bMostrarProdutos;
				formFConfiguracoes.MostrarProdutosFilhos = bMostrarProdutosFilhos;
				formFConfiguracoes.ShowDialog();
				if (formFConfiguracoes.Modificado)
					return(bSalvaDadosConfiguracao(formFConfiguracoes.MostrarProdutos,formFConfiguracoes.MostrarProdutosFilhos));
				return(false);
			}

			private int nRetornaIdTipoCo(int nIdTipoRelatorio)
			{
				int nRetorno = 0;
				switch(nIdTipoRelatorio)
				{
					case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosul:
						nRetorno = 1;
						break;
					case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosulBO:
						nRetorno = 2;
						break;
					case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosulCH:
						nRetorno = 3;
						break;
					case (int)mdlConstantes.Relatorio.CertificadoOrigemAladiAptr04:
						nRetorno = 4;
						break;
					case (int)mdlConstantes.Relatorio.CertificadoOrigemAladiAce39:
						nRetorno = 5;
						break;
					case (int)mdlConstantes.Relatorio.CertificadoOrigemAnexoIII:
						nRetorno = 6;
						break;
					case (int)mdlConstantes.Relatorio.CertificadoOrigemComum:
						nRetorno = 7;
						break;
					case (int)mdlConstantes.Relatorio.CertificadoOrigemAladiAce59:
						nRetorno = 29;
						break;
					case (int)mdlConstantes.Relatorio.CertificadoOrigemFormA:
						nRetorno = 30;
						break;
				}
				return(nRetorno);
			}

			private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem GetTbCertificadosOrigem()
			{
				System.Collections.ArrayList arlCondicaoCampo = new ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				arlCondicaoCampo.Add("nIdTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nRetornaIdTipoCo(m_nTipoRelatorio));

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private bool bCarregaDadosConfiguracao(out bool bMostrarProdutos,out bool bMostrarProdutosFilhos)
			{
				bMostrarProdutos = false;
				bMostrarProdutosFilhos = false;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadosOrigem = GetTbCertificadosOrigem();
				if (typDatSetCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificado = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)typDatSetCertificadosOrigem.tbCertificadosOrigem.Rows[0];
					if (!dtrwCertificado.IsbMostrarProdutosNull())
						bMostrarProdutos = dtrwCertificado.bMostrarProdutos;
					if (!dtrwCertificado.IsbMostrarProdutosFilhosNull())
						bMostrarProdutosFilhos = dtrwCertificado.bMostrarProdutosFilhos;
					return(true);
				}
				return(false);
			}

			private bool bSalvaDadosConfiguracao(bool bMostrarProdutos,bool bMostrarProdutosFilhos)
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadosOrigem = GetTbCertificadosOrigem();
				if (typDatSetCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificado = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)typDatSetCertificadosOrigem.tbCertificadosOrigem.Rows[0];
					dtrwCertificado.bMostrarProdutos = bMostrarProdutos;
					dtrwCertificado.bMostrarProdutosFilhos = bMostrarProdutosFilhos;
					m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(typDatSetCertificadosOrigem);
					return(m_cls_dba_ConnectionDB.Erro == null);
				}
				return(false);
			}
		#endregion
	}
}

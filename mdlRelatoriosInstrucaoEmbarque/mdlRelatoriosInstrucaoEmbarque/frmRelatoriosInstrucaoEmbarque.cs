using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosInstrucaoEmbarque
{
	/// <summary>
	/// Summary description for frmRelatoriosInstrucaoEmbarque.
	/// </summary>
	public class frmRelatoriosInstrucaoEmbarque : mdlRelatoriosBase.frmRelatoriosBase
	{
        #region Atributes
			private bool m_bActivated = true;

			private System.Windows.Forms.Button m_btAssistente;
			private System.Windows.Forms.CheckBox m_ckOrdemEmbarque;
			private System.Windows.Forms.CheckBox m_ckGuiaEntrada;
			private System.Windows.Forms.CheckBox m_ckReserva;
			private System.Windows.Forms.PictureBox m_picBackground;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor e Desctructor
			public frmRelatoriosInstrucaoEmbarque(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD, ref System.Windows.Forms.Form mdiParent,string strEnderecoExecutavel,int nIdExportador,string strIdPE) : base(ref tratadorErro,ref conexaoBD, ref mdiParent,strEnderecoExecutavel,15,nIdExportador,strIdPE)
			{
				InitializeComponent();
				bResizeForm();
				m_strSessaoArquivoConfiguracao = "SiscobrasCorSecundaria";
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRelatoriosInstrucaoEmbarque));
			this.m_btAssistente = new System.Windows.Forms.Button();
			this.m_ckOrdemEmbarque = new System.Windows.Forms.CheckBox();
			this.m_ckGuiaEntrada = new System.Windows.Forms.CheckBox();
			this.m_ckReserva = new System.Windows.Forms.CheckBox();
			this.m_picBackground = new System.Windows.Forms.PictureBox();
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
			this.m_btEnviarImagemEmail.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btEnviarImagemEmail.Name = "m_btEnviarImagemEmail";
			this.m_ttDica.SetToolTip(this.m_btEnviarImagemEmail, "Enviar via e-mail ");
			// 
			// m_btIdioma
			// 
			this.m_btIdioma.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btIdioma.Name = "m_btIdioma";
			this.m_ttDica.SetToolTip(this.m_btIdioma, "Alterar idioma ");
			this.m_btIdioma.Visible = false;
			// 
			// m_btSalvarImagem
			// 
			this.m_btSalvarImagem.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btSalvarImagem.Name = "m_btSalvarImagem";
			this.m_ttDica.SetToolTip(this.m_btSalvarImagem, "Salvar imagem");
			// 
			// m_btModoEdicao
			// 
			this.m_btModoEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btModoEdicao.Name = "m_btModoEdicao";
			this.m_ttDica.SetToolTip(this.m_btModoEdicao, "Editar ");
			// 
			// m_btTrocarRelatorio
			// 
			this.m_btTrocarRelatorio.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btTrocarRelatorio.Name = "m_btTrocarRelatorio";
			this.m_ttDica.SetToolTip(this.m_btTrocarRelatorio, "Trocar formato ");
			// 
			// m_btUltimaPagina
			// 
			this.m_btUltimaPagina.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btUltimaPagina.Name = "m_btUltimaPagina";
			this.m_ttDica.SetToolTip(this.m_btUltimaPagina, "Ultima página");
			// 
			// m_btPrimeiraPagima
			// 
			this.m_btPrimeiraPagima.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btPrimeiraPagima.Name = "m_btPrimeiraPagima";
			this.m_ttDica.SetToolTip(this.m_btPrimeiraPagima, "Primeira página");
			// 
			// m_lbPaginaAtual
			// 
			this.m_lbPaginaAtual.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_lbPaginaAtual.Name = "m_lbPaginaAtual";
			// 
			// m_btPaginaAnterior
			// 
			this.m_btPaginaAnterior.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btPaginaAnterior.Name = "m_btPaginaAnterior";
			this.m_ttDica.SetToolTip(this.m_btPaginaAnterior, "Página anterior");
			// 
			// m_btProximaPagina
			// 
			this.m_btProximaPagina.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btProximaPagina.Name = "m_btProximaPagina";
			this.m_ttDica.SetToolTip(this.m_btProximaPagina, "Página posterior");
			// 
			// m_vsbVertical
			// 
			this.m_vsbVertical.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_vsbVertical.Name = "m_vsbVertical";
			// 
			// m_hsbHorizontal
			// 
			this.m_hsbHorizontal.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_hsbHorizontal.Name = "m_hsbHorizontal";
			// 
			// m_btZoomMenos
			// 
			this.m_btZoomMenos.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btZoomMenos.Name = "m_btZoomMenos";
			// 
			// m_btZoomMais
			// 
			this.m_btZoomMais.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btZoomMais.Name = "m_btZoomMais";
			// 
			// m_gbBarraSuperior
			// 
			this.m_gbBarraSuperior.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_gbBarraSuperior.Controls.Add(this.m_ckGuiaEntrada);
			this.m_gbBarraSuperior.Controls.Add(this.m_ckReserva);
			this.m_gbBarraSuperior.Controls.Add(this.m_ckOrdemEmbarque);
			this.m_gbBarraSuperior.Controls.Add(this.m_btAssistente);
			this.m_gbBarraSuperior.Name = "m_gbBarraSuperior";
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_btAssistente, 0);
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_ckOrdemEmbarque, 0);
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_ckReserva, 0);
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_ckGuiaEntrada, 0);
			// 
			// m_gbBarraInferior
			// 
			this.m_gbBarraInferior.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_gbBarraInferior.Name = "m_gbBarraInferior";
			// 
			// m_btImprimir
			// 
			this.m_btImprimir.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btImprimir.Name = "m_btImprimir";
			// 
			// m_gbBarraInferiorEdicao
			// 
			this.m_gbBarraInferiorEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_gbBarraInferiorEdicao.Name = "m_gbBarraInferiorEdicao";
			// 
			// m_gbBarraSuperiorEdicao
			// 
			this.m_gbBarraSuperiorEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_gbBarraSuperiorEdicao.Name = "m_gbBarraSuperiorEdicao";
			// 
			// m_btModoVisualizacao
			// 
			this.m_btModoVisualizacao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btModoVisualizacao.Name = "m_btModoVisualizacao";
			// 
			// m_btZoomMaisEdicao
			// 
			this.m_btZoomMaisEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btZoomMaisEdicao.Name = "m_btZoomMaisEdicao";
			// 
			// m_btZoomMenosEdicao
			// 
			this.m_btZoomMenosEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btZoomMenosEdicao.Name = "m_btZoomMenosEdicao";
			// 
			// m_btSalvarEdicao
			// 
			this.m_btSalvarEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btSalvarEdicao.Name = "m_btSalvarEdicao";
			// 
			// m_btTrocarRelatorioEdicao
			// 
			this.m_btTrocarRelatorioEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btTrocarRelatorioEdicao.Name = "m_btTrocarRelatorioEdicao";
			// 
			// m_btSalvarComoEdicao
			// 
			this.m_btSalvarComoEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btSalvarComoEdicao.Name = "m_btSalvarComoEdicao";
			// 
			// m_btNovoEdicao
			// 
			this.m_btNovoEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btNovoEdicao.Name = "m_btNovoEdicao";
			// 
			// m_btMargensEdicao
			// 
			this.m_btMargensEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btMargensEdicao.Name = "m_btMargensEdicao";
			// 
			// m_btExcluirEdicao
			// 
			this.m_btExcluirEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
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
			// m_btAssistente
			// 
			this.m_btAssistente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btAssistente.Image = ((System.Drawing.Image)(resources.GetObject("m_btAssistente.Image")));
			this.m_btAssistente.Location = new System.Drawing.Point(18, 10);
			this.m_btAssistente.Name = "m_btAssistente";
			this.m_btAssistente.Size = new System.Drawing.Size(24, 24);
			this.m_btAssistente.TabIndex = 59;
			this.m_ttDica.SetToolTip(this.m_btAssistente, "Assistente");
			this.m_btAssistente.Click += new System.EventHandler(this.m_btAssistente_Click);
			// 
			// m_ckOrdemEmbarque
			// 
			this.m_ckOrdemEmbarque.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckOrdemEmbarque.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckOrdemEmbarque.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckOrdemEmbarque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_ckOrdemEmbarque.Location = new System.Drawing.Point(195, 11);
			this.m_ckOrdemEmbarque.Name = "m_ckOrdemEmbarque";
			this.m_ckOrdemEmbarque.Size = new System.Drawing.Size(144, 25);
			this.m_ckOrdemEmbarque.TabIndex = 60;
			this.m_ckOrdemEmbarque.Text = "Ordem de Embarque";
			this.m_ckOrdemEmbarque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ckOrdemEmbarque.CheckedChanged += new System.EventHandler(this.m_ckOrdemEmbarque_CheckedChanged);
			// 
			// m_ckGuiaEntrada
			// 
			this.m_ckGuiaEntrada.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckGuiaEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckGuiaEntrada.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckGuiaEntrada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_ckGuiaEntrada.Location = new System.Drawing.Point(347, 11);
			this.m_ckGuiaEntrada.Name = "m_ckGuiaEntrada";
			this.m_ckGuiaEntrada.Size = new System.Drawing.Size(144, 25);
			this.m_ckGuiaEntrada.TabIndex = 62;
			this.m_ckGuiaEntrada.Text = "Guia de Entrada";
			this.m_ckGuiaEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ckGuiaEntrada.CheckedChanged += new System.EventHandler(this.m_ckGuiaEntrada_CheckedChanged);
			// 
			// m_ckReserva
			// 
			this.m_ckReserva.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckReserva.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckReserva.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckReserva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_ckReserva.Location = new System.Drawing.Point(43, 11);
			this.m_ckReserva.Name = "m_ckReserva";
			this.m_ckReserva.Size = new System.Drawing.Size(144, 25);
			this.m_ckReserva.TabIndex = 61;
			this.m_ckReserva.Text = "Reserva (Booking)";
			this.m_ckReserva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ckReserva.CheckedChanged += new System.EventHandler(this.m_ckReserva_CheckedChanged);
			// 
			// m_picBackground
			// 
			this.m_picBackground.Image = ((System.Drawing.Image)(resources.GetObject("m_picBackground.Image")));
			this.m_picBackground.Location = new System.Drawing.Point(100, 60);
			this.m_picBackground.Name = "m_picBackground";
			this.m_picBackground.Size = new System.Drawing.Size(500, 300);
			this.m_picBackground.TabIndex = 9;
			this.m_picBackground.TabStop = false;
			// 
			// frmRelatoriosInstrucaoEmbarque
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(798, 598);
			this.Controls.Add(this.m_picBackground);
			this.Name = "frmRelatoriosInstrucaoEmbarque";
			this.Load += new System.EventHandler(this.frmRelatoriosInstrucaoEmbarque_Load);
			this.Controls.SetChildIndex(this.m_picBackground, 0);
			this.Controls.SetChildIndex(this.m_gbBarraSuperior, 0);
			this.Controls.SetChildIndex(this.m_gbBarraInferior, 0);
			this.Controls.SetChildIndex(this.m_rcRelatorio, 0);
			this.Controls.SetChildIndex(this.m_vsbVertical, 0);
			this.Controls.SetChildIndex(this.m_hsbHorizontal, 0);
			this.Controls.SetChildIndex(this.m_gbBarraInferiorEdicao, 0);
			this.Controls.SetChildIndex(this.m_gbBarraSuperiorEdicao, 0);
			this.m_gbBarraSuperior.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmRelatoriosInstrucaoEmbarque_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					vRefreshBotoes();
					vRefreshInterface();
				}
			#endregion
			#region	CheckBoxes
				private void m_ckOrdemEmbarque_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bActivated)
					{
						m_bActivated = false;
						if (m_ckOrdemEmbarque.Checked)
						{
							this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
							m_ckReserva.Checked = false;
							m_ckGuiaEntrada.Checked = false;
							m_nTipoRelatorio = mdlConstantes.clsConstantes.RELATORIO_ORDEM_EMBARQUE;
							m_rcRelatorio.ePageNumberChanged += new ReportCanvasPackage.ReportCanvas.delPageNumberChanged(base.m_rcRelatorio_ePageNumberChanged);
							m_rcRelatorio.TotalPages = -1;
							bCriaRegistro();
							if (!bCarregaIdRelatorio())
								carregaIdRelatorioDefault();
							bMostrarRelatorio();
							this.Cursor = System.Windows.Forms.Cursors.Default;
						}
						vRefreshInterface();
						m_bActivated = true;
					}
				}

				private void m_ckReserva_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bActivated)
					{
						m_bActivated = false;
						if (m_ckReserva.Checked)
						{
							this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
							m_ckOrdemEmbarque.Checked = false;
							m_ckGuiaEntrada.Checked = false;
							m_nTipoRelatorio = mdlConstantes.clsConstantes.RELATORIO_RESERVA;
							m_rcRelatorio.ePageNumberChanged += new ReportCanvasPackage.ReportCanvas.delPageNumberChanged(base.m_rcRelatorio_ePageNumberChanged);
							m_rcRelatorio.TotalPages = -1;
							bCriaRegistro();
							if (!bCarregaIdRelatorio())
								carregaIdRelatorioDefault();
							bMostrarRelatorio();
							this.Cursor = System.Windows.Forms.Cursors.Default;
						}
						vRefreshInterface();
						m_bActivated = true;
					}
				}

				private void m_ckGuiaEntrada_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bActivated)
					{
						m_bActivated = false;
						if (m_ckGuiaEntrada.Checked)
						{
							this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
							m_ckOrdemEmbarque.Checked = false;
							m_ckReserva.Checked = false;
							m_nTipoRelatorio = mdlConstantes.clsConstantes.RELATORIO_GUIA_ENTRADA;
							mdlRelatoriosCallBackAreaProdutos.clsRelatoriosCallBackAreaProdutos clsCallBack = new mdlRelatoriosCallBackAreaProdutos.clsRelatoriosCallBackAreaProdutos(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
							int nTotalPaginas = clsCallBack.nRetornaTotalPaginasAreaProdutos(m_nIdExportador,m_strIdCodigo,mdlConstantes.clsConstantes.RELATORIO_GUIA_ENTRADA);
							if (nTotalPaginas > 0)
							{
								m_rcRelatorio.TotalPages = nTotalPaginas;
								m_rcRelatorio.ePageNumberChanged += new ReportCanvasPackage.ReportCanvas.delPageNumberChanged(this.m_rcRelatorio_ePageNumberChanged);
								bCriaRegistro();
								if (!bCarregaIdRelatorio())
									carregaIdRelatorioDefault();
								bMostrarRelatorio();
							}else{
								m_ckGuiaEntrada.Checked = false;
								mdlMensagens.clsMensagens.ShowInformation("Antes de abrir a Guia de Entrada, é preciso informar o container, na Reserva(Booking).");
							}
							this.Cursor = System.Windows.Forms.Cursors.Default;
						}
						vRefreshInterface();
						m_bActivated = true;
					}
				}
			#endregion
			#region Botoes
				private void m_btAssistente_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlCriacaoDocumentos.Assistentes.clsAssistente cls_Assistente = null;
					switch(m_nTipoRelatorio)
					{
						case (int)mdlConstantes.Relatorio.Reserva:
							cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteReserva(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
							break;
						case (int)mdlConstantes.Relatorio.InstrucaoEmbarque:
							cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteOrdemEmbarque(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
							break;
						case (int)mdlConstantes.Relatorio.GuiaEntrada:
							cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteGuiaEntrada(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
							break;
					}
					if (cls_Assistente != null)
					{
						if(cls_Assistente.ShowDialog())
							bMostrarRelatorio();
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
        #endregion

		#region Overrides
			public override bool bCarregaIdRelatorio()
			{
				bool bRetorno = false;
				switch(m_nTipoRelatorio)
				{
					case mdlConstantes.clsConstantes.RELATORIO_ORDEM_EMBARQUE:
						bRetorno = bCarregaIdRelatorioOrdemEmbarque();
						break;
					case mdlConstantes.clsConstantes.RELATORIO_RESERVA:
						bRetorno = bCarregaIdRelatorioReserva();
						break;
					case mdlConstantes.clsConstantes.RELATORIO_GUIA_ENTRADA:
						bRetorno = bCarregaIdRelatorioGuiaEntrada();
						break;
				}
				return(bRetorno);
			}

			private bool bCarregaIdRelatorioOrdemEmbarque()
			{
				bool bRetorno = false;
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
				mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque typDatSetTbInstrucoesEmbarque = m_cls_dba_ConnectionDB.GetTbInstrucoesEmbarque(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwRowTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
					if (!dtrwRowTbInstrucoesEmbarque.IsnIdRelatorioNull())
						m_nIdRelatorio = dtrwRowTbInstrucoesEmbarque.nIdRelatorio;
					else
						m_nIdRelatorio = -1;
					return bRelatorioExiste();
				}
				return(bRetorno);
			}

			private bool bCarregaIdRelatorioReserva()
			{
				bool bRetorno = false;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strIdPe");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbReservas typDatSetReservas = m_cls_dba_ConnectionDB.GetTbReservas(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (typDatSetReservas.tbReservas.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow dtrwRowReserva = (mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow)typDatSetReservas.tbReservas.Rows[0];
					if (!dtrwRowReserva.IsnIdRelatorioNull())
						m_nIdRelatorio = dtrwRowReserva.nIdRelatorio;
					else
						m_nIdRelatorio = -1;
					return bRelatorioExiste();
				}
				return(bRetorno);
			}

			private bool bCarregaIdRelatorioGuiaEntrada()
			{
				bool bRetorno = false;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strIdPe");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada typDatSetGuiasEntrada = m_cls_dba_ConnectionDB.GetTbGuiasEntrada(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (typDatSetGuiasEntrada.tbGuiasEntrada.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow dtrwRowGuiasEntrada = (mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow)typDatSetGuiasEntrada.tbGuiasEntrada.Rows[0];
					if (!dtrwRowGuiasEntrada.IsnIdRelatorioNull())
						m_nIdRelatorio = dtrwRowGuiasEntrada.nIdRelatorio;
					else
						m_nIdRelatorio = -1;
					return bRelatorioExiste();
				}
				return(bRetorno);
			}

			protected override bool bSalvaIdRelatorio()
			{
				bool bRetorno = false;
				switch(m_nTipoRelatorio)
				{
					case mdlConstantes.clsConstantes.RELATORIO_ORDEM_EMBARQUE:
						bRetorno = bSalvaIdRelatorioOrdemEmbarque();
						break;
					case mdlConstantes.clsConstantes.RELATORIO_RESERVA:
						bRetorno = bSalvaIdRelatorioReserva();
						break;
					case mdlConstantes.clsConstantes.RELATORIO_GUIA_ENTRADA:
						bRetorno = bSalvaIdRelatorioGuiaEntrada();
						break;
				}
				return(bRetorno);
			}

			private bool bSalvaIdRelatorioOrdemEmbarque()
			{
				bool bRetorno = false;
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
				mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque typDatSetTbInstrucoesEmbarque = m_cls_dba_ConnectionDB.GetTbInstrucoesEmbarque(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwRowTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
					dtrwRowTbInstrucoesEmbarque.nIdRelatorio = m_nIdRelatorio;
					m_cls_dba_ConnectionDB.SetTbInstrucoesEmbarque(typDatSetTbInstrucoesEmbarque);
					bRetorno = (m_cls_dba_ConnectionDB.Erro == null);
				}
				return(bRetorno);
			}

			private bool bSalvaIdRelatorioReserva()
			{
				bool bRetorno = false;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strIdPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbReservas typDatSetReservas = m_cls_dba_ConnectionDB.GetTbReservas(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (typDatSetReservas.tbReservas.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow dtrwRowReserva = (mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow)typDatSetReservas.tbReservas.Rows[0];
					dtrwRowReserva.nIdRelatorio = m_nIdRelatorio;
					m_cls_dba_ConnectionDB.SetTbReservas(typDatSetReservas);
					bRetorno = (m_cls_dba_ConnectionDB.Erro == null);
				}
				return(bRetorno);
			}

			private bool bSalvaIdRelatorioGuiaEntrada()
			{
				bool bRetorno = false;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strIdPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada typDatSetGuiasEntrada = m_cls_dba_ConnectionDB.GetTbGuiasEntrada(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (typDatSetGuiasEntrada.tbGuiasEntrada.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow dtrwRowGuiaEntrada = (mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow)typDatSetGuiasEntrada.tbGuiasEntrada.Rows[0];
					dtrwRowGuiaEntrada.nIdRelatorio = m_nIdRelatorio;
					m_cls_dba_ConnectionDB.SetTbGuiasEntrada(typDatSetGuiasEntrada);
					bRetorno = (m_cls_dba_ConnectionDB.Erro == null);
				}
				return(bRetorno);
			}

			protected override bool bTrocarIdioma()
			{
				return false;
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
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwRowTbInstrucoesEmbarque;
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
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque typDatSetTbInstrucoesEmbarque = m_cls_dba_ConnectionDB.GetTbInstrucoesEmbarque(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
					if (typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
					{
						dtrwRowTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
						if (!dtrwRowTbInstrucoesEmbarque.IsnImpressoesNull())
							dtrwRowTbInstrucoesEmbarque.nImpressoes++;
						else
							dtrwRowTbInstrucoesEmbarque.nImpressoes = 1;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
		#endregion
		#region ReportCanvas
			protected override void m_rcRelatorio_ePageNumberChanged(object sender, EventArgs e)
			{
				base.m_rcRelatorio_ePageNumberChanged (sender, e);
				if (m_nTipoRelatorio == mdlConstantes.clsConstantes.RELATORIO_GUIA_ENTRADA)
				{
					System.Collections.ArrayList arlFields = new System.Collections.ArrayList();
					// Container Parameter
					arlFields.Add(7227);
					arlFields.Add(7327);
					arlFields.Add(7427);
					arlFields.Add(7527);
					arlFields.Add(7627);
					arlFields.Add(7727);
					arlFields.Add(7827);
					arlFields.Add(7927);
					arlFields.Add(8027);
					arlFields.Add(8127);
					arlFields.Add(8227);
					arlFields.Add(8327);
					arlFields.Add(8427);
					arlFields.Add(8627);
					// Transportadoras
					arlFields.Add(128);
					arlFields.Add(228);
					arlFields.Add(328);
					arlFields.Add(428);
					arlFields.Add(528);
					arlFields.Add(628);
					arlFields.Add(728);
					arlFields.Add(828);
					arlFields.Add(928);
					arlFields.Add(1028);
					arlFields.Add(1128);
					arlFields.Add(1228);
					arlFields.Add(1328);
					arlFields.Add(1428);
					arlFields.Add(1528);
					arlFields.Add(1628);
					arlFields.Add(1728);
					arlFields.Add(1828);
					m_rcRelatorio.vLoadFields(ref arlFields);
				}
			}
		#endregion

		#region Interface
			private void vRefreshBotoes()
			{
				bool bTemp;
				double dTemp;
				string strTemp;
				string strMeioTransporte;
				mdlIncoterm.clsIncoterm cls_Incoterm = new mdlIncoterm.Faturas.clsIncotermComercial(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
				cls_Incoterm.retornaValores(out strMeioTransporte,out dTemp,out dTemp,out bTemp,out dTemp,out dTemp,out dTemp,out dTemp,out strTemp,out dTemp,out dTemp,out bTemp,out strTemp);
				switch(strMeioTransporte)
				{
					case "":
						m_ckReserva.Visible = false;
						m_ckOrdemEmbarque.Visible = false;
						m_ckGuiaEntrada.Visible = false;

						break;
					case "Marítimo":
						break;
					default:
						m_ckReserva.Visible = false;
						m_ckGuiaEntrada.Visible = false;
						m_ckOrdemEmbarque.Location = m_ckReserva.Location;
						m_ckOrdemEmbarque.Checked = true;
						break;
				}
			}

			private void vRefreshInterface()
			{
				if ((m_ckOrdemEmbarque.Checked) || (m_ckReserva.Checked) || (m_ckGuiaEntrada.Checked))
				{
					m_rcRelatorio.Visible = true;
					m_gbBarraInferior.Visible = true;
					m_hsbHorizontal.Visible = true;
					m_vsbVertical.Visible = true;
					m_picBackground.Visible = false;
					m_btAssistente.Enabled = true;
				}
				else
				{
					m_picBackground.Visible = true;
					m_rcRelatorio.Visible = false;
					m_gbBarraInferior.Visible = false;
					m_hsbHorizontal.Visible = false;
					m_vsbVertical.Visible = false;
					m_btAssistente.Enabled = false;
				}
			}
		#endregion
		#region Criacao do Registro
			private bool bCriaRegistro()
			{
				bool bRetorno = false;
				switch(m_nTipoRelatorio)
				{
					case mdlConstantes.clsConstantes.RELATORIO_ORDEM_EMBARQUE:
						bRetorno = bCriaRegistroOrdemEmbarque();
						break;
					case mdlConstantes.clsConstantes.RELATORIO_RESERVA:
						bRetorno = bCriaRegistroReserva();
						break;
					case mdlConstantes.clsConstantes.RELATORIO_GUIA_ENTRADA:
						bRetorno = bCriaRegistroGuiaEntrada();
						break;
				}
				return(bRetorno);
			}

			private bool bCriaRegistroOrdemEmbarque()
			{
				try
				{
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
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque typDatSetInstrucoesEmbarque = m_cls_dba_ConnectionDB.GetTbInstrucoesEmbarque(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
					if (typDatSetInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count == 0)
					{
						if (!bCarregaIdRelatorio())
							carregaIdRelatorioDefault();

						int nIdAssinatura = 0;
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
						if (typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
						{
							mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
							if (!dtrwTbFaturasComerciais.IsidAssinaturaNull())
								nIdAssinatura = dtrwTbFaturasComerciais.idAssinatura;
						}
						mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwRowTbInstrucoesEmbarque = typDatSetInstrucoesEmbarque.tbInstrucoesEmbarque.NewtbInstrucoesEmbarqueRow();
						dtrwRowTbInstrucoesEmbarque.idExportador = m_nIdExportador;
						dtrwRowTbInstrucoesEmbarque.idPE = m_strIdCodigo;
						dtrwRowTbInstrucoesEmbarque.nIdRelatorio = m_nIdRelatorio;
						dtrwRowTbInstrucoesEmbarque.dtDataEmissao = System.DateTime.Now.Date;
						dtrwRowTbInstrucoesEmbarque.nIdAssinatura = nIdAssinatura;
						dtrwRowTbInstrucoesEmbarque.bPermitirEmbarquesParciais = true;
						dtrwRowTbInstrucoesEmbarque.bPermitirTransbordo = true;
						dtrwRowTbInstrucoesEmbarque.nImpressoes = 0;
						typDatSetInstrucoesEmbarque.tbInstrucoesEmbarque.AddtbInstrucoesEmbarqueRow(dtrwRowTbInstrucoesEmbarque);
						m_cls_dba_ConnectionDB.SetTbInstrucoesEmbarque(typDatSetInstrucoesEmbarque);
						mdlNumero.clsNumero obj = new mdlNumero.InstrucoesEmbarque.clsNumeroInstrucoesEmbarque(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo);
						obj.salvaDiretoSemMostrarInterface();
						obj = null;
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

			private bool bCriaRegistroReserva()
			{
				bool bRetorno = false;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strIdPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbReservas typDatSetReservas = m_cls_dba_ConnectionDB.GetTbReservas(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (typDatSetReservas.tbReservas.Rows.Count == 0)
				{
					if (!bCarregaIdRelatorio())
						carregaIdRelatorioDefault();

					int nIdAssinatura = 0;
					arlCondicaoCampo.Clear();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoCampo.Add("idPE");
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
					if (typDatSetFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)typDatSetFaturasComerciais.tbFaturasComerciais.Rows[0];
						if (!dtrwFaturaComercial.IsidAssinaturaNull())
							nIdAssinatura = dtrwFaturaComercial.idAssinatura;
					}
					mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow dtrwReserva = typDatSetReservas.tbReservas.NewtbReservasRow();
					dtrwReserva.nIdExportador = m_nIdExportador;
					dtrwReserva.strIdPe = m_strIdCodigo;
					dtrwReserva.nIdRelatorio = m_nIdRelatorio;
					dtrwReserva.dtEmissao = System.DateTime.Now.Date;
					dtrwReserva.nIdAssinatura = nIdAssinatura;
					dtrwReserva.nImpressoes = 0;
					typDatSetReservas.tbReservas.AddtbReservasRow(dtrwReserva);
					m_cls_dba_ConnectionDB.SetTbReservas(typDatSetReservas);
					bRetorno = (m_cls_dba_ConnectionDB == null);
				}
				return(bRetorno);
			}

			private bool bCriaRegistroGuiaEntrada()
			{
				bool bRetorno = false;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strIdPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada typDatSetGuiasEntrada = m_cls_dba_ConnectionDB.GetTbGuiasEntrada(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (typDatSetGuiasEntrada.tbGuiasEntrada.Rows.Count == 0)
				{
					if (!bCarregaIdRelatorio())
						carregaIdRelatorioDefault();

					int nIdAssinatura = 0;
					arlCondicaoCampo.Clear();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoCampo.Add("idPE");
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
					if (typDatSetFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)typDatSetFaturasComerciais.tbFaturasComerciais.Rows[0];
						if (!dtrwFaturaComercial.IsidAssinaturaNull())
							nIdAssinatura = dtrwFaturaComercial.idAssinatura;
					}
					mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada.tbGuiasEntradaRow dtrwGuiaEntrada = typDatSetGuiasEntrada.tbGuiasEntrada.NewtbGuiasEntradaRow();
					dtrwGuiaEntrada.nIdExportador = m_nIdExportador;
					dtrwGuiaEntrada.strIdPe = m_strIdCodigo;
					dtrwGuiaEntrada.nIdRelatorio = m_nIdRelatorio;
					dtrwGuiaEntrada.dtEmissao = System.DateTime.Now.Date;
					dtrwGuiaEntrada.nIdAssinatura = nIdAssinatura;
					dtrwGuiaEntrada.nImpressoes = 0;
					typDatSetGuiasEntrada.tbGuiasEntrada.AddtbGuiasEntradaRow(dtrwGuiaEntrada);
					m_cls_dba_ConnectionDB.SetTbGuiasEntrada(typDatSetGuiasEntrada);
					bRetorno = (m_cls_dba_ConnectionDB == null);
				}
				return(bRetorno);
			}
		#endregion
	}
}

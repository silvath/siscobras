using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosBase
{
	/// <summary>
	/// Summary description for frmRelatoriosBase.
	/// </summary>
	public class frmRelatoriosBase : mdlComponentesGraficos.FormFixo
	{
		#region Constantes
			protected const int RELATORIO_COTACAO = 1;
			private const int MODO_VISUALIZACAO = 1;
			private const int MODO_EDICAO = 2;
			private const int DESLOCAMENTO_SCROLLBARS = 20;
			private const int OBJECTS_MOVE_LESS = 1;
			private const int OBJECTS_MOVE = 5;
		#endregion
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected  mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		protected int m_nIdExportador;
		protected string m_strIdCodigo;
		protected int m_nTipoRelatorio;
		protected int m_nIdRelatorio;


		public System.Windows.Forms.ImageList m_ilBandeiras;
		internal System.Windows.Forms.Button m_btTrocarCor;
		protected ReportCanvasPackage.ReportCanvas m_rcRelatorio;
		public System.Windows.Forms.Button m_btEnviarImagemEmail;
		protected System.Windows.Forms.Button m_btIdioma;
		public System.Windows.Forms.Button m_btSalvarImagem;
		public System.Windows.Forms.Button m_btModoEdicao;
		public System.Windows.Forms.Button m_btTrocarRelatorio;
		public System.Windows.Forms.Button m_btUltimaPagina;
		public System.Windows.Forms.Button m_btPrimeiraPagima;
		internal System.Windows.Forms.Label m_lbNomeRelatorio;
		public System.Windows.Forms.Label m_lbPaginaAtual;
		public System.Windows.Forms.Button m_btPaginaAnterior;
		public System.Windows.Forms.Button m_btProximaPagina;
		private System.ComponentModel.IContainer components;
		protected System.Windows.Forms.ToolTip m_ttDica;


		// Colecoes de Teclas de Atalho 
		private const string NOMESESSAOTECLASATALHO = "TeclasAtalhoRelatorio";
		private ArrayList m_arlTeclasAtalhoNomes;
		private ArrayList m_arlTeclasAtalhoNomesNoIni;
		private ArrayList m_arlTeclasAtalhoAcoes;
		private ArrayList m_arlTeclasAtalhoTeclas;

		// Definidos 
		protected bool m_bAtivado = true;
		protected bool m_bToolsChangeEnabled = true;
		protected string m_strSessaoArquivoConfiguracao = "SiscobrasCorSecundaria";
		protected int m_nIdIdioma;
		protected bool m_ModificaPosicaoEZoomRelatorio = true;

		// Paginas
		private System.Drawing.Size m_szPagina;
		protected int m_nPaginaAtual;
		protected System.Windows.Forms.VScrollBar m_vsbVertical;
		protected System.Windows.Forms.HScrollBar m_hsbHorizontal;
		protected System.Windows.Forms.Button m_btZoomMenos;
		protected System.Windows.Forms.Button m_btZoomMais;
		protected int m_nTotalPaginas;

		// Barras de Rolagens
		public System.Windows.Forms.GroupBox m_gbBarraSuperior;
		public System.Windows.Forms.GroupBox m_gbBarraInferior;
		public System.Windows.Forms.Button m_btImprimir;
		public System.Windows.Forms.GroupBox m_gbBarraInferiorEdicao;
		public System.Windows.Forms.GroupBox m_gbBarraSuperiorEdicao;
		public System.Windows.Forms.Button m_btModoVisualizacao;
		protected System.Windows.Forms.Button m_btZoomMaisEdicao;
		protected System.Windows.Forms.Button m_btZoomMenosEdicao;
		public System.Windows.Forms.Button m_btSalvarEdicao;
		public System.Windows.Forms.Button m_btTrocarRelatorioEdicao;
		internal System.Windows.Forms.Label m_lbNomeRelatorioEdicao;
		public System.Windows.Forms.Button m_btSalvarComoEdicao;
		private System.Windows.Forms.CheckBox m_ckSelecaoEdicao;
		private System.Windows.Forms.CheckBox m_ckLinhaEdicao;
		private System.Windows.Forms.CheckBox m_ckCirculoEdicao;
		private System.Windows.Forms.CheckBox m_ckRetanguloEdicao;
		public System.Windows.Forms.Button m_btNovoEdicao;
		private System.Windows.Forms.CheckBox m_ckImagemEdicao;
		private System.Windows.Forms.CheckBox m_ckEtiquetaEdicao;
		private System.Windows.Forms.CheckBox m_ckCampoBDEdicao;
		private System.Windows.Forms.CheckBox m_ckAreaProdutosEdicao;
		private System.Windows.Forms.GroupBox m_gbFerramentas;
		public System.Windows.Forms.Button m_btMargensEdicao;
		private System.Windows.Forms.Button m_btCoresEdicao;
		private System.Windows.Forms.GroupBox m_gbConfiguracao;
		private System.Windows.Forms.Button m_btCanetaEdicao;
		private System.Windows.Forms.Button m_btFonteEdicao;
		private System.Windows.Forms.GroupBox m_gbVisualizacao;
		private System.Windows.Forms.Button m_btVisualizarEdicao;
		private System.Windows.Forms.GroupBox m_gbUndoEdicao;
		private System.Windows.Forms.Button m_btReUndoEdicao;
		private System.Windows.Forms.Button m_btUndoEdicao;
		private System.Windows.Forms.GroupBox m_gbAgrupar;
		private System.Windows.Forms.Button m_btDesagruparEdicao;
		private System.Windows.Forms.Button m_btAgruparEdicao;
		private System.Windows.Forms.GroupBox m_gbAlinhamento;
		private System.Windows.Forms.Button m_btAlinhamentoCentralizadoEdicao;
		private System.Windows.Forms.Button m_btAlinhamentoEsquerdaEdicao;
		private System.Windows.Forms.Button m_btAlinhamentoDireitaEdicao;
		private System.Windows.Forms.GroupBox m_gbEspacamento;
		private System.Windows.Forms.Button m_btEspacamentoVertical;
		private System.Windows.Forms.Button m_btEspacamentoHorizontal;
		public System.Windows.Forms.Button m_btExcluirEdicao;
		protected System.Windows.Forms.Button m_btZoomNormal;
		internal System.Windows.Forms.Button m_btZoomNormalEdicao;
		protected System.Windows.Forms.Button m_btImportar;
		protected System.Windows.Forms.Button m_btExportar;
		internal System.Windows.Forms.Button m_btTrocarTeclasAtalhoEdicao;

		// Modo Atual 
		private int m_nModo = MODO_VISUALIZACAO;

		#endregion
		#region Propriedades
			public System.Windows.Forms.ImageList ListaBandeiras
			{
				get
				{
					return (m_ilBandeiras);
				}
				set
				{
					m_ilBandeiras = value;
				}
			}

			protected bool MostrarAssistente
			{
				get
				{
					mdlManipuladorArquivo.clsManipuladorArquivoIni cls_ini_File = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "Sisco.ini");
					return(cls_ini_File.retornaValor(mdlConstantes.clsConstantes.SHOW_ASSISTENTE_SESSAO,mdlConstantes.clsConstantes.SHOW_ASSISTENTE_VARIAVEL,true));
				}
			}

			protected int Idioma
			{
				set
				{
					m_nIdIdioma = value;
					m_rcRelatorio.SetIdIdioma(m_nIdIdioma);
				}
				get
				{
					return(m_nIdIdioma);
				}
			}

			public ReportCanvasPackage.ReportCanvas ManipuladorGrafico
			{
				get
				{
					return(this.m_rcRelatorio);
				}
			}

			public int TotalPaginas
			{
				get
				{
					return(m_nTotalPaginas);
				}
			}

			public int TipoRelatorio
			{
				set
				{
					m_nTipoRelatorio = value;
					if (!bCarregaIdRelatorio())
						carregaIdRelatorioDefault();
				}
			}
		#endregion

		#region Eventos
			#region Formulario
				protected virtual void frmRelatoriosBase_Load(object sender, System.EventArgs e)
				{
				}

				/// <summary>
				/// Tratando as Teclas pressinadas peloUsuario
				/// </summary>
				/// <param name="sender"></param>
				/// <param name="e"></param>
				private void frmRelatoriosBase_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
				{
					System.Windows.Forms.KeyEventArgs keaKey;
					for (int nCont = 0; nCont < m_arlTeclasAtalhoTeclas.Count ; nCont++)
					{
						keaKey = (System.Windows.Forms.KeyEventArgs)m_arlTeclasAtalhoTeclas[nCont];
						if (e.KeyData == keaKey.KeyData)
							if (bExecutaTeclaAtalho((int)m_arlTeclasAtalhoAcoes[nCont]))
								break;
					}
					e.Handled = true;
				}

				private void frmRelatoriosBase_MouseWheel(object sender,System.Windows.Forms.MouseEventArgs e)
				{
					int nMovements = (e.Delta / 6);
					if (nMovements > 0) // Para Cima
					{
						if ((this.m_vsbVertical.Value - nMovements) > this.m_vsbVertical.Minimum)
							this.m_vsbVertical.Value = (this.m_vsbVertical.Value - nMovements);
						else
							this.m_vsbVertical.Value = this.m_vsbVertical.Minimum;
					}
					if (nMovements < 0) // Para Baixo
					{
						if ((this.m_vsbVertical.Value - nMovements) < (this.m_vsbVertical.Maximum))
							this.m_vsbVertical.Value = (this.m_vsbVertical.Value - nMovements);
						else
							this.m_vsbVertical.Value = this.m_vsbVertical.Maximum;
					}
				}
			#endregion
			#region rcRelatorio
				private void m_rcRelatorio_eCallPropertiesBoxObjectLine(object sender, System.EventArgs e)
				{
					Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoLinha formPropriedadesLinha = new mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoLinha(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_rcRelatorio.ObjectPrintable);
					formPropriedadesLinha.ShowDialog();
					if (formPropriedadesLinha.m_bModificado)
					{
						m_rcRelatorio.ClearSelection(true);
						bool VisivelImpressao = false;
						formPropriedadesLinha.RetornaValores(out VisivelImpressao);
						m_rcRelatorio.ObjectPrintable = VisivelImpressao;
						m_rcRelatorio.m_bCancelActualAction = false;
					}
					else
					{
						m_rcRelatorio.m_bCancelActualAction = true;
					}
					formPropriedadesLinha = null;
					Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_rcRelatorio_eCallPropertiesBoxObjectCircle(object sender, System.EventArgs e)
				{
					Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoCirculo formPropriedadesCirculo = new mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoCirculo(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_rcRelatorio.ObjectPrintable);
					formPropriedadesCirculo.ShowDialog();
					if (formPropriedadesCirculo.m_bModificado)
					{
						m_rcRelatorio.ClearSelection(true);
						bool VisivelImpressao = false;
						formPropriedadesCirculo.RetornaValores(out VisivelImpressao);
						m_rcRelatorio.ObjectPrintable = VisivelImpressao;
						m_rcRelatorio.m_bCancelActualAction = false;
					}
					else
					{
						m_rcRelatorio.m_bCancelActualAction = true;
					}
					formPropriedadesCirculo = null;
					Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_rcRelatorio_eCallPropertiesBoxObjectRectangle(object sender, System.EventArgs e)
				{
					Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoRetangulo formPropriedadesRetangulo = new mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoRetangulo(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_rcRelatorio.ObjectPrintable);
					formPropriedadesRetangulo.ShowDialog();
					if (formPropriedadesRetangulo.m_bModificado)
					{
						m_rcRelatorio.ClearSelection(true);
						bool VisivelImpressao = false;
						formPropriedadesRetangulo.RetornaValores(out VisivelImpressao);
						m_rcRelatorio.ObjectPrintable = VisivelImpressao;
						m_rcRelatorio.m_bCancelActualAction = false;
					}
					else
					{
						m_rcRelatorio.m_bCancelActualAction = true;
					}
					formPropriedadesRetangulo = null;
					Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_rcRelatorio_eCallPropertiesBoxObjectText(object sender, System.EventArgs e)
				{
					Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoTexto formPropriedadesTexto = new mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoTexto(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_rcRelatorio.TextString,m_rcRelatorio.TextColor.ToArgb(),m_rcRelatorio.TextFont,m_rcRelatorio.ObjectPrintable);
					formPropriedadesTexto.ShowDialog();
					if (formPropriedadesTexto.m_bModificado)
					{
						m_rcRelatorio.ClearSelection(true);
						string Texto = "";
						System.Drawing.Color Cor = System.Drawing.Color.Beige;
						System.Drawing.Font fntFonte = null;
						bool VisivelImpressao = false;
						formPropriedadesTexto.RetornaValores(out Texto,out Cor,out fntFonte,out VisivelImpressao);
						m_rcRelatorio.TextString = Texto;
						fntFonte = new System.Drawing.Font(fntFonte.Name,(int)fntFonte.Size,fntFonte.Style);
						m_rcRelatorio.TextFont = fntFonte; 
						m_rcRelatorio.TextColor = Cor;
						m_rcRelatorio.ObjectPrintable = VisivelImpressao;
						m_rcRelatorio.m_bCancelActualAction = false;
					}else{
						m_rcRelatorio.m_bCancelActualAction = true;
					}
					formPropriedadesTexto = null;
					Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_rcRelatorio_eCallPropertiesBoxObjectImage(object sender, System.EventArgs e)
				{
					Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlRelatoriosJanelas.frmFRelatoriosImagens formPropriedadesImagem = new mdlRelatoriosJanelas.frmFRelatoriosImagens(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
					formPropriedadesImagem.ShowDialog();
					if (formPropriedadesImagem.m_bModificado)
					{
						int nPosicao = 0;
						System.Drawing.Image imagem = null;
						formPropriedadesImagem.RetornaValores(out nPosicao,out imagem);
						if ((nPosicao >= 0) && (imagem != null))
						{
							m_rcRelatorio.ImageToInsert = (System.Drawing.Image)imagem.Clone();
							m_rcRelatorio.ImageToInsertIndex = nPosicao;
							m_rcRelatorio.m_bCancelActualAction = false;
						}else{
							m_rcRelatorio.m_bCancelActualAction = true;
						}
					}
					else
					{
						m_rcRelatorio.m_bCancelActualAction = true;
					}
					formPropriedadesImagem = null;
					Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_rcRelatorio_eCallPropertiesBoxObjectTextDB(object sender, System.EventArgs e)
				{
					try
					{
						Cursor = System.Windows.Forms.Cursors.WaitCursor;
						//TODO: Problemas com a System.Drawing.Font persistem ...
						System.Drawing.Font fntFontTemp = new System.Drawing.Font("Arial",8);
						mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoTextoDB formPropriedadesTextoBD = new mdlRelatoriosJanelas.frmFRelatoriosPropriedadesObjetoTextoDB (ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_nTipoRelatorio,m_nIdIdioma,m_strIdCodigo,m_rcRelatorio.BackgroundColorLabel,m_rcRelatorio.DBTextColor,m_rcRelatorio.BackgroundColor,m_btIdioma.Image,false,false,false,0,false,0,m_rcRelatorio.TextColor.ToArgb(),fntFontTemp,m_rcRelatorio.ObjectPrintable);
						formPropriedadesTextoBD.ShowDialog();
						if (formPropriedadesTextoBD.m_bModificado)
						{
							m_rcRelatorio.ClearSelection(true);
							int idCampoBD = m_rcRelatorio.DBIdCampo;
							string Texto = "";
							System.Drawing.Color Cor = System.Drawing.Color.Beige;
							System.Drawing.Font fntFonte = null;
							bool VisivelImpressao = false;
							bool CallBack = false;
							bool PertenceAreaProdutos = false;
							bool AlinhamentoInferiorAreaProdutos = false;
							int Alinhamento = 0;
							bool ImprimirSomenteUltimaPagina = false;
							int FormatoNumero = 0;

							formPropriedadesTextoBD.RetornaValores(out idCampoBD,out Texto,out fntFonte,out Cor,out VisivelImpressao,out CallBack,out PertenceAreaProdutos,out AlinhamentoInferiorAreaProdutos,out Alinhamento,out ImprimirSomenteUltimaPagina,out FormatoNumero);
							m_rcRelatorio.DBIdCampo = idCampoBD;
							m_rcRelatorio.TextString = Texto;
							fntFonte = new System.Drawing.Font(fntFonte.Name,(int)fntFonte.Size,fntFonte.Style);
							m_rcRelatorio.TextFont = fntFonte; 
							m_rcRelatorio.TextColor = Cor;
							m_rcRelatorio.ObjectPrintable = VisivelImpressao;

							m_rcRelatorio.ObjetoVisivelImpressao = VisivelImpressao;
							m_rcRelatorio.DBCallBack = CallBack;
							m_rcRelatorio.DBPertenceAreaProdutos = PertenceAreaProdutos;
							m_rcRelatorio.DBAlinhamentoInferiorAreaProdutos = AlinhamentoInferiorAreaProdutos;
							m_rcRelatorio.DBAlinhamento = Alinhamento;
							m_rcRelatorio.DBImprimirSomenteUltimaPagina = ImprimirSomenteUltimaPagina;
							m_rcRelatorio.DBFormatoNumero = FormatoNumero;

							m_rcRelatorio.m_bCancelActualAction = false;
						}
						else
						{
							m_rcRelatorio.m_bCancelActualAction = true;
						}
						formPropriedadesTextoBD = null;
						Cursor = System.Windows.Forms.Cursors.Default;
					}catch (System.Exception eErro){
						m_cls_ter_tratadorErro.trataErro(ref eErro);
					}
				}

				protected virtual void m_rcRelatorio_ePageNumberChanged(object sender, System.EventArgs e)
				{
					m_rcRelatorio.RefreshRelatorio();
					m_nPaginaAtual = m_rcRelatorio.nCurrentPage();
					refreshInterfaceLabelPagina();
					refreshInterfaceBotoesPagina();
				}

				private void m_rcRelatorio_ePageCountChanged(object sender, System.EventArgs e)
				{
					m_nPaginaAtual = m_rcRelatorio.nCurrentPage();
					m_nTotalPaginas = m_rcRelatorio.nTotalPages();
					refreshInterfaceLabelPagina();
					refreshInterfaceBotoesPagina();
				}

				private void m_rcRelatorio_eCallToolChanged()
				{
					if (m_bAtivado && m_bToolsChangeEnabled)
					{
						m_bAtivado = false;
						switch(m_rcRelatorio.CurrentTool)
						{
							case DrawingCanvasPackage.Tool.Selection:
							switch(m_rcRelatorio.CurrentSubTool)
							{
								case ReportCanvasPackage.SubTool.None:
									m_ckSelecaoEdicao.Checked = true;
									m_ckLinhaEdicao.Checked = false;
									m_ckCirculoEdicao.Checked = false;
									m_ckRetanguloEdicao.Checked = false;
									m_ckImagemEdicao.Checked = false;
									m_ckEtiquetaEdicao.Checked = false;
									m_ckCampoBDEdicao.Checked = false;
									m_ckAreaProdutosEdicao.Checked = false;
									break;
								case ReportCanvasPackage.SubTool.ProductArea:
									m_ckSelecaoEdicao.Checked = false;
									m_ckLinhaEdicao.Checked = false;
									m_ckCirculoEdicao.Checked = false;
									m_ckRetanguloEdicao.Checked = false;
									m_ckImagemEdicao.Checked = false;
									m_ckEtiquetaEdicao.Checked = false;
									m_ckCampoBDEdicao.Checked = false;
									m_ckAreaProdutosEdicao.Checked = true;
									break;
							}
								break;
							case DrawingCanvasPackage.Tool.Line:
								m_ckSelecaoEdicao.Checked = false;
								m_ckLinhaEdicao.Checked = true;
								m_ckCirculoEdicao.Checked = false;
								m_ckRetanguloEdicao.Checked = false;
								m_ckImagemEdicao.Checked = false;
								m_ckEtiquetaEdicao.Checked = false;
								m_ckCampoBDEdicao.Checked = false;
								m_ckAreaProdutosEdicao.Checked = false;
								break;
							case DrawingCanvasPackage.Tool.Circle:
								m_ckSelecaoEdicao.Checked = false;
								m_ckLinhaEdicao.Checked = false;
								m_ckCirculoEdicao.Checked = true;
								m_ckRetanguloEdicao.Checked = false;
								m_ckImagemEdicao.Checked = false;
								m_ckEtiquetaEdicao.Checked = false;
								m_ckCampoBDEdicao.Checked = false;
								m_ckAreaProdutosEdicao.Checked = false;
								break;
							case DrawingCanvasPackage.Tool.Rectangle:
								m_ckSelecaoEdicao.Checked = false;
								m_ckLinhaEdicao.Checked = false;
								m_ckCirculoEdicao.Checked = false;
								m_ckRetanguloEdicao.Checked = true;
								m_ckImagemEdicao.Checked = false;
								m_ckEtiquetaEdicao.Checked = false;
								m_ckCampoBDEdicao.Checked = false;
								m_ckAreaProdutosEdicao.Checked = false;
								break;
							case DrawingCanvasPackage.Tool.Image:
								m_ckSelecaoEdicao.Checked = false;
								m_ckLinhaEdicao.Checked = false;
								m_ckCirculoEdicao.Checked = false;
								m_ckRetanguloEdicao.Checked = false;
								m_ckImagemEdicao.Checked = true;
								m_ckEtiquetaEdicao.Checked = false;
								m_ckCampoBDEdicao.Checked = false;
								m_ckAreaProdutosEdicao.Checked = false;
								break;
							case DrawingCanvasPackage.Tool.Text:
							switch(m_rcRelatorio.CurrentSubTool)
							{
								case ReportCanvasPackage.SubTool.None:
									m_ckSelecaoEdicao.Checked = false;
									m_ckLinhaEdicao.Checked = false;
									m_ckCirculoEdicao.Checked = false;
									m_ckRetanguloEdicao.Checked = false;
									m_ckImagemEdicao.Checked = false;
									m_ckEtiquetaEdicao.Checked = true;
									m_ckCampoBDEdicao.Checked = false;
									m_ckAreaProdutosEdicao.Checked = false;
									break;
								case ReportCanvasPackage.SubTool.DBText:
									m_ckSelecaoEdicao.Checked = false;
									m_ckLinhaEdicao.Checked = false;
									m_ckCirculoEdicao.Checked = false;
									m_ckRetanguloEdicao.Checked = false;
									m_ckImagemEdicao.Checked = false;
									m_ckEtiquetaEdicao.Checked = false;
									m_ckCampoBDEdicao.Checked = true;
									m_ckAreaProdutosEdicao.Checked = false;
									break;
							}
								break;
						}
						m_bAtivado = true;
					}
				}
			#endregion
			#region Botoes
				private void m_btTrocarCor_Click(object sender, System.EventArgs e)
				{
					vTrocaCor();
				}
			#endregion
		#endregion
		#region Constructor e Desctructor

		public frmRelatoriosBase()
		{
			InitializeComponent();
		}

		public frmRelatoriosBase(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,ref System.Windows.Forms.Form Parent,string strEnderecoExecutavel,int nTipoRelatorio,int nIdExportador,string strIdCodigo)
		{
			InitializeComponent();

			this.vInitializeEvents();
			this.vMostraCor();		
            m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
			this.MdiParent = Parent;
			m_nTipoRelatorio = nTipoRelatorio;
			m_nIdExportador = nIdExportador;
			m_strIdCodigo = strIdCodigo;


			// Configurando 
			m_nPaginaAtual = 1;
			m_rcRelatorio.SetDataBaseAccess(ref m_cls_dba_ConnectionDB);
			m_rcRelatorio.SetTratadorDeErro(ref m_cls_ter_tratadorErro);
			m_rcRelatorio.SetEnderecoExecutavel(m_strEnderecoExecutavel);
			m_rcRelatorio.SetIdCodigo(m_strIdCodigo);
			m_rcRelatorio.SetFlagsList(ref m_ilBandeiras);
			if (!bCarregaIdIdioma())
               carregaIdIdiomaDefault();
			m_rcRelatorio.SetIdIdioma(m_nIdIdioma);
			if (!bCarregaIdRelatorio())
                carregaIdRelatorioDefault();
			m_rcRelatorio.SetViewMode(true);
			m_rcRelatorio.ShowGrid = false;
			m_rcRelatorio.ShowProductArea = false;

			// Carregando as teclas de atalho
			carregaTeclasAtalho();

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
		#region Cores do Formulario
			protected virtual void vMostraCor()
			{
				if (m_strSessaoArquivoConfiguracao == "")
					m_strSessaoArquivoConfiguracao = "SiscobrasCorSecundaria"; 
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini",m_strSessaoArquivoConfiguracao);
				this.BackColor = clsPaletaCores.retornaCorAtual();
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					ctrControleChild = this.Controls[nCont];
					vPaintControl(ref ctrControleChild,this.BackColor);
				}
			}

			protected virtual void vPaintControl(ref System.Windows.Forms.Control ctrControle,System.Drawing.Color clrBackColor)
			{
				switch(ctrControle.GetType().ToString())
				{
					case "mdlComponentesGraficos.ListView":
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TextBox":
						break;
					default:
						ctrControle.BackColor = clrBackColor;
						break;
				}
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < ctrControle.Controls.Count; nCont++)
				{
					ctrControleChild = ctrControle.Controls[nCont];
					vPaintControl(ref ctrControleChild,clrBackColor);
				}
			}


			protected void vTrocaCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores cls_palCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini",m_strSessaoArquivoConfiguracao);
				cls_palCores.mostraCorAtual();
				this.vMostraCor();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRelatoriosBase));
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_btEnviarImagemEmail = new System.Windows.Forms.Button();
			this.m_btUltimaPagina = new System.Windows.Forms.Button();
			this.m_btPrimeiraPagima = new System.Windows.Forms.Button();
			this.m_btIdioma = new System.Windows.Forms.Button();
			this.m_btSalvarImagem = new System.Windows.Forms.Button();
			this.m_btModoEdicao = new System.Windows.Forms.Button();
			this.m_btTrocarRelatorio = new System.Windows.Forms.Button();
			this.m_btImprimir = new System.Windows.Forms.Button();
			this.m_btPaginaAnterior = new System.Windows.Forms.Button();
			this.m_btProximaPagina = new System.Windows.Forms.Button();
			this.m_btZoomMenos = new System.Windows.Forms.Button();
			this.m_btZoomMais = new System.Windows.Forms.Button();
			this.m_btModoVisualizacao = new System.Windows.Forms.Button();
			this.m_btZoomMaisEdicao = new System.Windows.Forms.Button();
			this.m_btZoomMenosEdicao = new System.Windows.Forms.Button();
			this.m_btSalvarEdicao = new System.Windows.Forms.Button();
			this.m_btTrocarRelatorioEdicao = new System.Windows.Forms.Button();
			this.m_btSalvarComoEdicao = new System.Windows.Forms.Button();
			this.m_btNovoEdicao = new System.Windows.Forms.Button();
			this.m_btMargensEdicao = new System.Windows.Forms.Button();
			this.m_btExcluirEdicao = new System.Windows.Forms.Button();
			this.m_btEspacamentoVertical = new System.Windows.Forms.Button();
			this.m_btEspacamentoHorizontal = new System.Windows.Forms.Button();
			this.m_btAlinhamentoCentralizadoEdicao = new System.Windows.Forms.Button();
			this.m_btAlinhamentoEsquerdaEdicao = new System.Windows.Forms.Button();
			this.m_btAlinhamentoDireitaEdicao = new System.Windows.Forms.Button();
			this.m_btDesagruparEdicao = new System.Windows.Forms.Button();
			this.m_btAgruparEdicao = new System.Windows.Forms.Button();
			this.m_btReUndoEdicao = new System.Windows.Forms.Button();
			this.m_btUndoEdicao = new System.Windows.Forms.Button();
			this.m_btVisualizarEdicao = new System.Windows.Forms.Button();
			this.m_btFonteEdicao = new System.Windows.Forms.Button();
			this.m_btCanetaEdicao = new System.Windows.Forms.Button();
			this.m_btCoresEdicao = new System.Windows.Forms.Button();
			this.m_ckAreaProdutosEdicao = new System.Windows.Forms.CheckBox();
			this.m_ckCampoBDEdicao = new System.Windows.Forms.CheckBox();
			this.m_ckEtiquetaEdicao = new System.Windows.Forms.CheckBox();
			this.m_ckImagemEdicao = new System.Windows.Forms.CheckBox();
			this.m_ckRetanguloEdicao = new System.Windows.Forms.CheckBox();
			this.m_ckCirculoEdicao = new System.Windows.Forms.CheckBox();
			this.m_ckLinhaEdicao = new System.Windows.Forms.CheckBox();
			this.m_ckSelecaoEdicao = new System.Windows.Forms.CheckBox();
			this.m_btZoomNormal = new System.Windows.Forms.Button();
			this.m_btZoomNormalEdicao = new System.Windows.Forms.Button();
			this.m_btImportar = new System.Windows.Forms.Button();
			this.m_btExportar = new System.Windows.Forms.Button();
			this.m_btTrocarTeclasAtalhoEdicao = new System.Windows.Forms.Button();
			this.m_ilBandeiras = new System.Windows.Forms.ImageList(this.components);
			this.m_gbBarraSuperior = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_gbBarraInferior = new System.Windows.Forms.GroupBox();
			this.m_lbNomeRelatorio = new System.Windows.Forms.Label();
			this.m_lbPaginaAtual = new System.Windows.Forms.Label();
			this.m_rcRelatorio = new ReportCanvasPackage.ReportCanvas(this.components);
			this.m_vsbVertical = new System.Windows.Forms.VScrollBar();
			this.m_hsbHorizontal = new System.Windows.Forms.HScrollBar();
			this.m_gbBarraInferiorEdicao = new System.Windows.Forms.GroupBox();
			this.m_lbNomeRelatorioEdicao = new System.Windows.Forms.Label();
			this.m_gbBarraSuperiorEdicao = new System.Windows.Forms.GroupBox();
			this.m_gbEspacamento = new System.Windows.Forms.GroupBox();
			this.m_gbAlinhamento = new System.Windows.Forms.GroupBox();
			this.m_gbAgrupar = new System.Windows.Forms.GroupBox();
			this.m_gbUndoEdicao = new System.Windows.Forms.GroupBox();
			this.m_gbVisualizacao = new System.Windows.Forms.GroupBox();
			this.m_gbConfiguracao = new System.Windows.Forms.GroupBox();
			this.m_gbFerramentas = new System.Windows.Forms.GroupBox();
			this.m_gbBarraSuperior.SuspendLayout();
			this.m_gbBarraInferior.SuspendLayout();
			this.m_gbBarraInferiorEdicao.SuspendLayout();
			this.m_gbBarraSuperiorEdicao.SuspendLayout();
			this.m_gbEspacamento.SuspendLayout();
			this.m_gbAlinhamento.SuspendLayout();
			this.m_gbAgrupar.SuspendLayout();
			this.m_gbUndoEdicao.SuspendLayout();
			this.m_gbVisualizacao.SuspendLayout();
			this.m_gbConfiguracao.SuspendLayout();
			this.m_gbFerramentas.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// m_btEnviarImagemEmail
			// 
			this.m_btEnviarImagemEmail.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEnviarImagemEmail.Image = ((System.Drawing.Image)(resources.GetObject("m_btEnviarImagemEmail.Image")));
			this.m_btEnviarImagemEmail.Location = new System.Drawing.Point(57, 11);
			this.m_btEnviarImagemEmail.Name = "m_btEnviarImagemEmail";
			this.m_btEnviarImagemEmail.Size = new System.Drawing.Size(24, 24);
			this.m_btEnviarImagemEmail.TabIndex = 17;
			this.m_btEnviarImagemEmail.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btEnviarImagemEmail, "Enviar via e-mail ");
			this.m_btEnviarImagemEmail.Click += new System.EventHandler(this.m_btEnviarImagemEmail_Click);
			// 
			// m_btUltimaPagina
			// 
			this.m_btUltimaPagina.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUltimaPagina.Enabled = false;
			this.m_btUltimaPagina.Image = ((System.Drawing.Image)(resources.GetObject("m_btUltimaPagina.Image")));
			this.m_btUltimaPagina.Location = new System.Drawing.Point(616, 12);
			this.m_btUltimaPagina.Name = "m_btUltimaPagina";
			this.m_btUltimaPagina.Size = new System.Drawing.Size(24, 24);
			this.m_btUltimaPagina.TabIndex = 16;
			this.m_ttDica.SetToolTip(this.m_btUltimaPagina, "Ultima página");
			this.m_btUltimaPagina.Click += new System.EventHandler(this.m_btUltimaPagina_Click);
			// 
			// m_btPrimeiraPagima
			// 
			this.m_btPrimeiraPagima.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btPrimeiraPagima.Enabled = false;
			this.m_btPrimeiraPagima.Image = ((System.Drawing.Image)(resources.GetObject("m_btPrimeiraPagima.Image")));
			this.m_btPrimeiraPagima.Location = new System.Drawing.Point(500, 12);
			this.m_btPrimeiraPagima.Name = "m_btPrimeiraPagima";
			this.m_btPrimeiraPagima.Size = new System.Drawing.Size(24, 24);
			this.m_btPrimeiraPagima.TabIndex = 15;
			this.m_btPrimeiraPagima.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btPrimeiraPagima, "Primeira página");
			this.m_btPrimeiraPagima.Click += new System.EventHandler(this.m_btPrimeiraPagima_Click);
			// 
			// m_btIdioma
			// 
			this.m_btIdioma.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btIdioma.Image = ((System.Drawing.Image)(resources.GetObject("m_btIdioma.Image")));
			this.m_btIdioma.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.m_btIdioma.Location = new System.Drawing.Point(467, 12);
			this.m_btIdioma.Name = "m_btIdioma";
			this.m_btIdioma.Size = new System.Drawing.Size(24, 24);
			this.m_btIdioma.TabIndex = 13;
			this.m_btIdioma.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btIdioma, "Alterar idioma ");
			this.m_btIdioma.Click += new System.EventHandler(this.m_btIdioma_Click);
			// 
			// m_btSalvarImagem
			// 
			this.m_btSalvarImagem.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSalvarImagem.Image = ((System.Drawing.Image)(resources.GetObject("m_btSalvarImagem.Image")));
			this.m_btSalvarImagem.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.m_btSalvarImagem.Location = new System.Drawing.Point(31, 11);
			this.m_btSalvarImagem.Name = "m_btSalvarImagem";
			this.m_btSalvarImagem.Size = new System.Drawing.Size(24, 24);
			this.m_btSalvarImagem.TabIndex = 11;
			this.m_btSalvarImagem.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btSalvarImagem, "Salvar imagem");
			this.m_btSalvarImagem.Click += new System.EventHandler(this.m_btSalvarImagem_Click);
			// 
			// m_btModoEdicao
			// 
			this.m_btModoEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btModoEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btModoEdicao.Image")));
			this.m_btModoEdicao.Location = new System.Drawing.Point(121, 11);
			this.m_btModoEdicao.Name = "m_btModoEdicao";
			this.m_btModoEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btModoEdicao.TabIndex = 10;
			this.m_btModoEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btModoEdicao, "Editar ");
			this.m_btModoEdicao.Click += new System.EventHandler(this.m_btModoEdicao_Click);
			// 
			// m_btTrocarRelatorio
			// 
			this.m_btTrocarRelatorio.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("m_btTrocarRelatorio.Image")));
			this.m_btTrocarRelatorio.Location = new System.Drawing.Point(95, 11);
			this.m_btTrocarRelatorio.Name = "m_btTrocarRelatorio";
			this.m_btTrocarRelatorio.Size = new System.Drawing.Size(24, 24);
			this.m_btTrocarRelatorio.TabIndex = 9;
			this.m_btTrocarRelatorio.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btTrocarRelatorio, "Trocar formato ");
			this.m_btTrocarRelatorio.Click += new System.EventHandler(this.m_btTrocarRelatorio_Click);
			// 
			// m_btImprimir
			// 
			this.m_btImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImprimir.Image = ((System.Drawing.Image)(resources.GetObject("m_btImprimir.Image")));
			this.m_btImprimir.Location = new System.Drawing.Point(5, 11);
			this.m_btImprimir.Name = "m_btImprimir";
			this.m_btImprimir.Size = new System.Drawing.Size(24, 24);
			this.m_btImprimir.TabIndex = 8;
			this.m_btImprimir.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btImprimir, "Imprimir");
			this.m_btImprimir.Click += new System.EventHandler(this.m_btImprimir_Click);
			// 
			// m_btPaginaAnterior
			// 
			this.m_btPaginaAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btPaginaAnterior.Enabled = false;
			this.m_btPaginaAnterior.Image = ((System.Drawing.Image)(resources.GetObject("m_btPaginaAnterior.Image")));
			this.m_btPaginaAnterior.Location = new System.Drawing.Point(526, 12);
			this.m_btPaginaAnterior.Name = "m_btPaginaAnterior";
			this.m_btPaginaAnterior.Size = new System.Drawing.Size(24, 24);
			this.m_btPaginaAnterior.TabIndex = 6;
			this.m_btPaginaAnterior.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btPaginaAnterior, "Página anterior");
			this.m_btPaginaAnterior.Click += new System.EventHandler(this.m_btPaginaAnterior_Click);
			// 
			// m_btProximaPagina
			// 
			this.m_btProximaPagina.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProximaPagina.Enabled = false;
			this.m_btProximaPagina.Image = ((System.Drawing.Image)(resources.GetObject("m_btProximaPagina.Image")));
			this.m_btProximaPagina.Location = new System.Drawing.Point(590, 12);
			this.m_btProximaPagina.Name = "m_btProximaPagina";
			this.m_btProximaPagina.Size = new System.Drawing.Size(24, 24);
			this.m_btProximaPagina.TabIndex = 5;
			this.m_ttDica.SetToolTip(this.m_btProximaPagina, "Página posterior");
			this.m_btProximaPagina.Click += new System.EventHandler(this.m_btProximaPagina_Click);
			// 
			// m_btZoomMenos
			// 
			this.m_btZoomMenos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btZoomMenos.Image = ((System.Drawing.Image)(resources.GetObject("m_btZoomMenos.Image")));
			this.m_btZoomMenos.Location = new System.Drawing.Point(158, 11);
			this.m_btZoomMenos.Name = "m_btZoomMenos";
			this.m_btZoomMenos.Size = new System.Drawing.Size(24, 24);
			this.m_btZoomMenos.TabIndex = 18;
			this.m_btZoomMenos.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btZoomMenos, "Afastar");
			this.m_btZoomMenos.Visible = false;
			this.m_btZoomMenos.Click += new System.EventHandler(this.m_btZoomMenos_Click);
			// 
			// m_btZoomMais
			// 
			this.m_btZoomMais.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btZoomMais.Image = ((System.Drawing.Image)(resources.GetObject("m_btZoomMais.Image")));
			this.m_btZoomMais.Location = new System.Drawing.Point(187, 11);
			this.m_btZoomMais.Name = "m_btZoomMais";
			this.m_btZoomMais.Size = new System.Drawing.Size(24, 24);
			this.m_btZoomMais.TabIndex = 19;
			this.m_btZoomMais.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btZoomMais, "Aproximar");
			this.m_btZoomMais.Visible = false;
			this.m_btZoomMais.Click += new System.EventHandler(this.m_btZoomMais_Click);
			// 
			// m_btModoVisualizacao
			// 
			this.m_btModoVisualizacao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btModoVisualizacao.Image = ((System.Drawing.Image)(resources.GetObject("m_btModoVisualizacao.Image")));
			this.m_btModoVisualizacao.Location = new System.Drawing.Point(121, 11);
			this.m_btModoVisualizacao.Name = "m_btModoVisualizacao";
			this.m_btModoVisualizacao.Size = new System.Drawing.Size(24, 24);
			this.m_btModoVisualizacao.TabIndex = 11;
			this.m_btModoVisualizacao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btModoVisualizacao, "Visualizar relatório");
			this.m_btModoVisualizacao.Click += new System.EventHandler(this.m_btModoVisualizacao_Click);
			// 
			// m_btZoomMaisEdicao
			// 
			this.m_btZoomMaisEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btZoomMaisEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btZoomMaisEdicao.Image")));
			this.m_btZoomMaisEdicao.Location = new System.Drawing.Point(187, 11);
			this.m_btZoomMaisEdicao.Name = "m_btZoomMaisEdicao";
			this.m_btZoomMaisEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btZoomMaisEdicao.TabIndex = 21;
			this.m_btZoomMaisEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btZoomMaisEdicao, "Aproximar");
			this.m_btZoomMaisEdicao.Click += new System.EventHandler(this.m_btZoomMaisEdicao_Click);
			// 
			// m_btZoomMenosEdicao
			// 
			this.m_btZoomMenosEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btZoomMenosEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btZoomMenosEdicao.Image")));
			this.m_btZoomMenosEdicao.Location = new System.Drawing.Point(158, 11);
			this.m_btZoomMenosEdicao.Name = "m_btZoomMenosEdicao";
			this.m_btZoomMenosEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btZoomMenosEdicao.TabIndex = 20;
			this.m_btZoomMenosEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btZoomMenosEdicao, "Afastar");
			this.m_btZoomMenosEdicao.Click += new System.EventHandler(this.m_btZoomMenosEdicao_Click);
			// 
			// m_btSalvarEdicao
			// 
			this.m_btSalvarEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSalvarEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btSalvarEdicao.Image")));
			this.m_btSalvarEdicao.Location = new System.Drawing.Point(31, 11);
			this.m_btSalvarEdicao.Name = "m_btSalvarEdicao";
			this.m_btSalvarEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btSalvarEdicao.TabIndex = 12;
			this.m_btSalvarEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btSalvarEdicao, "Salvar");
			this.m_btSalvarEdicao.Click += new System.EventHandler(this.m_btSalvarEdicao_Click);
			// 
			// m_btTrocarRelatorioEdicao
			// 
			this.m_btTrocarRelatorioEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarRelatorioEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btTrocarRelatorioEdicao.Image")));
			this.m_btTrocarRelatorioEdicao.Location = new System.Drawing.Point(95, 11);
			this.m_btTrocarRelatorioEdicao.Name = "m_btTrocarRelatorioEdicao";
			this.m_btTrocarRelatorioEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btTrocarRelatorioEdicao.TabIndex = 22;
			this.m_btTrocarRelatorioEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btTrocarRelatorioEdicao, "Trocar formato ");
			this.m_btTrocarRelatorioEdicao.Click += new System.EventHandler(this.m_btTrocarRelatorioEdicao_Click);
			// 
			// m_btSalvarComoEdicao
			// 
			this.m_btSalvarComoEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSalvarComoEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btSalvarComoEdicao.Image")));
			this.m_btSalvarComoEdicao.Location = new System.Drawing.Point(57, 11);
			this.m_btSalvarComoEdicao.Name = "m_btSalvarComoEdicao";
			this.m_btSalvarComoEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btSalvarComoEdicao.TabIndex = 13;
			this.m_btSalvarComoEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btSalvarComoEdicao, "Salvar Como");
			this.m_btSalvarComoEdicao.Click += new System.EventHandler(this.m_btSalvarComoEdicao_Click);
			// 
			// m_btNovoEdicao
			// 
			this.m_btNovoEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNovoEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btNovoEdicao.Image")));
			this.m_btNovoEdicao.Location = new System.Drawing.Point(5, 11);
			this.m_btNovoEdicao.Name = "m_btNovoEdicao";
			this.m_btNovoEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btNovoEdicao.TabIndex = 24;
			this.m_btNovoEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btNovoEdicao, "Novo");
			this.m_btNovoEdicao.Click += new System.EventHandler(this.m_btNovoEdicao_Click);
			// 
			// m_btMargensEdicao
			// 
			this.m_btMargensEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btMargensEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btMargensEdicao.Image")));
			this.m_btMargensEdicao.Location = new System.Drawing.Point(221, 11);
			this.m_btMargensEdicao.Name = "m_btMargensEdicao";
			this.m_btMargensEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btMargensEdicao.TabIndex = 25;
			this.m_btMargensEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btMargensEdicao, "Configurar Relatorio");
			this.m_btMargensEdicao.Click += new System.EventHandler(this.m_btMargensEdicao_Click);
			// 
			// m_btExcluirEdicao
			// 
			this.m_btExcluirEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluirEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluirEdicao.Image")));
			this.m_btExcluirEdicao.Location = new System.Drawing.Point(247, 11);
			this.m_btExcluirEdicao.Name = "m_btExcluirEdicao";
			this.m_btExcluirEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btExcluirEdicao.TabIndex = 26;
			this.m_btExcluirEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btExcluirEdicao, "Excluir");
			this.m_btExcluirEdicao.Click += new System.EventHandler(this.m_btExcluirEdicao_Click);
			// 
			// m_btEspacamentoVertical
			// 
			this.m_btEspacamentoVertical.Image = ((System.Drawing.Image)(resources.GetObject("m_btEspacamentoVertical.Image")));
			this.m_btEspacamentoVertical.Location = new System.Drawing.Point(31, 8);
			this.m_btEspacamentoVertical.Name = "m_btEspacamentoVertical";
			this.m_btEspacamentoVertical.Size = new System.Drawing.Size(24, 24);
			this.m_btEspacamentoVertical.TabIndex = 3;
			this.m_btEspacamentoVertical.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btEspacamentoVertical, "Distribuir Verticalmente");
			this.m_btEspacamentoVertical.Click += new System.EventHandler(this.m_btEspacamentoVertical_Click);
			// 
			// m_btEspacamentoHorizontal
			// 
			this.m_btEspacamentoHorizontal.Image = ((System.Drawing.Image)(resources.GetObject("m_btEspacamentoHorizontal.Image")));
			this.m_btEspacamentoHorizontal.Location = new System.Drawing.Point(5, 9);
			this.m_btEspacamentoHorizontal.Name = "m_btEspacamentoHorizontal";
			this.m_btEspacamentoHorizontal.Size = new System.Drawing.Size(24, 24);
			this.m_btEspacamentoHorizontal.TabIndex = 2;
			this.m_btEspacamentoHorizontal.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btEspacamentoHorizontal, "Distribuir Horizontalmente");
			this.m_btEspacamentoHorizontal.Click += new System.EventHandler(this.m_btEspacamentoHorizontal_Click);
			// 
			// m_btAlinhamentoCentralizadoEdicao
			// 
			this.m_btAlinhamentoCentralizadoEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btAlinhamentoCentralizadoEdicao.Image")));
			this.m_btAlinhamentoCentralizadoEdicao.Location = new System.Drawing.Point(31, 8);
			this.m_btAlinhamentoCentralizadoEdicao.Name = "m_btAlinhamentoCentralizadoEdicao";
			this.m_btAlinhamentoCentralizadoEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btAlinhamentoCentralizadoEdicao.TabIndex = 3;
			this.m_btAlinhamentoCentralizadoEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btAlinhamentoCentralizadoEdicao, "Centralizar");
			this.m_btAlinhamentoCentralizadoEdicao.Click += new System.EventHandler(this.m_btAlinhamentoCentralizadoEdicao_Click);
			// 
			// m_btAlinhamentoEsquerdaEdicao
			// 
			this.m_btAlinhamentoEsquerdaEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btAlinhamentoEsquerdaEdicao.Image")));
			this.m_btAlinhamentoEsquerdaEdicao.Location = new System.Drawing.Point(5, 9);
			this.m_btAlinhamentoEsquerdaEdicao.Name = "m_btAlinhamentoEsquerdaEdicao";
			this.m_btAlinhamentoEsquerdaEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btAlinhamentoEsquerdaEdicao.TabIndex = 2;
			this.m_btAlinhamentoEsquerdaEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btAlinhamentoEsquerdaEdicao, "Alinhar à Esquerda");
			this.m_btAlinhamentoEsquerdaEdicao.Click += new System.EventHandler(this.m_btAlinhamentoEsquerdaEdicao_Click);
			// 
			// m_btAlinhamentoDireitaEdicao
			// 
			this.m_btAlinhamentoDireitaEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btAlinhamentoDireitaEdicao.Image")));
			this.m_btAlinhamentoDireitaEdicao.Location = new System.Drawing.Point(56, 8);
			this.m_btAlinhamentoDireitaEdicao.Name = "m_btAlinhamentoDireitaEdicao";
			this.m_btAlinhamentoDireitaEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btAlinhamentoDireitaEdicao.TabIndex = 1;
			this.m_btAlinhamentoDireitaEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btAlinhamentoDireitaEdicao, "Alinhar à Direita");
			this.m_btAlinhamentoDireitaEdicao.Click += new System.EventHandler(this.m_btAlinhamentoDireitaEdicao_Click);
			// 
			// m_btDesagruparEdicao
			// 
			this.m_btDesagruparEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btDesagruparEdicao.Image")));
			this.m_btDesagruparEdicao.Location = new System.Drawing.Point(31, 8);
			this.m_btDesagruparEdicao.Name = "m_btDesagruparEdicao";
			this.m_btDesagruparEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btDesagruparEdicao.TabIndex = 3;
			this.m_btDesagruparEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btDesagruparEdicao, "Desagrupar");
			this.m_btDesagruparEdicao.Click += new System.EventHandler(this.m_btDesagruparEdicao_Click);
			// 
			// m_btAgruparEdicao
			// 
			this.m_btAgruparEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btAgruparEdicao.Image")));
			this.m_btAgruparEdicao.Location = new System.Drawing.Point(5, 9);
			this.m_btAgruparEdicao.Name = "m_btAgruparEdicao";
			this.m_btAgruparEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btAgruparEdicao.TabIndex = 2;
			this.m_btAgruparEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btAgruparEdicao, "Agrupar");
			this.m_btAgruparEdicao.Click += new System.EventHandler(this.m_btAgruparEdicao_Click);
			// 
			// m_btReUndoEdicao
			// 
			this.m_btReUndoEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btReUndoEdicao.Image")));
			this.m_btReUndoEdicao.Location = new System.Drawing.Point(31, 8);
			this.m_btReUndoEdicao.Name = "m_btReUndoEdicao";
			this.m_btReUndoEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btReUndoEdicao.TabIndex = 3;
			this.m_btReUndoEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btReUndoEdicao, "Refazer");
			this.m_btReUndoEdicao.Click += new System.EventHandler(this.m_btReUndoEdicao_Click);
			// 
			// m_btUndoEdicao
			// 
			this.m_btUndoEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btUndoEdicao.Image")));
			this.m_btUndoEdicao.Location = new System.Drawing.Point(5, 9);
			this.m_btUndoEdicao.Name = "m_btUndoEdicao";
			this.m_btUndoEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btUndoEdicao.TabIndex = 2;
			this.m_btUndoEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btUndoEdicao, "Desfazer");
			this.m_btUndoEdicao.Click += new System.EventHandler(this.m_btUndoEdicao_Click);
			// 
			// m_btVisualizarEdicao
			// 
			this.m_btVisualizarEdicao.BackColor = System.Drawing.SystemColors.Control;
			this.m_btVisualizarEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btVisualizarEdicao.Image")));
			this.m_btVisualizarEdicao.Location = new System.Drawing.Point(31, 9);
			this.m_btVisualizarEdicao.Name = "m_btVisualizarEdicao";
			this.m_btVisualizarEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btVisualizarEdicao.TabIndex = 1;
			this.m_btVisualizarEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btVisualizarEdicao, "Configurar visibilidade");
			this.m_btVisualizarEdicao.Click += new System.EventHandler(this.m_btVisualizarEdicao_Click);
			// 
			// m_btFonteEdicao
			// 
			this.m_btFonteEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btFonteEdicao.Image")));
			this.m_btFonteEdicao.Location = new System.Drawing.Point(31, 8);
			this.m_btFonteEdicao.Name = "m_btFonteEdicao";
			this.m_btFonteEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btFonteEdicao.TabIndex = 3;
			this.m_btFonteEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btFonteEdicao, "Configurar Fonte");
			this.m_btFonteEdicao.Click += new System.EventHandler(this.m_btFonteEdicao_Click);
			// 
			// m_btCanetaEdicao
			// 
			this.m_btCanetaEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btCanetaEdicao.Image")));
			this.m_btCanetaEdicao.Location = new System.Drawing.Point(5, 9);
			this.m_btCanetaEdicao.Name = "m_btCanetaEdicao";
			this.m_btCanetaEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btCanetaEdicao.TabIndex = 2;
			this.m_btCanetaEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btCanetaEdicao, "Configurar Caneta");
			this.m_btCanetaEdicao.Click += new System.EventHandler(this.m_btCanetaEdicao_Click);
			// 
			// m_btCoresEdicao
			// 
			this.m_btCoresEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btCoresEdicao.Image")));
			this.m_btCoresEdicao.Location = new System.Drawing.Point(56, 8);
			this.m_btCoresEdicao.Name = "m_btCoresEdicao";
			this.m_btCoresEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btCoresEdicao.TabIndex = 1;
			this.m_btCoresEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btCoresEdicao, "Configurar Cores");
			this.m_btCoresEdicao.Click += new System.EventHandler(this.m_btCoresEdicao_Click);
			// 
			// m_ckAreaProdutosEdicao
			// 
			this.m_ckAreaProdutosEdicao.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckAreaProdutosEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckAreaProdutosEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_ckAreaProdutosEdicao.Image")));
			this.m_ckAreaProdutosEdicao.Location = new System.Drawing.Point(183, 9);
			this.m_ckAreaProdutosEdicao.Name = "m_ckAreaProdutosEdicao";
			this.m_ckAreaProdutosEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_ckAreaProdutosEdicao.TabIndex = 20;
			this.m_ckAreaProdutosEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_ckAreaProdutosEdicao, "Definir Área Composta");
			this.m_ckAreaProdutosEdicao.CheckedChanged += new System.EventHandler(this.m_ckAreaProdutosEdicao_CheckedChanged);
			// 
			// m_ckCampoBDEdicao
			// 
			this.m_ckCampoBDEdicao.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckCampoBDEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckCampoBDEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_ckCampoBDEdicao.Image")));
			this.m_ckCampoBDEdicao.Location = new System.Drawing.Point(158, 9);
			this.m_ckCampoBDEdicao.Name = "m_ckCampoBDEdicao";
			this.m_ckCampoBDEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_ckCampoBDEdicao.TabIndex = 19;
			this.m_ckCampoBDEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_ckCampoBDEdicao, "Inserir Texto Dinâmico");
			this.m_ckCampoBDEdicao.CheckedChanged += new System.EventHandler(this.m_ckCampoBDEdicao_CheckedChanged);
			// 
			// m_ckEtiquetaEdicao
			// 
			this.m_ckEtiquetaEdicao.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckEtiquetaEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckEtiquetaEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_ckEtiquetaEdicao.Image")));
			this.m_ckEtiquetaEdicao.Location = new System.Drawing.Point(135, 9);
			this.m_ckEtiquetaEdicao.Name = "m_ckEtiquetaEdicao";
			this.m_ckEtiquetaEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_ckEtiquetaEdicao.TabIndex = 18;
			this.m_ckEtiquetaEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_ckEtiquetaEdicao, "Inserir Texto Estático");
			this.m_ckEtiquetaEdicao.CheckedChanged += new System.EventHandler(this.m_ckEtiquetaEdicao_CheckedChanged);
			// 
			// m_ckImagemEdicao
			// 
			this.m_ckImagemEdicao.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckImagemEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckImagemEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_ckImagemEdicao.Image")));
			this.m_ckImagemEdicao.Location = new System.Drawing.Point(110, 9);
			this.m_ckImagemEdicao.Name = "m_ckImagemEdicao";
			this.m_ckImagemEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_ckImagemEdicao.TabIndex = 17;
			this.m_ckImagemEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_ckImagemEdicao, "Inserir Imagens");
			this.m_ckImagemEdicao.CheckedChanged += new System.EventHandler(this.m_ckImagemEdicao_CheckedChanged);
			// 
			// m_ckRetanguloEdicao
			// 
			this.m_ckRetanguloEdicao.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckRetanguloEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckRetanguloEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_ckRetanguloEdicao.Image")));
			this.m_ckRetanguloEdicao.Location = new System.Drawing.Point(85, 9);
			this.m_ckRetanguloEdicao.Name = "m_ckRetanguloEdicao";
			this.m_ckRetanguloEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_ckRetanguloEdicao.TabIndex = 16;
			this.m_ckRetanguloEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_ckRetanguloEdicao, "Inserir Retângulos");
			this.m_ckRetanguloEdicao.CheckedChanged += new System.EventHandler(this.m_ckRetanguloEdicao_CheckedChanged);
			// 
			// m_ckCirculoEdicao
			// 
			this.m_ckCirculoEdicao.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckCirculoEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckCirculoEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_ckCirculoEdicao.Image")));
			this.m_ckCirculoEdicao.Location = new System.Drawing.Point(58, 9);
			this.m_ckCirculoEdicao.Name = "m_ckCirculoEdicao";
			this.m_ckCirculoEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_ckCirculoEdicao.TabIndex = 15;
			this.m_ckCirculoEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_ckCirculoEdicao, "Inserir Elipses");
			this.m_ckCirculoEdicao.CheckedChanged += new System.EventHandler(this.m_ckCirculoEdicao_CheckedChanged);
			// 
			// m_ckLinhaEdicao
			// 
			this.m_ckLinhaEdicao.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckLinhaEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckLinhaEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_ckLinhaEdicao.Image")));
			this.m_ckLinhaEdicao.Location = new System.Drawing.Point(32, 9);
			this.m_ckLinhaEdicao.Name = "m_ckLinhaEdicao";
			this.m_ckLinhaEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_ckLinhaEdicao.TabIndex = 14;
			this.m_ckLinhaEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_ckLinhaEdicao, "Inserir Linhas");
			this.m_ckLinhaEdicao.CheckedChanged += new System.EventHandler(this.m_ckLinhaEdicao_CheckedChanged);
			// 
			// m_ckSelecaoEdicao
			// 
			this.m_ckSelecaoEdicao.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckSelecaoEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckSelecaoEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_ckSelecaoEdicao.Image")));
			this.m_ckSelecaoEdicao.Location = new System.Drawing.Point(6, 9);
			this.m_ckSelecaoEdicao.Name = "m_ckSelecaoEdicao";
			this.m_ckSelecaoEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_ckSelecaoEdicao.TabIndex = 13;
			this.m_ckSelecaoEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_ckSelecaoEdicao, "Selecionar objetos");
			this.m_ckSelecaoEdicao.CheckedChanged += new System.EventHandler(this.m_ckSelecaoEdicao_CheckedChanged);
			// 
			// m_btZoomNormal
			// 
			this.m_btZoomNormal.BackColor = System.Drawing.Color.White;
			this.m_btZoomNormal.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btZoomNormal.Location = new System.Drawing.Point(183, 22);
			this.m_btZoomNormal.Name = "m_btZoomNormal";
			this.m_btZoomNormal.Size = new System.Drawing.Size(4, 4);
			this.m_btZoomNormal.TabIndex = 58;
			this.m_btZoomNormal.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btZoomNormal, "Tamanho normal");
			this.m_btZoomNormal.Visible = false;
			this.m_btZoomNormal.Click += new System.EventHandler(this.m_btZoomNormal_Click);
			// 
			// m_btZoomNormalEdicao
			// 
			this.m_btZoomNormalEdicao.BackColor = System.Drawing.Color.White;
			this.m_btZoomNormalEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btZoomNormalEdicao.ForeColor = System.Drawing.Color.White;
			this.m_btZoomNormalEdicao.Location = new System.Drawing.Point(183, 22);
			this.m_btZoomNormalEdicao.Name = "m_btZoomNormalEdicao";
			this.m_btZoomNormalEdicao.Size = new System.Drawing.Size(4, 4);
			this.m_btZoomNormalEdicao.TabIndex = 59;
			this.m_btZoomNormalEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btZoomNormalEdicao, "Tamanho normal");
			this.m_btZoomNormalEdicao.Click += new System.EventHandler(this.m_btZoomNormalEdicao_Click);
			// 
			// m_btImportar
			// 
			this.m_btImportar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImportar.Image = ((System.Drawing.Image)(resources.GetObject("m_btImportar.Image")));
			this.m_btImportar.Location = new System.Drawing.Point(219, 11);
			this.m_btImportar.Name = "m_btImportar";
			this.m_btImportar.Size = new System.Drawing.Size(24, 24);
			this.m_btImportar.TabIndex = 60;
			this.m_btImportar.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btImportar, "Importar Relatório");
			this.m_btImportar.Visible = false;
			this.m_btImportar.Click += new System.EventHandler(this.m_btImportar_Click);
			// 
			// m_btExportar
			// 
			this.m_btExportar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExportar.Image = ((System.Drawing.Image)(resources.GetObject("m_btExportar.Image")));
			this.m_btExportar.Location = new System.Drawing.Point(245, 11);
			this.m_btExportar.Name = "m_btExportar";
			this.m_btExportar.Size = new System.Drawing.Size(24, 24);
			this.m_btExportar.TabIndex = 59;
			this.m_btExportar.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btExportar, "Exportar Relatório");
			this.m_btExportar.Visible = false;
			this.m_btExportar.Click += new System.EventHandler(this.m_btExportar_Click);
			// 
			// m_btTrocarTeclasAtalhoEdicao
			// 
			this.m_btTrocarTeclasAtalhoEdicao.BackColor = System.Drawing.SystemColors.Control;
			this.m_btTrocarTeclasAtalhoEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarTeclasAtalhoEdicao.Image = ((System.Drawing.Image)(resources.GetObject("m_btTrocarTeclasAtalhoEdicao.Image")));
			this.m_btTrocarTeclasAtalhoEdicao.Location = new System.Drawing.Point(5, 9);
			this.m_btTrocarTeclasAtalhoEdicao.Name = "m_btTrocarTeclasAtalhoEdicao";
			this.m_btTrocarTeclasAtalhoEdicao.Size = new System.Drawing.Size(24, 24);
			this.m_btTrocarTeclasAtalhoEdicao.TabIndex = 59;
			this.m_btTrocarTeclasAtalhoEdicao.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btTrocarTeclasAtalhoEdicao, "Teclas de Atalho");
			this.m_btTrocarTeclasAtalhoEdicao.Click += new System.EventHandler(this.m_btTrocarTeclasAtalhoEdicao_Click);
			// 
			// m_ilBandeiras
			// 
			this.m_ilBandeiras.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilBandeiras.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBandeiras.ImageStream")));
			this.m_ilBandeiras.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_gbBarraSuperior
			// 
			this.m_gbBarraSuperior.Controls.Add(this.m_btTrocarCor);
			this.m_gbBarraSuperior.Location = new System.Drawing.Point(74, -3);
			this.m_gbBarraSuperior.Name = "m_gbBarraSuperior";
			this.m_gbBarraSuperior.Size = new System.Drawing.Size(694, 40);
			this.m_gbBarraSuperior.TabIndex = 2;
			this.m_gbBarraSuperior.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(11, 11);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 57;
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_gbBarraInferior
			// 
			this.m_gbBarraInferior.CausesValidation = false;
			this.m_gbBarraInferior.Controls.Add(this.m_btImportar);
			this.m_gbBarraInferior.Controls.Add(this.m_btExportar);
			this.m_gbBarraInferior.Controls.Add(this.m_btZoomNormal);
			this.m_gbBarraInferior.Controls.Add(this.m_btZoomMais);
			this.m_gbBarraInferior.Controls.Add(this.m_btZoomMenos);
			this.m_gbBarraInferior.Controls.Add(this.m_btEnviarImagemEmail);
			this.m_gbBarraInferior.Controls.Add(this.m_btUltimaPagina);
			this.m_gbBarraInferior.Controls.Add(this.m_btPrimeiraPagima);
			this.m_gbBarraInferior.Controls.Add(this.m_lbNomeRelatorio);
			this.m_gbBarraInferior.Controls.Add(this.m_btIdioma);
			this.m_gbBarraInferior.Controls.Add(this.m_btSalvarImagem);
			this.m_gbBarraInferior.Controls.Add(this.m_btModoEdicao);
			this.m_gbBarraInferior.Controls.Add(this.m_btTrocarRelatorio);
			this.m_gbBarraInferior.Controls.Add(this.m_btImprimir);
			this.m_gbBarraInferior.Controls.Add(this.m_btPaginaAnterior);
			this.m_gbBarraInferior.Controls.Add(this.m_btProximaPagina);
			this.m_gbBarraInferior.Controls.Add(this.m_lbPaginaAtual);
			this.m_gbBarraInferior.Location = new System.Drawing.Point(74, 496);
			this.m_gbBarraInferior.Name = "m_gbBarraInferior";
			this.m_gbBarraInferior.Size = new System.Drawing.Size(694, 40);
			this.m_gbBarraInferior.TabIndex = 3;
			this.m_gbBarraInferior.TabStop = false;
			// 
			// m_lbNomeRelatorio
			// 
			this.m_lbNomeRelatorio.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbNomeRelatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.m_lbNomeRelatorio.Location = new System.Drawing.Point(288, 16);
			this.m_lbNomeRelatorio.Name = "m_lbNomeRelatorio";
			this.m_lbNomeRelatorio.Size = new System.Drawing.Size(176, 17);
			this.m_lbNomeRelatorio.TabIndex = 14;
			this.m_lbNomeRelatorio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_lbPaginaAtual
			// 
			this.m_lbPaginaAtual.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbPaginaAtual.Location = new System.Drawing.Point(547, 16);
			this.m_lbPaginaAtual.Name = "m_lbPaginaAtual";
			this.m_lbPaginaAtual.Size = new System.Drawing.Size(40, 16);
			this.m_lbPaginaAtual.TabIndex = 7;
			this.m_lbPaginaAtual.Text = "99/99";
			this.m_lbPaginaAtual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_rcRelatorio
			// 
			this.m_rcRelatorio.BackColor = System.Drawing.Color.White;
			this.m_rcRelatorio.BackgroundColor = System.Drawing.Color.White;
			this.m_rcRelatorio.BackgroundColorLabel = System.Drawing.Color.LightGreen;
			this.m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;
			this.m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.None;
			this.m_rcRelatorio.DBAlinhamento = 0;
			this.m_rcRelatorio.DBAlinhamentoInferiorAreaProdutos = false;
			this.m_rcRelatorio.DBCallBack = false;
			this.m_rcRelatorio.DBFormatoNumero = 0;
			this.m_rcRelatorio.DBIdCampo = 0;
			this.m_rcRelatorio.DBImprimirSomenteUltimaPagina = false;
			this.m_rcRelatorio.DBPertenceAreaProdutos = false;
			this.m_rcRelatorio.DBTextColor = System.Drawing.Color.LemonChiffon;
			this.m_rcRelatorio.HighlightColor = System.Drawing.SystemColors.Highlight;
			this.m_rcRelatorio.IdCodigo = "1";
			this.m_rcRelatorio.ImageToInsert = null;
			this.m_rcRelatorio.ImageToInsertIndex = 0;
			this.m_rcRelatorio.LineType = DrawingCanvasPackage.LineStyle.Free;
			this.m_rcRelatorio.Location = new System.Drawing.Point(74, 40);
			this.m_rcRelatorio.MarginColor = System.Drawing.Color.LightSkyBlue;
			this.m_rcRelatorio.MousePos = new System.Drawing.Point(0, 0);
			this.m_rcRelatorio.Name = "m_rcRelatorio";
			this.m_rcRelatorio.NotPrintableColor = System.Drawing.SystemColors.InactiveCaption;
			this.m_rcRelatorio.ObjectPrintable = true;
			this.m_rcRelatorio.ObjetoVisivelImpressao = false;
			this.m_rcRelatorio.OpaqueObject = false;
			this.m_rcRelatorio.Orientation = 0;
			this.m_rcRelatorio.PageSize = new System.Drawing.Size(300, 400);
			this.m_rcRelatorio.PenColor = System.Drawing.Color.Black;
			this.m_rcRelatorio.PenStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.m_rcRelatorio.PenWidth = 1;
			this.m_rcRelatorio.ProductAreaColor = System.Drawing.Color.Azure;
			this.m_rcRelatorio.SelectionColor = System.Drawing.Color.DarkCyan;
			this.m_rcRelatorio.ShowCircles = true;
			this.m_rcRelatorio.ShowDBText = true;
			this.m_rcRelatorio.ShowDBTextDados = true;
			this.m_rcRelatorio.ShowGrid = false;
			this.m_rcRelatorio.ShowImage = true;
			this.m_rcRelatorio.ShowLines = true;
			this.m_rcRelatorio.ShowMargins = true;
			this.m_rcRelatorio.ShowProductArea = false;
			this.m_rcRelatorio.ShowRectangles = true;
			this.m_rcRelatorio.ShowText = true;
			this.m_rcRelatorio.Size = new System.Drawing.Size(706, 424);
			this.m_rcRelatorio.TabIndex = 4;
			this.m_rcRelatorio.TabStop = false;
			this.m_rcRelatorio.TextColor = System.Drawing.Color.Black;
			this.m_rcRelatorio.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.m_rcRelatorio.TextString = null;
			// 
			// m_vsbVertical
			// 
			this.m_vsbVertical.LargeChange = 30;
			this.m_vsbVertical.Location = new System.Drawing.Point(779, 40);
			this.m_vsbVertical.Name = "m_vsbVertical";
			this.m_vsbVertical.Size = new System.Drawing.Size(16, 427);
			this.m_vsbVertical.SmallChange = 20;
			this.m_vsbVertical.TabIndex = 5;
			this.m_vsbVertical.Value = 50;
			this.m_vsbVertical.ValueChanged += new System.EventHandler(this.m_vsbVertical_ValueChanged);
			// 
			// m_hsbHorizontal
			// 
			this.m_hsbHorizontal.LargeChange = 30;
			this.m_hsbHorizontal.Location = new System.Drawing.Point(74, 464);
			this.m_hsbHorizontal.Name = "m_hsbHorizontal";
			this.m_hsbHorizontal.Size = new System.Drawing.Size(709, 16);
			this.m_hsbHorizontal.SmallChange = 20;
			this.m_hsbHorizontal.TabIndex = 6;
			this.m_hsbHorizontal.Value = 50;
			this.m_hsbHorizontal.ValueChanged += new System.EventHandler(this.m_hsbHorizontal_ValueChanged);
			// 
			// m_gbBarraInferiorEdicao
			// 
			this.m_gbBarraInferiorEdicao.Controls.Add(this.m_btZoomNormalEdicao);
			this.m_gbBarraInferiorEdicao.Controls.Add(this.m_btExcluirEdicao);
			this.m_gbBarraInferiorEdicao.Controls.Add(this.m_btMargensEdicao);
			this.m_gbBarraInferiorEdicao.Controls.Add(this.m_btNovoEdicao);
			this.m_gbBarraInferiorEdicao.Controls.Add(this.m_lbNomeRelatorioEdicao);
			this.m_gbBarraInferiorEdicao.Controls.Add(this.m_btTrocarRelatorioEdicao);
			this.m_gbBarraInferiorEdicao.Controls.Add(this.m_btZoomMaisEdicao);
			this.m_gbBarraInferiorEdicao.Controls.Add(this.m_btZoomMenosEdicao);
			this.m_gbBarraInferiorEdicao.Controls.Add(this.m_btModoVisualizacao);
			this.m_gbBarraInferiorEdicao.Controls.Add(this.m_btSalvarEdicao);
			this.m_gbBarraInferiorEdicao.Controls.Add(this.m_btSalvarComoEdicao);
			this.m_gbBarraInferiorEdicao.Location = new System.Drawing.Point(74, 400);
			this.m_gbBarraInferiorEdicao.Name = "m_gbBarraInferiorEdicao";
			this.m_gbBarraInferiorEdicao.Size = new System.Drawing.Size(694, 40);
			this.m_gbBarraInferiorEdicao.TabIndex = 7;
			this.m_gbBarraInferiorEdicao.TabStop = false;
			this.m_gbBarraInferiorEdicao.Visible = false;
			// 
			// m_lbNomeRelatorioEdicao
			// 
			this.m_lbNomeRelatorioEdicao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbNomeRelatorioEdicao.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.m_lbNomeRelatorioEdicao.Location = new System.Drawing.Point(376, 16);
			this.m_lbNomeRelatorioEdicao.Name = "m_lbNomeRelatorioEdicao";
			this.m_lbNomeRelatorioEdicao.Size = new System.Drawing.Size(240, 17);
			this.m_lbNomeRelatorioEdicao.TabIndex = 23;
			this.m_lbNomeRelatorioEdicao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_gbBarraSuperiorEdicao
			// 
			this.m_gbBarraSuperiorEdicao.Controls.Add(this.m_gbEspacamento);
			this.m_gbBarraSuperiorEdicao.Controls.Add(this.m_gbAlinhamento);
			this.m_gbBarraSuperiorEdicao.Controls.Add(this.m_gbAgrupar);
			this.m_gbBarraSuperiorEdicao.Controls.Add(this.m_gbUndoEdicao);
			this.m_gbBarraSuperiorEdicao.Controls.Add(this.m_gbVisualizacao);
			this.m_gbBarraSuperiorEdicao.Controls.Add(this.m_gbConfiguracao);
			this.m_gbBarraSuperiorEdicao.Controls.Add(this.m_gbFerramentas);
			this.m_gbBarraSuperiorEdicao.Location = new System.Drawing.Point(74, 336);
			this.m_gbBarraSuperiorEdicao.Name = "m_gbBarraSuperiorEdicao";
			this.m_gbBarraSuperiorEdicao.Size = new System.Drawing.Size(702, 45);
			this.m_gbBarraSuperiorEdicao.TabIndex = 8;
			this.m_gbBarraSuperiorEdicao.TabStop = false;
			this.m_gbBarraSuperiorEdicao.Visible = false;
			// 
			// m_gbEspacamento
			// 
			this.m_gbEspacamento.Controls.Add(this.m_btEspacamentoVertical);
			this.m_gbEspacamento.Controls.Add(this.m_btEspacamentoHorizontal);
			this.m_gbEspacamento.Location = new System.Drawing.Point(609, 6);
			this.m_gbEspacamento.Name = "m_gbEspacamento";
			this.m_gbEspacamento.Size = new System.Drawing.Size(60, 37);
			this.m_gbEspacamento.TabIndex = 21;
			this.m_gbEspacamento.TabStop = false;
			// 
			// m_gbAlinhamento
			// 
			this.m_gbAlinhamento.Controls.Add(this.m_btAlinhamentoCentralizadoEdicao);
			this.m_gbAlinhamento.Controls.Add(this.m_btAlinhamentoEsquerdaEdicao);
			this.m_gbAlinhamento.Controls.Add(this.m_btAlinhamentoDireitaEdicao);
			this.m_gbAlinhamento.Location = new System.Drawing.Point(524, 6);
			this.m_gbAlinhamento.Name = "m_gbAlinhamento";
			this.m_gbAlinhamento.Size = new System.Drawing.Size(85, 37);
			this.m_gbAlinhamento.TabIndex = 20;
			this.m_gbAlinhamento.TabStop = false;
			// 
			// m_gbAgrupar
			// 
			this.m_gbAgrupar.Controls.Add(this.m_btDesagruparEdicao);
			this.m_gbAgrupar.Controls.Add(this.m_btAgruparEdicao);
			this.m_gbAgrupar.Location = new System.Drawing.Point(464, 6);
			this.m_gbAgrupar.Name = "m_gbAgrupar";
			this.m_gbAgrupar.Size = new System.Drawing.Size(60, 37);
			this.m_gbAgrupar.TabIndex = 19;
			this.m_gbAgrupar.TabStop = false;
			// 
			// m_gbUndoEdicao
			// 
			this.m_gbUndoEdicao.Controls.Add(this.m_btReUndoEdicao);
			this.m_gbUndoEdicao.Controls.Add(this.m_btUndoEdicao);
			this.m_gbUndoEdicao.Location = new System.Drawing.Point(362, 6);
			this.m_gbUndoEdicao.Name = "m_gbUndoEdicao";
			this.m_gbUndoEdicao.Size = new System.Drawing.Size(60, 37);
			this.m_gbUndoEdicao.TabIndex = 17;
			this.m_gbUndoEdicao.TabStop = false;
			// 
			// m_gbVisualizacao
			// 
			this.m_gbVisualizacao.Controls.Add(this.m_btVisualizarEdicao);
			this.m_gbVisualizacao.Controls.Add(this.m_btTrocarTeclasAtalhoEdicao);
			this.m_gbVisualizacao.Location = new System.Drawing.Point(4, 6);
			this.m_gbVisualizacao.Name = "m_gbVisualizacao";
			this.m_gbVisualizacao.Size = new System.Drawing.Size(60, 37);
			this.m_gbVisualizacao.TabIndex = 16;
			this.m_gbVisualizacao.TabStop = false;
			// 
			// m_gbConfiguracao
			// 
			this.m_gbConfiguracao.Controls.Add(this.m_btFonteEdicao);
			this.m_gbConfiguracao.Controls.Add(this.m_btCoresEdicao);
			this.m_gbConfiguracao.Controls.Add(this.m_btCanetaEdicao);
			this.m_gbConfiguracao.Location = new System.Drawing.Point(277, 6);
			this.m_gbConfiguracao.Name = "m_gbConfiguracao";
			this.m_gbConfiguracao.Size = new System.Drawing.Size(85, 37);
			this.m_gbConfiguracao.TabIndex = 15;
			this.m_gbConfiguracao.TabStop = false;
			// 
			// m_gbFerramentas
			// 
			this.m_gbFerramentas.Controls.Add(this.m_ckAreaProdutosEdicao);
			this.m_gbFerramentas.Controls.Add(this.m_ckCampoBDEdicao);
			this.m_gbFerramentas.Controls.Add(this.m_ckEtiquetaEdicao);
			this.m_gbFerramentas.Controls.Add(this.m_ckImagemEdicao);
			this.m_gbFerramentas.Controls.Add(this.m_ckRetanguloEdicao);
			this.m_gbFerramentas.Controls.Add(this.m_ckCirculoEdicao);
			this.m_gbFerramentas.Controls.Add(this.m_ckLinhaEdicao);
			this.m_gbFerramentas.Controls.Add(this.m_ckSelecaoEdicao);
			this.m_gbFerramentas.Location = new System.Drawing.Point(64, 6);
			this.m_gbFerramentas.Name = "m_gbFerramentas";
			this.m_gbFerramentas.Size = new System.Drawing.Size(212, 37);
			this.m_gbFerramentas.TabIndex = 14;
			this.m_gbFerramentas.TabStop = false;
			// 
			// frmRelatoriosBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1022, 772);
			this.ControlBox = false;
			this.Controls.Add(this.m_gbBarraSuperiorEdicao);
			this.Controls.Add(this.m_gbBarraInferiorEdicao);
			this.Controls.Add(this.m_hsbHorizontal);
			this.Controls.Add(this.m_vsbVertical);
			this.Controls.Add(this.m_rcRelatorio);
			this.Controls.Add(this.m_gbBarraInferior);
			this.Controls.Add(this.m_gbBarraSuperior);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmRelatoriosBase";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Load += new System.EventHandler(this.frmRelatoriosBase_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmRelatoriosBase_KeyUp);
			this.m_gbBarraSuperior.ResumeLayout(false);
			this.m_gbBarraInferior.ResumeLayout(false);
			this.m_gbBarraInferiorEdicao.ResumeLayout(false);
			this.m_gbBarraSuperiorEdicao.ResumeLayout(false);
			this.m_gbEspacamento.ResumeLayout(false);
			this.m_gbAlinhamento.ResumeLayout(false);
			this.m_gbAgrupar.ResumeLayout(false);
			this.m_gbUndoEdicao.ResumeLayout(false);
			this.m_gbVisualizacao.ResumeLayout(false);
			this.m_gbConfiguracao.ResumeLayout(false);
			this.m_gbFerramentas.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Métodos Referentes ao Carregamento do Relatorio
			public void SetIdRelatorio(int nIdRelatorio)
			{
				m_nIdRelatorio = nIdRelatorio;
			}


			public bool bMostrarRelatorio()
			{
				bool bRetorno;
				bRetorno = m_rcRelatorio.bAbrirRelatorio(m_nIdExportador,m_nTipoRelatorio,m_nIdRelatorio);
				if (bRetorno)
				{
					m_szPagina = m_rcRelatorio.PageSize;
					m_nPaginaAtual = m_rcRelatorio.nCurrentPage();
					m_nTotalPaginas = m_rcRelatorio.nTotalPages();
					refreshInterfaceLabelPagina();
					refreshInterfaceBotoesPagina();
					refreshInterfaceNomeRelatorio();
					refreshInterfaceBandeira();
					if (m_nModo == MODO_VISUALIZACAO)
					{
						m_rcRelatorio.ShowProductArea = false;	
						m_rcRelatorio.ShowGrid = false;
					} 
					if (m_ModificaPosicaoEZoomRelatorio)
						ZoomNormal();
				}
				return (bRetorno);
			}
		#endregion
		#region InitializeEvents
			private void vInitializeEvents()
			{
				this.MouseWheel += new MouseEventHandler(frmRelatoriosBase_MouseWheel);
				this.m_rcRelatorio.eCallPropertiesBoxObjectText += new DrawingCanvasPackage.DrawingCanvas.delCallPropertiesBoxObjectText(this.m_rcRelatorio_eCallPropertiesBoxObjectText);
				this.m_rcRelatorio.ePageNumberChanged += new ReportCanvasPackage.ReportCanvas.delPageNumberChanged(this.m_rcRelatorio_ePageNumberChanged);
				this.m_rcRelatorio.eCallPropertiesBoxObjectImage += new DrawingCanvasPackage.DrawingCanvas.delCallPropertiesBoxObjectImage(this.m_rcRelatorio_eCallPropertiesBoxObjectImage);
				this.m_rcRelatorio.eCallPropertiesBoxObjectRectangle += new DrawingCanvasPackage.DrawingCanvas.delCallPropertiesBoxObjectRectangle(this.m_rcRelatorio_eCallPropertiesBoxObjectRectangle);
				this.m_rcRelatorio.eCallPropertiesBoxObjectCircle += new DrawingCanvasPackage.DrawingCanvas.delCallPropertiesBoxObjectCircle(this.m_rcRelatorio_eCallPropertiesBoxObjectCircle);
				this.m_rcRelatorio.ePageCountChanged += new ReportCanvasPackage.ReportCanvas.delPageCountChanged(this.m_rcRelatorio_ePageCountChanged);
				this.m_rcRelatorio.eCallPropertiesBoxObjectTextDB += new ReportCanvasPackage.ReportCanvas.delCallPropertiesBoxObjectTextDB(this.m_rcRelatorio_eCallPropertiesBoxObjectTextDB);
				this.m_rcRelatorio.eCallPropertiesBoxObjectLine += new DrawingCanvasPackage.DrawingCanvas.delCallPropertiesBoxObjectLine(this.m_rcRelatorio_eCallPropertiesBoxObjectLine);
				this.m_rcRelatorio.eCallToolChanged += new DrawingCanvasPackage.DrawingCanvas.delCallToolChanged(this.m_rcRelatorio_eCallToolChanged);
			}
		#endregion

		#region Refreshs Interface

		protected virtual bool bResizeForm()
		{
            // Resize do Form Principal 
			this.Size = new System.Drawing.Size(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width - 10,System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height - 38);

            // Barra Superior
            m_gbBarraSuperior.Width = Width - (m_gbBarraSuperior.Location.X + 2);
			m_gbBarraSuperior.Top += 2;

			// Barra Superior Edicao
			m_gbBarraSuperiorEdicao.Width = m_gbBarraSuperior.Width;
			m_gbBarraSuperiorEdicao.Location = m_gbBarraSuperior.Location;

            // Barra Inferior 
            m_gbBarraInferior.Width = Width - (m_gbBarraInferior.Location.X + 4);
            m_gbBarraInferior.Location = new System.Drawing.Point(m_gbBarraInferior.Location.X, this.Height - (m_gbBarraInferior.Height + 2));

			// Barra Inferior Edicao
			m_gbBarraInferiorEdicao.Width = m_gbBarraInferior.Width;
			m_gbBarraInferiorEdicao.Location = m_gbBarraInferior.Location;

			// Barra de Rolagem Vertical
			m_vsbVertical.Left = Width - m_vsbVertical.Width - 2;
			m_vsbVertical.Top = (m_gbBarraSuperior.Top + m_gbBarraSuperior.Height) + 2;
			m_vsbVertical.Height = m_gbBarraInferior.Top - (m_vsbVertical.Top + 15); 

			// Barra de Rolagem Horizontal 
			m_hsbHorizontal.Top = m_gbBarraInferior.Top - 15;
			m_hsbHorizontal.Width = m_gbBarraSuperior.Width - m_vsbVertical.Width;

			// Report Canvas 
			m_rcRelatorio.Size = new System.Drawing.Size(m_hsbHorizontal.Width,m_vsbVertical.Height);

            // Items da Barra Inferior
			m_btUltimaPagina.Left = m_gbBarraInferior.Width - 30;
			m_btProximaPagina.Left = m_btUltimaPagina.Left - 28;
			m_lbPaginaAtual.Left = m_btProximaPagina.Left - 36;
			m_btPaginaAnterior.Left = m_lbPaginaAtual.Left - 28;
			m_btPrimeiraPagima.Left = m_btPaginaAnterior.Left - 28;
			m_btIdioma.Left = m_btPrimeiraPagima.Left - 28;
			m_btIdioma.Top = m_btPrimeiraPagima.Top;

			// Nome do Relatorio Atual
			m_lbNomeRelatorio.Left =  m_btIdioma.Left - (m_lbNomeRelatorio.Width + 20 ) ;

			// Nome do Relatorio Atual (EDICAO)
			m_lbNomeRelatorioEdicao.Left = m_lbNomeRelatorio.Left;

			return true;
		}

		private void refreshInterfaceBandeira()
		{
			if (m_btIdioma.Visible)
			{ 
				if ((m_nIdIdioma - 1) >= 0 )
					m_btIdioma.Image = m_ilBandeiras.Images[m_nIdIdioma - 1];
				else
					m_btIdioma.Image = m_ilBandeiras.Images[0];
			}
		}

		private void refreshInterfaceLabelPagina()
		{
            m_lbPaginaAtual.Text = (m_nPaginaAtual + 1)+ "/" + m_nTotalPaginas;            
		}

		private void refreshInterfaceBotoesPagina()
		{
			if (m_nTotalPaginas <= 1)
			{
				m_btPrimeiraPagima.Visible = false;	
				m_btPaginaAnterior.Visible = false;
				m_lbPaginaAtual.Visible = false;
				m_btProximaPagina.Visible = false;
				m_btUltimaPagina.Visible = false;
			}else
			{
				m_btPrimeiraPagima.Visible = true;	
				m_btPaginaAnterior.Visible = true;
				m_lbPaginaAtual.Visible = true;
				m_btProximaPagina.Visible = true;
				m_btUltimaPagina.Visible = true;
				switch(m_nPaginaAtual)
				{
					case 0:
						m_btPrimeiraPagima.Enabled = false;	
						m_btPaginaAnterior.Enabled = false;
						if (m_nTotalPaginas == 1)
						{
							m_btProximaPagina.Enabled = false;
							m_btUltimaPagina.Enabled = false;
						}
						else
						{
							m_btProximaPagina.Enabled = true;
							m_btUltimaPagina.Enabled = true;
						}
						break;
					default:
						if ((m_nPaginaAtual + 1) == m_nTotalPaginas)
						{
							m_btPrimeiraPagima.Enabled = true;	
							m_btPaginaAnterior.Enabled = true;
							m_btProximaPagina.Enabled = false;
							m_btUltimaPagina.Enabled = false;
						}
						else
						{
							m_btPrimeiraPagima.Enabled = true;	
							m_btPaginaAnterior.Enabled = true;
							m_btProximaPagina.Enabled = true;
							m_btUltimaPagina.Enabled = true;
						}
						break;
				}
			}
        }
		private void refreshInterfaceNomeRelatorio()
		{
			if (m_rcRelatorio.GetReportName() != "")
			{
				if (m_nIdRelatorio > 0)
				{
					m_lbNomeRelatorio.Font = new System.Drawing.Font(m_lbNomeRelatorio.Font,System.Drawing.FontStyle.Regular);  
					m_lbNomeRelatorioEdicao.Font = m_lbNomeRelatorio.Font;
					m_lbNomeRelatorio.Text = m_rcRelatorio.GetReportName() + " ";
					m_lbNomeRelatorioEdicao.Text = m_lbNomeRelatorio.Text;
				}
				else
				{
					m_lbNomeRelatorio.Font = new System.Drawing.Font(m_lbNomeRelatorio.Font,System.Drawing.FontStyle.Bold);  
					m_lbNomeRelatorioEdicao.Font = m_lbNomeRelatorio.Font;
					m_lbNomeRelatorio.Text = m_rcRelatorio.GetReportName() + " ";
					m_lbNomeRelatorioEdicao.Text = m_lbNomeRelatorio.Text;
				}
			}else{
				m_lbNomeRelatorio.Text = "";
				m_lbNomeRelatorioEdicao.Text = "";
			}
		}
		#endregion
		#region Métodos Referentes as Barras de Rolagem do Relatorio
		protected void ajustaTamanhoBarrasRolagem()
		{
				m_hsbHorizontal.Maximum = m_szPagina.Width;
				m_vsbVertical.Maximum = m_szPagina.Height;
		}

		private void m_hsbHorizontal_ValueChanged(object sender, System.EventArgs e)
		{
			m_rcRelatorio.bMoveWindow(new System.Drawing.Point(m_hsbHorizontal.Value - 50 ,m_vsbVertical.Value - 50 ));
		}

		private void m_vsbVertical_ValueChanged(object sender, System.EventArgs e)
		{
				m_rcRelatorio.bMoveWindow(new System.Drawing.Point(m_hsbHorizontal.Value - 50 ,m_vsbVertical.Value - 50 ));
		}
		#endregion
		#region Métodos Referentes as Teclas de Atalho
		/// <summary>
		/// Executa a Acao referente a Tecla de Atalho 
		/// </summary>
		/// <param name="idAcao"></param>
		private bool bExecutaTeclaAtalho(int idAcao)
		{
			bool bRetorno = true;
			switch(idAcao)
			{
				case 1: // Delete 
					if (m_nModo == MODO_EDICAO)
					{
						m_rcRelatorio.bDeleteObj();
					}
					break;

				case 2: // Selecionando todos os Objetos 
					if (m_nModo == MODO_EDICAO)
					{
						m_rcRelatorio.bSelectAll(true);
					}
					break;

				case 3: // Menos Zoom
						m_btZoomMenos_Click(null,null);
					break;

				case 4: // Zoom Normal
						m_btZoomNormal_Click(null,null);
					break;

				case 5: // Mais Zoom
						m_btZoomMais_Click(null,null);
					break;

				case 6: // Undo
					if (m_nModo == MODO_EDICAO)
					{
						m_btUndoEdicao_Click(null,null);
					}
					break;
				case 7: // Redo
					if (m_nModo == MODO_EDICAO)
					{
						m_btReUndoEdicao_Click(null,null);
					}
					break;
				case 8: // Imprimir 
					if (m_nModo == MODO_VISUALIZACAO)
					{
						m_btImprimir_Click(null,null);
					}
					break;
				case 9: // Foto 
					if (m_nModo == MODO_VISUALIZACAO)
					{
						m_btSalvarImagem_Click(null,null);
					}
					break;

				case 10: // Email
					if (m_nModo == MODO_VISUALIZACAO)
					{
						m_btEnviarImagemEmail_Click(null,null);
					}
					break;

				case 11: // Trocar Relatorio
						m_btTrocarRelatorio_Click(null,null);
					break;

				case 12: // Visualizar / Editar 
					if (m_nModo == MODO_VISUALIZACAO)
						m_btModoEdicao_Click(null,null);
					else
						m_btModoVisualizacao_Click(null,null);
					break;

				case 13: // Exportar
					if (m_nModo == MODO_VISUALIZACAO)
					{
						m_btExportar_Click(null,null);
					}
					break;
				case 14: // Importar 
					if (m_nModo == MODO_VISUALIZACAO)
					{
						m_btImportar_Click(null,null);
					}
					break;

				case 15: // Idioma 
					if (m_nModo == MODO_VISUALIZACAO)
					{
						m_btIdioma_Click(null,null);
					}
					break;

				case 16: // Salvar 
					if (m_nModo == MODO_EDICAO)
					{
						m_btSalvarEdicao_Click(null,null);
					}
					break;

				case 17: // Salvar Como
					if (m_nModo == MODO_EDICAO)
					{
						m_btSalvarComoEdicao_Click(null,null);
					}
					break;

				case 18: // Visualizar
					if (m_nModo == MODO_EDICAO)
					{
						m_btVisualizarEdicao_Click(null,null);
					}
					break;

				case 19: // Selecao
					if (m_nModo == MODO_EDICAO)
					{
						m_ckSelecaoEdicao.Checked = true;	
						m_rcRelatorio.refreshCursor();
					}
					break;

				case 20: // Linha
					if (m_nModo == MODO_EDICAO)
					{
						m_ckLinhaEdicao.Checked = true;	
						m_rcRelatorio.refreshCursor();
					}
					break;

				case 21: // Circulo
					if (m_nModo == MODO_EDICAO)
					{
						m_ckCirculoEdicao.Checked = true;	
						m_rcRelatorio.refreshCursor();
					}
					break;

				case 22: // Retangulo
					if (m_nModo == MODO_EDICAO)
					{
						m_ckRetanguloEdicao.Checked = true;	
						m_rcRelatorio.refreshCursor();
					}
					break;

				case 23: // Imagem
					if (m_nModo == MODO_EDICAO)
					{
						m_ckImagemEdicao.Checked = true;	
						m_rcRelatorio.refreshCursor();
					}
					break;

				case 24: // Texto
					if (m_nModo == MODO_EDICAO)
					{
						m_ckEtiquetaEdicao.Checked = true;	
						m_rcRelatorio.refreshCursor();
					}
					break;

				case 25: // texto Dinamico
					if (m_nModo == MODO_EDICAO)
					{
						m_ckCampoBDEdicao.Checked = true;	
						m_rcRelatorio.refreshCursor();
					}
					break;

				case 26: // Area Produtos
					if (m_nModo == MODO_EDICAO)
					{
						m_ckAreaProdutosEdicao.Checked = true;	
						m_rcRelatorio.refreshCursor();
					}
					break;
					
				case 27: // Esquerda
					if (m_hsbHorizontal.Value >= m_hsbHorizontal.Minimum + DESLOCAMENTO_SCROLLBARS)
						m_hsbHorizontal.Value = m_hsbHorizontal.Value - DESLOCAMENTO_SCROLLBARS;
					break;

				case 28: // Acima 
					if (m_vsbVertical.Value >= m_vsbVertical.Minimum + DESLOCAMENTO_SCROLLBARS)
						m_vsbVertical.Value = m_vsbVertical.Value - DESLOCAMENTO_SCROLLBARS;
					break;

				case 29: // Direita 
					if (m_hsbHorizontal.Value + DESLOCAMENTO_SCROLLBARS <= m_hsbHorizontal.Maximum)
						m_hsbHorizontal.Value = m_hsbHorizontal.Value + DESLOCAMENTO_SCROLLBARS;
					break;

				case 30: // Abaixo 
					if (m_vsbVertical.Value + DESLOCAMENTO_SCROLLBARS <= m_vsbVertical.Maximum)
						m_vsbVertical.Value = m_vsbVertical.Value + DESLOCAMENTO_SCROLLBARS;
					break;

				case 31: // Copiar
					if (m_nModo == MODO_EDICAO)
						m_rcRelatorio.bCopyToClipBoard();
					break;

				case 32: // Colar 
					if (m_nModo == MODO_EDICAO)
						m_rcRelatorio.bCopyFromClipBoard();
					break;
				case 33: // Objects left
					if (m_nModo == MODO_EDICAO)
						m_rcRelatorio.bMoveSelectedObjects(-OBJECTS_MOVE,0);
					break;
				case 34: // Objects Up
					if (m_nModo == MODO_EDICAO)
						m_rcRelatorio.bMoveSelectedObjects(0,-OBJECTS_MOVE);
					break;
				case 35: // Objects Right
					if (m_nModo == MODO_EDICAO)
						m_rcRelatorio.bMoveSelectedObjects(OBJECTS_MOVE,0);
					break;
				case 36: // Objects Down
					if (m_nModo == MODO_EDICAO)
						m_rcRelatorio.bMoveSelectedObjects(0,OBJECTS_MOVE);
					break;
				case 37: // Objects Left Less
					if (m_nModo == MODO_EDICAO)
						m_rcRelatorio.bMoveSelectedObjects(-OBJECTS_MOVE_LESS,0);
					break;
				case 38: // Objects Up Less
					if (m_nModo == MODO_EDICAO)
						m_rcRelatorio.bMoveSelectedObjects(0,-OBJECTS_MOVE_LESS);
					break;
				case 39: // Objects Right Less
					if (m_nModo == MODO_EDICAO)
						m_rcRelatorio.bMoveSelectedObjects(OBJECTS_MOVE_LESS,0);
					break; 
				case 40: // Objects Down Less
					if (m_nModo == MODO_EDICAO)
						m_rcRelatorio.bMoveSelectedObjects(0,OBJECTS_MOVE_LESS);
					break;
				default:
					bRetorno = false;
					break;
			}
			return (bRetorno);
		}

		/// <summary>
		/// Carregando as Teclas de Atalho do Relatorio 
		/// </summary>
		private void carregaTeclasAtalho()
		{
			System.Windows.Forms.KeyEventArgs keaKey;
			mdlManipuladorArquivo.clsManipuladorArquivoIni cls_ini_Arquivo = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			string strValor;

			m_arlTeclasAtalhoNomes = new ArrayList();
			m_arlTeclasAtalhoNomesNoIni = new ArrayList();
			m_arlTeclasAtalhoTeclas = new ArrayList();
			m_arlTeclasAtalhoAcoes = new ArrayList();

			// Delete 
			m_arlTeclasAtalhoNomes.Add("Excluir Objeto");
			m_arlTeclasAtalhoNomesNoIni.Add("Delete");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)System.Windows.Forms.Keys.Delete).ToString());
			try
			{
				keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}catch{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
            m_arlTeclasAtalhoAcoes.Add(1);

			// Selecionar Tudo 
			m_arlTeclasAtalhoNomes.Add("Selecionar todos os Objetos");
			m_arlTeclasAtalhoNomesNoIni.Add("SelectAll");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)).ToString());
			try
			{
				keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}catch{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(2);

			// Menos Zoom
			m_arlTeclasAtalhoNomes.Add("Menos Zoom");
			m_arlTeclasAtalhoNomesNoIni.Add("LessZoom");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Subtract)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}

			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(3);

			// Zoom Normal
			m_arlTeclasAtalhoNomes.Add("Zoom Normal");
			m_arlTeclasAtalhoNomesNoIni.Add("NormalZoom");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Oemplus)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(4);

			// Mais Zoom
			m_arlTeclasAtalhoNomes.Add("Mais Zoom");
			m_arlTeclasAtalhoNomesNoIni.Add("MoreZoom");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Add)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(5);

			// Desfazer 
			m_arlTeclasAtalhoNomes.Add("Desfazer");
			m_arlTeclasAtalhoNomesNoIni.Add("Undo");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(6);

			// Refazer 
			m_arlTeclasAtalhoNomes.Add("Refazer");
			m_arlTeclasAtalhoNomesNoIni.Add("ReUndo");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Z)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(7);

			// Imprimir
			m_arlTeclasAtalhoNomes.Add("Imprimir");
			m_arlTeclasAtalhoNomesNoIni.Add("Print");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(8);

			// Foto
			m_arlTeclasAtalhoNomes.Add("Foto");
			m_arlTeclasAtalhoNomesNoIni.Add("Image");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(9);


			// Email
			m_arlTeclasAtalhoNomes.Add("E-Mail");
			m_arlTeclasAtalhoNomesNoIni.Add("Email");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(10);

			// Trocar Relatorio
			m_arlTeclasAtalhoNomes.Add("Trocar Relatório");
			m_arlTeclasAtalhoNomesNoIni.Add("ChangeReport");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(11);

			// Visualizacao / Manipulacao
			m_arlTeclasAtalhoNomes.Add("Visualizar/Editar");
			m_arlTeclasAtalhoNomesNoIni.Add("ViewEdit");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.F2)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(12);

			// Exportar
			m_arlTeclasAtalhoNomes.Add("Exportar");
			m_arlTeclasAtalhoNomesNoIni.Add("Export");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.E)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(13);

			// Importador
			m_arlTeclasAtalhoNomes.Add("Importar");
			m_arlTeclasAtalhoNomesNoIni.Add("Import");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.I)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(14);

			// Idioma 
			m_arlTeclasAtalhoNomes.Add("Idioma");
			m_arlTeclasAtalhoNomesNoIni.Add("Language");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(15);

			// Salvar 
			m_arlTeclasAtalhoNomes.Add("Salvar");
			m_arlTeclasAtalhoNomesNoIni.Add("Save");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(16);

			// Salvar Como 
			m_arlTeclasAtalhoNomes.Add("Salvar Como");
			m_arlTeclasAtalhoNomesNoIni.Add("SaveAs");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.S)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(17);

			// Visualizar
			m_arlTeclasAtalhoNomes.Add("Visualizar");
			m_arlTeclasAtalhoNomesNoIni.Add("View");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(18);

			// Selecionar Objetos 
			m_arlTeclasAtalhoNomes.Add("Selecionar Objetos");
			m_arlTeclasAtalhoNomesNoIni.Add("ObjSel");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Oemtilde)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(19);

			// Inserir Linhas 
			m_arlTeclasAtalhoNomes.Add("Inserir Linhas");
			m_arlTeclasAtalhoNomesNoIni.Add("ObjLine");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.D1)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(20);

			// Inserir Circulos
			m_arlTeclasAtalhoNomes.Add("Inserir Circulos");
			m_arlTeclasAtalhoNomesNoIni.Add("ObjCirc");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.D2)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(21);

			// Inserir Retangulos
			m_arlTeclasAtalhoNomes.Add("Inserir Retangulos");
			m_arlTeclasAtalhoNomesNoIni.Add("ObjRet");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.D3)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(22);

			// Inserir Imagens
			m_arlTeclasAtalhoNomes.Add("Inserir Imagens");
			m_arlTeclasAtalhoNomesNoIni.Add("ObjPic");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.D4)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(23);

			// Inserir Texto
			m_arlTeclasAtalhoNomes.Add("Inserir Texto");
			m_arlTeclasAtalhoNomesNoIni.Add("ObjText");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.D5)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(24);

			// Inserir Textos Dinamicos
			m_arlTeclasAtalhoNomes.Add("Inserir Texto Dinâmico");
			m_arlTeclasAtalhoNomesNoIni.Add("ObjTextD");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.D6)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(25);

			// Inserir Area Produtos 
			m_arlTeclasAtalhoNomes.Add("Inserir Área Produtos");
			m_arlTeclasAtalhoNomesNoIni.Add("ObjProdArea");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.D7)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(26);

			// Deslocamento no Relatorio 
			// Esquerda
			m_arlTeclasAtalhoNomes.Add("Esquerda");
			m_arlTeclasAtalhoNomesNoIni.Add("repLeft");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.F9)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(27);

			// Acima
			m_arlTeclasAtalhoNomes.Add("Acima");
			m_arlTeclasAtalhoNomesNoIni.Add("repUp");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.F10)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(28);

			// Direita
			m_arlTeclasAtalhoNomes.Add("Direita");
			m_arlTeclasAtalhoNomesNoIni.Add("repRight");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.F11)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(29);

			// Abaixo
			m_arlTeclasAtalhoNomes.Add("Abaixo");
			m_arlTeclasAtalhoNomesNoIni.Add("repDown");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.F12)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(30);

			// Copiar
			m_arlTeclasAtalhoNomes.Add("Copiar");
			m_arlTeclasAtalhoNomesNoIni.Add("Copy");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(31);

			// Colar
			m_arlTeclasAtalhoNomes.Add("Colar");
			m_arlTeclasAtalhoNomesNoIni.Add("Paste");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(32);

			// Objetos Selecionados Esquerda
			m_arlTeclasAtalhoNomes.Add("Mover Objetos Esquerda");
			m_arlTeclasAtalhoNomesNoIni.Add("SelectObjectLeft");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Left)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(33);

			// Objetos Selecionados Acima
			m_arlTeclasAtalhoNomes.Add("Mover Objetos Acima");
			m_arlTeclasAtalhoNomesNoIni.Add("SelectObjectUp");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Up)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(34);

			// Objetos Selecionados Direita
			m_arlTeclasAtalhoNomes.Add("Mover Objetos Direita");
			m_arlTeclasAtalhoNomesNoIni.Add("SelectObjectRight");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Right)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(35);

			// Objetos Selecionados Abaixo
			m_arlTeclasAtalhoNomes.Add("Mover Objetos Abaixo");
			m_arlTeclasAtalhoNomesNoIni.Add("SelectObjectDown");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Down)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(36);

			// Objetos Selecionados Suavemente Esquerda
			m_arlTeclasAtalhoNomes.Add("Mover Objetos Suavamente Esquerda");
			m_arlTeclasAtalhoNomesNoIni.Add("SelectObjectLeftLess");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(37);

			// Objetos Selecionados Suavemente Acima
			m_arlTeclasAtalhoNomes.Add("Mover Objetos Suavamente Acima");
			m_arlTeclasAtalhoNomesNoIni.Add("SelectObjectUpLess");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(38);

			// Objetos Selecionados Suavemente Direita
			m_arlTeclasAtalhoNomes.Add("Mover Objetos Suavamente Direita");
			m_arlTeclasAtalhoNomesNoIni.Add("SelectObjectRightLess");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(39);

			// Objetos Selecionados Suavemente Abaixo
			m_arlTeclasAtalhoNomes.Add("Mover Objetos Suavamente Abaixo");
			m_arlTeclasAtalhoNomesNoIni.Add("SelectObjectDownLess");
			strValor = cls_ini_Arquivo.retornaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[m_arlTeclasAtalhoNomesNoIni.Count - 1],((int)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)).ToString());
			try{
			keaKey = new System.Windows.Forms.KeyEventArgs((System.Windows.Forms.Keys)(Int32.Parse(strValor)));
			}
			catch
			{
				keaKey = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.NumLock);
			}
			m_arlTeclasAtalhoTeclas.Add(keaKey);
			m_arlTeclasAtalhoAcoes.Add(40);

			// Acionando as teclas de atalho 
			this.KeyPreview = true;
		}

		/// <summary>
		/// Salvando as Teclas de Atalho do Relatorio 
		/// </summary>
		private void salvaTeclasAtalho()
		{
			mdlManipuladorArquivo.clsManipuladorArquivoIni cls_ini_Arquivo = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			string strValor;

			for (int nCont = 0 ;nCont < m_arlTeclasAtalhoNomesNoIni.Count;nCont++)
			{
				strValor = (((System.Windows.Forms.KeyEventArgs)m_arlTeclasAtalhoTeclas[nCont]).KeyValue).ToString();
				cls_ini_Arquivo.colocaValor(NOMESESSAOTECLASATALHO,(string)m_arlTeclasAtalhoNomesNoIni[nCont],strValor);    
			}
		}

		private void mostraTeclasAtalho()
		{
			this.Cursor  = System.Windows.Forms.Cursors.WaitCursor;
			mdlRelatoriosJanelas.frmFRelatoriosTeclasAtalho formTeclasAtalho = new mdlRelatoriosJanelas.frmFRelatoriosTeclasAtalho(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,ref m_arlTeclasAtalhoNomes,ref m_arlTeclasAtalhoTeclas,ref m_arlTeclasAtalhoNomesNoIni,ref m_arlTeclasAtalhoAcoes);
			formTeclasAtalho.ShowDialog();
			if (formTeclasAtalho.m_bModificado)
			{
				formTeclasAtalho.vRetornaValores(out m_arlTeclasAtalhoTeclas);
				salvaTeclasAtalho();
			}
			formTeclasAtalho = null;
			this.Cursor  = System.Windows.Forms.Cursors.Default;
		}
		#endregion

		#region Métodos Referentes ao Modo Edicao
			private void vMudaModoVisualizacao()
			{
				bool bAtivado = true;
				switch(m_nModo)
				{
					case MODO_VISUALIZACAO:
						if (bAtivado)
						{
							// DesSelecioando qualquer ferramenta previamente selecionada 
							m_ckSelecaoEdicao.Checked = false;
							m_ckLinhaEdicao.Checked = false;
							m_ckCirculoEdicao.Checked = false;
							m_ckImagemEdicao.Checked = false;
							m_ckRetanguloEdicao.Checked = false;
							m_ckEtiquetaEdicao.Checked = false;
							m_ckCampoBDEdicao.Checked = false;
							m_ckAreaProdutosEdicao.Checked = false;
								
							m_btSalvarEdicao.Enabled = true;

							// Barras 
							m_gbBarraSuperiorEdicao.Visible = true;
							m_gbBarraSuperior.Visible = false;
							m_gbBarraInferiorEdicao.Visible = true;	
							m_gbBarraInferior.Visible = false;	

							bAtivado = false;
							m_rcRelatorio.SetViewMode(false);  
							m_nModo = MODO_EDICAO;  
							m_ModificaPosicaoEZoomRelatorio = false;
							bMostrarRelatorio();
							m_ModificaPosicaoEZoomRelatorio = true;
							m_ckSelecaoEdicao.Checked = true;	
						}
						break;
					case MODO_EDICAO:
						if (bAtivado)
						{
							//Barras 
							m_ckSelecaoEdicao.Checked = false;
							m_ckLinhaEdicao.Checked = false;
							m_ckCirculoEdicao.Checked = false;
							m_ckImagemEdicao.Checked = false;
							m_ckRetanguloEdicao.Checked = false;
							m_ckEtiquetaEdicao.Checked = false;
							m_ckCampoBDEdicao.Checked = false;
							m_ckAreaProdutosEdicao.Checked = false;

							m_gbBarraSuperior.Visible = true;
							m_gbBarraSuperiorEdicao.Visible = false;
							m_gbBarraInferior.Visible = true;	
							m_gbBarraInferiorEdicao.Visible = false;	

							bAtivado = false;

							// Area Produtos 
							m_rcRelatorio.SetViewMode(true);                                                
							m_nModo = MODO_VISUALIZACAO;                
							m_ModificaPosicaoEZoomRelatorio = false;
							bMostrarRelatorio();                  
							m_ModificaPosicaoEZoomRelatorio = true;
						}
						break;
				}
			}
		#endregion

		#region Métodos Referentes a Barra Ferramentas Inferior
			#region Métodos Referentes ao Zoom
			private void m_btZoomMenos_Click(object sender, System.EventArgs e)
			{
				m_rcRelatorio.bLessZoom();
				m_szPagina = m_rcRelatorio.PageSize;
				ajustaTamanhoBarrasRolagem();
			}

			private void m_btZoomNormal_Click(object sender, System.EventArgs e)
			{
				ZoomNormal();
			}
			private void ZoomNormal()
			{
				m_rcRelatorio.bDefaultZoom();
				m_szPagina = m_rcRelatorio.PageSize;
				ajustaTamanhoBarrasRolagem();

				if ( ((45 + m_rcRelatorio.GetLeftMargin()) >=  m_hsbHorizontal.Minimum) & ((45 + m_rcRelatorio.GetLeftMargin()) <= m_hsbHorizontal.Maximum) )
					m_hsbHorizontal.Value = 45 + m_rcRelatorio.GetLeftMargin();
				else
					m_hsbHorizontal.Value =	m_hsbHorizontal.Minimum;

				if ( ((45 + m_rcRelatorio.GetTopMargin()) >=  m_vsbVertical.Minimum) & ((45 + m_rcRelatorio.GetTopMargin()) <= m_vsbVertical.Maximum) )
					m_vsbVertical.Value = 45 + m_rcRelatorio.GetTopMargin();
				else
					m_vsbVertical.Value =	m_vsbVertical.Minimum;

				m_rcRelatorio.RefreshRelatorio();
			}

			private void m_btZoomMais_Click(object sender, System.EventArgs e)
			{
				m_rcRelatorio.bMoreZoom();
				m_szPagina = m_rcRelatorio.PageSize;
				ajustaTamanhoBarrasRolagem();
			}
			#endregion
			#region Métodos Referentes ao Deslocamento entre paginas
			private void m_btPrimeiraPagima_Click(object sender, System.EventArgs e)
			{
				if (m_rcRelatorio.bFirstPage())
				{
					m_nPaginaAtual = m_rcRelatorio.nCurrentPage();
					m_nTotalPaginas = m_rcRelatorio.nTotalPages();
					refreshInterfaceLabelPagina();
					refreshInterfaceBotoesPagina();
				}
			}

			private void m_btPaginaAnterior_Click(object sender, System.EventArgs e)
			{
				if (m_rcRelatorio.bPreviousPage())
				{
					m_nPaginaAtual = m_rcRelatorio.nCurrentPage();
					m_nTotalPaginas = m_rcRelatorio.nTotalPages();
					refreshInterfaceLabelPagina();
					refreshInterfaceBotoesPagina();
				}
			}

			private void m_btProximaPagina_Click(object sender, System.EventArgs e)
			{
				if (m_rcRelatorio.bNextPage())
				{
					m_nPaginaAtual = m_rcRelatorio.nCurrentPage();
					m_nTotalPaginas = m_rcRelatorio.nTotalPages();
					refreshInterfaceLabelPagina();
					refreshInterfaceBotoesPagina();
				}
			}

			private void m_btUltimaPagina_Click(object sender, System.EventArgs e)
			{
				if (m_rcRelatorio.bLastPage())
				{
					m_nPaginaAtual = m_rcRelatorio.nCurrentPage();
					m_nTotalPaginas = m_rcRelatorio.nTotalPages();
					refreshInterfaceLabelPagina();
					refreshInterfaceBotoesPagina();
				}
			}
			#endregion
			#region Importação e Exportação dos Relatórios
			/// <summary>
			/// Exportando Relatorios.
			/// </summary>
			private void m_btExportar_Click(object sender, System.EventArgs e)
			{
//				string strNomeRelatorio = m_rcRelatorio.GetReportName();
//				if ((strNomeRelatorio != "") && (strNomeRelatorio != "No name"))
//				{
//					System.Windows.Forms.SaveFileDialog dlgSave = new System.Windows.Forms.SaveFileDialog();
//					dlgSave.Filter = "Relatórios Siscobras.NET (*.rel)|*.rel";
//					if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
//					{
//						string strNomeArquivo;
//						string strNomeArquivoSaida = dlgSave.FileName;
//						mdlZip.clsZip cls_zip = new mdlZip.clsZip();
//						ADODB.Recordset rstDados;
//						string strCondicao;
//						string strSQLCommand;
//						int nNumTabelas = 7;
//						string[] strNomeTabelas = new string[7] {"tbRelatorios", "tbRelatorioLinhas", "tbRelatorioRetangulos","tbRelatorioCirculos","tbRelatorioEtiquetas","tbRelatorioCamposBD","tbRelatorioImagens"};
//
//						// Adiquirindo a Condicao do SQL
//						if (m_nIdExportador < 1) // Padrao
//							strCondicao = "WHERE (idTipo = " + m_nTipoRelatorio + " ) AND (idRelatorio = " + m_nIdRelatorio + ") ";
//						else // Normal
//							strCondicao = "WHERE (idExportador = " + m_nIdExportador + " ) AND (idTipo = " + m_nTipoRelatorio + " ) AND (idRelatorio = " + m_nIdRelatorio + ") ";
//
//						// Gerando os arquivos
//						for (int nCont = 0; nCont < nNumTabelas ;nCont++)
//						{
//							// Montando o SQL da tabela atual 
//							strSQLCommand = "SELECT * FROM " + strNomeTabelas[nCont] + " " + strCondicao;
//							// Caso Especial "tbRelatorioImagens"
//							if (nCont == 6)
//								strSQLCommand = "SELECT tbRelatorioImagens.*, tbImagens.strNome , tbImagens.strDados FROM tbRelatorioImagens INNER JOIN tbImagens ON tbRelatorioImagens.nIdImagem = tbImagens.idImagem " + strCondicao;
//							rstDados = m_cls_abd_conexaoBD.executa(strSQLCommand);
//							if (System.IO.File.Exists(m_strEnderecoExecutavel + strNomeTabelas[nCont]))
//							{
//								System.IO.File.Delete(m_strEnderecoExecutavel + strNomeTabelas[nCont]);                        
//							}
//							rstDados.Save((m_strEnderecoExecutavel + strNomeTabelas[nCont]),ADODB.PersistFormatEnum.adPersistXML);
//						}
//
//						// Apagando o arquivo de saida caso ele exista 
//						if (System.IO.File.Exists(strNomeArquivoSaida))
//						{
//							System.IO.File.Delete(strNomeArquivoSaida);
//						}
//
//						// Compactando os arquivos 
//						for (int nCont = 0; nCont < nNumTabelas;nCont++)
//						{
//							strNomeArquivo = m_strEnderecoExecutavel + strNomeTabelas[nCont];
//							if (nCont == 0)
//							{
//								cls_zip.compacta(ref strNomeArquivoSaida,ref strNomeArquivo,false);
//							}
//							cls_zip.compacta(ref strNomeArquivoSaida,ref strNomeArquivo,false);
//							System.IO.File.Delete(strNomeArquivo);
//						}
//
//						MessageBox.Show("Relatório '" + strNomeRelatorio +   "' exportado com Sucesso em " + strNomeArquivoSaida ,"Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
//					} 
//					dlgSave = null;
//				}else{
//					MessageBox.Show("Para exportar um Relatório você deve carregá-lo primeiro.","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
//				}
			}
			/// <summary>
			/// Importando Relatorio Botao.
			/// </summary>
			private void m_btImportar_Click(object sender, System.EventArgs e)
			{
				if (bRelatorioImportar())
				{
				}
			}
			/// <summary>
			/// Importando Relatorio.
			/// </summary>
			private bool bRelatorioImportar()
			{
				// Abrindo o arquivo do relatorio
//				System.Windows.Forms.OpenFileDialog dlgOpen = new System.Windows.Forms.OpenFileDialog();
//				dlgOpen.Filter = "Relatórios Siscobras.NET (*.rel)|*.rel";
//				if (dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
//				{
//					string strNomeArquivoEntrada = dlgOpen.FileName;
//					mdlZip.clsZip cls_zip = new mdlZip.clsZip();
//					int nNumTabelas = 7;
//					string strNomeTabela;
//					string[] strNomeTabelas = new string[7] {"tbRelatorios", "tbRelatorioLinhas", "tbRelatorioRetangulos","tbRelatorioCirculos","tbRelatorioEtiquetas","tbRelatorioCamposBD","tbRelatorioImagens"};
//					bool bRetorno = false;
//					ADODB.Recordset rstDados;
//
//					// Descompactando o arquivo
//					for (int nCont = 0; nCont < nNumTabelas;nCont++)
//					{
//						strNomeTabela = strNomeTabelas[nCont];
//						// Apagando o arquivo caso ele exista 
//						if (System.IO.File.Exists(m_strEnderecoExecutavel + strNomeTabelas[nCont]))
//							System.IO.File.Delete(m_strEnderecoExecutavel + strNomeTabelas[nCont]);
//
//						// Descompactando o arquivo 
//						if (nCont == 0)
//							cls_zip.descompacta(ref strNomeArquivoEntrada,ref strNomeTabela,ref m_strEnderecoExecutavel,ref bRetorno);
//						cls_zip.descompacta(ref strNomeArquivoEntrada,ref strNomeTabela,ref m_strEnderecoExecutavel,ref bRetorno);
//						if (!System.IO.File.Exists(m_strEnderecoExecutavel + strNomeTabelas[nCont]))
//						{
//							MessageBox.Show("O arquivo escolhido não é um arquivo de relatório válido.","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
//							return (false);
//						}
//					}
//
//					// Abrindo a mdlRelatorios e fazendo checagens iniciais
//                    ADODB.Recordset rstRelatorio = new ADODB.RecordsetClass();
//					rstRelatorio = m_cls_abd_conexaoBD.rstRetornaArquivoXML(m_strEnderecoExecutavel + "tbRelatorios");
//					try 
//					{
//						if (rstRelatorio.EOF)
//						{
//							MessageBox.Show("O arquivo escolhido não é um arquivo de relatório válido.","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
//							return (false);
//						}
//					}	
//					catch(System.Exception err) 
// 					{
//						System.Console.WriteLine(err.Message);
//						MessageBox.Show("O arquivo escolhido não é um arquivo de relatório válido.","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
//						return (false);
//					}
//
//					// Verificando se o arquivo a Importar nao eh de um tipo diferente 
//					int nTipoRelatorioImportar;
//					bool bArquivoImportarMesmoTipoRelatorio;
//					nTipoRelatorioImportar = (int)rstRelatorio.Fields["idTipo"].Value;
//			        bArquivoImportarMesmoTipoRelatorio = (nTipoRelatorioImportar == m_nTipoRelatorio);
//					if (!bArquivoImportarMesmoTipoRelatorio)
//					{
//						if (MessageBox.Show("O relatório que você esta importando é de um tipo diferente de relatório. Deseja mesmo assim importá-lo ? (Importando um relátorio de tipo diferente o mesmo perderá os textos dinâmicos)","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No )
//						{
//							return (false);
//						}
//					}
//
//					// Adquirindo o nome do Relatorio
//					bool bNomeRelatorioExiste = true;
//					string strNomeRelatorioImportado = "";
//					while (bNomeRelatorioExiste)
//					{
//						if (strNomeRelatorioImportado == "")
//							strNomeRelatorioImportado = (string)rstRelatorio.Fields["nomeRelatorio"].Value;  
//						else
//						{
//							mdlRelatoriosJanelas.frmFRelatoriosImportar formNome = new mdlRelatoriosJanelas.frmFRelatoriosImportar(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,ref m_cls_abd_conexaoBD,m_nIdExportador,m_nTipoRelatorio,m_nIdRelatorio);
//							formNome.ShowDialog();
//							if (formNome.m_bModificado)
//								formNome.retornaValores(ref strNomeRelatorioImportado);
//							else
//								return(false);
//							formNome = null;
//						}
//						rstDados = m_cls_abd_conexaoBD.executa("SELECT nomeRelatorio FROM tbRelatorios WHERE ((idTipo = " + m_nTipoRelatorio + " ) AND (idRelatorio < 1 ) AND (nomeRelatorio = \"" + strNomeRelatorioImportado + "\" ) ) OR ((idExportador = " + m_nIdExportador + " ) AND (idTipo = " + m_nTipoRelatorio + " ) AND (idRelatorio > 0 ) AND (nomeRelatorio = \"" + strNomeRelatorioImportado + "\" ) )");
//						if (rstDados.EOF)
//							bNomeRelatorioExiste = false;
//						rstDados.Close();
//						rstDados = null;
//					}
//
//					// Mudando o cursor (Pode demorar um pouco as operacoes abaixo)
//					Cursor = System.Windows.Forms.Cursors.WaitCursor;
//
//					// Adquirindo o novo Id do Relatorio 
//					int nIdRelatorio;
//					if ((int)rstRelatorio.Fields["idRelatorio"].Value < 1)
//					{ // Padrao
//						nIdRelatorio = 0;
//                        rstDados = m_cls_abd_conexaoBD.executa("SELECT idRelatorio FROM tbRelatorios WHERE (idTipo = " + m_nTipoRelatorio + ") AND (idRelatorio < 1) ORDER BY idRelatorio DESC");
//						while (!rstDados.EOF)
//						{
//							if ((int)rstDados.Fields["idRelatorio"].Value == nIdRelatorio)
//							{
//								nIdRelatorio = nIdRelatorio - 1;
//								rstDados.MoveNext();
//								if (rstDados.EOF)
//									nIdRelatorio = nIdRelatorio - 1;
//							}else{
//								break;
//							}
//						}
//						rstDados.Close();
//						rstDados = null;
//					}else{ // Normal 
//						nIdRelatorio = 1;
//						rstDados = m_cls_abd_conexaoBD.executa("SELECT idRelatorio FROM tbRelatorios WHERE (idExportador = " + m_nIdExportador + ") AND (idTipo = " + m_nTipoRelatorio + ") AND (idRelatorio > 0) ORDER BY idRelatorio");
//						while (!rstDados.EOF)
//						{
//							if ((int)rstDados.Fields["idRelatorio"].Value == nIdRelatorio)
//							{
//								nIdRelatorio = nIdRelatorio + 1;
//								rstDados.MoveNext();
//								if (rstDados.EOF)
//									nIdRelatorio = nIdRelatorio + 1;
//							}
//							else
//							{
//								break;
//							}
//						}
//						rstDados.Close();
//						rstDados = null;
//					}
//
//					// Registro da mdlRelatorios 
//                    string strSQL;
//					strSQL = strRetornaSQLInsercao(ref rstRelatorio,"tbRelatorios",strNomeRelatorioImportado,m_nIdExportador,m_nTipoRelatorio,nIdRelatorio,0);
//					if (strSQL != "")
//						m_cls_abd_conexaoBD.executa(strSQL);
//
//					// Demais Tabelas (- Imagens )
//					for (int nCont = 1; nCont < (nNumTabelas - 1);nCont++)
//					{   
//						if (nCont == nNumTabelas - 2)
//							if (!bArquivoImportarMesmoTipoRelatorio)
//								break;
//						rstDados = m_cls_abd_conexaoBD.rstRetornaArquivoXML(m_strEnderecoExecutavel + strNomeTabelas[nCont]);
//						while (!rstDados.EOF)
//						{
//							strSQL = strRetornaSQLInsercao(ref rstDados,strNomeTabelas[nCont],strNomeRelatorioImportado,m_nIdExportador,m_nTipoRelatorio,nIdRelatorio,0);
//							if (strSQL != "")
//								m_cls_abd_conexaoBD.executa(strSQL);
//							rstDados.MoveNext();
//						}
//					}
//					// Tabela das Imagens "tbRelatorioImagens"
//					int nIndiceImagem; 
//					ADODB.Recordset rstImagens;
//					rstDados = m_cls_abd_conexaoBD.rstRetornaArquivoXML(m_strEnderecoExecutavel + "tbRelatorioImagens");
//					while (!rstDados.EOF)
//					{
//						// Procurando o indice da imagem 
//						rstImagens = m_cls_abd_conexaoBD.executa("SELECT idImagem FROM tbImagens WHERE (strNome = \"" + (string)rstDados.Fields["strNome"].Value + "\" ) AND (bVisivelRelatorios = true) ");
//						if (!rstImagens.EOF) 
//						{ // Imagens ja existe no BD
//							nIndiceImagem = (Int16)rstImagens.Fields["idImagem"].Value;
//						}else{ // Inserindo a Imagem
//							nIndiceImagem = 1;
//							rstImagens = m_cls_abd_conexaoBD.executa("SELECT idImagem FROM tbImagens ORDER BY idImagem");
//							while (!rstImagens.EOF)
//							{
//								if ((Int16)rstImagens.Fields["idImagem"].Value == nIndiceImagem)
//								{
//									nIndiceImagem = nIndiceImagem + 1;
//									rstImagens.MoveNext();
//									if (rstImagens.EOF)
//										nIndiceImagem = nIndiceImagem + 1;
//								}
//								else
//								{
//									break;
//								}
//							}
//							rstImagens.Close();
//							rstImagens = null;
//							// Inserindo a Imagem no Banco de Dados 
//							m_cls_abd_conexaoBD.executa("INSERT INTO tbImagens (idImagem, strNome,strDados,bVisivelRelatorios) VALUES ( " + nIndiceImagem + " , \"" + (string)rstDados.Fields["strNome"].Value + "\" , \"" + (string)rstDados.Fields["strDados"].Value + "\" , true ) ");
//
//						} 
//						strSQL = strRetornaSQLInsercao(ref rstDados,"tbRelatorioImagens",strNomeRelatorioImportado,m_nIdExportador,m_nTipoRelatorio,nIdRelatorio,nIndiceImagem);
//						if (strSQL != "")
//							m_cls_abd_conexaoBD.executa(strSQL);
//						rstDados.MoveNext();
//					}
//
//					// Apagando os Arquivos Temporarios
//					for (int nCont = 0; nCont < nNumTabelas;nCont++)
//					{
//						strNomeTabela = strNomeTabelas[nCont];
//						// Apagando o arquivo caso ele exista 
//						if (System.IO.File.Exists(m_strEnderecoExecutavel + strNomeTabelas[nCont]))
//							System.IO.File.Delete(m_strEnderecoExecutavel + strNomeTabelas[nCont]);
//					}
//
//					Cursor = System.Windows.Forms.Cursors.Default;
//					if (MessageBox.Show("Relatório '" + strNomeRelatorioImportado +   "' importado com Sucesso. Deseja abri-lo agora ?","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
//					{
//						m_nIdRelatorio = nIdRelatorio;
//						bMostrarRelatorio();
//					}
//					return (true);
//				}
//				dlgOpen = null;
				return false;
			}

			/// <summary>
			/// Retornando o SQL do RecordSet atual.
			/// </summary>
//			public string strRetornaSQLInsercao(ref ADODB.Recordset rstDados,string NomeTabela, string NomeRelatorio, int IdExportador,int TipoRelatorio,int IdRelatorio,int nIndiceImagem) 
//   			{
//                string strSQL = "INSERT INTO " + NomeTabela + " ( " ;
//				string strCampos = "";
//				string strValores = "";
//
//				for (int nCont = 0 ; nCont < rstDados.Fields.Count; nCont++)
//				{
//					switch (rstDados.Fields[nCont].Name.ToString())
//					{
//						case "nomeRelatorio":
//							if (strCampos != "")
//							{
//								strCampos = strCampos + " , ";
//								strValores = strValores + " , ";
//							}
//							strCampos = strCampos + " nomeRelatorio ";
//							strValores = strValores + " \"" + NomeRelatorio + "\" ";
//							break;
//						case "idExportador":
//							if (strCampos != "")
//							{
//								strCampos = strCampos + " , ";
//								strValores = strValores + " , ";
//							}
//							strCampos = strCampos + " idExportador ";
//							strValores = strValores + " " + IdExportador + " ";
//							break;
//						case "idTipo":
//							if (strCampos != "")
//							{
//								strCampos = strCampos + " , ";
//								strValores = strValores + " , ";
//							}
//							strCampos = strCampos + " idTipo ";
//							strValores = strValores + " " + TipoRelatorio + " ";
//							break;
//						case "idRelatorio":
//							if (strCampos != "")
//							{
//								strCampos = strCampos + " , ";
//								strValores = strValores + " , ";
//							}
//							strCampos = strCampos + " idRelatorio ";
//							strValores = strValores + " " + IdRelatorio + " ";
//							break;
//                        case "strNome":
//							break;
//						case "strDados":
//							break;
//						case "nIdImagem":
//							if (strCampos != "")
//							{
//								strCampos = strCampos + " , ";
//								strValores = strValores + " , ";
//							}
//							strCampos = strCampos + " nIdImagem ";
//							strValores = strValores + " " + nIndiceImagem + " ";
//							break;
//						default:
//							if (strCampos != "")
//							{
//								strCampos = strCampos + " , ";
//								strValores = strValores + " , ";
//							}
//							switch (rstDados.Fields[nCont].Type)
//							{
//								case ADODB.DataTypeEnum.adWChar: 
//									strCampos = strCampos + " " + rstDados.Fields[nCont].Name.ToString() + " ";
//									strValores = strValores + " \"" + rstDados.Fields[nCont].Value + "\" ";
//									break;
//								case ADODB.DataTypeEnum.adVarWChar:
//									strCampos = strCampos + " " + rstDados.Fields[nCont].Name.ToString() + " ";
//									strValores = strValores + " \"" + rstDados.Fields[nCont].Value + "\" ";
//									break;
//								case ADODB.DataTypeEnum.adLongVarChar:
//									strCampos = strCampos + " " + rstDados.Fields[nCont].Name.ToString() + " ";
//									strValores = strValores + " \"" + rstDados.Fields[nCont].Value + "\" ";
//									break;
//								case ADODB.DataTypeEnum.adLongVarWChar:
//									strCampos = strCampos + " " + rstDados.Fields[nCont].Name.ToString() + " ";
//									strValores = strValores + " \"" + rstDados.Fields[nCont].Value + "\" ";
//									break;
//								default:
//									strCampos = strCampos + " " + rstDados.Fields[nCont].Name.ToString() + " ";
//									if (System.DBNull.Value != rstDados.Fields[nCont].Value)
//									{
//										strValores = strValores + " " + rstDados.Fields[nCont].Value + " ";    
//									}else{
//										strValores = strValores + " -1331 ";    
//									}
//									break;
//							}
//							break;
//					}
//				}
//				strSQL = strSQL + strCampos + " ) VALUES ( " +  strValores + " )";
//				return (strSQL);
//			}
		#endregion 
			#region Imprimir 
				private void m_btImprimir_Click(object sender, System.EventArgs e)
				{
					if (m_rcRelatorio.bPrintReport(true))
					{
						vIncrementaNumeroImpressoes();
					}
				}
			#endregion
			#region Salvar Imagem
				private void m_btSalvarImagem_Click(object sender, System.EventArgs e)
				{
					bool bIsPDF = false;
					System.Drawing.Imaging.ImageFormat imgFormato = null;
					System.Windows.Forms.SaveFileDialog dlgSalvar = new System.Windows.Forms.SaveFileDialog();
					dlgSalvar.Filter = "Arquivo PDF (*.pdf)|*.pdf|JPEG - Formato .JPG (*.jpg)|*.jpg|CompuServe GIF (*.gif)|*.gif|Portable Network Graphics (*.png)|*.png|Windows Bitmap (*.bmp)|*.bmp";
					if (dlgSalvar.ShowDialog() == System.Windows.Forms.DialogResult.OK )
					{
						string strNomeArquivo = dlgSalvar.FileName.Replace(".","");
						switch(dlgSalvar.FileName.Substring(dlgSalvar.FileName.Length - 3))
						{
							case "png":
								imgFormato = System.Drawing.Imaging.ImageFormat.Png;
								break;
							case "jpg":
								imgFormato = System.Drawing.Imaging.ImageFormat.Jpeg;
								break;
							case "bmp":
								imgFormato = System.Drawing.Imaging.ImageFormat.Bmp;
								break;
							case "gif":
								imgFormato = System.Drawing.Imaging.ImageFormat.Gif;
								break;
							case "pdf":
								bIsPDF = true;
								imgFormato = null;
								break;
							default:
								strNomeArquivo = strNomeArquivo + "jpg";
								imgFormato = System.Drawing.Imaging.ImageFormat.Jpeg;
								break;
						}
						int nTotalPaginas = m_nTotalPaginas;
						mdlPDF.clsPDF cls_pdfRelatorio = null;
						int nIdMarcador = 0;
						if (bIsPDF)
						{
							cls_pdfRelatorio = new mdlPDF.clsPDF();
							nIdMarcador = cls_pdfRelatorio.nAdicionaMarcador("Documento",0,1);
						}
						for (int nCont = 0;nCont < nTotalPaginas;nCont++ )
						{
							if (!bIsPDF)
							{
								string strNomeArquivoSalvar = strNomeArquivo;
								strNomeArquivoSalvar = strNomeArquivoSalvar.Substring(0,strNomeArquivoSalvar.Length - 3) + (nCont + 1).ToString() + "." + strNomeArquivoSalvar.Substring(strNomeArquivoSalvar.Length - 3);
								if (System.IO.File.Exists(strNomeArquivoSalvar))
									System.IO.File.Delete(strNomeArquivoSalvar);
								System.Drawing.Image imagem = null;
								if (m_rcRelatorio.bReturnPageImage(nCont,ref imagem))
								{
									if (!(imagem == null))
									{
										imagem.Save(strNomeArquivoSalvar,imgFormato);
									}
								}
							}else{
								cls_pdfRelatorio.bAdicionaPagina(m_rcRelatorio.PageSize);
								cls_pdfRelatorio.nAdicionaMarcador("Página " + (nCont + 1).ToString(),nIdMarcador,nCont + 1);
								m_rcRelatorio.bReturnPage(nCont,ref cls_pdfRelatorio);
							}
						}
						if (bIsPDF)
							cls_pdfRelatorio.bSalvar(dlgSalvar.FileName);
					}
				}
			#endregion
			#region Enviar E-mail
				private void m_btEnviarImagemEmail_Click(object sender, System.EventArgs e)
				{
					string strNomeArquivo;
					System.Collections.ArrayList arlArquivosAtachados = new System.Collections.ArrayList();
					System.Drawing.Imaging.ImageFormat imgFormato = System.Drawing.Imaging.ImageFormat.Jpeg;
					mdlEmailInterface.clsEmailInterface cls_email = new mdlEmailInterface.clsEmailInterface(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);                		
					cls_email.RemoveAtachmentsAfterSend = true;
					for (int nCont = 0;nCont < m_nTotalPaginas;nCont++ )
					{
						strNomeArquivo = "imagem" + (nCont + 1).ToString() + ".jpg";
						if (System.IO.File.Exists(strNomeArquivo))
							System.IO.File.Delete(strNomeArquivo);
						System.Drawing.Image imagem = null;
						if (m_rcRelatorio.bReturnPageImage(nCont,ref imagem))
						{
							if (!(imagem == null))
							{
								imagem.Save(strNomeArquivo,imgFormato);
								arlArquivosAtachados.Add(strNomeArquivo);
							}
						}
					}
					cls_email.Arquivos = arlArquivosAtachados;
					cls_email.ShowDialog();
				}
			#endregion
			#region Trocar Relatorio
				private void m_btTrocarRelatorio_Click(object sender, System.EventArgs e)
				{
					mdlRelatoriosJanelas.frmFRelatoriosTrocaRelatorio formTrocaRelatorio = new mdlRelatoriosJanelas.frmFRelatoriosTrocaRelatorio(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_nTipoRelatorio);
					formTrocaRelatorio.ShowDialog();
					if (formTrocaRelatorio.m_bModificado)
					{
						int nRelatorio;  
						formTrocaRelatorio.RetornaValores(out nRelatorio);
						if (nRelatorio != m_nIdRelatorio)
						{
							m_nIdRelatorio = nRelatorio;
							bSalvaIdRelatorio();
							bMostrarRelatorio();
						}
					}
				}
			#endregion
			#region Modo Edição
				private void m_btModoEdicao_Click(object sender, System.EventArgs e)
				{
					vMudaModoVisualizacao();
				}
			#endregion
			#region Idioma
			private void m_btIdioma_Click(object sender, System.EventArgs e)
			{
				if (bTrocarIdioma())
				{
					m_rcRelatorio.SetIdIdioma(m_nIdIdioma);
					bMostrarRelatorio();
				}
			}
			#endregion
			#region Trocar Idioma
				protected virtual bool bTrocarIdioma()
				{
					return false;
				}
			#endregion
		#endregion
		#region Métodos Referentes a Barra Ferramentas Superior (EDICAO)
			#region Visualizar
				private void m_btVisualizarEdicao_Click(object sender, System.EventArgs e)
				{
					mdlRelatoriosJanelas.frmFRelatoriosVisualizacaoItens formVisualizar = new mdlRelatoriosJanelas.frmFRelatoriosVisualizacaoItens(ref m_cls_ter_tratadorErro , m_strEnderecoExecutavel,m_rcRelatorio.ShowGrid,m_rcRelatorio.ShowMargins,m_rcRelatorio.ShowProductArea,m_rcRelatorio.ShowLines,m_rcRelatorio.ShowCircles,m_rcRelatorio.ShowRectangles,m_rcRelatorio.ShowImage,m_rcRelatorio.ShowText,m_rcRelatorio.ShowDBText,m_rcRelatorio.ShowDBTextDados);
					formVisualizar.ShowDialog();
					if (formVisualizar.m_bModificado)
					{
						bool bGrade = false;
						bool bMargens = false;
						bool bAreaProdutos = false ;

						bool bLinhas =false;
						bool bCirculos = false;
						bool bRetangulos = false;
						bool bImagens = false ;
						bool bTextos = false;
						bool bCamposBD = false;
						bool bCamposBDDados = false;
						formVisualizar.RetornaValores(out bGrade,out bMargens,out bAreaProdutos,out bLinhas,out bCirculos,out bRetangulos,out bImagens,out bTextos,out bCamposBD,out bCamposBDDados);
						// Geral
						m_rcRelatorio.ShowGrid = bGrade;
						m_rcRelatorio.ShowMargins = bMargens;
						m_rcRelatorio.ShowProductArea = bAreaProdutos;

						// Objetos 
						m_rcRelatorio.ShowLines = bLinhas;
						m_rcRelatorio.ShowCircles = bCirculos;
						m_rcRelatorio.ShowRectangles = bRetangulos;
						m_rcRelatorio.ShowImage = bImagens;
						m_rcRelatorio.ShowText = bTextos;
						m_rcRelatorio.ShowDBText = bCamposBD;
						m_rcRelatorio.ShowDBTextDados = bCamposBDDados;

						// Colocando o Relatorio como Modificado
						m_rcRelatorio.SetReportAsModified();
					} 
				}
			#endregion
			#region Teclas Atalho
				private void m_btTrocarTeclasAtalhoEdicao_Click(object sender, System.EventArgs e)
				{
					mostraTeclasAtalho();
				}
			#endregion
			#region Ferramentas
				private void m_ckSelecaoEdicao_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{ 
						if (m_ckSelecaoEdicao.Checked)
						{
							// Desselecionando os Demais
							m_ckLinhaEdicao.Checked = false;
							m_ckCirculoEdicao.Checked = false;
							m_ckRetanguloEdicao.Checked = false;
							m_ckImagemEdicao.Checked = false;
							m_ckEtiquetaEdicao.Checked = false;
							m_ckCampoBDEdicao.Checked = false;
							m_ckAreaProdutosEdicao.Checked = false;

							m_bToolsChangeEnabled = false;

							// Selecionando o Atual 
							m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.Selection;
							m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;

						}
						else
						{
							if ((m_rcRelatorio.CurrentTool == DrawingCanvasPackage.Tool.Selection) || (m_rcRelatorio.CurrentSubTool == ReportCanvasPackage.SubTool.None))
							{
								m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.None;
								m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;
							}
						}
						m_rcRelatorio.ClearSelection(true);
					}
					m_bToolsChangeEnabled = true;
				}

				private void m_ckLinhaEdicao_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{ 
						if (m_ckLinhaEdicao.Checked)
						{
							// Desselecionando os Demais
							m_ckSelecaoEdicao.Checked = false;
							m_ckCirculoEdicao.Checked = false;
							m_ckRetanguloEdicao.Checked = false;
							m_ckImagemEdicao.Checked = false;
							m_ckEtiquetaEdicao.Checked = false;
							m_ckCampoBDEdicao.Checked = false;
							m_ckAreaProdutosEdicao.Checked = false;

							m_bToolsChangeEnabled = false;

							// Selecionando o Atual 
							m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.Line;
							m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;
						}
						else
						{
							if (m_rcRelatorio.CurrentTool == DrawingCanvasPackage.Tool.Line)
							{
								m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.None;
								m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;
							}
						}
						m_rcRelatorio.ClearSelection(true);
					}
					m_bToolsChangeEnabled = true;
				}

				private void m_ckCirculoEdicao_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{ 

						if (m_ckCirculoEdicao.Checked)
						{
							// Desselecionando os Demais
							m_ckSelecaoEdicao.Checked = false;
							m_ckLinhaEdicao.Checked = false;
							m_ckRetanguloEdicao.Checked = false;
							m_ckImagemEdicao.Checked = false;
							m_ckEtiquetaEdicao.Checked = false;
							m_ckCampoBDEdicao.Checked = false;
							m_ckAreaProdutosEdicao.Checked = false;

							m_bToolsChangeEnabled = false;

							// Selecionando o Atual 
							m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.Circle;
							m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;
						}
						else
						{
							if (m_rcRelatorio.CurrentTool == DrawingCanvasPackage.Tool.Circle)
							{
								m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.None;
								m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;
							}
						}
						m_rcRelatorio.ClearSelection(true);
					}
					m_bToolsChangeEnabled = true;
				}

				private void m_ckRetanguloEdicao_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{ 
						if (m_ckRetanguloEdicao.Checked)
						{
							// Desselecionando os Demais
							m_ckSelecaoEdicao.Checked = false;
							m_ckLinhaEdicao.Checked = false;
							m_ckCirculoEdicao.Checked = false;
							m_ckImagemEdicao.Checked = false;
							m_ckEtiquetaEdicao.Checked = false;
							m_ckCampoBDEdicao.Checked = false;
							m_ckAreaProdutosEdicao.Checked = false;

							m_bToolsChangeEnabled = false;

							// Selecionando o Atual 
							m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.Rectangle;
							m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;

						}
						else
						{
							if (m_rcRelatorio.CurrentTool == DrawingCanvasPackage.Tool.Rectangle)
							{
								m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.None;
								m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;
							}
						}
						m_rcRelatorio.ClearSelection(true);
					}
					m_bToolsChangeEnabled = true;
				}

				private void m_ckImagemEdicao_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{ 
						if (m_ckImagemEdicao.Checked)
						{
							// Desselecionando os Demais
							m_ckSelecaoEdicao.Checked = false;
							m_ckLinhaEdicao.Checked = false;
							m_ckCirculoEdicao.Checked = false;
							m_ckRetanguloEdicao.Checked = false;
							m_ckEtiquetaEdicao.Checked = false;
							m_ckCampoBDEdicao.Checked = false;
							m_ckAreaProdutosEdicao.Checked = false;
                            
							m_bToolsChangeEnabled = false;

							// Selecionando o Atual 
							m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.Image;
							m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;

						}
						else
						{
							if (m_rcRelatorio.CurrentTool == DrawingCanvasPackage.Tool.Image)
							{
								m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.None;
								m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;
							}
						}
						m_rcRelatorio.ClearSelection(true);
					}
					m_bToolsChangeEnabled = true;
				}

				private void m_ckEtiquetaEdicao_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{ 
						if (m_ckEtiquetaEdicao.Checked)
						{
							// Desselecionando os Demais
							m_ckSelecaoEdicao.Checked = false;
							m_ckLinhaEdicao.Checked = false;
							m_ckCirculoEdicao.Checked = false;
							m_ckRetanguloEdicao.Checked = false;
							m_ckImagemEdicao.Checked = false;
							m_ckCampoBDEdicao.Checked = false;
							m_ckAreaProdutosEdicao.Checked = false;

							m_bToolsChangeEnabled = false;

							// Selecionando o Atual 
							m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.Text;
							m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;

						}
						else
						{
							if ((m_rcRelatorio.CurrentTool == DrawingCanvasPackage.Tool.Text) || (m_rcRelatorio.CurrentSubTool == ReportCanvasPackage.SubTool.None))
							{
								m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.None;
								m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;
							}
						}
						m_rcRelatorio.ClearSelection(true);
					}
					m_bToolsChangeEnabled = true;
				}

				private void m_ckCampoBDEdicao_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{ 
						if (m_ckCampoBDEdicao.Checked)
						{
							// Desselecionando os Demais
							m_ckSelecaoEdicao.Checked = false;
							m_ckLinhaEdicao.Checked = false;
							m_ckCirculoEdicao.Checked = false;
							m_ckRetanguloEdicao.Checked = false;
							m_ckImagemEdicao.Checked = false;
							m_ckEtiquetaEdicao.Checked = false;
							m_ckAreaProdutosEdicao.Checked = false;

							m_bToolsChangeEnabled = false;

							// Selecionando o Atual 
							m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.Text;
							m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.DBText;

						}
						else
						{
							if ((m_rcRelatorio.CurrentTool == DrawingCanvasPackage.Tool.Text) || (m_rcRelatorio.CurrentSubTool == ReportCanvasPackage.SubTool.DBText))
							{
								m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.None;
								m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;
							}
						}
						m_rcRelatorio.ClearSelection(true);
					}
					m_bToolsChangeEnabled = true;
				}

				private void m_ckAreaProdutosEdicao_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{ 
						if (m_ckAreaProdutosEdicao.Checked)
						{
							// Desselecionando os Demais
							m_ckSelecaoEdicao.Checked = false;
							m_ckLinhaEdicao.Checked = false;
							m_ckCirculoEdicao.Checked = false;
							m_ckRetanguloEdicao.Checked = false;
							m_ckImagemEdicao.Checked = false;
							m_ckEtiquetaEdicao.Checked = false;
							m_ckCampoBDEdicao.Checked = false;

							m_bToolsChangeEnabled = false;

							// Selecionando o Atual 
							m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.Selection;
							m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.ProductArea;

						}
						else
						{
							if ((m_rcRelatorio.CurrentTool == DrawingCanvasPackage.Tool.Selection) || (m_rcRelatorio.CurrentSubTool == ReportCanvasPackage.SubTool.ProductArea))
							{
								m_rcRelatorio.CurrentTool = DrawingCanvasPackage.Tool.None;
								m_rcRelatorio.CurrentSubTool = ReportCanvasPackage.SubTool.None;
							}
						}
						m_rcRelatorio.ClearSelection(true);
					}
					m_bToolsChangeEnabled = true;
				}
			#endregion
			#region Configuracao
				private void m_btCanetaEdicao_Click(object sender, System.EventArgs e)
				{
					mdlRelatoriosJanelas.frmFRelatoriosCaneta formCaneta = new mdlRelatoriosJanelas.frmFRelatoriosCaneta(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_rcRelatorio.PenWidth,m_rcRelatorio.PenStyle,m_rcRelatorio.PenColor);
					formCaneta.ShowDialog();
					if (formCaneta.m_bModificado)
					{
						int espessura = 0;
 						System.Drawing.Drawing2D.DashStyle estilo = System.Drawing.Drawing2D.DashStyle.Custom;
						System.Drawing.Color corCaneta = System.Drawing.Color.Black;	
						formCaneta.RetornaValores(out espessura,out estilo,out corCaneta);
						m_rcRelatorio.PenWidth = espessura;
						m_rcRelatorio.PenStyle = estilo;
						m_rcRelatorio.PenColor = corCaneta;

						// Colocando o Relatorio como Modificado
						m_rcRelatorio.SetReportAsModified();

					}
					formCaneta.Close();
					formCaneta = null;
				}

				private void m_btFonteEdicao_Click(object sender, System.EventArgs e)
				{
					try
					{
						System.Windows.Forms.FontDialog dlgFonte = new System.Windows.Forms.FontDialog();
						try
						{
							dlgFonte.Font = m_rcRelatorio.TextFont;
						}
						catch
						{
							dlgFonte.Font = new System.Drawing.Font("Arial",12);
						}
						dlgFonte.ShowColor = true;
						dlgFonte.FontMustExist = true;
						if ( dlgFonte.ShowDialog() == DialogResult.OK )
						{
							System.Drawing.Font fntFonte;
							try
							{
								fntFonte = dlgFonte.Font;
							}
							catch
							{
								fntFonte = new System.Drawing.Font("Arial",12);
							}
							if (fntFonte.Size != System.Math.Ceiling(fntFonte.Size))
							{
								FontStyle fs = new FontStyle();
								if ( fntFonte.Bold )
									fs = fs | FontStyle.Bold;
								if ( fntFonte.Italic)
									fs = fs | FontStyle.Italic;
								if ( fntFonte.Strikeout)
									fs = fs | FontStyle.Strikeout;
								if ( fntFonte.Underline)
									fs = fs | FontStyle.Underline;
								try
								{
									fntFonte = new System.Drawing.Font(fntFonte.FontFamily,(int)fntFonte.Size,fs);
								}
								catch
								{
									fntFonte = new System.Drawing.Font("Arial",12);
								}
							}
							try
							{
								m_rcRelatorio.TextFont = fntFonte;
							}
							catch
							{
								m_rcRelatorio.TextFont = new System.Drawing.Font("Arial",12);
							}
							m_rcRelatorio.TextColor = dlgFonte.Color;
							m_rcRelatorio.SetReportAsModified();
						}
					}catch{
					}
				}

				private void m_btCoresEdicao_Click(object sender, System.EventArgs e)
				{
                    mdlRelatoriosJanelas.frmFRelatoriosCores formCores = new mdlRelatoriosJanelas.frmFRelatoriosCores(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_rcRelatorio.PenColor,m_rcRelatorio.DBTextColor,m_rcRelatorio.HighlightColor,m_rcRelatorio.NotPrintableColor,m_rcRelatorio.ProductAreaColor,m_rcRelatorio.MarginColor,m_rcRelatorio.BackgroundColor);
					formCores.ShowDialog();
					if (formCores.m_bModificado)
					{
						System.Drawing.Color corCaneta = System.Drawing.Color.Black;	
						System.Drawing.Color corCampoBD = System.Drawing.Color.Black;	
						System.Drawing.Color corObjetosFocado = System.Drawing.Color.Black;	
						System.Drawing.Color corObjetosNaoImpressos = System.Drawing.Color.Black;	
						System.Drawing.Color corAreaProdutos = System.Drawing.Color.Black;	
						System.Drawing.Color corMargem = System.Drawing.Color.Black;	
						System.Drawing.Color corFundo = System.Drawing.Color.Black;	
                        formCores.RetornaValores(out corCaneta,out corCampoBD,out corObjetosFocado,out corObjetosNaoImpressos,out corAreaProdutos,out corMargem,out corFundo);
						m_rcRelatorio.PenColor = corCaneta;
						m_rcRelatorio.DBTextColor = corCampoBD; 
						m_rcRelatorio.HighlightColor = corObjetosFocado;
						m_rcRelatorio.NotPrintableColor = corObjetosNaoImpressos; 
						m_rcRelatorio.ProductAreaColor = corAreaProdutos; 
						m_rcRelatorio.MarginColor = corMargem; 
						m_rcRelatorio.BackgroundColor =  corFundo; 

						// Colocando o Relatorio como Modificado
						m_rcRelatorio.SetReportAsModified();

					}
					formCores = null;
				}
			#endregion
			#region Undo / Redo
				private void m_btUndoEdicao_Click(object sender, System.EventArgs e)
				{
					m_rcRelatorio.bUndo();
				}

				private void m_btReUndoEdicao_Click(object sender, System.EventArgs e)
				{
					m_rcRelatorio.bRedo();
				}
			#endregion
			#region Agrupamento
				private void m_btAgruparEdicao_Click(object sender, System.EventArgs e)
				{
		           if (m_rcRelatorio.bGroupObjects())	
						m_rcRelatorio.SetReportAsModified();
				}

				private void m_btDesagruparEdicao_Click(object sender, System.EventArgs e)
				{
					if (m_rcRelatorio.bUngroupObjects())		
						m_rcRelatorio.SetReportAsModified();
				}
			#endregion 
			#region Alinhamento
				private void m_btAlinhamentoEsquerdaEdicao_Click(object sender, System.EventArgs e)
				{
					if (m_rcRelatorio.bAlignObjects( DrawingCanvasPackage.Alignment.Left, true ))
						m_rcRelatorio.SetReportAsModified();
				}

				private void m_btAlinhamentoCentralizadoEdicao_Click(object sender, System.EventArgs e)
				{
					if (m_rcRelatorio.bAlignObjects( DrawingCanvasPackage.Alignment.Center, true ))
						m_rcRelatorio.SetReportAsModified();
				}

				private void m_btAlinhamentoDireitaEdicao_Click(object sender, System.EventArgs e)
				{
					if (m_rcRelatorio.bAlignObjects( DrawingCanvasPackage.Alignment.Right, true ))
						m_rcRelatorio.SetReportAsModified();
				}
			#endregion 
			#region Espaçamento
				private void m_btEspacamentoHorizontal_Click(object sender, System.EventArgs e)
				{
					if (m_rcRelatorio.bSetSpacing( DrawingCanvasPackage.Spacing.Horizontal, true ))
					m_rcRelatorio.SetReportAsModified();
				}

				private void m_btEspacamentoVertical_Click(object sender, System.EventArgs e)
				{
					if (m_rcRelatorio.bSetSpacing( DrawingCanvasPackage.Spacing.Vertical, true ))
						m_rcRelatorio.SetReportAsModified();
				}
			#endregion
		#endregion
		#region Métodos Referentes a Barra Ferramentas Inferior (EDICAO)

			private void m_btNovoEdicao_Click(object sender, System.EventArgs e)
			{
				// Margens 
				int nAcima = m_rcRelatorio.GetTopMargin() ;
				int nDireita = m_rcRelatorio.GetRightMargin();
				int nAbaixo = m_rcRelatorio.GetBottomMargin() ;
				int nEsquerda = m_rcRelatorio.GetLeftMargin() ;

				// Tamanho
				int nAltura = m_rcRelatorio.PageSize.Height;
				int nLargura = m_rcRelatorio.PageSize.Width;

				// Orientacao 
				int nOrientacao = m_rcRelatorio.Orientation;

				switch(nOrientacao)
				{
					case (int)DrawingCanvasPackage.Orientation.Retract:
						break;
					case (int)DrawingCanvasPackage.Orientation.Image:
						int aux;
						aux = nAltura;
						nAltura = nLargura;
						nLargura = aux;
						break;
				}
				mdlRelatoriosJanelas.frmFRelatoriosPropriedadesRelatorio formProp = new mdlRelatoriosJanelas.frmFRelatoriosPropriedadesRelatorio(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_rcRelatorio.BackgroundColor,m_rcRelatorio.MarginColor,nAcima,nDireita,nAbaixo,nEsquerda,nLargura,nAltura,nOrientacao);
				formProp.ShowDialog();
				if (formProp.m_bModificado)
				{
					formProp.RetornaValores(out nAcima,out nDireita,out nAbaixo,out nEsquerda,out nLargura, out nAltura,out nOrientacao);
					m_rcRelatorio.Orientation = nOrientacao;
					m_rcRelatorio.SetMargins(nEsquerda,nAcima,nDireita,nAbaixo,false);
					switch(nOrientacao)
					{
						case (int)DrawingCanvasPackage.Orientation.Retract:
							break;
						case (int)DrawingCanvasPackage.Orientation.Image:
							int aux;
							aux = nAltura;
							nAltura = nLargura;
							nLargura = aux;
							break;
					}
					m_rcRelatorio.PageSize = new System.Drawing.Size(nLargura,nAltura);
					m_szPagina = m_rcRelatorio.PageSize;
					m_rcRelatorio.refreshFormatoRelatorio();
					ajustaTamanhoBarrasRolagem();
					m_btSalvarEdicao.Enabled = false;
					m_btExcluirEdicao.Enabled = false;
					m_rcRelatorio.ClearData(true);
					refreshInterfaceNomeRelatorio();
				}
			}

			private void m_btSalvarEdicao_Click(object sender, System.EventArgs e)
			{
				bSave();
			}
	
			private bool bSave()
			{
				bool bReturn = false;
				if (m_nIdRelatorio > 0) 
					bReturn = m_rcRelatorio.bSalvarRelatorio(m_nIdExportador,m_nTipoRelatorio,m_nIdRelatorio);
				else
					bReturn = bSaveAs();
				return(bReturn);
			}

			private void m_btSalvarComoEdicao_Click(object sender, System.EventArgs e)
			{
				bSaveAs();
			}

			private bool bSaveAs()
			{
				bool bReturn = false;
				bool bMostrarRelatoriosPadroes = false;
				if ((int)System.Windows.Forms.Form.ModifierKeys == ((int)System.Windows.Forms.Keys.Shift + (int)System.Windows.Forms.Keys.Control + (int)System.Windows.Forms.Keys.Alt))
					bMostrarRelatoriosPadroes = true;	
				mdlRelatoriosJanelas.frmFRelatoriosSalvarComo formSalvarComo = new mdlRelatoriosJanelas.frmFRelatoriosSalvarComo(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_nTipoRelatorio,bMostrarRelatoriosPadroes);
				formSalvarComo.ShowDialog();
				if (bReturn = formSalvarComo.m_bModificado)
				{
					m_btSalvarEdicao.Enabled = true;
					m_btExcluirEdicao.Enabled = true;
					bool bReportAlredyExists;
					bool bReportDefault;
					int idRelatorio = 0 ;
					string strNome = "";
					formSalvarComo.RetornaValores(out bReportAlredyExists,out bReportDefault,out idRelatorio,out strNome);
					if (bReportAlredyExists)
					{
						m_rcRelatorio.bSalvarRelatorio(m_nIdExportador,m_nTipoRelatorio,idRelatorio);
						m_nIdRelatorio = idRelatorio;
					}
					else
					{
						m_rcRelatorio.bSalvarRelatorioComo(m_nIdExportador,m_nTipoRelatorio,false,strNome);
						m_nIdRelatorio = m_rcRelatorio.Report;
					}
					bSalvaIdRelatorio();
					refreshInterfaceNomeRelatorio();
					bMostrarRelatorio();
				}
				return(bReturn);
			}


			private void m_btTrocarRelatorioEdicao_Click(object sender, System.EventArgs e)
			{
                m_btTrocarRelatorio_Click(sender,e);		
			}
			private void m_btModoVisualizacao_Click(object sender, System.EventArgs e)
			{
				if (bSairRelatorio())
					vMudaModoVisualizacao();
			}

			private bool bSairRelatorio()
			{
				bool bRetorno = true;
				if (m_rcRelatorio.bReportModified())
				{
					switch(mdlMensagens.clsMensagens.ShowQuestion("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRelatoriosBase_frmRelatoriosBase_SairSemSalvar).Replace("\\n","\n"),System.Windows.Forms.MessageBoxButtons.YesNoCancel))
					{
						case System.Windows.Forms.DialogResult.Yes:
							bRetorno = bSave();
							break;
						case System.Windows.Forms.DialogResult.No:
							bRetorno = true;	
							break;
						case System.Windows.Forms.DialogResult.Cancel:
							bRetorno = false;	
							break;
					}
				}
				return (bRetorno);
			}

			private void m_btExcluirEdicao_Click(object sender, System.EventArgs e)
			{
				if (m_nIdRelatorio > 0) // Relatorio Normal
				{
					if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRelatoriosBase_frmRelatoriosBase_ExcluirRelatorio).Replace("\\n","\n"),System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						if (m_rcRelatorio.bDeleteReport())
						{
							m_btSalvarEdicao.Enabled = false;
							m_rcRelatorio.ClearData(true);
							refreshInterfaceNomeRelatorio();
							// Abrindo outro
							mdlRelatoriosJanelas.frmFRelatoriosTrocaRelatorio formTrocaRelatorio = new mdlRelatoriosJanelas.frmFRelatoriosTrocaRelatorio(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_nTipoRelatorio);
							formTrocaRelatorio.ShowDialog();
							if (formTrocaRelatorio.m_bModificado)
							{
								int nRelatorio;
								formTrocaRelatorio.RetornaValores(out nRelatorio);
								if (nRelatorio != m_nIdRelatorio)
								{
									m_nIdRelatorio = nRelatorio;
									bSalvaIdRelatorio();
									bMostrarRelatorio();
								}else{ // nada
								}
							}else{
                                // Criando um novo 
								m_btSalvarEdicao.Enabled = false;
								m_btExcluirEdicao.Enabled = false;
								m_rcRelatorio.ClearData(true);
								m_btMargensEdicao_Click(sender,e);
								refreshInterfaceNomeRelatorio();
							}
							formTrocaRelatorio = null;
						} 
					}
				}
				else
				{ // Relatorio Padrao
					if ((int)System.Windows.Forms.Form.ModifierKeys == ((int)System.Windows.Forms.Keys.Shift + (int)System.Windows.Forms.Keys.Control + (int)System.Windows.Forms.Keys.Alt))
					{
						if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRelatoriosBase_frmRelatoriosBase_ExcluirRelatorioPadrao).Replace("\\n","\n"),System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
						{
							if (m_rcRelatorio.bDeleteReport())
							{
								m_btSalvarEdicao.Enabled = false;
								m_rcRelatorio.ClearData(true);
								refreshInterfaceNomeRelatorio();
								// Abrindo outro
								mdlRelatoriosJanelas.frmFRelatoriosTrocaRelatorio formTrocaRelatorio = new mdlRelatoriosJanelas.frmFRelatoriosTrocaRelatorio(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_nTipoRelatorio);
								formTrocaRelatorio.ShowDialog();
								if (formTrocaRelatorio.m_bModificado)
								{
									int nRelatorio;
									formTrocaRelatorio.RetornaValores(out nRelatorio);
									if (nRelatorio != m_nIdRelatorio)
									{
										m_nIdRelatorio = nRelatorio;
										bSalvaIdRelatorio();
										bMostrarRelatorio();
									}
									else
									{ // nada
									}
								}
								else
								{
									// Criando um novo 
									m_btSalvarEdicao.Enabled = false;
									m_btExcluirEdicao.Enabled = false;
									m_rcRelatorio.ClearData(true);
									m_btMargensEdicao_Click(sender,e);
									refreshInterfaceNomeRelatorio();
								}
								formTrocaRelatorio = null;
							} 
						}
					}else{
						mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRelatoriosBase_frmRelatoriosBase_ExcluirRelatorioPadraoInvalido).Replace("\\n","\n"));
					}
				}
			}

			private void m_btZoomMenosEdicao_Click(object sender, System.EventArgs e)
			{
				m_btZoomMenos_Click(sender,e);
			}

			private void m_btZoomNormalEdicao_Click(object sender, System.EventArgs e)
			{
				m_btZoomNormal_Click(sender,e);
			}

			private void m_btZoomMaisEdicao_Click(object sender, System.EventArgs e)
			{
				m_btZoomMais_Click(sender,e);
			}

			private void m_btMargensEdicao_Click(object sender, System.EventArgs e)
			{
				// Margens 
				int nAcima = m_rcRelatorio.GetTopMargin() ;
				int nDireita = m_rcRelatorio.GetRightMargin();
				int nAbaixo = m_rcRelatorio.GetBottomMargin() ;
				int nEsquerda = m_rcRelatorio.GetLeftMargin() ;

				// Tamanho
				int nAltura = m_rcRelatorio.PageSize.Height;
				int nLargura = m_rcRelatorio.PageSize.Width;

				// Orientacao 
				int nOrientacao = m_rcRelatorio.Orientation;

				switch(nOrientacao)
				{
					case (int)DrawingCanvasPackage.Orientation.Retract:
						break;
					case (int)DrawingCanvasPackage.Orientation.Image:
						int aux;
						aux = nAltura;
						nAltura = nLargura;
						nLargura = aux;
						break;
				}
				mdlRelatoriosJanelas.frmFRelatoriosPropriedadesRelatorio formProp = new mdlRelatoriosJanelas.frmFRelatoriosPropriedadesRelatorio(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_rcRelatorio.BackgroundColor,m_rcRelatorio.MarginColor,nAcima,nDireita,nAbaixo,nEsquerda,nLargura,nAltura,nOrientacao);
				formProp.ShowDialog();
				if (formProp.m_bModificado)
				{
					formProp.RetornaValores(out nAcima,out nDireita,out nAbaixo,out nEsquerda,out nLargura, out nAltura,out nOrientacao);
					m_rcRelatorio.Orientation = nOrientacao;
					m_rcRelatorio.SetMargins(nEsquerda,nAcima,nDireita,nAbaixo,false);
					switch(nOrientacao)
					{
						case (int)DrawingCanvasPackage.Orientation.Retract:
							break;
						case (int)DrawingCanvasPackage.Orientation.Image:
							int aux;
							aux = nAltura;
							nAltura = nLargura;
							nLargura = aux;
							break;
					}
					m_rcRelatorio.PageSize = new System.Drawing.Size(nLargura,nAltura);
					m_szPagina = m_rcRelatorio.PageSize;
					m_rcRelatorio.refreshFormatoRelatorio();
					ajustaTamanhoBarrasRolagem();
				}
			}
		#endregion

		#region Métodos que devem ser SobreEscritos
			public virtual bool bCarregaIdIdioma()
			{
				m_nIdIdioma = 3;
				return true;
			}

			private void carregaIdIdiomaDefault()
			{
			}

			public virtual bool bCarregaIdRelatorio() 
			{
				return false;
			}

			protected virtual bool bSalvaIdRelatorio()
			{
				return true;
			}

			protected void carregaIdRelatorioDefault()
			{
				System.Collections.ArrayList arlCondicaoCampo =  new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador =  new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor =  new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
					
				arlCondicaoCampo.Add("nIdTipo");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nTipoRelatorio);
					
				arlOrdenacaoCampo.Add("nIdRelatorio");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Decrestente);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				mdlDataBaseAccess.Tabelas.XsdTbRelatorios typDatSetTbRelatorios = m_cls_dba_ConnectionDB.GetTbRelatorios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				if (typDatSetTbRelatorios.tbRelatorios.Rows.Count > 0)
				{
					m_nIdRelatorio = ((mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow)typDatSetTbRelatorios.tbRelatorios.Rows[0]).nIdRelatorio;
				}
				else
				{
					m_nIdRelatorio = 0;
				}
				bSalvaIdRelatorio();
			}

			protected bool bRelatorioExiste()
			{
				bool bRetorno = false;
				System.Collections.ArrayList arlCondicaoCampo =  new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador =  new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor =  new System.Collections.ArrayList();
				arlCondicaoCampo.Add("nIdTipo");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nTipoRelatorio);
				arlCondicaoCampo.Add("nIdRelatorio");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdRelatorio);
				if (m_nIdRelatorio > 0)
				{
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				}
				else
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				}
				mdlDataBaseAccess.Tabelas.XsdTbRelatorios typDatSetTbRelatorios = m_cls_dba_ConnectionDB.GetTbRelatorios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetTbRelatorios.tbRelatorios.Rows.Count > 0)
				{
					bRetorno = true;
				}
				return(bRetorno);
			}

			protected virtual void  vIncrementaNumeroImpressoes()
			{

			}
		#endregion

		#region Impressao
			public bool bImprimeRelatorio(bool bShowDialog)
			{
				vConfiguraRelatorioImpressao();
				bMostrarRelatorio();
				vIncrementaNumeroImpressoes();
				return(m_rcRelatorio.bPrintReport(bShowDialog));
			}

			protected virtual void vConfiguraRelatorioImpressao()
			{
			}
		#endregion
	}
}

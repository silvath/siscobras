using System;

namespace mdlCriacaoDocumentos
{
	#region Enums
		public enum TIPOCRIACAO 
		{ 
			NULO = -1,
			ASSISTENTE = 1,
			MODELO1, 
			MODELO2 
		};
	#endregion
	/// <summary>
	/// Summary description for clsCriacao.
	/// </summary>
	public abstract class clsCriacao
	{
		#region Atributos
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dbaConnnectionDB = null;
		protected mdlTratamentoErro.clsTratamentoErro m_cls_terTratadorErro = null;
		protected string m_strEnderecoExecutavel = "";

		#region Verificadores Booleanos
		protected bool m_bIdiomaOK = false;
		protected bool m_bMoedaOK = false;
		protected bool m_bImportadorOK = false;
		protected bool m_bProdutosOK = false;
		protected bool m_bPesosOK = false;
		protected bool m_bNumeroOrdemCompraOK = false;
		protected bool m_bIncotermsOK = false;
		protected bool m_bLocaisOK = false;
		protected bool m_bCondicoesPagamentoOK = false;
		protected bool m_bBancoImportadorOK = false;
		protected bool m_bBancoExportadorOK = false;
		protected bool m_bObservacoesOK = false;
		protected bool m_bNumeroFaturaOK = false;
		protected bool m_bAssinaturaOK = false;
		#endregion

		private string m_strLinkInternet = "";

		protected bool m_bPossuiAlgumaCotacao = false;
		protected bool m_bPossuiAlgumPE = false;

		protected System.Windows.Forms.ImageList m_ilBandeiras = null;

		protected bool m_bMostrarInterface = true;

		protected int m_nIdExportador = -1;
		protected string m_strIdCodigo = "";
		protected string m_strIdCodigoModelo = "";
		/// <summary>
		/// Get string Codigo do documento criado
		/// </summary>
		public string CODIGORETORNO
		{
			get
			{
				return m_strIdCodigo;
			}
		}

		protected mdlNumero.clsNumero m_clsNumero = null;

		public bool m_bModificado = false;
		public TIPOCRIACAO m_enumTipoCadastro = TIPOCRIACAO.NULO;

		internal Frames.frmFLista m_formFLista = null;
		internal Frames.frmFCadastro m_formFCadastro = null;
		internal Frames.frmFAssistentePrincipal m_formFAssistentePrincipal = null;

		protected mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbRelatorios m_typDatSetTbRelatorios = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes m_typDatSetTbFaturasCotacoes = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas m_typDatSetTbFaturasProformas = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao m_typDatSetTbProdutosFaturaCotacao = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma m_typDatSetTbProdutosFaturaProforma = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial m_typDatSetTbProdutosFaturaComercial = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem m_typDatSetTbCertificadosOrigem = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem m_typDatSetTbProdutosCertificadoOrigem = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque m_typDatSetTbInstrucoesEmbarque = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbBorderos m_typDatSetTbBorderos = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbSaques m_typDatSetTbSaques = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbSumarios m_typDatSetTbSumarios = null;
		#endregion

		#region Construtores & Destrutores
		public clsCriacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, ref System.Windows.Forms.ImageList ilBandeiras)
		{
			m_cls_terTratadorErro = tratadorErro;
			m_cls_dbaConnnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			m_ilBandeiras = ilBandeiras;
			carregaTypDatSet();
			checaExistenciaCotacoesPEs();
		}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
		private void carregaTypDatSet()
		{
			try
			{
				// Cria os Arrays para pesquisa no Banco de Dados
				System.Collections.ArrayList arlCondicoesCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoValor = new System.Collections.ArrayList();
				arlCondicoesCampo.Add("idExportador");
				arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicoesValor.Add(m_nIdExportador);
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
				arlOrdenacaoValor.Add("nmCli");

				m_typDatSetTbPes = m_cls_dbaConnnectionDB.GetTbPes(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
				m_typDatSetTbRelatorios = m_cls_dbaConnnectionDB.GetTbRelatorios(null,null,null,null,null);
				m_typDatSetTbCertificadosOrigem = m_cls_dbaConnnectionDB.GetTbCertificadosOrigem(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
				m_typDatSetTbProdutosCertificadoOrigem = m_cls_dbaConnnectionDB.GetTbProdutosCertificadoOrigem(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
				m_typDatSetTbProdutosFaturaProforma = m_cls_dbaConnnectionDB.GetTbProdutosFaturaProforma(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);				
				m_typDatSetTbExportadores = m_cls_dbaConnnectionDB.GetTbExportadores(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
				m_typDatSetTbImportadores = m_cls_dbaConnnectionDB.GetTbImportadores(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,arlOrdenacaoValor,arlOrdenacaoTipo);
				m_typDatSetTbBorderos = m_cls_dbaConnnectionDB.GetTbBorderos(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
				m_typDatSetTbInstrucoesEmbarque = m_cls_dbaConnnectionDB.GetTbInstrucoesEmbarque(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
				m_typDatSetTbRomaneios = m_cls_dbaConnnectionDB.GetTbRomaneios(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
				m_typDatSetTbSaques = m_cls_dbaConnnectionDB.GetTbSaques(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
				m_typDatSetTbSumarios = m_cls_dbaConnnectionDB.GetTbSumarios(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
				
				arlOrdenacaoValor.Clear();
				arlOrdenacaoValor.Add("idPE");
				// Executa a pesquisa
				m_typDatSetTbFaturasComerciais = m_cls_dbaConnnectionDB.GetTbFaturasComerciais(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,arlOrdenacaoValor,arlOrdenacaoTipo);
				m_typDatSetTbFaturasProformas = m_cls_dbaConnnectionDB.GetTbFaturasProformas(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,arlOrdenacaoValor,arlOrdenacaoTipo);

				arlOrdenacaoValor.Clear();
				arlOrdenacaoValor.Add("idCotacao");

				m_typDatSetTbFaturasCotacoes = m_cls_dbaConnnectionDB.GetTbFaturasCotacoes(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,arlOrdenacaoValor,arlOrdenacaoTipo);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface
		protected void carregaDadosCotacao(ref mdlComponentesGraficos.ListView lvListaCotacoes, ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores = null;
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes = null;
				System.Windows.Forms.ListViewItem lvItemListaCotacao;
				int nIdImportador = -1;

				for (int nCount = 0; nCount < m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count; nCount++)
				{
					dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[nCount];
					if (!dtrwRowTbFaturasCotacoes.IsidImportadorNull())
						nIdImportador = dtrwRowTbFaturasCotacoes.idImportador;
					dtrwRowTbImportadores = m_typDatSetTbImportadores.tbImportadores.FindByidExportadoridImportador(m_nIdExportador,nIdImportador);
					if (dtrwRowTbImportadores != null)
					{
						if (!dtrwRowTbImportadores.IsnmCliNull())
							lvItemListaCotacao = lvListaCotacoes.Items.Add(dtrwRowTbImportadores.nmCli);
						else
							lvItemListaCotacao = lvListaCotacoes.Items.Add("");
						if (!dtrwRowTbFaturasCotacoes.IsmstrNumeroNull())
							lvItemListaCotacao.SubItems.Add(dtrwRowTbFaturasCotacoes.mstrNumero);
						else
							lvItemListaCotacao.SubItems.Add(dtrwRowTbFaturasCotacoes.idCotacao);
						lvItemListaCotacao.Tag = dtrwRowTbFaturasCotacoes.idCotacao;
						lvItemListaCotacao = null;
					}
					else
					{
						lvItemListaCotacao = lvListaCotacoes.Items.Add("");
						if (!dtrwRowTbFaturasCotacoes.IsmstrNumeroNull())
							lvItemListaCotacao.SubItems.Add(dtrwRowTbFaturasCotacoes.mstrNumero);
						else
							lvItemListaCotacao.SubItems.Add(dtrwRowTbFaturasCotacoes.idCotacao);
						lvItemListaCotacao.Tag = dtrwRowTbFaturasCotacoes.idCotacao;
						lvItemListaCotacao = null;
					}
					nIdImportador = -1;
				}
				gbFields.Text = "Selecione a Cotação modelo";
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaDadosComerciais(ref mdlComponentesGraficos.ListView lvListaComerciais, ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				//Variáveis
				mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores = null;
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais = null;
				System.Windows.Forms.ListViewItem lvItemListaComercial;
				int nIdImportador = -1;

				for (int nCount = 0; nCount < m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count; nCount++)
				{
					dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[nCount];
					if (!dtrwRowTbFaturasComerciais.IsidImportadorNull())
                        nIdImportador = dtrwRowTbFaturasComerciais.idImportador;
					dtrwRowTbImportadores = m_typDatSetTbImportadores.tbImportadores.FindByidExportadoridImportador(m_nIdExportador,nIdImportador);
					if (dtrwRowTbImportadores != null)
					{
						if (!dtrwRowTbImportadores.IsnmCliNull())
							lvItemListaComercial = lvListaComerciais.Items.Add(dtrwRowTbImportadores.nmCli);
						else
							lvItemListaComercial = lvListaComerciais.Items.Add("");
						lvItemListaComercial.SubItems.Add(dtrwRowTbFaturasComerciais.idPE);
						lvItemListaComercial.Tag = dtrwRowTbFaturasComerciais.idPE;

						lvItemListaComercial = null;
					}
					else
					{
						lvItemListaComercial = lvListaComerciais.Items.Add("");
						lvItemListaComercial.SubItems.Add(dtrwRowTbFaturasComerciais.idPE);
						lvItemListaComercial.Tag = dtrwRowTbFaturasComerciais.idPE;
						lvItemListaComercial = null;
					}
					nIdImportador = -1;
				}
				gbFields.Text = "Selecione o PE modelo";
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region Checa Existencia Cotações e PEs
		private void checaExistenciaCotacoesPEs()
		{
			try
			{
				// Cotações
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
					m_bPossuiAlgumaCotacao = true;
				else
					m_bPossuiAlgumaCotacao = false;

				// PEs
				if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					m_bPossuiAlgumPE = true;
				else
					m_bPossuiAlgumPE = false;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Cadastrar Baseado Cotação
		private void cadastrarPEBaseadoCotacao(string idCotacao)
		{
			try
			{
				m_bMostrarInterface = false;
				m_strIdCodigo = idCotacao;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Seleciona Tipo Criação
		protected void selecionaTipoCriacao(TIPOCRIACAO tpCriacao)
		{
			m_enumTipoCadastro = tpCriacao;
		}
		#endregion

		#region Seleciona Item Modelo
		protected void selecionaItemModelo(string strIdCodigoModelo)
		{
			m_strIdCodigoModelo = strIdCodigoModelo;
		}
		#endregion

		#region CadastrarPEDiretoBaseadoCotacaoSemMostrarInterface
		public void CadastrarPEDiretoBaseadoCotacaoSemMostrarInterface(string strIdCotacao)
		{
			try
			{
				m_bMostrarInterface = false;
				m_strIdCodigoModelo = strIdCotacao;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Cadastra Documento
		public abstract void cadastraDocumento();
		#endregion
		#region Assistente
		public abstract void ShowAssistente();
		protected abstract void carregaDadosEstadoAssistente();
		#endregion

		#region Altera Banner
		protected void alteraBanner(ref System.Windows.Forms.PictureBox pbBanner)
		{
			try
			{
				pbBanner.Image = mdlControladoraImagens.clsControladoraImagens.retornaImagem(mdlControladoraImagens.LOCALIMAGEM.ASSISTENTE);
				m_strLinkInternet = mdlControladoraImagens.clsControladoraImagens.LINKINTERNET;
				if (m_formFAssistentePrincipal != null)
					m_formFAssistentePrincipal.setToolTipBanner(mdlControladoraImagens.clsControladoraImagens.TOOLTIPIMAGEM);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region ClickBanner
		protected void clickBanner()
		{
			try
			{
				if (m_strLinkInternet != "")
					System.Diagnostics.Process.Start(m_strLinkInternet);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
	}
}

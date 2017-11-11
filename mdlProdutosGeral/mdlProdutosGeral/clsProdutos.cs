using System;
using System.Collections;

namespace mdlProdutosGeral
{
	#region Enums
	internal enum EstadoObjeto
	{
		Normal = 1,
		Novo = 2,
		Modificado = 3,
		Apagado = 4
	}

	internal enum TipoClassificacaoTarifaria
	{
		Ncm = 1,
		Naladi = 2
	}

	public enum DataSource
	{
		FaturaCotacao = 1,
		FaturaComercial = 2
	}

	#endregion
	/// <summary>
	/// Summary description for clsProdutos.
	/// </summary>
	public class clsProdutos
	{
		#region Static
			#region Atributes
				static protected mdlDataBaseAccess.clsDataBaseAccess ms_cls_dba_ConnectionDB = null;

				static protected mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa m_typDatSetTbUnidadesMassa = null;
				static protected mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco m_typDatSetTbUnidadesEspaco = null;

				static protected mdlDataBaseAccess.Tabelas.XsdTbVolumes m_typDatSetTbVolumes = null; 
			#endregion
			#region Properties
				static public mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa TypDatSetTbUnidadesMassa
				{
					get
					{
						if (m_typDatSetTbUnidadesMassa != null)
							return(m_typDatSetTbUnidadesMassa);
						ms_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
						m_typDatSetTbUnidadesMassa = ms_cls_dba_ConnectionDB.GetTbUnidadesMassa(null,null,null,null,null);
						return(m_typDatSetTbUnidadesMassa);
					}
				}

				static public mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco TypDatSetTbUnidadesEspaco
				{
					get
					{
						if (m_typDatSetTbUnidadesEspaco != null)
							return(m_typDatSetTbUnidadesEspaco);
						ms_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
						m_typDatSetTbUnidadesEspaco = ms_cls_dba_ConnectionDB.GetTbUnidadesEspaco(null,null,null,null,null);
						return(m_typDatSetTbUnidadesEspaco);
					}
				}

				static public mdlDataBaseAccess.Tabelas.XsdTbVolumes TypDatSetTbVolumes
				{
					get
					{
						if (m_typDatSetTbVolumes != null)
							return(m_typDatSetTbVolumes);
						ms_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
						m_typDatSetTbVolumes = ms_cls_dba_ConnectionDB.GetTbVolumes(null,null,null,null,null);
						return(m_typDatSetTbVolumes);
					}
				}
			#endregion
			#region Methods
			#region UnidadeMetrica
				static internal int nRetornaProximaUnidadeMetrica(int nUnidadeMetricaAtual)
				{
					int nRetorno = 0;
					switch(nUnidadeMetricaAtual)
					{
						case (int)mdlConstantes.UnidadeMedida.Centimetro:
							nRetorno = (int)mdlConstantes.UnidadeMedida.Metro;
							break;
						case (int)mdlConstantes.UnidadeMedida.Metro:
							nRetorno = (int)mdlConstantes.UnidadeMedida.Centimetro;
							break;
						default:
							nRetorno = (int)mdlConstantes.UnidadeMedida.Centimetro;
							break;
					}
					return(nRetorno);
				}

				static internal string strRetornaSiglaUnidadeMetrica(int nIdUnidadeEspaco)
				{
					string strRetorno = "";
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco.tbUnidadesEspacoRow dtrwUnidadesEspaco = (mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco.tbUnidadesEspacoRow)TypDatSetTbUnidadesEspaco.tbUnidadesEspaco.FindBynIdUnidadeEspaco(nIdUnidadeEspaco);                    
					if (dtrwUnidadesEspaco != null)
					{
						strRetorno = dtrwUnidadesEspaco.strSigla;	
					}
					return(strRetorno);
				}
				#endregion	
				#region UnidadeMassa
				static internal int nRetornaProximaUnidadeMassa(int nUnidadeMassaAtual)
				{
					int nRetorno = 0;
					switch(nUnidadeMassaAtual)
					{
						case 2: // Grama
							nRetorno = 3;
							break;
						case 3: // KiloGrama
							nRetorno = 4;
							break;
						case 4: // Tonelada
							nRetorno = 2;
							break;
						default:
							nRetorno = 2;
							break;
					}
					return (nRetorno);
				}

				static internal string strRetornaSiglaUnidadeMassa(int nIdUnidadeMassa)
				{
					string strRetorno = "";
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa.tbUnidadesMassaRow dtrwUnidadesMassa = (mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa.tbUnidadesMassaRow)TypDatSetTbUnidadesMassa.tbUnidadesMassa.FindBynIdUnidadeMassa(nIdUnidadeMassa);                    
					if (dtrwUnidadesMassa != null)
					{
						strRetorno = dtrwUnidadesMassa.strSigla;	
					}
					return(strRetorno);
				}
			#endregion

		#endregion
		#endregion

		#region Constantes
		// ***************************************************************************************************
		// Constantes
		// ***************************************************************************************************
		private const int ID_CATEGORIA_TODAS = 0;
		private const string TEXTO_CATEGORIA_TODAS = "Todas";
		private const int ID_CATEGORIA_SEM_CATEGORIA = -1;
		private const string TEXTO_CATEGORIA_SEM_CATEGORIA = "Sem Categoria";
		// ***************************************************************************************************
		#endregion 
		#region Atributos
		// ***************************************************************************************************
		// Atributos
		// ***************************************************************************************************
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel; 

		private int m_nIdExportador;

		private int m_nIdioma = -1;
		private string m_strIdioma;
		private int m_nIdCategoriaCorrente = -1;

		private bool m_bNaoGravarTbProdutos = false;

		protected bool m_bMostrarBaloes = true;

		private System.Collections.ArrayList m_arlProdutosChild = new System.Collections.ArrayList();
		private System.Windows.Forms.TreeNode m_tnASerSelecionado;

		private System.Windows.Forms.ImageList m_ilBandeiras;

		// Forms
		private frmFProdutos m_formFProdutos; 

		// Typed DataSets
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutos m_typDatSetTbProdutos = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm m_typDatSetTbProdutosNcm = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;		
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi m_typDatSetTbProdutosNaladi = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas m_typDatSetTbProdutosIdiomas = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosParents m_typDatSetTbProdutosParents = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias m_typDatSetTbProdutosCategorias = null;

		protected System.Collections.ArrayList m_arlProdutosCodigo = null;

		private bool m_bVisualizarNcm = true;
		private bool m_bVisualizarNaladi = true;
		private bool m_bVisualizarCodigo = true;
		public bool m_bModificado = false;
		public bool m_bDadosSalvos = false;
		private bool m_bConfirmed = false;
		private bool m_bProdutosModificados = false;

		// Apenas produtos Processo Exportacao
		private DataSource m_enumDataSource = DataSource.FaturaComercial;
		private bool m_bApenasProdutosCodigo = false;
		private string m_strIdCodigo = "";

		private string m_strProcurarTexto = ""; 
		// ***************************************************************************************************
		#endregion 
		#region Properties
			public string Codigo
			{
				get
				{
					return(m_strIdCodigo);
				}
				set
				{
					m_strIdCodigo = value.Trim();
					if (m_strIdCodigo == "")
						ApenasProdutosCodigo = false;
				}
			}

			public bool ApenasProdutosCodigo
			{
				get
				{
					return(m_bApenasProdutosCodigo);
				}
				set
				{
					if ((value) && (m_strIdCodigo != ""))
						m_bApenasProdutosCodigo = value;
					else
						m_bApenasProdutosCodigo = false;
				}
			}
			
			public DataSource DataSourceCodigo
			{
				get
				{
					return(m_enumDataSource);
				}
				set
				{
					m_enumDataSource = value;
				}
			}

			public bool Confirmed
			{
				get
				{
					return(m_bConfirmed);
				}
			}
		#endregion
		#region Construtors and Destructors
		public clsProdutos(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD,string EnderecoExecutavel, int Exportador, int Idioma, ref System.Windows.Forms.ImageList Bandeiras)
		{
			ms_cls_dba_ConnectionDB = conexaoBD;
			m_cls_ter_tratadorErro = tratadorErro; 
			m_cls_dba_ConnectionDB = conexaoBD;
			m_strEnderecoExecutavel = EnderecoExecutavel; 
			m_ilBandeiras = Bandeiras;
			m_nIdioma = Idioma;
			m_nIdExportador = Exportador;
			mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
			CarregaDados();
		}
		public clsProdutos(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD,string EnderecoExecutavel, int Exportador, int Idioma, ref System.Windows.Forms.ImageList Bandeiras, ref mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi)
		{
			ms_cls_dba_ConnectionDB = conexaoBD;
			m_cls_ter_tratadorErro = tratadorErro; 
			m_cls_dba_ConnectionDB = conexaoBD;
			m_strEnderecoExecutavel = EnderecoExecutavel; 
			m_ilBandeiras = Bandeiras;
			m_nIdioma = Idioma;
			m_nIdExportador = Exportador;
			m_typDatSetTbProdutosNaladi = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi)typDatSetTbProdutosNaladi.Copy();
			mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
			CarregaDados();
		}
		public clsProdutos(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD,string EnderecoExecutavel, int Exportador, int Idioma, ref System.Windows.Forms.ImageList Bandeiras, ref mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm)
		{
			ms_cls_dba_ConnectionDB = conexaoBD;
			m_cls_ter_tratadorErro = tratadorErro; 
			m_cls_dba_ConnectionDB = conexaoBD;
			m_strEnderecoExecutavel = EnderecoExecutavel; 
			m_ilBandeiras = Bandeiras;
			m_nIdioma = Idioma;
			m_nIdExportador = Exportador;
			m_typDatSetTbProdutosNcm = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm)typDatSetTbProdutosNcm.Copy();
			mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
			CarregaDados();
		}
		public clsProdutos(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD,string EnderecoExecutavel, int Exportador, int Idioma, ref System.Windows.Forms.ImageList Bandeiras, ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm, ref mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi, bool bNaoGravarTbs)
		{
			ms_cls_dba_ConnectionDB = conexaoBD;
			m_cls_ter_tratadorErro = tratadorErro; 
			m_cls_dba_ConnectionDB = conexaoBD;
			m_strEnderecoExecutavel = EnderecoExecutavel; 
			m_ilBandeiras = Bandeiras;
			m_nIdioma = Idioma;
			m_nIdExportador = Exportador;
			m_typDatSetTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos)typDatSetTbProdutos.Copy();
			m_typDatSetTbProdutosNcm = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm)typDatSetTbProdutosNcm.Copy();
			m_typDatSetTbProdutosNaladi = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi)typDatSetTbProdutosNaladi.Copy();
			m_bNaoGravarTbProdutos = bNaoGravarTbs;
			mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
			CarregaDados();
		}
		#endregion

		#region ShowDialogs
			public void ShowDialogProdutos()
			{
				int nIdIdioma;
				m_formFProdutos = new frmFProdutos(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel, m_bMostrarBaloes);
				CarregaDados();
				m_formFProdutos.ApenasProdutosCodigo = m_bApenasProdutosCodigo;
				m_formFProdutos.VisibilidadeNCM = m_bVisualizarNcm;
				m_formFProdutos.VisibilidadeNaladi = m_bVisualizarNaladi;
				vInitializeEvents(ref m_formFProdutos);
				mdlIdioma.clsIdioma clsIdiomas = new mdlIdioma.clsIdiomaGeral(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_nIdioma, ref m_ilBandeiras, "Produtos");
				clsIdiomas.retornaValores(out nIdIdioma, out m_strIdioma);
				m_formFProdutos.mostraIdioma(m_strIdioma,m_ilBandeiras.Images[m_nIdioma - 1]);
				clsIdiomas = null;
				m_formFProdutos.ShowDialog();
				m_formFProdutos = null;
			}

			private void vInitializeEvents(ref frmFProdutos formFProdutos)
			{
				// Refresh Idioma do Formulario
				formFProdutos.eCallRefreshIdioma += new frmFProdutos.delCallRefreshIdioma(this.m_formFProdutos_Idioma_refresh);

				// Trocar Idioma do Formulario
				formFProdutos.eCallTrocarIdioma += new frmFProdutos.delCallTrocarIdioma(this.m_formFProdutos_Idioma_Trocar);

				// Refresh TreeView Categorias
				formFProdutos.eCallRefreshTvCategorias += new frmFProdutos.delCallRefreshTvCategorias(this.m_formFProdutos_m_tvCategoria_refresh);

				// Troca a Super Categoria de uma Categoria
				formFProdutos.eCallTrocarSuperCategoriaDaCategoria += new frmFProdutos.delCallTrocarSuperCategoriaDaCategoria(this.TrocaSuperCategoriaDeCategoria);

				// Informar se Deve mostrar Codigo
				formFProdutos.eCallInformarMostrarCodigo += new frmFProdutos.delCallInformarMostrarCodigo(this.InformarMostrarCodigo);

				// Trocar Mostrar Codigo de uma Categoria
				formFProdutos.eCallTrocarMostrarCodigoDaCategoria += new frmFProdutos.delCallTrocarMostrarCodigoDaCategoria(this.TrocarMostrarCodigoCategoria);

				// Nova Categoria 
				formFProdutos.eCallNovaCategoria += new frmFProdutos.delCallNovaCategoria(this.NovaCategoria);

				// Editar Categoria
				formFProdutos.eCallEditarCategoria += new frmFProdutos.delCallEditarCategoria(this.EditarCategoria);
					 
				// Excluir Categoria 
				formFProdutos.eCallExcluirCategoria += new frmFProdutos.delCallExcluirCategoria(this.ExcluirCategoria);
					    
				// Refresh ListView Produtos
				formFProdutos.eCallRefreshListVProdutos += new frmFProdutos.delCallRefreshListVProdutos(this.m_formFProdutos_m_listVProdutos_refresh);

				// Refresh TreeView Produtos
				formFProdutos.eCallRefreshTreeVProdutos += new frmFProdutos.delCallRefreshTreeVProdutos(this.m_formFProdutos_m_treeVProdutos_refresh);

				// Trocar a Categoria de uma Array List de Produtos
				formFProdutos.eCallTrocarCategoriaArrayListProdutos += new frmFProdutos.delCallTrocarCategoriaArrayListProdutos(this.TrocarCategoriaDeArrayListProdutos);

				// Selecionar Produtos a partir de Tree View
				formFProdutos.eCallSelecionaProdutosAPartirTreeView += new frmFProdutos.delCallSelecionaProdutosAPartirTreeView(this.selecionaProdutoAPartirDaTreeView);

				// Selecionar Produtos a partir da List View
				formFProdutos.eCallSelecionaProdutosAPartirListView += new frmFProdutos.delCallSelecionaProdutosAPartirListView(this.selecionaProdutoAPartirDaListView);

				// Produtos Selecionados Como Produtos Filhos
				formFProdutos.eCallProdutosSelecionadosComoProdutosFilhos += new frmFProdutos.delCallProdutosSelecionadosComoProdutosFilhos(ProdutosSelecionadosComoProdutosFilhos);

				// Excluir Produtos Filhos
				formFProdutos.eCallExcluirProdutosFilhos += new frmFProdutos.delCallExcluirProdutosFilhos(ExcluirProdutosFilhos);

				// Novos Produtos
				formFProdutos.eCallNovosProdutos += new frmFProdutos.delCallNovosProdutos(this.NovosProdutos);

				// Editar Produtos
				formFProdutos.eCallEditarProdutos += new frmFProdutos.delCallEditarProdutos(this.EditarProdutos);

				// Excluir Produtos 
				formFProdutos.eCallExcluirProdutos += new frmFProdutos.delCallExcluirProdutos(this.ExcluirProdutos);
	                
				// Refresh ListView Ncm
				formFProdutos.eCallRefreshLvNcm += new frmFProdutos.delCallRefreshLvNcm(this.m_formFProdutos_m_lvNcm_refresh);

				// Trocar Ncm de uma Array List de Produtos
				formFProdutos.eCallTrocarNcmArrayListProdutos += new frmFProdutos.delCallTrocarNcmArrayListProdutos(this.TrocarNcmDeArrayListProdutos);

				// Nova Ncm
				formFProdutos.eCallNovaNcm += new frmFProdutos.delCallNovaNcm(this.NovaNcm);
					  
				// Editar Ncm
				formFProdutos.eCallEditarNcm += new frmFProdutos.delCallEditarNcm(this.EditarNcm);

				// Excluir Ncm
				formFProdutos.eCallExcluirNcm += new frmFProdutos.delCallExcluirNcm(this.ExcluirNcm);

				// Nova Ncm 
				formFProdutos.eCallCriarNovaNcm += new frmFProdutos.delCallCriarNovaNcm(this.NovaNcm);

				// Editar Ncm 
				formFProdutos.eCallEditarAntigaNcm += new frmFProdutos.delCallEditarAntigaNcm(this.EditarNcm);

				// Refresh ListView Naladi
				formFProdutos.eCallRefreshLvNaladi += new frmFProdutos.delCallRefreshLvNaladi(this.m_formFProdutos_m_lvNaladi_refresh);

				// Trocar Naladi de uma Array List de Produtos
				formFProdutos.eCallTrocarNaladiArrayListProdutos += new frmFProdutos.delCallTrocarNaladiArrayListProdutos(this.TrocarNaladiDeArrayListProdutos);

				// Nova Naladi
				formFProdutos.eCallNovaNaladi += new frmFProdutos.delCallNovaNaladi(this.NovaNaladi);
						  
				// Editar Naladi
				formFProdutos.eCallEditarNaladi += new frmFProdutos.delCallEditarNaladi(this.EditarNaladi);

				// Excluir Naladi
				formFProdutos.eCallExcluirNaladi += new frmFProdutos.delCallExcluirNaladi(this.ExcluirNaladi);

				// Nova Ncm 
				formFProdutos.eCallCriarNovaNaladi += new frmFProdutos.delCallCriarNovaNaladi(this.NovaNaladi);

				// Editar Naladi 
				formFProdutos.eCallEditarAntigaNaladi += new frmFProdutos.delCallEditarAntigaNaladi(this.EditarNaladi);

				// Mostrar apenas produtos codigo
				formFProdutos.eCallMostrarApenasProdutosCodigo += new mdlProdutosGeral.frmFProdutos.delCallMostrarApenasProdutosCodigo(this.bMostrarApenasProdutosCodigo);

				// Mostrar Produtos Codigo
				formFProdutos.eCallApenasProdutosCodigo +=new mdlProdutosGeral.frmFProdutos.delCallApenasProdutosCodigo(this.bApenasProdutosCodigo);

				// Salvar Dados 
				formFProdutos.eCallSalvaDados += new frmFProdutos.delCallSalvaDados(this.SalvaDados);

				// Salvar Dados Sem Sair
				formFProdutos.eCallSalvaDadosSemSair += new frmFProdutos.delCallSalvaDadosSemSair(this.SalvaDadosSemSair);

				// Procurar
				formFProdutos.eCallProcurar += new mdlProdutosGeral.frmFProdutos.delCallProcurar(ShowDialogProcurar);

				// ShowDialog Atributos
				formFProdutos.eCallShowDialogAtributos += new mdlProdutosGeral.frmFProdutos.delCallShowDialogAtributos(ShowDialogAtributos);

				// ShowDialog Propriedades
				formFProdutos.eCallShowDialogPropriedades +=new mdlProdutosGeral.frmFProdutos.delCallShowDialogPropriedades(ShowDialogPropriedades);

				// ShowDialog Pequisa Classificacao Tarifaria
				formFProdutos.eCallShowDialogPequisaClassificacaoTarifaria += new mdlProdutosGeral.frmFProdutos.delCallShowDialogPequisaClassificacaoTarifaria(ShowDialogPesquisaClassificacaoTarifaria);
			} 

			private void MostrarIdioma()
			{
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwTbExportadores = m_typDatSetTbExportadores.tbExportadores.FindByidExportador(m_nIdExportador);
				int nIdIdioma;
				string strIdioma;
				mdlIdioma.clsIdioma clsIdiomas = new mdlIdioma.clsIdiomaGeral(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_nIdioma, ref m_ilBandeiras, "Produtos");
				clsIdiomas.ShowDialog();
				if (clsIdiomas.m_bModificado)
				{
					clsIdiomas.retornaValores(out nIdIdioma, out strIdioma);
					if (m_nIdioma != nIdIdioma)
					{
						m_nIdioma = nIdIdioma;
						if (dtrwTbExportadores != null)
							dtrwTbExportadores.nProdutosUltimoIdioma = nIdIdioma;
						m_strIdioma = strIdioma;
						m_formFProdutos.mostraIdioma(m_strIdioma,m_ilBandeiras.Images[m_nIdioma - 1]);
						CarregaDadosProdutosLinguaEstrangeira();
						m_formFProdutos.RecarregaProdutosCasoNecessario();
					}
				}
				clsIdiomas = null;
			}
			public void ShowDialogClassificacoesTarifariasCadastroNCM(out string strCodigo, out string strDenominacao, out bool bModificado)
			{
				frmFClassificacoesTarifariasCadEdit formClassificacoesCadEdit = new frmFClassificacoesTarifariasCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref m_typDatSetTbProdutosNcm, mdlProdutosGeral.TipoClassificacaoTarifaria.Ncm);
				formClassificacoesCadEdit.ShowDialog();
				formClassificacoesCadEdit.retornaDados(out strCodigo, out strDenominacao);
				bModificado = formClassificacoesCadEdit.m_bModificado;
				formClassificacoesCadEdit = null;
			}
			public void ShowDialogClassificacoesTarifariasCadastroNALADI(out string strCodigo, out string strDenominacao, out bool bModificado)
			{
				frmFClassificacoesTarifariasCadEdit formClassificacoesCadEdit = new frmFClassificacoesTarifariasCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref m_typDatSetTbProdutosNaladi, mdlProdutosGeral.TipoClassificacaoTarifaria.Naladi);
				formClassificacoesCadEdit.ShowDialog();
				formClassificacoesCadEdit.retornaDados(out strCodigo, out strDenominacao);
				bModificado = formClassificacoesCadEdit.m_bModificado;
				formClassificacoesCadEdit = null;
			}
			public void ShowDialogClassificacoesTarifariasEdicaoNALADI(string strNALADIOriginal, string strDENOMINACAOOriginal, out string strCodigo, out string strDenominacao, out bool bModificado)
			{
				frmFClassificacoesTarifariasCadEdit formClassificacoesCadEdit = new frmFClassificacoesTarifariasCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref m_typDatSetTbProdutosNaladi, mdlProdutosGeral.TipoClassificacaoTarifaria.Naladi, strNALADIOriginal, strDENOMINACAOOriginal);
				formClassificacoesCadEdit.ShowDialog();
				formClassificacoesCadEdit.retornaDados(out strCodigo, out strDenominacao);
				bModificado = formClassificacoesCadEdit.m_bModificado;
				formClassificacoesCadEdit = null;
			}
			public void ShowDialogClassificacoesTarifariasEdicaoNCM(string strNCMOriginal, string strDENOMINACAOOriginal, out string strCodigo, out string strDenominacao, out bool bModificado)
			{
				frmFClassificacoesTarifariasCadEdit formClassificacoesCadEdit = new frmFClassificacoesTarifariasCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref m_typDatSetTbProdutosNcm, mdlProdutosGeral.TipoClassificacaoTarifaria.Ncm, strNCMOriginal, strDENOMINACAOOriginal);
				formClassificacoesCadEdit.ShowDialog();
				formClassificacoesCadEdit.retornaDados(out strCodigo, out strDenominacao);
				bModificado = formClassificacoesCadEdit.m_bModificado;
				formClassificacoesCadEdit = null;
			}
		#endregion
		#region ShowDialogProcurar
			private void ShowDialogProcurar()
			{
				frmFProcurar form = new frmFProcurar(m_strEnderecoExecutavel);
				form.TextoProcurar = m_strProcurarTexto;
				form.eCallProcurar += new mdlProdutosGeral.frmFProcurar.delCallProcurar(formProcurar_eCallProcurar);
				form.ShowDialog();
				m_strProcurarTexto = form.TextoProcurar;
			}

			private bool formProcurar_eCallProcurar(string strDescricao)
			{
				strDescricao = strDescricao.ToLower();
				if (m_formFProdutos == null)
					return(false);
				mdlComponentesGraficos.ListView lvProdutos = m_formFProdutos.ListaProdutos;
				int nIndex = 0;
				if (lvProdutos.SelectedItems.Count > 0)
				{
					nIndex = lvProdutos.SelectedItems[0].Index;
					nIndex++;
					if (nIndex >= lvProdutos.Items.Count)
						nIndex = 0;
					lvProdutos.SelectedItems.Clear();
				}
				for(int i = nIndex; i < lvProdutos.Items.Count;i++)
				{
					System.Windows.Forms.ListViewItem lviItem = lvProdutos.Items[i];
					if (lviItem.SubItems[1].Text.ToLower().IndexOf(strDescricao) != -1)
					{
						lviItem.Selected = true;
						lvProdutos.EnsureVisible(lviItem.Index);
						return(true);
					}
				}
				return (false);
			}
		#endregion
		#region ShowDialogAtributos
			private bool ShowDialogAtributos(int nIdProduto)
			{
				frmFAtributos form = new frmFAtributos(m_strEnderecoExecutavel,nIdProduto);
				InitializeEvents(form);
				form.ShowDialog();
				return(false);
			}

			private void InitializeEvents(frmFAtributos form)
			{
				//Carrega Dados
				form.eCallCarregaDados += new mdlProdutosGeral.frmFAtributos.delCallCarregaDados(CarregaDadosProduto);

				//Salva Dados
				form.eCallSalvaDados += new mdlProdutosGeral.frmFAtributos.delCallSalvaDados(SalvaDadosProduto);

				// ShowDialog Volume Tipo
				form.eCallShowVolumeTipo += new mdlProdutosGeral.frmFAtributos.delCallShowVolumeTipo(ShowDialogVolumeTipo);

				form.eCallCarregaVolumeTipo += new mdlProdutosGeral.frmFAtributos.delCallCarregaVolumeTipo(CarregaDadosVolume);
			}
		#endregion
		#region ShowDialogVolumeTipo
			internal bool ShowDialogVolumeTipo(ref int nIdVolumeTipo)
			{
				frmFVolumeTipo formFVolumeTipo = new frmFVolumeTipo(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel);
				InitializeEventsFormVolumeTipo(ref formFVolumeTipo);
				formFVolumeTipo.Icon = m_formFProdutos.Icon;
				formFVolumeTipo.EspecieSelect = nIdVolumeTipo;
				formFVolumeTipo.ShowDialog();
				if (formFVolumeTipo.m_bModificado)
					formFVolumeTipo.RetornaValores(out nIdVolumeTipo);
				return(formFVolumeTipo.m_bModificado);
			}
				
			private void InitializeEventsFormVolumeTipo(ref frmFVolumeTipo formFVolumeTipo)
			{
				// Carregando os dados da Embalagem
				formFVolumeTipo.eCallCarregaDadosInterfaceVolumeTipo += new frmFVolumeTipo.delCallCarregaDadosInterfaceVolumeTipo(CarregaDadosInterfaceEmbalagemTipoFormVolumes);
			}

			private void CarregaDadosInterfaceEmbalagemTipoFormVolumes(ref mdlComponentesGraficos.ListView lvTiposVolumes, ref System.Windows.Forms.ImageList ilVolumes)
			{
				lvTiposVolumes.Columns[0].Width = lvTiposVolumes.Width - 25;
				mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow dtrwTipoVolume;
				System.Windows.Forms.ListViewItem lviVolume;

				lvTiposVolumes.Items.Clear();
				for (int nCont = 0 ;nCont < TypDatSetTbVolumes.tbVolumes.Rows.Count;nCont++)
				{
					dtrwTipoVolume = (mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow)TypDatSetTbVolumes.tbVolumes.Rows[nCont];
					lviVolume = lvTiposVolumes.Items.Add(dtrwTipoVolume.strDescricao);
					lviVolume.Tag = dtrwTipoVolume.nIdVolume;
					lviVolume.ImageIndex = dtrwTipoVolume.nIdImagem;
				}
			}

			private bool CarregaDadosVolume(int nIdVolumeTipo, out string strVolumeTipo)
			{
				strVolumeTipo = "";
				mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow dtrwVolume = TypDatSetTbVolumes.tbVolumes.FindBynIdVolume(nIdVolumeTipo);
				if (dtrwVolume != null)
				{
					if (!dtrwVolume.IsstrDescricaoNull())
						strVolumeTipo = dtrwVolume.strDescricao;
					return(true);
				}
				return(false);
			}
		#endregion
		#region ShowDialogPropriedades
			internal bool ShowDialogPropriedades()
			{
				clsProdutosPropriedades obj = new clsProdutosPropriedades(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador);
				return(obj.ShowDialog());
			}
		#endregion
		#region ShowDialogPesquisaClassificacaoTarifaria
			private bool ShowDialogPesquisaClassificacaoTarifaria()
			{
				SalvaDadosNcm();
				mdlTec.clsTec tec = new mdlTec.clsTec(m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
				tec.Exportador = m_nIdExportador;
				tec.ShowDialog();
				if (tec.Modificado)
				{
					CarregaDadosNcm();
					return(true);
				}
				return(false);
			}
		#endregion

		#region Carregamento Dados 
		#region Carrega Dados
		private void CarregaDados()
		{
			CarregaDadosConfiguracoes();
			CarregaDadosIdioma();
			CarregaDadosCategorias();
			CarregaDadosProdutos();
			CarregaDadosProdutosParents();
			CarregaDadosProdutosLinguaEstrangeira();
			CarregaDadosNcm();
			CarregaDadosNaladi();
		}
		#endregion
		#region Configurações
		private void CarregaDadosConfiguracoes()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwTbExportadores;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_nIdioma = 1;
				m_bVisualizarNcm = true;
				m_bVisualizarNaladi = true;

				m_typDatSetTbExportadores = m_cls_dba_ConnectionDB.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					// Idioma
					if (!dtrwTbExportadores.IsnProdutosUltimoIdiomaNull())
					{
						m_nIdioma = dtrwTbExportadores.nProdutosUltimoIdioma;
						if (m_nIdioma < 1)
							m_nIdioma = 1;
					}
						
					// Visualizar Ncm
					if (!dtrwTbExportadores.IsbProdutosVisualizarNcmNull())
					{
						m_bVisualizarNcm = dtrwTbExportadores.bProdutosVisualizarNcm;
					}
						
					// Visualizar Naladi
					if (!dtrwTbExportadores.IsbProdutosVisualizarNaladiNull())
					{
						m_bVisualizarNaladi = dtrwTbExportadores.bProdutosVisualizarNaladi;
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
		#region Idioma
		private void CarregaDadosIdioma()
		{
			int nIdIdioma;
			mdlIdioma.clsIdioma clsIdiomas = new mdlIdioma.clsIdiomaGeral(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_nIdioma, ref m_ilBandeiras, "Produtos");
			clsIdiomas.retornaValores(out nIdIdioma, out m_strIdioma);
			if (m_strIdioma.Trim().Length == 0)
			{
				m_nIdioma = 1;
				m_strIdioma = "Português";
			}
		}
		#endregion
		#region Categorias
		private void CarregaDadosCategorias()
		{
			try
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
					
				m_typDatSetTbProdutosCategorias = m_cls_dba_ConnectionDB.GetTbProdutosCategorias(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Dados Produtos
		private void CarregaDadosProdutos()
		{
			try
			{
				if (m_typDatSetTbProdutos == null)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					
					m_typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Dados Produtos Parents
		private void CarregaDadosProdutosParents()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosParents.tbProdutosParentsRow dtrwTbProdutosParents;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
						
				m_typDatSetTbProdutosParents = m_cls_dba_ConnectionDB.GetTbProdutosParents(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				for (int nCount = 0; nCount < m_typDatSetTbProdutosParents.tbProdutosParents.Rows.Count; nCount++)
				{
					dtrwTbProdutosParents = (mdlDataBaseAccess.Tabelas.XsdTbProdutosParents.tbProdutosParentsRow)m_typDatSetTbProdutosParents.tbProdutosParents.Rows[nCount];
					m_arlProdutosChild.Add(dtrwTbProdutosParents.nIdProdutoChild);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Língua Estrangeira
		private void CarregaDadosProdutosLinguaEstrangeira()
		{
			try
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idIdioma");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdioma);

				m_typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			//				ADODB.Recordset rstDados;
			//				clsItemProdutoLinguaEstrangeira itemProdutoLinguaEstrangeira;	
			//			
			//				int nIdProduto;
			//				string strDescricao;
			//
			//				m_arlProdutosLinguaEstrangeira = new ArrayList();
			//				if (m_nIdioma != -1)
			//				{
			//					rstDados = m_cls_abd_conexaoBD.executa("SELECT * FROM tbProdutosIdiomas WHERE (idExportador = " + m_nIdExportador + " ) AND (idIdioma = " + m_nIdioma + " ) ");
			//					while (!rstDados.EOF)
			//					{
			//						// Id 
			//						if (System.DBNull.Value != rstDados.Fields["idProduto"].Value )                    
			//							nIdProduto = (int)rstDados.Fields["idProduto"].Value;
			//						else
			//							nIdProduto = -1;
			//
			//						// strDescricao
			//						if (System.DBNull.Value != rstDados.Fields["strDescricao"].Value )                    
			//							strDescricao = (string)rstDados.Fields["strDescricao"].Value;
			//						else
			//							strDescricao = "";
			//
			//						// Criando o Produto e Inserindo 
			//						itemProdutoLinguaEstrangeira = new clsItemProdutoLinguaEstrangeira(nIdProduto,strDescricao,false);
			//						m_arlProdutosLinguaEstrangeira.Add(itemProdutoLinguaEstrangeira);
			//
			//						rstDados.MoveNext();
			//					}
			//				}
		}
		#endregion
		#region Ncm
		private void CarregaDadosNcm()
		{
			try
			{
				if (m_typDatSetTbProdutosNcm == null)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdencaoTipo = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlOrdenacaoCampo.Add("strNcm");
					arlOrdencaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
					
					m_typDatSetTbProdutosNcm = m_cls_dba_ConnectionDB.GetTbProdutosNcm(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdencaoTipo);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Naladi
		private void CarregaDadosNaladi()
		{
			try
			{
				if (m_typDatSetTbProdutosNaladi == null)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdencaoTipo = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlOrdenacaoCampo.Add("strNaladi");
					arlOrdencaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
					
					m_typDatSetTbProdutosNaladi = m_cls_dba_ConnectionDB.GetTbProdutosNaladi(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdencaoTipo);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Atributos
			private bool CarregaDadosProduto(int nIdProduto, out string strDescricao, out double dPesoLiquido, out int nUnidadePesoLiquido, out double dPesoBruto, out int nUnidadePesoBruto, out double dLargura, out int nUnidadeLargura, out double dComprimento, out int nUnidadeComprimento, out double dAltura, out int nUnidadeAlgura, out int nIdVolumeTipo, out string strVolumeTipoPopular, out double dQuantidadeVolume, out double dVolumeLargura, out int nVolumeUnidadeLargura, out double dVolumeComprimento, out int nVolumeUnidadeComprimento, out double dVolumeAltura, out int nVolumeUnidadeAlgura, out double dQuantidadeEmbalagens, out double dEmbalagensVolume,out bool bPossuiMaterialImportado,out double dPorcentagemValorNacional)
			{
				strDescricao = "";
				dPesoLiquido = 0;
				nUnidadePesoLiquido = 3;
				dPesoBruto = 0;
				nUnidadePesoBruto = 3;
				dLargura = 0;
				nUnidadeLargura = 2;
				dComprimento = 0;
				nUnidadeComprimento = 2;
				dAltura = 0;
				nUnidadeAlgura = 2;
				nIdVolumeTipo = 0;
				strVolumeTipoPopular = "";
				dQuantidadeVolume = 0;
				dVolumeLargura = 0;
				nVolumeUnidadeLargura = 2;
				dVolumeComprimento = 0;
				nVolumeUnidadeComprimento = 2;
				dVolumeAltura = 0;
				nVolumeUnidadeAlgura = 2;
				dQuantidadeEmbalagens = 0;
				dEmbalagensVolume = 0;
				bPossuiMaterialImportado = false;
				dPorcentagemValorNacional = 0;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if (dtrwProduto == null)
					return(false);
				if (dtrwProduto.RowState == System.Data.DataRowState.Deleted)
					return(false);
				// Produto
				if (!dtrwProduto.IsmstrDescricaoNull())
					strDescricao = dtrwProduto.mstrDescricao;
				if (!dtrwProduto.IsdPesoLiquidoNull())
					dPesoLiquido = dtrwProduto.dPesoLiquido;
				if (!dtrwProduto.IsnUnidadeMassaPesoLiquidoNull())
					nUnidadePesoLiquido = dtrwProduto.nUnidadeMassaPesoLiquido;
				if (!dtrwProduto.IsdPesoBrutoNull())
					dPesoBruto = dtrwProduto.dPesoBruto;
				if (!dtrwProduto.IsnUnidadeMassaPesoBrutoNull())
					nUnidadePesoBruto = dtrwProduto.nUnidadeMassaPesoBruto;
				if (!dtrwProduto.IsdLarguraNull())
					dLargura = dtrwProduto.dLargura;
				if (!dtrwProduto.IsnUnidadeLarguraNull())
					nUnidadeLargura = dtrwProduto.nUnidadeLargura;
				if (!dtrwProduto.IsdComprimentoNull())
					dComprimento = dtrwProduto.dComprimento;
				if (!dtrwProduto.IsnUnidadeComprimentoNull())
					nUnidadeComprimento = dtrwProduto.nUnidadeComprimento;
				if (!dtrwProduto.IsdAlturaNull())
					dAltura = dtrwProduto.dAltura;
				if (!dtrwProduto.IsnUnidadeAlturaNull())
					nUnidadeAlgura = dtrwProduto.nUnidadeAltura;
				if (!dtrwProduto.IsnlTipoVolumeNull())
					nIdVolumeTipo = dtrwProduto.nlTipoVolume;
				if (!dtrwProduto.IsstrTipoPopularNull())
					strVolumeTipoPopular = dtrwProduto.strTipoPopular;
				if (!dtrwProduto.IsdQuantidadeVolumeNull())
					dQuantidadeVolume = dtrwProduto.dQuantidadeVolume;
				if (!dtrwProduto.IsdVolumeLarguraNull())
					dVolumeLargura = dtrwProduto.dVolumeLargura;
				if (!dtrwProduto.IsnVolumeUnidadeLarguraNull())
					nVolumeUnidadeLargura = dtrwProduto.nVolumeUnidadeLargura;
				if (!dtrwProduto.IsdVolumeComprimentoNull())
					dVolumeComprimento = dtrwProduto.dVolumeComprimento;
				if (!dtrwProduto.IsnVolumeUnidadeComprimentoNull())
					nVolumeUnidadeComprimento = dtrwProduto.nVolumeUnidadeComprimento;
				if (!dtrwProduto.IsdVolumeAlturaNull())
					dVolumeAltura = dtrwProduto.dVolumeAltura;
				if (!dtrwProduto.IsnVolumeUnidadeAlturaNull())
					nVolumeUnidadeAlgura = dtrwProduto.nVolumeUnidadeAltura;
				if (!dtrwProduto.IsdQuantidadeEmbalagemNull())
					dQuantidadeEmbalagens = dtrwProduto.dQuantidadeEmbalagem;
				if (!dtrwProduto.IsdQuantidadeEmbalagensVolumeNull())
					dEmbalagensVolume = dtrwProduto.dQuantidadeEmbalagensVolume;
				bPossuiMaterialImportado = !dtrwProduto.IsbPossuiMaterialImportadoNull() ? dtrwProduto.bPossuiMaterialImportado : false;
				dPorcentagemValorNacional = !dtrwProduto.IsdPorcentagemValorNacionalNull() ? dtrwProduto.dPorcentagemValorNacional : 0;
				return(true);
			}
		#endregion
		#endregion
		#region Salvando Dados
		#region Configuração
		/// <summary>
		/// Salva os Dados Referentes a Configuracao da Janela 
		/// </summary>
		private void SalvaDadosConfiguracao()
		{
			mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwTbExportadores;
			m_bVisualizarNcm = m_formFProdutos.VisibilidadeNCM;
			m_bVisualizarNaladi = m_formFProdutos.VisibilidadeNaladi;
			if (m_typDatSetTbExportadores != null)
			{
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					dtrwTbExportadores.nProdutosUltimoIdioma = m_nIdioma;
					dtrwTbExportadores.bProdutosVisualizarNcm = m_bVisualizarNcm;
					dtrwTbExportadores.bProdutosVisualizarNaladi = m_bVisualizarNaladi;
					m_cls_dba_ConnectionDB.SetTbExportadores(m_typDatSetTbExportadores);
				}
			}
		}
		#endregion
		#region Categorias
		/// <summary>
		/// Salvando os Dados das Categorias 
		/// </summary>
		private void SalvaDadosCategorias()
		{
			try
			{
				if (m_typDatSetTbProdutosCategorias != null)
					m_cls_dba_ConnectionDB.SetTbProdutosCategorias(m_typDatSetTbProdutosCategorias);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Produtos
		/// <summary>
		/// Salvando os Dados dos Produtos
		/// </summary>
		private void SalvaDadosProdutos()
		{
			try
			{
				if ((m_typDatSetTbProdutos != null) && (!m_bNaoGravarTbProdutos))
					m_cls_dba_ConnectionDB.SetTbProdutos(m_typDatSetTbProdutos);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Produtos Parents
		/// <summary>
		/// Salvando os Dados dos Produtos Parents
		/// </summary>
		private void SalvaDadosProdutosParents()
		{
			try
			{
				if (m_typDatSetTbProdutosParents != null)
					m_cls_dba_ConnectionDB.SetTbProdutosParents(m_typDatSetTbProdutosParents);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}		
		#endregion
		#region Produtos Língua Estrangeira
		/// <summary>
		/// Salvando os Dados Produtos Língua Estrangeira
		/// </summary>
		private void SalvaDadosProdutosLinguaEstrangeira()
		{
			try
			{
				if (m_typDatSetTbProdutosIdiomas != null)
					m_cls_dba_ConnectionDB.SetTbProdutosIdiomas(m_typDatSetTbProdutosIdiomas);
				m_bProdutosModificados = false;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Ncm
		/// <summary>
		/// Salvando os Dados Ncm
		/// </summary>
		private void SalvaDadosNcm()
		{
			try
			{
				if ((m_typDatSetTbProdutosNcm != null) && (!m_bNaoGravarTbProdutos))
					m_cls_dba_ConnectionDB.SetTbProdutosNcm(m_typDatSetTbProdutosNcm);
				m_typDatSetTbProdutosNcm = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Naladi
		/// <summary>
		/// Salva Dados Naladi
		/// </summary>
		private void SalvaDadosNaladi()
		{
			try
			{
				if ((m_typDatSetTbProdutosNaladi != null) && (!m_bNaoGravarTbProdutos))
					m_cls_dba_ConnectionDB.SetTbProdutosNaladi(m_typDatSetTbProdutosNaladi);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Salva Dados
		/// <summary>
		/// Salva Dados
		/// </summary>
		private void SalvaDados()
		{
			m_bDadosSalvos = true;
			SalvaDadosConfiguracao();
			SalvaDadosCategorias();
			SalvaDadosProdutos();
			SalvaDadosProdutosParents();
			SalvaDadosProdutosLinguaEstrangeira();
			SalvaDadosNcm();
			SalvaDadosNaladi();
			m_bConfirmed = true;
		}
		private void SalvaDadosSemSair()
		{
			m_bDadosSalvos = true;
			SalvaDadosConfiguracao();
			SalvaDadosCategorias();
			SalvaDadosProdutos();
			SalvaDadosProdutosParents();
			SalvaDadosProdutosLinguaEstrangeira();
			SalvaDadosNcm();
			SalvaDadosNaladi();
			CarregaDados();
			m_bProdutosModificados = false;
			m_bConfirmed = true;
		}
		#endregion
		#region Atributos
			private bool SalvaDadosProduto(int nIdProduto,string strDescricao, double dPesoLiquido,int nUnidadePesoLiquido, double dPesoBruto, int nUnidadePesoBruto, double dLargura, int nUnidadeLargura, double dComprimento, int nUnidadeComprimento, double dAltura, int nUnidadeAlgura, int nIdVolumeTipo, string strVolumeTipoPopular, double dQuantidadeVolume, double dVolumeLargura, int nVolumeUnidadeLargura, double dVolumeComprimento, int nVolumeUnidadeComprimento, double dVolumeAltura, int nVolumeUnidadeAlgura, double dQuantidadeEmbalagens, double dEmbalagensVolume,bool bPossuiMaterialImportado,double dPorcentagemValorNacional)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if (dtrwProduto == null)
					return(false);
				if (dtrwProduto.RowState == System.Data.DataRowState.Deleted)
					return(false);
				// Produto
				dtrwProduto.mstrDescricao = strDescricao;
				dtrwProduto.dPesoLiquido = dPesoLiquido;
				dtrwProduto.nUnidadeMassaPesoLiquido = nUnidadePesoLiquido;
				dtrwProduto.dPesoBruto = dPesoBruto;
				dtrwProduto.nUnidadeMassaPesoBruto = nUnidadePesoBruto;
				dtrwProduto.dLargura = dLargura;
				dtrwProduto.nUnidadeLargura = nUnidadeLargura;
				dtrwProduto.dComprimento = dComprimento;
				dtrwProduto.nUnidadeComprimento = nUnidadeComprimento;
				dtrwProduto.dAltura = dAltura;
				dtrwProduto.nUnidadeAltura = nUnidadeAlgura;
				dtrwProduto.nlTipoVolume = nIdVolumeTipo;
				dtrwProduto.strTipoPopular = strVolumeTipoPopular;
				dtrwProduto.dQuantidadeVolume = dQuantidadeVolume;
				dtrwProduto.dVolumeLargura = dVolumeLargura;
				dtrwProduto.nVolumeUnidadeLargura = nVolumeUnidadeLargura;
				dtrwProduto.dVolumeComprimento = dVolumeComprimento;
				dtrwProduto.nVolumeUnidadeComprimento = nVolumeUnidadeComprimento;
				dtrwProduto.dVolumeAltura = dVolumeAltura;
				dtrwProduto.nVolumeUnidadeAltura = nVolumeUnidadeAlgura;
				dtrwProduto.dQuantidadeEmbalagem = dQuantidadeEmbalagens;
				dtrwProduto.dQuantidadeEmbalagensVolume = dEmbalagensVolume;
				dtrwProduto.bPossuiMaterialImportado = bPossuiMaterialImportado;
				dtrwProduto.dPorcentagemValorNacional = dPorcentagemValorNacional;
				return(true);
			}
		#endregion
		#endregion

		#region Eventos dos Formulários
		#region Produtos Idioma Refresh
		private void m_formFProdutos_Idioma_refresh()
		{
			m_formFProdutos.mostraIdioma(m_strIdioma,m_ilBandeiras.Images[m_nIdioma - 1]);
		}
		#endregion
		#region Trocar Idioma
		private void m_formFProdutos_Idioma_Trocar()
		{
			if (m_bProdutosModificados)
			{
				if (mdlMensagens.clsMensagens.ShowQuestion("Produtos",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_clsProdutos_ProdutosModificados).Replace("\\n","\n").Replace("TAG",m_strIdioma),System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					//if (System.Windows.Forms.MessageBox.Show("Alguns produtos em " + m_strIdioma + " foram modificados. Deseja salvá-los ?","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
					//{
					SalvaDadosProdutosLinguaEstrangeira();
					//}
				}
				else
				{
					m_bProdutosModificados = false;
				}
			}
			this.MostrarIdioma();
		}
		#endregion
		#region Tree View Categoria Refresh
		private void m_formFProdutos_m_tvCategoria_refresh(ref System.Windows.Forms.TreeView tvCategoria)
		{
			refreshTvCategorias(ref tvCategoria);
		}
		#endregion
		#region List View Produtos Refresh
		private void m_formFProdutos_m_listVProdutos_refresh(int nCategoria,ref mdlComponentesGraficos.ListView listVProdutos,bool bMostrarNcm,bool bMotrarNaladi)
		{
			refreshListVProdutos(nCategoria, ref listVProdutos, bMostrarNcm, bMotrarNaladi);
		}
		#endregion
		#region Tree View Produtos Refresh
		private void m_formFProdutos_m_treeVProdutos_refresh(int nCategoria, ref mdlComponentesGraficos.TreeView treeVProdutos,bool bMostrarNcm, bool bMotrarNaladi)
		{
			refreshtreeVProdutos(nCategoria,ref treeVProdutos, bMostrarNcm, bMotrarNaladi);
		}
		#endregion
		#region Ncm Refresh
		private void m_formFProdutos_m_lvNcm_refresh(ref mdlComponentesGraficos.ListView lvNcm)
		{
			refreshLvNcm(ref lvNcm);
		}
		#endregion
		#region Naladi Refresh
		private void m_formFProdutos_m_lvNaladi_refresh(ref mdlComponentesGraficos.ListView lvNaladi)
		{
			refreshLvNaladi(ref lvNaladi);
		}
		#endregion
		#endregion
		#region Refreshs
		#region tvCategoria
		#region refreshTvCategorias
		/// <summary>
		///  Refresh a Lista de Categoria para o Exportador atual 
		/// </summary>
		/// <param name="tvCategoria"></param>
		private void refreshTvCategorias(ref System.Windows.Forms.TreeView tvCategoria)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias;
				System.Windows.Forms.TreeNode tvnNodo;
				System.Windows.Forms.TreeNode tvnNodoTodas;
				System.Windows.Forms.TreeNode tvnNodoInserir;
				int nQuantNodosInseridos = 0;
					
				// Limpando a TreeView 
				tvCategoria.Nodes.Clear();
				// Todas 
				tvnNodo = tvCategoria.Nodes.Add(TEXTO_CATEGORIA_TODAS);
				tvnNodoTodas = tvnNodo;
				tvnNodo.Tag = ID_CATEGORIA_TODAS;
				tvCategoria.SelectedNode = tvnNodo;
				//nQuantNodosInseridos++;//Testando...................não é comentado
				// Sem Categoria 
				tvnNodo = tvnNodo.Nodes.Add(TEXTO_CATEGORIA_SEM_CATEGORIA);
				tvnNodo.Tag = ID_CATEGORIA_SEM_CATEGORIA;
				tvnNodo.ImageIndex = 1;
				tvnNodo.SelectedImageIndex = 3;
				//nQuantNodosInseridos++;//Testando...................não é comentado
					
				// Nodo de Todas 
				tvnNodo = tvnNodo.Parent;
				while (nQuantNodosInseridos < m_typDatSetTbProdutosCategorias.tbProdutosCategorias.Rows.Count)
				{
					// Inserindo a Lista de Categorias Ordenadamente 
					SortedList sortListCategorias;
					sortListCategorias = sortListRetornaListaCategoriasDaSuperCategoriaOrdenados((int)tvnNodo.Tag);
					for (int nCont = 0 ; nCont < sortListCategorias.Count; nCont++)
					{
						dtrwTbProdutosCategorias = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow)sortListCategorias.GetByIndex(nCont);
						tvnNodoInserir = tvnNodo.Nodes.Add(dtrwTbProdutosCategorias.mstrNomeCategoria);
						tvnNodoInserir.Tag = dtrwTbProdutosCategorias.nIdCategoria;
						if (dtrwTbProdutosCategorias.nIdCategoria == m_nIdCategoriaCorrente)
							tvCategoria.SelectedNode = tvnNodoInserir;
						nQuantNodosInseridos++;
					}
					
					// Passando para o proximo Nodo
					if (tvnNodo.Nodes.Count > 0)
					{
						tvnNodo = tvnNodo.FirstNode;
					}
					else
					{
						if (tvnNodo.NextNode != null)
						{
							tvnNodo = tvnNodo.NextNode;
						}
						else
						{
							if (tvnNodo.Parent != null)
							{
								tvnNodo = tvnNodo.Parent;
								while (tvnNodo.Nodes.Count > 0)
								{
									if (tvnNodo.NextNode != null)
									{
										tvnNodo = tvnNodo.NextNode;
									}
									else
									{
										if (tvnNodo.Parent != null)
											tvnNodo = tvnNodo.Parent;
										else
											tvnNodo = tvnNodo.FirstNode;
									}
								}
							}
						}
					}
				}
				//tvCategoria.ExpandAll();
				tvnNodoTodas.Expand();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region sortListRetornaListaCategoriasDaSuperCategoriaOrdenados
		/// <summary>
		/// Cria a sortedList que contem todas as super categorias
		/// </summary>
		/// <param name="IdSuperCategoria"></param>
		/// <returns></returns>
		private SortedList sortListRetornaListaCategoriasDaSuperCategoriaOrdenados(int IdSuperCategoria)
		{
			SortedList sortListRetorno = new SortedList();
			try
			{					
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias;
				if (m_typDatSetTbProdutosCategorias != null)
				{
					for (int nCount = 0; nCount < m_typDatSetTbProdutosCategorias.tbProdutosCategorias.Rows.Count; nCount++)
					{
						dtrwTbProdutosCategorias = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow)m_typDatSetTbProdutosCategorias.tbProdutosCategorias.Rows[nCount];
						if ((dtrwTbProdutosCategorias.nIdSuperCategoria == IdSuperCategoria) && (dtrwTbProdutosCategorias.nIdCategoria != ID_CATEGORIA_SEM_CATEGORIA) && (dtrwTbProdutosCategorias.nIdCategoria != IdSuperCategoria) )
						{
							if (dtrwTbProdutosCategorias.RowState != System.Data.DataRowState.Deleted)
								sortListRetorno.Add(dtrwTbProdutosCategorias.mstrNomeCategoria,dtrwTbProdutosCategorias);
						}
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return (sortListRetorno);
		}
		#endregion
		#endregion
		#region listVProdutos
		private void refreshListVProdutos(int nCategoria,ref mdlComponentesGraficos.ListView listVProdutos,bool bNecessitaColocarNcm,bool bNecessitaColocarNaladi)
		{
			try
			{
				listVProdutos.Columns[0].Width = (m_bVisualizarCodigo ? 50 : 0);
				listVProdutos.Columns[2].Width = (m_bVisualizarCodigo ? 70 : 0);
				listVProdutos.Columns[3].Width = (m_bVisualizarCodigo ? 70 : 0);
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
				System.Windows.Forms.ListViewItem lvItemProdutoInserir;
				SortedList sortListProdutos;
				bool bNecessitaColocarCodigo = false;
				bool bNecessitaColocarLinguaEstrangeira = false;

				// Limpando a TreeView
				listVProdutos.Items.Clear();
						
				// Verificando se necessita Colocar o Código;
				dtrwTbProdutosCategorias = retornaCategoria(nCategoria);
				if ((dtrwTbProdutosCategorias != null) && (!dtrwTbProdutosCategorias.IsbMostrarCodigoProdutoNull()))
					bNecessitaColocarCodigo = dtrwTbProdutosCategorias.bMostrarCodigoProduto;
						
				// Verificando se necessita Colocar Lingua Estrangeira;
				bNecessitaColocarLinguaEstrangeira = (m_nIdioma != 1);
						
				sortListProdutos = sortListRetornaListaProdutosDaCategoria(nCategoria);

				// Apenas produtos codigo
				if (m_bApenasProdutosCodigo)
				{
					if (m_arlProdutosCodigo == null)
						m_arlProdutosCodigo = arlRetornaProdutosCodigo();

					for (int i = sortListProdutos.Count - 1 ; i >= 0; i--)
					{
						dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)sortListProdutos.GetByIndex(i);
						if (!m_arlProdutosCodigo.Contains(dtrwTbProdutos.idProduto))
							sortListProdutos.RemoveAt(i);
					}
  				}

				// Adiciona Produtos
				string strCodigoProduto = "";
				string strDescricao = "";
				string strNcm = "";
				string strNaladi = "";
				for (int nCont = 0 ; nCont < sortListProdutos.Count; nCont++)
				{
					dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)sortListProdutos.GetByIndex(nCont);
					if (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted)
					{
						// Codigo do Produto
						if (!dtrwTbProdutos.IsmstrCodigoProdutoNull())
							strCodigoProduto = dtrwTbProdutos.mstrCodigoProduto;
						else
							strCodigoProduto = "";
						// Descricao
						if (!dtrwTbProdutos.IsmstrDescricaoNull())
							strDescricao = dtrwTbProdutos.mstrDescricao;
						else
							strDescricao = "";
						// Ncm
						if (!dtrwTbProdutos.IsstrNcmNull())
							strNcm = dtrwTbProdutos.strNcm;
						else
							strNcm = "";
						// Naladi
						if (!dtrwTbProdutos.IsstrNaladiNull())
							strNaladi = dtrwTbProdutos.strNaladi;
						else
							strNaladi = "";

						lvItemProdutoInserir = listVProdutos.Items.Add(strCodigoProduto);
						lvItemProdutoInserir.SubItems.Add(strDescricao);
						lvItemProdutoInserir.Tag = dtrwTbProdutos.idProduto;
						lvItemProdutoInserir.SubItems.Add(strNcm);
						lvItemProdutoInserir.SubItems.Add(strNaladi);
						// Produtos Parents
						if (bNecessitaColocarLinguaEstrangeira)
						{
							dtrwTbProdutosIdiomas = m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(m_nIdExportador,m_nIdioma, dtrwTbProdutos.idProduto);
							if (dtrwTbProdutosIdiomas != null)
							{
								if (!dtrwTbProdutosIdiomas.IsmstrDescricaoNull())
									lvItemProdutoInserir.SubItems.Add(dtrwTbProdutosIdiomas.mstrDescricao);
								else
									lvItemProdutoInserir.SubItems.Add(dtrwTbProdutosIdiomas.strDescricao);
							}
							else
							{
								lvItemProdutoInserir.SubItems.Add("");
							}
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
		#endregion
		#region treeVProdutos
		#region refreshtreeVProdutos
		private void refreshtreeVProdutos(int nCategoria,ref mdlComponentesGraficos.TreeView treeVProdutos,bool bNecessitaColocarNcm,bool bNecessitaColocarNaladi)
		{
			try
			{
				#region Variáveis
				System.Collections.ArrayList arlProdutosChild = new System.Collections.ArrayList();
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
				System.Windows.Forms.TreeNode tvnNodoInserir;
				SortedList sortListProdutos;
				bool bNecessitaColocarCodigo = false;
				bool bNecessitaColocarLinguaEstrangeira = false;
				#endregion
						
				#region Checagem e Inicializações
				// Limpando a TreeView
				treeVProdutos.Nodes.Clear();
						
				// Verificando se necessita Colocar o Código;
				dtrwTbProdutosCategorias = retornaCategoria(nCategoria);
				if (dtrwTbProdutosCategorias != null && !dtrwTbProdutosCategorias.IsbMostrarCodigoProdutoNull())
					bNecessitaColocarCodigo = dtrwTbProdutosCategorias.bMostrarCodigoProduto;
						
				// Verificando se necessita Colocar Lingua Estrangeira;
				bNecessitaColocarLinguaEstrangeira = (m_nIdioma != 1);
						
				string tvNodoTexto = "";
						
				sortListProdutos = sortListRetornaListaProdutosDaCategoria(nCategoria);
				#endregion
				#region Adiciona Produtos
				for (int nCont = 0 ; nCont < sortListProdutos.Count; nCont++)
				{
					dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)sortListProdutos.GetByIndex(nCont);
					if (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted)
					{
						if (!m_arlProdutosChild.Contains(dtrwTbProdutos.idProduto))
						{
							#region Produtos Parents
							tvNodoTexto += dtrwTbProdutos.mstrDescricao;
							tvnNodoInserir = treeVProdutos.Nodes.Add(tvNodoTexto);
							tvnNodoInserir.Tag = dtrwTbProdutos.idProduto;
							tvNodoTexto = "";
							#endregion
							#region Produtos Child
							refreshProdutosChilds(ref tvnNodoInserir, dtrwTbProdutos.idProduto);
							#endregion
						}
					}
				}
				#endregion
				treeVProdutos.ExpandAll();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void refreshProdutosChilds(ref System.Windows.Forms.TreeNode tvnNodoInserir, int nIdProdutoParent)
		{
			try
			{
				System.Windows.Forms.TreeNode tvnNodo;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosParents.tbProdutosParentsRow dtrwTbProdutosParents;
				for (int nCount = 0; nCount < m_typDatSetTbProdutosParents.tbProdutosParents.Rows.Count; nCount++)
				{
					dtrwTbProdutosParents = (mdlDataBaseAccess.Tabelas.XsdTbProdutosParents.tbProdutosParentsRow)m_typDatSetTbProdutosParents.tbProdutosParents.Rows[nCount];
					if (dtrwTbProdutosParents.RowState != System.Data.DataRowState.Deleted)
					{
						if (nIdProdutoParent == dtrwTbProdutosParents.nIdProdutoParent)
						{
							dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwTbProdutosParents.nIdProdutoChild);
							if (dtrwTbProdutos != null)
							{
								if (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted)
								{
									tvnNodo = tvnNodoInserir.Nodes.Add(dtrwTbProdutos.mstrDescricao);
									tvnNodo.Tag = dtrwTbProdutos.idProduto;
									if (!m_arlProdutosChild.Contains(dtrwTbProdutos.idProduto))
										m_arlProdutosChild.Add(dtrwTbProdutos.idProduto);
									refreshProdutosChilds(ref tvnNodo, dtrwTbProdutos.idProduto);
								}
							}
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
		private void refreshtreeVProdutos(int nCategoria,ref mdlComponentesGraficos.TreeView treeVProdutos,bool bNecessitaColocarNcm,bool bNecessitaColocarNaladi, int nIdProdutoASerSelecionado)
		{
			try
			{
				m_tnASerSelecionado = null;
				#region Variáveis
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
				System.Windows.Forms.TreeNode tvnNodoInserir;
				SortedList sortListProdutos;
				bool bNecessitaColocarCodigo = false;
				bool bNecessitaColocarLinguaEstrangeira = false;
				#endregion
						
				#region Checagem e Inicializações
				// Limpando a TreeView
				treeVProdutos.Nodes.Clear();
						
				// Verificando se necessita Colocar o Código;
				dtrwTbProdutosCategorias = retornaCategoria(nCategoria);
				if (dtrwTbProdutosCategorias != null && !dtrwTbProdutosCategorias.IsbMostrarCodigoProdutoNull())
					bNecessitaColocarCodigo = dtrwTbProdutosCategorias.bMostrarCodigoProduto;
						
				// Verificando se necessita Colocar Lingua Estrangeira;
				bNecessitaColocarLinguaEstrangeira = (m_nIdioma != 1);
						
				string tvNodoTexto = "";
						
				sortListProdutos = sortListRetornaListaProdutosDaCategoria(nCategoria);
				#endregion
				#region Adiciona Produtos
				for (int nCont = 0 ; nCont < sortListProdutos.Count; nCont++)
				{
					dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)sortListProdutos.GetByIndex(nCont);
					if (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted)
					{
						if (!m_arlProdutosChild.Contains(dtrwTbProdutos.idProduto))
						{
							#region Produtos Parents
							tvNodoTexto += dtrwTbProdutos.mstrDescricao;
							tvnNodoInserir = treeVProdutos.Nodes.Add(tvNodoTexto);
							tvnNodoInserir.Tag = dtrwTbProdutos.idProduto;
							if (dtrwTbProdutos.idProduto == nIdProdutoASerSelecionado)
								m_tnASerSelecionado = tvnNodoInserir;
							tvNodoTexto = "";
							#endregion
							#region Produtos Child
							//						for (int nCount = 0; nCount < m_typDatSetTbProdutosParents.tbProdutosParents.Rows.Count; nCount++)
							//						{
							//							dtrwTbProdutosParents = (mdlDataBaseAccess.Tabelas.XsdTbProdutosParents.tbProdutosParentsRow)m_typDatSetTbProdutosParents.tbProdutosParents.Rows[nCount];
							//							if (dtrwTbProdutos.idProduto == dtrwTbProdutosParents.nIdProdutoParent)
							//							{
							//								dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwTbProdutosParents.nIdProdutoChild);
							//								if (dtrwTbProdutos != null)
							//								{
							//									tvNodoTexto += dtrwTbProdutos.mstrDescricao;
							//									tvnNodo = tvnNodoInserir.Nodes.Add(tvNodoTexto);
							//									tvnNodo.Tag = dtrwTbProdutos.idProduto;
							//									tvNodoTexto = "";
							//								}
							//							}
							//						}
							refreshProdutosChilds(ref tvnNodoInserir, dtrwTbProdutos.idProduto, nIdProdutoASerSelecionado, ref treeVProdutos);
							#endregion
						}
					}
				}
				treeVProdutos.ExpandAll();
				if (m_tnASerSelecionado != null)
                    treeVProdutos.SelectedNode = m_tnASerSelecionado;
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void refreshProdutosChilds(ref System.Windows.Forms.TreeNode tvnNodoInserir, int nIdProdutoParent, int nIdProdutoASerSelecionado, ref mdlComponentesGraficos.TreeView tvProdutos)
		{
			try
			{
				System.Windows.Forms.TreeNode tvnNodo;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosParents.tbProdutosParentsRow dtrwTbProdutosParents;
				for (int nCount = 0; nCount < m_typDatSetTbProdutosParents.tbProdutosParents.Rows.Count; nCount++)
				{
					dtrwTbProdutosParents = (mdlDataBaseAccess.Tabelas.XsdTbProdutosParents.tbProdutosParentsRow)m_typDatSetTbProdutosParents.tbProdutosParents.Rows[nCount];
					if (dtrwTbProdutosParents.RowState != System.Data.DataRowState.Deleted)
					{
						if (nIdProdutoParent == dtrwTbProdutosParents.nIdProdutoParent)
						{
							dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwTbProdutosParents.nIdProdutoChild);
							if (dtrwTbProdutos != null)
							{
								tvnNodo = tvnNodoInserir.Nodes.Add(dtrwTbProdutos.mstrDescricao);
								tvnNodo.Tag = dtrwTbProdutos.idProduto;
								tvnNodo.ExpandAll();
								if (!m_arlProdutosChild.Contains(dtrwTbProdutos.idProduto))
									m_arlProdutosChild.Add(dtrwTbProdutos.idProduto);
								if (nIdProdutoASerSelecionado == dtrwTbProdutos.idProduto)
									m_tnASerSelecionado = tvnNodo;
								refreshProdutosChilds(ref tvnNodo, dtrwTbProdutos.idProduto, nIdProdutoASerSelecionado, ref tvProdutos);
							}
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
		#endregion
		#region sortListRetornaListaProdutosDaCategoria
		/// <summary>
		/// Retorna sorted list com produtos da categoria
		/// </summary>
		/// <param name="nIdCategoria"></param>
		/// <returns></returns>
		private SortedList sortListRetornaListaProdutosDaCategoria(int nIdCategoria)
		{
			SortedList sortListRetorno = new SortedList();
			try
			{					
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
				if (m_typDatSetTbProdutos != null)
				{
					for (int nCount = 0; nCount < m_typDatSetTbProdutos.tbProdutos.Rows.Count; nCount++)
					{
						dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_typDatSetTbProdutos.tbProdutos.Rows[nCount];
						if (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted)
						{
							if ((dtrwTbProdutos.idCategoria == nIdCategoria) || (nIdCategoria == 0))
							{
								if (!m_bVisualizarCodigo)
								{
									if (!sortListRetorno.ContainsKey(dtrwTbProdutos.mstrDescricao))
									{
										sortListRetorno.Add(dtrwTbProdutos.mstrDescricao,dtrwTbProdutos);
									}
									else
									{
										dtrwTbProdutos.Delete();
									}
								}
								else
								{
									if (!sortListRetorno.ContainsKey(dtrwTbProdutos.idProduto))
									{
										sortListRetorno.Add(dtrwTbProdutos.idProduto,dtrwTbProdutos);
									}
									else
									{
										dtrwTbProdutos.Delete();
									}
								}
							}
						}
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return (sortListRetorno);
		}
		#endregion
		#endregion
		#region lvNcm
		#region refreshLvNcm
		private void refreshLvNcm(ref mdlComponentesGraficos.ListView lvNcm)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwTbProdutosNcm;
				System.Windows.Forms.ListViewItem lviItem;
				SortedList sortListNcm;
						
				// Limpando a ListView 
				lvNcm.Items.Clear();
						
				// Arrumando as Colunas
				lvNcm.Columns.Clear();
				lvNcm.Columns.Add("Código",80,System.Windows.Forms.HorizontalAlignment.Left);
				lvNcm.Columns.Add("Denominação",380,System.Windows.Forms.HorizontalAlignment.Left);
						
				sortListNcm = sortListRetornaListaNcm();
				for (int nCont = 0 ; nCont < sortListNcm.Count; nCont++)
				{
					dtrwTbProdutosNcm = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow)sortListNcm.GetByIndex(nCont);
					lviItem = lvNcm.Items.Add(dtrwTbProdutosNcm.strNcm);
					lviItem.SubItems.Add(dtrwTbProdutosNcm.mstrDenominacao);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		#endregion
		#region sortListRetornaListaNcm
		private SortedList sortListRetornaListaNcm()
		{
			SortedList sortListRetorno = new SortedList();
			try
			{						
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwTbProdutosNcm;
				for (int nCont = 0; nCont < m_typDatSetTbProdutosNcm.tbProdutosNcm.Rows.Count; nCont++)
				{
					dtrwTbProdutosNcm = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow)m_typDatSetTbProdutosNcm.tbProdutosNcm.Rows[nCont];
					sortListRetorno.Add(dtrwTbProdutosNcm.strNcm,dtrwTbProdutosNcm);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return (sortListRetorno);
		}
		#endregion
		#endregion
		#region lvNaladi
		#region refreshLvNaladi
		private void refreshLvNaladi(ref mdlComponentesGraficos.ListView lvNaladi)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwTbProdutosNaladi;
				System.Windows.Forms.ListViewItem lviItem;
				SortedList sortListNaladi;
						
				// Limpando a ListView 
				lvNaladi.Items.Clear();
						
				// Arrumando as Colunas
				lvNaladi.Columns.Clear();
				lvNaladi.Columns.Add("Código",80,System.Windows.Forms.HorizontalAlignment.Left);
				lvNaladi.Columns.Add("Denominação",380,System.Windows.Forms.HorizontalAlignment.Left);
						
				sortListNaladi = sortListRetornaListaNaladi();
				for (int nCont = 0 ; nCont < sortListNaladi.Count; nCont++)
				{
					dtrwTbProdutosNaladi = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow)sortListNaladi.GetByIndex(nCont);
					lviItem = lvNaladi.Items.Add(dtrwTbProdutosNaladi.strNaladi);
					lviItem.SubItems.Add(dtrwTbProdutosNaladi.mstrDenominacao);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		#endregion
		#region sortListRetornaListaNaladi
		private SortedList sortListRetornaListaNaladi()
		{
			SortedList sortListRetorno = new SortedList();
			try
			{						
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwTbProdutosNaladi;
				for (int nCont = 0; nCont < m_typDatSetTbProdutosNaladi.tbProdutosNaladi.Rows.Count; nCont++)
				{
					dtrwTbProdutosNaladi = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow)m_typDatSetTbProdutosNaladi.tbProdutosNaladi.Rows[nCont];
					sortListRetorno.Add(dtrwTbProdutosNaladi.strNaladi,dtrwTbProdutosNaladi);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return (sortListRetorno);
		}
		#endregion
		#endregion
		#endregion

		#region Codigo
			private bool bMostrarApenasProdutosCodigo()
			{
				return(m_strIdCodigo != "");
			}

			private bool bApenasProdutosCodigo(bool bProdutosCodigo)
			{
				bool bEstadoAnterior = this.ApenasProdutosCodigo;
				this.ApenasProdutosCodigo = bProdutosCodigo;
				return(bEstadoAnterior != this.ApenasProdutosCodigo);
			}

			private System.Collections.ArrayList arlRetornaProdutosCodigo()
			{
				System.Collections.ArrayList arlProdutosCodigo = new ArrayList();

				System.Collections.ArrayList arlCondicaoCampo = new ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new ArrayList();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				switch(m_enumDataSource)
				{
					case DataSource.FaturaCotacao:
						arlCondicaoCampo.Add("idCotacao");
						arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicaoValor.Add(m_strIdCodigo);
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao typDatSetProdutosFaturaCotacao = m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacao(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwProduto in typDatSetProdutosFaturaCotacao.tbProdutosFaturaCotacao.Rows)
						{
							if (!arlProdutosCodigo.Contains(dtrwProduto.idProduto))
								arlProdutosCodigo.Add(dtrwProduto.idProduto);
						}
						break;
					case DataSource.FaturaComercial:
						arlCondicaoCampo.Add("idPe");
						arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicaoValor.Add(m_strIdCodigo);
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto in typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.Rows)
						{
							if (!arlProdutosCodigo.Contains(dtrwProduto.idProduto))
								arlProdutosCodigo.Add(dtrwProduto.idProduto);
						}
						break;
				} 
				return(arlProdutosCodigo);
			}
		#endregion
		#region Categorias
		#region TrocaSuperCategoriaDeCategoria
		private void TrocaSuperCategoriaDeCategoria(int nCategoria,int nNovaSuperCategoria)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias;
				dtrwTbProdutosCategorias = retornaCategoria(nCategoria);
				if (dtrwTbProdutosCategorias != null)
					dtrwTbProdutosCategorias.nIdSuperCategoria = nNovaSuperCategoria;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region retornaCategoria
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow retornaCategoria(int nIdCategoria)
		{
			mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias = null;
			try
			{
				dtrwTbProdutosCategorias = m_typDatSetTbProdutosCategorias.tbProdutosCategorias.FindBynIdExportadornIdCategoria(m_nIdExportador,nIdCategoria);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return(dtrwTbProdutosCategorias);
		}
		#endregion
		#region InformarMostrarCodigo
		private void InformarMostrarCodigo(int nCategoria)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias;
				dtrwTbProdutosCategorias = retornaCategoria(nCategoria);
				if ((dtrwTbProdutosCategorias != null) && (!dtrwTbProdutosCategorias.IsbMostrarCodigoProdutoNull()))
					m_formFProdutos.MostrarCodigo = dtrwTbProdutosCategorias.bMostrarCodigoProduto = m_bVisualizarCodigo;
				else
					m_formFProdutos.MostrarCodigo = m_bVisualizarCodigo;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region TrocarMostrarCodigoCategoria
		private void TrocarMostrarCodigoCategoria(int nCategoria,bool bMostrarCodigo)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias;
				dtrwTbProdutosCategorias = retornaCategoria(nCategoria);
				if (dtrwTbProdutosCategorias != null)
					dtrwTbProdutosCategorias.bMostrarCodigoProduto = m_bVisualizarCodigo = bMostrarCodigo;
				else
					m_bVisualizarCodigo = bMostrarCodigo;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region nRetornarProximoIdCategoriaDisponivel
		private int nRetornarProximoIdCategoriaDisponivel()
		{
			int nRetorno = 1;
			try
			{
				bool bExisteAlguemComEsteId = true;
				while(bExisteAlguemComEsteId)
				{
					bExisteAlguemComEsteId = false;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias = null;
					for(int nCont = 0; nCont < m_typDatSetTbProdutosCategorias.tbProdutosCategorias.Rows.Count;nCont++)
					{
						dtrwTbProdutosCategorias = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow)m_typDatSetTbProdutosCategorias.tbProdutosCategorias.Rows[nCont];
						if (dtrwTbProdutosCategorias.RowState != System.Data.DataRowState.Deleted)
						{
							if (nRetorno == dtrwTbProdutosCategorias.nIdCategoria)
							{
								bExisteAlguemComEsteId = true;
								nRetorno++;
								break;
							}
						}
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return(nRetorno);
		}
		#endregion
		#region NovaCategoria
		private void NovaCategoria(System.Windows.Forms.TreeNode tvnNodoPai)
		{
			try
			{
				frmFCategoriaCadEdit formCadastro = new frmFCategoriaCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				formCadastro.ShowDialog();
				if (formCadastro.m_bModificado)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias;
					string strNovoNodo = "";
					int nIdCategoria = nRetornarProximoIdCategoriaDisponivel();
					System.Windows.Forms.TreeNode tvnNodoInserir;
					formCadastro.retornaDados(out strNovoNodo);
					tvnNodoInserir = tvnNodoPai.Nodes.Add(strNovoNodo);
					tvnNodoInserir.Tag = nIdCategoria;
					dtrwTbProdutosCategorias = m_typDatSetTbProdutosCategorias.tbProdutosCategorias.NewtbProdutosCategoriasRow();
					dtrwTbProdutosCategorias.nIdExportador = m_nIdExportador;
					dtrwTbProdutosCategorias.nIdCategoria = nIdCategoria;
					dtrwTbProdutosCategorias.nIdSuperCategoria = (int)tvnNodoPai.Tag;
					dtrwTbProdutosCategorias.mstrNomeCategoria = strNovoNodo;
					m_typDatSetTbProdutosCategorias.tbProdutosCategorias.AddtbProdutosCategoriasRow(dtrwTbProdutosCategorias);
				}
				formCadastro = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region EditarCategoria
		private void EditarCategoria(System.Windows.Forms.TreeNode tvnNodoEditar)
		{
			try
			{
				frmFCategoriaCadEdit formCadastro = new frmFCategoriaCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel,tvnNodoEditar.Text);
				formCadastro.ShowDialog();
				if (formCadastro.m_bModificado)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias;
					dtrwTbProdutosCategorias = retornaCategoria((int)tvnNodoEditar.Tag);
					string strNovoNodo;
					formCadastro.retornaDados(out strNovoNodo);
					dtrwTbProdutosCategorias.mstrNomeCategoria = strNovoNodo;
					tvnNodoEditar.Text = strNovoNodo;
				}
				formCadastro = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region ExcluirCategoria
		private void ExcluirCategoria(System.Windows.Forms.TreeNode tvnNodoExcluir)
		{
			try
			{
				if (tvnNodoExcluir != null)
				{
					if ((mdlMensagens.clsMensagens.ShowQuestion("Siscobras",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_clsProdutos_ExcluirCategorias).Replace("TAG",tvnNodoExcluir.Text),System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes))
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
						mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias;
						dtrwTbProdutosCategorias = retornaCategoria((int)tvnNodoExcluir.Tag);
						System.Collections.SortedList sortListProdutos;
				
						sortListProdutos = sortListRetornaListaProdutosDaCategoria((int)tvnNodoExcluir.Tag);
						for (int nCont = 0 ; nCont < sortListProdutos.Count; nCont++)
						{
							dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)sortListProdutos.GetByIndex(nCont);
							if (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted)
							{
								dtrwTbProdutos.idCategoria = ID_CATEGORIA_SEM_CATEGORIA;
							}
						}				
						dtrwTbProdutosCategorias.Delete();
						tvnNodoExcluir.Remove();
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
		#endregion
		#region Produtos
		#region selecionaProdutoAPartirDaListView
		private void selecionaProdutoAPartirDaListView(ref System.Windows.Forms.TreeView tvCategorias, ref mdlComponentesGraficos.TreeView tvProdutos, ref mdlComponentesGraficos.ListView lvProdutos, int X, int Y)
		{
			try
			{
				System.Windows.Forms.ListViewItem lvItemProduto = lvProdutos.GetItemAt(X, Y);
				int nIdProduto = (int)lvItemProduto.Tag;
				int nIdCategoria = (int)tvCategorias.SelectedNode.Tag;
				//tvCategorias.SelectedNode = tvCategorias.Nodes[0];
				//refreshtreeVProdutos(nIdCategoria, ref tvProdutos, true, true, nIdProduto);
				System.Windows.Forms.TreeNodeCollection tnClTemp = tvProdutos.Nodes;
				tvProdutos.SelectedNode = selecionaProdutoNaTreeView(ref tnClTemp, nIdProduto);
				//refreshListVProdutos(nIdCategoria, ref lvProdutos, true, true);
				//for (int nCount = 0; nCount < lvProdutos.Items.Count; nCount++)
				//{
				//	lvItemProduto = lvProdutos.Items[nCount];
				//	if ((int)lvItemProduto.Tag == nIdProduto)
				//	{
				//		lvItemProduto.Selected = true;
				//		lvItemProduto.Focused = true;
				//		break;
				//	}
				//}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private System.Windows.Forms.TreeNode selecionaProdutoNaTreeView(ref System.Windows.Forms.TreeNodeCollection tnCollection, int nIdProduto)
		{
			try
			{
				foreach(System.Windows.Forms.TreeNode tnNodo in tnCollection)
				{
					if ((int)tnNodo.Tag == nIdProduto)
					{
						return tnNodo;
					}
					if (tnNodo.Nodes.Count > 0)
					{
						System.Windows.Forms.TreeNodeCollection tnClTemp = tnNodo.Nodes;
						System.Windows.Forms.TreeNode tnTemp = selecionaProdutoNaTreeView(ref tnClTemp, nIdProduto);
						if (tnTemp != null)
							return tnTemp;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return null;
		}
		#endregion
		#region selecionaProdutoAPartirDaTreeView
		private void selecionaProdutoAPartirDaTreeView(ref System.Windows.Forms.TreeView tvCategorias, ref mdlComponentesGraficos.TreeView tvProdutos, ref mdlComponentesGraficos.ListView lvProdutos)
		{
			try
			{
				System.Windows.Forms.TreeNode NodoProduto = tvProdutos.SelectedNode;
				System.Windows.Forms.ListViewItem lvItemProduto;
				int nIdProduto = (int)NodoProduto.Tag;
				foreach(System.Windows.Forms.ListViewItem lvItemSelecionados in lvProdutos.SelectedItems)
					lvItemSelecionados.Selected = false;
				//mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = retornaProduto(nIdProduto);
				//int nIdCategoria = 0;
				//tvCategorias.SelectedNode = tvCategorias.Nodes[0];
				//refreshtreeVProdutos(nIdCategoria, ref tvProdutos, true, true, nIdProduto);
				//refreshListVProdutos(nIdCategoria,ref lvProdutos, true, true);
				for (int nCount = 0; nCount < lvProdutos.Items.Count; nCount++)
				{
					lvItemProduto = lvProdutos.Items[nCount];
					if ((int)lvItemProduto.Tag == nIdProduto)
					{
						lvItemProduto.Selected = true;
						lvItemProduto.Focused = true;
						break;
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
		#region retornaProduto
		private mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow retornaProduto(int nIdProduto)
		{
			mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = null;
			try
			{
				dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return(dtrwTbProdutos);
		}
		#endregion
		#region ProdutosSelecionadosComoProdutosFilhos
		private void ProdutosSelecionadosComoProdutosFilhos(System.Collections.ArrayList arlProdutosSelecionados, ref System.Windows.Forms.ListViewItem lvItemProdutoPai)
		{
			try
			{
				bool bJahExisteRelacaoParent = false;
				System.Windows.Forms.ListViewItem lvItemProdutoSelecionado;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosParents.tbProdutosParentsRow dtrwTbProdutoParents;
				System.Data.DataRow[] arrayDataRow = m_typDatSetTbProdutosParents.tbProdutosParents.Select("nIdProdutoParent = " + lvItemProdutoPai.Tag.ToString());
				for (int nCount1 = 0; nCount1 < arlProdutosSelecionados.Count; nCount1++)
				{
					bJahExisteRelacaoParent = false;
					lvItemProdutoSelecionado = (System.Windows.Forms.ListViewItem)arlProdutosSelecionados[nCount1];
					for (int nCount2 = 0; nCount2 < m_typDatSetTbProdutosParents.tbProdutosParents.Rows.Count; nCount2++)
					{
						dtrwTbProdutoParents = (mdlDataBaseAccess.Tabelas.XsdTbProdutosParents.tbProdutosParentsRow)m_typDatSetTbProdutosParents.tbProdutosParents[nCount2];
						if (dtrwTbProdutoParents.RowState != System.Data.DataRowState.Deleted)
						{
							if (((dtrwTbProdutoParents.nIdProdutoChild == (int)lvItemProdutoSelecionado.Tag) && (dtrwTbProdutoParents.nIdProdutoParent == (int)lvItemProdutoPai.Tag)) || ((dtrwTbProdutoParents.nIdProdutoParent == (int)lvItemProdutoSelecionado.Tag) && (dtrwTbProdutoParents.nIdProdutoChild == (int)lvItemProdutoPai.Tag)))
							{
								bJahExisteRelacaoParent = true;
								break;
							}
						}
					}
					if (bJahExisteRelacaoParent == false)
					{
						dtrwTbProdutoParents = m_typDatSetTbProdutosParents.tbProdutosParents.NewtbProdutosParentsRow();
						dtrwTbProdutoParents.nIdExportador = m_nIdExportador;
						dtrwTbProdutoParents.nIdProdutoParent = (int)lvItemProdutoPai.Tag;
						dtrwTbProdutoParents.nIdProdutoChild = (int)lvItemProdutoSelecionado.Tag;
						m_typDatSetTbProdutosParents.tbProdutosParents.AddtbProdutosParentsRow(dtrwTbProdutoParents);
						lvItemProdutoPai.Text = "*" + lvItemProdutoPai.Text;
					}
					dtrwTbProdutoParents = null;
					bJahExisteRelacaoParent = false;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region ExcluirProdutosFilhos
		private void ExcluirProdutosFilhos(ref System.Windows.Forms.ListViewItem lvItemProdutoPai)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosParents.tbProdutosParentsRow dtrwTbProdutoParents;
				System.Data.DataRow[] arrayDataRow = m_typDatSetTbProdutosParents.tbProdutosParents.Select("nIdProdutoParent = " + lvItemProdutoPai.Tag.ToString());
				for (int nCount1 = 0; nCount1 < arrayDataRow.Length; nCount1++)
				{
					dtrwTbProdutoParents = (mdlDataBaseAccess.Tabelas.XsdTbProdutosParents.tbProdutosParentsRow)arrayDataRow[nCount1];
					while(m_arlProdutosChild.Contains(dtrwTbProdutoParents.nIdProdutoChild))
					{
						m_arlProdutosChild.Remove(dtrwTbProdutoParents.nIdProdutoChild);
					}
					dtrwTbProdutoParents.Delete();
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region TrocarCategoriaDeArrayListProdutos
		private void TrocarCategoriaDeArrayListProdutos(System.Collections.ArrayList arlProdutos,int nNovaCategoria)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = null;
				int nIdProduto;
				for (int nCount = 0; nCount < arlProdutos.Count; nCount++)
				{
					nIdProduto = (int)arlProdutos[nCount];
					dtrwTbProdutos = retornaProduto(nIdProduto);
					dtrwTbProdutos.idCategoria = nNovaCategoria;
					m_bProdutosModificados = true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
 		}
		#endregion
		#region TrocarNcmDeArrayListProdutos
		private void TrocarNcmDeArrayListProdutos(System.Collections.ArrayList arlProdutos,System.Windows.Forms.ListViewItem lviNcm,bool bMostrarNcm,bool bMostrarNaladi)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias = null;
				System.Windows.Forms.ListViewItem ItemProduto;
				bool bNecessitaColocarCodigo = false;
				bool bNecessitaColocarLinguaEstrangeira = false;
				string strNomeProduto = "";
				
				// Verificando se necessita Colocar Lingua Estrangeira;
				bNecessitaColocarLinguaEstrangeira = (m_nIdioma != 1);
				
				for (int nCont = 0 ; nCont < arlProdutos.Count;nCont++)
				{
					strNomeProduto = "";
					ItemProduto = (System.Windows.Forms.ListViewItem)arlProdutos[nCont]; 
					dtrwTbProdutos = retornaProduto((int)ItemProduto.Tag);
					if (nCont == 0)
					{
						// Verificando se necessita Colocar o Código;
						dtrwTbProdutosCategorias = retornaCategoria(dtrwTbProdutos.idCategoria);
						if ((dtrwTbProdutosCategorias != null) && (!dtrwTbProdutosCategorias.IsbMostrarCodigoProdutoNull()))
							bNecessitaColocarCodigo = dtrwTbProdutosCategorias.bMostrarCodigoProduto;
					}
					
					// Ajustando o itemProduto
					if (lviNcm != null)
						dtrwTbProdutos.strNcm = lviNcm.Text;
					else
						dtrwTbProdutos.strNcm = "";
					
					// Ajustando a Interface - Método com erro!!!!!!!!!!!!!!!!!!!
					strNomeProduto = ItemProduto.Text;
					ItemProduto.SubItems[2].Text = dtrwTbProdutos.strNcm;
					m_bProdutosModificados = true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region TrocarNaladiDeArrayListProdutos
		private void TrocarNaladiDeArrayListProdutos(System.Collections.ArrayList arlProdutos,System.Windows.Forms.ListViewItem lviNaladi,bool bMostrarNcm,bool bMostrarNaladi)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias = null;
				System.Windows.Forms.ListViewItem ItemProduto;
				bool bNecessitaColocarCodigo = false;
				bool bNecessitaColocarLinguaEstrangeira = false;
				
				// Verificando se necessita Colocar Lingua Estrangeira;
				bNecessitaColocarLinguaEstrangeira = (m_nIdioma != 1);
				
				for (int nCont = 0 ; nCont < arlProdutos.Count;nCont++)
				{
					ItemProduto = (System.Windows.Forms.ListViewItem)arlProdutos[nCont];
					dtrwTbProdutos = retornaProduto((int)ItemProduto.Tag);
					if (nCont == 0)
					{
						// Verificando se necessita Colocar o Código;
						dtrwTbProdutosCategorias = retornaCategoria(dtrwTbProdutos.idCategoria);
						if ((dtrwTbProdutosCategorias != null) && (!dtrwTbProdutosCategorias.IsbMostrarCodigoProdutoNull()))
                            bNecessitaColocarCodigo = dtrwTbProdutosCategorias.bMostrarCodigoProduto;
					}
					
					// Ajustando o itemProduto
					if (lviNaladi != null)
						dtrwTbProdutos.strNaladi = lviNaladi.Text;
					else
						dtrwTbProdutos.strNaladi = "";
					
					// Ajustando a Interface 
					ItemProduto.SubItems[3].Text = dtrwTbProdutos.strNaladi;
					m_bProdutosModificados = true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Novos Produtos
		private void NovosProdutos(int nCategoria,ref mdlComponentesGraficos.ListView lvProdutos,bool bMostrarNcm,bool bMostrarNaladi)
		{
			try
			{
				System.Collections.ArrayList arlProdutos = new System.Collections.ArrayList();
				System.Collections.ArrayList arlProdutosLinguaEstrangeira = new System.Collections.ArrayList();
				m_nIdCategoriaCorrente = nCategoria;
				System.Windows.Forms.ListViewItem ItemProduto;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias = retornaCategoria(nCategoria);
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwTbProdutosIdiomas = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = null;
				//bool bMostrarCodigo = false; // Verificar se estas mudanças são realmente necessárias - em 20/10/2003
				//if ((dtrwTbProdutosCategorias != null) && (!dtrwTbProdutosCategorias.IsbMostrarCodigoProdutoNull()))
				//	bMostrarCodigo = dtrwTbProdutosCategorias.bMostrarCodigoProduto;
				frmFProdutosCad formCadastro = new frmFProdutosCad(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel, m_nIdExportador,m_nIdioma,m_strIdioma, m_nIdCategoriaCorrente, m_ilBandeiras.Images[m_nIdioma - 1],m_bVisualizarCodigo, ref arlProdutos, ref m_typDatSetTbProdutos, ref m_typDatSetTbProdutosIdiomas);
				formCadastro.ShowDialog();
				if (formCadastro.m_bModificado)
				{
					m_bProdutosModificados = formCadastro.m_bModificado;
					formCadastro.retornaTypDatSets(out m_typDatSetTbProdutos, out m_typDatSetTbProdutosIdiomas);
					formCadastro.retornaValoresCadastro(out arlProdutos,out arlProdutosLinguaEstrangeira);
					for (int nCont = 0 ; nCont < arlProdutos.Count;	nCont++)
					{
						// Copiando os Produtos para a Lista Correta 
						dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)arlProdutos[nCont];						
						ItemProduto = lvProdutos.Items.Add(dtrwTbProdutos.mstrCodigoProduto);
						ItemProduto.Tag = dtrwTbProdutos.idProduto;
						ItemProduto.SubItems.Add(dtrwTbProdutos.mstrDescricao);
						ItemProduto.SubItems.Add(dtrwTbProdutos.strNcm);
						ItemProduto.SubItems.Add(dtrwTbProdutos.strNaladi);
						if ((m_nIdioma != 1))
						{
							// Copiando os Produtos da Lingua Estrangeira para a Lista Correta 
							dtrwTbProdutosIdiomas = (mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow)arlProdutosLinguaEstrangeira[nCont];
							string strDescricaoLinguaEstrangeira = (!dtrwTbProdutosIdiomas.IsmstrDescricaoNull()) ? dtrwTbProdutosIdiomas.mstrDescricao : "";
							if (strDescricaoLinguaEstrangeira == "")
								strDescricaoLinguaEstrangeira = dtrwTbProdutosIdiomas.strDescricao;
							ItemProduto.SubItems.Add(strDescricaoLinguaEstrangeira);
						}
					}
				}
				formCadastro = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Editar Produtos
		/// <summary>
		/// Edita os produtos do Array List 
		/// </summary>
		/// <param name="arlProdutos"></param>
		private void EditarProdutos(int nCategoria,System.Collections.ArrayList arlProdutos)
		{
			try
			{
				frmFProdutosCad formEditar = null;
				m_nIdCategoriaCorrente = nCategoria;
				System.Windows.Forms.ListViewItem ItemProduto;
				System.Collections.ArrayList arlProdutosEditar = new System.Collections.ArrayList();
				System.Collections.ArrayList arlProdutosLinguaEstrangeira = new System.Collections.ArrayList();
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias.tbProdutosCategoriasRow dtrwTbProdutosCategorias = retornaCategoria(nCategoria);
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = null;
				bool bMostrarCodigo = false;
				if ((dtrwTbProdutosCategorias != null) && (!dtrwTbProdutosCategorias.IsbMostrarCodigoProdutoNull()))
					bMostrarCodigo = dtrwTbProdutosCategorias.bMostrarCodigoProduto;
				
				// Montando as Colecoes de Produtos 
				for (int nCont = 0 ; nCont < arlProdutos.Count;nCont++)
				{
					ItemProduto = (System.Windows.Forms.ListViewItem)arlProdutos[nCont];
					dtrwTbProdutos = retornaProduto((int)ItemProduto.Tag);
					arlProdutosEditar.Add(dtrwTbProdutos);
				}
				formEditar = new frmFProdutosCad(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_nIdioma,m_strIdioma,m_nIdCategoriaCorrente,m_ilBandeiras.Images[m_nIdioma - 1],true,true, ref arlProdutos, ref arlProdutosEditar, ref m_typDatSetTbProdutos, ref m_typDatSetTbProdutosIdiomas);
				formEditar.ShowDialog();
				if (!formEditar.m_bModificado)
				{
					formEditar.retornaTypDatSets(out m_typDatSetTbProdutos, out m_typDatSetTbProdutosIdiomas);
					arlProdutosEditar = new System.Collections.ArrayList();
					formEditar.retornaValoresEdicao(out arlProdutosEditar);
				}
				else
				{
					formEditar.retornaTypDatSetIdioma(out m_typDatSetTbProdutosIdiomas);
				}
				m_bProdutosModificados = formEditar.m_bModificado;
				formEditar = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Excluir Produtos
		private void ExcluirProdutos(System.Collections.ArrayList arlProdutos)
		{
			try
			{
                System.Windows.Forms.ListViewItem ItemProduto;
				System.Data.DataRow[] arrayDataRow;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwTbProdutosIdiomas = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosParents.tbProdutosParentsRow dtrwTbProdutosParents = null;
				System.Collections.ArrayList ArrayListdtrwTbProdutosParents = new System.Collections.ArrayList();
				for (int nCont = 0; nCont < arlProdutos.Count ;nCont++)
				{
					ArrayListdtrwTbProdutosParents.Clear();
					ItemProduto = (System.Windows.Forms.ListViewItem)arlProdutos[nCont];
					dtrwTbProdutos = retornaProduto((int)ItemProduto.Tag);
					arrayDataRow = m_typDatSetTbProdutosParents.tbProdutosParents.Select("nIdProdutoParent = " + ItemProduto.Tag.ToString());
					for (int nCont2 = 0; nCont2 < arrayDataRow.Length; nCont2++)
					{
						dtrwTbProdutosParents = (mdlDataBaseAccess.Tabelas.XsdTbProdutosParents.tbProdutosParentsRow)arrayDataRow[nCont2];
						while(m_arlProdutosChild.Contains(dtrwTbProdutosParents.nIdProdutoChild))
						{
							m_arlProdutosChild.Remove(dtrwTbProdutosParents.nIdProdutoChild);
						}
						dtrwTbProdutosParents.Delete();
					}
					arrayDataRow = m_typDatSetTbProdutosParents.tbProdutosParents.Select("nIdProdutoChild = " + ItemProduto.Tag.ToString());
					for (int nCont3 = 0; nCont3 < arrayDataRow.Length; nCont3++)
					{
						dtrwTbProdutosParents = (mdlDataBaseAccess.Tabelas.XsdTbProdutosParents.tbProdutosParentsRow)arrayDataRow[nCont3];
						while(m_arlProdutosChild.Contains(dtrwTbProdutosParents.nIdProdutoChild))
						{
							m_arlProdutosChild.Remove(dtrwTbProdutosParents.nIdProdutoChild);
						}
						dtrwTbProdutosParents.Delete();
					}
					arrayDataRow = m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.Select("idProduto = " + ItemProduto.Tag.ToString());
					for (int nCont4 = 0; nCont4 < arrayDataRow.Length; nCont4++)
					{
						dtrwTbProdutosIdiomas = (mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow)arrayDataRow[nCont4];
						dtrwTbProdutosIdiomas.Delete();
					}
					dtrwTbProdutos.Delete();
					ItemProduto.Remove();
					m_bProdutosModificados = true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
		#region Ncm
			#region retornaNcm
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow retornaNcm(string nIdNcm)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwTbProdutosNcm = null;
				try
				{
					dtrwTbProdutosNcm = m_typDatSetTbProdutosNcm.tbProdutosNcm.FindBynIdExportadorstrNcm(m_nIdExportador,nIdNcm);
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				return(dtrwTbProdutosNcm);
			}
			#endregion
			#region NovaNcm
			private void NovaNcm(ref mdlComponentesGraficos.ListView lvNcm)
			{
				try
				{
					frmFClassificacoesTarifariasCadEdit formClassTar = new frmFClassificacoesTarifariasCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel,ref m_typDatSetTbProdutosNcm,mdlProdutosGeral.TipoClassificacaoTarifaria.Ncm);
					formClassTar.ShowDialog();
					if (formClassTar.m_bModificado)
					{
						string strCodigo = "";
						string strDenominacao = "";
						formClassTar.retornaDados(out strCodigo,out strDenominacao);
						// Adicionando a List View de Ncms
						if ((strCodigo != null) && (strCodigo.Trim() != ""))
						{
							System.Windows.Forms.ListViewItem lviNcm;
							lviNcm = lvNcm.Items.Add(strCodigo);
							lviNcm.SubItems.Add(strDenominacao);			
							lviNcm.Selected = true;
							NovaNcm(strCodigo, strDenominacao);
						}
					}
					formClassTar = null;
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region NovaNcm
			private void NovaNcm(string Codigo, string Denominacao)
			{
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwTbProdutosNcm = m_typDatSetTbProdutosNcm.tbProdutosNcm.NewtbProdutosNcmRow();
					dtrwTbProdutosNcm.nIdExportador = m_nIdExportador;
					dtrwTbProdutosNcm.strNcm = Codigo;
					dtrwTbProdutosNcm.mstrDenominacao = Denominacao;
					m_typDatSetTbProdutosNcm.tbProdutosNcm.AddtbProdutosNcmRow(dtrwTbProdutosNcm);
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region EditarNcm
		    /// <summary>
		    /// Editando a Ncm
		    /// </summary>
		    /// <param name="arlNcm"></param>
		    /// <param name="lvProdutos"></param>
			private void EditarNcm(System.Collections.ArrayList arlNcm, ref mdlComponentesGraficos.ListView lvProdutos)
			{
				try
				{
                    if (arlNcm.Count > 0)
					{
						System.Windows.Forms.ListViewItem lviItemNcm = null, lvItemProduto = null;
						lviItemNcm = (System.Windows.Forms.ListViewItem)arlNcm[0];
						frmFClassificacoesTarifariasCadEdit formClassTar = new frmFClassificacoesTarifariasCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref m_typDatSetTbProdutosNcm, mdlProdutosGeral.TipoClassificacaoTarifaria.Ncm,lviItemNcm.Text,lviItemNcm.SubItems[1].Text);
						formClassTar.ShowDialog();
						if (formClassTar.m_bModificado)
						{
							mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwTbProdutosNcm = null;
							dtrwTbProdutosNcm = retornaNcm(lviItemNcm.Text);
							if (dtrwTbProdutosNcm.RowState != System.Data.DataRowState.Deleted)
							{
							
								string strCodigo = "";
								string strDenominacao = "";
								//string strNodoTextoTemp = "";
								formClassTar.retornaDados(out strCodigo,out strDenominacao);
							
								// Ajustando todos os Produtos com esta Ncm Caso necessario
								if (dtrwTbProdutosNcm.strNcm != strCodigo)
								{
									// Ajustando os Objetos Produtos
									mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = null;
									for(int nCont = 0 ; nCont < m_typDatSetTbProdutos.tbProdutos.Rows.Count; nCont++)
									{
										dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_typDatSetTbProdutos.tbProdutos.Rows[nCont];
										if (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted)
										{
											if (!dtrwTbProdutos.IsstrNcmNull())
											{
												if (dtrwTbProdutos.strNcm == dtrwTbProdutosNcm.strNcm)
												{
													dtrwTbProdutos.strNcm = strCodigo;
													// Procurando o item correspondente na TreeView
													for(int nCont2 = 0 ; nCont2 < lvProdutos.Items.Count; nCont2++)
													{
														lvItemProduto = lvProdutos.Items[nCont2];
														if ((int)lvItemProduto.Tag == dtrwTbProdutos.idProduto)
														{
															lvItemProduto.SubItems[2].Text = strCodigo;
														}
													}
												}
											}
										}
									}
								}
								// Ajustando o Objeto Ncm
								dtrwTbProdutosNcm.strNcm = strCodigo;
								dtrwTbProdutosNcm.mstrDenominacao = strDenominacao;
							
								// Ajustando a Interface Ncm
								lviItemNcm.Text = strCodigo;
								lviItemNcm.SubItems[1].Text = strDenominacao;
							}
						}
						formClassTar = null;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region EditarNcm
			private void EditarNcm(string Codigo, string Denominacao)
			{
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwTbProdutosNcm = retornaNcm(Codigo);
					if (dtrwTbProdutosNcm.RowState != System.Data.DataRowState.Deleted)
						dtrwTbProdutosNcm.mstrDenominacao = Denominacao;
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region ExcluirNcm
			private void ExcluirNcm(System.Collections.ArrayList arlNcm, ref mdlComponentesGraficos.ListView lvProdutos)
			{
				try
				{
					//string strNodoTextTemp = "";
					System.Windows.Forms.ListViewItem lviItemNcm, lvItemProduto;
					//System.Windows.Forms.TreeNode NodoProduto = null;
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwTbProdutosNcm;
					
					// Apagando a Lista de Ncm's
					for (int nCont = 0; nCont < arlNcm.Count ;nCont++)
					{
						lviItemNcm = (System.Windows.Forms.ListViewItem)arlNcm[nCont];
						dtrwTbProdutosNcm = retornaNcm(lviItemNcm.Text);
						dtrwTbProdutosNcm.Delete();
						
						// Apagando as Ncms dos Produtos
						for (int nCont2 = 0 ;nCont2 < m_typDatSetTbProdutos.tbProdutos.Rows.Count; nCont2++)
						{
							dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_typDatSetTbProdutos.tbProdutos.Rows[nCont2];
							if (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted)
							{
								if ((!dtrwTbProdutos.IsstrNcmNull()) && (dtrwTbProdutos.strNcm == lviItemNcm.Text))
								{
									for (int nCont3 = 0; nCont3 < lvProdutos.Items.Count ; nCont3++)
									{
										// Apagando a Naladi deste Produto
										lvItemProduto = lvProdutos.Items[nCont3];
										if ((int)lvItemProduto.Tag == dtrwTbProdutos.idProduto)
										{
											lvItemProduto.SubItems[2].Text = "";
										}
									} // Testando solução
									dtrwTbProdutos.strNcm = "";
								}
							}
						}
						//Removendo a Ncm da ListView
						lviItemNcm.Remove();
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
		#endregion
		#region Naladi
			#region retornaNaladi
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow retornaNaladi(string nIdNaladi)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwTbProdutosNaladi = null;
				try
				{
					dtrwTbProdutosNaladi = m_typDatSetTbProdutosNaladi.tbProdutosNaladi.FindBynIdExportadorstrNaladi(m_nIdExportador,nIdNaladi);
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				return(dtrwTbProdutosNaladi);
			}
			#endregion
			#region NovaNaladi
			private void NovaNaladi(ref mdlComponentesGraficos.ListView lvNaladi)
			{
				try
				{
					frmFClassificacoesTarifariasCadEdit formClassTar = new frmFClassificacoesTarifariasCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref m_typDatSetTbProdutosNaladi, mdlProdutosGeral.TipoClassificacaoTarifaria.Naladi);
					formClassTar.ShowDialog();
					if (formClassTar.m_bModificado)
					{
						string strCodigo = "";
						string strDenominacao = "";
						formClassTar.retornaDados(out strCodigo,out strDenominacao);
						// Adicionando na lista de Naladi's
						System.Windows.Forms.ListViewItem lviNaladi;
						// Adicionando a List View de Naladi's
						lviNaladi = lvNaladi.Items.Add(strCodigo);
						lviNaladi.SubItems.Add(strDenominacao);			
						lviNaladi.Selected = true;
						NovaNaladi(strCodigo, strDenominacao);
					}
					formClassTar = null;
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region NovaNaladi
			private void NovaNaladi(string Codigo, string Denominacao)
			{
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwTbProdutosNaladi = m_typDatSetTbProdutosNaladi.tbProdutosNaladi.NewtbProdutosNaladiRow();
					dtrwTbProdutosNaladi.nIdExportador = m_nIdExportador;
					dtrwTbProdutosNaladi.strNaladi = Codigo;
					dtrwTbProdutosNaladi.mstrDenominacao = Denominacao;
					m_typDatSetTbProdutosNaladi.tbProdutosNaladi.AddtbProdutosNaladiRow(dtrwTbProdutosNaladi);
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region EditarNaladi
			private void EditarNaladi(System.Collections.ArrayList arlNaladi, ref mdlComponentesGraficos.ListView lvProdutos)
			{
				try
				{
					if (arlNaladi.Count > 0)
					{
						//string strNodoTextTemp = "";
						System.Windows.Forms.ListViewItem lviItemNaladi, lvItemProduto = null;
						lviItemNaladi = (System.Windows.Forms.ListViewItem)arlNaladi[0];
						frmFClassificacoesTarifariasCadEdit formClassTar = new frmFClassificacoesTarifariasCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref m_typDatSetTbProdutosNaladi, mdlProdutosGeral.TipoClassificacaoTarifaria.Naladi,lviItemNaladi.Text,lviItemNaladi.SubItems[1].Text);
						formClassTar.ShowDialog();
						if (formClassTar.m_bModificado)
						{
							mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwTbProdutosNaladi;
							dtrwTbProdutosNaladi = retornaNaladi(lviItemNaladi.Text);   
             
							if (dtrwTbProdutosNaladi.RowState != System.Data.DataRowState.Deleted)
							{
								string strCodigo = "";
								string strDenominacao = "";
								formClassTar.retornaDados(out strCodigo,out strDenominacao);
							
								// Ajustando todos os Produtos com esta Naladi Caso necessario
								if (dtrwTbProdutosNaladi.strNaladi != strCodigo)
								{
									// Ajustando os Objetos Produtos
									mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = null;
									for(int nCont = 0 ; nCont < m_typDatSetTbProdutos.tbProdutos.Rows.Count; nCont++)
									{
										dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_typDatSetTbProdutos.tbProdutos.Rows[nCont];
										if (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted)
										{
											if (!dtrwTbProdutos.IsstrNaladiNull())
											{
												if (dtrwTbProdutos.strNaladi == dtrwTbProdutosNaladi.strNaladi)
												{
													dtrwTbProdutos.strNaladi = strCodigo;
													// Procurando o item correspondente na ListView
													for(int nCont2 = 0 ; nCont2 < lvProdutos.Items.Count; nCont2++)
													{
														lvItemProduto = lvProdutos.Items[nCont2];
														if ((int)lvItemProduto.Tag == dtrwTbProdutos.idProduto)
														{
															lvItemProduto.SubItems[3].Text = strCodigo;
														}
													}
												}
											}
										}
									}
								}
								// Ajustando o Objeto Naladi
								dtrwTbProdutosNaladi.strNaladi = strCodigo;
								dtrwTbProdutosNaladi.mstrDenominacao = strDenominacao;
							
								// Ajustando a Interface Ncm
								lviItemNaladi.Text = strCodigo;
								lviItemNaladi.SubItems[1].Text = strDenominacao;
							}
						}
						formClassTar = null;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region EditarNaladi
			private void EditarNaladi(string Codigo, string Denominacao)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwTbProdutosNaladi = null;
				try
				{
					dtrwTbProdutosNaladi = retornaNaladi(Codigo);
					if (dtrwTbProdutosNaladi.RowState != System.Data.DataRowState.Deleted)
						dtrwTbProdutosNaladi.mstrDenominacao = Denominacao;
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region ExcluirNaladi
			/// <summary>
			/// Excluindo as Naladis 
			/// </summary>
			/// <param name="arlNaladi"></param>
			/// <param name="lvProdutos"></param>
			private void ExcluirNaladi(System.Collections.ArrayList arlNaladi, ref mdlComponentesGraficos.ListView lvProdutos)
			{
				try
				{
					//string strNodoTextTemp = "";
					System.Windows.Forms.ListViewItem lviItemNaladi, lvItemProduto;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwTbProdutosNaladi = null;
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = null;
					
					// Apagando a Lista de Ncm's
					for (int nCont = 0; nCont < arlNaladi.Count ;nCont++)
					{
						lviItemNaladi = (System.Windows.Forms.ListViewItem)arlNaladi[nCont];
						dtrwTbProdutosNaladi = retornaNaladi(lviItemNaladi.Text);                
						dtrwTbProdutosNaladi.Delete();
						
						// Apagando as Naladi dos Produtos
						for (int nCont2 = 0 ;nCont2 < m_typDatSetTbProdutosNaladi.tbProdutosNaladi.Rows.Count; nCont2++)
						{
							dtrwTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_typDatSetTbProdutos.tbProdutos.Rows[nCont2];
							if (dtrwTbProdutos.RowState != System.Data.DataRowState.Deleted)
							{
								if ((!dtrwTbProdutos.IsstrNaladiNull()) && (dtrwTbProdutos.strNaladi == lviItemNaladi.Text))
								{
									for (int nCont3 = 0; nCont3 < lvProdutos.Items.Count ; nCont3++)
									{
										// Apagando a Naladi deste Produto
										lvItemProduto = lvProdutos.Items[nCont3];
										if ((int)lvItemProduto.Tag == dtrwTbProdutos.idProduto)
										{
											lvItemProduto.SubItems[3].Text = "";
										}
									} // Testando solução
									dtrwTbProdutos.strNaladi = "";
								}
							}
						}
						//Removendo a Naladi da ListView
						lviItemNaladi.Remove();
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
		#endregion

		#region Retorna TypDatSets
		public void retornaTypDatSets(out mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos, out mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm, out mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi)
		{
			typDatSetTbProdutos = m_typDatSetTbProdutos;
			typDatSetTbProdutosNcm = m_typDatSetTbProdutosNcm;
			typDatSetTbProdutosNaladi = m_typDatSetTbProdutosNaladi;
		}
		#endregion
	}
}

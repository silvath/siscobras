using System;

namespace mdlContainers
{
	/// <summary>
	/// Summary description for clsContainers.
	/// </summary>
	public class clsContainers
	{
		#region Static
			#region Unidade
				internal static string strRetornaUnidade(mdlConstantes.UnidadeMassa enumUnidadeMassa)
				{
					string strRetorno = "";
					switch(enumUnidadeMassa)
					{
						case mdlConstantes.UnidadeMassa.Kilograma:
							strRetorno = "kg";
							break;
						case mdlConstantes.UnidadeMassa.Tonelada:
							strRetorno = "Ton";
							break;
					}
					return(strRetorno);
				}

				internal static mdlConstantes.UnidadeMassa enumRetornaProximaUnidadeMassa(mdlConstantes.UnidadeMassa enumUnidadeMassa)
				{
					switch(enumUnidadeMassa)
					{
						case mdlConstantes.UnidadeMassa.Kilograma:
							enumUnidadeMassa = mdlConstantes.UnidadeMassa.Tonelada;
							break;
						case mdlConstantes.UnidadeMassa.Tonelada:
							enumUnidadeMassa = mdlConstantes.UnidadeMassa.Kilograma;
							break;
					}
					return(enumUnidadeMassa);
				}

				internal static string strRetornaUnidade(mdlConstantes.UnidadeMedida enumUnidadeMedida)
				{
					string strRetorno = "";
					switch(enumUnidadeMedida)
					{
						case mdlConstantes.UnidadeMedida.Centimetro:
							strRetorno = "cm";
							break;
						case mdlConstantes.UnidadeMedida.Metro:
							strRetorno = "m";
							break;
					}
					return(strRetorno);
				}

				internal static mdlConstantes.UnidadeMedida enumRetornaProximaUnidadeMedida(mdlConstantes.UnidadeMedida enumUnidadeMedida)
				{
					switch(enumUnidadeMedida)
					{
						case mdlConstantes.UnidadeMedida.Centimetro:
							enumUnidadeMedida = mdlConstantes.UnidadeMedida.Metro;
							break;
						case mdlConstantes.UnidadeMedida.Metro:
							enumUnidadeMedida = mdlConstantes.UnidadeMedida.Centimetro;
							break;
					}
					return(enumUnidadeMedida);
				}

			#endregion
		#endregion
		#region Constants
			public const int CONTAINER_ID_OUTRO = 0;
			public const int CONTAINER_ID_DRY = 1;
			public const int CONTAINER_ID_REEFER = 2;
			public const int CONTAINER_ID_HIGHCUBE = 3;
			public const int CONTAINER_ID_FLATRACK = 4;
			public const int CONTAINER_ID_TANK = 5;
			public const int CONTAINER_ID_FLATBED = 6;
			public const int CONTAINER_ID_OPENTOP = 7;
			public const int CONTAINER_ID_OPENSIDE = 8;
			public const int CONTAINER_ID_HALFHEIGHTOPENTOP = 9;
			public const int CONTAINER_ID_VENTED = 10;
			public const int CONTAINER_ID_AUTORACK = 11;
			public const string CONTAINER_TEXT_OUTRO = "Outro";
			public const string CONTAINER_TEXT_DRY = "Dry";
			public const string CONTAINER_TEXT_REEFER = "Reefer";
			public const string CONTAINER_TEXT_HIGHCUBE = "High Cube";
			public const string CONTAINER_TEXT_FLATRACK = "Flat Rack";
			public const string CONTAINER_TEXT_TANK = "Tank";
			public const string CONTAINER_TEXT_FLATBED = "Flat Bed";
			public const string CONTAINER_TEXT_OPENTOP = "Open Top";
			public const string CONTAINER_TEXT_OPENSIDE = "Open Side";
			public const string CONTAINER_TEXT_HALFHEIGHTOPENTOP = "Half Height Open Top";
			public const string CONTAINER_TEXT_VENTED = "Vented";
			public const string CONTAINER_TEXT_AUTORACK = "AutoRack";
		#endregion
		#region Atributes
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel; 

			private int m_nIdExportador;
			private string m_strIdPe;

			private bool m_bChanged = false;
			public bool m_bModificado = false;

			// Typded Data Sets
			mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetPes;
			mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers m_typDatSetProcessosContainers;

			// Formularios
			mdlContainers.Formularios.frmFContainers m_formFContainers = null;
		#endregion
		#region Constructors and Destructors
		public clsContainers(ref mdlTratamentoErro.clsTratamentoErro tratadorErro , ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB , string strEnderecoExecutavel,int idExportador, string idPe)
		{
			m_cls_ter_tratadorErro = tratadorErro; 
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel; 

			m_strIdPe = idPe;
			m_nIdExportador = idExportador;

			vCarregaDados();
		}
		#endregion

		#region Carregamento dos Dados
			private void vCarregaDados()
			{
				vCarregaDadosProcessoExportacao();
				vCarregaDadosContainers();
			}

			private void vCarregaDadosProcessoExportacao()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPe);

				m_typDatSetPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}

			private void vCarregaDadosContainers()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strIdPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPe);

				m_typDatSetProcessosContainers = m_cls_dba_ConnectionDB.GetTbProcessosContainers(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
		#endregion
		#region Salvamento dos Dados
			private bool bSalvaDados()
			{
				bool bRetorno = false;
				if (bSalvaDadosProcessoExportacao())
					m_bModificado = bRetorno = bSalvaDadosContainers();
				return(bRetorno);
			}

			private bool bSalvaDadosProcessoExportacao()
			{
				m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetPes);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool bSalvaDadosContainers()
			{
				m_cls_dba_ConnectionDB.SetTbProcessosContainers(m_typDatSetProcessosContainers);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				m_formFContainers = new mdlContainers.Formularios.frmFContainers(m_strEnderecoExecutavel);
				vInitializeEvents(ref m_formFContainers);
				m_formFContainers.ShowDialog();
				return(m_bModificado);
			}

			private void vInitializeEvents(ref mdlContainers.Formularios.frmFContainers formFContainers)
			{
				// Carrega Dados Containers Informacao
				formFContainers.eCallCarregaDadosContainersInformacao += new mdlContainers.Formularios.frmFContainers.delCallCarregaDadosContainersInformacao(vCarregaDadosInformacoesContainers);

				// Salva Dados Containers Informacoes
				formFContainers.eCallSalvaDadosContainersInformacao += new mdlContainers.Formularios.frmFContainers.delCallSalvaDadosContainersInformacao(vSalvaDadosInformacoesContainers);

				// Containers Refresh
				formFContainers.eCallContainersRefresh += new mdlContainers.Formularios.frmFContainers.delCallContainersRefresh(vRefreshContainers);

				// Container Novo
				formFContainers.eCallContainersNovo += new mdlContainers.Formularios.frmFContainers.delCallContainersNovo(ShowContainerNovo);

				// Container Edicao
				formFContainers.eCallContainersEdicao += new mdlContainers.Formularios.frmFContainers.delCallContainersEdicao(ShowContainerEdicao);

				// Container Exclui
				formFContainers.eCallContainersExclui += new mdlContainers.Formularios.frmFContainers.delCallContainersExclui(bContainerExclui);

				// Salva Dados 
				formFContainers.eCallSalvaDados += new mdlContainers.Formularios.frmFContainers.delCallSalvaDados(bSalvaDados);
			}
		#endregion
		#region ShowContainerNovo
			private bool ShowContainerNovo()
			{
				mdlContainers.Formularios.frmFContainersEditar formFContainerNovo = new mdlContainers.Formularios.frmFContainersEditar(m_strEnderecoExecutavel);
				vInitializeEvents(ref formFContainerNovo);
				formFContainerNovo.ShowDialog();
				return(formFContainerNovo.m_bModificado);
			}
			
			private void vInitializeEvents(ref mdlContainers.Formularios.frmFContainersEditar formFContainerNovo)
			{
				// Containers Tipo
				formFContainerNovo.eCallContainersTipo += new mdlContainers.Formularios.frmFContainersEditar.delCallContainersTipo(ShowContainerTipo);

				// Containters Text
				formFContainerNovo.eCallContainersText += new mdlContainers.Formularios.frmFContainersEditar.delCallContainersText(bContainersText);

				// Refresh Containers Tamanho
				formFContainerNovo.eCallRefreshContainersTamanho += new mdlContainers.Formularios.frmFContainersEditar.delCallRefreshContainersTamanho(vRefreshContainersTamanho);

				// Carrega Dados
				formFContainerNovo.eCallCarregaDados += new mdlContainers.Formularios.frmFContainersEditar.delCallCarregaDados(vCarregaDados);

				// Salva Dados
				formFContainerNovo.eCallSalvaDados += new mdlContainers.Formularios.frmFContainersEditar.delCallSalvaDados(bSalvaDados);
			}
		#endregion
		#region ShowContainerEdicao
			private bool ShowContainerEdicao(int nIdContainer)
			{
				mdlContainers.Formularios.frmFContainersEditar formFContainerEdicao = new mdlContainers.Formularios.frmFContainersEditar(m_strEnderecoExecutavel,nIdContainer);
				vInitializeEvents(ref formFContainerEdicao);
				formFContainerEdicao.ShowDialog();
				return(formFContainerEdicao.m_bModificado);
			}
		#endregion
		#region ShowContainerTipo
			private bool ShowContainerTipo(ref int nIdContainerTipo)
			{
				mdlContainers.Formularios.frmFContainersTipo formFContainerTipo = new mdlContainers.Formularios.frmFContainersTipo(m_strEnderecoExecutavel,nIdContainerTipo);
				vInitializeEvents(ref formFContainerTipo);
				formFContainerTipo.ShowDialog();
				if (formFContainerTipo.m_bModificado)
				{
					formFContainerTipo.vRetornaValores(out nIdContainerTipo);
				}
				return(formFContainerTipo.m_bModificado);
			}

			private void vInitializeEvents(ref mdlContainers.Formularios.frmFContainersTipo formFContainerTipo)
			{
				// Refresh Containers Tipo
				formFContainerTipo.eCallContainersTipoRefresh += new mdlContainers.Formularios.frmFContainersTipo.delCallContainersTipoRefresh(vRefreshContainersTipo);

				// Containers Informacao
				formFContainerTipo.eCallContainersInformacao += new mdlContainers.Formularios.frmFContainersTipo.delCallContainersInformacao(bContainerInformacao);
			}
		#endregion

		#region Tipo de Container
			private void vRefreshContainersTipo(ref System.Windows.Forms.ListView lvContainersTipo)
			{
				lvContainersTipo.Items.Clear();
				lvContainersTipo.Items.Add(CONTAINER_TEXT_DRY).Tag = CONTAINER_ID_DRY;
				lvContainersTipo.Items.Add(CONTAINER_TEXT_REEFER).Tag = CONTAINER_ID_REEFER;
				lvContainersTipo.Items.Add(CONTAINER_TEXT_HIGHCUBE).Tag = CONTAINER_ID_HIGHCUBE;
				lvContainersTipo.Items.Add(CONTAINER_TEXT_FLATRACK).Tag = CONTAINER_ID_FLATRACK;
				lvContainersTipo.Items.Add(CONTAINER_TEXT_TANK).Tag = CONTAINER_ID_TANK;
				lvContainersTipo.Items.Add(CONTAINER_TEXT_FLATBED).Tag = CONTAINER_ID_FLATBED;
				lvContainersTipo.Items.Add(CONTAINER_TEXT_OPENTOP).Tag = CONTAINER_ID_OPENTOP;
				lvContainersTipo.Items.Add(CONTAINER_TEXT_OPENSIDE).Tag = CONTAINER_ID_OPENSIDE;
				lvContainersTipo.Items.Add(CONTAINER_TEXT_HALFHEIGHTOPENTOP).Tag = CONTAINER_ID_HALFHEIGHTOPENTOP;
				lvContainersTipo.Items.Add(CONTAINER_TEXT_VENTED).Tag = CONTAINER_ID_VENTED;
				lvContainersTipo.Items.Add(CONTAINER_TEXT_AUTORACK).Tag = CONTAINER_ID_AUTORACK;
				lvContainersTipo.Items.Add(CONTAINER_TEXT_OUTRO).Tag = CONTAINER_ID_OUTRO;
			}

			private bool bContainerInformacao(int nIdContainerTipo,out string strInformacao)
			{
				bool bRetorno = true;
				strInformacao = "";
				switch(nIdContainerTipo)
				{
					case CONTAINER_ID_OUTRO:
						strInformacao = "Utilize esta opção caso o Conteiner desejado não se encontre na lista.";
						break;
					case CONTAINER_ID_DRY:
						strInformacao = "Dry: ";
						strInformacao = strInformacao + System.Environment.NewLine + " Utilizado na maioria dos casos.";
						strInformacao = strInformacao + System.Environment.NewLine;
						strInformacao = strInformacao + System.Environment.NewLine + "20 Pés";
						strInformacao = strInformacao + System.Environment.NewLine + "Carregamento Máximo: 27 ton";
						strInformacao = strInformacao + System.Environment.NewLine + "Comprimento: 5,90m";
						strInformacao = strInformacao + System.Environment.NewLine + "Largura: 2,34m";
						strInformacao = strInformacao + System.Environment.NewLine + "Algura: 2,39m";
						strInformacao = strInformacao + System.Environment.NewLine + "Cúbicos: 33m³";
						strInformacao = strInformacao + System.Environment.NewLine;
						strInformacao = strInformacao + System.Environment.NewLine + "40 Pés";
						strInformacao = strInformacao + System.Environment.NewLine + "Carregamento Máximo: 27 ton";
						strInformacao = strInformacao + System.Environment.NewLine + "Comprimento: 12,03m";
						strInformacao = strInformacao + System.Environment.NewLine + "Largura: 2,34m";
						strInformacao = strInformacao + System.Environment.NewLine + "Algura: 2,39m";
						strInformacao = strInformacao + System.Environment.NewLine + "Cúbicos: 67m³";
						break;
					case CONTAINER_ID_REEFER:
						strInformacao = "Reefer: ";
						strInformacao = strInformacao + System.Environment.NewLine + " Utilizado em casos em que a carga necessita refrigeração.";
						strInformacao = strInformacao + System.Environment.NewLine;
						strInformacao = strInformacao + System.Environment.NewLine + "20 Pés";
						strInformacao = strInformacao + System.Environment.NewLine + "Carregamento Máximo: 20 ton";
						strInformacao = strInformacao + System.Environment.NewLine + "Comprimento: 5,02m";
						strInformacao = strInformacao + System.Environment.NewLine + "Largura: 2,16m";
						strInformacao = strInformacao + System.Environment.NewLine + "Algura: 2,13m";
						strInformacao = strInformacao + System.Environment.NewLine + "Cúbicos: 24m³";
						break;
					case CONTAINER_ID_HIGHCUBE:
						strInformacao = "High Cube: ";
						strInformacao = strInformacao + System.Environment.NewLine + " Utilizado em cargas altas.";
						strInformacao = strInformacao + System.Environment.NewLine;
						strInformacao = strInformacao + System.Environment.NewLine + "40 Pés";
						strInformacao = strInformacao + System.Environment.NewLine + "Carregamento Máximo: 27 ton";
						strInformacao = strInformacao + System.Environment.NewLine + "Comprimento: 12,03m";
						strInformacao = strInformacao + System.Environment.NewLine + "Largura: 2,34m";
						strInformacao = strInformacao + System.Environment.NewLine + "Algura: 2,69m";
						strInformacao = strInformacao + System.Environment.NewLine + "Cúbicos: 76,3m³";
						break;
					case CONTAINER_ID_FLATRACK:
						strInformacao = "Flat Rack: ";
						strInformacao = strInformacao + System.Environment.NewLine + " ";
						strInformacao = strInformacao + System.Environment.NewLine;
						strInformacao = strInformacao + System.Environment.NewLine + "40 Pés";
						strInformacao = strInformacao + System.Environment.NewLine + "Carregamento Máximo: 40 ton";
						strInformacao = strInformacao + System.Environment.NewLine + "Comprimento: 12,03m";
						strInformacao = strInformacao + System.Environment.NewLine + "Largura: 2,34m";
						strInformacao = strInformacao + System.Environment.NewLine + "Algura: 2,69m";
						break;
					case CONTAINER_ID_TANK:
						strInformacao = "Tank: ";
						strInformacao = strInformacao + System.Environment.NewLine + " Utilizado para o transporte de líquidos.";
						strInformacao = strInformacao + System.Environment.NewLine;
						strInformacao = strInformacao + System.Environment.NewLine + "20 Pés";
						strInformacao = strInformacao + System.Environment.NewLine + "Carregamento Máximo: 19 ton";
						strInformacao = strInformacao + System.Environment.NewLine + "Comprimento: 5,90m";
						strInformacao = strInformacao + System.Environment.NewLine + "Largura: 2,34m";
						strInformacao = strInformacao + System.Environment.NewLine + "Algura: 2,69m";
						strInformacao = strInformacao + System.Environment.NewLine + "Cúbicos: 33m³";
						break;
					case CONTAINER_ID_FLATBED:
						strInformacao = "Flat Bed: ";
						strInformacao = strInformacao + System.Environment.NewLine + " ";
						strInformacao = strInformacao + System.Environment.NewLine;
						strInformacao = strInformacao + System.Environment.NewLine + "40 Pés";
						strInformacao = strInformacao + System.Environment.NewLine + "Carregamento Máximo: 40 ton";
						strInformacao = strInformacao + System.Environment.NewLine + "Comprimento: 12,03m";
						strInformacao = strInformacao + System.Environment.NewLine + "Largura: 2,34m";
						break;
					case CONTAINER_ID_OPENTOP:
						strInformacao = "Open Top: ";
						strInformacao = strInformacao + System.Environment.NewLine + " ";
						strInformacao = strInformacao + System.Environment.NewLine;
						strInformacao = strInformacao + System.Environment.NewLine + "40 Pés";
						strInformacao = strInformacao + System.Environment.NewLine + "Carregamento Máximo: 27 ton";
						strInformacao = strInformacao + System.Environment.NewLine + "Comprimento: 12,03m";
						strInformacao = strInformacao + System.Environment.NewLine + "Largura: 2,34m";
						strInformacao = strInformacao + System.Environment.NewLine + "Algura: 2,39m";
						strInformacao = strInformacao + System.Environment.NewLine + "Cúbicos: 67m³";
						break;
					case CONTAINER_ID_OPENSIDE:
						strInformacao = "Open Side: ";
						strInformacao = strInformacao + System.Environment.NewLine + " ";
						strInformacao = strInformacao + System.Environment.NewLine;
						strInformacao = strInformacao + System.Environment.NewLine + "20 Pés";
						strInformacao = strInformacao + System.Environment.NewLine + "Carregamento Máximo: 27 ton";
						strInformacao = strInformacao + System.Environment.NewLine + "Comprimento: 5,90m";
						strInformacao = strInformacao + System.Environment.NewLine + "Largura: 2,34m";
						strInformacao = strInformacao + System.Environment.NewLine + "Algura: 2,39m";
						strInformacao = strInformacao + System.Environment.NewLine + "Cúbicos: 33m³";
						break;
					case CONTAINER_ID_HALFHEIGHTOPENTOP:
						strInformacao = "Half Height Open Top: ";
						strInformacao = strInformacao + System.Environment.NewLine + " ";
						strInformacao = strInformacao + System.Environment.NewLine;
						strInformacao = strInformacao + System.Environment.NewLine + "20 Pés";
						strInformacao = strInformacao + System.Environment.NewLine + "Carregamento Máximo: 27 ton";
						strInformacao = strInformacao + System.Environment.NewLine + "Comprimento: 5,90m";
						strInformacao = strInformacao + System.Environment.NewLine + "Largura: 2,34m";
						strInformacao = strInformacao + System.Environment.NewLine + "Algura: 1,07m";
						strInformacao = strInformacao + System.Environment.NewLine + "Cúbicos: 14,8m³";
						break;
					case CONTAINER_ID_VENTED:
						strInformacao = "Vented: ";
						strInformacao = strInformacao + System.Environment.NewLine + " Usado para cargas que necessitam de ventilação.";
						strInformacao = strInformacao + System.Environment.NewLine;
						strInformacao = strInformacao + System.Environment.NewLine + "20 Pés";
						strInformacao = strInformacao + System.Environment.NewLine + "Carregamento Máximo: 27 ton";
						strInformacao = strInformacao + System.Environment.NewLine + "Comprimento: 5,90m";
						strInformacao = strInformacao + System.Environment.NewLine + "Largura: 2,34m";
						strInformacao = strInformacao + System.Environment.NewLine + "Algura: 2,39m";
						strInformacao = strInformacao + System.Environment.NewLine + "Cúbicos: 33m³";
						break;
					case CONTAINER_ID_AUTORACK:
						strInformacao = "Auto Rack: ";
						strInformacao = strInformacao + System.Environment.NewLine + " ";
						strInformacao = strInformacao + System.Environment.NewLine;
						strInformacao = strInformacao + System.Environment.NewLine + "40 Pés";
						strInformacao = strInformacao + System.Environment.NewLine + "Carregamento Máximo: 27 ton";
						strInformacao = strInformacao + System.Environment.NewLine + "Comprimento: 12,03m";
						strInformacao = strInformacao + System.Environment.NewLine + "Largura: 2,34m";
						strInformacao = strInformacao + System.Environment.NewLine + "Algura: 2,39m";
						break;
					default:
						bRetorno = false;
						break;
				}
				return(bRetorno);
			}

			private bool bContainersText(int nIdContainerTipo,out string strContainerText)
			{
				bool bRetorno = true;
				strContainerText = "";
				switch(nIdContainerTipo)
				{
					case CONTAINER_ID_OUTRO:
						strContainerText = "Outro";
						break;
					case CONTAINER_ID_DRY:
						strContainerText = "Dry";
						break;
					case CONTAINER_ID_REEFER:
						strContainerText = "Reefer";
						break;
					case CONTAINER_ID_HIGHCUBE:
						strContainerText = "High Cube";
						break;
					case CONTAINER_ID_FLATRACK:
						strContainerText = "Flat Rack";
						break;
					case CONTAINER_ID_TANK:
						strContainerText = "Tank";
						break;
					case CONTAINER_ID_FLATBED:
						strContainerText = "Flat Bed";
						break;
					case CONTAINER_ID_OPENTOP:
						strContainerText = "Open Top";
						break;
					case CONTAINER_ID_OPENSIDE:
						strContainerText = "Open Side";
						break;
					case CONTAINER_ID_HALFHEIGHTOPENTOP:
						strContainerText = "Half Height Open Top";
						break;
					case CONTAINER_ID_VENTED:
						strContainerText = "Vented";
						break;
					case CONTAINER_ID_AUTORACK:
						strContainerText = "Auto Rack";
						break;
					default:
						bRetorno = false;
						break;
				}
				return(bRetorno);
			}

			private void vRefreshContainersTamanho(int nIdContainerTipo,ref mdlComponentesGraficos.ComboBox cbContainersTamanho)
			{
				cbContainersTamanho.Items.Clear();
				switch(nIdContainerTipo)
				{
					case CONTAINER_ID_DRY:
						cbContainersTamanho.Items.Add("10'");
						cbContainersTamanho.Items.Add("20'");
						cbContainersTamanho.Items.Add("30'");
						cbContainersTamanho.Items.Add("40'");
						break;
					case CONTAINER_ID_REEFER:
						cbContainersTamanho.Items.Add("10'");
						cbContainersTamanho.Items.Add("20'");
						cbContainersTamanho.Items.Add("30'");
						cbContainersTamanho.Items.Add("40'");
						break;
					case CONTAINER_ID_HIGHCUBE:
						cbContainersTamanho.Items.Add("10'");
						cbContainersTamanho.Items.Add("20'");
						cbContainersTamanho.Items.Add("30'");
						cbContainersTamanho.Items.Add("40'");
						break;
					case CONTAINER_ID_FLATRACK:
						cbContainersTamanho.Items.Add("10'");
						cbContainersTamanho.Items.Add("20'");
						cbContainersTamanho.Items.Add("30'");
						cbContainersTamanho.Items.Add("40'");
						break;
					case CONTAINER_ID_TANK:
						cbContainersTamanho.Items.Add("10'");
						cbContainersTamanho.Items.Add("20'");
						cbContainersTamanho.Items.Add("30'");
						cbContainersTamanho.Items.Add("40'");
						break;
					case CONTAINER_ID_FLATBED:
						cbContainersTamanho.Items.Add("10'");
						cbContainersTamanho.Items.Add("20'");
						cbContainersTamanho.Items.Add("30'");
						cbContainersTamanho.Items.Add("40'");
						break;
					case CONTAINER_ID_OPENTOP:
						cbContainersTamanho.Items.Add("10'");
						cbContainersTamanho.Items.Add("20'");
						cbContainersTamanho.Items.Add("30'");
						cbContainersTamanho.Items.Add("40'");
						break;
					case CONTAINER_ID_OPENSIDE:
						cbContainersTamanho.Items.Add("10'");
						cbContainersTamanho.Items.Add("20'");
						cbContainersTamanho.Items.Add("30'");
						cbContainersTamanho.Items.Add("40'");
						break;
					case CONTAINER_ID_HALFHEIGHTOPENTOP:
						cbContainersTamanho.Items.Add("10'");
						cbContainersTamanho.Items.Add("20'");
						cbContainersTamanho.Items.Add("30'");
						cbContainersTamanho.Items.Add("40'");
						break;
					case CONTAINER_ID_VENTED:
						cbContainersTamanho.Items.Add("10'");
						cbContainersTamanho.Items.Add("20'");
						cbContainersTamanho.Items.Add("30'");
						cbContainersTamanho.Items.Add("40'");
						break;
					case CONTAINER_ID_AUTORACK:
						cbContainersTamanho.Items.Add("10'");
						cbContainersTamanho.Items.Add("20'");
						cbContainersTamanho.Items.Add("30'");
						cbContainersTamanho.Items.Add("40'");
						break;
				}
			}
		#endregion
		#region Informacoes Containers
			private void vGeraInformacoesContainers(out string strContainersNumero,out string strContainersTipo,out string strContainersISO,out string strContainersTamanho,out string strContainersTara,out string strContainersLacre,out string strContainersLacreArmador,out string strContainerExcessoCargaAltura,out string strContainerExcessoCargaLargura,out string strContainerExcessoCargaComprimento,out string strContainerTemperaturaMinima,out string strContainerTemperaturaMaxima,out string strContainerIMO,out string strContainerUNO)
			{
				strContainersNumero = strContainersTipo = strContainersISO = strContainersTamanho = strContainersTara = strContainersLacre = strContainersLacreArmador = strContainerExcessoCargaAltura = strContainerExcessoCargaLargura = strContainerExcessoCargaComprimento = strContainerTemperaturaMinima = strContainerTemperaturaMaxima = strContainerIMO = strContainerUNO = "";
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer in m_typDatSetProcessosContainers.tbProcessosContainers.Rows)
				{
					if (dtrwContainer.RowState != System.Data.DataRowState.Deleted)
					{
						// strNumero
						if (!dtrwContainer.IsstrNumeroNull())							 
						{
							if (strContainersNumero != "")
								strContainersNumero = strContainersNumero + " , ";
							strContainersNumero = strContainersNumero + dtrwContainer.strNumero;
						}else{
							strContainersNumero = strContainersNumero + " , ";
						}
						// strContainersTipo
						if (!dtrwContainer.IsstrContainerTipoNull())							 
						{
							if (strContainersTipo != "")
								strContainersTipo = strContainersTipo + " , ";
							strContainersTipo = strContainersTipo + dtrwContainer.strContainerTipo;
						}
						else
						{
							strContainersTipo = strContainersTipo + " , ";
						}
						// strContainersISO
						if (!dtrwContainer.IsstrISONull())							 
						{
							if (strContainersISO != "")
								strContainersISO = strContainersISO + " , ";
							strContainersISO = strContainersISO + dtrwContainer.strISO;
						}
						else
						{
							strContainersISO = strContainersISO + " , ";
						}
						// strContainersTamanho
						if (!dtrwContainer.IsstrTamanhoNull())							 
						{
							if (strContainersTamanho != "")
								strContainersTamanho = strContainersTamanho + " , ";
							strContainersTamanho = strContainersTamanho + dtrwContainer.strTamanho;
						}
						else
						{
							strContainersTamanho = strContainersTamanho + " , ";
						}
						// strContainersTara
						if (!dtrwContainer.IsdTaraNull())							 
						{
							if (strContainersTara != "")
								strContainersTara = strContainersTara + " , ";
							strContainersTara = strContainersTara + dtrwContainer.dTara + " " + strRetornaUnidade((mdlConstantes.UnidadeMassa)dtrwContainer.nUnidadeTara).ToString();
						}
						else
						{
							strContainersTara = strContainersTara + " , ";
						}

						// strContainersLacre
						if (!dtrwContainer.IsstrLacreNull())							 
						{
							if (strContainersLacre != "")
								strContainersLacre = strContainersLacre + " , ";
							strContainersLacre = strContainersLacre + dtrwContainer.strLacre;
						}
						else
						{
							strContainersLacre = strContainersLacre + " , ";
						}

						// strContainersLacreArmador
						if (!dtrwContainer.IsstrLacreArmadorNull())							 
						{
							if (strContainersLacreArmador != "")
								strContainersLacreArmador = strContainersLacreArmador + " , ";
							strContainersLacreArmador = strContainersLacreArmador + dtrwContainer.strLacreArmador;
						}
						else
						{
							strContainersLacreArmador = strContainersLacreArmador + " , ";
						}
					
						//strContainerExcessoCargaAltura
						if ((!dtrwContainer.IsdExcessoCargaAlturaNull()) && (dtrwContainer.dExcessoCargaAltura != 0))
							strContainerExcessoCargaAltura = strContainerExcessoCargaAltura + dtrwContainer.dExcessoCargaAltura.ToString() + " " + clsContainers.strRetornaUnidade((mdlConstantes.UnidadeMedida)dtrwContainer.nUnidadeExcessoCargaAltura) + " , ";
						else
							strContainerExcessoCargaAltura = strContainerExcessoCargaAltura + " , ";


						//strContainerExcessoCargaLargura
						if ((!dtrwContainer.IsdExcessoCargaLarguraNull()) && (dtrwContainer.dExcessoCargaLargura != 0))
							strContainerExcessoCargaLargura = strContainerExcessoCargaLargura + dtrwContainer.dExcessoCargaLargura.ToString() + " " + clsContainers.strRetornaUnidade((mdlConstantes.UnidadeMedida)dtrwContainer.nUnidadeExcessoCargaLargura) + " , ";
						else
							strContainerExcessoCargaLargura = strContainerExcessoCargaLargura + " , ";

						//strContainerExcessoCargaComprimento
						if ((!dtrwContainer.IsdExcessoCargaAlturaNull()) && (dtrwContainer.dExcessoCargaComprimento != 0))
							strContainerExcessoCargaComprimento = strContainerExcessoCargaComprimento + dtrwContainer.dExcessoCargaComprimento.ToString() + " " + clsContainers.strRetornaUnidade((mdlConstantes.UnidadeMedida)dtrwContainer.nUnidadeExcessoCargaComprimento) + " , ";
						else
							strContainerExcessoCargaComprimento = strContainerExcessoCargaComprimento + " , ";

						//strContainerTemperaturaMinima
						if (!dtrwContainer.IsstrTemperaturaMinimaNull())							 
						{
							if (strContainerTemperaturaMinima != "")
								strContainerTemperaturaMinima = strContainerTemperaturaMinima + " , ";
							strContainerTemperaturaMinima = strContainerTemperaturaMinima + dtrwContainer.strTemperaturaMinima;
						}
						else
						{
							strContainerTemperaturaMinima = strContainerTemperaturaMinima + " , ";
						}

						//strContainerTemperaturaMaxima
						if (!dtrwContainer.IsstrTemperaturaMaximaNull())							 
						{
							if (strContainerTemperaturaMaxima != "")
								strContainerTemperaturaMaxima = strContainerTemperaturaMaxima + " , ";
							strContainerTemperaturaMaxima = strContainerTemperaturaMaxima + dtrwContainer.strTemperaturaMaxima;
						}else{
							strContainerTemperaturaMaxima = strContainerTemperaturaMaxima + " , ";
						}

						//strContainerIMO
						if (!dtrwContainer.IsstrIMONull())							 
						{
							if (strContainerIMO != "")
								strContainerIMO = strContainerIMO + " , ";
							strContainerIMO = strContainerIMO + dtrwContainer.strIMO;
						}else{
							strContainerIMO = strContainerIMO + " , ";
						}

						//strContainerUNO
						if (!dtrwContainer.IsstrUNONull())							 
						{
							if (strContainerUNO != "")
								strContainerUNO = strContainerUNO + " , ";
							strContainerUNO = strContainerUNO + dtrwContainer.strUNO;
						}
						else
						{
							strContainerUNO = strContainerUNO + " , ";
						}
					}
				}
				if (strContainerExcessoCargaAltura.EndsWith(", "))
					strContainerExcessoCargaAltura = strContainerExcessoCargaAltura.Substring(0,strContainerExcessoCargaAltura.Length - 2);
				if (strContainerExcessoCargaLargura.EndsWith(", "))
					strContainerExcessoCargaLargura = strContainerExcessoCargaLargura.Substring(0,strContainerExcessoCargaLargura.Length - 2);
				if (strContainerExcessoCargaComprimento.EndsWith(", "))
					strContainerExcessoCargaComprimento = strContainerExcessoCargaComprimento.Substring(0,strContainerExcessoCargaComprimento.Length - 2);
			}
			
			private void vCarregaDadosInformacoesContainers(out string strContainersNumero,out string strContainersTipo,out string strContainersISO,out string strContainersTamanho,out string strContainersTara,out string strContainersLacre,out string strContainersLacreArmador,out string strContainerExcessoCargaAltura,out string strContainerExcessoCargaLargura,out string strContainerExcessoCargaComprimento,out string strContainerTemperaturaMinima,out string strContainerTemperaturaMaxima,out string strContainerIMO,out string strContainerUNO)
			{
				strContainersNumero = strContainersTipo = strContainersISO = strContainersTamanho = strContainersTara = strContainersLacre = strContainersLacreArmador = strContainerExcessoCargaAltura = strContainerExcessoCargaLargura = strContainerExcessoCargaComprimento = strContainerTemperaturaMinima = strContainerTemperaturaMaxima = strContainerIMO = strContainerUNO ="";

				if (!m_bChanged)
				{
					if (m_typDatSetPes.tbPEs.Rows.Count > 0 )
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
						// strContainersNumero
						if (!dtrwPe.IsmstrContainerNumeroNull())
							strContainersNumero = dtrwPe.mstrContainerNumero;
						// strContainersTipo 
						if (!dtrwPe.IsmstrContainerTipoNull())
							strContainersTipo = dtrwPe.mstrContainerTipo;
						// strContainersISO
						if (!dtrwPe.IsmstrContainerISONull())
							strContainersISO = dtrwPe.mstrContainerISO;
						// strContainersTamanho 
						if (!dtrwPe.IsmstrContainerTamanhoNull())
							strContainersTamanho = dtrwPe.mstrContainerTamanho;
						// strContainersTara 
						if (!dtrwPe.IsmstrContainerTaraNull())
							strContainersTara = dtrwPe.mstrContainerTara;
						// strContainersLacre 
						if (!dtrwPe.IsmstrContainerLacreNull())
							strContainersLacre = dtrwPe.mstrContainerLacre;
						// strContainersLacreArmador
						if (!dtrwPe.IsmstrContainerLacreArmadorNull())
							strContainersLacreArmador = dtrwPe.mstrContainerLacreArmador;
						//mstrContainerExcessoCargaAltura
						if (!dtrwPe.IsmstrContainerExcessoCargaAlturaNull())
							strContainerExcessoCargaAltura  = dtrwPe.mstrContainerExcessoCargaAltura;
						//mstrContainerExcessoCargaLargura
						if (!dtrwPe.IsmstrContainerExcessoCargaLarguraNull())
							strContainerExcessoCargaLargura  = dtrwPe.mstrContainerExcessoCargaLargura;
						//mstrContainerExcessoCargaComprimento
						if (!dtrwPe.IsmstrContainerExcessoCargaComprimentoNull())
							strContainerExcessoCargaComprimento  = dtrwPe.mstrContainerExcessoCargaComprimento;
						//mstrContainerTemperaturaMinima
						if (!dtrwPe.IsmstrContainerTemperaturaMinimaNull())
							strContainerTemperaturaMinima  = dtrwPe.mstrContainerTemperaturaMinima;
						//mstrContainerTemperaturaMaxima
						if (!dtrwPe.IsmstrContainerTemperaturaMaximaNull())
							strContainerTemperaturaMaxima  = dtrwPe.mstrContainerTemperaturaMaxima;
						//mstrContainerIMO
						if (!dtrwPe.IsmstrContainerIMONull())
							strContainerIMO  = dtrwPe.mstrContainerIMO;
						//mstrContainerUNO
						if (!dtrwPe.IsmstrContainerUNONull())
							strContainerUNO = dtrwPe.mstrContainerUNO;
					}
				}else{
					vGeraInformacoesContainers(out strContainersNumero,out strContainersTipo,out strContainersISO,out strContainersTamanho,out strContainersTara,out strContainersLacre,out strContainersLacreArmador,out strContainerExcessoCargaAltura,out strContainerExcessoCargaLargura,out strContainerExcessoCargaComprimento,out strContainerTemperaturaMinima,out strContainerTemperaturaMaxima,out strContainerIMO,out strContainerUNO);
					if (m_typDatSetPes.tbPEs.Rows.Count > 0 )
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
						// strContainersNumero
						dtrwPe.mstrContainerNumero = strContainersNumero;
						// strContainersTipo 
						dtrwPe.mstrContainerTipo = strContainersNumero;
						// strContainersISO 
						dtrwPe.mstrContainerISO = strContainersISO;
						// strContainersTamanho 
						dtrwPe.mstrContainerTamanho = strContainersNumero;
						// strContainersTara 
						dtrwPe.mstrContainerTara = strContainersNumero;
						// strContainersLacre 
						dtrwPe.mstrContainerLacre = strContainersNumero;
						// strContainersLacreArmador
						dtrwPe.mstrContainerLacreArmador = strContainersNumero;
						//mstrContainerExcessoCargaAltura
						dtrwPe.mstrContainerExcessoCargaAltura = strContainerExcessoCargaAltura;
						//mstrContainerExcessoCargaLargura
						dtrwPe.mstrContainerExcessoCargaLargura = strContainerExcessoCargaLargura;
						//mstrContainerExcessoCargaComprimento
						dtrwPe.mstrContainerExcessoCargaComprimento = strContainerExcessoCargaComprimento;
						//mstrContainerTemperaturaMinima
						dtrwPe.mstrContainerTemperaturaMinima = strContainerTemperaturaMinima;
						//mstrContainerTemperaturaMaxima
						dtrwPe.mstrContainerTemperaturaMaxima = strContainerTemperaturaMaxima;
						//mstrContainerIMO
						dtrwPe.mstrContainerIMO	= strContainerIMO;
						//mstrContainerUNO
						dtrwPe.mstrContainerUNO = strContainerUNO;
					}
					m_bChanged = false;
				}
			}

			private void vSalvaDadosInformacoesContainers(string strContainersNumero,string strContainersTipo,string strContainersISO,string strContainersTamanho,string strContainersTara,string strContainersLacre,string strContainersLacreArmador,string strContainerExcessoCargaAltura,string strContainerExcessoCargaLargura,string strContainerExcessoCargaComprimento,string strContainerTemperaturaMinima,string strContainerTemperaturaMaxima,string strContainerIMO,string strContainerUNO)
			{
				if (m_typDatSetPes.tbPEs.Rows.Count > 0 )
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					// strContainersNumero
					dtrwPe.mstrContainerNumero = strContainersNumero;
					// strContainersTipo 
					dtrwPe.mstrContainerTipo = strContainersTipo;
					// strContainersISO
					dtrwPe.mstrContainerISO = strContainersISO;
					// strContainersTamanho 
					dtrwPe.mstrContainerTamanho = strContainersTamanho;
					// strContainersTara 
					dtrwPe.mstrContainerTara = strContainersTara;
					// strContainersLacre 
					dtrwPe.mstrContainerLacre = strContainersLacre;
					// strContainersLacreArmador
					dtrwPe.mstrContainerLacreArmador = strContainersLacreArmador;
					//mstrContainerExcessoCargaAltura
					dtrwPe.mstrContainerExcessoCargaAltura = strContainerExcessoCargaAltura;
					//mstrContainerExcessoCargaLargura
					dtrwPe.mstrContainerExcessoCargaLargura = strContainerExcessoCargaLargura;
					//mstrContainerExcessoCargaComprimento
					dtrwPe.mstrContainerExcessoCargaComprimento = strContainerExcessoCargaComprimento;
					//mstrContainerTemperaturaMinima
					dtrwPe.mstrContainerTemperaturaMinima = strContainerTemperaturaMinima;
					//mstrContainerTemperaturaMaxima
					dtrwPe.mstrContainerTemperaturaMaxima = strContainerTemperaturaMaxima;
					//mstrContainerIMO
					dtrwPe.mstrContainerIMO	= strContainerIMO;
					//mstrContainerUNO
					dtrwPe.mstrContainerUNO = strContainerUNO;
				}
			}
			
		#endregion
		#region Containers
			private void vContainers(out System.Collections.SortedList sorLstContainers)
			{
 			    sorLstContainers = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer in m_typDatSetProcessosContainers.tbProcessosContainers.Rows)
					if (dtrwContainer.RowState != System.Data.DataRowState.Deleted)
						if (!sorLstContainers.Contains(dtrwContainer.nIdContainer))
							sorLstContainers.Add(dtrwContainer.nIdContainer,dtrwContainer);
			}

			private int[] arrnContainersIdentificacoes()
			{
				System.Collections.SortedList sorLstContainers = null;
				vContainers(out sorLstContainers);
				int[] nReturn = new int[sorLstContainers.Count];
				for(int i = 0; i < sorLstContainers.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer = (mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow)sorLstContainers.GetByIndex(i);
					nReturn[i] = dtrwContainer.nIdContainer;
				}
				return(nReturn);
			}

			public int nQuantidadeContainers()
			{
				System.Collections.SortedList sorLstContainers = null;
				vContainers(out sorLstContainers);
				return(sorLstContainers.Count);
			}

			private void vCarregaDados(int nIdContainer,out string strNumero,out int nIdContainerTipo,out string strContainerTipo,out string strContainerISO,out string strTamanho,out double dTara,out int nUnidadeTara,out string strLacre,out string strLacreArmador,out double dExcessoCargaAltura,out double dExcessoCargaLargura,out double dExcessoCargaComprimento,out int nUnidadeExcessoCargaAltura,out int nUnidadeExcessoCargaLargura,out int nUnidadeExcessoCargaComprimento,out string strTemperaturaMinima,out string strTemperaturaMaxima,out string strIMO,out string strUNO)
			{
			 	strNumero = "";
				nIdContainerTipo = 1;
				strContainerTipo = "Dry";
				strContainerISO = "";
				strTamanho = "";
				dTara = 0;
				nUnidadeTara = (int)mdlConstantes.UnidadeMassa.Kilograma;
				strLacre = "";
				strLacreArmador = "";
				dExcessoCargaAltura = 0;
				dExcessoCargaLargura = 0;
				dExcessoCargaComprimento = 0;
				nUnidadeExcessoCargaAltura = (int)mdlConstantes.UnidadeMedida.Centimetro;
				nUnidadeExcessoCargaLargura = (int)mdlConstantes.UnidadeMedida.Centimetro;
				nUnidadeExcessoCargaComprimento = (int)mdlConstantes.UnidadeMedida.Centimetro;
				strTemperaturaMinima = "";
				strTemperaturaMaxima = "";
				strIMO = "";
				strUNO = "";
				mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer = m_typDatSetProcessosContainers.tbProcessosContainers.FindBynIdExportadorstrIdPenIdContainer(m_nIdExportador,m_strIdPe,nIdContainer);
				if ((dtrwContainer != null) && (dtrwContainer.RowState != System.Data.DataRowState.Deleted))
				{
					// strNumero
					if (!dtrwContainer.IsstrNumeroNull())
						strNumero = dtrwContainer.strNumero;
					// nIdContainerTipo 
					if (!dtrwContainer.IsnIdContainerTipoNull())
						nIdContainerTipo = dtrwContainer.nIdContainerTipo ;
					// strContainerTipo 
					if (!dtrwContainer.IsstrContainerTipoNull())
						strContainerTipo = dtrwContainer.strContainerTipo;
					// strContainerISO
					if (!dtrwContainer.IsstrISONull())
						strContainerISO = dtrwContainer.strISO;
					// strTamanho 
					if (!dtrwContainer.IsstrTamanhoNull())
						strTamanho = dtrwContainer.strTamanho;
					// dTara 
					if (!dtrwContainer.IsdTaraNull())
						dTara = dtrwContainer.dTara;
					// nUnidadeTara 
					if (!dtrwContainer.IsnUnidadeTaraNull())
						nUnidadeTara = dtrwContainer.nUnidadeTara;
					// strLacre 
					if (!dtrwContainer.IsstrLacreNull())
						strLacre = dtrwContainer.strLacre;
					// strLacreArmador
					if (!dtrwContainer.IsstrLacreArmadorNull())
						strLacreArmador = dtrwContainer.strLacreArmador;
					// dExcessoCargaAltura
					if (!dtrwContainer.IsdExcessoCargaAlturaNull())
						dExcessoCargaAltura = dtrwContainer.dExcessoCargaAltura;
					// dExcessoCargaLargura
					if (!dtrwContainer.IsdExcessoCargaLarguraNull())
						dExcessoCargaLargura = dtrwContainer.dExcessoCargaLargura;
					// dExcessoCargaComprimento
					if (!dtrwContainer.IsdExcessoCargaComprimentoNull())
						dExcessoCargaComprimento = dtrwContainer.dExcessoCargaComprimento;
					// nUnidadeExcessoCargaAltura
					if (!dtrwContainer.IsnUnidadeExcessoCargaAlturaNull())
						nUnidadeExcessoCargaAltura = dtrwContainer.nUnidadeExcessoCargaAltura;
					// nUnidadeExcessoCargaLargura
					if (!dtrwContainer.IsnUnidadeExcessoCargaLarguraNull())
						nUnidadeExcessoCargaLargura = dtrwContainer.nUnidadeExcessoCargaLargura;
					// nUnidadeExcessoCargaComprimento
					if (!dtrwContainer.IsnUnidadeExcessoCargaComprimentoNull())
						nUnidadeExcessoCargaComprimento = dtrwContainer.nUnidadeExcessoCargaComprimento;
					// strTemperaturaMinima
					if (!dtrwContainer.IsstrTemperaturaMinimaNull())
						strTemperaturaMinima = dtrwContainer.strTemperaturaMinima;
					// strTemperaturaMaxima
					if (!dtrwContainer.IsstrTemperaturaMaximaNull())
						strTemperaturaMaxima = dtrwContainer.strTemperaturaMaxima;
					// strIMO
					if (!dtrwContainer.IsstrIMONull())
						strIMO = dtrwContainer.strIMO;
					// strUNO
					if (!dtrwContainer.IsstrUNONull())
						strUNO = dtrwContainer.strUNO;
				}
			}

			private bool bSalvaDados(int nIdContainer,string strNumero,int nIdContainerTipo,string strContainerTipo,string strContainerISO,string strTamanho,double dTara,int nUnidadeTara,string strLacre,string strLacreArmador,double dExcessoCargaAltura,double dExcessoCargaLargura,double dExcessoCargaComprimento,int nUnidadeExcessoCargaAltura,int nUnidadeExcessoCargaLargura,int nUnidadeExcessoCargaComprimento,string strTemperaturaMinima,string strTemperaturaMaxima,string strIMO,string strUNO)
			{
				bool bAdd = false;

				if (strNumero != "")
				{
					// Numero (Validacao)
					if (!mdlValidacao.clsContainer.bCheckContainerDigit(strNumero))
					{
						mdlMensagens.clsMensagens.ShowInformation("O número do container esta incorreto.");
						return(false);
					}

					// Numero (replicacao)
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainerCheck in m_typDatSetProcessosContainers.tbProcessosContainers.Rows)
					{
						if (dtrwContainerCheck.RowState != System.Data.DataRowState.Deleted)
						{
							if ((dtrwContainerCheck.strNumero == strNumero) && (dtrwContainerCheck.nIdContainer != nIdContainer))
							{
								mdlMensagens.clsMensagens.ShowInformation("O número do container não pode ser replicado.");
								return(false);
							}
						}
					}
				}

				mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer = null;
				if (bAdd = (nIdContainer == -1))
				{
					dtrwContainer = m_typDatSetProcessosContainers.tbProcessosContainers.NewtbProcessosContainersRow();
					dtrwContainer.nIdExportador = m_nIdExportador;
					dtrwContainer.strIdPe = m_strIdPe;
					dtrwContainer.nIdContainer = nNextNumeroContainer();
				}else{
					dtrwContainer = m_typDatSetProcessosContainers.tbProcessosContainers.FindBynIdExportadorstrIdPenIdContainer(m_nIdExportador,m_strIdPe,nIdContainer);
					if ((dtrwContainer == null) && (dtrwContainer.RowState == System.Data.DataRowState.Deleted))
						return(false);
				}
				dtrwContainer.strNumero = strNumero;
				dtrwContainer.nIdContainerTipo = nIdContainerTipo;
				dtrwContainer.strContainerTipo = strContainerTipo;
				dtrwContainer.strISO = strContainerISO;
				dtrwContainer.strTamanho = strTamanho;
				dtrwContainer.dTara = dTara;
				dtrwContainer.nUnidadeTara = nUnidadeTara;
				dtrwContainer.strLacre = strLacre;
				dtrwContainer.strLacreArmador = strLacreArmador;
				dtrwContainer.dExcessoCargaAltura = dExcessoCargaAltura;
				dtrwContainer.dExcessoCargaLargura = dExcessoCargaLargura;
				dtrwContainer.dExcessoCargaComprimento = dExcessoCargaComprimento;
				dtrwContainer.nUnidadeExcessoCargaAltura = nUnidadeExcessoCargaAltura;
				dtrwContainer.nUnidadeExcessoCargaLargura = nUnidadeExcessoCargaLargura;
				dtrwContainer.nUnidadeExcessoCargaComprimento = nUnidadeExcessoCargaComprimento;
				dtrwContainer.strTemperaturaMinima = strTemperaturaMinima;
				dtrwContainer.strTemperaturaMaxima = strTemperaturaMaxima;
				dtrwContainer.strIMO = strIMO;
				dtrwContainer.strUNO = strUNO;
				if (bAdd)
					m_typDatSetProcessosContainers.tbProcessosContainers.AddtbProcessosContainersRow(dtrwContainer);
				m_bChanged = true;
				return(true);
			}

			private int nNextNumeroContainer()
			{
				int nIndex = 1;
				while (m_typDatSetProcessosContainers.tbProcessosContainers.FindBynIdExportadorstrIdPenIdContainer(m_nIdExportador,m_strIdPe,nIndex) != null)
					nIndex++;
				return(nIndex);
			}

			private void vRefreshContainers(ref System.Windows.Forms.ListView lvContainers)
			{
				System.Windows.Forms.ListViewItem lviContainer;
				lvContainers.Items.Clear();

				System.Collections.SortedList sortLstContainers = new System.Collections.SortedList();
				// Ordenando 
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer in m_typDatSetProcessosContainers.tbProcessosContainers)
				{
					if (dtrwContainer.RowState != System.Data.DataRowState.Deleted)
					{
						string strNumero = dtrwContainer.strNumero;
						while(sortLstContainers.ContainsKey(strNumero))
							strNumero += "X";
						sortLstContainers.Add(strNumero,dtrwContainer);
					}
				}

				// Inserindo 
				for(int i = 0; i < sortLstContainers.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainerInserir = (mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow)sortLstContainers.GetByIndex(i);
					lviContainer = lvContainers.Items.Add(dtrwContainerInserir.strNumero);
					lviContainer.SubItems.Add(dtrwContainerInserir.strContainerTipo);
					lviContainer.Tag = dtrwContainerInserir.nIdContainer;
				}

			}

			private bool bContainerExclui(System.Collections.ArrayList arlContainers,bool bSilent)
			{
				if (!bSilent)
					if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras","Deseja mesmo excluir este(s) container(s)?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);

				for(int i = m_typDatSetProcessosContainers.tbProcessosContainers.Rows.Count - 1; i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer = (mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow)m_typDatSetProcessosContainers.tbProcessosContainers.Rows[i];
					if ((dtrwContainer.RowState != System.Data.DataRowState.Deleted) && (arlContainers.Contains(dtrwContainer.nIdContainer)))
						dtrwContainer.Delete();
				}
				m_bChanged = true;
				return(true);
			}
		#endregion

		#region Retorno 
			public void vRetornaValores(out string strContainersNumero,out string strContainersTipo,out string strContainersISO,out string strContainersTamanho,out string strContainersTara,out string strContainersLacre,out string strContainersLacreArmador,out string strContainerExcessoCargaAltura,out string strContainerExcessoCargaLargura,out string strContainerExcessoCargaComprimento,out string strContainerTemperaturaMinima,out string strContainerTemperaturaMaxima,out string strContainerIMO,out string strContainerUNO)
			{
				vCarregaDadosInformacoesContainers(out strContainersNumero,out strContainersTipo,out strContainersISO,out strContainersTamanho,out strContainersTara,out strContainersLacre,out strContainersLacreArmador,out strContainerExcessoCargaAltura,out strContainerExcessoCargaLargura,out strContainerExcessoCargaComprimento,out strContainerTemperaturaMinima,out strContainerTemperaturaMaxima,out strContainerIMO,out strContainerUNO);
			}

			public void vRetornaValores(int nIdParametro,out int nIdContainer)
			{
				int[] nIdsContainers = arrnContainersIdentificacoes();
				if ((nIdParametro < nIdsContainers.Length) && (nIdParametro >= 0))
					nIdContainer = nIdsContainers[nIdParametro];
				else
					nIdContainer = -1;
			}
			
			public void vRetornaValores(int nIdParametro,out string strContainersNumero,out string strContainersTipo,out string strContainersISO,out string strContainersTamanho,out string strContainersTara,out string strContainersLacre,out string strContainersLacreArmador,out string strContainerExcessoCargaAltura,out string strContainerExcessoCargaLargura,out string strContainerExcessoCargaComprimento,out string strContainerTemperaturaMinima,out string strContainerTemperaturaMaxima,out string strContainerIMO,out string strContainerUNO)
			{
				int[] nIdsContainers = arrnContainersIdentificacoes();
				if ((nIdParametro < nIdsContainers.Length) && (nIdParametro >= 0))
				{
					int nIdContainer = nIdsContainers[nIdParametro],nIdContainerTipo,nUnidadeTara;
					double dTara,dExcessoCargaAltura,dExcessoCargaLargura,dExcessoCargaComprimento;
					int nUnidadeExcessoCargaAltura,nUnidadeExcessoCargaLargura,nUnidadeExcessoCargaComprimento;
					vCarregaDados(nIdContainer,out strContainersNumero,out nIdContainerTipo,out strContainersTipo,out strContainersISO,out strContainersTamanho,out dTara,out nUnidadeTara,out strContainersLacre,out strContainersLacreArmador,out dExcessoCargaAltura,out dExcessoCargaLargura,out dExcessoCargaComprimento,out nUnidadeExcessoCargaAltura,out nUnidadeExcessoCargaLargura,out nUnidadeExcessoCargaComprimento,out strContainerTemperaturaMinima,out strContainerTemperaturaMaxima,out strContainerIMO,out strContainerUNO);
					strContainersTara = "";
					strContainerExcessoCargaAltura = "";
					strContainerExcessoCargaLargura = "";
					strContainerExcessoCargaComprimento = "";
					if (dTara != 0)
						strContainersTara = dTara.ToString() + " " + clsContainers.strRetornaUnidade((mdlConstantes.UnidadeMassa)nUnidadeTara);
					if (dExcessoCargaAltura != 0)
						strContainerExcessoCargaAltura = dExcessoCargaAltura.ToString() + " " + clsContainers.strRetornaUnidade((mdlConstantes.UnidadeMedida)nUnidadeExcessoCargaAltura);
					if (dExcessoCargaLargura != 0)
						strContainerExcessoCargaLargura = dExcessoCargaLargura.ToString() + " " + clsContainers.strRetornaUnidade((mdlConstantes.UnidadeMedida)nUnidadeExcessoCargaLargura);
					if (dExcessoCargaComprimento != 0)
						strContainerExcessoCargaComprimento = dExcessoCargaComprimento.ToString() + " " + clsContainers.strRetornaUnidade((mdlConstantes.UnidadeMedida)nUnidadeExcessoCargaComprimento);
				}
				else
				{
					strContainersNumero = strContainersTipo = strContainersISO = strContainersTamanho = strContainersTara = strContainersLacre = strContainersLacreArmador = strContainerExcessoCargaAltura = strContainerExcessoCargaLargura = strContainerExcessoCargaComprimento = strContainerTemperaturaMinima = strContainerTemperaturaMaxima = strContainerIMO = strContainerUNO = "";
				}			
			}
		#endregion
	}
}

using System;

namespace mdlProdutosRomaneio
{
	/// <summary>
	/// Summary description for clsProdutosRomaneioSimplificado.
	/// </summary>
	public class clsProdutosRomaneioSimplificado
	{
		#region Static
			#region Volumes
				static internal bool bVolumeCubagem(UnidadeMedida enumUnidadeMedica,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwVolume,out double dCubagem)
				{
					bool bReturn = false;
					dCubagem = 0;
					if (dtrwVolume.RowState != System.Data.DataRowState.Deleted)
					{
						if ((!dtrwVolume.IsdVolumeNull()) && (!dtrwVolume.IsnUnidadeVolumeNull()))
						{
							dCubagem = dtrwVolume.dVolume;
							if ((int)enumUnidadeMedica != dtrwVolume.nUnidadeVolume)
							{
								double dFatorConversao = clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesEspaco(dtrwVolume.nUnidadeVolume,(int)enumUnidadeMedica);
								dCubagem = dCubagem * dFatorConversao * dFatorConversao * dFatorConversao;
							}
							bReturn = true;
						}
					}
					return(bReturn);
				}
			#endregion
		#endregion
		
		#region Constants
			private const int MAXDECIMALS = 8;
		#endregion
		#region Atributes
			// ***************************************************************************************************
			// Atributos
			// ***************************************************************************************************
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel; 

			private int m_nIdExportador;
			private string m_strIdPe;

			private int m_nIdIdioma = -1;

			//Default
			private int m_nIdTipoVolumeDefault = -1;
			private string m_strDescricaoVolumeDefault = "";

			// Formularios 
			frmFProdutosSimplificado m_formFProdutosSimplificado = null;

			// Ordenacao Produtos 
			private Ordenacao m_enumOrdenacao = Ordenacao.Simplificado;

			// Fatura Comercial 
			private double m_dFaturaPesoLiquido = 0;
			private double m_dFaturaPesoBruto = 0;
			private int m_nIdUnidadeMassaFaturaPesoLiquido = 0;
			private int m_nIdUnidadeMassaFaturaPesoBruto = 0;

			// Typed DataSets
			protected mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa m_typDatSetTbUnidadesMassa;
			protected mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma m_typDatSetTbUnidadesMassaIdioma;
			protected mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco m_typDatSetTbUnidadesEspaco;
			protected mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma m_typDatSetTbUnidadesEspacoIdioma;

			protected mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais;

			protected mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios;

			protected mdlDataBaseAccess.Tabelas.XsdTbProdutos m_typDatSetTbProdutos;
			protected mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas m_typDatSetTbProdutosIdiomas;
			protected mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial m_typDatSetTbProdutosFaturaComercial;

			protected mdlDataBaseAccess.Tabelas.XsdTbVolumes m_typDatSetTbVolumes;
			protected mdlDataBaseAccess.Tabelas.XsdTbExportadoresVolumes m_typDatSetTbExportadoresVolumes;

			protected mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado m_typDatSetTbProdutosRomaneioSimplificado;

			private System.Drawing.Color m_clrQuantidadeInteira = System.Drawing.Color.Red;
			private System.Drawing.Color m_clrQuantidadeMetade = System.Drawing.Color.Orange;
			private System.Drawing.Color m_clrQuantidadeNada = System.Drawing.Color.Green;

			public bool m_bModificado = false;
		#endregion
		#region Properties
			public bool HasProducts
			{
				get
				{
					if (m_typDatSetTbProdutosRomaneioSimplificado == null)
						return(false);
					return(m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows.Count > 0);
				}
			}
		#endregion
		#region Constructors and Destructors
			public clsProdutosRomaneioSimplificado(ref mdlTratamentoErro.clsTratamentoErro tratadorErro , ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB , string strEnderecoExecutavel,int idExportador, string idPe)
			{
				m_cls_ter_tratadorErro = tratadorErro; 
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel; 

				m_strIdPe = idPe;
				m_nIdExportador = idExportador;

				this.vCarregaDadosBD();
			}
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{
				m_formFProdutosSimplificado = new frmFProdutosSimplificado(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel);
				vInitializeEvents(ref m_formFProdutosSimplificado);
				m_formFProdutosSimplificado.ShowDialog();
				m_bModificado = m_formFProdutosSimplificado.m_bModificado;
				m_formFProdutosSimplificado = null;
			}

			private void vInitializeEvents(ref frmFProdutosSimplificado formFProdutosSimplificado)
			{
				// Carrega os Dados na Interface Produtos Fatura
				formFProdutosSimplificado.eCallCarregaDadosInterfaceProdutosFatura += new frmFProdutosSimplificado.delCallCarregaDadosInterfaceProdutosFatura(vCarregaDadosInterfaceProdutosFatura);

				// Carrega os Dados na Interface Produtos Romaneio
				formFProdutosSimplificado.eCallCarregaDadosInterfaceProdutosRomaneio += new frmFProdutosSimplificado.delCallCarregaDadosInterfaceProdutosRomaneio(vCarregaDadosInterfaceProdutosRomaneio);

				// Carrega os Dados da Fatura Comercial
				formFProdutosSimplificado.eCallCarregaDadosFaturaComercial += new frmFProdutosSimplificado.delCallCarregaDadosFaturaComercial(vCarregaDadosFaturaComercial);
				
				// Carrega os Dados do Romaneio
				formFProdutosSimplificado.eCallCarregaDadosRomaneio += new frmFProdutosSimplificado.delCallCarregaDadosRomaneio(vCarregaDadosRomaneio);

				// Vinculo Novo
				formFProdutosSimplificado.eCallShowDialogVinculo += new mdlProdutosRomaneio.frmFProdutosSimplificado.delCallShowDialogVinculo(bShowDialogVinculo);

				// Vinculo Editar 
				formFProdutosSimplificado.eCallShowDialogVinculoEditar += new mdlProdutosRomaneio.frmFProdutosSimplificado.delCallShowDialogVinculoEditar(bShowDialogVinculoEditar);

				// Vinculo Remover 
				formFProdutosSimplificado.eCallVinculoRemover += new mdlProdutosRomaneio.frmFProdutosSimplificado.delCallVinculoRemover(bVinculoRemover);

				// Troca Ordem Produtos
				formFProdutosSimplificado.eCallTrocaOrdemProdutos += new mdlProdutosRomaneio.frmFProdutosSimplificado.delCallTrocaOrdemProdutos(bTrocaOrdemProdutos);

				// Salva Dados
				formFProdutosSimplificado.eCallSalvaDados += new mdlProdutosRomaneio.frmFProdutosSimplificado.delCallSalvaDados(bSalvaDados);

				// ShowDialog Automatico
				formFProdutosSimplificado.eCallShowDialogAutomatico += new mdlProdutosRomaneio.frmFProdutosSimplificado.delCallShowDialogAutomatico(ShowDialogAutomatico);
			}
		#endregion
		#region ShowDialogVinculoNovo
			private bool bShowDialogVinculo(int nIdOrdem)
			{
				bool bRetorno = false;
				int nIdOrdemProdutoRomaneio = -1;
//				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoRomaneio in m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows)
//				{
//					if (dtrwProdutoRomaneio.RowState != System.Data.DataRowState.Deleted)
//					{
//						if (dtrwProdutoRomaneio.nIdOrdemProduto == nIdOrdem)
//						{
//							nIdOrdemProdutoRomaneio = dtrwProdutoRomaneio.nIdOrdem;
//							break;
//						}
//					}
//				}
				bRetorno = bShowDialogVinculo(nIdOrdem,nIdOrdemProdutoRomaneio);
				return(bRetorno);
			}
			
			private bool bShowDialogVinculoEditar(int nIdOrdemProdutoRomaneio)
			{
				bool bRetorno = false;
				int nIdOrdemProduto = -1;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoRomaneio in m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows)
				{
					if (dtrwProdutoRomaneio.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwProdutoRomaneio.nIdOrdem == nIdOrdemProdutoRomaneio)
						{
							nIdOrdemProduto = dtrwProdutoRomaneio.nIdOrdemProduto;
							break;
						}
					}
				}
				if (nIdOrdemProduto != -1)
				{
					bRetorno = bShowDialogVinculo(nIdOrdemProduto,nIdOrdemProdutoRomaneio);
				}
				return(bRetorno);
			}

			private bool bShowDialogVinculo(int nIdOrdem,int nIdOrdemProdutoRomaneio)
			{
				bool bRetorno = false;
				frmFProdutosSimplificadoVincular formFProdutosSimplificadoVincular = new frmFProdutosSimplificadoVincular(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,nIdOrdem,nIdOrdemProdutoRomaneio);
				vInitializeEvents(ref formFProdutosSimplificadoVincular);
				formFProdutosSimplificadoVincular.ShowDialog();
				bRetorno = formFProdutosSimplificadoVincular.m_bModificado;
				formFProdutosSimplificadoVincular = null;
				return(bRetorno);
			}

			private void vInitializeEvents(ref frmFProdutosSimplificadoVincular formFProdutosSimplificadoVincular)
			{
				// Carrega Unidade Metrica
				formFProdutosSimplificadoVincular.eCallRetornaSiglaUnidadeEspaco +=new mdlProdutosRomaneio.frmFProdutosSimplificadoVincular.delCallRetornaSiglaUnidadeEspaco(strRetornaSiglaUnidadeEspaco);

				// Carrega Unidade Massa
				formFProdutosSimplificadoVincular.eCallRetornaSiglaUnidadeMassa +=new mdlProdutosRomaneio.frmFProdutosSimplificadoVincular.delCallRetornaSiglaUnidadeMassa(strRetornaSiglaUnidadeMassa);

				// Carrega dados Produto
				formFProdutosSimplificadoVincular.eCallCarregaDadosProduto += new mdlProdutosRomaneio.frmFProdutosSimplificadoVincular.delCallCarregaDadosProduto(vCarregaDadosProduto);

				// Carrega dados Produto Romaneio
				formFProdutosSimplificadoVincular.eCallCarregaDados += new mdlProdutosRomaneio.frmFProdutosSimplificadoVincular.delCallCarregaDados(vCarregaDados);

				// ShowDialogVolumeTipo
				formFProdutosSimplificadoVincular.eCallShowDialogVolumeTipo += new mdlProdutosRomaneio.frmFProdutosSimplificadoVincular.delCallShowDialogVolumeTipo(bShowDialogVolumeTipo);

				// Carrega Dados Volume Tipo
				formFProdutosSimplificadoVincular.eCallCarregaDadosTipoVolume += new mdlProdutosRomaneio.frmFProdutosSimplificadoVincular.delCallCarregaDadosTipoVolume(vCarregaDadosVolumeTipo);

				// Salva Dados
				formFProdutosSimplificadoVincular.eCallSalvaDados += new mdlProdutosRomaneio.frmFProdutosSimplificadoVincular.delCallSalvaDados(bSalvaDados);

			}
		#endregion
		#region ShowDialogVolumeTipo
			private bool bShowDialogVolumeTipo(ref System.Windows.Forms.ImageList ilVolumes,ref int nIdTipoVolume)
			{
				bool bRetorno = false;
				frmFVolumeTipo formFVolumeTipo = new frmFVolumeTipo(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,ref ilVolumes);
				vInitializeEvents(ref formFVolumeTipo);
				formFVolumeTipo.Icon = m_formFProdutosSimplificado.Icon;
				formFVolumeTipo.EspecieSelect = nIdTipoVolume;
				formFVolumeTipo.ShowDialog();
				if (bRetorno = formFVolumeTipo.m_bModificado)
					formFVolumeTipo.RetornaValores(out nIdTipoVolume);
				return(bRetorno);
			}

			private void vInitializeEvents(ref frmFVolumeTipo formFVolumeTipo)
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
				for (int nCont = 0 ;nCont < m_typDatSetTbVolumes.tbVolumes.Rows.Count;nCont++)
				{
					dtrwTipoVolume = (mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow)m_typDatSetTbVolumes.tbVolumes.Rows[nCont];
					lviVolume = lvTiposVolumes.Items.Add(dtrwTipoVolume.strDescricao);
					lviVolume.Tag = dtrwTipoVolume.nIdVolume;
					lviVolume.ImageIndex = dtrwTipoVolume.nIdImagem;
				}
			}
		#endregion
		#region ShowDialogAutomatico
			private bool ShowDialogAutomatico()
			{
				bSalvaDados();
				clsProdutosRomaneioAutomacao clsAutomacao = new clsProdutosRomaneioAutomacao(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPe);
				if (clsAutomacao.ShowDialog())
				{
					vCarregaDadosBD();
					return(true);
				}
				return(false);
			}
		#endregion

		#region Carregamento dos Dados
			#region Banco Dados
				private void vCarregaDadosBD()
				{
					CarregaDadosBDUnidadesMassa();
					CarregaDadosBDUnidadesMassaIdioma();
					CarregaDadosBDUnidadesEspaco();
					CarregaDadosBDUnidadesEspacoIdioma();

					CarregaDadosBDFaturasComerciais();
					CarregaDadosBDRomaneios();
					CarregaDadosBDProdutos();
					CarregaDadosBDProdutosIdiomas();
					CarregaDadosBDProdutosFaturaComercial();

					CarregaDadosBDVolumes();
					CarregaDadosBDExportadoresVolumes();

					vCarregaDadosBDProdutosRomaneioSimplificado();
				}

				private void CarregaDadosBDUnidadesMassa()
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbUnidadesMassa = m_cls_dba_ConnectionDB.GetTbUnidadesMassa(null,null,null,null,null);
				}

				private void CarregaDadosBDUnidadesMassaIdioma()
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbUnidadesMassaIdioma = m_cls_dba_ConnectionDB.GetTbUnidadesMassaIdioma(null,null,null,null,null);
				}

				private void CarregaDadosBDUnidadesEspaco()
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbUnidadesEspaco = m_cls_dba_ConnectionDB.GetTbUnidadesEspaco(null,null,null,null,null);
				}

				private void CarregaDadosBDUnidadesEspacoIdioma()
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbUnidadesEspacoIdioma = m_cls_dba_ConnectionDB.GetTbUnidadesEspacoIdioma(null,null,null,null,null);
				}

				private void CarregaDadosBDFaturasComerciais()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idPe");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strIdPe);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);

					// Selecionando a Linha
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPe);
					if (dtrwFaturaComercial != null)
					{
						// Idioma
						if (!dtrwFaturaComercial.IsidIdiomaNull())
							m_nIdIdioma = dtrwFaturaComercial.idIdioma;

						// Peso Liquido 
						if (!dtrwFaturaComercial.IspesoLiquidoNull())
							m_dFaturaPesoLiquido = dtrwFaturaComercial.pesoLiquido;

						// Peso Bruto
						if (!dtrwFaturaComercial.IspesoBrutoNull())
							m_dFaturaPesoBruto = dtrwFaturaComercial.pesoBruto;

						// Unidade Peso Liquido
						if (!dtrwFaturaComercial.IsnUnidadeMassaPesoLiquidoNull())
							m_nIdUnidadeMassaFaturaPesoLiquido = dtrwFaturaComercial.nUnidadeMassaPesoLiquido;

						// Unidade Peso Bruto 
						if (!dtrwFaturaComercial.IsnUnidadeMassaPesoBrutoNull())
							m_nIdUnidadeMassaFaturaPesoBruto = dtrwFaturaComercial.nUnidadeMassaPesoBruto;
					}
				}

				private void CarregaDadosBDRomaneios()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idPe");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strIdPe);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
						// Tipo Ordenacao
						if (!dtrwRomaneio.IsnTipoOrdenacaoNull())
						{
							m_enumOrdenacao = (Ordenacao)dtrwRomaneio.nTipoOrdenacao;
						}
						else
						{
							dtrwRomaneio.nTipoOrdenacao = (int)m_enumOrdenacao;
						}
					}
				}

				private void CarregaDadosBDProdutos()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
				}

				private void CarregaDadosBDProdutosIdiomas()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
				}

				private void CarregaDadosBDProdutosFaturaComercial()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idPe");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strIdPe);
					arlOrdenacaoCampo.Add("idOrdem");
					arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
				}

				private void CarregaDadosBDVolumes()
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbVolumes = m_cls_dba_ConnectionDB.GetTbVolumes(null,null,null,null,null);
				}
									
				private void CarregaDadosBDExportadoresVolumes()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbExportadoresVolumes = m_cls_dba_ConnectionDB.GetTbExportadoresVolumes(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
				}
			
				private void vCarregaDadosBDProdutosRomaneioSimplificado()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idPe");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strIdPe);
					arlOrdenacaoCampo.Add("nIdOrdem");
					arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbProdutosRomaneioSimplificado = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioSimplificado(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
				}
			#endregion
			#region Interface
				private void vCarregaDadosInterfaceProdutosFatura(ref mdlComponentesGraficos.TreeView tvProdutosFatura)
				{
					// Limpando a TreeView 
					tvProdutosFatura.Nodes.Clear();
					
					// Inserindo o Primeiro Nivel de Produtos
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura in m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows)
					{
						if ((!dtrwProdutoFatura.IsidProdutoNull()) && ((dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFatura.nIdOrdemProdutoParent <= 0)))
						{
							if (dtrwProdutoFatura.RowState != System.Data.DataRowState.Deleted)
							{
								vCarregaDadosInterfaceProdutosFaturaInsereProduto(ref tvProdutosFatura,null,dtrwProdutoFatura);
							}
						}
					}
				}

				private void vCarregaDadosInterfaceProdutosFaturaInsereProduto(ref mdlComponentesGraficos.TreeView tvProdutosFatura,System.Windows.Forms.TreeNode tvnParent,mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura)
				{
					string strLabelProduto = "";
					double dQuantidadeRestante = 0;
					double dQuantidadeTotal = 0;
					System.Windows.Forms.TreeNode tvnProduto = null;

					dQuantidadeRestante = dProdutoFaturaQuantidadeRestante(dtrwProdutoFatura.idOrdem);
					dQuantidadeTotal = dProdutoFaturaQuantidadeTotal(dtrwProdutoFatura.idOrdem); 
					if (!dtrwProdutoFatura.IsmstrDescricaoNull())
						strLabelProduto = dtrwProdutoFatura.mstrDescricao;
					else
						strLabelProduto = clsProdutosRomaneio.strRetornaDescricaoProduto(ref m_typDatSetTbProdutos,ref m_typDatSetTbProdutosIdiomas,m_nIdExportador,m_nIdIdioma,dtrwProdutoFatura.idProduto) + " (" + dQuantidadeRestante.ToString() + " " + dtrwProdutoFatura.strUnidade + ")"; 

					if (tvnParent == null)
						tvnProduto = tvProdutosFatura.Nodes.Add(strLabelProduto);
					else
						tvnProduto = tvnParent.Nodes.Add(strLabelProduto);
					tvnProduto.Tag = dtrwProdutoFatura.idOrdem;
					if (dQuantidadeRestante == dQuantidadeTotal)
					{
						tvnProduto.ForeColor = m_clrQuantidadeInteira;
					}
					else
					{
						if (dQuantidadeRestante == 0)
							tvnProduto.ForeColor = m_clrQuantidadeNada;
						else
							tvnProduto.ForeColor = m_clrQuantidadeMetade;
					}

					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFilho in m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows)
					{
						if(dtrwProdutoFilho.RowState != System.Data.DataRowState.Deleted)
							if ((!dtrwProdutoFilho.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFilho.nIdOrdemProdutoParent == dtrwProdutoFatura.idOrdem))
								vCarregaDadosInterfaceProdutosFaturaInsereProduto(ref tvProdutosFatura,tvnProduto,dtrwProdutoFilho);
					}
				}

				private void vCarregaDadosInterfaceProdutosRomaneio(ref mdlComponentesGraficos.ListView lvProdutosRomaneio)
				{
					lvProdutosRomaneio.Items.Clear();
					System.Windows.Forms.ListViewItem lviProduto = null;

					// Order 
					System.Collections.SortedList sortListProdutos = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProduto in m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows)
					{
						if (dtrwProduto.RowState != System.Data.DataRowState.Deleted)
							sortListProdutos.Add(dtrwProduto.nIdOrdem,dtrwProduto);
					}
					for(int i = 0; i < sortListProdutos.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoInserir = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow)sortListProdutos.GetByIndex(i);
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPe,dtrwProdutoInserir.nIdOrdemProduto);
						if (dtrwProdutoFatura != null)
						{
							string strQuantidadeProduto = dtrwProdutoInserir.dQuantidadeProduto.ToString() + " " + dtrwProdutoFatura.strUnidade;
							string strQuantidadeVolumes = dtrwProdutoInserir.dQuantidadeVolumes.ToString() + " " + dtrwProdutoInserir.strTipoPopular;
							string strDescricao = "";
							if (!dtrwProdutoFatura.IsmstrDescricaoNull())
								strDescricao = dtrwProdutoFatura.mstrDescricao;
							else
								strDescricao = clsProdutosRomaneio.strRetornaDescricaoProduto(ref m_typDatSetTbProdutos,ref m_typDatSetTbProdutosIdiomas,m_nIdExportador,m_nIdIdioma,dtrwProdutoFatura.idProduto); 
							lviProduto = lvProdutosRomaneio.Items.Add(strQuantidadeProduto);
							lviProduto.SubItems.Add(strQuantidadeVolumes);
							lviProduto.SubItems.Add(strDescricao);
							lviProduto.Tag = dtrwProdutoInserir.nIdOrdem;
						}
					}
				}

				private void vCarregaDadosProduto(int nIdOrdemProduto,int nIdOrdemProdutoRomaneio,out string strDescricao,out double dQuantidadeProduto,out double dQuantidadeProdutoMaxima,out string strProdutoUnidade)
				{
					strDescricao = "";
					dQuantidadeProduto = 0;
					dQuantidadeProdutoMaxima = 0;
					strProdutoUnidade = "";
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPe,nIdOrdemProduto);
					if (dtrwProdutoFatura != null)
					{
						if (!dtrwProdutoFatura.IsmstrDescricaoNull())
							strDescricao = dtrwProdutoFatura.mstrDescricao;
						else
							strDescricao = clsProdutosRomaneio.strRetornaDescricaoProduto(ref m_typDatSetTbProdutos,ref m_typDatSetTbProdutosIdiomas,m_nIdExportador,m_nIdIdioma,dtrwProdutoFatura.idProduto);
						strProdutoUnidade = clsProdutosRomaneio.strRetornaUnidadeQuantidadeProdutoFatura(ref m_typDatSetTbProdutosFaturaComercial,nIdOrdemProduto);
						dQuantidadeProduto = dProdutoFaturaQuantidadeRestante(nIdOrdemProduto);
						dQuantidadeProdutoMaxima = System.Math.Round(dQuantidadeProduto + dRetornaQuantidadeProdutoRomaneio(nIdOrdemProdutoRomaneio,nIdOrdemProduto),MAXDECIMALS);
						if (nIdOrdemProdutoRomaneio != -1)
						{
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoRomaneio = m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.FindByIdExportadoridPEnIdOrdem(m_nIdExportador,m_strIdPe,nIdOrdemProdutoRomaneio);
							if ((dtrwProdutoRomaneio != null) && (dtrwProdutoRomaneio.RowState != System.Data.DataRowState.Deleted))
								dQuantidadeProduto = dtrwProdutoRomaneio.dQuantidadeProduto; 
						}
					}
				}

				private void vCarregaDados(int nIdOrdemProdutoRomaneio,out int nIdTipoVolume,out string strTipoPopular,out double dAltura,out int nUnidadeMetricaAltura,out double dLargura,out int nUnidadeMetricaLargura,out double dComprimento,out int nUnidadeMetricaComprimento,out double dVolumeCubico,out int nUnidadeMetricaVolume,out double dPesoLiquidoUnitario,out int nUnidadeMassaPesoLiquido,out double dPesoBrutoUnitario,out int nUnidadeMassaPesoBruto,out double dQuantidadeVolumes)
				{
					nIdTipoVolume = -1;
					strTipoPopular = "";
					dAltura = 0;
					nUnidadeMetricaAltura = 2;
					dLargura = 0;
					nUnidadeMetricaLargura = 2;
					dComprimento = 0;
					nUnidadeMetricaComprimento = 2;
					dVolumeCubico = 0;
					nUnidadeMetricaVolume = 4;
					dPesoLiquidoUnitario = 0;
					nUnidadeMassaPesoLiquido = 3;
					dPesoBrutoUnitario = 0;
					nUnidadeMassaPesoBruto = 3;
					dQuantidadeVolumes = 0;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProduto = m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.FindByIdExportadoridPEnIdOrdem(m_nIdExportador,m_strIdPe,nIdOrdemProdutoRomaneio);
					if ((dtrwProduto != null) && (dtrwProduto.RowState != System.Data.DataRowState.Deleted))
					{
						nIdTipoVolume = dtrwProduto.nlTipoVolume;
						strTipoPopular = dtrwProduto.strTipoPopular;
						dAltura = dtrwProduto.dAltura;
						nUnidadeMetricaAltura = dtrwProduto.nUnidadeAltura;
						dLargura = dtrwProduto.dLargura;
						nUnidadeMetricaLargura = dtrwProduto.nUnidadeLargura;
						dComprimento = dtrwProduto.dComprimento;
						nUnidadeMetricaComprimento = dtrwProduto.nUnidadeComprimento;
						dVolumeCubico = dtrwProduto.dVolume;
						nUnidadeMetricaVolume = dtrwProduto.nUnidadeVolume;
						dPesoLiquidoUnitario = dtrwProduto.dPesoLiquidoUnitario;
						nUnidadeMassaPesoLiquido = dtrwProduto.nUnidadeMassaPesoLiquido;
						dPesoBrutoUnitario = dtrwProduto.dPesoBrutoUnitario;
						nUnidadeMassaPesoBruto = dtrwProduto.nUnidadeMassaPesoBruto;
						dQuantidadeVolumes = dtrwProduto.dQuantidadeVolumes;
					}
				}

				private void vCarregaDadosVolumeTipo(int nIdTipoVolume,out int nIdImageIndex,out string strDescricao)
				{
					if (nIdTipoVolume == -1)
					{
						nIdTipoVolume = m_nIdTipoVolumeDefault;
						strDescricao = m_strDescricaoVolumeDefault;
					}else{
						strDescricao = strRetornaDescricaoVolume(nIdTipoVolume);
					}
					nIdImageIndex = clsProdutosRomaneio.nRetornaIndiceImagemVolume(ref m_typDatSetTbVolumes,nIdTipoVolume);
				}
			#endregion
		#endregion
		#region Salvamento dos Dados
			#region Interface
				private bool bSalvaDados(int nIdOrdemProdutoRomaneio,int nIdOrdemProduto,int nIdTipoVolume,string strTipoPopular,double dAltura,int nUnidadeMetricaAltura,double dLargura,int nUnidadeMetricaLargura,double dComprimento,int nUnidadeMetricaComprimento,double dVolumeCubico,int nUnidadeMetricaVolume,double dPesoLiquidoUnitario,int nUnidadeMassaPesoLiquido,double dPesoBrutoUnitario,int nUnidadeMassaPesoBruto,double dQuantidadeProduto,double dQuantidadeVolumes)
				{
					bool bRetorno = false;
					bool bAdd = false;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoRomaneio = null;
					if (bAdd = (nIdOrdemProdutoRomaneio == -1))
					{
						nIdOrdemProdutoRomaneio = nNextProdutoRomaneio();
						dtrwProdutoRomaneio = m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.NewtbProdutosRomaneioSimplificadoRow();
						dtrwProdutoRomaneio.IdExportador = m_nIdExportador;
						dtrwProdutoRomaneio.idPE = m_strIdPe;
						dtrwProdutoRomaneio.nIdOrdem = nIdOrdemProdutoRomaneio;
					}else{
						dtrwProdutoRomaneio = m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.FindByIdExportadoridPEnIdOrdem(m_nIdExportador,m_strIdPe,nIdOrdemProdutoRomaneio);
						if (dtrwProdutoRomaneio == null)
							return(false);
					}
					dtrwProdutoRomaneio.nIdOrdemProduto = nIdOrdemProduto;
					dtrwProdutoRomaneio.dQuantidadeProduto = dQuantidadeProduto;
					dtrwProdutoRomaneio.dQuantidadeVolumes = dQuantidadeVolumes;
					dtrwProdutoRomaneio.dPesoLiquidoUnitario = dPesoLiquidoUnitario;
					dtrwProdutoRomaneio.dPesoBrutoUnitario = dPesoBrutoUnitario;
					dtrwProdutoRomaneio.nUnidadeMassaPesoLiquido = nUnidadeMassaPesoLiquido;
					dtrwProdutoRomaneio.nUnidadeMassaPesoBruto = nUnidadeMassaPesoBruto;
					dtrwProdutoRomaneio.nlTipoVolume = nIdTipoVolume;
					dtrwProdutoRomaneio.strTipoPopular = strTipoPopular;
					dtrwProdutoRomaneio.dLargura =  dLargura;
					dtrwProdutoRomaneio.dAltura =  dAltura;
					dtrwProdutoRomaneio.dComprimento = dComprimento;
					dtrwProdutoRomaneio.dVolume = dVolumeCubico;
					dtrwProdutoRomaneio.nUnidadeLargura = nUnidadeMetricaLargura;
					dtrwProdutoRomaneio.nUnidadeAltura =  nUnidadeMetricaAltura;
					dtrwProdutoRomaneio.nUnidadeComprimento = nUnidadeMetricaComprimento; 
					dtrwProdutoRomaneio.nUnidadeVolume = nUnidadeMetricaVolume;

					m_nIdTipoVolumeDefault = nIdTipoVolume;
					m_strDescricaoVolumeDefault = strTipoPopular;

					if (bAdd)
						m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.AddtbProdutosRomaneioSimplificadoRow(dtrwProdutoRomaneio);
					bRetorno = true;
					return(bRetorno);
				}
			#endregion
			#region Banco Dados
				private bool bSalvaDados()
				{
					bool bRetorno = false;
					bRetorno = bSalvaProdutosRomaneio();
					return(bRetorno);
				}

				private bool bSalvaProdutosRomaneio()
				{
					bool bRetorno = false;
					m_cls_dba_ConnectionDB.SetTbProdutosRomaneioSimplificado(m_typDatSetTbProdutosRomaneioSimplificado);
					bRetorno = (m_cls_dba_ConnectionDB.Erro == null);
					return(bRetorno);
				}	
			#endregion
		#endregion

		#region Fatura Comercial
			private void vCarregaDadosFaturaComercial(out string strPesoLiquido,out string strPesoBruto)
			{
				strPesoLiquido = m_dFaturaPesoLiquido.ToString() + " " + clsProdutosRomaneio.strRetornaSiglaUnidadeMassa(ref m_typDatSetTbUnidadesMassa,ref m_typDatSetTbUnidadesMassaIdioma,m_nIdUnidadeMassaFaturaPesoLiquido,m_nIdIdioma);
				strPesoBruto = m_dFaturaPesoBruto.ToString() + " " + clsProdutosRomaneio.strRetornaSiglaUnidadeMassa(ref m_typDatSetTbUnidadesMassa,ref m_typDatSetTbUnidadesMassaIdioma,m_nIdUnidadeMassaFaturaPesoBruto,m_nIdIdioma);
			}
		#endregion
		#region Produtos Fatura
			private double dProdutoFaturaQuantidadeTotal(int nIdOrdem)
			{
				double dRetorno = 0;
                mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial =  m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPe,nIdOrdem);				
				if (dtrwProdutoFaturaComercial != null)
				{
					dRetorno = dtrwProdutoFaturaComercial.dQuantidade;
				}
				return(dRetorno);
			}

			private double dProdutoFaturaQuantidadeRestante(int nIdOrdem)
			{
				double dRetorno = 0;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwRomaneioSimplificado in m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows)
				{
					if ((dtrwRomaneioSimplificado.RowState != System.Data.DataRowState.Deleted) && (dtrwRomaneioSimplificado.nIdOrdemProduto == nIdOrdem))
					{
						dRetorno = System.Math.Round(dRetorno + dtrwRomaneioSimplificado.dQuantidadeProduto,MAXDECIMALS);
					}
				}
				dRetorno = System.Math.Round(dProdutoFaturaQuantidadeTotal(nIdOrdem) - dRetorno,MAXDECIMALS);
				if (dRetorno < 0)
					dRetorno = 0;
 				return(dRetorno);
			}
		#endregion
		#region Romaneio
			private void vCarregaDadosRomaneio(out string strPesoLiquido,out string strPesoBruto)
			{
				double dPesoLiquido = 0;
				double dPesoBruto = 0;
				int nRomaneioPrecisaoPesoLiquidoTotal,nRomaneioPrecisaoPesoBrutoTotal;
				bool bRomaneioPrecisaoPesoLiquidoTotalArredondar,bRomaneioPrecisaoPesoBrutoTotalArredondar;
				clsProdutosRomaneio.vRomaneioCarregaPreferencias(ref m_cls_dba_ConnectionDB,out nRomaneioPrecisaoPesoLiquidoTotal,out nRomaneioPrecisaoPesoBrutoTotal,out bRomaneioPrecisaoPesoLiquidoTotalArredondar,out bRomaneioPrecisaoPesoBrutoTotalArredondar);
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoSimplificado in m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows)
				{
					if (dtrwProdutoSimplificado.RowState != System.Data.DataRowState.Deleted)
					{
						if ((!dtrwProdutoSimplificado.IsdPesoLiquidoUnitarioNull()) && (!dtrwProdutoSimplificado.IsnUnidadeMassaPesoLiquidoNull()))
						{
							if (m_nIdUnidadeMassaFaturaPesoLiquido == dtrwProdutoSimplificado.nUnidadeMassaPesoLiquido)
							{
								dPesoLiquido = System.Math.Round(dPesoLiquido + mdlConversao.clsTruncamento.dTrunca(dtrwProdutoSimplificado.dPesoLiquidoUnitario * dtrwProdutoSimplificado.dQuantidadeProduto,mdlConstantes.clsConstantes.DEFAULT_PRECISAO),8);
							}
							else
							{
								dPesoLiquido = System.Math.Round(dPesoLiquido + mdlConversao.clsTruncamento.dTrunca(((clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesMassa(dtrwProdutoSimplificado.nUnidadeMassaPesoLiquido,m_nIdUnidadeMassaFaturaPesoLiquido)) * dtrwProdutoSimplificado.dPesoLiquidoUnitario) * dtrwProdutoSimplificado.dQuantidadeProduto,mdlConstantes.clsConstantes.DEFAULT_PRECISAO),8);
							}
						}
						if ((!dtrwProdutoSimplificado.IsdPesoBrutoUnitarioNull()) && (!dtrwProdutoSimplificado.IsnUnidadeMassaPesoBrutoNull()))
						{
							if (m_nIdUnidadeMassaFaturaPesoBruto == dtrwProdutoSimplificado.nUnidadeMassaPesoBruto)
							{
								dPesoBruto = System.Math.Round(dPesoBruto + mdlConversao.clsTruncamento.dTrunca(dtrwProdutoSimplificado.dPesoBrutoUnitario * dtrwProdutoSimplificado.dQuantidadeVolumes,mdlConstantes.clsConstantes.DEFAULT_PRECISAO),8);
							}
							else
							{
								dPesoBruto = System.Math.Round(dPesoBruto + mdlConversao.clsTruncamento.dTrunca(((clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesMassa(dtrwProdutoSimplificado.nUnidadeMassaPesoBruto,m_nIdUnidadeMassaFaturaPesoBruto)) * dtrwProdutoSimplificado.dPesoBrutoUnitario) * dtrwProdutoSimplificado.dQuantidadeVolumes,mdlConstantes.clsConstantes.DEFAULT_PRECISAO),8);
							}
						}
					}
				}
				if (bRomaneioPrecisaoPesoLiquidoTotalArredondar)
					strPesoLiquido = System.Math.Round(dPesoLiquido,nRomaneioPrecisaoPesoLiquidoTotal).ToString(clsProdutosRomaneio.strRetornaFormato(nRomaneioPrecisaoPesoLiquidoTotal));
				else
					strPesoLiquido = mdlConversao.clsTruncamento.dRound(dPesoLiquido,nRomaneioPrecisaoPesoLiquidoTotal).ToString(clsProdutosRomaneio.strRetornaFormato(nRomaneioPrecisaoPesoLiquidoTotal));
				if (bRomaneioPrecisaoPesoBrutoTotalArredondar)
					strPesoBruto = System.Math.Round(dPesoBruto,nRomaneioPrecisaoPesoBrutoTotal).ToString(clsProdutosRomaneio.strRetornaFormato(nRomaneioPrecisaoPesoBrutoTotal));
				else
					strPesoBruto = mdlConversao.clsTruncamento.dRound(dPesoLiquido,nRomaneioPrecisaoPesoBrutoTotal).ToString(clsProdutosRomaneio.strRetornaFormato(nRomaneioPrecisaoPesoBrutoTotal));
			}

			private void vCarregaDadosRomaneio(out string strPesoLiquido,out string strPesoBruto,out double dDiferencaPesoLiquido,out double dDiferencaPesoBruto)
			{
				double dPesoLiquido = 0;
				double dPesoBruto = 0;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoSimplificado in m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows)
				{
					if (dtrwProdutoSimplificado.RowState != System.Data.DataRowState.Deleted)
					{
						if ((!dtrwProdutoSimplificado.IsdPesoLiquidoUnitarioNull()) && (!dtrwProdutoSimplificado.IsnUnidadeMassaPesoLiquidoNull()))
						{
							if (m_nIdUnidadeMassaFaturaPesoLiquido == dtrwProdutoSimplificado.nUnidadeMassaPesoLiquido)
							{
								dPesoLiquido = System.Math.Round(dPesoLiquido + mdlConversao.clsTruncamento.dTrunca(dtrwProdutoSimplificado.dPesoLiquidoUnitario * dtrwProdutoSimplificado.dQuantidadeProduto,mdlConstantes.clsConstantes.DEFAULT_PRECISAO),8);
							}
							else
							{
								dPesoLiquido = System.Math.Round(dPesoLiquido + mdlConversao.clsTruncamento.dTrunca(((clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesMassa(dtrwProdutoSimplificado.nUnidadeMassaPesoLiquido,m_nIdUnidadeMassaFaturaPesoLiquido)) * dtrwProdutoSimplificado.dPesoLiquidoUnitario) * dtrwProdutoSimplificado.dQuantidadeProduto,mdlConstantes.clsConstantes.DEFAULT_PRECISAO),8);
							}
						}
						if ((!dtrwProdutoSimplificado.IsdPesoBrutoUnitarioNull()) && (!dtrwProdutoSimplificado.IsnUnidadeMassaPesoBrutoNull()))
						{
							if (m_nIdUnidadeMassaFaturaPesoBruto == dtrwProdutoSimplificado.nUnidadeMassaPesoBruto)
							{
								dPesoBruto = System.Math.Round(dPesoBruto + mdlConversao.clsTruncamento.dTrunca(dtrwProdutoSimplificado.dPesoBrutoUnitario * dtrwProdutoSimplificado.dQuantidadeVolumes,mdlConstantes.clsConstantes.DEFAULT_PRECISAO),8);
							}
							else
							{
								dPesoBruto = System.Math.Round(dPesoBruto + mdlConversao.clsTruncamento.dTrunca(((clsProdutosRomaneio.dRetornaFatorConversaoEntreUnidadesMassa(dtrwProdutoSimplificado.nUnidadeMassaPesoBruto,m_nIdUnidadeMassaFaturaPesoBruto)) * dtrwProdutoSimplificado.dPesoBrutoUnitario) * dtrwProdutoSimplificado.dQuantidadeVolumes,mdlConstantes.clsConstantes.DEFAULT_PRECISAO),8);
							}
						}
					}
				}
				strPesoLiquido = dPesoLiquido.ToString() + " " + clsProdutosRomaneio.strRetornaSiglaUnidadeMassa(ref m_typDatSetTbUnidadesMassa,ref m_typDatSetTbUnidadesMassaIdioma,m_nIdUnidadeMassaFaturaPesoLiquido,m_nIdIdioma);
				strPesoBruto = dPesoBruto.ToString() + " " + clsProdutosRomaneio.strRetornaSiglaUnidadeMassa(ref m_typDatSetTbUnidadesMassa,ref m_typDatSetTbUnidadesMassaIdioma,m_nIdUnidadeMassaFaturaPesoBruto,m_nIdIdioma);
				dDiferencaPesoLiquido = m_dFaturaPesoLiquido - dPesoLiquido;
				dDiferencaPesoBruto = m_dFaturaPesoBruto - dPesoBruto;
			}
		#endregion
		#region Produto Romaneio
			private int nNextProdutoRomaneio()
			{
				int nIndex = 1;
				while(m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.FindByIdExportadoridPEnIdOrdem(m_nIdExportador,m_strIdPe,nIndex) != null)
					nIndex++;
				return(nIndex);
			}
			private double dRetornaQuantidadeProdutoRomaneio(int nIdOrdemRomaneio,int nIdOrdemProdutoFatura)
			{
				double dRetorno = 0;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoRomaneio in m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows)
				{
					if ((dtrwProdutoRomaneio.RowState != System.Data.DataRowState.Deleted) && (dtrwProdutoRomaneio.nIdOrdem == nIdOrdemRomaneio) && (dtrwProdutoRomaneio.nIdOrdemProduto == nIdOrdemProdutoFatura))
						dRetorno = dtrwProdutoRomaneio.dQuantidadeProduto;
				}
				return(dRetorno);
			}

			private bool bTrocaOrdemProdutos(int nIdOrdem1, int nIdOrdem2)
			{
				bool bRetorno = false;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProduto1 = m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.FindByIdExportadoridPEnIdOrdem(m_nIdExportador,m_strIdPe,nIdOrdem1);
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProduto2 = m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.FindByIdExportadoridPEnIdOrdem(m_nIdExportador,m_strIdPe,nIdOrdem2);
				if ((dtrwProduto1 != null) && (dtrwProduto1.RowState != System.Data.DataRowState.Deleted) && (dtrwProduto2 != null) && (dtrwProduto2.RowState != System.Data.DataRowState.Deleted))
				{
					dtrwProduto1.nIdOrdem = -1;
					dtrwProduto2.nIdOrdem = -2;
					vInsereNovaLinha(dtrwProduto1,nIdOrdem2);
					vInsereNovaLinha(dtrwProduto2,nIdOrdem1);
					dtrwProduto1.Delete();
					dtrwProduto2.Delete();
					bRetorno = true;
				}
				return (bRetorno);
			}

			protected void vInsereNovaLinha(System.Data.DataRow dtrwProduto,int nNovoValorColuna)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoNovo = m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.NewtbProdutosRomaneioSimplificadoRow();
				foreach(System.Data.DataColumn dtclColuna in m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Columns)
					dtrwProdutoNovo[dtclColuna] = dtrwProduto[dtclColuna,System.Data.DataRowVersion.Current];
				dtrwProdutoNovo["nIdOrdem"] = nNovoValorColuna;
				m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.AddtbProdutosRomaneioSimplificadoRow(dtrwProdutoNovo);
			}

			private bool bVinculoRemover(int nIdOrdem)
			{
				bool bRetorno = false;
                mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoRomaneio = m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.FindByIdExportadoridPEnIdOrdem(m_nIdExportador,m_strIdPe,nIdOrdem);
				if ((dtrwProdutoRomaneio != null) && (dtrwProdutoRomaneio.RowState != System.Data.DataRowState.Deleted))
				{
					dtrwProdutoRomaneio.Delete();
					bRetorno = true;
				}
				return(bRetorno);
			}
		#endregion
		#region Volumes
			private string strRetornaDescricaoVolume(int nIdVolume)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow dtrwVolume;
				for (int nCont = 0;nCont < m_typDatSetTbVolumes.tbVolumes.Rows.Count;nCont++)
				{
					dtrwVolume = (mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow)m_typDatSetTbVolumes.tbVolumes.Rows[nCont];
					if (dtrwVolume.nIdVolume == nIdVolume)
					{
						if (!dtrwVolume.IsstrDescricaoNull())
							strRetorno = dtrwVolume.strDescricao;
						break;
					}
				}
				return (strRetorno);
			}
		#endregion
		#region Unidades
			private string strRetornaSiglaUnidadeEspaco(int nUnidadeMetrica)
			{
				return(clsProdutosRomaneio.strRetornaSiglaUnidadeMetrica(ref m_typDatSetTbUnidadesEspaco,ref m_typDatSetTbUnidadesEspacoIdioma,nUnidadeMetrica,m_nIdIdioma));
			}

			private string strRetornaSiglaUnidadeMassa(int nUnidadeMassa)
			{
				return(clsProdutosRomaneio.strRetornaSiglaUnidadeMassa(ref m_typDatSetTbUnidadesMassa,ref m_typDatSetTbUnidadesMassaIdioma,nUnidadeMassa,m_nIdIdioma));
			}
		#endregion

		#region Retorno
		public void vRetornaValores(out System.Collections.ArrayList arlVolumes)
		{
			System.Collections.SortedList srtLstVolumes = new System.Collections.SortedList();
			foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProduto in m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows)
			{
				string strTipo = "";
				if (!dtrwProduto.IsstrTipoPopularNull())
					strTipo = dtrwProduto.strTipoPopular;
				if (strTipo == "")
				{
					if (!dtrwProduto.IsnlTipoVolumeNull())
					{
						mdlDataBaseAccess.Tabelas.XsdTbVolumes.tbVolumesRow dtrwVolumes = m_typDatSetTbVolumes.tbVolumes.FindBynIdVolume(dtrwProduto.nlTipoVolume);
						if (dtrwVolumes != null)
						{
							strTipo = dtrwVolumes.strDescricao;
						}
					}
				}
				if (strTipo != "")
				{
					string strOriginal = strTipo;
					while(srtLstVolumes.Contains(strTipo))
						strTipo += "x";
					srtLstVolumes.Add(strTipo,dtrwProduto);
				}
			}
			arlVolumes = new System.Collections.ArrayList();
			for(int i = 0;i < srtLstVolumes.Count;i++)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoInserir = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow)srtLstVolumes.GetByIndex(i);
				if (!dtrwProdutoInserir.IsdQuantidadeVolumesNull())
				{
					for(int j = 0; j < dtrwProdutoInserir.dQuantidadeVolumes;j++)
						arlVolumes.Add(dtrwProdutoInserir.strTipoPopular);
				}
			}
		}

		public void vRetornaValores(UnidadeMedida enumUnidadeMedida,out double dCubagemTotal,out string strUnidadeCubagem)
		{
			dCubagemTotal = 0;
			double dVolume = 0;
			strUnidadeCubagem = strRetornaSiglaUnidadeEspaco((int)enumUnidadeMedida) + "³";
			for(int i = 0; i < m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows.Count;i++)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwVolume = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow)m_typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows[i];
				if (bVolumeCubagem(enumUnidadeMedida,ref dtrwVolume,out dVolume))
					if (!dtrwVolume.IsdQuantidadeVolumesNull())
						dCubagemTotal += System.Math.Round((dVolume * dtrwVolume.dQuantidadeVolumes),3);
			}
		}

		public void vRetornaValores(mdlConstantes.UnidadeMassa enumUnidadeMassaPesoLiquido,out string strPesoLiquido,mdlConstantes.UnidadeMassa enumUnidadeMassaPesoBruto,out string strPesoBruto)
		{
			int nUnidadeMassaPesoLiquidoFatura,nUnidadeMassaPesoBrutoFatura;
			nUnidadeMassaPesoLiquidoFatura = m_nIdUnidadeMassaFaturaPesoLiquido;
			nUnidadeMassaPesoBrutoFatura = m_nIdUnidadeMassaFaturaPesoBruto;
			m_nIdUnidadeMassaFaturaPesoLiquido = (int)enumUnidadeMassaPesoLiquido;
			m_nIdUnidadeMassaFaturaPesoBruto = (int)enumUnidadeMassaPesoBruto;
			vCarregaDadosRomaneio(out strPesoLiquido,out strPesoBruto);
			m_nIdUnidadeMassaFaturaPesoLiquido = nUnidadeMassaPesoLiquidoFatura;
			m_nIdUnidadeMassaFaturaPesoBruto = nUnidadeMassaPesoBrutoFatura;
		}

		#endregion
	}	
}

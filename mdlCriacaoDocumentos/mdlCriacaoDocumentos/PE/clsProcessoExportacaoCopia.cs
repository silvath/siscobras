using System;

namespace mdlCriacaoDocumentos.PE
{
	/// <summary>
	/// Summary description for clsProcessoExportacaoCopia.
	/// </summary>
	public class clsProcessoExportacaoCopia
	{
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
		#endregion
		#region Constructors and Destructors
			public clsProcessoExportacaoCopia(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				m_cls_ter_tratadorErro = cls_ter_tratadorErro;
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
			}
		#endregion

		#region bCopia
			public bool bCopia(int nIdExportador,string strIdPeOriginal,string strIdPeDestino)
			{
				bRemovePe(nIdExportador,strIdPeDestino);

				if (bCopiaPe(nIdExportador,strIdPeOriginal,strIdPeDestino))
				{
					if (bCopiaFaturaProforma(nIdExportador,strIdPeOriginal,strIdPeDestino))
					{
						if (bCopiaFaturaComercial(nIdExportador,strIdPeOriginal,strIdPeDestino))
						{
							if (bCopiaCertificadoOrigem(nIdExportador,strIdPeOriginal,strIdPeDestino))
							{
								if (bCopiaRomaneio(nIdExportador,strIdPeOriginal,strIdPeDestino))
								{
									if (bCopiaSaque(nIdExportador,strIdPeOriginal,strIdPeDestino))
									{
										if (bCopiaInstrucoesEmbarque(nIdExportador,strIdPeOriginal,strIdPeDestino))
										{
											if (bCopiaBordero(nIdExportador,strIdPeOriginal,strIdPeDestino))
											{
												return(bCopiaSumario(nIdExportador,strIdPeOriginal,strIdPeDestino));
											}
										}
									}
								}
							}
						}
					}
				}

				bRemovePe(nIdExportador,strIdPeDestino);
				return(false);
			}

			#region Processo Exportacao (PE)
				private bool bCopiaPe(int nIdExportador,string strIdPeOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdPeOriginal);

					// Pe
					mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetPes.tbPEs.Count == 0)
						return(false);

					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = typDatSetPes.tbPEs.NewtbPEsRow();
					if (bDataRowCopia(typDatSetPes.tbPEs[0],dtrwPe))
					{
						dtrwPe.idPE = strIdPeDestino;
						dtrwPe.dtDataCriacao = System.DateTime.Now;

						// Geral
						dtrwPe.SetbConcluidoNull();

						// RE
						dtrwPe.SetmstrRENull();
						dtrwPe.SetmstrSDNull();
						dtrwPe.SetmstrDSENull();

						// Relatorios
						dtrwPe.SetstrIdConhecimentoEmbarqueNull();
						dtrwPe.SetstrIdSeguroNull();
						dtrwPe.SetstrIdCertificadoPesoNull();
						dtrwPe.SetstrIdCertificadoAnaliseNull();
						dtrwPe.SetstrIdFitossanitarioNull();

						// Carta de Credito
						dtrwPe.SetnIdCartaCreditoNull();
						dtrwPe.SetnCartaCreditoSaldoRestanteNull();

						//Datas
						dtrwPe.dtDataCriacao = System.DateTime.Now;
						dtrwPe.SetdtDataConclusaoNull();
						dtrwPe.SetdtEmissaoRENull();
						dtrwPe.SetdtEmissaoSDNull();
						dtrwPe.SetdtEmissaoDSENull();
						dtrwPe.SetdtEmissaoFitoSanitarioNull();
						dtrwPe.SetdtEmissaoCertificadoPesoNull();
						dtrwPe.SetdtEmissaoCertificadoAnaliseNull();
						dtrwPe.SetdtEmissaoSeguroNull();
						dtrwPe.SetdtEmissaoOrdemCompraNull();

						// Deadlines
						dtrwPe.SetdtAberturaPortaoNull();
						dtrwPe.SetdtDeadlineChegadaPrevistaTransporteNull();
						dtrwPe.SetdtDeadLineEspelhoBLNull();
						dtrwPe.SetdtDeadlineFechamentoPortaoNull();
						dtrwPe.SetdtDeadlineLiberacaoRFNull();
						dtrwPe.SetdtDeadlineListaCargaNull();
						dtrwPe.SetdtDeadlineOutroNull();
						dtrwPe.SetdtDeadlineRetiradaContainerTerminalNull();

						// Armador
						dtrwPe.SetnIdArmadorNull();
						dtrwPe.SetnIdNavioNull();
						dtrwPe.SetnIdTerminalNull();
						dtrwPe.SetnIdTerminalContatoNull();
						dtrwPe.SetmstrViagemNull();

						// Containers
						dtrwPe.SetmstrContainerNumeroNull();
						dtrwPe.SetmstrContainerTipoNull();
						dtrwPe.SetmstrContainerTamanhoNull();
						dtrwPe.SetmstrContainerTaraNull();
						dtrwPe.SetmstrContainerLacreNull();
						dtrwPe.SetmstrContainerLacreArmadorNull();
						dtrwPe.SetmstrContainerExcessoCargaAlturaNull();
						dtrwPe.SetmstrContainerExcessoCargaLarguraNull();
						dtrwPe.SetmstrContainerExcessoCargaComprimentoNull();
						dtrwPe.SetmstrContainerTemperaturaMinimaNull();
						dtrwPe.SetmstrContainerTemperaturaMaximaNull();
						dtrwPe.SetmstrContainerIMONull();
						dtrwPe.SetmstrContainerUNONull();
						dtrwPe.SetmstrContainerISONull();

						typDatSetPes.tbPEs.AddtbPEsRow(dtrwPe);
						m_cls_dba_ConnectionDB.SetTbPes(typDatSetPes);
						return(m_cls_dba_ConnectionDB.Erro == null);
					}else{
						return(false);
					}
   				}
			#endregion
			#region Fatura Proforma
  				private bool bCopiaFaturaProforma(int nIdExportador,string strIdPeOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdPeOriginal);

					// Fatura Proforma
					mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas typDatSetFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetFaturasProformas.tbFaturasProformas.Count == 0)
						return(true);

					mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwFaturaProforma = typDatSetFaturasProformas.tbFaturasProformas.NewtbFaturasProformasRow();
					if (bDataRowCopia(typDatSetFaturasProformas.tbFaturasProformas[0],dtrwFaturaProforma))
					{
						dtrwFaturaProforma.idPE = strIdPeDestino;
						dtrwFaturaProforma.dataEmissao = System.DateTime.Now;

						typDatSetFaturasProformas.tbFaturasProformas.AddtbFaturasProformasRow(dtrwFaturaProforma);
						m_cls_dba_ConnectionDB.SetTbFaturasProformas(typDatSetFaturasProformas);
						if (m_cls_dba_ConnectionDB.Erro == null)
						{
							// Produtos Fatura Proforma
							mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma typDatSetProdutosFaturaProforma = m_cls_dba_ConnectionDB.GetTbProdutosFaturaProforma(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
							for(int i = typDatSetProdutosFaturaProforma.tbProdutosFaturaProforma.Rows.Count - 1; i >= 0; i--)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)typDatSetProdutosFaturaProforma.tbProdutosFaturaProforma.Rows[i];
								mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow dtrwProdutoNovo = typDatSetProdutosFaturaProforma.tbProdutosFaturaProforma.NewtbProdutosFaturaProformaRow();
								if (bDataRowCopia(dtrwProduto,dtrwProdutoNovo))
								{
									dtrwProdutoNovo.idPE = strIdPeDestino;
									typDatSetProdutosFaturaProforma.tbProdutosFaturaProforma.AddtbProdutosFaturaProformaRow(dtrwProdutoNovo);
								}
							}
							m_cls_dba_ConnectionDB.SetTbProdutosFaturaProforma(typDatSetProdutosFaturaProforma);
							if (bCopiaFaturaProformaColunas(nIdExportador,strIdPeOriginal,strIdPeDestino))
								return((bCopiaFaturaProformaProdutosPropriedades(nIdExportador,strIdPeOriginal,strIdPeDestino)));
							return(false);
						}
						else
						{
							return(false);
						}
					}
					else
					{
						return(false);
					}
				}

				private bool bCopiaFaturaProformaColunas(int nIdExportador,string strIdPeOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("strIdPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdPeOriginal);

					mdlDataBaseAccess.Tabelas.XsdTbFaturasProformasColunas typDatSetColunas = m_cls_dba_ConnectionDB.GetTbFaturasProformasColunas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					for(int i = typDatSetColunas.tbFaturasProformasColunas.Rows.Count - 1; i >= 0; i--)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasProformasColunas.tbFaturasProformasColunasRow dtrwColuna = typDatSetColunas.tbFaturasProformasColunas[i];
						mdlDataBaseAccess.Tabelas.XsdTbFaturasProformasColunas.tbFaturasProformasColunasRow dtrwColunaNova = typDatSetColunas.tbFaturasProformasColunas.NewtbFaturasProformasColunasRow();
						if (bDataRowCopia(dtrwColuna,dtrwColunaNova))
						{
							dtrwColunaNova.strIdPe = strIdPeDestino;
							typDatSetColunas.tbFaturasProformasColunas.AddtbFaturasProformasColunasRow(dtrwColunaNova);
						}
					}
					m_cls_dba_ConnectionDB.SetTbFaturasProformasColunas(typDatSetColunas);
					return(true);
				} 

				private bool bCopiaFaturaProformaProdutosPropriedades(int nIdExportador,string strIdPeOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("strIdPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdPeOriginal);

					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades typDatSetPropriedades = m_cls_dba_ConnectionDB.GetTbProdutosFaturaProformaPropriedades(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					for(int i = typDatSetPropriedades.tbProdutosFaturaProformaPropriedades.Rows.Count - 1; i >= 0; i--)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades.tbProdutosFaturaProformaPropriedadesRow dtrwPropriedade = typDatSetPropriedades.tbProdutosFaturaProformaPropriedades[i];
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades.tbProdutosFaturaProformaPropriedadesRow dtrwPropriedadeNova = typDatSetPropriedades.tbProdutosFaturaProformaPropriedades.NewtbProdutosFaturaProformaPropriedadesRow();
						if (bDataRowCopia(dtrwPropriedade,dtrwPropriedadeNova))
						{
							dtrwPropriedadeNova.strIdPe = strIdPeDestino;
							typDatSetPropriedades.tbProdutosFaturaProformaPropriedades.AddtbProdutosFaturaProformaPropriedadesRow(dtrwPropriedadeNova);
						}
					}
					m_cls_dba_ConnectionDB.SetTbProdutosFaturaProformaPropriedades(typDatSetPropriedades);
					return(true);
				} 
			#endregion
			#region Fatura Comercial
				private bool bCopiaFaturaComercial(int nIdExportador,string strIdPeOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdPeOriginal);

					// Fatura Comercial
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetFaturasComerciais.tbFaturasComerciais.Count == 0)
						return(false);

					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = typDatSetFaturasComerciais.tbFaturasComerciais.NewtbFaturasComerciaisRow();
					if (bDataRowCopia(typDatSetFaturasComerciais.tbFaturasComerciais[0],dtrwFaturaComercial))
					{
						dtrwFaturaComercial.idPE = strIdPeDestino;
						dtrwFaturaComercial.dataEmissao = System.DateTime.Now;
						dtrwFaturaComercial.SetnImpressoesNull();
						dtrwFaturaComercial.SetdataEmbarqueNull();
						typDatSetFaturasComerciais.tbFaturasComerciais.AddtbFaturasComerciaisRow(dtrwFaturaComercial);
						m_cls_dba_ConnectionDB.SetTbFaturasComerciais(typDatSetFaturasComerciais);
						if (m_cls_dba_ConnectionDB.Erro == null)
						{
							// Produtos Fatura Comercial
							mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
							for(int i = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count - 1; i >= 0; i--)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[i];
								mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoNovo = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.NewtbProdutosFaturaComercialRow();
								if (bDataRowCopia(dtrwProduto,dtrwProdutoNovo))
								{
									dtrwProdutoNovo.idPE = strIdPeDestino;
									typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.AddtbProdutosFaturaComercialRow(dtrwProdutoNovo);
								}
							}
							m_cls_dba_ConnectionDB.SetTbProdutosFaturaComercial(typDatSetProdutosFaturaComercial);
							if (bCopiaFaturaComercialColunas(nIdExportador,strIdPeOriginal,strIdPeDestino))
								return((bCopiaFaturaComercialProdutosPropriedades(nIdExportador,strIdPeOriginal,strIdPeDestino)));
							return(false);
						}
						else
						{
							return(false);
						}
					}
					else
					{
						return(false);
					}
				}

				private bool bCopiaFaturaComercialColunas(int nIdExportador,string strIdPeOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("strIdPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdPeOriginal);

					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas typDatSetColunas = m_cls_dba_ConnectionDB.GetTbFaturasComerciaisColunas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					for(int i = typDatSetColunas.tbFaturasComerciaisColunas.Rows.Count - 1; i >= 0; i--)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas.tbFaturasComerciaisColunasRow dtrwColuna = typDatSetColunas.tbFaturasComerciaisColunas[i];
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas.tbFaturasComerciaisColunasRow dtrwColunaNova = typDatSetColunas.tbFaturasComerciaisColunas.NewtbFaturasComerciaisColunasRow();
						if (bDataRowCopia(dtrwColuna,dtrwColunaNova))
						{
							dtrwColunaNova.strIdPe = strIdPeDestino;
							typDatSetColunas.tbFaturasComerciaisColunas.AddtbFaturasComerciaisColunasRow(dtrwColunaNova);
						}
					}
					m_cls_dba_ConnectionDB.SetTbFaturasComerciaisColunas(typDatSetColunas);
					return(true);
				} 

				private bool bCopiaFaturaComercialProdutosPropriedades(int nIdExportador,string strIdPeOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("strIdPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdPeOriginal);

					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades typDatSetPropriedades = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercialPropriedades(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					for(int i = typDatSetPropriedades.tbProdutosFaturaComercialPropriedades.Rows.Count - 1; i >= 0; i--)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades.tbProdutosFaturaComercialPropriedadesRow dtrwPropriedade = typDatSetPropriedades.tbProdutosFaturaComercialPropriedades[i];
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades.tbProdutosFaturaComercialPropriedadesRow dtrwPropriedadeNova = typDatSetPropriedades.tbProdutosFaturaComercialPropriedades.NewtbProdutosFaturaComercialPropriedadesRow();
						if (bDataRowCopia(dtrwPropriedade,dtrwPropriedadeNova))
						{
							dtrwPropriedadeNova.strIdPe = strIdPeDestino;
							typDatSetPropriedades.tbProdutosFaturaComercialPropriedades.AddtbProdutosFaturaComercialPropriedadesRow(dtrwPropriedadeNova);
						}
					}
					m_cls_dba_ConnectionDB.SetTbProdutosFaturaComercialPropriedades(typDatSetPropriedades);
					return(true);
				} 
			#endregion
			#region Certificados Origem
				private bool bCopiaCertificadoOrigem(int nIdExportador,string strIdPeOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdPeOriginal);

					// Certificados Origem
					mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetCertificadosOrigem.tbCertificadosOrigem.Count == 0)
						return(true);

					for(int i = typDatSetCertificadosOrigem.tbCertificadosOrigem.Count - 1; i >= 0;i--)
					{
						mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificadoOrigem = typDatSetCertificadosOrigem.tbCertificadosOrigem.NewtbCertificadosOrigemRow();
						if (bDataRowCopia(typDatSetCertificadosOrigem.tbCertificadosOrigem[i],dtrwCertificadoOrigem))
						{
							dtrwCertificadoOrigem.idPE = strIdPeDestino;
							dtrwCertificadoOrigem.dtDataCO = System.DateTime.Now;
							dtrwCertificadoOrigem.SetstrNumeroCertificadoOrigemNull();
							dtrwCertificadoOrigem.SetnImpressoesNull();

							typDatSetCertificadosOrigem.tbCertificadosOrigem.AddtbCertificadosOrigemRow(dtrwCertificadoOrigem);
							m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(typDatSetCertificadosOrigem);
							if (m_cls_dba_ConnectionDB.Erro == null)
							{
								// Produtos Certificado Origem
								mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem typDatSetProdutosCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
								for(int j = typDatSetProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows.Count - 1; j >= 0; j--)
								{
									mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)typDatSetProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows[j];
									if (dtrwCertificadoOrigem.nIdTipoCO == dtrwProduto.idTipoCO)
									{
										mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoNovo = typDatSetProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.NewtbProdutosCertificadoOrigemRow();
										if (bDataRowCopia(dtrwProduto,dtrwProdutoNovo))
										{
											dtrwProdutoNovo.idPE = strIdPeDestino;
											typDatSetProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.AddtbProdutosCertificadoOrigemRow(dtrwProdutoNovo);
										}
									}
								}
								m_cls_dba_ConnectionDB.SetTbProdutosCertificadoOrigem(typDatSetProdutosCertificadoOrigem);
								if (m_cls_dba_ConnectionDB.Erro != null)
									return(false);
							}
							else
							{
								return(false);
							}
						}
						else
						{
							return(false);
						}
					}
					return(true);
				}
			#endregion
			#region Romaneio
				private bool bCopiaRomaneio(int nIdExportador,string strIdPeOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdPeOriginal);

					// Romaneio
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios typDatSetRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetRomaneios.tbRomaneios.Count == 0)
						return(true);

					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = typDatSetRomaneios.tbRomaneios.NewtbRomaneiosRow();
					if (bDataRowCopia(typDatSetRomaneios.tbRomaneios[0],dtrwRomaneio))
					{
						dtrwRomaneio.idPE = strIdPeDestino;
						dtrwRomaneio.dtDataEmissao = System.DateTime.Now;
						dtrwRomaneio.SetnImpressoesNull();

						typDatSetRomaneios.tbRomaneios.AddtbRomaneiosRow(dtrwRomaneio);
						m_cls_dba_ConnectionDB.SetTbRomaneios(typDatSetRomaneios);
						if (m_cls_dba_ConnectionDB.Erro == null)
						{
							// Produtos Romaneios - tbProdutosRomaneioEmbalagens
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetProdutosRomaneioEmbalagens = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioEmbalagens(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
							for(int i = typDatSetProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows.Count - 1; i >= 0; i--)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow)typDatSetProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.Rows[i];
								mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwProdutoNovo = typDatSetProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.NewtbProdutosRomaneioEmbalagensRow();
								if (bDataRowCopia(dtrwProduto,dtrwProdutoNovo))
								{
									dtrwProdutoNovo.idPE = strIdPeDestino;
									typDatSetProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.AddtbProdutosRomaneioEmbalagensRow(dtrwProdutoNovo);
								}
							}
							m_cls_dba_ConnectionDB.SetTbProdutosRomaneioEmbalagens(typDatSetProdutosRomaneioEmbalagens);
							if (m_cls_dba_ConnectionDB.Erro != null)
								return (false);

							// Produtos Romaneios - tbProdutosRomaneioEmbalagensProdutos
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetProdutosRomaneioEmbalagensProdutos = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioEmbalagensProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
							for(int i = typDatSetProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows.Count - 1; i >= 0; i--)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow)typDatSetProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows[i];
								mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutoNovo = typDatSetProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.NewtbProdutosRomaneioEmbalagensProdutosRow();
								if (bDataRowCopia(dtrwProduto,dtrwProdutoNovo))
								{
									dtrwProdutoNovo.idPE = strIdPeDestino;
									typDatSetProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.AddtbProdutosRomaneioEmbalagensProdutosRow(dtrwProdutoNovo);
								}
							}
							m_cls_dba_ConnectionDB.SetTbProdutosRomaneioEmbalagensProdutos(typDatSetProdutosRomaneioEmbalagensProdutos);
							if (m_cls_dba_ConnectionDB.Erro != null)
								return (false);

							// Produtos Romaneios - tbProdutosRomaneioSimplificado
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado typDatSetProdutosRomaneioSimplificado = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioSimplificado(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
							for(int i = typDatSetProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows.Count - 1; i >= 0; i--)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow)typDatSetProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows[i];
								mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoNovo = typDatSetProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.NewtbProdutosRomaneioSimplificadoRow();
								if (bDataRowCopia(dtrwProduto,dtrwProdutoNovo))
								{
									dtrwProdutoNovo.idPE = strIdPeDestino;
									typDatSetProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.AddtbProdutosRomaneioSimplificadoRow(dtrwProdutoNovo);
								}
							}
							m_cls_dba_ConnectionDB.SetTbProdutosRomaneioSimplificado(typDatSetProdutosRomaneioSimplificado);
							if (m_cls_dba_ConnectionDB.Erro != null)
								return (false);

							// Produtos Romaneios - tbProdutosRomaneioVolumes
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetProdutosRomaneioVolumes = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioVolumes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
							for(int i = typDatSetProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows.Count - 1; i >= 0; i--)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow)typDatSetProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.Rows[i];
								mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwProdutoNovo = typDatSetProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.NewtbProdutosRomaneioVolumesRow();
								if (bDataRowCopia(dtrwProduto,dtrwProdutoNovo))
								{
									dtrwProdutoNovo.idPE = strIdPeDestino;
									typDatSetProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.AddtbProdutosRomaneioVolumesRow(dtrwProdutoNovo);
								}
							}
							m_cls_dba_ConnectionDB.SetTbProdutosRomaneioVolumes(typDatSetProdutosRomaneioVolumes);
							if (m_cls_dba_ConnectionDB.Erro != null)
								return (false);

							// Produtos Romaneios - tbProdutosRomaneioVolumesProdutos
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetProdutosRomaneioVolumesProdutos = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioVolumesProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
							for(int i = typDatSetProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows.Count - 1; i >= 0; i--)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow)typDatSetProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows[i];
								mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutoNovo = typDatSetProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.NewtbProdutosRomaneioVolumesProdutosRow();
								if (bDataRowCopia(dtrwProduto,dtrwProdutoNovo))
								{
									dtrwProdutoNovo.idPE = strIdPeDestino;
									typDatSetProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.AddtbProdutosRomaneioVolumesProdutosRow(dtrwProdutoNovo);
								}
							}
							m_cls_dba_ConnectionDB.SetTbProdutosRomaneioVolumesProdutos(typDatSetProdutosRomaneioVolumesProdutos);
							if (m_cls_dba_ConnectionDB.Erro != null)
								return (false);

							// Romaneios Secundarios
							arlCondicaoCampo.Clear();
							arlCondicaoCampo.Add("nIdExportador");
							arlCondicaoCampo.Add("strIdPe");

							mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios typDatSetRomaneiosSecundarios = m_cls_dba_ConnectionDB.GetTbRomaneiosSecundarios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
							for(int i = typDatSetRomaneiosSecundarios.tbRomaneiosSecundarios.Rows.Count - 1; i >= 0; i--)
							{
								mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios.tbRomaneiosSecundariosRow dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios.tbRomaneiosSecundariosRow)typDatSetRomaneiosSecundarios.tbRomaneiosSecundarios.Rows[i];
								mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios.tbRomaneiosSecundariosRow dtrwProdutoNovo = typDatSetRomaneiosSecundarios.tbRomaneiosSecundarios.NewtbRomaneiosSecundariosRow();
								if (bDataRowCopia(dtrwProduto,dtrwProdutoNovo))
								{
									dtrwProdutoNovo.strIdPE = strIdPeDestino;
									typDatSetRomaneiosSecundarios.tbRomaneiosSecundarios.AddtbRomaneiosSecundariosRow(dtrwProdutoNovo);
								}
							}
							m_cls_dba_ConnectionDB.SetTbRomaneiosSecundarios(typDatSetRomaneiosSecundarios);
							return(m_cls_dba_ConnectionDB.Erro == null);
						}
						else
						{
							return(false);
						}
					}
					else
					{
						return(false);
					}
				}
			#endregion
			#region Saque
				private bool bCopiaSaque(int nIdExportador,string strIdPeOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdPeOriginal);

					// Saque
					mdlDataBaseAccess.Tabelas.XsdTbSaques typDatSetSaques = m_cls_dba_ConnectionDB.GetTbSaques(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetSaques.tbSaques.Count == 0)
						return(true);

					mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwSaque = typDatSetSaques.tbSaques.NewtbSaquesRow();
					if (bDataRowCopia(typDatSetSaques.tbSaques[0],dtrwSaque))
					{
						dtrwSaque.idPE = strIdPeDestino;
						dtrwSaque.dtDataEmissao = System.DateTime.Now;
						dtrwSaque.SetstrNumeroSaqueNull();
						dtrwSaque.SetnImpressoesNull();

						typDatSetSaques.tbSaques.AddtbSaquesRow(dtrwSaque);
						m_cls_dba_ConnectionDB.SetTbSaques(typDatSetSaques);
						return(m_cls_dba_ConnectionDB.Erro == null);
					}
					else
					{
						return(false);
					}
				}
			#endregion
			#region Instrucoes Embarque
				private bool bCopiaInstrucoesEmbarque(int nIdExportador,string strIdPeOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdPeOriginal);

					// Instrucoes Embarque
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque typDatSetInstrucoesEmbarque = m_cls_dba_ConnectionDB.GetTbInstrucoesEmbarque(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetInstrucoesEmbarque.tbInstrucoesEmbarque.Count == 0)
						return(true);

					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwInstrucoesEmbarque = typDatSetInstrucoesEmbarque.tbInstrucoesEmbarque.NewtbInstrucoesEmbarqueRow();
					if (bDataRowCopia(typDatSetInstrucoesEmbarque.tbInstrucoesEmbarque[0],dtrwInstrucoesEmbarque))
					{
						dtrwInstrucoesEmbarque.idPE = strIdPeDestino;
						dtrwInstrucoesEmbarque.dtDataEmissao = System.DateTime.Now;
						dtrwInstrucoesEmbarque.SetstrNumeroNull();
						dtrwInstrucoesEmbarque.SetstrNumeroReservaNull();
						dtrwInstrucoesEmbarque.SetdtDeadLineInstrucaoEmbarqueNull();
						dtrwInstrucoesEmbarque.SetdtDeadLineEspelhoNull();
						dtrwInstrucoesEmbarque.SetdtDeadLineLiberacaoNull();
						dtrwInstrucoesEmbarque.SetdtReservaNull();
						dtrwInstrucoesEmbarque.SetnImpressoesNull();

						typDatSetInstrucoesEmbarque.tbInstrucoesEmbarque.AddtbInstrucoesEmbarqueRow(dtrwInstrucoesEmbarque);
						m_cls_dba_ConnectionDB.SetTbInstrucoesEmbarque(typDatSetInstrucoesEmbarque);
						return(m_cls_dba_ConnectionDB.Erro == null);
					}
					else
					{
						return(false);
					}
				}
			#endregion
			#region Bordero
				private bool bCopiaBordero(int nIdExportador,string strIdPeOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdPeOriginal);

					// Bordero
					mdlDataBaseAccess.Tabelas.XsdTbBorderos typDatSetBorderos = m_cls_dba_ConnectionDB.GetTbBorderos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetBorderos.tbBorderos.Count == 0)
						return(true);

					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwBordero = typDatSetBorderos.tbBorderos.NewtbBorderosRow();
					if (bDataRowCopia(typDatSetBorderos.tbBorderos[0],dtrwBordero))
					{
						dtrwBordero.idPE = strIdPeDestino;
						dtrwBordero.dtDataEmissao = System.DateTime.Now;
						dtrwBordero.SetnImpressoesNull();

						typDatSetBorderos.tbBorderos.AddtbBorderosRow(dtrwBordero);
						m_cls_dba_ConnectionDB.SetTbBorderos(typDatSetBorderos);
						if (m_cls_dba_ConnectionDB.Erro == null)
						{
							// Borderos Secundarios
							arlCondicaoCampo.Clear();
							arlCondicaoCampo.Add("nIdExportador");
							arlCondicaoCampo.Add("strIdPe");
							mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios typDatSetBorderosSecundarios = m_cls_dba_ConnectionDB.GetTbBorderosSecundarios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
							for(int i = typDatSetBorderosSecundarios.tbBorderosSecundarios.Rows.Count - 1; i >= 0; i--)
							{
								mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow)typDatSetBorderosSecundarios.tbBorderosSecundarios.Rows[i];
								mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow dtrwProdutoNovo = typDatSetBorderosSecundarios.tbBorderosSecundarios.NewtbBorderosSecundariosRow();
								if (bDataRowCopia(dtrwProduto,dtrwProdutoNovo))
								{
									dtrwProdutoNovo.strIdPE = strIdPeDestino;
									typDatSetBorderosSecundarios.tbBorderosSecundarios.AddtbBorderosSecundariosRow(dtrwProdutoNovo);
								}
							}
							m_cls_dba_ConnectionDB.SetTbBorderosSecundarios(typDatSetBorderosSecundarios);
							return(m_cls_dba_ConnectionDB.Erro == null);
						}
						else
						{
							return(false);
						}
					}
					else
					{
						return(false);
					}
				}
			#endregion
			#region Sumario
				private bool bCopiaSumario(int nIdExportador,string strIdPeOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdPeOriginal);

					// Sumario
					mdlDataBaseAccess.Tabelas.XsdTbSumarios typDatSetSumarios = m_cls_dba_ConnectionDB.GetTbSumarios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetSumarios.tbSumarios.Count == 0)
						return(true);

					mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow dtrwSumario = typDatSetSumarios.tbSumarios.NewtbSumariosRow();
					if (bDataRowCopia(typDatSetSumarios.tbSumarios[0],dtrwSumario))
					{
						dtrwSumario.idPE = strIdPeDestino;
						dtrwSumario.dtEmissao = System.DateTime.Now;
						dtrwSumario.SetnImpressoesNull();

						typDatSetSumarios.tbSumarios.AddtbSumariosRow(dtrwSumario);
						m_cls_dba_ConnectionDB.SetTbSumarios(typDatSetSumarios);
						return(m_cls_dba_ConnectionDB.Erro == null);
					}
					else
					{
						return(false);
					}
				}
			#endregion
		#endregion
		#region bCopiaCotacao
			public bool bCopiaCotacao(int nIdExportador,string strIdCotacaoOriginal,string strIdPeDestino)
			{
				bool bRetorno = false;

				bRemovePe(nIdExportador,strIdPeDestino);

				if (bCopiaPeCotacao(nIdExportador,strIdCotacaoOriginal,strIdPeDestino))
					if (bCopiaFaturaProformaCotacao(nIdExportador,strIdCotacaoOriginal,strIdPeDestino))
						if (bRetorno = bCopiaFaturaComercialCotacao(nIdExportador,strIdCotacaoOriginal,strIdPeDestino))
							bRemoveCotacao(nIdExportador,strIdCotacaoOriginal);
				return(bRetorno);
			}

			#region ProcessoExportacao (PE)
				private bool bCopiaPeCotacao(int nIdExportador,string strIdCotacaoOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					// Cotacao
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("idCotacao");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdCotacaoOriginal);

					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes typDatSetCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetCotacoes.tbFaturasCotacoes.Count == 0)
						return(false);
					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwFaturaCotacao = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)typDatSetCotacoes.tbFaturasCotacoes[0];

					// Processo Exportacao
					arlCondicaoCampo.Clear();
					arlCondicaoComparador.Clear();
					arlCondicaoValor.Clear();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdPeDestino);

					mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetPes.tbPEs.Count > 0)
						return(false);

					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = typDatSetPes.tbPEs.NewtbPEsRow();
					dtrwPe.idExportador = nIdExportador;
					dtrwPe.idPE = strIdPeDestino;
					dtrwPe.dtDataCriacao = System.DateTime.Now;
					if (!dtrwFaturaCotacao.IsnIdConsignatarioNull())
						dtrwPe.nIdConsignatario = dtrwFaturaCotacao.nIdConsignatario;
					typDatSetPes.tbPEs.AddtbPEsRow(dtrwPe);
					m_cls_dba_ConnectionDB.SetTbPes(typDatSetPes);
					return(m_cls_dba_ConnectionDB.Erro == null);
				}
			#endregion
			#region Fatura Proforma
				private bool bCopiaFaturaProformaCotacao(int nIdExportador,string strIdCotacaoOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					// Cotacao
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("idCotacao");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdCotacaoOriginal);

					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes typDatSetCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetCotacoes.tbFaturasCotacoes.Count == 0)
						return(false);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao typDatSetProdutosCotacao = m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacao(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					// Fatura Proforma
					arlCondicaoCampo.Clear();
					arlCondicaoValor.Clear();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoCampo.Add("idPe");
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoValor.Add(strIdPeDestino);

					mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas typDatSetFaturaProforma = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetFaturaProforma.tbFaturasProformas.Count > 0)
						return(false);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma typDatSetProdutosFaturaProforma = m_cls_dba_ConnectionDB.GetTbProdutosFaturaProforma(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwFaturaProforma = typDatSetFaturaProforma.tbFaturasProformas.NewtbFaturasProformasRow();
					if (bDataRowCopia(typDatSetCotacoes.tbFaturasCotacoes[0],dtrwFaturaProforma))
					{
						dtrwFaturaProforma.idPE = strIdPeDestino;
						dtrwFaturaProforma.dataEmissao = System.DateTime.Now;
						dtrwFaturaProforma.numeroFatura = typDatSetCotacoes.tbFaturasCotacoes[0].mstrNumero;

						typDatSetFaturaProforma.tbFaturasProformas.AddtbFaturasProformasRow(dtrwFaturaProforma);
						m_cls_dba_ConnectionDB.SetTbFaturasProformas(typDatSetFaturaProforma);
						if (m_cls_dba_ConnectionDB.Erro == null)
						{
							// Produtos Fatura Proforma
							for(int i = typDatSetProdutosCotacao.tbProdutosFaturaCotacao.Rows.Count - 1; i >= 0; i--)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwProdutoCotacao = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)typDatSetProdutosCotacao.tbProdutosFaturaCotacao.Rows[i];
								mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow dtrwProdutoNovo = typDatSetProdutosFaturaProforma.tbProdutosFaturaProforma.NewtbProdutosFaturaProformaRow();
								if (bDataRowCopia(dtrwProdutoCotacao,dtrwProdutoNovo))
								{
									dtrwProdutoNovo.idPE = strIdPeDestino;
									typDatSetProdutosFaturaProforma.tbProdutosFaturaProforma.AddtbProdutosFaturaProformaRow(dtrwProdutoNovo);
								}
							}
							m_cls_dba_ConnectionDB.SetTbProdutosFaturaProforma(typDatSetProdutosFaturaProforma);
							if (bCopiaFaturaProformaCotacaoColunas(nIdExportador,strIdCotacaoOriginal,strIdPeDestino))
								return(bCopiaFaturaProformaCotacaoPropriedadesProdutos(nIdExportador,strIdCotacaoOriginal,strIdPeDestino));
							return(false);
						}else{
							return(false);
						}
					}
					else
					{
						return(false);
					}
				}

				private bool bCopiaFaturaProformaCotacaoColunas(int nIdExportador,string strIdCotacaoOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					// Cotacao
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
                    
					arlCondicaoCampo.Add("strIdCotacao");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdCotacaoOriginal);

					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas typDatSetFaturasCotacoesColunas = m_cls_dba_ConnectionDB.GetTbFaturasCotacoesColunas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					// Proforma 
					arlCondicaoCampo.Clear();
					arlCondicaoValor.Clear();
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("strIdPe");
					arlCondicaoCampo.Add(strIdPeDestino);
					mdlDataBaseAccess.Tabelas.XsdTbFaturasProformasColunas typDatSetFaturasProformasColunas = m_cls_dba_ConnectionDB.GetTbFaturasProformasColunas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					for(int i = 0; i < typDatSetFaturasCotacoesColunas.tbFaturasCotacoesColunas.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas.tbFaturasCotacoesColunasRow dtrwCotacaoColuna = typDatSetFaturasCotacoesColunas.tbFaturasCotacoesColunas[i];
						mdlDataBaseAccess.Tabelas.XsdTbFaturasProformasColunas.tbFaturasProformasColunasRow dtrwProformaColuna = typDatSetFaturasProformasColunas.tbFaturasProformasColunas.NewtbFaturasProformasColunasRow();
						if (bDataRowCopia(dtrwCotacaoColuna,dtrwProformaColuna))
						{
							dtrwProformaColuna.strIdPe = strIdPeDestino;
							typDatSetFaturasProformasColunas.tbFaturasProformasColunas.AddtbFaturasProformasColunasRow(dtrwProformaColuna);
						}
					}
					m_cls_dba_ConnectionDB.SetTbFaturasProformasColunas(typDatSetFaturasProformasColunas);
					return(true);
				}

				private bool bCopiaFaturaProformaCotacaoPropriedadesProdutos(int nIdExportador,string strIdCotacaoOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					// Cotacao
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
                    
					arlCondicaoCampo.Add("strIdCotacao");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdCotacaoOriginal);

					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades typDatSetProdutosFaturaCotacaoPropriedades = m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacaoPropriedades(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					// Proforma 
					arlCondicaoCampo.Clear();
					arlCondicaoValor.Clear();
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("strIdPe");
					arlCondicaoCampo.Add(strIdPeDestino);

					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades typDatSetProdutosFaturaProformaPropriedades = m_cls_dba_ConnectionDB.GetTbProdutosFaturaProformaPropriedades(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					for(int i = 0; i < typDatSetProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedades.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedadesRow dtrwCotacaoPropriedade = typDatSetProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedades[i];
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades.tbProdutosFaturaProformaPropriedadesRow dtrwProformaPropriedade = typDatSetProdutosFaturaProformaPropriedades.tbProdutosFaturaProformaPropriedades.NewtbProdutosFaturaProformaPropriedadesRow();
						if (bDataRowCopia(dtrwCotacaoPropriedade,dtrwProformaPropriedade))
						{
							dtrwProformaPropriedade.strIdPe = strIdPeDestino;
							typDatSetProdutosFaturaProformaPropriedades.tbProdutosFaturaProformaPropriedades.AddtbProdutosFaturaProformaPropriedadesRow(dtrwProformaPropriedade);
						}
					}
					m_cls_dba_ConnectionDB.SetTbProdutosFaturaProformaPropriedades(typDatSetProdutosFaturaProformaPropriedades);
					return(true);
				}
			#endregion
			#region Fatura Comercial
				private bool bCopiaFaturaComercialCotacao(int nIdExportador,string strIdCotacaoOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					// Cotacao
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("idCotacao");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdCotacaoOriginal);

					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes typDatSetCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetCotacoes.tbFaturasCotacoes.Count == 0)
						return(false);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao typDatSetProdutosCotacao = m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacao(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					// Fatura Comercial
					arlCondicaoCampo.Clear();
					arlCondicaoValor.Clear();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoCampo.Add("idPe");
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoValor.Add(strIdPeDestino);

					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturaComercial = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetFaturaComercial.tbFaturasComerciais.Count > 0)
						return(false);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = typDatSetFaturaComercial.tbFaturasComerciais.NewtbFaturasComerciaisRow();
					if (bDataRowCopia(typDatSetCotacoes.tbFaturasCotacoes[0],dtrwFaturaComercial))
					{
						dtrwFaturaComercial.idPE = strIdPeDestino;
						dtrwFaturaComercial.dataEmissao = System.DateTime.Now;

						typDatSetFaturaComercial.tbFaturasComerciais.AddtbFaturasComerciaisRow(dtrwFaturaComercial);
						m_cls_dba_ConnectionDB.SetTbFaturasComerciais(typDatSetFaturaComercial);
						if(m_cls_dba_ConnectionDB.Erro == null)
						{
							// Produtos Fatura Comercial
							for(int i = typDatSetProdutosCotacao.tbProdutosFaturaCotacao.Rows.Count - 1; i >= 0; i--)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwProdutoCotacao = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)typDatSetProdutosCotacao.tbProdutosFaturaCotacao.Rows[i];
								mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoNovo = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.NewtbProdutosFaturaComercialRow();
								if (bDataRowCopia(dtrwProdutoCotacao,dtrwProdutoNovo))
								{
									dtrwProdutoNovo.idPE = strIdPeDestino;
									typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.AddtbProdutosFaturaComercialRow(dtrwProdutoNovo);
								}
							}
							m_cls_dba_ConnectionDB.SetTbProdutosFaturaComercial(typDatSetProdutosFaturaComercial);
							if (bCopiaFaturaComercialCotacaoColunas(nIdExportador,strIdCotacaoOriginal,strIdPeDestino))
								return(bCopiaFaturaComercialCotacaoPropriedadesProdutos(nIdExportador,strIdCotacaoOriginal,strIdPeDestino));
							return(false);
						}else{
							return(false);
						}
					}
					else
					{
						return(false);
					}
				}

				private bool bCopiaFaturaComercialCotacaoColunas(int nIdExportador,string strIdCotacaoOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					// Cotacao
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
                    
					arlCondicaoCampo.Add("strIdCotacao");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdCotacaoOriginal);

					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas typDatSetFaturasCotacoesColunas = m_cls_dba_ConnectionDB.GetTbFaturasCotacoesColunas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					// Comercial 
					arlCondicaoCampo.Clear();
					arlCondicaoValor.Clear();
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("strIdPe");
					arlCondicaoCampo.Add(strIdPeDestino);
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas typDatSetFaturasComerciaisColunas = m_cls_dba_ConnectionDB.GetTbFaturasComerciaisColunas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					for(int i = 0; i < typDatSetFaturasCotacoesColunas.tbFaturasCotacoesColunas.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas.tbFaturasCotacoesColunasRow dtrwCotacaoColuna = typDatSetFaturasCotacoesColunas.tbFaturasCotacoesColunas[i];
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas.tbFaturasComerciaisColunasRow dtrwComercialColuna = typDatSetFaturasComerciaisColunas.tbFaturasComerciaisColunas.NewtbFaturasComerciaisColunasRow();
						if (bDataRowCopia(dtrwCotacaoColuna,dtrwComercialColuna))
						{
							dtrwComercialColuna.strIdPe = strIdPeDestino;
							typDatSetFaturasComerciaisColunas.tbFaturasComerciaisColunas.AddtbFaturasComerciaisColunasRow(dtrwComercialColuna);
						}
					}
					m_cls_dba_ConnectionDB.SetTbFaturasComerciaisColunas(typDatSetFaturasComerciaisColunas);
					return(true);
				}

				private bool bCopiaFaturaComercialCotacaoPropriedadesProdutos(int nIdExportador,string strIdCotacaoOriginal,string strIdPeDestino)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					// Cotacao
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
                    
					arlCondicaoCampo.Add("strIdCotacao");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdCotacaoOriginal);

					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades typDatSetProdutosFaturaCotacaoPropriedades = m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacaoPropriedades(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					// Comercial 
					arlCondicaoCampo.Clear();
					arlCondicaoValor.Clear();
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("strIdPe");
					arlCondicaoCampo.Add(strIdPeDestino);

					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades typDatSetProdutosFaturaComercialPropriedades = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercialPropriedades(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					for(int i = 0; i < typDatSetProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedades.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedadesRow dtrwCotacaoPropriedade = typDatSetProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedades[i];
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades.tbProdutosFaturaComercialPropriedadesRow dtrwComercialPropriedade = typDatSetProdutosFaturaComercialPropriedades.tbProdutosFaturaComercialPropriedades.NewtbProdutosFaturaComercialPropriedadesRow();
						if (bDataRowCopia(dtrwCotacaoPropriedade,dtrwComercialPropriedade))
						{
							dtrwComercialPropriedade.strIdPe = strIdPeDestino;
							typDatSetProdutosFaturaComercialPropriedades.tbProdutosFaturaComercialPropriedades.AddtbProdutosFaturaComercialPropriedadesRow(dtrwComercialPropriedade);
						}
					}
					m_cls_dba_ConnectionDB.SetTbProdutosFaturaComercialPropriedades(typDatSetProdutosFaturaComercialPropriedades);
					return(true);
				}
			#endregion
		#endregion
		#region bCopiaCotacaoCotacao
			public bool bCopiaCotacaoCotacao(int nIdExportador,string strIdCotacaoOriginal,string strIdCotacaoDestino,string strNumeroCotacao)
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCotacaoOriginal);

				// Fatura Cotacao
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes typDatSetFaturaCotacao = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetFaturaCotacao.tbFaturasCotacoes.Count == 0)
					return(false);

				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwFaturaCotacao = typDatSetFaturaCotacao.tbFaturasCotacoes.NewtbFaturasCotacoesRow();
				if (bDataRowCopia(typDatSetFaturaCotacao.tbFaturasCotacoes[0],dtrwFaturaCotacao))
				{
					dtrwFaturaCotacao.idCotacao = strIdCotacaoDestino;
					dtrwFaturaCotacao.mstrNumero = strNumeroCotacao;
					dtrwFaturaCotacao.dataEmissao = System.DateTime.Now;
					typDatSetFaturaCotacao.tbFaturasCotacoes.AddtbFaturasCotacoesRow(dtrwFaturaCotacao);
					m_cls_dba_ConnectionDB.SetTbFaturasCotacoes(typDatSetFaturaCotacao);
					if (m_cls_dba_ConnectionDB.Erro != null)
						return(false);
					if (bCopiaCotacaoCotacaoProdutos(nIdExportador,strIdCotacaoOriginal,strIdCotacaoDestino))
						if (bCopiaCotacaoCotacaoColunas(nIdExportador,strIdCotacaoOriginal,strIdCotacaoDestino))
							return(bCopiaCotacaoCotacaoPropriedadesProdutos(nIdExportador,strIdCotacaoOriginal,strIdCotacaoDestino));
					return(false);
				}else{
					return(false);
				}
			}

			private bool bCopiaCotacaoCotacaoProdutos(int nIdExportador,string strIdCotacaoOriginal,string strIdCotacaoDestino)
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCotacaoOriginal);

				// Produtos Cotacao
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao typDatSetProdutos = m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacao(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				for(int i = typDatSetProdutos.tbProdutosFaturaCotacao.Rows.Count - 1; i >= 0; i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)typDatSetProdutos.tbProdutosFaturaCotacao.Rows[i];
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwProdutoNovo = typDatSetProdutos.tbProdutosFaturaCotacao.NewtbProdutosFaturaCotacaoRow();
					if (bDataRowCopia(dtrwProduto,dtrwProdutoNovo))
					{
						dtrwProdutoNovo.idCotacao = strIdCotacaoDestino;
						typDatSetProdutos.tbProdutosFaturaCotacao.AddtbProdutosFaturaCotacaoRow(dtrwProdutoNovo);
					}
				}
				m_cls_dba_ConnectionDB.SetTbProdutosFaturaCotacao(typDatSetProdutos);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool bCopiaCotacaoCotacaoColunas(int nIdExportador,string strIdCotacaoOriginal,string strIdCotacaoDestino)
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				// Cotacao
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
                    
				arlCondicaoCampo.Add("strIdCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCotacaoOriginal);

				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas typDatSetFaturasCotacoesColunas = m_cls_dba_ConnectionDB.GetTbFaturasCotacoesColunas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				for(int i = (typDatSetFaturasCotacoesColunas.tbFaturasCotacoesColunas.Count - 1); i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas.tbFaturasCotacoesColunasRow dtrwCotacaoColuna = typDatSetFaturasCotacoesColunas.tbFaturasCotacoesColunas[i];
					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas.tbFaturasCotacoesColunasRow dtrwCotacaoColunaNew = typDatSetFaturasCotacoesColunas.tbFaturasCotacoesColunas.NewtbFaturasCotacoesColunasRow();
					if (bDataRowCopia(dtrwCotacaoColuna,dtrwCotacaoColunaNew))
					{
						dtrwCotacaoColunaNew.strIdCotacao = strIdCotacaoDestino;
						typDatSetFaturasCotacoesColunas.tbFaturasCotacoesColunas.AddtbFaturasCotacoesColunasRow(dtrwCotacaoColunaNew);
					}
				}
				m_cls_dba_ConnectionDB.SetTbFaturasCotacoesColunas(typDatSetFaturasCotacoesColunas);
				return(true);
			}

			private bool bCopiaCotacaoCotacaoPropriedadesProdutos(int nIdExportador,string strIdCotacaoOriginal,string strIdCotacaoDestino)
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				// Cotacao
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
                    
				arlCondicaoCampo.Add("strIdCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCotacaoOriginal);

				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades typDatSetProdutosFaturaCotacaoPropriedades = m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacaoPropriedades(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				for(int i = (typDatSetProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedades.Count - 1); i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedadesRow dtrwCotacaoPropriedade = typDatSetProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedades[i];
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedadesRow dtrwCotacaoPropriedadeNew = typDatSetProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedades.NewtbProdutosFaturaCotacaoPropriedadesRow();
					if (bDataRowCopia(dtrwCotacaoPropriedade,dtrwCotacaoPropriedadeNew))
					{
						dtrwCotacaoPropriedadeNew.strIdCotacao = strIdCotacaoDestino;
						typDatSetProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedades.AddtbProdutosFaturaCotacaoPropriedadesRow(dtrwCotacaoPropriedadeNew);
					}
				}
				m_cls_dba_ConnectionDB.SetTbProdutosFaturaCotacaoPropriedades(typDatSetProdutosFaturaCotacaoPropriedades);
				return(true);
			}
		#endregion

		#region bRemoveCotacao
			public bool bRemoveCotacao(int nIdExportador,string strIdCotacao)
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCotacao);

				// Cotacao
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes typDatSetCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetCotacoes.tbFaturasCotacoes.Count != 0)
				{
					typDatSetCotacoes.tbFaturasCotacoes[0].Delete();
					bool bCheckIntegrityUpdate = m_cls_dba_ConnectionDB.CheckIntegrityUpdate;
					m_cls_dba_ConnectionDB.CheckIntegrityUpdate = true;
					m_cls_dba_ConnectionDB.SetTbFaturasCotacoes(typDatSetCotacoes);
					m_cls_dba_ConnectionDB.CheckIntegrityUpdate = bCheckIntegrityUpdate;
					return(m_cls_dba_ConnectionDB.Erro == null);
				}
				else
				{
					return(false);
				}
			}
		#endregion
		#region bRemovePe
			public bool bRemovePe(int nIdExportador,string strIdPe)
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdPe);

				// Pe
				mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetPes.tbPEs.Count != 0)
				{
					typDatSetPes.tbPEs[0].Delete();
					bool bCheckIntegrityUpdate = m_cls_dba_ConnectionDB.CheckIntegrityUpdate;
					m_cls_dba_ConnectionDB.CheckIntegrityUpdate = true;
					m_cls_dba_ConnectionDB.SetTbPes(typDatSetPes);
					m_cls_dba_ConnectionDB.CheckIntegrityUpdate = bCheckIntegrityUpdate;
					return(m_cls_dba_ConnectionDB.Erro == null);
				}else{
					return(false);
				}
			}
		#endregion

		#region DataRowCopia
			private bool bDataRowCopia(System.Data.DataRow dtrwOriginal,System.Data.DataRow dtrwDestino)
			{
				foreach(System.Data.DataColumn dtclColuna in dtrwOriginal.Table.Columns)
				{
					if ((!dtrwOriginal.IsNull(dtclColuna)) && (dtrwDestino.Table.Columns.Contains(dtclColuna.ColumnName)))
						dtrwDestino[dtclColuna.ColumnName] = dtrwOriginal[dtclColuna];
				}
				return(true);
			}
		#endregion

	}
}
